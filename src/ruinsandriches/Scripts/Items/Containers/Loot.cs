using System;
using System.IO;
using System.Reflection;
using Server;
using Server.Items;
using Server.Misc;

namespace Server
{
	public class Loot
	{
		#region List definitions
		private static Type[] m_SEWeaponTypes = new Type[]
			{
				typeof( Bokuto ),				typeof( Daisho ),				typeof( Kama ),
				typeof( Lajatang ),				typeof( NoDachi ),				typeof( Nunchaku ),
				typeof( Sai ),					typeof( Tekagi ),				typeof( Tessen ),
				typeof( Tetsubo ),				typeof( Wakizashi ), 			typeof( PugilistGloves ),
				typeof( RepeatingCrossbow ),	typeof( Katana ),
				typeof( QuarterStaff ),			typeof( Pike ),					typeof( BladedStaff ),
				typeof( Spear ),				typeof( Axe ),					typeof( ElvenMachete ),
				typeof( Scimitar ),				typeof( Leafblade ),			typeof( Longsword ),
				typeof( Dagger ),				typeof( WarMace )
			};

		public static Type[] SEWeaponTypes{ get{ return m_SEWeaponTypes; } }

		private static Type[] m_AosWeaponTypes = new Type[]
			{
				typeof( Scythe ),				typeof( BoneHarvester ),		typeof( Scepter ),
				typeof( BladedStaff ),			typeof( Pike ),					typeof( DoubleBladedStaff ),
				typeof( Lance ),				typeof( CrescentBlade )
			};

		public static Type[] AosWeaponTypes{ get{ return m_AosWeaponTypes; } }

		private static Type[] m_WeaponTypes = new Type[]
			{
				typeof( Axe ),				typeof( BattleAxe ),		typeof( DoubleAxe ),
				typeof( ExecutionersAxe ),	typeof( Hatchet ),			typeof( LargeBattleAxe ),
				typeof( TwoHandedAxe ),		typeof( WarAxe ),			typeof( Club ),
				typeof( Mace ),				typeof( Maul ),				typeof( WarHammer ),
				typeof( WarMace ),			typeof( Bardiche ),			typeof( Halberd ),
				typeof( Spear ),			typeof( ShortSpear ),		typeof( Pitchfork ),
				typeof( WarFork ),			typeof( BlackStaff ),		typeof( GnarledStaff ),
				typeof( QuarterStaff ),		typeof( Broadsword ),		typeof( Cutlass ),
				typeof( Katana ),			typeof( Kryss ),			typeof( Longsword ),
				typeof( Scimitar ),			typeof( VikingSword ),		typeof( Pickaxe ),
				typeof( HammerPick ),		typeof( ButcherKnife ),		typeof( Cleaver ),
				typeof( Dagger ),			typeof( SkinningKnife ),	typeof( ShepherdsCrook ),
				typeof( Axe ),				typeof( BattleAxe ),		typeof( DoubleAxe ),
				typeof( ExecutionersAxe ),	typeof( Hatchet ),			typeof( LargeBattleAxe ),
				typeof( TwoHandedAxe ),		typeof( WarAxe ),			typeof( Club ),
				typeof( Mace ),				typeof( Maul ),				typeof( WarHammer ),
				typeof( WarMace ),			typeof( Bardiche ),			typeof( Halberd ),
				typeof( Spear ),			typeof( ShortSpear ),		typeof( Pitchfork ),
				typeof( WarFork ),			typeof( BlackStaff ),		typeof( GnarledStaff ),
				typeof( QuarterStaff ),		typeof( Broadsword ),		typeof( Cutlass ),
				typeof( Katana ),			typeof( Kryss ),			typeof( Longsword ),
				typeof( Scimitar ),			typeof( VikingSword ),		typeof( Pickaxe ),
				typeof( HammerPick ),		typeof( ButcherKnife ),		typeof( Cleaver ),
				typeof( Dagger ),			typeof( SkinningKnife ),	typeof( ShepherdsCrook ),
				typeof( PugilistGlove ),	typeof( PugilistGloves ),	typeof( AssassinSpike ),
				typeof( ElvenMachete ),		typeof( DiamondMace ),		typeof( Leafblade ),
				typeof( OrnateAxe ),		typeof( ElvenSpellblade ),	typeof( WildStaff ),
				typeof( RuneBlade ),		typeof( RadiantScimitar ),	typeof( WarCleaver ),
				typeof( RoyalSword ),		typeof( WizardWand ),		typeof( WizardStaff ),
				typeof( WizardStick ),		typeof( Harpoon ),			typeof( Claymore ),
				typeof( Claymore ),			typeof( Hammers ), 			typeof( Hammers ),
				typeof( LargeKnife ),		typeof( LargeKnife ),		typeof( ShortSword ),
				typeof( ShortSword ),		typeof( SpikedClub ),		typeof( SpikedClub ),
				typeof( Pitchforks ),		typeof( Whips )
			};

		public static Type[] WeaponTypes{ get{ return m_WeaponTypes; } }

		private static Type[] m_SERangedWeaponTypes = new Type[]
			{
				typeof( Yumi ),					typeof( Yumi ),					typeof( Yumi ),
				typeof( Crossbow ),				typeof( ElvenCompositeLongbow ),
				typeof( ThrowingGloves )
			};

		public static Type[] SERangedWeaponTypes{ get{ return m_SERangedWeaponTypes; } }

		private static Type[] m_AosRangedWeaponTypes = new Type[]
			{
				typeof( CompositeBow ),				typeof( RepeatingCrossbow ),
				typeof( ElvenCompositeLongbow ),	typeof( MagicalShortbow )	
			};

		public static Type[] AosRangedWeaponTypes{ get{ return m_AosRangedWeaponTypes; } }

		private static Type[] m_RangedWeaponTypes = new Type[]
			{
				typeof( Bow ),					typeof( Crossbow ),				typeof( HeavyCrossbow ),
				typeof( ThrowingGloves )
			};

		public static Type[] RangedWeaponTypes{ get{ return m_RangedWeaponTypes; } }

		private static Type[] m_SEArmorTypes = new Type[]
			{
				typeof( ChainHatsuburi ),		typeof( LeatherDo ),				typeof( LeatherHaidate ),
				typeof( LeatherHiroSode ),		typeof( LeatherJingasa ),			typeof( LeatherMempo ),
				typeof( LeatherNinjaHood ),		typeof( LeatherNinjaJacket ),		typeof( LeatherNinjaMitts ),
				typeof( LeatherNinjaPants ),	typeof( LeatherSuneate ),			typeof( DecorativePlateKabuto ),
				typeof( HeavyPlateJingasa ),	typeof( LightPlateJingasa ),		typeof( PlateBattleKabuto ),
				typeof( PlateDo ),				typeof( PlateHaidate ),				typeof( PlateHatsuburi ),
				typeof( PlateHiroSode ),		typeof( PlateMempo ),				typeof( PlateSuneate ),
				typeof( SmallPlateJingasa ),	typeof( StandardPlateKabuto ),		typeof( StuddedDo ),
				typeof( StuddedHaidate ),		typeof( StuddedHiroSode ),			typeof( StuddedMempo ),
				typeof( StuddedSuneate ),		typeof( BoneSkirt ),				typeof( HideChest ), 
				typeof( SavageArms ), 			typeof( SavageChest ), 				typeof( SavageGloves ),
				typeof( SavageHelm ), 			typeof( SavageLegs ),				typeof( StuddedHideChest ), 
				typeof( Bascinet ),				typeof( LeatherSandals ),			typeof( RingmailArms ),			
				typeof( BoneArms ),				typeof( LeatherShoes ),				typeof( RingmailChest ),			
				typeof( BoneChest ),			typeof( LeatherShorts ),			typeof( RingmailGloves ),			
				typeof( BoneGloves ),			typeof( LeatherSkirt ),				typeof( RingmailLegs ),			
				typeof( BoneHelm ),				typeof( LeatherSoftBoots ),			typeof( RoyalArms ),			
				typeof( BoneLegs ),				typeof( LeatherThighBoots ),		typeof( RoyalBoots ),			
				typeof( ChainChest ),			typeof( MagicBoneArms ),			typeof( RoyalChest ),			
				typeof( ChainCoif ),			typeof( MagicBoneChest ),			typeof( DreadHelm ),
				typeof( ChainLegs ),			typeof( MagicBoneGloves ),			typeof( RoyalGloves ),			
				typeof( CloseHelm ),			typeof( MagicBoneHelm ),			typeof( RoyalGorget ),			
				typeof( FemaleLeatherChest ),	typeof( MagicBoneLegs ),			typeof( RoyalHelm ),			
				typeof( FemalePlateChest ),		typeof( RoyalsLegs ),				typeof( PlateSkirt ),
				typeof( FemaleStuddedChest ),	typeof( StuddedArms ),				typeof( ChainSkirt ),
				typeof( Helmet ),				typeof( StuddedBustierArms ),		typeof( RingmailSkirt ),
				typeof( MagicFurArms ),			typeof( MagicFurChest ),			typeof( MagicFurLegs ),
				typeof( LeatherArms ),			typeof( StuddedChest ),				typeof( StuddedSkirt ),
				typeof( LeatherBoots ),			typeof( StuddedGloves ),			typeof( MagicBoneSkirt ),
				typeof( LeatherBustierArms ),	typeof( NorseHelm ),				typeof( StuddedGorget ),			
				typeof( LeatherCap ),			typeof( OrcHelm ),					typeof( StuddedLegs ),			
				typeof( LeatherChest ),			typeof( PlateArms ),				typeof( WoodenPlateArms ),			
				typeof( LeatherCloak ),			typeof( PlateChest ),				typeof( WoodenPlateChest ),			
				typeof( LeatherGloves ),		typeof( PlateGloves ),				typeof( WoodenPlateGloves ),			
				typeof( LeatherGorget ),		typeof( PlateGorget ),				typeof( WoodenPlateGorget ),			
				typeof( LeatherLegs ),			typeof( PlateHelm ),				typeof( WoodenPlateHelm ),			
				typeof( LeatherRobe ),			typeof( PlateLegs ),				typeof( WoodenPlateLegs ),
				typeof( WhiteFurLegs ),			typeof( WhiteFurTunic ),			typeof( WhiteFurArms ),
				typeof( FurLegs ),				typeof( FurTunic ),					typeof( FurArms ),
				typeof( ShinobiCowl ),			typeof( ShinobiHood ),				typeof( ShinobiMask ),
				typeof( ShinobiRobe ),			typeof( HikingBoots ),				typeof( OniwabanTunic ),
				typeof( OniwabanBoots ),		typeof( OniwabanGloves ),			typeof( OniwabanLeggings ),
				typeof( OniwabanHood )
			};

		public static Type[] SEArmorTypes{ get{ return m_SEArmorTypes; } }

		private static Type[] m_ArmorTypes = new Type[]
			{
				typeof( Bascinet ),				typeof( LeatherSandals ),			typeof( RingmailArms ),			
				typeof( BoneArms ),				typeof( LeatherShoes ),				typeof( RingmailChest ),			
				typeof( BoneChest ),			typeof( LeatherShorts ),			typeof( RingmailGloves ),			
				typeof( BoneGloves ),			typeof( LeatherSkirt ),				typeof( RingmailLegs ),			
				typeof( BoneHelm ),				typeof( LeatherSoftBoots ),			typeof( RoyalArms ),			
				typeof( BoneLegs ),				typeof( LeatherThighBoots ),		typeof( RoyalBoots ),			
				typeof( ChainChest ),			typeof( MagicBoneArms ),			typeof( RoyalChest ),			
				typeof( ChainCoif ),			typeof( MagicBoneChest ),			typeof( DreadHelm ),
				typeof( ChainLegs ),			typeof( MagicBoneGloves ),			typeof( RoyalGloves ),			
				typeof( CloseHelm ),			typeof( MagicBoneHelm ),			typeof( RoyalGorget ),			
				typeof( FemaleLeatherChest ),	typeof( MagicBoneLegs ),			typeof( RoyalHelm ),			
				typeof( FemalePlateChest ),		typeof( RoyalsLegs ),				typeof( PlateSkirt ),
				typeof( FemaleStuddedChest ),	typeof( StuddedArms ),				typeof( ChainSkirt ),
				typeof( Helmet ),				typeof( StuddedBustierArms ),		typeof( RingmailSkirt ),
				typeof( MagicFurArms ),			typeof( MagicFurChest ),			typeof( MagicFurLegs ),
				typeof( LeatherArms ),			typeof( StuddedChest ),				typeof( StuddedSkirt ),
				typeof( LeatherBoots ),			typeof( StuddedGloves ),			typeof( MagicBoneSkirt ),
				typeof( LeatherBustierArms ),	typeof( NorseHelm ),				typeof( StuddedGorget ),			
				typeof( LeatherCap ),			typeof( OrcHelm ),					typeof( StuddedLegs ),			
				typeof( LeatherChest ),			typeof( PlateArms ),				typeof( WoodenPlateArms ),			
				typeof( LeatherCloak ),			typeof( PlateChest ),				typeof( WoodenPlateChest ),			
				typeof( LeatherGloves ),		typeof( PlateGloves ),				typeof( WoodenPlateGloves ),			
				typeof( LeatherGorget ),		typeof( PlateGorget ),				typeof( WoodenPlateGorget ),			
				typeof( LeatherLegs ),			typeof( PlateHelm ),				typeof( WoodenPlateHelm ),			
				typeof( LeatherRobe ),			typeof( PlateLegs ),				typeof( WoodenPlateLegs ),
				typeof( BoneSkirt ),			typeof( HideChest ), 				typeof( HikingBoots ),
				typeof( SavageArms ), 			typeof( SavageChest ), 				typeof( SavageGloves ),
				typeof( SavageHelm ), 			typeof( SavageLegs ),				typeof( StuddedHideChest )
			};

		public static Type[] ArmorTypes{ get{ return m_ArmorTypes; } }

		private static Type[] m_DragonArmorTypes = new Type[]
			{
				typeof( MagicDragonArms ),		typeof( MagicDragonChest ),			typeof( MagicDragonGloves ),
				typeof( MagicDragonHelm ),		typeof( MagicDragonLegs )
			};

		public static Type[] DragonArmorTypes{ get{ return m_DragonArmorTypes; } }

		private static Type[] m_AosShieldTypes = new Type[]
			{
				typeof( ChaosShield ),			typeof( OrderShield ),			typeof( RoyalShield ),
				typeof( GuardsmanShield ),		typeof( ElvenShield ),			typeof( DarkShield ),
				typeof( CrestedShield ),		typeof( ChampionShield ),		typeof( JeweledShield )
			};

		public static Type[] AosShieldTypes{ get{ return m_AosShieldTypes; } }

		private static Type[] m_ShieldTypes = new Type[]
			{
				typeof( BronzeShield ),			typeof( Buckler ),				typeof( HeaterShield ),
				typeof( MetalShield ),			typeof( MetalKiteShield ),		typeof( WoodenKiteShield ),
				typeof( WoodenShield )
			};

		public static Type[] ShieldTypes{ get{ return m_ShieldTypes; } }

		private static Type[] m_FoodsTypes = new Type[]
			{
				typeof( CookedBird ),		typeof( LambLeg ),			typeof( Lime ),
				typeof( Muffins ),			typeof( Grapes ),			typeof( Apple ),
				typeof( Peach ),			typeof( Banana ),			typeof( Pear ),
				typeof( Cabbage ),			typeof( Cantaloupe ),		typeof( Carrot ),
				typeof( HoneydewMelon ),	typeof( Squash ),			typeof( Lettuce ),
				typeof( Onion ),			typeof( Pumpkin ),			typeof( GreenGourd ),
				typeof( YellowGourd ),		typeof( Watermelon ),		typeof( Lemon ),
				typeof( LambLeg ),			typeof( ChickenLeg ),		typeof( Sausage ),
				typeof( Ribs ),				typeof( Ham ),				typeof( FishSteak ),
				typeof( CheeseWheel ),		typeof( CheeseWedge ),		typeof( Ribs ),
				typeof( LambLeg ),			typeof( ChickenLeg ),		typeof( Sausage ),
				typeof( Ribs ),				typeof( Ham ),				typeof( FishSteak ),
				typeof( CheeseWheel ),		typeof( CheeseWedge ),		typeof( Ribs ),
				typeof( LambLeg ),			typeof( ChickenLeg ),		typeof( Sausage ),
				typeof( Ribs ),				typeof( Ham ),				typeof( FishSteak ),
				typeof( CheeseWheel ),		typeof( CheeseWedge ),		typeof( Ribs )
			};

		public static Type[] FoodsTypes{ get{ return m_FoodsTypes; } }

		private static Type[] m_GemTypes = new Type[]
			{
				typeof( Amber ),				typeof( Amethyst ),				typeof( Citrine ),
				typeof( Diamond ),				typeof( Emerald ),				typeof( Ruby ),
				typeof( Sapphire ),				typeof( StarSapphire ),			typeof( Tourmaline ),
				typeof( Amber ),				typeof( Amethyst ),				typeof( Citrine ),
				typeof( Diamond ),				typeof( Emerald ),				typeof( Ruby ),
				typeof( Sapphire ),				typeof( StarSapphire ),			typeof( Tourmaline ),
				typeof( Amber ),				typeof( Amethyst ),				typeof( Citrine ),
				typeof( Diamond ),				typeof( Emerald ),				typeof( Ruby ),
				typeof( Sapphire ),				typeof( StarSapphire ),			typeof( Tourmaline ),
				typeof( MagicJewelryRing ),		typeof( MagicJewelryNecklace ),	typeof( MagicJewelryEarrings ),
				typeof( MagicJewelryBracelet ),	typeof( MagicJewelryCirclet )
			};

		public static Type[] GemTypes{ get{ return m_GemTypes; } }

		private static Type[] m_JewelryTypes = new Type[]
			{
				typeof( MagicJewelryRing ),		typeof( MagicJewelryNecklace ),	typeof( MagicJewelryEarrings ),	
				typeof( MagicJewelryBracelet ),	typeof( MagicJewelryCirclet ),
				typeof( MagicCandle ),			typeof( MagicTorch ),			typeof( MagicLantern ),
				typeof( MagicSash ),			typeof( MagicCloak ),			typeof( MagicRobe ),			
				typeof( MagicRobe ), 			typeof( MagicBelt ), 			typeof( MagicHat ),
				typeof( MagicCloak ), 			typeof( MagicBoots ), 			typeof( MagicTalisman )
			};

		public static Type[] JewelryTypes{ get{ return m_JewelryTypes; } }

		private static Type[] m_SecretRegTypes = new Type[]
			{
				typeof( UnknownReagent )
			};

		public static Type[] SecretRegTypes { get{ return m_SecretRegTypes ; } }

		private static Type[] m_RegTypes = new Type[]
			{
				typeof( BlackPearl ),			typeof( Bloodmoss ),			typeof( Garlic ),
				typeof( Ginseng ),				typeof( MandrakeRoot ),			typeof( Nightshade ),
				typeof( SulfurousAsh ),			typeof( SpidersSilk )
			};

		public static Type[] RegTypes{ get{ return m_RegTypes; } }

		private static Type[] m_WitchRegTypes = new Type[]
			{
				typeof( BlackSand ),			typeof( BloodRose ),			typeof( DriedToad ),
				typeof( Maggot ),				typeof( MummyWrap ),			typeof( VioletFungus ),
				typeof( WerewolfClaw ),			typeof( Wolfsbane ),			typeof( BitterRoot ),
				typeof( BatWing ),				typeof( DaemonBlood ),			typeof( PigIron ),
				typeof( NoxCrystal ),			typeof( GraveDust ),			typeof( BlackPearl ),
				typeof( Bloodmoss ),			typeof( Brimstone ),			typeof( EyeOfToad ),
				typeof( GargoyleEar ),			typeof( BeetleShell ),			typeof( MoonCrystal ),
				typeof( PixieSkull ),			typeof( RedLotus ),				typeof( SilverWidow ),
				typeof( SwampBerries )
			};

		public static Type[] WitchRegTypes{ get{ return m_WitchRegTypes; } }

		private static Type[] m_DruidRegTypes = new Type[]
			{
				typeof( BlackPearl ),			typeof( Bloodmoss ),			typeof( Garlic ),
				typeof( Ginseng ),				typeof( MandrakeRoot ),			typeof( Nightshade ),
				typeof( SpidersSilk ),			typeof( SulfurousAsh ),			typeof( Brimstone ),
				typeof( ButterflyWings ),		typeof( EyeOfToad ),			typeof( FairyEgg ),
				typeof( BeetleShell ),			typeof( MoonCrystal ),			typeof( RedLotus ),
				typeof( SeaSalt ),				typeof( SilverWidow ),			typeof( SwampBerries )
			};

		public static Type[] DruidRegTypes{ get{ return m_DruidRegTypes; } }

		private static Type[] m_NecroRegTypes = new Type[]
			{
				typeof( BatWing ),				typeof( GraveDust ),			typeof( DaemonBlood ),
				typeof( NoxCrystal ),			typeof( PigIron )
			};

		public static Type[] NecroRegTypes{ get{ return m_NecroRegTypes; } }

		private static Type[] m_MixerRegTypes = new Type[]
			{
				typeof( EyeOfToad ),			typeof( FairyEgg ),				typeof( GargoyleEar ),
				typeof( BeetleShell ),			typeof( MoonCrystal ),			typeof( PixieSkull ),
				typeof( RedLotus ),				typeof( SeaSalt ),				typeof( SilverWidow ),
				typeof( SwampBerries ),			typeof( Brimstone ),			typeof( ButterflyWings )
			};

		public static Type[] MixerRegTypes{ get{ return m_MixerRegTypes; } }

		private static Type[] m_PotionTypes = new Type[]
			{
				typeof( AgilityPotion ),				typeof( StrengthPotion ),				typeof( RefreshPotion ),
				typeof( LesserCurePotion ),				typeof( LesserHealPotion ),				typeof( LesserPoisonPotion ),
				typeof( ConflagrationPotion ),			typeof( ConfusionBlastPotion ),			typeof( CurePotion ),
				typeof( DeadlyPoisonPotion ),			typeof( ExplosionPotion ),				typeof( GreaterAgilityPotion ),
				typeof( GreaterConflagrationPotion ),	typeof( GreaterConfusionBlastPotion ),	typeof( GreaterCurePotion ),
				typeof( GreaterExplosionPotion ),		typeof( GreaterHealPotion ),			typeof( GreaterPoisonPotion ),
				typeof( GreaterStrengthPotion ),		typeof( HealPotion ),					typeof( LesserExplosionPotion ),
				typeof( NightSightPotion ),				typeof( PoisonPotion ),					typeof( TotalRefreshPotion ),
				typeof( LethalPoisonPotion ),			typeof( RejuvenatePotion ),				typeof( GreaterRejuvenatePotion ),
				typeof( InvisibilityPotion ),			typeof( GreaterInvisibilityPotion ),	typeof( LesserInvisibilityPotion ),
				typeof( LesserManaPotion ),				typeof( ManaPotion ),
				typeof( GreaterManaPotion ),			typeof( LesserRejuvenatePotion ),
				typeof( FrostbitePotion ),				typeof( GreaterFrostbitePotion )
			};

		public static Type[] PotionTypes{ get{ return m_PotionTypes; } }

		private static Type[] m_UPotionTypes = new Type[]
			{
				typeof( UnknownLiquid )
			};

		public static Type[] UPotionTypes{ get{ return m_UPotionTypes; } }

		private static Type[] m_SEInstrumentTypes = new Type[]
			{
				typeof( Drums ),				typeof( LapHarp ),
				typeof( Lute ),					typeof( Tambourine ),
				typeof( BambooFlute ),			typeof( Trumpet )
			};

		public static Type[] SEInstrumentTypes{ get{ return m_SEInstrumentTypes; } }

		private static Type[] m_InstrumentTypes = new Type[]
			{
				typeof( Drums ),				typeof( LapHarp ),
				typeof( Lute ),					typeof( TambourineTassel ),
				typeof( BambooFlute )
			};

		public static Type[] InstrumentTypes{ get{ return m_InstrumentTypes; } }

		private static Type[] m_QuiverTypes = new Type[]
		{
			typeof( MagicQuiver )
		};

		public static Type[] QuiverTypes{ get{ return m_QuiverTypes; } }

		private static Type[] m_StatueTypes = new Type[]
		{
			typeof( StatueSouth ),			typeof( StatueSouth2 ),			typeof( StatueNorth ),
			typeof( StatueWest ),			typeof( StatueEast ),			typeof( StatueEast2 ),
			typeof( StatueSouthEast ),		typeof( BustSouth ),			typeof( BustEast )
		};

		public static Type[] StatueTypes{ get{ return m_StatueTypes; } }

		private static Type[] m_RegularScrollTypes = new Type[]
			{
				typeof( ReactiveArmorScroll ),	typeof( ClumsyScroll ),					typeof( CreateFoodScroll ),				typeof( FeeblemindScroll ),
				typeof( HealScroll ),			typeof( MagicArrowScroll ),				typeof( NightSightScroll ),				typeof( WeakenScroll ),
				typeof( AgilityScroll ),		typeof( CunningScroll ),				typeof( CureScroll ),					typeof( HarmScroll ),
				typeof( MagicTrapScroll ),		typeof( MagicUnTrapScroll ),			typeof( ProtectionScroll ),				typeof( StrengthScroll ),
				typeof( BlessScroll ),			typeof( FireballScroll ),				typeof( MagicLockScroll ),				typeof( PoisonScroll ),
				typeof( TelekinisisScroll ),	typeof( TeleportScroll ),				typeof( UnlockScroll ),					typeof( WallOfStoneScroll ),
				typeof( ArchCureScroll ),		typeof( ArchProtectionScroll ),			typeof( CurseScroll ),					typeof( FireFieldScroll ),
				typeof( GreaterHealScroll ),	typeof( LightningScroll ),				typeof( ManaDrainScroll ),				typeof( RecallScroll ),
				typeof( BladeSpiritsScroll ),	typeof( DispelFieldScroll ),			typeof( IncognitoScroll ),				typeof( MagicReflectScroll ),
				typeof( MindBlastScroll ),		typeof( ParalyzeScroll ),				typeof( PoisonFieldScroll ),			typeof( SummonCreatureScroll ),
				typeof( DispelScroll ),			typeof( EnergyBoltScroll ),				typeof( ExplosionScroll ),				typeof( InvisibilityScroll ),
				typeof( MarkScroll ),			typeof( MassCurseScroll ),				typeof( ParalyzeFieldScroll ),			typeof( RevealScroll ),
				typeof( ChainLightningScroll ), typeof( EnergyFieldScroll ),			typeof( FlamestrikeScroll ),			typeof( GateTravelScroll ),
				typeof( ManaVampireScroll ),	typeof( MassDispelScroll ),				typeof( MeteorSwarmScroll ),			typeof( PolymorphScroll ),
				typeof( EarthquakeScroll ),		typeof( EnergyVortexScroll ),			typeof( ResurrectionScroll ),			typeof( SummonAirElementalScroll ),
				typeof( SummonDaemonScroll ),	typeof( SummonEarthElementalScroll ),	typeof( SummonFireElementalScroll ),	typeof( SummonWaterElementalScroll )
			};

		private static Type[] m_NecromancyScrollTypes = new Type[]
			{
				typeof( AnimateDeadScroll ),		typeof( BloodOathScroll ),		typeof( CorpseSkinScroll ),	typeof( CurseWeaponScroll ),
				typeof( EvilOmenScroll ),			typeof( HorrificBeastScroll ),	typeof( LichFormScroll ),	typeof( MindRotScroll ),
				typeof( PainSpikeScroll ),			typeof( PoisonStrikeScroll ),	typeof( StrangleScroll ),	typeof( SummonFamiliarScroll ),
				typeof( VampiricEmbraceScroll ),	typeof( VengefulSpiritScroll ),	typeof( WitherScroll ),		typeof( WraithFormScroll ),
				typeof( ExorcismScroll )
			};

		private static Type[] m_PaladinScrollTypes = new Type[0];

		private static Type[] m_ElementalScrollTypes = new Type[]
			{
				typeof( Elemental_Armor_Scroll ),			typeof( Elemental_Bolt_Scroll ),			typeof( Elemental_Mend_Scroll ),
				typeof( Elemental_Sanctuary_Scroll ),		typeof( Elemental_Pain_Scroll ),			typeof( Elemental_Protection_Scroll ),
				typeof( Elemental_Purge_Scroll ),			typeof( Elemental_Steed_Scroll ),			typeof( Elemental_Call_Scroll ),
				typeof( Elemental_Force_Scroll ),			typeof( Elemental_Wall_Scroll ),			typeof( Elemental_Warp_Scroll ),
				typeof( Elemental_Field_Scroll ),			typeof( Elemental_Restoration_Scroll ),		typeof( Elemental_Strike_Scroll ),
				typeof( Elemental_Void_Scroll ),			typeof( Elemental_Blast_Scroll ),			typeof( Elemental_Echo_Scroll ),
				typeof( Elemental_Fiend_Scroll ),			typeof( Elemental_Hold_Scroll ),			typeof( Elemental_Barrage_Scroll ),
				typeof( Elemental_Rune_Scroll ),			typeof( Elemental_Storm_Scroll ),			typeof( Elemental_Summon_Scroll ),
				typeof( Elemental_Devastation_Scroll ),		typeof( Elemental_Fall_Scroll ),			typeof( Elemental_Gate_Scroll ),
				typeof( Elemental_Havoc_Scroll ),			typeof( Elemental_Apocalypse_Scroll ),		typeof( Elemental_Lord_Scroll ),
				typeof( Elemental_Soul_Scroll ),			typeof( Elemental_Spirit_Scroll )
			};

		public static Type[] RegularScrollTypes{ get{ return m_RegularScrollTypes; } }
		public static Type[] NecromancyScrollTypes{ get{ return m_NecromancyScrollTypes; } }
		public static Type[] PaladinScrollTypes{ get{ return m_PaladinScrollTypes; } }
		public static Type[] ElementalScrollTypes{ get{ return m_ElementalScrollTypes; } }

		private static Type[] m_WandTypes = new Type[]
			{
				typeof( AgilityMagicStaff ),		typeof( PoisonFieldMagicStaff ),	typeof( MagicArrowMagicStaff ),			typeof( EarthElementalMagicStaff ),
				typeof( AgilityMagicStaff ),		typeof( PoisonMagicStaff ),			typeof( MagicArrowMagicStaff ),			typeof( EarthquakeMagicStaff ),
				typeof( AgilityMagicStaff ),		typeof( PoisonMagicStaff ),			typeof( MagicArrowMagicStaff ),			typeof( EnergyBoltMagicStaff ),
				typeof( AgilityMagicStaff ),		typeof( PoisonMagicStaff ),			typeof( MagicLockMagicStaff ),			typeof( EnergyBoltMagicStaff ),
				typeof( AgilityMagicStaff ),		typeof( PoisonMagicStaff ),			typeof( MagicLockMagicStaff ),			typeof( EnergyBoltMagicStaff ),
				typeof( AgilityMagicStaff ),		typeof( PoisonMagicStaff ),			typeof( MagicLockMagicStaff ),			typeof( EnergyFieldMagicStaff ),
				typeof( AgilityMagicStaff ),		typeof( PoisonMagicStaff ),			typeof( MagicLockMagicStaff ),			typeof( EnergyFieldMagicStaff ),
				typeof( AirElementalMagicStaff ),	typeof( PolymorphMagicStaff ),		typeof( MagicLockMagicStaff ),			typeof( EnergyVortexMagicStaff ),
				typeof( ArchCureMagicStaff ),		typeof( PolymorphMagicStaff ),		typeof( MagicLockMagicStaff ),			typeof( ExplosionMagicStaff ),
				typeof( ArchCureMagicStaff ),		typeof( ProtectionMagicStaff ),		typeof( MagicReflectionMagicStaff ),	typeof( ExplosionMagicStaff ),
				typeof( ArchCureMagicStaff ),		typeof( ProtectionMagicStaff ),		typeof( MagicReflectionMagicStaff ),	typeof( ExplosionMagicStaff ),
				typeof( ArchCureMagicStaff ),		typeof( ProtectionMagicStaff ),		typeof( MagicReflectionMagicStaff ),	typeof( FeebleMagicStaff ),
				typeof( ArchCureMagicStaff ),		typeof( ProtectionMagicStaff ),		typeof( MagicReflectionMagicStaff ),	typeof( FeebleMagicStaff ),
				typeof( ArchProtectionMagicStaff ),	typeof( ProtectionMagicStaff ),		typeof( MagicTrapMagicStaff ),			typeof( FeebleMagicStaff ),
				typeof( ArchProtectionMagicStaff ),	typeof( ProtectionMagicStaff ),		typeof( MagicTrapMagicStaff ),			typeof( FeebleMagicStaff ),
				typeof( ArchProtectionMagicStaff ),	typeof( ProtectionMagicStaff ),		typeof( MagicTrapMagicStaff ),			typeof( FeebleMagicStaff ),
				typeof( ArchProtectionMagicStaff ),	typeof( ReactiveArmorMagicStaff ),	typeof( MagicTrapMagicStaff ),			typeof( FeebleMagicStaff ),
				typeof( ArchProtectionMagicStaff ),	typeof( ReactiveArmorMagicStaff ),	typeof( MagicTrapMagicStaff ),			typeof( FeebleMagicStaff ),
				typeof( BladeSpiritsMagicStaff ),	typeof( ReactiveArmorMagicStaff ),	typeof( MagicTrapMagicStaff ),			typeof( FeebleMagicStaff ),
				typeof( BladeSpiritsMagicStaff ),	typeof( ReactiveArmorMagicStaff ),	typeof( MagicTrapMagicStaff ),			typeof( FireballMagicStaff ),
				typeof( BladeSpiritsMagicStaff ),	typeof( ReactiveArmorMagicStaff ),	typeof( MagicUnlockMagicStaff ),		typeof( FireballMagicStaff ),
				typeof( BladeSpiritsMagicStaff ),	typeof( ReactiveArmorMagicStaff ),	typeof( MagicUnlockMagicStaff ),		typeof( FireballMagicStaff ),
				typeof( BlessMagicStaff ),			typeof( ReactiveArmorMagicStaff ),	typeof( MagicUnlockMagicStaff ),		typeof( FireballMagicStaff ),
				typeof( BlessMagicStaff ),			typeof( ReactiveArmorMagicStaff ),	typeof( MagicUnlockMagicStaff ),		typeof( FireballMagicStaff ),
				typeof( BlessMagicStaff ),			typeof( RecallMagicStaff ),			typeof( MagicUnlockMagicStaff ),		typeof( FireballMagicStaff ),
				typeof( BlessMagicStaff ),			typeof( RecallMagicStaff ),			typeof( MagicUnlockMagicStaff ),		typeof( FireElementalMagicStaff ),
				typeof( BlessMagicStaff ),			typeof( RecallMagicStaff ),			typeof( MagicUntrapMagicStaff ),		typeof( FireFieldMagicStaff ),
				typeof( BlessMagicStaff ),			typeof( RecallMagicStaff ),			typeof( MagicUntrapMagicStaff ),		typeof( FireFieldMagicStaff ),
				typeof( ChainLightningMagicStaff ),	typeof( RecallMagicStaff ),			typeof( MagicUntrapMagicStaff ),		typeof( FireFieldMagicStaff ),
				typeof( ChainLightningMagicStaff ),	typeof( ResurrectionMagicStaff ),	typeof( MagicUntrapMagicStaff ),		typeof( FireFieldMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( RevealMagicStaff ),			typeof( MagicUntrapMagicStaff ),		typeof( FireFieldMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( RevealMagicStaff ),			typeof( MagicUntrapMagicStaff ),		typeof( FlameStrikeMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( RevealMagicStaff ),			typeof( MagicUntrapMagicStaff ),		typeof( FlameStrikeMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( StrengthMagicStaff ),		typeof( ManaDrainMagicStaff ),			typeof( GateTravelMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( StrengthMagicStaff ),		typeof( ManaDrainMagicStaff ),			typeof( GateTravelMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( StrengthMagicStaff ),		typeof( ManaDrainMagicStaff ),			typeof( GreaterHealMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( StrengthMagicStaff ),		typeof( ManaDrainMagicStaff ),			typeof( GreaterHealMagicStaff ),
				typeof( ClumsyMagicStaff ),			typeof( StrengthMagicStaff ),		typeof( ManaDrainMagicStaff ),			typeof( GreaterHealMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( StrengthMagicStaff ),		typeof( ManaVampireMagicStaff ),		typeof( GreaterHealMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( StrengthMagicStaff ),		typeof( ManaVampireMagicStaff ),		typeof( GreaterHealMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( SummonCreatureMagicStaff ),	typeof( MarkMagicStaff ),				typeof( HarmMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( SummonCreatureMagicStaff ),	typeof( MarkMagicStaff ),				typeof( HarmMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( SummonCreatureMagicStaff ),	typeof( MarkMagicStaff ),				typeof( HarmMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( SummonCreatureMagicStaff ),	typeof( MassCurseMagicStaff ),			typeof( HarmMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( SummonDaemonMagicStaff ),	typeof( MassCurseMagicStaff ),			typeof( HarmMagicStaff ),
				typeof( CreateFoodMagicStaff ),		typeof( TelekinesisMagicStaff ),	typeof( MassCurseMagicStaff ),			typeof( HarmMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TelekinesisMagicStaff ),	typeof( MassDispelMagicStaff ),			typeof( HarmMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TelekinesisMagicStaff ),	typeof( MassDispelMagicStaff ),			typeof( HealMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TelekinesisMagicStaff ),	typeof( MeteorSwarmMagicStaff ),		typeof( HealMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TelekinesisMagicStaff ),	typeof( MeteorSwarmMagicStaff ),		typeof( HealMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TelekinesisMagicStaff ),	typeof( MindBlastMagicStaff ),			typeof( HealMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TeleportMagicStaff ),		typeof( MindBlastMagicStaff ),			typeof( HealMagicStaff ),
				typeof( CunningMagicStaff ),		typeof( TeleportMagicStaff ),		typeof( MindBlastMagicStaff ),			typeof( HealMagicStaff ),
				typeof( CureMagicStaff ),			typeof( TeleportMagicStaff ),		typeof( MindBlastMagicStaff ),			typeof( HealMagicStaff ),
				typeof( CureMagicStaff ),			typeof( TeleportMagicStaff ),		typeof( NightSightMagicStaff ),			typeof( HealMagicStaff ),
				typeof( CureMagicStaff ),			typeof( TeleportMagicStaff ),		typeof( NightSightMagicStaff ),			typeof( IncognitoMagicStaff ),
				typeof( CureMagicStaff ),			typeof( TeleportMagicStaff ),		typeof( NightSightMagicStaff ),			typeof( IncognitoMagicStaff ),
				typeof( CureMagicStaff ),			typeof( WallofStoneMagicStaff ),	typeof( NightSightMagicStaff ),			typeof( IncognitoMagicStaff ),
				typeof( CureMagicStaff ),			typeof( WallofStoneMagicStaff ),	typeof( NightSightMagicStaff ),			typeof( IncognitoMagicStaff ),
				typeof( CureMagicStaff ),			typeof( WallofStoneMagicStaff ),	typeof( NightSightMagicStaff ),			typeof( InvisibilityMagicStaff ),
				typeof( CurseMagicStaff ),			typeof( WallofStoneMagicStaff ),	typeof( NightSightMagicStaff ),			typeof( InvisibilityMagicStaff ),
				typeof( CurseMagicStaff ),			typeof( WallofStoneMagicStaff ),	typeof( NightSightMagicStaff ),			typeof( InvisibilityMagicStaff ),
				typeof( CurseMagicStaff ),			typeof( WallofStoneMagicStaff ),	typeof( ParalyzeFieldMagicStaff ),		typeof( LightningMagicStaff ),
				typeof( CurseMagicStaff ),			typeof( WaterElementalMagicStaff ),	typeof( ParalyzeFieldMagicStaff ),		typeof( LightningMagicStaff ),
				typeof( CurseMagicStaff ),			typeof( WeaknessMagicStaff ),		typeof( ParalyzeFieldMagicStaff ),		typeof( LightningMagicStaff ),
				typeof( DispelFieldMagicStaff ),	typeof( WeaknessMagicStaff ),		typeof( ParalyzeMagicStaff ),			typeof( LightningMagicStaff ),
				typeof( DispelFieldMagicStaff ),	typeof( WeaknessMagicStaff ),		typeof( ParalyzeMagicStaff ),			typeof( LightningMagicStaff ),
				typeof( DispelFieldMagicStaff ),	typeof( WeaknessMagicStaff ),		typeof( ParalyzeMagicStaff ),			typeof( MagicArrowMagicStaff ),
				typeof( DispelFieldMagicStaff ),	typeof( WeaknessMagicStaff ),		typeof( ParalyzeMagicStaff ),			typeof( MagicArrowMagicStaff ),
				typeof( DispelMagicStaff ),			typeof( WeaknessMagicStaff ),		typeof( PoisonFieldMagicStaff ),		typeof( MagicArrowMagicStaff ),
				typeof( DispelMagicStaff ),			typeof( WeaknessMagicStaff ),		typeof( PoisonFieldMagicStaff ),		typeof( MagicArrowMagicStaff ),
				typeof( DispelMagicStaff ),			typeof( WeaknessMagicStaff ),		typeof( PoisonFieldMagicStaff ),		typeof( MagicArrowMagicStaff ),
				typeof( IdentifyStaff ),			typeof( IdentifyStaff ),			typeof( IdentifyStaff ),				typeof( IdentifyStaff ),
				typeof( IdentifyStaff ),			typeof( IdentifyStaff ),			typeof( IdentifyStaff ),				typeof( IdentifyStaff )
			};
		public static Type[] WandTypes{ get{ return m_WandTypes; } }

		private static Type[] m_ArtyTypes = new Type[]
			{
				typeof( Artifact_AbysmalGloves ), 
				typeof( Artifact_AchillesShield ), 
				typeof( Artifact_AchillesSpear ), 
				typeof( Artifact_AcidProofRobe ), 
				typeof( Artifact_Aegis ), 
				typeof( Artifact_AegisOfGrace ), 
				typeof( Artifact_AilricsLongbow ), 
				typeof( Artifact_AlchemistsBauble ), 
				typeof( Artifact_ANecromancerShroud ), 
				typeof( Artifact_AngelicEmbrace ), 
				typeof( Artifact_AngeroftheGods ), 
				typeof( Artifact_Annihilation ), 
				typeof( Artifact_ArcaneArms ), 
				typeof( Artifact_ArcaneCap ), 
				typeof( Artifact_ArcaneGloves ), 
				typeof( Artifact_ArcaneGorget ), 
				typeof( Artifact_ArcaneLeggings ), 
				typeof( Artifact_ArcaneShield ), 
				typeof( Artifact_ArcaneTunic ), 
				typeof( Artifact_ArcanicRobe ), 
				typeof( Artifact_ArcticBeacon ), 
				typeof( Artifact_ArcticDeathDealer ), 
				typeof( Artifact_ArmorOfFortune ), 
				typeof( Artifact_ArmorOfInsight ), 
				typeof( Artifact_ArmorOfNobility ), 
				typeof( Artifact_ArmsOfAegis ), 
				typeof( Artifact_ArmsOfFortune ), 
				typeof( Artifact_ArmsOfInsight ), 
				typeof( Artifact_ArmsOfNobility ), 
				typeof( Artifact_ArmsOfTheFallenKing ), 
				typeof( Artifact_ArmsOfTheHarrower ), 
				typeof( Artifact_ArmsOfToxicity ), 
				typeof( Artifact_AuraOfShadows ), 
				typeof( Artifact_AxeOfTheHeavens ), 
				typeof( Artifact_AxeoftheMinotaur ), 
				typeof( Artifact_BeggarsRobe ), 
				typeof( Artifact_BelmontWhip ), 
				typeof( Artifact_BeltofHercules ), 
				typeof( Artifact_BladeDance ), 
				typeof( Artifact_BladeOfInsanity ), 
				typeof( Artifact_BladeOfTheRighteous ), 
				typeof( Artifact_BlazeOfDeath ), 
				typeof( Artifact_BlightGrippedLongbow ), 
				typeof( Artifact_BloodwoodSpirit ), 
				typeof( Artifact_BoneCrusher ), 
				typeof( Artifact_Bonesmasher ), 
				typeof( Artifact_BookOfKnowledge ), 
				typeof( Artifact_Boomstick ), 
				typeof( Artifact_BootsofHermes ), 
				typeof( Artifact_BowOfTheJukaKing ), 
				typeof( Artifact_BowofthePhoenix ), 
				typeof( Artifact_BraceletOfHealth ), 
				typeof( Artifact_BraceletOfTheElements ), 
				typeof( Artifact_BraceletOfTheVile ), 
				typeof( Artifact_BrambleCoat ), 
				typeof( Artifact_BraveKnightOfTheBritannia ), 
				typeof( Artifact_BreathOfTheDead ), 
				typeof( Artifact_BurglarsBandana ), 
				typeof( Artifact_Calm ), 
				typeof( Artifact_CandleCold ), 
				typeof( Artifact_CandleEnergy ), 
				typeof( Artifact_CandleFire ), 
				typeof( Artifact_CandleNecromancer ), 
				typeof( Artifact_CandlePoison ), 
				typeof( Artifact_CandleWizard ), 
				typeof( Artifact_CapOfFortune ), 
				typeof( Artifact_CapOfTheFallenKing ), 
				typeof( Artifact_CaptainJohnsHat ), 
				typeof( Artifact_CaptainQuacklebushsCutlass ), 
				typeof( Artifact_CavortingClub ), 
				typeof( Artifact_CircletOfTheSorceress ), 
				typeof( Artifact_CoifOfBane ), 
				typeof( Artifact_CoifOfFire ), 
				typeof( Artifact_ColdBlood ), 
				typeof( Artifact_ColdForgedBlade ), 
				typeof( Artifact_ConansHelm ), 
				typeof( Artifact_ConansLoinCloth ), 
				typeof( Artifact_ConansSword ), 
				typeof( Artifact_CrimsonCincture ), 
				typeof( Artifact_CrownOfTalKeesh ), 
				typeof( Artifact_DaggerOfVenom ), 
				typeof( Artifact_DarkGuardiansChest ), 
				typeof( Artifact_DarkLordsPitchfork ), 
				typeof( Artifact_DarkNeck ), 
				typeof( Artifact_DeathsMask ), 
				typeof( Artifact_DetectiveBoots ), 
				typeof( Artifact_DivineArms ), 
				typeof( Artifact_DivineCountenance ), 
				typeof( Artifact_DivineGloves ), 
				typeof( Artifact_DivineGorget ), 
				typeof( Artifact_DivineLeggings ), 
				typeof( Artifact_DivineTunic ), 
				typeof( Artifact_DjinnisRing ), 
				typeof( Artifact_DreadPirateHat ), 
				typeof( Artifact_DupresCollar ), 
				typeof( Artifact_DupresShield ), 
				typeof( Artifact_EarringsOfHealth ), 
				typeof( Artifact_EarringsOfTheElements ), 
				typeof( Artifact_EarringsOfTheMagician ), 
				typeof( Artifact_EarringsOfTheVile ), 
				typeof( Artifact_EmbroideredOakLeafCloak ), 
				typeof( Artifact_EnchantedTitanLegBone ), 
				typeof( Artifact_EssenceOfBattle ), 
				typeof( Artifact_EternalFlame ), 
				typeof( Artifact_EvilMageGloves ), 
				typeof( Artifact_Excalibur ), 
				typeof( Artifact_FalseGodsScepter ), 
				typeof( Artifact_FangOfRactus ), 
				typeof( Artifact_FesteringWound ), 
				typeof( Artifact_FeyLeggings ), 
				typeof( Artifact_FleshRipper ), 
				typeof( Artifact_Fortifiedarms ), 
				typeof( Artifact_FortunateBlades ), 
				typeof( Artifact_Frostbringer ), 
				typeof( Artifact_FurCapeOfTheSorceress ), 
				typeof( Artifact_Fury ), 
				typeof( Artifact_GandalfsHat ), 
				typeof( Artifact_GandalfsRobe ), 
				typeof( Artifact_GandalfsStaff ), 
				typeof( Artifact_GauntletsOfNobility ), 
				typeof( Artifact_GeishasObi ), 
				typeof( Artifact_GiantBlackjack ), 
				typeof( Artifact_GladiatorsCollar ), 
				typeof( Artifact_GlassSword ), 
				typeof( Artifact_GlovesOfAegis ), 
				typeof( Artifact_GlovesOfCorruption ), 
				typeof( Artifact_GlovesOfDexterity ), 
				typeof( Artifact_GlovesOfFortune ), 
				typeof( Artifact_GlovesOfInsight ), 
				typeof( Artifact_GlovesOfRegeneration ), 
				typeof( Artifact_GlovesOfTheFallenKing ), 
				typeof( Artifact_GlovesOfTheHarrower ), 
				typeof( Artifact_GlovesOfThePugilist ), 
				typeof( Artifact_GorgetOfAegis ), 
				typeof( Artifact_GorgetOfFortune ), 
				typeof( Artifact_GorgetOfInsight ), 
				typeof( Artifact_GrayMouserCloak ), 
				typeof( Artifact_GrimReapersLantern ), 
				typeof( Artifact_GrimReapersMask ), 
				typeof( Artifact_GrimReapersRobe ), 
				typeof( Artifact_GrimReapersScythe ), 
				typeof( Artifact_GuantletsOfAnger ), 
				typeof( Artifact_HammerofThor ), 
				typeof( Artifact_HatOfTheMagi ), 
				typeof( Artifact_HeartOfTheLion ), 
				typeof( Artifact_HellForgedArms ), 
				typeof( Artifact_HelmOfAegis ), 
				typeof( Artifact_HelmOfBrilliance ), 
				typeof( Artifact_HelmOfInsight ), 
				typeof( Artifact_HelmOfSwiftness ), 
				typeof( Artifact_HolyKnightsArmPlates ), 
				typeof( Artifact_HolyKnightsBreastplate ), 
				typeof( Artifact_HolyKnightsGloves ), 
				typeof( Artifact_HolyKnightsGorget ), 
				typeof( Artifact_HolyKnightsLegging ), 
				typeof( Artifact_HolyKnightsPlateHelm ), 
				typeof( Artifact_HolySword ), 
				typeof( Artifact_HoodedShroudOfShadows ), 
				typeof( HornOfKingTriton ), 
				typeof( Artifact_HuntersArms ), 
				typeof( Artifact_HuntersGloves ), 
				typeof( Artifact_HuntersGorget ), 
				typeof( Artifact_HuntersHeaddress ), 
				typeof( Artifact_HuntersLeggings ), 
				typeof( Artifact_HuntersTunic ), 
				typeof( Artifact_Indecency ), 
				typeof( Artifact_InquisitorsArms ), 
				typeof( Artifact_InquisitorsGorget ), 
				typeof( Artifact_InquisitorsHelm ), 
				typeof( Artifact_InquisitorsLeggings ), 
				typeof( Artifact_InquisitorsResolution ), 
				typeof( Artifact_InquisitorsTunic ), 
				typeof( Artifact_IronwoodCrown ), 
				typeof( Artifact_JackalsArms ), 
				typeof( Artifact_JackalsCollar ), 
				typeof( Artifact_JackalsGloves ), 
				typeof( Artifact_JackalsHelm ), 
				typeof( Artifact_JackalsLeggings ), 
				typeof( Artifact_JackalsTunic ), 
				typeof( Artifact_JadeScimitar ), 
				typeof( Artifact_JesterHatofChuckles ), 
				typeof( Artifact_JinBaoriOfGoodFortune ), 
				typeof( Artifact_KamiNarisIndestructableDoubleAxe ), 
				typeof( Artifact_KodiakBearMask ), 
				typeof( Artifact_LegacyOfTheDreadLord ), 
				typeof( Artifact_LeggingsOfAegis ), 
				typeof( Artifact_LeggingsOfBane ), 
				typeof( Artifact_LeggingsOfDeceit ), 
				typeof( Artifact_LeggingsOfEmbers ), 
				typeof( Artifact_LeggingsOfEnlightenment ), 
				typeof( Artifact_LeggingsOfFire ), 
				typeof( Artifact_LegsOfFortune ), 
				typeof( Artifact_LegsOfInsight ), 
				typeof( Artifact_LegsOfNobility ), 
				typeof( Artifact_LegsOfTheFallenKing ), 
				typeof( Artifact_LegsOfTheHarrower ), 
				typeof( Artifact_LieutenantOfTheBritannianRoyalGuard ), 
				typeof( Artifact_LongShot ), 
				typeof( Artifact_LuckyEarrings ), 
				typeof( Artifact_LuckyNecklace ), 
				typeof( Artifact_LuminousRuneBlade ), 
				typeof( Artifact_LunaLance ), 
				typeof( Artifact_MadmansHatchet ), 
				typeof( Artifact_MagesBand ), 
				typeof( Artifact_MagiciansIllusion ), 
				typeof( Artifact_MagiciansMempo ), 
				typeof( Artifact_MarbleShield ), 
				typeof( Artifact_MauloftheBeast ), 
				typeof( Artifact_MaulOfTheTitans ), 
				typeof( Artifact_MelisandesCorrodedHatchet ), 
				typeof( Artifact_MidnightBracers ), 
				typeof( Artifact_MidnightGloves ), 
				typeof( Artifact_MidnightHelm ), 
				typeof( Artifact_MidnightLegs ), 
				typeof( Artifact_MidnightTunic ), 
				typeof( Artifact_MinersPickaxe ), 
				typeof( Artifact_NightsKiss ), 
				typeof( Artifact_NordicVikingSword ), 
				typeof( Artifact_NoxBow ), 
				typeof( Artifact_NoxNightlight ), 
				typeof( Artifact_NoxRangersHeavyCrossbow ), 
				typeof( Artifact_OblivionsNeedle ), 
				typeof( Artifact_OrcChieftainHelm ), 
				typeof( Artifact_OrcishVisage ), 
				typeof( Artifact_OrnamentOfTheMagician ), 
				typeof( Artifact_OrnateCrownOfTheHarrower ), 
				typeof( Artifact_OssianGrimoire ), 
				typeof( Artifact_OverseerSunderedBlade ), 
				typeof( Artifact_Pacify ), 
				typeof( Artifact_PadsOfTheCuSidhe ), 
				typeof( Artifact_PendantOfTheMagi ), 
				typeof( Artifact_Pestilence ), 
				typeof( Artifact_PhantomStaff ), 
				typeof( Artifact_PixieSwatter ), 
				typeof( Artifact_PolarBearBoots ), 
				typeof( Artifact_PolarBearCape ), 
				typeof( Artifact_PolarBearMask ), 
				typeof( Artifact_PowerSurge ), 
				typeof( Artifact_Quell ), 
				typeof( Artifact_RaedsGlory ), 
				typeof( Artifact_RamusNecromanticScalpel ), 
				typeof( Artifact_ResilientBracer ), 
				typeof( Artifact_Retort ), 
				typeof( Artifact_RighteousAnger ), 
				typeof( Artifact_RingOfHealth ), 
				typeof( Artifact_RingOfProtection ), 
				typeof( Artifact_RingOfTheElements ), 
				typeof( Artifact_RingOfTheMagician ), 
				typeof( Artifact_RingOfTheVile ), 
				typeof( Artifact_RobeOfTeleportation ), 
				typeof( Artifact_RobeOfTheEclipse ), 
				typeof( Artifact_RobeOfTheEquinox ), 
				typeof( Artifact_RobeOfTreason ), 
				typeof( Artifact_RobinHoodsBow ), 
				typeof( Artifact_RobinHoodsFeatheredHat ), 
				typeof( Artifact_RodOfResurrection ), 
				typeof( Artifact_RoyalArchersBow ), 
				typeof( Artifact_RoyalGuardsChestplate ), 
				typeof( Artifact_RoyalGuardsGorget ), 
				typeof( Artifact_RoyalGuardSurvivalKnife ), 
				typeof( Artifact_RuneCarvingKnife ), 
				typeof( Artifact_SamaritanRobe ), 
				typeof( Artifact_SamuraiHelm ), 
				typeof( Artifact_SerpentsFang ), 
				typeof( Artifact_ShadowBlade ), 
				typeof( Artifact_ShadowDancerArms ), 
				typeof( Artifact_ShadowDancerCap ), 
				typeof( Artifact_ShadowDancerGloves ), 
				typeof( Artifact_ShadowDancerGorget ), 
				typeof( Artifact_ShadowDancerLeggings ), 
				typeof( Artifact_ShadowDancerTunic ), 
				typeof( Artifact_ShaMontorrossbow ), 
				typeof( Artifact_ShardThrasher ), 
				typeof( Artifact_ShieldOfInvulnerability ), 
				typeof( Artifact_ShimmeringTalisman ), 
				typeof( Artifact_ShroudOfDeciet ), 
				typeof( Artifact_SilvanisFeywoodBow ), 
				typeof( Artifact_SinbadsSword ), 
				typeof( Artifact_SongWovenMantle ), 
				typeof( Artifact_SoulSeeker ), 
				typeof( Artifact_SpellWovenBritches ), 
				typeof( Artifact_SpiritOfTheTotem ), 
				typeof( Artifact_SprintersSandals ), 
				typeof( Artifact_StaffOfPower ), 
				typeof( Artifact_StaffofSnakes ), 
				typeof( Artifact_StaffOfTheMagi ), 
				typeof( Artifact_StitchersMittens ), 
				typeof( Artifact_Stormbringer ), 
				typeof( Artifact_Subdue ), 
				typeof( Artifact_SwiftStrike ), 
				typeof( Artifact_TalonBite ), 
				typeof( Artifact_TheBeserkersMaul ), 
				typeof( Artifact_TheDragonSlayer ), 
				typeof( Artifact_TheDryadBow ), 
				typeof( Artifact_TheNightReaper ), 
				typeof( Artifact_TheRobeOfBritanniaAri ), 
				typeof( Artifact_TheTaskmaster ), 
				typeof( Artifact_TitansHammer ), 
				typeof( Artifact_TorchOfTrapFinding ), 
				typeof( Artifact_TotemArms ), 
				typeof( Artifact_TotemGloves ), 
				typeof( Artifact_TotemGorget ), 
				typeof( Artifact_TotemLeggings ), 
				typeof( Artifact_TotemOfVoid ), 
				typeof( Artifact_TotemTunic ), 
				typeof( Artifact_TownGuardsHalberd ), 
				typeof( Artifact_TunicOfAegis ), 
				typeof( Artifact_TunicOfBane ), 
				typeof( Artifact_TunicOfFire ), 
				typeof( Artifact_TunicOfTheFallenKing ), 
				typeof( Artifact_TunicOfTheHarrower ), 
				typeof( Artifact_VampiresRobe ), 
				typeof( Artifact_VampiricDaisho ), 
				typeof( Artifact_VioletCourage ), 
				typeof( Artifact_VoiceOfTheFallenKing ), 
				typeof( Artifact_WarriorsClasp ), 
				typeof( Artifact_WildfireBow ), 
				typeof( Artifact_Windsong ), 
				typeof( Artifact_WizardsPants ), 
				typeof( Artifact_WrathOfTheDryad ), 
				typeof( Artifact_YashimotosHatsuburi ), 
				typeof( Artifact_ZyronicClaw ), 
				typeof( GwennosHarp ), 
				typeof( IolosLute ), 
				typeof( QuiverOfBlight ), 
				typeof( QuiverOfElements ), 
				typeof( QuiverOfFire ), 
				typeof( QuiverOfIce ), 
				typeof( QuiverOfInfinity ), 
				typeof( QuiverOfLightning ), 
				typeof( QuiverOfRage ),
				typeof( Artifact_RobeofStratos ),
				typeof( Artifact_BootsofHydros ),
				typeof( Artifact_BootsofLithos ),
				typeof( Artifact_BootsofPyros ),
				typeof( Artifact_BootsofStratos ),
				typeof( Artifact_MantleofHydros ),
				typeof( Artifact_MantleofLithos ),
				typeof( Artifact_MantleofPyros ),
				typeof( Artifact_MantleofStratos ),
				typeof( Artifact_RobeofHydros ),
				typeof( Artifact_RobeofLithos ),
				typeof( Artifact_RobeofPyros ),
				typeof( Artifact_PyrosGrimoire ),
				typeof( Artifact_StratosManual ),
				typeof( Artifact_HydrosLexicon ),
				typeof( Artifact_LithosTome )
			};
		public static Type[] ArtyTypes{ get{ return m_ArtyTypes; } }

		private static Type[] m_RelicTypes = new Type[]
			{
				typeof( DDRelicCoins ),
				typeof( DDRelicClock1 ),			typeof( DDRelicClock2 ),				typeof( DDRelicClock3 ),
				typeof( DDRelicLight2 ), 			typeof( DDRelicLight1 ), 				typeof( DDRelicLight3 ),
				typeof( DDRelicVase ),				typeof( DDRelicPainting ),				typeof( DDRelicArts ),
				typeof( DDRelicStatue ), 			typeof( DDRelicRugAddonDeed ),			typeof( DDRelicWeapon ),
				typeof( DDRelicArmor ),				typeof( DDRelicJewels ),				typeof( DDRelicInstrument ),
				typeof( DDRelicScrolls ),			typeof( DDRelicCloth ),					typeof( DDRelicFur ),
				typeof( DDRelicDrink ),				typeof( DDRelicReagent ),				typeof( DDRelicOrbs ),
				typeof( DDRelicVase ),				typeof( DDRelicPainting ),				typeof( DDRelicArts ),
				typeof( DDRelicStatue ), 			typeof( DDRelicRugAddonDeed ),			typeof( DDRelicWeapon ),
				typeof( DDRelicArmor ),				typeof( DDRelicJewels ),				typeof( DDRelicInstrument ),
				typeof( DDRelicScrolls ),			typeof( DDRelicCloth ),					typeof( DDRelicFur ),
				typeof( DDRelicDrink ),				typeof( DDRelicReagent ),				typeof( DDRelicOrbs ),
				typeof( DDRelicVase ),				typeof( DDRelicPainting ),				typeof( DDRelicArts ),
				typeof( DDRelicStatue ), 			typeof( DDRelicRugAddonDeed ),			typeof( DDRelicWeapon ),
				typeof( DDRelicArmor ),				typeof( DDRelicJewels ),				typeof( DDRelicInstrument ),
				typeof( DDRelicScrolls ),			typeof( DDRelicCloth ),					typeof( DDRelicFur ),
				typeof( DDRelicDrink ),				typeof( DDRelicReagent ),				typeof( DDRelicOrbs ),
				typeof( DDRelicBearRugsAddonDeed ), typeof( DDRelicLeather ),				typeof( DDRelicAlchemy ),
				typeof( DDRelicBook ),				typeof( DDRelicBook ),					typeof( DDRelicBook ),
				typeof( DDRelicTablet ),			typeof( DDRelicGem ),					typeof( DDRelicBanner )
			};
		public static Type[] RelicTypes{ get{ return m_RelicTypes; } }

		private static Type[] m_SeaTypes = new Type[]
			{
				typeof( AdmiralsHeartyRum ),
				typeof( ShipModelOfTheHMSCape ),
				typeof( SeahorseStatuette ),
				typeof( GhostShipAnchor ),
				typeof( AquariumEastAddonDeed ),
				typeof( LightHouseAddonDeed ),
				typeof( MarlinEastAddonDeed ),
				typeof( MarlinSouthAddonDeed ),
				typeof( DolphinSouthSmallAddonDeed ),
				typeof( SkullEastLargeAddonDeed ),
				typeof( SkullEastSmallAddonDeed ),
				typeof( SkullSouthLargeAddonDeed ),
				typeof( SkullSouthSmallAddonDeed ),
				typeof( DolphinSouthLargeAddonDeed ),
				typeof( DolphinEastLargeAddonDeed ),
				typeof( AquariumSouthAddonDeed ),
				typeof( DolphinEastSmallAddonDeed ),
				typeof( SeaShell )
			};
		public static Type[] SeaTypes{ get{ return m_SeaTypes; } }

		private static Type[] m_SArtyTypes = new Type[]
			{
				typeof( GoldBricks ),				typeof( BedOfNailsDeed ),			typeof( DecoGinsengRoot ),		typeof( DecoRoseOfTrinsic ),
				typeof( PhillipsWoodenSteed ),		typeof( BoneCouchDeed ),			typeof( DecoGinsengRoot2 ),		typeof( DecoRoseOfTrinsic2 ),
				typeof( BoneTableDeed ),			typeof( DecoMandrake ),				typeof( DecoRoseOfTrinsic3 ),	typeof( SackOfHolding ),
				typeof( SoulStone ),				typeof( BoneThroneDeed ),			typeof( DecoMandrake2 ),		typeof( BrokenChair ),
				typeof( RedSoulstone ),				typeof( CreepyPortraitDeed ),		typeof( DecoMandrake3 ),		typeof( EmptyJar ),
				typeof( BlueSoulstone ),			typeof( DisturbingPortraitDeed ),	typeof( DecoMandrakeRoot ),		typeof( DecoFullJar ),
				typeof( MinotaurStatueDeed ),		typeof( HaunterMirrorDeed ),		typeof( DecoMandrakeRoot2 ),	typeof( HalfEmptyJar ),
				typeof( HangingSkeletonDeed ),		typeof( DirtPatch ),				typeof( DecoNightshade ),		typeof( DecoCrystalBall ),
				typeof( FlamingHeadDeed ),			typeof( EvilIdolSkull ),			typeof( DecoNightshade2 ),		typeof( DecoMagicalCrystal ),
				typeof( RewardBrazierDeed ),		typeof( WallBlood ),				typeof( DecoNightshade3 ),		typeof( DecoSpittoon ),
				typeof( BloodyPentagramDeed ),		typeof( SkullPole ),				typeof( DecoObsidian ),			typeof( DecoDeckOfTarot ),
				typeof( AnkhOfSacrificeDeed ),		typeof( MonsterStatueDeed ),		typeof( DecoPumice ),			typeof( DecoDeckOfTarot2 ),
				typeof( WeaponEngravingTool ),		typeof( DecoStatueDeed ),			typeof( DecoWyrmsHeart ),		typeof( DecoTarot ),
				typeof( IronMaidenDeed ),			typeof( GrizzledMareStatuette ),	typeof( DecoArrowShafts ),		typeof( DecoTarot2 ),
				typeof( StoneStatueDeed ),			typeof( TormentedChains ),			typeof( CrossbowBolts ),		typeof( DecoTarot3 ),
				typeof( MountedPixieWhiteDeed ),	typeof( DecoBlackmoor ),			typeof( EmptyToolKit ),			typeof( DecoTarot4 ),
				typeof( MountedPixieBlueDeed ),		typeof( DecoBloodspawn ),			typeof( EmptyToolKit2 ),		typeof( DecoTarot5 ),
				typeof( MountedPixieGreenDeed ),	typeof( DecoBrimstone ),			typeof( Lockpicks ),			typeof( DecoTarot6 ),
				typeof( MountedPixieLimeDeed ),		typeof( DecoDragonsBlood ),			typeof( ToolKit ),				typeof( DecoTarot7 ),
				typeof( MountedPixieOrangeDeed ),	typeof( DecoDragonsBlood2 ),		typeof( UnfinishedBarrel ),		typeof( Cards ),
				typeof( SacrificialAltarDeed ),		typeof( DecoEyeOfNewt ),			typeof( DecoRock2 ),			typeof( Cards2 ),
				typeof( UnsettlingPortraitDeed ),	typeof( DecoGarlic ),				typeof( DecoRocks ),			typeof( Cards3 ),
				typeof( GuillotineDeed ),			typeof( DecoGarlic2 ),				typeof( DecoRocks2 ),			typeof( Cards4 ),
				typeof( WindSpirit ),				typeof( DecoGarlicBulb ),			typeof( DecoRock ),				typeof( DecoCards5 ),
				typeof( SuitOfGoldArmorDeed ),		typeof( DecoGarlicBulb2 ),			typeof( DecoFlower ),			typeof( PlayingCards ),
				typeof( SuitOfSilverArmorDeed ),	typeof( DecoGinseng ),				typeof( DecoFlower2 ),			typeof( PlayingCards2 ),
				typeof( WoodenCoffinDeed ),			typeof( DecoGinseng2 ),				typeof( JokeBook ),				typeof( HorseArmor ),
				typeof( Dice4 ),					typeof( Dice6 ),					typeof( Dice8 ),				typeof( Dice10 ),
				typeof( Dice12 ),					typeof( Dice20 ),					typeof( MonsterManual ),		typeof( PlayersHandbook ),
				typeof( DungeonMastersGuide ),		typeof( GygaxStatue ), 				typeof( DragonOrbStatue ),		typeof( WizardsStatue ),
				typeof( PandorasBox ),				typeof( ColoringBook ),				typeof( EverlastingBottle ),	typeof( EverlastingLoaf ),
				typeof( GemOfSeeing ),				typeof( AwesomeDisturbingPortraitDeed ),							typeof( CandelabraOfSouls )
			};
		public static Type[] SArtyTypes{ get{ return m_SArtyTypes; } }
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		private static Type[] m_SEClothingTypes = new Type[]
			{
				typeof( ClothNinjaJacket ),		typeof( FemaleKimono ),			typeof( Hakama ),
				typeof( HakamaShita ),			typeof( JinBaori ),				typeof( Kamishimo ),
				typeof( MaleKimono ),			typeof( NinjaTabi ),			typeof( Obi ),
				typeof( SamuraiTabi ),			typeof( TattsukeHakama ),		typeof( Waraji ),
				typeof( LeatherNinjaBelt )
			};

		public static Type[] SEClothingTypes{ get{ return m_SEClothingTypes; } }

		private static Type[] m_AosClothingTypes = new Type[]
			{
				typeof( FurSarong ),			typeof( FurCape ),				typeof( FlowerGarland ),
				typeof( GildedDress ),			typeof( FurBoots ),				typeof( FormalShirt ),
				typeof( WhiteFurRobe ),			typeof( WhiteFurBoots ), 		typeof( WhiteFurSarong ),
				typeof( FurRobe ),				typeof( Boots ),				typeof( Sandals ),
				typeof( ThighBoots )
		};

		public static Type[] AosClothingTypes{ get{ return m_AosClothingTypes; } }

		private static Type[] m_ClothingTypes = new Type[]
			{
				typeof( Bonnet ),               typeof( Cap ),		            typeof( FeatheredHat ),
				typeof( FloppyHat ),            typeof( JesterHat ),			typeof( Surcoat ),
				typeof( SkullCap ),             typeof( StrawHat ),	            typeof( TallStrawHat ),
				typeof( TricorneHat ),			typeof( WideBrimHat ),          typeof( WizardsHat ),
				typeof( ReaperHood ),			typeof( ReaperCowl ),			typeof( FancyHood ),
				typeof( Boots ),				typeof( Sandals ),				typeof( Shoes ),
				typeof( ThighBoots ),			typeof( Boots ),				typeof( Sandals ),
				typeof( Shoes ),				typeof( ThighBoots ),			typeof( WitchHat ),
				typeof( BodySash ),             typeof( Doublet ),				typeof( FancyShirt ),
				typeof( FullApron ),            typeof( JesterSuit ),  			typeof( ClothHood ),         
				typeof( Tunic ),				typeof( Shirt ),				typeof( ClothCowl ),
				typeof( FancyDress ),			typeof( PlainDress ),           typeof( Robe ),
				typeof( JokerRobe ),			typeof( AssassinRobe ),			typeof( FancyRobe ),
				typeof( GildedRobe ),			typeof( OrnateRobe ),			typeof( MagistrateRobe ),
				typeof( RoyalRobe ),			typeof( SorcererRobe ),			typeof( ScholarRobe ),
				typeof( NecromancerRobe ),		typeof( SpiderRobe ),			typeof( PirateHat ),
				typeof( HalfApron ), 			typeof( LoinCloth ),			typeof( VagabondRobe), 
				typeof( ShortPants ),			typeof( LongPants ),			typeof( Kilt ),
				typeof( Skirt ),				typeof( ShortPants ),			typeof( LongPants ),
				typeof( Kilt ),					typeof( Skirt ),				typeof( WhiteFurCape ),			
				typeof( Cloak ),				typeof( RoyalCape ), 			typeof( PirateCoat ),
				typeof( Cloak ),				typeof( RoyalCape ), 			typeof( JokerHat ),
				typeof( Cloak ),				typeof( RoyalCape ),			typeof( FoolsCoat ),
				typeof( JesterGarb ),			typeof( FurRobe ), 				typeof( FurCap ),
				typeof( FurCape ),				typeof( HoodedMantle ), 
				typeof( ExquisiteRobe ),		typeof( ProphetRobe ),			typeof( ElegantRobe ),
				typeof( FormalRobe ),			typeof( ArchmageRobe ),			typeof( PriestRobe ),
				typeof( CultistRobe ),			typeof( GildedDarkRobe ),		typeof( GildedLightRobe ),
				typeof( SageRobe ),				typeof( RoyalCoat ),			typeof( RoyalShirt ),
				typeof( RusticShirt ),			typeof( SquireShirt ),			typeof( FormalCoat ),
				typeof( WizardShirt ),			typeof( BeggarVest ),			typeof( RoyalVest ),
				typeof( RusticVest ),			typeof( SailorPants ),			typeof( PiratePants ),
				typeof( DeadMask ),				typeof( WizardHood ),			typeof( RoyalSkirt ),
				typeof( RoyalLongSkirt ),		typeof( BarbarianBoots )
			};
		public static Type[] ClothingTypes{ get{ return m_ClothingTypes; } }

		private static Type[] m_SEHatTypes = new Type[]
			{
				typeof( ClothNinjaHood ),		typeof( Kasa ), 				typeof( Bandana )
			};

		public static Type[] SEHatTypes{ get{ return m_SEHatTypes; } }

		private static Type[] m_AosHatTypes = new Type[]
			{
				typeof( FlowerGarland ),	typeof( BearMask ),		typeof( DeerMask ),		typeof( StagMask), 
				typeof( WolfMask ), 		typeof( WhiteFurCap ), 	typeof( FurCap )
			};

		public static Type[] AosHatTypes{ get{ return m_AosHatTypes; } }

		private static Type[] m_HatTypes = new Type[]
			{
				typeof( SkullCap ),			typeof( Bandana ),		typeof( FloppyHat ),
				typeof( Cap ),				typeof( WideBrimHat ),	typeof( StrawHat ),
				typeof( TallStrawHat ),		typeof( WizardsHat ),	typeof( Bonnet ),
				typeof( WitchHat ),			typeof( ClothCowl ),	typeof( ClothHood ),
				typeof( FeatheredHat ),		typeof( TricorneHat ),	typeof( JesterHat ),
				typeof( PirateHat ),		typeof( JokerHat ),		typeof( FancyHood ),
				typeof( DeadMask ),			typeof( WizardHood ),	typeof( HoodedMantle )
			};

		public static Type[] HatTypes{ get{ return m_HatTypes; } }

		#endregion

		#region Accessors

		public static BaseMagicStaff RandomWand()
		{
			return Construct( m_WandTypes ) as BaseMagicStaff;
		}

		public static BaseClothing RandomClothing()
		{
			return RandomClothing( false );
		}

		public static BaseClothing RandomClothing( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEClothingTypes ) as BaseClothing;

			return Construct( m_AosClothingTypes, m_ClothingTypes ) as BaseClothing;
		}

		public static BaseHat RandomHats()
		{
			return RandomHats( false );
		}

		public static BaseHat RandomHats( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEHatTypes ) as BaseHat;

			return Construct( m_AosHatTypes, m_HatTypes ) as BaseHat;
		}

		public static BaseWeapon RandomRangedWeapon()
		{
			return RandomRangedWeapon( false );
		}

		public static BaseWeapon RandomRangedWeapon( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SERangedWeaponTypes ) as BaseWeapon;

			return Construct( m_AosRangedWeaponTypes, m_RangedWeaponTypes ) as BaseWeapon;
		}

		public static BaseWeapon RandomWeapon()
		{
			return RandomWeapon( false );
		}

		public static BaseWeapon RandomWeapon( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEWeaponTypes ) as BaseWeapon;

			return Construct( m_AosWeaponTypes, m_WeaponTypes ) as BaseWeapon;
		}

		public static Item RandomWeaponOrJewelry()
		{
			return RandomWeaponOrJewelry( false );
		}

		public static Item RandomWeaponOrJewelry( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEWeaponTypes, m_JewelryTypes );

			return Construct( m_AosWeaponTypes, m_WeaponTypes, m_JewelryTypes );
		}

		public static BaseJewel RandomJewelry()
		{
			return Construct( m_JewelryTypes ) as BaseJewel;
		}

		public static BaseArmor RandomArmor()
		{
			return RandomArmor( false );
		}

		public static BaseArmor RandomArmor( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEArmorTypes ) as BaseArmor;

			if ( 1 == Utility.Random( 1000 ) )
				return Construct( m_DragonArmorTypes ) as BaseArmor;

			return Construct( m_ArmorTypes ) as BaseArmor;
		}

		public static BaseHat RandomHat()
		{
			return RandomHat( false );
		}

		public static BaseHat RandomHat( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEHatTypes ) as BaseHat;

			return Construct( m_AosHatTypes, m_HatTypes ) as BaseHat;
		}

		public static Item RandomArmorOrHatOrClothes()
		{
			return RandomArmorOrHatOrClothes( false );
		}

		public static Item RandomArmorOrHatOrClothes( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEArmorTypes, m_SEHatTypes, m_SEClothingTypes );

			if ( 1 == Utility.Random( 2000 ) )
				return Construct( m_DragonArmorTypes );

			return Construct( m_ArmorTypes, m_ArmorTypes, m_ArmorTypes, m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosClothingTypes, m_ClothingTypes );
		}

		public static BaseShield RandomShield()
		{
			return Construct( m_AosShieldTypes, m_ShieldTypes ) as BaseShield;
		}

		public static BaseArmor RandomArmorOrShield()
		{
			return RandomArmorOrShield( false );
		}

		public static BaseArmor RandomArmorOrShield( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEArmorTypes, m_AosShieldTypes, m_ShieldTypes ) as BaseArmor;

			if ( 1 == Utility.Random( 2000 ) )
				return Construct( m_DragonArmorTypes ) as BaseArmor;

			return Construct( m_ArmorTypes, m_AosShieldTypes, m_ShieldTypes ) as BaseArmor;
		}

		public static Item RandomArmorOrShieldOrJewelry()
		{
			return RandomArmorOrShieldOrJewelry( false );
		}

		public static Item RandomArmorOrShieldOrJewelry( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEArmorTypes, m_SEHatTypes, m_AosShieldTypes, m_ShieldTypes, m_JewelryTypes );

			if ( 1 == Utility.Random( 3000 ) )
				return Construct( m_DragonArmorTypes );

			return Construct( m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosShieldTypes, m_ShieldTypes, m_JewelryTypes );
		}

		public static Item RandomArmorOrShieldOrWeapon()
		{
			return RandomArmorOrShieldOrWeapon( false );
		}

		public static Item RandomArmorOrShieldOrWeapon( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEWeaponTypes, m_SERangedWeaponTypes, m_SEArmorTypes, m_SEHatTypes, m_AosShieldTypes, m_ShieldTypes );

			if ( 1 == Utility.Random( 3000 ) )
				return Construct( m_DragonArmorTypes );

			return Construct( m_AosWeaponTypes, m_WeaponTypes, m_AosRangedWeaponTypes, m_RangedWeaponTypes, m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosShieldTypes, m_ShieldTypes );
		}

		public static Item RandomArmorOrShieldOrWeaponOrJewelryOrClothing()
		{
			return RandomArmorOrShieldOrWeaponOrJewelryOrClothing( false );
		}

		public static Item RandomArmorOrShieldOrWeaponOrJewelryOrClothing( bool inIslesDread )
		{
			if ( inIslesDread )
				return Construct( m_SEWeaponTypes, m_SERangedWeaponTypes, m_SEArmorTypes, m_SEHatTypes, m_AosShieldTypes, m_ShieldTypes, m_JewelryTypes, m_SEClothingTypes );

			if ( 1 == Utility.Random( 4000 ) )
				return Construct( m_DragonArmorTypes ) as BaseArmor;

			return Construct( m_AosWeaponTypes, m_WeaponTypes, m_AosRangedWeaponTypes, m_RangedWeaponTypes, m_ArmorTypes, m_AosHatTypes, m_HatTypes, m_AosShieldTypes, m_ShieldTypes, m_JewelryTypes, m_AosClothingTypes, m_ClothingTypes );
		}
		
		#region Chest of Heirlooms
		public static Item ChestOfHeirloomsContains()
		{
			return Construct( m_SEArmorTypes, m_SEHatTypes, m_SEWeaponTypes, m_SERangedWeaponTypes, m_JewelryTypes );
		}
		#endregion

		public static Item RandomFoods()
		{
			return Construct( m_FoodsTypes );
		}

		public static Item RandomGem()
		{
			return Construct( m_GemTypes );
		}

		public static Item RandomArty()
		{
			return Construct( m_ArtyTypes );
		}

		public static Item RandomSArty()
		{
			return Construct( m_SArtyTypes );
		}

		public static Item RandomRelic()
		{
			return Construct( m_RelicTypes );
		}

		public static Item RandomSea()
		{
			return Construct( m_SeaTypes );
		}

		public static Item RandomSecretReagent()
		{
			return Construct( m_SecretRegTypes );
		}
		////////////////////////////////////////////////////

		public static Item RandomReagent()
		{
			return Construct( m_RegTypes );
		}

		public static Item RandomDruidReagent()
		{
			return Construct( m_DruidRegTypes );
		}

		public static Item RandomWitchReagent()
		{
			return Construct( m_WitchRegTypes );
		}

		public static Item RandomNecromancyReagent()
		{
			return Construct( m_NecroRegTypes );
		}

		public static Item RandomMixerReagent()
		{
			return Construct( m_MixerRegTypes );
		}

		public static Item RandomPossibleReagent()
		{
			return Construct( m_RegTypes, m_WitchRegTypes, m_NecroRegTypes, m_MixerRegTypes );
		}

		public static Item RandomPotion()
		{
			if ( MyServerSettings.GetUnidentifiedChance() >= Utility.RandomMinMax( 1, 100 ) )
				return Construct( m_UPotionTypes );

			return Construct( m_PotionTypes );
		}

		public static BaseInstrument RandomInstrument()
		{
			if ( Core.SE )
				return Construct( m_InstrumentTypes, m_SEInstrumentTypes ) as BaseInstrument;

			return Construct( m_InstrumentTypes ) as BaseInstrument;
		}

		public static Item RandomStatue()
		{
			return Construct( m_StatueTypes );
		}

		public static BaseQuiver RandomQuiver()
		{
			return Construct( m_QuiverTypes ) as BaseQuiver;
		}

		public static SpellScroll RandomScroll( int minIndex, int maxIndex, SpellbookType type )
		{
			Type[] types;

			switch ( type )
			{
				default:
				case SpellbookType.Regular: types = m_RegularScrollTypes; break;
				case SpellbookType.Necromancer: types = m_NecromancyScrollTypes; break;
				case SpellbookType.Elementalism: types = m_ElementalScrollTypes; break;
			}

			return Construct( types, Utility.RandomMinMax( minIndex, maxIndex ) ) as SpellScroll;
		}

		#endregion

		#region Construction methods
		public static Item Construct( Type type )
		{
			try
			{
				return Activator.CreateInstance( type ) as Item;
			}
			catch
			{
				return null;
			}
		}

		public static Item Construct( Type[] types )
		{
			if ( types.Length > 0 )
				return Construct( types, Utility.Random( types.Length ) );

			return null;
		}

		public static Item Construct( Type[] types, int index )
		{
			if ( index >= 0 && index < types.Length )
				return Construct( types[index] );

			return null;
		}

		public static Item Construct( params Type[][] types )
		{
			int totalLength = 0;

			for ( int i = 0; i < types.Length; ++i )
				totalLength += types[i].Length;

			if ( totalLength > 0 )
			{
				int index = Utility.Random( totalLength );

				for ( int i = 0; i < types.Length; ++i )
				{
					if ( index >= 0 && index < types[i].Length )
						return Construct( types[i][index] );

					index -= types[i].Length;
				}
			}

			return null;
		}
		#endregion
	}
}