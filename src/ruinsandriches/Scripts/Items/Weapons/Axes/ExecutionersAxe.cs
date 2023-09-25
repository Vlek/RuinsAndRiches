using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class ExecutionersAxe : BaseAxe
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }
		public override WeaponAbility ThirdAbility{ get{ return WeaponAbility.ForceOfNature; } }
		public override WeaponAbility FourthAbility{ get{ return WeaponAbility.EarthStrike; } }
		public override WeaponAbility FifthAbility{ get{ return WeaponAbility.DeathBlow; } }

		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 17; } }
		public override float MlSpeed{ get{ return 3.25f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public ExecutionersAxe() : base( 0xF45 )
		{
			Weight = 8.0;
			Name = "great axe";
			ItemID = Utility.RandomList( 0xF45, 0x265A );
		}

		public ExecutionersAxe( Serial serial ) : base( serial )
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
