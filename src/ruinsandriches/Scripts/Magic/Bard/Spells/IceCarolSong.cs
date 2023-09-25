using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Gumps;
using Server.Spells;
using Server.Misc;

namespace Server.Spells.Song
{
	public class IceCarolSong : Song
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Ice Carol", "*plays an ice carol*",
				//SpellCircle.First,
				//212,9041
				-1
			);

		private SongBook m_Book;
		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 5 ); } }
		public override double RequiredSkill{ get{ return 50.0; } }
		public override int RequiredMana{ get{ return 12; } }

		public IceCarolSong( Mobile caster, Item scroll) : base( caster, scroll, m_Info )
		{
		}

        public override void OnCast()
        {
            //get songbook instrument
            Spellbook book = Spellbook.Find(Caster, -1, SpellbookType.Song);
            if (book == null)
            {
                return;
            }
            m_Book = (SongBook)book;
            if (m_Book.Instrument == null || !(Caster.InRange(m_Book.Instrument.GetWorldLocation(), 1)))
            {
                Caster.SendMessage("Your instrument is missing! You can select another from your song book.");
                return;
            }

			bool sings = false;

			if( CheckSequence() )
			{
				sings = true;

				ArrayList targets = new ArrayList();

				foreach ( Mobile m in Caster.GetMobilesInRange( 3 ) )
				{
					if ( Caster.CanBeBeneficial( m, false, true ) && !(m is Golem) )
						targets.Add( m );
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					TimeSpan duration = TimeSpan.FromSeconds( (double)(MusicSkill( Caster ) * 2) );
                    int amount = Server.Misc.MyServerSettings.PlayerLevelMod( (int)(MusicSkill( Caster ) / 16), Caster );

					m.SendMessage( "Your resistance to cold has increased." );
					ResistanceMod mod1 = new ResistanceMod( ResistanceType.Cold, + amount );

					m.AddResistanceMod( mod1 );

					m.FixedParticles( 0x373A, 10, 15, 5012, 0x480, 3, EffectLayer.Waist );

					new ExpireTimer( m, mod1, duration ).Start();

				}
			}

			BardFunctions.UseBardInstrument( m_Book.Instrument, sings, Caster );
			FinishSequence();
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mods;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mod;
			}

			public void DoExpire()
			{
				PlayerMobile dpm = m_Mobile as PlayerMobile;
				m_Mobile.RemoveResistanceMod( m_Mods );

				Stop();
			}

			protected override void OnTick()
			{
				if ( m_Mobile != null )
				{
					m_Mobile.SendMessage( "The effect of the ice carol wears off." );
					DoExpire();
				}
			}
		}
	}
}
