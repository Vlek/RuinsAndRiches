using System;
using Server;

namespace Server.Items
{
	public class Artifact_RobeofPyros : GiftRobe
	{
		[Constructable]
		public Artifact_RobeofPyros()
		{
			ItemID = 0x2B69;
			Name = "Robe of the Daemon King";
			Hue = 0x981;
			Resistances.Physical = 8;
			Resistances.Fire = 16;
			Attributes.CastRecovery = 1;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 20;
			Attributes.LowerRegCost = 20;
			Attributes.RegenStam = 4;
			SkillBonuses.SetValues(0, SkillName.Elementalism, 20);
			SkillBonuses.SetValues(1, SkillName.Focus, 15);
			SkillBonuses.SetValues(2, SkillName.Meditation, 15);
			Server.Misc.Arty.ArtySetup( this, 9, "Pyros' Vile Robe" );
		}

		public Artifact_RobeofPyros( Serial serial ) : base( serial )
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