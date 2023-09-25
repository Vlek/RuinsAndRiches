using System;
using System.Collections;
using Server.Misc;

namespace Server.Items
{
	public enum CraftResource
	{
		None = 0,
		Iron = 1,
		DullCopper,
		ShadowIron,
		Copper,
		Bronze,
		Gold,
		Agapite,
		Verite,
		Valorite,
		Nepturite,
		Obsidian,
		Steel,
		Brass,
		Mithril,
		Xormite,
		Dwarven,

		RegularLeather = 101,
		SpinedLeather,
		HornedLeather,
		BarbedLeather,
		NecroticLeather,
		VolcanicLeather,
		FrozenLeather,
		GoliathLeather,
		DraconicLeather,
		HellishLeather,
		DinosaurLeather,
		AlienLeather,

		RedScales = 201,
		YellowScales,
		BlackScales,
		GreenScales,
		WhiteScales,
		BlueScales,
		DinosaurScales,

		RegularWood = 301,
		AshTree,
		CherryTree,
		EbonyTree,
		GoldenOakTree,
		HickoryTree,
		MahoganyTree,
		OakTree,
		PineTree,
		GhostTree,
		RosewoodTree,
		WalnutTree,
		PetrifiedTree,
		DriftwoodTree,
		ElvenTree
	}

	public enum CraftResourceType
	{
		None,
		Metal,
		Leather,
		Scales,
		Wood
	}

	public class CraftAttributeInfo
	{
		private int m_WeaponFireDamage;
		private int m_WeaponColdDamage;
		private int m_WeaponPoisonDamage;
		private int m_WeaponEnergyDamage;
		private int m_WeaponChaosDamage;
		private int m_WeaponDirectDamage;
		private int m_WeaponDurability;
		private int m_WeaponLuck;
		private int m_WeaponGoldIncrease;
		private int m_WeaponLowerRequirements;

		private int m_ArmorPhysicalResist;
		private int m_ArmorFireResist;
		private int m_ArmorColdResist;
		private int m_ArmorPoisonResist;
		private int m_ArmorEnergyResist;
		private int m_ArmorDurability;
		private int m_ArmorLuck;
		private int m_ArmorGoldIncrease;
		private int m_ArmorLowerRequirements;

		private int m_RunicMinAttributes;
		private int m_RunicMaxAttributes;
		private int m_RunicMinIntensity;
		private int m_RunicMaxIntensity;

		public int WeaponFireDamage{ get{ return m_WeaponFireDamage; } set{ m_WeaponFireDamage = value; } }
		public int WeaponColdDamage{ get{ return m_WeaponColdDamage; } set{ m_WeaponColdDamage = value; } }
		public int WeaponPoisonDamage{ get{ return m_WeaponPoisonDamage; } set{ m_WeaponPoisonDamage = value; } }
		public int WeaponEnergyDamage{ get{ return m_WeaponEnergyDamage; } set{ m_WeaponEnergyDamage = value; } }
		public int WeaponChaosDamage{ get{ return m_WeaponChaosDamage; } set{ m_WeaponChaosDamage = value; } }
		public int WeaponDirectDamage{ get{ return m_WeaponDirectDamage; } set{ m_WeaponDirectDamage = value; } }
		public int WeaponDurability{ get{ return m_WeaponDurability; } set{ m_WeaponDurability = value; } }
		public int WeaponLuck{ get{ return m_WeaponLuck; } set{ m_WeaponLuck = value; } }
		public int WeaponGoldIncrease{ get{ return m_WeaponGoldIncrease; } set{ m_WeaponGoldIncrease = value; } }
		public int WeaponLowerRequirements{ get{ return m_WeaponLowerRequirements; } set{ m_WeaponLowerRequirements = value; } }

		public int ArmorPhysicalResist{ get{ return m_ArmorPhysicalResist; } set{ m_ArmorPhysicalResist = value; } }
		public int ArmorFireResist{ get{ return m_ArmorFireResist; } set{ m_ArmorFireResist = value; } }
		public int ArmorColdResist{ get{ return m_ArmorColdResist; } set{ m_ArmorColdResist = value; } }
		public int ArmorPoisonResist{ get{ return m_ArmorPoisonResist; } set{ m_ArmorPoisonResist = value; } }
		public int ArmorEnergyResist{ get{ return m_ArmorEnergyResist; } set{ m_ArmorEnergyResist = value; } }
		public int ArmorDurability{ get{ return m_ArmorDurability; } set{ m_ArmorDurability = value; } }
		public int ArmorLuck{ get{ return m_ArmorLuck; } set{ m_ArmorLuck = value; } }
		public int ArmorGoldIncrease{ get{ return m_ArmorGoldIncrease; } set{ m_ArmorGoldIncrease = value; } }
		public int ArmorLowerRequirements{ get{ return m_ArmorLowerRequirements; } set{ m_ArmorLowerRequirements = value; } }

		public int RunicMinAttributes{ get{ return m_RunicMinAttributes; } set{ m_RunicMinAttributes = value; } }
		public int RunicMaxAttributes{ get{ return m_RunicMaxAttributes; } set{ m_RunicMaxAttributes = value; } }
		public int RunicMinIntensity{ get{ return m_RunicMinIntensity; } set{ m_RunicMinIntensity = value; } }
		public int RunicMaxIntensity{ get{ return m_RunicMaxIntensity; } set{ m_RunicMaxIntensity = value; } }

		public CraftAttributeInfo()
		{
		}

		public static readonly CraftAttributeInfo Blank;
		public static readonly CraftAttributeInfo DullCopper, ShadowIron, Copper, Bronze, Golden, Agapite, Verite, Valorite, Nepturite, Obsidian, Steel, Brass, Mithril, Xormite, Dwarven;
		public static readonly CraftAttributeInfo Spined, Horned, Barbed, Necrotic, Volcanic, Frozen, Goliath, Draconic, Hellish, Dinosaur, Alien;
		public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales, DinosaurScales;
		public static readonly CraftAttributeInfo AshTree, CherryTree, EbonyTree, GoldenOakTree, HickoryTree, MahoganyTree, OakTree, PineTree, GhostTree, RosewoodTree, WalnutTree, PetrifiedTree, DriftwoodTree, ElvenTree;

		static CraftAttributeInfo()
		{
			Blank = new CraftAttributeInfo();

			CraftAttributeInfo dullCopper = DullCopper = new CraftAttributeInfo();

			dullCopper.ArmorPhysicalResist = 6;
			dullCopper.ArmorDurability = 50;
			dullCopper.ArmorLowerRequirements = 20;
			dullCopper.WeaponDurability = 100;
			dullCopper.WeaponLowerRequirements = 50;
			dullCopper.RunicMinAttributes = 1;
			dullCopper.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				dullCopper.RunicMinIntensity = 40;
				dullCopper.RunicMaxIntensity = 100;
			}
			else
			{
				dullCopper.RunicMinIntensity = 10;
				dullCopper.RunicMaxIntensity = 35;
			}

			CraftAttributeInfo shadowIron = ShadowIron = new CraftAttributeInfo();

			shadowIron.ArmorPhysicalResist = 2;
			shadowIron.ArmorFireResist = 1;
			shadowIron.ArmorEnergyResist = 5;
			shadowIron.ArmorDurability = 100;
			shadowIron.WeaponColdDamage = 20;
			shadowIron.WeaponDurability = 50;
			shadowIron.RunicMinAttributes = 2;
			shadowIron.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				shadowIron.RunicMinIntensity = 45;
				shadowIron.RunicMaxIntensity = 100;
			}
			else
			{
				shadowIron.RunicMinIntensity = 20;
				shadowIron.RunicMaxIntensity = 45;
			}

			CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

			copper.ArmorPhysicalResist = 1;
			copper.ArmorFireResist = 1;
			copper.ArmorPoisonResist = 5;
			copper.ArmorEnergyResist = 2;
			copper.WeaponPoisonDamage = 10;
			copper.WeaponEnergyDamage = 20;
			copper.RunicMinAttributes = 2;
			copper.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				copper.RunicMinIntensity = 50;
				copper.RunicMaxIntensity = 100;
			}
			else
			{
				copper.RunicMinIntensity = 25;
				copper.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

			bronze.ArmorPhysicalResist = 3;
			bronze.ArmorColdResist = 5;
			bronze.ArmorPoisonResist = 1;
			bronze.ArmorEnergyResist = 1;
			bronze.WeaponFireDamage = 40;
			bronze.RunicMinAttributes = 3;
			bronze.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				bronze.RunicMinIntensity = 55;
				bronze.RunicMaxIntensity = 100;
			}
			else
			{
				bronze.RunicMinIntensity = 30;
				bronze.RunicMaxIntensity = 65;
			}

			CraftAttributeInfo golden = Golden = new CraftAttributeInfo();

			golden.ArmorPhysicalResist = 1;
			golden.ArmorFireResist = 1;
			golden.ArmorColdResist = 2;
			golden.ArmorEnergyResist = 2;
			golden.ArmorLuck = 40;
			golden.ArmorLowerRequirements = 30;
			golden.WeaponLuck = 40;
			golden.WeaponLowerRequirements = 50;
			golden.RunicMinAttributes = 3;
			golden.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				golden.RunicMinIntensity = 60;
				golden.RunicMaxIntensity = 100;
			}
			else
			{
				golden.RunicMinIntensity = 35;
				golden.RunicMaxIntensity = 75;
			}

			CraftAttributeInfo agapite = Agapite = new CraftAttributeInfo();

			agapite.ArmorPhysicalResist = 2;
			agapite.ArmorFireResist = 3;
			agapite.ArmorColdResist = 2;
			agapite.ArmorPoisonResist = 2;
			agapite.ArmorEnergyResist = 2;
			agapite.WeaponColdDamage = 30;
			agapite.WeaponEnergyDamage = 20;
			agapite.RunicMinAttributes = 4;
			agapite.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				agapite.RunicMinIntensity = 65;
				agapite.RunicMaxIntensity = 100;
			}
			else
			{
				agapite.RunicMinIntensity = 40;
				agapite.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

			verite.ArmorPhysicalResist = 3;
			verite.ArmorFireResist = 3;
			verite.ArmorColdResist = 2;
			verite.ArmorPoisonResist = 3;
			verite.ArmorEnergyResist = 1;
			verite.WeaponPoisonDamage = 40;
			verite.WeaponEnergyDamage = 20;
			verite.RunicMinAttributes = 4;
			verite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				verite.RunicMinIntensity = 70;
				verite.RunicMaxIntensity = 100;
			}
			else
			{
				verite.RunicMinIntensity = 45;
				verite.RunicMaxIntensity = 90;
			}

			CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

			valorite.ArmorPhysicalResist = 4;
			valorite.ArmorColdResist = 3;
			valorite.ArmorPoisonResist = 3;
			valorite.ArmorEnergyResist = 3;
			valorite.ArmorDurability = 50;
			valorite.WeaponFireDamage = 10;
			valorite.WeaponColdDamage = 20;
			valorite.WeaponPoisonDamage = 10;
			valorite.WeaponEnergyDamage = 20;
			valorite.RunicMinAttributes = 5;
			valorite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				valorite.RunicMinIntensity = 85;
				valorite.RunicMaxIntensity = 100;
			}
			else
			{
				valorite.RunicMinIntensity = 50;
				valorite.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo nepturite = Nepturite = new CraftAttributeInfo();

			nepturite.ArmorPhysicalResist = 8;
			nepturite.ArmorColdResist = 5;
			nepturite.ArmorPoisonResist = 5;
			nepturite.ArmorDurability = 50;
			nepturite.WeaponColdDamage = 25;
			nepturite.WeaponPoisonDamage = 25;
			nepturite.RunicMinAttributes = 5;
			nepturite.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				nepturite.RunicMinIntensity = 85;
				nepturite.RunicMaxIntensity = 100;
			}
			else
			{
				nepturite.RunicMinIntensity = 50;
				nepturite.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo obsidian = Obsidian = new CraftAttributeInfo();

			obsidian.ArmorPhysicalResist = 6;
			obsidian.ArmorColdResist = 2;
			obsidian.ArmorPoisonResist = 2;
			obsidian.ArmorFireResist = 6;
			obsidian.ArmorEnergyResist = 2;
			obsidian.ArmorDurability = 50;
			obsidian.WeaponFireDamage = 20;
			obsidian.WeaponEnergyDamage = 10;
			obsidian.RunicMinAttributes = 5;
			obsidian.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				obsidian.RunicMinIntensity = 85;
				obsidian.RunicMaxIntensity = 100;
			}
			else
			{
				obsidian.RunicMinIntensity = 50;
				obsidian.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo steel = Steel = new CraftAttributeInfo();

			steel.ArmorPhysicalResist = 6;
			steel.ArmorColdResist = 5;
			steel.ArmorPoisonResist = 5;
			steel.ArmorEnergyResist = 5;
			steel.ArmorDurability = 65;
			steel.RunicMinAttributes = 6;
			steel.RunicMaxAttributes = 7;
			steel.WeaponDurability = 50;
			steel.WeaponLowerRequirements = 25;
			steel.ArmorDurability = 50;
			steel.ArmorLowerRequirements = 25;
			if ( Core.ML )
			{
				steel.RunicMinIntensity = 85;
				steel.RunicMaxIntensity = 100;
			}
			else
			{
				steel.RunicMinIntensity = 50;
				steel.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo brass = Brass = new CraftAttributeInfo();

			brass.ArmorPhysicalResist = 8;
			brass.ArmorColdResist = 7;
			brass.ArmorPoisonResist = 7;
			brass.ArmorEnergyResist = 7;
			brass.ArmorDurability = 80;
			brass.WeaponFireDamage = 20;
			brass.WeaponEnergyDamage = 20;
			brass.RunicMinAttributes = 8;
			brass.RunicMaxAttributes = 9;
			brass.WeaponDurability = 30;
			brass.WeaponLowerRequirements = 45;
			brass.ArmorDurability = 30;
			brass.ArmorLowerRequirements = 45;
			if ( Core.ML )
			{
				brass.RunicMinIntensity = 85;
				brass.RunicMaxIntensity = 100;
			}
			else
			{
				brass.RunicMinIntensity = 50;
				brass.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo mithril = Mithril = new CraftAttributeInfo();

			mithril.ArmorPhysicalResist = 10;
			mithril.ArmorColdResist = 9;
			mithril.ArmorLuck = 100;
			mithril.WeaponLuck = 100;
			mithril.ArmorPoisonResist = 9;
			mithril.ArmorEnergyResist = 9;
			mithril.ArmorDurability = 100;
			mithril.WeaponEnergyDamage = 30;
			mithril.RunicMinAttributes = 10;
			mithril.RunicMaxAttributes = 11;
			mithril.WeaponDurability = 100;
			mithril.WeaponLowerRequirements = 75;
			mithril.ArmorLowerRequirements = 75;
			if ( Core.ML )
			{
				mithril.RunicMinIntensity = 85;
				mithril.RunicMaxIntensity = 100;
			}
			else
			{
				mithril.RunicMinIntensity = 50;
				mithril.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo dwarven = Dwarven = new CraftAttributeInfo();

			dwarven.ArmorPhysicalResist = 20;
			dwarven.ArmorFireResist = 10;
			dwarven.ArmorColdResist = 10;
			dwarven.ArmorDurability = 100;
			dwarven.RunicMinAttributes = 20;
			dwarven.RunicMaxAttributes = 22;
			dwarven.WeaponDurability = 100;
			if ( Core.ML )
			{
				dwarven.RunicMinIntensity = 170;
				dwarven.RunicMaxIntensity = 200;
			}
			else
			{
				dwarven.RunicMinIntensity = 100;
				dwarven.RunicMaxIntensity = 200;
			}

			CraftAttributeInfo xormite = Xormite = new CraftAttributeInfo();

			xormite.ArmorPhysicalResist = 10;
			xormite.ArmorColdResist = 9;
			xormite.ArmorPoisonResist = 9;
			xormite.ArmorFireResist = 9;
			xormite.ArmorEnergyResist = 12;
			xormite.ArmorDurability = 100;
			xormite.WeaponEnergyDamage = 30;
			xormite.RunicMinAttributes = 10;
			xormite.RunicMaxAttributes = 11;
			xormite.WeaponDurability = 100;
			xormite.WeaponLowerRequirements = 75;
			xormite.ArmorDurability = 100;
			xormite.ArmorLowerRequirements = 75;
			if ( Core.ML )
			{
				xormite.RunicMinIntensity = 85;
				xormite.RunicMaxIntensity = 100;
			}
			else
			{
				xormite.RunicMinIntensity = 50;
				xormite.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo spined = Spined = new CraftAttributeInfo();

			spined.ArmorDurability = 40;
			spined.WeaponDurability = 40;
			spined.ArmorPhysicalResist = 4;
			spined.ArmorFireResist = 1;
			spined.ArmorColdResist = 5;
			spined.ArmorPoisonResist = 5;
			spined.ArmorEnergyResist = 3;
			spined.ArmorLuck = 40;
			spined.WeaponLuck = 40;
			spined.WeaponPoisonDamage = 20;
			spined.RunicMinAttributes = 1;
			spined.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				spined.RunicMinIntensity = 40;
				spined.RunicMaxIntensity = 100;
			}
			else
			{
				spined.RunicMinIntensity = 20;
				spined.RunicMaxIntensity = 40;
			}

			CraftAttributeInfo horned = Horned = new CraftAttributeInfo();

			horned.ArmorDurability = 10;
			horned.WeaponDurability = 10;
			horned.ArmorPhysicalResist = 3;
			horned.ArmorFireResist = 2;
			horned.ArmorColdResist = 2;
			horned.ArmorPoisonResist = 2;
			horned.ArmorEnergyResist = 2;
			horned.RunicMinAttributes = 3;
			horned.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				horned.RunicMinIntensity = 45;
				horned.RunicMaxIntensity = 100;
			}
			else
			{
				horned.RunicMinIntensity = 30;
				horned.RunicMaxIntensity = 70;
			}

			CraftAttributeInfo barbed = Barbed = new CraftAttributeInfo();

			barbed.ArmorDurability = 20;
			barbed.WeaponDurability = 20;
			barbed.ArmorPhysicalResist = 3;
			barbed.ArmorFireResist = 2;
			barbed.ArmorColdResist = 2;
			barbed.ArmorPoisonResist = 6;
			barbed.ArmorEnergyResist = 3;
			barbed.WeaponPoisonDamage = 70;
			barbed.RunicMinAttributes = 4;
			barbed.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				barbed.RunicMinIntensity = 50;
				barbed.RunicMaxIntensity = 100;
			}
			else
			{
				barbed.RunicMinIntensity = 40;
				barbed.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo necrotic = Necrotic = new CraftAttributeInfo();

			necrotic.ArmorDurability = 30;
			necrotic.WeaponDurability = 30;
			necrotic.ArmorPhysicalResist = 3;
			necrotic.ArmorFireResist = 1;
			necrotic.ArmorColdResist = 3;
			necrotic.ArmorPoisonResist = 5;
			necrotic.ArmorEnergyResist = 2;
			necrotic.WeaponFireDamage = 50;
			necrotic.RunicMinAttributes = 5;
			necrotic.RunicMaxAttributes = 6;
			if ( Core.ML )
			{
				necrotic.RunicMinIntensity = 50;
				necrotic.RunicMaxIntensity = 100;
			}
			else
			{
				necrotic.RunicMinIntensity = 40;
				necrotic.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo volcanic = Volcanic = new CraftAttributeInfo();

			volcanic.ArmorDurability = 50;
			volcanic.WeaponDurability = 50;
			volcanic.ArmorPhysicalResist = 5;
			volcanic.ArmorFireResist = 6;
			volcanic.ArmorColdResist = 1;
			volcanic.ArmorPoisonResist = 3;
			volcanic.ArmorEnergyResist = 3;
			volcanic.WeaponFireDamage = 50;
			volcanic.RunicMinAttributes = 6;
			volcanic.RunicMaxAttributes = 7;
			if ( Core.ML )
			{
				volcanic.RunicMinIntensity = 50;
				volcanic.RunicMaxIntensity = 100;
			}
			else
			{
				volcanic.RunicMinIntensity = 40;
				volcanic.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo frozen = Frozen = new CraftAttributeInfo();

			frozen.ArmorDurability = 50;
			frozen.WeaponDurability = 50;
			frozen.ArmorPhysicalResist = 5;
			frozen.ArmorFireResist = 1;
			frozen.ArmorColdResist = 6;
			frozen.ArmorPoisonResist = 3;
			frozen.ArmorEnergyResist = 3;
			frozen.WeaponColdDamage = 50;
			frozen.RunicMinAttributes = 6;
			frozen.RunicMaxAttributes = 7;
			if ( Core.ML )
			{
				frozen.RunicMinIntensity = 50;
				frozen.RunicMaxIntensity = 100;
			}
			else
			{
				frozen.RunicMinIntensity = 40;
				frozen.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo goliath = Goliath = new CraftAttributeInfo();

			goliath.ArmorDurability = 60;
			goliath.WeaponDurability = 60;
			goliath.ArmorPhysicalResist = 6;
			goliath.ArmorFireResist = 3;
			goliath.ArmorColdResist = 3;
			goliath.ArmorPoisonResist = 4;
			goliath.ArmorEnergyResist = 7;
			goliath.WeaponEnergyDamage = 25;
			goliath.RunicMinAttributes = 7;
			goliath.RunicMaxAttributes = 8;
			if ( Core.ML )
			{
				goliath.RunicMinIntensity = 50;
				goliath.RunicMaxIntensity = 100;
			}
			else
			{
				goliath.RunicMinIntensity = 40;
				goliath.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo draconic = Draconic = new CraftAttributeInfo();

			draconic.ArmorDurability = 70;
			draconic.WeaponDurability = 70;
			draconic.ArmorPhysicalResist = 7;
			draconic.ArmorFireResist = 6;
			draconic.ArmorColdResist = 6;
			draconic.ArmorPoisonResist = 6;
			draconic.ArmorEnergyResist = 6;
			draconic.WeaponFireDamage = 25;
			draconic.RunicMinAttributes = 8;
			draconic.RunicMaxAttributes = 9;
			if ( Core.ML )
			{
				draconic.RunicMinIntensity = 50;
				draconic.RunicMaxIntensity = 100;
			}
			else
			{
				draconic.RunicMinIntensity = 40;
				draconic.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo hellish = Hellish = new CraftAttributeInfo();

			hellish.ArmorDurability = 80;
			hellish.WeaponDurability = 80;
			hellish.ArmorPhysicalResist = 8;
			hellish.ArmorFireResist = 7;
			hellish.ArmorColdResist = 7;
			hellish.ArmorPoisonResist = 7;
			hellish.ArmorEnergyResist = 7;
			hellish.WeaponFireDamage = 50;
			hellish.RunicMinAttributes = 10;
			hellish.RunicMaxAttributes = 11;
			if ( Core.ML )
			{
				hellish.RunicMinIntensity = 50;
				hellish.RunicMaxIntensity = 100;
			}
			else
			{
				hellish.RunicMinIntensity = 40;
				hellish.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo dinosaur = Dinosaur = new CraftAttributeInfo();

			dinosaur.ArmorDurability = 100;
			dinosaur.WeaponDurability = 100;
			dinosaur.ArmorPhysicalResist = 9;
			dinosaur.ArmorFireResist = 8;
			dinosaur.ArmorColdResist = 8;
			dinosaur.ArmorPoisonResist = 8;
			dinosaur.ArmorEnergyResist = 8;
			dinosaur.RunicMinAttributes = 11;
			dinosaur.RunicMaxAttributes = 12;
			if ( Core.ML )
			{
				dinosaur.RunicMinIntensity = 50;
				dinosaur.RunicMaxIntensity = 100;
			}
			else
			{
				dinosaur.RunicMinIntensity = 40;
				dinosaur.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo alien = Alien = new CraftAttributeInfo();

			alien.ArmorDurability = 100;
			alien.WeaponDurability = 100;
			alien.ArmorPhysicalResist = 9;
			alien.ArmorFireResist = 8;
			alien.ArmorColdResist = 8;
			alien.ArmorPoisonResist = 8;
			alien.ArmorEnergyResist = 8;
			alien.RunicMinAttributes = 11;
			alien.RunicMaxAttributes = 12;
			if ( Core.ML )
			{
				alien.RunicMinIntensity = 50;
				alien.RunicMaxIntensity = 100;
			}
			else
			{
				alien.RunicMinIntensity = 40;
				alien.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo red = RedScales = new CraftAttributeInfo();

			red.ArmorPhysicalResist = 7;
			red.ArmorFireResist = 7;
			red.ArmorColdResist = 3;
			red.ArmorPoisonResist = 3;
			red.ArmorEnergyResist = 3;

			CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

			yellow.ArmorPhysicalResist = 7;
			yellow.ArmorFireResist = 5;
			yellow.ArmorColdResist = 3;
			yellow.ArmorPoisonResist = 3;
			yellow.ArmorEnergyResist = 5;

			CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

			black.ArmorPhysicalResist = 7;
			black.ArmorFireResist = 3;
			black.ArmorColdResist = 3;
			black.ArmorPoisonResist = 7;
			black.ArmorEnergyResist = 3;

			CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

			green.ArmorPhysicalResist = 7;
			green.ArmorFireResist = 7;
			green.ArmorColdResist = 3;
			green.ArmorPoisonResist = 3;
			green.ArmorEnergyResist = 3;

			CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

			white.ArmorPhysicalResist = 7;
			white.ArmorFireResist = 3;
			white.ArmorColdResist = 7;
			white.ArmorPoisonResist = 3;
			white.ArmorEnergyResist = 3;

			CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

			blue.ArmorPhysicalResist = 7;
			blue.ArmorFireResist = 3;
			blue.ArmorColdResist = 3;
			blue.ArmorPoisonResist = 5;
			blue.ArmorEnergyResist = 5;

			CraftAttributeInfo dino = DinosaurScales = new CraftAttributeInfo();

			dino.ArmorPhysicalResist = 9;
			dino.ArmorFireResist = 3;
			dino.ArmorColdResist = 3;
			dino.ArmorPoisonResist = 3;
			dino.ArmorEnergyResist = 3;

			CraftAttributeInfo ashtree = AshTree = new CraftAttributeInfo();

			ashtree.ArmorPhysicalResist = 2;
			ashtree.ArmorFireResist = 3;
			ashtree.ArmorColdResist = 2;
			ashtree.ArmorPoisonResist = 2;
			ashtree.ArmorEnergyResist = 2;
			ashtree.WeaponFireDamage = 5;
			ashtree.WeaponColdDamage = 5;
			ashtree.WeaponPoisonDamage = 5;
			ashtree.WeaponEnergyDamage = 5;
			ashtree.RunicMinAttributes = 3;
			ashtree.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				ashtree.RunicMinIntensity = 45;
				ashtree.RunicMaxIntensity = 100;
			}
			else
			{
				ashtree.RunicMinIntensity = 30;
				ashtree.RunicMaxIntensity = 70;
			}

			CraftAttributeInfo cherrytree = CherryTree = new CraftAttributeInfo();

			cherrytree.ArmorPhysicalResist = 2;
			cherrytree.ArmorFireResist = 1;
			cherrytree.ArmorColdResist = 2;
			cherrytree.ArmorPoisonResist = 3;
			cherrytree.ArmorEnergyResist = 4;
			cherrytree.WeaponPoisonDamage = 10;
			cherrytree.WeaponEnergyDamage = 20;
			cherrytree.RunicMinAttributes = 4;
			cherrytree.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				cherrytree.RunicMinIntensity = 50;
				cherrytree.RunicMaxIntensity = 100;
			}
			else
			{
				cherrytree.RunicMinIntensity = 40;
				cherrytree.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo ebonytree = EbonyTree = new CraftAttributeInfo();

			ebonytree.ArmorPhysicalResist = 2;
			ebonytree.ArmorFireResist = 1;
			ebonytree.ArmorEnergyResist = 5;
			ebonytree.ArmorDurability = 100;
			ebonytree.WeaponColdDamage = 20;
			ebonytree.WeaponDurability = 50;
			ebonytree.RunicMinAttributes = 2;
			ebonytree.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				ebonytree.RunicMinIntensity = 45;
				ebonytree.RunicMaxIntensity = 100;
			}
			else
			{
				ebonytree.RunicMinIntensity = 20;
				ebonytree.RunicMaxIntensity = 45;
			}

			CraftAttributeInfo goldenoaktree = GoldenOakTree = new CraftAttributeInfo();

			goldenoaktree.ArmorPhysicalResist = 1;
			goldenoaktree.ArmorFireResist = 1;
			goldenoaktree.ArmorColdResist = 2;
			goldenoaktree.ArmorEnergyResist = 2;
			goldenoaktree.ArmorLuck = 40;
			goldenoaktree.ArmorLowerRequirements = 30;
			goldenoaktree.WeaponLuck = 40;
			goldenoaktree.WeaponLowerRequirements = 50;
			goldenoaktree.RunicMinAttributes = 3;
			goldenoaktree.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				goldenoaktree.RunicMinIntensity = 60;
				goldenoaktree.RunicMaxIntensity = 100;
			}
			else
			{
				goldenoaktree.RunicMinIntensity = 35;
				goldenoaktree.RunicMaxIntensity = 75;
			}

			CraftAttributeInfo hickorytree = HickoryTree = new CraftAttributeInfo();

			hickorytree.ArmorPhysicalResist = 6;
			hickorytree.ArmorDurability = 50;
			hickorytree.ArmorLowerRequirements = 20;
			hickorytree.WeaponDurability = 100;
			hickorytree.WeaponLowerRequirements = 50;
			hickorytree.RunicMinAttributes = 1;
			hickorytree.RunicMaxAttributes = 2;
			if ( Core.ML )
			{
				hickorytree.RunicMinIntensity = 40;
				hickorytree.RunicMaxIntensity = 100;
			}
			else
			{
				hickorytree.RunicMinIntensity = 10;
				hickorytree.RunicMaxIntensity = 35;
			}

			CraftAttributeInfo mahoganytree = MahoganyTree = new CraftAttributeInfo();

			mahoganytree.ArmorPhysicalResist = 1;
			mahoganytree.ArmorFireResist = 1;
			mahoganytree.ArmorPoisonResist = 5;
			mahoganytree.ArmorEnergyResist = 2;
			mahoganytree.WeaponPoisonDamage = 10;
			mahoganytree.WeaponEnergyDamage = 20;
			mahoganytree.RunicMinAttributes = 2;
			mahoganytree.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				mahoganytree.RunicMinIntensity = 50;
				mahoganytree.RunicMaxIntensity = 100;
			}
			else
			{
				mahoganytree.RunicMinIntensity = 25;
				mahoganytree.RunicMaxIntensity = 50;
			}

			CraftAttributeInfo oaktree = OakTree = new CraftAttributeInfo();

			oaktree.ArmorPhysicalResist = 3;
			oaktree.ArmorColdResist = 5;
			oaktree.ArmorPoisonResist = 1;
			oaktree.ArmorEnergyResist = 1;
			oaktree.WeaponFireDamage = 40;
			oaktree.RunicMinAttributes = 3;
			oaktree.RunicMaxAttributes = 3;
			if ( Core.ML )
			{
				oaktree.RunicMinIntensity = 55;
				oaktree.RunicMaxIntensity = 100;
			}
			else
			{
				oaktree.RunicMinIntensity = 30;
				oaktree.RunicMaxIntensity = 65;
			}

			CraftAttributeInfo pinetree = PineTree = new CraftAttributeInfo();

			pinetree.ArmorPhysicalResist = 2;
			pinetree.ArmorFireResist = 3;
			pinetree.ArmorColdResist = 2;
			pinetree.ArmorPoisonResist = 2;
			pinetree.ArmorEnergyResist = 2;
			pinetree.WeaponColdDamage = 30;
			pinetree.WeaponEnergyDamage = 20;
			pinetree.RunicMinAttributes = 4;
			pinetree.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				pinetree.RunicMinIntensity = 65;
				pinetree.RunicMaxIntensity = 100;
			}
			else
			{
				pinetree.RunicMinIntensity = 40;
				pinetree.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo ghosttree = GhostTree = new CraftAttributeInfo();

			ghosttree.ArmorPhysicalResist = 2;
			ghosttree.ArmorFireResist = 2;
			ghosttree.ArmorColdResist = 3;
			ghosttree.ArmorPoisonResist = 3;
			ghosttree.ArmorEnergyResist = 3;
			ghosttree.WeaponColdDamage = 25;
			ghosttree.WeaponEnergyDamage = 25;
			ghosttree.RunicMinAttributes = 4;
			ghosttree.RunicMaxAttributes = 4;
			if ( Core.ML )
			{
				ghosttree.RunicMinIntensity = 65;
				ghosttree.RunicMaxIntensity = 100;
			}
			else
			{
				ghosttree.RunicMinIntensity = 40;
				ghosttree.RunicMaxIntensity = 80;
			}

			CraftAttributeInfo rosewoodtree = RosewoodTree = new CraftAttributeInfo();

			rosewoodtree.ArmorPhysicalResist = 3;
			rosewoodtree.ArmorFireResist = 3;
			rosewoodtree.ArmorColdResist = 2;
			rosewoodtree.ArmorPoisonResist = 3;
			rosewoodtree.ArmorEnergyResist = 1;
			rosewoodtree.WeaponPoisonDamage = 40;
			rosewoodtree.WeaponEnergyDamage = 20;
			rosewoodtree.RunicMinAttributes = 4;
			rosewoodtree.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				rosewoodtree.RunicMinIntensity = 70;
				rosewoodtree.RunicMaxIntensity = 100;
			}
			else
			{
				rosewoodtree.RunicMinIntensity = 45;
				rosewoodtree.RunicMaxIntensity = 90;
			}

			CraftAttributeInfo walnuttree = WalnutTree = new CraftAttributeInfo();

			walnuttree.ArmorPhysicalResist = 4;
			walnuttree.ArmorColdResist = 3;
			walnuttree.ArmorPoisonResist = 3;
			walnuttree.ArmorEnergyResist = 3;
			walnuttree.ArmorDurability = 50;
			walnuttree.WeaponFireDamage = 10;
			walnuttree.WeaponColdDamage = 20;
			walnuttree.WeaponPoisonDamage = 10;
			walnuttree.WeaponEnergyDamage = 20;
			walnuttree.RunicMinAttributes = 5;
			walnuttree.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				walnuttree.RunicMinIntensity = 85;
				walnuttree.RunicMaxIntensity = 100;
			}
			else
			{
				walnuttree.RunicMinIntensity = 50;
				walnuttree.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo petrifiedtree = PetrifiedTree = new CraftAttributeInfo();

			petrifiedtree.ArmorPhysicalResist = 8;
			petrifiedtree.ArmorColdResist = 2;
			petrifiedtree.ArmorPoisonResist = 2;
			petrifiedtree.ArmorEnergyResist = 2;
			petrifiedtree.ArmorFireResist = 2;
			petrifiedtree.ArmorDurability = 70;
			petrifiedtree.WeaponColdDamage = 25;
			petrifiedtree.RunicMinAttributes = 5;
			petrifiedtree.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				petrifiedtree.RunicMinIntensity = 85;
				petrifiedtree.RunicMaxIntensity = 100;
			}
			else
			{
				walnuttree.RunicMinIntensity = 50;
				walnuttree.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo driftwoodtree = DriftwoodTree = new CraftAttributeInfo();

			driftwoodtree.ArmorPhysicalResist = 4;
			driftwoodtree.ArmorColdResist = 2;
			driftwoodtree.ArmorPoisonResist = 5;
			driftwoodtree.ArmorEnergyResist = 2;
			driftwoodtree.ArmorDurability = 50;
			driftwoodtree.WeaponFireDamage = 10;
			driftwoodtree.WeaponColdDamage = 10;
			driftwoodtree.WeaponPoisonDamage = 20;
			driftwoodtree.WeaponEnergyDamage = 10;
			driftwoodtree.RunicMinAttributes = 5;
			driftwoodtree.RunicMaxAttributes = 5;
			if ( Core.ML )
			{
				driftwoodtree.RunicMinIntensity = 85;
				driftwoodtree.RunicMaxIntensity = 100;
			}
			else
			{
				driftwoodtree.RunicMinIntensity = 50;
				driftwoodtree.RunicMaxIntensity = 100;
			}

			CraftAttributeInfo elventree = ElvenTree = new CraftAttributeInfo();

			elventree.ArmorPhysicalResist = 8;
			elventree.ArmorColdResist = 6;
			elventree.ArmorPoisonResist = 6;
			elventree.ArmorEnergyResist = 6;
			elventree.ArmorDurability = 100;
			elventree.ArmorLuck = 100;
			elventree.WeaponLuck = 100;
			elventree.WeaponFireDamage = 0;
			elventree.WeaponColdDamage = 0;
			elventree.WeaponPoisonDamage = 0;
			elventree.WeaponEnergyDamage = 0;
			elventree.RunicMinAttributes = 10;
			elventree.RunicMaxAttributes = 10;
			if ( Core.ML )
			{
				elventree.RunicMinIntensity = 170;
				elventree.RunicMaxIntensity = 200;
			}
			else
			{
				elventree.RunicMinIntensity = 100;
				elventree.RunicMaxIntensity = 200;
			}
		}
	}

	public class CraftResourceInfo
	{
		private int m_Hue;
		private int m_Number;
		private string m_Name;
		private CraftAttributeInfo m_AttributeInfo;
		private CraftResource m_Resource;
		private Type[] m_ResourceTypes;

		public int Hue{ get{ return m_Hue; } }
		public int Number{ get{ return m_Number; } }
		public string Name{ get{ return m_Name; } }
		public CraftAttributeInfo AttributeInfo{ get{ return m_AttributeInfo; } }
		public CraftResource Resource{ get{ return m_Resource; } }
		public Type[] ResourceTypes{ get{ return m_ResourceTypes; } }

		public CraftResourceInfo( int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes )
		{
			m_Hue = hue;
			m_Number = number;
			m_Name = name;
			m_AttributeInfo = attributeInfo;
			m_Resource = resource;
			m_ResourceTypes = resourceTypes;

			for ( int i = 0; i < resourceTypes.Length; ++i )
				CraftResources.RegisterType( resourceTypes[i], resource );
		}
	}

	public class CraftResources
	{
		private static CraftResourceInfo[] m_MetalInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 													1053109, "Iron",		CraftAttributeInfo.Blank,		CraftResource.Iron,				typeof( IronIngot ),		typeof( IronOre ),			typeof( Granite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "dull copper", "", 0 ), 	1053108, "Dull Copper",	CraftAttributeInfo.DullCopper,	CraftResource.DullCopper,		typeof( DullCopperIngot ),	typeof( DullCopperOre ),	typeof( DullCopperGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "shadow iron", "", 0 ), 	1053107, "Shadow Iron",	CraftAttributeInfo.ShadowIron,	CraftResource.ShadowIron,		typeof( ShadowIronIngot ),	typeof( ShadowIronOre ),	typeof( ShadowIronGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "copper", "", 0 ), 		1053106, "Copper",		CraftAttributeInfo.Copper,		CraftResource.Copper,			typeof( CopperIngot ),		typeof( CopperOre ),		typeof( CopperGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "bronze", "", 0 ), 		1053105, "Bronze",		CraftAttributeInfo.Bronze,		CraftResource.Bronze,			typeof( BronzeIngot ),		typeof( BronzeOre ),		typeof( BronzeGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "gold", "", 0 ), 			1053104, "Gold",		CraftAttributeInfo.Golden,		CraftResource.Gold,				typeof( GoldIngot ),		typeof( GoldOre ),			typeof( GoldGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "agapite", "", 0 ), 		1053103, "Agapite",		CraftAttributeInfo.Agapite,		CraftResource.Agapite,			typeof( AgapiteIngot ),		typeof( AgapiteOre ),		typeof( AgapiteGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "verite", "", 0 ), 		1053102, "Verite",		CraftAttributeInfo.Verite,		CraftResource.Verite,			typeof( VeriteIngot ),		typeof( VeriteOre ),		typeof( VeriteGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "valorite", "", 0 ), 		1053101, "Valorite",	CraftAttributeInfo.Valorite,	CraftResource.Valorite,			typeof( ValoriteIngot ),	typeof( ValoriteOre ),		typeof( ValoriteGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "nepturite", "", 0 ), 	1036175, "Nepturite",	CraftAttributeInfo.Nepturite,	CraftResource.Nepturite,		typeof( NepturiteIngot ),	typeof( NepturiteOre ),		typeof( NepturiteGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "obsidian", "", 0 ), 		1036165, "Obsidian",	CraftAttributeInfo.Obsidian,	CraftResource.Obsidian,			typeof( ObsidianIngot ),	typeof( ObsidianOre ),		typeof( ObsidianGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "steel", "", 0 ), 		1036146, "Steel",		CraftAttributeInfo.Steel,		CraftResource.Steel,			typeof( SteelIngot ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "brass", "", 0 ), 		1036154, "Brass",		CraftAttributeInfo.Brass,		CraftResource.Brass,			typeof( BrassIngot ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "mithril", "", 0 ), 		1036139, "Mithril",		CraftAttributeInfo.Mithril,		CraftResource.Mithril,			typeof( MithrilIngot ),		typeof( MithrilOre ),		typeof( MithrilGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "xormite", "", 0 ), 		1034439, "Xormite",		CraftAttributeInfo.Xormite,		CraftResource.Xormite,			typeof( XormiteIngot ),		typeof( XormiteOre ),		typeof( XormiteGranite ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "dwarven", "", 0 ), 		1036183, "Dwarven",		CraftAttributeInfo.Dwarven,		CraftResource.Dwarven,			typeof( DwarvenIngot ),		typeof( DwarvenOre ),		typeof( DwarvenGranite ) )
			};

		private static CraftResourceInfo[] m_ScaleInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x66D, 1053129, "Red Scales",		CraftAttributeInfo.RedScales,		CraftResource.RedScales,		typeof( RedScales ) ),
				new CraftResourceInfo( 0x8A8, 1053130, "Yellow Scales",		CraftAttributeInfo.YellowScales,	CraftResource.YellowScales,		typeof( YellowScales ) ),
				new CraftResourceInfo( 0x455, 1053131, "Black Scales",		CraftAttributeInfo.BlackScales,		CraftResource.BlackScales,		typeof( BlackScales ) ),
				new CraftResourceInfo( 0x851, 1053132, "Green Scales",		CraftAttributeInfo.GreenScales,		CraftResource.GreenScales,		typeof( GreenScales ) ),
				new CraftResourceInfo( 0x8FD, 1053133, "White Scales",		CraftAttributeInfo.WhiteScales,		CraftResource.WhiteScales,		typeof( WhiteScales ) ),
				new CraftResourceInfo( 0x8B0, 1053134, "Blue Scales",		CraftAttributeInfo.BlueScales,		CraftResource.BlueScales,		typeof( BlueScales ) ),
				new CraftResourceInfo( 0x430, 1054016, "Dinosaur Scales",	CraftAttributeInfo.DinosaurScales,	CraftResource.DinosaurScales,	typeof( DinosaurScales ) )
			};

		private static CraftResourceInfo[] m_AOSLeatherInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 												1049353, "Normal",		CraftAttributeInfo.Blank,		CraftResource.RegularLeather,	typeof( Leather ),			typeof( Hides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "deep sea", "", 0 ), 	1049354, "Deep Sea",	CraftAttributeInfo.Spined,		CraftResource.SpinedLeather,	typeof( SpinedLeather ),	typeof( SpinedHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "lizard", "", 0 ), 	1049355, "Lizard",		CraftAttributeInfo.Horned,		CraftResource.HornedLeather,	typeof( HornedLeather ),	typeof( HornedHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "serpent", "", 0 ), 	1049356, "Serpent",		CraftAttributeInfo.Barbed,		CraftResource.BarbedLeather,	typeof( BarbedLeather ),	typeof( BarbedHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "necrotic", "", 0 ), 	1034404, "Necrotic",	CraftAttributeInfo.Necrotic,	CraftResource.NecroticLeather,	typeof( NecroticLeather ),	typeof( NecroticHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "volcanic", "", 0 ), 	1034415, "Volcanic",	CraftAttributeInfo.Volcanic,	CraftResource.VolcanicLeather,	typeof( VolcanicLeather ),	typeof( VolcanicHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "frozen", "", 0 ), 	1034426, "Frozen",		CraftAttributeInfo.Frozen,		CraftResource.FrozenLeather,	typeof( FrozenLeather ),	typeof( FrozenHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "goliath", "", 0 ), 	1034371, "Goliath",		CraftAttributeInfo.Goliath,		CraftResource.GoliathLeather,	typeof( GoliathLeather ),	typeof( GoliathHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "draconic", "", 0 ), 	1034382, "Draconic",	CraftAttributeInfo.Draconic,	CraftResource.DraconicLeather,	typeof( DraconicLeather ),	typeof( DraconicHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "hellish", "", 0 ), 	1034393, "Hellish",		CraftAttributeInfo.Hellish,		CraftResource.HellishLeather,	typeof( HellishLeather ),	typeof( HellishHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "dinosaur", "", 0 ), 	1036105, "Dinosaur",	CraftAttributeInfo.Dinosaur,	CraftResource.DinosaurLeather,	typeof( DinosaurLeather ),	typeof( DinosaurHides ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "alien", "", 0 ), 	1034445, "Alien",		CraftAttributeInfo.Alien,		CraftResource.AlienLeather,		typeof( AlienLeather ),		typeof( AlienHides ) )
			};

		private static CraftResourceInfo[] m_WoodInfo = new CraftResourceInfo[]
			{
				new CraftResourceInfo( 0x000, 													1011542,	"Normal",		CraftAttributeInfo.Blank,			CraftResource.RegularWood,		typeof( Log ),			typeof( Board ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "ash", "", 0 ),			1095399,	"Ash",			CraftAttributeInfo.AshTree,			CraftResource.AshTree,			typeof( AshLog ),		typeof( AshBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "cherry", "", 0 ),		1095400,	"Cherry",		CraftAttributeInfo.CherryTree,		CraftResource.CherryTree,		typeof( CherryLog ),	typeof( CherryBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "ebony", "", 0 ),			1095401,	"Ebony",		CraftAttributeInfo.EbonyTree,		CraftResource.EbonyTree,		typeof( EbonyLog ),		typeof( EbonyBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "golden oak", "", 0 ),	1095402,	"Golden Oak",	CraftAttributeInfo.GoldenOakTree,	CraftResource.GoldenOakTree,	typeof( GoldenOakLog ),	typeof( GoldenOakBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "hickory", "", 0 ),		1095403,	"Hickory",		CraftAttributeInfo.HickoryTree,		CraftResource.HickoryTree,		typeof( HickoryLog ),	typeof( HickoryBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "mahogany", "", 0 ),		1095404,	"Mahogany",		CraftAttributeInfo.MahoganyTree,	CraftResource.MahoganyTree,		typeof( MahoganyLog ),	typeof( MahoganyBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "oak", "", 0 ),			1095405,	"Oak",			CraftAttributeInfo.OakTree,			CraftResource.OakTree,			typeof( OakLog ),		typeof( OakBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "pine", "", 0 ),			1095406,	"Pine",			CraftAttributeInfo.PineTree,		CraftResource.PineTree,			typeof( PineLog ),		typeof( PineBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "ghostwood", "", 0 ),		1095513,	"Ghostwood",	CraftAttributeInfo.GhostTree,		CraftResource.GhostTree,		typeof( GhostLog ),		typeof( GhostBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "rosewood", "", 0 ),		1095407,	"Rosewood",		CraftAttributeInfo.RosewoodTree,	CraftResource.RosewoodTree,		typeof( RosewoodLog ),	typeof( RosewoodBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "walnut", "", 0 ),		1095408,	"Walnut",		CraftAttributeInfo.WalnutTree,		CraftResource.WalnutTree,		typeof( WalnutLog ),	typeof( WalnutBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "petrified", "", 0 ),		1095534,	"Petrified",	CraftAttributeInfo.PetrifiedTree,	CraftResource.PetrifiedTree,	typeof( PetrifiedLog ),	typeof( PetrifiedBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "driftwood", "", 0 ),		1095510,	"Driftwood",	CraftAttributeInfo.DriftwoodTree,	CraftResource.DriftwoodTree,	typeof( DriftwoodLog ),	typeof( DriftwoodBoard ) ),
				new CraftResourceInfo( MaterialInfo.GetMaterialColor( "elven", "", 0 ),			1095537,	"Elven",		CraftAttributeInfo.ElvenTree,		CraftResource.ElvenTree,		typeof( ElvenLog ),		typeof( ElvenBoard ) )
			};

		/// <summary>
		/// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
		/// </summary>
		public static bool IsStandard( CraftResource resource )
		{
			return ( resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood );
		}

		private static Hashtable m_TypeTable;

		/// <summary>
		/// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="CraftResources.GetFromType"/>
		/// </summary>
		public static void RegisterType( Type resourceType, CraftResource resource )
		{
			if ( m_TypeTable == null )
				m_TypeTable = new Hashtable();

			m_TypeTable[resourceType] = resource;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
		/// </summary>
		public static CraftResource GetFromType( Type resourceType )
		{
			if ( m_TypeTable == null )
				return CraftResource.None;

			object obj = m_TypeTable[resourceType];

			if ( !(obj is CraftResource) )
				return CraftResource.None;

			return (CraftResource)obj;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
		/// </summary>
		public static CraftResourceInfo GetInfo( CraftResource resource )
		{
			CraftResourceInfo[] list = null;

			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: list = m_MetalInfo; break;
				case CraftResourceType.Leather: list = m_AOSLeatherInfo; break;
				case CraftResourceType.Scales: list = m_ScaleInfo; break;
				case CraftResourceType.Wood: list = m_WoodInfo; break;
			}

			if ( list != null )
			{
				int index = GetIndex( resource );

				if ( index >= 0 && index < list.Length )
					return list[index];
			}

			return null;
		}

		/// <summary>
		/// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
		/// </summary>
		public static CraftResourceType GetType( CraftResource resource )
		{
			if ( resource >= CraftResource.Iron && resource <= CraftResource.Valorite )
				return CraftResourceType.Metal;

			if ( resource == CraftResource.Steel || resource == CraftResource.Brass || resource == CraftResource.Mithril || resource == CraftResource.Dwarven || resource == CraftResource.Xormite || resource == CraftResource.Obsidian || resource == CraftResource.Nepturite )
				return CraftResourceType.Metal;

			if ( resource >= CraftResource.RegularLeather && resource <= CraftResource.BarbedLeather )
				return CraftResourceType.Leather;

			if ( 	resource == CraftResource.NecroticLeather ||
					resource == CraftResource.VolcanicLeather ||
					resource == CraftResource.FrozenLeather ||
					resource == CraftResource.GoliathLeather ||
					resource == CraftResource.DraconicLeather ||
					resource == CraftResource.HellishLeather ||
					resource == CraftResource.DinosaurLeather ||
					resource == CraftResource.AlienLeather )
				return CraftResourceType.Leather;

			if ( resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales )
				return CraftResourceType.Scales;

			if ( resource == CraftResource.DinosaurScales )
				return CraftResourceType.Scales;

			if (	resource == CraftResource.RegularWood ||
					resource == CraftResource.AshTree ||
					resource == CraftResource.CherryTree ||
					resource == CraftResource.EbonyTree ||
					resource == CraftResource.GoldenOakTree ||
					resource == CraftResource.HickoryTree ||
					resource == CraftResource.MahoganyTree ||
					resource == CraftResource.OakTree ||
					resource == CraftResource.PineTree ||
					resource == CraftResource.GhostTree ||
					resource == CraftResource.RosewoodTree ||
					resource == CraftResource.WalnutTree ||
					resource == CraftResource.DriftwoodTree ||
					resource == CraftResource.ElvenTree ||
					resource == CraftResource.PetrifiedTree )
				return CraftResourceType.Wood;

			return CraftResourceType.None;
		}

		/// <summary>
		/// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
		/// </summary>
		public static CraftResource GetStart( CraftResource resource )
		{
			switch ( GetType( resource ) )
			{
				case CraftResourceType.Metal: return CraftResource.Iron;
				case CraftResourceType.Leather: return CraftResource.RegularLeather;
				case CraftResourceType.Scales: return CraftResource.RedScales;
				case CraftResourceType.Wood: return CraftResource.RegularWood;
			}

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
		/// </summary>
		public static int GetIndex( CraftResource resource )
		{
			CraftResource start = GetStart( resource );

			if ( start == CraftResource.None )
				return 0;

			return (int)(resource - start);
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetLocalizationNumber( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Number );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
		/// </summary>
		public static int GetHue( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? 0 : info.Hue );
		}

		/// <summary>
		/// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
		/// </summary>
		public static string GetName( CraftResource resource )
		{
			CraftResourceInfo info = GetInfo( resource );

			return ( info == null ? String.Empty : info.Name );
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info )
		{
			if ( info.Name.IndexOf( "Deep Sea" ) >= 0 )
				return CraftResource.SpinedLeather;
			else if ( info.Name.IndexOf( "Lizard" ) >= 0 )
				return CraftResource.HornedLeather;
			else if ( info.Name.IndexOf( "Serpent" ) >= 0 )
				return CraftResource.BarbedLeather;
			else if ( info.Name.IndexOf( "Necrotic" ) >= 0 )
				return CraftResource.NecroticLeather;
			else if ( info.Name.IndexOf( "Volcanic" ) >= 0 )
				return CraftResource.VolcanicLeather;
			else if ( info.Name.IndexOf( "Frozen" ) >= 0 )
				return CraftResource.FrozenLeather;
			else if ( info.Name.IndexOf( "Goliath" ) >= 0 )
				return CraftResource.GoliathLeather;
			else if ( info.Name.IndexOf( "Draconic" ) >= 0 )
				return CraftResource.DraconicLeather;
			else if ( info.Name.IndexOf( "Hellish" ) >= 0 )
				return CraftResource.HellishLeather;
			else if ( info.Name.IndexOf( "Dinosaur" ) >= 0 )
				return CraftResource.DinosaurLeather;
			else if ( info.Name.IndexOf( "Alien" ) >= 0 )
				return CraftResource.AlienLeather;
			else if ( info.Name.IndexOf( "Leather" ) >= 0 )
				return CraftResource.RegularLeather;

			if ( info.Level == 0 )
				return CraftResource.Iron;
			else if ( info.Level == 1 )
				return CraftResource.DullCopper;
			else if ( info.Level == 2 )
				return CraftResource.ShadowIron;
			else if ( info.Level == 3 )
				return CraftResource.Copper;
			else if ( info.Level == 4 )
				return CraftResource.Bronze;
			else if ( info.Level == 5 )
				return CraftResource.Gold;
			else if ( info.Level == 6 )
				return CraftResource.Agapite;
			else if ( info.Level == 7 )
				return CraftResource.Verite;
			else if ( info.Level == 8 )
				return CraftResource.Valorite;
			else if ( info.Level == 9 )
				return CraftResource.Nepturite;
			else if ( info.Level == 10 )
				return CraftResource.Obsidian;
			else if ( info.Level == 11 )
				return CraftResource.Steel;
			else if ( info.Level == 12 )
				return CraftResource.Brass;
			else if ( info.Level == 13 )
				return CraftResource.Mithril;
			else if ( info.Level == 14 )
				return CraftResource.Xormite;
			else if ( info.Level == 15 )
				return CraftResource.Dwarven;

			return CraftResource.None;
		}

		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
		/// </summary>
		public static CraftResource GetFromOreInfo( OreInfo info, ArmorMaterialType material )
		{
			if ( material == ArmorMaterialType.Studded ||
					material == ArmorMaterialType.Leather ||
					material == ArmorMaterialType.Spined ||
					material == ArmorMaterialType.Necrotic ||
					material == ArmorMaterialType.Volcanic ||
					material == ArmorMaterialType.Frozen ||
					material == ArmorMaterialType.Goliath ||
					material == ArmorMaterialType.Draconic ||
					material == ArmorMaterialType.Hellish ||
					material == ArmorMaterialType.Horned ||
					material == ArmorMaterialType.Barbed ||
					material == ArmorMaterialType.Dinosaur ||
					material == ArmorMaterialType.Alien )
			{
				if ( info.Level == 0 )
					return CraftResource.RegularLeather;
				else if ( info.Level == 1 )
					return CraftResource.SpinedLeather;
				else if ( info.Level == 2 )
					return CraftResource.HornedLeather;
				else if ( info.Level == 3 )
					return CraftResource.BarbedLeather;
				else if ( info.Level == 4 )
					return CraftResource.NecroticLeather;
				else if ( info.Level == 5 )
					return CraftResource.VolcanicLeather;
				else if ( info.Level == 6 )
					return CraftResource.FrozenLeather;
				else if ( info.Level == 7 )
					return CraftResource.GoliathLeather;
				else if ( info.Level == 8 )
					return CraftResource.DraconicLeather;
				else if ( info.Level == 9 )
					return CraftResource.HellishLeather;
				else if ( info.Level == 10 )
					return CraftResource.DinosaurLeather;
				else if ( info.Level == 11 )
					return CraftResource.AlienLeather;

				return CraftResource.None;
			}

			return GetFromOreInfo( info );
		}
	}

	// NOTE: This class is only for compatability with very old RunUO versions.
	// No changes to it should be required for custom resources.
	public class OreInfo
	{
		public static readonly OreInfo Iron			= new OreInfo( 0, 0x000, "Iron" );
		public static readonly OreInfo DullCopper	= new OreInfo( 1, MaterialInfo.GetMaterialColor( "dull copper", "", 0 ), "Dull Copper" );
		public static readonly OreInfo ShadowIron	= new OreInfo( 2, MaterialInfo.GetMaterialColor( "shadow iron", "", 0 ), "Shadow Iron" );
		public static readonly OreInfo Copper		= new OreInfo( 3, MaterialInfo.GetMaterialColor( "copper", "classic", 0 ), "Copper" );
		public static readonly OreInfo Bronze		= new OreInfo( 4, MaterialInfo.GetMaterialColor( "bronze", "classic", 0 ), "Bronze" );
		public static readonly OreInfo Gold			= new OreInfo( 5, MaterialInfo.GetMaterialColor( "gold", "classic", 0 ), "Gold" );
		public static readonly OreInfo Agapite		= new OreInfo( 6, MaterialInfo.GetMaterialColor( "agapite", "classic", 0 ), "Agapite" );
		public static readonly OreInfo Verite		= new OreInfo( 7, MaterialInfo.GetMaterialColor( "verite", "classic", 0 ), "Verite" );
		public static readonly OreInfo Valorite		= new OreInfo( 8, MaterialInfo.GetMaterialColor( "valorite", "classic", 0 ), "Valorite" );
		public static readonly OreInfo Nepturite	= new OreInfo( 9, MaterialInfo.GetMaterialColor( "nepturite", "classic", 0 ), "Nepturite" );
		public static readonly OreInfo Obsidian		= new OreInfo( 10, MaterialInfo.GetMaterialColor( "obsidian", "classic", 0 ), "Obsidian" );
		public static readonly OreInfo Mithril		= new OreInfo( 11, MaterialInfo.GetMaterialColor( "mithril", "classic", 0 ), "Mithril" );
		public static readonly OreInfo Xormite		= new OreInfo( 12, MaterialInfo.GetMaterialColor( "xormite", "classic", 0 ), "Xormite" );
		public static readonly OreInfo Dwarven		= new OreInfo( 13, MaterialInfo.GetMaterialColor( "dwarven", "classic", 0 ), "Dwarven" );

		private int m_Level;
		private int m_Hue;
		private string m_Name;

		public OreInfo( int level, int hue, string name )
		{
			m_Level = level;
			m_Hue = hue;
			m_Name = name;
		}

		public int Level
		{
			get
			{
				return m_Level;
			}
		}

		public int Hue
		{
			get
			{
				return m_Hue;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}
	}
}
