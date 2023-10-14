using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Menus;
using Server.Menus.Questions;
using Server.Accounting;
using Server.Multis;
using Server.Mobiles;
using Server.Regions;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Misc;
using Server.Items;
using System.Globalization;

namespace Server.Engines.Help
{
public class ServerSettingsGump : Gump
{
    public ServerSettingsGump(Mobile from, int page) : base(50, 50)
    {
        string color  = "#33788a";
        int    button = 4005;

        from.SendSound(0x4A);

        Closable   = true;
        Disposable = true;
        Dragable   = true;
        Resizable  = false;

        AddPage(0);

        AddImage(0, 0, 7065);

        AddHtml(17, 15, 857, 23, @"<BASEFONT Color=" + color + ">SERVER SETTINGS</BASEFONT>", (bool)false, (bool)false);

        AddButton(867, 15, 4014, 4014, 800, GumpButtonType.Reply, 0);
        AddButton(904, 15, 3610, 3610, 802, GumpButtonType.Reply, 0);
        AddButton(962, 15, 4005, 4005, 801, GumpButtonType.Reply, 0);

        int rules = 50;
        int rule  = 0;
        if (page == 2)
        {
            rule = 50;
        }

        int x = 16;
        int y = 52;

        while (rules > 0)
        {
            rule++;
            rules--;

            if (rule == 26)
            {
                x = 600;
                y = 52;
            }

            this.AddButton(x, y, 3609, 3609, (1000 + rule), GumpButtonType.Reply, 0);
            this.AddButton(x + 37, y, 4011, 4011, (2000 + rule), GumpButtonType.Reply, 0);
            this.AddHtml(x + 77, y, 367, 23, @"<BASEFONT Color=" + SettingEach(rule, 3) + ">" + SettingEach(rule, 1) + "</BASEFONT>", (bool)false, (bool)false);

            y = y + 32;
        }
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile from = state.Mobile;

        from.SendSound(0x4A);

        from.CloseGump(typeof(Server.Engines.Help.ServerSettingsGump));

        if (info.ButtonID > 81 && info.ButtonID < 200)                   // SMALL INFO HELP WINDOWS
        {
            from.CloseGump(typeof(SettingInfoGump));
            from.SendGump(new SettingInfoGump(from, info.ButtonID, 12));
        }
    }

    public static string SettingMain(int setting, bool colors)
    {
        string color    = "";
        string category = "";

        switch (setting)
        {
            case 1:         color = "#33788a";      category = "System";    break;
            case 2:         color = "#6c7d33";      category = "Game";              break;
            case 3:         color = "#963390";      category = "Players";   break;
            case 4:         color = "#d87888";      category = "Dangers";   break;
            case 5:         color = "#bd954f";      category = "Creatures"; break;
            case 6:         color = "#88df96";      category = "Comrades";  break;
            case 7:         color = "#e1e65b";      category = "Quests";    break;
            case 8:         color = "#9299f5";      category = "Homes";             break;
            case 9:         color = "#f0b9f1";      category = "Vendors";   break;
            case 10:        color = "#84eeef";      category = "Guards";    break;
        }

        if (colors)
        {
            return color;
        }

        return category;
    }

    public static string SettingEach(int id, int part)
    {
        string title    = "";
        string defaults = "";
        string category = "";
        string note     = "";

        switch (id)
        {
            case 1: title  = "Auto Account Creation"; defaults = "false"; category = "1"; note = "If set, players can just type in a name and password and it will create an account for them."; break;
            case 2: title  = "Days to Delete Characters"; defaults = "7.0"; category = "1"; note = "This setting is the number of days a character must exist before a player can delete them."; break;
            case 3: title  = "Enable Console"; defaults = "false"; category = "1"; note = "Enables commands to be entered into the server console. WARNING: May cause crashes so enable it at your own risk."; break;
            case 4: title  = "Game Save Time"; defaults = "30.0"; category = "1"; note = "The game saves itself after this many minutes in decimal format between 10 and 240 minutes."; break;
            case 5: title  = "Run Routines on Startup"; defaults = "true"; category = "1"; note = "If you play a single player game, then setting this will enable the game to run certain routines to keep the world in shape. Otherwise, a constantly running server will do this for you."; break;
            case 6: title  = "Save on Log Out"; defaults = "true"; category = "1"; note = "If set, this saves the game when your character logs out. Helpful for single player games."; break;
            case 7: title  = "Server Port"; defaults = "2593"; category = "1"; note = "The port you want your server to listen on."; break;
            case 8: title  = "Allow Unattended Harvesting"; defaults = "true"; category = "2"; note = "If this is not set, then characters will get a CAPTCHA window occasionally to avoid unattended resource gathering with macros."; break;
            case 9: title  = "Alter Classic Artifacts"; defaults = "false"; category = "2"; note = "There are almost 300 classic artifacts in the game, as well as artifacts created for this game that are specifically named and designed. These are items like 'Stormbringer' or 'Conan's Lost Sword'. By default, these items will retain their appearance and color no matter what is done to them. Setting this to true will allow a player to use items like the Magic Scissors or Magic Hammer to change the appearance of the items, but they will always retain their name. This is false by default."; break;
            case 10: title = "Boat/Carpet Decay in Days"; defaults = "5.0"; category = "2"; note = "The number of days, no less than 5.0 (decimal format), that a boat or magic carpet will decay if on the sea not used."; break;
            case 11: title = "Home Decay in Days"; defaults = "30.0"; category = "2"; note = "The number of days, no less than 30.0 (decimal format), that a home will decay if an owner never shows up."; break;
            case 12: title = "Harvest Modifier"; defaults = "1"; category = "2"; note = "This value should be set between 1-100, where the amount of resources one gets (ore, logs, hides, herbs, jars of body parts, meat, feathers, scales, wool, wheat, furs, fish, sand, and blank scrolls) will be modified in some way by this value. The Isles of Dread will still have a slightly more amount than the other lands as intended. Certain skills will still enhance what is found too as they normally do. Increasing this from 1 is meant for games where resource gathering is to be made easier, so an increase in this will also cause the harvesting skill to raise faster as well, but only when successful resources are gathered (lumberjacking, mining, fishing, forensics, cooking, and inscription)."; break;
            case 13: title = "New Leather Colors"; defaults = "true"; category = "2"; note = "If set, then your world will use newer leather colors whenever possible. If you ever change this, delete the colors.set file in the Info folder and restart the server so the current items can have their color changed."; break;
            case 14: title = "New Metal Colors"; defaults = "true"; category = "2"; note = "If set, then your world will use shiny metal colors whenever possible. If you ever change this, delete the colors.set file in the Info folder and restart the server so the current items can have their color changed."; break;
            case 15: title = "Only Identify Items in Backpack"; defaults = "false"; category = "2"; note = "If set, then characters can only identify items (that require a double click) within their backpack."; break;
            case 16: title = "Unidentified Items"; defaults = "50"; category = "2"; note = "The percent chance an item will be unidentified, and no less than 10 percent."; break;
            case 17: title = "Persistent Blackjack"; defaults = "false"; category = "2"; note = "If set, then the blackjack tables will retain their settings and information if the server ever restarts. Better for persistent worlds."; break;
            case 18: title = "Alien Races"; defaults = "true"; category = "3"; note = "If set, then new characters can choose to take the alien origin route."; break;
            case 19: title = "Allow Custom Titles"; defaults = "true"; category = "3"; note = "If set, then characters will be able to set a custom title for their character in the HELP section."; break;
            case 20: title = "Character Races"; defaults = "1"; category = "3"; note = "Set to the number 0 to disable. The other values are 1, 2, or 3 where the default is 1. When greater than 0, you will enable the creature character feature of the game. This allows players to become a creature of the game as their player character. They can play like the game normally plays, but since they would be using creature models their appearance will remain static (some species have options to change appearances to other models). They can equip and use things normally (except cloaks and quivers), but their equipment will be displayed as icons on their paperdoll so they can manage their inventory. They will not be able to start as alien races if that option is enabled, but they can do the other starting area options if their alignment allows. Disabling this option, at a later time, will return all characters back to human upon world restart. The different values indicate the size of creatures allowed to choose from. Option '1' allows for roughly human height humanoids like lizardment, ratmen, trolls, and ogres. Option '2' allows for option '1' and includes larger creatures like ogre lords, ettins, and daemons. Option '3' includes the first two options, but also allows for creatures such as giants and balrons. There is a more details explanation of this system using the gypsy's shelf in her starting tent."; break;
            case 21: title = "Bones Decay in Minutes"; defaults = "110"; category = "3"; note = "This setting is the number of minutes that a player character bones will decay. This option could potentially be used to have player character corpses remain longer or for a more difficult style of play where the corpse and belongings vanish immediatley."; break;
            case 22: title = "Corpse to Bones in Minutes"; defaults = "10"; category = "3"; note = "This setting is the number of minutes that a player character corpse will turn into bones. when added to the bone decay setting, it makes the total number of minutes that a player has to find their corpse and potentially collect their belongings."; break;
            case 23: title = "Dismount in Buildings"; defaults = "true"; category = "3"; note = "If set, then characters on mounts will dismount when they enter a building. They should mount their steed again when they leave."; break;
            case 24: title = "Dismount in Homes"; defaults = "true"; category = "3"; note = "If set, then characters on mounts will dismount when they enter a player character's home. They should mount their steed again when they leave."; break;
            case 25: title = "Exceptional Item Magic"; defaults = "true"; category = "3"; note = "If set, then players have a chance for some slight magical properties on crafted exceptional items (armor, weapons, clothing, quivers, jewelry, or instruments) where the better the skill, material, and if they are in the guild will determine effectiveness."; break;
            case 26: title = "Macro Skills Disabled"; defaults = "false"; category = "3"; note = "If set, then a player character cannot use macros to improve their skills quickly."; break;
            case 27: title = "Minimum Skill for Weapon Abilities"; defaults = "70.0"; category = "3"; note = "To use special weapon abilities, this is the minimum skill level required (weapon skill and tactics) where the default is 70.0 (minimum of 20.0). Each ability requires 10 additional points above the previous (70, 80, 90, etc)."; break;
            case 28: title = "Minutes for Stat Gain"; defaults = "15.0"; category = "3"; note = "The minutes between stat gains. This can be between 5.0 to 60.0 minutes."; break;
            case 29: title = "Stat Gain Rate"; defaults = "33.3"; category = "3"; note = "You can increase the rate that stats gain from 50.0 (slow) to 10.0 (fast)."; break;
            case 30: title = "Stat to Ability Modifier"; defaults = "2.0"; category = "3"; note = "This setting between 0.5 and 2.0 (decimal format) will give a character that much hit points, mana, or stamina based on the attribute. So a strength of 100 will give a character 200 hit points if this is set at 2.0."; break;
            case 31: title = "Spell Damage to Monsters"; defaults = "200"; category = "3"; note = "Spell damage toward monsters can be between 25 and 200 percent."; break;
            case 32: title = "Spell Damage to Players"; defaults = "100"; category = "3"; note = "Spell damage toward player characters can be between 25 and 200 percent."; break;
            case 33: title = "All Creatures Search"; defaults = "true"; category = "4"; note = "If set, then all creatures will have an ability to detect hidden characters based on their difficulty level."; break;
            case 34: title = "Critical Damage to Pet Chance"; defaults = "0"; category = "4"; note = "If you think animal tamer pets ruin game balance, then you can set a 0-100 percent chance they will get a critical double damage hit against them."; break;
            case 35: title = "Damage to Pets Modifier"; defaults = "1.0"; category = "4"; note = "If you think animal tamer pets ruin game balance, then increase this amount in decimal format to increase damage done to them."; break;
            case 36: title = "Dungeon Sounds"; defaults = "true"; category = "4"; note = "If set, then dungeon environments will have random sounds as you traverse the corridors."; break;
            case 37: title = "Active Floor Traps"; defaults = "20"; category = "4"; note = "The percentage of dungeon floor traps that are actually active, and no less than 5 percent."; break;
            case 38: title = "Fog of War"; defaults = "true"; category = "4"; note = "If set, then creatures will not be seen behind dungeon doors and walls or around corners unless they are searching for blood. It only applies to creatures in dungeons, caves, or outside dangerous areas like cemeteries."; break;
            case 39: title = "Good Attacks Evil"; defaults = "true"; category = "4"; note = "If set, then the purple named creatures will attack nearby evil creatures and not just the characters that are criminals, murderers, or have low karma."; break;
            case 40: title = "No Riding in Dungeons"; defaults = "true"; category = "4"; note = "If set, then some areas will not allow you to mount a creature for riding. This makes dungeons (for example) more challenging."; break;
            case 41: title = "Trap Avoidance Notification"; defaults = "false"; category = "4"; note = "If set, then anytime a character avoids a trap due to resistances they will be notified. Otherwise, they will never know they avoided it due to resistances."; break;
            case 42: title = "Animal, Elephants"; defaults = "true"; category = "5"; note = "If set, then elephants will be in your game world."; break;
            case 43: title = "Animal, Forest Cats"; defaults = "true"; category = "5"; note = "If set, then some of the great forest cats will use the larger model. Otherwise, they will use the classic smaller model."; break;
            case 44: title = "Animal, Foxes"; defaults = "true"; category = "5"; note = "If set, then foxes will be in your game world."; break;
            case 45: title = "Animal, Zebras"; defaults = "true"; category = "5"; note = "If set, then zebras will be in your game world."; break;
            case 46: title = "Wyrm Appearance"; defaults = "723"; category = "5"; note = "This is the body value for standard Wyrms. 723 is the newer, larger creatures. 12 is the classic wyrm where 59 is the dragon body."; break;
            case 47: title = "Citizens Have Creature Comrades"; defaults = "true"; category = "6"; note = "If set, then adventurers that gather in towns may have a humanoid, pet, or summoned companion with them. These gatherings are when 2-4 adventurers stand in a circle and face each other, usually holding weapons and sometimes riding mounts. This setting adds a bit of fantasy world atmosphere and lets players know that they too can perhaps have such a follower. There is only about a 5% chance one will appear and then only 1 will appear in a group."; break;
            case 48: title = "Extra Stable Slots"; defaults = "5"; category = "6"; note = "This setting can be between 0 and 20. This is the number of extra stabled pets players get (beyond the normal amount of '2'), where anything more will rely on their skills in druidism, taming, veterinary, and herding."; break;
            case 49: title = "Friends March in Order"; defaults = "false"; category = "6"; note = "If set, then followers will not stack on top of each other but instead spread out a bit."; break;
            case 50: title = "Friends Protect Friends"; defaults = "true"; category = "6"; note = "If set, then followers will not only guard you when commanded, but guard the other followers in your group."; break;
            case 51: title = "Friends Run to Keep Up"; defaults = "true"; category = "6"; note = "If set, then followers will attempt to keep up with you if you are running fast."; break;
            case 52: title = "Minutes for Pet Stat Gain"; defaults = "5.0"; category = "6"; note = "The minutes between stat gains for pets that you can train. This can be between 1.0 to 60.0 minutes."; break;
            case 53: title = "Gold Drop"; defaults = "25"; category = "7"; note = "The percent of gold you get from creatures, treasure, cargo, museum searches, shoppes, and some quests between 5 (low) to 100 (high)."; break;
            case 54: title = "Gold Modifier for Bulletin Boards"; defaults = "150"; category = "7"; note = "The gold reward from bulletin board quests is modified between 50 and 250 percent."; break;
            case 55: title = "Minutes for Bulletin Board Quests"; defaults = "60"; category = "7"; note = "The minutes before you can take a bulletin board quest after finishing one."; break;
            case 56: title = "Minutes for Sage Quests"; defaults = "20160"; category = "7"; note = "The minutes before you can take a sage artifact quest after finishing one."; break;
            case 57: title = "Custom House System"; defaults = "true"; category = "8"; note = "If set, then players can make use of the custom house system. Otherwise they can only purchase the pre-built classic houses."; break;
            case 58: title = "Color Homes"; defaults = "true"; category = "8"; note = "If set, this means that the players can dye construction contracts so their pre-designed home is entirely in that same color."; break;
            case 59: title = "Houses Decay"; defaults = "false"; category = "8"; note = "If set, then houses never decay."; break;
            case 60: title = "Items in Home Never Decay"; defaults = "false"; category = "8"; note = "If set, then anything you set in your home will never decay. This makes the housing system's storage capacity useless as any home can hold any amount of items, and it may convince players to never bother with a castle or dungeon home because there is no storage limits on any house. But if you don't want to worry about this game element in your world then you can allow players to drop things on the floor without worrying about locking or securing them down. Players still need to lock items down if they are going to decorate their home and they want them unmovable or able to be manipulated with the homeowner tools."; break;
            case 61: title = "Houses per Character"; defaults = "-1"; category = "8"; note = "The amount of houses an account's characters may own. A -1 setting will be unlimited."; break;
            case 62: title = "Co-Owners are Owners"; defaults = "false"; category = "8"; note = "If set, then co-owners of houses will have the same permissions as owners. The security choice gump will then specify this dual ownership when choosing an item security level. When this is not set, then co-owners have much more limited permissions as the standard game allows."; break;
            case 63: title = "Enable Lawn Tools"; defaults = "true"; category = "8"; note = "When set, characters can use lawn tools (from architects) to add items to the outside of their home like trees, shrubs, fences, lave, water, and other items. Lawn tools require an amount of gold to place items. If this was previously set and characters placed lawn items, and then you turn it off, the lawn items will refund the gold back to the character's bank box and the lawn tools will be removed from the game."; break;
            case 64: title = "Enable Remodeling Tools"; defaults = "true"; category = "8"; note = "When set, characters can use remodeling tools (from architects) to add items to their home like walls, doors, tiles, and other items. Remodeling tools require an amount of gold to place items. If this was previously set and characters placed remodeling items, and then you turn it off, the remodeling items will refund the gold back to the character's bank box and the remodeling tools will be removed from the game."; break;
            case 65: title = "Public Basements"; defaults = "true"; category = "8"; note = "If set, the public basement system is active. This lets players buy basement doors for their homes and basement doors will appear in some trade shops. These lead to the same basement public area and is usually used for multiplayer game environments."; break;
            case 66: title = "Vendor Buys Very Common Items"; defaults = "80"; category = "9"; note = "Percent chance that a vendor buys a very common item."; break;
            case 67: title = "Vendor Buys Common Items"; defaults = "50"; category = "9"; note = "Percent chance that a vendor buys a common item."; break;
            case 68: title = "Vendor Buys Rare Items"; defaults = "70"; category = "9"; note = "Percent chance that a vendor buys a rare item."; break;
            case 69: title = "Vendor Sells Very Common Items"; defaults = "80"; category = "9"; note = "Percent chance that a vendor sells a very common item."; break;
            case 70: title = "Vendor Sells Common Items"; defaults = "50"; category = "9"; note = "Percent chance that a vendor sells a common item."; break;
            case 71: title = "Vendor Sells Rare Items"; defaults = "25"; category = "9"; note = "Percent chance that a vendor sells a rare item."; break;
            case 72: title = "Vendor Sells Very Rare Items"; defaults = "5"; category = "9"; note = "Percent chance that a vendor sells a very rare item."; break;
            case 73: title = "Vendors Sell Resources"; defaults = "false"; category = "9"; note = "If set, then some merchants may sell large volumes of resources (ingots, ore, boards, leather, hides, cloth, bottles, jars, and blank scrolls) and more types, except for non-magical resources (reagents). The resources sold may appear based on their rarity and location of the merchant (verite, cherry wood, deep sea leather, etc). EXAMPLE: If you can only get obsidian in the Serpent Island, then you will only find obsidian ingots available for sale in that land. Those that set this to true, want a game where they would like to craft items and spend gold gathering the resources more often than harvesting."; break;
            case 74: title = "Merchant Books Enabled"; defaults = "true"; category = "9"; note = "If set, then special merchant books may appear in the leather, carpenter, bowyer, and blacksmith shops. These books will have a list of items a character can buy that would be made from special materials like valorite metal, serpent leather, or hickory wood (as examples). Every 250 minutes they will switch to either be a different material type or there is simply a 50% chance they will not appear in the shop until the next scheduled run. Some materials will never appear in shops if the material is specific to a particular land. EXAMPLE: If you can only get obsidian in the Serpent Island, then you will may only find obsidian items available for sale in that land."; break;
            case 75: title = "Bribery Cost"; defaults = "50000"; category = "10"; note = "If set to 1,000 gold or higher, then the bribery system will be enabled that allows characters to give this amount of gold to the Assassin Guildmaster so they can bribe the right people and remove a murder count one at a time (never applies to fugitives, and assassin guild members only pay half this amount)."; break;
            case 76: title = "Guards Run"; defaults = "true"; category = "10"; note = "If set, then guards will run to catch criminals but this only works if they do not sentence them to death."; break;
            case 77: title = "Guards Watch Borders"; defaults = "false"; category = "10"; note = "If set, then guards will react to enemies outside of their town borders."; break;
            case 78: title = "Sentenced to Death"; defaults = "false"; category = "10"; note = "If set, then guards will instantly kill criminal and murderer characters. Otherwise, the guards will chase them and try to send them to prison."; break;
        }

        if (part == 1)
        {
            return title;
        }
        else if (part == 2)
        {
            return defaults;
        }
        else if (part == 3)
        {
            return SettingMain(Int32.Parse(category), true);
        }
        else if (part == 4)
        {
            return SettingMain(Int32.Parse(category), false);
        }

        return note;
    }
}
}

namespace Server.Gumps
{
public class SettingInfoGump : Gump
{
    public int m_Origin;

    public SettingInfoGump(Mobile from, int page, int origin) : base(50, 50)
    {
        m_Origin = origin;

        this.Closable   = true;
        this.Disposable = true;
        this.Dragable   = true;
        this.Resizable  = false;

        string title     = "";
        string info      = "";
        bool   scrollbar = true;

        if (page == 82)
        {
            scrollbar = false;
            title     = "Music Tone";
            info      = "This option will simply toggle your music preference to play a different set of music in the dungeons. When turned on, it will play music you normally hear when traveling the land, instead of the music commonly played in dungeons.";
        }
        else if (page == 83)
        {
            title = "Music Playlist";
            info  = "This gives you a complete list of the in-game music. You can select the music you like and those choices will randomly play as you go from region to region. To listen to a song for review, select the blue gem icon. Note that the client has a delay time when you can start another song so selecting the blue gem may not respond if you started a song too soon before that. Wait for a few seconds and try clicking the blue gem again to see if that song starts to play. Playlists are disabled by default, so if you want your playlist to function, make sure to enable it.";
        }

        AddPage(0);

        string color = "#ddbc4b";

        AddImage(0, 0, 9577, Server.Misc.PlayerSettings.GetGumpHue(from));
        AddHtml(12, 12, 239, 20, @"<BODY><BASEFONT Color=" + color + ">" + title + "</BASEFONT></BODY>", (bool)false, (bool)false);
        AddHtml(12, 43, 278, 212, @"<BODY><BASEFONT Color=" + color + ">" + info + "</BASEFONT></BODY>", (bool)false, (bool)scrollbar);
        AddButton(268, 9, 4017, 4017, 0, GumpButtonType.Reply, 0);
    }

    public override void OnResponse(NetState sender, RelayInfo info)
    {
        Mobile from = sender.Mobile;
        from.SendSound(0x4A);
        from.CloseGump(typeof(Server.Engines.Help.ServerSettingsGump));
        if (m_Origin != 999)
        {
            from.SendGump(new Server.Engines.Help.ServerSettingsGump(from, m_Origin));
        }
    }
}
}
