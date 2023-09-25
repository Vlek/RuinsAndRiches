using System;
using System.Collections.Generic;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class Devon : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.FishermensGuild; } }

		[Constructable]
		public Devon() : base( "the fisherman" )
		{
			Name = "Devon";
			SpeechHue = Utility.RandomTalkHue();
			Body = 400;
			Female = false;
			Hue = 0x83EA;

			SetSkill( SkillName.Seafaring, 75.0, 98.0 );

			FacialHairItemID = 0; // NO BEARD
			HairItemID = 0x203D; // PONY TAIL
			FacialHairHue = 0;
			HairHue = 0x467;
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBFisherman() );
			m_SBInfos.Add( new SBDevon() );
			m_SBInfos.Add( new SBShipwright() );
		}

		public override void InitOutfit()
		{
			this.FacialHairItemID = 0; // NO BEARD
			this.HairItemID = 0x203D; // PONY TAIL
			this.FacialHairHue = 0;
			this.HairHue = 0x467;

			AddItem( new Server.Items.LongPants( Utility.RandomNeutralHue() ) );
			AddItem( new Server.Items.FishingPole() );
			AddItem( new Server.Items.Shirt( Utility.RandomNeutralHue() ) );
		}

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
						mobile.SendGump(new SpeechGump( mobile, "Sailing Carthax Lake", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Devon" ) ));
					}
				}
            }
        }

		public Devon( Serial serial ) : base( serial )
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
