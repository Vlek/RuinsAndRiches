using System;
using System.Collections.Generic;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	public class Miner : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MinersGuild; } }

		[Constructable]
		public Miner() : base( "the miner" )
		{
			SetSkill( SkillName.Mining, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBMiner() );

			m_SBInfos.Add( new RSOreMain() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" )
				m_SBInfos.Add( new RSOreSerpentIsland() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
				m_SBInfos.Add( new RSOreUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				m_SBInfos.Add( new RSOreSea() );

			m_SBInfos.Add( new SBBuyArtifacts() );
			m_SBInfos.Add( new SBGemArmor() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();
			AddItem( new Server.Items.Bandana( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.Pickaxe() );
		}

		public Miner( Serial serial ) : base( serial )
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
