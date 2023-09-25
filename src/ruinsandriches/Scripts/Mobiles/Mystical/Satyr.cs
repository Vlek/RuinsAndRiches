using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "a satyr's corpse" )]
	public class Satyr : BaseCreature
	{
		private DateTime m_NextPickup;

		[Constructable]
		public Satyr() : base( AIType.AI_Animal, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a satyr";
			Body = 271;
			BaseSoundID = 0x586;

			SetStr( 177, 195 );
			SetDex( 251, 269 );
			SetInt( 153, 170 );

			SetHits( 150, 200 );

			SetDamage( 13, 24 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 60 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 55.0, 65.0 );
			SetSkill( SkillName.Tactics, 80.0, 100.0 );
			SetSkill( SkillName.FistFighting, 80.0, 100.0 );

			Fame = 5000;
			Karma = 5000;

			VirtualArmor = 28;

			SpeechHue = 0x5B8;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			switch( Utility.RandomMinMax( 0, 15 ) )
			{
				case 0:		c.DropItem( new ArmysPaeonScroll() ); break;
				case 1:		c.DropItem( new EnchantingEtudeScroll() ); break;
				case 2:		c.DropItem( new EnergyCarolScroll() ); break;
				case 3:		c.DropItem( new EnergyThrenodyScroll() ); break;
				case 4:		c.DropItem( new FireCarolScroll() ); break;
				case 5:		c.DropItem( new FireThrenodyScroll() ); break;
				case 6:		c.DropItem( new FoeRequiemScroll() ); break;
				case 7:		c.DropItem( new IceCarolScroll() ); break;
				case 8:		c.DropItem( new IceThrenodyScroll() ); break;
				case 9:		c.DropItem( new KnightsMinneScroll() ); break;
				case 10:	c.DropItem( new MagesBalladScroll() ); break;
				case 11:	c.DropItem( new MagicFinaleScroll() ); break;
				case 12:	c.DropItem( new PoisonCarolScroll() ); break;
				case 13:	c.DropItem( new PoisonThrenodyScroll() ); break;
				case 14:	c.DropItem( new SheepfoeMamboScroll() ); break;
				case 15:	c.DropItem( new SinewyEtudeScroll() ); break;
			}

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					if ( GetPlayerInfo.LuckyKiller( killer.Luck ) && Utility.RandomMinMax( 1, 4 ) == 1 )
					{
						Item item = new Pipes();
						item.Hue = 0xB95;
						item = Server.Misc.ContainerFunctions.LootMutate( killer, Server.LootPack.GetRegularLuckChance( killer ), item, c, 5 );
						item.Name = "satyr pipes";
						c.DropItem( item );
					}
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MlRich );
		}

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextPickup )
			{
				m_NextPickup = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 20 ) );

				switch( Utility.RandomMinMax( 0, 3 ) )
				{
					case 0:	Peace( Combatant ); break;
					case 1:	Undress( Combatant ); break;
					case 2:	Suppress( Combatant ); break;
					case 3:	Provoke( Combatant ); break;
				}
			}
			base.OnThink();
		}

		public override int Meat { get { return 1; } }

		public Satyr( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		// ------------------------------------------------------------------------------------------------------------------------------------------

		private DateTime m_NextPeace;
		public void Peace( Mobile target )
		{
			if ( target == null || Deleted || !Alive || m_NextPeace > DateTime.Now )
				return;

			PlayerMobile p = target as PlayerMobile;

			if ( p != null && p.PeacedUntil < DateTime.Now && !p.Hidden && CanBeHarmful( p ) )
			{
				p.PeacedUntil = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 20, 45 ) );
				p.SendLocalizedMessage( 500616 ); // You hear lovely music, and forget to continue battling!
				p.FixedParticles( 0x376A, 1, 32, 0x15BD, EffectLayer.Waist );
				p.Combatant = null;
				target.Warmode = false;
				UndressItem( target, Layer.OneHanded );
				UndressItem( target, Layer.TwoHanded );

				PlaySound( SpeechHue );
			}

			m_NextPeace = DateTime.Now + TimeSpan.FromSeconds( 50 );
		}

		// ------------------------------------------------------------------------------------------------------------------------------------------

		private static Dictionary<Mobile, Timer> m_Suppressed = new Dictionary<Mobile, Timer>();
		private DateTime m_NextSuppress;
		public void Suppress( Mobile target )
		{
			if ( target == null || m_Suppressed.ContainsKey( target ) || Deleted || !Alive || m_NextSuppress > DateTime.Now )
				return;

			TimeSpan delay = TimeSpan.FromSeconds( Utility.RandomMinMax( 20, 80 ) );

			if ( !target.Hidden && CanBeHarmful( target ) )
			{
				target.SendMessage("You hear jarring music, suppressing your abilities.");

				for ( int i = 0; i < target.Skills.Length; i++ )
				{
					Skill s = target.Skills[ i ];

					if ( s.Base > 0 ){ target.AddSkillMod( new TimedSkillMod( s.SkillName, true, s.Base * -0.28, delay ) ); }
				}

				int count = (int) Math.Round( delay.TotalSeconds / 1.25 );
				Timer timer = new AnimateTimer( target, count );
				m_Suppressed.Add( target, timer );
				timer.Start();

				PlaySound( SpeechHue );
			}

			m_NextSuppress = DateTime.Now + TimeSpan.FromSeconds( 90 );
		}

		public static void SuppressRemove( Mobile target )
		{
			if ( target != null && m_Suppressed.ContainsKey( target ) )
			{
				Timer timer = m_Suppressed[ target ];

				if ( timer != null || timer.Running )
					timer.Stop();

				m_Suppressed.Remove( target );
			}
		}

		private class AnimateTimer : Timer
		{
			private Mobile m_Owner;
			private int m_Count;

			public AnimateTimer( Mobile owner, int count ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 1.25 ) )
			{
				m_Owner = owner;
				m_Count = count;
			}

			protected override void OnTick()
			{
				if ( m_Owner.Deleted || !m_Owner.Alive || m_Count-- < 0 )
				{
					SuppressRemove( m_Owner );
				}
				else
					m_Owner.FixedParticles( 0x376A, 1, 32, 0x15BD, EffectLayer.Waist );
			}
		}

		// ------------------------------------------------------------------------------------------------------------------------------------------

		private DateTime m_NextUndress;
		public void Undress( Mobile target )
		{
			if ( target == null || Deleted || !Alive || m_NextUndress > DateTime.Now )
				return;

			if ( target.Player && target.Female && !target.Hidden && CanBeHarmful( target ) )
			{
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.OuterTorso ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.InnerTorso ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.MiddleTorso ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Pants ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Shirt ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Ring ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Helm ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Arms ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.OuterLegs ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Neck ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Gloves ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Talisman ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Shoes ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Cloak ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.InnerLegs ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Earrings ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Waist ); }
				if ( Utility.RandomBool() ){ UndressItem( target, Layer.Bracelet ); }

				target.SendMessage("The music is hypnotic, making you remove your worn items.");
				PlaySound( SpeechHue );
			}

			m_NextUndress = DateTime.Now + TimeSpan.FromSeconds( 20 );
		}

		public void UndressItem( Mobile m, Layer layer )
		{
			Item item = m.FindItemOnLayer( layer );

			if ( item != null && item.Movable )
				m.PlaceInBackpack( item );
		}

		// ------------------------------------------------------------------------------------------------------------------------------------------

		private DateTime m_NextProvoke;
		public void Provoke( Mobile target )
		{
			if ( target == null || Deleted || !Alive || m_NextProvoke > DateTime.Now )
				return;

			foreach ( Mobile m in GetMobilesInRange( RangePerception ) )
			{
				if ( m is BaseCreature )
				{
					BaseCreature c = (BaseCreature) m;

					if ( c == this || c == target || c.Unprovokable || c.IsParagon || c.BardProvoked || c.AccessLevel != AccessLevel.Player || !c.CanBeHarmful( target ) )
						continue;

					c.Provoke( this, target, true );

					if ( target.Player )
						target.SendLocalizedMessage( 1072062 ); // You hear angry music, and start to fight.

					PlaySound( SpeechHue );
					break;
				}
			}

			m_NextProvoke = DateTime.Now + TimeSpan.FromSeconds( 10 );
		}

		// ------------------------------------------------------------------------------------------------------------------------------------------
	}
}
