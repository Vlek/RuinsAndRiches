using System;
using Server;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using System.Collections.Generic;

namespace Server.Mobiles
{
	public class Minstrel : BaseCreature
	{
		private DateTime m_NextPickup;

		[Constructable]
		public Minstrel() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 0: Title = "the bard"; break;
				case 1: Title = "the minstrel"; break;
				case 2: Title = "the troubadour"; break;
				case 3: Title = "the musician"; break;
				case 4: Title = "the balladeer"; break;
			}

			Hue = Utility.RandomSkinColor();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomColor(0) ) );
				Utility.AssignRandomHair( this );
				HairHue = Utility.RandomHairHue();
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomColor(0) ) );
				Utility.AssignRandomHair( this );
				int HairColor = Utility.RandomHairHue();
				FacialHairItemID = Utility.RandomList( 0, 8254, 8255, 8256, 8257, 8267, 8268, 8269 );
				HairHue = HairColor;
				FacialHairHue = HairColor;
			}

			SetStr( 86, 100 );
			SetDex( 81, 95 );
			SetInt( 61, 75 );

			SetDamage( 10, 23 );

			SetSkill( SkillName.Marksmanship, 80.1, 90.0 );
			SetSkill( SkillName.FistFighting, 66.0, 97.5 );
			SetSkill( SkillName.MagicResist, 25.0, 47.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );

			Fame = 2000;
			Karma = -2000;

			AddItem( new Boots( Utility.RandomNeutralHue() ) );
			AddItem( new FancyShirt( Utility.RandomColor(0) ));

			switch ( Utility.Random( 4 ))
			{
				case 0: AddItem( new FeatheredHat( Utility.RandomColor(0) ) ); break;
				case 1: AddItem( new FloppyHat( Utility.RandomColor(0) ) ); break;
				case 2: AddItem( new StrawHat( Utility.RandomColor(0) ) ); break;
				case 3: AddItem( new SkullCap( Utility.RandomColor(0) ) ); break;
			}

			switch ( Utility.Random( 2 ))
			{
				case 0: AddItem( new Crossbow() ); PackItem( new Bolt( Utility.RandomMinMax( 5, 15 ) ) ); break;
				case 1: AddItem( new Bow() ); PackItem( new Arrow( Utility.RandomMinMax( 5, 15 ) ) ); break;
			}

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new BambooFlute() );	SpeechHue = 0x504;	break;
				case 1: PackItem( new Drums() );		SpeechHue = 0x38;	break;
				case 2: PackItem( new Tambourine() );	SpeechHue = 0x52;	break;
				case 3: PackItem( new LapHarp() );		SpeechHue = 0x45;	break;
				case 4: PackItem( new Lute() );			SpeechHue = 0x4C;	break;
				case 5: PackItem( new Trumpet() );		SpeechHue = 0x3CE;	break;
			}

			Server.Misc.IntelligentAction.GiveAdventureGear( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
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
		}

		public override bool AlwaysAttackable{ get{ return true; } }
		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }

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

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );
			Server.Misc.IntelligentAction.CryOut( this );
		}

		public Minstrel( Serial serial ) : base( serial )
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
