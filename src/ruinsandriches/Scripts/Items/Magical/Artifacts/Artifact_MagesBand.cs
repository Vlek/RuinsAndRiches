using System;
using Server;

namespace Server.Items
{
    public class Artifact_MagesBand : GiftGoldRing, IIslesDreadDyable
    {
        [Constructable]
        public Artifact_MagesBand()
        {
            Name = "Mage's Band";
            Attributes.LowerRegCost = 15;
            Attributes.LowerManaCost = 5;
            Hue = 1170;
			ItemID = 0x4CF9;
            Attributes.CastRecovery = 3;
            Attributes.BonusMana = 15;
            Attributes.RegenMana = 5;
			Server.Misc.Arty.ArtySetup( this, 8, "" );
		}

        public Artifact_MagesBand( Serial serial )
            : base( serial )
        {
        }
        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }
        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
