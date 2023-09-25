using System;
using Server;

namespace Server.Items
{
	public class ShaMontorrossbow : RepeatingCrossbow
	{
		public override int LabelNumber{ get{ return 1062915; } } // Shamino’s Best Crossbow

		[Constructable]
		public ShaMontorrossbow()
		{
			Hue = 0x504;
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 40;
			WeaponAttributes.SelfRepair = 10;
			WeaponAttributes.LowerStatReq = 100;
		}

		public ShaMontorrossbow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
