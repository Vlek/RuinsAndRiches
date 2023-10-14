using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using Server.Targeting;
using System.Collections.Generic;
using Server.Items;
using Server.Spells.Fifth;
using System.IO;
using System.Xml;

namespace Server.Misc
{
class MyServerSettings
{
    public static string ServerName()
    {
        return "Ruins & Riches";
    }

    public static string Version()
    {
        return "Version: Dracula (20 Sep 2022)";
    }

    public static void UpdateWarning()
    {
        if (Utility.DateUpdated() != 2021220)
        {
            Console.WriteLine("Warning: Your World.exe requires an update!");
        }
    }

    public static string FilesPath()
    {
        return "Data/Files";
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private static bool S_EnableConsole                = true;
    private static double S_ServerSaveMinutes          = 30.0;
    private static bool S_SaveOnCharacterLogout        = true;
    private static bool S_PersistentBlackjack          = false;
    private static int S_FloorTrapTrigger              = 20;
    private static int S_GetUnidentifiedChance         = 50;
    private static bool S_NoMacroing                   = false;
    private static double S_StatGain                   = 33.3;
    private static double S_StatGainDelay              = 15.0;
    private static double S_PetStatGainDelay           = 5.0;
    private static int S_GetTimeBetweenQuests          = 60;
    private static int S_GetTimeBetweenArtifactQuests  = 20160;
    private static int S_GetGoldCutRate                = 25;
    private static bool S_AllowMacroResources          = true;
    private static bool S_CreaturesSearching           = true;
    private static bool S_GuardsSentenceDeath          = false;
    private static bool S_GuardsPatrolOutside          = false;
    private static bool S_GuardsSprint                 = true;
    private static bool S_NoMountsInCertainRegions     = true;
    private static bool S_AllowAlienChoice             = true;
    private static bool S_AnnounceTrapSaves            = false;
    private static bool S_IdentifyItemsOnlyInPack      = false;
    private static double S_DamageToPets               = 1.0;
    private static int S_CriticalToPets                = 0;
    private static int S_SpellDamageIncreaseVsMonsters = 200;
    private static int S_SpellDamageIncreaseVsPlayers  = 100;
    private static bool S_RunRoutinesAtStartup         = true;
    private static int S_QuestRewardModifier           = 150;
    private static double S_PlayerLevelMod             = 2.0;
    private static int S_WyrmBody                   = 723;
    private static bool S_Quest                     = true;
    private static bool S_FastFriends               = true;
    private static bool S_FriendsAvoidHeels         = true;
    private static bool S_FriendsGuardFriends       = true;
    private static double S_BoatDecay               = 365.0;
    private static double S_HomeDecay               = 365.0;
    private static bool S_HousesDecay               = false;
    private static int S_HousesPerAccount           = 5;
    private static bool S_EnableDungeonSoundEffects = true;
    private static int S_SellChance                 = 50;
    private static int S_SellCommonChance           = 80;
    private static int S_SellRareChance             = 25;
    private static int S_SellVeryRareChance         = 5;
    private static int S_BuyChance                  = 100;
    private static int S_BuyCommonChance            = 100;
    private static int S_BuyRareChance              = 100;
    private static bool S_ShinyArmor                = true;
    private static bool S_NewLeather                = true;
    private static bool S_Leopards                  = true;
    private static bool S_Elephants                 = false;
    private static bool S_Zebras                    = true;
    private static bool S_Fox                      = true;
    private static bool S_Basements                = false;
    private static bool S_NoMountBuilding          = true;
    private static bool S_NoMountsInHouses         = true;
    private static bool S_AllowCustomTitles        = true;
    private static bool S_AllowHouseDyes           = true;
    private static bool S_AllowCustomHomes         = true;
    private static bool S_AllowCraftMagic          = true;
    private static int S_Bribery                   = 50000;
    private static bool S_LineOfSight              = true;
    private static bool S_ChangeArtyLook           = false;
    private static int S_Resources                 = 1;
    private static bool S_SoldResource             = false;
    private static bool S_Humanoids                = true;
    private static bool S_MerchantBooks            = true;
    private static bool S_HouseStorage             = false;
    private static int S_CorpseDecay               = 7;
    private static int S_BoneDecay                 = 113;
    private static bool S_HouseOwners              = false;
    private static bool S_LawnsAllowed             = true;
    private static bool S_ShantysAllowed           = true;
    private static int S_MonsterCharacters         = 1;
    private static double S_DeleteDays             = 7.0;
    private static bool S_AutoAccounts             = true;
    private static int S_Port                      = 2593;
    private static double S_SpecialWeaponAbilSkill = 70.0;
    private static int S_Stables                   = 2;
    private static double S_HPModifier             = 0.0;

    public static void Configure()
    {
        if (System.IO.File.Exists("Info/settings.xml"))
        {
            UpdateWarning();
            XmlDocument doc = new XmlDocument();
            doc.Load(System.IO.Path.Combine(Core.BaseDirectory, "Info/settings.xml"));

            XmlElement root = doc["settings"];

            if (root != null)
            {
                int setting = 1;

                foreach (XmlElement node in root.SelectNodes("setting"))
                {
                    if (setting == 1)
                    {
                        S_EnableConsole = bool.Parse(node.InnerText);
                    }
                    else if (setting == 2)
                    {
                        S_ServerSaveMinutes = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 3)
                    {
                        S_SaveOnCharacterLogout = bool.Parse(node.InnerText);
                    }
                    else if (setting == 4)
                    {
                        S_PersistentBlackjack = bool.Parse(node.InnerText);
                    }
                    else if (setting == 5)
                    {
                        S_FloorTrapTrigger = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 6)
                    {
                        S_GetUnidentifiedChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 7)
                    {
                        S_NoMacroing = bool.Parse(node.InnerText);
                    }
                    else if (setting == 8)
                    {
                        S_StatGain = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 9)
                    {
                        S_StatGainDelay = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 10)
                    {
                        S_PetStatGainDelay = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 11)
                    {
                        S_GetTimeBetweenQuests = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 12)
                    {
                        S_GetTimeBetweenArtifactQuests = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 13)
                    {
                        S_GetGoldCutRate = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 14)
                    {
                        S_AllowMacroResources = bool.Parse(node.InnerText);
                    }
                    else if (setting == 15)
                    {
                        S_CreaturesSearching = bool.Parse(node.InnerText);
                    }
                    else if (setting == 16)
                    {
                        S_GuardsSentenceDeath = bool.Parse(node.InnerText);
                    }
                    else if (setting == 17)
                    {
                        S_GuardsPatrolOutside = bool.Parse(node.InnerText);
                    }
                    else if (setting == 18)
                    {
                        S_GuardsSprint = bool.Parse(node.InnerText);
                    }
                    else if (setting == 19)
                    {
                        S_NoMountsInCertainRegions = bool.Parse(node.InnerText);
                    }
                    else if (setting == 20)
                    {
                        S_AllowAlienChoice = bool.Parse(node.InnerText);
                    }
                    else if (setting == 21)
                    {
                        S_AnnounceTrapSaves = bool.Parse(node.InnerText);
                    }
                    else if (setting == 22)
                    {
                        S_IdentifyItemsOnlyInPack = bool.Parse(node.InnerText);
                    }
                    else if (setting == 23)
                    {
                        S_DamageToPets = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 24)
                    {
                        S_CriticalToPets = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 25)
                    {
                        S_SpellDamageIncreaseVsMonsters = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 26)
                    {
                        S_SpellDamageIncreaseVsPlayers = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 27)
                    {
                        S_RunRoutinesAtStartup = bool.Parse(node.InnerText);
                    }
                    else if (setting == 28)
                    {
                        S_QuestRewardModifier = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 29)
                    {
                        S_PlayerLevelMod = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 30)
                    {
                        S_WyrmBody = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 31)
                    {
                        S_Quest = bool.Parse(node.InnerText);
                    }
                    else if (setting == 32)
                    {
                        S_FastFriends = bool.Parse(node.InnerText);
                    }
                    else if (setting == 33)
                    {
                        S_FriendsAvoidHeels = bool.Parse(node.InnerText);
                    }
                    else if (setting == 34)
                    {
                        S_FriendsGuardFriends = bool.Parse(node.InnerText);
                    }
                    else if (setting == 35)
                    {
                        S_BoatDecay = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 36)
                    {
                        S_HomeDecay = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 37)
                    {
                        S_HousesDecay = bool.Parse(node.InnerText);
                    }
                    else if (setting == 38)
                    {
                        S_HousesPerAccount = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 39)
                    {
                        S_EnableDungeonSoundEffects = bool.Parse(node.InnerText);
                    }
                    else if (setting == 40)
                    {
                        S_SellChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 41)
                    {
                        S_SellCommonChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 42)
                    {
                        S_SellRareChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 43)
                    {
                        S_SellVeryRareChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 44)
                    {
                        S_BuyChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 45)
                    {
                        S_BuyCommonChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 46)
                    {
                        S_BuyRareChance = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 47)
                    {
                        S_ShinyArmor = bool.Parse(node.InnerText);
                    }
                    else if (setting == 48)
                    {
                        S_NewLeather = bool.Parse(node.InnerText);
                    }
                    else if (setting == 49)
                    {
                        S_Leopards = bool.Parse(node.InnerText);
                    }
                    else if (setting == 50)
                    {
                        S_Elephants = bool.Parse(node.InnerText);
                    }
                    else if (setting == 51)
                    {
                        S_Zebras = bool.Parse(node.InnerText);
                    }
                    else if (setting == 52)
                    {
                        S_Fox = bool.Parse(node.InnerText);
                    }
                    else if (setting == 53)
                    {
                        S_Basements = bool.Parse(node.InnerText);
                    }
                    else if (setting == 54)
                    {
                        S_NoMountBuilding = bool.Parse(node.InnerText);
                    }
                    else if (setting == 55)
                    {
                        S_NoMountsInHouses = bool.Parse(node.InnerText);
                    }
                    else if (setting == 56)
                    {
                        S_AllowCustomTitles = bool.Parse(node.InnerText);
                    }
                    else if (setting == 57)
                    {
                        S_AllowHouseDyes = bool.Parse(node.InnerText);
                    }
                    else if (setting == 58)
                    {
                        S_AllowCustomHomes = bool.Parse(node.InnerText);
                    }
                    else if (setting == 59)
                    {
                        S_AllowCraftMagic = bool.Parse(node.InnerText);
                    }
                    else if (setting == 60)
                    {
                        S_Bribery = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 61)
                    {
                        S_LineOfSight = bool.Parse(node.InnerText);
                    }
                    else if (setting == 62)
                    {
                        S_ChangeArtyLook = bool.Parse(node.InnerText);
                    }
                    else if (setting == 63)
                    {
                        S_Resources = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 64)
                    {
                        S_SoldResource = bool.Parse(node.InnerText);
                    }
                    else if (setting == 65)
                    {
                        S_Humanoids = bool.Parse(node.InnerText);
                    }
                    else if (setting == 66)
                    {
                        S_MerchantBooks = bool.Parse(node.InnerText);
                    }
                    else if (setting == 67)
                    {
                        S_HouseStorage = bool.Parse(node.InnerText);
                    }
                    else if (setting == 68)
                    {
                        S_CorpseDecay = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 69)
                    {
                        S_BoneDecay = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 70)
                    {
                        S_HouseOwners = bool.Parse(node.InnerText);
                    }
                    else if (setting == 71)
                    {
                        S_LawnsAllowed = bool.Parse(node.InnerText);
                    }
                    else if (setting == 72)
                    {
                        S_ShantysAllowed = bool.Parse(node.InnerText);
                    }
                    else if (setting == 73)
                    {
                        S_MonsterCharacters = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 74)
                    {
                        S_DeleteDays = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 75)
                    {
                        S_AutoAccounts = bool.Parse(node.InnerText);
                    }
                    else if (setting == 76)
                    {
                        S_Port = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 77)
                    {
                        S_SpecialWeaponAbilSkill = XmlConvert.ToDouble(node.InnerText);
                    }
                    else if (setting == 78)
                    {
                        S_Stables = Int32.Parse(node.InnerText);
                    }
                    else if (setting == 79)
                    {
                        S_HPModifier = XmlConvert.ToDouble(node.InnerText);
                    }

                    setting++;
                }
            }
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public static bool EnableConsole()
    {
        // THIS WILL ENABLE THE ABILITY TO TYPE COMMANDS IN THE SERVER CONSOLE
        // WARNING: THIS MAY CAUSE ISSUES SO ENABLE IT AT YOUR OWN RISK
        return S_EnableConsole;
    }

    public static double ServerSaveMinutes()             // HOW MANY MINUTES BETWEEN AUTOMATIC SERVER SAVES
    {
        if (S_ServerSaveMinutes > 240)
        {
            S_ServerSaveMinutes = 240.0;
        }
        else if (S_ServerSaveMinutes < 10)
        {
            S_ServerSaveMinutes = 10.0;
        }

        return S_ServerSaveMinutes;
    }

    public static bool SaveOnCharacterLogout()
    {
        // THIS IS HELPFUL IN SINGLE PLAYER MODE, WHERE THE GAME WILL SAVE AS SOON AS YOU LOG OUT YOUR CHARACTER
        return S_SaveOnCharacterLogout;
    }

    public static bool PersistentBlackjack()
    {
        // IF YOU HAVE CUSTOM SETTINGS FOR YOUR BLACKJACK TABLES
        // THEN SETTING THIS TO true WILL KEEP YOUR TABLES IN PLACE
        // EVEN AFTER YOU DO A [buildworld COMMAND
        return S_PersistentBlackjack;
    }

    public static int FloorTrapTrigger()
    {
        // THERE ARE MANY HIDDEN TRAPS ON THE FLOOR, BUT THE PERCENT CHANCE
        // IS SET BELOW THAT THEY WILL TRIGGER WHEN WALKED OVER BY PLAYERS
        // 20% IS THE DEFAULT...WHERE 0 IS NEVER AND 100 IS ALWAYS

        if (S_FloorTrapTrigger < 5)
        {
            S_FloorTrapTrigger = 5;
        }

        return S_FloorTrapTrigger;
    }

    public static int GetUnidentifiedChance()
    {
        // CHANCE THAT ITEMS ARE UNIDENTIFIED
        // IF YOU SET THIS VERY LOW, THEN MERCANTILE STARTS TO BECOME A USELESS SKILL

        if (S_GetUnidentifiedChance < 10)
        {
            S_GetUnidentifiedChance = 10;
        }

        return S_GetUnidentifiedChance;
    }

    public static bool NoMacroing()
    {
        // SOME SKILLS ARE MEANT TO BE WORKED ACTIVELY BY THE PLAYER
        // THIS SETS THE TONE FOR GAME DIFFICULTY AND CHARACTER DEVELOPMENT
        // SETTING THE BELOW TO FALSE WILL IGNORE THIS FEATURE OF THE GAME
        return S_NoMacroing;
    }

    public static double StatGain()
    {
        // THIS IS NOT ADVISED, BUT YOU CAN INCREASE THE CHANCE OF A STAT GAIN TO OCCUR
        // STATS ONLY GAIN WHEN SKILLS ARE USED, SO A SKILL GAIN POTENTIAL MUST PRECEDE A STAT GAIN

        if (S_StatGain > 50)
        {
            S_StatGain = 50.0;
        }
        else if (S_StatGain < 10)
        {
            S_StatGain = 10.0;
        }

        return S_StatGain;                 // LOWER THIS VALUE FOR MORE STAT GAIN - 33.3 IS DEFAULT - 0.01 IS VERY OFTEN
    }

    public static TimeSpan StatGainDelay()
    {
        // THIS IS NOT ADVISED, BUT YOU CAN CHANGE THE TIME BETWEEN STAT GAINS
        // HOW MANY MINUTES BETWEEN STAT GAINS

        if (S_StatGainDelay > 60)
        {
            S_StatGainDelay = 60.0;
        }
        else if (S_StatGainDelay < 5)
        {
            S_StatGainDelay = 5.0;
        }

        return TimeSpan.FromMinutes(S_StatGainDelay);                   // 15.0 IS DEFAULT
    }

    public static TimeSpan PetStatGainDelay()
    {
        // THIS IS NOT ADVISED, BUT YOU CAN CHANGE THE TIME BETWEEN STAT GAINS FOR PETS
        // HOW MANY MINUTES BETWEEN STAT GAINS

        if (S_PetStatGainDelay > 60)
        {
            S_PetStatGainDelay = 60.0;
        }
        else if (S_PetStatGainDelay < 1)
        {
            S_PetStatGainDelay = 1.0;
        }

        return TimeSpan.FromMinutes(S_PetStatGainDelay);                   // 5.0 IS DEFAULT
    }

    public static int GetTimeBetweenQuests()
    {
        if (S_GetTimeBetweenQuests > 240)
        {
            S_GetTimeBetweenQuests = 240;
        }
        else if (S_GetTimeBetweenQuests < 1)
        {
            S_GetTimeBetweenQuests = 0;
        }

        return S_GetTimeBetweenQuests;                 // MINUTES
    }

    public static int GetTimeBetweenArtifactQuests()
    {
        if (S_GetTimeBetweenArtifactQuests > 20160)
        {
            S_GetTimeBetweenArtifactQuests = 20160;
        }
        else if (S_GetTimeBetweenArtifactQuests < 1)
        {
            S_GetTimeBetweenArtifactQuests = 0;
        }

        return S_GetTimeBetweenArtifactQuests;                 // MINUTES
    }

    public static int GetGoldCutRate()             // DEFAULT IS 25% OF WHAT GOLD NORMALLY DROPS
    {
        // THIS AFFECTS MONEY ELEMENTS SUCH AS...
        // MONSTER DROPS
        // CHEST DROPS
        // CARGO
        // MUSEUM SEARCHES
        // SHOPPE PROFITS
        // SOME QUESTS

        if (S_GetGoldCutRate < 5)
        {
            S_GetGoldCutRate = 5;
        }
        else if (S_GetGoldCutRate > 100)
        {
            S_GetGoldCutRate = 100;
        }

        return S_GetGoldCutRate;
    }

    public static bool AllowMacroResources()
    {
        // IF SET TO false, PLAYERS WILL GET A CAPTCHA EVERY FEW MINUTES WHEN HARVESTING
        // RESOURCES...WHERE THEY MUST ANSWER THE CAPTCHA TO CONTINUE
        return S_AllowMacroResources;
    }

    public static bool CreaturesSearching()
    {
        // IF TRUE, ALL CREATURES WILL HAVE SOME FORM OF SEARCHING SKILL
        // THAT IS BASED ON THEIR CREATURE LEVEL. THIS MAKES THE STEALTHY
        // THIEVES HAVE MORE OF A CHALLENGE WHEN THEY ARE TOMB RAIDING
        return S_CreaturesSearching;
    }

    public static bool GuardsSentenceDeath()
    {
        // IF TRUE, TOWN GUARDS WILL INSTANTLY KILL CRIMINALS AND MONSTERS
        // OTHERWISE, THEY WILL CHASE THEM IN TOWN WHERE ANY PLAYER CHARACTERS
        // THAT GET HIT BY THEM WILL BE SENT TO PRISON AND LOSE SOME EQUIPMENT
        // WHICH IS LIMITED TO ITEMS LIKE:
        // Potions, bandages, arrows, bolts, gems, coins, jewels, crystals,
        // reagents, bottles, food, and water
        return S_GuardsSentenceDeath;
    }

    public static bool GuardsPatrolOutside()
    {
        // IF TRUE, TOWN GUARDS WILL LOOK FOR ENEMIES OUTSIDE OF TOWN BORDERS
        // THAT ARE WITHIN SITE OF THE GUARD, OTHERWISE THEY WILL BE IGNORED
        return S_GuardsPatrolOutside;
    }

    public static bool GuardsSprint()
    {
        // IF TRUE, TOWN GUARDS WILL RUN FASTER THAN NORMAL
        return S_GuardsSprint;
    }

    public static bool NoMountsInCertainRegions()
    {
        // PLAYER MOUNTS GET STABLED WHEN THEY GO IN CERTAIN AREAS LIKE DUNGEONS OR CAVES
        // THEY WILL REMOUNT THEM WHEN THEY LEAVE THESE AREAS
        // SET TO false IF YOU DO NOT WANT TO LIMIT WHERE THEY TAKE MOUNTS
        // KEEP IN MIND THAT HAVING NO MOUNTS IN DUNGEONS DOES INCREASE THE DIFFICULTY
        return S_NoMountsInCertainRegions;
    }

    public static bool AllowAlienChoice()
    {
        // THERE IS A PLAY STYLE WHERE ONE CAN CHOOSE TO ENTER A TRANSPORTER AND BE A CHARACTER THAT CRASHD
        // HERE FROM ANOTHER WORLD. THIS GIVES THEM THE ABILITY TO GRANDMASTER 40 SKILLS BUT THEY BEGIN THE
        // THE GAME WITH NO GOLD OR ANY SKILLS. THEY WILL ALSO SUFFER:
        // 4X GUILD FEES
        // 3X RESURRECTION FEES
        // SUFFER DOUBLE STAT/FAME/KARMA/SKILL LOSS ON DEATH WITH NO TRIBUTE
        // SUFFER NORMAL STAT/FAME/KARMA/SKILL LOSS ON DEATH WITH TRIBUTE
        return S_AllowAlienChoice;
    }

    public static bool AnnounceTrapSaves()
    {
        // IF SET TO TRUE, THEN CHARACTERS WILL HAVE AN ANNOUNCEMENT WHEN THEY MAKE A SAVING THROW
        // AGAINST A PARTICULAR HIDDEN FLOOR TRAP. OTHERWISE, THEY WILL NEVER KNOW THEY AVOIDED IT.
        return S_AnnounceTrapSaves;
    }

    public static bool IdentifyItemsOnlyInPack()
    {
        // IF SET TO TRUE, THEN CHARACTERS HAVE TO PUT UNIDENTIFIED ITEMS IN THEIR PACK TO IDENTIFY THEM
        // IF SET TO FALSE, THEN CHARACTERS CAN IDENITIFY ITEMS THEY ARE ABLE TO DOUBLE CLICK
        // THIS OPTION IS ONLY PROVIDED IF YOU NEED THE SECURITY OF MULTI-PLAYER ENVIRONMENTS
        return S_IdentifyItemsOnlyInPack;
    }

    public static double DamageToPets()
    {
        // IF YOU THINK TAMER PETS SOMEHOW RUIN YOUR GAME, YOU CAN INCREASE THIS VALUE
        // AS IT WILL INCREASE A CREATURES DAMAGE TOWARD SUCH PETS AND IT ONLY ALTERS MELEE DAMAGE

        if (S_DamageToPets < 1)
        {
            S_DamageToPets = 1.0;
        }

        return S_DamageToPets;                 // DEFAULT 1.0
    }

    public static int CriticalToPets()
    {
        // IF YOU THINK TAMER PETS SOMEHOW RUIN YOUR GAME, YOU CAN INCREASE THIS VALUE
        // AS IT WILL INCREASE A CREATURES CHANCE OF DOING DOUBLE MELEE DAMAGE TO PETS

        if (S_CriticalToPets < 1)
        {
            S_CriticalToPets = 0;
        }
        else if (S_CriticalToPets > 100)
        {
            S_CriticalToPets = 100;
        }

        return S_CriticalToPets;                 // DEFAULT 0
    }

    public static int SpellDamageIncreaseVsMonsters()
    {
        if (S_SpellDamageIncreaseVsMonsters < 25)
        {
            S_SpellDamageIncreaseVsMonsters = 25;
        }
        else if (S_SpellDamageIncreaseVsMonsters > 200)
        {
            S_SpellDamageIncreaseVsMonsters = 200;
        }
        return S_SpellDamageIncreaseVsMonsters;
    }

    public static int SpellDamageIncreaseVsPlayers()
    {
        if (S_SpellDamageIncreaseVsPlayers < 25)
        {
            S_SpellDamageIncreaseVsPlayers = 25;
        }
        else if (S_SpellDamageIncreaseVsPlayers > 200)
        {
            S_SpellDamageIncreaseVsPlayers = 200;
        }
        return S_SpellDamageIncreaseVsPlayers;
    }

    public static bool RunRoutinesAtStartup()
    {
        // THE SERVER HAS SOME SELF-CLEANING AND SELF-SUSTAINING SCRIPTS IT RUNS EVERY HOUR, 3 HOURS, & 24 HOURS
        // IF YOU RUN A 24x7 SERVER, YOU CAN SET THE BELOW TO false SINCE YOUR SERVER WILL RUN THESE AT THOSE TIMES
        // IF YOU PLAY SINGLE PLAYER, AND YOU TURN THE SERVER ON/OFF AS REQUIRED, THEN SET THIS TO true SO THESE ROUTINES AT LEAST RUN FOR YOU
        return S_RunRoutinesAtStartup;
    }

    public static int QuestRewardModifier()
    {
        // FOR ASSSASSIN, THIEF, FISHING, & STANDARD QUESTS
        // 100 PERCENT IS STANDARD

        if (S_QuestRewardModifier < 50)
        {
            S_QuestRewardModifier = 50;
        }
        else if (S_QuestRewardModifier > 250)
        {
            S_QuestRewardModifier = 250;
        }

        return S_QuestRewardModifier;                 // PERCENT
    }

    public static int PlayerLevelMod(int value, Mobile m)
    {
        // THIS MULTIPLIES AGAINST THE RAW STAT TO GIVE THE RETURNING HIT POINTS, MANA, OR STAMINA
        // SO SETTING THIS TO 2.0 WOULD GIVE THE CHARACTER HITS POINTS EQUAL TO THEIR STRENGTH x 2
        // THIS ALSO AFFECTS BENEFICIAL SPELLS AND POTIONS THAT RESTORE HEALTH, STAMINA, AND MANA

        if (S_PlayerLevelMod > 2)
        {
            S_PlayerLevelMod = 2.0;
        }
        else if (S_PlayerLevelMod < 0.5)
        {
            S_PlayerLevelMod = 0.5;
        }

        double mod = 1.0;
        if (m is PlayerMobile)
        {
            mod = S_PlayerLevelMod;
        }                                                                           // ONLY CHANGE THIS VALUE

        value = (int)(value * mod);
        if (value < 0)
        {
            value = 1;
        }

        return value;
    }

    public static int WyrmBody()
    {
        if (S_WyrmBody != 723 && S_WyrmBody != 12 && S_WyrmBody != 59)
        {
            S_WyrmBody = 723;
        }

        return S_WyrmBody;                 // THIS IS WHAT WYRMS LOOK LIKE IN THE GAME...IF YOU WANT A DIFFERENT APPEARANCE THEN CHANGE THIS VALUE
    }

    public static bool Quest()
    {
        // THERE ARE CREATURES WITH PURPLE NAMES THAT FIGHT EVIL. THIS MEANS CRIMINALS, MURDERERS, OR THOSE WITH NEGATIVE KARMA
        // THEY WILL ATTACH OTHER PLAYER CHARACTER BUT SETTING THIS VALUE TO TRUE WILL ALSO HAVE THEM ATTACK EVIL MONSTERS THEY ARE NEAR
        // THOSE THAT ATTACK EVIL ATTACK THOSE WITH -2500 KARMA OR LOWER
        // IF YOU FIND THAT THESE GOODY-GOODY CREATURES ARE FIGHTING OTHER CREATURES TOO MUCH IN YOUR VIRTUAL WORLD, SET THIS TO FALSE
        // CREATURES THAT KILL EACH OTHER IN THESE SIMULATED CONFLICTS WILL HAVE THE CORPSES DELETE UPON DEATH SO PLAYERS DO NOT BENEFIT FROM FREE TREASURE
        // NO MATTER THIS SETTING, SUCH GOODY-GOODY CREATURES WILL ATTACK OTHER PLAYER CHARACTERS THAT FALL WITHIN THE CRITERIA NOTED
        return S_Quest;
    }

    public static bool FastFriends(Mobile m)                                                    // IF TRUE, FOLLOWERS WILL ATTEMPT TO STAY WITH YOU IF YOU ARE RUNNING FAST
    {                                                                                           // OTHERWISE THEY HAVE THEIR OWN DEFAULT SPEEDS
        if (m is BaseCreature && ((BaseCreature)m).ControlMaster != null)
        {
            return true;
        }                                                                                                   // THIS VALUE YOU WOULD CHANGE
        return S_FastFriends;
    }

    public static bool FriendsAvoidHeels()             // IF true, FOLLOWERS WILL HAVE A MORE RANDOM PATTERN WHEN FOLLOWING YOU, INSTEAD OF ALWAYS STACKED ON TOP OF EACH OTHER
    {
        return S_FriendsAvoidHeels;
    }

    public static bool FriendsGuardFriends()             // IF true, FOLLOWERS WILL NOT ONLY GUARD YOU...BUT ALSO YOUR OTHER FOLLOWERS AND ATTACK THOSE THAT YOUR GROUP ATTACKS
    {
        return S_FriendsGuardFriends;
    }

    public static double BoatDecay()             // HOW MANY DAYS A BOAT WILL LAST BEFORE IT DECAYS, WHERE using IT REFRESHES THE TIME
    {
        if (S_BoatDecay < 5)
        {
            S_BoatDecay = 5.0;
        }
        return S_BoatDecay;
    }

    public static double HomeDecay()             // HOW MANY DAYS A HOUSE WILL LAST BEFORE IT DECAYS, WHERE using IT REFRESHES THE TIME
    {
        if (S_HomeDecay < 30)
        {
            S_HomeDecay = 30.0;
        }
        return S_HomeDecay;
    }

    public static bool HousesDecay()             // DO HOUSES DECAY IN YOUR GAME AT ALL?
    {
        return S_HousesDecay;
    }

    public static int HousesPerAccount()             // HOW MANY HOUSES CAN ONE ACCOUNT HAVE, WHERE -1 IS NO LIMIT
    {
        if (S_HousesPerAccount == 0)
        {
            S_HousesPerAccount = 1;
        }
        else if (S_HousesPerAccount < 0)
        {
            S_HousesPerAccount = -1;
        }
        return S_HousesPerAccount;
    }

    public static bool EnableDungeonSoundEffects()             // DO THE DUNGEONS HAVE RANDOM SOUND EFFECTS?
    {
        return S_EnableDungeonSoundEffects;
    }

    // ******************************************************************************************************************************************

    // THE OPTIONS IN THIS SECTION ARE MEANT TO HELP SIMULATE AN ECOMONY IN THE WORLD WHERE VENDORS SELL AND/OR BUY SOME THINGS BUT NOT OTHERS.
    // THIS CHANGES ON A SCHEDULE AND THEN RANDOMIZES WHAT THEY BUY/SELL EACH TIME THE SCHEDULE TRIGGERS. SOME EXAMPLES OF THIS CONFIGURATION IS
    // A VENDOR IN BRITAIN MAY NOT WANT TO BUY YOUR LEATHER HIDES, BUT THE TANNER IN MONTOR JUST MIGHT SO YOUR CHARACTER MAY WANT TO MAKE THE
    // JOURNEY THERE. THERE ARE ALSO ITEMS THAT ARE MEANT TO BE HARD TO FIND (LIKE RUNEBOOKS) SO YOU MAY HAVE TO VISIT SEVERAL VILLAGES BEFORE
    // YOU FIND A VENDOR THAT SELLS ONE. AGAIN, THIS IS TO CULTIVATE WORLD TRAVEL AND EXPLORATION.

    public static bool SellChance()             // CHANCE A VENDOR SELLS A REGULAR ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_SellChance;      if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    public static bool SellCommonChance()             // CHANCE A VENDOR SELLS A REALLY COMMON ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_SellCommonChance;        if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    public static bool SellRareChance()             // CHANCE A VENDOR SELLS A RARE ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_SellRareChance;  if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    public static bool SellVeryRareChance()             // CHANCE A VENDOR SELLS A VERY RARE ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_SellVeryRareChance;      if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    public static bool BuyChance()             // CHANCE A VENDOR BUYS A REGULAR ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_BuyChance;       if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    public static bool BuyCommonChance()             // CHANCE A VENDOR BUYS A COMMON ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_BuyCommonChance; if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    public static bool BuyRareChance()             // CHANCE A VENDOR BUYS A RARE ITEM. SET "chance" HIGHER FOR MORE OFTEN
    {
        int chance = S_BuyRareChance;   if (chance >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }
        return false;
    }

    // ******************************************************************************************************************************************

    public static bool ShinyArmor()          // DO YOU WANT SHINY METAL ARMOR
    {
        return S_ShinyArmor;                 // IF YOU CHANGE THIS, DELETE THE INFO/colors.set FILE AND RESTART THE SERVER, IT WILL TAKE A BIT TO LOAD WHILE IT UPDATES COLORS
    }

    public static bool LeatherColor()        // DO YOU WANT NEWER LEATHER COLORS
    {
        return S_NewLeather;                 // IF YOU CHANGE THIS, DELETE THE INFO/colors.set FILE AND RESTART THE SERVER, IT WILL TAKE A BIT TO LOAD WHILE IT UPDATES COLORS
    }

    public static int LeopardBodies()
    {
        int body = 214; if (S_Leopards)
        {
            body = 336;
        }
        return body;
    }

    public static bool AllowElephants()
    {
        return S_Elephants;
    }

    public static bool AllowZebras()
    {
        return S_Zebras;
    }

    public static bool AllowFox()
    {
        return S_Fox;
    }

    public static bool OpenBasements()
    {
        return S_Basements;
    }

    public static bool NoMountBuilding()
    {
        return S_NoMountBuilding;
    }

    public static bool NoMountsInHouses()
    {
        return S_NoMountsInHouses;
    }

    public static bool AllowCustomTitles()
    {
        return S_AllowCustomTitles;
    }

    public static bool AllowHouseDyes()
    {
        return S_AllowHouseDyes;
    }

    public static bool AllowCustomHomes()
    {
        return S_AllowCustomHomes;
    }

    public static bool AllowCraftMagic()
    {
        return S_AllowCraftMagic;
    }

    public static int AllowBribes()
    {
        return S_Bribery;
    }

    // THE BELOW TWO SETTINGS ARE USED IF THE GAME SETTINGS ARE CONFIGURED TO HAVE CREATURES HIDDEN FROM VIEW WHEN THERE IS NO LINE OF SIGHT TO THEM.
    // THIS ONLY APPLIES TO CREATURES IN CAVES, DUNGEONS, OR OUTSIDE DANGEROUS AREAS LIKE CEMETERIES. IT PROVIDES A LEVEL OF DIFFICULTY TO THE GAME
    // WHICH IS NOT A REGULAR PART OF THE ORIGINAL GAME.

    public static bool LineOfSight(Mobile m, bool hidden)
    {
        if (S_LineOfSight && m is BaseCreature && m.CanHearGhosts && hidden && m.Hidden)
        {
            return true;
        }
        else if (S_LineOfSight && m is BaseCreature && m.CanHearGhosts)
        {
            return true;
        }

        return false;
    }

    public static bool LineOfSightOn()
    {
        return S_LineOfSight;
    }

    public static bool ChangeArtyLook()
    {
        return S_ChangeArtyLook;
    }

    public static int Resources()
    {
        int res = S_Resources;
        if (res < 1)
        {
            res = 1;
        }
        else if (res > 100)
        {
            res = 100;
        }

        return res;
    }

    public static bool SoldResource()
    {
        return S_SoldResource;
    }

    public static bool Humanoids()
    {
        if (S_Humanoids && Utility.RandomMinMax(1, 20) == 1)
        {
            return true;
        }

        return false;
    }

    public static bool Humanoid()
    {
        if (S_Humanoids && Utility.RandomBool())
        {
            return true;
        }

        return false;
    }

    public static bool MerchantBooks()
    {
        if (S_MerchantBooks)
        {
            return true;
        }

        return false;
    }

    public static bool HouseStorage()
    {
        return S_HouseStorage;
    }

    public static double CorpseDecay()
    {
        if (S_CorpseDecay < 1)
        {
            S_CorpseDecay = 0;
        }

        return (double)S_CorpseDecay;
    }

    public static double BoneDecay()
    {
        if (S_BoneDecay < 1)
        {
            S_BoneDecay = 0;
        }

        return (double)S_BoneDecay;
    }

    public static bool HouseOwners()
    {
        return S_HouseOwners;
    }

    public static bool LawnsAllowed()
    {
        return S_LawnsAllowed;
    }

    public static bool ShantysAllowed()
    {
        return S_ShantysAllowed;
    }

    public static bool AlterArtifact(Item item)
    {
        if (Server.Misc.Arty.isArtifact(item) && !Server.Misc.MyServerSettings.ChangeArtyLook())
        {
            return false;
        }

        return true;
    }

    public static int MonsterCharacters()
    {
        return S_MonsterCharacters;
    }

    public static bool MonstersAllowed()
    {
        if (MonsterCharacters() > 0)
        {
            return true;
        }

        return false;
    }

    public static double DeleteDelay()
    {
        if (S_DeleteDays < 1)
        {
            S_DeleteDays = 0;
        }

        return (double)S_DeleteDays;
    }

    public static bool AutoAccounts()
    {
        return S_AutoAccounts;
    }

    public static int MyPort()
    {
        return S_Port;
    }

    public static double SpecialWeaponAbilSkill()             // MIN SKILLS NEEDED TO START WEAPON SPECIAL ABILITIES
    {
        if (S_SpecialWeaponAbilSkill < 20)
        {
            S_SpecialWeaponAbilSkill = 20.0;
        }
        return S_SpecialWeaponAbilSkill;
    }

    public static int ExtraStableSlots()
    {
        int stable = S_Stables;

        if (stable < 0)
        {
            stable = 0;
        }

        if (stable > 20)
        {
            stable = 20;
        }

        return stable;
    }

    public static double HPModifier()
    {
        return S_HPModifier;
    }
}
}
