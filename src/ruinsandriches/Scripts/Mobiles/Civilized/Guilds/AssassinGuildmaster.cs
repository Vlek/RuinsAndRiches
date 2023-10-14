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
public class AssassinGuildmaster : BaseGuildmaster
{
    public override NpcGuild NpcGuild {
        get { return NpcGuild.AssassinsGuild; }
    }

    [Constructable]
    public AssassinGuildmaster() : base("assassin")
    {
        SetSkill(SkillName.Searching, 75.0, 98.0);
        SetSkill(SkillName.Hiding, 65.0, 88.0);
        SetSkill(SkillName.Fencing, 75.0, 98.0);
        SetSkill(SkillName.Stealth, 85.0, 100.0);
        SetSkill(SkillName.Poisoning, 85.0, 100.0);
    }

    public override void InitSBInfo()
    {
        SBInfos.Add(new SBAssassin());
        SBInfos.Add(new SBBuyArtifacts());
    }

    public override void InitOutfit()
    {
        base.InitOutfit();

        switch (Utility.RandomMinMax(0, 3))
        {
            case 0: AddItem(new Server.Items.ClothCowl(2411)); break;
            case 1: AddItem(new Server.Items.ClothHood(2411)); break;
            case 2: AddItem(new Server.Items.FancyHood(2411)); break;
            case 3: AddItem(new Server.Items.HoodedMantle(2411)); break;
        }

        AddItem(new Server.Items.Dagger());
    }

    ///////////////////////////////////////////////////////////////////////////
    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
        base.GetContextMenuEntries(from, list);
        if (Server.Misc.MyServerSettings.AllowBribes() >= 1000)
        {
            list.Add(new HireEntry(from, this));
        }
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
                Server.Misc.IntelligentAction.SayHey(m_Giver);
                mobile.SendGump(new SpeechGump(mobile, "Death and Taxes", SpeechFunctions.SpeechText(m_Giver, m_Mobile, "Assassin")));
            }
        }
    }

    private class HireEntry : ContextMenuEntry
    {
        private AssassinGuildmaster m_Giver;
        private Mobile m_From;

        public HireEntry(Mobile from, AssassinGuildmaster giver) : base(6120, 12)
        {
            m_From  = from;
            m_Giver = giver;
        }

        public override void OnClick()
        {
            if (!(m_From is PlayerMobile))
            {
                return;
            }

            m_Giver.Bribery(m_From);
        }
    }

    public void Bribery(Mobile from)
    {
        if (Deleted || !from.CheckAlive())
        {
            return;
        }

        PlayerMobile pm   = (PlayerMobile)from;
        int          cost = Server.Misc.MyServerSettings.AllowBribes();
        if (pm.NpcGuild == NpcGuild.AssassinsGuild)
        {
            cost = (int)(cost / 2);
        }
        Container packs = from.Backpack;
        bool      paid  = false;

        if (pm.Profession == 1)
        {
            SayTo(from, "You are a bit too famous in the land to pursuade the guards to forget your crimes.");
            paid = true;
        }
        else if (from.Kills < 1)
        {
            SayTo(from, "You are not guilty of any murders.");
            paid = true;
        }
        else if (packs.ConsumeTotal(typeof(Gold), cost))
        {
            SayTo(from, "I will use your " + cost.ToString() + " gold to pursuade the guards to look the other way.");
            from.SendMessage(String.Format("You pay {0} gold.", cost));
            from.Kills = from.Kills - 1;
            paid       = true;
        }
        else
        {
            Container cont = from.FindBankNoCreate();
            if (cont != null && cont.ConsumeTotal(typeof(Gold), cost))
            {
                SayTo(from, "I will use  " + cost.ToString() + " gold from your bank box to pursuade the guards to look the other way.");
                from.SendMessage(String.Format("You pay {0} gold from your bank box.", cost));
                from.Kills = from.Kills - 1;
                paid       = true;
            }
        }

        if (!paid)
        {
            SayTo(from, "I would require " + cost.ToString() + " gold to bribe the guards.");
        }
    }

    ///////////////////////////////////////////////////////////////////////////

    public AssassinGuildmaster(Serial serial) : base(serial)
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
