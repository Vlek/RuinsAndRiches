using System;
using System.Collections;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	public class MinerGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.MinersGuild; } }

		[Constructable]
		public MinerGuildmaster() : base( "miner" )
		{
			SetSkill( SkillName.Mercantile, 60.0, 83.0 );
			SetSkill( SkillName.Mining, 90.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBMinerGuild() );

			SBInfos.Add( new RSOreMain() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" )
				SBInfos.Add( new RSOreSerpentIsland() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
				SBInfos.Add( new RSOreUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				SBInfos.Add( new RSOreSea() );

			SBInfos.Add( new SBBuyArtifacts() ); 
			SBInfos.Add( new SBGemArmor() ); 
		}

		public override void InitOutfit()
		{
			base.InitOutfit();
			AddItem( new Server.Items.Bandana( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.Pickaxe() );
		}

		public MinerGuildmaster( Serial serial ) : base( serial )
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