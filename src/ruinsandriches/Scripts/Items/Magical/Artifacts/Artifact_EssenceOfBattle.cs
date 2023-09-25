using System;

namespace Server.Items
{
	public class Artifact_EssenceOfBattle : GiftGoldRing
	{
		[Constructable]
		public Artifact_EssenceOfBattle()
		{
			Name = "Essence of Battle";
			Hue = 0x550;
			ItemID = 0x4CF6;
			Attributes.BonusDex = 7;
			Attributes.BonusStr = 7;
			Attributes.WeaponDamage = 30;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public Artifact_EssenceOfBattle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}
