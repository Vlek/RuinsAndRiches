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
using Server.Targeting;
using Server.Network;

namespace Server.Mobiles
{
	public class Provisioner : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MerchantsGuild; } }

		[Constructable]
		public Provisioner() : base( "the provisioner" )
		{
			SetSkill( SkillName.Camping, 65.0, 88.0 );
			SetSkill( SkillName.Mercantile, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBProvisioner() );

			Region reg = Region.Find( this.Location, this.Map );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
			{
				m_SBInfos.Add( new SBSailor() );
				m_SBInfos.Add( new SBHighSeas() );
			}

			string CurrentMonth = DateTime.Now.ToString("MM");

			if ( CurrentMonth == "12" ){ m_SBInfos.Add( new SBHolidayXmas() ); }
			if ( CurrentMonth == "10" ){ m_SBInfos.Add( new SBHolidayHalloween() ); }

			m_SBInfos.Add( new SBBuyArtifacts() );

			if ( Server.Misc.Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Land of Lodoria" )
			{
				m_SBInfos.Add( new SBElfRares() );
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
						mobile.SendGump(new SpeechGump( mobile, "The Right Survival Gear", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Provisioner" ) ));
					}
				}
            }
        }

		///////////////////////////////////////////////////////////////////////////

		private class FixEntry : ContextMenuEntry
		{
			private Provisioner m_Provisioner;
			private Mobile m_From;

			public FixEntry( Provisioner Provisioner, Mobile from ) : base( 6120, 12 )
			{
				m_Provisioner = Provisioner;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Provisioner.BeginRepair( m_From );
			}
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( from.Alive && !from.Blessed )
			{
				list.Add( new FixEntry( this, from ) );
			}

			base.AddCustomContextEntries( from, list );
		}

        public void BeginRepair(Mobile from)
        {
            if ( Deleted || !from.Alive )
                return;

			int idCost = 25;
			int nCost = 5;
			int nCostH = 10;

			if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
			{
				nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
				nCostH = nCostH - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCostH ); if ( nCostH < 1 ){ nCostH = 1; }
				idCost = idCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * idCost ); if ( idCost < 1 ){ idCost = 1; }
				SayTo(from, "Since you are begging, which unusual item shall I examine, for " + idCost.ToString() + " gold?");
			}
			else { SayTo(from, "Which unusual item shall I examine, for " + idCost.ToString() + " gold?"); }

            from.Target = new RepairTarget(this);
        }

        private class RepairTarget : Target
        {
            private Provisioner m_Provisioner;

            public RepairTarget(Provisioner provisioner) : base(12, false, TargetFlags.None)
            {
                m_Provisioner = provisioner;
            }

            protected override void OnTarget(Mobile from, object targeted)
			{
				if ( targeted is Item )
				{
					Item examine = (Item)targeted;

					if ( Server.Misc.RelicItems.IsRelicItem( examine ) )
					{
						Container packs = from.Backpack;
						int nCost = 25;

						if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
						{
							nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
						}
						int toConsume = nCost;

						if ( packs.ConsumeTotal(typeof(Gold), toConsume) )
						{
							string toSay = Server.Misc.RelicItems.IdentifyRelicValue( m_Provisioner, from, examine );
							if ( toSay != "" )
							{
								from.SendMessage(String.Format("You pay {0} gold.", toConsume));
								m_Provisioner.SayTo(from, toSay );
							}
							else
							{
								m_Provisioner.SayTo(from, "I cannot put a value on that.");
							}

						}
						else
						{
							m_Provisioner.SayTo(from, "It would cost you {0} gold for me to examine that.", toConsume);
							from.SendMessage("You do not have enough gold.");
						}
					}
					else
					{
						m_Provisioner.SayTo(from, "I cannot put a value on that.");
					}
				}
				/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				else
				{
					m_Provisioner.SayTo(from, "I cannot put a value on that.");
				}
            }
        }

		public Provisioner( Serial serial ) : base( serial )
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
