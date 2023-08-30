using System;
using System.Collections.Generic;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	public class CarpenterGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.CarpentersGuild; } }

		[Constructable]
		public CarpenterGuildmaster() : base( "carpenter" )
		{
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBStavesWeapon() );
			SBInfos.Add( new SBCarpenterGuild() );
			SBInfos.Add( new SBWoodenShields() ); 

			SBInfos.Add( new RSBoardsMain() );
			if ( Worlds.IsCrypt( this.Location, this.Map ) )
				SBInfos.Add( new RSBoardsGhost() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Land of Sosaria" )
				SBInfos.Add( new RSBoardsUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				SBInfos.Add( new RSBoardsSea() );

			SBInfos.Add( new RSLogsMain() );
			if ( Worlds.IsCrypt( this.Location, this.Map ) )
				SBInfos.Add( new RSLogsGhost() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
				SBInfos.Add( new RSLogsUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				SBInfos.Add( new RSLogsSea() );

			SBInfos.Add( new SBBuyArtifacts() ); 
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.SmithHammer() );
		}

		public CarpenterGuildmaster( Serial serial ) : base( serial )
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