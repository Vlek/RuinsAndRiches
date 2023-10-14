using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
public class BloodPactScroll : SpellScroll
{
    [Constructable]
    public BloodPactScroll() : this(1)
    {
    }

    [Constructable]
    public BloodPactScroll(int amount) : base(140, 0x282F, amount)
    {
        Name = "blood pact elixir";
        Hue  = 0x5B5;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public BloodPactScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class GhostlyImagesScroll : SpellScroll
{
    [Constructable]
    public GhostlyImagesScroll() : this(1)
    {
    }

    [Constructable]
    public GhostlyImagesScroll(int amount) : base(143, 0x282F, amount)
    {
        Name = "ghostly images draught";
        Hue  = 0xBF;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public GhostlyImagesScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class GhostPhaseScroll : SpellScroll
{
    [Constructable]
    public GhostPhaseScroll() : this(1)
    {
    }

    [Constructable]
    public GhostPhaseScroll(int amount) : base(144, 0x282F, amount)
    {
        Name = "ghost phase concoction";
        Hue  = 0x47E;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public GhostPhaseScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class GraveyardGatewayScroll : SpellScroll
{
    [Constructable]
    public GraveyardGatewayScroll() : this(1)
    {
    }

    [Constructable]
    public GraveyardGatewayScroll(int amount) : base(135, 0x282F, amount)
    {
        Name = "black gate draught";
        Hue  = 0x2EA;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public GraveyardGatewayScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class HellsBrandScroll : SpellScroll
{
    [Constructable]
    public HellsBrandScroll() : this(1)
    {
    }

    [Constructable]
    public HellsBrandScroll(int amount) : base(134, 0x282F, amount)
    {
        Name = "hellish branding ooze";
        Hue  = 0x54C;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public HellsBrandScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class HellsGateScroll : SpellScroll
{
    [Constructable]
    public HellsGateScroll() : this(1)
    {
    }

    [Constructable]
    public HellsGateScroll(int amount) : base(142, 0x282F, amount)
    {
        Name = "demonic fire ooze";
        Hue  = 0x54F;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public HellsGateScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class ManaLeechScroll : SpellScroll
{
    [Constructable]
    public ManaLeechScroll() : this(1)
    {
    }

    [Constructable]
    public ManaLeechScroll(int amount) : base(132, 0x282F, amount)
    {
        Name = "lich leech mixture";
        Hue  = 0xB87;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public ManaLeechScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class NecroCurePoisonScroll : SpellScroll
{
    [Constructable]
    public NecroCurePoisonScroll() : this(1)
    {
    }

    [Constructable]
    public NecroCurePoisonScroll(int amount) : base(133, 0x282F, amount)
    {
        Name = "disease curing concoction";
        Hue  = 0x8A2;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public NecroCurePoisonScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class NecroPoisonScroll : SpellScroll
{
    [Constructable]
    public NecroPoisonScroll() : this(1)
    {
    }

    [Constructable]
    public NecroPoisonScroll(int amount) : base(141, 0x282F, amount)
    {
        Name = "disease draught";
        Hue  = 0x4F8;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public NecroPoisonScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class NecroUnlockScroll : SpellScroll
{
    [Constructable]
    public NecroUnlockScroll() : this(1)
    {
    }

    [Constructable]
    public NecroUnlockScroll(int amount) : base(145, 0x282F, amount)
    {
        Name = "tomb raiding concoction";
        Hue  = 0x493;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public NecroUnlockScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class PhantasmScroll : SpellScroll
{
    [Constructable]
    public PhantasmScroll() : this(1)
    {
    }

    [Constructable]
    public PhantasmScroll(int amount) : base(146, 0x282F, amount)
    {
        Name = "phantasm elixir";
        Hue  = 0x6DE;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public PhantasmScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class RetchedAirScroll : SpellScroll
{
    [Constructable]
    public RetchedAirScroll() : this(1)
    {
    }

    [Constructable]
    public RetchedAirScroll(int amount) : base(136, 0x282F, amount)
    {
        Name = "retched air elixir";
        Hue  = 0xA97;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public RetchedAirScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class SpectreShadowScroll : SpellScroll
{
    [Constructable]
    public SpectreShadowScroll() : this(1)
    {
    }

    [Constructable]
    public SpectreShadowScroll(int amount) : base(131, 0x282F, amount)
    {
        Name = "spectre shadow elixir";
        Hue  = 0x17E;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public SpectreShadowScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class UndeadEyesScroll : SpellScroll
{
    [Constructable]
    public UndeadEyesScroll() : this(1)
    {
    }

    [Constructable]
    public UndeadEyesScroll(int amount) : base(137, 0x282F, amount)
    {
        Name = "eyes of the dead mixture";
        Hue  = 0x491;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public UndeadEyesScroll(Serial ser) : base(ser)
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
        ItemID = 0x282F;
    }
}

public class VampireGiftScroll : SpellScroll
{
    [Constructable]
    public VampireGiftScroll() : this(1)
    {
    }

    [Constructable]
    public VampireGiftScroll(int amount) : base(139, 0x282F, amount)
    {
        Name = "vampire blood draught";
        Hue  = 0xB85;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public VampireGiftScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}

public class WallOfSpikesScroll : SpellScroll
{
    [Constructable]
    public WallOfSpikesScroll() : this(1)
    {
    }

    [Constructable]
    public WallOfSpikesScroll(int amount) : base(138, 0x282F, amount)
    {
        Name = "wall of spikes draught";
        Hue  = 0xB8F;
    }

    public override void GetContextMenuEntries(Mobile from, List <ContextMenuEntry> list)
    {
    }

    public WallOfSpikesScroll(Serial serial) : base(serial)
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
        ItemID = 0x282F;
    }
}
}
