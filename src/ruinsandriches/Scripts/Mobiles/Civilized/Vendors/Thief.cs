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
	public class Thief : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.ThievesGuild; } }

		[Constructable]
		public Thief() : base( "the thief" )
		{
			SetSkill( SkillName.Fencing, 55.0, 78.0 );
			SetSkill( SkillName.Searching, 65.0, 88.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.RemoveTrap, 65.0, 88.0 );
			SetSkill( SkillName.Lockpicking, 60.0, 83.0 );
			SetSkill( SkillName.Snooping, 65.0, 88.0 );
			SetSkill( SkillName.Stealing, 65.0, 88.0 );
			SetSkill( SkillName.Stealth, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBThief() );
			m_SBInfos.Add( new SBBuyArtifacts() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			int color = Utility.RandomNeutralHue();
			switch ( Utility.RandomMinMax( 0, 5 ) )
			{
				case 0: AddItem( new Server.Items.Bandana( color ) ); break;
				case 1: AddItem( new Server.Items.SkullCap( color ) ); break;
				case 2: AddItem( new Server.Items.ClothCowl( color ) ); AddItem( new Server.Items.Cloak( color ) ); break;
				case 3: AddItem( new Server.Items.ClothHood( color ) ); AddItem( new Server.Items.Cloak( color ) ); break;
				case 4: AddItem( new Server.Items.FancyHood( color ) ); AddItem( new Server.Items.Cloak( color ) ); break;
				case 5: AddItem( new Server.Items.HoodedMantle( color ) ); AddItem( new Server.Items.Cloak( color ) ); break;
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
						mobile.SendGump(new SpeechGump( mobile, "The Art Of Thievery", SpeechFunctions.SpeechText( m_Giver, m_Mobile, "Thief" ) ));
					}
				}
            }
        }
		///////////////////////////////////////////////////////////////////////////

		private class FixEntry : ContextMenuEntry
		{
			private Thief m_Thief;
			private Mobile m_From;

			public FixEntry( Thief Thief, Mobile from ) : base( 6120, 12 )
			{
				m_Thief = Thief;
				m_From = from;
			}

			public override void OnClick()
			{
				m_Thief.BeginRepair( m_From );
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

			int nCost = 1000;

			if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
			{
				nCost = nCost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * nCost ); if ( nCost < 1 ){ nCost = 1; }
				SayTo(from, "Since you are begging, do you still want me to unlock a box? It will only cost you " + nCost.ToString() + ".");
			}
			else { SayTo(from, "If you want me to unlock a box, it will cost you " + nCost.ToString() + " gold."); }

            from.Target = new RepairTarget(this);
        }

        private class RepairTarget : Target
        {
            private Thief m_Thief;

            public RepairTarget(Thief thief) : base(12, false, TargetFlags.None)
            {
                m_Thief = thief;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is BookBox && from.Backpack != null)
				{
					m_Thief.SayTo(from, "I cannot help with such a cursed item.");
				}
                else if (targeted is LockableContainer && from.Backpack != null)
                {
					LockableContainer box = (LockableContainer)targeted;
                    Container pack = from.Backpack;

                    int toConsume = 1000;
					if ( BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
					{
						toConsume = toConsume - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * toConsume );
					}

                    if (toConsume == 0)
                        return;

                    if (pack.ConsumeTotal(typeof(Gold), toConsume))
                    {
						if ( BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -BeggingKarma( from ), true ); } // DO ANY KARMA LOSS
                        m_Thief.SayTo(from, "That is now unlocked.");
                        from.SendMessage(String.Format("You pay {0} gold.", toConsume));
                        Effects.PlaySound(from.Location, from.Map, 0x241);
						box.Locked = false;
						box.TrapPower = 0;
						box.TrapLevel = 0;
						box.LockLevel = 0;
						box.MaxLockLevel = 0;
						box.RequiredSkill = 0;
						box.TrapType = TrapType.None;
                    }
                    else
                    {
                        m_Thief.SayTo(from, "It would cost you {0} gold to have that unlocked.", toConsume);
                        from.SendMessage("You do not have enough gold.");
                    }
                }
				else
				{
					m_Thief.SayTo(from, "That does not need my services.");
				}
            }
        }

		public Thief( Serial serial ) : base( serial )
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
