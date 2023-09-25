using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Spells.Seventh;

namespace Server.Spells.Shinobi
{
	public class Deception : ShinobiSpell
	{
		public override int spellIndex { get { return 291; } }
		private static SpellInfo m_Info = new SpellInfo(
				"Deception", "Azamuku Koto",
				-1,
				0
			);

		public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 3.0 ); } }
		public override double RequiredSkill{ get{ return (double)(Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "skill" ))); } }
		public override int RequiredTithing{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "points" )); } }
		public override int RequiredMana{ get{ return Int32.Parse(  Server.Items.ShinobiScroll.ShinobiInfo( spellIndex, "mana" )); } }

		public Deception( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( Factions.Sigil.ExistsOn( Caster ) )
			{
				Caster.SendMessage( "You cannot disguise yourself if you have a sigil!" );
				return false;
			}
			else if ( !Caster.CanBeginAction( typeof( IncognitoSpell ) ) )
			{
				Caster.SendMessage( "You are already in a disguise!" );
				return false;
			}
			else if ( !Caster.CanBeginAction( typeof( Deception ) ) )
			{
				Caster.SendMessage( "You are already in a disguise!" );
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( !Caster.CanBeginAction( typeof( Deception ) ) )
			{
				Caster.SendMessage( "You are already in a disguise!" );
			}
			else if ( !Caster.CanBeginAction( typeof( IncognitoSpell ) ) )
			{
				Caster.SendMessage( "You are already in a disguise!" );
			}
			else if ( DisguiseTimers.IsDisguised( Caster ) )
			{
				Caster.SendMessage( "You can't do that while disguised.!" );
			}
			else if ( !Caster.CanBeginAction( typeof( PolymorphSpell ) ) || ( Caster.IsBodyMod && Caster.RaceID != Caster.BodyMod ) )
			{
				DoFizzle();
			}
			else if ( CheckSequence() )
			{
				if ( Caster.BeginAction( typeof( Deception ) ) )
				{
					DisguiseTimers.StopTimer( Caster );

					if ( Caster.RaceID != 0 )
					{
						Caster.HueMod = 0;
						Caster.BodyMod = Utility.RandomList(593, 597, 598);
						Caster.NameMod = NameList.RandomName( "dwarf" );
					}
					else
					{
						Caster.HueMod = Caster.Race.RandomSkinHue();
						Caster.NameMod = Caster.Female ? NameList.RandomName( "female" ) : NameList.RandomName( "male" );

						PlayerMobile pm = Caster as PlayerMobile;

						if ( pm != null && pm.Race != null )
						{
							pm.SetHairMods( pm.Race.RandomHair( pm.Female ), pm.Race.RandomFacialHair( pm.Female ) );
							pm.HairHue = Utility.RandomHairHue();
							pm.FacialHairHue = Utility.RandomHairHue();
						}
					}

					Effects.SendLocationParticles( EffectItem.Create( Caster.Location, Caster.Map, EffectItem.DefaultDuration ), 0x3728, 8, 20, 0, 0, 5042, 0 );
					Effects.PlaySound( Caster, Caster.Map, 0x201 );

					BaseArmor.ValidateMobile( Caster );
					BaseClothing.ValidateMobile( Caster );

					StopTimer( Caster );

					int timeVal = ((6 * Caster.Skills.Ninjitsu.Fixed) / 50) + 1;

					if( timeVal > 144 )
						timeVal = 144;

					TimeSpan length = TimeSpan.FromSeconds( timeVal );

					Timer t = new InternalTimer( Caster, length );

					m_Timers[Caster] = t;

					t.Start();

					BuffInfo.AddBuff( Caster, new BuffInfo( BuffIcon.Incognito, 1075819, length, Caster ) );

				}
				else
				{
					Caster.SendLocalizedMessage( 1079022 ); // You're already incognitoed!
				}
			}

			FinishSequence();
		}

		private static Hashtable m_Timers = new Hashtable();

		public static bool StopTimer( Mobile m )
		{
			Timer t = (Timer)m_Timers[m];

			if ( t != null )
			{
				t.Stop();
				m_Timers.Remove( m );
				BuffInfo.RemoveBuff( m, BuffIcon.Incognito );
			}

			return ( t != null );
		}

		private static int[] m_HairIDs = new int[]
			{
				0x2044, 0x2045, 0x2046,
				0x203C, 0x203B, 0x203D,
				0x2047, 0x2048, 0x2049,
				0x204A, 0x0000
			};

		private static int[] m_BeardIDs = new int[]
			{
				0x203E, 0x203F, 0x2040,
				0x2041, 0x204B, 0x204C,
				0x204D, 0x0000
			};

		private class InternalTimer : Timer
		{
			private Mobile m_Owner;

			public InternalTimer( Mobile owner, TimeSpan length ) : base( length )
			{
				m_Owner = owner;

				/*
				int val = ((6 * owner.Skills.Ninjitsu.Fixed) / 50) + 1;

				if ( val > 144 )
					val = 144;

				Delay = TimeSpan.FromSeconds( val );
				 * */
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( Deception ) ) )
				{
					if ( m_Owner is PlayerMobile && m_Owner.RaceID == 0 )
						((PlayerMobile)m_Owner).SetHairMods( -1, -1 );

					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.NameMod = null;
					m_Owner.RaceBody();
					m_Owner.EndAction( typeof( Deception ) );

					BaseArmor.ValidateMobile( m_Owner );
					BaseClothing.ValidateMobile( m_Owner );
				}
			}
		}
	}
}
