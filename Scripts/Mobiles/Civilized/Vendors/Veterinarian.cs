using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;
using Server.Misc;

namespace Server.Mobiles
{
	public class Veterinarian : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.DruidsGuild; } }

		[Constructable]
		public Veterinarian() : base( "the vet" )
		{
			SetSkill( SkillName.Druidism, 85.0, 100.0 );
			SetSkill( SkillName.Veterinary, 90.0, 100.0 );
		}

		///////////////////////////////////////////////////////////////////////////

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new SpeechGumpEntry( from, this ) ); 
			list.Add( new RidingGumpEntry( from, this ) ); 
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
						mobile.SendGump(new SpeechGump( mobile, "Animal Companions", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Pets" ) ));
					}
				}
            }
        }

		///////////////////////////////////////////////////////////////////////////

		public class RidingGumpEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public RidingGumpEntry( Mobile from, Mobile giver ) : base( 6098, 3 )
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
					if ( ! mobile.HasGump( typeof( Server.Mobiles.Veterinarian.RidingGump ) ) )
					{
						mobile.SendGump(new Server.Mobiles.Veterinarian.RidingGump( mobile ));
					}
				}
            }
        }

		public class RidingGump : Gump
		{
			public RidingGump( Mobile from ) : base( 50, 50 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				from.SendSound( 0x4A ); 
				string color = "#c8b67d";

				AddPage(0);

				AddImage(0, 0, 20767);
				AddButton(968, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 13, 578, 981, 20, @"<BODY><BASEFONT Color=" + color + ">If you see any creature that looks like these here, regardless of color, they can be used as mounts to travel with if tamed or purchased.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 13, 618, 981, 20, @"<BODY><BASEFONT Color=" + color + ">* Dragons must learn to be ridden, while Dragyns can be ridden if the Zuluu legends are true.</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 670, 134, 27, 20, @"<BODY><BASEFONT Color=" + color + "><BIG>*</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile;
				from.SendSound( 0x4A );
			}
		}

		///////////////////////////////////////////////////////////////////////////

		public override void InitSBInfo()
		{
			if ( Server.Misc.Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" )
			{
				m_SBInfos.Add( new SBGargoyleAnimalTrainer() );
			}
			else if ( Server.Misc.Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Land of Lodoria" )
			{
				m_SBInfos.Add( new SBElfAnimalTrainer() );
			}
			else if ( Server.Misc.Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Isles of Dread" )
			{
				m_SBInfos.Add( new SBBarbarianAnimalTrainer() );
			}
			else if ( Server.Misc.Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Savaged Empire" )
			{
				m_SBInfos.Add( new SBOrkAnimalTrainer() );
			}
			else if ( Worlds.IsCrypt( this.Location, this.Map ) )
			{
				m_SBInfos.Add( new SBDeadAnimalTrainer() );
			}
			else
			{
				m_SBInfos.Add( new SBHumanAnimalTrainer() );
			}
			m_SBInfos.Add( new SBVeterinarian() ); 
			m_SBInfos.Add( new SBBuyArtifacts() ); 
		}

		public Veterinarian( Serial serial ) : base( serial )
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