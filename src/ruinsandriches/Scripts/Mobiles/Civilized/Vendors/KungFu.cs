using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using System.Collections;
using Server.ContextMenus;
using Server.Gumps;
using Server.Multis;
using Server.Misc;
using Server.Guilds;

namespace Server.Mobiles
{
	public class KungFu : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public KungFu() : base( "the Monk" )
		{
			SetSkill( SkillName.Bushido, 85.0, 125.0 );
			SetSkill( SkillName.Fencing, 64.0, 80.0 );
			SetSkill( SkillName.Bludgeoning, 64.0, 80.0 );
			SetSkill( SkillName.Ninjitsu, 85.0, 125.0 );
			SetSkill( SkillName.Parry, 64.0, 80.0 );
			SetSkill( SkillName.Tactics, 64.0, 85.0 );
			SetSkill( SkillName.Swords, 64.0, 85.0 );
			SetSkill( SkillName.FistFighting, 85.0, 125.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.Stealth, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBKungFu() );
			m_SBInfos.Add( new SBSEArmor() );
			m_SBInfos.Add( new SBSELeatherArmor() );
			m_SBInfos.Add( new SBSEBowyer() );
			m_SBInfos.Add( new SBSECarpenter() );
			m_SBInfos.Add( new SBSEWeapons() );
			m_SBInfos.Add( new SBSEHats() );
			m_SBInfos.Add( new SBSECook() );
			m_SBInfos.Add( new SBSEFood() );
			m_SBInfos.Add( new SBBuyArtifacts() );
		}

		public override void InitOutfit()
		{
			Server.Misc.MorphingTime.RemoveMyClothes( this );
			Title = "the Monk";
			Server.Misc.IntelligentAction.DressUpWizards( this, true );
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
						mobile.SendGump(new SpeechGump( mobile, "The Mystical Art Of Wizardry", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Monk" ) ));
					}
				}
            }
        }
		///////////////////////////////////////////////////////////////////////////

		public KungFu( Serial serial ) : base( serial )
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
