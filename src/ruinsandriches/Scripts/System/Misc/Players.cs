using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server;
using System.Collections.Generic;
using System.Collections;
using System;
using Server.Spells.Seventh;

namespace Server.Misc
{
class GetPlayerInfo
{
    public static string GetSkillTitle(Mobile m)
    {
        bool isOriental = Server.Misc.GetPlayerInfo.OrientalPlay(m);
        bool isEvil     = Server.Misc.GetPlayerInfo.EvilPlay(m);
        int  isBarbaric = Server.Misc.GetPlayerInfo.BarbaricPlay(m);

        if (((PlayerMobile)m).CharacterSkill == 66)
        {
            return "Titan of Ether";
        }
        else if (m.SkillsTotal > 0)
        {
            Skill highest = GetShowingSkill(m);

            if (highest != null)
            {
                if (highest.Value < 0.1)
                {
                    return "Village Idiot";
                }
                else
                {
                    string skillLevel = null;
                    if (highest.Value < 29.1)
                    {
                        skillLevel = "Aspiring";
                    }
                    else
                    {
                        skillLevel = GetSkillLevel(highest);
                    }

                    string skillTitle = highest.Info.Title;

                    skillTitle = Skill.CharacterTitle(skillTitle, m.Female, m.Karma, m.Skills[SkillName.Knightship].Value, m.Skills[SkillName.Seafaring].Value, m.Skills[SkillName.Magery].Base, m.Skills[SkillName.Necromancy].Base, m.Skills[SkillName.Healing].Base, m.Skills[SkillName.Spiritualism].Base, isBarbaric, isOriental, isMonk(m), isSyth(m, false), isJedi(m, false), isJester(m), isEvil);

                    return String.Concat(skillLevel, " ", skillTitle);
                }
            }
        }

        return "Village Idiot";
    }

    public static bool isMonk(Mobile m)
    {
        int points = 0;

        Spellbook book = Spellbook.FindMystic(m);
        if (book is MysticSpellbook)
        {
            MysticSpellbook tome = (MysticSpellbook)book;
            if (tome.owner == m)
            {
                points++;
            }
        }

        if (Server.Spells.Mystic.MysticSpell.MonkNotIllegal(m))
        {
            points++;
        }

        if (points > 1)
        {
            return true;
        }

        return false;
    }

    public static bool isFromSpace(Mobile m)
    {
        if (m.Skills.Cap >= 40000)
        {
            return true;
        }

        return false;
    }

    public static bool isSyth(Mobile m, bool checkSword)
    {
        int points = 0;

        Spellbook book = Spellbook.FindSyth(m);
        if (book is SythSpellbook)
        {
            SythSpellbook tome = (SythSpellbook)book;
            if (tome.owner == m)
            {
                points++;
            }
        }

        if (Server.Spells.Syth.SythSpell.SythNotIllegal(m, checkSword))
        {
            points++;
        }

        if (points > 1)
        {
            return true;
        }

        return false;
    }

    public static bool isJedi(Mobile m, bool checkSword)
    {
        int points = 0;

        Spellbook book = Spellbook.FindJedi(m);
        if (book is JediSpellbook)
        {
            JediSpellbook tome = (JediSpellbook)book;
            if (tome.owner == m)
            {
                points++;
            }
        }

        if (Server.Spells.Jedi.JediSpell.JediNotIllegal(m, checkSword))
        {
            points++;
        }

        if (points > 1)
        {
            return true;
        }

        return false;
    }

    public static bool isJester(Mobile from)
    {
        int points = 0;

        if (from is PlayerMobile && from != null && from.Backpack != null)
        {
            foreach (Item i in from.Backpack.FindItemsByType(typeof(BagOfTricks), true))
            {
                if (i != null)
                {
                    points = 1;
                }
            }

            if (from.Skills[SkillName.Begging].Value > 10 || from.Skills[SkillName.Psychology].Value > 10)
            {
                points++;
            }

            if (from.FindItemOnLayer(Layer.OuterTorso) != null)
            {
                Item robe = from.FindItemOnLayer(Layer.OuterTorso);
                if (robe.ItemID == 0x1f9f || robe.ItemID == 0x1fa0 || robe.ItemID == 0x4C16 || robe.ItemID == 0x4C17 || robe.ItemID == 0x2B6B || robe.ItemID == 0x3162)
                {
                    points++;
                }
            }
            if (from.FindItemOnLayer(Layer.MiddleTorso) != null)
            {
                Item shirt = from.FindItemOnLayer(Layer.MiddleTorso);
                if (shirt.ItemID == 0x1f9f || shirt.ItemID == 0x1fa0 || shirt.ItemID == 0x4C16 || shirt.ItemID == 0x4C17 || shirt.ItemID == 0x2B6B || shirt.ItemID == 0x3162)
                {
                    points++;
                }
            }
            if (from.FindItemOnLayer(Layer.Helm) != null)
            {
                Item hat = from.FindItemOnLayer(Layer.Helm);
                if (hat.ItemID == 0x171C || hat.ItemID == 0x4C15)
                {
                    points++;
                }
            }
            if (from.FindItemOnLayer(Layer.Shoes) != null)
            {
                Item feet = from.FindItemOnLayer(Layer.Shoes);
                if (feet.ItemID == 0x4C27)
                {
                    points++;
                }
            }
        }

        if (points > 2)
        {
            return true;
        }

        return false;
    }

    private static Skill GetHighestSkill(Mobile m)
    {
        Skills skills = m.Skills;

        if (!Core.AOS)
        {
            return skills.Highest;
        }

        Skill highest = m.Skills[SkillName.FistFighting];

        for (int i = 0; i < m.Skills.Length; ++i)
        {
            Skill check = m.Skills[i];

            if (highest == null || check.Value > highest.Value)
            {
                highest = check;
            }
            else if (highest != null && highest.Lock != SkillLock.Up && check.Lock == SkillLock.Up && check.Value == highest.Value)
            {
                highest = check;
            }
        }

        return highest;
    }

    private static string[,] m_Levels = new string[, ]
    {
        { "Neophyte", "Neophyte", "Neophyte" },
        { "Novice", "Novice", "Novice" },
        { "Apprentice", "Apprentice", "Apprentice" },
        { "Journeyman", "Journeyman", "Journeyman" },
        { "Expert", "Expert", "Expert" },
        { "Adept", "Adept", "Adept" },
        { "Master", "Master", "Master" },
        { "Grandmaster", "Grandmaster", "Grandmaster" },
        { "Elder", "Tatsujin", "Shinobi" },
        { "Legendary", "Kengo", "Ka-ge" }
    };

    private static string GetSkillLevel(Skill skill)
    {
        return m_Levels[GetTableIndex(skill), GetTableType(skill)];
    }

    private static int GetTableType(Skill skill)
    {
        switch (skill.SkillName)
        {
            default: return 0;

            case SkillName.Bushido: return 1;

            case SkillName.Ninjitsu: return 2;
        }
    }

    private static int GetTableIndex(Skill skill)
    {
        int fp = 0;                 // Math.Min( skill.BaseFixedPoint, 1200 );

        if (skill.Value >= 120)
        {
            fp = 9;
        }
        else if (skill.Value >= 110)
        {
            fp = 8;
        }
        else if (skill.Value >= 100)
        {
            fp = 7;
        }
        else if (skill.Value >= 90)
        {
            fp = 6;
        }
        else if (skill.Value >= 80)
        {
            fp = 5;
        }
        else if (skill.Value >= 70)
        {
            fp = 4;
        }
        else if (skill.Value >= 60)
        {
            fp = 3;
        }
        else if (skill.Value >= 50)
        {
            fp = 2;
        }
        else if (skill.Value >= 40)
        {
            fp = 1;
        }
        else
        {
            fp = 0;
        }

        return fp;

        // return (fp - 300) / 100;
    }

    private static Skill GetShowingSkill(Mobile m)
    {
        Skill skill = GetHighestSkill(m);

        int NskillShow = ((PlayerMobile)m).CharacterSkill;

        if (NskillShow > 0)
        {
            if (NskillShow == 1)
            {
                skill = m.Skills[SkillName.Alchemy];
            }
            else if (NskillShow == 2)
            {
                skill = m.Skills[SkillName.Anatomy];
            }
            else if (NskillShow == 3)
            {
                skill = m.Skills[SkillName.Druidism];
            }
            else if (NskillShow == 4)
            {
                skill = m.Skills[SkillName.Taming];
            }
            else if (NskillShow == 5)
            {
                skill = m.Skills[SkillName.Marksmanship];
            }
            else if (NskillShow == 6)
            {
                skill = m.Skills[SkillName.ArmsLore];
            }
            else if (NskillShow == 7)
            {
                skill = m.Skills[SkillName.Begging];
            }
            else if (NskillShow == 8)
            {
                skill = m.Skills[SkillName.Blacksmith];
            }
            else if (NskillShow == 9)
            {
                skill = m.Skills[SkillName.Bushido];
            }
            else if (NskillShow == 10)
            {
                skill = m.Skills[SkillName.Camping];
            }
            else if (NskillShow == 11)
            {
                skill = m.Skills[SkillName.Carpentry];
            }
            else if (NskillShow == 12)
            {
                skill = m.Skills[SkillName.Cartography];
            }
            else if (NskillShow == 13)
            {
                skill = m.Skills[SkillName.Knightship];
            }
            else if (NskillShow == 14)
            {
                skill = m.Skills[SkillName.Cooking];
            }
            else if (NskillShow == 15)
            {
                skill = m.Skills[SkillName.Searching];
            }
            else if (NskillShow == 16)
            {
                skill = m.Skills[SkillName.Discordance];
            }
            else if (NskillShow == 17)
            {
                skill = m.Skills[SkillName.Psychology];
            }
            else if (NskillShow == 18)
            {
                skill = m.Skills[SkillName.Fencing];
            }
            else if (NskillShow == 19)
            {
                skill = m.Skills[SkillName.Seafaring];
            }
            else if (NskillShow == 20)
            {
                skill = m.Skills[SkillName.Bowcraft];
            }
            else if (NskillShow == 21)
            {
                skill = m.Skills[SkillName.Focus];
            }
            else if (NskillShow == 22)
            {
                skill = m.Skills[SkillName.Forensics];
            }
            else if (NskillShow == 23)
            {
                skill = m.Skills[SkillName.Healing];
            }
            else if (NskillShow == 24)
            {
                skill = m.Skills[SkillName.Herding];
            }
            else if (NskillShow == 25)
            {
                skill = m.Skills[SkillName.Hiding];
            }
            else if (NskillShow == 26)
            {
                skill = m.Skills[SkillName.Inscribe];
            }
            else if (NskillShow == 27)
            {
                skill = m.Skills[SkillName.Mercantile];
            }
            else if (NskillShow == 28)
            {
                skill = m.Skills[SkillName.Lockpicking];
            }
            else if (NskillShow == 29)
            {
                skill = m.Skills[SkillName.Lumberjacking];
            }
            else if (NskillShow == 30)
            {
                skill = m.Skills[SkillName.Bludgeoning];
            }
            else if (NskillShow == 31)
            {
                skill = m.Skills[SkillName.Magery];
            }
            else if (NskillShow == 32)
            {
                skill = m.Skills[SkillName.MagicResist];
            }
            else if (NskillShow == 33)
            {
                skill = m.Skills[SkillName.Meditation];
            }
            else if (NskillShow == 34)
            {
                skill = m.Skills[SkillName.Mining];
            }
            else if (NskillShow == 35)
            {
                skill = m.Skills[SkillName.Musicianship];
            }
            else if (NskillShow == 36)
            {
                skill = m.Skills[SkillName.Necromancy];
            }
            else if (NskillShow == 37)
            {
                skill = m.Skills[SkillName.Ninjitsu];
            }
            else if (NskillShow == 38)
            {
                skill = m.Skills[SkillName.Parry];
            }
            else if (NskillShow == 39)
            {
                skill = m.Skills[SkillName.Peacemaking];
            }
            else if (NskillShow == 40)
            {
                skill = m.Skills[SkillName.Poisoning];
            }
            else if (NskillShow == 41)
            {
                skill = m.Skills[SkillName.Provocation];
            }
            else if (NskillShow == 42)
            {
                skill = m.Skills[SkillName.RemoveTrap];
            }
            else if (NskillShow == 43)
            {
                skill = m.Skills[SkillName.Snooping];
            }
            else if (NskillShow == 44)
            {
                skill = m.Skills[SkillName.Spiritualism];
            }
            else if (NskillShow == 45)
            {
                skill = m.Skills[SkillName.Stealing];
            }
            else if (NskillShow == 46)
            {
                skill = m.Skills[SkillName.Stealth];
            }
            else if (NskillShow == 47)
            {
                skill = m.Skills[SkillName.Swords];
            }
            else if (NskillShow == 48)
            {
                skill = m.Skills[SkillName.Tactics];
            }
            else if (NskillShow == 49)
            {
                skill = m.Skills[SkillName.Tailoring];
            }
            else if (NskillShow == 50)
            {
                skill = m.Skills[SkillName.Tasting];
            }
            else if (NskillShow == 51)
            {
                skill = m.Skills[SkillName.Tinkering];
            }
            else if (NskillShow == 52)
            {
                skill = m.Skills[SkillName.Tracking];
            }
            else if (NskillShow == 53)
            {
                skill = m.Skills[SkillName.Veterinary];
            }
            else if (NskillShow == 54)
            {
                skill = m.Skills[SkillName.FistFighting];
            }
            else if (NskillShow == 55)
            {
                skill = m.Skills[SkillName.Elementalism];
            }
            else
            {
                skill = GetHighestSkill(m);
            }
        }

        return skill;
    }

    public static string GetNPCGuild(Mobile m)
    {
        string GuildTitle = "";

        if (m is PlayerMobile)
        {
            PlayerMobile pm = (PlayerMobile)m;

            if (pm.Profession == 1 && m.RaceID < 1)
            {
                GuildTitle = " & Fugitive";
            }
            else if (pm.NpcGuild == NpcGuild.MagesGuild)
            {
                GuildTitle = " of the Wizards Guild";
            }
            else if (pm.NpcGuild == NpcGuild.WarriorsGuild)
            {
                GuildTitle = " of the Warriors Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ThievesGuild)
            {
                GuildTitle = " of the Thieves Guild";
            }
            else if (pm.NpcGuild == NpcGuild.RangersGuild)
            {
                GuildTitle = " of the Rangers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.HealersGuild)
            {
                GuildTitle = " of the Healers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.MinersGuild)
            {
                GuildTitle = " of the Miners Guild";
            }
            else if (pm.NpcGuild == NpcGuild.MerchantsGuild)
            {
                GuildTitle = " of the Merchants Guild";
            }
            else if (pm.NpcGuild == NpcGuild.TinkersGuild)
            {
                GuildTitle = " of the Tinkers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.TailorsGuild)
            {
                GuildTitle = " of the Tailors Guild";
            }
            else if (pm.NpcGuild == NpcGuild.FishermensGuild)
            {
                GuildTitle = " of the Mariners Guild";
            }
            else if (pm.NpcGuild == NpcGuild.BardsGuild)
            {
                GuildTitle = " of the Bards Guild";
            }
            else if (pm.NpcGuild == NpcGuild.BlacksmithsGuild)
            {
                GuildTitle = " of the Blacksmiths Guild";
            }
            else if (pm.NpcGuild == NpcGuild.NecromancersGuild)
            {
                GuildTitle = " of the Black Magic Guild";
            }
            else if (pm.NpcGuild == NpcGuild.AlchemistsGuild)
            {
                GuildTitle = " of the Alchemists Guild";
            }
            else if (pm.NpcGuild == NpcGuild.DruidsGuild)
            {
                GuildTitle = " of the Druids Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ArchersGuild)
            {
                GuildTitle = " of the Archers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CarpentersGuild)
            {
                GuildTitle = " of the Carpenters Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CartographersGuild)
            {
                GuildTitle = " of the Cartographers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.LibrariansGuild)
            {
                GuildTitle = " of the Librarians Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CulinariansGuild)
            {
                GuildTitle = " of the Culinary Guild";
            }
            else if (pm.NpcGuild == NpcGuild.AssassinsGuild)
            {
                GuildTitle = " of the Assassins Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ElementalGuild)
            {
                GuildTitle = " of the Elemental Guild";
            }
        }
        else if (m is BaseVendor)
        {
            BaseVendor pm = (BaseVendor)m;

            if (pm.NpcGuild == NpcGuild.MagesGuild)
            {
                GuildTitle = "Wizards Guild";
            }
            else if (pm.NpcGuild == NpcGuild.WarriorsGuild)
            {
                GuildTitle = "Warriors Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ThievesGuild)
            {
                GuildTitle = "Thieves Guild";
            }
            else if (pm.NpcGuild == NpcGuild.RangersGuild)
            {
                GuildTitle = "Rangers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.HealersGuild)
            {
                GuildTitle = "Healers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.MinersGuild)
            {
                GuildTitle = "Miners Guild";
            }
            else if (pm.NpcGuild == NpcGuild.MerchantsGuild)
            {
                GuildTitle = "Merchants Guild";
            }
            else if (pm.NpcGuild == NpcGuild.TinkersGuild)
            {
                GuildTitle = "Tinkers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.TailorsGuild)
            {
                GuildTitle = "Tailors Guild";
            }
            else if (pm.NpcGuild == NpcGuild.FishermensGuild)
            {
                GuildTitle = "Mariners Guild";
            }
            else if (pm.NpcGuild == NpcGuild.BardsGuild)
            {
                GuildTitle = "Bards Guild";
            }
            else if (pm.NpcGuild == NpcGuild.BlacksmithsGuild)
            {
                GuildTitle = "Blacksmiths Guild";
            }
            else if (pm.NpcGuild == NpcGuild.NecromancersGuild)
            {
                GuildTitle = "Black Magic Guild";
            }
            else if (pm.NpcGuild == NpcGuild.AlchemistsGuild)
            {
                GuildTitle = "Alchemists Guild";
            }
            else if (pm.NpcGuild == NpcGuild.DruidsGuild)
            {
                GuildTitle = "Druids Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ArchersGuild)
            {
                GuildTitle = "Archers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CarpentersGuild)
            {
                GuildTitle = "Carpenters Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CartographersGuild)
            {
                GuildTitle = "Cartographers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.LibrariansGuild)
            {
                GuildTitle = "Librarians Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CulinariansGuild)
            {
                GuildTitle = "Culinary Guild";
            }
            else if (pm.NpcGuild == NpcGuild.AssassinsGuild)
            {
                GuildTitle = "Assassins Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ElementalGuild)
            {
                GuildTitle = "Elemental Guild";
            }
        }
        return GuildTitle;
    }

    public static string GetStatusGuild(Mobile m)
    {
        string GuildTitle = "";

        if (m is PlayerMobile)
        {
            PlayerMobile pm = (PlayerMobile)m;

            if (pm.Profession == 1)
            {
                GuildTitle = "The Fugitive";
            }
            else if (pm.NpcGuild == NpcGuild.MagesGuild)
            {
                GuildTitle = "The Wizards Guild";
            }
            else if (pm.NpcGuild == NpcGuild.WarriorsGuild)
            {
                GuildTitle = "The Warriors Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ThievesGuild)
            {
                GuildTitle = "The Thieves Guild";
            }
            else if (pm.NpcGuild == NpcGuild.RangersGuild)
            {
                GuildTitle = "The Rangers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.HealersGuild)
            {
                GuildTitle = "The Healers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.MinersGuild)
            {
                GuildTitle = "The Miners Guild";
            }
            else if (pm.NpcGuild == NpcGuild.MerchantsGuild)
            {
                GuildTitle = "The Merchants Guild";
            }
            else if (pm.NpcGuild == NpcGuild.TinkersGuild)
            {
                GuildTitle = "The Tinkers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.TailorsGuild)
            {
                GuildTitle = "The Tailors Guild";
            }
            else if (pm.NpcGuild == NpcGuild.FishermensGuild)
            {
                GuildTitle = "The Mariners Guild";
            }
            else if (pm.NpcGuild == NpcGuild.BardsGuild)
            {
                GuildTitle = "The Bards Guild";
            }
            else if (pm.NpcGuild == NpcGuild.BlacksmithsGuild)
            {
                GuildTitle = "The Blacksmiths Guild";
            }
            else if (pm.NpcGuild == NpcGuild.NecromancersGuild)
            {
                GuildTitle = "The Black Magic Guild";
            }
            else if (pm.NpcGuild == NpcGuild.AlchemistsGuild)
            {
                GuildTitle = "The Alchemists Guild";
            }
            else if (pm.NpcGuild == NpcGuild.DruidsGuild)
            {
                GuildTitle = "The Druids Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ArchersGuild)
            {
                GuildTitle = "The Archers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CarpentersGuild)
            {
                GuildTitle = "The Carpenters Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CartographersGuild)
            {
                GuildTitle = "The Cartographers Guild";
            }
            else if (pm.NpcGuild == NpcGuild.LibrariansGuild)
            {
                GuildTitle = "The Librarians Guild";
            }
            else if (pm.NpcGuild == NpcGuild.CulinariansGuild)
            {
                GuildTitle = "The Culinary Guild";
            }
            else if (pm.NpcGuild == NpcGuild.AssassinsGuild)
            {
                GuildTitle = "The Assassins Guild";
            }
            else if (pm.NpcGuild == NpcGuild.ElementalGuild)
            {
                GuildTitle = "The Elemental Guild";
            }
        }
        return GuildTitle;
    }

    public static int GetPlayerLevel(Mobile m)
    {
        int fame = m.Fame;
        if (fame > 15000)
        {
            fame = 15000;
        }

        int karma = m.Karma;
        if (karma < 0)
        {
            karma = m.Karma * -1;
        }
        if (karma > 15000)
        {
            karma = 15000;
        }

        int skills = m.Skills.Total;
        if (skills > 10000)
        {
            skills = 10000;
        }
        skills = (int)(1.5 * skills);                                           // UP TO 15,000

        int stats = m.RawStr + m.RawDex + m.RawInt;
        if (stats > 250)
        {
            stats = 250;
        }
        stats = 60 * stats;                                                                     // UP TO 15,000

        int level = (int)((fame + karma + skills + stats) / 600);
        level = (int)((level - 10) * 1.12);

        if (level < 1)
        {
            level = 1;
        }
        if (level > 100)
        {
            level = 100;
        }

        return level;
    }

    public static int GetPlayerDifficulty(Mobile m)
    {
        int difficulty = 0;
        int level      = GetPlayerLevel(m);

        if (level >= 95)
        {
            difficulty = 4;
        }
        else if (level >= 75)
        {
            difficulty = 3;
        }
        else if (level >= 50)
        {
            difficulty = 2;
        }
        else if (level >= 25)
        {
            difficulty = 1;
        }

        return difficulty;
    }

    public static int GetResurrectCost(Mobile m)
    {
        int fame = m.Fame;
        if (fame > 15000)
        {
            fame = 15000;
        }
        int karma = m.Karma * -1;
        if (karma > 15000)
        {
            karma = 15000;
        }

        int skills = m.Skills.Total;
        if (skills > 10000)
        {
            skills = 10000;
        }
        skills = (int)(1.5 * skills);                                           // UP TO 15,000

        int stats = m.RawStr + m.RawDex + m.RawInt;
        if (stats > 250)
        {
            stats = 250;
        }
        stats = 60 * stats;                                                                     // UP TO 15,000

        int level = (int)((fame + karma + skills + stats) / 600);
        level = (int)((level - 10) * 1.12);

        if (level < 1)
        {
            level = 1;
        }
        if (level > 100)
        {
            level = 100;
        }

        level = (level * 20);

        if (m.Skills.Total <= 2000)
        {
            level = 0;
        }
        if ((m.RawStr + m.RawDex + m.RawInt) <= 90)
        {
            level = 0;
        }

        if (((PlayerMobile)m).Profession == 1)
        {
            level = level * 2;
        }
        else if (GetPlayerInfo.isFromSpace(m))
        {
            level = level * 3;
        }

        return level;
    }

    public static string GetTodaysDate()
    {
        string sYear      = DateTime.Now.Year.ToString();
        string sMonth     = DateTime.Now.Month.ToString();
        string sMonthName = "January";
        if (sMonth == "2")
        {
            sMonthName = "February";
        }
        else if (sMonth == "3")
        {
            sMonthName = "March";
        }
        else if (sMonth == "4")
        {
            sMonthName = "April";
        }
        else if (sMonth == "5")
        {
            sMonthName = "May";
        }
        else if (sMonth == "6")
        {
            sMonthName = "June";
        }
        else if (sMonth == "7")
        {
            sMonthName = "July";
        }
        else if (sMonth == "8")
        {
            sMonthName = "August";
        }
        else if (sMonth == "9")
        {
            sMonthName = "September";
        }
        else if (sMonth == "10")
        {
            sMonthName = "October";
        }
        else if (sMonth == "11")
        {
            sMonthName = "November";
        }
        else if (sMonth == "12")
        {
            sMonthName = "December";
        }
        string sDay    = DateTime.Now.Day.ToString();
        string sHour   = DateTime.Now.Hour.ToString();
        string sMinute = DateTime.Now.Minute.ToString();
        string sSecond = DateTime.Now.Second.ToString();

        if (sHour.Length == 1)
        {
            sHour = "0" + sHour;
        }
        if (sMinute.Length == 1)
        {
            sMinute = "0" + sMinute;
        }
        if (sSecond.Length == 1)
        {
            sSecond = "0" + sSecond;
        }

        string sDateString = sMonthName + " " + sDay + ", " + sYear + " at " + sHour + ":" + sMinute;

        return sDateString;
    }

    public static bool LuckyPlayer(int luck)
    {
        if (luck <= 0)
        {
            return false;
        }

        if (luck > 2000)
        {
            luck = 2000;
        }

        int clover = (int)(luck * 0.04);                 // RETURNS A MAX OF 80%

        if (clover >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }

        return false;
    }

    public static bool LuckyKiller(int luck)
    {
        if (luck <= 0)
        {
            return false;
        }

        if (luck > 2000)
        {
            luck = 2000;
        }

        int clover = (int)(luck * 0.02) + 10;                 // RETURNS A MAX OF 50%

        if (clover >= Utility.RandomMinMax(1, 100))
        {
            return true;
        }

        return false;
    }

    public static bool EvilPlayer(Mobile m)
    {
        if (m is BaseCreature)
        {
            m = ((BaseCreature)m).GetMaster();
        }

        if (m is PlayerMobile)
        {
            if (m.AccessLevel > AccessLevel.Player)
            {
                return true;
            }

            if (m.Skills[SkillName.Necromancy].Base >= 50.0 && m.Karma < 0)                       // NECROMANCERS
            {
                return true;
            }

            if (m.Skills[SkillName.Forensics].Base >= 80.0 && m.Karma < 0)                       // UNDERTAKERS
            {
                return true;
            }

            if (m.Skills[SkillName.Knightship].Base >= 50.0 && m.Karma <= -5000)                       // DEATH KNIGHTS
            {
                return true;
            }

            if (m.Skills[SkillName.Psychology].Base >= 50.0 && m.Skills[SkillName.Swords].Base >= 50.0 && m.Karma <= -5000 && Server.Misc.GetPlayerInfo.isSyth(m, false))                      // SYTH
            {
                return true;
            }

            if (Server.Items.BaseRace.IsRavendarkCreature(m))                         // EVIL UNDEAD CREATURE PLAYERS
            {
                return true;
            }
        }

        return false;
    }

    public static string GetWantedStatus(Mobile m)
    {
        string warning = "";
        string safe    = "";
        bool   umbra   = true;

        if (m is PlayerMobile)
        {
            if (((PlayerMobile)m).Profession == 1 || m.Kills > 0)
            {
                warning = warning + "You are wanted for your murderous deeds! ";
                umbra   = false;
            }
            else if (m.Criminal)
            {
                warning = warning + "You are being sought as a criminal right now. ";
                umbra   = false;
            }
            if (m is PlayerMobile && (m.Karma < 2500 || m.Fame < 2500) && Server.Items.BaseRace.IsEvil(m))
            {
                warning = warning + "You are considered by most to be a vile creature and not welcome in many settlements. ";
            }
            if (m is PlayerMobile && m.Karma <= -5000 && m.Skills[SkillName.Knightship].Base >= 50)
            {
                warning = warning + "You are a death knight, which is feared amongst the land. ";
            }
            if (m is PlayerMobile && m.Karma <= -5000 && m.Skills[SkillName.Psychology].Base >= 50 && Server.Misc.GetPlayerInfo.isSyth(m, false))
            {
                warning = warning + "You are a syth, and are not welcome in most settlements. ";
            }

            if (DisguiseTimers.IsDisguised(m) && warning != "")
            {
                warning = warning + "You could probably sneak into settlements, however, since you will not be recognized.";
            }
            else if (!m.CanBeginAction(typeof(PolymorphSpell)) && warning != "")
            {
                warning = warning + "You could probably sneak into settlements, however, since you will not be recognized.";
            }

            safe = "<BR><BR>SAFE PLACES:<BR>";
            safe = safe + "<BR>Anchor Rock Port";
            safe = safe + "<BR>Bank";
            safe = safe + "<BR>Black Magic Guild";
            safe = safe + "<BR>Dojo";
            safe = safe + "<BR>Druid Glade";
            safe = safe + "<BR>Forgotten Lighthouse";
            safe = safe + "<BR>Inn";
            safe = safe + "<BR>Kraken Reef Port";
            safe = safe + "<BR>Lankhmar Lighthouse";
            safe = safe + "<BR>Lyceum";
            safe = safe + "<BR>Nightwood Fort";
            safe = safe + "<BR>Port of Shadows";
            safe = safe + "<BR>Ravendark Village";
            safe = safe + "<BR>Savage Sea Port";
            safe = safe + "<BR>Serpent Sail Port";
            safe = safe + "<BR>Stonewall Fort";
            safe = safe + "<BR>Tavern";
            safe = safe + "<BR>Tenebrae Fort";
            safe = safe + "<BR>Thieves Guild";
            if (umbra)
            {
                safe = safe + "<BR>Umbra Undercity";
            }
            safe = safe + "<BR>Wizards Guild";
            safe = safe + "<BR>Xardok's Castle";

            if (warning != "")
            {
                warning = warning + safe;
            }
        }

        if (warning == "")
        {
            warning = "You are not wanted for any crimes.";
        }

        return warning;
    }

    public static bool IsWanted(Mobile m)
    {
        bool wanted = false;

        if (m is PlayerMobile)
        {
            if (((PlayerMobile)m).Profession == 1 || m.Kills > 0)
            {
                wanted = true;
            }
            else if (m is PlayerMobile && (m.Karma < 2500 || m.Fame < 2500) && Server.Items.BaseRace.IsEvil(m))
            {
                wanted = true;
            }
            else if (m is PlayerMobile && m.Karma <= -5000 && m.Skills[SkillName.Knightship].Base >= 50)
            {
                wanted = true;
            }
            else if (m is PlayerMobile && m.Karma <= -5000 && m.Skills[SkillName.Psychology].Base >= 50 && Server.Misc.GetPlayerInfo.isSyth(m, false))
            {
                wanted = true;
            }
            else if (m.Criminal)
            {
                wanted = true;
            }
        }
        return wanted;
    }

    public static int LuckyPlayerArtifacts(int luck)
    {
        if (luck > 2000)
        {
            luck = 2000;
        }

        int clover = (int)(luck * 0.005);                 // RETURNS A MAX OF 10

        return clover;
    }

    public static bool OrientalPlay(Mobile m)
    {
        if (m != null && m is PlayerMobile)
        {
            if (((PlayerMobile)m).CharacterOriental == 1)
            {
                return true;
            }
        }
        else if (m != null && m is BaseCreature)
        {
            Mobile killer = m.LastKiller;
            if (killer is BaseCreature)
            {
                BaseCreature bc_killer = (BaseCreature)killer;
                if (bc_killer.Summoned)
                {
                    if (bc_killer.SummonMaster != null)
                    {
                        killer = bc_killer.SummonMaster;
                    }
                }
                else if (bc_killer.Controlled)
                {
                    if (bc_killer.ControlMaster != null)
                    {
                        killer = bc_killer.ControlMaster;
                    }
                }
                else if (bc_killer.BardProvoked)
                {
                    if (bc_killer.BardMaster != null)
                    {
                        killer = bc_killer.BardMaster;
                    }
                }
            }

            if (killer != null && killer is PlayerMobile)
            {
                if (((PlayerMobile)killer).CharacterOriental == 1)
                {
                    return true;
                }
            }
            else
            {
                Mobile hitter = m.FindMostRecentDamager(true);
                if (hitter is BaseCreature)
                {
                    BaseCreature bc_killer = (BaseCreature)hitter;
                    if (bc_killer.Summoned)
                    {
                        if (bc_killer.SummonMaster != null)
                        {
                            hitter = bc_killer.SummonMaster;
                        }
                    }
                    else if (bc_killer.Controlled)
                    {
                        if (bc_killer.ControlMaster != null)
                        {
                            hitter = bc_killer.ControlMaster;
                        }
                    }
                    else if (bc_killer.BardProvoked)
                    {
                        if (bc_killer.BardMaster != null)
                        {
                            hitter = bc_killer.BardMaster;
                        }
                    }
                }

                if (hitter != null && hitter is PlayerMobile)
                {
                    if (((PlayerMobile)hitter).CharacterOriental == 1)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public static int BarbaricPlay(Mobile m)
    {
        if (m != null && m is PlayerMobile)
        {
            if (((PlayerMobile)m).CharacterBarbaric > 0)
            {
                return ((PlayerMobile)m).CharacterBarbaric;
            }
        }

        return 0;
    }

    public static bool EvilPlay(Mobile m)
    {
        if (m != null && m is PlayerMobile)
        {
            if (((PlayerMobile)m).CharacterEvil == 1)
            {
                return true;
            }
        }
        else if (m != null && m is BaseCreature)
        {
            Mobile killer = m.LastKiller;
            if (killer is BaseCreature)
            {
                BaseCreature bc_killer = (BaseCreature)killer;
                if (bc_killer.Summoned)
                {
                    if (bc_killer.SummonMaster != null)
                    {
                        killer = bc_killer.SummonMaster;
                    }
                }
                else if (bc_killer.Controlled)
                {
                    if (bc_killer.ControlMaster != null)
                    {
                        killer = bc_killer.ControlMaster;
                    }
                }
                else if (bc_killer.BardProvoked)
                {
                    if (bc_killer.BardMaster != null)
                    {
                        killer = bc_killer.BardMaster;
                    }
                }
            }

            if (killer != null && killer is PlayerMobile)
            {
                if (((PlayerMobile)killer).CharacterEvil == 1)
                {
                    return true;
                }
            }
            else
            {
                Mobile hitter = m.FindMostRecentDamager(true);
                if (hitter is BaseCreature)
                {
                    BaseCreature bc_killer = (BaseCreature)hitter;
                    if (bc_killer.Summoned)
                    {
                        if (bc_killer.SummonMaster != null)
                        {
                            hitter = bc_killer.SummonMaster;
                        }
                    }
                    else if (bc_killer.Controlled)
                    {
                        if (bc_killer.ControlMaster != null)
                        {
                            hitter = bc_killer.ControlMaster;
                        }
                    }
                    else if (bc_killer.BardProvoked)
                    {
                        if (bc_killer.BardMaster != null)
                        {
                            hitter = bc_killer.BardMaster;
                        }
                    }
                }

                if (hitter != null && hitter is PlayerMobile)
                {
                    if (((PlayerMobile)hitter).CharacterEvil == 1)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public static int GetWealth(Mobile from, int pack)
    {
        int wealth = 0;

        Container bank = from.FindBankNoCreate();
        if (pack > 0)
        {
            bank = from.Backpack;
        }

        if (bank != null)
        {
            Item[] gold     = bank.FindItemsByType(typeof(Gold));
            Item[] checks   = bank.FindItemsByType(typeof(BankCheck));
            Item[] silver   = bank.FindItemsByType(typeof(DDSilver));
            Item[] copper   = bank.FindItemsByType(typeof(DDCopper));
            Item[] xormite  = bank.FindItemsByType(typeof(DDXormite));
            Item[] jewels   = bank.FindItemsByType(typeof(DDJewels));
            Item[] crystals = bank.FindItemsByType(typeof(Crystals));
            Item[] gems     = bank.FindItemsByType(typeof(DDGemstones));
            Item[] nuggets  = bank.FindItemsByType(typeof(DDGoldNuggets));

            for (int i = 0; i < gold.Length; ++i)
            {
                wealth += gold[i].Amount;
            }

            for (int i = 0; i < checks.Length; ++i)
            {
                wealth += ((BankCheck)checks[i]).Worth;
            }

            for (int i = 0; i < silver.Length; ++i)
            {
                wealth += (int)Math.Floor((decimal)(silver[i].Amount / 5));
            }

            for (int i = 0; i < copper.Length; ++i)
            {
                wealth += (int)Math.Floor((decimal)(copper[i].Amount / 10));
            }

            for (int i = 0; i < xormite.Length; ++i)
            {
                wealth += (xormite[i].Amount) * 3;
            }

            for (int i = 0; i < crystals.Length; ++i)
            {
                wealth += (crystals[i].Amount) * 5;
            }

            for (int i = 0; i < jewels.Length; ++i)
            {
                wealth += (jewels[i].Amount) * 2;
            }

            for (int i = 0; i < gems.Length; ++i)
            {
                wealth += (gems[i].Amount) * 2;
            }

            for (int i = 0; i < nuggets.Length; ++i)
            {
                wealth += (nuggets[i].Amount);
            }
        }

        return wealth;
    }
}
}

namespace Server.Gumps
{
public class StatsGump : Gump
{
    public int m_Origin;

    public static void Initialize()
    {
        CommandSystem.Register("status", AccessLevel.Player, new CommandEventHandler(MyStats_OnCommand));
    }

    public static void Register(string command, AccessLevel access, CommandEventHandler handler)
    {
        CommandSystem.Register(command, access, handler);
    }

    [Usage("status")]
    [Description("Opens Stats Gump.")]
    public static void MyStats_OnCommand(CommandEventArgs e)
    {
        Mobile from = e.Mobile;
        from.CloseGump(typeof(StatsGump));
        from.SendGump(new StatsGump(from, from, 0));
    }

    public StatsGump(Mobile m, Mobile from, int origin) : base(50, 50)
    {
        m_Origin = origin;

        if (origin == 0)
        {
            from.SendSound(0x4A);
        }

        int    LRCCap            = 100;
        int    LMCCap            = 40;
        double BandageSpeedCap   = 5.0;
        int    SwingSpeedCap     = 100;
        int    HCICap            = 45;
        int    DCICap            = 45;
        int    FCCap             = 4; // FC 4 For Paladin, otherwise FC 2 for Mage
        int    FCRCap            = 4;
        int    DamageIncreaseCap = 100;
        int    SDICap            = 1000000;
        if (SDICap > Server.Misc.MyServerSettings.SpellDamageIncreaseVsMonsters() && Server.Misc.MyServerSettings.SpellDamageIncreaseVsMonsters() > 0)
        {
            SDICap = Server.Misc.MyServerSettings.SpellDamageIncreaseVsMonsters();
        }
        int ReflectDamageCap = 100;
        int SSICap           = 100;

        int      LRC            = AosAttributes.GetValue(from, AosAttribute.LowerRegCost) > LRCCap ? LRCCap : AosAttributes.GetValue(from, AosAttribute.LowerRegCost);
        int      LMC            = AosAttributes.GetValue(from, AosAttribute.LowerManaCost) > LMCCap ? LMCCap : AosAttributes.GetValue(from, AosAttribute.LowerManaCost);
        double   BandageSpeed   = (5.0 + (0.5 * ((double)(120 - from.Dex) / 10))) < BandageSpeedCap ? BandageSpeedCap : (5.0 + (0.5 * ((double)(120 - from.Dex) / 10)));
        TimeSpan SwingSpeed     = (from.Weapon as BaseWeapon).GetDelay(from) > TimeSpan.FromSeconds(SwingSpeedCap) ? TimeSpan.FromSeconds(SwingSpeedCap) : (from.Weapon as BaseWeapon).GetDelay(from);
        int      HCI            = AosAttributes.GetValue(from, AosAttribute.AttackChance) > HCICap ? HCICap : AosAttributes.GetValue(from, AosAttribute.AttackChance);
        int      DCI            = AosAttributes.GetValue(from, AosAttribute.DefendChance) > DCICap ? DCICap : AosAttributes.GetValue(from, AosAttribute.DefendChance);
        int      FC             = AosAttributes.GetValue(from, AosAttribute.CastSpeed) > FCCap ? FCCap : AosAttributes.GetValue(from, AosAttribute.CastSpeed);
        int      FCR            = AosAttributes.GetValue(from, AosAttribute.CastRecovery) > FCRCap ? FCRCap : AosAttributes.GetValue(from, AosAttribute.CastRecovery);
        int      DamageIncrease = AosAttributes.GetValue(from, AosAttribute.WeaponDamage) > DamageIncreaseCap ? DamageIncreaseCap : AosAttributes.GetValue(from, AosAttribute.WeaponDamage);
        int      SDI            = AosAttributes.GetValue(from, AosAttribute.SpellDamage) > SDICap ? SDICap : AosAttributes.GetValue(from, AosAttribute.SpellDamage);
        int      ReflectDamage  = AosAttributes.GetValue(from, AosAttribute.ReflectPhysical) > ReflectDamageCap ? ReflectDamageCap : AosAttributes.GetValue(from, AosAttribute.ReflectPhysical);
        int      SSI            = AosAttributes.GetValue(from, AosAttribute.WeaponSpeed) > SSICap ? SSICap : AosAttributes.GetValue(from, AosAttribute.WeaponSpeed);
        int      HealCost       = GetPlayerInfo.GetResurrectCost(from);
        int      CharacterLevel = GetPlayerInfo.GetPlayerLevel(from);
        int      EP             = BasePotion.EnhancePotions(from);
        int      MgAb           = from.MagicDamageAbsorb;
        int      MeAb           = from.MeleeDamageAbsorb;

        this.Closable   = true;
        this.Disposable = true;
        this.Dragable   = true;
        this.Resizable  = false;

        AddPage(0);

        // 0 - BUTTON // 1 - PLAYERS HANDBOOK // 2 - DIVINATION

        int    img   = 11420;
        string color = "#E4E377";

        if (m_Origin == 1)
        {
            img   = 11417;
            color = "#DCB179";
        }
        else if (m_Origin == 2)
        {
            img   = 11419;
            color = "#E59DE2";
        }

        AddImage(1, 1, img, Server.Misc.PlayerSettings.GetGumpHue(m));

        string name = from.Name;
        if (from.Title != "" && from.Title != null)
        {
            name = name + " " + from.Title;
        }
        else
        {
            name = name + " the " + GetPlayerInfo.GetSkillTitle(from) + "";
        }

        AddHtml(15, 15, 400, 20, @"<BODY><BASEFONT Color=" + color + ">" + name.ToUpper() + "</BASEFONT></BODY>", (bool)false, (bool)false);

        AddButton(667, 12, 4017, 4017, 0, GumpButtonType.Reply, 0);

        AddButton(20, 402, 4011, 4011, 666, GumpButtonType.Reply, 0);
        string warnColor = "#7ab582";
        string warnMsg   = "Innocent";
        if (Server.Misc.GetPlayerInfo.IsWanted(from))
        {
            warnColor = "#d38a8a";
            warnMsg   = "Guilty";
        }

        AddHtml(61, 406, 100, 20, @"<BODY><BASEFONT Color=" + warnColor + ">" + warnMsg + "</BASEFONT></BODY>", (bool)false, (bool)false);

        string colA = "";
        colA = colA + "Strength<BR><BR>";
        colA = colA + "Dexterity<BR><BR>";
        colA = colA + "Intelligence<BR><BR>";
        colA = colA + "Fame<BR><BR>";
        colA = colA + "Karma<BR><BR>";
        colA = colA + "Tithe<BR><BR>";
        colA = colA + "Hunger<BR><BR>";
        colA = colA + "Thirst<BR><BR>";
        colA = colA + "Potion Enhance<BR><BR>";
        colA = colA + "Bank Gold<BR><BR>";

        string colB = "";
        colB = colB + "" + String.Format(" {0} + {1}", from.RawStr, from.Str - from.RawStr) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0} + {1}", from.RawDex, from.Dex - from.RawDex) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0} + {1}", from.RawInt, from.Int - from.RawInt) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0}", from.Fame) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0}", from.Karma) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0}", from.TithingPoints) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0}", from.Hunger) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0}", from.Thirst) + "<BR><BR>";
        colB = colB + "" + String.Format(" {0}%", EP) + "<BR><BR>";
        colB = colB + "" + Banker.GetBalance(from) + "<BR> <BR><BR>";

        AddHtml(20, 45, 200, 370, @"<BODY><BASEFONT Color=" + color + ">" + colA + "</BASEFONT></BODY>", (bool)false, (bool)false);
        AddHtml(135, 45, 80, 370, @"<BODY><BASEFONT Color=" + color + "><div align=right>" + colB + "</div></BASEFONT></BODY>", (bool)false, (bool)false);

        ///////////////////////////////////////////////////////////////////////////////////

        string colC = "";
        colC = colC + "Level<BR><BR>";
        colC = colC + "Hits<BR><BR>";
        colC = colC + "Stamina<BR><BR>";
        colC = colC + "Mana<BR><BR>";
        colC = colC + "Hits Regen<BR><BR>";
        colC = colC + "Stamina Regen<BR><BR>";
        colC = colC + "Mana Regen<BR><BR>";
        colC = colC + "Low Reagent<BR><BR>";
        colC = colC + "Low Mana<BR><BR>";
        colC = colC + "Resurrect Cost<BR><BR>";
        colC = colC + "Murders<BR><BR>";

        string colD = "";
        colD = colD + "" + String.Format(" {0}", CharacterLevel) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0} + {1}", from.Hits - AosAttributes.GetValue(from, AosAttribute.BonusHits), AosAttributes.GetValue(from, AosAttribute.BonusHits)) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0} + {1}", from.Stam - AosAttributes.GetValue(from, AosAttribute.BonusStam), AosAttributes.GetValue(from, AosAttribute.BonusStam)) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0} + {1}", from.Mana - AosAttributes.GetValue(from, AosAttribute.BonusMana), AosAttributes.GetValue(from, AosAttribute.BonusMana)) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}", AosAttributes.GetValue(from, AosAttribute.RegenHits)) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}", AosAttributes.GetValue(from, AosAttribute.RegenStam)) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}", AosAttributes.GetValue(from, AosAttribute.RegenMana)) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}%", LRC) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}%", LMC) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}", HealCost) + "<BR><BR>";
        colD = colD + "" + String.Format(" {0}", from.Kills) + "<BR><BR>";

        AddHtml(260, 45, 150, 380, @"<BODY><BASEFONT Color=" + color + ">" + colC + "</BASEFONT></BODY>", (bool)false, (bool)false);
        AddHtml(375, 45, 80, 380, @"<BODY><BASEFONT Color=" + color + "><div align=right>" + colD + "</div></BASEFONT></BODY>", (bool)false, (bool)false);

        ///////////////////////////////////////////////////////////////////////////////////

        string colE = "";
        colE = colE + "Hit Chance<BR><BR>";
        colE = colE + "Defend Chance<BR><BR>";
        colE = colE + "Swing Speed<BR><BR>";
        colE = colE + "Swing Speed +<BR><BR>";
        colE = colE + "Bandage Speed<BR><BR>";
        colE = colE + "Damage Increase<BR><BR>";
        colE = colE + "Reflect Damage<BR><BR>";
        colE = colE + "Fast Cast<BR><BR>";
        colE = colE + "Cast Recovery<BR><BR>";
        colE = colE + "Spell Damage +<BR><BR>";
        colE = colE + "Magic/Melee Absorb<BR><BR>";

        string colF = "";
        colF = colF + "" + String.Format(" {0}%", HCI) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}%", DCI) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}s", new DateTime(SwingSpeed.Ticks).ToString("s.ff")) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}%", SSI) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0:0.0}s", new DateTime(TimeSpan.FromSeconds(BandageSpeed).Ticks).ToString("s.ff")) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}%", DamageIncrease) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}%", ReflectDamage) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}", FC) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}", FCR) + "<BR><BR>";
        colF = colF + "" + String.Format(" {0}%", SDI) + "<BR><BR>";
        colF = colF + "" + MgAb + "/" + MeAb + "<BR><BR>";

        AddHtml(500, 45, 150, 380, @"<BODY><BASEFONT Color=" + color + ">" + colE + "</BASEFONT></BODY>", (bool)false, (bool)false);
        AddHtml(615, 45, 80, 380, @"<BODY><BASEFONT Color=" + color + "><div align=right>" + colF + "</div></BASEFONT></BODY>", (bool)false, (bool)false);
    }

    public override void OnResponse(NetState sender, RelayInfo info)
    {
        Mobile from = sender.Mobile;

        if (info.ButtonID == 666)
        {
            from.SendGump(new StatsGump(from, from, m_Origin));
            from.SendGump(new Wanted(from));
        }
        else if (m_Origin == 1)
        {
            from.SendSound(0x55);
        }
        else if (m_Origin == 2)
        {
            from.SendSound(0x0F9);
        }
        else
        {
            from.SendSound(0x4A);
        }
    }
}
}

namespace Server.Engines.Quests
{
public class QuestButton
{
    public static void Initialize()
    {
        EventSink.QuestGumpRequest += new QuestGumpRequestHandler(EventSink_QuestGumpRequest);
    }

    public static void EventSink_QuestGumpRequest(QuestGumpRequestArgs e)
    {
        Mobile from = e.Mobile;
        from.CloseGump(typeof(StatsGump));
        from.SendGump(new StatsGump(from, from, 0));
    }
}
}
