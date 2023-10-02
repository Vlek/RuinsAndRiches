using System;
using Server;

namespace Server.Items
{
public class GwennosHarp : LapHarp
{
    public override int InitMinUses {
        get { return 800; }
    }
    public override int InitMaxUses {
        get { return 800; }
    }

    [Constructable]
    public GwennosHarp()
    {
        int attributeCount = Utility.RandomMinMax(4, 7);
        int min            = Utility.RandomMinMax(5, 10);
        int max            = min + 15;
        BaseRunicTool.ApplyAttributesTo((BaseInstrument)this, attributeCount, min, max);

        Hue           = 0x9C4;
        Name          = "Gwenno's Harp";
        UsesRemaining = 800;
        Slayer        = SlayerName.Repond;
        Slayer2       = SlayerName.ReptilianDeath;
        SkillBonuses.SetValues(0, SkillName.Discordance, 10);
        SkillBonuses.SetValues(1, SkillName.Musicianship, 10);
        SkillBonuses.SetValues(2, SkillName.Peacemaking, 10);
        SkillBonuses.SetValues(3, SkillName.Provocation, 10);
    }

    public override void AddNameProperties(ObjectPropertyList list)
    {
        base.AddNameProperties(list);
        list.Add(1070722, "Artifact");
    }

    public GwennosHarp(Serial serial) : base(serial)
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
