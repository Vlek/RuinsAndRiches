using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;

namespace Server.Mobiles
{
public class Rancher : BaseVendor
{
    private List <SBInfo> m_SBInfos = new List <SBInfo>();
    protected override List <SBInfo> SBInfos {
        get { return m_SBInfos; }
    }

    public override NpcGuild NpcGuild {
        get { return NpcGuild.DruidsGuild; }
    }

    [Constructable]
    public Rancher() : base("the rancher")
    {
        SetSkill(SkillName.Druidism, 55.0, 78.0);
        SetSkill(SkillName.Taming, 55.0, 78.0);
        SetSkill(SkillName.Herding, 64.0, 100.0);
        SetSkill(SkillName.Veterinary, 60.0, 83.0);
    }

    public override void InitSBInfo()
    {
        m_SBInfos.Add(new SBRancher());
    }

    public override void InitOutfit()
    {
        base.InitOutfit();

        if (Utility.RandomBool())
        {
            if (this.RawStr < 45)
            {
                this.RawStr = 50;
            }
            AddItem(new Server.Items.Pitchforks());
        }

        switch (Utility.RandomMinMax(1, 4))
        {
            case 1: AddItem(new TallStrawHat()); break;
            case 2: AddItem(new StrawHat()); break;
        }
    }

    public Rancher(Serial serial) : base(serial)
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
