using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
public class Fisherman : BaseVendor
{
    private List <SBInfo> m_SBInfos = new List <SBInfo>();
    protected override List <SBInfo> SBInfos {
        get { return m_SBInfos; }
    }

    public override NpcGuild NpcGuild {
        get { return NpcGuild.FishermensGuild; }
    }

    [Constructable]
    public Fisherman() : base("the fisherman")
    {
        SetSkill(SkillName.Seafaring, 75.0, 98.0);
    }

    public override void InitSBInfo()
    {
        m_SBInfos.Add(new SBFisherman());
        m_SBInfos.Add(new SBSailor());
        m_SBInfos.Add(new SBHighSeas());
    }

    public override void InitOutfit()
    {
        base.InitOutfit();

        AddItem(new Server.Items.FishingPole());

        switch (Utility.RandomMinMax(1, 5))
        {
            case 1: AddItem(new WideBrimHat(Utility.RandomNeutralHue())); break;
            case 2: AddItem(new FloppyHat(Utility.RandomNeutralHue())); break;
            case 3: AddItem(new TallStrawHat()); break;
            case 4: AddItem(new SkullCap(Utility.RandomNeutralHue())); break;
            case 5: AddItem(new StrawHat()); break;
        }
    }

    public Fisherman(Serial serial) : base(serial)
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
