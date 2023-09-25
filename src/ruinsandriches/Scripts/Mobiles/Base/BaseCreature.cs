using System;
using System.Collections.Generic;
using System.Collections;
using Server.Regions;
using Server.Targeting;
using Server.Network;
using Server.Multis;
using Server.Spells;
using Server.Misc;
using Server.Items;
using Server.ContextMenus;
using Server.Engines.Quests;
using Server.Engines.PartySystem;
using Server.Factions;
using Server.Spells.Bushido;
using Server.Spells.Necromancy;
using Server.Spells.Elementalism;
using System.Text;
using Server;
using System.IO;

namespace Server.Mobiles
{
	#region Enums
	/// <summary>
	/// Summary description for MobileAI.
	/// </summary>
	///
	public enum FightMode
	{
		None,			// Never focus on others
		Aggressor,		// Only attack aggressors
		Strongest,		// Attack the strongest
		Weakest,		// Attack the weakest
		Closest, 		// Attack the closest
		Evil,			// Only attack aggressor -or- negative karma
		Good,			// Only attack aggressor -or- positive karma
		CharmMonster,
		CharmAnimal
	}

	public enum OrderType
	{
		None,			//When no order, let's roam
		Come,			//"(All/Name) come"  Summons all or one pet to your location.
		Drop,			//"(Name) drop"  Drops its loot to the ground (if it carries any).
		Follow,			//"(Name) follow"  Follows targeted being.
						//"(All/Name) follow me"  Makes all or one pet follow you.
		Friend,			//"(Name) friend"  Allows targeted player to confirm resurrection.
		Unfriend,		// Remove a friend
		Guard,			//"(Name) guard"  Makes the specified pet guard you. Pets can only guard their owner.
						//"(All/Name) guard me"  Makes all or one pet guard you.
		Attack,			//"(All/Name) kill",
						//"(All/Name) attack"  All or the specified pet(s) currently under your control attack the target.
		Patrol,			//"(Name) patrol"  Roves between two or more guarded targets.
		Release,		//"(Name) release"  Releases pet back into the wild (removes "tame" status).
		Stay,			//"(All/Name) stay" All or the specified pet(s) will stop and stay in current spot.
		Stop,			//"(All/Name) stop Cancels any current orders to attack, guard or follow.
		Transfer		//"(Name) transfer" Transfers complete ownership to targeted player.
	}

	[Flags]
	public enum FoodType
	{
		None			= 0x0000,
		Meat			= 0x0001,
		FruitsAndVegies	= 0x0002,
		GrainsAndHay	= 0x0004,
		Fish			= 0x0008,
		Eggs			= 0x0010,
		Gold			= 0x0020,
		Fire			= 0x0040,
		Gems			= 0x0080,
		Nox				= 0x0100,
		Sea				= 0x0200,
		Moon			= 0x0400
	}

	[Flags]
	public enum PackInstinct
	{
		None			= 0x0000,
		Canine			= 0x0001,
		Ostard			= 0x0002,
		Feline			= 0x0004,
		Arachnid		= 0x0008,
		Daemon			= 0x0010,
		Bear			= 0x0020,
		Equine			= 0x0040,
		Bull			= 0x0080
	}

	public enum ScaleType
	{
		Red,
		Yellow,
		Black,
		Green,
		White,
		Blue,
		Dinosaur,
		All
	}

	public enum MeatType
	{
		Ribs,
		Bird,
		LambLeg,
		Fish,
		Pigs
	}

	public enum FurType
	{
		Regular,
		White
	}

	public enum HideType
	{
		Regular,
		Spined,
		Horned,
		Barbed,
		Necrotic,
		Volcanic,
		Frozen,
		Goliath,
		Draconic,
		Hellish,
		Dinosaur,
		Alien
	}

	#endregion

	public class DamageStore : IComparable
	{
		public Mobile m_Mobile;
		public int m_Damage;
		public bool m_HasRight;

		public DamageStore( Mobile m, int damage )
		{
			m_Mobile = m;
			m_Damage = damage;
		}

		public int CompareTo( object obj )
		{
			DamageStore ds = (DamageStore)obj;

			return ds.m_Damage - m_Damage;
		}
	}

	[AttributeUsage( AttributeTargets.Class )]
	public class FriendlyNameAttribute : Attribute
	{
		//future use: Talisman 'Protection/Bonus vs. Specific Creature
		private TextDefinition m_FriendlyName;

		public TextDefinition FriendlyName
		{
			get
			{
				return m_FriendlyName;
			}
		}

		public FriendlyNameAttribute( TextDefinition friendlyName )
		{
			m_FriendlyName = friendlyName;
		}

		public static TextDefinition GetFriendlyNameFor( Type t )
		{
			if( t.IsDefined( typeof( FriendlyNameAttribute ), false ) )
			{
				object[] objs = t.GetCustomAttributes( typeof( FriendlyNameAttribute ), false );

				if( objs != null && objs.Length > 0 )
				{
					FriendlyNameAttribute friendly = objs[0] as FriendlyNameAttribute;

					return friendly.FriendlyName;
				}
			}

			return t.Name;
		}
	}

	public class BaseCreature : Mobile, IHonorTarget
	{
		public const int MaxLoyalty = 100;

		#region Var declarations
		private BaseAI	m_AI;					// THE AI

		private AIType	m_CurrentAI;			// The current AI
		private AIType	m_DefaultAI;			// The default AI

		private Mobile	m_FocusMob;				// Use focus mob instead of combatant, maybe we don't whan to fight
		private FightMode m_FightMode;			// The style the mob uses

		private int		m_iRangePerception;		// The view area
		private int		m_iRangeFight;			// The fight distance

		private bool	m_bDebugAI;				// Show debug AI messages

		private int		m_iTeam;				// Monster Team

		private double	m_dActiveSpeed;			// Timer speed when active
		private double	m_dPassiveSpeed;		// Timer speed when not active
		private double	m_dCurrentSpeed;		// The current speed, lets say it could be changed by something;

		private Point3D m_pHome;				// The home position of the creature, used by some AI
		private int		m_iRangeHome = 10;		// The home range of the creature

		List<Type>		m_arSpellAttack;		// List of attack spell/power
		List<Type>		m_arSpellDefense;		// List of defensive spell/power

		private bool		m_bControlled;		// Is controlled
		private Mobile		m_ControlMaster;	// My master
		private Mobile		m_ControlTarget;	// My target mobile
		private Point3D		m_ControlDest;		// My target destination (patrol)
		private OrderType	m_ControlOrder;		// My order

		private int			m_Loyalty;

		private double		m_dMinTameSkill;
		private bool		m_bTamable;

		private bool		m_bSummoned = false;
		private DateTime	m_SummonEnd;
		private int			m_iControlSlots = 1;

		private bool		m_bBardProvoked = false;
		private bool		m_bBardPacified = false;
		private Mobile		m_bBardMaster = null;
		private Mobile		m_bBardTarget = null;
		private DateTime	m_timeBardEnd;
		private WayPoint	m_CurrentWayPoint = null;
		private IPoint2D	m_TargetLocation = null;

		private Mobile		m_SummonMaster;

		private int			m_HitsMax = -1;
		private	int			m_StamMax = -1;
		private int			m_ManaMax = -1;
		private int			m_DamageMin = -1;
		private int			m_DamageMax = -1;

		private int			m_PhysicalResistance, m_PhysicalDamage = 100;
		private int			m_FireResistance, m_FireDamage;
		private int			m_ColdResistance, m_ColdDamage;
		private int			m_PoisonResistance, m_PoisonDamage;
		private int			m_EnergyResistance, m_EnergyDamage;
		private int			m_ChaosDamage;
		private int			m_DirectDamage;

		private List<Mobile> m_Owners;
		private List<Mobile> m_Friends;

		private bool		m_IsStabled;

		private bool		m_HasGeneratedLoot; // have we generated our loot yet?

		private bool		m_Paragon;

		private bool		m_IsPrisoner;

		private int			m_Coins;
		private string		m_CoinType;
		private int 		m_SpawnerID;
		private bool		m_Swimmer;
		private bool		m_NoWalker;

		private int			m_HitsBeforeMod;

		#endregion

		public virtual InhumanSpeech SpeechType{ get{ return null; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public bool IsStabled
		{
			get{ return m_IsStabled; }
			set
			{
				m_IsStabled = value;
				if ( m_IsStabled )
					StopDeleteTimer();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsPrisoner
		{
			get{ return m_IsPrisoner; }
			set{ m_IsPrisoner = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int HitsBeforeMod
		{
			get{ return m_HitsBeforeMod; }
			set{ m_HitsBeforeMod = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Coins
		{
			get{ return m_Coins; }
			set{ m_Coins = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public string CoinType
		{
			get{ return m_CoinType; }
			set{ m_CoinType = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int SpawnerID
		{
			get{ return m_SpawnerID; }
			set{ m_SpawnerID = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Swimmer
		{
			get{ return m_Swimmer; }
			set{ m_Swimmer = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool NoWalker
		{
			get{ return m_NoWalker; }
			set{ m_NoWalker = value; }
		}

		protected DateTime SummonEnd
		{
			get { return m_SummonEnd; }
			set { m_SummonEnd = value; }
		}

		public virtual Faction FactionAllegiance{ get{ return null; } }
		public virtual int FactionSilverWorth{ get{ return 30; } }

		#region Bonding
		public const bool BondingEnabled = true;

		public virtual bool IsNecromancer { get { return ( Skills[ SkillName.Necromancy ].Value > 50 ); } }

		public virtual bool IsBondable{ get{ return ( BondingEnabled && !Summoned ); } }
		public virtual TimeSpan BondingDelay{ get{ return TimeSpan.FromDays( 7.0 ); } }
		public virtual TimeSpan BondingAbandonDelay{ get{ return TimeSpan.FromDays( 1.0 ); } }

		public override bool CanRegenHits{ get{ return !m_IsDeadPet && base.CanRegenHits; } }
		public override bool CanRegenStam{ get{ return !m_IsDeadPet && base.CanRegenStam; } }
		public override bool CanRegenMana{ get{ return !m_IsDeadPet && base.CanRegenMana; } }

		public override bool IsDeadBondedPet{ get{ return m_IsDeadPet; } }

		private bool m_IsBonded;
		private bool m_IsDeadPet;
		private DateTime m_BondingBegin;
		private DateTime m_OwnerAbandonTime;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile LastOwner
		{
			get
			{
				if ( m_Owners == null || m_Owners.Count == 0 )
					return null;

				return m_Owners[m_Owners.Count - 1];
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsBonded
		{
			get{ return m_IsBonded; }
			set{ m_IsBonded = value; InvalidateProperties(); }
		}

		public bool IsDeadPet
		{
			get{ return m_IsDeadPet; }
			set{ m_IsDeadPet = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime BondingBegin
		{
			get{ return m_BondingBegin; }
			set{ m_BondingBegin = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime OwnerAbandonTime
		{
			get{ return m_OwnerAbandonTime; }
			set{ m_OwnerAbandonTime = value; }
		}
		#endregion

		#region Delete Previously Tamed Timer
		private DeleteTimer		m_DeleteTimer;

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan DeleteTimeLeft
		{
			get
			{
				if ( m_DeleteTimer != null && m_DeleteTimer.Running )
					return m_DeleteTimer.Next - DateTime.Now;

				return TimeSpan.Zero;
			}
		}

		private class DeleteTimer : Timer
		{
			private Mobile m;

			public DeleteTimer( Mobile creature, TimeSpan delay ) : base( delay )
			{
				m = creature;
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				m.Delete();
			}
		}

		public void BeginDeleteTimer()
		{
			if ( !Summoned && !Deleted && !IsStabled )
			{
				StopDeleteTimer();
				m_DeleteTimer = new DeleteTimer( this, TimeSpan.FromDays( 3.0 ) );
				m_DeleteTimer.Start();
			}
		}

		public void StopDeleteTimer()
		{
			if ( m_DeleteTimer != null )
			{
				m_DeleteTimer.Stop();
				m_DeleteTimer = null;
			}
		}

		#endregion

		public virtual double WeaponAbilityChance{ get{ return 0.4; } }

		public virtual WeaponAbility GetWeaponAbility()
		{
			return null;
		}

		#region Elemental Resistance/Damage

		public override int BasePhysicalResistance{ get{ return m_PhysicalResistance; } }
		public override int BaseFireResistance{ get{ return m_FireResistance; } }
		public override int BaseColdResistance{ get{ return m_ColdResistance; } }
		public override int BasePoisonResistance{ get{ return m_PoisonResistance; } }
		public override int BaseEnergyResistance{ get{ return m_EnergyResistance; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int PhysicalResistanceSeed{ get{ return m_PhysicalResistance; } set{ m_PhysicalResistance = value; UpdateResistances(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int FireResistSeed{ get{ return m_FireResistance; } set{ m_FireResistance = value; UpdateResistances(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int ColdResistSeed{ get{ return m_ColdResistance; } set{ m_ColdResistance = value; UpdateResistances(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int PoisonResistSeed{ get{ return m_PoisonResistance; } set{ m_PoisonResistance = value; UpdateResistances(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int EnergyResistSeed{ get{ return m_EnergyResistance; } set{ m_EnergyResistance = value; UpdateResistances(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int PhysicalDamage{ get{ return m_PhysicalDamage; } set{ m_PhysicalDamage = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int FireDamage{ get{ return m_FireDamage; } set{ m_FireDamage = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int ColdDamage{ get{ return m_ColdDamage; } set{ m_ColdDamage = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int PoisonDamage{ get{ return m_PoisonDamage; } set{ m_PoisonDamage = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int EnergyDamage{ get{ return m_EnergyDamage; } set{ m_EnergyDamage = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int ChaosDamage{ get{ return m_ChaosDamage; } set{ m_ChaosDamage = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int DirectDamage{ get{ return m_DirectDamage; } set{ m_DirectDamage = value; } }

		#endregion

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsParagon
		{
			get{ return m_Paragon; }
			set
			{
				if ( m_Paragon == value )
					return;
				else if ( value )
					Paragon.Convert( this );
				else
					Paragon.UnConvert( this );

				m_Paragon = value;

				InvalidateProperties();
			}
		}

		public virtual FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public virtual PackInstinct PackInstinct{ get{ return PackInstinct.None; } }

		public List<Mobile> Owners { get { return m_Owners; } }

		public virtual bool AllowMaleTamer{ get{ return true; } }
		public virtual bool AllowFemaleTamer{ get{ return true; } }
		public virtual bool SubdueBeforeTame{ get{ return false; } }
		public virtual bool StatLossAfterTame{ get{ return SubdueBeforeTame; } }
		public virtual bool ReduceSpeedWithDamage{ get{ return true; } }
		public virtual bool IsSubdued{ get{ return SubdueBeforeTame && ( Hits < ( HitsMax / 10 ) ); } }

		public virtual bool Commandable{ get{ return true; } }

		public virtual Poison HitPoison{ get{ return null; } }
		public virtual double HitPoisonChance{ get{ return 0.5; } }
		public virtual Poison PoisonImmune{ get{ return null; } }

		public virtual bool BardImmune{ get{ return false; } }
		public virtual bool Unprovokable{ get{ return BardImmune || m_IsDeadPet; } }
		public virtual bool Uncalmable{ get{ return BardImmune || m_IsDeadPet; } }
		public virtual bool AreaPeaceImmune { get { return BardImmune || m_IsDeadPet; } }

		public virtual bool BleedImmune{ get{ return false; } }
		public virtual double BonusPetDamageScalar{ get{ return 1.0; } }

		public virtual bool DeathAdderCharmable{ get{ return false; } }

		//TODO: Find the pub 31 tweaks to the DispelDifficulty and apply them of course.
		public virtual double DispelDifficulty{ get{ return 0.0; } } // at this skill level we dispel 50% chance
		public virtual double DispelFocus{ get{ return 20.0; } } // at difficulty - focus we have 0%, at difficulty + focus we have 100%
		public virtual bool DisplayWeight{ get{ return Backpack is StrongBackpack; } }

		#region Breath ability, like dragon fire breath
		private DateTime m_NextBreathTime;

		// Must be overriden in subclass to enable
		public virtual bool HasBreath{ get{ return false; } }

		// Base damage given is: CurrentHitPoints * BreathDamageScalar
		public virtual double BreathDamageScalar{ get{ return 0.20; } }

		// Min/max seconds until next breath
		public virtual double BreathMinDelay{ get{ return 10.0; } }
		public virtual double BreathMaxDelay{ get{ return 15.0; } }

		// Creature stops moving for 1.0 seconds while breathing
		public virtual double BreathStallTime{ get{ return 1.0; } }

		// Effect is sent 1.3 seconds after BreathAngerSound and BreathAngerAnimation is played
		public virtual double BreathEffectDelay{ get{ return 1.3; } }

		// Damage is given 1.0 seconds after effect is sent
		public virtual double BreathDamageDelay{ get{ return 1.0; } }

		public virtual int BreathRange{ get{ return RangePerception; } }

		// Damage types
		public virtual int BreathPhysicalDamage{ get{ return 0; } }
		public virtual int BreathFireDamage{ get{ return 100; } }
		public virtual int BreathColdDamage{ get{ return 0; } }
		public virtual int BreathPoisonDamage{ get{ return 0; } }
		public virtual int BreathEnergyDamage{ get{ return 0; } }

		// Is immune to breath damages
		public virtual bool BreathImmune{ get{ return false; } }

		// Effect details and sound
		public virtual int BreathEffectItemID{ get{ return 0x36D4; } }
		public virtual int BreathEffectSpeed{ get{ return 5; } }
		public virtual int BreathEffectDuration{ get{ return 0; } }
		public virtual bool BreathEffectExplodes{ get{ return false; } }
		public virtual bool BreathEffectFixedDir{ get{ return false; } }
		public virtual int BreathEffectHue{ get{ return 0; } }
		public virtual int BreathEffectRenderMode{ get{ return 0; } }

		public virtual int BreathEffectSound{ get{ return 0x227; } }

		// Anger sound/animations
		public virtual int BreathAngerSound{ get{ return GetAngerSound(); } }
		public virtual int BreathAngerAnimation{ get{ return 12; } }

		public virtual void BreathStart( Mobile target )
		{
			BreathStallMovement();
			BreathPlayAngerSound();
			BreathPlayAngerAnimation();

			this.Direction = this.GetDirectionTo( target );

			Timer.DelayCall( TimeSpan.FromSeconds( BreathEffectDelay ), new TimerStateCallback( BreathEffect_Callback ), target );
		}

		public virtual void BreathStallMovement()
		{
			if ( m_AI != null )
				m_AI.NextMove = DateTime.Now + TimeSpan.FromSeconds( BreathStallTime );
		}

		public virtual void BreathPlayAngerSound()
		{
			PlaySound( BreathAngerSound );
		}

		public virtual void BreathPlayAngerAnimation()
		{
			Animate( BreathAngerAnimation, 5, 1, true, false, 0 );
		}

		public virtual void BreathEffect_Callback( object state )
		{
			Mobile target = (Mobile)state;

			if ( !target.Alive || !CanBeHarmful( target ) )
				return;

			BreathPlayEffectSound();
			if ( BreathEffectItemID > 0 ){ BreathPlayEffect( target ); }

			Timer.DelayCall( TimeSpan.FromSeconds( BreathDamageDelay ), new TimerStateCallback( BreathDamage_Callback ), target );
		}

		public virtual void BreathPlayEffectSound()
		{
			PlaySound( BreathEffectSound );
		}

		public virtual void BreathPlayEffect( Mobile target )
		{
			Effects.SendMovingEffect( this, target, BreathEffectItemID,
				BreathEffectSpeed, BreathEffectDuration, BreathEffectFixedDir,
				BreathEffectExplodes, BreathEffectHue, BreathEffectRenderMode );
		}

		public virtual void BreathDamage_Callback( object state )
		{
			Mobile target = (Mobile)state;

			if ( target is BaseCreature && ((BaseCreature)target).BreathImmune )
				return;

			if ( CanBeHarmful( target ) )
			{
				DoHarmful( target );
				BreathDealDamage( target, 0 );
			}
		}

		public virtual void BreathDealDamage( Mobile target, int form )
		{
			if( Evasion.CheckSpellEvasion( target ) )
				return;

			DoFinalBreathAttack( target, form, true );
		}

		public void DoFinalBreathAttack( Mobile target, int form, bool cycle )
		{
			int physDamage = BreathPhysicalDamage;
			int fireDamage = BreathFireDamage;
			int coldDamage = BreathColdDamage;
			int poisDamage = BreathPoisonDamage;
			int nrgyDamage = BreathEnergyDamage;
			int BreathDistance = 0;

			Point3D blast1 = new Point3D( ( target.X ), ( target.Y ), target.Z );
			Point3D blast2 = new Point3D( ( target.X-1 ), ( target.Y ), target.Z );
			Point3D blast3 = new Point3D( ( target.X+1 ), ( target.Y ), target.Z );
			Point3D blast4 = new Point3D( ( target.X ), ( target.Y-1 ), target.Z );
			Point3D blast5 = new Point3D( ( target.X ), ( target.Y+1 ), target.Z );

			Point3D blast1z = new Point3D( ( target.X ), ( target.Y ), target.Z+10 );
			Point3D blast2z = new Point3D( ( target.X-1 ), ( target.Y ), target.Z+10 );
			Point3D blast3z = new Point3D( ( target.X+1 ), ( target.Y ), target.Z+10 );
			Point3D blast4z = new Point3D( ( target.X ), ( target.Y-1 ), target.Z+10 );
			Point3D blast5z = new Point3D( ( target.X ), ( target.Y+1 ), target.Z+10 );

			Point3D blast1w = new Point3D( ( target.X ), ( target.Y ), target.Z );
			Point3D blast2w = new Point3D( ( target.X-2 ), ( target.Y ), target.Z );
			Point3D blast3w = new Point3D( ( target.X+2 ), ( target.Y ), target.Z );
			Point3D blast4w = new Point3D( ( target.X ), ( target.Y-2 ), target.Z );
			Point3D blast5w = new Point3D( ( target.X ), ( target.Y+2 ), target.Z );

			AOS.Damage( target, this, BreathComputeDamage(), physDamage, fireDamage, coldDamage, poisDamage, nrgyDamage );

			if ( form == 1 ) // CRYSTAL DRAGONS -----------------------------------------------------------------------------------------------------
			{
				int bColor = Utility.RandomList( 0x48D, 0x48E, 0x48F, 0x490, 0x491 );
				Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10, bColor, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3709, 30, 10, bColor, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3709, 30, 10, bColor, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3709, 30, 10, bColor, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3709, 30, 10, bColor, 0 );
				target.PlaySound( 0x208 );
				BreathDistance = 3;
			}
			else if ( form == 2 ) // POTIONS THROWN -------------------------------------------------------------------------------------------------
			{
				if ( BreathEffectHue == 0x488 )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10 );
					target.PlaySound( 0x208 );
					target.PlaySound( 0x38D );
				}
				else if ( BreathEffectHue == 0xB92 )
				{
					Effects.SendLocationParticles( EffectItem.Create( blast1, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x229 );

					if ( !(Server.Items.HiddenTrap.SavingThrow( target, "Poison", false )) )
					{
						switch( Utility.RandomMinMax( 1, 2 ) )
						{
							case 1: target.ApplyPoison( target, Poison.Lesser );	break;
							case 2: target.ApplyPoison( target, Poison.Regular );	break;
						}
					}
					target.PlaySound( 0x38D );
				}
				else if ( form == 0x5B5 )
				{
					Point3D vortex = new Point3D( ( target.X+1 ), ( target.Y+1 ), target.Z );
					Effects.SendLocationEffect( vortex, target.Map, 0x37CC, 30, 10, 0x481, 0 );
					target.PlaySound( 0x10B );
					target.PlaySound( 0x38D );
				}
				else
				{
					target.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					target.PlaySound( 0x307 );
				}

				this.YellHue = Utility.RandomMinMax( 0, 3 ); // THIS IS USED TO RANDOMIZE POTION TYPES
			}
			else if ( form == 3 ) // DAGGERS OR STARS THROWN ----------------------------------------------------------------------------------------
			{
				if ( target is PlayerMobile && Server.Items.BaseRace.IsBleeder( target ) )
				{
					Server.Misc.IntelligentAction.CryOut( target );

					Blood blood = new Blood(); blood.MoveToWorld( blast2, this.Map );
						  blood = new Blood(); blood.MoveToWorld( blast3, this.Map );
						  blood = new Blood(); blood.MoveToWorld( blast4, this.Map );
						  blood = new Blood(); blood.MoveToWorld( blast5, this.Map );
				}

				if ( BreathEffectItemID == 0x406C ) // ASSASSIN STAR
				{
					if ( !(Server.Items.HiddenTrap.SavingThrow( target, "Poison", false )) )
					{
						switch( Utility.RandomMinMax( 1, 2 ) )
						{
							case 1: target.ApplyPoison( target, Poison.Lesser );	break;
							case 2: target.ApplyPoison( target, Poison.Regular );	break;
						}
					}
				}
			}
			else if ( form == 4 ) // DINOSAUR ROAR --------------------------------------------------------------------------------------------------
			{
				target.SendMessage( "You are hit by the force of the mighty roar!" );
				target.PlaySound( 0x63F );
				BreathDistance = 5;
			}
			else if ( form == 5 ) // MANTICORE ------------------------------------------------------------------------------------------------------
			{
				target.SendMessage( "You are hit by a manticore thorn!" );
				if ( !(Server.Items.HiddenTrap.SavingThrow( target, "Poison", false )) )
				{
					target.ApplyPoison( target, Poison.Lethal );
				}
				Server.Misc.IntelligentAction.CryOut( target );
			}
			else if ( form == 6 ) // SPIDERS --------------------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x10D3, 30, 10, 0, 0 );
				target.PlaySound( 0x62D );
				double webbed = ((double)(this.Fame/200));
					if ( webbed > 15.0 ){ webbed = 15.0; }
				target.Paralyze( TimeSpan.FromSeconds( webbed ) );
			}
			else if ( form == 7 ) // GIANT STONES AND LOGS ------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x36B0, 30, 10, 0x837, 0 );
				target.PlaySound( 0x664 );
				BreathDistance = 2;
			}
			else if ( form == 8 ) // LARGE SAND BREATH ----------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1w, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				Effects.SendLocationEffect( blast2w, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				Effects.SendLocationEffect( blast3w, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				Effects.SendLocationEffect( blast4w, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				Effects.SendLocationEffect( blast5w, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				target.PlaySound( 0x10B );
				BreathDistance = 3;
			}
			else if ( form == 9 ) // LARGE FIRE BREATH ----------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3709, 30, 10 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3709, 30, 10 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3709, 30, 10 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3709, 30, 10 );
				target.PlaySound( 0x208 );
				BreathDistance = 3;
			}
			else if ( form == 10 ) // LARGE POISON BREATH -------------------------------------------------------------------------------------------
			{
				if ( Utility.RandomBool() )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60 );
					Effects.SendLocationEffect( blast2, target.Map, 0x3400, 60 );
					Effects.SendLocationEffect( blast3, target.Map, 0x3400, 60 );
					Effects.SendLocationEffect( blast4, target.Map, 0x3400, 60 );
					Effects.SendLocationEffect( blast5, target.Map, 0x3400, 60 );
					Effects.PlaySound( target.Location, target.Map, 0x108 );
				}
				else
				{
					Effects.SendLocationParticles( EffectItem.Create( blast1, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.SendLocationParticles( EffectItem.Create( blast2, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.SendLocationParticles( EffectItem.Create( blast3, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.SendLocationParticles( EffectItem.Create( blast4, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.SendLocationParticles( EffectItem.Create( blast5, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x229 );
				}
				BreathDistance = 3;

				if ( !(Server.Items.HiddenTrap.SavingThrow( target, "Poison", false )) )
				{
					switch( Utility.RandomMinMax( 1, 2 ) )
					{
						case 1: target.ApplyPoison( target, Poison.Greater );	break;
						case 2: target.ApplyPoison( target, Poison.Deadly );	break;
					}
				}
			}
			else if ( form == 11 ) // LARGE RADIATION -----------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, 0xB96, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3400, 60, 0xB96, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3400, 60, 0xB96, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3400, 60, 0xB96, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3400, 60, 0xB96, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x108 );
				BreathDistance = 3;
			}
			else if ( form == 12 ) // LARGE COLD BREATH ---------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x1A84, 30, 10, 0x9C1, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x1A84, 30, 10, 0x9C1, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x1A84, 30, 10, 0x9C1, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x1A84, 30, 10, 0x9C1, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x1A84, 30, 10, 0x9C1, 0 );
				target.PlaySound( 0x10B );
				BreathDistance = 3;
			}
			else if ( form == 13 ) // LARGE ELECTRICAL BREATH ---------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast2, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast3, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast4, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast5, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				target.PlaySound( 0x5C3 );
				BreathDistance = 3;
			}
			else if ( form == 14 ) // TITAN LIGHTNING BOLT ------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast2, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast3, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast4, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				Effects.SendLocationEffect( blast5, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				target.PlaySound( 0x5C3 );
				target.BoltEffect( 0 );
				BreathDistance = 3;
			}
			else if ( form == 15 ) // SPHINX --------------------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				target.PlaySound( 0x10B );
				BreathDistance = 3;
			}
			else if ( form == 16 ) // LARGE STEAM BREATH --------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, 10, 0x9C4, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3400, 60, 10, 0x9C4, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3400, 60, 10, 0x9C4, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3400, 60, 10, 0x9C4, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3400, 60, 10, 0x9C4, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x108 );
				BreathDistance = 3;
			}
			else if ( form == 17 ) // SMALL FIRE BREATH ---------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10 );
				target.PlaySound( 0x208 );
			}
			else if ( form == 18 ) // SMALL POISON BREATH -------------------------------------------------------------------------------------------
			{
				if ( Utility.RandomBool() )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60 );
					Effects.PlaySound( target.Location, target.Map, 0x108 );
				}
				else
				{
					Effects.SendLocationParticles( EffectItem.Create( blast1, target.Map, EffectItem.DefaultDuration ), 0x36B0, 1, 14, 63, 7, 9915, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x229 );
				}

				if ( !(Server.Items.HiddenTrap.SavingThrow( target, "Poison", false )) )
				{
					switch( Utility.RandomMinMax( 1, 2 ) )
					{
						case 1: target.ApplyPoison( target, Poison.Lesser );	break;
						case 2: target.ApplyPoison( target, Poison.Regular );	break;
					}
				}
				BreathDistance = 2;
			}
			else if ( form == 19 ) // SMALL COLD BREATH ---------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x1A84, 30, 10, 0x9C1, 0 );
				target.PlaySound( 0x10B );
				BreathDistance = 2;
			}
			else if ( form == 20 ) // SMALL ENERGY BREATH -------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				target.PlaySound( 0x5C3 );
				BreathDistance = 2;
			}
			else if ( form == 21 ) // SMALL ENERGY WITH BOLT ----------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, Utility.RandomList( 0x3967, 0x3979 ), 30, 10 );
				target.PlaySound( 0x5C3 );
				target.BoltEffect( 0 );
				BreathDistance = 2;
			}
			else if ( form == 22 ) // MISC ELEMENTAL ------------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x36B0, 30, 10, 0x840, 0 );
				target.PlaySound( 0x65A );
			}
			else if ( form == 23 || form == 24 || form == 25 ) // LARGE VOID BREATH -----------------------------------------------------------------
			{
				int color = 0x496;
					if ( form == 24 ){ color = 0x844; }
					else if ( form == 25 ){ color = 0x9C1; }
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, color, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3400, 60, color, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3400, 60, color, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3400, 60, color, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3400, 60, color, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x108 );
				BreathDistance = 3;

				int drain = ((int)(this.Fame/500));

				target.Mana = target.Mana - drain;
					if ( target.Mana < 0 ){ target.Mana = 0; }

				target.Stam = target.Stam - drain;
					if ( target.Stam < 0 ){ target.Stam = 0; }

				target.SendMessage( "You feel your soul draining!" );
			}
			else if ( form == 26 || form == 27 || form == 28 ) // SMALL VOID BREATH -----------------------------------------------------------------
			{
				int color = 0x496;
					if ( form == 27 ){ color = 0x844; }
					else if ( form == 28 ){ color = 0x9C1; }
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, color, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x108 );
				BreathDistance = 2;

				int drain = ((int)(this.Fame/500));

				target.Mana = target.Mana - drain;
					if ( target.Mana < 0 ){ target.Mana = 0; }

				target.Stam = target.Stam - drain;
					if ( target.Stam < 0 ){ target.Stam = 0; }

				target.SendMessage( "You feel your soul draining!" );
			}
			else if ( form == 29 ) // STONE HANDS FROM THE GROUND -----------------------------------------------------------------------------------
			{
				Point3D hands = new Point3D( ( target.X ), ( target.Y ), ( target.Z+5 ) );
				Effects.SendLocationEffect( hands, target.Map, 0x3837, 23, 10, this.Hue, 0 );
				target.PlaySound( 0x65A );
			}
			else if ( form == 30 ) // WATER SPLASH --------------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x1A84, 30, 10, BreathEffectHue, 0 );
				target.PlaySound( 0x026 );
				BreathDistance = 2;
			}
			else if ( form == 31 ) // WATER SPLASH --------------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x1A84, 30, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x23B2, 16, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x23B2, 16, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x23B2, 16, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x23B2, 16, BreathEffectHue, 0 );
				target.PlaySound( 0x026 );
				BreathDistance = 4;
			}
			else if ( form == 32 ) // SMALL FALLING ICE ---------------------------------------------------------------------------------------------
			{
				if ( Utility.RandomBool() )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x5571, 85, 10, 0, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x5C0 );
				}
				else
				{
					Effects.SendLocationEffect( blast1, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x656 );
				}
				BreathDistance = 2;
			}
			else if ( form == 33 ) // BIG FALLING ICE -----------------------------------------------------------------------------------------------
			{
				int icy = Utility.RandomMinMax(1,3);
				if ( icy == 1 )
				{
					Effects.SendLocationEffect( blast1, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
					Effects.SendLocationEffect( blast2, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
					Effects.SendLocationEffect( blast3, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
					Effects.SendLocationEffect( blast4, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
					Effects.SendLocationEffect( blast5, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x658 );
				}
				else if ( icy == 2 )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x5571, 85, 10, 0, 0 );
					Effects.SendLocationEffect( blast2, target.Map, 0x5571, 85, 10, 0, 0 );
					Effects.SendLocationEffect( blast3, target.Map, 0x5571, 85, 10, 0, 0 );
					Effects.SendLocationEffect( blast4, target.Map, 0x5571, 85, 10, 0, 0 );
					Effects.SendLocationEffect( blast5, target.Map, 0x5571, 85, 10, 0, 0 );
					Effects.PlaySound( target.Location, target.Map, 0x5C0 );
				}
				else
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x55BB, 85, 10, 0, 0 );
					Effects.PlaySound( blast1, target.Map, 0x5CE );
				}
				BreathDistance = 3;
			}
			else if ( form == 34 ) // LARGE WEED BREATH ---------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, 0xB97, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3400, 60, 0xB97, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3400, 60, 0xB97, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3400, 60, 0xB97, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3400, 60, 0xB97, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x64F );
				BreathDistance = 3;

				double weed = ((double)(this.Fame/200));
					if ( weed > 15.0 ){ weed = 15.0; }
				target.Paralyze( TimeSpan.FromSeconds( weed ) );
			}
			else if ( form == 35 ) // SMALL WEED BREATH ---------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, 0xB97, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x64F );
				BreathDistance = 2;

				double weed = ((double)(this.Fame/200));
					if ( weed > 15.0 ){ weed = 15.0; }
				target.Paralyze( TimeSpan.FromSeconds( weed ) );
			}
			else if ( form == 36 ) // ACID SPLASH ---------------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x1A84, 30, 10, BreathEffectHue, 1167 );
				Effects.SendLocationEffect( blast2, target.Map, 0x23B2, 16, BreathEffectHue, 1167 );
				Effects.SendLocationEffect( blast3, target.Map, 0x23B2, 16, BreathEffectHue, 1167 );
				Effects.SendLocationEffect( blast4, target.Map, 0x23B2, 16, BreathEffectHue, 1167 );
				Effects.SendLocationEffect( blast5, target.Map, 0x23B2, 16, BreathEffectHue, 1167 );
				target.PlaySound( 0x026 );
				BreathDistance = 3;
			}
			else if ( form == 37 ) // MUMMY WRAP ----------------------------------------------------------------------------------------------------
			{
				Point3D wrapped = new Point3D( ( target.X ), ( target.Y ), (target.Z+2) );
				Effects.SendLocationEffect( wrapped, target.Map, 0x23AF, 30, 10, 0, 0 );
				target.PlaySound( 0x5D2 );
				target.Paralyze( TimeSpan.FromSeconds( 5.0 ) );
			}
			else if ( form == 38 ) // SMALL STEAM BREATH --------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, 10, 0x9C4, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x108 );
				BreathDistance = 2;
			}
			else if ( form == 39 ) // SMALL RADIATION -----------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3400, 60, 0xB96, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x108 );
				BreathDistance = 2;
			}
			else if ( form == 40 ) // SMALL SAND BREATH ---------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x5590, 30, 10, Utility.RandomList( 0xB4D, 0xB4E ), 0 );
				target.PlaySound( 0x10B );
				BreathDistance = 2;
			}
			else if ( form == 41 ) // TITAN OF EARTH ATTACK -----------------------------------------------------------------------------------------
			{
				Point3D hands = new Point3D( ( target.X ), ( target.Y ), ( target.Z+5 ) );
				Effects.SendLocationEffect( hands, target.Map, 0x3837, 23, 10, BreathEffectHue, 0 );

				Effects.SendLocationEffect( blast1z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast2z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast3z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast4z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast5z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x658 );

				BreathDistance = 6;
			}
			else if ( form == 42 ) // TITAN OF FIRE ATTACK ------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast2, target.Map, 0x3709, 30, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast3, target.Map, 0x3709, 30, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast4, target.Map, 0x3709, 30, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast5, target.Map, 0x3709, 30, 10, BreathEffectHue, 0 );
				target.PlaySound( 0x208 );

				Effects.SendLocationEffect( blast1z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast2z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast3z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast4z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast5z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.PlaySound( target.Location, target.Map, 0x15F );

				BreathDistance = 6;
			}
			else if ( form == 43 ) // TITAN OF WATER ATTACK -----------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1, target.Map, 0x23B2, 16 );
				Effects.SendLocationEffect( blast2, target.Map, 0x23B2, 16 );
				Effects.SendLocationEffect( blast3, target.Map, 0x23B2, 16 );
				Effects.SendLocationEffect( blast4, target.Map, 0x23B2, 16 );
				Effects.SendLocationEffect( blast5, target.Map, 0x23B2, 16 );
				target.PlaySound( 0x026 );

				Effects.SendLocationEffect( blast1z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast2z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast3z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast4z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );
				Effects.SendLocationEffect( blast5z, target.Map, Utility.RandomList( 0x384E, 0x3859 ), 85, 10, BreathEffectHue, 0 );

				BreathDistance = 6;
			}
			else if ( form == 44 ) // TITAN OF AIR ATTACK -----------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast2w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast3w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast4w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast5w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				target.PlaySound( 0x10B );

				if ( target is PlayerMobile && Utility.RandomBool() )
				{
					IMount mount = target.Mount;

					if ( mount != null )
					{
						target.SendLocalizedMessage( 1062315 ); // You fall off your mount!
						Server.Mobiles.EtherealMount.EthyDismount( target );
						mount.Rider = null;
					}
					target.Animate( 22, 5, 1, true, false, 0 );
				}
				BreathDistance = 6;
			}
			else if ( form == 45 ) // STAR CREATURE ATTACK ------------------------------------------------------------------------------------------
			{
				if ( Utility.RandomBool() )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10 );
					Effects.SendLocationEffect( blast2, target.Map, 0x3709, 30, 10 );
					Effects.SendLocationEffect( blast3, target.Map, 0x3709, 30, 10 );
					Effects.SendLocationEffect( blast4, target.Map, 0x3709, 30, 10 );
					Effects.SendLocationEffect( blast5, target.Map, 0x3709, 30, 10 );
					target.PlaySound( 0x208 );
				}
				else
				{
					Effects.SendLocationEffect( blast1z, target.Map, 0x2A4E, 30, 10 );
					Effects.SendLocationEffect( blast2z, target.Map, 0x2A4E, 30, 10 );
					Effects.SendLocationEffect( blast3z, target.Map, 0x2A4E, 30, 10 );
					Effects.SendLocationEffect( blast4z, target.Map, 0x2A4E, 30, 10 );
					Effects.SendLocationEffect( blast5z, target.Map, 0x2A4E, 30, 10 );
					target.PlaySound( 0x5C3 );
				}
				BreathDistance = 3;
			}
			else if ( form == 46 ) // LARGE STORM ATTACK --------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast2w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast3w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast4w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast5w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				target.PlaySound( 0x10B );

				Effects.SendLocationEffect( blast1z, target.Map, 0x2A4E, 30, 10 );
				Effects.SendLocationEffect( blast2z, target.Map, 0x2A4E, 30, 10 );
				Effects.SendLocationEffect( blast3z, target.Map, 0x2A4E, 30, 10 );
				Effects.SendLocationEffect( blast4z, target.Map, 0x2A4E, 30, 10 );
				Effects.SendLocationEffect( blast5z, target.Map, 0x2A4E, 30, 10 );
				target.PlaySound( 0x5C3 );

				if ( target is PlayerMobile && Utility.RandomMinMax( 1, 5 ) == 1 )
				{
					IMount mount = target.Mount;

					if ( mount != null )
					{
						target.SendLocalizedMessage( 1062315 ); // You fall off your mount!
						Server.Mobiles.EtherealMount.EthyDismount( target );
						mount.Rider = null;
					}
					target.Animate( 22, 5, 1, true, false, 0 );
				}

				BreathDistance = 3;
			}
			else if ( form == 47 ) // AIR BLOWING BREATH --------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast2w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast3w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast4w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				Effects.SendLocationEffect( blast5w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				target.PlaySound( 0x10B );

				if ( target is PlayerMobile && Utility.RandomBool() )
				{
					IMount mount = target.Mount;

					if ( mount != null )
					{
						target.SendLocalizedMessage( 1062315 ); // You fall off your mount!
						Server.Mobiles.EtherealMount.EthyDismount( target );
						mount.Rider = null;
					}
					target.Animate( 22, 5, 1, true, false, 0 );
				}
				BreathDistance = 3;
			}
			else if ( form == 48 ) // SMALL AIR BLOWING BREATH --------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				target.PlaySound( 0x10B );

				if ( target is PlayerMobile && Utility.RandomBool() )
				{
					IMount mount = target.Mount;

					if ( mount != null )
					{
						target.SendLocalizedMessage( 1062315 ); // You fall off your mount!
						Server.Mobiles.EtherealMount.EthyDismount( target );
						mount.Rider = null;
					}
					target.Animate( 22, 5, 1, true, false, 0 );
				}
				BreathDistance = 2;
			}
			else if ( form == 49 ) // SMALL STAR CREATURE ATTACK ------------------------------------------------------------------------------------
			{
				if ( Utility.RandomBool() )
				{
					Effects.SendLocationEffect( blast1, target.Map, 0x3709, 30, 10 );
					target.PlaySound( 0x208 );
				}
				else
				{
					Effects.SendLocationEffect( blast1w, target.Map, 0x2A4E, 30, 10 );
					target.PlaySound( 0x5C3 );
				}
				BreathDistance = 2;
			}
			else if ( form == 50 ) // SMALL STORM ATTACK --------------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( blast1w, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				target.PlaySound( 0x10B );

				Effects.SendLocationEffect( blast1w, target.Map, 0x2A4E, 30, 10 );
				target.PlaySound( 0x5C3 );

				if ( target is PlayerMobile && Utility.RandomMinMax( 1, 5 ) == 1 )
				{
					IMount mount = target.Mount;

					if ( mount != null )
					{
						target.SendLocalizedMessage( 1062315 ); // You fall off your mount!
						Server.Mobiles.EtherealMount.EthyDismount( target );
						mount.Rider = null;
					}
					target.Animate( 22, 5, 1, true, false, 0 );
				}

				BreathDistance = 3;
			}
			else if ( form == 51 ) // SMALL AIR ATTACK -----------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( target.Location, target.Map, 0x5590, 30, 10, 0xB24, 0 );
				target.PlaySound( 0x10B );

				if ( target is PlayerMobile && Utility.RandomMinMax( 1, 5 ) == 1 )
				{
					IMount mount = target.Mount;

					if ( mount != null )
					{
						target.SendLocalizedMessage( 1062315 ); // You fall off your mount!
						Server.Mobiles.EtherealMount.EthyDismount( target );
						mount.Rider = null;
					}
					target.Animate( 22, 5, 1, true, false, 0 );
				}
				BreathDistance = 2;
			}
			else if ( form == 52 ) // SMALL UNICORN ATTACK -------------------------------------------------------------------------------------
			{
				Effects.SendLocationEffect( target.Location, target.Map, 0x3039, 30, 10, 0xB71, 0 );
				target.PlaySound( 0x20B );
				BreathDistance = 2;
			}

			if ( BreathDistance > 0 && cycle )
			{
				List<Mobile> targets = new List<Mobile>();

				Map map = this.Map;

				if ( map != null && target != null )
				{
					foreach ( Mobile m in target.GetMobilesInRange( BreathDistance ) )
					{
						if ( m != this && m != target && this.InLOS( m ) && m is PlayerMobile && m.Alive && CanBeHarmful( m ) && !m.Blessed )
							targets.Add( m );
						if ( m != this && m != target && this.InLOS( m ) && m is BaseCreature && m.Alive && CanBeHarmful( m ) && !m.Blessed )
						{
							if ( ((BaseCreature)m).Summoned || ((BaseCreature)m).Controlled )
								targets.Add( m );
						}
					}
					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = targets[i];
						DoFinalBreathAttack( m, form, false );
					}
				}
			}
		}

		public virtual int BreathComputeDamage()
		{
			int damage = (int)(Hits * BreathDamageScalar);

			if ( IsParagon )
				damage = (int)(damage / Paragon.HitsBuff);

			if ( damage > 100 ){ damage = 100; }

			if ( damage < DamageMax )
					damage = DamageMax;

			return damage;
		}

		#endregion

		#region Spill Acid

		public void SpillAcid( int Amount )
		{
			SpillAcid( null, Amount );
		}

		public void SpillAcid( Mobile target, int Amount )
		{
			if ( (target != null && target.Map == null) || this.Map == null )
				return;

			for ( int i = 0; i < Amount; ++i )
			{
				Point3D loc = this.Location;
				Map map = this.Map;
				Item acid = NewHarmfulItem();

				if ( target != null && target.Map != null && Amount == 1 )
				{
					loc = target.Location;
					map = target.Map;
				}
				else
				{
					bool validLocation = false;
					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						loc = new Point3D(
							loc.X+(Utility.Random(0,3)-2),
							loc.Y+(Utility.Random(0,3)-2),
							loc.Z );
						loc.Z = map.GetAverageZ( loc.X, loc.Y );
						validLocation = map.CanFit( loc, 16, false, false ) ;
					}
				}
				acid.MoveToWorld( loc, map );
			}
		}

		/*
			Solen Style, override me for other mobiles/items:
			kappa+acidslime, grizzles+whatever, etc.
		*/

		public virtual Item NewHarmfulItem()
		{
			return new PoolOfAcid( TimeSpan.FromSeconds(10), 30, 30 );
		}

		#endregion

		#region Flee!!!
		private DateTime m_EndFlee;

		public DateTime EndFleeTime
		{
			get{ return m_EndFlee; }
			set{ m_EndFlee = value; }
		}

		public virtual void StopFlee()
		{
			m_EndFlee = DateTime.MinValue;
		}

		public virtual bool CheckFlee()
		{
			if ( m_EndFlee == DateTime.MinValue )
				return false;

			if ( DateTime.Now >= m_EndFlee )
			{
				StopFlee();
				return false;
			}

			return true;
		}

		public virtual void BeginFlee( TimeSpan maxDuration )
		{
			m_EndFlee = DateTime.Now + maxDuration;
		}

		#endregion

		public BaseAI AIObject{ get{ return m_AI; } }

		public const int MaxOwners = 5;

		public virtual OppositionGroup OppositionGroup
		{
			get{ return null; }
		}

		#region Friends
		public List<Mobile> Friends { get { return m_Friends; } }

		public virtual bool AllowNewPetFriend
		{
			get{ return ( m_Friends == null || m_Friends.Count < 5 ); }
		}

		public virtual bool IsPetFriend( Mobile m )
		{
			return ( m_Friends != null && m_Friends.Contains( m ) );
		}

		public virtual void AddPetFriend( Mobile m )
		{
			if ( m_Friends == null )
				m_Friends = new List<Mobile>();

			m_Friends.Add( m );
		}

		public virtual void RemovePetFriend( Mobile m )
		{
			if ( m_Friends != null )
				m_Friends.Remove( m );
		}

		public virtual bool IsFriend( Mobile m )
		{
			OppositionGroup g = this.OppositionGroup;

			if ( g != null && g.IsEnemy( this, m ) )
				return false;

			if ( !(m is BaseCreature) )
				return false;

			BaseCreature c = (BaseCreature)m;

			return ( m_iTeam == c.m_iTeam && ( (m_bSummoned || m_bControlled) == (c.m_bSummoned || c.m_bControlled) )/* && c.Combatant != this */);
		}

		#endregion

		#region Allegiance
		public virtual Ethics.Ethic EthicAllegiance { get { return null; } }

		public enum Allegiance
		{
			None,
			Ally,
			Enemy
		}

		public virtual Allegiance GetFactionAllegiance( Mobile mob )
		{
			if ( mob == null || mob.Map != Faction.Facet || FactionAllegiance == null )
				return Allegiance.None;

			Faction fac = Faction.Find( mob, true );

			if ( fac == null )
				return Allegiance.None;

			return ( fac == FactionAllegiance ? Allegiance.Ally : Allegiance.Enemy );
		}

		public virtual Allegiance GetEthicAllegiance( Mobile mob )
		{
			if ( mob == null || mob.Map != Faction.Facet || EthicAllegiance == null )
				return Allegiance.None;

			Ethics.Ethic ethic = Ethics.Ethic.Find( mob, true );

			if ( ethic == null )
				return Allegiance.None;

			return ( ethic == EthicAllegiance ? Allegiance.Ally : Allegiance.Enemy );
		}

		#endregion

		public bool IsCitizen()
		{
			if ( this is BaseNPC )
				return true;
			else if ( this is BasePerson )
				return true;
			else if ( this is BaseVendor )
				return true;
			else if ( this is BaseHealer )
				return true;
			else if ( AlwaysInvulnerable( this ) )
				return true;
			else if ( IsPet( this ) )
				return true;
			else if ( this is Citizens )
				return true;

			return false;
		}

		public virtual bool IsEnemy( Mobile m )
		{
			Region reg = Region.Find( this.Location, this.Map );

			if ( m is PlayerMobile )
			{
				SlayerEntry undead_creatures = SlayerGroup.GetEntryByName( SlayerName.Silver );
				if ( undead_creatures.Slays(this) )
				{
					Item item = m.FindItemOnLayer( Layer.Helm );
					if ( item is DeathlyMask )
					{
						return false;
					}
				}
			}

			if ( WhisperHue == 999 && Hidden && m is PlayerMobile && !Server.Mobiles.BasePirate.IsSailor( this ) ) // SURFACE FROM WATER AND ATTACK
			{
				this.Home = this.Location; // SO THEY KNOW WHERE TO GO BACK TO

				if ( m.Z < 0 ) // JUMP NEAR A BOAT
				{
					Point3D loc = Server.Misc.Worlds.GetBoatWater( m.X, m.Y, m.Map, 4 );
					if ( loc.X == 0 && loc.Y == 0 && loc.Z == 0 )
					{
						loc = m.Location;
					}
					this.Location = loc;
					this.PlaySound( 0x026 );
					Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );
				}
				else if ( !(CanOnlyMoveOnSea()) ) // JUMP OUT OF WATER AND WALK TO SHORE
				{
					this.PlaySound( 0x026 );
					Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );
				}
				this.Warmode = true;
				this.Combatant = m;
				this.CantWalk = m_NoWalker;
				this.CanSwim = m_Swimmer;
				this.Hidden = false;
				return true;
			}

			// DRACULA ISLAND SPECIAL REACTIONS
			SlayerEntry undead = SlayerGroup.GetEntryByName( SlayerName.Silver );
			SlayerEntry exorcism = SlayerGroup.GetEntryByName( SlayerName.Exorcism );
			if ( reg.IsPartOf( typeof( NecromancerRegion ) ) && this.ControlSlots != 666 && ( m is BaseVendor || GetPlayerInfo.EvilPlayer( m ) ) && (this is Bat || this is DiseasedRat || this is DarkHound || undead.Slays(this) || exorcism.Slays(this) || this is EvilMage) )
				return false;

			OppositionGroup g = this.OppositionGroup;

			if ( g != null && g.IsEnemy( this, m ) )
				return true;

			if (!(m is BaseCreature))
				return true;

			BaseCreature c = (BaseCreature)m;

			return ( m_iTeam != c.m_iTeam || ( (m_bSummoned || m_bControlled) != (c.m_bSummoned || c.m_bControlled) )/* || c.Combatant == this*/ );
		}

		public static bool AlwaysInvulnerable( Mobile m )
		{
			if ( m is PackBear ){ return true; }
			else if ( m is PackMule ){ return true; }
			else if ( m is PackStegosaurus ){ return true; }
			else if ( m is PackTurtle ){ return true; }
			else if ( m is HenchmanFamiliar ){ return true; }
			else if ( m is AerialServant ){ return true; }
			else if ( m is PackBeast ){ return true; }
			else if ( m is FrankenPorter ){ return true; }
			else if ( m is GolemPorter ){ return true; }
			else if ( m is EtherealDealer ){ return true; }
			else if ( m is TavernPatronEast ){ return true; }
			else if ( m is TavernPatronNorth ){ return true; }
			else if ( m is TavernPatronSouth ){ return true; }
			else if ( m is TavernPatronWest ){ return true; }
			else if ( m is AdventurerEast ){ return true; }
			else if ( m is AdventurerNorth ){ return true; }
			else if ( m is AdventurerSouth ){ return true; }
			else if ( m is AdventurerWest ){ return true; }
			else if ( m is Citizens ){ return true; }
			else if ( m is EpicPet ){ return true; }
			else if ( m is EpicCharacter ){ return true; }
			else if ( m is DeathKnightDemon ){ return true; }
			else if ( m is ElementalSteed ){ return true; }
			else if ( m is DraculaBride ){ return true; }
			else if ( m is GodOfLegends ){ return true; }
			else if ( m is NecroGreeter ){ return true; }
			else if ( m is Priest ){ return true; }
			else if ( m is BaseNPC ){ return true; }

			return false;
		}

		public bool CanOnlyMoveOnSea()
		{
			if ( m_Swimmer && m_NoWalker )
				return true;

			return false;
		}

		public static bool IsCitizen( Mobile m )
		{
			if ( m is BaseFamiliar ){ return true; }
			else if ( m is BaseGuildmaster ){ return true; }
			else if ( m is BaseVendor ){ return true; }
			else if ( m is BaseHealer ){ return true; }
			else if ( m is BaseNPC ){ return true; }
			else if ( m is BasePerson ){ return true; }
			else if ( m is Citizens ){ return true; }

			return false;
		}

		public override string ApplyNameSuffix( string suffix )
		{
			if ( IsParagon )
			{
				if ( suffix.Length == 0 )
					suffix = "(cursed)";
				else
					suffix = String.Concat( suffix, " (cursed)" );
			}

			return base.ApplyNameSuffix( suffix );
		}

		public virtual bool CheckControlChance( Mobile m )
		{
			if ( GetControlChance( m ) > Utility.RandomDouble() )
			{
				Loyalty += 1;
				return true;
			}

			PlaySound( GetAngerSound() );

			if ( Body.IsAnimal )
				Animate( 10, 5, 1, true, false, 0 );
			else if ( Body.IsMonster )
				Animate( 18, 5, 1, true, false, 0 );

			Loyalty -= 3;
			return false;
		}

		public virtual bool CanBeControlledBy( Mobile m )
		{
			return ( GetControlChance( m ) > 0.0 );
		}

		public double GetControlChance( Mobile m )
		{
			return GetControlChance( m, false );
		}

		public virtual double GetControlChance( Mobile m, bool useBaseSkill )
		{
			if ( m_dMinTameSkill <= 29.1 || m_bSummoned || m.AccessLevel >= AccessLevel.GameMaster )
				return 1.0;

			double dMinTameSkill = m_dMinTameSkill;

			if ( dMinTameSkill > -24.9 && Server.SkillHandlers.Taming.CheckMastery( m, this ) )
				dMinTameSkill = -24.9;

			int taming = (int)((useBaseSkill ? m.Skills[SkillName.Taming].Base : m.Skills[SkillName.Taming].Value ) * 10);
			int lore = (int)((useBaseSkill ? m.Skills[SkillName.Taming].Base : m.Skills[SkillName.Taming].Value ) * 10);
				if ( m.Skills[SkillName.Druidism].Base > m.Skills[SkillName.Taming].Base && useBaseSkill )
					lore = (int)((useBaseSkill ? m.Skills[SkillName.Druidism].Base : m.Skills[SkillName.Druidism].Value )* 10);
				else if ( m.Skills[SkillName.Druidism].Value > m.Skills[SkillName.Taming].Value )
					lore = (int)((useBaseSkill ? m.Skills[SkillName.Druidism].Base : m.Skills[SkillName.Druidism].Value )* 10);

			int bonus = 0, chance = 700;

			int SkillBonus = taming - (int)(dMinTameSkill * 10);
			int LoreBonus = lore - (int)(dMinTameSkill * 10);

			int SkillMod = 6, LoreMod = 6;

			if( SkillBonus < 0 )
				SkillMod = 28;
			if( LoreBonus < 0 )
				LoreMod = 14;

			SkillBonus *= SkillMod;
			LoreBonus *= LoreMod;

			bonus = (SkillBonus + LoreBonus ) / 2;

			chance += bonus;

			if ( chance >= 0 && chance < 200 )
				chance = 200;
			else if ( chance > 990 )
				chance = 990;

			chance -= (MaxLoyalty - m_Loyalty) * 10;

			return ( (double)chance / 1000 );
		}

		private static Type[] m_AnimateDeadTypes = new Type[]
			{
				typeof( HellSteed ), typeof( SkeletalMount ),
				typeof( WailingBanshee ), typeof( Wraith ), typeof( SkeletalDragon ),
				typeof( LichLord ), typeof( FleshGolem ), typeof( Lich ),
				typeof( SkeletalKnight ), typeof( BoneKnight ), typeof( Mummy ),
				typeof( SkeletalMage ), typeof( BoneMagi )
			};

		public virtual bool IsAnimatedDead
		{
			get
			{
				if ( this is SummonedCorpse )
					return true;

				return false;
			}
		}

		public virtual bool IsNecroFamiliar
		{
			get
			{
				if ( !Summoned )
					return false;

				if ( m_ControlMaster != null && SummonFamiliarSpell.Table.Contains( m_ControlMaster ) )
					return SummonFamiliarSpell.Table[ m_ControlMaster ] == this;

				return false;
			}
		}

		public override void Damage( int amount, Mobile from )
		{
			int oldHits = this.Hits;

			if ( Core.AOS && !this.Summoned && this.Controlled && 0.2 > Utility.RandomDouble() )
				amount = (int)(amount * BonusPetDamageScalar);

			if ( from is BaseCreature && !((BaseCreature)from).Summoned && !((BaseCreature)from).Controlled && IsPet( this ) && MyServerSettings.DamageToPets() > 1.0 )
			{
				amount = (int)(amount * MyServerSettings.DamageToPets());
			}

			if ( from is BaseCreature && !((BaseCreature)from).Summoned && !((BaseCreature)from).Controlled && IsPet( this ) && MyServerSettings.CriticalToPets() >= Utility.RandomMinMax( 1, 100 ) )
			{
				amount = amount * 2;
			}

			if ( Spells.Necromancy.EvilOmenSpell.TryEndEffect( this ) )
				amount = (int)(amount * 1.25);

			Mobile oath = Spells.Necromancy.BloodOathSpell.GetBloodOath( from );

			if ( oath == this )
			{
				amount = (int)(amount * 1.1);
				from.Damage( amount, from );
			}

			base.Damage( amount, from );

			if ( SubdueBeforeTame && !Controlled )
			{
				if ( (oldHits > (this.HitsMax / 10)) && (this.Hits <= (this.HitsMax / 10)) )
					PublicOverheadMessage( MessageType.Regular, 0x3B2, false, "* The creature has been beaten into subjugation! *" );
			}
		}

		public virtual bool DeleteCorpseOnDeath
		{
			get
			{
				return m_bSummoned;
			}
		}

		public override void SetLocation( Point3D newLocation, bool isTeleport )
		{
			base.SetLocation( newLocation, isTeleport );

			if ( isTeleport && m_AI != null )
				m_AI.OnTeleported();
		}

		public override void OnBeforeSpawn( Point3D location, Map m )
		{
			if ( ( Paragon.CheckConvert( this, location, m ) ) && ( this.Karma < -999 ) && ( this.EmoteHue != 123 ) && !( this.Region is GargoyleRegion ) && !( this.Region.IsPartOf( "the Castle of the Black Knight" ) ) )
				IsParagon = true;

			base.OnBeforeSpawn( location, m );
		}

		public void ExtraHP()
		{
			double mod = Server.Misc.MyServerSettings.HPModifier();
			m_HitsBeforeMod = HitsMax;

			if ( mod > 0.0 && !IsCitizen() )
			{
				int hits = (int)( HitsMax + ( HitsMax * mod ) );
				SetHits( hits );
				Hits = HitsMax;
			}
		}

		public static void AdditionalHitPoints( BaseCreature bc, int DungeonDifficulty )
		{
			double HitPercents = 0;
			if ( DungeonDifficulty > 1 ){ HitPercents = ( DungeonDifficulty * 10 )*0.01; }

			int hits = (int)(bc.HitsMax + (bc.HitsMax*HitPercents) );
			bc.SetHits( hits );
			bc.Hits = bc.HitsMax;
		}

		public static void BeefUp( BaseCreature bc, int up )
		{
			int HitPointIncrease = up;

			// WE DON'T WANT THE VERY POWERFUL CREATURES TO BE IMPOSSIBLE SO WE CAP THEM BASED ON FAME
			if ( bc.Fame >= 20000 ){ up = 0; }
			else if ( bc.Fame >= 18000 && up > 1 ){ up = 1; }
			else if ( bc.Fame >= 15000 && up > 2 ){ up = 2; }
			else if ( bc.Fame >= 10000 && up > 3 ){ up = 3; }

			// Buffs
			double TameBuff   = 0.15 * up;
			double GoldBuff   = 0.1 * up;
			double HitsBuff   = 0.1 * up;
			double StrBuff    = 0.1 * up;
			double IntBuff    = 0.3 * up;
			double DexBuff    = 0.3 * up;
			double SkillsBuff = 0.3 * up;
			double FameBuff   = 0.1 * up;
			double KarmaBuff  = 0.1 * up;
			int    DamageBuff = up;

			if ( bc.IsParagon )
				return;

			if ( HitPointIncrease > 0 )
			{
				if ( up > 0 )
				{
					if ( bc.HitsMaxSeed >= 0 )
						bc.HitsMaxSeed = (int)( bc.HitsMaxSeed + ( bc.HitsMaxSeed * HitsBuff ) );

					bc.RawStr = (int)( bc.RawStr + ( bc.RawStr * StrBuff ) );
					bc.RawInt = (int)( bc.RawInt + ( bc.RawInt * IntBuff ) );
					bc.RawDex = (int)( bc.RawDex + ( bc.RawDex * DexBuff ) );

					bc.Hits = bc.HitsMax;
					bc.Mana = bc.ManaMax;
					bc.Stam = bc.StamMax;
				}

				Server.Mobiles.BaseCreature.AdditionalHitPoints( bc, HitPointIncrease );

				if ( up > 0 )
				{
					for( int i = 0; i < bc.Skills.Length; i++ )
					{
						Skill skill = (Skill)bc.Skills[i];

						if ( skill.Base > 0.0 )
							skill.Base = skill.Base + ( skill.Base * SkillsBuff );
					}

					bc.DamageMin += DamageBuff;
					bc.DamageMax += DamageBuff;

					if ( bc.Fame > 0 )
						bc.Fame = (int)( bc.Fame + ( bc.Fame * FameBuff ) );

					if ( bc.Fame > 32000 )
						bc.Fame = 32000;

					if ( bc.Karma != 0 )
					{
						bc.Karma = (int)( bc.Karma + ( bc.Karma * KarmaBuff ) );

						if( Math.Abs( bc.Karma ) > 32000 )
							bc.Karma = 32000 * Math.Sign( bc.Karma );
					}

					if ( bc.Backpack != null )
					{
						int BonusGold = bc.Backpack.GetAmount( typeof( Gold ) );
						if ( BonusGold > 0 )
						{
							BonusGold = (int)( BonusGold * GoldBuff );
							bc.AddToBackpack( new Gold( BonusGold ) );
						}
					}

					if ( bc.Tamable )
					{
						bc.MinTameSkill = bc.MinTameSkill + ( bc.MinTameSkill * TameBuff );
					}
				}
			}

			if ( Server.Misc.MyServerSettings.CreaturesSearching() )
			{
				double searching = (double)(Server.Misc.IntelligentAction.GetCreatureLevel( (Mobile)bc ) + 10);
				if ( bc.Skills[SkillName.Searching].Value > 10 ){} // DON'T MODIFY THOSE THAT ALREADY HAVE THE SKILL
				else { bc.SetSkill( SkillName.Searching, searching ); }
			}
		}

		public static void BeefUpLoot( BaseCreature bc, int up )
		{
			if ( bc.IsParagon || up < 1 )
				return;

			if ( bc.Backpack != null )
			{
				if ( up >= Utility.Random( 7 ) )
				{
					if ( bc.Fame < 1250 )
						bc.AddLoot( LootPack.Meager );
					else if ( bc.Fame < 2500 )
						bc.AddLoot( LootPack.Average );
					else if ( bc.Fame < 5000 )
						bc.AddLoot( LootPack.Rich );
					else if ( bc.Fame < 10000 )
						bc.AddLoot( LootPack.FilthyRich );
					else
						bc.AddLoot( LootPack.UltraRich );
				}
			}
		}

		public override void OnAfterSpawn()
		{
			m_Swimmer = CanSwim;
			m_NoWalker = CantWalk;

			if ( !IsCitizen() && Server.Misc.MyServerSettings.LineOfSightOn() && WhisperHue != 999 && WhisperHue != 666 && !CanHearGhosts && !Controlled && (this.Region is DungeonRegion || this.Region is DeadRegion || this.Region is CaveRegion || this.Region is BardDungeonRegion || this.Region is OutDoorBadRegion) )
			{
				CanHearGhosts = true;
				CantWalk = true;
				Hidden = true;
			}

			int Heat = Worlds.GetDifficultyLevel( this.Location, this.Map );

			Heat = Server.Misc.SummonQuests.SummonCarriers( this, this, Heat );

			Region reg = Region.Find( this.Location, this.Map );

			if ( this is Xurtzar || this is Surtaz || this is Vulcrum || this is Arachnar || this is CaddelliteDragon ){ Heat = 4; } // TIME LORD TRIAL CREATURES GET HP BUFF

			// BARDS TALE TWEAKS
			if ( reg.IsPartOf( "Mangar's Tower" ) && this.Fame >= 5000 ){ Heat = 1; }
			else if ( reg.IsPartOf( "Mangar's Chamber" ) && this.Fame >= 5000 ){ Heat = 1; }
			else if ( reg.IsPartOf( "Kylearan's Tower" ) && this.Fame >= 5000 ){ Heat = 1; }

			if ( this.Name == "a vampire" ){ this.Title = null; }
			else if ( this.Name == "a young vampire" ){ this.Title = null; }
			else if ( this.Name == "a vampire lord" ){ this.Title = null; }
			else if ( this.Name == "a vampire prince" ){ this.Title = null; }

			if ( this.Map == Map.IslesDread && Utility.RandomMinMax( 1, 4 ) == 1 ) // SOME ANIMALS ARE AGGRESSIVE ON THE ISLES OF DREAD
			{
				if (	this is WhiteTiger ||
						this is WhiteTigerRiding ||
						this is PolarBear ||
						this is WhiteWolf ||
						this is SnowLeopard ||
						this is Mammoth ||
						this is Boar ||
						this is Panda ||
						this is PandaRiding ||
						this is Bull ||
						this is Gorilla ||
						this is Panther ||
						this is GreyWolf ){

					AI = AIType.AI_Melee;
					FightMode = FightMode.Closest;
					Karma = 0 - Fame;
					Tamable = false;
				}
			}

			if ( reg.IsPartOf( "the Pixie Cave" ) && this is ElderBrownBearRiding )
			{
				FightMode = FightMode.Evil;
			}

			if ( reg.IsPartOf( "the Druid's Glade" ) )
			{
				if ( this is Unicorn || this is Satyr )
				{
					AI = AIType.AI_Melee;
					FightMode = FightMode.Aggressor;
					Karma = 0;
					Fame = 0;
					Tamable = false;
				}
				else if ( this is DruidTree )
				{
					CantWalk = true;
					Direction = Direction.South;
				}
			}

			if ( reg.IsPartOf( "the Lyceum" ) )
			{
				if ( this is Alchemist || this is Scribe )
				{
					CantWalk = true;
					Direction = Direction.South;
				}
				else if ( this is Sage || this is Shepherd )
				{
					CantWalk = true;
					Direction = Direction.East;
					if ( this.FindItemOnLayer( Layer.OneHanded ) != null ){ (this.FindItemOnLayer( Layer.OneHanded )).Delete(); }
					if ( this.FindItemOnLayer( Layer.FirstValid ) != null ){ (this.FindItemOnLayer( Layer.FirstValid )).Delete(); }
					if ( this.FindItemOnLayer( Layer.TwoHanded ) != null ){ (this.FindItemOnLayer( Layer.TwoHanded )).Delete(); }
				}
			}

			if ( reg.IsPartOf( "the Ancient Crash Site" ) || reg.IsPartOf( "the Ancient Sky Ship" ) )
			{
				if ( this is SwampTentacle )
				{
					Name = "mutant plant";
					Body = 869;
					Hue = 0;
				}
				else if ( this is ElderGazer )
				{
					Name = "mutant gazer";
					Body = 457;
				}
				else if ( this is MarshWurm )
				{
					Name = "alien mutant";
					Body = 931;
				}
				else if ( this is Viscera )
				{
					Name = "crawling organs";
					Body = 951;
					Hue = 0;
				}
				else if ( this is Ghoul )
				{
					Name = "a ghoulish mutant";
					Body = 961;
				}
			}

			if ( this.Map == Map.Lodor && this.Z > 10 && this.X >= 1975 && this.Y >= 2201 && this.X <= 2032 && this.Y <= 2247 ) // ZOO ONLY HAS FRIENDLY ANIMALS
			{
				AI = AIType.AI_Melee;
				FightMode = FightMode.Aggressor;
				Karma = 0;
				Fame = 0;
				Tamable = false;
			}

			if ( Region.IsPartOf( typeof( PirateRegion ) ) ) // GHOST PIRATE SHIP ////////////////////////////////////////
			{
				if ( this is SkeletalMage ){ this.Name = "a dead pirate"; }
				else if ( this is SkeletalKnight ){ this.Name = "a skeletal pirate"; }
				else if ( this is Ghoul ){ this.Name = "a ghoulish pirate"; }
				else if ( this is Zombie ){ this.Name = "a rotting pirate"; }
				else if ( this is Spectre ){ this.Name = "a spectral pirate"; }
				else if ( this is AncientLich )
				{
					this.Name = NameList.RandomName( "evil mage" );
					this.Title = "the Captain of the Dead";
					PirateChest MyChest = new PirateChest(10,null);
					MyChest.ContainerOwner = "Treasure Chest of " + this.Name + " " + this.Title + "";
					MyChest.Hue = 0x47E;
					this.PackItem( MyChest );
				}
			}

			if ( Utility.RandomMinMax( 1, 4 ) == 1 && Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) ) ) // FOR HORSE RIDERS
			{
				if (	this is Adventurers ||
						this is Berserker ||
						this is Minstrel ||
						this is Rogue ||
						this is EvilMage ||
						this is EvilMageLord ||
						this is Brigand ||
						this is Executioner ||
						this is Monks ||
						this is ElfBerserker ||
						this is ElfMage ||
						this is ElfRogue ||
						this is ElfMinstrel ||
						this is ElfMonks ||
						this is OrkWarrior ||
						this is OrkMage ||
						this is OrkRogue ||
						this is OrkMonks )
				{

					Citizens.MountCitizens ( this, false );

					IMount bSteed = this.Mount;
					BaseMount iSteed = (BaseMount)bSteed;

					BaseMount steed = new EvilMount();
					steed.Body = iSteed.Body;
					steed.ItemID = iSteed.ItemID;
					steed.Hue = iSteed.Hue;
					iSteed.Delete();

					steed.Rider = this;
					ActiveSpeed = 0.1;
					PassiveSpeed = 0.2;
				}
			}

			// BARD'S TALE ///////////////////////////////////////////////////////////////////////////////////////
			if ( reg.IsPartOf( typeof( BardDungeonRegion ) ) )
			{
				if ( reg.IsPartOf( "the Sewers" ) )
				{
					if ( this is GiantSpider ){ this.Name = "a spinner"; }
				}
				else if ( reg.IsPartOf( "the Catacombs" ) || reg.IsPartOf( "the Lower Catacombs" ) )
				{
					if ( this is Spectre ){ this.Name = "a shadow"; }
					if ( this is Spirit ){ this.Name = "a ghost"; }
				}
				else if ( reg.IsPartOf( "Harkyn's Castle" ) )
				{
					if ( this is Gazer ){ this.Name = "a seeker"; }
					if ( this is MadDog ){ this.Name = "a wolf"; }
					if ( this is StoneElemental ){ this.Name = "a stone golem"; }
					if ( this is FrostGiant ){ this.Title = "the ice giant"; }
					if ( this is MetalDragon )
					{
						this.Hue = 2413; // FORCE A COPPER DRAGON
					}
				}
				else if ( reg.IsPartOf( "Kylearan's Tower" ) )
				{
					if ( this is Gazer ){ this.Body = 674; this.BaseSoundID = 0x47D; this.Name = NameList.RandomName( "drakkul" ); this.Title = "the beholder"; }
					if ( this is MadDog ){ this.Name = "a wolf"; }
					if ( this is StoneElemental ){ this.Name = "a stone elemental"; }
					if ( this is LowerDemon ){ this.Name = "a demon"; this.Hue = 0x5B5; this.Body = 4; }
				}
				else if ( reg.IsPartOf( "Mangar's Tower" ) )
				{
					if ( this is Dragon ){ this.Body = 12; }
					if ( this is Gazer ){ this.Name = "an evil eye"; this.Body = 83; }
					if ( this is LowerDemon ){ this.Name = "a demon lord"; this.Title = ""; this.Body = 102; }
					if ( this is Demon ){ this.Name = "a greater demon"; this.Title = ""; this.Hue = 0; this.Body = 40; }
					if ( this is Daemon ){ this.Name = "a balrog"; this.Title = ""; this.Body = 38; }
					if ( this is StormGiant && Utility.RandomBool() )
					{
						this.Title = "the cloud giant";
						Item lootchest = this.Backpack.FindItemByType( typeof ( LootChest ) );
						if ( lootchest != null )
						{
							lootchest.Hue = 0x835;
							lootchest.Name = "silver chest";
						}
					}
				}
				else if ( this is Orc ){ this.Body = Utility.RandomList( 7, 17, 41 ); }
			}

			if ( reg.IsPartOf( "the Castle of the Black Knight" ) )
			{
				if ( this is Gargoyle )
				{
					MorphingTime.MakeMeAGargoyle( this, "mage" );
				}
				else if ( this is EvilMage )
				{
					this.Title = "the dark wizard";
					MorphingTime.ColorMyClothes( this, 0x497, 0 );
				}
			}

			if ( reg.IsPartOf( "the Blood Temple" ) )
			{
				if ( this is Devil )
				{
					switch ( Utility.Random( 5 ) )
					{
						case 0: this.Title = "the devil of blood"; 			break;
						case 1: this.Title = "the bleeding devil"; 			break;
						case 2: this.Title = "the blood devil"; 			break;
						case 3: this.Title = "the devil of bloody hell"; 	break;
						case 4: this.Title = "the blood moon devil"; 		break;
					}
					Hue = Utility.RandomList( 0xB01, 0x870 );
				}
			}

			if ( reg.IsPartOf( "the Daemon's Crag" ) )
			{
				if ( this is Daemon )
				{
					Name = NameList.RandomName( "demonic" );
					Title = "the daemon";
					Body = Utility.RandomList( 9, 320 );
					Hue = 0;
					BaseSoundID = 357;
				}
				else if ( this is Balron )
				{
					Name = NameList.RandomName( "demonic" );
					Title = "the daemon lord";
					Body = Utility.RandomList( 191, 427 );
					Hue = 0;
					BaseSoundID = 357;
				}
				else if ( this is EvilMageLord || this is EvilMage )
				{
					MorphingTime.RemoveMyClothes( this );

					Item robe = new AssassinRobe();
						robe.Name = "sorcerer robe";
						robe.Hue = 2411;
						AddItem( robe );

					Item boots = new Boots();
						boots.Name = "boots";
						boots.Hue = 2411;
						AddItem( boots );

					Item hat = new ClothHood();
						hat.Name = "sorcerer hood";
						hat.Hue = 2411;
						AddItem( hat );

					Item staff = new BlackStaff();
						staff.Name = "sorcerer staff";
						AddItem( staff );

					Body = 0x190;
					Title = "the sorcerer";
					BaseSoundID = 0x47D;

					if ( this is EvilMageLord )
					{
						Name = "Malchir";
						Title = "the master sorcerer";
					}
					else if ( this is EvilMage && Home.X == 6277 && Home.Y == 2099 )
					{
						Body = 0x191;
						Name = "Bane";
						Title = "the sorceress";
						BaseSoundID = 0x4B0;
					}
					else if ( this is EvilMage && Home.X == 6398 && Home.Y == 1966 )
					{
						Name = "Vardion";
					}
					else if ( this is EvilMage && Home.X == 6398 && Home.Y == 1966 )
					{
						Name = "Beren";
					}
					else if ( this is EvilMage && Home.X == 6398 && Home.Y == 1966 )
					{
						Name = "Gorgrond";
					}

					Utility.AssignRandomHair( this );
					FacialHairItemID = 0;

					if ( this is EvilMageLord )
					{
						SetStr( 216, 305 );
						SetDex( 96, 115 );
						SetInt( 966, 1045 );
						SetHits( 560, 595 );
						SetDamage( 15, 27 );

						SetDamageType( ResistanceType.Physical, 20 );
						SetDamageType( ResistanceType.Cold, 40 );
						SetDamageType( ResistanceType.Energy, 40 );

						SetResistance( ResistanceType.Physical, 55, 65 );
						SetResistance( ResistanceType.Fire, 25, 30 );
						SetResistance( ResistanceType.Cold, 50, 60 );
						SetResistance( ResistanceType.Poison, 50, 60 );
						SetResistance( ResistanceType.Energy, 25, 30 );

						SetSkill( SkillName.Psychology, 120.1, 130.0 );
						SetSkill( SkillName.Magery, 120.1, 130.0 );
						SetSkill( SkillName.Meditation, 100.1, 101.0 );
						SetSkill( SkillName.Poisoning, 100.1, 101.0 );
						SetSkill( SkillName.MagicResist, 175.2, 200.0 );
						SetSkill( SkillName.Tactics, 90.1, 100.0 );
						SetSkill( SkillName.FistFighting, 75.1, 100.0 );

						Fame = 23000;
						Karma = -23000;

						VirtualArmor = 60;
					}
					else
					{
						SetStr( 416, 505 );
						SetDex( 146, 165 );
						SetInt( 566, 655 );

						SetHits( 250, 303 );

						SetDamage( 11, 13 );

						SetDamageType( ResistanceType.Physical, 0 );
						SetDamageType( ResistanceType.Cold, 60 );
						SetDamageType( ResistanceType.Energy, 40 );

						SetResistance( ResistanceType.Physical, 40, 50 );
						SetResistance( ResistanceType.Fire, 30, 40 );
						SetResistance( ResistanceType.Cold, 50, 60 );
						SetResistance( ResistanceType.Poison, 50, 60 );
						SetResistance( ResistanceType.Energy, 40, 50 );

						SetSkill( SkillName.Necromancy, 90, 110.0 );
						SetSkill( SkillName.Spiritualism, 90.0, 110.0 );

						SetSkill( SkillName.Psychology, 90.1, 100.0 );
						SetSkill( SkillName.Magery, 90.1, 100.0 );
						SetSkill( SkillName.MagicResist, 150.5, 200.0 );
						SetSkill( SkillName.Tactics, 50.1, 70.0 );
						SetSkill( SkillName.FistFighting, 60.1, 80.0 );

						Fame = 18000;
						Karma = -18000;

						VirtualArmor = 50;
					}
				}
			}

			if ( reg.IsPartOf( "the Mines of Morinia" ) )
			{
				if ( this is PoisonElemental )
				{
					this.Body = 16;
					this.BaseSoundID = 278;
				}
				else if ( this is CrystalElemental )
				{
					this.Hue = Utility.RandomList( 0x48D, 0x48E, 0x48F, 0x490, 0x491 );
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Poison, 0 );
					this.SetDamageType( ResistanceType.Physical, 20 );
					this.SetDamageType( ResistanceType.Energy, 80 );
					this.AddItem( new LightSource() );
				}
			}

			if ( reg.IsPartOf( "the Fires of Hell" ) )
			{
				if ( this is Gargoyle )
				{
					this.Name = "an ashen gargoyle";
					this.Hue = 0xB85;
				}
				else if ( this is BoneMagi )
				{
					this.Name = "a skeletal fire mage";
					this.Hue = Utility.RandomList( 0xB73, 0xB71, 0xB17, 0xAFA, 0xAC8, 0x986 );
					this.AddItem( new LightSource() );
				}
				else if ( this is SkeletalMage )
				{
					this.Name = "an undead pyromancer";
					this.Hue = Utility.RandomList( 0xB73, 0xB71, 0xB17, 0xAFA, 0xAC8, 0x986 );
					this.AddItem( new LightSource() );
				}
				else if ( this is BoneKnight )
				{
					this.Name = "a skeletal guard";
					this.Hue = Utility.RandomList( 0xB73, 0xB71, 0xB17, 0xAFA, 0xAC8, 0x986 );
					this.AddItem( new LightSource() );
				}
			}

			if ( reg.IsPartOf( "the City of Embers" ) )
			{
				if ( this is DreadSpider )
				{
					this.Name = "a vulrachnid";
					this.Hue = 0xB73;
					this.Body = 99;
					this.AddItem( new LightSource() );
				}
				else if ( this is BoneMagi )
				{
					this.Name = "an undead flamecaster";
					this.Hue = Utility.RandomList( 0xB73, 0xB71, 0xB17, 0xAFA, 0xAC8, 0x986 );
					this.AddItem( new LightSource() );
				}
				else if ( this is SkeletalMage )
				{
					this.Name = "a skeletal pyromancer";
					this.Hue = Utility.RandomList( 0xB73, 0xB71, 0xB17, 0xAFA, 0xAC8, 0x986 );
					this.AddItem( new LightSource() );
				}
				else if ( this is BoneKnight )
				{
					this.Name = "a firebone warrior";
					this.Hue = Utility.RandomList( 0xB73, 0xB71, 0xB17, 0xAFA, 0xAC8, 0x986 );
					this.AddItem( new LightSource() );
				}
			}

			if ( reg.IsPartOf( "Dungeon Hythloth" ) )
			{
				if ( this is LichLord )
				{
					this.Title = "the high pharaoh";
					this.Hue = 0x9C4;
					this.Body = 125;
				}
				else if ( this is Lich )
				{
					this.Title = "the pharaoh";
					this.Hue = 0x9DF;
					this.Body = 125;
				}
				else if ( this is Gazer )
				{
					this.Name = "a watcher";
					this.Hue = 0x96D;
				}
				else if ( this is ElderGazer )
				{
					this.Name = "a tomb watcher";
					this.Hue = 0x9D1;
					this.Body = 674;
				}
				else if ( this is Gargoyle )
				{
					this.Name = "a sand gargoyle";
					this.Hue = 0x96D;
					this.PackItem( new Sand( Utility.RandomMinMax( 1, 2 ) ) );
				}
			}

			if ( reg.IsPartOf( "the Ruins of the Black Blade" ) )
			{
				if ( this is Gazer ){ this.Name = "a seeker"; }
				if ( this is StoneElemental ){ this.Name = "a stone golem"; }
			}

			if ( reg.IsPartOf( "the Ancient Crash Site" ) || reg.IsPartOf( "the Ancient Sky Ship" ) )
			{
				if ( this is Fungal ){ this.Name = "a mushroom man"; this.Hue=0x48F; this.AddItem( new LightSource() ); }
				else if ( this is FungalMage ){ this.Name = "a psychic mushroom"; this.Hue=0xABA; this.AddItem( new LightSource() ); }
				else if ( this is ToxicElemental ){ this.Name = "a toxic waste elemental"; this.Hue=0xBA1; this.AddItem( new LighterSource() ); this.Body = 707;}
				else if ( this is PoisonBeetle ){ this.Name = "a rad beetle"; this.Hue=0xB07; this.AddItem( new LighterSource() ); }
				else if ( this is PoisonBeetleRiding ){ this.Name = "a rad beetle"; this.Hue=0xB07; this.AddItem( new LighterSource() ); }
				else if ( this is ElectricalElemental ){ this.Name = "a plasma elemental"; this.Hue=0xB53; }
				else if ( this is Stirge ){ this.Name = "a mynock"; this.Body = 742; }
				else if ( this is BloodElemental )
				{
					this.AddItem( new LighterSource() );
					if ( this.X > 954 && this.Y > 3771 && this.X < 976 && this.Y < 3793 ) { this.Name = "a coolant elemental"; this.Hue = 0xB73; }
					else { this.Name = "a contaminated elemental"; this.Hue = 0xBAD; }
				}
			}

			if ( Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) ) && Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) == "the Savaged Empire" )
			{
				if ( this is HugeLizard )
				{
					this.Body = 456;
					this.Hue = Utility.RandomList( 0x7D1, 0x7D2, 0x7D3, 0x7D4, 0x7D5, 0x7D6 );
					this.Name = "a gator";
					BeefUp( this, 3 );
				}
				if ( this is MountainGoat )
				{
					this.Body = 936;
					this.Name = "a ram";
					BeefUp( this, 3 );
				}
			}

			if ( Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( this.Map, this.Location ) ) )
			{
				if ( this is AntaurSoldier )
				{
					this.Body = 458;
					this.Name = "an antaur";
				}
			}

			if ( reg.IsPartOf( "the Forgotten Halls" ) )
			{
				if ( this is Daemon && Server.Misc.SummonQuests.IsInLocation( this.Home.X, this.Home.Y, this.Map, 409, 3670, Map.SavagedEmpire ) )
				{
					switch ( Utility.Random( 5 ) )
					{
						case 0: this.Title = "the daemon of filth"; break;
						case 1: this.Title = "the daemon of crud"; break;
						case 2: this.Title = "the daemon of grime"; break;
						case 3: this.Title = "the daemon of sludge"; break;
						case 4: this.Title = "the daemon of the putrid"; break;
					}
				}
				if ( this is ToxicElemental ){ this.Name = "a sewage elemental"; this.Hue = Hue = 0xB97; }
				if ( this is ForestGiant ){ this.Hue = Hue = 0xB97; this.Title = "the sludge giant"; }
				if ( this is AncientLich )
				{
					this.Hue = Hue = 0x967;
					this.Title = "the shadow lich";

					if ( Utility.Random( 3 ) == 1 )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0: BoneArms radarm = new BoneArms(); 		radarm.Name = "shadow lich arms"; 		radarm.Hue = 0x497; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radarm, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); 	this.PackItem( radarm ); 	break;
							case 1: BoneChest radchest = new BoneChest(); 	radchest.Name = "shadow lich chest"; 	radchest.Hue = 0x497; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radchest, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); this.PackItem( radchest ); 	break;
							case 2: BoneGloves radglove = new BoneGloves(); radglove.Name = "shadow lich gloves"; 	radglove.Hue = 0x497; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radglove, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); this.PackItem( radglove ); 	break;
							case 3: BoneLegs radleg = new BoneLegs(); 		radleg.Name = "shadow lich leggings"; 	radleg.Hue = 0x497; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radleg, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); 	this.PackItem( radleg ); 	break;
							case 4: BoneHelm radhelm = new BoneHelm(); 		radhelm.Name = "shadow lich helm"; 		radhelm.Hue = 0x497; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radhelm, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); 	this.PackItem( radhelm ); 	break;
						}
					}
				}
				if ( this is SkeletalKnight )
				{
					this.Name = "a rotting skeleton";
					this.Hue = 0xB97;
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Physical, 60 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					this.SetDamageType( ResistanceType.Poison, 40 );
					this.Body = Utility.RandomList( 57, 50, 56 );

					List<Item> belongings = new List<Item>();
					foreach( Item i in this.Backpack.Items )
					{
						belongings.Add(i);
					}
					foreach ( Item stuff in belongings )
					{
						stuff.Delete();
					}

					GenerateLoot( true );

					if ( Utility.Random( 4 ) == 1 )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0: BoneArms radarm = new BoneArms(); 		radarm.Name = "rotting bone arms"; 		radarm.Hue = 0xB97; 	radarm.PoisonBonus = 10; 	this.PackItem( radarm ); 	break;
							case 1: BoneChest radchest = new BoneChest(); 	radchest.Name = "rotting bone chest"; 	radchest.Hue = 0xB97; 	radchest.PoisonBonus = 10; 	this.PackItem( radchest ); 	break;
							case 2: BoneGloves radglove = new BoneGloves(); radglove.Name = "rotting bone gloves"; 	radglove.Hue = 0xB97; 	radglove.PoisonBonus = 10; 	this.PackItem( radglove ); 	break;
							case 3: BoneLegs radleg = new BoneLegs(); 		radleg.Name = "rotting bone leggings"; 	radleg.Hue = 0xB97; 	radleg.PoisonBonus = 10; 	this.PackItem( radleg ); 	break;
							case 4: BoneHelm radhelm = new BoneHelm(); 		radhelm.Name = "rotting bone helm"; 	radhelm.Hue = 0xB97; 	radhelm.PoisonBonus = 10; 	this.PackItem( radhelm ); 	break;
						}
					}

					if ( this.Body == 56 || this.Body == 168 ){ BattleAxe radaxe = new BattleAxe(); radaxe.Name = "rusty battle axe"; radaxe.Hue = 0xB97; radaxe.AosElementDamages.Poison=50; this.PackItem( radaxe ); }
					if ( this.Body == 57 ){ Scimitar radsim = new Scimitar(); radsim.Name = "rusty scimitar"; radsim.Hue = 0xB97;	radsim.AosElementDamages.Poison=50; this.PackItem( radsim ); }
					if ( this.Body == 170 || this.Body == 327 ){ Longsword radswd = new Longsword(); radswd.Name = "rusty longsword"; radswd.Hue = 0xB97;	radswd.AosElementDamages.Poison=50; this.PackItem( radswd ); }
					if ( this.Body == 57 || this.Body == 168 || this.Body == 170 ){ WoodenShield radshield = new WoodenShield(); radshield.Name = "rotting shield"; radshield.Hue = 0xB97; radshield.PoisonBonus = 5; this.PackItem( radshield ); }
				}
			}

			if ( reg.IsPartOf( "the Tomb of Kazibal" ) )
			{
				if ( this is AncientLich )
				{
					this.Hue = Hue = 0x83B;
					this.Name = "Kazibal";
					this.Title = "the unearthed";

					if ( Utility.Random( 3 ) == 1 )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0: BoneArms radarm = new BoneArms(); 		radarm.Name = "Kazibal bone arms"; 		radarm.Hue = 0x83B; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radarm, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); 	this.PackItem( radarm ); 	break;
							case 1: BoneChest radchest = new BoneChest(); 	radchest.Name = "Kazibal bone chest"; 	radchest.Hue = 0x83B; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radchest, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); this.PackItem( radchest ); 	break;
							case 2: BoneGloves radglove = new BoneGloves(); radglove.Name = "Kazibal bone gloves"; 	radglove.Hue = 0x83B; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radglove, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); this.PackItem( radglove ); 	break;
							case 3: BoneLegs radleg = new BoneLegs(); 		radleg.Name = "Kazibal bone leggings"; 	radleg.Hue = 0x83B; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radleg, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); 	this.PackItem( radleg ); 	break;
							case 4: BoneHelm radhelm = new BoneHelm(); 		radhelm.Name = "Kazibal bone helm"; 	radhelm.Hue = 0x83B; 	BaseRunicTool.ApplyAttributesTo( (BaseArmor)radhelm, false, 1000, Utility.RandomMinMax( 4, 8 ), 50, 125 ); 	this.PackItem( radhelm ); 	break;
						}
					}
				}
			}

			if ( reg.IsPartOf( "the Stygian Abyss" ) )
			{
				if ( this is SerpynSorceress )
				{
					this.Hue = 0xB79;
					this.Body = 306;
					this.BaseSoundID = 639;
					this.Name = NameList.RandomName( "lizardman" );
					this.Title = "the silisk sorcerer";
				}
				else if ( this is Sleestax )
				{
					this.Title = "the silisk";
				}
				else if ( this is Grathek )
				{
					this.Title = "the silisk guard";
				}
			}

			if ( reg.IsPartOf( "the Sanctum of Saltmarsh" ) )
			{
				if ( this is Tyranasaur )
				{
					this.Hue = 0xB51;
				}
				else if ( this is Raptor )
				{
					this.Hue = 0xB51;
				}
				else if ( this is Stegosaurus )
				{
					this.Name = "a scalosaur";
					this.Hue = 0xB18;
					AI = AIType.AI_Melee;
					FightMode = FightMode.Closest;
					Karma = 0 - Fame;
				}
			}

			if ( reg.IsPartOf( "the Hall of the Mountain King" ) )
			{
				if ( this is StygianGargoyleLord )
				{
					this.Name = "a gargoyle";
				}
				else if ( this is Sleestax )
				{
					this.Title = "the silisk";
				}
				else if ( this is MountainGiant && this.X >= 5158 && this.Y >= 2705 && this.X <= 5243 && this.Y <= 2813 )
				{
					this.Hue = 0;
					this.Name = "a stone guard";
					this.Body = 450;
					this.Title = "";
					this.BaseSoundID = 268;
				}
			}

			if ( reg.IsPartOf( "Argentrock Castle" ) )
			{
				if ( this is ElderTitan )
				{
					this.Title = "the ancient titan";
				}
				else if ( this is StygianGargoyleLord )
				{
					this.Name = "an elder gargoyle";
				}
				else if ( this is StygianGargoyle )
				{
					this.Name = "a gargoyle";
				}
				else if ( this is HarpyElder )
				{
					this.Name = "a harpy";
				}
				else if ( this is Griffon || this is GriffonRiding )
				{
					AI = AIType.AI_Melee;
					FightMode = FightMode.Closest;
					Karma = 0 - Fame;
					Tamable = false;
				}
				else if ( this is AnyStatue )
				{
					Body = 303;
				}
			}

			if ( reg.IsPartOf( "the Undersea Castle" ) )
			{
				CantWalk = false; // SOME OF THESE SETTINGS KEEP SWIMMERS ON THE STONE AND OFF THE WATER IN THESE DUNGEONS
				CanSwim = false;

				Location = Home;
			}

			if ( reg.IsPartOf( "the Depths of Carthax Lake" ) )
			{
				CantWalk = false; // SOME OF THESE SETTINGS KEEP SWIMMERS ON THE STONE AND OFF THE WATER IN THESE DUNGEONS
				CanSwim = false;

				if ( this is WaterBeetleRiding || this is WaterBeetle )
				{
					this.Body = 0xF4;
					this.Hue = 0xB48;
				}
				else if ( this is Sleestax )
				{
					this.Title = "the silisk";
				}
				else if ( this is GiantEel )
				{
					this.Body = 21;
					this.Hue = 0xB9D;
				}
				else if ( this is GiantSquid )
				{
					this.Title = "squid tentacles";
					this.Hue = 0xB75;
				}

				Location = Home;
			}

			if ( reg.IsPartOf( "the Dragon's Maw" ) )
			{
				if ( this is BoneKnight )
				{
					this.Name = "a skeleton";
					this.Hue = 0x48F;
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Physical, 20 );
					this.SetDamageType( ResistanceType.Energy, 40 );
					this.SetDamageType( ResistanceType.Poison, 40 );
					this.Body = Utility.RandomList( 57, 50, 56 );
					this.AddItem( new LightSource() );

					List<Item> belongings = new List<Item>();
					foreach( Item i in this.Backpack.Items )
					{
						belongings.Add(i);
					}
					foreach ( Item stuff in belongings )
					{
						stuff.Delete();
					}

					GenerateLoot( true );

					if ( Utility.Random( 4 ) == 1 )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0: BoneArms radarm = new BoneArms(); 		radarm.Name = "irradiated bone arms"; 		radarm.Hue = 0x48F; 	radarm.PoisonBonus = 10; 	this.PackItem( radarm ); 	break;
							case 1: BoneChest radchest = new BoneChest(); 	radchest.Name = "irradiated bone chest"; 	radchest.Hue = 0x48F; 	radchest.PoisonBonus = 10; 	this.PackItem( radchest ); 	break;
							case 2: BoneGloves radglove = new BoneGloves(); radglove.Name = "irradiated bone gloves"; 	radglove.Hue = 0x48F; 	radglove.PoisonBonus = 10; 	this.PackItem( radglove ); 	break;
							case 3: BoneLegs radleg = new BoneLegs(); 		radleg.Name = "irradiated bone leggings"; 	radleg.Hue = 0x48F; 	radleg.PoisonBonus = 10; 	this.PackItem( radleg ); 	break;
							case 4: BoneHelm radhelm = new BoneHelm(); 		radhelm.Name = "irradiated bone helm"; 		radhelm.Hue = 0x48F; 	radhelm.PoisonBonus = 10; 	this.PackItem( radhelm ); 	break;
						}
					}

					if ( this.Body == 56 || this.Body == 168 ){ BattleAxe radaxe = new BattleAxe(); radaxe.Name = "irradiated battle axe"; radaxe.Hue = 0x48F; radaxe.AosElementDamages.Poison=50; this.PackItem( radaxe ); }
					if ( this.Body == 57 ){ Scimitar radsim = new Scimitar(); radsim.Name = "irradiated scimitar"; radsim.Hue = 0x48F;	radsim.AosElementDamages.Poison=50; this.PackItem( radsim ); }
					if ( this.Body == 170 || this.Body == 327 ){ Longsword radswd = new Longsword(); radswd.Name = "irradiated longsword"; radswd.Hue = 0x48F;	radswd.AosElementDamages.Poison=50; this.PackItem( radswd ); }
					if ( this.Body == 57 || this.Body == 168 || this.Body == 170 ){ WoodenShield radshield = new WoodenShield(); radshield.Name = "irradiated shield"; radshield.Hue = 0x48F; radshield.PoisonBonus = 5; this.PackItem( radshield ); }
				}
				else if ( this is CrystalElemental )
				{
					this.Hue = Utility.RandomList( 0x48D, 0x48E, 0x48F, 0x490, 0x491 );
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Poison, 0 );
					this.SetDamageType( ResistanceType.Physical, 20 );
					this.SetDamageType( ResistanceType.Energy, 80 );
					this.AddItem( new LightSource() );
				}
				else if ( this is FloatingEye )
				{
					this.Hue = 0x494;
					this.Name = "an eye of the void";
				}
			}

			if ( reg.IsPartOf( "the Catacombs of Azerok" ) )
			{
				if ( this is BoneKnight )
				{
					this.Name = "a rotting skeleton";
					this.Hue = 0xB97;
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Physical, 60 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					this.SetDamageType( ResistanceType.Poison, 40 );
					this.Body = Utility.RandomList( 57, 50, 56 );

					List<Item> belongings = new List<Item>();
					foreach( Item i in this.Backpack.Items )
					{
						belongings.Add(i);
					}
					foreach ( Item stuff in belongings )
					{
						stuff.Delete();
					}

					GenerateLoot( true );

					if ( Utility.Random( 4 ) == 1 )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0: BoneArms radarm = new BoneArms(); 		radarm.Name = "rotting bone arms"; 		radarm.Hue = 0xB97; 	radarm.PoisonBonus = 10; 	this.PackItem( radarm ); 	break;
							case 1: BoneChest radchest = new BoneChest(); 	radchest.Name = "rotting bone chest"; 	radchest.Hue = 0xB97; 	radchest.PoisonBonus = 10; 	this.PackItem( radchest ); 	break;
							case 2: BoneGloves radglove = new BoneGloves(); radglove.Name = "rotting bone gloves"; 	radglove.Hue = 0xB97; 	radglove.PoisonBonus = 10; 	this.PackItem( radglove ); 	break;
							case 3: BoneLegs radleg = new BoneLegs(); 		radleg.Name = "rotting bone leggings"; 	radleg.Hue = 0xB97; 	radleg.PoisonBonus = 10; 	this.PackItem( radleg ); 	break;
							case 4: BoneHelm radhelm = new BoneHelm(); 		radhelm.Name = "rotting bone helm"; 	radhelm.Hue = 0xB97; 	radhelm.PoisonBonus = 10; 	this.PackItem( radhelm ); 	break;
						}
					}

					if ( this.Body == 56 || this.Body == 168 ){ BattleAxe radaxe = new BattleAxe(); radaxe.Name = "rusty battle axe"; radaxe.Hue = 0xB97; radaxe.AosElementDamages.Poison=50; this.PackItem( radaxe ); }
					if ( this.Body == 57 ){ Scimitar radsim = new Scimitar(); radsim.Name = "rusty scimitar"; radsim.Hue = 0xB97;	radsim.AosElementDamages.Poison=50; this.PackItem( radsim ); }
					if ( this.Body == 170 || this.Body == 327 ){ Longsword radswd = new Longsword(); radswd.Name = "rusty longsword"; radswd.Hue = 0xB97;	radswd.AosElementDamages.Poison=50; this.PackItem( radswd ); }
					if ( this.Body == 57 || this.Body == 168 || this.Body == 170 ){ WoodenShield radshield = new WoodenShield(); radshield.Name = "rotting shield"; radshield.Hue = 0xB97; radshield.PoisonBonus = 5; this.PackItem( radshield ); }
				}
			}

			if ( reg.IsPartOf( "the Tower of Brass" ) )
			{
				if ( this is BloodDemon )
				{
					this.Hue = 0x480;
					this.Body = 9;
					switch ( Utility.RandomMinMax( 0, 5 ) )
					{
						case 0: this.Title = "the ice daemon";			break;
						case 1: this.Title = "the daemon of ice";		break;
						case 2: this.Title = "of the icy veil";			break;
						case 3: this.Title = "of the frozen void";		break;
						case 4: this.Title = "of the frozen wastes";	break;
						case 5: this.Title = "of the icy depths";		break;
					}
				}
				else if ( this is CrystalElemental )
				{
					this.Hue = Utility.RandomList( 0x54B, 0x54C, 0x54D, 0x54E, 0x54F, 0x550 );
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 50 );
					this.SetDamageType( ResistanceType.Poison, 0 );
					this.SetDamageType( ResistanceType.Physical, 50 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					this.AddItem( new LightSource() );
				}
				else if ( this is Brigand )
				{
					for ( int i = 0; i < this.Items.Count; ++i )
					{
						Item item = this.Items[i];

						if ( item is Hair || item is Beard )
						{
							item.Hue = 0x455;
						}
						else if ( ( item is BasePants ) || ( item is BaseOuterLegs ) )
						{
							item.Delete();
							AddItem( new Kilt(Utility.RandomYellowHue()) );
						}
						else if ( item is BaseClothing || item is BaseWeapon || item is BaseArmor || item is BaseTool )
						{
							item.Hue = Utility.RandomYellowHue();
						}
					}

					if ( this.FindItemOnLayer( Layer.OneHanded ) != null ) { this.FindItemOnLayer( Layer.OneHanded ).Delete(); }
					if ( this.FindItemOnLayer( Layer.TwoHanded ) != null ) { this.FindItemOnLayer( Layer.TwoHanded ).Delete(); }

					this.AddItem( new Pickaxe() );
					this.PackItem ( new CopperOre( Utility.RandomMinMax( 1, 3 ) ) );
					this.HairHue = 0x455;
					this.FacialHairHue = 0x455;
					this.Title = "the miner";
				}
				else if ( this is IronCobra )
				{
					this.Name = "a brass serpent";
					this.Hue = MaterialInfo.GetMaterialColor( "brass", "monster", 0 );
				}

				if ( this.Backpack != null && !(this is Brigand) && !(this is GhostWarrior) && !(this is GhostWizard) )
				{
					for ( int i = 0; i < this.Items.Count; ++i )
					{
						Item item = this.Items[i];

						if ( item is BaseWeapon )
						{
							BaseWeapon iweapon = (BaseWeapon)item;
							if ( Server.Misc.MaterialInfo.IsMetalItem( item ) && Utility.RandomMinMax( 1, 20 ) == 1 ){ iweapon.Resource = CraftResource.Brass; iweapon.Hue = MaterialInfo.GetMaterialColor( "brass", "", 0 ); }
							else { item.Hue = Utility.RandomYellowHue(); }
						}
						else if ( item is BaseArmor )
						{
							BaseArmor iarmor = (BaseArmor)item;
							if ( Server.Misc.MaterialInfo.IsMetalItem( item ) && Utility.RandomMinMax( 1, 20 ) == 1 ){ iarmor.Resource = CraftResource.Brass; iarmor.Hue = MaterialInfo.GetMaterialColor( "brass", "", 0 ); }
							else { item.Hue = Utility.RandomYellowHue(); }
						}
						else if ( ( item is BasePants ) || ( item is BaseOuterLegs ) )
						{
							item.Delete();
							AddItem( new Kilt(Utility.RandomYellowHue()) );
						}
						else if ( item is BaseClothing || item is BaseTool )
						{
							item.Hue = Utility.RandomYellowHue();
						}
					}

					List<Item> brasses = new List<Item>();
					foreach( Item i in this.Backpack.Items )
					{
						if ( i is BaseWeapon && Utility.RandomMinMax( 1, 20 ) == 1 )
						{
							BaseWeapon iweapon = (BaseWeapon)i;
							if ( Server.Misc.MaterialInfo.IsMetalItem( i ) ){ iweapon.Resource = CraftResource.Brass; }
						}
						else if ( i is BaseArmor && Utility.RandomMinMax( 1, 20 ) == 1 )
						{
							BaseArmor iarmor = (BaseArmor)i;
							if ( Server.Misc.MaterialInfo.IsMetalItem( i ) ){ iarmor.Resource = CraftResource.Brass; }
						}
						else if ( i is IronIngot )
						{
							brasses.Add(i);
						}
					}
					foreach ( Item brs in brasses )
					{
						this.PackItem ( new BrassIngot( brs.Amount ) );
						brs.Delete();
					}
				}
			}
			if ( reg.IsPartOf( "the Castle of Dracula" ) )
			{
				if ( this is OrcCaptain )
				{
					this.Title = "the orc miner";
					this.Body = 17;

					List<Item> belongings = new List<Item>();
					foreach( Item i in this.Backpack.Items )
					{
						belongings.Add(i);
					}
					foreach ( Item stuff in belongings )
					{
						stuff.Delete();
					}

					switch ( Utility.RandomMinMax( 0, 1 ) )
					{
						case 0: this.PackItem( new Pickaxe() ); break;
						case 1: this.PackItem( new Shovel() ); break;
					}

					this.PackItem ( new IronOre( Utility.RandomMinMax( 1, 3 ) ) );

					if ( Utility.RandomMinMax( 1, 10 ) > 3 )
					{
						switch ( Utility.RandomMinMax( 0, 5 ) )
						{
							case 0: this.PackItem( new BreadLoaf( Utility.RandomMinMax( 1, 3 ) ) ); break;
							case 1: this.PackItem( new CheeseWheel( Utility.RandomMinMax( 1, 3 ) ) ); break;
							case 2: this.PackItem( new Ribs( Utility.RandomMinMax( 1, 3 ) ) ); break;
							case 3: this.PackItem( new Apple( Utility.RandomMinMax( 1, 3 ) ) ); break;
							case 4: this.PackItem( new CookedBird( Utility.RandomMinMax( 1, 3 ) ) ); break;
							case 5: this.PackItem( new LambLeg( Utility.RandomMinMax( 1, 3 ) ) ); break;
						}
					}
					if ( Utility.RandomMinMax( 1, 10 ) > 3 )
					{
						switch ( Utility.RandomMinMax( 0, 4 ) )
						{
							case 0: this.PackItem( new BeverageBottle( BeverageType.Ale ) ); break;
							case 1: this.PackItem( new BeverageBottle( BeverageType.Wine ) ); break;
							case 2: this.PackItem( new BeverageBottle( BeverageType.Liquor ) ); break;
							case 3: this.PackItem( new Jug( BeverageType.Cider ) ); break;
							case 4: this.PackItem( new Waterskin() ); break;
						}
					}
					if ( Utility.RandomMinMax( 1, 10 ) > 3 )
					{
						switch ( Utility.RandomMinMax( 0, 2 ) )
						{
							case 0: this.PackItem( new Torch() ); break;
							case 1: this.PackItem( new Candle() ); break;
							case 2: this.PackItem( new Lantern() ); break;
						}
					}
				}
				else if ( this is BoneKnight && this.X >= 6978 && this.Y >= 1670 && this.X <= 6998 && this.Y <= 1697 )
				{
					this.Name = "a skeletal jailor";
				}
				else if ( this is LivingStoneStatue )
				{
					this.Name = "a giant statue";
					this.Body = 325;
					this.Hue = 0x847;
					BeefUp( this, 3 );
				}
				else if ( this is LivingIronStatue )
				{
					this.Hue = 0x6DF;
				}
			}
			if ( reg.IsPartOf( "Stonegate Castle" ) )
			{
				if ( this is Daemon && this.X >= 6512 && this.X <= 6551 && this.Y >= 2782 && this.Y <= 2836 )
				{
					this.Name = "Balinor";
					this.Title = "the Guardian of Stonegate";
					this.EmoteHue = 123;
					this.Body = 40;
					this.BaseSoundID = 357;
				}
				else if ( this is Daemon && this.X >= 6756 && this.X <= 6878 && this.Y>= 2464 && this.Y<= 2544 )
				{
					if ( Utility.RandomMinMax( 1, 4 ) == 1 )
					{
						Item bonearmor = new BoneChest(); bonearmor.Delete();
						int reflect = 0;

						switch ( Utility.RandomMinMax( 0, 4 ) )
						{
							case 0: bonearmor = new BoneChest(); bonearmor.Name = "daemon ash bone tunic";							reflect = 12; break;
							case 1: bonearmor = new BoneArms(); bonearmor.Name = "daemon ash bone bracers";							reflect = 8; break;
							case 2: bonearmor = new BoneLegs(); bonearmor.Name = "daemon ash bone leggings";						reflect = 10; break;
							case 3: bonearmor = new BoneGloves(); bonearmor.Name = "daemon ash bone gauntlets";						reflect = 6; break;
							case 4: bonearmor = new BoneHelm(); bonearmor.ItemID = 0x1F0C; bonearmor.Name = "daemon ash bone helm";	reflect = 6; break;
						}

						BaseArmor bones = (BaseArmor)bonearmor;
						bones.Durability = ArmorDurabilityLevel.Indestructible;
						bones.ProtectionLevel = ArmorProtectionLevel.Invulnerability;
						bones.FireBonus = 8;
						bones.Attributes.ReflectPhysical = reflect;
						bones.Hue = 0xB85;
						PackItem( bones );
					}
				}
				else if ( this is CrystalElemental )
				{
					this.Name = "a gem elemental";
					this.AddLoot( LootPack.Gems, Utility.RandomMinMax( 7, 12 ) );
					this.Hue = Utility.RandomList( 0x48D, 0x48E, 0x48F, 0x490, 0x491 );
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Poison, 0 );
					this.SetDamageType( ResistanceType.Physical, 20 );
					this.SetDamageType( ResistanceType.Energy, 80 );
					this.AddItem( new LightSource() );
				}
				else if ( this is MonstrousSpider )
				{
					this.Name = "an ash crawler";
					this.Hue = 0x774;
				}
				else if ( this is CaveLizard )
				{
					this.Name = "a stone lizard";
				}
				else if ( this is MinotaurScout )
				{
					this.Name = "a minotaur berserker";
				}
				else if ( this is SeaTroll )
				{
					this.Name = "a deep water troll";
				}
				else if ( this is OrcishLord )
				{
					this.Title = "an orc barbarian";
				}
				else if ( this is BoneKnight )
				{
					this.Name = "a burnt skeleton";
					this.Hue = 0xA78;
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 60 );
					this.SetDamageType( ResistanceType.Physical, 40 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					this.SetDamageType( ResistanceType.Poison, 0 );
					this.Body = Utility.RandomList( 57, 50, 56 );

					List<Item> belongings = new List<Item>();
					foreach( Item i in this.Backpack.Items )
					{
						belongings.Add(i);
					}
					foreach ( Item stuff in belongings )
					{
						stuff.Delete();
					}

					GenerateLoot( true );

					if ( this.Body == 50 || this.Body == 57 || ( this.Body == 56 && Utility.Random( 4 ) == 1 ) )
					{
						switch ( Utility.Random( 5 ) )
						{
							case 0: BoneArms asharm = new BoneArms(); 		asharm.Name = "burnt bone arms"; 		asharm.Hue = 0xA78; 	asharm.FireBonus = 10; 		this.PackItem( asharm ); 	break;
							case 1: BoneChest ashchest = new BoneChest(); 	ashchest.Name = "burnt bone chest"; 	ashchest.Hue = 0xA78; 	ashchest.FireBonus = 10; 	this.PackItem( ashchest ); 	break;
							case 2: BoneGloves ashglove = new BoneGloves(); ashglove.Name = "burnt bone gloves"; 	ashglove.Hue = 0xA78; 	ashglove.FireBonus = 10; 	this.PackItem( ashglove ); 	break;
							case 3: BoneLegs ashleg = new BoneLegs(); 		ashleg.Name = "burnt bone leggings"; 	ashleg.Hue = 0xA78; 	ashleg.FireBonus = 10; 		this.PackItem( ashleg ); 	break;
							case 4: BoneHelm ashhelm = new BoneHelm(); 		ashhelm.Name = "burnt bone helm"; 		ashhelm.Hue = 0xA78; 	ashhelm.FireBonus = 10; 	this.PackItem( ashhelm ); 	break;
						}
					}

					if ( this.Body == 56 || this.Body == 168 ){ BattleAxe radaxe = new BattleAxe(); radaxe.Name = "burnt battle axe"; radaxe.Hue = 0xA78; radaxe.AosElementDamages.Fire=50; this.PackItem( radaxe ); }
					if ( this.Body == 57 ){ Scimitar radsim = new Scimitar(); radsim.Name = "burnt scimitar"; radsim.Hue = 0xA78;	radsim.AosElementDamages.Fire=50; this.PackItem( radsim ); }
					if ( this.Body == 170 || this.Body == 327 ){ Longsword radswd = new Longsword(); radswd.Name = "burnt longsword"; radswd.Hue = 0xA78;	radswd.AosElementDamages.Fire=50; this.PackItem( radswd ); }
					if ( this.Body == 57 || this.Body == 168 || this.Body == 170 ){ WoodenShield radshield = new WoodenShield(); radshield.Name = "burnt shield"; radshield.Hue = 0xA78; radshield.FireBonus = 5; this.PackItem( radshield ); }
				}
			}
			if ( reg.IsPartOf( "the Ancient Elven Mine" ) || reg.IsPartOf( "the Undersea Pass" ) )
			{
				if ( this is ShamanicCyclops )
				{
					this.Name = NameList.RandomName( "giant" );
					this.Title = "the warlord";
				}
				if ( this is Urk )
				{
					this.Hue = 0x8A4;

					MorphingTime.RemoveMyClothes( this );

					Item helm = new WornHumanDeco();
						helm.Name = "orcish face";
						helm.ItemID = 0x141B;
						helm.Hue = 0x8A4;
						helm.Layer = Layer.Helm;
						AddItem( helm );

					Item boots = new Boots();
						boots.Name = "orcish boots";
						boots.Hue = 0x97D;
						AddItem( boots );

					int DressUpAs = Utility.RandomMinMax( 1, 4 );

					if ( DressUpAs == 1 )
					{
						LeatherArms drowarms = new LeatherArms();
							drowarms.Name = "drow skin arms";
							drowarms.Attributes.BonusDex = 4;
							drowarms.SkillBonuses.SetValues( 0, SkillName.MagicResist, 6 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ drowarms.LootType = LootType.Blessed; }
							drowarms.Hue = 0x966;
							AddItem( drowarms );

						LeatherChest drowchest = new LeatherChest();
							drowchest.Name = "drow skin tunic";
							drowchest.Attributes.BonusDex = 5;
							drowchest.SkillBonuses.SetValues( 0, SkillName.MagicResist, 8 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ drowchest.LootType = LootType.Blessed; }
							drowchest.Hue = 0x966;
							AddItem( drowchest );

						LeatherGloves drowgloves = new LeatherGloves();
							drowgloves.Name = "drow skin gloves";
							drowgloves.Attributes.BonusDex = 3;
							drowgloves.SkillBonuses.SetValues( 0, SkillName.MagicResist, 5 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ drowgloves.LootType = LootType.Blessed; }
							drowgloves.Hue = 0x966;
							AddItem( drowgloves );

						LeatherGorget drowgorget = new LeatherGorget();
							drowgorget.Name = "drow skin gorget";
							drowgorget.Attributes.BonusDex = 2;
							drowgorget.SkillBonuses.SetValues( 0, SkillName.MagicResist, 4 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ drowgorget.LootType = LootType.Blessed; }
							drowgorget.Hue = 0x966;
							AddItem( drowgorget );

						LeatherLegs drowlegs = new LeatherLegs();
							drowlegs.Name = "drow skin leggings";
							drowlegs.Attributes.BonusDex = 4;
							drowlegs.SkillBonuses.SetValues( 0, SkillName.MagicResist, 7 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ drowlegs.LootType = LootType.Blessed; }
							drowlegs.Hue = 0x966;
							AddItem( drowlegs );
					}
					else if ( DressUpAs == 2 )
					{
						BoneChest bonechest = new BoneChest();
							bonechest.Name = "drow bone chest piece";
							bonechest.Attributes.BonusDex = 4;
							bonechest.SkillBonuses.SetValues( 0, SkillName.MagicResist, 8 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ bonechest.LootType = LootType.Blessed; }
							bonechest.Hue = 0x966;
							AddItem( bonechest );

						BoneArms bonearms = new BoneArms();
							bonearms.Name = "drow bone bracers";
							bonearms.Attributes.BonusDex = 3;
							bonearms.SkillBonuses.SetValues( 0, SkillName.MagicResist, 6 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ bonearms.LootType = LootType.Blessed; }
							bonearms.Hue = 0x966;
							AddItem( bonearms );

						BoneLegs bonelegs = new BoneLegs();
							bonelegs.Name = "drow bone leggings";
							bonelegs.Attributes.BonusDex = 3;
							bonelegs.SkillBonuses.SetValues( 0, SkillName.MagicResist, 7 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ bonelegs.LootType = LootType.Blessed; }
							bonelegs.Hue = 0x966;
							AddItem( bonelegs );

						BoneGloves bonegloves = new BoneGloves();
							bonegloves.Name = "drow bone gauntlets";
							bonegloves.Attributes.BonusDex = 2;
							bonegloves.SkillBonuses.SetValues( 0, SkillName.MagicResist, 5 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ bonegloves.LootType = LootType.Blessed; }
							bonegloves.Hue = 0x966;
							AddItem( bonegloves );
					}
					else // MINER
					{
						LeatherGloves minegloves = new LeatherGloves();
							minegloves.Name = "miner gloves";
							minegloves.SkillBonuses.SetValues( 0, SkillName.Mining, 5 );
							if ( Utility.RandomMinMax( 1, 10 ) > 1 ){ minegloves.LootType = LootType.Blessed; }
							minegloves.Hue = 0x97D;
							AddItem( minegloves );

						Item cloth5 = new LoinCloth();
							cloth5.Hue = 0x97D;
							cloth5.Name = "orcish loin cloth";
							AddItem( cloth5 );

						AddItem( new Pickaxe() );
						this.Title = "the orc miner";
					}

					if ( DressUpAs < 3 )
					{
						BaseWeapon weapon = new BattleAxe();

						switch ( Utility.Random( 28 ))
						{
							case 0: weapon = new BattleAxe(); weapon.Name = "battle axe"; break;
							case 1: weapon = new VikingSword(); weapon.Name = "great sword"; break;
							case 2: weapon = new Halberd(); weapon.Name = "halberd"; break;
							case 3: weapon = new DoubleAxe(); weapon.Name = "double axe"; break;
							case 4: weapon = new ExecutionersAxe(); weapon.Name = "great axe"; break;
							case 5: weapon = new WarAxe(); weapon.Name = "war axe"; break;
							case 6: weapon = new TwoHandedAxe(); weapon.Name = "two handed axe"; break;
							case 7: weapon = new Cutlass(); weapon.Name = "cutlass"; break;
							case 8: weapon = new Katana(); weapon.Name = "katana"; break;
							case 9: weapon = new Kryss(); weapon.Name = "kryss"; break;
							case 10: weapon = new Broadsword(); weapon.Name = "broadsword"; break;
							case 11: weapon = new Longsword(); weapon.Name = "longsword"; break;
							case 12: weapon = new ThinLongsword(); weapon.Name = "longsword"; break;
							case 13: weapon = new Scimitar(); weapon.Name = "scimitar"; break;
							case 14: weapon = new BoneHarvester(); weapon.Name = "sickle"; break;
							case 15: weapon = new CrescentBlade(); weapon.Name = "crescent blade"; break;
							case 16: weapon = new DoubleBladedStaff(); weapon.Name = "double bladed staff"; break;
							case 17: weapon = new Pike(); weapon.Name = "pike"; break;
							case 18: weapon = new Scythe(); weapon.Name = "scythe"; break;
							case 19: weapon = new Pitchfork(); weapon.Name = "trident"; weapon.Hue = Server.Misc.MaterialInfo.PlainIronColor( weapon.ItemID ); break;
							case 20: weapon = new ShortSpear(); weapon.Name = "rapier"; break;
							case 21: weapon = new Spear(); weapon.Name = "spear"; break;
							case 22: weapon = new Club(); weapon.Name = "club"; break;
							case 23: weapon = new HammerPick(); weapon.Name = "hammer pick"; break;
							case 24: weapon = new Mace(); weapon.Name = "mace"; break;
							case 25: weapon = new Maul(); weapon.Name = "maul"; break;
							case 26: weapon = new WarHammer(); weapon.Name = "war hammer"; break;
							case 27: weapon = new WarMace(); weapon.Name = "war mace"; break;
						}

						weapon.Name = "orcish " + weapon.Name;
						weapon.Hue = 0x97D;
						weapon.MinDamage = weapon.MinDamage + 3;
						weapon.MaxDamage = weapon.MaxDamage + 5;
						AddItem( weapon );

						switch ( Utility.RandomMinMax( 0, 5 ) )
						{
							case 0: this.Title = "the orc warrior"; break;
							case 1: this.Title = "the orc savage"; break;
							case 2: this.Title = "the orc barbarian"; break;
							case 3: this.Title = "the orc fighter"; break;
							case 4: this.Title = "the orc gladiator"; break;
							case 5: this.Title = "the orc berserker"; break;
						}
					}
				}
			}
			if ( reg.IsPartOf( "the Caverns of Poseidon" ) )
			{
				if ( this is DeepSeaSerpent )
				{
					this.Name = "a great serpent";
					this.Hue = 0x67;
					this.Body = 21;
					switch ( Utility.RandomMinMax( 0, 5 ) )
					{
						case 0: this.Title = "from the frozen deep";		break;
						case 1: this.Title = "of the darkest sea";			break;
						case 2: this.Title = "from the deepest depths";		break;
						case 3: this.Title = "of the cold sea";				break;
						case 4: this.Title = "of the icy waves";			break;
						case 5: this.Title = "of the icy sea";				break;
					}
					this.AddItem( new LightSource() );
				}
				else if ( this is JadeSerpent )
				{
					this.Name = "a coldwater serpent";
					this.Hue = 0x48D;
					this.SetDamageType( ResistanceType.Cold, 50 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Poison, 0 );
					this.SetDamageType( ResistanceType.Physical, 50 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					this.AddItem( new LightSource() );
				}
				else if ( this is PirateLand || this is PirateCaptain )
				{
					for ( int i = 0; i < this.Items.Count; ++i )
					{
						Item item = this.Items[i];

						if ( item is BaseClothing || item is BaseArmor )
						{
							item.Hue = Utility.RandomBlueHue();
						}
					}
				}
				else if ( this is SeaGiant )
				{
					this.Name = NameList.RandomName( "drakkul" );
					this.Title = "the gate keeper";
				}
				else if ( this is SwampTentacle )
				{
					this.Name = "a kelp fiend";
				}
				else if ( this is BloodSnake )
				{
					this.Name = "a sea viper";
					this.Hue = 0x555;
				}
				else if ( this is LichLord )
				{
					this.Title = "the lich of the deep";
					this.Hue = 0x48D;
					this.AddItem( new LightSource() );
				}
				else if ( this is CrystalElemental )
				{
					this.Name = "a nox elemental";
					this.Hue = 0x48F;
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Poison, 50 );
					this.SetDamageType( ResistanceType.Physical, 50 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					this.AddItem( new LightSource() );
				}
				else if ( this is Devil )
				{
					this.Hue = 0x48F;
					this.AddItem( new LightSource() );
					this.SetDamageType( ResistanceType.Cold, 0 );
					this.SetDamageType( ResistanceType.Fire, 0 );
					this.SetDamageType( ResistanceType.Poison, 60 );
					this.SetDamageType( ResistanceType.Physical, 40 );
					this.SetDamageType( ResistanceType.Energy, 0 );
					switch ( Utility.RandomMinMax( 0, 5 ) )
					{
						case 0: this.Title = "the nox devil";			break;
						case 1: this.Title = "the shard devil";			break;
						case 2: this.Title = "of the poison veil";		break;
						case 3: this.Title = "of the venomous void";	break;
						case 4: this.Title = "of the foul wastes";		break;
						case 5: this.Title = "of the crystal depths";	break;
					}
				}
				else if ( this is BoneKnight )
				{
					this.Name = "a skeletal pirate";
				}
				else if ( this is AquaticGhoul )
				{
					this.Name = "a ghoulish pirate";
				}
			}

			if ( reg.IsPartOf( "the Vault of the Black Knight" ) )
			{
				if ( this is LivingShadowIronStatue ){ this.Body = 485; }
				if ( this is LivingGoldStatue ){ this.Body = 485; }
				if ( this is LivingBronzeStatue ){ this.Body = 485; }
			}

			Server.Mobiles.PremiumSpawner.SpreadOut( this );

			if ( this is BasePerson || this is BaseVendor || m_bSummoned || m_bControlled )
			{
				Heat = 0;
			}

			if ( reg.IsPartOf( "the Barge of the Dead" ) && !(this is BaseVendor) ) // NO STOWAWAYS //////////////
			{
				this.Delete();
			}

			if ( Heat > 0 && !IsParagon )
			{
				BeefUp( this, Heat );
			}

			ExtraHP();

			if ( this.Backpack != null )
			{
				int cashgrab = this.TotalGold;

				List<Item> pockets = new List<Item>();
				foreach( Item i in this.Backpack.Items )
				{
					if ( i is Gold )
					{
						pockets.Add(i);
					}
				}
				foreach ( Item coins in pockets )
				{
					coins.Delete();
				}

				if ( cashgrab > 0 )
				{
					if (	(Region.Find( this.Location, this.Map )).IsPartOf( "the Ancient Crash Site" ) ||
							(Region.Find( this.Location, this.Map )).IsPartOf( "the Ancient Sky Ship" ) )
					{
						int xormite = (int)(cashgrab/3);
						PackItem( new DDXormite( xormite ) );

						m_Coins = xormite;
						m_CoinType = "xormite";
					}
					else if ( (Region.Find( this.Location, this.Map )).IsPartOf( "the Mines of Morinia" ) && Utility.RandomMinMax( 1, 5 ) == 1 )
					{
						int crystals = (int)(cashgrab/5);
						PackItem( new Crystals( crystals ) );

						m_Coins = crystals;
						m_CoinType = "crystals";
					}
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
					{
						int jewels = (int)(cashgrab/2);
						PackItem( new DDJewels( jewels ) );

						m_Coins = jewels;
						m_CoinType = "jewels";
					}
					else
					{
						m_Coins = cashgrab;
						m_CoinType = "gold";

						cashgrab = cashgrab * 10;

						if (Utility.RandomMinMax( 1, 100 ) > 99)
						{
							int nGm = 20;
							int nGms = (int)Math.Floor((decimal)(cashgrab/nGm));
							if (nGms > 0)
							{
								int nGemstones = Utility.RandomMinMax( 1, nGms );
									if ( nGemstones < 10 ){ nGemstones = Utility.RandomMinMax( 10, 15 ); }
								PackItem( new DDGemstones( nGemstones ) );
								cashgrab = cashgrab - (nGemstones * nGm);
							}
						}
						if (Utility.RandomMinMax( 1, 100 ) > 95)
						{
							int nGs = 10;
							int nGps = (int)Math.Floor((decimal)(cashgrab/nGs));
							if (nGps > 0)
							{
								int nNuggets = Utility.RandomMinMax( 1, nGps );
									if ( nNuggets < 10 ){ nNuggets = Utility.RandomMinMax( 10, 15 ); }
								PackItem( new DDGoldNuggets( nNuggets ) );
								cashgrab = cashgrab - (nNuggets * nGs);
							}
						}
						if (Utility.RandomMinMax( 1, 100 ) > 66)
						{
							int nGp = 10;
							int nGpp = (int)Math.Floor((decimal)(cashgrab/nGp));
							if (nGpp > 0)
							{
								int nGold = Utility.RandomMinMax( 1, nGpp );
									if ( nGold < 10 ){ nGold = Utility.RandomMinMax( 10, 15 ); }
								PackItem( new Gold( nGold ) );
								cashgrab = cashgrab - (nGold * nGp);
							}
						}
						if (Utility.RandomMinMax( 1, 100 ) > 33)
						{
							int nSp = 5;
							int nSpp = (int)Math.Floor((decimal)(cashgrab/nSp));
							if (nSpp > 0)
							{
								int nSilver = Utility.RandomMinMax( 1, nSpp );
									if ( nSilver < 10 ){ nSilver = Utility.RandomMinMax( 10, 15 ); }
								PackItem( new DDSilver( nSilver ) );
								cashgrab = cashgrab - (nSilver * nSp);
							}
						}
						if (cashgrab > 0){ if ( cashgrab < 10 ){ cashgrab = Utility.RandomMinMax( 10, 15 ); } PackItem( new DDCopper( cashgrab ) ); }
					}
				}
			}

			if ( this.Body != 400 && this.Body != 401 ){ this.TithingPoints = this.Body; } // STORE THE BODY VALUE IN AN UNUSED VARIABLE FOR NECRO ANIMATE

			NameColor();
			ProcessClothing();
		}

		public override ApplyPoisonResult ApplyPoison( Mobile from, Poison poison )
		{
			if ( !Alive || IsDeadPet )
				return ApplyPoisonResult.Immune;

			if ( Spells.Necromancy.EvilOmenSpell.TryEndEffect( this ) )
				poison = PoisonImpl.IncreaseLevel( poison );

			ApplyPoisonResult result = base.ApplyPoison( from, poison );

			if ( from != null && result == ApplyPoisonResult.Poisoned && PoisonTimer is PoisonImpl.PoisonTimer )
				(PoisonTimer as PoisonImpl.PoisonTimer).From = from;

			return result;
		}

		public override bool CheckPoisonImmunity( Mobile from, Poison poison )
		{
			if ( base.CheckPoisonImmunity( from, poison ) )
				return true;

			Poison p = this.PoisonImmune;

			return ( p != null && p.Level >= poison.Level );
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Loyalty
		{
			get
			{
				return m_Loyalty;
			}
			set
			{
				m_Loyalty = Math.Min( Math.Max( value, 0 ), MaxLoyalty );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint CurrentWayPoint
		{
			get
			{
				return m_CurrentWayPoint;
			}
			set
			{
				m_CurrentWayPoint = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public IPoint2D TargetLocation
		{
			get
			{
				return m_TargetLocation;
			}
			set
			{
				m_TargetLocation = value;
			}
		}

		public virtual Mobile ConstantFocus{ get{ return null; } }

		public virtual bool DisallowAllMoves
		{
			get
			{
				return false;
			}
		}

		public virtual bool InitialInnocent
		{
			get
			{
				return false;
			}
		}

		public virtual bool AlwaysMurderer
		{
			get
			{
				return false;
			}
		}

		public virtual bool AlwaysAttackable
		{
			get
			{
				return false;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int DamageMin{ get{ return m_DamageMin; } set{ m_DamageMin = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int DamageMax{ get{ return m_DamageMax; } set{ m_DamageMax = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public override int HitsMax
		{
			get
			{
				if ( m_HitsMax > 0 ) {
					int value = m_HitsMax + GetStatOffset( StatType.Str );

					if( value < 1 )
						value = 1;
					else if( value > 65000 )
						value = 65000;

					return value;
				}

				return Str;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int HitsMaxSeed
		{
			get{ return m_HitsMax; }
			set{ m_HitsMax = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int StamMax
		{
			get
			{
				if ( m_StamMax > 0 ) {
					int value = m_StamMax + GetStatOffset( StatType.Dex );

					if( value < 1 )
						value = 1;
					else if( value > 65000 )
						value = 65000;

					return value;
				}

				return Dex;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int StamMaxSeed
		{
			get{ return m_StamMax; }
			set{ m_StamMax = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ManaMax
		{
			get
			{
				if ( m_ManaMax > 0 ) {
					int value = m_ManaMax + GetStatOffset( StatType.Int );

					if( value < 1 )
						value = 1;
					else if( value > 65000 )
						value = 65000;

					return value;
				}

				return Int;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int ManaMaxSeed
		{
			get{ return m_ManaMax; }
			set{ m_ManaMax = value; }
		}

		public virtual bool CanOpenDoors
		{
			get
			{
				return !this.Body.IsAnimal && !this.Body.IsSea;
			}
		}

		public virtual bool CanMoveOverObstacles
		{
			get
			{
				return Core.AOS || this.Body.IsMonster;
			}
		}

		public virtual bool CanDestroyObstacles
		{
			get
			{
				// to enable breaking of furniture, 'return CanMoveOverObstacles;'
				return false;
			}
		}

		public void Unpacify()
		{
			BardEndTime = DateTime.Now;
			BardPacified = false;
		}

		private HonorContext m_ReceivedHonorContext;

		public HonorContext ReceivedHonorContext{ get{ return m_ReceivedHonorContext; } set{ m_ReceivedHonorContext = value; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( BardPacified && (HitsMax - Hits) * 0.001 > Utility.RandomDouble() )
				Unpacify();

			// OCEAN MONSTERS SHOULD NOT GET ARROWS JUST HITTING THEM BECAUSE THEY CANNOT NAVIGATE THE SHORE
			// SO THEY WILL LEAP AT AN ATTACKER ON SHORE IF THEY GET HURT FROM THEM
			if ( !(CanOnlyMoveOnSea()) && this.WhisperHue == 999 && this.Z < -2 && from.Z >=0 && from is PlayerMobile && from.InRange( this.Location, 15 ) && from.Alive && from.Map == this.Map && CanSee( from ) && !Server.Mobiles.BasePirate.IsSailor( this ) )
			{
				this.Home = this.Location; // SO THEY KNOW WHERE TO GO BACK TO
				from.PlaySound( 0x026 );
				Effects.SendLocationEffect( from.Location, from.Map, 0x23B2, 16 );
				this.Location = from.Location;
				this.Warmode = true;
				this.Combatant = from;
				this.CantWalk = m_NoWalker;
				this.CanSwim = m_Swimmer;
				this.Hidden = false;
			}

			int disruptThreshold;
			//NPCs can use bandages too!
			if( !Core.AOS )
				disruptThreshold = 0;
			else if( from != null && from.Player )
				disruptThreshold = 18;
			else
				disruptThreshold = 25;

			if( amount > disruptThreshold )
			{
				BandageContext c = BandageContext.GetContext( this );

				if( c != null )
					c.Slip();
			}

			if( Confidence.IsRegenerating( this ) )
				Confidence.StopRegenerating( this );

			WeightOverloading.FatigueOnDamage( this, amount );

			InhumanSpeech speechType = this.SpeechType;

			if ( speechType != null && !willKill )
				speechType.OnDamage( this, amount );

			if ( !Summoned && willKill )
			{
				Mobile leveler = from;

				if ( leveler is BaseCreature )
					leveler = ((BaseCreature)leveler).GetMaster();

				if ( leveler is PlayerMobile )
				{
					LevelItemManager.CheckItems( leveler, this );
				}
			}

			if ( m_ReceivedHonorContext != null )
				m_ReceivedHonorContext.OnTargetDamaged( from, amount );

			if ( willKill && from is PlayerMobile )
				Timer.DelayCall( TimeSpan.FromSeconds( 10 ), new TimerCallback( ((PlayerMobile) from).RecoverAmmo ) );

			base.OnDamage( amount, from, willKill );
		}

		public virtual void OnDamagedBySpell( Mobile from )
		{
		}

		public virtual void OnHarmfulSpell( Mobile from )
		{
		}

		#region Alter[...]Damage From/To

		public virtual void AlterDamageScalarFrom( Mobile caster, ref double scalar )
		{
		}

		public virtual void AlterDamageScalarTo( Mobile target, ref double scalar )
		{
		}

		public virtual void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
		}

		public virtual void AlterSpellDamageTo( Mobile to, ref int damage )
		{
		}

		public virtual void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
		}

		public virtual void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
		}

		#endregion

		public virtual void CheckReflect( Mobile caster, ref bool reflect )
		{
		}

		public virtual void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			int feathers = Feathers;
			int wool = Wool;
			int meat = Meat;
			int hides = Hides;
			int scales = Scales;
			int furs = Furs;

			SlayerEntry giant = SlayerGroup.GetEntryByName( SlayerName.GiantKiller );
			Mobile frank = corpse.m_Owner;

			if ( from.Backpack.FindItemByType( typeof ( FrankenJournal ) ) != null && !(corpse.VisitedByTaxidermist) && from.Skills[SkillName.Forensics].Value >= Utility.RandomMinMax( 30, 250 ) && giant.Slays(frank) )
			{
				Item piece = new FrankenLegLeft(); piece.Delete();

				switch ( Utility.Random( 7 ) )
				{
					case 0: piece = new FrankenLegLeft(); from.SendMessage("You sever off the giant's left leg."); break;
					case 1: piece = new FrankenLegRight(); from.SendMessage("You sever off the giant's right leg."); break;
					case 2: piece = new FrankenArmLeft(); from.SendMessage("You sever off the giant's left arm."); break;
					case 3: piece = new FrankenArmRight(); from.SendMessage("You sever off the giant's right arm."); break;
					case 4: piece = new FrankenHead(); from.SendMessage("You sever off the giant's head."); break;
					case 5: piece = new FrankenTorso(); from.SendMessage("You sever apart the giant's torso."); break;
					case 6: piece = new FrankenBrain(); from.SendMessage("You remove the giant's fresh brain."); break;
				}

				if ( piece is FrankenBrain )
				{
					FrankenBrain brain = (FrankenBrain)piece;

					string brainName = frank.Name;
						if ( frank.Title != "" ){ brainName = brainName + " " + frank.Title; }

					brain.BrainSource = brainName;
					brain.BrainLevel = ( IntelligentAction.GetCreatureLevel( frank ) + 5 ); // TITAN LICHES SEEM TO HAVE LEVEL 96 BRAINS
						if ( brain.BrainLevel > 100 ){ brain.BrainLevel = 100; }
				}

				from.AddToBackpack( piece );
			}

			if ( (feathers == 0 && wool == 0 && meat == 0 && hides == 0 && scales == 0 && furs == 0) || Summoned || IsBonded || corpse.Animated )
			{
				if ( corpse.Animated )
					corpse.SendLocalizedMessageTo( from, 500464 );	// Use this on corpses to carve away meat and hide
				else
				from.SendLocalizedMessage( 500485 ); // You see nothing useful to carve from the corpse.
			}
			else
			{
				int resource = 2 * ( Server.Misc.MyServerSettings.Resources() - 1 );

				if ( feathers > 0 ){ feathers += resource; }
				if ( hides > 0 ){ hides += resource; }
				if ( meat > 0 ){ meat += resource; }
				if ( scales > 0 ){ scales += resource; }
				if ( furs > 0 ){ furs += resource; }

				if ( Worlds.GetMyWorld( from.Map, from.Location, from.X, from.Y ) == "the Isles of Dread" )
				{
					if ( feathers > 0 ){ feathers = feathers + (int)(feathers/2) + Utility.RandomMinMax(1,5); }
					if ( wool > 0 ){ wool = wool + (int)(wool/2) + Utility.RandomMinMax(1,5); }
					if ( hides > 0 ){ hides = hides + (int)(hides/2) + Utility.RandomMinMax(1,5); }
					if ( meat > 0 ){ meat = meat + (int)(meat/2) + Utility.RandomMinMax(1,5); }
					if ( scales > 0 ){ scales = scales + (int)(scales/2) + Utility.RandomMinMax(1,5); }
					if ( furs > 0 ){ furs = furs + (int)(furs/2) + Utility.RandomMinMax(1,5); }
				}

				if ( ( from.CheckSkill( SkillName.Forensics, 0, 100 ) ) && ( from.Skills[SkillName.Forensics].Base >= 5.0 ) )
				{
					if (feathers > 0){ feathers = feathers + (int)(from.Skills[SkillName.Forensics].Value/25) + (int)(from.Skills[SkillName.Anatomy].Value/25); }
					if (wool > 0){ wool = wool + (int)(from.Skills[SkillName.Forensics].Value/25) + (int)(from.Skills[SkillName.Anatomy].Value/25); }
					if (hides > 0){ hides = hides + (int)(from.Skills[SkillName.Forensics].Value/25) + (int)(from.Skills[SkillName.Anatomy].Value/25); }
					if (meat > 0){ meat = meat + (int)(from.Skills[SkillName.Forensics].Value/25) + (int)(from.Skills[SkillName.Anatomy].Value/25); }
					if (scales > 0){ scales = scales + (int)(from.Skills[SkillName.Forensics].Value/25) + (int)(from.Skills[SkillName.Anatomy].Value/25); }
					if (furs > 0){ furs = furs + (int)(from.Skills[SkillName.Forensics].Value/25) + (int)(from.Skills[SkillName.Anatomy].Value/25); }
				}

				new Blood( 0x122D ).MoveToWorld( corpse.Location, corpse.Map );

				if ( feathers != 0 )
				{
					corpse.AddCarvedItem( new Feather( feathers ), from );
					from.SendLocalizedMessage( 500479 ); // You pluck the bird. The feathers are now on the corpse.
				}

				if ( wool != 0 )
				{
					corpse.AddCarvedItem( new TaintedWool( wool ), from );
					from.SendLocalizedMessage( 500483 ); // You shear it, and the wool is now on the corpse.
				}

				if ( meat != 0 )
				{
					if ( MeatType == MeatType.Ribs )
						corpse.AddCarvedItem( new RawRibs( meat ), from );
					else if ( MeatType == MeatType.Bird )
						corpse.AddCarvedItem( new RawBird( meat ), from );
					else if ( MeatType == MeatType.LambLeg )
						corpse.AddCarvedItem( new RawLambLeg( meat ), from );
					else if ( MeatType == MeatType.Fish )
						corpse.AddCarvedItem( new RawFishSteak( meat ), from );
					else if ( MeatType == MeatType.Pigs )
						corpse.AddCarvedItem( new RawPig( meat ), from );

					from.SendLocalizedMessage( 500467 ); // You carve some meat, which remains on the corpse.
				}

				if ( furs != 0 )
				{
					if ( FurType == FurType.Regular )
						corpse.AddCarvedItem( new Furs( furs ), from );
					else if ( FurType == FurType.White )
						corpse.AddCarvedItem( new FursWhite( furs ), from );

					from.SendLocalizedMessage( 500475 );
				}

				if ( hides != 0 )
				{
					Item holding = from.Weapon as Item;
					if ( Core.AOS && ( holding is SkinningKnife /* TODO: || holding is ButcherWarCleaver || with is ButcherWarCleaver */ ) )
					{
						Item leather = null;

						switch ( HideType )
						{
							case HideType.Regular: leather = new Leather( hides ); break;
							case HideType.Spined: leather = new SpinedLeather( hides ); break;
							case HideType.Horned: leather = new HornedLeather( hides ); break;
							case HideType.Barbed: leather = new BarbedLeather( hides ); break;
							case HideType.Necrotic: leather = new NecroticLeather( hides ); break;
							case HideType.Volcanic: leather = new VolcanicLeather( hides ); break;
							case HideType.Frozen: leather = new FrozenLeather( hides ); break;
							case HideType.Goliath: leather = new GoliathLeather( hides ); break;
							case HideType.Draconic: leather = new DraconicLeather( hides ); break;
							case HideType.Hellish: leather = new HellishLeather( hides ); break;
							case HideType.Dinosaur: leather = new DinosaurLeather( hides ); break;
							case HideType.Alien: leather = new AlienLeather( hides ); break;
						}

						if ( leather != null )
						{
							if ( !from.PlaceInBackpack( leather ) )
							{
								corpse.DropItem( leather );
								from.SendLocalizedMessage( 500471 ); // You skin it, and the hides are now in the corpse.
							}
							else
								from.SendLocalizedMessage( 1073555 ); // You skin it and place the cut-up hides in your backpack.
						}
					}
					else
					{
						if ( HideType == HideType.Regular )
							corpse.DropItem( new Hides( hides ) );
						else if ( HideType == HideType.Spined )
							corpse.DropItem( new SpinedHides( hides ) );
						else if ( HideType == HideType.Horned )
							corpse.DropItem( new HornedHides( hides ) );
						else if ( HideType == HideType.Barbed )
							corpse.DropItem( new BarbedHides( hides ) );
						else if ( HideType == HideType.Necrotic )
							corpse.DropItem( new NecroticHides( hides ) );
						else if ( HideType == HideType.Volcanic )
							corpse.DropItem( new VolcanicHides( hides ) );
						else if ( HideType == HideType.Frozen )
							corpse.DropItem( new FrozenHides( hides ) );
						else if ( HideType == HideType.Goliath )
							corpse.DropItem( new GoliathHides( hides ) );
						else if ( HideType == HideType.Draconic )
							corpse.DropItem( new DraconicHides( hides ) );
						else if ( HideType == HideType.Hellish )
							corpse.DropItem( new HellishHides( hides ) );
						else if ( HideType == HideType.Dinosaur )
							corpse.DropItem( new DinosaurHides( hides ) );
						else if ( HideType == HideType.Alien )
							corpse.DropItem( new AlienHides( hides ) );

						from.SendLocalizedMessage( 500471 ); // You skin it, and the hides are now in the corpse.
					}
				}

				if ( scales != 0 )
				{
					ScaleType sc = this.ScaleType;

					switch ( sc )
					{
						case ScaleType.Red:     	corpse.AddCarvedItem( new RedScales( scales ), from ); break;
						case ScaleType.Yellow: 	 	corpse.AddCarvedItem( new YellowScales( scales ), from ); break;
						case ScaleType.Black:  	 	corpse.AddCarvedItem( new BlackScales( scales ), from ); break;
						case ScaleType.Green:   	corpse.AddCarvedItem( new GreenScales( scales ), from ); break;
						case ScaleType.White:   	corpse.AddCarvedItem( new WhiteScales( scales ), from ); break;
						case ScaleType.Blue:    	corpse.AddCarvedItem( new BlueScales( scales ), from ); break;
						case ScaleType.Dinosaur:    corpse.AddCarvedItem( new DinosaurScales( scales ), from ); break;
						case ScaleType.All:
						{
							corpse.AddCarvedItem( new RedScales( scales ), from );
							corpse.AddCarvedItem( new YellowScales( scales ), from );
							corpse.AddCarvedItem( new BlackScales( scales ), from );
							corpse.AddCarvedItem( new GreenScales( scales ), from );
							corpse.AddCarvedItem( new WhiteScales( scales ), from );
							corpse.AddCarvedItem( new BlueScales( scales ), from );
							corpse.AddCarvedItem( new DinosaurScales( scales ), from );
							break;
						}
					}

					from.SendMessage( "You cut away some scales, but they remain on the corpse." );
				}

				corpse.Carved = true;

				if ( corpse.IsCriminalAction( from ) )
					from.CriminalAction( true );
			}

			if ( 	( corpse.m_Owner is DemonOfTheSea ) ||
					( corpse.m_Owner is BloodDemon ) ||
					( corpse.m_Owner is Devil ) ||
					( corpse.m_Owner is TitanPyros ) ||
					( corpse.m_Owner is Balron ) ||
					( corpse.m_Owner is Fiend ) ||
					( corpse.m_Owner is Archfiend ) ||
					( corpse.m_Owner is LesserDemon ) ||
					( corpse.m_Owner is Xurtzar ) ||
					( corpse.m_Owner is FireDemon ) ||
					( corpse.m_Owner is DeepSeaDevil ) ||
					( corpse.m_Owner is Daemon ) ||
					( corpse.m_Owner is DaemonTemplate ) ||
					( corpse.m_Owner is BlackGateDemon ) )
			{
				if ( 90 < Utility.Random( 100 ) ){ DemonSkin goods = new DemonSkin(); goods.Amount = Utility.RandomMinMax( 1, 3 ); corpse.DropItem(goods); }
			}
			if ( ( corpse.m_Owner is Unicorn ) || ( corpse.m_Owner is Dreadhorn ) || ( corpse.m_Owner is DarkUnicorn ) || ( corpse.m_Owner is DarkUnicornRiding ) )
			{
				if ( 70 < Utility.Random( 100 ) ){ UnicornSkin goods = new UnicornSkin(); goods.Amount = Utility.RandomMinMax( 1, 3 ); corpse.DropItem(goods); }
			}
			if ( corpse.m_Owner is Nightmare || corpse.m_Owner is AncientNightmare || corpse.m_Owner is AncientNightmareRiding )
			{
				if ( 70 < Utility.Random( 100 ) ){ NightmareSkin goods = new NightmareSkin(); goods.Amount = Utility.RandomMinMax( 1, 3 ); corpse.DropItem(goods); }
			}
			if ( ( corpse.m_Owner is Troll ) || ( corpse.m_Owner is SeaTroll ) || ( corpse.m_Owner is SwampTroll ) || ( corpse.m_Owner is FrostTroll ) )
			{
				if ( 95 < Utility.Random( 100 ) ){ TrollSkin goods = new TrollSkin(); goods.Amount = Utility.RandomMinMax( 1, 2 ); corpse.DropItem(goods); }
			}
			if ( ( corpse.m_Owner is GoldenSerpent ) || ( corpse.m_Owner is BloodSnake ) || ( corpse.m_Owner is SilverSerpent ) || ( corpse.m_Owner is JungleViper ) || ( corpse.m_Owner is IceSerpent ) ||
				( corpse.m_Owner is GiantSerpent ) || ( corpse.m_Owner is GiantSnake ) || ( corpse.m_Owner is SeaSnake ) || ( corpse.m_Owner is LavaSerpent ) || ( corpse.m_Owner is LargeSnake ) || ( corpse.m_Owner is GiantAdder ) )
			{
				if ( 95 < Utility.Random( 100 ) ){ SerpentSkin goods = new SerpentSkin(); goods.Amount = Utility.RandomMinMax( 1, 2 ); corpse.DropItem(goods); }
			}
			if ( 	( corpse.m_Owner is AncientWyrm ) ||
					( corpse.m_Owner is LavaDragon ) ||
					( corpse.m_Owner is BottleDragon ) ||
					( corpse.m_Owner is SeaDragon ) ||
					( corpse.m_Owner is DeepSeaDragon ) ||
					( corpse.m_Owner is Dragon ) ||
					( corpse.m_Owner is Dragons ) ||
					( corpse.m_Owner is Dragoon ) ||
					( corpse.m_Owner is RidingDragon ) ||
					( corpse.m_Owner is DeepSeaDragon ) ||
					( corpse.m_Owner is SeaDragon ) ||
					( corpse.m_Owner is BlackDragon ) ||
					( corpse.m_Owner is AsianDragon ) ||
					( corpse.m_Owner is PrimevalFireDragon ) ||
					( corpse.m_Owner is PrimevalGreenDragon ) ||
					( corpse.m_Owner is PrimevalNightDragon ) ||
					( corpse.m_Owner is PrimevalRedDragon ) ||
					( corpse.m_Owner is PrimevalRoyalDragon ) ||
					( corpse.m_Owner is PrimevalRunicDragon ) ||
					( corpse.m_Owner is PrimevalSeaDragon ) ||
					( corpse.m_Owner is ReanimatedDragon ) ||
					( corpse.m_Owner is VampiricDragon ) ||
					( corpse.m_Owner is PrimevalAbysmalDragon ) ||
					( corpse.m_Owner is PrimevalAmberDragon ) ||
					( corpse.m_Owner is PrimevalBlackDragon ) ||
					( corpse.m_Owner is PrimevalDragon ) ||
					( corpse.m_Owner is PrimevalSilverDragon ) ||
					( corpse.m_Owner is PrimevalVolcanicDragon ) ||
					( corpse.m_Owner is PrimevalStygianDragon ) ||
					( corpse.m_Owner is GemDragon ) ||
					( corpse.m_Owner is DragonKing ) ||
					( corpse.m_Owner is VolcanicDragon ) ||
					( corpse.m_Owner is RadiationDragon ) ||
					( corpse.m_Owner is CrystalDragon ) ||
					( corpse.m_Owner is VoidDragon ) ||
					( corpse.m_Owner is ElderDragon ) ||
					( corpse.m_Owner is BlueDragon ) ||
					( corpse.m_Owner is SlasherOfVoid ) ||
					( corpse.m_Owner is GreenDragon ) ||
					( corpse.m_Owner is WhiteDragon ) ||
					( corpse.m_Owner is ZombieDragon ) ||
					( corpse.m_Owner is NightWyrm ) ||
					( corpse.m_Owner is JungleWyrm ) ||
					( corpse.m_Owner is DesertWyrm ) ||
					( corpse.m_Owner is MountainWyrm ) ||
					( corpse.m_Owner is OnyxWyrm ) ||
					( corpse.m_Owner is EmeraldWyrm ) ||
					( corpse.m_Owner is AmethystWyrm ) ||
					( corpse.m_Owner is SapphireWyrm ) ||
					( corpse.m_Owner is GarnetWyrm ) ||
					( corpse.m_Owner is TopazWyrm ) ||
					( corpse.m_Owner is RubyWyrm ) ||
					( corpse.m_Owner is SpinelWyrm ) ||
					( corpse.m_Owner is Wyrms ) ||
					( corpse.m_Owner is QuartzWyrm ) ||
					( corpse.m_Owner is WhiteWyrm ) )
			{
				if ( 95 < Utility.Random( 100 ) ){ DragonSkin goods = new DragonSkin(); goods.Amount = Utility.RandomMinMax( 1, 3 ); corpse.DropItem(goods); }
			}
		}

		public const int DefaultRangePerception = 16;
		public const int OldRangePerception = 10;

		public BaseCreature(AIType ai,
			FightMode mode,
			int iRangePerception,
			int iRangeFight,
			double dActiveSpeed,
			double dPassiveSpeed)
		{
			if ( iRangePerception == OldRangePerception )
				iRangePerception = DefaultRangePerception;

			m_Loyalty = MaxLoyalty; // Wonderfully Happy

			m_CurrentAI = ai;
			m_DefaultAI = ai;

			m_iRangePerception = iRangePerception;
			m_iRangeFight = iRangeFight;

			m_FightMode = mode;

			m_iTeam = 0;

			SpeedInfo.GetSpeeds( this, ref dActiveSpeed, ref dPassiveSpeed );

			m_dActiveSpeed = dActiveSpeed;
			m_dPassiveSpeed = dPassiveSpeed;
			m_dCurrentSpeed = dPassiveSpeed;

			m_bDebugAI = false;

			m_arSpellAttack = new List<Type>();
			m_arSpellDefense = new List<Type>();

			m_bControlled = false;
			m_ControlMaster = null;
			m_ControlTarget = null;
			m_ControlOrder = OrderType.None;

			m_bTamable = false;

			m_Owners = new List<Mobile>();

			m_NextReacquireTime = DateTime.Now + ReacquireDelay;

			ChangeAIType(AI);

			InhumanSpeech speechType = this.SpeechType;

			if ( speechType != null )
				speechType.OnConstruct( this );

			GenerateLoot( true );
		}

		public BaseCreature( Serial serial ) : base( serial )
		{
			m_arSpellAttack = new List<Type>();
			m_arSpellDefense = new List<Type>();

			m_bDebugAI = false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 19 ); // version

			writer.Write( (int)m_HitsBeforeMod );

			writer.Write( (int)m_Coins );
			writer.Write( m_CoinType );
			writer.Write( (int)m_SpawnerID );
			writer.Write( (bool) m_Swimmer );
			writer.Write( (bool) m_NoWalker );

			writer.Write( (int)m_CurrentAI );
			writer.Write( (int)m_DefaultAI );

			writer.Write( (int)m_iRangePerception );
			writer.Write( (int)m_iRangeFight );

			writer.Write( (int)m_iTeam );

			writer.Write( (double)m_dActiveSpeed );
			writer.Write( (double)m_dPassiveSpeed );
			writer.Write( (double)m_dCurrentSpeed );

			writer.Write( (int) m_pHome.X );
			writer.Write( (int) m_pHome.Y );
			writer.Write( (int) m_pHome.Z );

			// Version 1
			writer.Write( (int) m_iRangeHome );

			int i=0;

			writer.Write( (int) m_arSpellAttack.Count );
			for ( i=0; i< m_arSpellAttack.Count; i++ )
			{
				writer.Write( m_arSpellAttack[i].ToString() );
			}

			writer.Write( (int) m_arSpellDefense.Count );
			for ( i=0; i< m_arSpellDefense.Count; i++ )
			{
				writer.Write( m_arSpellDefense[i].ToString() );
			}

			// Version 2
			writer.Write( (int) m_FightMode );

			writer.Write( (bool) m_bControlled );
			writer.Write( (Mobile) m_ControlMaster );
			writer.Write( (Mobile) m_ControlTarget );
			writer.Write( (Point3D) m_ControlDest );
			writer.Write( (int) m_ControlOrder );
			writer.Write( (double) m_dMinTameSkill );
			// Removed in version 9
			//writer.Write( (double) m_dMaxTameSkill );
			writer.Write( (bool) m_bTamable );
			writer.Write( (bool) m_bSummoned );

			if ( m_bSummoned )
				writer.WriteDeltaTime( m_SummonEnd );

			writer.Write( (int) m_iControlSlots );

			// Version 3
			writer.Write( (int)m_Loyalty );

			// Version 4
			writer.Write( m_CurrentWayPoint );

			// Verison 5
			writer.Write( m_SummonMaster );

			// Version 6
			writer.Write( (int) m_HitsMax );
			writer.Write( (int) m_StamMax );
			writer.Write( (int) m_ManaMax );
			writer.Write( (int) m_DamageMin );
			writer.Write( (int) m_DamageMax );

			// Version 7
			writer.Write( (int) m_PhysicalResistance );
			writer.Write( (int) m_PhysicalDamage );

			writer.Write( (int) m_FireResistance );
			writer.Write( (int) m_FireDamage );

			writer.Write( (int) m_ColdResistance );
			writer.Write( (int) m_ColdDamage );

			writer.Write( (int) m_PoisonResistance );
			writer.Write( (int) m_PoisonDamage );

			writer.Write( (int) m_EnergyResistance );
			writer.Write( (int) m_EnergyDamage );

			// Version 8
			writer.Write( m_Owners, true );

			// Version 10
			writer.Write( (bool) m_IsDeadPet );
			writer.Write( (bool) m_IsBonded );
			writer.Write( (DateTime) m_BondingBegin );
			writer.Write( (DateTime) m_OwnerAbandonTime );

			// Version 11
			writer.Write( (bool) m_HasGeneratedLoot );

			// Version 12
			writer.Write( (bool) m_Paragon );

			// Version 13
			writer.Write( (bool) ( m_Friends != null && m_Friends.Count > 0 ) );

			if ( m_Friends != null && m_Friends.Count > 0 )
				writer.Write( m_Friends, true );

			// Version 14
			writer.Write( (bool)m_RemoveIfUntamed );
			writer.Write( (int)m_RemoveStep );

			// Version 17
			if ( IsStabled || ( Controlled && ControlMaster != null ) )
				writer.Write( TimeSpan.Zero );
			else
				writer.Write( DeleteTimeLeft );
		}

		private static double[] m_StandardActiveSpeeds = new double[]
			{
				0.175, 0.1, 0.15, 0.2, 0.25, 0.3, 0.4, 0.5, 0.6, 0.8
			};

		private static double[] m_StandardPassiveSpeeds = new double[]
			{
				0.350, 0.2, 0.4, 0.5, 0.6, 0.8, 1.0, 1.2, 1.6, 2.0
			};

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version >= 19 )
			{
				m_HitsBeforeMod = reader.ReadInt();
			}

			if ( version >= 18 )
			{
				m_Coins = reader.ReadInt();
				m_CoinType = reader.ReadString();
				m_SpawnerID = reader.ReadInt();
				m_Swimmer = reader.ReadBool();
				m_NoWalker = reader.ReadBool();
			}

			m_CurrentAI = (AIType)reader.ReadInt();
			m_DefaultAI = (AIType)reader.ReadInt();

			m_iRangePerception = reader.ReadInt();
			m_iRangeFight = reader.ReadInt();

			m_iTeam = reader.ReadInt();

			m_dActiveSpeed = reader.ReadDouble();
			m_dPassiveSpeed = reader.ReadDouble();
			m_dCurrentSpeed = reader.ReadDouble();

			if ( m_iRangePerception == OldRangePerception )
				m_iRangePerception = DefaultRangePerception;

			m_pHome.X = reader.ReadInt();
			m_pHome.Y = reader.ReadInt();
			m_pHome.Z = reader.ReadInt();

			if ( version >= 1 )
			{
				m_iRangeHome = reader.ReadInt();

				int i, iCount;

				iCount = reader.ReadInt();
				for ( i=0; i< iCount; i++ )
				{
					string str = reader.ReadString();
					Type type = Type.GetType( str );

					if ( type != null )
					{
						m_arSpellAttack.Add( type );
					}
				}

				iCount = reader.ReadInt();
				for ( i=0; i< iCount; i++ )
				{
					string str = reader.ReadString();
					Type type = Type.GetType( str );

					if ( type != null )
					{
						m_arSpellDefense.Add( type );
					}
				}
			}
			else
			{
				m_iRangeHome = 0;
			}

			if ( version >= 2 )
			{
				m_FightMode = ( FightMode )reader.ReadInt();

				m_bControlled = reader.ReadBool();
				m_ControlMaster = reader.ReadMobile();
				m_ControlTarget = reader.ReadMobile();
				m_ControlDest = reader.ReadPoint3D();
				m_ControlOrder = (OrderType) reader.ReadInt();

				m_dMinTameSkill = reader.ReadDouble();

				if ( version < 9 )
					reader.ReadDouble();

				m_bTamable = reader.ReadBool();
				m_bSummoned = reader.ReadBool();

				if ( m_bSummoned )
				{
					m_SummonEnd = reader.ReadDeltaTime();
					new UnsummonTimer( m_ControlMaster, this, m_SummonEnd - DateTime.Now ).Start();
				}

				m_iControlSlots = reader.ReadInt();
			}
			else
			{
				m_FightMode = FightMode.Closest;

				m_bControlled = false;
				m_ControlMaster = null;
				m_ControlTarget = null;
				m_ControlOrder = OrderType.None;
			}

			if ( version >= 3 )
				m_Loyalty = reader.ReadInt();
			else
				m_Loyalty = MaxLoyalty; // Wonderfully Happy

			if ( version >= 4 )
				m_CurrentWayPoint = reader.ReadItem() as WayPoint;

			if ( version >= 5 )
				m_SummonMaster = reader.ReadMobile();

			if ( version >= 6 )
			{
				m_HitsMax = reader.ReadInt();
				m_StamMax = reader.ReadInt();
				m_ManaMax = reader.ReadInt();
				m_DamageMin = reader.ReadInt();
				m_DamageMax = reader.ReadInt();
			}

			if ( version >= 7 )
			{
				m_PhysicalResistance = reader.ReadInt();
				m_PhysicalDamage = reader.ReadInt();

				m_FireResistance = reader.ReadInt();
				m_FireDamage = reader.ReadInt();

				m_ColdResistance = reader.ReadInt();
				m_ColdDamage = reader.ReadInt();

				m_PoisonResistance = reader.ReadInt();
				m_PoisonDamage = reader.ReadInt();

				m_EnergyResistance = reader.ReadInt();
				m_EnergyDamage = reader.ReadInt();
			}

			if ( version >= 8 )
				m_Owners = reader.ReadStrongMobileList();
			else
				m_Owners = new List<Mobile>();

			if ( version >= 10 )
			{
				m_IsDeadPet = reader.ReadBool();
				m_IsBonded = reader.ReadBool();
				m_BondingBegin = reader.ReadDateTime();
				m_OwnerAbandonTime = reader.ReadDateTime();
			}

			if ( version >= 11 )
				m_HasGeneratedLoot = reader.ReadBool();
			else
				m_HasGeneratedLoot = true;

			if ( version >= 12 )
				m_Paragon = reader.ReadBool();
			else
				m_Paragon = false;

			if ( version >= 13 && reader.ReadBool() )
				m_Friends = reader.ReadStrongMobileList();
			else if ( version < 13 && m_ControlOrder >= OrderType.Unfriend )
				++m_ControlOrder;

			if ( version < 16 && Loyalty != MaxLoyalty )
				Loyalty *= 10;

			double activeSpeed = m_dActiveSpeed;
			double passiveSpeed = m_dPassiveSpeed;

			SpeedInfo.GetSpeeds( this, ref activeSpeed, ref passiveSpeed );

			bool isStandardActive = false;
			for ( int i = 0; !isStandardActive && i < m_StandardActiveSpeeds.Length; ++i )
				isStandardActive = ( m_dActiveSpeed == m_StandardActiveSpeeds[i] );

			bool isStandardPassive = false;
			for ( int i = 0; !isStandardPassive && i < m_StandardPassiveSpeeds.Length; ++i )
				isStandardPassive = ( m_dPassiveSpeed == m_StandardPassiveSpeeds[i] );

			if ( isStandardActive && m_dCurrentSpeed == m_dActiveSpeed )
				m_dCurrentSpeed = activeSpeed;
			else if ( isStandardPassive && m_dCurrentSpeed == m_dPassiveSpeed )
				m_dCurrentSpeed = passiveSpeed;

			if ( isStandardActive && !m_Paragon )
				m_dActiveSpeed = activeSpeed;

			if ( isStandardPassive && !m_Paragon )
				m_dPassiveSpeed = passiveSpeed;

			if ( version >= 14 )
			{
				m_RemoveIfUntamed = reader.ReadBool();
				m_RemoveStep = reader.ReadInt();
			}

			TimeSpan deleteTime = TimeSpan.Zero;

			if ( version >= 17 )
				deleteTime = reader.ReadTimeSpan();

			if ( deleteTime > TimeSpan.Zero || LastOwner != null && !Controlled && !IsStabled )
			{
				if ( deleteTime == TimeSpan.Zero )
					deleteTime = TimeSpan.FromDays( 3.0 );

				m_DeleteTimer = new DeleteTimer( this, deleteTime );
				m_DeleteTimer.Start();
			}

			if( version <= 14 && m_Paragon && Hue == 0x31 )
			{
				Hue = Paragon.Hue; //Paragon hue fixed, should now be 0x501.
			}

			CheckStatTimers();

			ChangeAIType(m_CurrentAI);

			AddFollowers();

			//if ( IsAnimatedDead )
			//	Spells.Necromancy.AnimateDeadSpell.Register( m_SummonMaster, this );

			if ( FightMode == FightMode.CharmMonster ){ FightMode = FightMode.Closest; }
			else if ( FightMode == FightMode.CharmAnimal ){ FightMode = FightMode.Aggressor; }

			if ( FollowersMax > 5 ){ FollowersMax = 5; }

			if ( !IsCitizen() && Server.Misc.MyServerSettings.LineOfSightOn() && WhisperHue != 999 && WhisperHue != 666 && !CanHearGhosts && !Controlled && (this.Region is DungeonRegion || this.Region is DeadRegion || this.Region is CaveRegion || this.Region is BardDungeonRegion || this.Region is OutDoorBadRegion) )
			{
				CanHearGhosts = true;
				CantWalk = true;
				Hidden = true;
			}

			if ( RaceID > 0 && BodyMod == 0 )
			{
				BodyMod = RaceID;
				HueMod = RaceSection;
			}
		}

		public virtual bool IsHumanInTown()
		{
			return false;
		}

		public virtual bool CheckGold( Mobile from, Item dropped )
		{
			if ( dropped is Gold )
				return OnGoldGiven( from, (Gold)dropped );

			return false;
		}

		public virtual bool OnGoldGiven( Mobile from, Gold dropped )
		{
			if ( CheckTeachingMatch( from ) )
			{
				if ( Teach( m_Teaching, from, dropped.Amount, true ) )
				{
					dropped.Delete();
					return true;
				}
			}
			else if ( IsHumanInTown() )
			{
				Direction = GetDirectionTo( from );

				int oldSpeechHue = this.SpeechHue;

				this.SpeechHue = 0x23F;
				SayTo( from, "Thou art giving me gold?" );

				if ( dropped.Amount >= 400 )
					SayTo( from, "'Tis a noble gift." );
				else
					SayTo( from, "Money is always welcome." );

				this.SpeechHue = 0x3B2;
				SayTo( from, 501548 ); // I thank thee.

				this.SpeechHue = oldSpeechHue;

				dropped.Delete();
				return true;
			}

			return false;
		}

		public override bool ShouldCheckStatTimers{ get{ return false; } }

		#region Food
		private static Type[] m_Eggs = new Type[]
			{
				typeof( FriedEggs ), typeof( Eggs ), typeof( FairyEgg )
			};

		private static Type[] m_Fish = new Type[]
			{
				typeof( FishSteak ), typeof( RawFishSteak ), typeof( NewFish )
			};

		private static Type[] m_GrainsAndHay = new Type[]
			{
				typeof( BreadLoaf ), typeof( FrenchBread ), typeof( SheafOfHay )
			};

		private static Type[] m_Meat = new Type[]
			{
				/* Cooked */
				typeof( Bacon ), typeof( CookedBird ), typeof( Sausage ),
				typeof( Ham ), typeof( Ribs ), typeof( LambLeg ), typeof( FoodDriedBeef ),
				typeof( ChickenLeg ), typeof( FoodBeefJerky ),

				/* Uncooked */
				typeof( RawBird ), typeof( RawRibs ), typeof( RawLambLeg ),
				typeof( RawChickenLeg ), typeof( TastyHeart), typeof( RawPig ),

				/* Body Parts */
				typeof( Head ), typeof( LeftArm ), typeof( LeftLeg ),
				typeof( Torso ), typeof( RightArm ), typeof( RightLeg ), typeof( BodyPart )
			};

		private static Type[] m_FruitsAndVegies = new Type[]
			{
				typeof( HoneydewMelon ), typeof( YellowGourd ), typeof( GreenGourd ),
				typeof( Banana ), typeof( Bananas ), typeof( Lemon ), typeof( Lime ),
				typeof( Dates ), typeof( Grapes ), typeof( Peach ), typeof( Pear ),
				typeof( Apple ), typeof( Watermelon ), typeof( Squash ), typeof ( SmallWatermelon ),
				typeof( Cantaloupe ), typeof( Carrot ), typeof( Cabbage ), typeof ( FoodImpBerry ),
				typeof( Onion ), typeof( Lettuce ), typeof( Pumpkin ), typeof( FoodToadStool ),
				typeof( Tomato ), typeof( FoodPotato ), typeof( Corn ), typeof( Acorn )
			};

		private static Type[] m_Gold = new Type[]
			{
				typeof( Gold ), typeof( GoldBricks ), typeof( GoldIngot )
			};

		private static Type[] m_Fire = new Type[]
			{
				typeof( Brimstone ), typeof( SulfurousAsh )
			};

		private static Type[] m_Gems = new Type[]
			{
				typeof( Ruby ), typeof( Amber ), typeof( Amethyst ), typeof( Citrine ),
				typeof( Emerald ), typeof( Diamond ), typeof( Sapphire ), typeof( StarSapphire ),
				typeof( Tourmaline ), typeof( DDRelicGem )
			};

		private static Type[] m_Nox = new Type[]
			{
				typeof( Nightshade ), typeof( NoxCrystal ), typeof( SwampBerries )
			};

		private static Type[] m_Sea = new Type[]
			{
				typeof( SeaSalt ), typeof( EnchantedSeaweed ), typeof( SpecialSeaweed )
			};

		private static Type[] m_Moon = new Type[]
			{
				typeof( MoonCrystal )
			};

		public virtual bool CheckFoodPreference( Item f )
		{
			if ( CheckFoodPreference( f, FoodType.Eggs, m_Eggs ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Fish, m_Fish ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.GrainsAndHay, m_GrainsAndHay ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Meat, m_Meat ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.FruitsAndVegies, m_FruitsAndVegies ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Gold, m_Gold ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Fire, m_Fire ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Gems, m_Gems ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Nox, m_Nox ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Sea, m_Sea ) )
				return true;

			if ( CheckFoodPreference( f, FoodType.Moon, m_Moon ) )
				return true;

			return false;
		}

		public virtual bool CheckFoodPreference( Item fed, FoodType type, Type[] types )
		{
			if ( (FavoriteFood & type) == 0 )
				return false;

			Type fedType = fed.GetType();
			bool contains = false;

			for ( int i = 0; !contains && i < types.Length; ++i )
				contains = ( fedType == types[i] );

			return contains;
		}

		public static bool IsPet( Mobile m )
		{
			if ( m is PlayerMobile )
				return false;

			if ( m is BaseCreature )
			{
				if ( m is FrankenFighter || m is Robot || m is GolemFighter || m is HenchmanMonster || m is HenchmanWizard || m is HenchmanArcher || m is HenchmanFighter )
					return false;

				BaseCreature bc = (BaseCreature)m;

				if ( bc.Summoned || bc.Controlled )
				{
					bc.SpawnerID = 0;
					return true;
				}
			}

			return false;
		}

		public static bool IsHenchman( Mobile m )
		{
			if ( m is FrankenFighter || m is HenchmanMonster || m is HenchmanWizard || m is HenchmanArcher || m is HenchmanFighter )
				return false;

			return false;
		}

		public virtual bool CheckFeed( Mobile from, Item dropped )
		{
			if ( 	!IsDeadPet &&
					!( this is FrankenPorter ) &&
					!( this is FrankenFighter ) &&
					!( this is GolemPorter ) &&
					!( this is AerialServant ) &&
					!( this is Robot ) &&
					!( this is Robot ) &&
					!( this is PackBeast ) &&
					!( this is HenchmanFamiliar ) &&
					!( this is HenchmanFighter ) &&
					!( this is HenchmanMonster ) &&
					!( this is HenchmanWizard ) &&
					!( this is HenchmanArcher ) &&
					Controlled &&
					( ControlMaster == from || IsPetFriend( from ) )
				)
			{
				Item f = dropped;

				if ( CheckFoodPreference( f ) )
				{
					int amount = f.Amount;

					if ( amount > 0 )
					{
						int stamGain;

						if ( f is Gold )
							stamGain = amount - 50;
						else
							stamGain = (amount * 15) - 50;

						if ( stamGain > 0 )
							Stam += stamGain;

						if ( Core.SE )
						{
							if ( m_Loyalty < MaxLoyalty )
							{
								m_Loyalty = MaxLoyalty;
							}
						}
						else
						{
							for ( int i = 0; i < amount; ++i )
							{
								if ( m_Loyalty < MaxLoyalty  && 0.5 >= Utility.RandomDouble() )
								{
									m_Loyalty += 10;
								}
							}
						}

						/* if ( happier )*/	// looks like in OSI pets say they are happier even if they are at maximum loyalty
							SayTo( from, 502060 ); // Your pet looks happier.

						if ( Body.IsAnimal )
							Animate( 3, 5, 1, true, false, 0 );
						else if ( Body.IsMonster )
							Animate( 17, 5, 1, true, false, 0 );

						if ( IsBondable && !IsBonded )
						{
							Mobile master = m_ControlMaster;

							if ( master != null && master == from )	//So friends can't start the bonding process
							{
								if ( m_dMinTameSkill <= 29.1 || master.Skills[SkillName.Taming].Base >= m_dMinTameSkill || OverrideBondingReqs() || (Core.ML && master.Skills[SkillName.Taming].Value >= m_dMinTameSkill) )
								{
									if ( BondingBegin == DateTime.MinValue )
									{
										BondingBegin = DateTime.Now;
									}
									else if ( (BondingBegin + BondingDelay) <= DateTime.Now )
									{
										IsBonded = true;
										BondingBegin = DateTime.MinValue;
										from.SendLocalizedMessage( 1049666 ); // Your pet has bonded with you!
									}
								}
								else if( Core.ML )
								{
									from.SendLocalizedMessage( 1075268 ); // Your pet cannot form a bond with you until your taming ability has risen.
								}
							}
						}

						dropped.Delete();
						return true;
					}
				}
			}

			return false;
		}

		#endregion

		public virtual bool OverrideBondingReqs()
		{
			return false;
		}

		public virtual bool CanAngerOnTame{ get{ return false; } }

		#region OnAction[...]

		public virtual void OnActionWander()
		{
		}

		public virtual void OnActionCombat()
		{
		}

		public virtual void OnActionGuard()
		{
		}

		public virtual void OnActionFlee()
		{
		}

		public virtual void OnActionInteract()
		{
		}

		public virtual void OnActionBackoff()
		{
		}

		#endregion

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( CheckFeed( from, dropped ) )
				return true;
			else if ( CheckGold( from, dropped ) )
				return true;

			return base.OnDragDrop( from, dropped );
		}

		protected virtual BaseAI ForcedAI { get { return null; } }

		public  void ChangeAIType( AIType NewAI )
		{
			if ( m_AI != null )
				m_AI.m_Timer.Stop();

			if( ForcedAI != null )
			{
				m_AI = ForcedAI;
				return;
			}

			m_AI = null;

			switch ( NewAI )
			{
				case AIType.AI_Melee:
					m_AI = new MeleeAI(this);
					break;
				case AIType.AI_Animal:
					m_AI = new AnimalAI(this);
					break;
				case AIType.AI_Berserk:
					m_AI = new BerserkAI(this);
					break;
				case AIType.AI_Archer:
					m_AI = new ArcherAI(this);
					break;
				case AIType.AI_Healer:
					m_AI = new HealerAI(this);
					break;
				case AIType.AI_Vendor:
					m_AI = new VendorAI(this);
					break;
				case AIType.AI_Mage:
					m_AI = new MageAI(this);
					break;
				case AIType.AI_Predator:
					//m_AI = new PredatorAI(this);
					m_AI = new MeleeAI(this);
					break;
				case AIType.AI_Thief:
					m_AI = new ThiefAI(this);
					break;
			}
		}

		public void ChangeAIToDefault()
		{
			ChangeAIType(m_DefaultAI);
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public AIType AI
		{
			get
			{
				return m_CurrentAI;
			}
			set
			{
				m_CurrentAI = value;

				if (m_CurrentAI == AIType.AI_Use_Default)
				{
					m_CurrentAI = m_DefaultAI;
				}

				ChangeAIType(m_CurrentAI);
			}
		}

		[CommandProperty( AccessLevel.Administrator )]
		public bool Debug
		{
			get
			{
				return m_bDebugAI;
			}
			set
			{
				m_bDebugAI = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Team
		{
			get
			{
				return m_iTeam;
			}
			set
			{
				m_iTeam = value;

				OnTeamChange();
			}
		}

		public virtual void OnTeamChange()
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile FocusMob
		{
			get
			{
				return m_FocusMob;
			}
			set
			{
				m_FocusMob = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public FightMode FightMode
		{
			get
			{
				return m_FightMode;
			}
			set
			{
				m_FightMode = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int RangePerception
		{
			get
			{
				return m_iRangePerception;
			}
			set
			{
				m_iRangePerception = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int RangeFight
		{
			get
			{
				return m_iRangeFight;
			}
			set
			{
				m_iRangeFight = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int RangeHome
		{
			get
			{
				return m_iRangeHome;
			}
			set
			{
				m_iRangeHome = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public double ActiveSpeed
		{
			get
			{
				return m_dActiveSpeed;
			}
			set
			{
				m_dActiveSpeed = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public double PassiveSpeed
		{
			get
			{
				return m_dPassiveSpeed;
			}
			set
			{
				m_dPassiveSpeed = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public double CurrentSpeed
		{
			get
			{
				if ( m_TargetLocation != null )
					return 0.3;

				return m_dCurrentSpeed;
			}
			set
			{
				if ( m_dCurrentSpeed != value )
				{
					m_dCurrentSpeed = value;

					if (m_AI != null)
						m_AI.OnCurrentSpeedChanged();
				}
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D Home
		{
			get
			{
				return m_pHome;
			}
			set
			{
				m_pHome = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Controlled
		{
			get
			{
				return m_bControlled;
			}
			set
			{
				if ( m_bControlled == value )
					return;

				m_bControlled = value;
				Delta( MobileDelta.Noto );

				InvalidateProperties();
			}
		}

		public override void RevealingAction()
		{
			if ( Server.Misc.MyServerSettings.LineOfSight( this, true ) )
			{
				this.CantWalk = m_NoWalker;
				this.Hidden = false;
			}
			else if ( WhisperHue == 999 && Hidden && CantWalk && !CanSwim && !Server.Mobiles.BasePirate.IsSailor( this ) )
			{
				this.PlaySound( 0x026 );
				Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );
				this.CantWalk = m_NoWalker;
				this.CanSwim = m_Swimmer;
				this.Hidden = false;
			}
			else if ( WhisperHue == 666 && Hidden && CantWalk )
			{
				Server.Items.DemonGate.MakeDemonGate( this );
				this.CantWalk = m_NoWalker;
				this.Hidden = false;
			}

			this.CantWalk = m_NoWalker;

			Spells.Sixth.InvisibilitySpell.RemoveTimer( this );

			base.RevealingAction();
		}

		public void RemoveFollowers()
		{
			if ( m_ControlMaster != null )
			{
				m_ControlMaster.Followers -= ControlSlots;
				if( m_ControlMaster is PlayerMobile )
				{
					((PlayerMobile)m_ControlMaster).AllFollowers.Remove( this );
					if( ((PlayerMobile)m_ControlMaster).AutoStabled.Contains( this ) )
						((PlayerMobile)m_ControlMaster).AutoStabled.Remove( this );
				}
			}
			else if ( m_SummonMaster != null )
			{
				m_SummonMaster.Followers -= ControlSlots;
				if( m_SummonMaster is PlayerMobile )
				{
					((PlayerMobile)m_SummonMaster).AllFollowers.Remove( this );
				}
			}

			if ( m_ControlMaster != null && m_ControlMaster.Followers < 0 )
				m_ControlMaster.Followers = 0;

			if ( m_SummonMaster != null && m_SummonMaster.Followers < 0 )
				m_SummonMaster.Followers = 0;
		}

		public void AddFollowers()
		{
			if ( m_ControlMaster != null )
			{
				m_ControlMaster.Followers += ControlSlots;
				if( m_ControlMaster is PlayerMobile )
				{
					((PlayerMobile)m_ControlMaster).AllFollowers.Add( this );
				}
			}
			else if ( m_SummonMaster != null )
			{
				m_SummonMaster.Followers += ControlSlots;
				if( m_SummonMaster is PlayerMobile )
				{
					((PlayerMobile)m_SummonMaster).AllFollowers.Add( this );
				}
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile ControlMaster
		{
			get
			{
				return m_ControlMaster;
			}
			set
			{
				if ( m_ControlMaster == value || this == value )
					return;

				RemoveFollowers();
				m_ControlMaster = value;
				AddFollowers();
				if ( m_ControlMaster != null )
					StopDeleteTimer();

				Delta( MobileDelta.Noto );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile SummonMaster
		{
			get
			{
				return m_SummonMaster;
			}
			set
			{
				if ( m_SummonMaster == value || this == value )
					return;

				RemoveFollowers();
				m_SummonMaster = value;
				AddFollowers();

				Delta( MobileDelta.Noto );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile ControlTarget
		{
			get
			{
				return m_ControlTarget;
			}
			set
			{
				m_ControlTarget = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Point3D ControlDest
		{
			get
			{
				return m_ControlDest;
			}
			set
			{
				m_ControlDest = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public OrderType ControlOrder
		{
			get
			{
				return m_ControlOrder;
			}
			set
			{
				m_ControlOrder = value;

				if ( m_AI != null )
					m_AI.OnCurrentOrderChanged();

				InvalidateProperties();

				if ( m_ControlMaster != null )
					m_ControlMaster.InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool BardProvoked
		{
			get
			{
				return m_bBardProvoked;
			}
			set
			{
				m_bBardProvoked = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool BardPacified
		{
			get
			{
				return m_bBardPacified;
			}
			set
			{
				m_bBardPacified = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile BardMaster
		{
			get
			{
				return m_bBardMaster;
			}
			set
			{
				m_bBardMaster = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile BardTarget
		{
			get
			{
				return m_bBardTarget;
			}
			set
			{
				m_bBardTarget = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime BardEndTime
		{
			get
			{
				return m_timeBardEnd;
			}
			set
			{
				m_timeBardEnd = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public double MinTameSkill
		{
			get
			{
				return m_dMinTameSkill;
			}
			set
			{
				m_dMinTameSkill = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Tamable
		{
			get
			{
				return m_bTamable && !m_Paragon;
			}
			set
			{
				m_bTamable = value;
			}
		}

		[CommandProperty( AccessLevel.Administrator )]
		public bool Summoned
		{
			get
			{
				return m_bSummoned;
			}
			set
			{
				if ( m_bSummoned == value )
					return;

				m_NextReacquireTime = DateTime.Now;

				m_bSummoned = value;
				Delta( MobileDelta.Noto );

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.Administrator )]
		public int ControlSlots
		{
			get
			{
				return m_iControlSlots;
			}
			set
			{
				m_iControlSlots = value;
			}
		}

		public virtual bool NoHouseRestrictions{ get{ return false; } }
		public virtual bool IsHouseSummonable{ get{ return false; } }

		#region Corpse Resources
		public virtual int Feathers{ get{ return 0; } }
		public virtual int Wool{ get{ return 0; } }

		public virtual MeatType MeatType{ get{ return MeatType.Ribs; } }
		public virtual int Meat{ get{ return 0; } }

		public virtual FurType FurType{ get{ return FurType.Regular; } }
		public virtual int Furs{ get{ return 0; } }

		public virtual int Hides{ get{ return 0; } }
		public virtual HideType HideType{ get{ return HideType.Regular; } }

		public virtual int Scales{ get{ return 0; } }
		public virtual ScaleType ScaleType{ get{ return ScaleType.Red; } }
		#endregion

		public virtual bool AutoDispel{ get{ return false; } }
		public virtual double AutoDispelChance
		{
			get
			{
				if ( this.Skills[SkillName.Magery].Value < 53 && this.Skills[SkillName.Necromancy].Value < 80 )
					return 0.0;

				return (double)(Server.Misc.IntelligentAction.GetCreatureLevel(this));
			}
		}

		public virtual bool IsScaryToPets{ get{ return false; } }
		public virtual bool IsScaredOfScaryThings{ get{ return true; } }

		public virtual bool CanRummageCorpses{ get{ return false; } }

		public static bool CanDispel( BaseCreature attacker, Mobile defender )
		{
			if ( defender is BaseCreature && ( defender.Skills[SkillName.Magery].Value >= 53 || defender.Skills[SkillName.Necromancy].Value >= 80 ) )
			{
				BaseCreature bc = (BaseCreature)defender;
				if ( bc.IsDispellable && ( Utility.RandomMinMax(0,50) + attacker.AutoDispelChance ) > bc.DispelDifficulty )
					return true;
			}
			return false;
		}

		public virtual void OnGotMeleeAttack( Mobile attacker )
		{
			if ( attacker is PlayerMobile && attacker.RaceID > 0 && attacker.RaceMakeSounds && attacker.RaceAttackSound > 0 && Utility.RandomBool() )
				attacker.PlaySound( attacker.RaceAttackSound );

			if ( CanDispel( this, attacker ) )
				Dispel( attacker );

			int stealing = Utility.RandomMinMax( 1, (int)(attacker.Skills[SkillName.Stealing].Value) ) + 10;
			double snooping = attacker.Skills[SkillName.Snooping].Value;
			int level = IntelligentAction.GetCreatureLevel( this );

			int x = System.Math.Abs( this.X - attacker.X );
			int y = System.Math.Abs( this.Y - attacker.Y );

			if ( m_Coins > 0 && x < 2 && y < 2 && attacker is PlayerMobile && stealing >= 20.0 && level < stealing && snooping > Utility.RandomMinMax(20, 126) )
			{
				int coins = m_Coins * ( 1 - ( level / stealing ) );
				if ( coins < 1 )
					coins = 1;

				coins = Utility.RandomMinMax( 1, coins );

				m_Coins = m_Coins - coins;
				if ( m_Coins < 0 )
					m_Coins = 0;

				if ( m_CoinType == "xormite" )
					attacker.AddToBackpack( new DDXormite( coins ) );
				else if ( m_CoinType == "crystals" )
					attacker.AddToBackpack( new Crystals( coins ) );
				else if ( m_CoinType == "jewels" )
					attacker.AddToBackpack( new DDJewels( coins ) );
				else
					attacker.AddToBackpack( new Gold( coins ) );

				string stole = "stolen";
				switch ( Utility.RandomMinMax( 0, 7 ) )
				{
					case 1: stole = "swiped"; break;
					case 2: stole = "grabbed"; break;
					case 3: stole = "taken"; break;
					case 4: stole = "filched"; break;
					case 5: stole = "lifted"; break;
					case 6: stole = "robbed"; break;
					case 7: stole = "snatched"; break;
				}

				attacker.SendMessage( "You " + stole + " " + coins + " " + m_CoinType + "!" );

				if ( this.Karma > 0 )
					Titles.AwardKarma( attacker, -coins, false );

				if ( ( ( stealing - level ) < 50 ) && Utility.RandomBool() )
					attacker.CheckSkill( SkillName.Stealing, 0, 125 );
			}
		}

		public virtual void Dispel( Mobile m )
		{
			Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 5042 );
			Effects.PlaySound( m, m.Map, 0x201 );

			m.Delete();
		}

		public virtual bool DeleteOnRelease{ get{ return m_bSummoned; } }

		public virtual void OnGaveMeleeAttack( Mobile defender )
		{
			if ( defender is PlayerMobile && defender.RaceID > 0 && defender.RaceMakeSounds && defender.RaceHurtSound > 0 && Utility.RandomBool() )
				defender.PlaySound( defender.RaceHurtSound );

			Poison p = HitPoison;

			if ( m_Paragon )
				p = PoisonImpl.IncreaseLevel( p );

			if ( p != null && HitPoisonChance >= Utility.RandomDouble() ) {
				defender.ApplyPoison( this, p );
				if ( this.Controlled )
					this.CheckSkill(SkillName.Poisoning, 0, this.Skills[SkillName.Poisoning].Cap);
			}

			if ( CanDispel( this, defender ) )
				Dispel( defender );

			Server.Misc.IntelligentAction.SaySomethingWhenAttacking( this, defender );

			if ( AI == AIType.AI_Archer )
			{
				int sound = 0;

				if ( FindItemOnLayer( Layer.OneHanded ) is BaseMeleeWeapon ) { sound = ( ( BaseMeleeWeapon )( FindItemOnLayer( Layer.OneHanded ) ) ).DefHitSound; }
				else if ( FindItemOnLayer( Layer.TwoHanded ) is BaseMeleeWeapon ) { sound = ( ( BaseMeleeWeapon )( FindItemOnLayer( Layer.TwoHanded ) ) ).DefHitSound; }

				if ( sound > 0 ){ PlaySound( sound ); }
			}
			else if ( AI == AIType.AI_Mage )
			{
				int sound = 0;

				if ( FindItemOnLayer( Layer.OneHanded ) is BaseWizardStaff ) { sound = ( ( BaseMeleeWeapon )( FindItemOnLayer( Layer.OneHanded ) ) ).DefHitSound; }
				else if ( FindItemOnLayer( Layer.TwoHanded ) is BaseWizardStaff ) { sound = ( ( BaseMeleeWeapon )( FindItemOnLayer( Layer.TwoHanded ) ) ).DefHitSound; }

				if ( sound > 0 ){ PlaySound( sound ); }
			}
		}

		public override void OnAfterDelete()
		{
			if ( m_AI != null )
			{
				if ( m_AI.m_Timer != null )
					m_AI.m_Timer.Stop();

				m_AI = null;
			}

			if ( m_DeleteTimer != null )
			{
				m_DeleteTimer.Stop();
				m_DeleteTimer = null;
			}

			FocusMob = null;

			//if ( IsAnimatedDead )
			//	Spells.Necromancy.AnimateDeadSpell.Unregister( m_SummonMaster, this );

			base.OnAfterDelete();
		}

		public void DebugSay( string text )
		{
			if ( m_bDebugAI )
				this.PublicOverheadMessage( MessageType.Regular, 41, false, text );
		}

		public void DebugSay( string format, params object[] args )
		{
			if ( m_bDebugAI )
				this.PublicOverheadMessage( MessageType.Regular, 41, false, String.Format( format, args ) );
		}

		/*
		 * This function can be overriden.. so a "Strongest" mobile, can have a different definition depending
		 * on who check for value
		 * -Could add a FightMode.Prefered
		 *
		 */

		public virtual double GetFightModeRanking( Mobile m, FightMode acqType, bool bPlayerOnly )
		{
			if ( ( bPlayerOnly && m.Player ) ||  !bPlayerOnly )
			{
				switch( acqType )
				{
					case FightMode.Strongest :
						return (m.Skills[SkillName.Tactics].Value + m.Str); //returns strongest mobile

					case FightMode.Weakest :
						return -m.Hits; // returns weakest mobile

					default :
						return -GetDistanceToSqrt( m ); // returns closest mobile
				}
			}
			else
			{
				return double.MinValue;
			}
		}

		// Turn, - for left, + for right
		// Basic for now, needs work
		public virtual void Turn(int iTurnSteps)
		{
			int v = (int)Direction;

			Direction = (Direction)((((v & 0x7) + iTurnSteps) & 0x7) | (v & 0x80));
		}

		public virtual void TurnInternal(int iTurnSteps)
		{
			int v = (int)Direction;

			SetDirection( (Direction)((((v & 0x7) + iTurnSteps) & 0x7) | (v & 0x80)) );
		}

		public bool IsHurt()
		{
			return ( Hits != HitsMax );
		}

		public double GetHomeDistance()
		{
			return GetDistanceToSqrt( m_pHome );
		}

		public virtual int GetTeamSize(int iRange)
		{
			int iCount = 0;

			foreach ( Mobile m in this.GetMobilesInRange( iRange ) )
			{
				if (m is BaseCreature)
				{
					if ( ((BaseCreature)m).Team == Team )
					{
						if ( !m.Deleted )
						{
							if ( m != this )
							{
								if ( CanSee( m ) )
								{
									iCount++;
								}
							}
						}
					}
				}
			}

			return iCount;
		}

		private class TameEntry : ContextMenuEntry
		{
			private BaseCreature m_Mobile;

			public TameEntry( Mobile from, BaseCreature creature ) : base( 6130, 6 )
			{
				m_Mobile = creature;

				Enabled = Enabled && ( from.Female ? creature.AllowFemaleTamer : creature.AllowMaleTamer );
			}

			public override void OnClick()
			{
				if ( !Owner.From.CheckAlive() )
					return;

				Owner.From.TargetLocked = true;
				SkillHandlers.Taming.DisableMessage = true;

				if ( Owner.From.UseSkill( SkillName.Taming ) )
					Owner.From.Target.Invoke( Owner.From, m_Mobile );

				SkillHandlers.Taming.DisableMessage = false;
				Owner.From.TargetLocked = false;
			}
		}

		#region Teaching
		public virtual bool CanTeach{ get{ return false; } }

		public virtual bool CheckTeach( SkillName skill, Mobile from )
		{
			if ( !CanTeach )
				return false;

			if( skill == SkillName.Stealth && from.Skills[SkillName.Hiding].Base < ((Core.SE) ? 50.0 : 80.0) )
				return false;

			return true;
		}

		public enum TeachResult
		{
			Success,
			Failure,
			KnowsMoreThanMe,
			KnowsWhatIKnow,
			SkillNotRaisable,
			NotEnoughFreePoints
		}

		public virtual TeachResult CheckTeachSkills( SkillName skill, Mobile m, int maxPointsToLearn, ref int pointsToLearn, bool doTeach )
		{
			if ( !CheckTeach( skill, m ) || !m.CheckAlive() )
				return TeachResult.Failure;

			Skill ourSkill = Skills[skill];
			Skill theirSkill = m.Skills[skill];

			if ( ourSkill == null || theirSkill == null )
				return TeachResult.Failure;

			int baseToSet = ourSkill.BaseFixedPoint / 3;

			if ( baseToSet > 420 )
				baseToSet = 420;
			else if ( baseToSet < 200 )
				return TeachResult.Failure;

			if ( baseToSet > theirSkill.CapFixedPoint )
				baseToSet = theirSkill.CapFixedPoint;

			pointsToLearn = baseToSet - theirSkill.BaseFixedPoint;

			if ( maxPointsToLearn > 0 && pointsToLearn > maxPointsToLearn )
			{
				pointsToLearn = maxPointsToLearn;
				baseToSet = theirSkill.BaseFixedPoint + pointsToLearn;
			}

			if ( pointsToLearn < 0 )
				return TeachResult.KnowsMoreThanMe;

			if ( pointsToLearn == 0 )
				return TeachResult.KnowsWhatIKnow;

			if ( theirSkill.Lock != SkillLock.Up )
				return TeachResult.SkillNotRaisable;

			int freePoints = m.Skills.Cap - m.Skills.Total;
			int freeablePoints = 0;

			if ( freePoints < 0 )
				freePoints = 0;

			for ( int i = 0; (freePoints + freeablePoints) < pointsToLearn && i < m.Skills.Length; ++i )
			{
				Skill sk = m.Skills[i];

				if ( sk == theirSkill || sk.Lock != SkillLock.Down )
					continue;

				freeablePoints += sk.BaseFixedPoint;
			}

			if ( (freePoints + freeablePoints) == 0 )
				return TeachResult.NotEnoughFreePoints;

			if ( (freePoints + freeablePoints) < pointsToLearn )
			{
				pointsToLearn = freePoints + freeablePoints;
				baseToSet = theirSkill.BaseFixedPoint + pointsToLearn;
			}

			if ( doTeach )
			{
				int need = pointsToLearn - freePoints;

				for ( int i = 0; need > 0 && i < m.Skills.Length; ++i )
				{
					Skill sk = m.Skills[i];

					if ( sk == theirSkill || sk.Lock != SkillLock.Down )
						continue;

					if ( sk.BaseFixedPoint < need )
					{
						need -= sk.BaseFixedPoint;
						sk.BaseFixedPoint = 0;
					}
					else
					{
						sk.BaseFixedPoint -= need;
						need = 0;
					}
				}

				/* Sanity check */
				if ( baseToSet > theirSkill.CapFixedPoint || (m.Skills.Total - theirSkill.BaseFixedPoint + baseToSet) > m.Skills.Cap )
					return TeachResult.NotEnoughFreePoints;

				theirSkill.BaseFixedPoint = baseToSet;
			}

			return TeachResult.Success;
		}

		public virtual bool CheckTeachingMatch( Mobile m )
		{
			if ( m_Teaching == (SkillName)(-1) )
				return false;

			if ( m is PlayerMobile )
				return ( ((PlayerMobile)m).Learning == m_Teaching );

			return true;
		}

		private SkillName m_Teaching = (SkillName)(-1);

		public virtual bool Teach( SkillName skill, Mobile m, int maxPointsToLearn, bool doTeach )
		{
			int pointsToLearn = 0;
			TeachResult res = CheckTeachSkills( skill, m, maxPointsToLearn, ref pointsToLearn, doTeach );

			switch ( res )
			{
				case TeachResult.KnowsMoreThanMe:
				{
					Say( 501508 ); // I cannot teach thee, for thou knowest more than I!
					break;
				}
				case TeachResult.KnowsWhatIKnow:
				{
					Say( 501509 ); // I cannot teach thee, for thou knowest all I can teach!
					break;
				}
				case TeachResult.NotEnoughFreePoints:
				case TeachResult.SkillNotRaisable:
				{
					m.SendMessage( "Make sure this skill is marked to raise. If you are near the skill cap you may need to lose some points in another skill first.");
					break;
				}
				case TeachResult.Success:
				{
					if ( doTeach )
					{
						Say( 501539 ); // Let me show thee something of how this is done.
						m.SendLocalizedMessage( 501540 ); // Your skill level increases.

						m_Teaching = (SkillName)(-1);

						if ( m is PlayerMobile )
							((PlayerMobile)m).Learning = (SkillName)(-1);
					}
					else
					{
						// I will teach thee all I know, if paid the amount in full.  The price is:
						Say( 1019077, AffixType.Append, String.Format( " {0}", pointsToLearn ), "" );
						Say( 1043108 ); // For less I shall teach thee less.

						m_Teaching = skill;

						if ( m is PlayerMobile )
							((PlayerMobile)m).Learning = skill;
					}

					Server.Gumps.SkillListingGump.RefreshSkillList( m );

					return true;
				}
			}

			return false;
		}

		#endregion

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			if ( this.ControlMaster != null )
				if ( NotorietyHandlers.CheckAggressor( this.ControlMaster.Aggressors, aggressor ) )
					aggressor.Aggressors.Add( AggressorInfo.Create( this, aggressor, true ) );

			OrderType ct = m_ControlOrder;

			if ( m_AI != null )
			{
				if( !Core.ML || ( ct != OrderType.Follow && ct != OrderType.Stop ) )
				{
					m_AI.OnAggressiveAction( aggressor );
				}
				else
				{
					DebugSay( "I'm being attacked but my master told me not to fight." );
					Warmode = false;
					return;
				}
			}

			StopFlee();

			ForceReacquire();

			if ( !IsEnemy( aggressor ) )
			{
				Ethics.Player pl = Ethics.Player.Find( aggressor, true );

				if ( pl != null && pl.IsShielded )
					pl.FinishShield();
			}

			SlayerEntry undead_creatures = SlayerGroup.GetEntryByName( SlayerName.Silver );
			if ( undead_creatures.Slays(this) && aggressor is PlayerMobile )
			{
				Item item = aggressor.FindItemOnLayer( Layer.Helm );
				if ( item is DeathlyMask )
				{
					item.Delete();
					aggressor.LocalOverheadMessage(Network.MessageType.Emote, 0x3B2, false, "The mask of death has vanished.");
					aggressor.PlaySound( 0x1F0 );
				}
			}

			if ( aggressor.ChangingCombatant && (m_bControlled || m_bSummoned) && (ct == OrderType.Come || ( !Core.ML && ct == OrderType.Stay ) || ct == OrderType.Stop || ct == OrderType.None || ct == OrderType.Follow) )
			{
				ControlTarget = aggressor;
				ControlOrder = OrderType.Attack;
			}
			else if ( Combatant == null && !m_bBardPacified )
			{
				Warmode = true;
				Combatant = aggressor;
			}
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature && !((BaseCreature)m).Controlled )
				return ( !Alive || !m.Alive || IsDeadBondedPet || m.IsDeadBondedPet ) || ( Hidden && m.AccessLevel > AccessLevel.Player );

			return base.OnMoveOver( m );
		}

		public virtual void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public virtual bool CanDrop { get { return IsBonded; } }

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( m_AI != null && Commandable )
				m_AI.GetContextMenuEntries( from, list );

			if ( m_bTamable && !m_bControlled && from.Alive )
				list.Add( new TameEntry( from, this ) );

			AddCustomContextEntries( from, list );

			if ( CanTeach && from.Alive && from.Kills < 1 && !from.Criminal )
			{
				Skills ourSkills = this.Skills;
				Skills theirSkills = from.Skills;

				for ( int i = 0; i < ourSkills.Length && i < theirSkills.Length; ++i )
				{
					Skill skill = ourSkills[i];
					Skill theirSkill = theirSkills[i];

					if ( skill != null && theirSkill != null && skill.Base >= 60.0 && CheckTeach( skill.SkillName, from ) )
					{
						double toTeach = skill.Base / 3.0;

						if ( toTeach > 42.0 )
							toTeach = 42.0;

						list.Add( new TeachEntry( (SkillName)i, this, from, ( toTeach > theirSkill.Base ) ) );
					}
				}
			}
		}

		public override bool HandlesOnSpeech( Mobile from )
		{
			InhumanSpeech speechType = this.SpeechType;

			if ( speechType != null && (speechType.Flags & IHSFlags.OnSpeech) != 0 && from.InRange( this, 3 ) )
				return true;

			return ( m_AI != null && m_AI.HandlesOnSpeech( from ) && from.InRange( this, m_iRangePerception ) );
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			InhumanSpeech speechType = this.SpeechType;

			if ( speechType != null && speechType.OnSpeech( this, e.Mobile, e.Speech ) )
				e.Handled = true;
			else if ( !e.Handled && m_AI != null && e.Mobile.InRange( this, m_iRangePerception ) )
				m_AI.OnSpeech( e );
		}

		public override bool IsHarmfulCriminal( Mobile target )
		{
			if ( (Controlled && target == m_ControlMaster) || (Summoned && target == m_SummonMaster) )
				return false;

			if ( target is BaseCreature && ((BaseCreature)target).InitialInnocent && !((BaseCreature)target).Controlled )
				return false;

			if ( target is PlayerMobile && ((PlayerMobile)target).PermaFlags.Count > 0 )
				return false;

			return base.IsHarmfulCriminal( target );
		}

		public override void CriminalAction( bool message )
		{
			base.CriminalAction( message );

			if ( Controlled || Summoned )
			{
				if ( m_ControlMaster != null && m_ControlMaster.Player )
					m_ControlMaster.CriminalAction( false );
				else if ( m_SummonMaster != null && m_SummonMaster.Player )
					m_SummonMaster.CriminalAction( false );
			}
		}

		public override void DoHarmful( Mobile target, bool indirect )
		{
			base.DoHarmful( target, indirect );

			if ( target == this || target == m_ControlMaster || target == m_SummonMaster || (!Controlled && !Summoned) )
				return;

			List<AggressorInfo> list = this.Aggressors;

			for ( int i = 0; i < list.Count; ++i )
			{
				AggressorInfo ai = list[i];

				if ( ai.Attacker == target )
					return;
			}

			list = this.Aggressed;

			for ( int i = 0; i < list.Count; ++i )
			{
				AggressorInfo ai = list[i];

				if ( ai.Defender == target )
				{
					if ( m_ControlMaster != null && m_ControlMaster.Player && m_ControlMaster.CanBeHarmful( target, false ) )
						m_ControlMaster.DoHarmful( target, true );
					else if ( m_SummonMaster != null && m_SummonMaster.Player && m_SummonMaster.CanBeHarmful( target, false ) )
						m_SummonMaster.DoHarmful( target, true );

					return;
				}
			}
		}

		private static Mobile m_NoDupeGuards;

		public void ReleaseGuardDupeLock()
		{
			m_NoDupeGuards = null;
		}

		public void ReleaseGuardLock()
		{
			EndAction( typeof( GuardedRegion ) );
		}

		private DateTime m_IdleReleaseTime;

		public virtual bool CheckIdle()
		{
			if ( Combatant != null )
				return false; // in combat.. not idling

			if ( m_IdleReleaseTime > DateTime.MinValue )
			{
				// idling...

				if ( DateTime.Now >= m_IdleReleaseTime )
				{
					m_IdleReleaseTime = DateTime.MinValue;
					return false; // idle is over
				}

				return true; // still idling
			}

			if ( 95 > Utility.Random( 100 ) )
				return false; // not idling, but don't want to enter idle state

			m_IdleReleaseTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 15, 25 ) );

			if ( Body.IsHuman && !Mounted )
			{
				switch ( Utility.Random( 2 ) )
				{
					case 0: Animate( 5, 5, 1, true,  true, 1 ); break;
					case 1: Animate( 6, 5, 1, true, false, 1 ); break;
				}
			}
			else if ( Body.IsAnimal )
			{
				switch ( Utility.Random( 3 ) )
				{
					case 0: Animate(  3, 3, 1, true, false, 1 ); break;
					case 1: Animate(  9, 5, 1, true, false, 1 ); break;
					case 2: Animate( 10, 5, 1, true, false, 1 ); break;
				}
			}
			else if ( Body.IsMonster )
			{
				switch ( Utility.Random( 2 ) )
				{
					case 0: Animate( 17, 5, 1, true, false, 1 ); break;
					case 1: Animate( 18, 5, 1, true, false, 1 ); break;
				}
			}

			PlaySound( GetIdleSound() );
			return true; // entered idle state
		}

		protected override void OnLocationChange( Point3D oldLocation )
		{
			Map map = this.Map;

			if ( PlayerRangeSensitive && m_AI != null && map != null && map.GetSector( this.Location ).Active )
				m_AI.Activate();

			base.OnLocationChange( oldLocation );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );

			if ( ReacquireOnMovement || m_Paragon )
				ForceReacquire();

			InhumanSpeech speechType = this.SpeechType;

			if ( speechType != null )
				speechType.OnMovement( this, m, oldLocation );

			/* Begin notice sound */
			if ( (!m.Hidden || m.AccessLevel == AccessLevel.Player) && m.Player && m_FightMode != FightMode.Aggressor && m_FightMode != FightMode.None && Combatant == null && !Controlled && !Summoned )
			{
				// If this creature defends itself but doesn't actively attack (animal) or
				// doesn't fight at all (vendor) then no notice sounds are played..
				// So, players are only notified of aggressive monsters

				// Monsters that are currently fighting are ignored

				// Controlled or summoned creatures are ignored

				if ( InRange( m.Location, 18 ) && !InRange( oldLocation, 18 ) && IsEnemy( m ) && CanSee( m ) && InLOS( m ) )
				{
					if ( Body.IsMonster )
						Animate( 11, 5, 1, true, false, 1 );

					PlaySound( GetAngerSound() );
				}
			}
			/* End notice sound */

			if ( m_NoDupeGuards == m )
				return;

			if ( !Body.IsHuman || Kills >= 5 || AlwaysMurderer || AlwaysAttackable || m.Kills < 5 || !m.InRange( Location, 12 ) || !m.Alive )
				return;
		}

		public void AddSpellAttack( Type type )
		{
			m_arSpellAttack.Add ( type );
		}

		public void AddSpellDefense( Type type )
		{
			m_arSpellDefense.Add ( type );
		}

		public Spell GetAttackSpellRandom()
		{
			if ( m_arSpellAttack.Count > 0 )
			{
				Type type = m_arSpellAttack[Utility.Random(m_arSpellAttack.Count)];

				object[] args = {this, null};
				return Activator.CreateInstance( type, args ) as Spell;
			}
			else
			{
				return null;
			}
		}

		public Spell GetDefenseSpellRandom()
		{
			if ( m_arSpellDefense.Count > 0 )
			{
				Type type = m_arSpellDefense[Utility.Random(m_arSpellDefense.Count)];

				object[] args = {this, null};
				return Activator.CreateInstance( type, args ) as Spell;
			}
			else
			{
				return null;
			}
		}

		public Spell GetSpellSpecific( Type type )
		{
			int i;

			for( i=0; i< m_arSpellAttack.Count; i++ )
			{
				if( m_arSpellAttack[i] == type )
				{
					object[] args = { this, null };
					return Activator.CreateInstance( type, args ) as Spell;
				}
			}

			for ( i=0; i< m_arSpellDefense.Count; i++ )
			{
				if ( m_arSpellDefense[i] == type )
				{
					object[] args = {this, null};
					return Activator.CreateInstance( type, args ) as Spell;
				}
			}

			return null;
		}

		#region Set[...]

		public void SetDamage( int val )
		{
			m_DamageMin = val;
			m_DamageMax = val;
		}

		public void SetDamage( int min, int max )
		{
			m_DamageMin = min;
			m_DamageMax = max;
		}

		public void SetHits( int val )
		{
			if ( val < 1000 && !Core.AOS )
				val = (val * 100) / 60;

			m_HitsMax = val;
			Hits = HitsMax;
		}

		public void SetHits( int min, int max )
		{
			if ( min < 1000 && !Core.AOS )
			{
				min = (min * 100) / 60;
				max = (max * 100) / 60;
			}

			m_HitsMax = Utility.RandomMinMax( min, max );
			Hits = HitsMax;
		}

		public void SetStam( int val )
		{
			m_StamMax = val;
			Stam = StamMax;
		}

		public void SetStam( int min, int max )
		{
			m_StamMax = Utility.RandomMinMax( min, max );
			Stam = StamMax;
		}

		public void SetMana( int val )
		{
			m_ManaMax = val;
			Mana = ManaMax;
		}

		public void SetMana( int min, int max )
		{
			m_ManaMax = Utility.RandomMinMax( min, max );
			Mana = ManaMax;
		}

		public void SetStr( int val )
		{
			RawStr = val;
			Hits = HitsMax;
		}

		public void SetStr( int min, int max )
		{
			RawStr = Utility.RandomMinMax( min, max );
			Hits = HitsMax;
		}

		public void SetDex( int val )
		{
			RawDex = val;
			Stam = StamMax;
		}

		public void SetDex( int min, int max )
		{
			RawDex = Utility.RandomMinMax( min, max );
			Stam = StamMax;
		}

		public void SetInt( int val )
		{
			RawInt = val;
			Mana = ManaMax;
		}

		public void SetInt( int min, int max )
		{
			RawInt = Utility.RandomMinMax( min, max );
			Mana = ManaMax;
		}

		public void SetDamageType( ResistanceType type, int min, int max )
		{
			SetDamageType( type, Utility.RandomMinMax( min, max ) );
		}

		public void SetDamageType( ResistanceType type, int val )
		{
			switch ( type )
			{
				case ResistanceType.Physical: m_PhysicalDamage = val; break;
				case ResistanceType.Fire: m_FireDamage = val; break;
				case ResistanceType.Cold: m_ColdDamage = val; break;
				case ResistanceType.Poison: m_PoisonDamage = val; break;
				case ResistanceType.Energy: m_EnergyDamage = val; break;
			}
		}

		public void SetResistance( ResistanceType type, int min, int max )
		{
			SetResistance( type, Utility.RandomMinMax( min, max ) );
		}

		public void SetResistance( ResistanceType type, int val )
		{
			switch ( type )
			{
				case ResistanceType.Physical: m_PhysicalResistance = val; break;
				case ResistanceType.Fire: m_FireResistance = val; break;
				case ResistanceType.Cold: m_ColdResistance = val; break;
				case ResistanceType.Poison: m_PoisonResistance = val; break;
				case ResistanceType.Energy: m_EnergyResistance = val; break;
			}

			UpdateResistances();
		}

		public void SetSkill( SkillName name, double val )
		{
			Skills[name].BaseFixedPoint = (int)(val * 10);

			if ( Skills[name].Base > Skills[name].Cap )
			{
				if ( Core.SE )
					this.SkillsCap += ( Skills[name].BaseFixedPoint - Skills[name].CapFixedPoint );

				Skills[name].Cap = Skills[name].Base;
			}
		}

		public void SetSkill( SkillName name, double min, double max )
		{
			int minFixed = (int)(min * 10);
			int maxFixed = (int)(max * 10);

			Skills[name].BaseFixedPoint = Utility.RandomMinMax( minFixed, maxFixed );

			if ( Skills[name].Base > Skills[name].Cap )
			{
				if ( Core.SE )
					this.SkillsCap += ( Skills[name].BaseFixedPoint - Skills[name].CapFixedPoint );

				Skills[name].Cap = Skills[name].Base;
			}
		}

		public void SetFameLevel( int level )
		{
			switch ( level )
			{
				case 1: Fame = Utility.RandomMinMax(     0,  1249 ); break;
				case 2: Fame = Utility.RandomMinMax(  1250,  2499 ); break;
				case 3: Fame = Utility.RandomMinMax(  2500,  4999 ); break;
				case 4: Fame = Utility.RandomMinMax(  5000,  9999 ); break;
				case 5: Fame = Utility.RandomMinMax( 10000, 10000 ); break;
			}
		}

		public void SetKarmaLevel( int level )
		{
			switch ( level )
			{
				case 0: Karma = -Utility.RandomMinMax(     0,   624 ); break;
				case 1: Karma = -Utility.RandomMinMax(   625,  1249 ); break;
				case 2: Karma = -Utility.RandomMinMax(  1250,  2499 ); break;
				case 3: Karma = -Utility.RandomMinMax(  2500,  4999 ); break;
				case 4: Karma = -Utility.RandomMinMax(  5000,  9999 ); break;
				case 5: Karma = -Utility.RandomMinMax( 10000, 10000 ); break;
			}
		}

		#endregion

		public static void Cap( ref int val, int min, int max )
		{
			if ( val < min )
				val = min;
			else if ( val > max )
				val = max;
		}

		#region Pack & Loot

		public void PackPotion()
		{
			PackItem( Loot.RandomPotion() );
		}

		public void PackElementalScroll( double chance )
		{
			if ( chance <= Utility.RandomDouble() )
				return;

			PackItem( Loot.Construct( Loot.ElementalScrollTypes ) );
		}

		public void PackNecroScroll( int index )
		{
			if ( 0.05 <= Utility.RandomDouble() )
				return;

			PackItem( Loot.Construct( Loot.NecromancyScrollTypes, index ) );
		}

		public void PackScroll( int minCircle, int maxCircle )
		{
			PackScroll( Utility.RandomMinMax( minCircle, maxCircle ) );
		}

		public void PackScroll( int circle )
		{
			int min = (circle - 1) * 8;
			int Emin = (circle - 1) * 4;

			if ( Utility.RandomMinMax( 1, 5 ) == 1 )
				PackItem( Loot.RandomScroll( min, min + 7, SpellbookType.Regular ) );
			else
				PackItem( Loot.RandomScroll( Emin, Emin + 3, SpellbookType.Elementalism ) );
		}

		public void PackMagicItems( int minLevel, int maxLevel )
		{
			PackMagicItems( minLevel, maxLevel, 0.30, 0.15 );
		}

		public void PackMagicItems( int minLevel, int maxLevel, double armorChance, double weaponChance )
		{
			if ( !PackArmor( minLevel, maxLevel, armorChance ) )
				PackWeapon( minLevel, maxLevel, weaponChance );
		}

		public virtual void DropBackpack()
		{
			if ( Backpack != null )
			{
				if( Backpack.Items.Count > 0 )
				{
					Backpack b = new CreatureBackpack( Name );

					List<Item> list = new List<Item>( Backpack.Items );
					foreach ( Item item in list )
					{
						b.DropItem( item );
					}

					BaseHouse house = BaseHouse.FindHouseAt( this );
					if ( house  != null )
						b.MoveToWorld( house.BanLocation, house.Map );
					else
						b.MoveToWorld( Location, Map );
				}
			}
		}

		protected bool m_Spawning;
		protected int m_KillersLuck;

		public virtual void GenerateLoot( bool spawning )
		{
			m_Spawning = spawning;

			if ( !spawning )
				m_KillersLuck = LootPack.GetLuckChanceForKiller( this );

			GenerateLoot();

			if ( m_Paragon )
			{
				if ( Fame < 1250 )
					AddLoot( LootPack.Meager );
				else if ( Fame < 2500 )
					AddLoot( LootPack.Average );
				else if ( Fame < 5000 )
					AddLoot( LootPack.Rich );
				else if ( Fame < 10000 )
					AddLoot( LootPack.FilthyRich );
				else
					AddLoot( LootPack.UltraRich );
			}

			m_Spawning = false;
			m_KillersLuck = 0;
		}

		public virtual void GenerateLoot()
		{
		}

		public virtual void AddLoot( LootPack pack, int amount )
		{
			for ( int i = 0; i < amount; ++i )
				AddLoot( pack );
		}

		public virtual void AddLoot( LootPack pack )
		{
			if ( Summoned )
				return;

			Container backpack = Backpack;

			if ( backpack == null )
			{
				backpack = new Backpack();

				backpack.Movable = false;

				AddItem( backpack );
			}

			pack.Generate( this, backpack, m_Spawning, m_KillersLuck );
		}

		public bool PackArmor( int minLevel, int maxLevel )
		{
			return PackArmor( minLevel, maxLevel, 1.0 );
		}

		public bool PackArmor( int minLevel, int maxLevel, double chance )
		{
			if ( chance <= Utility.RandomDouble() )
				return false;

			Cap( ref minLevel, 0, 5 );
			Cap( ref maxLevel, 0, 5 );

			Item item = Loot.RandomArmorOrShieldOrJewelry();

			if ( item == null )
				return false;

			int attributeCount, min, max;
			GetRandomAOSStats( minLevel, maxLevel, out attributeCount, out min, out max );

			if ( item is BaseArmor )
			{
				BaseRunicTool.ApplyAttributesTo( (BaseArmor)item, attributeCount, min, max );
				item.Name = LootPackEntry.MagicItemName( item, this, Region.Find( this.Location, this.Map ) );
				Server.Misc.MorphingTime.ChangeMaterialType( item, this );
			}
			else if ( item is BaseJewel )
			{
				BaseRunicTool.ApplyAttributesTo( (BaseJewel)item, attributeCount, min, max );
				item.Name = LootPackEntry.MagicItemName( item, this, Region.Find( this.Location, this.Map ) );
			}

			PackItem( item );

			return true;
		}

		public static void GetRandomAOSStats( int minLevel, int maxLevel, out int attributeCount, out int min, out int max )
		{
			int v = RandomMinMaxScaled( minLevel, maxLevel );

			if ( v >= 5 )
			{
				attributeCount = Utility.RandomMinMax( 2, 6 );
				min = 20; max = 70;
			}
			else if ( v == 4 )
			{
				attributeCount = Utility.RandomMinMax( 2, 4 );
				min = 20; max = 50;
			}
			else if ( v == 3 )
			{
				attributeCount = Utility.RandomMinMax( 2, 3 );
				min = 20; max = 40;
			}
			else if ( v == 2 )
			{
				attributeCount = Utility.RandomMinMax( 1, 2 );
				min = 10; max = 30;
			}
			else
			{
				attributeCount = 1;
				min = 10; max = 20;
			}
		}

		public static int RandomMinMaxScaled( int min, int max )
		{
			if ( min == max )
				return min;

			if ( min > max )
			{
				int hold = min;
				min = max;
				max = hold;
			}

			/* Example:
			 *    min: 1
			 *    max: 5
			 *  count: 5
			 *
			 * total = (5*5) + (4*4) + (3*3) + (2*2) + (1*1) = 25 + 16 + 9 + 4 + 1 = 55
			 *
			 * chance for min+0 : 25/55 : 45.45%
			 * chance for min+1 : 16/55 : 29.09%
			 * chance for min+2 :  9/55 : 16.36%
			 * chance for min+3 :  4/55 :  7.27%
			 * chance for min+4 :  1/55 :  1.81%
			 */

			int count = max - min + 1;
			int total = 0, toAdd = count;

			for ( int i = 0; i < count; ++i, --toAdd )
				total += toAdd*toAdd;

			int rand = Utility.Random( total );
			toAdd = count;

			int val = min;

			for ( int i = 0; i < count; ++i, --toAdd, ++val )
			{
				rand -= toAdd*toAdd;

				if ( rand < 0 )
					break;
			}

			return val;
		}

		public bool PackSlayer()
		{
			return PackSlayer( 0.05 );
		}

		public bool PackSlayer( double chance )
		{
			if ( chance <= Utility.RandomDouble() )
				return false;

			if ( Utility.RandomBool() )
			{
				BaseInstrument instrument = Loot.RandomInstrument();

				if ( instrument != null )
				{
					instrument.Slayer = SlayerGroup.GetLootSlayerType( GetType() );
					PackItem( instrument );
				}
			}
			else if ( !Core.AOS )
			{
				BaseWeapon weapon = Loot.RandomWeapon();

				if ( weapon != null )
				{
					weapon.Slayer = SlayerGroup.GetLootSlayerType( GetType() );
					PackItem( weapon );
				}
			}

			return true;
		}

		public bool PackWeapon( int minLevel, int maxLevel )
		{
			return PackWeapon( minLevel, maxLevel, 1.0 );
		}

		public bool PackWeapon( int minLevel, int maxLevel, double chance )
		{
			if ( chance <= Utility.RandomDouble() )
				return false;

			Cap( ref minLevel, 0, 5 );
			Cap( ref maxLevel, 0, 5 );

			if ( Core.AOS )
			{
				Item item = Loot.RandomWeaponOrJewelry();

				if ( item == null )
					return false;

				int attributeCount, min, max;
				GetRandomAOSStats( minLevel, maxLevel, out attributeCount, out min, out max );

				if ( item is BaseWeapon )
				{
					BaseRunicTool.ApplyAttributesTo( (BaseWeapon)item, attributeCount, min, max );
					item.Name = LootPackEntry.MagicItemName( item, this, Region.Find( this.Location, this.Map ) );
					Server.Misc.MorphingTime.ChangeMaterialType( item, this );
				}
				else if ( item is BaseJewel )
				{
					BaseRunicTool.ApplyAttributesTo( (BaseJewel)item, attributeCount, min, max );
					item.Name = LootPackEntry.MagicItemName( item, this, Region.Find( this.Location, this.Map ) );
				}

				PackItem( item );
			}
			else
			{
				BaseWeapon weapon = Loot.RandomWeapon();

				if ( weapon == null )
					return false;

				if ( 0.05 > Utility.RandomDouble() )
					weapon.Slayer = SlayerName.Silver;

				weapon.DamageLevel = (WeaponDamageLevel)RandomMinMaxScaled( minLevel, maxLevel );
				weapon.AccuracyLevel = (WeaponAccuracyLevel)RandomMinMaxScaled( minLevel, maxLevel );
				weapon.DurabilityLevel = (WeaponDurabilityLevel)RandomMinMaxScaled( minLevel, maxLevel );

				PackItem( weapon );
			}

			return true;
		}

		public void PackGold( int amount )
		{
			if ( amount > 0 )
				PackItem( new Gold( amount ) );
		}

		public void PackGold( int min, int max )
		{
			PackGold( Utility.RandomMinMax( min, max ) );
		}

		public void PackStatue( int min, int max )
		{
			PackStatue( Utility.RandomMinMax( min, max ) );
		}

		public void PackStatue( int amount )
		{
			for ( int i = 0; i < amount; ++i )
				PackStatue();
		}

		public void PackStatue()
		{
			PackItem( Loot.RandomStatue() );
		}

		public void PackGem()
		{
			PackGem( 1 );
		}

		public void PackGem( int min, int max )
		{
			PackGem( Utility.RandomMinMax( min, max ) );
		}

		public void PackGem( int amount )
		{
			if ( amount <= 0 )
				return;

			Item gem = Loot.RandomGem();

			gem.Amount = amount;

			PackItem( gem );
		}

		public void PackNecroReg( int min, int max )
		{
			int amount = Utility.RandomMinMax( min, max );

			if ( Utility.RandomMinMax( 1 , 4 ) == 1 )
			{
				for ( int i = 0; i < amount; ++i )
					PackItem( Loot.RandomNecromancyReagent() );
			}
			else
			{
				Item wizreg = Loot.RandomSecretReagent();
				if ( Server.Misc.Worlds.IsOnSpaceship( this.Location, this.Map ) ){ Server.Misc.MorphingTime.MakeSpaceAceItem( wizreg, this ); }
				UnknownReagent myreg = (UnknownReagent)wizreg;
				myreg.RegAmount = Utility.RandomMinMax( (amount * 1), (amount * 2) );
				PackItem( myreg );
			}
		}

		public void PackNecroReg( int amount )
		{
			if ( Utility.RandomMinMax( 1 , 4 ) == 1 )
			{
				for ( int i = 0; i < amount; ++i )
					PackItem( Loot.RandomNecromancyReagent() );
			}
			else
			{
				Item wizreg = Loot.RandomSecretReagent();
				UnknownReagent myreg = (UnknownReagent)wizreg;
				if ( Server.Misc.Worlds.IsOnSpaceship( this.Location, this.Map ) ){ Server.Misc.MorphingTime.MakeSpaceAceItem( wizreg, this ); }
				myreg.RegAmount = Utility.RandomMinMax( (amount * 1), (amount * 4) );
				PackItem( myreg );
			}
		}

		public void PackNecroReg()
		{
			if ( Utility.RandomMinMax( 1 , 4 ) == 1 ){ PackItem( Loot.RandomNecromancyReagent() ); }
			else
			{
				Item wizreg = Loot.RandomSecretReagent();
				UnknownReagent myreg = (UnknownReagent)wizreg;
				if ( Server.Misc.Worlds.IsOnSpaceship( this.Location, this.Map ) ){ Server.Misc.MorphingTime.MakeSpaceAceItem( wizreg, this ); }
				PackItem( myreg );
			}
		}

		public void PackReg( int min, int max )
		{
			PackReg( Utility.RandomMinMax( min, max ) );
		}

		public void PackReg( int amount )
		{
			if ( amount <= 0 )
				return;

			Item reg = Loot.RandomReagent();

			reg.Amount = amount;

			if ( Utility.RandomMinMax( 1 , 4 ) == 1 ){ PackItem( reg ); }
			else
			{
				Item wizreg = Loot.RandomSecretReagent();
				UnknownReagent myreg = (UnknownReagent)wizreg;
				if ( Server.Misc.Worlds.IsOnSpaceship( this.Location, this.Map ) ){ Server.Misc.MorphingTime.MakeSpaceAceItem( wizreg, this ); }
				myreg.RegAmount = amount; PackItem( myreg );
			}
		}

		public void PackItem( Item item )
		{
			if ( Summoned || item == null )
			{
				if ( item != null )
					item.Delete();

				return;
			}

			Container pack = Backpack;

			if ( pack == null )
			{
				pack = new Backpack();

				pack.Movable = false;

				AddItem( pack );
			}

			if ( !item.Stackable || !pack.TryDropItem( this, item, false ) ) // try stack
				pack.DropItem( item ); // failed, drop it anyway
		}

		#endregion

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.AccessLevel >= AccessLevel.GameMaster && !Body.IsHuman && RaceID < 1 )
			{
				Container pack = this.Backpack;

				if ( pack != null )
					pack.DisplayTo( from );
			}

			if ( this.DeathAdderCharmable && from.CanBeHarmful( this, false ) )
			{
				DeathAdder da = Spells.Necromancy.SummonFamiliarSpell.Table[from] as DeathAdder;

				if ( da != null && !da.Deleted )
				{
					from.SendAsciiMessage( "You charm the snake.  Select a target to attack." );
					from.Target = new DeathAdderCharmTarget( this );
				}
			}

			if ( isVortex( this ) && from == SummonMaster )
			{
				Effects.SendLocationParticles( EffectItem.Create( Location, Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 0, 0, 5042, 0 );
				Effects.PlaySound( this, Map, 0x201 );
				Delete();
			}

			base.OnDoubleClick( from );
		}

		private class DeathAdderCharmTarget : Target
		{
			private BaseCreature m_Charmed;

			public DeathAdderCharmTarget( BaseCreature charmed ) : base( -1, false, TargetFlags.Harmful )
			{
				m_Charmed = charmed;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( !m_Charmed.DeathAdderCharmable || m_Charmed.Combatant != null || !from.CanBeHarmful( m_Charmed, false ) )
					return;

				DeathAdder da = Spells.Necromancy.SummonFamiliarSpell.Table[from] as DeathAdder;
				if ( da == null || da.Deleted )
					return;

				Mobile targ = targeted as Mobile;
				if ( targ == null || !from.CanBeHarmful( targ, false ) )
					return;

				from.RevealingAction();
				from.DoHarmful( targ, true );

				m_Charmed.Combatant = targ;

				if ( m_Charmed.AIObject != null )
					m_Charmed.AIObject.Action = ActionType.Combat;
			}
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			if ( Core.ML )
			{
				if ( DisplayWeight && Controlled )
					list.Add( TotalWeight == 1 ? 1072788 : 1072789, TotalWeight.ToString() ); // Weight: ~1_WEIGHT~ stones

				if ( m_ControlOrder == OrderType.Guard )
					list.Add( 1080078 ); // guarding
			}

			if ( this is JediMirage || this is SythProjection || this is Clown || this is Clone ){} // NO WORDS
			else if ( this is HenchmanFamiliar )
				list.Add( "(familiar)" );
			else if ( this is PackBeast )
				list.Add( "(Pack Animal)" );
			else if ( this is GolemPorter || this is GolemFighter )
				list.Add( "(automaton)" );
			else if ( this is Robot )
				list.Add( "(robot)" );
			else if ( this is FrankenPorter || this is FrankenFighter )
				list.Add( "(reanimation)" );
			else if ( Summoned && !IsAnimatedDead && !IsNecroFamiliar )
				list.Add( 1049646 ); // (summoned)
			else if ( Controlled && Commandable && !(this is FrankenFighter) && !(this is AerialServant) && !(this is FrankenPorter) && !(this is Robot) && !(this is GolemFighter) && !(this is GolemPorter) && !(this is PackBeast) && !(this is HenchmanMonster) && !(this is HenchmanFighter) && !(this is HenchmanWizard) && !(this is HenchmanArcher) && !(this is HenchmanFamiliar) )
			{
				if ( IsBonded )	//Intentional difference (showing ONLY bonded when bonded instead of bonded & tame)
					list.Add( 1049608 ); // (bonded)
				else
					list.Add( 502006 ); // (tame)

                list.Add(1060662, String.Format("Loyalty Rating\t{0}%", Loyalty.ToString())); // ADD THIS
			}
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( Controlled && Commandable )
			{
				int number;

				if ( Summoned )
					number = 1049646; // (summoned)
				else if ( IsBonded )
					number = 1049608; // (bonded)
				else
					number = 502006; // (tame)

				PrivateOverheadMessage( MessageType.Regular, 0x3B2, number, from.NetState );
			}

			base.OnSingleClick( from );
		}

		public virtual double TreasureMapChance{ get{ return TreasureMap.LootChance; } }
		public virtual int TreasureMapLevel{ get{ return -1; } }

		public virtual bool IgnoreYoungProtection { get { return false; } }

		public bool SeaEnemy()
		{
			if ( this.WhisperHue == 999 ||
				 this is PirateCrewMage ||
				 this is PirateCrewBow ||
				 this is PirateCrew ||
				 this is PirateCaptain ||
				 this is ElfPirateCrewMage ||
				 this is ElfPirateCrewBow ||
				 this is ElfPirateCrew ||
				 this is ElfPirateCaptain ||
				 this is BaseSailor ||
				 this is BasePirate )
				return true;

			return false;
		}

		public override bool OnBeforeDeath()
		{
			Region reg = Region.Find( this.Location, this.Map );

			SlayerEntry undead = SlayerGroup.GetEntryByName( SlayerName.Silver );
			SlayerEntry exorcism = SlayerGroup.GetEntryByName( SlayerName.Exorcism );

			if ( AI == AIType.AI_Citizen )
			{
				Mobile murderer = this.LastKiller;

				if (murderer is BaseCreature)
				{
					BaseCreature bc_killer = (BaseCreature)murderer;
					if(bc_killer.Summoned)
					{
						if(bc_killer.SummonMaster != null)
							murderer = bc_killer.SummonMaster;
					}
					else if(bc_killer.Controlled)
					{
						if(bc_killer.ControlMaster != null)
							murderer=bc_killer.ControlMaster;
					}
					else if(bc_killer.BardProvoked)
					{
						if(bc_killer.BardMaster != null)
							murderer=bc_killer.BardMaster;
					}
				}

				if ( murderer is PlayerMobile )
				{
					murderer.Criminal = true;
					murderer.Kills = murderer.Kills + 1;
					Server.Items.DisguiseTimers.RemoveDisguise( murderer );
				}

				string bSay = "Help! Guards!";
				this.PublicOverheadMessage( MessageType.Regular, 0, false, string.Format ( bSay ) );
			}

			Mobile slayer = this.FindMostRecentDamager(true);
			int Heat = Worlds.GetDifficultyLevel( this.Location, this.Map );
			if ( !this.IsBonded && ( slayer is BasePerson || ( slayer is BaseCreature && ((BaseCreature)slayer).FightMode == FightMode.Evil ) ) )
			{
				this.Delete();
			}
			else if ( !this.IsBonded && this is BaseCreature && this.FightMode == FightMode.Evil )
			{
				if ( slayer is PlayerMobile ){}
				else if ( slayer is BaseCreature && ((BaseCreature)slayer).ControlMaster != null && ((BaseCreature)slayer).Controlled ){}
				else { this.Delete(); }
			}
			else if ( Heat > 0 && IsParagon == false )
			{
				BeefUpLoot( this, Heat );
			}

			if ( slayer is PlayerMobile )
			{
				///////////////////////////////////////////////////////////////////////////////////////

				Server.Misc.IntelligentAction.SaySomethingOnDeath( this, this.LastKiller );

				Server.Misc.HoardPile.MakeHoard( this ); // SEE IF A HOARD DROPS NEARBY

				Server.Misc.SummonQuests.WellTheyDied( this, this );

				///////////////////////////////////////////////////////////////////////////////////////

				if ( SeaEnemy() )
					Server.Engines.Harvest.Fishing.SailorSkill( slayer, (int)( IntelligentAction.GetCreatureLevel( this ) / 10 ) );

				if ( reg.IsPartOf( typeof( NecromancerRegion ) ) && GetPlayerInfo.EvilPlayer( slayer ) && slayer.Skills[SkillName.Necromancy].Base >= 25 )
				{
					if ( undead.Slays(this) || exorcism.Slays(this) )
					{
						switch ( Utility.Random( 7 ) )
						{
							case 0: PackItem( new BatWing( Utility.RandomMinMax( 1, 10 ) ) ); break;
							case 1: PackItem( new NoxCrystal( Utility.RandomMinMax( 1, 10 ) ) ); break;
							case 2: PackItem( new GraveDust( Utility.RandomMinMax( 1, 10 ) ) ); break;
							case 3: PackItem( new PigIron( Utility.RandomMinMax( 1, 10 ) ) ); break;
							case 4: PackItem( new DaemonBlood( Utility.RandomMinMax( 1, 10 ) ) ); break;
						}
					}
					else if ( this is EvilMage )
					{
						PackItem( new BatWing( Utility.RandomMinMax( 1, 10 ) ) );
						PackItem( new NoxCrystal( Utility.RandomMinMax( 1, 10 ) ) );
						PackItem( new GraveDust( Utility.RandomMinMax( 1, 10 ) ) );
						PackItem( new PigIron( Utility.RandomMinMax( 1, 10 ) ) );
						PackItem( new DaemonBlood( Utility.RandomMinMax( 1, 10 ) ) );
					}
				}

				Server.Misc.IntelligentAction.DropReagent( slayer, this );

				if ( slayer.Skills[SkillName.Forensics].Value >= Utility.RandomMinMax( 30, 150 ) )
				{
					if ( 	this is MummyGiant || this is FleshGolem || this is ReanimatedDragon || this is AncientFleshGolem || this is SkinGolem ||
							this is Ghoul || this is AquaticGhoul || this is DiseasedMummy || this is Mummy || this is MummyLord || this is RottingCorpse ||
							this is WalkingCorpse || this is ZombieGiant || this is FrozenCorpse || this is ZombieGargoyle || this is SeaZombie ||
							this is ZombieMage || this is Zombie )
					{
						PackItem( new EmbalmingFluid() );
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////////////

			SlayerEntry spreaddeath = SlayerGroup.GetEntryByName( SlayerName.Repond );

			Mobile deathknight = this.LastKiller;										// DEATH KNIGHT HOLDING SOUL LANTERNS
			if ( spreaddeath.Slays(this) && deathknight != null && this.TotalGold > 0 )	// TURNS THE MONEY TO SOUL COUNT
			{
				if ( deathknight is BaseCreature )
					deathknight = ((BaseCreature)deathknight).GetMaster();

				if ( deathknight is PlayerMobile )
				{
					Item lantern = deathknight.FindItemOnLayer( Layer.TwoHanded );

					if ( lantern is SoulLantern )
					{
						SoulLantern souls = (SoulLantern)lantern;
						souls.TrappedSouls = souls.TrappedSouls + this.TotalGold;
						if ( souls.TrappedSouls > 100000 ){ souls.TrappedSouls = 100000; }
						souls.InvalidateProperties();

						Item deathpack = this.FindItemOnLayer( Layer.Backpack );
						if ( deathpack != null )
						{
							Item dtcoins = this.Backpack.FindItemByType( typeof( Gold ) );
							dtcoins.Delete();
							deathknight.SendMessage( "A soul has been claimed." );
							Effects.SendLocationParticles( EffectItem.Create( deathknight.Location, deathknight.Map, EffectItem.DefaultDuration ), 0x376A, 9, 32, 5008 );
							Effects.PlaySound( deathknight.Location, deathknight.Map, 0x1ED );
						}
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////////////

			SlayerEntry holyundead = SlayerGroup.GetEntryByName( SlayerName.Silver );
			SlayerEntry holydemons = SlayerGroup.GetEntryByName( SlayerName.Exorcism );

			Mobile holyman = this.LastKiller;																		// HOLY MANY HOLDING HOLY SYMBOL
			if ( ( holyundead.Slays(this) || holydemons.Slays(this) ) && holyman != null && this.TotalGold > 0 )	// TURNS THE MONEY TO BANISH COUNT
			{
				if ( holyman is BaseCreature )
					holyman = ((BaseCreature)holyman).GetMaster();

				if ( holyman is PlayerMobile )
				{
					Item symbol = holyman.FindItemOnLayer( Layer.Talisman );

					if ( symbol is HolySymbol )
					{
						HolySymbol banish = (HolySymbol)symbol;
						banish.BanishedEvil = banish.BanishedEvil + this.TotalGold;
						if ( banish.BanishedEvil > 100000 ){ banish.BanishedEvil = 100000; }
						banish.InvalidateProperties();

						Item deathpack = this.FindItemOnLayer( Layer.Backpack );
						if ( deathpack != null )
						{
							Item dtcoins = this.Backpack.FindItemByType( typeof( Gold ) );
							dtcoins.Delete();
							holyman.SendMessage( "Evil has been banished." );
							holyman.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
							holyman.PlaySound( 0x1EA );
						}
					}
				}
			}

			///////////////////////////////////////////////////////////////////////////////////////

			SlayerEntry vampAnimal = SlayerGroup.GetEntryByName( SlayerName.AnimalHunter );
			SlayerEntry vampAvian = SlayerGroup.GetEntryByName( SlayerName.AvianHunter );
			SlayerEntry vampRepond = SlayerGroup.GetEntryByName( SlayerName.Repond );
			SlayerEntry vampGiant = SlayerGroup.GetEntryByName( SlayerName.GiantKiller );

			if ( vampAnimal.Slays(this) || vampAvian.Slays(this) || vampRepond.Slays(this) || vampGiant.Slays(this) )
			{
				Mobile vampire = this.LastKiller;

				if ( vampire is BaseCreature )
					vampire = ((BaseCreature)vampire).GetMaster();

				if ( vampire is PlayerMobile && Server.Items.BaseRace.BloodDrinker( vampire.RaceID ) && Utility.RandomBool() )
				{
					PackItem( new BloodyDrink() );
				}
				else if ( vampire is PlayerMobile && Server.Items.BaseRace.BrainEater( vampire.RaceID ) && Utility.RandomBool() )
				{
					PackItem( new FreshBrain() );
				}
			}

			///////////////////////////////////////////////////////////////////////////////////////

			// GOLDEN FEATHERS FOR THE RANGERS OUTPOST ALTAR
			if ( this is Harpy || this is StoneHarpy || this is SnowHarpy || this is Phoenix || this is HarpyElder || this is HarpyHen )
			{
				Mobile FeatherGetter = this.LastKiller;

				if ( FeatherGetter is BaseCreature )
					FeatherGetter = ((BaseCreature)FeatherGetter).GetMaster();

				if ( FeatherGetter is PlayerMobile )
				{
					Item RangerBook = FeatherGetter.Backpack.FindItemByType( typeof( GoldenRangers ) );
					if ( RangerBook != null && ( FeatherGetter.Skills[SkillName.Camping].Base >= 90 || FeatherGetter.Skills[SkillName.Tracking].Base >= 90 ) )
					{
						int FeatherChance = 5;
						if ( this is Phoenix ){ FeatherChance = 25; }

						if ( FeatherChance >= Utility.RandomMinMax( 1, 100 ) )
						{
							ArrayList targets = new ArrayList();
							foreach ( Item item in World.Items.Values )
							if ( item is GoldenFeathers )
							{
								GoldenFeathers goldfeather = (GoldenFeathers)item;
								if ( goldfeather.owner == FeatherGetter )
								{
									targets.Add( item );
								}
							}
							for ( int i = 0; i < targets.Count; ++i )
							{
								Item item = ( Item )targets[ i ];
								item.Delete();
							}
							FeatherGetter.AddToBackpack( new GoldenFeathers( FeatherGetter ) );
							FeatherGetter.SendSound( 0x3D );
							FeatherGetter.PrivateOverheadMessage(MessageType.Regular, 1150, false, "The goddess has given you golden feathers.", FeatherGetter.NetState);
						}
					}
				}
			}

			int treasureLevel = TreasureMapLevel;

			if ( treasureLevel == 1 && this.Map == Map.Sosaria )
			{
				Mobile killer = this.LastKiller;

				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile && ((PlayerMobile)killer).Young )
					treasureLevel = 0;
			}

			if ( !Summoned && !NoKillAwards && !IsBonded && treasureLevel >= 0 )
			{
				if ( m_Paragon && Paragon.ChestChance > Utility.RandomDouble() )
					PackItem( new ParagonChest( this.Name, this.Title, treasureLevel, this ) );
				else if ( TreasureMap.LootChance >= Utility.RandomDouble() )
				{
					PackItem( new TreasureMap( treasureLevel, this.Map, this.Location, this.X, this.Y ) );
				}
			}

			if ( !Summoned && !NoKillAwards && !m_HasGeneratedLoot )
			{
				m_HasGeneratedLoot = true;
				GenerateLoot( false );
			}

			if ( IsAnimatedDead )
				Effects.SendLocationEffect( Location, Map, 0x3728, 13, 1, 0x461, 4 );

			InhumanSpeech speechType = this.SpeechType;

			if ( speechType != null )
				speechType.OnDeath( this );

			if ( m_ReceivedHonorContext != null )
				m_ReceivedHonorContext.OnTargetKilled();

			return base.OnBeforeDeath();
		}

		private bool m_NoKillAwards;

		public bool NoKillAwards
		{
			get{ return m_NoKillAwards; }
			set{ m_NoKillAwards = value; }
		}

		public int ComputeBonusDamage( List<DamageEntry> list, Mobile m )
		{
			int bonus = 0;

			for ( int i = list.Count - 1; i >= 0; --i )
			{
				DamageEntry de = list[i];

				if ( de.Damager == m || !(de.Damager is BaseCreature) )
					continue;

				BaseCreature bc = (BaseCreature)de.Damager;
				Mobile master = null;

				master = bc.GetMaster();

				if ( master == m )
					bonus += de.DamageGiven;
			}

			return bonus;
		}

		public Mobile GetMaster()
		{
			if ( Controlled && ControlMaster != null )
				return ControlMaster;
			else if ( Summoned && SummonMaster != null )
				return SummonMaster;

			return null;
		}

		private class FKEntry
		{
			public Mobile m_Mobile;
			public int m_Damage;

			public FKEntry( Mobile m, int damage )
			{
				m_Mobile = m;
				m_Damage = damage;
			}
		}

		public static List<DamageStore> GetLootingRights( List<DamageEntry> damageEntries, int hitsMax )
		{
			List<DamageStore> rights = new List<DamageStore>();

			for ( int i = damageEntries.Count - 1; i >= 0; --i )
			{
				if ( i >= damageEntries.Count )
					continue;

				DamageEntry de = damageEntries[i];

				if ( de.HasExpired )
				{
					damageEntries.RemoveAt( i );
					continue;
				}

				int damage = de.DamageGiven;

				List<DamageEntry> respList = de.Responsible;

				if ( respList != null )
				{
					for ( int j = 0; j < respList.Count; ++j )
					{
						DamageEntry subEntry = respList[j];
						Mobile master = subEntry.Damager;

						if ( master == null || master.Deleted || !master.Player )
							continue;

						bool needNewSubEntry = true;

						for ( int k = 0; needNewSubEntry && k < rights.Count; ++k )
						{
							DamageStore ds = rights[k];

							if ( ds.m_Mobile == master )
							{
								ds.m_Damage += subEntry.DamageGiven;
								needNewSubEntry = false;
							}
						}

						if ( needNewSubEntry )
							rights.Add( new DamageStore( master, subEntry.DamageGiven ) );

						damage -= subEntry.DamageGiven;
					}
				}

				Mobile m = de.Damager;

				if ( m == null || m.Deleted || !m.Player )
					continue;

				if ( damage <= 0 )
					continue;

				bool needNewEntry = true;

				for ( int j = 0; needNewEntry && j < rights.Count; ++j )
				{
					DamageStore ds = rights[j];

					if ( ds.m_Mobile == m )
					{
						ds.m_Damage += damage;
						needNewEntry = false;
					}
				}

				if ( needNewEntry )
					rights.Add( new DamageStore( m, damage ) );
			}

			if ( rights.Count > 0 )
			{
				rights[0].m_Damage = (int)(rights[0].m_Damage * 1.25);	//This would be the first valid person attacking it.  Gets a 25% bonus.  Per 1/19/07 Five on Friday

				if ( rights.Count > 1 )
					rights.Sort(); //Sort by damage

				int topDamage = rights[0].m_Damage;
				int minDamage;

				if ( hitsMax >= 3000 )
					minDamage = topDamage / 16;
				else if ( hitsMax >= 1000 )
					minDamage = topDamage / 8;
				else if ( hitsMax >= 200 )
					minDamage = topDamage / 4;
				else
					minDamage = topDamage / 2;

				for ( int i = 0; i < rights.Count; ++i )
				{
					DamageStore ds = rights[i];

					ds.m_HasRight = ( ds.m_Damage >= minDamage );
				}
			}

			return rights;
		}

		public virtual void OnKilledBy( Mobile mob )
		{
			if ( m_Paragon && Paragon.CheckArtifactChance( mob, this ) )
				Paragon.GiveArtifactTo( mob );
		}

		public override void OnDeath( Container c )
		{
			Mobile killer = this.LastKiller;

			QuestTake.DropChest( this );

			if (killer is BaseCreature)
			{
				BaseCreature bc_killer = (BaseCreature)killer;
				if(bc_killer.Summoned)
				{
					if(bc_killer.SummonMaster != null)
						killer = bc_killer.SummonMaster;
				}
				else if(bc_killer.Controlled)
				{
					if(bc_killer.ControlMaster != null)
						killer=bc_killer.ControlMaster;
				}
				else if(bc_killer.BardProvoked)
				{
					if(bc_killer.BardMaster != null)
						killer=bc_killer.BardMaster;
				}
			}

			if ( ( killer is PlayerMobile ) && (killer.AccessLevel < AccessLevel.GameMaster) )
			{
				LoggingFunctions.LogBattles( killer, this );
			}

			if ( killer is PlayerMobile )
			{
				AssassinFunctions.CheckTarget( killer, this );
				StandardQuestFunctions.CheckTarget( killer, this, null );
				FishingQuestFunctions.CheckTarget( killer, this, null );
				if ( killer.Backpack.FindItemByType( typeof ( MuseumBook ) ) != null && this.Fame >= 18000 )
				{
					MuseumBook.FoundItem( killer, 1 );
				}
				if ( killer.Backpack.FindItemByType( typeof ( QuestTome ) ) != null && this.Fame >= 18000 )
				{
					QuestTome.FoundItem( killer, 1, null );
				}
			}

			Server.Misc.DropRelic.DropSpecialItem( this, killer, c ); // SOME DROP RARE ITEMS

			if ( IsBonded )
			{
				int sound = this.GetDeathSound();

				if ( sound >= 0 )
					Effects.PlaySound( this, this.Map, sound );

				Warmode = false;

				Poison = null;
				Combatant = null;

				Hits = 0;
				Stam = 0;
				Mana = 0;

				IsDeadPet = true;
				ControlTarget = ControlMaster;
				ControlOrder = OrderType.Follow;

				ProcessDeltaQueue();
				SendIncomingPacket();
				SendIncomingPacket();

				List<AggressorInfo> aggressors = this.Aggressors;

				for ( int i = 0; i < aggressors.Count; ++i )
				{
					AggressorInfo info = aggressors[i];

					if ( info.Attacker.Combatant == this )
						info.Attacker.Combatant = null;
				}

				List<AggressorInfo> aggressed = this.Aggressed;

				for ( int i = 0; i < aggressed.Count; ++i )
				{
					AggressorInfo info = aggressed[i];

					if ( info.Defender.Combatant == this )
						info.Defender.Combatant = null;
				}

				Mobile owner = this.ControlMaster;

				if ( owner == null || owner.Deleted || owner.Map != this.Map || !owner.InRange( this, 12 ) || !this.CanSee( owner ) || !this.InLOS( owner ) )
				{
					if ( this.OwnerAbandonTime == DateTime.MinValue )
						this.OwnerAbandonTime = DateTime.Now;
				}
				else
				{
					this.OwnerAbandonTime = DateTime.MinValue;
				}

				CheckStatTimers();
			}
			else
			{
				if ( !Summoned && !m_NoKillAwards )
				{
					int totalFame = Fame / 100;
					int totalKarma = -Karma / 100;

					List<DamageStore> list = GetLootingRights( this.DamageEntries, this.HitsMax );
					List<Mobile> titles = new List<Mobile>();
					List<int> fame = new List<int>();
					List<int> karma = new List<int>();

					bool givenQuestKill = false;
					bool givenFactionKill = false;

					for ( int i = 0; i < list.Count; ++i )
					{
						DamageStore ds = list[i];

						if ( !ds.m_HasRight )
							continue;

						Party party = Engines.PartySystem.Party.Get( ds.m_Mobile );

						if ( party != null )
						{
							int divedFame = totalFame / party.Members.Count;
							int divedKarma = totalKarma / party.Members.Count;

							for ( int j = 0; j < party.Members.Count; ++j )
							{
								PartyMemberInfo info = party.Members[ j ] as PartyMemberInfo;

								if ( info != null && info.Mobile != null )
								{
									int index = titles.IndexOf( info.Mobile );

									if ( index == -1 )
									{
										titles.Add( info.Mobile );
										fame.Add( divedFame );
										karma.Add( divedKarma );
									}
									else
									{
										fame[ index ] += divedFame;
										karma[ index ] += divedKarma;
									}
								}
							}
						}
						else
						{
							titles.Add( ds.m_Mobile );
							fame.Add( totalFame );
							karma.Add( totalKarma );
						}

						OnKilledBy( ds.m_Mobile );

						if ( !givenFactionKill )
						{
							givenFactionKill = true;
							Faction.HandleDeath( this, ds.m_Mobile );
						}

						Region region = ds.m_Mobile.Region;

						if ( givenQuestKill )
							continue;

						PlayerMobile pm = ds.m_Mobile as PlayerMobile;

						if ( pm != null )
						{
							QuestSystem qs = pm.Quest;

							if ( qs != null )
							{
								qs.OnKill( this, c );
								givenQuestKill = true;
							}
						}
					}
					for ( int i = 0; i < titles.Count; ++i )
					{
						Titles.AwardFame( titles[ i ], fame[ i ], true );
						Titles.AwardKarma( titles[ i ], karma[ i ], true );
					}
				}

				base.OnDeath( c );

				if ( DeleteCorpseOnDeath || ( ( this.Name == "a follower" || this.Name == "a sailor" || this.Name == "a pirate" ) && this.EmoteHue > 0 ) )
					c.Delete();
			}
		}

		/* To save on cpu usage, RunUO creatures only reacquire creatures under the following circumstances:
		 *  - 10 seconds have elapsed since the last time it tried
		 *  - The creature was attacked
		 *  - Some creatures, like dragons, will reacquire when they see someone move
		 *
		 * This functionality appears to be implemented on OSI as well
		 */

		private DateTime m_NextReacquireTime;

		public DateTime NextReacquireTime{ get{ return m_NextReacquireTime; } set{ m_NextReacquireTime = value; } }

		public virtual TimeSpan ReacquireDelay{ get{ return TimeSpan.FromSeconds( 10.0 ); } }
		public virtual bool ReacquireOnMovement{ get{ return false; } }

		public void ForceReacquire()
		{
			m_NextReacquireTime = DateTime.MinValue;
		}

		public override void OnDelete()
		{
			Server.Mobiles.PremiumSpawner.ActivateSpawner( this );

			Mobile m = m_ControlMaster;

			SetControlMaster( null );
			SummonMaster = null;

			if ( m_ReceivedHonorContext != null )
				m_ReceivedHonorContext.Cancel();

			if ( this is HenchmanFamiliar )
			{
				ArrayList bagitems = new ArrayList(this.Backpack.Items);
				foreach (Item item in bagitems)
				{
					if ((item.Layer != Layer.Bank) && (item.Layer != Layer.Backpack) && (item.Layer != Layer.Hair) && (item.Layer != Layer.FacialHair) && (item.Layer != Layer.Mount))
					{
						item.MoveToWorld(this.Location, this.Map);
					}
				}
			}
			else if ( this is PackBeast )
			{
				ArrayList bagitems = new ArrayList(this.Backpack.Items);
				foreach (Item item in bagitems)
				{
					if ((item.Layer != Layer.Bank) && (item.Layer != Layer.Backpack) && (item.Layer != Layer.Hair) && (item.Layer != Layer.FacialHair) && (item.Layer != Layer.Mount))
					{
						item.MoveToWorld(this.Location, this.Map);
					}
				}
			}
			else if ( this is GolemPorter )
			{
				ArrayList bagitems = new ArrayList(this.Backpack.Items);
				foreach (Item item in bagitems)
				{
					if ((item.Layer != Layer.Bank) && (item.Layer != Layer.Backpack) && (item.Layer != Layer.Hair) && (item.Layer != Layer.FacialHair) && (item.Layer != Layer.Mount))
					{
						item.MoveToWorld(this.Location, this.Map);
					}
				}
			}
			else if ( this is FrankenFighter || this is FrankenPorter )
			{
				Server.Items.FrankenPorterItem.Stash( this );
			}
			else if ( this is AerialServant )
			{
				ArrayList bagitems = new ArrayList(this.Backpack.Items);
				foreach (Item item in bagitems)
				{
					if ((item.Layer != Layer.Bank) && (item.Layer != Layer.Backpack) && (item.Layer != Layer.Hair) && (item.Layer != Layer.FacialHair) && (item.Layer != Layer.Mount))
					{
						item.MoveToWorld(this.Location, this.Map);
					}
				}
			}

			if ( this.Mounted )
			{
				Mobiles.IMount mt = this.Mount;
				Mobile animal = (Mobile)mt;
				animal.Delete();
			}

			base.OnDelete();

			if ( m != null )
				m.InvalidateProperties();
		}

		public override bool CanBeHarmful( Mobile target, bool message, bool ignoreOurBlessedness )
		{
			if ( target is BaseFactionGuard )
				return false;

			if ( (target is BaseVendor && ((BaseVendor)target).IsInvulnerable) || target is PlayerVendor || target is PlayerBarkeeper )
			{
				if ( message )
				{
					if ( target.Title == null )
						SendMessage( "{0} the vendor cannot be harmed.", target.Name );
					else
						SendMessage( "{0} {1} cannot be harmed.", target.Name, target.Title );
				}

				return false;
			}

			return base.CanBeHarmful( target, message, ignoreOurBlessedness );
		}

		public override bool CanBeRenamedBy( Mobile from )
		{
			bool ret = base.CanBeRenamedBy( from );

			if ( Controlled && from == ControlMaster && !from.Region.IsPartOf( typeof( Jail ) ) )
				ret = true;

			return ret;
		}

		public bool SetControlMaster( Mobile m )
		{
			if ( m == null )
			{
				ControlMaster = null;
				Controlled = false;
				ControlTarget = null;
				ControlOrder = OrderType.None;
				Guild = null;

				Delta( MobileDelta.Noto );
			}
			else
			{
				ISpawner se = this.Spawner;
				if ( se != null && se.UnlinkOnTaming )
				{
					this.Spawner.Remove( this );
					this.Spawner = null;
				}

				if ( m.Followers + ControlSlots > m.FollowersMax )
				{
					m.SendLocalizedMessage( 1049607 ); // You have too many followers to control that creature.
					return false;
				}

				CurrentWayPoint = null;//so tamed animals don't try to go back

				ControlMaster = m;
				Controlled = true;
				ControlTarget = null;
				ControlOrder = OrderType.Come;
				Guild = null;

				if ( m_DeleteTimer != null )
				{
					m_DeleteTimer.Stop();
					m_DeleteTimer = null;
				}

				Delta( MobileDelta.Noto );
			}

			InvalidateProperties();

			return true;
		}

		public override void OnRegionChange( Region Old, Region New )
		{
			base.OnRegionChange( Old, New );

			if ( this.Controlled )
			{
				SpawnEntry se = this.Spawner as SpawnEntry;

				if ( se != null && !se.UnlinkOnTaming && ( New == null || !New.AcceptsSpawnsFrom( se.Region ) ) )
				{
					this.Spawner.Remove( this );
					this.Spawner = null;
				}
			}
		}

		private static bool m_Summoning;

		public static bool Summoning
		{
			get{ return m_Summoning; }
			set{ m_Summoning = value; }
		}

		public static bool Summon( BaseCreature creature, Mobile caster, Point3D p, int sound, TimeSpan duration )
		{
			return Summon( creature, true, caster, p, sound, duration );
		}

		public static bool isVortex( Mobile m )
		{
			if (
				m is ElementalFiendWater ||
				m is ElementalFiendFire ||
				m is ElementalFiendEarth ||
				m is ElementalFiendAir ||
				m is ElementalSpiritAir ||
				m is ElementalSpiritFire ||
				m is ElementalSpiritWater ||
				m is ElementalSpiritEarth ||
				m is BladeSpirits ||
				m is DevilPact ||
				m is SummonSnakes ||
				m is ElementalFiendWater ||
				m is GasCloud ||
				m is DeathVortex ||
				m is SummonedTreefellow ||
				m is EnergyVortex ||
				m is SummonSkeleton ||
				m is Swarm ||
				m is SummonDragon
			)
				return true;

			return false;
		}

		public static bool Summon( BaseCreature creature, bool controlled, Mobile caster, Point3D p, int sound, TimeSpan duration )
		{
			if ( caster.Followers + creature.ControlSlots > caster.FollowersMax )
			{
				caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				creature.Delete();
				return false;
			}

			m_Summoning = true;

			if ( controlled )
				creature.SetControlMaster( caster );

			creature.RangeHome = 10;
			creature.Summoned = true;

			creature.SummonMaster = caster;

			if (	creature is SummonedAirElemental ||
					creature is SummonedAirElementalGreater ||
					creature is SummonedDaemon ||
					creature is SummonedDaemonGreater ||
					creature is SummonedEarthElemental ||
					creature is SummonedEarthElementalGreater ||
					creature is SummonedFireElemental ||
					creature is SummonedFireElementalGreater ||
					creature is SummonedWaterElemental ||
					creature is SummonedWaterElementalGreater ||
					creature is ElementalCalledFire ||
					creature is ElementalCalledWater ||
					creature is ElementalCalledEarth ||
					creature is ElementalCalledAir ||
					creature is ElementalSummonIce ||
					creature is ElementalSummonMagma ||
					creature is ElementalSummonLightning ||
					creature is ElementalSummonEnt ||
					creature is ElementalLordWater ||
					creature is ElementalLordAir ||
					creature is ElementalLordEarth ||
					creature is ElementalLordFire ||
					creature is AncientFleshGolem ||
					creature is FleshGolem ||
					creature is BloodElemental ||
					creature is ElectricalElemental ||
					creature is GemElemental ||
					creature is IceElemental ||
					creature is MudElemental ||
					creature is PoisonElemental ||
					creature is WeedElemental ||
					creature is ToxicElemental ||
					creature is SummonedTreefellow ||
					creature is BoneKnight ||
					creature is Devil ||
					creature is BlackBear ||
					creature is BrownBear ||
					creature is DireWolf ||
					creature is WolfDire ||
					creature is Panther ||
					creature is Tiger ||
					creature is TigerRiding ||
					creature is TimberWolf ||
					creature is Scorpion ||
					creature is GiantSpider ||
					creature is HugeLizard ||
					creature is GiantToad ||
					creature is Slime )
			{
				creature.ControlOrder = OrderType.Guard;
			}

			Container pack = creature.Backpack;

			if ( pack != null )
			{
				for ( int i = pack.Items.Count - 1; i >= 0; --i )
				{
					if ( i >= pack.Items.Count )
						continue;

					pack.Items[i].Delete();
				}
			}

			new UnsummonTimer( caster, creature, duration ).Start();
			creature.m_SummonEnd = DateTime.Now + duration;

			creature.MoveToWorld( p, caster.Map );

			Effects.PlaySound( p, creature.Map, sound );

			m_Summoning = false;

			return true;
		}

		private static bool EnableRummaging = true;

		private const double ChanceToRummage = 0.5; // 50%

		private const double MinutesToNextRummageMin = 1.0;
		private const double MinutesToNextRummageMax = 4.0;

		private const double MinutesToNextChanceMin = 0.25;
		private const double MinutesToNextChanceMax = 0.75;

		private DateTime m_NextRummageTime;

		public virtual bool CanBreath { get { return HasBreath && !Summoned; } }
		public virtual bool IsDispellable { get { return ( Summoned || DispelDifficulty > 0 ) && !IsAnimatedDead; } }

		#region Healing
		public virtual bool CanHeal { get { return false; } }
		public virtual bool CanHealOwner { get { return false; } }
		public virtual double HealScalar { get { return 1.0; } }

		public virtual int HealSound { get { return 0x57; } }
		public virtual int HealStartRange { get { return 2; } }
		public virtual int HealEndRange { get { return RangePerception; } }
		public virtual double HealTrigger { get { return 0.78; } }
		public virtual double HealDelay { get { return 6.5; } }
		public virtual double HealInterval { get { return 0.0; } }
		public virtual bool HealFully { get { return true; } }
		public virtual double HealOwnerTrigger { get { return 0.78; } }
		public virtual double HealOwnerDelay { get { return 6.5; } }
		public virtual double HealOwnerInterval { get { return 30.0; } }
		public virtual bool HealOwnerFully { get { return false; } }

		private DateTime m_NextHealTime = DateTime.Now;
		private DateTime m_NextHealOwnerTime = DateTime.Now;
		private Timer m_HealTimer = null;

		public bool IsHealing { get { return ( m_HealTimer != null ); } }

		public virtual void HealStart( Mobile patient )
		{
			bool onSelf = ( patient == this );

			//DoBeneficial( patient );

			RevealingAction();

			if ( !onSelf )
			{
				patient.RevealingAction();
				patient.SendLocalizedMessage( 1008078, false, Name ); //  : Attempting to heal you.
			}

			double seconds = ( onSelf ? HealDelay : HealOwnerDelay ) + ( patient.Alive ? 0.0 : 5.0 );

			m_HealTimer = Timer.DelayCall( TimeSpan.FromSeconds( seconds ), new TimerStateCallback( Heal_Callback ), patient );
		}

		private void Heal_Callback( object state )
		{
			if ( state is Mobile )
				Heal( (Mobile)state );
		}

		public virtual void Heal( Mobile patient )
		{
			if ( !Alive || this.Map == Map.Internal || !CanBeBeneficial( patient, true, true ) || patient.Map != this.Map || !InRange( patient, HealEndRange ) )
			{
				StopHeal();
				return;
			}

			bool onSelf = ( patient == this );

			if ( !patient.Alive )
			{
			}
			else if ( patient.Poisoned )
			{
				int poisonLevel = patient.Poison.Level;

				double healing = Skills.Healing.Value;
				double anatomy = Skills.Anatomy.Value;
				double chance = ( healing - 30.0 ) / 50.0 - poisonLevel * 0.1;

				if ( ( healing >= 60.0 && anatomy >= 60.0 ) && chance > Utility.RandomDouble() )
				{
					if ( patient.CurePoison( this ) )
					{
						patient.SendLocalizedMessage( 1010059 ); // You have been cured of all poisons.

						CheckSkill( SkillName.Healing, 0.0, 60.0 + poisonLevel * 10.0 ); // TODO: Verify formula
						CheckSkill( SkillName.Anatomy, 0.0, 100.0 );
					}
				}
			}
			else if ( BleedAttack.IsBleeding( patient ) )
			{
				patient.SendLocalizedMessage( 1060167 ); // The bleeding wounds have healed, you are no longer bleeding!
				BleedAttack.EndBleed( patient, false );
			}
			else
			{
				double healing = Skills.Healing.Value;
				double anatomy = Skills.Anatomy.Value;
				double chance = ( healing + 10.0 ) / 100.0;

				if ( chance > Utility.RandomDouble() )
				{
					double min, max;

					min = ( anatomy / 10.0 ) + ( healing / 6.0 ) + 4.0;
					max = ( anatomy / 8.0 ) + ( healing / 3.0 ) + 4.0;

					if ( onSelf )
						max += 10;

					double toHeal = min + ( Utility.RandomDouble() * ( max - min ) );

					toHeal *= HealScalar;

					patient.Heal( (int)toHeal );

					CheckSkill( SkillName.Healing, 0.0, 90.0 );
					CheckSkill( SkillName.Anatomy, 0.0, 100.0 );
				}
			}

			HealEffect( patient );

			StopHeal();

			if ( ( onSelf && HealFully && Hits >= HealTrigger * HitsMax && Hits < HitsMax ) || ( !onSelf && HealOwnerFully && patient.Hits >= HealOwnerTrigger * patient.HitsMax && patient.Hits < patient.HitsMax ) )
				HealStart( patient );
		}

		public virtual void StopHeal()
		{
			if ( m_HealTimer != null )
				m_HealTimer.Stop();

			m_HealTimer = null;
		}

		public virtual void HealEffect( Mobile patient )
		{
			patient.PlaySound( HealSound );
		}

		#endregion

		public void NameColor()
		{
			if ( this is HenchmanMonster || this is HenchmanFighter || this is HenchmanWizard || this is HenchmanArcher )
			{
				NameHue = 1154;
			}
			else if ( this.Map == Map.IslesDread && ( this is WhiteTigerRiding || this is WhiteTiger || this is PolarBear || this is WhiteWolf || this is SnowLeopard || this is Mammoth || this is Boar || this is PandaRiding || this is Panda || this is Bull || this is Gorilla || this is Panther || this is GreyWolf ) )
			{
				NameHue = -1;
			}
			else if ( this.Map == Map.Lodor && this.Z > 10 && this.X >= 1975 && this.Y >= 2201 && this.X <= 2032 && this.Y <= 2247 ) // ZOO
			{
				NameHue = -1;
			}
			else if ( m_FightMode == FightMode.Closest && !( this is BasePerson || this is BaseVendor || (this.GetType()).IsAssignableFrom(typeof(PlayerVendor)) || this is PlayerBarkeeper ) )
			{
				NameHue = 0x22;
			}
			else if ( m_FightMode == FightMode.Evil )
			{
				NameHue = 0x92E;
			}

			if ( GetMaster() is PlayerMobile && NameHue > 0 && !( this is HenchmanMonster || this is HenchmanFighter || this is HenchmanWizard || this is HenchmanArcher ) ){ NameHue = -1; }
		}

		public virtual void OnThink()
		{
			if ( EmoteHue > 10000 )
			{
				bool keepMe = false;
				foreach ( Item i in GetItemsInRange( 20 ) )
				{
					if ( i is BaseBoat && i.Serial == EmoteHue )
						keepMe = true;
				}

				if ( !keepMe )
					this.Delete();
			}

			if ( ( Summoned || Controlled ) && SpawnerID > 0 )
				SpawnerID = 0;

			NameColor();

			if ( m_HitsBeforeMod > 0 && IsPet(this) )
			{
				SetHits( m_HitsBeforeMod );
				Hits = HitsMax;
				m_HitsBeforeMod = 0;
			}

			Mobile tamer = GetMaster(); // FOR INVULNERABLE POTIONS AND SEANCE SPELLS
			if ( tamer is PlayerMobile )
			{
				if ( tamer.Blessed )
				{
					Blessed = true;
				}
				else if ( !AlwaysInvulnerable( this ) && Blessed )
				{
					Blessed = false;
				}
			}
			if ( !Controlled && !AlwaysInvulnerable( this ) && Blessed )
			{
				Blessed = false;
			}

			if ( this is HenchmanMonster || this is HenchmanFighter || this is HenchmanWizard || this is HenchmanArcher || MyServerSettings.FastFriends( this ) )
			{
				Mobile leader = GetMaster();
				if ( leader != null )
				{
					if ( Server.Misc.MyServerSettings.NoMountsInCertainRegions() && Server.Mobiles.AnimalTrainer.IsNoMountRegion( leader, Region.Find( leader.Location, leader.Map ) ) )
					{
						Server.Misc.HenchmanFunctions.DismountHenchman( leader );
					}
					else if ( Region.Find( this.Location, this.Map ) is HouseRegion && MyServerSettings.NoMountsInHouses() )
					{
						Server.Misc.HenchmanFunctions.DismountHenchman( leader );
					}
					else if ( Server.Mobiles.AnimalTrainer.IsBeingFast( leader ) && this.ActiveSpeed >= 0.2 )
					{
						Server.Misc.HenchmanFunctions.MountHenchman( leader );
					}
					else if ( !Server.Mobiles.AnimalTrainer.IsBeingFast( leader ) && this.ActiveSpeed <= 0.1 )
					{
						Server.Misc.HenchmanFunctions.DismountHenchman( leader );
					}
				}
				else
				{
					Server.Misc.HenchmanFunctions.ForceSlow( this );
				}
			}

			if ( EnableRummaging && CanRummageCorpses && !Summoned && !Controlled && DateTime.Now >= m_NextRummageTime )
			{
				double min, max;

				if ( ChanceToRummage > Utility.RandomDouble() && Rummage() )
				{
					min = MinutesToNextRummageMin;
					max = MinutesToNextRummageMax;
				}
				else
				{
					min = MinutesToNextChanceMin;
					max = MinutesToNextChanceMax;
				}

				double delay = min + (Utility.RandomDouble() * (max - min));
				m_NextRummageTime = DateTime.Now + TimeSpan.FromMinutes( delay );
			}

			if ( CanBreath && DateTime.Now >= m_NextBreathTime ) // tested: controlled dragons do breath fire, what about summoned skeletal dragons?
			{
				Mobile target = this.Combatant;

				if( target != null && target.Alive && !target.IsDeadBondedPet && CanBeHarmful( target ) && target.Map == this.Map && !IsDeadBondedPet && target.InRange( this, BreathRange ) && InLOS( target ) && !BardPacified )
				{
					if( ( DateTime.Now - m_NextBreathTime ) < TimeSpan.FromSeconds( 30 ) )
					{
						BreathStart( target );
					}

					m_NextBreathTime = DateTime.Now + TimeSpan.FromSeconds( BreathMinDelay + ( Utility.RandomDouble() * BreathMaxDelay ) );
				}
			}

			if ( ( CanHeal || CanHealOwner ) && Alive && !IsHealing && !BardPacified )
			{
				Mobile owner = this.ControlMaster;

				if ( owner != null && CanHealOwner && DateTime.Now >= m_NextHealOwnerTime && CanBeBeneficial( owner, true, true ) && owner.Map == this.Map && InRange( owner, HealStartRange ) && InLOS( owner ) && owner.Hits < HealOwnerTrigger * owner.HitsMax )
				{
					HealStart( owner );

					m_NextHealOwnerTime = DateTime.Now + TimeSpan.FromSeconds( HealOwnerInterval );
				}
				else if ( CanHeal && DateTime.Now >= m_NextHealTime && CanBeBeneficial( this ) && ( Hits < HealTrigger * HitsMax || Poisoned ) )
				{
					HealStart( this );

					m_NextHealTime = DateTime.Now + TimeSpan.FromSeconds( HealInterval );
				}
			}

			if ( ( this is TownGuards || ( this is BaseVendor && this.WhisperHue != 999 && !((this.GetType()).IsAssignableFrom(typeof(PlayerVendor))) && !(this is PlayerBarkeeper) ) ) // GUARDS/MERCHANTS SHOULD MOVE BACK TO THEIR POST
				&&
				( Math.Abs( this.X-this.Home.X ) > 8 || Math.Abs( this.Y-this.Home.Y ) > 8 || Math.Abs( this.Z-this.Home.Z ) > 8 )
				&&
				Combatant == null )
			{
				this.Location = this.Home;
			}
			else if ( WhisperHue == 999 && CanSwim && !(CanOnlyMoveOnSea()) && !CantWalk && Combatant == null && !Hidden && !Server.Mobiles.BasePirate.IsSailor( this ) ) // DIVE UNDER WATER AND WAIT FOR VICTIM
			{
				bool dive = true;

				foreach ( NetState state in NetState.Instances )
				{
					Mobile m = state.Mobile;

					if ( m is PlayerMobile && m.InRange( this.Location, 20 ) && m.Alive && m.Map == this.Map )
					{
						if ( m.AccessLevel == AccessLevel.Player ){ dive = false; }
					}
				}

				if ( dive )
				{
					Point3D loc = Server.Misc.Worlds.GetBoatWater( this.X, this.Y, this.Map, 8 );

					if ( loc.X == 0 && loc.Y == 0 && loc.Z == 0 )
					{
						this.Location = this.Home;
						Effects.SendLocationParticles( EffectItem.Create( this.Location, this.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
						this.PlaySound( 0x1FE );
					}
					else
					{
						this.Location = loc;
						this.PlaySound( 0x026 );
						Effects.SendLocationEffect( this.Location, this.Map, 0x23B2, 16 );
					}

					this.Warmode = false;
					this.CantWalk = true;
					this.CanSwim = false;
					this.Hidden = true;
				}
			}
			else if ( Server.Misc.MyServerSettings.LineOfSight( this, false ) && Combatant == null && WhisperHue != 999 && WhisperHue != 666 ) // MOVE FROM PLAYER SIGHT WHEN NOT SEEN
			{
				bool seeing = true;

				foreach ( NetState state in NetState.Instances )
				{
					Mobile m = state.Mobile;

					if ( ( m is PlayerMobile || (m is BaseCreature && ((BaseCreature)m).Controlled) ) && !IsCitizen() && !Server.Misc.IntelligentAction.IsHiding( this ) && InLOS( m ) && m.Alive && m.Map == this.Map )
					{
						//if ( m.AccessLevel == AccessLevel.Player ){ seeing = false; }
						seeing = false;
					}
					else if ( ( m is PlayerMobile || (m is BaseCreature && ((BaseCreature)m).Controlled) ) && Hits > 30 && !IsCitizen() && Server.Misc.IntelligentAction.IsHiding( this ) && InLOS( m ) && m.Alive && m.Map == this.Map )
					{
						seeing = false;
					}
				}

				if ( seeing )
				{
					Warmode = false;
					CantWalk = true;
					Hidden = true;
				}
				else
				{
					CantWalk = m_NoWalker;
					Hidden = false;
				}
			}
			else if ( WhisperHue == 666 ) // ENTER A DEMON GATE
			{
				if ( !CantWalk && Combatant == null && !Hidden )
				{
					bool escape = true;

					foreach ( NetState state in NetState.Instances )
					{
						Mobile m = state.Mobile;

						if ( m is PlayerMobile && m.InRange( this.Location, 20 ) && m.Alive && m.Map == this.Map )
						{
							if ( m.AccessLevel == AccessLevel.Player ){ escape = false; }
						}
					}

					if ( escape )
					{
						Server.Items.DemonGate.MakeDemonGate( this );
						this.Location = this.Home;
						this.Warmode = false;
						this.CantWalk = true;
						this.Hidden = true;
					}
				}
				else if ( Hidden && CantWalk )
				{
					bool appear = false;

					foreach ( NetState state in NetState.Instances )
					{
						Mobile m = state.Mobile;

						if ( m is PlayerMobile && m.InRange( this.Location, 8 ) && m.Alive && m.Map == this.Map )
						{
							if ( m.AccessLevel == AccessLevel.Player ){ appear = true; }
						}
					}

					if ( appear )
					{
						this.Home = this.Location;
						Server.Items.DemonGate.MakeDemonGate( this );
						this.CantWalk = m_NoWalker;
						this.Hidden = false;
					}
				}
			}
		}

		public virtual bool Rummage()
		{
			Corpse toRummage = null;

			foreach ( Item item in this.GetItemsInRange( 2 ) )
			{
				if ( item is Corpse && item.Items.Count > 0 )
				{
					toRummage = (Corpse)item;
					break;
				}
			}

			if ( toRummage == null )
				return false;

			Container pack = this.Backpack;

			if ( pack == null )
				return false;

			List<Item> items = toRummage.Items;

			bool rejected;
			LRReason reason;

			for ( int i = 0; i < items.Count; ++i )
			{
				Item item = items[Utility.Random( items.Count )];

				Lift( item, item.Amount, out rejected, out reason );

				if ( !rejected && Drop( this, new Point3D( -1, -1, 0 ) ) )
				{
					// *rummages through a corpse and takes an item*
					PublicOverheadMessage( MessageType.Emote, 0x3B2, 1008086 );
					//TODO: Instancing of Rummaged stuff.
					return true;
				}
			}

			return false;
		}

		public void Pacify( Mobile master, DateTime endtime )
		{
			BardPacified = true;
			BardEndTime = endtime;
		}

		public override Mobile GetDamageMaster( Mobile damagee )
		{
			if ( m_bBardProvoked && damagee == m_bBardTarget )
				return m_bBardMaster;
			else if ( m_bControlled && m_ControlMaster != null )
				return m_ControlMaster;
			else if ( m_bSummoned && m_SummonMaster != null )
				return m_SummonMaster;

			return base.GetDamageMaster( damagee );
		}

		public void Provoke( Mobile master, Mobile target, bool bSuccess )
		{
			BardProvoked = true;

			if ( !Core.ML )
			{
				this.PublicOverheadMessage( MessageType.Emote, EmoteHue, false, "*looks furious*" );
			}

			if ( bSuccess )
			{
				PlaySound( GetIdleSound() );

				BardMaster = master;
				BardTarget = target;
				Combatant = target;
				BardEndTime = DateTime.Now + TimeSpan.FromSeconds( 30.0 );

				if ( target is BaseCreature )
				{
					BaseCreature t = (BaseCreature)target;

					if ( t.Unprovokable || (t.IsParagon && BaseInstrument.GetBaseDifficulty( t ) >= 160.0) )
						return;

					t.BardProvoked = true;

					t.BardMaster = master;
					t.BardTarget = this;
					t.Combatant = this;
					t.BardEndTime = DateTime.Now + TimeSpan.FromSeconds( 30.0 );
				}
			}
			else
			{
				PlaySound( GetAngerSound() );

				BardMaster = master;
				BardTarget = target;
			}
		}

		public bool FindMyName( string str, bool bWithAll )
		{
			int i, j;

			string name = this.Name;

			if( name == null || str.Length < name.Length )
				return false;

			string[] wordsString = str.Split(' ');
			string[] wordsName = name.Split(' ');

			for ( j=0 ; j < wordsName.Length; j++ )
			{
				string wordName = wordsName[j];

				bool bFound = false;
				for ( i=0 ; i < wordsString.Length; i++ )
				{
					string word = wordsString[i];

					if ( Insensitive.Equals( word, wordName ) )
						bFound = true;

					if ( bWithAll && Insensitive.Equals( word, "all" ) )
						return true;
				}

				if ( !bFound )
					return false;
			}

			return true;
		}

		public static void TeleportPets( Mobile master, Point3D loc, Map map )
		{
			TeleportPets( master, loc, map, false );
		}

		public static void TeleportPets( Mobile master, Point3D loc, Map map, bool onlyBonded )
		{
			List<Mobile> move = new List<Mobile>();

			foreach ( Mobile m in master.GetMobilesInRange( 10 ) )
			{
				if ( m is BaseCreature )
				{
					BaseCreature pet = (BaseCreature)m;

					if ( pet.Controlled && pet.ControlMaster == master )
					{
						if ( !onlyBonded || pet.IsBonded )
						{
							if ( pet.ControlOrder == OrderType.Guard || pet.ControlOrder == OrderType.Follow || pet.ControlOrder == OrderType.Come )
								move.Add( pet );
						}
						else if ( pet is HenchmanFamiliar || pet is AerialServant || pet is PackBeast || pet is Robot || pet is GolemPorter || pet is GolemFighter || pet is FrankenPorter || pet is FrankenFighter ){ move.Add( pet ); }
					}
				}
			}

			foreach ( Mobile m in move )
				m.MoveToWorld( loc, map );
		}

		public virtual void ResurrectPet()
		{
			if ( !IsDeadPet )
				return;

			OnBeforeResurrect();

			Poison = null;

			Warmode = false;

			Hits = 10;
			Stam = StamMax;
			Mana = 0;

			ProcessDeltaQueue();

			IsDeadPet = false;

			Effects.SendPacket( Location, Map, new BondedStatus( 0, this.Serial, 0 ) );

			this.SendIncomingPacket();
			this.SendIncomingPacket();

			OnAfterResurrect();

			Mobile owner = this.ControlMaster;

			if ( owner == null || owner.Deleted || owner.Map != this.Map || !owner.InRange( this, 12 ) || !this.CanSee( owner ) || !this.InLOS( owner ) )
			{
				if ( this.OwnerAbandonTime == DateTime.MinValue )
					this.OwnerAbandonTime = DateTime.Now;
			}
			else
			{
				this.OwnerAbandonTime = DateTime.MinValue;
			}

			CheckStatTimers();
		}

		public override bool CanBeDamaged()
		{
			if ( IsDeadPet )
				return false;

			return base.CanBeDamaged();
		}

		public virtual bool PlayerRangeSensitive{ get{ return (this.CurrentWayPoint == null); } }	//If they are following a waypoint, they'll continue to follow it even if players aren't around

		public override void OnSectorDeactivate()
		{
			if ( PlayerRangeSensitive && m_AI != null )
				m_AI.Deactivate();

			base.OnSectorDeactivate();
		}

		public override void OnSectorActivate()
		{
			if ( PlayerRangeSensitive && m_AI != null )
				m_AI.Activate();

			base.OnSectorActivate();
		}

		private bool m_RemoveIfUntamed;

		// used for deleting untamed creatures [in houses]
		private int m_RemoveStep;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool RemoveIfUntamed{ get{ return m_RemoveIfUntamed; } set{ m_RemoveIfUntamed = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int RemoveStep { get { return m_RemoveStep; } set { m_RemoveStep = value; } }
	}

	public class LoyaltyTimer : Timer
	{
		private static TimeSpan InternalDelay = TimeSpan.FromMinutes( 5.0 );

		public static void Initialize()
		{
			new LoyaltyTimer().Start();
		}

		public LoyaltyTimer() : base( InternalDelay, InternalDelay )
		{
			m_NextHourlyCheck = DateTime.Now + TimeSpan.FromHours( 1.0 );
			Priority = TimerPriority.FiveSeconds;
		}

		private DateTime m_NextHourlyCheck;

		protected override void OnTick()
		{
			if ( DateTime.Now >= m_NextHourlyCheck )
				m_NextHourlyCheck = DateTime.Now + TimeSpan.FromHours( 1.0 );
			else
				return;

			List<BaseCreature> toRelease = new List<BaseCreature>();

			// added array for wild creatures in house regions to be removed
			List<BaseCreature> toRemove = new List<BaseCreature>();

			foreach ( Mobile m in World.Mobiles.Values )
			{
				if ( m is BaseMount && ((BaseMount)m).Rider != null )
				{
					((BaseCreature)m).OwnerAbandonTime = DateTime.MinValue;
					continue;
				}

				if ( m is BaseCreature )
				{
					BaseCreature c = (BaseCreature)m;

					if ( c.IsDeadPet )
					{
						Mobile owner = c.ControlMaster;

						if ( owner == null || owner.Deleted || owner.Map != c.Map || !owner.InRange( c, 12 ) || !c.CanSee( owner ) || !c.InLOS( owner ) )
						{
							if ( c.OwnerAbandonTime == DateTime.MinValue )
								c.OwnerAbandonTime = DateTime.Now;
							else if ( (c.OwnerAbandonTime + c.BondingAbandonDelay) <= DateTime.Now )
								toRemove.Add( c );
						}
						else
						{
							c.OwnerAbandonTime = DateTime.MinValue;
						}
					}
					else if ( c.Controlled && c.Commandable )
					{
						c.OwnerAbandonTime = DateTime.MinValue;

						if ( c.Map != Map.Internal )
						{
							c.Loyalty -= (BaseCreature.MaxLoyalty / 10);

							if( c.Loyalty < (BaseCreature.MaxLoyalty / 10) )
							{
								c.Say( 1043270, c.Name ); // * ~1_NAME~ looks around desperately *
								c.PlaySound( c.GetIdleSound() );
							}

							if ( c.Loyalty <= 0 )
								toRelease.Add( c );
						}
					}

					if ( !c.Controlled && c.LastOwner != null && !c.IsStabled && c.CanBeDamaged() && c.Map != Map.Internal && !(c.Region is HouseRegion) )
					{
						c.RemoveStep++;

						if ( c.RemoveStep >= 1 )
							toRemove.Add( c );
					}
					else
					{
						c.RemoveStep = 0;
					}
				}
			}

			foreach ( BaseCreature c in toRelease )
			{
				c.Say( 1043255, c.Name ); // ~1_NAME~ appears to have decided that is better off without a master!
				c.Loyalty = BaseCreature.MaxLoyalty; // Wonderfully Happy
				c.IsBonded = false;
				c.BondingBegin = DateTime.MinValue;
				c.OwnerAbandonTime = DateTime.MinValue;
				c.ControlTarget = null;
				//c.ControlOrder = OrderType.Release;
				c.AIObject.DoOrderRelease(); // this will prevent no release of creatures left alone with AI disabled (and consequent bug of Followers)
				c.DropBackpack();
			}

			// added code to handle removing of wild creatures in house regions
			foreach ( BaseCreature c in toRemove )
			{
				c.Delete();
			}
		}
	}
}
