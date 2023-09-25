﻿using System;

namespace Server.Items
{
	public class Artifact_HydrosLexicon : MyElementalSpellbook, IIslesDreadDyable
	{
		[Constructable]
		public Artifact_HydrosLexicon() : base()
		{
			ItemID = 0x6420;
			Name = "Lexicon of the Lurker";
			Attributes.RegenMana = Utility.RandomMinMax( 1, 5 );
			Attributes.CastSpeed = Utility.RandomMinMax( 1, 5 );
			Attributes.SpellDamage = 10;
            Slayer = SlayerName.FlameDousing;

			switch( Utility.RandomMinMax( 0, 6 ) )
			{
				case 0: this.Content = 0xFFFFFFFF; break;
				case 1: this.Content = 0xFFFFFFF; break;
				case 2: this.Content = 0xFFFFFF; break;
				case 3: this.Content = 0xFFFFFF; break;
				case 4: this.Content = 0xFFFF; break;
				case 5: this.Content = 0xFFFF; break;
				case 6: this.Content = 0xFFFF; break;
			}

			Server.Misc.BookProperties.GetBookProperties( this, 10, 40 );

			SkillBonuses.SetValues( 0, SkillName.Elementalism, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 1, SkillName.MagicResist, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 2, SkillName.Focus, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
			SkillBonuses.SetValues( 3, SkillName.Meditation, ( 10.0 + (Utility.RandomMinMax(0,2)*5) ) );
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artifact");
            list.Add( 1049644, "Hydros' Book of Spells");
        }

		public Artifact_HydrosLexicon( Serial serial ) : base( serial )
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
