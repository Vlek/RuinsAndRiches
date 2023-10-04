using System;
using Server.Network;
using Server;
using Server.Mobiles;

namespace Server.Misc
{
	public class FoodDecayTimer : Timer
	{
		public static void Initialize()
		{
			new FoodDecayTimer().Start();
		}

		public FoodDecayTimer() : base( TimeSpan.FromMinutes( 5 ), TimeSpan.FromMinutes( 5 ) )
		{
			Priority = TimerPriority.OneMinute;
		}

		protected override void OnTick()
		{
			FoodDecay();			
		}

		public static void FoodDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				HungerDecay( state.Mobile );
				ThirstDecay( state.Mobile );
			}
		}

		public static void HungerDecay( Mobile m )
		{
			if ( m != null  )
			{
				if ( m is PlayerMobile )
				{
					if ( m.Skills[SkillName.Camping].Value >= Utility.RandomMinMax( 1, 200 ) ){}
					else if ( Server.Items.BaseRace.NoFood( m.RaceID ) ){ m.Hunger = 20; }
					else if ( Server.Items.BaseRace.NoFoodOrDrink( m.RaceID ) ){ m.Thirst = 20; m.Hunger = 20; }
					else
					{
						if ( m.Hunger >= 1 )
						{
							m.Hunger -= 1;
							// added to give hunger value a real meaning.
							if ( m.Hunger < 5 ){ m.SendMessage( "You are extremely hungry." ); m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "I am extremely hungry."); }
							else if ( m.Hunger < 10 ){ m.SendMessage( "You are getting very hungry." ); m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "I am getting very hungry."); }
						}	
						else
						{
							if ( m.Hits > 5 )
								m.Hits -= 5;
							if ( m.Mana > 2 )
								m.Mana -= 2;

							m.SendMessage( "You are starving to death!" );
							m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "I am starving to death!");
						}
					}
				}
				else if ( m is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)m;

					if ( bc.Controlled && m.Hunger >= 1 )
					{
						m.Hunger -= 1;
					}
				}
			}
		}

		public static void ThirstDecay( Mobile m )
		{
			if ( m != null )
			{
				if ( m is PlayerMobile )
				{
					if ( m.Skills[SkillName.Camping].Value >= Utility.RandomMinMax( 1, 200 ) ){}
					else if ( Server.Items.BaseRace.NoFoodOrDrink( m.RaceID ) ){ m.Thirst = 20; m.Hunger = 20; }
					else if ( Server.Items.BaseRace.BrainEater( m.RaceID ) ){ m.Thirst = 20; }
					else
					{
						if ( m.Thirst >= 1 )
						{
							m.Thirst -= 1;
							if ( m.Thirst < 5 ){ m.SendMessage( "You are extremely thirsty." ); m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "I am extremely thirsty."); }
							else if ( m.Thirst < 10 ){ m.SendMessage( "You are getting thirsty." ); m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "I am getting thirsty."); }
						}
						else
						{
							if ( m.Stam > 5 )
								m.Stam -= 5;
							if ( m.Mana > 2 )
								m.Mana -= 2;

							m.SendMessage( "You are exhausted from thirst" );
							m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "I am exhausted from thirst!");
						}
					}
				}
				else if ( m is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)m;

					if ( bc.Controlled && m.Thirst >= 1 )
					{
						m.Thirst -= 1;
					}
				}
			}
		}
	}
}