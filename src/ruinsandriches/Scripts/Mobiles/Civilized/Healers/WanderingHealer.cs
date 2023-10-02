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
using Server.Regions;

namespace Server.Mobiles
{
public class WanderingHealer : BaseHealer
{
    public override bool CanTeach {
        get { return true; }
    }

    public override bool CheckTeach(SkillName skill, Mobile from)
    {
        if (!base.CheckTeach(skill, from))
        {
            return false;
        }

        return (skill == SkillName.Anatomy)
               || (skill == SkillName.Camping)
               || (skill == SkillName.Forensics)
               || (skill == SkillName.Healing)
               || (skill == SkillName.Spiritualism);
    }

    [Constructable]
    public WanderingHealer()
    {
        Title = "the wandering healer";

        SetSkill(SkillName.Camping, 80.0, 100.0);
        SetSkill(SkillName.Forensics, 80.0, 100.0);
        SetSkill(SkillName.Spiritualism, 80.0, 100.0);
    }

    public override void InitOutfit()
    {
        base.InitOutfit();

        switch (Utility.RandomMinMax(0, 4))
        {
            case 1: AddItem(new Server.Items.GnarledStaff()); break;
            case 2: AddItem(new Server.Items.BlackStaff()); break;
            case 3: AddItem(new Server.Items.WildStaff()); break;
            case 4: AddItem(new Server.Items.QuarterStaff()); break;
        }
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
                    mobile.SendGump(new SpeechGump(mobile, "Thou Art Going To Get Hurt", SpeechFunctions.SpeechText(m_Giver, m_Mobile, "Healer")));
                }
            }
        }
    }

    ///////////////////////////////////////////////////////////////////////////

    public WanderingHealer(Serial serial) : base(serial)
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
