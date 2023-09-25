using System;
using System.Collections;
using Server.Targeting;
using Server.Items;
using Server.Misc;
using Server.Engines.Harvest;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class FishingPole : BaseHarvestTool
	{
		public override HarvestSystem HarvestSystem{ get{ return Fishing.System; } }

		[Constructable]
		public FishingPole() : this( 50 )
		{
		}

		[Constructable]
		public FishingPole( int uses ) : base( uses, 0x0DC0 )
		{
			Name = "fishing pole";
			Layer = Layer.OneHanded;
			Weight = 8.0;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			if ( (int)PoleSkill( this ) > 0 ){ list.Add( 1070722, "+" + (int)PoleSkill( this ) + " Skill" ); }
		}

		public FishingPole( Serial serial ) : base( serial )
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

		public static void WoodType( FishingPole pole )
		{
			if ( pole.Hue == MaterialInfo.GetMaterialColor( "ash", "", 0 ) ){				pole.UsesRemaining = pole.UsesRemaining + 5;  pole.Name = "ash fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "cherry", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 10; pole.Name = "cherry fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "ebony", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 15; pole.Name = "ebony fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "golden oak", "", 0 ) ){	pole.UsesRemaining = pole.UsesRemaining + 20; pole.Name = "golden oak fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "hickory", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 25; pole.Name = "hickory fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "mahogany", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 30; pole.Name = "mahogany fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "driftwood", "", 0 ) ){	pole.UsesRemaining = pole.UsesRemaining + 35; pole.Name = "driftwood fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "oak", "", 0 ) ){			pole.UsesRemaining = pole.UsesRemaining + 40; pole.Name = "oak fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "pine", "", 0 ) ){			pole.UsesRemaining = pole.UsesRemaining + 45; pole.Name = "pine fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "ghostwood", "", 0 ) ){	pole.UsesRemaining = pole.UsesRemaining + 50; pole.Name = "ghostwood fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "rosewood", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 55; pole.Name = "rosewood fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "walnut", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 60; pole.Name = "walnut fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "petrified", "", 0 ) ){	pole.UsesRemaining = pole.UsesRemaining + 65; pole.Name = "petrified fishing pole"; }
			else if ( pole.Hue == MaterialInfo.GetMaterialColor( "elven", "", 0 ) ){		pole.UsesRemaining = pole.UsesRemaining + 70; pole.Name = "elven fishing pole"; }
		}

		public static void RandomPole( FishingPole pole )
		{
			switch ( Utility.Random( 20 ) )
			{
				case 1: pole.Hue = MaterialInfo.GetMaterialColor( "ash", "", 0 ); break;
				case 2: pole.Hue = MaterialInfo.GetMaterialColor( "cherry", "", 0 ); break;
				case 3: pole.Hue = MaterialInfo.GetMaterialColor( "ebony", "", 0 ); break;
				case 4: pole.Hue = MaterialInfo.GetMaterialColor( "golden oak", "", 0 ); break;
				case 5: pole.Hue = MaterialInfo.GetMaterialColor( "hickory", "", 0 ); break;
				case 6: pole.Hue = MaterialInfo.GetMaterialColor( "mahogany", "", 0 ); break;
				case 7: pole.Hue = MaterialInfo.GetMaterialColor( "driftwood", "", 0 ); break;
				case 8: pole.Hue = MaterialInfo.GetMaterialColor( "oak", "", 0 ); break;
				case 9: pole.Hue = MaterialInfo.GetMaterialColor( "pine", "", 0 ); break;
				case 10: pole.Hue = MaterialInfo.GetMaterialColor( "ghostwood", "", 0 ); break;
				case 11: pole.Hue = MaterialInfo.GetMaterialColor( "rosewood", "", 0 ); break;
				case 12: pole.Hue = MaterialInfo.GetMaterialColor( "walnut", "", 0 ); break;
				case 13: pole.Hue = MaterialInfo.GetMaterialColor( "petrified", "", 0 ); break;
				case 14: pole.Hue = MaterialInfo.GetMaterialColor( "elven", "", 0 ); break;
			}
			WoodType( pole );
		}

		public static double PoleSkill( Item pole )
		{
			double bonus = 0.0;

			if ( pole.Name == "ash fishing pole" ){ bonus = 3.0; }
			else if ( pole.Name == "cherry fishing pole" ){ bonus = 6.0; }
			else if ( pole.Name == "ebony fishing pole" ){ bonus = 9.0; }
			else if ( pole.Name == "golden oak fishing pole" ){ bonus = 12.0; }
			else if ( pole.Name == "hickory fishing pole" ){ bonus = 15.0; }
			else if ( pole.Name == "mahogany fishing pole" ){ bonus = 18.0; }
			else if ( pole.Name == "oak fishing pole" ){ bonus = 21.0; }
			else if ( pole.Name == "pine fishing pole" ){ bonus = 24.0; }
			else if ( pole.Name == "ghostwood fishing pole" ){ bonus = 27.0; }
			else if ( pole.Name == "rosewood fishing pole" ){ bonus = 30.0; }
			else if ( pole.Name == "walnut fishing pole" ){ bonus = 33.0; }
			else if ( pole.Name == "petrified fishing pole" ){ bonus = 36.0; }
			else if ( pole.Name == "driftwood fishing pole" ){ bonus = 39.0; }
			else if ( pole.Name == "elven fishing pole" ){ bonus = 42.0; }

			return bonus;
		}
	}
}
