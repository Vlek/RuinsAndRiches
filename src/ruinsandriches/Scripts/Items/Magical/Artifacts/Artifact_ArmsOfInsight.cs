using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArmsOfInsight : GiftPlateArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public Artifact_ArmsOfInsight()
		{
			Name = "Arms of Insight";
			Hue = 0x554;
			ItemID = 0x1410;
			Attributes.BonusInt = 8;
			Attributes.BonusMana = 15;
			Attributes.RegenMana = 2;
			Attributes.LowerManaCost = 8;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_ArmsOfInsight( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
