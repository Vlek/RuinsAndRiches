using System;
using Server.Items;

namespace Server.Items
{
	public class RoyalArms : PlateArms
	{
		[Constructable]
		public RoyalArms()
		{
			ItemID = 0x2B0A;
			Name = "royal mantle";
			Weight = 5.0;
		}

		public RoyalArms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( Weight == 1.0 )
				Weight = 5.0;
		}
	}
}
