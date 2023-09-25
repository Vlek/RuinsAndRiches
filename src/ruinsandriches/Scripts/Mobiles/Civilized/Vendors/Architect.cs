using System;
using System.Collections.Generic;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
public class Architect : BaseVendor
{
    private List <SBInfo> m_SBInfos = new List <SBInfo>();
    protected override List <SBInfo> SBInfos {
        get { return m_SBInfos; }
    }

    public override NpcGuild NpcGuild {
        get { return NpcGuild.MerchantsGuild; }
    }

    [Constructable]
    public Architect() : base("the architect")
    {
    }

    public override void InitSBInfo()
    {
        if (!Core.AOS)
        {
            m_SBInfos.Add(new SBHouseDeed());
        }

        m_SBInfos.Add(new SBArchitect());
    }

    ///////////////////////////////////////////////////////////////////////////
    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
        base.GetContextMenuEntries(from, list);
        list.Add(new SpeechGumpEntry(from, this));
    }

    public class SpeechGumpEntry : ContextMenuEntry
    {
        private Mobile m_Mobile;
        private Mobile m_Giver;

        public SpeechGumpEntry(Mobile from, Mobile giver) : base(6146, 3)
        {
            m_Mobile = from;
            m_Giver  = giver;
        }

        public override void OnClick()
        {
            if (!(m_Mobile is PlayerMobile))
            {
                return;
            }

            PlayerMobile mobile = (PlayerMobile)m_Mobile;
            {
                if (!mobile.HasGump(typeof(SpeechGump)))
                {
                    Server.Misc.IntelligentAction.SayHey(m_Giver);
                    mobile.SendGump(new SpeechGump(mobile, "Better Homes And Gardens", SpeechFunctions.SpeechText(m_Giver, m_Mobile, "Architect")));
                }
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////

    public Architect(Serial serial) : base(serial)
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
