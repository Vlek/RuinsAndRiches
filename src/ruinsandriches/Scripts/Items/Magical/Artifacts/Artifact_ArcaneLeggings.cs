using System;
using Server;

namespace Server.Items
{
	public class Artifact_ArcaneLeggings : GiftLeatherLegs
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_ArcaneLeggings()
		{
			Name = "Arcane Leggings";
			Hue = 0x556;
			ItemID = 0x13cb;
			Attributes.NightSight = 1;
			Attributes.DefendChance = 14;
			Attributes.CastSpeed = 1;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 5;
			Attributes.SpellDamage = 5;
			Server.Misc.Arty.ArtySetup( this, 7, "" );
		}

		public Artifact_ArcaneLeggings( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
