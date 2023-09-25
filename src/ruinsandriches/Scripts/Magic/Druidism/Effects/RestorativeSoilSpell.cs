using System;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;

namespace Server.Spells.Herbalist
{
	public class RestorativeSoilSpell : HerbalistSpell
	{
		private static SpellInfo m_Info = new SpellInfo( "", "", 239, 9021 );
		public override int HerbalistSpellCircle{ get{ return 4; } }
		public override double CastDelay{ get{ return 2.0; } }
		public override double RequiredSkill{ get{ return 85.0; } }
		public override int RequiredMana{ get{ return 0; } }
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }

		public RestorativeSoilSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

        public override void OnCast()
        {
            Caster.Target = new InternalTarget( this );
        }

        public void Target( Mobile m )
        {
            if ( !Caster.CanSee( m ) )
            {
                Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
            }
            else if ( m == Caster && CheckBSequence( m, true ) )
            {
				ArrayList targets = new ArrayList();
				foreach ( Item item in World.Items.Values )
				if ( item is SoulOrb )
				{
					SoulOrb myOrb = (SoulOrb)item;
					if ( myOrb.m_Owner == m )
					{
						targets.Add( item );
					}
				}
				for ( int i = 0; i < targets.Count; ++i )
				{
					Item item = ( Item )targets[ i ];
					item.Delete();
				}

                m.PlaySound( 0x5C9 );
                m.FixedEffect( 0x54F4, 10, 16, 0, 0 );
				m.SendMessage( "You pour the mystical mud in your pack to protect your soul." );
				SoulOrb iOrb = new SoulOrb();
				iOrb.m_Owner = m;
				iOrb.Name = "mystical mud";
				iOrb.ItemID = 0x913;
				iOrb.Hue = 0;
				m.AddToBackpack( iOrb );
				Server.Items.SoulOrb.OnSummoned( m, iOrb );
            }
            else if ( !Caster.Alive )
            {
                Caster.SendLocalizedMessage( 501040 ); // The resurrecter must be alive.
            }
            else if (m.Alive)
            {
                Caster.SendLocalizedMessage( 501041 ); // Target is not dead.
            }
            else if ( !Caster.InRange( m, 2 ) )
            {
                Caster.SendLocalizedMessage( 501042 ); // Target is not close enough.
            }
            else if ( m.Map == null || !m.Map.CanFit( m.Location, 16, false, false ) )
            {
                Caster.SendLocalizedMessage( 501042 ); // Target can not be resurrected at that location.
                m.SendLocalizedMessage( 502391 ); // Thou can not be resurrected there!
            }
            else if ( m is PlayerMobile && CheckBSequence( m, true ) )
            {
                SpellHelper.Turn( Caster, m );

                m.PlaySound( 0x5C9 );
                m.FixedEffect( 0x54F4, 10, 16, 0, 0 );

                m.CloseGump( typeof( ResurrectGump ) );
                m.SendGump( new ResurrectGump( m, Caster ) );
            }
            else if (m is BaseCreature && CheckBSequence( m, true ) )
			{
				BaseCreature pet = (BaseCreature)m;
				Mobile master = pet.GetMaster();
                SpellHelper.Turn( Caster, m );

                m.PlaySound( 0x5C9 );
                m.FixedEffect( 0x54F4, 10, 16, 0, 0 );

                master.CloseGump(typeof(PetResurrectGump));
                master.SendGump(new PetResurrectGump(master, pet));
            }
            FinishSequence();
        }

       public void ItemTarget( Item hench )
        {
			if ( hench is HenchmanFighterItem && CheckSequence() )
			{
				HenchmanFighterItem friend = (HenchmanFighterItem)hench;

				if ( friend.HenchDead > 0 )
				{
					friend.Name = "fighter henchman";
					friend.HenchDead = 0;
					friend.InvalidateProperties();
					Caster.PlaySound( 0x5C9 );
				}
				else
				{
					Caster.SendMessage("They are not dead.");
				}
			}
			else if ( hench is HenchmanWizardItem && CheckSequence() )
			{
				HenchmanWizardItem friend = (HenchmanWizardItem)hench;

				if ( friend.HenchDead > 0 )
				{
					friend.Name = "wizard henchman";
					friend.HenchDead = 0;
					friend.InvalidateProperties();
					Caster.PlaySound( 0x5C9 );
				}
				else
				{
					Caster.SendMessage("They are not dead.");
				}
			}
			else if ( hench is HenchmanArcherItem && CheckSequence() )
			{
				HenchmanArcherItem friend = (HenchmanArcherItem)hench;

				if ( friend.HenchDead > 0 )
				{
					friend.Name = "archer henchman";
					friend.HenchDead = 0;
					friend.InvalidateProperties();
					Caster.PlaySound( 0x5C9 );
				}
				else
				{
					Caster.SendMessage("They are not dead.");
				}
			}
			else if (hench is HenchmanMonsterItem && CheckSequence() )
			{
				HenchmanMonsterItem friend = (HenchmanMonsterItem)hench;

				if ( friend.HenchDead > 0 )
				{
					friend.Name = "creature henchman";
					friend.HenchDead = 0;
					friend.InvalidateProperties();
					Caster.PlaySound( 0x5C9 );
				}
				else
				{
					Caster.SendMessage("They are not dead.");
				}
			}
			else
			{
				Caster.SendMessage("This potion didn't seem to work.");
			}
            FinishSequence();
		}

        private class InternalTarget : Target
        {
            private RestorativeSoilSpell m_Owner;

            public InternalTarget( RestorativeSoilSpell owner ) : base( 1, false, TargetFlags.Beneficial )
            {
                m_Owner = owner;
            }

            protected override void OnTarget( Mobile from, object o )
            {
                if ( o is Mobile )
                {
                    m_Owner.Target( (Mobile)o );
                }
                else if ( o is Item )
                {
                    m_Owner.ItemTarget( (Item)o );
                }
            }

            protected override void OnTargetFinish( Mobile from )
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
