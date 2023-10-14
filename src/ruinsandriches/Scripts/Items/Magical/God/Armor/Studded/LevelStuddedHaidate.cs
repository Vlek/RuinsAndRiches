using System;
using Server.Items;

namespace Server.Items
{
public class LevelStuddedHaidate : BaseLevelArmor
{
    public override int BasePhysicalResistance {
        get { return 2; }
    }
    public override int BaseFireResistance {
        get { return 4; }
    }
    public override int BaseColdResistance {
        get { return 3; }
    }
    public override int BasePoisonResistance {
        get { return 3; }
    }
    public override int BaseEnergyResistance {
        get { return 4; }
    }

    public override int InitMinHits {
        get { return 35; }
    }
    public override int InitMaxHits {
        get { return 45; }
    }

    public override int AosStrReq {
        get { return 30; }
    }
    public override int OldStrReq {
        get { return 30; }
    }

    public override int ArmorBase {
        get { return 3; }
    }

    public override ArmorMaterialType MaterialType {
        get { return ArmorMaterialType.Studded; }
    }
    public override CraftResource DefaultResource {
        get { return CraftResource.RegularLeather; }
    }

    [Constructable]
    public LevelStuddedHaidate() : base(0x278B)
    {
        Weight = 5.0;
    }

    public LevelStuddedHaidate(Serial serial) : base(serial)
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
