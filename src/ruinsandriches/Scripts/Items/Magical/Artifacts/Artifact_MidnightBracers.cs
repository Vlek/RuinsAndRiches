using System;
using Server;

namespace Server.Items
{
	public class Artifact_MidnightBracers : GiftBoneArms
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }
		public override int BasePhysicalResistance{ get{ return 23; } }

		[Constructable]
		public Artifact_MidnightBracers()
		{
			Name = "Midnight Bracers";
			Hue = 0x455;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 20.0 );
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_MidnightBracers( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
				PhysicalBonus = 0;
		}
	}
}
