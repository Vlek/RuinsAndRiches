using System;
using Server.Network;
using Server.Spells;
using Server.Spells.Elementalism;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
public class ElementalSpellbook : Spellbook
{
    public override int Hue {
        get { return 0; }
    }

    public Mobile EllyOwner;
    [CommandProperty(AccessLevel.GameMaster)]
    public Mobile Elly_Owner {
        get { return EllyOwner; } set { EllyOwner = value; }
    }

    public int EllyPage;
    [CommandProperty(AccessLevel.GameMaster)]
    public int Elly_Page {
        get { return EllyPage; } set { EllyPage = value; }
    }

    public override SpellbookType SpellbookType {
        get { return SpellbookType.Elementalism; }
    }
    public override int BookOffset {
        get { return 300; }
    }
    public override int BookCount {
        get { return 32; }
    }

    [Constructable]
    public ElementalSpellbook() : this((ulong)0)
    {
    }

    [Constructable]
    public ElementalSpellbook(ulong content) : base(content, 0x641F)
    {
        Layer  = Layer.Talisman;
        Name   = "elemental spellbook";
        ItemID = Utility.RandomList(0x641F, 0x6420, 0x6421, 0x6422);
    }

    public override bool OnDragLift(Mobile from)
    {
        SetupBook(from);
        return base.OnDragLift(from);
    }

    public override void OnDoubleClick(Mobile from)
    {
        SetupBook(from);
        Container pack = from.Backpack;

        if (!ElementalSpell.CanUseBook(this, from, true))
        {
            from.CloseGump(typeof(ElementalSpellbookGump));
            from.CloseGump(typeof(ElementalSpellHelp));
        }
        else if (Parent == from || (pack != null && Parent == pack))
        {
            from.SendSound(0x55);
            from.CloseGump(typeof(ElementalSpellbookGump));
            from.CloseGump(typeof(ElementalSpellHelp));
            from.SendGump(new ElementalSpellbookGump(from, this, 1));
        }
        else
        {
            from.SendLocalizedMessage(500207);                  // The spellbook must be in your backpack (and not in a container within) to open.
        }
    }

    public void SetupBook(Mobile from)
    {
        if (EllyOwner != from)
        {
            EllyOwner = from;
        }
        ElementalSpell.BookCover(this, ((PlayerMobile)from).CharacterElement);
    }

    public ElementalSpellbook(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)1);                   // version
        writer.Write((Mobile)EllyOwner);
        writer.Write((int)EllyPage);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
        EllyOwner = reader.ReadMobile();
        int EllyPage = reader.ReadInt();
    }
}
}
