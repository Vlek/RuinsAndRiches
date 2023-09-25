using System;
using Server;

namespace Server.Items
{
	public class AchillesStrike : WeaponAbility
	{
		public AchillesStrike(){}

		public override int BaseMana { get { return 20; } }

		public override void OnHit(Mobile attacker, Mobile defender, int damage)
		{
			if (!Validate(attacker) || !CheckMana(attacker, true)) return;
			ClearCurrentAbility(attacker);
			attacker.SendMessage("You damage their Achilles tendon!");
			defender.SendMessage("Your Achilles tendon was hurt!");

			BaseWeapon weapon = attacker.Weapon as BaseWeapon;
			if (weapon == null) return;
			Skill skill = attacker.Skills[weapon.Skill];
			double reqSkill = GetRequiredSkill(attacker);
			double skilltouse = 0.0;
			if (skill != null) skilltouse = skill.Value;
			if (weapon.WeaponAttributes.UseBestSkill > 0)
			{
				double skilltouse2 = 0.0;
				if ( attacker.Skills[SkillName.Swords].Value >= reqSkill ) skilltouse2 = attacker.Skills[SkillName.Swords].Value;
				if ( attacker.Skills[SkillName.Bludgeoning].Value >= reqSkill && attacker.Skills[SkillName.Bludgeoning].Value > skilltouse2 ) skilltouse2 = attacker.Skills[SkillName.Bludgeoning].Value;
				if ( attacker.Skills[SkillName.Fencing].Value >= reqSkill && attacker.Skills[SkillName.Fencing].Value > skilltouse2 ) skilltouse2 = attacker.Skills[SkillName.Fencing].Value;
				if ( attacker.Skills[SkillName.Lumberjacking].Value >= reqSkill && attacker.Skills[SkillName.Lumberjacking].Value > skilltouse2 ) skilltouse2 = attacker.Skills[SkillName.Lumberjacking].Value;
				if (skilltouse2 > skilltouse) skilltouse = skilltouse2;
			}
			int todam = (int)(skilltouse / 20);
			WeaponStrikes.AchillesStrike( defender, TimeSpan.FromSeconds( (Utility.RandomDouble() * todam / 2 ) + 3 ) );
			AOS.Damage( defender, attacker, (Utility.RandomMinMax(5, 25) + todam), true, 100, 0, 0, 0, 0 );
			base.OnHit(attacker, defender, damage);
		}
	}
}
