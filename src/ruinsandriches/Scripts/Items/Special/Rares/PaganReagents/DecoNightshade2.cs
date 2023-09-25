using System;

namespace Server.Items
{
	public class DecoNightshade2 : Item
	{

		[Constructable]
		public DecoNightshade2() : base( 0x18E5 )
		{
			Movable = true;
			Stackable = false;
		}

		public DecoNightshade2( Serial serial ) : base( serial )
		{
		}

		public override bool OnDragLift( Mobile from )
		{
			from.SendMessage( "This cannot be used in alchemy, but it is rare and collectible." );
			return base.OnDragLift( from );
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
