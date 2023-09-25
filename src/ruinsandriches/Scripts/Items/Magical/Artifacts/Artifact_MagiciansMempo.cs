using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
public class Artifact_MagiciansMempo : GiftPlateMempo, IIslesDreadDyable
{
    public override int InitMinHits {
        get { return 80; }
    }
    public override int InitMaxHits {
        get { return 160; }
    }

    public override int BaseColdResistance {
        get { return 8; }
    }
    public override int BaseEnergyResistance {
        get { return 7; }
    }
    public override int BasePhysicalResistance {
        get { return 5; }
    }
    public override int BasePoisonResistance {
        get { return 6; }
    }
    public override int BaseFireResistance {
        get { return 10; }
    }

    [Constructable]
    public Artifact_MagiciansMempo()
    {
        Name = "Magician's Mempo";
        Hue  = 1151;
        ArmorAttributes.MageArmor = 1;
        Attributes.BonusInt       = 3;
        Attributes.BonusMana      = 10;
        Attributes.EnhancePotions = 25;
        Attributes.LowerManaCost  = 5;
        Attributes.LowerRegCost   = 15;
        Attributes.RegenMana      = 3;
        Attributes.SpellDamage    = 20;
        Server.Misc.Arty.ArtySetup(this, 10, "");
    }

    public Artifact_MagiciansMempo(Serial serial) : base(serial)
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
