using System;
using Server;

namespace Server.Items
{
public class LieutenantOfTheBritannianRoyalGuard : BodySash
{
    public override int InitMinHits {
        get { return 150; }
    }
    public override int InitMaxHits {
        get { return 150; }
    }

    public override bool CanFortify {
        get { return false; }
    }

    [Constructable]
    public LieutenantOfTheBritannianRoyalGuard()
    {
        Name = "Royal Guard Sash";
        Hue  = 0xe8;

        Attributes.BonusInt     = 5;
        Attributes.RegenMana    = 2;
        Attributes.LowerRegCost = 10;
    }

    public override void AddNameProperties(ObjectPropertyList list)
    {
        base.AddNameProperties(list);
        list.Add(1070722, "Artefact");
    }

    public LieutenantOfTheBritannianRoyalGuard(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)0);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();
    }
}
}
