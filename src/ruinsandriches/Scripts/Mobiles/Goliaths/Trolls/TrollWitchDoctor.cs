using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
[CorpseName("a troll corpse")]
public class TrollWitchDoctor : BaseCreature
{
    [Constructable]
    public TrollWitchDoctor() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
    {
        Name        = "a troll witch doctor";
        Body        = 156;
        BaseSoundID = 461;

        SetStr(176, 205);
        SetDex(46, 65);
        SetInt(150, 200);

        SetHits(106, 123);

        SetDamage(8, 14);

        SetDamageType(ResistanceType.Physical, 100);

        SetResistance(ResistanceType.Physical, 35, 45);
        SetResistance(ResistanceType.Fire, 25, 35);
        SetResistance(ResistanceType.Cold, 15, 25);
        SetResistance(ResistanceType.Poison, 5, 15);
        SetResistance(ResistanceType.Energy, 5, 15);

        SetSkill(SkillName.Psychology, 85.1, 100.0);
        SetSkill(SkillName.Magery, 85.1, 100.0);
        SetSkill(SkillName.MagicResist, 80.2, 110.0);
        SetSkill(SkillName.Tactics, 60.1, 80.0);
        SetSkill(SkillName.FistFighting, 40.1, 50.0);

        Fame  = 4000;
        Karma = -4000;

        VirtualArmor = 40;
    }

    public override void GenerateLoot()
    {
        AddLoot(LootPack.Rich);
        AddLoot(LootPack.LowScrolls);
    }

    public override bool CanRummageCorpses {
        get { return true; }
    }
    public override Poison PoisonImmune {
        get { return Poison.Regular; }
    }
    public override int TreasureMapLevel {
        get { return 3; }
    }
    public override int Meat {
        get { return 2; }
    }
    public override int Hides {
        get { return 18; }
    }
    public override HideType HideType {
        get { return HideType.Goliath; }
    }

    public TrollWitchDoctor(Serial serial) : base(serial)
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
