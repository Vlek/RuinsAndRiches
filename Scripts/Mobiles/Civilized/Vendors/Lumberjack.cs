using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Lumberjack : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.CarpentersGuild; } }

		[Constructable]
		public Lumberjack() : base( "the lumberjack" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBStavesWeapon() );
			m_SBInfos.Add( new SBCarpenter() );
			m_SBInfos.Add( new SBWoodenShields() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();
			if ( Utility.RandomBool() ){ AddItem( new Server.Items.Hatchet() ); }
		}

		public Lumberjack( Serial serial ) : base( serial )
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