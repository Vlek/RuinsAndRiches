
////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class TreasurePile3Addon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {6981, 3, -1, 1}, {6988, -2, 0, 1}, {6989, -2, -1, 1}// 1	2	3
			, {6995, 1, 1, 1}, {6996, 0, 3, 1}, {6998, -1, 3, 1}// 4	5	6
			, {7003, 1, 2, 1}, {7000, -1, 1, 1}, {7005, -1, 2, 1}// 7	8	9
			, {7001, 0, 0, 1}, {6984, 2, -1, 1}, {6980, -1, 0, 1}// 10	11	12
			, {6999, -2, 1, 1}, {7015, 0, -1, 1}, {6979, 0, 2, 1}// 13	14	15
			, {7002, 1, 0, 1}, {6993, -1, -1, 1}, {6998, 0, 1, 1}// 16	17	18
			, {7017, 1, -1, 1}, {7010, -1, 4, 1}, {7018, 1, -2, 1}// 19	20	21
			, {7004, 2, 0, 3}, {7013, 0, -2, 1}, {7011, -2, 4, 1}// 22	23	24
			, {6992, -2, 3, 1}, {7012, -2, 2, 1}, {7019, 1, -3, 1}// 25	26	27
			, {7011, -2, 2, 1}, {7014, 0, -3, 1}, {6992, 1, -3, 1}// 28	29	30
			, {6977, -3, 4, 1}, {6996, -2, 4, 1}, {6996, 0, -3, 0}// 31	32	33
					};



		public override BaseAddonDeed Deed
		{
			get
			{
				return new TreasurePile3AddonDeed();
			}
		}

		[ Constructable ]
		public TreasurePile3Addon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );

		}

		public TreasurePile3Addon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class TreasurePile3AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new TreasurePile3Addon();
			}
		}

		[Constructable]
		public TreasurePile3AddonDeed()
		{
			ItemID = 0x0E41;
			Weight = 50.0;
			Name = "Chest of Decorative Treasure";
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
            list.Add( 1049644, "Double Click To Dump In Your Home");
        }

		public TreasurePile3AddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
