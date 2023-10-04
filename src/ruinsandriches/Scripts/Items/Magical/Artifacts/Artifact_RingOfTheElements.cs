using System;
using Server;

namespace Server.Items
{
	public class Artifact_RingOfTheElements : GiftGoldRing
	{
		[Constructable]
		public Artifact_RingOfTheElements()
		{
			Name = "Ring of the Elements";
			Hue = 0x4E9;
			ItemID = 0x4CF6;
			Attributes.Luck = 100;
			Resistances.Fire = 16;
			Resistances.Cold = 16;
			Resistances.Poison = 16;
			Resistances.Energy = 16;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

		public Artifact_RingOfTheElements( Serial serial ) : base( serial )
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
		}
	}
}