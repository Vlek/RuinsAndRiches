using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Artifact_TownGuardsHalberd : GiftHalberd, IIslesDreadDyable
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_TownGuardsHalberd()
		{
			Name = "Guardsman Halberd";
			Hue = 1407;
			ItemID = 0x143E;
			WeaponAttributes.HitLightning = 100;
			WeaponAttributes.HitLowerDefend = 40;
			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 25;
			Slayer = SlayerName.Repond ;
			Server.Misc.Arty.ArtySetup( this, 10, "" );
		}

		public Artifact_TownGuardsHalberd( Serial serial ) : base( serial )
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
