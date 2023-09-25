using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
public class GiftCompositeBow : BaseGiftRanged
{
    public override int EffectID {
        get { return ArrowType(1); }
    }
    public override Type AmmoType {
        get { return typeof(Arrow); }
    }
    public override Item Ammo {
        get { return new Arrow(); }
    }

    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.ArmorIgnore; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.MovingShot; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.DoubleShot; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.ZapDexStrike; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.ZapManaStrike; }
    }

    public override int AosStrengthReq {
        get { return 45; }
    }
    public override int AosMinDamage {
        get { return Core.ML ? 13 : 15; }
    }
    public override int AosMaxDamage {
        get { return 17; }
    }
    public override float MlSpeed {
        get { return 4.00f; }
    }

    public override int DefMaxRange {
        get { return 10; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 70; }
    }

    public override WeaponAnimation DefAnimation {
        get { return WeaponAnimation.ShootBow; }
    }

    [Constructable]
    public GiftCompositeBow() : base(0x26C2)
    {
        Weight   = 5.0;
        Resource = CraftResource.RegularWood;
        Layer    = Layer.TwoHanded;
        Name     = "composite bow";
        ItemID   = Utility.RandomList(0x26C2, 0x26CC, 0x2667, 0x2668, 0x63A6, 0x63A7);
    }

    public GiftCompositeBow(Serial serial) : base(serial)
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
