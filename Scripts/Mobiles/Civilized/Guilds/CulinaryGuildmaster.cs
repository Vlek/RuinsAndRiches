using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class CulinaryGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.CulinariansGuild; } }

		[Constructable]
		public CulinaryGuildmaster() : base( "culinary" )
		{
			SetSkill( SkillName.Cooking, 90.0, 100.0 );
			SetSkill( SkillName.Tasting, 75.0, 98.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBCook() );
			SBInfos.Add( new SBBaker() );
			SBInfos.Add( new SBButcher() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Knife() );
		}

		public CulinaryGuildmaster( Serial serial ) : base( serial )
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