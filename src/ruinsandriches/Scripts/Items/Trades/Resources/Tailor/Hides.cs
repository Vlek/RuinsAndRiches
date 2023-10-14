using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
public abstract class BaseHides : Item, ICommodity, IScissorable
{
    private CraftResource m_Resource;

    [CommandProperty(AccessLevel.GameMaster)]
    public CraftResource Resource
    {
        get { return m_Resource; }
        set { m_Resource = value; InvalidateProperties(); }
    }

    int ICommodity.DescriptionNumber {
        get { return LabelNumber; }
    }
    bool ICommodity.IsDeedable {
        get { return true; }
    }

    public abstract BaseLeather GetLeather();

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)1);                    // version
        writer.Write((int)m_Resource);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
        m_Resource = (CraftResource)reader.ReadInt();
        Name       = Server.Misc.MaterialInfo.GetResourceName(m_Resource) + "hide";
    }

    public BaseHides(CraftResource resource) : this(resource, 1)
    {
    }

    public BaseHides(CraftResource resource, int amount) : base(0x1079)
    {
        Stackable = true;
        Weight    = 5.0;
        Amount    = amount;
        Hue       = CraftResources.GetHue(resource);

        m_Resource = resource;
        Name       = Server.Misc.MaterialInfo.GetResourceName(resource) + "hide";
    }

    public BaseHides(Serial serial) : base(serial)
    {
    }

    public override int LabelNumber
    {
        get
        {
            if (m_Resource >= CraftResource.SpinedLeather && m_Resource <= CraftResource.BarbedLeather)
            {
                return 1049687 + (int)(m_Resource - CraftResource.SpinedLeather);
            }

            if (m_Resource == CraftResource.DinosaurLeather)
            {
                return 1036112;
            }

            return 1047023;
        }
    }

    public bool Scissor(Mobile from, Scissors scissors)
    {
        if (Deleted || !from.CanSee(this))
        {
            return false;
        }

        if (!from.InRange(this.GetWorldLocation(), 2))
        {
            from.SendLocalizedMessage(500447); // That is not accessible.
            return false;
        }

        base.ScissorHelper(from, GetLeather(), 1);
        return true;
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class Hides : BaseHides
{
    [Constructable]
    public Hides() : this(1)
    {
    }

    [Constructable]
    public Hides(int amount) : base(CraftResource.RegularLeather, amount)
    {
    }

    public Hides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new Leather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class SpinedHides : BaseHides
{
    [Constructable]
    public SpinedHides() : this(1)
    {
    }

    [Constructable]
    public SpinedHides(int amount) : base(CraftResource.SpinedLeather, amount)
    {
    }

    public SpinedHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new SpinedLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class HornedHides : BaseHides
{
    [Constructable]
    public HornedHides() : this(1)
    {
    }

    [Constructable]
    public HornedHides(int amount) : base(CraftResource.HornedLeather, amount)
    {
    }

    public HornedHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new HornedLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class BarbedHides : BaseHides
{
    [Constructable]
    public BarbedHides() : this(1)
    {
    }

    [Constructable]
    public BarbedHides(int amount) : base(CraftResource.BarbedLeather, amount)
    {
    }

    public BarbedHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new BarbedLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class NecroticHides : BaseHides
{
    [Constructable]
    public NecroticHides() : this(1)
    {
    }

    [Constructable]
    public NecroticHides(int amount) : base(CraftResource.NecroticLeather, amount)
    {
    }

    public NecroticHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new NecroticLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class VolcanicHides : BaseHides
{
    [Constructable]
    public VolcanicHides() : this(1)
    {
    }

    [Constructable]
    public VolcanicHides(int amount) : base(CraftResource.VolcanicLeather, amount)
    {
    }

    public VolcanicHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new VolcanicLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class FrozenHides : BaseHides
{
    [Constructable]
    public FrozenHides() : this(1)
    {
    }

    [Constructable]
    public FrozenHides(int amount) : base(CraftResource.FrozenLeather, amount)
    {
    }

    public FrozenHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new FrozenLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class GoliathHides : BaseHides
{
    [Constructable]
    public GoliathHides() : this(1)
    {
    }

    [Constructable]
    public GoliathHides(int amount) : base(CraftResource.GoliathLeather, amount)
    {
    }

    public GoliathHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new GoliathLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class DraconicHides : BaseHides
{
    [Constructable]
    public DraconicHides() : this(1)
    {
    }

    [Constructable]
    public DraconicHides(int amount) : base(CraftResource.DraconicLeather, amount)
    {
    }

    public DraconicHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new DraconicLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class HellishHides : BaseHides
{
    [Constructable]
    public HellishHides() : this(1)
    {
    }

    [Constructable]
    public HellishHides(int amount) : base(CraftResource.HellishLeather, amount)
    {
    }

    public HellishHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new HellishLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class DinosaurHides : BaseHides
{
    [Constructable]
    public DinosaurHides() : this(1)
    {
    }

    [Constructable]
    public DinosaurHides(int amount) : base(CraftResource.DinosaurLeather, amount)
    {
    }

    public DinosaurHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new DinosaurLeather();
    }
}

[FlipableAttribute(0x1079, 0x1078)]
public class AlienHides : BaseHides
{
    [Constructable]
    public AlienHides() : this(1)
    {
    }

    [Constructable]
    public AlienHides(int amount) : base(CraftResource.AlienLeather, amount)
    {
    }

    public AlienHides(Serial serial) : base(serial)
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

    public override BaseLeather GetLeather()
    {
        return new AlienLeather();
    }
}
}
