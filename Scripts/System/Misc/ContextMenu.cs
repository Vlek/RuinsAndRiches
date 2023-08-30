using System;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;
using Server.Multis;

namespace Server.ContextMenus
{
	public class AddToSpellbookEntry : ContextMenuEntry
	{
		public AddToSpellbookEntry() : base( 6144, 3 )
		{
		}

		public override void OnClick()
		{
			if ( Owner.From.CheckAlive() && Owner.Target is SpellScroll )
				Owner.From.Target = new InternalTarget( (SpellScroll)Owner.Target );
		}

		private class InternalTarget : Target
		{
			private SpellScroll m_Scroll;

			public InternalTarget( SpellScroll scroll ) : base( 3, false, TargetFlags.None )
			{
				m_Scroll = scroll;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Spellbook )
				{
					if ( from.CheckAlive() && !m_Scroll.Deleted && m_Scroll.Movable && m_Scroll.Amount >= 1 && m_Scroll.CheckItemUse( from ) )
					{
						Spellbook book = (Spellbook)targeted;

						SpellbookType type = Spellbook.GetTypeForSpell( m_Scroll.SpellID );

						if ( type != book.SpellbookType )
						{
						}
						else if ( book.HasSpell( m_Scroll.SpellID ) )
						{
							from.SendLocalizedMessage( 500179 ); // That spell is already present in that spellbook.
						}
						else
						{
							int val = m_Scroll.SpellID - book.BookOffset;

							if ( val >= 0 && val < book.BookCount )
							{
								book.Content |= (ulong)1 << val;

								m_Scroll.Consume();

								from.Send( new Network.PlaySound( 0x249, book.GetWorldLocation() ) );
							}
						}
					}
				}
			}
		}
	}
}

namespace Server.ContextMenus
{
	public class EatEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private Food m_Food;

		public EatEntry( Mobile from, Food food ) : base( 6135, 1 )
		{
			m_From = from;
			m_Food = food;
		}

		public override void OnClick()
		{
			if ( m_Food.Deleted || !m_Food.Movable || !m_From.CheckAlive() || !m_Food.CheckItemUse( m_From ) )
				return;

			m_Food.Eat( m_From );
		}
	}
}

namespace Server.ContextMenus
{
	public class OpenBankEntry : ContextMenuEntry
	{
		private Mobile m_Banker;

		public OpenBankEntry( Mobile from, Mobile banker ) : base( 6105, 12 )
		{
			m_Banker = banker;
		}

		public override void OnClick()
		{
			if ( !Owner.From.CheckAlive() )
				return;

			if ( Owner.From.Criminal )
			{
				m_Banker.Say( 500378 ); // Thou art a criminal and cannot access thy bank box.
			}
			else
			{
				BankBox box = this.Owner.From.BankBox;
				if (box != null)
				{
					box.Open();
				}
			}
		}
	}
}

namespace Server.ContextMenus
{
	public class AddToPartyEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private Mobile m_Target;
		
		public AddToPartyEntry( Mobile from, Mobile target ) : base( 0197, 12 )
		{
			m_From = from;
			m_Target = target;
		}

		public override void OnClick()
		{			
			Party p = Party.Get( m_From );
			Party mp = Party.Get( m_Target );

			if ( m_From == m_Target )
				m_From.SendLocalizedMessage( 1005439 ); // You cannot add yourself to a party.
			else if ( p != null && p.Leader != m_From )
				m_From.SendLocalizedMessage( 1005453 ); // You may only add members to the party if you are the leader.
			else if ( p != null && (p.Members.Count + p.Candidates.Count) >= Party.Capacity )
				m_From.SendLocalizedMessage( 1008095 ); // You may only have 10 in your party (this includes candidates).
			else if ( !m_Target.Player )
				m_From.SendLocalizedMessage( 1005444 ); // The creature ignores your offer.
			else if ( mp != null && mp == p )
				m_From.SendLocalizedMessage( 1005440 ); // This person is already in your party!
			else if ( mp != null )
				m_From.SendLocalizedMessage( 1005441 ); // This person is already in a party!
			else
				Party.Invite( m_From, m_Target );
		}
	}
}

namespace Server.ContextMenus
{
	public class EjectPlayerEntry : ContextMenuEntry
	{
		private Mobile m_From;
		private Mobile m_Target;
		private BaseHouse m_TargetHouse;
		
		public EjectPlayerEntry( Mobile from, Mobile target ) : base( 6206, 12 )
		{
			m_From = from;
			m_Target = target;
			m_TargetHouse = BaseHouse.FindHouseAt( m_Target );
		}

		public override void OnClick()
		{			
			if ( !m_From.Alive || m_TargetHouse.Deleted || !m_TargetHouse.IsFriend( m_From ) )
				return;

			if ( m_Target is Mobile )
			{
				m_TargetHouse.Kick( m_From, (Mobile)m_Target );
			}
		}
	}
}

namespace Server.ContextMenus
{
	public class TeachEntry : ContextMenuEntry
	{
		private SkillName m_Skill;
		private BaseCreature m_Mobile;
		private Mobile m_From;

		public TeachEntry( SkillName skill, BaseCreature m, Mobile from, bool enabled ) : base( 6000 + (int)skill )
		{
			m_Skill = skill;
			m_Mobile = m;
			m_From = from;

			if ( !enabled )
				Flags |= Network.CMEFlags.Disabled;
		}

		public override void OnClick()
		{
			if ( !m_From.CheckAlive() )
				return;

			m_Mobile.Teach( m_Skill, m_From, 0, false );
		}
	}
}