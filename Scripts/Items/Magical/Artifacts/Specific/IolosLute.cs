using System;
using Server;

namespace Server.Items
{
	public class IolosLute : Lute
	{
		public override int InitMinUses{ get{ return 800; } }
		public override int InitMaxUses{ get{ return 800; } }

		[Constructable]
		public IolosLute()
		{
			int attributeCount = Utility.RandomMinMax(8,15);
			int min = Utility.RandomMinMax(15,25);
			int max = min + 40;
			BaseRunicTool.ApplyAttributesTo( (BaseInstrument)this, attributeCount, min, max );

			Name = "Iolo's Lute";
			UsesRemaining = 800;
			Hue = 0x9C4;
			Slayer = SlayerName.Silver;
			Slayer2 = SlayerName.Exorcism;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artifact");
        }

		public IolosLute( Serial serial ) : base( serial )
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