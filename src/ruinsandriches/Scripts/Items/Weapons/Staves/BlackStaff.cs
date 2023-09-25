using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
public class BlackStaff : BaseStaff
{
    public override int Hue {
        get { return 0; }
    }

    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.MagicProtection; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.ElementalStrike; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.ArmorIgnore; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.MagicProtection2; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.LightningStriker; }
    }

    public override int AosStrengthReq {
        get { return 20; }
    }
    public override int AosMinDamage {
        get { return 13; }
    }
    public override int AosMaxDamage {
        get { return 16; }
    }
    public override float MlSpeed {
        get { return 2.75f; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 70; }
    }

    [Constructable]
    public BlackStaff() : base(0xDF0)
    {
        Weight   = 6.0;
        Resource = CraftResource.Iron;
        Name     = "wizard staff";
        ItemID   = Utility.RandomList(0xDF0, 0x0DF1, 0x2AAC, 0x63B1, 0x6522);
    }

    public BlackStaff(Serial serial) : base(serial)
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
