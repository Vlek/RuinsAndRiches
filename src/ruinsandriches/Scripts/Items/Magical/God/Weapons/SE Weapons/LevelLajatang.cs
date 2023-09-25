using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
[FlipableAttribute(0x27A7, 0x27F2)]
public class LevelLajatang : BaseLevelKnife
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.DefenseMastery; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.FrenziedWhirlwind; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.DevastatingBlow; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.ForceOfNature; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.ZapManaStrike; }
    }

    public override int AosStrengthReq {
        get { return 65; }
    }
    public override int AosMinDamage {
        get { return 16; }
    }
    public override int AosMaxDamage {
        get { return 18; }
    }
    public override float MlSpeed {
        get { return 3.50f; }
    }

    public override int DefHitSound {
        get { return 0x232; }
    }
    public override int DefMissSound {
        get { return 0x238; }
    }

    public override int InitMinHits {
        get { return 90; }
    }
    public override int InitMaxHits {
        get { return 95; }
    }

    public override SkillName DefSkill {
        get { return SkillName.Fencing; }
    }
    public override WeaponType DefType {
        get { return WeaponType.Piercing; }
    }
    public override WeaponAnimation DefAnimation {
        get { return WeaponAnimation.Pierce1H; }
    }

    [Constructable]
    public LevelLajatang() : base(0x27A7)
    {
        Weight = 12.0;
        Layer  = Layer.TwoHanded;
    }

    public LevelLajatang(Serial serial) : base(serial)
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
