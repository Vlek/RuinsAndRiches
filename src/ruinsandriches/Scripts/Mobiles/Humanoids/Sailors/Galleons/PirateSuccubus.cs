using System;
using Server;
using Server.Misc;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Targeting;
using Server.Multis;

namespace Server.Mobiles
{
public class PirateSuccubus : BasePirate
{
    [Constructable]
    public PirateSuccubus()
    {
        Name        = NameList.RandomName("goddess");
        Title       = "the succubus captain";
        Body        = Utility.RandomList(174, 689);
        BaseSoundID = 0x4B0;

        AI        = AIType.AI_Mage;
        FightMode = FightMode.Closest;
        if (Utility.RandomBool())
        {
            ship = new GalleonExotic();
        }
        else
        {
            ship = new GalleonRoyal();
        }
        ship.Hue = ShipColor("demon");

        SetStr(786, 985);
        SetDex(177, 255);
        SetInt(151, 250);

        SetHits(592, 711);

        SetDamage(22, 29);

        SetDamageType(ResistanceType.Physical, 50);
        SetDamageType(ResistanceType.Fire, 25);
        SetDamageType(ResistanceType.Energy, 25);

        SetResistance(ResistanceType.Physical, 65, 80);
        SetResistance(ResistanceType.Fire, 60, 80);
        SetResistance(ResistanceType.Cold, 50, 60);
        SetResistance(ResistanceType.Poison, 100);
        SetResistance(ResistanceType.Energy, 40, 50);

        SetSkill(SkillName.Anatomy, 25.1, 50.0);
        SetSkill(SkillName.Psychology, 90.1, 100.0);
        SetSkill(SkillName.Magery, 95.5, 100.0);
        SetSkill(SkillName.Meditation, 25.1, 50.0);
        SetSkill(SkillName.MagicResist, 100.5, 150.0);
        SetSkill(SkillName.Tactics, 90.1, 100.0);
        SetSkill(SkillName.FistFighting, 90.1, 100.0);

        Fame  = 20000;
        Karma = -20000;

        VirtualArmor = 90;
        healme       = "Heal me my slaves!";
    }

    public PirateSuccubus(Serial serial) : base(serial)
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

    public override int BreathPhysicalDamage {
        get { return 20; }
    }
    public override int BreathFireDamage {
        get { return 20; }
    }
    public override int BreathColdDamage {
        get { return 20; }
    }
    public override int BreathPoisonDamage {
        get { return 20; }
    }
    public override int BreathEnergyDamage {
        get { return 20; }
    }
    public override int BreathEffectHue {
        get { return 0x844; }
    }
    public override int BreathEffectSound {
        get { return 0x658; }
    }
    public override int BreathEffectItemID {
        get { return 0x37BC; }
    }
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
        base.BreathDealDamage(target, 24);
    }

    public override Poison PoisonImmune {
        get { return Poison.Deadly; }
    }
}
}
