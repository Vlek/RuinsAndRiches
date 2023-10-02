using System;

namespace Server.Items
{
public class Artifact_CrimsonCincture : GiftHalfApron, IIslesDreadDyable
{
    [Constructable]
    public Artifact_CrimsonCincture() : base()
    {
        Hue  = 0x485;
        Name = "Crimson Cincture";
        Attributes.BonusDex  = 5;
        Attributes.BonusHits = 10;
        Attributes.RegenHits = 2;
        Server.Misc.Arty.ArtySetup(this, 5, "");
    }

    public Artifact_CrimsonCincture(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);                    // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
}
