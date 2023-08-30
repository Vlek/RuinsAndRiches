using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a mastadon corpse" )]
	public class Mastadon : Elephant
	{
		[Constructable]
		public Mastadon()
		{
			Name = "a mastadon";
			Hue = 0xABF;

			SetStr( 326, 355 );
			SetDex( 81, 105 );
			SetInt( 16, 40 );

			SetHits( 276, 293 );

			SetDamage( 14, 20 );

			Fame = 3000;

			VirtualArmor = 35;

			ControlSlots = 2;
			MinTameSkill = 89.1;
		}

		public override FurType FurType{ get{ return FurType.Regular; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 16 ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay | FoodType.FruitsAndVegies; } }

		public Mastadon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}