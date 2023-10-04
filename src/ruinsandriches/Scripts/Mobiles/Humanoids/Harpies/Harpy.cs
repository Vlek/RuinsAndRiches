using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a harpy corpse" )]
	public class Harpy : BaseCreature
	{
		private DateTime m_NextPickup;

		[Constructable]
		public Harpy() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a harpy";
			Body = 30;
			BaseSoundID = 402;

			SetStr( 96, 120 );
			SetDex( 86, 110 );
			SetInt( 51, 75 );

			SetHits( 58, 72 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 28;
		}

		public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			base.OnCarve( from, corpse, with );

			if ( Utility.RandomMinMax( 1, 5 ) == 1 )
			{
				Item egg = new Eggs( Utility.RandomMinMax( 1, 8 ) );
				corpse.DropItem( egg );
			}

			Item leg1 = new RawChickenLeg();
				leg1.Name = "raw harpy leg";
			corpse.DropItem( leg1 );

			Item leg2 = new RawChickenLeg();
				leg2.Name = "raw harpy leg";
			corpse.DropItem( leg2 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override int GetAttackSound()
		{
			return 916;
		}

		public override int GetAngerSound()
		{
			return 916;
		}

		public override int GetDeathSound()
		{
			return 917;
		}

		public override int GetHurtSound()
		{
			return 919;
		}

		public override int GetIdleSound()
		{
			return 918;
		}

		public override void OnThink()
		{
			base.OnThink();
			if ( DateTime.Now < m_NextPickup )
				return;

			m_NextPickup = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 20 ) );

			Peace( Combatant );
		}

		private DateTime m_NextPeace;

		public void Peace( Mobile target )
		{
			if ( target == null || Deleted || !Alive || m_NextPeace > DateTime.Now || 0.1 < Utility.RandomDouble() )
				return;

			PlayerMobile p = target as PlayerMobile;

			if ( p != null && p.PeacedUntil < DateTime.Now && !p.Hidden && CanBeHarmful( p ) )
			{
				p.PeacedUntil = DateTime.Now + TimeSpan.FromSeconds( 20.0 );
				p.SendLocalizedMessage( 500616 ); // You hear lovely music, and forget to continue battling!
				p.FixedParticles( 0x376A, 1, 32, 0x15BD, EffectLayer.Waist );
				p.Combatant = null;

				PlaySound( 0x58C );
			}

			m_NextPeace = DateTime.Now + TimeSpan.FromSeconds( 10 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 4; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }

		public Harpy( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}