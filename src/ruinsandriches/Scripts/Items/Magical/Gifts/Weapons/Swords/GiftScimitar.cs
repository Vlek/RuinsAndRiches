using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
public class GiftScimitar : BaseGiftSword
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.DoubleStrike; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.ParalyzingBlow; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.MagicProtection2; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.ShadowInfectiousStrike; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.ZapStamStrike; }
    }

    public override int AosStrengthReq {
        get { return 25; }
    }
    public override int AosMinDamage {
        get { return 13; }
    }
    public override int AosMaxDamage {
        get { return 15; }
    }
    public override float MlSpeed {
        get { return 3.00f; }
    }

    public override int DefHitSound {
        get { return 0x23B; }
    }
    public override int DefMissSound {
        get { return 0x23A; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 90; }
    }

    [Constructable]
    public GiftScimitar() : base(0x13B6)
    {
        Weight = 5.0;
        Name   = "scimitar";
        ItemID = Utility.RandomList(0x13B6, 0x268F);
    }

    public GiftScimitar(Serial serial) : base(serial)
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
