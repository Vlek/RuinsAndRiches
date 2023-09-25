using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
[FlipableAttribute(0x13F8, 0x13F9)]
public class GnarledStaff : BaseStaff
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.ConcussionBlow; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.ParalyzingBlow; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.ConsecratedStrike; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.NerveStrike; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.Feint; }
    }

    public override int AosStrengthReq {
        get { return 20; }
    }
    public override int AosMinDamage {
        get { return 15; }
    }
    public override int AosMaxDamage {
        get { return 17; }
    }
    public override float MlSpeed {
        get { return 3.25f; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 50; }
    }

    [Constructable]
    public GnarledStaff() : base(0x13F8)
    {
        Weight   = 3.0;
        Resource = CraftResource.RegularWood;
    }

    public GnarledStaff(Serial serial) : base(serial)
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
