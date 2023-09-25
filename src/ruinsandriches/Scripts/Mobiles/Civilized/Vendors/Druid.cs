using System;
using System.Collections;
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
	public class Druid : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.DruidsGuild; } }

		[Constructable]
		public Druid() : base( "the druid" )
		{
			SetSkill( SkillName.Herding, 80.0, 100.0 );
			SetSkill( SkillName.Camping, 80.0, 100.0 );
			SetSkill( SkillName.Cooking, 80.0, 100.0 );
			SetSkill( SkillName.Alchemy, 80.0, 100.0 );
			SetSkill( SkillName.Druidism, 85.0, 100.0 );
			SetSkill( SkillName.Taming, 90.0, 100.0 );
			SetSkill( SkillName.Veterinary, 90.0, 100.0 );

			AddItem( new LightSource() );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBDruid() );
			m_SBInfos.Add( new RSJars() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new DeerMask() );
			switch ( Utility.RandomMinMax( 0, 5 ) )
			{
				case 1: AddItem( new Server.Items.GnarledStaff() ); break;
				case 2: AddItem( new Server.Items.BlackStaff() ); break;
				case 3: AddItem( new Server.Items.WildStaff() ); break;
				case 4: AddItem( new Server.Items.QuarterStaff() ); break;
				case 5: AddItem( new Server.Items.ShepherdsCrook() ); break;
			}
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
						mobile.SendGump(new SpeechGump( mobile, "The Protectors Of The Forest", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Druid" ) ));
					}
				}
            }
        }
		///////////////////////////////////////////////////////////////////////////

		public virtual bool CheckResurrect( Mobile m )
		{
			return true;
		}

		private DateTime m_NextResurrect;
		private static TimeSpan ResurrectDelay = TimeSpan.FromSeconds( 2.0 );

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( !m.Frozen && DateTime.Now >= m_NextResurrect && InRange( m, 4 ) && !InRange( oldLocation, 4 ) && InLOS( m ) )
			{
				if ( m.IsDeadBondedPet )
				{
					m_NextResurrect = DateTime.Now + ResurrectDelay;

					if ( m.Map == null || !m.Map.CanFit( m.Location, 16, false, false ) )
					{
						Say("I sense a spirt of an animal...somewhere.");
					}
					else
					{
						BaseCreature bc = m as BaseCreature;

						bc.PlaySound( 0x214 );
						bc.FixedEffect( 0x376A, 10, 16 );

						bc.ResurrectPet();

						Say("Rise my friend. I wish I could save every unfortunate animal.");
					}
				}
			}
		}

		public Druid( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
		}
	}
}
