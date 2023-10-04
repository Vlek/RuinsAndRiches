using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Eighth
{
	public class EarthElementalSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Earth Elemental", "Kal Vas Xen Ylem",
				269,
				9020,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle { get { return SpellCircle.Eighth; } }

		public EarthElementalSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 2) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				TimeSpan duration = TimeSpan.FromSeconds( (Caster.Skills[SkillName.Magery].Value + Caster.Skills[SkillName.Psychology].Value) * 9 );

				if ( Caster.CheckTargetSkill( SkillName.Psychology, Caster, 0.0, 125.0 ) )
					SpellHelper.Summon( new SummonedEarthElementalGreater(), Caster, 0x217, duration, false, false );
				else
					SpellHelper.Summon( new SummonedEarthElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}