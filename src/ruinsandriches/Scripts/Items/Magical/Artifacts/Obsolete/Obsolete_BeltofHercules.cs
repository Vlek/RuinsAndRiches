using System;
using Server;

namespace Server.Items
{
	public class BeltofHercules : MagicBelt
	{
		[Constructable]
		public BeltofHercules()
		{
			Hue = 0xB54;
			ItemID = 0x2790;
			Name = "Belt of Hercules";
			Attributes.BonusStr = 30;
			SkillBonuses.SetValues( 0, SkillName.FistFighting, 50 );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public BeltofHercules( Serial serial ) : base( serial )
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
