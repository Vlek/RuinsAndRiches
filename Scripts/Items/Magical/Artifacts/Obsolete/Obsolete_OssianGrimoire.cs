using System;

namespace Server.Items
{
	public class OssianGrimoire : NecromancerSpellbook, IIslesDreadDyable
	{
		[Constructable]
		public OssianGrimoire() : base()
		{
			Name = "Ossian Grimoire";
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 10.0 );
			Attributes.RegenMana = 1;
			Attributes.CastSpeed = 1;
		}

		public OssianGrimoire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}