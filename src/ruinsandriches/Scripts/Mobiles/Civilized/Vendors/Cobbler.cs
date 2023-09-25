using System;
using System.Collections.Generic;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
public class Cobbler : BaseVendor
{
    private List <SBInfo> m_SBInfos = new List <SBInfo>();
    protected override List <SBInfo> SBInfos {
        get { return m_SBInfos; }
    }

    [Constructable]
    public Cobbler() : base("the cobbler")
    {
        SetSkill(SkillName.Tailoring, 60.0, 83.0);
    }

    public override void InitSBInfo()
    {
        m_SBInfos.Add(new SBCobbler());

        m_SBInfos.Add(new RSLeatherMain());
        if (Worlds.IsCrypt(this.Location, this.Map))
        {
            m_SBInfos.Add(new RSLeatherDead());
        }
        if (Worlds.GetMyWorld(this.Map, this.Location, this.X, this.Y) == "the Savaged Empire")
        {
            m_SBInfos.Add(new RSLeatherDino());
        }
        if (Worlds.GetMyWorld(this.Map, this.Location, this.X, this.Y) == "the Underworld")
        {
            m_SBInfos.Add(new RSLeatherUnderworld());
        }
        if (Server.Misc.Worlds.IsSeaTown(this.Location, this.Map))
        {
            m_SBInfos.Add(new RSLeatherSea());
        }
    }

    public Cobbler(Serial serial) : base(serial)
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
