using System;
using System.Collections;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	public class BlacksmithGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.BlacksmithsGuild; } }

		[Constructable]
		public BlacksmithGuildmaster() : base( "blacksmith" )
		{
			SetSkill( SkillName.ArmsLore, 65.0, 88.0 );
			SetSkill( SkillName.Blacksmith, 90.0, 100.0 );
			SetSkill( SkillName.Bludgeoning, 36.0, 68.0 );
			SetSkill( SkillName.Parry, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBBlacksmithGuild() );

			SBInfos.Add( new RSIngotsMain() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" )
				SBInfos.Add( new RSIngotsSerpentIsland() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Savaged Empire" )
				SBInfos.Add( new RSIngotsSavagedEmpire() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Island of Umber Veil" )
				SBInfos.Add( new RSIngotsUmberVeil() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Land of Sosaria" )
				SBInfos.Add( new RSIngotsUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				SBInfos.Add( new RSIngotsSea() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.FullApron( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.Bandana( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.SmithHammer() );
		}

		public BlacksmithGuildmaster( Serial serial ) : base( serial )
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