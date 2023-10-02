using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
[FlipableAttribute(0xF62, 0xF63)]
public class LevelTribalSpear : BaseLevelSpear
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.ArmorIgnore; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.ParalyzingBlow; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.ZapStamStrike; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.AchillesStrike; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.NerveStrike; }
    }

    public override int AosStrengthReq {
        get { return 50; }
    }
    public override int AosMinDamage {
        get { return 13; }
    }
    public override int AosMaxDamage {
        get { return 15; }
    }
    public override float MlSpeed {
        get { return 2.75f; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 80; }
    }

    public override int VirtualDamageBonus {
        get { return 25; }
    }

    public override string DefaultName
    {
        get { return "a tribal spear"; }
    }

    [Constructable]
    public LevelTribalSpear() : base(0xF62)
    {
        Weight = 7.0;
        Hue    = 837;
    }

    public LevelTribalSpear(Serial serial) : base(serial)
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
