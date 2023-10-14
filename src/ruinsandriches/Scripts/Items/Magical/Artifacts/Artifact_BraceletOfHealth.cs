using System;
using Server;

namespace Server.Items
{
public class Artifact_BraceletOfHealth : GiftGoldBracelet
{
    [Constructable]
    public Artifact_BraceletOfHealth()
    {
        Name = "Bracelet of Health";
        Hue  = 0x21;
        Attributes.BonusHits = 25;
        Attributes.RegenHits = 10;
        ItemID = 0x4CEC;
        Server.Misc.Arty.ArtySetup(this, 6, "");
    }

    public Artifact_BraceletOfHealth(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
}
