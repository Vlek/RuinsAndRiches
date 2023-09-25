using System;
using Server;

namespace Server.Items
{
	public class ConansLoinCloth : MagicBelt
	{
		[Constructable]
		public ConansLoinCloth()
		{
			Hue = 0x978;
			ItemID = 0x2B68;
			Name = "Loin Cloth of the Cimmerian";
			Attributes.BonusStr = 10;
			SkillBonuses.SetValues( 0, SkillName.Swords, 10 );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
            list.Add( 1049644, "Conan's Loin Cloth");
        }

		public ConansLoinCloth( Serial serial ) : base( serial )
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
