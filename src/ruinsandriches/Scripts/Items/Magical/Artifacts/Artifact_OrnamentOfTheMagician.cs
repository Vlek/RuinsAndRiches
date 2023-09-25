using System;
using Server;

namespace Server.Items
{
	public class Artifact_OrnamentOfTheMagician : GiftGoldBracelet
	{
		[Constructable]
		public Artifact_OrnamentOfTheMagician()
		{
			Name = "Ornament of the Magician";
			Hue = 0x554;
			ItemID = 0x4CF0;
			Attributes.CastRecovery = 3;
			Attributes.CastSpeed = 2;
			Attributes.LowerManaCost = 10;
			Attributes.LowerRegCost = 20;
			Resistances.Energy = 15;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_OrnamentOfTheMagician( Serial serial ) : base( serial )
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

			if ( Hue == 0x12B )
				Hue = 0x554;
		}
	}
}
