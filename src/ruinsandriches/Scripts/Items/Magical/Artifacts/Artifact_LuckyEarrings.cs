using System;
using Server;

namespace Server.Items
{
public class Artifact_LuckyEarrings : GiftGoldEarrings, IIslesDreadDyable
{
    [Constructable]
    public Artifact_LuckyEarrings()
    {
        Name = "Lucky Earrings";

        Hue = 0xAFF;

        Attributes.Luck = 150;

        Attributes.RegenMana = 3;

        Attributes.RegenStam = 3;

        Attributes.RegenHits = 3;

        Attributes.AttackChance = 5;

        Attributes.DefendChance = 5;

        Attributes.WeaponSpeed = 5;

        Server.Misc.Arty.ArtySetup(this, 7, "");
    }

    public Artifact_LuckyEarrings(Serial serial) : base(serial)
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
