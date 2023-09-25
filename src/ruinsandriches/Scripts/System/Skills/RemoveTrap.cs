using System;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Network;
using Server.Factions;

namespace Server.SkillHandlers
{
	public class RemoveTrap
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.RemoveTrap].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			m.Target = new InternalTarget();

			m.SendLocalizedMessage( 502368 ); // Which trap will you attempt to disarm?

			return TimeSpan.FromSeconds( 5.0 ); // 5 second delay before being able to re-use a skill
		}

		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 2, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					from.SendLocalizedMessage( 502816 ); // You feel that such an action would be inappropriate
				}
				else if ( targeted is TrapableContainer )
				{
					TrapableContainer targ = (TrapableContainer)targeted;

					from.Direction = from.GetDirectionTo( targ );

					int nTrapLevel = targ.TrapLevel * 10;

					if ( targ.TrapType == TrapType.None )
					{
						from.SendLocalizedMessage( 502373 ); // That doesn't appear to be trapped
						return;
					}

					if ( (int)(from.Skills[SkillName.RemoveTrap].Value ) < nTrapLevel )
					{
						from.SendMessage( "This trap looks too complicated for you." );
						return;
					}

					from.PlaySound( 0x241 );

					// if ( from.CheckTargetSkill( SkillName.RemoveTrap, targ, targ.TrapPower, targ.TrapPower + 30 ) )
					nTrapLevel = nTrapLevel + 20;
					if ( from.CheckTargetSkill( SkillName.RemoveTrap, targ, 0, nTrapLevel ) )
					{
						targ.TrapPower = 0;
						targ.TrapLevel = 0;
						targ.TrapType = TrapType.None;
						from.SendLocalizedMessage( 502377 ); // You successfully render the trap harmless
					}
					else
					{
						from.SendLocalizedMessage( 502372 ); // You fail to disarm the trap... but you don't set it off
					}
				}
				else if ( targeted is BaseFactionTrap )
				{
					BaseFactionTrap trap = (BaseFactionTrap) targeted;
					Faction faction = Faction.Find( from );

					FactionTrapRemovalKit kit = ( from.Backpack == null ? null : from.Backpack.FindItemByType( typeof( FactionTrapRemovalKit ) ) as FactionTrapRemovalKit );

					bool isOwner = ( trap.Placer == from || ( trap.Faction != null && trap.Faction.IsCommander( from ) ) );

					if ( faction == null )
					{
						from.SendLocalizedMessage( 1010538 ); // You may not disarm faction traps unless you are in an opposing faction
					}
					else if ( faction == trap.Faction && trap.Faction != null && !isOwner )
					{
						from.SendLocalizedMessage( 1010537 ); // You may not disarm traps set by your own faction!
					}
					else if ( !isOwner && kit == null )
					{
						from.SendLocalizedMessage( 1042530 ); // You must have a trap removal kit at the base level of your pack to disarm a faction trap.
					}
					else
					{
						if ( (Core.ML && isOwner) || (from.CheckTargetSkill( SkillName.RemoveTrap, trap, 80.0, 125.0 ) && from.CheckTargetSkill( SkillName.Tinkering, trap, 80.0, 125.0 )) )
						{
							from.PrivateOverheadMessage( MessageType.Regular, trap.MessageHue, trap.DisarmMessage, from.NetState );

							if ( !isOwner )
							{
								int silver = faction.AwardSilver( from, trap.SilverFromDisarm );

								if ( silver > 0 )
									from.SendLocalizedMessage( 1008113, true, silver.ToString( "N0" ) ); // You have been granted faction silver for removing the enemy trap :
							}

							trap.Delete();
						}
						else
						{
							from.SendLocalizedMessage( 502372 ); // You fail to disarm the trap... but you don't set it off
						}

						if ( !isOwner && kit != null )
							kit.ConsumeCharge( from );
					}
				}
				else if ( targeted is Item )
				{
					if ( (Item)targeted is HiddenTrap )
					{
						from.PlaySound( 0x241 );
						
						if ( from.CheckSkill( SkillName.RemoveTrap, 0, 125 ) )
						{
							Item HideTrap = (Item)targeted;
							HideTrap.Delete();
							from.SendLocalizedMessage( 502377 ); // You successfully render the trap harmless
						}
						else
						{
							from.SendLocalizedMessage( 502372 ); // You fail to disarm the trap... but you don't set it off
						}
					}
					else { from.SendLocalizedMessage( 502373 ); }
				}
				else
				{
					from.SendLocalizedMessage( 502373 ); // That does'nt appear to be trapped
				}
			}
		}
	}
}