using System;
using Server.Targeting;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using System.Collections;
using System.Collections.Generic;

namespace Server.Spells.Elementalism
{
    public class Elemental_Soul_Spell : ElementalSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Elemental Soul", "Viata",
                245,
                9062
            );

        public override SpellCircle Circle { get { return SpellCircle.Eighth; } }

        public Elemental_Soul_Spell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget( this );
        }

        public void Target( Mobile m )
        {
			string elm = ElementalSpell.GetElement( Caster );
			string orb = "air";
			int color = 0xAFE;
			int hue = 0x8CB-1;

			if ( elm == "air" )
			{
				orb = "air";
				color = 0xAFE;
				hue = 0x8CB-1;
			}
			else if ( elm == "earth" )
			{
				orb = "the earth";
				color = 0xB79;
				hue = 0;
			}
			else if ( elm == "fire" )
			{
				orb = "fire";
				color = 0xB17;
				hue = 0xAC8-1;
			}
			else if ( elm == "water" )
			{
				orb = "water";
				color = 0xB3F;
				hue = 0x90F-1;
			}

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

                m.PlaySound( 0x214 );
                m.FixedEffect( 0x3039, 10, 16, hue, 0 );
				m.SendMessage( "You summon a magical orb of " + orb + " to protect your soul." );
				SoulOrb iOrb = new SoulOrb();
				iOrb.m_Owner = m;
				iOrb.Hue = color;
				iOrb.Name = "magical orb of " + orb + "";
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

                m.PlaySound( 0x214 );
                m.FixedEffect( 0x3039, 10, 16, hue, 0 );

                m.CloseGump( typeof( ResurrectGump ) );
                m.SendGump( new ResurrectGump( m, Caster ) );
            }
            else if (m is BaseCreature && CheckBSequence( m, true ) )
			{
				BaseCreature pet = (BaseCreature)m;
				Mobile master = pet.GetMaster();
                SpellHelper.Turn( Caster, m );

                m.PlaySound( 0x214 );
                m.FixedEffect( 0x3039, 10, 16, hue, 0 );

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
					Caster.PlaySound( 0x214 );
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
					Caster.PlaySound( 0x214 );
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
					Caster.PlaySound( 0x214 );
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
					Caster.PlaySound( 0x214 );
				}
				else
				{
					Caster.SendMessage("They are not dead.");
				}
			}
			else
			{
				Caster.SendMessage("This spell didn't seem to work.");
			}
            FinishSequence();
		}

        private class InternalTarget : Target
        {
            private Elemental_Soul_Spell m_Owner;

            public InternalTarget( Elemental_Soul_Spell owner ) : base( 1, false, TargetFlags.Beneficial )
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
