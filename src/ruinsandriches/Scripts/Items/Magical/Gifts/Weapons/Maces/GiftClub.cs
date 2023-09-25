using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
public class GiftClub : BaseGiftBashing
{
    public override WeaponAbility PrimaryAbility {
        get { return WeaponAbility.ShadowStrike; }
    }
    public override WeaponAbility SecondaryAbility {
        get { return WeaponAbility.Dismount; }
    }
    public override WeaponAbility ThirdAbility {
        get { return WeaponAbility.StunningStrike; }
    }
    public override WeaponAbility FourthAbility {
        get { return WeaponAbility.SpinAttack; }
    }
    public override WeaponAbility FifthAbility {
        get { return WeaponAbility.DevastatingBlow; }
    }

    public override int AosStrengthReq {
        get { return 40; }
    }
    public override int AosMinDamage {
        get { return 11; }
    }
    public override int AosMaxDamage {
        get { return 13; }
    }
    public override float MlSpeed {
        get { return 2.50f; }
    }

    public override int InitMinHits {
        get { return 31; }
    }
    public override int InitMaxHits {
        get { return 40; }
    }

    [Constructable]
    public GiftClub() : base(0x13B4)
    {
        Weight   = 9.0;
        Resource = CraftResource.RegularWood;
        Name     = "club";
        ItemID   = Utility.RandomList(0x13b4, 0x13b3, 0x13b4, 0x13b3, 0x266B, 0x266C, 0x266D, 0x266E);
    }

    public GiftClub(Serial serial) : base(serial)
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
