using System;
using Server;

namespace Server.Items
{
	public class Artifact_ConansSword : GiftClaymore
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ConansSword()
		{
			Hue = 0x835;
			Name = "Blade of the Cimmerian";
			ItemID = 0x56B7;
			Attributes.BonusStr = 10;
			SkillBonuses.SetValues( 0, SkillName.Swords, 20 );
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.AttackChance = 10;
            Slayer = SlayerName.Exorcism;
			Server.Misc.Arty.ArtySetup( this, 6, "Conan's Lost Sword " );
		}

		public Artifact_ConansSword( Serial serial ) : base( serial )
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
