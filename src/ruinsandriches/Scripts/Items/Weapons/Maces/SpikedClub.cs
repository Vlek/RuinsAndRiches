using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
public class SpikedClub : BaseBashing
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.ConcussionBlow; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.Disarm; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.MeleeProtection; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.CrushingBlow; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.NerveStrike; }
    }

    public override int AosStrengthReq {
        get { return 45; }
    }
    public override int AosMinDamage {
        get { return 12; }
    }
    public override int AosMaxDamage {
        get { return 14; }
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

    public override WeaponAnimation DefAnimation {
        get { return WeaponAnimation.Bash1H; }
    }

    [Constructable]
    public SpikedClub() : base(0x2AB5)
    {
        Weight = 8.0;
        Layer  = Layer.OneHanded;
        Name   = "spiked club";
    }

    public SpikedClub(Serial serial) : base(serial)
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
