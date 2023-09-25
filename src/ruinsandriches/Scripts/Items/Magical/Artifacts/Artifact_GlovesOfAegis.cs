using System;
using Server;

namespace Server.Items
{
public class Artifact_GlovesOfAegis : GiftPlateGloves
{
    public override int InitMinHits {
        get { return 80; }
    }
    public override int InitMaxHits {
        get { return 160; }
    }

    public override int BasePhysicalResistance {
        get { return 8; }
    }

    [Constructable]
    public Artifact_GlovesOfAegis()
    {
        Name   = "Gloves of Aegis";
        Hue    = 0x47E;
        ItemID = 0x1414;
        ArmorAttributes.SelfRepair = 5;
        Attributes.ReflectPhysical = 10;
        Attributes.DefendChance    = 10;
        Attributes.LowerManaCost   = 4;
        Server.Misc.Arty.ArtySetup(this, 5, "");
    }

    public Artifact_GlovesOfAegis(Serial serial) : base(serial)
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
