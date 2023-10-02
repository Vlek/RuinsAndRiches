using System;
using Server;

namespace Server.Items
{
public class Artifact_ArmsOfNobility : GiftRingmailArms
{
    public override int InitMinHits {
        get { return 80; }
    }
    public override int InitMaxHits {
        get { return 160; }
    }

    public override int BasePhysicalResistance {
        get { return 20; }
    }
    public override int BasePoisonResistance {
        get { return 22; }
    }

    [Constructable]
    public Artifact_ArmsOfNobility()
    {
        Name = "Arms of Nobility";
        Hue  = 0x4FE;
        Attributes.BonusStr     = 8;
        Attributes.Luck         = 100;
        Attributes.WeaponDamage = 20;
        Server.Misc.Arty.ArtySetup(this, 8, "");
    }

    public Artifact_ArmsOfNobility(Serial serial) : base(serial)
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
