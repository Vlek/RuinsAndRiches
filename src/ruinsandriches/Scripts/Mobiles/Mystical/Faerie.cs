using System;
using Server;
using Server.Misc;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a faerie corpse" )]
	public class Faerie : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0xB71; } }
		public override int BreathEffectSound{ get{ return 0x655; } }
		public override int BreathEffectItemID{ get{ return 0x3039; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 52 ); }

		[Constructable]
		public Faerie() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "pixie" );
			Title = "the faerie";
			Body = 356;
			BaseSoundID = 0x467;

			SetStr( 21, 30 );
			SetDex( 301, 400 );
			SetInt( 201, 250 );

			SetHits( 13, 18 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 10.1, 20.0 );
			SetSkill( SkillName.FistFighting, 10.1, 12.5 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 100;
			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Gems, 2 );
		}

		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public Faerie( Serial serial ) : base( serial )
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
