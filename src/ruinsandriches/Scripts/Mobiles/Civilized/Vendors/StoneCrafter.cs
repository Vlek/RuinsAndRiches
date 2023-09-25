using Server;
using System;
using System.Collections.Generic;
using System.Collections;
using Server.Items;
using Server.Multis;
using Server.Guilds;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	[TypeAlias( "Server.Mobiles.GargoyleStonecrafter" )]
	public class StoneCrafter : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MinersGuild; } }

		[Constructable]
		public StoneCrafter() : base( "the stone crafter" )
		{
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBStoneCrafter() );

			m_SBInfos.Add( new RSBoardsMain() );
			if ( Worlds.IsCrypt( this.Location, this.Map ) )
				m_SBInfos.Add( new RSBoardsGhost() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
				m_SBInfos.Add( new RSBoardsUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				m_SBInfos.Add( new RSBoardsSea() );

			m_SBInfos.Add( new RSLogsMain() );
			if ( Worlds.IsCrypt( this.Location, this.Map ) )
				m_SBInfos.Add( new RSLogsGhost() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
				m_SBInfos.Add( new RSLogsUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				m_SBInfos.Add( new RSLogsSea() );
		}

		///////////////////////////////////////////////////////////////////////////
		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SpeechGumpEntry( from, this ) );
		}

		public class SpeechGumpEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

			public SpeechGumpEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;

				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( ! mobile.HasGump( typeof( SpeechGump ) ) )
					{
						Server.Misc.IntelligentAction.SayHey( m_Giver );
						mobile.SendGump(new SpeechGump( mobile, "The Shaping of Stone", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Stonecrafter" ) ));
					}
				}
            }
        }
		///////////////////////////////////////////////////////////////////////////

		public StoneCrafter( Serial serial ) : base( serial )
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

			if ( Title == "the stonecrafter" )
				Title = "the stone crafter";
		}
	}
}
