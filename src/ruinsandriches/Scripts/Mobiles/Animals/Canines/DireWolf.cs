using System;
using Server.Mobiles;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a dire wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class WolfDire : BaseMount
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public WolfDire() : this( "a dire wolf" )
		{
		}

		[Constructable]
		public WolfDire( string name ) : base( name, 277, 16017, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Hue = 0xB61;
			BaseSoundID = 0xE5;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 83.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 7; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 4 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public WolfDire(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}
