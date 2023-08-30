using System;
using Server;
using Server.Engines.Harvest;

namespace Server.Items
{
	public class OreShovel : BaseHarvestTool
	{
		public override int Hue { get{ return 0x96D; } }
		public override HarvestSystem HarvestSystem{ get{ return Mining.System; } }

		[Constructable]
		public OreShovel() : this( 50 )
		{
		}

		[Constructable]
		public OreShovel( int uses ) : base( uses, 0xF3A )
		{
			Name = "ore spade";
			Weight = 5.0;
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "Digs Up Iron Ore Only" );
		}

		public OreShovel( Serial serial ) : base( serial )
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
	}
}