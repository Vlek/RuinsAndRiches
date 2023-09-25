using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fourth;
using Server.Spells.Magical;
using Server.Spells.Bushido;
using Server.Spells.Ninjitsu;
using Server.Spells.Necromancy;
using Server.Spells.Chivalry;
using Server.Spells.DeathKnight;
using Server.Spells.Herbalist;
using Server.Spells.Undead;
using Server.Spells.Mystic;
using Server.Spells.Research;
using Server.Spells.Elementalism;

namespace Server.Misc
{
    class Worlds
    {
		public static string GetMyWorld( Map map, Point3D location, int x, int y )
		{
			Region reg = Region.Find( location, map );
			string worldLocation = "the Land of Sosaria";

			if ( map == Map.Sosaria && x > 5774 && y > 2694 && x < 6123 && y < 3074 ){ worldLocation = "the Moon of Luna"; }
			else if ( map == Map.Sosaria && ( reg.IsPartOf( "Moonlight Cavern" ) ||
												reg.IsPartOf( "The Core of the Moon" ) ||
												reg.IsPartOf( "The Moon's Core" ) ) ){ worldLocation = "the Moon of Luna"; }

			else if ( map == Map.Sosaria && x > 5125 && y > 3038 && x < 6124 && y < 4093 ){ worldLocation = "the Land of Ambrosia"; }
			else if ( map == Map.Sosaria && x > 3229 && y > 3870 && x < 3344 && y < 3946 ){ worldLocation = "the Land of Ambrosia"; }
			else if ( map == Map.Sosaria && ( reg.IsPartOf( "the Dragon's Maw" ) ||
												reg.IsPartOf( "the Cave of the Zuluu" ) ||
												reg.IsPartOf( "the Arena of The Zuluu" ) ) ){ worldLocation = "the Land of Ambrosia"; }

			else if ( map == Map.Sosaria && x > 2931 && y > 3675 && x < 2999 && y < 3722 ){ worldLocation = "the Island of Umber Veil"; }
			else if ( map == Map.Sosaria && x > 699 && y > 3129 && x < 2272 && y < 4095 ){ worldLocation = "the Island of Umber Veil"; }
			else if ( map == Map.Sosaria && reg.IsPartOf( "the Mausoleum" ) ){ worldLocation = "the Island of Umber Veil"; }
			else if ( map == Map.Sosaria && reg.IsPartOf( "the Tower of Brass" ) ){ worldLocation = "the Island of Umber Veil"; }

			else if ( map == Map.Sosaria && x > 6127 && y > 828 && x < 7168 && y < 2736 ){ worldLocation = "the Bottle World of Kuldar"; }
			else if ( map == Map.Sosaria && ( reg.IsPartOf( "Highrock Mine" ) ||
												reg.IsPartOf( "Waterfall Cavern" ) ||
												reg.IsPartOf( "the Crumbling Cave" ) ||
												reg.IsPartOf( "Steamfire Cave" ) ||
												reg.IsPartOf( "the Valley of Dark Druids" ) ||
												reg.IsPartOf( "Vordo's Castle Grounds" ) ||
												reg.IsPartOf( "the Kuldara Sewers" ) ||
												reg.IsPartOf( "the Crypts of Kuldar" ) ||
												reg.IsPartOf( "Vordo's Castle" ) ||
												reg.IsPartOf( "Vordo's Dungeon" ) ) ){ worldLocation = "the Bottle World of Kuldar"; }

			else if ( map == Map.Lodor && ( reg.IsPartOf( "Morgaelin's Inferno" ) ||
												reg.IsPartOf( "the Zealan Tombs" ) ||
												reg.IsPartOf( "Argentrock Castle" ) ||
												reg.IsPartOf( "the Daemon's Crag" ) ||
												reg.IsPartOf( "the Hall of the Mountain King" ) ||
												reg.IsPartOf( "the Depths of Carthax Lake" ) ) ){ worldLocation = "the Underworld"; }

			else if ( map == Map.Sosaria && reg.IsPartOf( "the Chamber of Corruption" ) ){ worldLocation = "the Underworld"; }

			else if ( map == Map.SavagedEmpire && ( reg.IsPartOf( "the Ancient Crash Site" ) ||
												reg.IsPartOf( "the Obsidian Fortress" ) ||
												reg.IsPartOf( "the Ancient Sky Ship" ) ) ){ worldLocation = "the Underworld"; }

			else if ( map == Map.Underworld && ( reg.IsPartOf( "the Glacial Scar" ) ) ){ worldLocation = "the Isles of Dread"; }

			else if ( map == Map.Lodor && ( reg.IsPartOf( "the Temple of Osirus" ) || reg.IsPartOf( "the Sanctum of Saltmarsh" ) ) ){ worldLocation = "the Isles of Dread"; }

			else if ( reg.IsPartOf( typeof( BardTownRegion ) ) || reg.IsPartOf( typeof( BardDungeonRegion ) ) ){ worldLocation = "the Town of Skara Brae"; }

			else if ( map == Map.Lodor && reg.IsPartOf( "the Montor Sewers" ) ){ worldLocation = "the Land of Sosaria"; }
			else if ( map == Map.Lodor && !reg.IsPartOf( "the Vault of the Black Knight" ) ){ worldLocation = "the Land of Lodoria"; }

			else if ( map == Map.SerpentIsland || reg.IsPartOf( "the Vault of the Black Knight" ) ){ worldLocation = "the Serpent Island"; }

			else if (
						map == Map.SavagedEmpire &&
						( reg.IsPartOf( "the Cimmeran Mines" ) ||
						reg.IsPartOf( "the Ice Queen Fortress" ) ||
						reg.IsPartOf( "the Scurvy Reef" ) ||
						reg.IsPartOf( "the Blood Temple" ) ) ){ worldLocation = "the Isles of Dread"; }

			else if ( map == Map.SavagedEmpire && reg.IsPartOf( "the Forgotten Halls" ) ){ worldLocation = "the Land of Sosaria"; }

			else if ( map == Map.SerpentIsland && !reg.IsPartOf( typeof( SkyHomeDwelling ) ) ){ worldLocation = "the Serpent Island"; }

			// SKY CASTLES
			else if ( map == Map.SerpentIsland && ( x > 1949 ) && ( y > 1393 ) && ( x < 2061 ) && ( y < 1486 ) ){ worldLocation = "the Land of Sosaria"; }
			else if ( map == Map.SerpentIsland && ( x > 2150 ) && ( y > 1401 ) && ( x < 2270 ) && ( y < 1513 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.SerpentIsland && ( x > 2375 ) && ( y > 1398 ) && ( x < 2442 ) && ( y < 1467 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.SerpentIsland && ( x > 2401 ) && ( y > 1635 ) && ( x < 2468 ) && ( y < 1703 ) ){ worldLocation = "the Serpent Island"; }
			else if ( map == Map.SerpentIsland && ( x > 2408 ) && ( y > 1896 ) && ( x < 2517 ) && ( y < 2005 ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.SerpentIsland && ( x > 2181 ) && ( y > 1889 ) && ( x < 2275 ) && ( y < 2003 ) ){ worldLocation = "the Isles of Dread"; }
			else if ( map == Map.SerpentIsland && ( x > 1930 ) && ( y > 1890 ) && ( x < 2022 ) && ( y < 1997 ) ){ worldLocation = "the Land of Sosaria"; }

			// DUNGEON HOMES
			else if ( map == Map.Underworld && ( x > 1644 ) && ( y > 35 ) && ( x < 1818 ) && ( y < 163 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.Underworld && ( x > 1864 ) && ( y > 32 ) && ( x < 2041 ) && ( y < 162 ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.Underworld && ( x > 2098 ) && ( y > 27 ) && ( x < 2272 ) && ( y < 156 ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.Underworld && ( x > 1647 ) && ( y > 184 ) && ( x < 1810 ) && ( y < 305 ) ){ worldLocation = "the Serpent Island"; }
			else if ( map == Map.Underworld && ( x > 1877 ) && ( y > 187 ) && ( x < 2033 ) && ( y < 302 ) ){ worldLocation = "the Island of Umber Veil"; }
			else if ( map == Map.Underworld && ( x > 2108 ) && ( y > 190 ) && ( x < 2269 ) && ( y < 305 ) ){ worldLocation = "the Serpent Island"; }
			else if ( map == Map.Underworld && ( x > 1656 ) && ( y > 335 ) && ( x < 1807 ) && ( y < 443 ) ){ worldLocation = "the Land of Sosaria"; }
			else if ( map == Map.Underworld && ( x > 1880 ) && ( y > 338 ) && ( x < 2031 ) && ( y < 445 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.Underworld && ( x > 2111 ) && ( y > 335 ) && ( x < 2266 ) && ( y < 446 ) ){ worldLocation = "the Isles of Dread"; }
			else if ( map == Map.Underworld && ( x > 1657 ) && ( y > 496 ) && ( x < 1807 ) && ( y < 606 ) ){ worldLocation = "the Land of Sosaria"; }
			else if ( map == Map.Underworld && ( x > 1879 ) && ( y > 498 ) && ( x < 2031 ) && ( y < 605 ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.Underworld && ( x > 2115 ) && ( y > 499 ) && ( x < 2263 ) && ( y < 605 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.Underworld && ( x > 1657 ) && ( y > 641 ) && ( x < 1808 ) && ( y < 748 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.Underworld && ( x > 1883 ) && ( y > 640 ) && ( x < 2033 ) && ( y < 745 ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.Underworld && ( x > 2113 ) && ( y > 641 ) && ( x < 2266 ) && ( y < 747 ) ){ worldLocation = "the Isles of Dread"; }
			else if ( map == Map.Underworld && ( x > 1657 ) && ( y > 795 ) && ( x < 1811 ) && ( y < 898 ) ){ worldLocation = "the Serpent Island"; }
			else if ( map == Map.Underworld && ( x > 1883 ) && ( y > 794 ) && ( x < 2034 ) && ( y < 902 ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.Underworld && ( x > 2112 ) && ( y > 794 ) && ( x < 2267 ) && ( y < 898 ) ){ worldLocation = "the Isles of Dread"; }
			else if ( map == Map.Underworld && ( x > 1659 ) && ( y > 953 ) && ( x < 1809 ) && ( y < 1059 ) ){ worldLocation = "the Land of Ambrosia"; }
			else if ( map == Map.Underworld && ( x > 1881 ) && ( y > 954 ) && ( x < 2034 ) && ( y < 1059 ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.Underworld && ( x > 2113 ) && ( y > 952 ) && ( x < 2268 ) && ( y < 1056 ) ){ worldLocation = "the Savaged Empire"; }

			else if ( map == Map.Lodor ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.Sosaria ){ worldLocation = "the Land of Sosaria"; }
			else if ( map == Map.Underworld ){ worldLocation = "the Underworld"; }
			else if ( map == Map.SerpentIsland ){ worldLocation = "the Serpent Island"; }
			else if ( map == Map.IslesDread ){ worldLocation = "the Isles of Dread"; }
			else if ( map == Map.SavagedEmpire ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.Atlantis ){ worldLocation = "the World of Atlantis"; }

			if ( map == Map.SerpentIsland && reg.IsPartOf( "Sosaria Prison" ) ){ worldLocation = "the Land of Sosaria"; }
			else if ( map == Map.SerpentIsland && reg.IsPartOf( "Lodoria Prison" ) ){ worldLocation = "the Land of Lodoria"; }
			else if ( map == Map.SerpentIsland && reg.IsPartOf( "Renika Prison" ) ){ worldLocation = "the Island of Umber Veil"; }
			else if ( map == Map.SerpentIsland && reg.IsPartOf( "Kuldara Prison" ) ){ worldLocation = "the Bottle World of Kuldar"; }
			else if ( map == Map.SerpentIsland && reg.IsPartOf( "Ork Prison" ) ){ worldLocation = "the Savaged Empire"; }
			else if ( map == Map.SerpentIsland && reg.IsPartOf( "Furnace Prison" ) ){ worldLocation = "the Serpent Island"; }
			else if ( map == Map.SerpentIsland && reg.IsPartOf( "Cimmeran Prison" ) ){ worldLocation = "the Isles of Dread"; }

			return worldLocation;
		}

		public static void EnteredTheLand( Mobile from )
		{
			if ( from is PlayerMobile )
			{
				string world = GetRegionName( from.Map, from.Location );

				bool runLog = false;

				if ( world == "the Land of Lodoria" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Land of Sosaria" )
				{
					if ( from.X >= 3546 && from.Y >= 3383 && from.X <= 3590 && from.Y <= 3428 ){ /* DO NOTHING IN TIME LORD CHAMBER */ }
					else { PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				}
				else if ( world == "the Island of Umber Veil" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Land of Ambrosia" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Serpent Island" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Isles of Dread" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Savaged Empire" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Underworld" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }
				else if ( world == "the Bottle World of Kuldar" ){ PlayerSettings.SetDiscovered( from, world, true ); runLog = true; }

				if ( runLog )
					LoggingFunctions.LogRegions( from, world, "enter" );
			}
		}

		public static int GetDifficultyLevel( Point3D loc, Map map ) // THESE ARE DUNGEON DIFFICULTY LEVELS FROM 0 (NEWBIE) TO 1 (NORMAL) UP TO 5 (EPIC)
		{
			int Heat = -5;

			Region reg = Region.Find( loc, map );

			if ( map == Map.Lodor )
			{
				if ( reg.IsPartOf( "the Lodoria Sewers" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Lizardman Cave" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Ratmen Cave" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Crypt" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dungeon Wrong" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Volcanic Cave" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Terathan Keep" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Dungeon Shame" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Ice Fiend Lair" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Frozen Hells" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Dungeon Hythloth" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Mind Flayer City" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the City of Embers" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dungeon Destard" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Dungeon Despise" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Dungeon Deceit" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Dungeon Covetous" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Lodoria Catacombs" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Halls of Undermountain" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Vault of the Black Knight" ) ){ Heat = 3; } // -- IN SERPENT ISLAND
				else if ( reg.IsPartOf( "the Crypts of Dracula" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Castle of Dracula" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Stonegate Castle" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Ancient Elven Mine" ) ){ Heat = 3; }

				else if ( reg.IsPartOf( "Morgaelin's Inferno" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Zealan Tombs" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Temple of Osirus" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Argentrock Castle" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Daemon's Crag" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Hall of the Mountain King" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Depths of Carthax Lake" ) ){ Heat = 4; }

				else if ( reg.IsPartOf( "the Montor Sewers" ) ){ Heat = 0; }

				else if ( reg.IsPartOf( "Mangar's Tower" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Mangar's Chamber" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "Kylearan's Tower" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Harkyn's Castle" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Catacombs" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Lower Catacombs" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Sewers" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Cellar" ) ){ Heat = 0; }

				else if ( reg.IsPartOf( "the Sanctum of Saltmarsh" ) ){ Heat = 3; }
			}
			else if ( map == Map.Sosaria )
			{
				if ( reg.IsPartOf( "the Ancient Pyramid" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Mausoleum" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Dungeon Clues" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dardin's Pit" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Frostwall Caverns" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dungeon Doom" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dungeon Exodus" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Fires of Hell" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Frozen Dungeon" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Mines of Morinia" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Perinian Depths" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Ratmen Lair" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Dungeon of Time Awaits" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Castle Exodus" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Cave of Banished Mages" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the City of the Dead" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Dragon's Maw" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Cave of the Zuluu" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Tower of Brass" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Caverns of Poseidon" ) ){ Heat = 1; }

				else if ( reg.IsPartOf( "the Accursed Maze" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "the Chamber of Bane" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "Coldhall Depths" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "the Dark Sanctum" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "the Forgotten Tombs" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "the Magma Vaults" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "the Dark Tombs" ) ){ Heat = -1; }
				else if ( reg.IsPartOf( "the Shrouded Grave" ) ){ Heat = -1; }

				else if ( reg.IsPartOf( "the Ruins of the Black Blade" ) ){ Heat = 2; }

				else if ( reg.IsPartOf( "Steamfire Cave" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Kuldara Sewers" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Crypts of Kuldar" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "Vordo's Castle" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "Vordo's Dungeon" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "Vordo's Castle Grounds" ) ){ Heat = 3; }
			}
			else if ( map == Map.SerpentIsland )
			{
				if ( reg.IsPartOf( "the Ancient Prison" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Cave of Fire" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Cave of Souls" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Dungeon Ankh" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "Dungeon Bane" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dungeon Hate" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Dungeon Scorn" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Dungeon Torment" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "Dungeon Vile" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "Dungeon Wicked" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "Dungeon Wrath" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Flooded Temple" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Gargoyle Crypts" ) ){ Heat = 0; }
				else if ( reg.IsPartOf( "the Serpent Sanctum" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Tomb of the Fallen Wizard" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Castle of the Black Knight" ) ){ Heat = 3; }
			}
			else if ( map == Map.IslesDread )
			{
				if ( reg.IsPartOf( "the Altar of the Blood God" ) ){ Heat = 2; }
			}
			else if ( map == Map.Underworld )
			{
				if ( loc.X > 1655 && loc.Y < 1065 )
				{
					// THIS IS THE DUNGEON HOME REGION
				}
				else
				{
					if ( reg.IsPartOf( "the Glacial Scar" ) ){ Heat = 2; }
					else if ( Server.Misc.Worlds.GetRegionName( map, loc ) == "the Underworld" ){ Heat = 3; }
					else if ( reg.IsPartOf( typeof( DungeonRegion ) ) ){ Heat = 4; }
				}
			}
			else if ( map == Map.SavagedEmpire )
			{
				if ( reg.IsPartOf( "the Blood Temple" ) ){ Heat = 2; } // -- IN ISLES OF DREAD
				else if ( reg.IsPartOf( "the Tombs" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Corrupt Pass" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Crypt" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Great Pyramid" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Altar of the Dragon King" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Ice Queen Fortress" ) ){ Heat = 2; } // -- IN ISLES OF DREAD
				else if ( reg.IsPartOf( "the Dungeon of the Lich King" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Dungeon of the Mad Archmage" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Halls of Ogrimar" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Ratmen Mines" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "Dungeon Rock" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Sakkhra Tunnel" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Spider Cave" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Storm Giant Lair" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Cave of the Ancient Wyrm" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Isle of the Lich" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Castle of the Mad Archmage" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Mage Mansion" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Island of the Storm Giant" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Orc Fort" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Hedge Maze" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Pixie Cave" ) ){ Heat = 1; }
				else if ( reg.IsPartOf( "the Forgotten Halls" ) ){ Heat = 2; }
				else if ( reg.IsPartOf( "the Undersea Castle" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Tomb of Kazibal" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Catacombs of Azerok" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Azure Castle" ) ){ Heat = 3; }
				else if ( reg.IsPartOf( "the Scurvy Reef" ) ){ Heat = 2; }

				else if ( reg.IsPartOf( "the Ancient Crash Site" ) ){ Heat = 4; }
				else if ( reg.IsPartOf( "the Ancient Sky Ship" ) ){ Heat = 4; }
			}
			else if ( map == Map.Atlantis )
			{
				if ( reg.IsPartOf( "the Erase" ) ){ Heat = 0; }
				else { Heat = 4; }
			}

			return Heat;
		}

		public static bool isOrientalRegion( Mobile m )
		{
			if ( m is PlayerMobile )
				return false;

			if ( m is BaseCreature && ((BaseCreature)m).Controlled )
				return false;

			if ( m.Region.Name == "the Dojo" )
				return true;

			// DOJO IN LODOR CITY
			if ( m.Map == Map.Lodor && m.X >= 1888 && m.Y >= 2136 && m.X <= 1897 && m.Y <= 2150 )
				return true;

			// DOJO IN LODOR CITY
			if ( m.Map == Map.Lodor && m.X >= 1877 && m.Y >= 2145 && m.X <= 1891 && m.Y <= 2159 )
				return true;

			if ( m.Region.Name == "Shimazu's Dojo" )
				return true;

			return false;
		}

		public static bool NoApocalypse( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg is WantedRegion ||
			reg is SavageRegion ||
			reg is VillageRegion ||
			reg is UnderHouseRegion ||
			reg is UmbraRegion ||
			reg is TownRegion ||
			reg is StartRegion ||
			reg is SkyHomeDwelling ||
			reg is SafeRegion ||
			reg is ProtectedRegion ||
			reg is PublicRegion ||
			reg is PirateRegion ||
			reg is BardTownRegion ||
			reg is DawnRegion ||
			reg is DungeonHomeRegion ||
			reg is GargoyleRegion ||
			reg is GuardedRegion ||
			reg is HouseRegion ||
			reg is LunaRegion ||
			reg is MazeRegion ||
			reg is MoonCore  )
				return true;

			return false;
		}

		public static string GetRegionName( Map map, Point3D location )
		{
			Region reg = Region.Find( location, map );

			string regionName = reg.Name;

			if ( ( reg.IsDefault || reg.Name == null || reg.Name == "" ) )
			{
				if ( map == Map.Lodor )
				{
					if ( location.X >= 0 && location.Y >= 0 && location.X <= 5118 && location.Y <= 4092 ){ regionName = "the Land of Lodoria"; }
				}
				else if ( map == Map.Sosaria )
				{
					if ( location.X >= 0 && location.Y >= 0 && location.X <= 5118 && location.Y <= 3125 ){ regionName = "the Land of Sosaria"; }
					else if ( location.X >= 699 && location.Y >= 3129 && location.X <= 2272 && location.Y <= 4095 ){ regionName = "the Island of Umber Veil"; }
					else if ( location.X >= 5122 && location.Y >= 3036 && location.X <= 6126 && location.Y <= 4095 ){ regionName = "the Land of Ambrosia"; }
					else if ( location.X >= 6127 && location.Y >= 828 && location.X <= 7167 && location.Y <= 2743 ){ regionName = "the Bottle World of Kuldar"; }
				}
				else if ( map == Map.Underworld )
				{
					if ( location.X >= 0 && location.Y >= 0 && location.X <= 1624 && location.Y <= 1600 ){ regionName = "the Underworld"; }
				}
				else if ( map == Map.SerpentIsland )
				{
					if ( location.X >= 0 && location.Y >= 0 && location.X <= 1874 && location.Y <= 2042 ){ regionName = "the Serpent Island"; }
				}
				else if ( map == Map.IslesDread )
				{
					if ( location.X >= 0 && location.Y >= 0 && location.X <= 1430 && location.Y <= 1430 ){ regionName = "the Isles of Dread"; }
				}
				else if ( map == Map.SavagedEmpire )
				{
					if ( location.X >= 0 && location.Y >= 0 && location.X <= 1168 && location.Y <= 1802 ){ regionName = "the Savaged Empire"; }
				}
			}

			return regionName;
		}

		public static bool IsMainRegion( string region )
		{
			if ( 	region == "the Land of Lodoria" ||
					region == "the Land of Sosaria" ||
					region == "the Island of Umber Veil" ||
					region == "the Land of Ambrosia" ||
					region == "the Bottle World of Kuldar" ||
					region == "the Underworld" ||
					region == "the Serpent Island" ||
					region == "the Isles of Dread" ||
					region == "the Savaged Empire" )
				return true;

			return false;
		}

		public static string GetMyRegion( Map map, Point3D location )
		{
			Region reg = Region.Find( location, map );
			return reg.Name;
		}

		public static string GetMyMapString( Map map )
		{
			string world = "Sosaria";

			if ( map == Map.Lodor ){ world = "Lodor"; }
			else if ( map == Map.Underworld ){ world = "Underworld"; }
			else if ( map == Map.SerpentIsland ){ world = "SerpentIsland"; }
			else if ( map == Map.IslesDread ){ world = "IslesDread"; }
			else if ( map == Map.SavagedEmpire ){ world = "SavagedEmpire"; }

			return world;
		}

		public static Map GetMyDefaultMap( string world )
		{
			Map map = Map.Sosaria;

			if ( world == "the Town of Skara Brae" ){ map = Map.Lodor; }
			else if ( world == "the Land of Lodoria" ){ map = Map.Lodor; }
			else if ( world == "the Serpent Island" ){ map = Map.SerpentIsland; }
			else if ( world == "the Isles of Dread" ){ map = Map.IslesDread; }
			else if ( world == "the Savaged Empire" ){ map = Map.SavagedEmpire; }
			else if ( world == "the Underworld" ){ map = Map.Underworld; }
			/// THE REST ARE ON SOSARIA ///

			return map;
		}

		public static Map GetMyDefaultTreasureMap( string world )
		{
			Map map = Map.Sosaria;

			if ( world == "the Land of Lodoria" ){ map = Map.Lodor; }
			else if ( world == "the Serpent Island" ){ map = Map.SerpentIsland; }
			else if ( world == "the Isles of Dread" ){ map = Map.IslesDread; }
			else if ( world == "the Savaged Empire" ){ map = Map.SavagedEmpire; }
			else if ( world == "the Underworld" ){ map = Map.Underworld; }
			/// THE REST ARE ON SOSARIA ///

			return map;
		}

		public static bool IsCrypt( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg.IsPartOf( "the Crypt" ) ||
				reg.IsPartOf( "the Lodoria Catacombs" ) ||
				reg.IsPartOf( "the Crypts of Dracula" ) ||
				reg.IsPartOf( "the Castle of Dracula" ) ||
				reg.IsPartOf( "the Graveyard" ) ||
				reg.IsPartOf( "Ravendark Woods" ) ||
				reg.IsPartOf( "the Island of Dracula" ) ||
				reg.IsPartOf( "the Village of Ravendark" ) ||
				reg.IsPartOf( "the Black Magic Guild" ) ||
				reg.IsPartOf( "the Lodoria Cemetery" ) ||
				reg.IsPartOf( "the Lost Graveyard" ) ||
				reg.IsPartOf( "the Mausoleum" ) ||
				reg.IsPartOf( "the Dark Tombs" ) ||
				reg.IsPartOf( "the Kuldar Cemetery" ) ||
				reg.IsPartOf( "the Undercity of Umbra" ) ||
				reg.IsPartOf( "the Cave of Souls" ) ||
				reg.IsPartOf( "the Crypts of Kuldar" ) ||
				reg.IsPartOf( "the Zealan Graveyard" ) ||
				reg.IsPartOf( "Nightwood Fort" ) ||
				reg.IsPartOf( "the Zealan Tombs" ) ||
				reg.IsPartOf( "the Tombs" ) ||
				reg.IsPartOf( "the Dungeon of the Lich King" ) ||
				reg.IsPartOf( "the Tomb of Kazibal" ) ||
				reg.IsPartOf( "the Catacombs of Azerok" ) )
				return true;

			return false;
		}

		public static bool IsSeaDungeon( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg.IsPartOf( "the Depths of Carthax Lake" ) ||
			reg.IsPartOf( "the Storm Giant Lair" ) ||
			reg.IsPartOf( "the Island of the Storm Giant" ) ||
			reg.IsPartOf( "the Undersea Castle" ) ||
			reg.IsPartOf( "the Scurvy Reef" ) ||
			reg.IsPartOf( "the Caverns of Poseidon" ) ||
			reg.IsPartOf( "the Cavern of the Deep Ones" ) ||
			Worlds.GetMyWorld( map, p, p.X, p.Y ) == "the World of Atlantis" ||
			reg.IsPartOf( "the Flooded Temple" ) )
				return true;

			return false;
		}

		public static bool IsSeaTown( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg.IsPartOf( "Anchor Rock Docks" ) ||
			reg.IsPartOf( "Kraken Reef Docks" ) ||
			reg.IsPartOf( "Savage Sea Docks" ) ||
			reg.IsPartOf( "the Lankhmar Lighthouse" ) ||
			reg.IsPartOf( "Serpent Sail Docks" ) ||
			reg.IsPartOf( "the Forgotten Lighthouse" ) ||
			reg.IsPartOf( "the Port" ) )
				return true;

			return false;
		}

		public static bool IsFireDungeon( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg.IsPartOf( "the Fires of Hell" ) ||
			reg.IsPartOf( "Morgaelin's Inferno" ) ||
			reg.IsPartOf( "the City of Embers" ) ||
			reg.IsPartOf( "the Cave of Fire" ) ||
			reg.IsPartOf( "Steamfire Cave" ) ||
			reg.IsPartOf( "the Volcanic Cave" ) )
				return true;

			return false;
		}

		public static bool IsOnSpaceship( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg.IsPartOf( "the Ancient Crash Site" ) ||
			reg.IsPartOf( "the Ancient Sky Ship" ) )
				return true;

			return false;
		}

		public static bool IsIceDungeon( Point3D p, Map map )
		{
			Region reg = Region.Find( p, map );

			if ( reg.IsPartOf( "the Glacial Scar" ) ||
			reg.IsPartOf( "the Frozen Hells" ) ||
			reg.IsPartOf( "the Ratmen Cave" ) ||
			reg.IsPartOf( "the Ice Fiend Lair" ) ||
			reg.IsPartOf( "the Ice Queen Fortress" ) ||
			reg.IsPartOf( "the Frozen Dungeon" ) ||
			reg.IsPartOf( "Frostwall Caverns" ) )
				return true;

			return false;
		}

		public static bool IsExploringSeaAreas( Mobile m )
		{
			if ( IsOnBoat( m ) == true && BoatToCloseToTown( m ) == false )
				return true;

			Region reg = Region.Find( m.Location, m.Map );

			if ( reg.IsPartOf( "the Caverns of Poseidon" ) )
				return true;

			if ( reg.IsPartOf( "the Storm Giant Lair" ) )
				return true;

			if ( reg.IsPartOf( "the Cavern of the Deep Ones" ) )
				return true;

			if ( reg.IsPartOf( "the Island of the Storm Giant" ) )
				return true;

			if ( reg.IsPartOf( "the Island of Poseidon" ) )
				return true;

			if ( reg.IsPartOf( "the Buccaneer's Den" ) )
				return true;

			if ( reg.IsPartOf( "the Undersea Castle" ) )
				return true;

			if ( reg.IsPartOf( "the Depths of Carthax Lake" ) )
				return true;

			if ( reg.IsPartOf( "the Scurvy Reef" ) )
				return true;

			if ( reg.IsPartOf( "the Flooded Temple" ) )
				return true;

			if ( reg.IsPartOf( typeof( PirateRegion ) ) )
				return true;

			if ( Worlds.GetMyWorld( m.Map, m.Location, m.X, m.Y ) == "the World of Atlantis" )
				return true;

			return false;
		}

		public static bool IsOnBoat( Mobile m )
		{
			if ( m.Z > -1 || m.Z < -3 )
				return false;

			int KeepSearching = 0;
			bool IsOnShip = false;

			foreach ( Item boatman in m.GetItemsInRange( 15 ) )
			{
				if ( KeepSearching != 1 )
				{
					if ( boatman is TillerMan )
					{
						IsOnShip = true;
						if ( IsOnShip == true ){ KeepSearching = 1; }
					}
				}
			}
			return IsOnShip;
		}

		public static bool ItemOnBoat( Item i )
		{
			if ( i.Z > -1 || i.Z < -3 )
				return false;

			int KeepSearching = 0;
			bool IsOnShip = false;

			foreach ( Item boatman in i.GetItemsInRange( 15 ) )
			{
				if ( KeepSearching != 1 )
				{
					if ( boatman is TillerMan )
					{
						IsOnShip = true;
						if ( IsOnShip == true ){ KeepSearching = 1; }
					}
				}
			}
			return IsOnShip;
		}

		public static bool BoatToCloseToTown( Mobile m )
		{
			foreach ( Mobile landlover in m.GetMobilesInRange( 50 ) )
			{
				if ( landlover is BaseVendor || landlover is BasePerson || landlover is BaseNPC )
				{
					return true;
				}
			}
			return false;
		}

		public static bool RegionAllowedTeleport( Map map, Point3D location, int x, int y )
		{
			string world = Worlds.GetMyWorld( map, location, x, y );
			Region reg = Region.Find( location, map );

			if ( reg.IsPartOf( typeof( DungeonRegion ) ) )
				return false;

			if ( world == "the Bottle World of Kuldar" )
				return false;

			if ( world == "the Time Lord Chamber" )
				return false;

			if ( world == "the Underworld" )
				return false;

			if ( world == "the Land of Ambrosia" )
				return false;

			if ( world == "the Town of Skara Brae" )
				return false;

			if ( reg.IsPartOf( "the Moon's Core" ) || reg.IsPartOf( "the Core of the Moon" ) || reg.IsPartOf( "Moonlight Cavern" ) )
				return false;

			if ( reg.IsPartOf( "the Camping Tent" ) )
				return false;

			if ( reg.IsPartOf( "the Dungeon Room" ) )
				return false;

			if ( reg.IsPartOf( "the Lyceum" ) )
				return false;

			if ( reg.IsPartOf( "the Island of Stonegate" ) )
				return false;

			if ( reg.IsPartOf( "the Painting of the Glade" ) )
				return false;

			if ( reg.IsPartOf( "the Island of the Black Knight" ) )
				return false;

			if ( reg.IsPartOf( "the Castle of the Black Knight" ) )
				return false;

			if ( reg.IsPartOf( "the Castle of the Black Knight" ) )
				return false;

			if ( reg.IsPartOf( typeof( GargoyleRegion ) ) )
				return false;

			if ( reg.IsPartOf( typeof( MazeRegion ) ) )
				return false;

			if ( reg.IsPartOf( typeof( PublicRegion ) ) )
				return false;

			if ( reg.IsPartOf( "the Island of Poseidon" ) )
				return false;

			if ( reg.IsPartOf( "the Village of Ravendark" ) )
				return false;

			if ( reg.IsPartOf( typeof( BargeDeadRegion ) ) )
				return false;

			return true;
		}

		public static bool AllowEscape( Mobile m, Map map, Point3D location, int x, int y )
		{
			bool canLeave = true;
			int mX = 0;
			int mY = 0;
			int mZ = 0;
			Map mWorld = null;

			string sPublicDoor = ((PlayerMobile)m).CharacterPublicDoor;
			if ( sPublicDoor != null )
			{
				if ( sPublicDoor.Length > 0 )
				{
					string[] sPublicDoors = sPublicDoor.Split('#');
					int nEntry = 1;
					foreach (string exits in sPublicDoors)
					{
						if ( nEntry == 1 ){ mX = Convert.ToInt32(exits); }
						else if ( nEntry == 2 ){ mY = Convert.ToInt32(exits); }
						else if ( nEntry == 3 ){ mZ = Convert.ToInt32(exits); }
						else if ( nEntry == 4 ){ try { mWorld = Map.Parse( exits ); } catch{} if ( mWorld == null ){ mWorld = Map.Sosaria; } }
						nEntry++;
					}

					location = new Point3D( mX, mY, mZ );
					map = mWorld;
					x = mX;
					y = mY;
				}
			}

			string world = Worlds.GetMyWorld( map, location, x, y );
			Region reg = Region.Find( location, map );

			if ( world == "the Bottle World of Kuldar" && PlayerSettings.GetDiscovered( m, "the Bottle World of Kuldar" ) )
				canLeave = false;

			if ( world == "the Town of Skara Brae" )
				canLeave = false;

			if ( reg.IsPartOf( "the Camping Tent" ) )
				canLeave = false;

			if ( reg.IsPartOf( "the Dungeon Room" ) )
				canLeave = false;

			if ( reg.IsPartOf( "the Lyceum" ) )
				canLeave = false;

			if ( reg.IsPartOf( "the Chasm" ) )
				canLeave = false;

			if ( reg.IsPartOf( "the Ship's Lower Deck" ) )
				canLeave = false;

			return canLeave;
		}

		public static bool IsAllowedSpell( Mobile m, ISpell s )
		{
			if ( m.Region.IsPartOf( "the Ship's Lower Deck" ) )
				return false;

			if (	s is GateTravelSpell ||
						s is MushroomGatewaySpell ||
						s is UndeadGraveyardGatewaySpell ||
						s is HellsGateSpell ||
						s is AstralTravel ||
						s is ResearchEtherealTravel ||
						s is NaturesPassageSpell ||
						s is RecallSpell ||
						s is TravelSpell ||
						s is Elemental_Void_Spell ||
						s is Elemental_Gate_Spell ||
						s is SacredJourneySpell )
			{
				return true;
			}

			return false;
		}

		public static bool RegionAllowedRecall( Map map, Point3D location, int x, int y )
		{
			string world = Worlds.GetMyWorld( map, location, x, y );
			Region reg = Region.Find( location, map );

			if ( world == "the Town of Skara Brae" )
				return false;

			if ( reg.IsPartOf( "Moonlight Cavern" ) )
				return false;

			if ( world == "the Bottle World of Kuldar" )
				return false;

			if ( world == "the Land of Ambrosia" )
				return false;

			if ( reg.IsPartOf( "the Village of Ravendark" ) )
				return false;

			return true;
		}

		public static bool IsPlayerInTheLand( Map map, Point3D location, int x, int y )
		{
			string world = Worlds.GetMyWorld( map, location, x, y );
			Region reg = Region.Find( location, map );

			if ( world == "the Moon of Luna" && x >= 5801 && y >= 2716 && x <= 6125 && y <= 3034 )
				return true;
			else if ( world == "the Land of Sosaria" && x >= 0 && y >= 0 && x <= 5119 && y <= 3127 )
				return true;
			else if ( world == "the Land of Lodoria" && x >= 0 && y >= 0 && x <= 5120 && y <= 4095 )
				return true;
			else if ( world == "the Serpent Island" && x >= 0 && y >= 0 && x <= 1870 && y <= 2047 )
				return true;
			else if ( world == "the Isles of Dread" && x >= 0 && y >= 0 && x <= 1447 && y <= 1447 )
				return true;
			else if ( world == "the Savaged Empire" && x >= 136 && y >= 8 && x <= 1160 && y <= 1792 )
				return true;
			else if ( world == "the Land of Ambrosia" && x >= 5122 && y >= 3036 && x <= 6126 && y <= 4095 )
				return true;
			else if ( world == "the Island of Umber Veil" && x >= 699 && y >= 3129 && x <= 2272 && y <= 4095 )
				return true;
			else if ( world == "the Bottle World of Kuldar" && x >= 6127 && y >= 828 && x <= 7168 && y <= 2742 )
				return true;
			else if ( world == "the Underworld" && x >= 0 && y >= 0 && x <= 1581 && y <= 1599 )
				return true;

			return false;
		}

		public static bool PlayersLeftInRegion( Mobile from, Region region )
		{
			bool occupied = false;

			foreach ( NetState state in NetState.Instances )
			{
				Mobile m = state.Mobile;

				if ( m != null /* && m.AccessLevel < AccessLevel.GameMaster */ && m != from && m.Region == region )
				{
					occupied = true;
				}
			}

			return occupied;
		}

		public static void MoveToRandomDungeon( Mobile m )
		{
			Point3D loc = new Point3D(0, 0, 0);
			Map map = Map.Sosaria;

			switch ( Utility.RandomMinMax( 0, 69 ) )
			{
				case 0: loc = new Point3D(5773, 2804, 0); map = Map.Lodor; break; // the Crypts of Dracula
				case 1: loc = new Point3D(5353, 91, 15); map = Map.Lodor; break; // the Mind Flayer City
				case 2: loc = new Point3D(5789, 2558, -30); map = Map.Lodor; break; // Dungeon Covetous
				case 3: loc = new Point3D(5308, 680, 0); map = Map.Lodor; break; // Dungeon Deceit
				case 4: loc = new Point3D(5185, 2442, 6); map = Map.Lodor; break; // Dungeon Despise
				case 5: loc = new Point3D(5321, 799, 0); map = Map.Lodor; break; // Dungeon Destard
				case 6: loc = new Point3D(5869, 1443, 0); map = Map.Lodor; break; // the City of Embers
				case 7: loc = new Point3D(6038, 200, 22); map = Map.Lodor; break; // Dungeon Hythloth
				case 8: loc = new Point3D(5728, 155, 1); map = Map.Lodor; break; // the Frozen Hells
				case 9: loc = new Point3D(5783, 23, 0); map = Map.Lodor; break; // Dungeon Shame
				case 10: loc = new Point3D(5174, 1703, 2); map = Map.Lodor; break; // Terathan Keep
				case 11: loc = new Point3D(5247, 436, 0); map = Map.Lodor; break; // the Halls of Undermountain
				case 12: loc = new Point3D(5859, 3427, 0); map = Map.Lodor; break; // the Volcanic Cave
				case 13: loc = new Point3D(5443, 1398, 0); map = Map.Lodor; break; // Dungeon Wrong
				case 14: loc = new Point3D(5854, 1756, 0); map = Map.Sosaria; break; // the Caverns of Poseidon
				case 15: loc = new Point3D(6387, 3754, -2); map = Map.Sosaria; break; // the Tower of Brass
				case 16: loc = new Point3D(3943, 3370, 0); map = Map.Sosaria; break; // the Mausoleum
				case 17: loc = new Point3D(6384, 490, 0); map = Map.Sosaria; break; // Vordo's Dungeon
				case 18: loc = new Point3D(7028, 3824, 5); map = Map.Sosaria; break; // the Cave of the Zuluu
				case 19: loc = new Point3D(4629, 3599, 0); map = Map.Sosaria; break; // the Dragon's Maw
				case 20: loc = new Point3D(5354, 923, 0); map = Map.Sosaria; break; // the Ancient Pyramid
				case 21: loc = new Point3D(5965, 636, 0); map = Map.Sosaria; break; // Dungeon Exodus
				case 22: loc = new Point3D(262, 3380, 0); map = Map.Sosaria; break; // the Cave of Banished Mages
				case 23: loc = new Point3D(5981, 2154, 0); map = Map.Sosaria; break; // Dungeon Clues
				case 24: loc = new Point3D(5550, 393, 0); map = Map.Sosaria; break; // Dardin's Pit
				case 25: loc = new Point3D(5259, 262, 0); map = Map.Sosaria; break; // Dungeon Doom
				case 26: loc = new Point3D(5526, 1228, 0); map = Map.Sosaria; break; // the Fires of Hell
				case 27: loc = new Point3D(5587, 1602, 0); map = Map.Sosaria; break; // the Mines of Morinia
				case 28: loc = new Point3D(5995, 423, 0); map = Map.Sosaria; break; // the Perinian Depths
				case 29: loc = new Point3D(5638, 821, 0); map = Map.Sosaria; break; // the Dungeon of Time Awaits
				case 30: loc = new Point3D(1955, 523, 0); map = Map.SerpentIsland; break; // the Ancient Prison
				case 31: loc = new Point3D(2090, 863, 0); map = Map.SerpentIsland; break; // the Cave of Fire
				case 32: loc = new Point3D(2440, 53, 2); map = Map.SerpentIsland; break; // the Cave of Souls
				case 33: loc = new Point3D(2032, 76, 0); map = Map.SerpentIsland; break; // Dungeon Ankh
				case 34: loc = new Point3D(1947, 216, 0); map = Map.SerpentIsland; break; // Dungeon Bane
				case 35: loc = new Point3D(2189, 425, 0); map = Map.SerpentIsland; break; // Dungeon Hate
				case 36: loc = new Point3D(2221, 816, 0); map = Map.SerpentIsland; break; // Dungeon Scorn
				case 37: loc = new Point3D(1957, 710, 0); map = Map.SerpentIsland; break; // Dungeon Torment
				case 38: loc = new Point3D(2361, 403, 0); map = Map.SerpentIsland; break; // Dungeon Vile
				case 39: loc = new Point3D(2160, 173, 2); map = Map.SerpentIsland; break; // Dungeon Wicked
				case 40: loc = new Point3D(2311, 912, 2); map = Map.SerpentIsland; break; // Dungeon Wrath
				case 41: loc = new Point3D(2459, 880, 0); map = Map.SerpentIsland; break; // the Flooded Temple
				case 42: loc = new Point3D(2064, 509, 0); map = Map.SerpentIsland; break; // the Gargoyle Crypts
				case 43: loc = new Point3D(2457, 506, 0); map = Map.SerpentIsland; break; // the Serpent Sanctum
				case 44: loc = new Point3D(2327, 183, 2); map = Map.SerpentIsland; break; // the Tomb of the Fallen Wizard
				case 45: loc = new Point3D(729, 2635, -28); map = Map.SavagedEmpire; break; // the Blood Temple
				case 46: loc = new Point3D(774, 1984, -28); map = Map.SavagedEmpire; break; // the Dungeon of the Mad Archmage
				case 47: loc = new Point3D(51, 2619, -28); map = Map.SavagedEmpire; break; // the Tombs
				case 48: loc = new Point3D(342, 2296, -1); map = Map.SavagedEmpire; break; // the Dungeon of the Lich King
				case 49: loc = new Point3D(323, 2836, 0); map = Map.SavagedEmpire; break; // the Ice Queen Fortress
				case 50: loc = new Point3D(1143, 2403, -28); map = Map.SavagedEmpire; break; // the Halls of Ogrimar
				case 51: loc = new Point3D(692, 2319, -27); map = Map.SavagedEmpire; break; // Dungeon Rock
				case 52: loc = new Point3D(100, 3389, 0); map = Map.SavagedEmpire; break; // Forgotten Halls
				case 53: loc = new Point3D(366, 3886, 0); map = Map.SavagedEmpire; break; // the Scurvy Reef
				case 54: loc = new Point3D(647, 3860, 39); map = Map.SavagedEmpire; break; // the Undersea Castle
				case 55: loc = new Point3D(231, 3650, 25); map = Map.SavagedEmpire; break; // the Azure Castle
				case 56: loc = new Point3D(436, 3311, 20); map = Map.SavagedEmpire; break; // the Tomb of Kazibal
				case 57: loc = new Point3D(670, 3357, 20); map = Map.SavagedEmpire; break; // the Catacombs of Azerok
				case 58: loc = new Point3D(6035, 2574, 0); map = Map.Lodor; break; // Stonegate Castle
				case 59: loc = new Point3D(1968, 1363, 61); map = Map.Underworld; break; // the Glacial Scar
				case 60: loc = new Point3D(6142, 3660, -20); map = Map.Lodor; break; // the Temple of Osirus
				case 61: loc = new Point3D(1851, 1233, -42); map = Map.Underworld; break; // the Stygian Abyss
				case 62: loc = new Point3D(6413, 2004, -40); map = Map.Lodor; break; // the Daemon's Crag
				case 63: loc = new Point3D(7003, 2437, -11); map = Map.Lodor; break; // the Zealan Tombs
				case 64: loc = new Point3D(6368, 968, 25); map = Map.Lodor; break; // the Hall of the Mountain King
				case 65: loc = new Point3D(6826, 1123, -92); map = Map.Lodor; break; // Morgaelin's Inferno
				case 66: loc = new Point3D(5950, 1654, -5); map = Map.Lodor; break; // the Depths of Carthax Lake
				case 67: loc = new Point3D(5989, 484, 1); map = Map.Lodor; break; // Argentrock Castle
				case 68: loc = new Point3D(6021, 1968, 0); map = Map.Lodor; break; // the Sanctum of Saltmarsh
				case 69: loc = new Point3D(1125, 3684, 0); map = Map.Lodor; break; // the Ancient Sky Ship
			}

			if ( m is PlayerMobile )
			{
				Server.Mobiles.BaseCreature.TeleportPets( m, loc, map );
				m.MoveToWorld( loc, map );
			}
			else if ( m is BaseCreature )
			{
				m.MoveToWorld( loc, map );
			}
		}

		public static void MoveToRandomOcean( Mobile m )
		{
			Point3D loc = new Point3D(20, 20, 0);
			Map map = Map.Sosaria;
			string world = "the Land of Sosaria";

			switch ( Utility.RandomMinMax( 0, 8 ) )
			{
				case 0: world = "the Bottle World of Kuldar";	map = Map.Sosaria;			break;
				case 1: world = "the Land of Ambrosia";			map = Map.Sosaria;			break;
				case 2: world = "the Island of Umber Veil";		map = Map.Sosaria;			break;
				case 3: world = "the Land of Lodoria";			map = Map.Lodor;			break;
				case 4: world = "the Underworld";				map = Map.Underworld;		break;
				case 5: world = "the Serpent Island";			map = Map.SerpentIsland;	break;
				case 6: world = "the Isles of Dread";			map = Map.IslesDread;		break;
				case 7: world = "the Savaged Empire";			map = Map.SavagedEmpire;	break;
				case 8: world = "the Land of Sosaria";			map = Map.Sosaria;			break;
			}

			loc = GetRandomLocation( world, "ocean" );

			if ( m is PlayerMobile )
			{
				Server.Mobiles.BaseCreature.TeleportPets( m, loc, map );
				m.MoveToWorld( loc, map );
			}
			else if ( m is BaseCreature )
			{
				m.MoveToWorld( loc, map );
			}
		}

		public static Point3D GetRandomDungeonSpot( Map map )
		{
			Point3D loc = new Point3D(0, 0, 0);
			int aCount = 0;
			ArrayList targets = new ArrayList();
			foreach ( Item target in World.Items.Values )
			{
				if ( target is DungeonChest || target is DungeonChestSpawner && target.Map == map && Server.Misc.Worlds.GetDifficultyLevel( target.Location, target.Map ) > 0 )
				{
					Region reg = Region.Find( target.Location, target.Map );
					if ( reg.IsPartOf( typeof( DungeonRegion ) ) )
					{
						targets.Add( target );
						aCount++;
					}
				}
			}
			aCount = Utility.RandomMinMax( 1, aCount );
			int xCount = 0;
			for ( int i = 0; i < targets.Count; ++i )
			{
				xCount++;

				if ( xCount == aCount )
				{
					Item finding = ( Item )targets[ i ];
					loc = finding.Location;
				}
			}
			return loc;
		}

        public static string GetAreaEntrance( string zone, Map map )
        {
			// THIS RETURNS THE COORDINATES AND MAP OF THE DUNGEON ENTRANCE

			Point3D loc = new Point3D(0, 0, 0);

			if ( zone == "the City of the Dead" && map == Map.Sosaria ){ loc = new Point3D(5828, 3263, 0); }
			else if ( zone == "the Mausoleum" && map == Map.Sosaria ){ loc = new Point3D(1529, 3599, 0); }
			else if ( zone == "the Valley of Dark Druids" && map == Map.Sosaria ){ loc = new Point3D(6763, 1423, 2); }
			else if ( zone == "Vordo's Castle" && map == Map.Sosaria ){ loc = new Point3D(6708, 1729, 25); }
			else if ( zone == "Vordo's Dungeon" && map == Map.Sosaria ){ loc = new Point3D(6708, 1729, 25); }
			else if ( zone == "the Crypts of Kuldar" && map == Map.Sosaria ){ loc = new Point3D(6668, 1568, 10); }
			else if ( zone == "the Kuldara Sewers" && map == Map.Sosaria ){ loc = new Point3D(6790, 1745, 24); }
			else if ( zone == "the Ancient Pyramid" && map == Map.Sosaria ){ loc = new Point3D(1162, 472, 0); }
			else if ( zone == "Dungeon Exodus" && map == Map.Sosaria ){ loc = new Point3D(877, 2702, 0); }
			else if ( zone == "the Cave of Banished Mages" && map == Map.Sosaria ){ loc = new Point3D(3798, 1879, 2); }
			else if ( zone == "Dungeon Clues" && map == Map.Sosaria ){ loc = new Point3D(3760, 2038, 0); }
			else if ( zone == "Dardin's Pit" && map == Map.Sosaria ){ loc = new Point3D(3006, 446, 0); }
			else if ( zone == "Dungeon Doom" && map == Map.Sosaria ){ loc = new Point3D(1628, 2561, 0); }
			else if ( zone == "the Fires of Hell" && map == Map.Sosaria ){ loc = new Point3D(3345, 1647, 0); }
			else if ( zone == "the Mines of Morinia" && map == Map.Sosaria ){ loc = new Point3D(1022, 1369, 2); }
			else if ( zone == "the Perinian Depths" && map == Map.Sosaria ){ loc = new Point3D(3619, 456, 0); }
			else if ( zone == "the Dungeon of Time Awaits" && map == Map.Sosaria ){ loc = new Point3D(3831, 1494, 0); }
			else if ( zone == "the Pirate Cave" && map == Map.Sosaria ){ loc = new Point3D(1842, 2211, 0); }
			else if ( zone == "the Dragon's Maw" && map == Map.Sosaria ){ loc = new Point3D(5315, 3430, 2); }
			else if ( zone == "the Cave of the Zuluu" && map == Map.Sosaria ){ loc = new Point3D(5901, 3999, 0); }
			else if ( zone == "the Ratmen Lair" && map == Map.Sosaria ){ loc = new Point3D(1303, 1458, 0); }
			else if ( zone == "the Caverns of Poseidon" && map == Map.Sosaria ){ loc = new Point3D(198, 2295, 12); }
			else if ( zone == "the Tower of Brass" && map == Map.Sosaria ){ loc = new Point3D(1593, 3376, 15); }
			else if ( zone == "the Forgotten Halls" && map == Map.Sosaria ){ loc = new Point3D(3015, 944, 0); }

			else if ( zone == "the Vault of the Black Knight" && map == Map.Lodor ){ loc = new Point3D(1581, 202, 0); map = Map.SerpentIsland; }
			else if ( zone == "the Undersea Pass" && map == Map.Lodor ){ loc = new Point3D(1179, 1931, 0); }
			else if ( zone == "the Castle of Dracula" && map == Map.Lodor ){ loc = new Point3D(466, 3794, 0); }
			else if ( zone == "the Crypts of Dracula" && map == Map.Lodor ){ loc = new Point3D(466, 3794, 0); }
			else if ( zone == "the Lodoria Catacombs" && map == Map.Lodor ){ loc = new Point3D(1869, 2378, 0); }
			else if ( zone == "Dungeon Covetous" && map == Map.Lodor ){ loc = new Point3D(4019, 2436, 2); }
			else if ( zone == "Dungeon Deceit" && map == Map.Lodor ){ loc = new Point3D(2523, 757, 1); }
			else if ( zone == "Dungeon Despise" && map == Map.Lodor ){ loc = new Point3D(1278, 1852, 0); }
			else if ( zone == "Dungeon Destard" && map == Map.Lodor ){ loc = new Point3D(749, 630, 0); }
			else if ( zone == "the City of Embers" && map == Map.Lodor ){ loc = new Point3D(3196, 3318, 0); }
			else if ( zone == "Dungeon Hythloth" && map == Map.Lodor ){ loc = new Point3D(1634, 2805, 0); }
			else if ( zone == "the Frozen Hells" && map == Map.Lodor ){ loc = new Point3D(3769, 1092, 0); }
			else if ( zone == "the Ice Fiend Lair" && map == Map.Lodor ){ loc = new Point3D(3769, 1092, 0); }
			else if ( zone == "the Halls of Undermountain" && map == Map.Lodor ){ loc = new Point3D(959, 2669, 5); }
			else if ( zone == "Dungeon Shame" && map == Map.Lodor ){ loc = new Point3D(1405, 2338, 0); }
			else if ( zone == "Terathan Keep" && map == Map.Lodor ){ loc = new Point3D(624, 2403, 2); }
			else if ( zone == "the Volcanic Cave" && map == Map.Lodor ){ loc = new Point3D(3105, 3594, 0); }
			else if ( zone == "Dungeon Wrong" && map == Map.Lodor ){ loc = new Point3D(2252, 854, 1); }
			else if ( zone == "Stonegate Castle" && map == Map.Lodor ){ loc = new Point3D(1355, 404, 0); }
			else if ( zone == "the Ancient Elven Mine" && map == Map.Lodor ){ loc = new Point3D(1179, 1931, 0); }

			else if ( zone == "Dungeon of the Mad Archmage" && map == Map.SavagedEmpire ){ loc = new Point3D(464, 851, -60); }
			else if ( zone == "Dungeon of the Lich King" && map == Map.SavagedEmpire ){ loc = new Point3D(922, 1772, 26); }
			else if ( zone == "the Halls of Ogrimar" && map == Map.SavagedEmpire ){ loc = new Point3D(1107, 1380, 17); }
			else if ( zone == "the Ratmen Mines" && map == Map.SavagedEmpire ){ loc = new Point3D(157, 1369, 32); }
			else if ( zone == "Dungeon Rock" && map == Map.SavagedEmpire ){ loc = new Point3D(1092, 1038, 0); }
			else if ( zone == "the Storm Giant Lair" && map == Map.SavagedEmpire ){ loc = new Point3D(283, 466, 14); }
			else if ( zone == "the Corrupt Pass" && map == Map.SavagedEmpire ){ loc = new Point3D(155, 1125, 60); }
			else if ( zone == "the Tombs" && map == Map.SavagedEmpire ){ loc = new Point3D(222, 1361, 0); }
			else if ( zone == "the Undersea Castle" && map == Map.SavagedEmpire ){ loc = new Point3D(283, 409, 20); }
			else if ( zone == "the Azure Castle" && map == Map.SavagedEmpire ){ loc = new Point3D(774, 612, 15); }
			else if ( zone == "the Tomb of Kazibal" && map == Map.SavagedEmpire ){ loc = new Point3D(368, 298, 57); }
			else if ( zone == "the Catacombs of Azerok" && map == Map.SavagedEmpire ){ loc = new Point3D(1056, 424, 38); }

			else if ( zone == "the Ancient Prison" && map == Map.SerpentIsland ){ loc = new Point3D(748, 846, 1); }
			else if ( zone == "the Cave of Fire" && map == Map.SerpentIsland ){ loc = new Point3D(561, 1143, 0); }
			else if ( zone == "the Cave of Souls" && map == Map.SerpentIsland ){ loc = new Point3D(121, 1475, 0); }
			else if ( zone == "Dungeon Ankh" && map == Map.SerpentIsland ){ loc = new Point3D(465, 1435, 2); }
			else if ( zone == "Dungeon Bane" && map == Map.SerpentIsland ){ loc = new Point3D(310, 761, 2); }
			else if ( zone == "Dungeon Hate" && map == Map.SerpentIsland ){ loc = new Point3D(1459, 1220, 0); }
			else if ( zone == "Dungeon Scorn" && map == Map.SerpentIsland ){ loc = new Point3D(1463, 873, 2); }
			else if ( zone == "Dungeon Torment" && map == Map.SerpentIsland ){ loc = new Point3D(1690, 1225, 0); }
			else if ( zone == "Dungeon Vile" && map == Map.SerpentIsland ){ loc = new Point3D(1554, 991, 2); }
			else if ( zone == "Dungeon Wicked" && map == Map.SerpentIsland ){ loc = new Point3D(733, 260, 0); }
			else if ( zone == "Dungeon Wrath" && map == Map.SerpentIsland ){ loc = new Point3D(1803, 918, 0); }
			else if ( zone == "the Flooded Temple" && map == Map.SerpentIsland ){ loc = new Point3D(1069, 952, 2); }
			else if ( zone == "the Gargoyle Crypts" && map == Map.SerpentIsland ){ loc = new Point3D(1267, 936, 0); }
			else if ( zone == "the Serpent Sanctum" && map == Map.SerpentIsland ){ loc = new Point3D(1093, 1609, 0); }
			else if ( zone == "the Tomb of the Fallen Wizard" && map == Map.SerpentIsland ){ loc = new Point3D(1056, 1338, 0); }

			else if ( zone == "the Blood Temple" && map == Map.SavagedEmpire ){ loc = new Point3D(1258, 1231, 0); map = Map.IslesDread; }
			else if ( zone == "the Ice Queen Fortress" && map == Map.SavagedEmpire ){ loc = new Point3D(319, 324, 5); map = Map.IslesDread; }
			else if ( zone == "the Scurvy Reef" && map == Map.SavagedEmpire ){ loc = new Point3D(713, 493, 1); map = Map.IslesDread; }
			else if ( zone == "the Glacial Scar" && map == Map.Underworld ){ loc = new Point3D(238, 171, 0); map = Map.IslesDread; }
			else if ( zone == "the Temple of Osirus" && map == Map.Lodor ){ loc = new Point3D(601, 819, 20); map = Map.IslesDread; }
			else if ( zone == "the Sanctum of Saltmarsh" && map == Map.Lodor ){ loc = new Point3D(926, 874, 0); map = Map.IslesDread; }

			else if ( zone == "Morgaelin's Inferno" && map == Map.Lodor ){ loc = new Point3D(1459, 100, 0); map = Map.Underworld; }
			else if ( zone == "the Zealan Tombs" && map == Map.Lodor ){ loc = new Point3D(1094, 1229, 0); map = Map.Underworld; }
			else if ( zone == "Argentrock Castle" && map == Map.Lodor ){ loc = new Point3D(103, 999, 36); map = Map.Underworld; }
			else if ( zone == "the Daemon's Crag" && map == Map.Lodor ){ loc = new Point3D(1481, 835, 0); map = Map.Underworld; }
			else if ( zone == "the Stygian Abyss" && map == Map.Underworld ){ loc = new Point3D(824, 907, 0); }
			else if ( zone == "the Hall of the Mountain King" && map == Map.Lodor ){ loc = new Point3D(130, 102, 0); map = Map.Underworld; }
			else if ( zone == "the Depths of Carthax Lake" && map == Map.Lodor ){ loc = new Point3D(926, 874, 0); map = Map.Underworld; }
			else if ( zone == "the Ancient Sky Ship" && map == Map.SavagedEmpire ){ loc = new Point3D(66, 561, 0); map = Map.Underworld; }

			string my_location = "";

			int xLong = 0, yLat = 0;
			int xMins = 0, yMins = 0;
			bool xEast = false, ySouth = false;

			if ( Sextant.Format( loc, map, ref xLong, ref yLat, ref xMins, ref yMins, ref xEast, ref ySouth ) )
			{
				my_location = String.Format( "{0}° {1}'{2}, {3}° {4}'{5}", yLat, yMins, ySouth ? "S" : "N", xLong, xMins, xEast ? "E" : "W" );
			}

            return my_location;
        }

        public static string GetDungeonListing()
        {
			// THIS RETURNS AN ALPHABETICAL LIST (BY WORLD) OF DUNGEONS & LOCATIONS

			int i = 0;
			string dungeon = "";
			string listing = "";
			string location = "";

			while ( i < 85 )
			{
				i++;

				if ( i == 1 ){ dungeon = "Dardin's Pit"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 2 ){ dungeon = "Dungeon Clues"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 3 ){ dungeon = "Dungeon Doom"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 4 ){ dungeon = "Dungeon Exodus"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 5 ){ dungeon = "the Pirate Cave"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 6 ){ dungeon = "the Ancient Pyramid"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 7 ){ dungeon = "the Cave of Banished Mages"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 8 ){ dungeon = "the Caverns of Poseidon"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 9 ){ dungeon = "the Dungeon of Time Awaits"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 10 ){ dungeon = "the Fires of Hell"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 11 ){ dungeon = "the Forgotten Halls"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 12 ){ dungeon = "the Mines of Morinia"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 13 ){ dungeon = "the Perinian Depths"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 14 ){ dungeon = "the Ratmen Lair"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Sosaria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 15 ){ dungeon = "the Cave of the Zuluu"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Ambrosia<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 16 ){ dungeon = "the City of the Dead"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Ambrosia<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 17 ){ dungeon = "the Dragon's Maw"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Ambrosia<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 18 ){ dungeon = "the Mausoleum"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Umber Veil<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 19 ){ dungeon = "the Tower of Brass"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Umber Veil<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 20 ){ dungeon = "Dungeon Covetous"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 21 ){ dungeon = "Dungeon Deceit"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 22 ){ dungeon = "Dungeon Despise"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 23 ){ dungeon = "Dungeon Destard"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 24 ){ dungeon = "Dungeon Hythloth"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 25 ){ dungeon = "Dungeon Shame"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 26 ){ dungeon = "Dungeon Wrong"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 27 ){ dungeon = "Stonegate Castle"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 28 ){ dungeon = "Terathan Keep"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 29 ){ dungeon = "the Ancient Elven Mine"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 30 ){ dungeon = "the Castle of Dracula"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 31 ){ dungeon = "the City of Embers"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 32 ){ dungeon = "the Crypts of Dracula"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 33 ){ dungeon = "the Frozen Hells"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 34 ){ dungeon = "the Halls of Undermountain"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 35 ){ dungeon = "the Ice Fiend Lair"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 36 ){ dungeon = "the Lodoria Catacombs"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 37 ){ dungeon = "the Undersea Pass"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 38 ){ dungeon = "the Volcanic Cave"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Lodoria<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 39 ){ dungeon = "Dungeon Ankh"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 40 ){ dungeon = "Dungeon Bane"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 41 ){ dungeon = "Dungeon Hate"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 42 ){ dungeon = "Dungeon Scorn"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 43 ){ dungeon = "Dungeon Torment"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 44 ){ dungeon = "Dungeon Vile"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 45 ){ dungeon = "Dungeon Wicked"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 46 ){ dungeon = "Dungeon Wrath"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 47 ){ dungeon = "the Ancient Prison"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 48 ){ dungeon = "the Cave of Fire"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 49 ){ dungeon = "the Cave of Souls"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 50 ){ dungeon = "the Flooded Temple"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 51 ){ dungeon = "the Gargoyle Crypts"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 52 ){ dungeon = "the Serpent Sanctum"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 53 ){ dungeon = "the Tomb of the Fallen Wizard"; location = GetAreaEntrance( dungeon, Map.SerpentIsland ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 54 ){ dungeon = "the Vault of the Black Knight"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Serpent Island<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 55 ){ dungeon = "the Blood Temple"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Isles of Dread<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 56 ){ dungeon = "the Glacial Scar"; location = GetAreaEntrance( dungeon, Map.Underworld ); listing = listing + "Isles of Dread<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 57 ){ dungeon = "the Ice Queen Fortress"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Isles of Dread<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 58 ){ dungeon = "the Sanctum of Saltmarsh"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Isles of Dread<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 59 ){ dungeon = "the Scurvy Reef"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Isles of Dread<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 60 ){ dungeon = "the Temple of Osirus"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Isles of Dread<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 61 ){ dungeon = "Dungeon of the Lich King"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 62 ){ dungeon = "Dungeon of the Mad Archmage"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 63 ){ dungeon = "Dungeon Rock"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 64 ){ dungeon = "the Azure Castle"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 65 ){ dungeon = "the Catacombs of Azerok"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 66 ){ dungeon = "the Corrupt Pass"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 67 ){ dungeon = "the Halls of Ogrimar"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 68 ){ dungeon = "the Ratmen Mines"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 69 ){ dungeon = "the Storm Giant Lair"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 70 ){ dungeon = "the Tomb of Kazibal"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 71 ){ dungeon = "the Tombs"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 72 ){ dungeon = "the Undersea Castle"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Savaged Empire<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 73 ){ dungeon = "the Crypts of Kuldar"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Kuldar<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 74 ){ dungeon = "the Kuldara Sewers"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Kuldar<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 75 ){ dungeon = "the Valley of Dark Druids"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Kuldar<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 76 ){ dungeon = "Vordo's Castle"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Kuldar<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 77 ){ dungeon = "Vordo's Dungeon"; location = GetAreaEntrance( dungeon, Map.Sosaria ); listing = listing + "Kuldar<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 78 ){ dungeon = "Argentrock Castle"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 79 ){ dungeon = "the Ancient Sky Ship"; location = GetAreaEntrance( dungeon, Map.SavagedEmpire ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 80 ){ dungeon = "Morgaelin's Inferno"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 81 ){ dungeon = "the Daemon's Crag"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 82 ){ dungeon = "the Depths of Carthax Lake"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 83 ){ dungeon = "the Hall of the Mountain King"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 84 ){ dungeon = "the Stygian Abyss"; location = GetAreaEntrance( dungeon, Map.Underworld ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
				else if ( i == 85 ){ dungeon = "the Zealan Tombs"; location = GetAreaEntrance( dungeon, Map.Lodor ); listing = listing + "Underworld<br>" + dungeon + "<br>" + location + "<br><br>"; }
			}

            return listing;
        }

		public static Point3D GetRandomLocation( string world, string scape )
		{
            bool LandOk = false;
			Point3D loc = new Point3D(0, 0, 0);
			Point3D failover = new Point3D(0, 0, 0);
			Point3D testLocation = new Point3D(0, 0, 0);

			Map tl = Map.Sosaria;
            int tx = 0;
			int ty = 0;
			int tz = 0;
			int tm = 0;
			int r = 0;
			int swrapx = 0;
			int swrapy = 0;

			if ( scape != "land" ){ swrapx = 26; swrapy = 26; }

            while ( tm < 1 )
            {
                if (world == "the Bottle World of Kuldar")
                {
					tl = Map.Sosaria;
                    tx = Utility.RandomMinMax( 6166+swrapx, 7204-swrapx );
                    ty = Utility.RandomMinMax( 829+swrapy, 2741-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(6722, 1338, 0); } else { failover = new Point3D(6348, 1096, -5); }
                }
                else if (world == "the Land of Ambrosia")
                {
					tl = Map.Sosaria;
                    tx = Utility.RandomMinMax( 5160+swrapx, 6163-swrapx );
                    ty = Utility.RandomMinMax( 3036+swrapy, 4095-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(5599, 3523, 22); } else { failover = new Point3D(5512, 3232, -5); }
                }
                else if (world == "the Island of Umber Veil")
                {
					tl = Map.Sosaria;
                    tx = Utility.RandomMinMax( 737+swrapx, 2310-swrapx );
                    ty = Utility.RandomMinMax( 3130+swrapy, 4095-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(1766, 3638, 22); } else { failover = new Point3D(880, 3796, -5); }
                }
                else if (world == "the Moon of Luna")
                {
					tl = Map.Sosaria;
                    tx = Utility.RandomMinMax( 5856+swrapx, 6164-swrapx );
                    ty = Utility.RandomMinMax( 2740+swrapy, 3018-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(5902, 2793, 0); } else { failover = new Point3D(112, 1816, -5); }
                }
                else if (world == "the Town of Skara Brae")
                {
					tl = Map.Lodor;
                    tx = Utility.RandomMinMax( 6898+swrapx, 7068-swrapx );
                    ty = Utility.RandomMinMax( 130+swrapy, 314-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(6927, 300, 0); } else { failover = new Point3D(112, 1816, -5); }
                }
                else if (world == "the Land of Lodoria")
                {
					tl = Map.Lodor;
                    tx = Utility.RandomMinMax( 0+swrapx, 5157-swrapx );
                    ty = Utility.RandomMinMax( 0+swrapy, 4095-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(1050, 2236, 0); } else { failover = new Point3D(3470, 2504, -5); }
                }
                else if (world == "the Underworld")
                {
					tl = Map.Underworld;
                    tx = Utility.RandomMinMax( 50+swrapx, 1660-swrapx );
                    ty = Utility.RandomMinMax( 10+swrapy, 1600-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(1433, 855, 0); } else { failover = new Point3D(547, 1441, -5); }
                }
                else if (world == "the Serpent Island")
                {
					tl = Map.SerpentIsland;
                    tx = Utility.RandomMinMax( 0+swrapx, 1908-swrapx );
                    ty = Utility.RandomMinMax( 0+swrapy, 2047-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(286, 1392, 2); } else { failover = new Point3D(1605, 536, -5); }
                }
                else if (world == "the Isles of Dread")
                {
					tl = Map.IslesDread;
                    tx = Utility.RandomMinMax( 0+swrapx, 1446-swrapx );
                    ty = Utility.RandomMinMax( 0+swrapy, 1446-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(1176, 816, 0); } else { failover = new Point3D(626, 643, -5); }
                }
                else if (world == "the Savaged Empire")
                {
					tl = Map.SavagedEmpire;
                    tx = Utility.RandomMinMax( 170+swrapx, 1200-swrapx );
                    ty = Utility.RandomMinMax( 10+swrapy, 1795-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(653, 1269, -2); } else { failover = new Point3D(320, 638, -5); }
                }
                else if (world == "the Land of Sosaria")
                {
					tl = Map.Sosaria;
                    tx = Utility.RandomMinMax( 0+swrapx, 5158-swrapx );
                    ty = Utility.RandomMinMax( 0+swrapy, 3128-swrapy );
                    tz = tl.GetAverageZ(tx, ty);
					if ( scape == "land" ){ failover = new Point3D(2575, 1680, 20); } else { failover = new Point3D(112, 1816, -5); }
                }

                LandTile t = tl.Tiles.GetLandTile(tx, ty);

				if ( scape == "land" )
				{
					LandOk = Utility.PassableTile ( t.ID, "any" );

					Mobile mSp = new Rat();
					mSp.Name = "locator";
					mSp.MoveToWorld(new Point3D(tx, ty, tz), tl);
					Region RatReg = mSp.Region;
					mSp.Delete();
					testLocation = new Point3D(tx, ty, tz);

					if (LandOk && tl.CanSpawnMobile(tx, ty, tz) && ( Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( tl, testLocation ) ) || RatReg.IsPartOf(typeof(Regions.BardTownRegion)) ) )
					{
						loc = new Point3D(tx, ty, tz);
						tm = 1;
					}
				}
				else // GET WATER TILES
				{
					if ( Server.Misc.Worlds.IsWaterTile( t.ID, 0 ) && Server.Misc.Worlds.TestOcean ( tl, tx, ty, 2 ) ) { LandOk = true; }

					Point3D locale = new Point3D(tx, ty, tz);
					Region reg = Region.Find( locale, tl );

					if ( tz != -5 ){ LandOk = false; }

					if ( LandOk && Server.Misc.Worlds.IsMainRegion( Server.Misc.Worlds.GetRegionName( tl, locale ) ) )
					{
						loc = new Point3D(tx, ty, tz);
						tm = 1;
					}
				}

				r++; // SAFETY CATCH
				if ( r > 1000 && tm != 1)
                {
                    loc = failover;
					tm = 1;
                }
            }
            return loc;
        }

		public static bool InBuilding( Mobile m )
		{
			bool indoors = false;

			if ( !Server.Misc.MyServerSettings.NoMountBuilding() && !(m is TownGuards) )
				return false;

			// A TWEAK FOR ONE GUARD WHO SOMETIMES MOUNTS BECAUSE THEY SPAWN AT Z OF 0
			if ( m is TownGuards && m.Map == Map.Sosaria & ((BaseCreature)m).Home.X == 2999 && ((BaseCreature)m).Home.Y == 1124 )
				return true;

			if ( m.Map == Map.Atlantis )
			{
				indoors = true;
			}
			else if ( m.Map == Map.Sosaria )
			{
				// BRITAIN
				if ( m.X >= 2971 && m.Y >= 991 && m.X <= 2985 && m.Y <= 998 ){ indoors = true; }
				else if ( m.X >= 2950 && m.Y >= 990 && m.X <= 2965 && m.Y <= 998 ){ indoors = true; }
				else if ( m.X >= 2939 && m.Y >= 985 && m.X <= 2944 && m.Y <= 990 ){ indoors = true; }
				else if ( m.X >= 2940 && m.Y >= 1000 && m.X <= 2950 && m.Y <= 1016 ){ indoors = true; }
				else if ( m.X >= 2970 && m.Y >= 1008 && m.X <= 2985 && m.Y <= 1018 ){ indoors = true; }
				else if ( m.X >= 2970 && m.Y >= 1022 && m.X <= 2985 && m.Y <= 1031 ){ indoors = true; }
				else if ( m.X >= 2967 && m.Y >= 1033 && m.X <= 2985 && m.Y <= 1053 ){ indoors = true; }
				else if ( m.X >= 2941 && m.Y >= 1020 && m.X <= 2950 && m.Y <= 1027 ){ indoors = true; }
				else if ( m.X >= 2941 && m.Y >= 1027 && m.X <= 2954 && m.Y <= 1036 ){ indoors = true; }
				else if ( m.X >= 2956 && m.Y >= 1058 && m.X <= 2967 && m.Y <= 1068 ){ indoors = true; }
				else if ( m.X >= 2986 && m.Y >= 1095 && m.X <= 2995 && m.Y <= 1108 ){ indoors = true; }
				else if ( m.X >= 3005 && m.Y >= 1103 && m.X <= 3016 && m.Y <= 1110 ){ indoors = true; }
				else if ( m.X >= 3020 && m.Y >= 1104 && m.X <= 3030 && m.Y <= 1110 ){ indoors = true; }
				else if ( m.X >= 3033 && m.Y >= 1094 && m.X <= 3039 && m.Y <= 1105 ){ indoors = true; }
				else if ( m.X >= 3039 && m.Y >= 1045 && m.X <= 3046 && m.Y <= 1056 ){ indoors = true; }
				else if ( m.X >= 3020 && m.Y >= 1034 && m.X <= 3030 && m.Y <= 1042 ){ indoors = true; }
				else if ( m.X >= 3020 && m.Y >= 1024 && m.X <= 3030 && m.Y <= 1032 ){ indoors = true; }
				else if ( m.X >= 3021 && m.Y >= 1007 && m.X <= 3030 && m.Y <= 1021 ){ indoors = true; }
				else if ( m.X >= 3004 && m.Y >= 1006 && m.X <= 3014 && m.Y <= 1018 ){ indoors = true; }
				else if ( m.X >= 2955 && m.Y >= 893 && m.X <= 2967 && m.Y <= 904 ){ indoors = true; }
				else if ( m.X >= 2983 && m.Y >= 895 && m.X <= 2999 && m.Y <= 898 ){ indoors = true; }
				else if ( m.X >= 3015 && m.Y >= 893 && m.X <= 3027 && m.Y <= 904 ){ indoors = true; }
				else if ( m.X >= 3015 && m.Y >= 957 && m.X <= 3027 && m.Y <= 968 ){ indoors = true; }
				else if ( m.X >= 2985 && m.Y >= 963 && m.X <= 2997 && m.Y <= 967 ){ indoors = true; }
				else if ( m.X >= 2955 && m.Y >= 957 && m.X <= 2967 && m.Y <= 968 ){ indoors = true; }
				else if ( m.X >= 2959 && m.Y >= 898 && m.X <= 3023 && m.Y <= 963 ){ indoors = true; }
				else if ( m.X >= 3062 && m.Y >= 963 && m.X <= 3067 && m.Y <= 967 ){ indoors = true; }
				else if ( m.X >= 3044 && m.Y >= 1015 && m.X <= 3055 && m.Y <= 1026 ){ indoors = true; }
				else if ( m.X >= 3051 && m.Y >= 1026 && m.X <= 3055 && m.Y <= 1057 ){ indoors = true; }
				else if ( m.X >= 3051 && m.Y >= 1064 && m.X <= 3055 && m.Y <= 1127 ){ indoors = true; }
				else if ( m.X >= 3003 && m.Y >= 1123 && m.X <= 3055 && m.Y <= 1127 ){ indoors = true; }
				else if ( m.X >= 2929 && m.Y >= 1123 && m.X <= 2996 && m.Y <= 1127 ){ indoors = true; }
				else if ( m.X >= 2929 && m.Y >= 1065 && m.X <= 2933 && m.Y <= 1127 ){ indoors = true; }
				else if ( m.X >= 2929 && m.Y >= 986 && m.X <= 2938 && m.Y <= 993 ){ indoors = true; }
				else if ( m.X >= 2929 && m.Y >= 986 && m.X <= 2933 && m.Y <= 1060 ){ indoors = true; }
				else if ( m.X >= 2947 && m.Y >= 1083 && m.X <= 2952 && m.Y <= 1088 ){ indoors = true; }
				else if ( m.X >= 2994 && m.Y >= 1123 && m.X <= 3005 && m.Y <= 1127 && m.Z >= 20 ){ indoors = true; }
				else if ( m.X >= 2929 && m.Y >= 1053 && m.X <= 2933 && m.Y <= 1072 && m.Z >= 20 ){ indoors = true; }
				else if ( m.X >= 3051 && m.Y >= 1053 && m.X <= 3055 && m.Y <= 1071 && m.Z >= 20 ){ indoors = true; }
				else if ( m.X >= 2631 && m.Y >= 3221 && m.X <= 2748 && m.Y <= 3346 ){ indoors = true; }
				// MONTOR
				else if ( m.X >= 3070 && m.Y >= 2571 && m.X <= 3085 && m.Y <= 2580 ){ indoors = true; }
				else if ( m.X >= 3093 && m.Y >= 2574 && m.X <= 3098 && m.Y <= 2579 ){ indoors = true; }
				else if ( m.X >= 3103 && m.Y >= 2581 && m.X <= 3114 && m.Y <= 2588 ){ indoors = true; }
				else if ( m.X >= 3131 && m.Y >= 2581 && m.X <= 3143 && m.Y <= 2588 ){ indoors = true; }
				else if ( m.X >= 3111 && m.Y >= 2568 && m.X <= 3134 && m.Y <= 2577 ){ indoors = true; }
				else if ( m.X >= 3117 && m.Y >= 2577 && m.X <= 3128 && m.Y <= 2588 ){ indoors = true; }
				else if ( m.X >= 3163 && m.Y >= 2572 && m.X <= 3177 && m.Y <= 2580 ){ indoors = true; }
				else if ( m.X >= 3143 && m.Y >= 2597 && m.X <= 3160 && m.Y <= 2605 ){ indoors = true; }
				else if ( m.X >= 3085 && m.Y >= 2597 && m.X <= 3094 && m.Y <= 2605 ){ indoors = true; }
				else if ( m.X >= 3070 && m.Y >= 2625 && m.X <= 3085 && m.Y <= 2635 ){ indoors = true; }
				else if ( m.X >= 3074 && m.Y >= 2638 && m.X <= 3085 && m.Y <= 2650 ){ indoors = true; }
				else if ( m.X >= 3142 && m.Y >= 2615 && m.X <= 3161 && m.Y <= 2623 ){ indoors = true; }
				else if ( m.X >= 3143 && m.Y >= 2619 && m.X <= 3151 && m.Y <= 2632 ){ indoors = true; }
				else if ( m.X >= 3142 && m.Y >= 2635 && m.X <= 3149 && m.Y <= 2649 ){ indoors = true; }
				else if ( m.X >= 3151 && m.Y >= 2634 && m.X <= 3159 && m.Y <= 2647 ){ indoors = true; }
				else if ( m.X >= 3196 && m.Y >= 2615 && m.X <= 3204 && m.Y <= 2626 ){ indoors = true; }
				else if ( m.X >= 3236 && m.Y >= 2586 && m.X <= 3243 && m.Y <= 2595 ){ indoors = true; }
				else if ( m.X >= 3260 && m.Y >= 2577 && m.X <= 3272 && m.Y <= 2585 ){ indoors = true; }
				else if ( m.X >= 3283 && m.Y >= 2573 && m.X <= 3295 && m.Y <= 2580 ){ indoors = true; }
				else if ( m.X >= 3300 && m.Y >= 2568 && m.X <= 3324 && m.Y <= 2580 ){ indoors = true; }
				else if ( m.X >= 3328 && m.Y >= 2573 && m.X <= 3342 && m.Y <= 2580 ){ indoors = true; }
				else if ( m.X >= 3356 && m.Y >= 2576 && m.X <= 3369 && m.Y <= 2585 ){ indoors = true; }
				else if ( m.X >= 3340 && m.Y >= 2594 && m.X <= 3356 && m.Y <= 2603 ){ indoors = true; }
				else if ( m.X >= 3317 && m.Y >= 2594 && m.X <= 3333 && m.Y <= 2603 ){ indoors = true; }
				else if ( m.X >= 3355 && m.Y >= 2638 && m.X <= 3370 && m.Y <= 2647 ){ indoors = true; }
				else if ( m.X >= 3306 && m.Y >= 2642 && m.X <= 3321 && m.Y <= 2651 ){ indoors = true; }
				else if ( m.X >= 3259 && m.Y >= 2638 && m.X <= 3272 && m.Y <= 2647 ){ indoors = true; }
				else if ( m.X >= 3262 && m.Y >= 2650 && m.X <= 3272 && m.Y <= 2657 ){ indoors = true; }
				else if ( m.X >= 3174 && m.Y >= 2600 && m.X <= 3181 && m.Y <= 2608 ){ indoors = true; }
				else if ( m.X >= 3181 && m.Y >= 2602 && m.X <= 3193 && m.Y <= 2606 ){ indoors = true; }
				else if ( m.X >= 3174 && m.Y >= 2614 && m.X <= 3181 && m.Y <= 2622 ){ indoors = true; }
				else if ( m.X >= 3181 && m.Y >= 2616 && m.X <= 3193 && m.Y <= 2620 ){ indoors = true; }
				else if ( m.X >= 3189 && m.Y >= 2616 && m.X <= 3193 && m.Y <= 2663 ){ indoors = true; }
				else if ( m.X >= 3068 && m.Y >= 2613 && m.X <= 3075 && m.Y <= 2621 ){ indoors = true; }
				else if ( m.X >= 3057 && m.Y >= 2615 && m.X <= 3068 && m.Y <= 2619 ){ indoors = true; }
				else if ( m.X >= 3057 && m.Y >= 2615 && m.X <= 3061 && m.Y <= 2659 ){ indoors = true; }
				else if ( m.X >= 3057 && m.Y >= 2659 && m.X <= 3193 && m.Y <= 2663 ){ indoors = true; }
				else if ( m.X >= 3068 && m.Y >= 2600 && m.X <= 3075 && m.Y <= 2608 ){ indoors = true; }
				else if ( m.X >= 3057 && m.Y >= 2602 && m.X <= 3068 && m.Y <= 2606 ){ indoors = true; }
				else if ( m.X >= 3057 && m.Y >= 2561 && m.X <= 3061 && m.Y <= 2606 ){ indoors = true; }
				else if ( m.X >= 3057 && m.Y >= 2561 && m.X <= 3193 && m.Y <= 2565 ){ indoors = true; }
				else if ( m.X >= 3189 && m.Y >= 2561 && m.X <= 3193 && m.Y <= 2606 ){ indoors = true; }
				else if ( m.X >= 3181 && m.Y >= 2602 && m.X <= 3193 && m.Y <= 2606 ){ indoors = true; }
				// KULDAR
				else if ( m.X >= 6627 && m.Y >= 1827 && m.X <= 6634 && m.Y <= 1834 ){ indoors = true; }
				else if ( m.X >= 6627 && m.Y >= 1843 && m.X <= 6635 && m.Y <= 1851 ){ indoors = true; }
				else if ( m.X >= 6643 && m.Y >= 1843 && m.X <= 6651 && m.Y <= 1851 ){ indoors = true; }
				else if ( m.X >= 6632 && m.Y >= 1831 && m.X <= 6647 && m.Y <= 1847 ){ indoors = true; }
				else if ( m.X >= 6703 && m.Y >= 1815 && m.X <= 6711 && m.Y <= 1823 ){ indoors = true; }
				else if ( m.X >= 6708 && m.Y >= 1848 && m.X <= 6719 && m.Y <= 1863 ){ indoors = true; }
				else if ( m.X >= 6720 && m.Y >= 1856 && m.X <= 6727 && m.Y <= 1863 ){ indoors = true; }
				else if ( m.X >= 6743 && m.Y >= 1823 && m.X <= 6759 && m.Y <= 1831 ){ indoors = true; }
				else if ( m.X >= 6768 && m.Y >= 1824 && m.X <= 6779 && m.Y <= 1831 ){ indoors = true; }
				else if ( m.X >= 6787 && m.Y >= 1816 && m.X <= 6795 && m.Y <= 1827 ){ indoors = true; }
				else if ( m.X >= 6767 && m.Y >= 1839 && m.X <= 6779 && m.Y <= 1847 ){ indoors = true; }
				else if ( m.X >= 6767 && m.Y >= 1839 && m.X <= 6775 && m.Y <= 1855 ){ indoors = true; }
				else if ( m.X >= 6744 && m.Y >= 1808 && m.X <= 6767 && m.Y <= 1815 ){ indoors = true; }
				else if ( m.X >= 6761 && m.Y >= 1787 && m.X <= 6773 && m.Y <= 1795 ){ indoors = true; }
				else if ( m.X >= 6761 && m.Y >= 1787 && m.X <= 6769 && m.Y <= 1799 ){ indoors = true; }
				else if ( m.X >= 6746 && m.Y >= 1782 && m.X <= 6753 && m.Y <= 1797 ){ indoors = true; }
				else if ( m.X >= 6759 && m.Y >= 1767 && m.X <= 6783 && m.Y <= 1779 ){ indoors = true; }
				else if ( m.X >= 6792 && m.Y >= 1760 && m.X <= 6803 && m.Y <= 1767 ){ indoors = true; }
				else if ( m.X >= 6792 && m.Y >= 1760 && m.X <= 6799 && m.Y <= 1771 ){ indoors = true; }
				else if ( m.X >= 6735 && m.Y >= 1763 && m.X <= 6750 && m.Y <= 1773 ){ indoors = true; }
				else if ( m.X >= 6731 && m.Y >= 1749 && m.X <= 6747 && m.Y <= 1757 ){ indoors = true; }
				else if ( m.X >= 6717 && m.Y >= 1750 && m.X <= 6727 && m.Y <= 1769 ){ indoors = true; }
				else if ( m.X >= 6703 && m.Y >= 1717 && m.X <= 6711 && m.Y <= 1725 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6703 && m.Y >= 1733 && m.X <= 6711 && m.Y <= 1741 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6719 && m.Y >= 1737 && m.X <= 6723 && m.Y <= 1743 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6720 && m.Y >= 1743 && m.X <= 6749 && m.Y <= 1747 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6749 && m.Y >= 1739 && m.X <= 6757 && m.Y <= 1751 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6785 && m.Y >= 1739 && m.X <= 6793 && m.Y <= 1751 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6793 && m.Y >= 1743 && m.X <= 6805 && m.Y <= 1747 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6805 && m.Y >= 1739 && m.X <= 6813 && m.Y <= 1751 && m.Z < 35 ){ indoors = true; }
				else if ( m.X >= 6793 && m.Y >= 1687 && m.X <= 6801 && m.Y <= 1696 && m.Z < 15 ){ indoors = true; }
				else if ( m.X >= 6797 && m.Y >= 1695 && m.X <= 6801 && m.Y <= 1707 && m.Z < 15 ){ indoors = true; }
				else if ( m.X >= 6798 && m.Y >= 1707 && m.X <= 6809 && m.Y <= 1711 && m.Z < 15 ){ indoors = true; }
				else if ( m.X >= 6805 && m.Y >= 1708 && m.X <= 6809 && m.Y <= 1713 && m.Z < 15 ){ indoors = true; }
				else if ( m.X >= 6805 && m.Y >= 1713 && m.X <= 6813 && m.Y <= 1721 && m.Z < 15 ){ indoors = true; }
				else if ( m.X >= 6802 && m.Y >= 1695 && m.X <= 6809 && m.Y <= 1705 ){ indoors = true; }
				else if ( m.X >= 6800 && m.Y >= 1668 && m.X <= 6811 && m.Y <= 1679 ){ indoors = true; }
				else if ( m.X >= 6803 && m.Y >= 1663 && m.X <= 6811 && m.Y <= 1679 ){ indoors = true; }
				else if ( m.X >= 6791 && m.Y >= 1616 && m.X <= 6807 && m.Y <= 1631 ){ indoors = true; }
				else if ( m.X >= 6779 && m.Y >= 1647 && m.X <= 6795 && m.Y <= 1663 ){ indoors = true; }
				else if ( m.X >= 6732 && m.Y >= 1652 && m.X <= 6771 && m.Y <= 1671 ){ indoors = true; }
				else if ( m.X >= 6711 && m.Y >= 1647 && m.X <= 6723 && m.Y <= 1655 ){ indoors = true; }
				else if ( m.X >= 6711 && m.Y >= 1647 && m.X <= 6717 && m.Y <= 1663 ){ indoors = true; }
				else if ( m.X >= 6711 && m.Y >= 1679 && m.X <= 6727 && m.Y <= 1687 ){ indoors = true; }
				else if ( m.X >= 6724 && m.Y >= 1696 && m.X <= 6735 && m.Y <= 1703 ){ indoors = true; }
				else if ( m.X >= 6735 && m.Y >= 1679 && m.X <= 6755 && m.Y <= 1687 ){ indoors = true; }
				else if ( m.X >= 6743 && m.Y >= 1679 && m.X <= 6755 && m.Y <= 1703 ){ indoors = true; }
				else if ( m.X >= 6723 && m.Y >= 1711 && m.X <= 6735 && m.Y <= 1719 ){ indoors = true; }
				else if ( m.X >= 6703 && m.Y >= 1691 && m.X <= 6715 && m.Y <= 1715 ){ indoors = true; }
				else if ( m.X >= 6743 && m.Y >= 1711 && m.X <= 6751 && m.Y <= 1723 ){ indoors = true; }
				else if ( m.X >= 6743 && m.Y >= 1711 && m.X <= 6755 && m.Y <= 1719 ){ indoors = true; }
				else if ( m.X >= 6764 && m.Y >= 1696 && m.X <= 6779 && m.Y <= 1703 ){ indoors = true; }
				else if ( m.X >= 6776 && m.Y >= 1684 && m.X <= 6783 && m.Y <= 1694 ){ indoors = true; }
				else if ( m.X >= 6764 && m.Y >= 1680 && m.X <= 6774 && m.Y <= 1687 ){ indoors = true; }
				else if ( m.X >= 6764 && m.Y >= 1712 && m.X <= 6775 && m.Y <= 1719 ){ indoors = true; }
				// RENIKA
				else if ( m.X >= 1370 && m.Y >= 3633 && m.X <= 1417 && m.Y <= 3661 ){ indoors = true; }
				else if ( m.X >= 1414 && m.Y >= 3637 && m.X <= 1421 && m.Y <= 3644 ){ indoors = true; }
				else if ( m.X >= 1414 && m.Y >= 3661 && m.X <= 1421 && m.Y <= 3668 ){ indoors = true; }
				else if ( m.X >= 1388 && m.Y >= 3661 && m.X <= 1395 && m.Y <= 3668 ){ indoors = true; }
				else if ( m.X >= 1398 && m.Y >= 3662 && m.X <= 1411 && m.Y <= 3667 ){ indoors = true; }
				else if ( m.X >= 1387 && m.Y >= 3777 && m.X <= 1403 && m.Y <= 3789 ){ indoors = true; }
				else if ( m.X >= 1425 && m.Y >= 3757 && m.X <= 1436 && m.Y <= 3764 ){ indoors = true; }
				else if ( m.X >= 1439 && m.Y >= 3752 && m.X <= 1445 && m.Y <= 3764 ){ indoors = true; }
				else if ( m.X >= 1419 && m.Y >= 3767 && m.X <= 1427 && m.Y <= 3777 ){ indoors = true; }
				else if ( m.X >= 1418 && m.Y >= 3779 && m.X <= 1427 && m.Y <= 3791 ){ indoors = true; }
				else if ( m.X >= 1454 && m.Y >= 3766 && m.X <= 1464 && m.Y <= 3773 ){ indoors = true; }
				else if ( m.X >= 1468 && m.Y >= 3766 && m.X <= 1479 && m.Y <= 3773 ){ indoors = true; }
				else if ( m.X >= 1434 && m.Y >= 3791 && m.X <= 1445 && m.Y <= 3799 ){ indoors = true; }
				else if ( m.X >= 1438 && m.Y >= 3802 && m.X <= 1445 && m.Y <= 3809 ){ indoors = true; }
				else if ( m.X >= 1454 && m.Y >= 3781 && m.X <= 1476 && m.Y <= 3789 ){ indoors = true; }
				else if ( m.X >= 1453 && m.Y >= 3802 && m.X <= 1460 && m.Y <= 3809 ){ indoors = true; }
				// BANDIT CAMP
				else if ( m.X >= 3005 && m.Y >= 383 && m.X <= 3009 && m.Y <= 388 ){ indoors = true; }
				else if ( m.X >= 3005 && m.Y >= 370 && m.X <= 3014 && m.Y <= 377 ){ indoors = true; }
				// DARK TOWER
				else if ( m.X >= 3504 && m.Y >= 2277 && m.X <= 3512 && m.Y <= 2289 ){ indoors = true; }
				else if ( m.X >= 3503 && m.Y >= 2278 && m.X <= 3513 && m.Y <= 2288 ){ indoors = true; }
				else if ( m.X >= 3502 && m.Y >= 2279 && m.X <= 3514 && m.Y <= 2287 ){ indoors = true; }
				// DARK FORTRESS
				else if ( m.X >= 3779 && m.Y >= 1846 && m.X <= 3786 && m.Y <= 1857 ){ indoors = true; }
				else if ( m.X >= 3786 && m.Y >= 1846 && m.X <= 3797 && m.Y <= 1861 ){ indoors = true; }
				else if ( m.X >= 3797 && m.Y >= 1848 && m.X <= 3812 && m.Y <= 1862 ){ indoors = true; }
				else if ( m.X >= 3804 && m.Y >= 1846 && m.X <= 3812 && m.Y <= 1864 ){ indoors = true; }
				else if ( m.X >= 3786 && m.Y >= 1854 && m.X <= 3807 && m.Y <= 1861 ){ indoors = true; }
				else if ( m.X >= 3787 && m.Y >= 1861 && m.X <= 3812 && m.Y <= 1876 ){ indoors = true; }
				else if ( m.X >= 3786 && m.Y >= 1864 && m.X <= 3812 && m.Y <= 1876 ){ indoors = true; }
				else if ( m.X >= 3794 && m.Y >= 1851 && m.X <= 3809 && m.Y <= 1873 ){ indoors = true; }
				// LIGHTHOUSE
				else if ( m.X >= 3191 && m.Y >= 507 && m.X <= 3200 && m.Y <= 520 ){ indoors = true; }
				// MANGARS TOWER
				else if ( m.X >= 2823 && m.Y >= 1870 && m.X <= 2834 && m.Y <= 1878 ){ indoors = true; }
				// PIRATE ISLE
				else if ( m.X >= 1823 && m.Y >= 2219 && m.X <= 1830 && m.Y <= 2226 ){ indoors = true; }
				else if ( m.X >= 1807 && m.Y >= 2219 && m.X <= 1814 && m.Y <= 2226 ){ indoors = true; }
				else if ( m.X >= 1823 && m.Y >= 2235 && m.X <= 1830 && m.Y <= 2242 ){ indoors = true; }
				else if ( m.X >= 1803 && m.Y >= 2254 && m.X <= 1807 && m.Y <= 2258 ){ indoors = true; }
				// DAWN
				else if ( m.X >= 5903 && m.Y >= 2875 && m.X <= 5910 && m.Y <= 2881 ){ indoors = true; }
				else if ( m.X >= 5903 && m.Y >= 2842 && m.X <= 5910 && m.Y <= 2849 ){ indoors = true; }
				else if ( m.X >= 5903 && m.Y >= 2848 && m.X <= 5905 && m.Y <= 2875 ){ indoors = true; }
				else if ( m.X >= 5908 && m.Y >= 2842 && m.X <= 6014 && m.Y <= 2844 ){ indoors = true; }
				else if ( m.X >= 6014 && m.Y >= 2842 && m.X <= 6021 && m.Y <= 2849 ){ indoors = true; }
				else if ( m.X >= 6019 && m.Y >= 2849 && m.X <= 6021 && m.Y <= 2882 ){ indoors = true; }
				else if ( m.X >= 6019 && m.Y >= 2887 && m.X <= 6021 && m.Y <= 2903 ){ indoors = true; }
				else if ( m.X >= 5989 && m.Y >= 2901 && m.X <= 6021 && m.Y <= 2903 ){ indoors = true; }
				else if ( m.X >= 5989 && m.Y >= 2901 && m.X <= 5991 && m.Y <= 2924 ){ indoors = true; }
				else if ( m.X >= 5903 && m.Y >= 2922 && m.X <= 5991 && m.Y <= 2924 ){ indoors = true; }
				else if ( m.X >= 5903 && m.Y >= 2887 && m.X <= 5910 && m.Y <= 2893 ){ indoors = true; }
				else if ( m.X >= 5903 && m.Y >= 2887 && m.X <= 5905 && m.Y <= 2922 ){ indoors = true; }
				else if ( m.X >= 6019 && m.Y >= 2881 && m.X <= 6021 && m.Y <= 2889 && m.Z > 20 ){ indoors = true; }
				else if ( m.X >= 6002 && m.Y >= 2884 && m.X <= 6010 && m.Y <= 2896 ){ indoors = true; }
				else if ( m.X >= 6011 && m.Y >= 2888 && m.X <= 6014 && m.Y <= 2896 ){ indoors = true; }
				else if ( m.X >= 6003 && m.Y >= 2866 && m.X <= 6009 && m.Y <= 2872 ){ indoors = true; }
				else if ( m.X >= 6009 && m.Y >= 2867 && m.X <= 6016 && m.Y <= 2879 ){ indoors = true; }
				else if ( m.X >= 6003 && m.Y >= 2854 && m.X <= 6010 && m.Y <= 2860 ){ indoors = true; }
				else if ( m.X >= 5981 && m.Y >= 2857 && m.X <= 5993 && m.Y <= 2864 ){ indoors = true; }
				else if ( m.X >= 5964 && m.Y >= 2852 && m.X <= 5977 && m.Y <= 2861 ){ indoors = true; }
				else if ( m.X >= 5945 && m.Y >= 2848 && m.X <= 5959 && m.Y <= 2855 ){ indoors = true; }
				else if ( m.X >= 5930 && m.Y >= 2851 && m.X <= 5943 && m.Y <= 2858 ){ indoors = true; }
				else if ( m.X >= 5920 && m.Y >= 2872 && m.X <= 5937 && m.Y <= 2876 ){ indoors = true; }
				else if ( m.X >= 5933 && m.Y >= 2866 && m.X <= 5937 && m.Y <= 2876 ){ indoors = true; }
				else if ( m.X >= 5913 && m.Y >= 2886 && m.X <= 5922 && m.Y <= 2900 ){ indoors = true; }
				else if ( m.X >= 5927 && m.Y >= 2888 && m.X <= 5938 && m.Y <= 2896 ){ indoors = true; }
				else if ( m.X >= 5928 && m.Y >= 2904 && m.X <= 5938 && m.Y <= 2911 ){ indoors = true; }
				else if ( m.X >= 5943 && m.Y >= 2901 && m.X <= 5949 && m.Y <= 2910 ){ indoors = true; }
				else if ( m.X >= 5951 && m.Y >= 2901 && m.X <= 5958 && m.Y <= 2910 ){ indoors = true; }
				else if ( m.X >= 5963 && m.Y >= 2903 && m.X <= 5971 && m.Y <= 2913 ){ indoors = true; }
				else if ( m.X >= 5975 && m.Y >= 2905 && m.X <= 5985 && m.Y <= 2913 ){ indoors = true; }
				// YEW
				else if ( m.X >= 2347 && m.Y >= 874 && m.X <= 2355 && m.Y <= 879 ){ indoors = true; }
				else if ( m.X >= 2397 && m.Y >= 859 && m.X <= 2407 && m.Y <= 865 ){ indoors = true; }
				else if ( m.X >= 2387 && m.Y >= 888 && m.X <= 2400 && m.Y <= 898 ){ indoors = true; }
				else if ( m.X >= 2410 && m.Y >= 858 && m.X <= 2422 && m.Y <= 865 ){ indoors = true; }
				else if ( m.X >= 2419 && m.Y >= 887 && m.X <= 2424 && m.Y <= 896 ){ indoors = true; }
				else if ( m.X >= 2432 && m.Y >= 847 && m.X <= 2438 && m.Y <= 857 ){ indoors = true; }
				else if ( m.X >= 2442 && m.Y >= 847 && m.X <= 2448 && m.Y <= 857 ){ indoors = true; }
				else if ( m.X >= 2454 && m.Y >= 835 && m.X <= 2465 && m.Y <= 845 ){ indoors = true; }
				else if ( m.X >= 2452 && m.Y >= 865 && m.X <= 2464 && m.Y <= 871 ){ indoors = true; }
				else if ( m.X >= 2492 && m.Y >= 879 && m.X <= 2502 && m.Y <= 886 ){ indoors = true; }
				else if ( m.X >= 2475 && m.Y >= 888 && m.X <= 2485 && m.Y <= 895 ){ indoors = true; }
				else if ( m.X >= 2509 && m.Y >= 856 && m.X <= 2514 && m.Y <= 866 ){ indoors = true; }
				// PORT
				else if ( m.X >= 7063 && m.Y >= 703 && m.X <= 7087 && m.Y <= 719 ){ indoors = true; }
				else if ( m.X >= 7031 && m.Y >= 695 && m.X <= 7047 && m.Y <= 703 ){ indoors = true; }
				else if ( m.X >= 7039 && m.Y >= 679 && m.X <= 7063 && m.Y <= 687 ){ indoors = true; }
				else if ( m.X >= 7047 && m.Y >= 671 && m.X <= 7063 && m.Y <= 687 ){ indoors = true; }
				else if ( m.X >= 7007 && m.Y >= 687 && m.X <= 7015 && m.Y <= 703 ){ indoors = true; }
				else if ( m.X >= 7007 && m.Y >= 688 && m.X <= 7023 && m.Y <= 695 ){ indoors = true; }
				else if ( m.X >= 6981 && m.Y >= 693 && m.X <= 7000 && m.Y <= 714 ){ indoors = true; }
				else if ( m.X >= 6998 && m.Y >= 671 && m.X <= 7007 && m.Y <= 679 ){ indoors = true; }
				else if ( m.X >= 6991 && m.Y >= 662 && m.X <= 7000 && m.Y <= 670 ){ indoors = true; }
				else if ( m.X >= 7015 && m.Y >= 663 && m.X <= 7031 && m.Y <= 679 ){ indoors = true; }
				else if ( m.X >= 7026 && m.Y >= 663 && m.X <= 7039 && m.Y <= 671 ){ indoors = true; }
				else if ( m.X >= 7047 && m.Y >= 655 && m.X <= 7071 && m.Y <= 663 ){ indoors = true; }
				else if ( m.X >= 7055 && m.Y >= 647 && m.X <= 7063 && m.Y <= 655 ){ indoors = true; }
				else if ( m.X >= 7071 && m.Y >= 640 && m.X <= 7079 && m.Y <= 647 ){ indoors = true; }
				else if ( m.X >= 7079 && m.Y >= 640 && m.X <= 7087 && m.Y <= 655 ){ indoors = true; }
				else if ( m.X >= 7055 && m.Y >= 615 && m.X <= 7071 && m.Y <= 631 ){ indoors = true; }
				else if ( m.X >= 7055 && m.Y >= 626 && m.X <= 7063 && m.Y <= 639 ){ indoors = true; }
				else if ( m.X >= 7079 && m.Y >= 615 && m.X <= 7087 && m.Y <= 623 ){ indoors = true; }
				else if ( m.X >= 7079 && m.Y >= 624 && m.X <= 7095 && m.Y <= 631 ){ indoors = true; }
				else if ( m.X >= 7071 && m.Y >= 597 && m.X <= 7085 && m.Y <= 609 ){ indoors = true; }
				else if ( m.X >= 7085 && m.Y >= 589 && m.X <= 7102 && m.Y <= 609 ){ indoors = true; }
				else if ( m.X >= 7047 && m.Y >= 598 && m.X <= 7055 && m.Y <= 607 ){ indoors = true; }
				else if ( m.X >= 7039 && m.Y >= 616 && m.X <= 7047 && m.Y <= 631 ){ indoors = true; }
				else if ( m.X >= 7015 && m.Y >= 623 && m.X <= 7023 && m.Y <= 639 ){ indoors = true; }
				else if ( m.X >= 7015 && m.Y >= 623 && m.X <= 7031 && m.Y <= 631 ){ indoors = true; }
				else if ( m.X >= 7015 && m.Y >= 599 && m.X <= 7031 && m.Y <= 615 ){ indoors = true; }
				else if ( m.X >= 6998 && m.Y >= 632 && m.X <= 7007 && m.Y <= 639 ){ indoors = true; }
				else if ( m.X >= 6998 && m.Y >= 607 && m.X <= 7007 && m.Y <= 615 ){ indoors = true; }
				else if ( m.X >= 6975 && m.Y >= 608 && m.X <= 6983 && m.Y <= 623 ){ indoors = true; }
				else if ( m.X >= 6975 && m.Y >= 608 && m.X <= 6991 && m.Y <= 615 ){ indoors = true; }
				else if ( m.X >= 6975 && m.Y >= 632 && m.X <= 6991 && m.Y <= 639 ){ indoors = true; }
				else if ( m.X >= 6960 && m.Y >= 646 && m.X <= 6971 && m.Y <= 659 ){ indoors = true; }
				else if ( m.X >= 6998 && m.Y >= 631 && m.X <= 7007 && m.Y <= 639 ){ indoors = true; }
				else if ( m.X >= 7031 && m.Y >= 639 && m.X <= 7047 && m.Y <= 647 ){ indoors = true; }
				else if ( m.X >= 7031 && m.Y >= 648 && m.X <= 7039 && m.Y <= 655 ){ indoors = true; }
				else if ( m.X >= 7007 && m.Y >= 648 && m.X <= 7023 && m.Y <= 655 ){ indoors = true; }
				// DEATH GULCH
				else if ( m.X >= 3696 && m.Y >= 1557 && m.X <= 3704 && m.Y <= 1569 ){ indoors = true; }
				else if ( m.X >= 3759 && m.Y >= 1565 && m.X <= 3765 && m.Y <= 1571 ){ indoors = true; }
				else if ( m.X >= 3765 && m.Y >= 1562 && m.X <= 3778 && m.Y <= 1572 ){ indoors = true; }
				else if ( m.X >= 3762 && m.Y >= 1527 && m.X <= 3772 && m.Y <= 1533 ){ indoors = true; }
				else if ( m.X >= 3778 && m.Y >= 1494 && m.X <= 3783 && m.Y <= 1499 ){ indoors = true; }
				else if ( m.X >= 3783 && m.Y >= 1495 && m.X <= 3789 && m.Y <= 1504 ){ indoors = true; }
				else if ( m.X >= 3689 && m.Y >= 1514 && m.X <= 3692 && m.Y <= 1523 ){ indoors = true; }
				else if ( m.X >= 3689 && m.Y >= 1514 && m.X <= 3695 && m.Y <= 1517 ){ indoors = true; }
				// DEVIL GUARD
				else if ( m.X >= 1560 && m.Y >= 1398 && m.X <= 1569 && m.Y <= 1403 ){ indoors = true; }
				else if ( m.X >= 6588 && m.Y >= 3193 && m.X <= 6595 && m.Y <= 3199 ){ indoors = true; }
				else if ( m.X >= 6588 && m.Y >= 3193 && m.X <= 6591 && m.Y <= 3201 ){ indoors = true; }
				else if ( m.X >= 6608 && m.Y >= 3194 && m.X <= 6619 && m.Y <= 3202 ){ indoors = true; }
				else if ( m.X >= 1599 && m.Y >= 1463 && m.X <= 1609 && m.Y <= 1471 ){ indoors = true; }
				else if ( m.X >= 1605 && m.Y >= 1448 && m.X <= 1617 && m.Y <= 1458 ){ indoors = true; }
				else if ( m.X >= 1620 && m.Y >= 1449 && m.X <= 1631 && m.Y <= 1458 ){ indoors = true; }
				else if ( m.X >= 1663 && m.Y >= 1444 && m.X <= 1673 && m.Y <= 1458 ){ indoors = true; }
				else if ( m.X >= 1676 && m.Y >= 1449 && m.X <= 1689 && m.Y <= 1458 ){ indoors = true; }
				else if ( m.X >= 1711 && m.Y >= 1505 && m.X <= 1729 && m.Y <= 1517 ){ indoors = true; }
				else if ( m.X >= 1732 && m.Y >= 1505 && m.X <= 1739 && m.Y <= 1517 ){ indoors = true; }
				else if ( m.X >= 1714 && m.Y >= 1527 && m.X <= 1720 && m.Y <= 1536 ){ indoors = true; }
				else if ( m.X >= 1729 && m.Y >= 1526 && m.X <= 1738 && m.Y <= 1535 ){ indoors = true; }
				else if ( m.X >= 1633 && m.Y >= 1507 && m.X <= 1648 && m.Y <= 1523 ){ indoors = true; }
				// FAWN
				else if ( m.X >= 2076 && m.Y >= 247 && m.X <= 2089 && m.Y <= 257 ){ indoors = true; }
				else if ( m.X >= 2061 && m.Y >= 262 && m.X <= 2074 && m.Y <= 270 ){ indoors = true; }
				else if ( m.X >= 2094 && m.Y >= 247 && m.X <= 2107 && m.Y <= 258 ){ indoors = true; }
				else if ( m.X >= 2088 && m.Y >= 291 && m.X <= 2100 && m.Y <= 306 ){ indoors = true; }
				else if ( m.X >= 2113 && m.Y >= 247 && m.X <= 2119 && m.Y <= 257 ){ indoors = true; }
				else if ( m.X >= 2122 && m.Y >= 246 && m.X <= 2130 && m.Y <= 264 ){ indoors = true; }
				else if ( m.X >= 2088 && m.Y >= 291 && m.X <= 2100 && m.Y <= 306 ){ indoors = true; }
				else if ( m.X >= 2103 && m.Y >= 291 && m.X <= 2111 && m.Y <= 306 ){ indoors = true; }
				else if ( m.X >= 2103 && m.Y >= 291 && m.X <= 2117 && m.Y <= 298 ){ indoors = true; }
				else if ( m.X >= 2171 && m.Y >= 248 && m.X <= 2182 && m.Y <= 254 ){ indoors = true; }
				else if ( m.X >= 2159 && m.Y >= 254 && m.X <= 2169 && m.Y <= 268 ){ indoors = true; }
				else if ( m.X >= 2159 && m.Y >= 282 && m.X <= 2167 && m.Y <= 294 ){ indoors = true; }
				else if ( m.X >= 2141 && m.Y >= 298 && m.X <= 2154 && m.Y <= 305 ){ indoors = true; }
				else if ( m.X >= 2158 && m.Y >= 298 && m.X <= 2173 && m.Y <= 305 ){ indoors = true; }
				else if ( m.X >= 2180 && m.Y >= 268 && m.X <= 2187 && m.Y <= 279 ){ indoors = true; }
				else if ( m.X >= 2180 && m.Y >= 268 && m.X <= 2195 && m.Y <= 274 ){ indoors = true; }
				else if ( m.X >= 2195 && m.Y >= 268 && m.X <= 2204 && m.Y <= 284 ){ indoors = true; }
				// GLACIAL COAST
				else if ( m.X >= 4738 && m.Y >= 1151 && m.X <= 4746 && m.Y <= 1161 ){ indoors = true; }
				else if ( m.X >= 4738 && m.Y >= 1163 && m.X <= 4746 && m.Y <= 1174 ){ indoors = true; }
				else if ( m.X >= 4717 && m.Y >= 1170 && m.X <= 4723 && m.Y <= 1177 ){ indoors = true; }
				else if ( m.X >= 4723 && m.Y >= 1170 && m.X <= 4730 && m.Y <= 1183 ){ indoors = true; }
				else if ( m.X >= 4751 && m.Y >= 1167 && m.X <= 4763 && m.Y <= 1174 ){ indoors = true; }
				else if ( m.X >= 4734 && m.Y >= 1180 && m.X <= 4746 && m.Y <= 1188 ){ indoors = true; }
				else if ( m.X >= 4738 && m.Y >= 1190 && m.X <= 4746 && m.Y <= 1200 ){ indoors = true; }
				else if ( m.X >= 4751 && m.Y >= 1179 && m.X <= 4762 && m.Y <= 1194 ){ indoors = true; }
				else if ( m.X >= 4767 && m.Y >= 1179 && m.X <= 4789 && m.Y <= 1186 ){ indoors = true; }
				// GREY
				else if ( m.X >= 838 && m.Y >= 2014 && m.X <= 845 && m.Y <= 2028 ){ indoors = true; }
				else if ( m.X >= 831 && m.Y >= 2051 && m.X <= 837 && m.Y <= 2061 ){ indoors = true; }
				else if ( m.X >= 834 && m.Y >= 2066 && m.X <= 840 && m.Y <= 2078 ){ indoors = true; }
				else if ( m.X >= 865 && m.Y >= 2048 && m.X <= 876 && m.Y <= 2055 ){ indoors = true; }
				else if ( m.X >= 885 && m.Y >= 2048 && m.X <= 891 && m.Y <= 2057 ){ indoors = true; }
				else if ( m.X >= 895 && m.Y >= 2048 && m.X <= 901 && m.Y <= 2057 ){ indoors = true; }
				else if ( m.X >= 904 && m.Y >= 2042 && m.X <= 916 && m.Y <= 2051 ){ indoors = true; }
				else if ( m.X >= 920 && m.Y >= 2048 && m.X <= 929 && m.Y <= 2057 ){ indoors = true; }
				else if ( m.X >= 887 && m.Y >= 2067 && m.X <= 897 && m.Y <= 2073 ){ indoors = true; }
				else if ( m.X >= 887 && m.Y >= 2076 && m.X <= 897 && m.Y <= 2083 ){ indoors = true; }
				else if ( m.X >= 921 && m.Y >= 2072 && m.X <= 927 && m.Y <= 2080 ){ indoors = true; }
				else if ( m.X >= 921 && m.Y >= 2083 && m.X <= 927 && m.Y <= 2091 ){ indoors = true; }
				else if ( m.X >= 915 && m.Y >= 2094 && m.X <= 924 && m.Y <= 2102 ){ indoors = true; }
				else if ( m.X >= 905 && m.Y >= 2112 && m.X <= 912 && m.Y <= 2124 ){ indoors = true; }
				// ICELAD VILLAGE
				else if ( m.X >= 4322 && m.Y >= 1143 && m.X <= 4329 && m.Y <= 1152 ){ indoors = true; }
				else if ( m.X >= 4315 && m.Y >= 1158 && m.X <= 4321 && m.Y <= 1168 ){ indoors = true; }
				else if ( m.X >= 4327 && m.Y >= 1156 && m.X <= 4337 && m.Y <= 1162 ){ indoors = true; }
				else if ( m.X >= 4319 && m.Y >= 1172 && m.X <= 4325 && m.Y <= 1183 ){ indoors = true; }
				else if ( m.X >= 4325 && m.Y >= 1176 && m.X <= 4329 && m.Y <= 1183 ){ indoors = true; }
				else if ( m.X >= 4306 && m.Y >= 1170 && m.X <= 4315 && m.Y <= 1177 ){ indoors = true; }
				// MOUNTAIN CREST
				else if ( m.X >= 4498 && m.Y >= 1250 && m.X <= 4513 && m.Y <= 1256 ){ indoors = true; }
				else if ( m.X >= 4516 && m.Y >= 1245 && m.X <= 4523 && m.Y <= 1256 ){ indoors = true; }
				else if ( m.X >= 4526 && m.Y >= 1248 && m.X <= 4538 && m.Y <= 1256 ){ indoors = true; }
				else if ( m.X >= 4540 && m.Y >= 1252 && m.X <= 4547 && m.Y <= 1256 ){ indoors = true; }
				else if ( m.X >= 4529 && m.Y >= 1278 && m.X <= 4537 && m.Y <= 1287 ){ indoors = true; }
				else if ( m.X >= 4517 && m.Y >= 1278 && m.X <= 4527 && m.Y <= 1283 ){ indoors = true; }
				else if ( m.X >= 4517 && m.Y >= 1278 && m.X <= 4523 && m.Y <= 1287 ){ indoors = true; }
				else if ( m.X >= 4514 && m.Y >= 1264 && m.X <= 4528 && m.Y <= 1272 ){ indoors = true; }
				else if ( m.X >= 4503 && m.Y >= 1263 && m.X <= 4511 && m.Y <= 1272 ){ indoors = true; }
				else if ( m.X >= 4501 && m.Y >= 1277 && m.X <= 4511 && m.Y <= 1283 ){ indoors = true; }
				else if ( m.X >= 4501 && m.Y >= 1285 && m.X <= 4511 && m.Y <= 1291 ){ indoors = true; }
				// HOMES
				else if ( m.X >= 963 && m.Y >= 640 && m.X <= 971 && m.Y <= 652 ){ indoors = true; }
				else if ( m.X >= 941 && m.Y >= 629 && m.X <= 954 && m.Y <= 636 ){ indoors = true; }
				else if ( m.X >= 979 && m.Y >= 673 && m.X <= 992 && m.Y <= 681 ){ indoors = true; }
				else if ( m.X >= 1003 && m.Y >= 654 && m.X <= 1015 && m.Y <= 661 ){ indoors = true; }
				else if ( m.X >= 909 && m.Y >= 767 && m.X <= 915 && m.Y <= 779 ){ indoors = true; }
				else if ( m.X >= 907 && m.Y >= 787 && m.X <= 913 && m.Y <= 798 ){ indoors = true; }
				else if ( m.X >= 2991 && m.Y >= 1267 && m.X <= 3001 && m.Y <= 1274 ){ indoors = true; }
				else if ( m.X >= 2998 && m.Y >= 1274 && m.X <= 3001 && m.Y <= 1279 ){ indoors = true; }
				else if ( m.X >= 2961 && m.Y >= 1196 && m.X <= 2969 && m.Y <= 1208 ){ indoors = true; }
				else if ( m.X >= 2939 && m.Y >= 1185 && m.X <= 2952 && m.Y <= 1192 ){ indoors = true; }
				else if ( m.X >= 2813 && m.Y >= 999 && m.X <= 2819 && m.Y <= 1010 ){ indoors = true; }
				else if ( m.X >= 2816 && m.Y >= 980 && m.X <= 2821 && m.Y <= 991 ){ indoors = true; }
				else if ( m.X >= 2765 && m.Y >= 918 && m.X <= 2771 && m.Y <= 929 ){ indoors = true; }
				else if ( m.X >= 2774 && m.Y >= 900 && m.X <= 2786 && m.Y <= 912 ){ indoors = true; }
				else if ( m.X >= 2777 && m.Y >= 590 && m.X <= 2784 && m.Y <= 602 ){ indoors = true; }
				else if ( m.X >= 2791 && m.Y >= 588 && m.X <= 2802 && m.Y <= 594 ){ indoors = true; }
				else if ( m.X >= 2688 && m.Y >= 626 && m.X <= 2701 && m.Y <= 633 ){ indoors = true; }
				else if ( m.X >= 2678 && m.Y >= 593 && m.X <= 2686 && m.Y <= 611 ){ indoors = true; }
				else if ( m.X >= 2642 && m.Y >= 509 && m.X <= 2654 && m.Y <= 516 ){ indoors = true; }
				else if ( m.X >= 2618 && m.Y >= 512 && m.X <= 2628 && m.Y <= 527 ){ indoors = true; }
				else if ( m.X >= 2613 && m.Y >= 521 && m.X <= 2628 && m.Y <= 527 ){ indoors = true; }
				// MOON
				else if ( m.X >= 791 && m.Y >= 679 && m.X <= 806 && m.Y <= 687 ){ indoors = true; }
				else if ( m.X >= 784 && m.Y >= 697 && m.X <= 791 && m.Y <= 707 ){ indoors = true; }
				else if ( m.X >= 803 && m.Y >= 695 && m.X <= 814 && m.Y <= 700 ){ indoors = true; }
				else if ( m.X >= 810 && m.Y >= 714 && m.X <= 822 && m.Y <= 722 ){ indoors = true; }
				else if ( m.X >= 826 && m.Y >= 715 && m.X <= 837 && m.Y <= 722 ){ indoors = true; }
				else if ( m.X >= 801 && m.Y >= 741 && m.X <= 808 && m.Y <= 753 ){ indoors = true; }
				else if ( m.X >= 802 && m.Y >= 757 && m.X <= 808 && m.Y <= 768 ){ indoors = true; }
				else if ( m.X >= 826 && m.Y >= 715 && m.X <= 837 && m.Y <= 722 ){ indoors = true; }
				else if ( m.X >= 854 && m.Y >= 711 && m.X <= 860 && m.Y <= 722 ){ indoors = true; }
				else if ( m.X >= 842 && m.Y >= 732 && m.X <= 849 && m.Y <= 744 ){ indoors = true; }
				else if ( m.X >= 837 && m.Y >= 738 && m.X <= 849 && m.Y <= 744 ){ indoors = true; }
				else if ( m.X >= 843 && m.Y >= 682 && m.X <= 850 && m.Y <= 691 ){ indoors = true; }
				else if ( m.X >= 836 && m.Y >= 700 && m.X <= 849 && m.Y <= 706 ){ indoors = true; }
			}
			else if ( m.Map == Map.IslesDread )
			{
				// ISLES OF DREAD
				if ( m.X >= 6764 && m.Y >= 1712 && m.X <= 6775 && m.Y <= 1719 ){ indoors = true; }
				else if ( m.X >= 1223 && m.Y >= 175 && m.X <= 1239 && m.Y <= 183 ){ indoors = true; }
				else if ( m.X >= 1236 && m.Y >= 175 && m.X <= 1257 && m.Y <= 186 ){ indoors = true; }
				else if ( m.X >= 1255 && m.Y >= 173 && m.X <= 1264 && m.Y <= 182 ){ indoors = true; }
				else if ( m.X >= 1256 && m.Y >= 175 && m.X <= 1261 && m.Y <= 186 ){ indoors = true; }
				else if ( m.X >= 245 && m.Y >= 1149 && m.X <= 265 && m.Y <= 1169 ){ indoors = true; }
				else if ( m.X >= 248 && m.Y >= 1184 && m.X <= 263 && m.Y <= 1199 ){ indoors = true; }
				else if ( m.X >= 279 && m.Y >= 1167 && m.X <= 287 && m.Y <= 1183 ){ indoors = true; }
				else if ( m.X >= 283 && m.Y >= 1168 && m.X <= 295 && m.Y <= 1175 ){ indoors = true; }
				else if ( m.X >= 312 && m.Y >= 1184 && m.X <= 319 && m.Y <= 1199 ){ indoors = true; }
				else if ( m.X >= 304 && m.Y >= 1192 && m.X <= 319 && m.Y <= 1199 ){ indoors = true; }
				else if ( m.X >= 381 && m.Y >= 1205 && m.X <= 401 && m.Y <= 1225 ){ indoors = true; }
				else if ( m.X >= 325 && m.Y >= 1165 && m.X <= 345 && m.Y <= 1185 ){ indoors = true; }
				else if ( m.X >= 333 && m.Y >= 1144 && m.X <= 337 && m.Y <= 1168 && m.Z >= 13 ){ indoors = true; }
				else if ( m.X >= 325 && m.Y >= 1125 && m.X <= 343 && m.Y <= 1145 ){ indoors = true; }
				else if ( m.X >= 384 && m.Y >= 1138 && m.X <= 397 && m.Y <= 1151 ){ indoors = true; }
				else if ( m.X >= 253 && m.Y >= 1093 && m.X <= 273 && m.Y <= 1113 ){ indoors = true; }
				else if ( m.X >= 343 && m.Y >= 1063 && m.X <= 367 && m.Y <= 1071 ){ indoors = true; }
				else if ( m.X >= 310 && m.Y >= 1056 && m.X <= 329 && m.Y <= 1073 ){ indoors = true; }
				else if ( m.X >= 309 && m.Y >= 1029 && m.X <= 343 && m.Y <= 1055 ){ indoors = true; }
				else if ( m.X >= 343 && m.Y >= 1029 && m.X <= 374 && m.Y <= 1047 ){ indoors = true; }
				else if ( m.X >= 364 && m.Y >= 1029 && m.X <= 415 && m.Y <= 1055 ){ indoors = true; }
				else if ( m.X >= 399 && m.Y >= 1054 && m.X <= 415 && m.Y <= 1057 ){ indoors = true; }
				else if ( m.X >= 413 && m.Y >= 1029 && m.X <= 430 && m.Y <= 1031 ){ indoors = true; }
				else if ( m.X >= 429 && m.Y >= 1021 && m.X <= 446 && m.Y <= 1041 ){ indoors = true; }
				else if ( m.X >= 429 && m.Y >= 1021 && m.X <= 446 && m.Y <= 1039 ){ indoors = true; }
				else if ( m.X >= 440 && m.Y >= 1039 && m.X <= 446 && m.Y <= 1041 ){ indoors = true; }
				else if ( m.X >= 424 && m.Y >= 1032 && m.X <= 431 && m.Y <= 1039 ){ indoors = true; }
				else if ( m.X >= 440 && m.Y >= 1040 && m.X <= 441 && m.Y <= 1081 ){ indoors = true; }
				else if ( m.X >= 440 && m.Y >= 1070 && m.X <= 441 && m.Y <= 1161 ){ indoors = true; }
				else if ( m.X >= 415 && m.Y >= 1159 && m.X <= 441 && m.Y <= 1161 ){ indoors = true; }
				else if ( m.X >= 415 && m.Y >= 1159 && m.X <= 417 && m.Y <= 1169 ){ indoors = true; }
				else if ( m.X >= 397 && m.Y >= 1167 && m.X <= 417 && m.Y <= 1169 ){ indoors = true; }
				else if ( m.X >= 399 && m.Y >= 1149 && m.X <= 417 && m.Y <= 1151 ){ indoors = true; }
				else if ( m.X >= 397 && m.Y >= 1135 && m.X <= 399 && m.Y <= 1169 ){ indoors = true; }
				else if ( m.X >= 375 && m.Y >= 1135 && m.X <= 399 && m.Y <= 1137 ){ indoors = true; }
				else if ( m.X >= 365 && m.Y >= 1072 && m.X <= 367 && m.Y <= 1087 ){ indoors = true; }
				else if ( m.X >= 333 && m.Y >= 1085 && m.X <= 367 && m.Y <= 1087 ){ indoors = true; }
				else if ( m.X >= 333 && m.Y >= 1085 && m.X <= 351 && m.Y <= 1103 ){ indoors = true; }
				else if ( m.X >= 334 && m.Y >= 1103 && m.X <= 343 && m.Y <= 1105 ){ indoors = true; }
				else if ( m.X >= 341 && m.Y >= 1104 && m.X <= 351 && m.Y <= 1119 ){ indoors = true; }
				else if ( m.X >= 342 && m.Y >= 1114 && m.X <= 343 && m.Y <= 1125 ){ indoors = true; }
				else if ( m.X >= 367 && m.Y >= 1111 && m.X <= 375 && m.Y <= 1127 ){ indoors = true; }
				else if ( m.X >= 383 && m.Y >= 1111 && m.X <= 399 && m.Y <= 1127 ){ indoors = true; }
				else if ( m.X >= 408 && m.Y >= 1112 && m.X <= 415 && m.Y <= 1119 ){ indoors = true; }
				else if ( m.X >= 424 && m.Y >= 1104 && m.X <= 431 && m.Y <= 1111 ){ indoors = true; }
				else if ( m.X >= 423 && m.Y >= 1071 && m.X <= 439 && m.Y <= 1095 ){ indoors = true; }
				else if ( m.X >= 424 && m.Y >= 1048 && m.X <= 431 && m.Y <= 1063 ){ indoors = true; }
				else if ( m.X >= 376 && m.Y >= 1072 && m.X <= 391 && m.Y <= 1079 ){ indoors = true; }
			}
			else if ( m.Map == Map.Lodor )
			{
				// SKARA BRAE
				if ( m.X >= 7001 && m.Y >= 184 && m.X <= 7023 && m.Y <= 206 ){ indoors = true; }
				else if ( m.X >= 7005 && m.Y >= 180 && m.X <= 7046 && m.Y <= 184 ){ indoors = true; }
				else if ( m.X >= 7043 && m.Y >= 180 && m.X <= 7047 && m.Y <= 266 ){ indoors = true; }
				else if ( m.X >= 7000 && m.Y >= 262 && m.X <= 7047 && m.Y <= 266 ){ indoors = true; }
				else if ( m.X >= 7000 && m.Y >= 262 && m.X <= 7004 && m.Y <= 311 ){ indoors = true; }
				else if ( m.X >= 6861 && m.Y >= 307 && m.X <= 7004 && m.Y <= 311 ){ indoors = true; }
				else if ( m.X >= 6861 && m.Y >= 131 && m.X <= 6886 && m.Y <= 158 ){ indoors = true; }
				else if ( m.X >= 6861 && m.Y >= 155 && m.X <= 6865 && m.Y <= 311 ){ indoors = true; }
				else if ( m.X >= 6861 && m.Y >= 131 && m.X <= 7001 && m.Y <= 135 ){ indoors = true; }
				else if ( m.X >= 7001 && m.Y >= 131 && m.X <= 7013 && m.Y <= 184 ){ indoors = true; }
				else if ( m.X >= 6938 && m.Y >= 213 && m.X <= 6979 && m.Y <= 238 ){ indoors = true; }
				else if ( m.X >= 6947 && m.Y >= 282 && m.X <= 6957 && m.Y <= 288 ){ indoors = true; }
				else if ( m.X >= 6913 && m.Y >= 273 && m.X <= 6922 && m.Y <= 284 ){ indoors = true; }
				else if ( m.X >= 6912 && m.Y >= 237 && m.X <= 6922 && m.Y <= 256 ){ indoors = true; }
				else if ( m.X >= 6906 && m.Y >= 224 && m.X <= 6922 && m.Y <= 233 ){ indoors = true; }
				else if ( m.X >= 6883 && m.Y >= 224 && m.X <= 6897 && m.Y <= 233 ){ indoors = true; }
				else if ( m.X >= 6905 && m.Y >= 190 && m.X <= 6922 && m.Y <= 202 ){ indoors = true; }
				else if ( m.X >= 6897 && m.Y >= 150 && m.X <= 6905 && m.Y <= 162 ){ indoors = true; }
				else if ( m.X >= 6912 && m.Y >= 159 && m.X <= 6922 && m.Y <= 178 ){ indoors = true; }
				else if ( m.X >= 6940 && m.Y >= 146 && m.X <= 6957 && m.Y <= 155 ){ indoors = true; }
				else if ( m.X >= 6958 && m.Y >= 147 && m.X <= 6960 && m.Y <= 150 ){ indoors = true; }
				else if ( m.X >= 6954 && m.Y >= 177 && m.X <= 6964 && m.Y <= 197 ){ indoors = true; }
				else if ( m.X >= 6940 && m.Y >= 187 && m.X <= 6964 && m.Y <= 197 ){ indoors = true; }
				else if ( m.X >= 6985 && m.Y >= 181 && m.X <= 6996 && m.Y <= 197 ){ indoors = true; }
				// HOUSES
				else if ( m.X >= 5221 && m.Y >= 1188 && m.X <= 5226 && m.Y <= 1194 ){ indoors = true; }
				else if ( m.X >= 5230 && m.Y >= 1188 && m.X <= 5235 && m.Y <= 1194 ){ indoors = true; }
				else if ( m.X >= 5209 && m.Y >= 1211 && m.X <= 5225 && m.Y <= 1223 ){ indoors = true; }
				else if ( m.X >= 5226 && m.Y >= 1213 && m.X <= 5230 && m.Y <= 1220 ){ indoors = true; }
				else if ( m.X >= 5231 && m.Y >= 1214 && m.X <= 5232 && m.Y <= 1219 ){ indoors = true; }
				else if ( m.X >= 5248 && m.Y >= 1228 && m.X <= 5254 && m.Y <= 1238 ){ indoors = true; }
				else if ( m.X >= 5242 && m.Y >= 1231 && m.X <= 5248 && m.Y <= 1241 ){ indoors = true; }
				else if ( m.X >= 5246 && m.Y >= 1231 && m.X <= 5249 && m.Y <= 1238 ){ indoors = true; }
				else if ( m.X >= 2153 && m.Y >= 2769 && m.X <= 2169 && m.Y <= 2788 ){ indoors = true; }
				else if ( m.X >= 2123 && m.Y >= 2799 && m.X <= 2132 && m.Y <= 2806 ){ indoors = true; }
				else if ( m.X >= 2142 && m.Y >= 2792 && m.X <= 2149 && m.Y <= 2801 ){ indoors = true; }
				else if ( m.X >= 2149 && m.Y >= 2739 && m.X <= 2158 && m.Y <= 2746 ){ indoors = true; }
				else if ( m.X >= 2140 && m.Y >= 2749 && m.X <= 2147 && m.Y <= 2758 ){ indoors = true; }
				else if ( m.X >= 1149 && m.Y >= 2882 && m.X <= 1160 && m.Y <= 2889 ){ indoors = true; }
				else if ( m.X >= 1154 && m.Y >= 2876 && m.X <= 1156 && m.Y <= 2883 ){ indoors = true; }
				else if ( m.X >= 1153 && m.Y >= 2877 && m.X <= 1157 && m.Y <= 2880 ){ indoors = true; }
				else if ( m.X >= 2885 && m.Y >= 1097 && m.X <= 2890 && m.Y <= 1105 ){ indoors = true; }
				else if ( m.X >= 2891 && m.Y >= 1096 && m.X <= 2898 && m.Y <= 1114 ){ indoors = true; }
				else if ( m.X >= 2863 && m.Y >= 1103 && m.X <= 2868 && m.Y <= 1112 ){ indoors = true; }
				else if ( m.X >= 2762 && m.Y >= 1228 && m.X <= 2769 && m.Y <= 1242 ){ indoors = true; }
				else if ( m.X >= 1860 && m.Y >= 2393 && m.X <= 1878 && m.Y <= 2403 ){ indoors = true; }
				else if ( m.X >= 2087 && m.Y >= 2419 && m.X <= 2093 && m.Y <= 2427 ){ indoors = true; }
				else if ( m.X >= 2095 && m.Y >= 2420 && m.X <= 2106 && m.Y <= 2427 ){ indoors = true; }
				else if ( m.X >= 2101 && m.Y >= 2427 && m.X <= 2106 && m.Y <= 2434 ){ indoors = true; }
				else if ( m.X >= 2063 && m.Y >= 2037 && m.X <= 2069 && m.Y <= 2046 ){ indoors = true; }
				else if ( m.X >= 2106 && m.Y >= 2047 && m.X <= 2112 && m.Y <= 2061 ){ indoors = true; }
				else if ( m.X >= 2099 && m.Y >= 2054 && m.X <= 2112 && m.Y <= 2061 ){ indoors = true; }
				// DUSK
				else if ( m.X >= 2659 && m.Y >= 3169 && m.X <= 2672 && m.Y <= 3176 ){ indoors = true; }
				else if ( m.X >= 2679 && m.Y >= 3169 && m.X <= 2687 && m.Y <= 3185 ){ indoors = true; }
				else if ( m.X >= 2680 && m.Y >= 3179 && m.X <= 2696 && m.Y <= 3187 ){ indoors = true; }
				else if ( m.X >= 2687 && m.Y >= 3170 && m.X <= 2696 && m.Y <= 3179 ){ indoors = true; }
				else if ( m.X >= 2700 && m.Y >= 3181 && m.X <= 2708 && m.Y <= 3196 ){ indoors = true; }
				else if ( m.X >= 2665 && m.Y >= 3184 && m.X <= 2672 && m.Y <= 3196 ){ indoors = true; }
				else if ( m.X >= 2659 && m.Y >= 3202 && m.X <= 2672 && m.Y <= 3210 ){ indoors = true; }
				else if ( m.X >= 2654 && m.Y >= 3230 && m.X <= 2671 && m.Y <= 3238 ){ indoors = true; }
				else if ( m.X >= 2640 && m.Y >= 3193 && m.X <= 2646 && m.Y <= 3205 ){ indoors = true; }
				else if ( m.X >= 2640 && m.Y >= 3220 && m.X <= 2646 && m.Y <= 3235 ){ indoors = true; }
				else if ( m.X >= 2667 && m.Y >= 3247 && m.X <= 2670 && m.Y <= 3250 ){ indoors = true; }
				else if ( m.X >= 2680 && m.Y >= 3247 && m.X <= 2683 && m.Y <= 3250 ){ indoors = true; }
				else if ( m.X >= 2735 && m.Y >= 3192 && m.X <= 2738 && m.Y <= 3195 ){ indoors = true; }
				else if ( m.X >= 2735 && m.Y >= 3205 && m.X <= 2738 && m.Y <= 3208 ){ indoors = true; }
				else if ( m.X >= 2630 && m.Y >= 3171 && m.X <= 2633 && m.Y <= 3174 ){ indoors = true; }
				else if ( m.X >= 2642 && m.Y >= 3161 && m.X <= 2645 && m.Y <= 3164 ){ indoors = true; }
				// ELIDOR
				else if ( m.X >= 2952 && m.Y >= 1277 && m.X <= 2956 && m.Y <= 1281 ){ indoors = true; }
				else if ( m.X >= 2952 && m.Y >= 1244 && m.X <= 2956 && m.Y <= 1248 ){ indoors = true; }
				else if ( m.X >= 2940 && m.Y >= 1244 && m.X <= 2944 && m.Y <= 1248 ){ indoors = true; }
				else if ( m.X >= 2970 && m.Y >= 1329 && m.X <= 2974 && m.Y <= 1333 ){ indoors = true; }
				else if ( m.X >= 2970 && m.Y >= 1363 && m.X <= 2974 && m.Y <= 1367 ){ indoors = true; }
				else if ( m.X >= 2970 && m.Y >= 1375 && m.X <= 2974 && m.Y <= 1379 ){ indoors = true; }
				else if ( m.X >= 2884 && m.Y >= 1385 && m.X <= 2888 && m.Y <= 1389 ){ indoors = true; }
				else if ( m.X >= 2884 && m.Y >= 1373 && m.X <= 2888 && m.Y <= 1377 ){ indoors = true; }
				else if ( m.X >= 2930 && m.Y >= 1250 && m.X <= 2944 && m.Y <= 1260 ){ indoors = true; }
				else if ( m.X >= 2905 && m.Y >= 1256 && m.X <= 2912 && m.Y <= 1267 ){ indoors = true; }
				else if ( m.X >= 2906 && m.Y >= 1263 && m.X <= 2918 && m.Y <= 1269 ){ indoors = true; }
				else if ( m.X >= 2920 && m.Y >= 1257 && m.X <= 2928 && m.Y <= 1269 ){ indoors = true; }
				else if ( m.X >= 2890 && m.Y >= 1258 && m.X <= 2902 && m.Y <= 1269 ){ indoors = true; }
				else if ( m.X >= 2880 && m.Y >= 1257 && m.X <= 2888 && m.Y <= 1278 ){ indoors = true; }
				else if ( m.X >= 2876 && m.Y >= 1260 && m.X <= 2882 && m.Y <= 1266 ){ indoors = true; }
				else if ( m.X >= 2877 && m.Y >= 1279 && m.X <= 2888 && m.Y <= 1296 ){ indoors = true; }
				else if ( m.X >= 2897 && m.Y >= 1278 && m.X <= 2910 && m.Y <= 1291 ){ indoors = true; }
				else if ( m.X >= 2935 && m.Y >= 1278 && m.X <= 2945 && m.Y <= 1292 ){ indoors = true; }
				else if ( m.X >= 2963 && m.Y >= 1306 && m.X <= 2969 && m.Y <= 1314 ){ indoors = true; }
				else if ( m.X >= 2902 && m.Y >= 1298 && m.X <= 2914 && m.Y <= 1305 ){ indoors = true; }
				else if ( m.X >= 2914 && m.Y >= 1301 && m.X <= 2920 && m.Y <= 1304 ){ indoors = true; }
				else if ( m.X >= 2917 && m.Y >= 1297 && m.X <= 2941 && m.Y <= 1300 ){ indoors = true; }
				else if ( m.X >= 2917 && m.Y >= 1316 && m.X <= 2920 && m.Y <= 1319 ){ indoors = true; }
				else if ( m.X >= 2938 && m.Y >= 1316 && m.X <= 2941 && m.Y <= 1319 ){ indoors = true; }
				else if ( m.X >= 2920 && m.Y >= 1298 && m.X <= 2938 && m.Y <= 1318 ){ indoors = true; }
				else if ( m.X >= 2897 && m.Y >= 1313 && m.X <= 2912 && m.Y <= 1323 ){ indoors = true; }
				else if ( m.X >= 2873 && m.Y >= 1300 && m.X <= 2888 && m.Y <= 1308 ){ indoors = true; }
				else if ( m.X >= 2873 && m.Y >= 1300 && m.X <= 2883 && m.Y <= 1318 ){ indoors = true; }
				else if ( m.X >= 2874 && m.Y >= 1318 && m.X <= 2888 && m.Y <= 1326 ){ indoors = true; }
				else if ( m.X >= 2881 && m.Y >= 1331 && m.X <= 2888 && m.Y <= 1346 ){ indoors = true; }
				else if ( m.X >= 2918 && m.Y >= 1331 && m.X <= 2925 && m.Y <= 1337 ){ indoors = true; }
				else if ( m.X >= 2934 && m.Y >= 1332 && m.X <= 2949 && m.Y <= 1341 ){ indoors = true; }
				else if ( m.X >= 2954 && m.Y >= 1332 && m.X <= 2963 && m.Y <= 1352 ){ indoors = true; }
				else if ( m.X >= 2949 && m.Y >= 1355 && m.X <= 2963 && m.Y <= 1368 ){ indoors = true; }
				else if ( m.X >= 2935 && m.Y >= 1349 && m.X <= 2942 && m.Y <= 1360 ){ indoors = true; }
				else if ( m.X >= 2914 && m.Y >= 1361 && m.X <= 2925 && m.Y <= 1368 ){ indoors = true; }
				else if ( m.X >= 2898 && m.Y >= 1358 && m.X <= 2910 && m.Y <= 1368 ){ indoors = true; }
				else if ( m.X >= 2881 && m.Y >= 1353 && m.X <= 2888 && m.Y <= 1368 ){ indoors = true; }
				else if ( m.X >= 2865 && m.Y >= 1370 && m.X <= 2877 && m.Y <= 1377 ){ indoors = true; }
				else if ( m.X >= 2896 && m.Y >= 1383 && m.X <= 2904 && m.Y <= 1397 ){ indoors = true; }
				else if ( m.X >= 2904 && m.Y >= 1389 && m.X <= 2912 && m.Y <= 1397 ){ indoors = true; }
				else if ( m.X >= 2915 && m.Y >= 1390 && m.X <= 2925 && m.Y <= 1397 ){ indoors = true; }
				else if ( m.X >= 2942 && m.Y >= 1384 && m.X <= 2963 && m.Y <= 1390 ){ indoors = true; }
				else if ( m.X >= 2950 && m.Y >= 1390 && m.X <= 2963 && m.Y <= 1397 ){ indoors = true; }
				// GLACIAL HILLS
				else if ( m.X >= 3657 && m.Y >= 466 && m.X <= 3661 && m.Y <= 470 ){ indoors = true; }
				else if ( m.X >= 3671 && m.Y >= 466 && m.X <= 3675 && m.Y <= 470 ){ indoors = true; }
				else if ( m.X >= 3733 && m.Y >= 381 && m.X <= 3737 && m.Y <= 385 ){ indoors = true; }
				else if ( m.X >= 3733 && m.Y >= 395 && m.X <= 3737 && m.Y <= 399 ){ indoors = true; }
				else if ( m.X >= 3619 && m.Y >= 395 && m.X <= 3623 && m.Y <= 399 ){ indoors = true; }
				else if ( m.X >= 3619 && m.Y >= 381 && m.X <= 3623 && m.Y <= 385 ){ indoors = true; }
				else if ( m.X >= 3662 && m.Y >= 350 && m.X <= 3666 && m.Y <= 354 ){ indoors = true; }
				else if ( m.X >= 3648 && m.Y >= 350 && m.X <= 3652 && m.Y <= 354 ){ indoors = true; }
				else if ( m.X >= 3697 && m.Y >= 272 && m.X <= 3701 && m.Y <= 276 ){ indoors = true; }
				else if ( m.X >= 3711 && m.Y >= 271 && m.X <= 3725 && m.Y <= 278 ){ indoors = true; }
				else if ( m.X >= 3629 && m.Y >= 377 && m.X <= 3643 && m.Y <= 386 ){ indoors = true; }
				else if ( m.X >= 3648 && m.Y >= 372 && m.X <= 3659 && m.Y <= 386 ){ indoors = true; }
				else if ( m.X >= 3688 && m.Y >= 376 && m.X <= 3701 && m.Y <= 386 ){ indoors = true; }
				else if ( m.X >= 3712 && m.Y >= 394 && m.X <= 3720 && m.Y <= 406 ){ indoors = true; }
				else if ( m.X >= 3695 && m.Y >= 394 && m.X <= 3708 && m.Y <= 402 ){ indoors = true; }
				else if ( m.X >= 3678 && m.Y >= 394 && m.X <= 3688 && m.Y <= 401 ){ indoors = true; }
				else if ( m.X >= 3627 && m.Y >= 395 && m.X <= 3633 && m.Y <= 406 ){ indoors = true; }
				else if ( m.X >= 3621 && m.Y >= 410 && m.X <= 3632 && m.Y <= 426 ){ indoors = true; }
				else if ( m.X >= 3624 && m.Y >= 431 && m.X <= 3632 && m.Y <= 444 ){ indoors = true; }
				else if ( m.X >= 3624 && m.Y >= 439 && m.X <= 3637 && m.Y <= 446 ){ indoors = true; }
				else if ( m.X >= 3639 && m.Y >= 423 && m.X <= 3650 && m.Y <= 431 ){ indoors = true; }
				else if ( m.X >= 3653 && m.Y >= 418 && m.X <= 3662 && m.Y <= 431 ){ indoors = true; }
				else if ( m.X >= 3647 && m.Y >= 438 && m.X <= 3662 && m.Y <= 457 ){ indoors = true; }
				else if ( m.X >= 3670 && m.Y >= 404 && m.X <= 3678 && m.Y <= 412 ){ indoors = true; }
				else if ( m.X >= 3670 && m.Y >= 422 && m.X <= 3678 && m.Y <= 430 ){ indoors = true; }
				else if ( m.X >= 3669 && m.Y >= 440 && m.X <= 3684 && m.Y <= 451 ){ indoors = true; }
				else if ( m.X >= 3695 && m.Y >= 421 && m.X <= 3706 && m.Y <= 431 ){ indoors = true; }
				else if ( m.X >= 3689 && m.Y >= 440 && m.X <= 3704 && m.Y <= 451 ){ indoors = true; }
				else if ( m.X >= 3709 && m.Y >= 421 && m.X <= 3720 && m.Y <= 431 ){ indoors = true; }
				else if ( m.X >= 3703 && m.Y >= 411 && m.X <= 3720 && m.Y <= 418 ){ indoors = true; }
				// GREENSKY
				else if ( m.X >= 4236 && m.Y >= 2964 && m.X <= 4246 && m.Y <= 2970 ){ indoors = true; }
				else if ( m.X >= 4226 && m.Y >= 2985 && m.X <= 4239 && m.Y <= 2992 ){ indoors = true; }
				else if ( m.X >= 4233 && m.Y >= 2985 && m.X <= 4239 && m.Y <= 2998 ){ indoors = true; }
				else if ( m.X >= 4213 && m.Y >= 3010 && m.X <= 4219 && m.Y <= 3018 ){ indoors = true; }
				// ISLEGEM
				else if ( m.X >= 2802 && m.Y >= 2257 && m.X <= 2808 && m.Y <= 2263 ){ indoors = true; }
				else if ( m.X >= 2807 && m.Y >= 2210 && m.X <= 2814 && m.Y <= 2222 ){ indoors = true; }
				else if ( m.X >= 2817 && m.Y >= 2203 && m.X <= 2827 && m.Y <= 2208 ){ indoors = true; }
				else if ( m.X >= 2829 && m.Y >= 2202 && m.X <= 2835 && m.Y <= 2208 ){ indoors = true; }
				else if ( m.X >= 2820 && m.Y >= 2223 && m.X <= 2829 && m.Y <= 2236 ){ indoors = true; }
				else if ( m.X >= 2814 && m.Y >= 2240 && m.X <= 2829 && m.Y <= 2247 ){ indoors = true; }
				else if ( m.X >= 2842 && m.Y >= 2241 && m.X <= 2852 && m.Y <= 2248 ){ indoors = true; }
				else if ( m.X >= 2854 && m.Y >= 2242 && m.X <= 2860 && m.Y <= 2248 ){ indoors = true; }
				// WHISPER
				else if ( m.X >= 886 && m.Y >= 962 && m.X <= 893 && m.Y <= 968 ){ indoors = true; }
				else if ( m.X >= 878 && m.Y >= 973 && m.X <= 885 && m.Y <= 979 ){ indoors = true; }
				else if ( m.X >= 901 && m.Y >= 962 && m.X <= 907 && m.Y <= 969 ){ indoors = true; }
				else if ( m.X >= 894 && m.Y >= 982 && m.X <= 904 && m.Y <= 985 ){ indoors = true; }
				else if ( m.X >= 895 && m.Y >= 980 && m.X <= 902 && m.Y <= 985 ){ indoors = true; }
				else if ( m.X >= 897 && m.Y >= 979 && m.X <= 900 && m.Y <= 980 ){ indoors = true; }
				else if ( m.X >= 895 && m.Y >= 985 && m.X <= 902 && m.Y <= 987 ){ indoors = true; }
				else if ( m.X >= 897 && m.Y >= 987 && m.X <= 901 && m.Y <= 989 ){ indoors = true; }
				else if ( m.X >= 902 && m.Y >= 985 && m.X <= 903 && m.Y <= 988 ){ indoors = true; }
				else if ( m.X >= 904 && m.Y >= 983 && m.X <= 906 && m.Y <= 987 ){ indoors = true; }
				else if ( m.X >= 888 && m.Y >= 935 && m.X <= 902 && m.Y <= 943 ){ indoors = true; }
				else if ( m.X >= 902 && m.Y >= 935 && m.X <= 904 && m.Y <= 940 ){ indoors = true; }
				else if ( m.X >= 881 && m.Y >= 918 && m.X <= 888 && m.Y <= 924 ){ indoors = true; }
				else if ( m.X >= 902 && m.Y >= 890 && m.X <= 913 && m.Y <= 895 ){ indoors = true; }
				else if ( m.X >= 904 && m.Y >= 889 && m.X <= 913 && m.Y <= 895 ){ indoors = true; }
				else if ( m.X >= 887 && m.Y >= 898 && m.X <= 900 && m.Y <= 904 ){ indoors = true; }
				else if ( m.X >= 868 && m.Y >= 912 && m.X <= 874 && m.Y <= 920 ){ indoors = true; }
				else if ( m.X >= 869 && m.Y >= 910 && m.X <= 874 && m.Y <= 916 ){ indoors = true; }
				else if ( m.X >= 858 && m.Y >= 925 && m.X <= 864 && m.Y <= 933 ){ indoors = true; }
				else if ( m.X >= 864 && m.Y >= 932 && m.X <= 869 && m.Y <= 933 ){ indoors = true; }
				else if ( m.X >= 853 && m.Y >= 938 && m.X <= 870 && m.Y <= 957 ){ indoors = true; }
				else if ( m.X >= 807 && m.Y >= 920 && m.X <= 845 && m.Y <= 965 ){ indoors = true; }
				else if ( m.X >= 840 && m.Y >= 945 && m.X <= 853 && m.Y <= 953 ){ indoors = true; }
				// STARGUIDE
				else if ( m.X >= 2373 && m.Y >= 3165 && m.X <= 2376 && m.Y <= 3168 ){ indoors = true; }
				else if ( m.X >= 2299 && m.Y >= 3165 && m.X <= 2302 && m.Y <= 3168 ){ indoors = true; }
				else if ( m.X >= 2299 && m.Y >= 3151 && m.X <= 2302 && m.Y <= 3154 ){ indoors = true; }
				else if ( m.X >= 2325 && m.Y >= 3129 && m.X <= 2330 && m.Y <= 3138 ){ indoors = true; }
				else if ( m.X >= 2338 && m.Y >= 3129 && m.X <= 2344 && m.Y <= 3138 ){ indoors = true; }
				else if ( m.X >= 2340 && m.Y >= 3132 && m.X <= 2351 && m.Y <= 3138 ){ indoors = true; }
				else if ( m.X >= 2338 && m.Y >= 3146 && m.X <= 2344 && m.Y <= 3155 ){ indoors = true; }
				else if ( m.X >= 2353 && m.Y >= 3164 && m.X <= 2358 && m.Y <= 3173 ){ indoors = true; }
				else if ( m.X >= 2359 && m.Y >= 3164 && m.X <= 2365 && m.Y <= 3173 ){ indoors = true; }
				else if ( m.X >= 2364 && m.Y >= 3150 && m.X <= 2372 && m.Y <= 3155 ){ indoors = true; }
				else if ( m.X >= 2321 && m.Y >= 3164 && m.X <= 2330 && m.Y <= 3170 ){ indoors = true; }
				else if ( m.X >= 2321 && m.Y >= 3149 && m.X <= 2330 && m.Y <= 3155 ){ indoors = true; }
				else if ( m.X >= 2299 && m.Y >= 3133 && m.X <= 2303 && m.Y <= 3138 ){ indoors = true; }
				else if ( m.X >= 2306 && m.Y >= 3127 && m.X <= 2310 && m.Y <= 3132 ){ indoors = true; }
				// SPRINGVALE
				else if ( m.X >= 4247 && m.Y >= 1490 && m.X <= 4250 && m.Y <= 1493 ){ indoors = true; }
				else if ( m.X >= 4261 && m.Y >= 1490 && m.X <= 4264 && m.Y <= 1493 ){ indoors = true; }
				else if ( m.X >= 4291 && m.Y >= 1490 && m.X <= 4294 && m.Y <= 1493 ){ indoors = true; }
				else if ( m.X >= 4291 && m.Y >= 1476 && m.X <= 4294 && m.Y <= 1479 ){ indoors = true; }
				else if ( m.X >= 4170 && m.Y >= 1487 && m.X <= 4173 && m.Y <= 1490 ){ indoors = true; }
				else if ( m.X >= 4186 && m.Y >= 1406 && m.X <= 4189 && m.Y <= 1409 ){ indoors = true; }
				else if ( m.X >= 4172 && m.Y >= 1406 && m.X <= 4175 && m.Y <= 1409 ){ indoors = true; }
				else if ( m.X >= 4168 && m.Y >= 1425 && m.X <= 4177 && m.Y <= 1441 ){ indoors = true; }
				else if ( m.X >= 4167 && m.Y >= 1469 && m.X <= 4177 && m.Y <= 1481 ){ indoors = true; }
				else if ( m.X >= 4184 && m.Y >= 1472 && m.X <= 4197 && m.Y <= 1481 ){ indoors = true; }
				else if ( m.X >= 4186 && m.Y >= 1445 && m.X <= 4198 && m.Y <= 1453 ){ indoors = true; }
				else if ( m.X >= 4184 && m.Y >= 1420 && m.X <= 4197 && m.Y <= 1429 ){ indoors = true; }
				else if ( m.X >= 4203 && m.Y >= 1417 && m.X <= 4212 && m.Y <= 1429 ){ indoors = true; }
				else if ( m.X >= 4201 && m.Y >= 1441 && m.X <= 4213 && m.Y <= 1453 ){ indoors = true; }
				else if ( m.X >= 4206 && m.Y >= 1448 && m.X <= 4214 && m.Y <= 1454 ){ indoors = true; }
				else if ( m.X >= 4217 && m.Y >= 1443 && m.X <= 4237 && m.Y <= 1453 ){ indoors = true; }
				else if ( m.X >= 4238 && m.Y >= 1416 && m.X <= 4257 && m.Y <= 1429 ){ indoors = true; }
				else if ( m.X >= 4242 && m.Y >= 1436 && m.X <= 4252 && m.Y <= 1451 ){ indoors = true; }
				else if ( m.X >= 4243 && m.Y >= 1465 && m.X <= 4252 && m.Y <= 1481 ){ indoors = true; }
				else if ( m.X >= 4227 && m.Y >= 1471 && m.X <= 4240 && m.Y <= 1481 ){ indoors = true; }
				else if ( m.X >= 4210 && m.Y >= 1461 && m.X <= 4219 && m.Y <= 1481 ){ indoors = true; }
				// RAVENDARK
				else if ( m.X >= 6759 && m.Y >= 3631 && m.X <= 6786 && m.Y <= 3647 ){ indoors = true; }
				else if ( m.X >= 6813 && m.Y >= 3653 && m.X <= 6819 && m.Y <= 3659 ){ indoors = true; }
				else if ( m.X >= 6826 && m.Y >= 3653 && m.X <= 6832 && m.Y <= 3659 ){ indoors = true; }
				else if ( m.X >= 6813 && m.Y >= 3668 && m.X <= 6819 && m.Y <= 3674 ){ indoors = true; }
				else if ( m.X >= 6826 && m.Y >= 3668 && m.X <= 6832 && m.Y <= 3674 ){ indoors = true; }
				else if ( m.X >= 6814 && m.Y >= 3659 && m.X <= 6831 && m.Y <= 3670 ){ indoors = true; }
				else if ( m.X >= 6831 && m.Y >= 3662 && m.X <= 6832 && m.Y <= 3665 ){ indoors = true; }
				else if ( m.X >= 6815 && m.Y >= 3677 && m.X <= 6818 && m.Y <= 3681 ){ indoors = true; }
				else if ( m.X >= 6815 && m.Y >= 3683 && m.X <= 6819 && m.Y <= 3689 ){ indoors = true; }
				else if ( m.X >= 6816 && m.Y >= 3669 && m.X <= 6838 && m.Y <= 3695 ){ indoors = true; }
				else if ( m.X >= 6816 && m.Y >= 3688 && m.X <= 6824 && m.Y <= 3689 ){ indoors = true; }
				else if ( m.X >= 6816 && m.Y >= 3690 && m.X <= 6819 && m.Y <= 3708 ){ indoors = true; }
				else if ( m.X >= 6817 && m.Y >= 3691 && m.X <= 6829 && m.Y <= 3706 ){ indoors = true; }
				else if ( m.X >= 6822 && m.Y >= 3706 && m.X <= 6825 && m.Y <= 3708 ){ indoors = true; }
				else if ( m.X >= 6828 && m.Y >= 3705 && m.X <= 6831 && m.Y <= 3708 ){ indoors = true; }
				else if ( m.X >= 6824 && m.Y >= 3690 && m.X <= 6830 && m.Y <= 3705 ){ indoors = true; }
				else if ( m.X >= 6829 && m.Y >= 3699 && m.X <= 6831 && m.Y <= 3702 ){ indoors = true; }
				else if ( m.X >= 6836 && m.Y >= 3693 && m.X <= 6839 && m.Y <= 3696 ){ indoors = true; }
				else if ( m.X >= 6828 && m.Y >= 3694 && m.X <= 6833 && m.Y <= 3696 ){ indoors = true; }
				else if ( m.X >= 6832 && m.Y >= 3693 && m.X <= 6836 && m.Y <= 3695 ){ indoors = true; }
				else if ( m.X >= 6836 && m.Y >= 3682 && m.X <= 6838 && m.Y <= 3693 ){ indoors = true; }
				else if ( m.X >= 6837 && m.Y >= 3687 && m.X <= 6839 && m.Y <= 3690 ){ indoors = true; }
				else if ( m.X >= 6837 && m.Y >= 3681 && m.X <= 6839 && m.Y <= 3684 ){ indoors = true; }
				else if ( m.X >= 6837 && m.Y >= 3675 && m.X <= 6840 && m.Y <= 3680 ){ indoors = true; }
				else if ( m.X >= 6825 && m.Y >= 3718 && m.X <= 6832 && m.Y <= 3722 ){ indoors = true; }
				else if ( m.X >= 6786 && m.Y >= 3732 && m.X <= 6793 && m.Y <= 3738 ){ indoors = true; }
				else if ( m.X >= 6752 && m.Y >= 3753 && m.X <= 6758 && m.Y <= 3759 ){ indoors = true; }
				else if ( m.X >= 6750 && m.Y >= 3741 && m.X <= 6758 && m.Y <= 3747 ){ indoors = true; }
				else if ( m.X >= 6738 && m.Y >= 3745 && m.X <= 6745 && m.Y <= 3755 ){ indoors = true; }
				else if ( m.X >= 6703 && m.Y >= 3750 && m.X <= 6710 && m.Y <= 3755 ){ indoors = true; }
				else if ( m.X >= 6705 && m.Y >= 3742 && m.X <= 6710 && m.Y <= 3751 ){ indoors = true; }
				else if ( m.X >= 6707 && m.Y >= 3741 && m.X <= 6714 && m.Y <= 3750 ){ indoors = true; }
				else if ( m.X >= 6707 && m.Y >= 3742 && m.X <= 6716 && m.Y <= 3749 ){ indoors = true; }
				else if ( m.X >= 6736 && m.Y >= 3692 && m.X <= 6746 && m.Y <= 3707 ){ indoors = true; }
				else if ( m.X >= 6728 && m.Y >= 3708 && m.X <= 6735 && m.Y <= 3716 ){ indoors = true; }
				else if ( m.X >= 6735 && m.Y >= 3708 && m.X <= 6740 && m.Y <= 3714 ){ indoors = true; }
				else if ( m.X >= 6763 && m.Y >= 3669 && m.X <= 6771 && m.Y <= 3676 ){ indoors = true; }
				else if ( m.X >= 6769 && m.Y >= 3670 && m.X <= 6773 && m.Y <= 3673 ){ indoors = true; }
				else if ( m.X >= 6749 && m.Y >= 3691 && m.X <= 6758 && m.Y <= 3699 ){ indoors = true; }
				else if ( m.X >= 6758 && m.Y >= 3699 && m.X <= 6764 && m.Y <= 3707 ){ indoors = true; }
				else if ( m.X >= 6755 && m.Y >= 3700 && m.X <= 6761 && m.Y <= 3707 ){ indoors = true; }
				else if ( m.X >= 6752 && m.Y >= 3707 && m.X <= 6761 && m.Y <= 3716 ){ indoors = true; }
				else if ( m.X >= 6755 && m.Y >= 3717 && m.X <= 6764 && m.Y <= 3725 ){ indoors = true; }
				else if ( m.X >= 6788 && m.Y >= 3690 && m.X <= 6807 && m.Y <= 3702 ){ indoors = true; }
				else if ( m.X >= 6796 && m.Y >= 3701 && m.X <= 6803 && m.Y <= 3709 ){ indoors = true; }
				else if ( m.X >= 6775 && m.Y >= 3709 && m.X <= 6787 && m.Y <= 3723 ){ indoors = true; }
				else if ( m.X >= 6788 && m.Y >= 3713 && m.X <= 6789 && m.Y <= 3719 ){ indoors = true; }
				else if ( m.X >= 6819 && m.Y >= 3655 && m.X <= 6830 && m.Y <= 3663 ){ indoors = true; }
				else if ( m.X >= 6819 && m.Y >= 3655 && m.X <= 6830 && m.Y <= 3663 ){ indoors = true; }
				else if ( m.X >= 6735 && m.Y >= 3776 && m.X <= 6743 && m.Y <= 3786 ){ indoors = true; }
				else if ( m.X >= 6736 && m.Y >= 3786 && m.X <= 6742 && m.Y <= 3791 ){ indoors = true; }
				// PORTSHINE
				else if ( m.X >= 817 && m.Y >= 1990 && m.X <= 825 && m.Y <= 1997 ){ indoors = true; }
				else if ( m.X >= 818 && m.Y >= 1995 && m.X <= 823 && m.Y <= 2002 ){ indoors = true; }
				else if ( m.X >= 824 && m.Y >= 1989 && m.X <= 830 && m.Y <= 1995 ){ indoors = true; }
				else if ( m.X >= 837 && m.Y >= 1984 && m.X <= 842 && m.Y <= 1995 ){ indoors = true; }
				else if ( m.X >= 841 && m.Y >= 1989 && m.X <= 846 && m.Y <= 1995 ){ indoors = true; }
				else if ( m.X >= 849 && m.Y >= 2017 && m.X <= 859 && m.Y <= 2023 ){ indoors = true; }
				else if ( m.X >= 832 && m.Y >= 2030 && m.X <= 842 && m.Y <= 2036 ){ indoors = true; }
				// LODORIA CASTLE
				else if ( m.X >= 1763 && m.Y >= 2199 && m.X <= 1794 && m.Y <= 2224 ){ indoors = true; }
				else if ( m.X >= 1791 && m.Y >= 2199 && m.X <= 1798 && m.Y <= 2206 ){ indoors = true; }
				else if ( m.X >= 1791 && m.Y >= 2224 && m.X <= 1798 && m.Y <= 2231 ){ indoors = true; }
				// LODORIA VILLAGE
				else if ( m.X >= 2019 && m.Y >= 2159 && m.X <= 2026 && m.Y <= 2165 ){ indoors = true; }
				else if ( m.X >= 2040 && m.Y >= 2168 && m.X <= 2047 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 2049 && m.Y >= 2155 && m.X <= 2056 && m.Y <= 2166 ){ indoors = true; }
				else if ( m.X >= 2056 && m.Y >= 2159 && m.X <= 2064 && m.Y <= 2166 ){ indoors = true; }
				else if ( m.X >= 2072 && m.Y >= 2159 && m.X <= 2084 && m.Y <= 2166 ){ indoors = true; }
				else if ( m.X >= 2086 && m.Y >= 2144 && m.X <= 2093 && m.Y <= 2156 ){ indoors = true; }
				else if ( m.X >= 2100 && m.Y >= 2150 && m.X <= 2112 && m.Y <= 2156 ){ indoors = true; }
				else if ( m.X >= 2100 && m.Y >= 2164 && m.X <= 2107 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 2071 && m.Y >= 2176 && m.X <= 2084 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 2072 && m.Y >= 2191 && m.X <= 2084 && m.Y <= 2197 ){ indoors = true; }
				else if ( m.X >= 2077 && m.Y >= 2202 && m.X <= 2084 && m.Y <= 2212 ){ indoors = true; }
				else if ( m.X >= 2058 && m.Y >= 2206 && m.X <= 2071 && m.Y <= 2212 ){ indoors = true; }
				else if ( m.X >= 2040 && m.Y >= 2169 && m.X <= 2047 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 2054 && m.Y >= 2177 && m.X <= 2067 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 2038 && m.Y >= 2247 && m.X <= 2045 && m.Y <= 2253 ){ indoors = true; }
				else if ( m.X >= 1975 && m.Y >= 2223 && m.X <= 2001 && m.Y <= 2247 ){ indoors = true; }
				else if ( m.X >= 1983 && m.Y >= 2201 && m.X <= 2020 && m.Y <= 2247 ){ indoors = true; }
				else if ( m.X >= 2014 && m.Y >= 2244 && m.X <= 2020 && m.Y <= 2249 ){ indoors = true; }
				else if ( m.X >= 2015 && m.Y >= 2216 && m.X <= 2032 && m.Y <= 2240 ){ indoors = true; }
				else if ( m.X >= 2025 && m.Y >= 2222 && m.X <= 2038 && m.Y <= 2230 ){ indoors = true; }
				else if ( m.X >= 2008 && m.Y >= 2201 && m.X <= 2032 && m.Y <= 2225 ){ indoors = true; }
				// LODORIA CITY
				else if ( m.X >= 1937 && m.Y >= 2130 && m.X <= 1945 && m.Y <= 2145 ){ indoors = true; }
				else if ( m.X >= 1903 && m.Y >= 2136 && m.X <= 1907 && m.Y <= 2140 ){ indoors = true; }
				else if ( m.X >= 1901 && m.Y >= 2144 && m.X <= 1908 && m.Y <= 2158 ){ indoors = true; }
				else if ( m.X >= 1894 && m.Y >= 2151 && m.X <= 1908 && m.Y <= 2158 ){ indoors = true; }
				else if ( m.X >= 1916 && m.Y >= 2158 && m.X <= 1920 && m.Y <= 2162 ){ indoors = true; }
				else if ( m.X >= 1888 && m.Y >= 2136 && m.X <= 1898 && m.Y <= 2150 ){ indoors = true; }
				else if ( m.X >= 1877 && m.Y >= 2146 && m.X <= 1890 && m.Y <= 2158 ){ indoors = true; }
				else if ( m.X >= 1851 && m.Y >= 2161 && m.X <= 1859 && m.Y <= 2178 ){ indoors = true; }
				else if ( m.X >= 1850 && m.Y >= 2185 && m.X <= 1854 && m.Y <= 2189 ){ indoors = true; }
				else if ( m.X >= 1845 && m.Y >= 2196 && m.X <= 1858 && m.Y <= 2203 ){ indoors = true; }
				else if ( m.X >= 1870 && m.Y >= 2182 && m.X <= 1879 && m.Y <= 2193 ){ indoors = true; }
				else if ( m.X >= 1863 && m.Y >= 2197 && m.X <= 1878 && m.Y <= 2203 ){ indoors = true; }
				else if ( m.X >= 1884 && m.Y >= 2177 && m.X <= 1894 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 1899 && m.Y >= 2176 && m.X <= 1908 && m.Y <= 2183 ){ indoors = true; }
				else if ( m.X >= 1885 && m.Y >= 2196 && m.X <= 1897 && m.Y <= 2204 ){ indoors = true; }
				else if ( m.X >= 1901 && m.Y >= 2192 && m.X <= 1908 && m.Y <= 2203 ){ indoors = true; }
				else if ( m.X >= 1916 && m.Y >= 2177 && m.X <= 1930 && m.Y <= 2184 ){ indoors = true; }
				else if ( m.X >= 1920 && m.Y >= 2191 && m.X <= 1935 && m.Y <= 2197 ){ indoors = true; }
				else if ( m.X >= 1929 && m.Y >= 2198 && m.X <= 1935 && m.Y <= 2205 ){ indoors = true; }
				else if ( m.X >= 1927 && m.Y >= 2223 && m.X <= 1936 && m.Y <= 2235 ){ indoors = true; }
				else if ( m.X >= 1943 && m.Y >= 2213 && m.X <= 1949 && m.Y <= 2234 ){ indoors = true; }
				else if ( m.X >= 1914 && m.Y >= 2241 && m.X <= 1920 && m.Y <= 2255 ){ indoors = true; }
				else if ( m.X >= 1923 && m.Y >= 2247 && m.X <= 1936 && m.Y <= 2256 ){ indoors = true; }
				else if ( m.X >= 1885 && m.Y >= 2273 && m.X <= 1896 && m.Y <= 2279 ){ indoors = true; }
				else if ( m.X >= 1899 && m.Y >= 2266 && m.X <= 1906 && m.Y <= 2279 ){ indoors = true; }
				else if ( m.X >= 1927 && m.Y >= 2223 && m.X <= 1936 && m.Y <= 2235 ){ indoors = true; }
				else if ( m.X >= 1902 && m.Y >= 2227 && m.X <= 1917 && m.Y <= 2235 ){ indoors = true; }
				else if ( m.X >= 1898 && m.Y >= 2241 && m.X <= 1906 && m.Y <= 2257 ){ indoors = true; }
				else if ( m.X >= 1890 && m.Y >= 2249 && m.X <= 1906 && m.Y <= 2257 ){ indoors = true; }
				else if ( m.X >= 1891 && m.Y >= 2219 && m.X <= 1899 && m.Y <= 2235 ){ indoors = true; }
				else if ( m.X >= 1885 && m.Y >= 2227 && m.X <= 1899 && m.Y <= 2235 ){ indoors = true; }
				else if ( m.X >= 1863 && m.Y >= 2242 && m.X <= 1878 && m.Y <= 2258 ){ indoors = true; }
				else if ( m.X >= 1871 && m.Y >= 2267 && m.X <= 1878 && m.Y <= 2281 ){ indoors = true; }
				else if ( m.X >= 1832 && m.Y >= 2237 && m.X <= 1838 && m.Y <= 2254 ){ indoors = true; }
				else if ( m.X >= 1846 && m.Y >= 2227 && m.X <= 1858 && m.Y <= 2234 ){ indoors = true; }
				else if ( m.X >= 1843 && m.Y >= 2289 && m.X <= 1948 && m.Y <= 2291 && m.Z >= 18 ){ indoors = true; }
				else if ( m.X >= 1855 && m.Y >= 2120 && m.X <= 1958 && m.Y <= 2123 && m.Z >= 18 ){ indoors = true; }
				else if ( m.X >= 1956 && m.Y >= 2119 && m.X <= 1959 && m.Y <= 2256 && m.Z >= 18 ){ indoors = true; }
				else if ( m.X >= 1945 && m.Y >= 2253 && m.X <= 1959 && m.Y <= 2256 && m.Z >= 18 ){ indoors = true; }
				else if ( m.X >= 1945 && m.Y >= 2253 && m.X <= 1947 && m.Y <= 2292 && m.Z >= 18 ){ indoors = true; }
			}
			else if ( m.Map == Map.SerpentIsland )
			{
				if ( m.X >= 2259 && m.Y >= 1655 && m.X <= 2267 && m.Y <= 1666 ){ indoors = true; }
				else if ( m.X >= 2255 && m.Y >= 1661 && m.X <= 2267 && m.Y <= 1666 ){ indoors = true; }
				else if ( m.X >= 2286 && m.Y >= 1654 && m.X <= 2297 && m.Y <= 1666 ){ indoors = true; }
				else if ( m.X >= 2268 && m.Y >= 1673 && m.X <= 2278 && m.Y <= 1680 ){ indoors = true; }
				else if ( m.X >= 2268 && m.Y >= 1673 && m.X <= 2272 && m.Y <= 1690 ){ indoors = true; }
				else if ( m.X >= 2294 && m.Y >= 1675 && m.X <= 2305 && m.Y <= 1685 ){ indoors = true; }
				else if ( m.X >= 2270 && m.Y >= 1697 && m.X <= 2279 && m.Y <= 1706 ){ indoors = true; }
				else if ( m.X >= 2280 && m.Y >= 1713 && m.X <= 2294 && m.Y <= 1722 ){ indoors = true; }
				else if ( m.X >= 2274 && m.Y >= 1732 && m.X <= 2288 && m.Y <= 1741 ){ indoors = true; }
				else if ( m.X >= 2304 && m.Y >= 1704 && m.X <= 2316 && m.Y <= 1717 ){ indoors = true; }
				else if ( m.X >= 2270 && m.Y >= 1697 && m.X <= 2279 && m.Y <= 1706 ){ indoors = true; }
				else if ( m.X >= 2248 && m.Y >= 1697 && m.X <= 2263 && m.Y <= 1706 ){ indoors = true; }
				else if ( m.X >= 2228 && m.Y >= 1697 && m.X <= 2241 && m.Y <= 1707 ){ indoors = true; }
				else if ( m.X >= 2235 && m.Y >= 1713 && m.X <= 2248 && m.Y <= 1725 ){ indoors = true; }
				else if ( m.X >= 2244 && m.Y >= 1734 && m.X <= 2258 && m.Y <= 1742 ){ indoors = true; }
				else if ( m.X >= 2228 && m.Y >= 1735 && m.X <= 2236 && m.Y <= 1744 ){ indoors = true; }
				else if ( m.X >= 2190 && m.Y >= 1662 && m.X <= 2212 && m.Y <= 1676 ){ indoors = true; }
			}
			else if ( m.Map == Map.SavagedEmpire )
			{
				if ( m.X >= 767 && m.Y >= 311 && m.X <= 799 && m.Y <= 327 ){ indoors = true; }
				else if ( m.X >= 776 && m.Y >= 327 && m.X <= 791 && m.Y <= 335 ){ indoors = true; }
				else if ( m.X >= 212 && m.Y >= 1657 && m.X <= 219 && m.Y <= 1667 ){ indoors = true; }
				else if ( m.X >= 238 && m.Y >= 1705 && m.X <= 247 && m.Y <= 1711 ){ indoors = true; }
				else if ( m.X >= 228 && m.Y >= 1710 && m.X <= 239 && m.Y <= 1721 ){ indoors = true; }
				else if ( m.X >= 245 && m.Y >= 1717 && m.X <= 253 && m.Y <= 1731 ){ indoors = true; }
				else if ( m.X >= 306 && m.Y >= 1699 && m.X <= 319 && m.Y <= 1704 ){ indoors = true; }
				else if ( m.X >= 306 && m.Y >= 1699 && m.X <= 311 && m.Y <= 1707 ){ indoors = true; }
				else if ( m.X >= 287 && m.Y >= 1643 && m.X <= 297 && m.Y <= 1654 ){ indoors = true; }
				else if ( m.X >= 273 && m.Y >= 1634 && m.X <= 286 && m.Y <= 1652 ){ indoors = true; }
				else if ( m.X >= 285 && m.Y >= 1638 && m.X <= 294 && m.Y <= 1643 ){ indoors = true; }
				else if ( m.X >= 670 && m.Y >= 847 && m.X <= 685 && m.Y <= 858 ){ indoors = true; }
				else if ( m.X >= 773 && m.Y >= 854 && m.X <= 803 && m.Y <= 877 ){ indoors = true; }
				else if ( m.X >= 758 && m.Y >= 893 && m.X <= 777 && m.Y <= 904 ){ indoors = true; }
				else if ( m.X >= 758 && m.Y >= 893 && m.X <= 765 && m.Y <= 912 ){ indoors = true; }
				else if ( m.X >= 740 && m.Y >= 888 && m.X <= 752 && m.Y <= 891 ){ indoors = true; }
				else if ( m.X >= 739 && m.Y >= 891 && m.X <= 755 && m.Y <= 903 ){ indoors = true; }
				else if ( m.X >= 740 && m.Y >= 900 && m.X <= 751 && m.Y <= 906 ){ indoors = true; }
				else if ( m.X >= 724 && m.Y >= 900 && m.X <= 734 && m.Y <= 911 ){ indoors = true; }
				else if ( m.X >= 723 && m.Y >= 908 && m.X <= 734 && m.Y <= 911 ){ indoors = true; }
				else if ( m.X >= 747 && m.Y >= 919 && m.X <= 755 && m.Y <= 931 ){ indoors = true; }
				else if ( m.X >= 703 && m.Y >= 908 && m.X <= 718 && m.Y <= 919 ){ indoors = true; }
				else if ( m.X >= 747 && m.Y >= 919 && m.X <= 755 && m.Y <= 931 ){ indoors = true; }
				else if ( m.X >= 739 && m.Y >= 944 && m.X <= 747 && m.Y <= 952 ){ indoors = true; }
				else if ( m.X >= 766 && m.Y >= 972 && m.X <= 773 && m.Y <= 980 ){ indoors = true; }
				else if ( m.X >= 749 && m.Y >= 962 && m.X <= 758 && m.Y <= 968 ){ indoors = true; }
				else if ( m.X >= 749 && m.Y >= 966 && m.X <= 755 && m.Y <= 975 ){ indoors = true; }
				else if ( m.X >= 808 && m.Y >= 991 && m.X <= 817 && m.Y <= 1001 ){ indoors = true; }
				else if ( m.X >= 809 && m.Y >= 998 && m.X <= 832 && m.Y <= 1010 ){ indoors = true; }
				else if ( m.X >= 824 && m.Y >= 990 && m.X <= 832 && m.Y <= 1002 ){ indoors = true; }
				else if ( m.X >= 812 && m.Y >= 969 && m.X <= 831 && m.Y <= 980 ){ indoors = true; }
				else if ( m.X >= 815 && m.Y >= 981 && m.X <= 828 && m.Y <= 984 ){ indoors = true; }
				else if ( m.X >= 712 && m.Y >= 979 && m.X <= 718 && m.Y <= 995 ){ indoors = true; }
				else if ( m.X >= 710 && m.Y >= 983 && m.X <= 718 && m.Y <= 991 ){ indoors = true; }
				else if ( m.X >= 706 && m.Y >= 988 && m.X <= 710 && m.Y <= 991 ){ indoors = true; }
				else if ( m.X >= 707 && m.Y >= 992 && m.X <= 714 && m.Y <= 995 ){ indoors = true; }
				else if ( m.X >= 681 && m.Y >= 986 && m.X <= 693 && m.Y <= 994 ){ indoors = true; }
				else if ( m.X >= 215 && m.Y >= 1649 && m.X <= 236 && m.Y <= 1653 && m.Z > 55 ){ indoors = true; }
				else if ( m.X >= 324 && m.Y >= 1649 && m.X <= 328 && m.Y <= 1740 && m.Z > 55 ){ indoors = true; }
				else if ( m.X >= 288 && m.Y >= 1759 && m.X <= 313 && m.Y <= 1764 && m.Z > 55 ){ indoors = true; }
				else if ( m.X >= 1045 && m.Y >= 421 && m.X <= 1063 && m.Y <= 440 ){ indoors = true; }
			}

            return indoors;
        }

		public static bool IsMassSpawnZone( Map map, int x, int y )
		{
			if (
				( x >= 0 && y >= 0 && x <= 6 && y <= 6 && map == Map.Lodor ) ||
				( x >= 0 && y >= 0 && x <= 6 && y <= 6 && map == Map.Sosaria ) ||
				( x >= 0 && y >= 0 && x <= 6 && y <= 6 && map == Map.SerpentIsland ) ||
				( x >= 0 && y >= 0 && x <= 6 && y <= 6 && map == Map.IslesDread ) ||
				( x >= 1125 && y >= 298 && x <= 1131 && y <= 305 && map == Map.SavagedEmpire ) ||
				( x >= 5457 && y >= 3300 && x <= 5459 && y <= 3302 && map == Map.Sosaria ) ||
				( x >= 608 && y >= 4090 && x <= 704 && y <= 4096 && map == Map.Sosaria ) ||
				( x >= 6126 && y >= 827 && x <= 6132 && y <= 833 && map == Map.Sosaria ) ||
				( x >= 2 && y >= 2 && x <= 5 && y <= 5 && map == Map.Underworld )
				)
				return true;

			return false;
		}

		public static Point3D GetBoatWater( int x, int y, Map map, int range )
		{
			bool WaterOk = false;
			Point3D loc = new Point3D(0, 0, 0);

			Map tm = map;
			int tx = 0;
			int ty = 0;
			int tz = 0;
			int r = 0;
			LandTile t = tm.Tiles.GetLandTile(tx, ty);

            while ( !WaterOk )
            {
				tx = Utility.RandomMinMax( x+range, x-range );
				ty = Utility.RandomMinMax( y+range, y-range );
				tz = tm.GetAverageZ(tx, ty);

				t = tm.Tiles.GetLandTile(tx, ty);

				if ( Server.Misc.Worlds.IsWaterTile ( t.ID, 0 ) ){ WaterOk = true; }

				if ( WaterOk )
				{
					loc = new Point3D(tx, ty, tz);
				}

				r++; // SAFETY CATCH
				if ( r > 50 )
                {
					WaterOk = true;
                }
            }
            return loc;
        }

		public static bool IsWaterTile ( int id, int harvest )
		{
			if ( harvest == 0 && ( id==0x00A8 || id==0x00A9 || id==0x00AA || id==0x00AB || id==0x0136 || id==0x0137 || id==0x1559 || id==0x1796 || id==0x1797 || id==0x1798 || id==0x1799 || id==0x179A || id==0x179B || id==0x179C || id==0x179D || id==0x179E || id==0x179F || id==0x17A0 || id==0x17A1 || id==0x17A2 || id==0x17A3 || id==0x17A4 || id==0x17A5 || id==0x17A6 || id==0x17A7 || id==0x17A8 || id==0x17A9 || id==0x17AA || id==0x17AB || id==0x17AC || id==0x17AD || id==0x17AE || id==0x17AF || id==0x17B0 || id==0x17B1 || id==0x17B2 || id==0x17BB || id==0x17BC || id==0x346E || id==0x346F || id==0x3470 || id==0x3471 || id==0x3472 || id==0x3473 || id==0x3474 || id==0x3475 || id==0x3476 || id==0x3477 || id==0x3478 || id==0x3479 || id==0x347A || id==0x347B || id==0x347C || id==0x347D || id==0x347E || id==0x347F || id==0x3480 || id==0x3481 || id==0x3482 || id==0x3483 || id==0x3484 || id==0x3485 || id==0x3494 || id==0x3495 || id==0x3496 || id==0x3497 || id==0x3498 || id==0x349A || id==0x349B || id==0x349C || id==0x349D || id==0x349E || id==0x34A0 || id==0x34A1 || id==0x34A2 || id==0x34A3 || id==0x34A4 || id==0x34A6 || id==0x34A7 || id==0x34A8 || id==0x34A9 || id==0x34AA || id==0x34AB || id==0x34B8 || id==0x34B9 || id==0x34BA || id==0x34BB || id==0x34BD || id==0x34BE || id==0x34BF || id==0x34C0 || id==0x34C2 || id==0x34C3 || id==0x34C4 || id==0x34C5 || id==0x34C7 || id==0x34C8 || id==0x34C9 || id==0x34CA || id==0x34D2 || id==0x3529 || id==0x352A || id==0x352B || id==0x352C || id==0x3531 || id==0x3532 || id==0x3533 || id==0x3534 || id==0x3535 || id==0x3536 || id==0x3537 || id==0x3538 || id==0x353D || id==0x353E || id==0x353F || id==0x3540 || id==0x3541 || id==0x55F0 || id==0x55F1 || id==0x55F2 || id==0x55F3 || id==0x55F4 || id==0x55F5 || id==0x55F6 || id==0x55F7 || id==0x55F8 || id==0x55F9 || id==0x55FA || id==0x55FB || id==0x55FC || id==0x55FD || id==0x55FE || id==0x55FF || id==0x5600 || id==0x5601 || id==0x5602 || id==0x5603 || id==0x5604 || id==0x5605 || id==0x5606 || id==0x5607 || id==0x5608 || id==0x5609 || id==0x560A || id==0x560B || id==0x560C || id==0x560D || id==0x560E || id==0x560F || id==0x5610 || id==0x5611 || id==0x5612 || id==0x5613 || id==0x5614 || id==0x5615 || id==0x5616 || id==0x5617 || id==0x5618 || id==0x5619 || id==0x561A || id==0x561B || id==0x561C || id==0x561D || id==0x561E || id==0x561F || id==0x5620 || id==0x5621 || id==0x5622 || id==0x5623 || id==0x5624 || id==0x5633 || id==0x5634 || id==0x5635 || id==0x5636 || id==0x5637 || id==0x5638 || id==0x5639 || id==0x563A || id==0x563B || id==0x563C || id==0x563D || id==0x563F || id==0x5640 || id==0x5641 || id==0x5642 || id==0x5643 || id==0x5644 || id==0x5645 || id==0x5646 || id==0x5647 || id==0x5648 || id==0x5649 || id==0x564A || id==0x5657 || id==0x5658 || id==0x5659 || id==0x565A || id==0x565B || id==0x565C || id==0x565D || id==0x565E || id==0x565F || id==0x5660 || id==0x5661 || id==0x5662 || id==0x5663 || id==0x5664 || id==0x5665 || id==0x5666 || id==0x5667 || id==0x5668 || id==0x5669 || id==0x566A || id==0x566B || id==0x566C || id==0x566D || id==0x566E || id==0x566F ) )
				return true;

			else if ( id>=0x5536 && id<= 0x553F )
				return true;

			else if ( harvest == 1 && ( id==0x40A8 || id==0x40A9 || id==0x40AA || id==0x40AB || id==0x4136 || id==0x4137 || id==0x5559 || id==0x5796 || id==0x5797 || id==0x5798 || id==0x5799 || id==0x579A || id==0x579B || id==0x579C || id==0x579D || id==0x579E || id==0x579F || id==0x57A0 || id==0x57A1 || id==0x57A2 || id==0x57A3 || id==0x57A4 || id==0x57A5 || id==0x57A6 || id==0x57A7 || id==0x57A8 || id==0x57A9 || id==0x57AA || id==0x57AB || id==0x57AC || id==0x57AD || id==0x57AE || id==0x57AF || id==0x57B0 || id==0x57B1 || id==0x57B2 || id==0x57BB || id==0x57BC || id==0x746E || id==0x746F || id==0x7470 || id==0x7471 || id==0x7472 || id==0x7473 || id==0x7474 || id==0x7475 || id==0x7476 || id==0x7477 || id==0x7478 || id==0x7479 || id==0x747A || id==0x747B || id==0x747C || id==0x747D || id==0x747E || id==0x747F || id==0x7480 || id==0x7481 || id==0x7482 || id==0x7483 || id==0x7484 || id==0x7485 || id==0x7494 || id==0x7495 || id==0x7496 || id==0x7497 || id==0x7498 || id==0x749A || id==0x749B || id==0x749C || id==0x749D || id==0x749E || id==0x74A0 || id==0x74A1 || id==0x74A2 || id==0x74A3 || id==0x74A4 || id==0x74A6 || id==0x74A7 || id==0x74A8 || id==0x74A9 || id==0x74AA || id==0x74AB || id==0x74B8 || id==0x74B9 || id==0x74BA || id==0x74BB || id==0x74BD || id==0x74BE || id==0x74BF || id==0x74C0 || id==0x74C2 || id==0x74C3 || id==0x74C4 || id==0x74C5 || id==0x74C7 || id==0x74C8 || id==0x74C9 || id==0x74CA || id==0x74D2 || id==0x7529 || id==0x752A || id==0x752B || id==0x752C || id==0x7531 || id==0x7532 || id==0x7533 || id==0x7534 || id==0x7535 || id==0x7536 || id==0x7537 || id==0x7538 || id==0x753D || id==0x753E || id==0x753F || id==0x7540 || id==0x7541 || id==0x95F0 || id==0x95F1 || id==0x95F2 || id==0x95F3 || id==0x95F4 || id==0x95F5 || id==0x95F6 || id==0x95F7 || id==0x95F8 || id==0x95F9 || id==0x95FA || id==0x95FB || id==0x95FC || id==0x95FD || id==0x95FE || id==0x95FF || id==0x9600 || id==0x9601 || id==0x9602 || id==0x9603 || id==0x9604 || id==0x9605 || id==0x9606 || id==0x9607 || id==0x9608 || id==0x9609 || id==0x960A || id==0x960B || id==0x960C || id==0x960D || id==0x960E || id==0x960F || id==0x9610 || id==0x9611 || id==0x9612 || id==0x9613 || id==0x9614 || id==0x9615 || id==0x9616 || id==0x9617 || id==0x9618 || id==0x9619 || id==0x961A || id==0x961B || id==0x961C || id==0x961D || id==0x961E || id==0x961F || id==0x9620 || id==0x9621 || id==0x9622 || id==0x9623 || id==0x9624 || id==0x9633 || id==0x9634 || id==0x9635 || id==0x9636 || id==0x9637 || id==0x9638 || id==0x9639 || id==0x963A || id==0x963B || id==0x963C || id==0x963D || id==0x963F || id==0x9640 || id==0x9641 || id==0x9642 || id==0x9643 || id==0x9644 || id==0x9645 || id==0x9646 || id==0x9647 || id==0x9648 || id==0x9649 || id==0x964A || id==0x9657 || id==0x9658 || id==0x9659 || id==0x965A || id==0x965B || id==0x965C || id==0x965D || id==0x965E || id==0x965F || id==0x9660 || id==0x9661 || id==0x9662 || id==0x9663 || id==0x9664 || id==0x9665 || id==0x9666 || id==0x9667 || id==0x9668 || id==0x9669 || id==0x966A || id==0x966B || id==0x966C || id==0x966D || id==0x966E || id==0x966F ) )
				return true;

			return false;
		}

		public static bool TestTile ( Map map, int x, int y, string category )
		{
			Region reg = Region.Find( new Point3D( x, y, 0 ), map );
				if ( reg.IsPartOf( typeof( DungeonRegion ) ) ){ return false; }

			int results = 0;

			LandTile landTile1 = map.Tiles.GetLandTile( x-1, y-1 );
			LandTile landTile2 = map.Tiles.GetLandTile( x, y-1 );
			LandTile landTile3 = map.Tiles.GetLandTile( x+1, y-1 );
			LandTile landTile4 = map.Tiles.GetLandTile( x-1, y );
			LandTile landTile5 = map.Tiles.GetLandTile( x, y );
			LandTile landTile6 = map.Tiles.GetLandTile( x+1, y );
			LandTile landTile7 = map.Tiles.GetLandTile( x-1, y+1 );
			LandTile landTile8 = map.Tiles.GetLandTile( x, y+1 );
			LandTile landTile9 = map.Tiles.GetLandTile( x+1, y+1 );

			// YEW FOREST PATCH
			if ( map == Map.Sosaria && category == "forest" )
			{
				if (
					( x >= 2089 && y >= 841 && x <= 2207 && y <= 1001 ) ||
					( x >= 2162 && y >= 679 && x <= 2358 && y <= 1077 ) ||
					( x >= 2335 && y >= 660 && x <= 2621 && y <= 1117 ) ||
					( x >= 2610 && y >= 718 && x <= 2747 && y <= 1025 )
				)
					category = "jungle";
			}

			if ( Utility.PassableTile ( landTile1.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile1.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile2.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile2.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile3.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile3.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile4.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile4.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile5.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile5.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile6.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile6.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile7.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile7.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile8.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile8.ID, category ) ){ results ++; }
			if ( Utility.PassableTile ( landTile9.ID, category ) ){ results ++; }
				if ( Utility.BlockedTile ( landTile9.ID, category ) ){ results ++; }

			if ( results > 4 )
				return true;

			return false;
		}

		public static bool TestMountain ( Map map, int x, int y, int distance )
		{
			Region reg = Region.Find( new Point3D( x, y, 0 ), map );
				if ( reg.IsPartOf( typeof( DungeonRegion ) ) ){ return false; }

			int results = 0;

			LandTile landRock1 = map.Tiles.GetLandTile( x-distance, y-distance );
			LandTile landRock2 = map.Tiles.GetLandTile( x, y-distance );
			LandTile landRock3 = map.Tiles.GetLandTile( x+distance, y-distance );
			LandTile landRock4 = map.Tiles.GetLandTile( x-distance, y );
			LandTile landRock5 = map.Tiles.GetLandTile( x+distance, y );
			LandTile landRock6 = map.Tiles.GetLandTile( x-distance, y+distance );
			LandTile landRock7 = map.Tiles.GetLandTile( x, y+distance );
			LandTile landRock8 = map.Tiles.GetLandTile( x+distance, y+distance );

			if ( Utility.BlockedTile ( landRock1.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock2.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock3.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock4.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock5.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock6.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock7.ID, "rock" ) ){ results ++; }
			if ( Utility.BlockedTile ( landRock8.ID, "rock" ) ){ results ++; }

			if ( results > 0 )
				return true;

			return false;
		}

		public static bool TestOcean( Map map, int x, int y, int distance )
		{
			Region reg = Region.Find( new Point3D( x, y, 0 ), map );
				if ( reg.IsPartOf( typeof( DungeonRegion ) ) ){ return false; }

			int results = 0;

			LandTile seaTile1 = map.Tiles.GetLandTile( x-distance, y-distance );
			LandTile seaTile2 = map.Tiles.GetLandTile( x, y-distance );
			LandTile seaTile3 = map.Tiles.GetLandTile( x+distance, y-distance );
			LandTile seaTile4 = map.Tiles.GetLandTile( x-distance, y );
			LandTile seaTile5 = map.Tiles.GetLandTile( x+distance, y );
			LandTile seaTile6 = map.Tiles.GetLandTile( x-distance, y+distance );
			LandTile seaTile7 = map.Tiles.GetLandTile( x, y+distance );
			LandTile seaTile8 = map.Tiles.GetLandTile( x+distance, y+distance );

			if ( Utility.BlockedTile ( seaTile1.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile2.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile3.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile4.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile5.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile6.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile7.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile8.ID, "water" ) ){ results ++; }

			if ( results > 0 )
				return true;

			return false;
		}

		public static bool TestShore( Map map, int x, int y, int distance )
		{
			int results = 0;

			LandTile seaTile1 = map.Tiles.GetLandTile( x-distance, y-distance );
			LandTile seaTile2 = map.Tiles.GetLandTile( x, y-distance );
			LandTile seaTile3 = map.Tiles.GetLandTile( x+distance, y-distance );
			LandTile seaTile4 = map.Tiles.GetLandTile( x-distance, y );
			LandTile seaTile5 = map.Tiles.GetLandTile( x+distance, y );
			LandTile seaTile6 = map.Tiles.GetLandTile( x-distance, y+distance );
			LandTile seaTile7 = map.Tiles.GetLandTile( x, y+distance );
			LandTile seaTile8 = map.Tiles.GetLandTile( x+distance, y+distance );

			if ( Utility.BlockedTile ( seaTile1.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile2.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile3.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile4.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile5.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile6.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile7.ID, "water" ) ){ results ++; }
			if ( Utility.BlockedTile ( seaTile8.ID, "water" ) ){ results ++; }

			if ( results > 7 )
				return false;

			return true;
		}
	}

    class WhereWorld
    {
		public static void Initialize()
		{
            CommandSystem.Register( "world", AccessLevel.Administrator, new CommandEventHandler( WhereWorld_OnCommand ) );
		}
		public static void Register( string command, AccessLevel access, CommandEventHandler handler )
		{
            CommandSystem.Register(command, access, handler);
		}

		[Usage( "world" )]
		[Description( "Tells you what world you are in." )]
		public static void WhereWorld_OnCommand( CommandEventArgs e )
        {
			Mobile from = e.Mobile;
			string sMap = Worlds.GetMyWorld( from.Map, from.Location, from.X, from.Y );
			from.SendMessage( "You are currently in " + sMap + "." );
		}
	}
}
