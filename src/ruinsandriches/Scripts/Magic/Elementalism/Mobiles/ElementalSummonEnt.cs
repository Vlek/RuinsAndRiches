using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
[CorpseName("a fallen tree")]
public class ElementalSummonEnt : BaseCreature
{
    public override double DispelDifficulty {
        get { return 117.5; }
    }
    public override double DispelFocus {
        get { return 45.0; }
    }
    public override bool DeleteCorpseOnDeath {
        get { return true; }
    }

    public override int BreathPhysicalDamage {
        get { return 100; }
    }
    public override int BreathFireDamage {
        get { return 0; }
    }
    public override int BreathColdDamage {
        get { return 0; }
    }
    public override int BreathPoisonDamage {
        get { return 0; }
    }
    public override int BreathEnergyDamage {
        get { return 0; }
    }
    public override int BreathEffectHue {
        get { return 0; }
    }
    public override int BreathEffectSound {
        get { return 0x65A; }
    }
    public override int BreathEffectItemID {
        get { return 0x707; }
    }                                                                          // LARGE LOG
    public override bool ReacquireOnMovement {
        get { return !Controlled; }
    }
    public override bool HasBreath {
        get { return true; }
    }
    public override double BreathEffectDelay {
        get { return 0.1; }
    }
    public override void BreathDealDamage(Mobile target, int form)
    {
        base.BreathDealDamage(target, 7);
    }

    [Constructable]
    public ElementalSummonEnt() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
    {
        Name        = "an ent";
        Body        = 309;
        BaseSoundID = 442;

        SetStr(200);
        SetDex(70);
        SetInt(70);

        SetHits(180);

        SetDamage(14, 21);

        SetDamageType(ResistanceType.Physical, 70);
        SetDamageType(ResistanceType.Poison, 30);

        SetResistance(ResistanceType.Physical, 65, 75);
        SetResistance(ResistanceType.Fire, 10, 20);
        SetResistance(ResistanceType.Cold, 40, 50);
        SetResistance(ResistanceType.Poison, 80, 90);
        SetResistance(ResistanceType.Energy, 40, 50);

        SetSkill(SkillName.MagicResist, 65.0);
        SetSkill(SkillName.Tactics, 100.0);
        SetSkill(SkillName.FistFighting, 90.0);

        VirtualArmor = 34;
        ControlSlots = 2;
    }

    public ElementalSummonEnt(Serial serial) : base(serial)
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
