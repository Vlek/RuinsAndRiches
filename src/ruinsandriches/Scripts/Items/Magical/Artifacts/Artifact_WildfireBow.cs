using System;
using Server;

namespace Server.Items
{
	public class Artifact_WildfireBow : GiftElvenCompositeLongbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public Artifact_WildfireBow() : base()
		{
			Hue = 0x489;
			Name = "Wildfire Bow";
			ItemID = 0x2D1E;
			
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			WeaponAttributes.ResistFireBonus = 25;
			
			Velocity = 15;
			Server.Misc.Arty.ArtySetup( this, 5, "" );
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}

		public Artifact_WildfireBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}
