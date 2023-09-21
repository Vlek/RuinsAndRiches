using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0xF49, 0xF4a )]
	public class Axe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.TalonStrike; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.ToxicStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.FrenziedWhirlwind; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 16; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 110; } }

		[Constructable]
		public Axe() : base( 0xF49 )
		{
			Weight = 4.0;
			Name = "axe";
			ItemID = Utility.RandomList( 0xF49, 0x2665 );
		}

		public Axe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
