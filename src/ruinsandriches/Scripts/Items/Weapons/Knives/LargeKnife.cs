using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
public class LargeKnife : BaseKnife
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.InfectiousStrike; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.Disarm; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.ConsecratedStrike; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.DoubleWhirlwindAttack; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.MagicProtection2; }
    }

    public override int AosStrengthReq {
        get { return 5; }
    }
    public override int AosMinDamage {
        get { return 9; }
    }
    public override int AosMaxDamage {
        get { return 11; }
    }
    public override float MlSpeed {
        get { return 2.25f; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 40; }
    }

    [Constructable]
    public LargeKnife() : base(0x2674)
    {
        Weight = 1.0;
        Layer  = Layer.OneHanded;
        Name   = "large knife";
    }

    public LargeKnife(Serial serial) : base(serial)
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
