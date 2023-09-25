using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
public class RunicHammer1 : BaseRunicTool
{
    public override CraftSystem CraftSystem {
        get { return DefBlacksmithy.CraftSystem; }
    }

    public override void AddNameProperties(ObjectPropertyList list)
    {
        base.AddNameProperties(list);

        int index = CraftResources.GetIndex(Resource);

        if (index >= 1 && index <= 8)
        {
            return;
        }

        if (!CraftResources.IsStandard(Resource))
        {
            int num = CraftResources.GetLocalizationNumber(Resource);

            if (num > 0)
            {
                list.Add(num);
            }
            else
            {
                list.Add(CraftResources.GetName(Resource));
            }
        }
    }

    [Constructable]
    public RunicHammer1(CraftResource resource) : base(resource, 0x5445)
    {
        Weight = 8.0;
        Hue    = CraftResources.GetHue(resource);
        Name   = "runic smithing tools";
    }

    [Constructable]
    public RunicHammer1(CraftResource resource, int uses) : base(resource, uses, 0x5445)
    {
        Weight = 8.0;
        Hue    = CraftResources.GetHue(resource);
        Name   = "runic smithing tools";
    }

    public RunicHammer1(Serial serial) : base(serial)
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

        ItemID = 0x5445;
        Name   = "runic smithing tools";
    }
}

public class BronzeHammer : RunicHammer1
{
    [Constructable]
    public BronzeHammer() : this(50)
    {
    }

    [Constructable]
    public BronzeHammer(int uses) : base(CraftResource.Bronze)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public BronzeHammer(Serial serial) : base(serial)
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

public class CopperHammer : RunicHammer1
{
    [Constructable]
    public CopperHammer() : this(50)
    {
    }

    [Constructable]
    public CopperHammer(int uses) : base(CraftResource.Copper)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public CopperHammer(Serial serial) : base(serial)
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

public class DullCopperHammer : RunicHammer1
{
    [Constructable]
    public DullCopperHammer() : this(50)
    {
    }

    [Constructable]
    public DullCopperHammer(int uses) : base(CraftResource.DullCopper)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public DullCopperHammer(Serial serial) : base(serial)
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

public class GoldHammer : RunicHammer1
{
    [Constructable]
    public GoldHammer() : this(50)
    {
    }

    [Constructable]
    public GoldHammer(int uses) : base(CraftResource.Gold)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public GoldHammer(Serial serial) : base(serial)
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

public class ShadowIronHammer : RunicHammer1
{
    [Constructable]
    public ShadowIronHammer() : this(50)
    {
    }

    [Constructable]
    public ShadowIronHammer(int uses) : base(CraftResource.ShadowIron)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public ShadowIronHammer(Serial serial) : base(serial)
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

public class ValoriteHammer : RunicHammer1
{
    [Constructable]
    public ValoriteHammer() : this(50)
    {
    }

    [Constructable]
    public ValoriteHammer(int uses) : base(CraftResource.Valorite)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public ValoriteHammer(Serial serial) : base(serial)
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

public class VeriteHammer : RunicHammer1
{
    [Constructable]
    public VeriteHammer() : this(50)
    {
    }

    [Constructable]
    public VeriteHammer(int uses) : base(CraftResource.Verite)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public VeriteHammer(Serial serial) : base(serial)
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

public class AgapiteHammer : RunicHammer1
{
    [Constructable]
    public AgapiteHammer() : this(50)
    {
    }

    [Constructable]
    public AgapiteHammer(int uses) : base(CraftResource.Agapite)
    {
        Weight        = 1.0;
        UsesRemaining = uses;
        Name          = "runic smithing tools";
    }

    public AgapiteHammer(Serial serial) : base(serial)
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
