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
public class WonderousDealer : BaseVendor
{
    public override bool IsActiveVendor {
        get { return false; }
    }
    private List <SBInfo> m_SBInfos = new List <SBInfo>();
    protected override List <SBInfo> SBInfos {
        get { return m_SBInfos; }
    }

    [Constructable]
    public WonderousDealer() : base("the wondrous sage")
    {
    }

    public override void InitSBInfo()
    {
    }

    public override void InitOutfit()
    {
        base.InitOutfit();

        if (Utility.RandomBool())
        {
            switch (Utility.RandomMinMax(0, 4))
            {
                case 1: AddItem(new Server.Items.GnarledStaff()); break;
                case 2: AddItem(new Server.Items.BlackStaff()); break;
                case 3: AddItem(new Server.Items.WildStaff()); break;
                case 4: AddItem(new Server.Items.QuarterStaff()); break;
            }
        }
    }

    public WonderousDealer(Serial serial) : base(serial)
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

    ///////////////////////////////////////////////////////////////////////////
    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
        base.GetContextMenuEntries(from, list);
        list.Add(new BuyGumpEntry(from, this));
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
                    mobile.SendGump(new SpeechGump(mobile, "Seeking Higher Knowledge", SpeechFunctions.SpeechText(m_Giver, m_Mobile, "Powerscroll")));
                }
            }
        }
    }

    ///////////////////////////////////////////////////////////////////////////
    public class BuyGumpEntry : ContextMenuEntry
    {
        private Mobile m_Mobile;
        private Mobile m_Giver;

        public BuyGumpEntry(Mobile from, Mobile giver) : base(6103, 3)
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
                if (!mobile.HasGump(typeof(PowerGump)))
                {
                    mobile.SendGump(new PowerGump("", m_Mobile, m_Giver));
                }
            }
        }
    }
}
}
