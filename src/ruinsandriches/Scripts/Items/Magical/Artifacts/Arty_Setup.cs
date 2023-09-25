using System;
using Server;
using Server.Items;

namespace Server.Misc
{
	public class Arty
	{
		public static void ArtySetup( Item item, int points, string extra )
		{
			points = points * 10;
			points = 200 - points;
			if ( points < 50 ){ points = 50; }

			if ( item is BaseGiftArmor )
			{
				((BaseGiftArmor)item).m_Gifter = extra + "Artefact";;
				((BaseGiftArmor)item).m_How = "Unearthed by";
				((BaseGiftArmor)item).m_Points = points;
			}
			else if ( item is BaseGiftClothing )
			{
				((BaseGiftClothing)item).m_Gifter = extra + "Artefact";;
				((BaseGiftClothing)item).m_How = "Unearthed by";
				((BaseGiftClothing)item).m_Points = points;
			}
			else if ( item is BaseGiftJewel )
			{
				((BaseGiftJewel)item).m_Gifter = extra + "Artefact";;
				((BaseGiftJewel)item).m_How = "Unearthed by";
				((BaseGiftJewel)item).m_Points = points;
			}
			else if ( item is BaseGiftShield )
			{
				((BaseGiftShield)item).m_Gifter = extra + "Artefact";;
				((BaseGiftShield)item).m_How = "Unearthed by";
				((BaseGiftShield)item).m_Points = points;
			}
			else if ( item is BaseGiftAxe )
			{
				((BaseGiftAxe)item).m_Gifter = extra + "Artefact";;
				((BaseGiftAxe)item).m_How = "Unearthed by";
				((BaseGiftAxe)item).m_Points = points;
			}
			else if ( item is BaseGiftKnife )
			{
				((BaseGiftKnife)item).m_Gifter = extra + "Artefact";;
				((BaseGiftKnife)item).m_How = "Unearthed by";
				((BaseGiftKnife)item).m_Points = points;
			}
			else if ( item is BaseGiftBashing )
			{
				((BaseGiftBashing)item).m_Gifter = extra + "Artefact";;
				((BaseGiftBashing)item).m_How = "Unearthed by";
				((BaseGiftBashing)item).m_Points = points;
			}
			else if ( item is BaseGiftWhip )
			{
				((BaseGiftWhip)item).m_Gifter = extra + "Artefact";;
				((BaseGiftWhip)item).m_How = "Unearthed by";
				((BaseGiftWhip)item).m_Points = points;
			}
			else if ( item is BaseGiftPoleArm )
			{
				((BaseGiftPoleArm)item).m_Gifter = extra + "Artefact";;
				((BaseGiftPoleArm)item).m_How = "Unearthed by";
				((BaseGiftPoleArm)item).m_Points = points;
			}
			else if ( item is BaseGiftRanged )
			{
				((BaseGiftRanged)item).m_Gifter = extra + "Artefact";;
				((BaseGiftRanged)item).m_How = "Unearthed by";
				((BaseGiftRanged)item).m_Points = points;
			}
			else if ( item is BaseGiftSpear )
			{
				((BaseGiftSpear)item).m_Gifter = extra + "Artefact";;
				((BaseGiftSpear)item).m_How = "Unearthed by";
				((BaseGiftSpear)item).m_Points = points;
			}
			else if ( item is BaseGiftStaff )
			{
				((BaseGiftStaff)item).m_Gifter = extra + "Artefact";;
				((BaseGiftStaff)item).m_How = "Unearthed by";
				((BaseGiftStaff)item).m_Points = points;
			}
			else if ( item is BaseGiftSword )
			{
				((BaseGiftSword)item).m_Gifter = extra + "Artefact";;
				((BaseGiftSword)item).m_How = "Unearthed by";
				((BaseGiftSword)item).m_Points = points;
			}
		}

		public static void setArtifact( Item item )
		{
			if ( isArtifact( item ) )
			{
				Type itemType = item.GetType();
				Item arty = null;

				if ( itemType != null )
				{
					arty = (Item)Activator.CreateInstance(itemType);

					if ( item is BaseWeapon )
					{
						BaseWeapon weapon = (BaseWeapon)item;

						if ( Server.Misc.MaterialInfo.IsMetalItem( item ) && weapon.Resource != CraftResource.Iron )
						{
							weapon.Resource = CraftResource.Iron;
						}
						else if ( Server.Misc.MaterialInfo.IsLeatherItem( item ) && weapon.Resource != CraftResource.RegularLeather )
						{
							weapon.Resource = CraftResource.RegularLeather;
						}
						else if ( Server.Misc.MaterialInfo.IsWoodenItem( item ) && weapon.Resource != CraftResource.RegularWood )
						{
							weapon.Resource = CraftResource.RegularWood;
						}
					}
					else if ( item is BaseArmor )
					{
						BaseArmor armor = (BaseArmor)item;

						if ( Server.Misc.MaterialInfo.IsMetalItem( item ) && armor.Resource != CraftResource.Iron )
						{
							armor.Resource = CraftResource.Iron;
						}
						else if ( Server.Misc.MaterialInfo.IsLeatherItem( item ) && armor.Resource != CraftResource.RegularLeather )
						{
							armor.Resource = CraftResource.RegularLeather;
						}
						else if ( Server.Misc.MaterialInfo.IsWoodenItem( item ) && armor.Resource != CraftResource.RegularWood )
						{
							armor.Resource = CraftResource.RegularWood;
						}
					}

					item.Name = arty.Name;
					if ( !(item is BaseQuiver) && !Server.Misc.MyServerSettings.ChangeArtyLook() ){ item.ItemID = arty.ItemID; }
					if ( !Server.Misc.MyServerSettings.ChangeArtyLook() ){ item.Hue = arty.Hue; }

					arty.Delete();
				}
			}
		}

		public static bool canEnchant( Item item )
		{
			if ( isArtifact( item ) )
				return false;
			else if ( item is IGiftable )
				return false;
			else if ( item is ILevelable )
				return false;
			else if ( Server.Engines.Craft.CraftItem.IsGodCrafted( item ) )
				return false;

			return true;
		}

		public static bool canEnchantArty( Item item )
		{
			if (
				item is Artifact_BookOfKnowledge ||
				item is Artifact_OssianGrimoire ||
				item is GwennosHarp ||
				item is HornOfKingTriton ||
				item is IolosLute ||
				item is QuiverOfBlight ||
				item is QuiverOfElements ||
				item is QuiverOfFire ||
				item is QuiverOfIce ||
				item is QuiverOfInfinity ||
				item is QuiverOfLightning ||
				item is QuiverOfRage
			){ return true; }

			return false;
		}

		public static bool isArtifact( Item item )
		{
			if (
				item is Artifact_AbysmalGloves ||
				item is Artifact_AchillesShield ||
				item is Artifact_AchillesSpear ||
				item is Artifact_AcidProofRobe ||
				item is Artifact_Aegis ||
				item is Artifact_AegisOfGrace ||
				item is Artifact_AilricsLongbow ||
				item is Artifact_AlchemistsBauble ||
				item is Artifact_ANecromancerShroud ||
				item is Artifact_AngelicEmbrace ||
				item is Artifact_AngeroftheGods ||
				item is Artifact_Annihilation ||
				item is Artifact_ArcaneArms ||
				item is Artifact_ArcaneCap ||
				item is Artifact_ArcaneGloves ||
				item is Artifact_ArcaneGorget ||
				item is Artifact_ArcaneLeggings ||
				item is Artifact_ArcaneShield ||
				item is Artifact_ArcaneTunic ||
				item is Artifact_ArcanicRobe ||
				item is Artifact_ArcticBeacon ||
				item is Artifact_ArcticDeathDealer ||
				item is Artifact_ArmorOfFortune ||
				item is Artifact_ArmorOfInsight ||
				item is Artifact_ArmorOfNobility ||
				item is Artifact_ArmsOfAegis ||
				item is Artifact_ArmsOfFortune ||
				item is Artifact_ArmsOfInsight ||
				item is Artifact_ArmsOfNobility ||
				item is Artifact_ArmsOfTheFallenKing ||
				item is Artifact_ArmsOfTheHarrower ||
				item is Artifact_ArmsOfToxicity ||
				item is Artifact_AuraOfShadows ||
				item is Artifact_AxeOfTheHeavens ||
				item is Artifact_AxeoftheMinotaur ||
				item is Artifact_BeggarsRobe ||
				item is Artifact_BeltofHercules ||
				item is Artifact_BelmontWhip ||
				item is Artifact_BladeDance ||
				item is Artifact_BladeOfInsanity ||
				item is Artifact_BladeOfTheRighteous ||
				item is Artifact_BlazeOfDeath ||
				item is Artifact_BlightGrippedLongbow ||
				item is Artifact_BloodwoodSpirit ||
				item is Artifact_BoneCrusher ||
				item is Artifact_Bonesmasher ||
				item is Artifact_BookOfKnowledge ||
				item is Artifact_Boomstick ||
				item is Artifact_BootsofHermes ||
				item is Artifact_BowOfTheJukaKing ||
				item is Artifact_BowofthePhoenix ||
				item is Artifact_BraceletOfHealth ||
				item is Artifact_BraceletOfTheElements ||
				item is Artifact_BraceletOfTheVile ||
				item is Artifact_BrambleCoat ||
				item is Artifact_BraveKnightOfTheBritannia ||
				item is Artifact_BreathOfTheDead ||
				item is Artifact_BurglarsBandana ||
				item is Artifact_Calm ||
				item is Artifact_CandleCold ||
				item is Artifact_CandleEnergy ||
				item is Artifact_CandleFire ||
				item is Artifact_CandleNecromancer ||
				item is Artifact_CandlePoison ||
				item is Artifact_CandleWizard ||
				item is Artifact_CapOfFortune ||
				item is Artifact_CapOfTheFallenKing ||
				item is Artifact_CaptainJohnsHat ||
				item is Artifact_CaptainQuacklebushsCutlass ||
				item is Artifact_CavortingClub ||
				item is Artifact_CircletOfTheSorceress ||
				item is Artifact_CoifOfBane ||
				item is Artifact_CoifOfFire ||
				item is Artifact_ColdBlood ||
				item is Artifact_ColdForgedBlade ||
				item is Artifact_ConansHelm ||
				item is Artifact_ConansLoinCloth ||
				item is Artifact_ConansSword ||
				item is Artifact_CrimsonCincture ||
				item is Artifact_CrownOfTalKeesh ||
				item is Artifact_DaggerOfVenom ||
				item is Artifact_DarkGuardiansChest ||
				item is Artifact_DarkLordsPitchfork ||
				item is Artifact_DarkNeck ||
				item is Artifact_DeathsMask ||
				item is Artifact_DetectiveBoots ||
				item is Artifact_DivineArms ||
				item is Artifact_DivineCountenance ||
				item is Artifact_DivineGloves ||
				item is Artifact_DivineGorget ||
				item is Artifact_DivineLeggings ||
				item is Artifact_DivineTunic ||
				item is Artifact_DjinnisRing ||
				item is Artifact_DreadPirateHat ||
				item is Artifact_DupresCollar ||
				item is Artifact_DupresShield ||
				item is Artifact_EarringsOfHealth ||
				item is Artifact_EarringsOfTheElements ||
				item is Artifact_EarringsOfTheMagician ||
				item is Artifact_EarringsOfTheVile ||
				item is Artifact_EmbroideredOakLeafCloak ||
				item is Artifact_EnchantedTitanLegBone ||
				item is Artifact_EssenceOfBattle ||
				item is Artifact_EternalFlame ||
				item is Artifact_EvilMageGloves ||
				item is Artifact_Excalibur ||
				item is Artifact_FalseGodsScepter ||
				item is Artifact_FangOfRactus ||
				item is Artifact_FesteringWound ||
				item is Artifact_FeyLeggings ||
				item is Artifact_FleshRipper ||
				item is Artifact_Fortifiedarms ||
				item is Artifact_FortunateBlades ||
				item is Artifact_Frostbringer ||
				item is Artifact_FurCapeOfTheSorceress ||
				item is Artifact_Fury ||
				item is Artifact_GandalfsHat ||
				item is Artifact_GandalfsRobe ||
				item is Artifact_GandalfsStaff ||
				item is Artifact_GauntletsOfNobility ||
				item is Artifact_GeishasObi ||
				item is Artifact_GiantBlackjack ||
				item is Artifact_GladiatorsCollar ||
				item is Artifact_GlassSword ||
				item is Artifact_GlovesOfAegis ||
				item is Artifact_GlovesOfCorruption ||
				item is Artifact_GlovesOfDexterity ||
				item is Artifact_GlovesOfFortune ||
				item is Artifact_GlovesOfInsight ||
				item is Artifact_GlovesOfRegeneration ||
				item is Artifact_GlovesOfTheFallenKing ||
				item is Artifact_GlovesOfTheHarrower ||
				item is Artifact_GlovesOfThePugilist ||
				item is Artifact_GorgetOfAegis ||
				item is Artifact_GorgetOfFortune ||
				item is Artifact_GorgetOfInsight ||
				item is Artifact_GrayMouserCloak ||
				item is Artifact_GrimReapersLantern ||
				item is Artifact_GrimReapersMask ||
				item is Artifact_GrimReapersRobe ||
				item is Artifact_GrimReapersScythe ||
				item is Artifact_GuantletsOfAnger ||
				item is Artifact_HammerofThor ||
				item is Artifact_HatOfTheMagi ||
				item is Artifact_HeartOfTheLion ||
				item is Artifact_HellForgedArms ||
				item is Artifact_HelmOfAegis ||
				item is Artifact_HelmOfBrilliance ||
				item is Artifact_HelmOfInsight ||
				item is Artifact_HelmOfSwiftness ||
				item is Artifact_HolyKnightsArmPlates ||
				item is Artifact_HolyKnightsBreastplate ||
				item is Artifact_HolyKnightsGloves ||
				item is Artifact_HolyKnightsGorget ||
				item is Artifact_HolyKnightsLegging ||
				item is Artifact_HolyKnightsPlateHelm ||
				item is Artifact_HolySword ||
				item is Artifact_HoodedShroudOfShadows ||
				item is Artifact_HuntersArms ||
				item is Artifact_HuntersGloves ||
				item is Artifact_HuntersGorget ||
				item is Artifact_HuntersHeaddress ||
				item is Artifact_HuntersLeggings ||
				item is Artifact_HuntersTunic ||
				item is Artifact_Indecency ||
				item is Artifact_InquisitorsArms ||
				item is Artifact_InquisitorsGorget ||
				item is Artifact_InquisitorsHelm ||
				item is Artifact_InquisitorsLeggings ||
				item is Artifact_InquisitorsResolution ||
				item is Artifact_InquisitorsTunic ||
				item is Artifact_IronwoodCrown ||
				item is Artifact_JackalsArms ||
				item is Artifact_JackalsCollar ||
				item is Artifact_JackalsGloves ||
				item is Artifact_JackalsHelm ||
				item is Artifact_JackalsLeggings ||
				item is Artifact_JackalsTunic ||
				item is Artifact_JadeScimitar ||
				item is Artifact_JesterHatofChuckles ||
				item is Artifact_JinBaoriOfGoodFortune ||
				item is Artifact_KamiNarisIndestructableDoubleAxe ||
				item is Artifact_KodiakBearMask ||
				item is Artifact_LegacyOfTheDreadLord ||
				item is Artifact_LeggingsOfAegis ||
				item is Artifact_LeggingsOfBane ||
				item is Artifact_LeggingsOfDeceit ||
				item is Artifact_LeggingsOfEmbers ||
				item is Artifact_LeggingsOfEnlightenment ||
				item is Artifact_LeggingsOfFire ||
				item is Artifact_LegsOfFortune ||
				item is Artifact_LegsOfInsight ||
				item is Artifact_LegsOfNobility ||
				item is Artifact_LegsOfTheFallenKing ||
				item is Artifact_LegsOfTheHarrower ||
				item is Artifact_LieutenantOfTheBritannianRoyalGuard ||
				item is Artifact_LongShot ||
				item is Artifact_LuckyEarrings ||
				item is Artifact_LuckyNecklace ||
				item is Artifact_LuminousRuneBlade ||
				item is Artifact_LunaLance ||
				item is Artifact_MadmansHatchet ||
				item is Artifact_MagesBand ||
				item is Artifact_MagiciansIllusion ||
				item is Artifact_MagiciansMempo ||
				item is Artifact_MarbleShield ||
				item is Artifact_MauloftheBeast ||
				item is Artifact_MaulOfTheTitans ||
				item is Artifact_MelisandesCorrodedHatchet ||
				item is Artifact_MidnightBracers ||
				item is Artifact_MidnightGloves ||
				item is Artifact_MidnightHelm ||
				item is Artifact_MidnightLegs ||
				item is Artifact_MidnightTunic ||
				item is Artifact_MinersPickaxe ||
				item is Artifact_NightsKiss ||
				item is Artifact_NordicVikingSword ||
				item is Artifact_NoxBow ||
				item is Artifact_NoxNightlight ||
				item is Artifact_NoxRangersHeavyCrossbow ||
				item is Artifact_OblivionsNeedle ||
				item is Artifact_OrcChieftainHelm ||
				item is Artifact_OrcishVisage ||
				item is Artifact_OrnamentOfTheMagician ||
				item is Artifact_OrnateCrownOfTheHarrower ||
				item is Artifact_OssianGrimoire ||
				item is Artifact_OverseerSunderedBlade ||
				item is Artifact_Pacify ||
				item is Artifact_PadsOfTheCuSidhe ||
				item is Artifact_PendantOfTheMagi ||
				item is Artifact_Pestilence ||
				item is Artifact_PhantomStaff ||
				item is Artifact_PixieSwatter ||
				item is Artifact_PolarBearBoots ||
				item is Artifact_PolarBearCape ||
				item is Artifact_PolarBearMask ||
				item is Artifact_PowerSurge ||
				item is Artifact_Quell ||
				item is Artifact_RaedsGlory ||
				item is Artifact_RamusNecromanticScalpel ||
				item is Artifact_ResilientBracer ||
				item is Artifact_Retort ||
				item is Artifact_RighteousAnger ||
				item is Artifact_RingOfHealth ||
				item is Artifact_RingOfProtection ||
				item is Artifact_RingOfTheElements ||
				item is Artifact_RingOfTheMagician ||
				item is Artifact_RingOfTheVile ||
				item is Artifact_RobeOfTeleportation ||
				item is Artifact_RobeOfTheEclipse ||
				item is Artifact_RobeOfTheEquinox ||
				item is Artifact_RobeOfTreason ||
				item is Artifact_RobinHoodsBow ||
				item is Artifact_RobinHoodsFeatheredHat ||
				item is Artifact_RodOfResurrection ||
				item is Artifact_RoyalArchersBow ||
				item is Artifact_RoyalGuardsChestplate ||
				item is Artifact_RoyalGuardsGorget ||
				item is Artifact_RoyalGuardSurvivalKnife ||
				item is Artifact_RuneCarvingKnife ||
				item is Artifact_SamaritanRobe ||
				item is Artifact_SamuraiHelm ||
				item is Artifact_SerpentsFang ||
				item is Artifact_ShadowBlade ||
				item is Artifact_ShadowDancerArms ||
				item is Artifact_ShadowDancerCap ||
				item is Artifact_ShadowDancerGloves ||
				item is Artifact_ShadowDancerGorget ||
				item is Artifact_ShadowDancerLeggings ||
				item is Artifact_ShadowDancerTunic ||
				item is Artifact_ShaMontorrossbow ||
				item is Artifact_ShardThrasher ||
				item is Artifact_ShieldOfInvulnerability ||
				item is Artifact_ShimmeringTalisman ||
				item is Artifact_ShroudOfDeciet ||
				item is Artifact_SilvanisFeywoodBow ||
				item is Artifact_SinbadsSword ||
				item is Artifact_SongWovenMantle ||
				item is Artifact_SoulSeeker ||
				item is Artifact_SpellWovenBritches ||
				item is Artifact_SpiritOfTheTotem ||
				item is Artifact_SprintersSandals ||
				item is Artifact_StaffOfPower ||
				item is Artifact_StaffofSnakes ||
				item is Artifact_StaffOfTheMagi ||
				item is Artifact_StitchersMittens ||
				item is Artifact_Stormbringer ||
				item is Artifact_Subdue ||
				item is Artifact_SwiftStrike ||
				item is Artifact_TalonBite ||
				item is Artifact_TheBeserkersMaul ||
				item is Artifact_TheDragonSlayer ||
				item is Artifact_TheDryadBow ||
				item is Artifact_TheNightReaper ||
				item is Artifact_TheRobeOfBritanniaAri ||
				item is Artifact_TheTaskmaster ||
				item is Artifact_TitansHammer ||
				item is Artifact_TorchOfTrapFinding ||
				item is Artifact_TotemArms ||
				item is Artifact_TotemGloves ||
				item is Artifact_TotemGorget ||
				item is Artifact_TotemLeggings ||
				item is Artifact_TotemOfVoid ||
				item is Artifact_TotemTunic ||
				item is Artifact_TownGuardsHalberd ||
				item is Artifact_TunicOfAegis ||
				item is Artifact_TunicOfBane ||
				item is Artifact_TunicOfFire ||
				item is Artifact_TunicOfTheFallenKing ||
				item is Artifact_TunicOfTheHarrower ||
				item is Artifact_VampiresRobe ||
				item is Artifact_VampiricDaisho ||
				item is Artifact_VioletCourage ||
				item is Artifact_VoiceOfTheFallenKing ||
				item is Artifact_WarriorsClasp ||
				item is Artifact_WildfireBow ||
				item is Artifact_Windsong ||
				item is Artifact_WizardsPants ||
				item is Artifact_WrathOfTheDryad ||
				item is Artifact_YashimotosHatsuburi ||
				item is Artifact_ZyronicClaw ||
				item is GwennosHarp ||
				item is HornOfKingTriton ||
				item is IolosLute ||
				item is QuiverOfBlight ||
				item is QuiverOfElements ||
				item is QuiverOfFire ||
				item is QuiverOfIce ||
				item is QuiverOfInfinity ||
				item is QuiverOfLightning ||
				item is QuiverOfRage ||
				item is Artifact_RobeofStratos ||
				item is Artifact_BootsofHydros ||
				item is Artifact_BootsofLithos ||
				item is Artifact_BootsofPyros ||
				item is Artifact_BootsofStratos ||
				item is Artifact_MantleofHydros ||
				item is Artifact_MantleofLithos ||
				item is Artifact_MantleofPyros ||
				item is Artifact_MantleofStratos ||
				item is Artifact_RobeofHydros ||
				item is Artifact_RobeofLithos ||
				item is Artifact_RobeofPyros ||
				item is Artifact_PyrosGrimoire ||
				item is Artifact_StratosManual ||
				item is Artifact_HydrosLexicon ||
				item is Artifact_LithosTome
			){ return true; }

			return false;
		}
	}
}
