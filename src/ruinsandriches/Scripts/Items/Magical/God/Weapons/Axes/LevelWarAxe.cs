using System;
using Server.Items;
using Server.Network;
using Server.Engines.Harvest;

namespace Server.Items
{
public class LevelWarAxe : BaseLevelAxe
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.ArmorIgnore; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.BleedAttack; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.DefenseMastery; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.StunningStrike; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.MeleeProtection2; }
    }

    public override int AosStrengthReq {
        get { return 35; }
    }
    public override int AosMinDamage {
        get { return 14; }
    }
    public override int AosMaxDamage {
        get { return 15; }
    }
    public override float MlSpeed {
        get { return 3.25f; }
    }

    public override int DefHitSound {
        get { return 0x233; }
    }
    public override int DefMissSound {
        get { return 0x239; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 80; }
    }

    public override SkillName DefSkill {
        get { return SkillName.Bludgeoning; }
    }
    public override WeaponType DefType {
        get { return WeaponType.Bashing; }
    }
    public override WeaponAnimation DefAnimation {
        get { return WeaponAnimation.Bash1H; }
    }

    public override HarvestSystem HarvestSystem {
        get { return null; }
    }

    [Constructable]
    public LevelWarAxe() : base(0x13B0)
    {
        Weight = 8.0;
        Name   = "war axe";
    }

    public LevelWarAxe(Serial serial) : base(serial)
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
