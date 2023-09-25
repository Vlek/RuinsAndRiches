using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
public class Scribe : BaseVendor
{
    private List <SBInfo> m_SBInfos = new List <SBInfo>();
    protected override List <SBInfo> SBInfos {
        get { return m_SBInfos; }
    }

    public override NpcGuild NpcGuild {
        get { return NpcGuild.LibrariansGuild; }
    }

    [Constructable]
    public Scribe() : base("the scribe")
    {
        SetSkill(SkillName.Psychology, 60.0, 83.0);
        SetSkill(SkillName.Inscribe, 90.0, 100.0);
        SetSkill(SkillName.Mercantile, 65.0, 88.0);
    }

    public override void InitSBInfo()
    {
        m_SBInfos.Add(new RSScrolls());
        m_SBInfos.Add(new SBScribe());
        m_SBInfos.Add(new SBBuyArtifacts());
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
                    mobile.SendGump(new SpeechGump(mobile, "The Written Word", SpeechFunctions.SpeechText(m_Giver, m_Mobile, "Scribe")));
                }
            }
        }
    }

    ///////////////////////////////////////////////////////////////////////////

    public override bool OnDragDrop(Mobile from, Item dropped)
    {
        if (dropped is Gold)
        {
            string sMessage = "";

            if (dropped.Amount == 500)
            {
                if (from.Skills[SkillName.Inscribe].Value >= 30)
                {
                    if (Server.Misc.Research.AlreadyHasBag(from))
                    {
                        this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Here. You already have a pack."));
                    }
                    else
                    {
                        ResearchBag bag = new ResearchBag();
                        from.PlaySound(0x2E6);
                        Server.Misc.Research.SetupBag(from, bag);
                        from.AddToBackpack(bag);
                        this.PublicOverheadMessage(MessageType.Regular, 0, false, string.Format("Good luck with your research."));
                        dropped.Delete();
                    }
                }
                else
                {
                    sMessage = "You need to be a neophyte scribe before I sell that to you.";
                    from.AddToBackpack(dropped);
                }
            }
            else
            {
                sMessage = "You look like you need this more than I do.";
                from.AddToBackpack(dropped);
            }

            this.PrivateOverheadMessage(MessageType.Regular, 1153, false, sMessage, from.NetState);
        }
        else if (dropped is SmallHollowBook)
        {
            dropped.ItemID = 0x56F9;
            from.PlaySound(0x249);
            from.AddToBackpack(dropped);
            this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have rebound your book.", from.NetState);
        }
        else if (dropped is LargeHollowBook)
        {
            dropped.ItemID = 0x5703;
            from.PlaySound(0x249);
            from.AddToBackpack(dropped);
            this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have rebound your book.", from.NetState);
        }
        else if (dropped is Runebook)
        {
            if (dropped.ItemID == 0x22C5)
            {
                dropped.ItemID = 0x0F3D;
            }
            else if (dropped.ItemID == 0x0F3D)
            {
                dropped.ItemID = 0x5687;
            }
            else if (dropped.ItemID == 0x5687)
            {
                dropped.ItemID = 0x4F50;
            }
            else if (dropped.ItemID == 0x4F50)
            {
                dropped.ItemID = 0x4F51;
            }
            else if (dropped.ItemID == 0x4F51)
            {
                dropped.ItemID = 0x5463;
            }
            else if (dropped.ItemID == 0x5463)
            {
                dropped.ItemID = 0x5464;
            }
            else
            {
                dropped.ItemID = 0x22C5;
            }

            from.PlaySound(0x249);
            from.AddToBackpack(dropped);
            this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "I have changed the cover of your book.", from.NetState);
        }

        return base.OnDragDrop(from, dropped);
    }

    ///////////////////////////////////////////////////////////////////////////

    private class FixEntry : ContextMenuEntry
    {
        private Scribe m_Scribe;
        private Mobile m_From;

        public FixEntry(Scribe Scribe, Mobile from) : base(6120, 12)
        {
            m_Scribe = Scribe;
            m_From   = from;
        }

        public override void OnClick()
        {
            m_Scribe.BeginRepair(m_From);
        }
    }

    public override void AddCustomContextEntries(Mobile from, List <ContextMenuEntry> list)
    {
        if (from.Alive && !from.Blessed)
        {
            list.Add(new FixEntry(this, from));
        }

        base.AddCustomContextEntries(from, list);
    }

    public void BeginRepair(Mobile from)
    {
        if (Deleted || !from.Alive)
        {
            return;
        }

        int nCost = 50;

        if (BeggingPose(from) > 0)                   // LET US SEE IF THEY ARE BEGGING
        {
            nCost = nCost - (int)((from.Skills[SkillName.Begging].Value * 0.005) * nCost); if (nCost < 1)
            {
                nCost = 1;
            }
            SayTo(from, "Since you are begging, do you still want me to identify an unknown scroll, it will only cost you  " + nCost.ToString() + " gold?");
        }
        else
        {
            SayTo(from, "If you want me to identify an unknown scroll, it will cost you  " + nCost.ToString() + " gold.");
        }

        from.Target = new RepairTarget(this);
    }

    private class RepairTarget : Target
    {
        private Scribe m_Scribe;

        public RepairTarget(Scribe mage) : base(12, false, TargetFlags.None)
        {
            m_Scribe = mage;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            int nCost = 50;

            if (BeggingPose(from) > 0)                       // LET US SEE IF THEY ARE BEGGING
            {
                nCost = nCost - (int)((from.Skills[SkillName.Begging].Value * 0.005) * nCost); if (nCost < 1)
                {
                    nCost = 1;
                }
            }

            if (targeted is UnknownScroll && from.Backpack != null)
            {
                Container pack      = from.Backpack;
                int       toConsume = nCost;

                if (pack.ConsumeTotal(typeof(Gold), toConsume))
                {
                    if (BeggingPose(from) > 0)
                    {
                        Titles.AwardKarma(from, -BeggingKarma(from), true);
                    }                                                                                                                   // DO ANY KARMA LOSS

                    from.SendMessage(String.Format("You pay {0} gold.", toConsume));

                    m_Scribe.PlaySound(0x249);
                    UnknownScroll rolls = (UnknownScroll)targeted;

                    ItemIdentification.IDScroll(from, rolls.ScrollType, rolls.ScrollLevel, m_Scribe);

                    rolls.Delete();
                }
                else
                {
                    m_Scribe.SayTo(from, "It would cost you {0} gold to have that identified.", toConsume);
                    from.SendMessage("You do not have enough gold.");
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            else if (targeted is ScrollClue)
            {
                Container packs = from.Backpack;
                nCost = 100;
                ScrollClue WhatIsIt = (ScrollClue)targeted;

                if (BeggingPose(from) > 0)                           // LET US SEE IF THEY ARE BEGGING
                {
                    nCost = nCost - (int)((from.Skills[SkillName.Begging].Value * 0.005) * nCost); if (nCost < 1)
                    {
                        nCost = 1;
                    }
                }
                int toConsume = nCost;

                if (WhatIsIt.ScrollIntelligence == 0)
                {
                    m_Scribe.SayTo(from, "That was already deciphered by someone.");
                }
                else if (packs.ConsumeTotal(typeof(Gold), toConsume))
                {
                    if (WhatIsIt.ScrollIntelligence >= 80)
                    {
                        WhatIsIt.Name = "diabolically coded parchment";
                    }
                    else if (WhatIsIt.ScrollIntelligence >= 70)
                    {
                        WhatIsIt.Name = "ingeniously coded parchment";
                    }
                    else if (WhatIsIt.ScrollIntelligence >= 60)
                    {
                        WhatIsIt.Name = "deviously coded parchment";
                    }
                    else if (WhatIsIt.ScrollIntelligence >= 50)
                    {
                        WhatIsIt.Name = "cleverly coded parchment";
                    }
                    else if (WhatIsIt.ScrollIntelligence >= 40)
                    {
                        WhatIsIt.Name = "adeptly coded parchment";
                    }
                    else if (WhatIsIt.ScrollIntelligence >= 30)
                    {
                        WhatIsIt.Name = "expertly coded parchment";
                    }
                    else
                    {
                        WhatIsIt.Name = "plainly coded parchment";
                    }

                    WhatIsIt.ScrollIntelligence = 0;
                    WhatIsIt.InvalidateProperties();
                    from.SendMessage(String.Format("You pay {0} gold.", toConsume));
                    m_Scribe.SayTo(from, "Let me show you what this reads...");
                    WhatIsIt.ScrollSolved = "Deciphered by " + m_Scribe.Name + " the Scribe";
                    from.PlaySound(0x249);
                    WhatIsIt.InvalidateProperties();
                }
                else
                {
                    m_Scribe.SayTo(from, "It would cost you {0} gold to have that deciphered.", toConsume);
                    from.SendMessage("You do not have enough gold.");
                }
            }
            else
            {
                m_Scribe.SayTo(from, "That does not need my services.");
            }
        }
    }

    public Scribe(Serial serial) : base(serial)
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
