using System;
using Server;

namespace Server.Items
{
public class Artifact_CapOfTheFallenKing : GiftLeatherCap
{
    public override int InitMinHits {
        get { return 80; }
    }
    public override int InitMaxHits {
        get { return 160; }
    }

    public override int BaseColdResistance {
        get { return 12; }
    }
    public override int BaseEnergyResistance {
        get { return 12; }
    }

    [Constructable]
    public Artifact_CapOfTheFallenKing()
    {
        Name = "Cap of the Fallen King";
        Hue  = 0x76D;
        Attributes.BonusStr  = 5;
        Attributes.RegenHits = 5;
        Attributes.RegenStam = 1;
        Server.Misc.Arty.ArtySetup(this, 7, "");
    }

    public Artifact_CapOfTheFallenKing(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)1);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
}
