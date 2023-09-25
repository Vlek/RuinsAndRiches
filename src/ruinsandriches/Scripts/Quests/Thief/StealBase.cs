using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
	public class StealBase : BaseAddon
	{
		public int BoxType;
		public int BoxColor;
		public int PedType;
		public string BoxOrigin;
		public string BoxCarving;

		[CommandProperty(AccessLevel.Owner)]
		public int Box_Type { get { return BoxColor; } set { BoxColor = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Box_Color { get { return BoxType; } set { BoxType = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public int Ped_Type { get { return PedType; } set { PedType = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Box_Origin { get { return BoxOrigin; } set { BoxOrigin = value; InvalidateProperties(); } }

		[CommandProperty(AccessLevel.Owner)]
		public string Box_Carving { get { return BoxCarving; } set { BoxCarving = value; InvalidateProperties(); } }

		public int m_Tries;
		public int Tries{ get{ return m_Tries; } set{ m_Tries = value; } }

		[ Constructable ]
		public StealBase()
		{
			int iZ = 0;
			int iZ1 = 0;
			int iZ2 = 0;

			if ( Utility.RandomMinMax( 1, 3 ) > 1 )
			{
				iZ1 = 5;
				iZ2 = 6;
				PedType = 13042;
			}
			else
			{
				iZ1 = 10;
				iZ2 = 10;
				PedType = 0x1223;
			}

				string sEtch = "etched";
				string sPed = "an ornately ";
				switch( Utility.RandomMinMax( 0, 10 ) )
				{
					case 0: sPed = "an ornately ";		break;
					case 1: sPed = "a beautifully ";	break;
					case 2: sPed = "an expertly ";		break;
					case 3: sPed = "an artistically ";	break;
					case 4: sPed = "an exquisitely ";	break;
					case 5: sPed = "a decoratively ";	break;
					case 6: sPed = "an ancient ";		break;
					case 7: sPed = "an old ";			break;
					case 8: sPed = "an unusually ";		break;
					case 9: sPed = "a curiously ";		break;
					case 10: sPed = "an oddly ";		break;
				}
				sPed = sPed + "carved pedestal";

				int iColor = 0;
				int iThing = 0x9A8;
				string sArty = "a strange";
				switch( Utility.RandomMinMax( 0, 6 ) )
				{
					case 0: sArty = "an odd ";		break;
					case 1: sArty = "an unusual ";	break;
					case 2: sArty = "a bizarre ";	break;
					case 3: sArty = "a curious ";	break;
					case 4: sArty = "a peculiar ";	break;
					case 5: sArty = "a strange ";	break;
					case 6: sArty = "a weird ";		break;
				}

				string sThing = "metal box";
				switch( Utility.RandomMinMax( 0, 6 ) )
				{
					case 0: iThing = 0x9AA; sThing = "metal box"; break;
					case 1: iThing = 0xE7D; sThing = "metal box"; break;
					case 2: iThing = 0x9AA; sThing = "wooden box"; break;
					case 3: iThing = 0xE7D; sThing = "wooden box"; break;
					case 4: iThing = 0xE76; sThing = "bag"; break;
					case 5: iThing = 0xE76; sThing = "sack"; break;
					case 6: iThing = 0xE76; sThing = "pouch"; break;
				}

				if ( sThing == "metal box")
				{
					BoxType = 1;
					iZ = iZ1;
					sEtch = "etched";
					switch ( Utility.RandomMinMax( 0, 19 ) )
					{
						case 0: iColor = MaterialInfo.GetMaterialColor( "dull copper", "classic", 0 ); sThing = "dull copper box";	break;
						case 1: iColor = MaterialInfo.GetMaterialColor( "shadow iron", "classic", 0 ); sThing = "shadow iron box";	break;
						case 2: iColor = MaterialInfo.GetMaterialColor( "copper", "classic", 0 ); sThing = "copper box";			break;
						case 3: iColor = MaterialInfo.GetMaterialColor( "bronze", "classic", 0 ); sThing = "bronze box";			break;
						case 4: iColor = MaterialInfo.GetMaterialColor( "gold", "classic", 0 ); sThing = "golden box";				break;
						case 5: iColor = MaterialInfo.GetMaterialColor( "agapite", "classic", 0 ); sThing = "agapite box";			break;
						case 6: iColor = MaterialInfo.GetMaterialColor( "verite", "classic", 0 ); sThing = "verite box";			break;
						case 7: iColor = MaterialInfo.GetMaterialColor( "valorite", "classic", 0 ); sThing = "valorite box";		break;
						case 8: iColor = MaterialInfo.GetMaterialColor( "silver", "classic", 0 ); sThing = "silver box";			break;
						case 9: iColor = MaterialInfo.GetMaterialColor( "emerald", "classic", 0 ); sThing = "emerald box";			break;
						case 10: iColor = MaterialInfo.GetMaterialColor( "jade", "classic", 0 ); sThing = "jade box";				break;
						case 11: iColor = MaterialInfo.GetMaterialColor( "onyx", "classic", 0 ); sThing = "onyx box";				break;
						case 12: iColor = MaterialInfo.GetMaterialColor( "ruby", "classic", 0 ); sThing = "ruby box";				break;
						case 13: iColor = MaterialInfo.GetMaterialColor( "sapphire", "classic", 0 ); sThing = "sapphire box";		break;
						case 14: iColor = 0x317; sThing = "iron box";																break;
						case 15: iColor = MaterialInfo.GetMaterialColor( "mithril", "classic", 0 ); sThing = "mithril box";			break;
						case 16: iColor = MaterialInfo.GetMaterialColor( "brass", "classic", 0 ); sThing = "brass box";				break;
						case 17: iColor = MaterialInfo.GetMaterialColor( "nepturite", "classic", 0 ); sThing = "nepturite box";		break;
						case 18: iColor = MaterialInfo.GetMaterialColor( "obsidian", "classic", 0 ); sThing = "obsidian box";		break;
						case 19: iColor = MaterialInfo.GetMaterialColor( "steel", "classic", 0 ); sThing = "steel box";				break;
					}
				}
				else if ( sThing == "wooden box")
				{
					BoxType = 2;
					iZ = iZ1;
					sEtch = "carved";
					switch ( Utility.RandomMinMax( 0, 14 ) )
					{
						case 0: iColor = 0; 													sThing = "wooden box";			break;
						case 1: iColor = MaterialInfo.GetMaterialColor( "oak", "", 0 ); 		sThing = "oak wood box";		break;
						case 2: iColor = MaterialInfo.GetMaterialColor( "ash", "", 0 ); 		sThing = "ash wood box";		break;
						case 3: iColor = MaterialInfo.GetMaterialColor( "cherry", "", 0 ); 		sThing = "cherry wood box";		break;
						case 4: iColor = MaterialInfo.GetMaterialColor( "walnut", "", 0 ); 		sThing = "walnut wood box";		break;
						case 5: iColor = MaterialInfo.GetMaterialColor( "golden oak", "", 0 ); 	sThing = "golden oak wood box";	break;
						case 6: iColor = MaterialInfo.GetMaterialColor( "ebony", "", 0 ); 		sThing = "ebony wood box";		break;
						case 7: iColor = MaterialInfo.GetMaterialColor( "hickory", "", 0 ); 	sThing = "hickory wood box";	break;
						case 8: iColor = MaterialInfo.GetMaterialColor( "pine", "", 0 ); 		sThing = "pine wood box";		break;
						case 9: iColor = MaterialInfo.GetMaterialColor( "rosewood", "", 0 ); 	sThing = "rosewood box";		break;
						case 10: iColor = MaterialInfo.GetMaterialColor( "mahogany", "", 0 ); 	sThing = "mahogany wood box";	break;
						case 11: iColor = MaterialInfo.GetMaterialColor( "elven", "", 0 ); 		sThing = "elven wood box";		break;
						case 12: iColor = MaterialInfo.GetMaterialColor( "petrified", "", 0 ); 	sThing = "petrified wood box";	break;
						case 13: iColor = MaterialInfo.GetMaterialColor( "ghostwood", "", 0 ); 	sThing = "ghost wood box";		break;
						case 14: iColor = MaterialInfo.GetMaterialColor( "driftwood", "", 0 ); 	sThing = "drift wood box";		break;
					}
				}
				else
				{
					BoxType = 3;
					iZ = iZ2;
					sEtch = "etched";
					switch ( Utility.RandomMinMax( 0, 10 ) )
					{
						case 0: iColor = MaterialInfo.GetMaterialColor( "frozen", "", 0 ); sThing = "frozen leather " + sThing;	break;
						case 1: iColor = MaterialInfo.GetMaterialColor( "volcanic", "", 0 ); sThing = "volcanic leather " + sThing;	break;
						case 2: iColor = MaterialInfo.GetMaterialColor( "dinosaur", "", 0 ); sThing = "dinosaur leather " + sThing;	break;
						case 3: iColor = MaterialInfo.GetMaterialColor( "serpent", "", 0 ); sThing = "serpent leather " + sThing;	break;
						case 4: iColor = MaterialInfo.GetMaterialColor( "lizard", "", 0 ); sThing = "lizard leather " + sThing;	break;
						case 5: iColor = MaterialInfo.GetMaterialColor( "deep sea", "", 0 ); sThing = "deep sea leather " + sThing;	break;
						case 6: iColor = MaterialInfo.GetMaterialColor( "draconic", "", 0 ); sThing = "draconic leather " + sThing;	break;
						case 7: iColor = MaterialInfo.GetMaterialColor( "hellish", "", 0 ); sThing = "hellish leather " + sThing;	break;
						case 8: iColor = MaterialInfo.GetMaterialColor( "goliath", "", 0 ); sThing = "goliath leather " + sThing;	break;
						case 9: iColor = MaterialInfo.GetMaterialColor( "necrotic", "", 0 ); sThing = "necrotic leather " + sThing;	break;
						case 10: iColor = 0; sThing = "leather " + sThing;	break;
					}
				}
				sThing = sArty + sThing;

			AddComplexComponent( (BaseAddon) this, iThing, 0, 0, iZ, iColor, -1, sThing, 1);
			AddComplexComponent( (BaseAddon) this, 5703, 0, 0, 0, 0, 29, sPed, 1);
			AddComplexComponent( (BaseAddon) this, PedType, 0, 0, 0, 0, -1, "", 1);

			BoxOrigin = sThing;
			BoxColor = iColor;

			///// DO THE CARVINGS ON THE BAG OR BOX ///////////////////////////////////////////////////////////
			string sLanguage = "pixie";
			switch( Utility.RandomMinMax( 0, 28 ) )
			{
				case 0: sLanguage = "balron"; break;
				case 1: sLanguage = "pixie"; break;
				case 2: sLanguage = "centaur"; break;
				case 3: sLanguage = "demonic"; break;
				case 4: sLanguage = "dragon"; break;
				case 5: sLanguage = "dwarvish"; break;
				case 6: sLanguage = "elven"; break;
				case 7: sLanguage = "fey"; break;
				case 8: sLanguage = "gargoyle"; break;
				case 9: sLanguage = "cyclops"; break;
				case 10: sLanguage = "gnoll"; break;
				case 11: sLanguage = "goblin"; break;
				case 12: sLanguage = "gremlin"; break;
				case 13: sLanguage = "druidic"; break;
				case 14: sLanguage = "tritun"; break;
				case 15: sLanguage = "minotaur"; break;
				case 16: sLanguage = "naga"; break;
				case 17: sLanguage = "ogrish"; break;
				case 18: sLanguage = "orkish"; break;
				case 19: sLanguage = "sphinx"; break;
				case 20: sLanguage = "treekin"; break;
				case 21: sLanguage = "trollish"; break;
				case 22: sLanguage = "undead"; break;
				case 23: sLanguage = "vampire"; break;
				case 24: sLanguage = "dark elf"; break;
				case 25: sLanguage = "magic"; break;
				case 26: sLanguage = "human"; break;
				case 27: sLanguage = "symbolic"; break;
				case 28: sLanguage = "runic"; break;
			}

			string sPart = "strange ";
			switch( Utility.RandomMinMax( 0, 5 ) )
			{
				case 0:	sPart = "strange ";	break;
				case 1:	sPart = "odd ";		break;
				case 2:	sPart = "ancient ";	break;
				case 3:	sPart = "long dead ";	break;
				case 4:	sPart = "cryptic ";	break;
				case 5:	sPart = "mystical ";	break;
			}

			string sPart2 = " symbols ";
			switch( Utility.RandomMinMax( 0, 5 ) )
			{
				case 0:	sPart2 = " symbols ";	break;
				case 1:	sPart2 = " words ";		break;
				case 2:	sPart2 = " writings ";	break;
				case 3:	sPart2 = " glyphs ";	break;
				case 4:	sPart2 = " pictures ";	break;
				case 5:	sPart2 = " runes ";		break;
			}

			BoxCarving = "with " + sPart + sLanguage + sPart2 + sEtch + " on it";
		}

		public StealBase( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void OnComponentUsed( AddonComponent ac, Mobile from )
		{
			if ( from.Backpack.FindItemByType( typeof ( MuseumBook ) ) != null && !from.Blessed && from.InRange( GetWorldLocation(), 2 ) )
			{
				MuseumBook.FoundItem( from, 2 );
			}

			if ( from.Backpack.FindItemByType( typeof ( QuestTome ) ) != null && !from.Blessed && from.InRange( GetWorldLocation(), 2 ) )
			{
				QuestTome.FoundItem( from, 2, null );
			}

			if ( from.Blessed )
			{
				from.SendMessage( "You cannot open that while in this state." );
			}
			else if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.SendMessage( "You will have to get closer to try and steal the item." );
			}
			else if ( m_Tries > 5 )
			{
				Item Pedul = new StealBaseEmpty();
				Pedul.ItemID = PedType;
				Pedul.MoveToWorld (new Point3D(this.X, this.Y, this.Z), this.Map);
				from.SendMessage( "Your fingers were not nimble enough and your prize has vanished!" );
				this.Delete();
			}
			else if ( !from.CheckSkill( SkillName.Snooping, 0, 125 ) )
			{
				m_Tries++;
				if ( from.CheckSkill( SkillName.RemoveTrap, 0, 125 ) )
				{
					from.SendMessage( "You pull back just in time to avoid a trap!" );
				}
				else
				{
					int nReaction = Utility.RandomMinMax( 1, 3 );

					if ( nReaction == 1 )
					{
						from.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
						from.PlaySound( 0x205 );
						int nPoison = Utility.RandomMinMax( 0, 10 );
							if ( nPoison > 9 ) { from.ApplyPoison( from, Poison.Deadly ); }
							else if ( nPoison > 7 ) { from.ApplyPoison( from, Poison.Greater ); }
							else if ( nPoison > 4 ) { from.ApplyPoison( from, Poison.Regular ); }
							else { from.ApplyPoison( from, Poison.Lesser ); }
						from.SendMessage( "You accidentally trigger a poison trap!" );
						LoggingFunctions.LogTraps( from, "a pedestal poison trap" );
					}
					else if ( nReaction == 2 )
					{
						from.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
						from.PlaySound( 0x208 );
						Spells.SpellHelper.Damage( TimeSpan.FromSeconds( 0.5 ), from, from, Utility.RandomMinMax( 10, 80 ), 0, 100, 0, 0, 0 );
						from.SendMessage( "You accidentally trigger a flame trap!" );
						LoggingFunctions.LogTraps( from, "a pedestal fire trap" );
					}
					else if ( nReaction == 3 )
					{
						from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
						from.PlaySound( 0x307 );
						Spells.SpellHelper.Damage( TimeSpan.FromSeconds( 0.5 ), from, from, Utility.RandomMinMax( 10, 80 ), 0, 100, 0, 0, 0 );
						from.SendMessage( "You accidentally trigger an explosion trap!" );
						LoggingFunctions.LogTraps( from, "a pedestal explosion trap" );
					}
				}
			}
			else if ( from.CheckSkill( SkillName.Stealing, 0, 125 ) )
			{
				m_Tries++;
				bool TakeBox = true;

				if ( from.Backpack.FindItemByType( typeof ( ThiefNote ) ) != null )
				{
					Item mail = from.Backpack.FindItemByType( typeof ( ThiefNote ) );
					ThiefNote envelope = (ThiefNote)mail;

					if ( envelope.NoteOwner == from )
					{
						if ( envelope.NoteItemArea == Server.Misc.Worlds.GetRegionName( from.Map, from.Location ) && envelope.NoteItemGot == 0 )
						{
							envelope.NoteItemGot = 1;
							from.LocalOverheadMessage(MessageType.Emote, 1150, true, "You found " + envelope.NoteItem + ".");
							from.SendSound( 0x3D );
							from.CloseGump( typeof( Server.Items.ThiefNote.NoteGump ) );
							envelope.InvalidateProperties();
							TakeBox = false;
						}
					}
				}

				if ( TakeBox )
				{
					if ( BoxType == 1 )
					{
						Item Bags = new StealMetalBox();
						StealMetalBox bag = (StealMetalBox)Bags;
						bag.BoxColor = BoxColor;
						bag.Hue = BoxColor;
						bag.Name = BoxOrigin;
						bag.BoxName = BoxOrigin;
						bag.BoxMarkings = BoxCarving;
						FillMeUp( bag, from );
						from.AddToBackpack( bag );
					}
					else if ( BoxType == 2 )
					{
						Item Bags = new StealBox();
						StealBox bag = (StealBox)Bags;
						bag.BoxColor = BoxColor;
						bag.Hue = BoxColor;
						bag.Name = BoxOrigin;
						bag.BoxName = BoxOrigin;
						bag.BoxMarkings = BoxCarving;
						FillMeUp( bag, from );
						from.AddToBackpack( bag );
					}
					else
					{
						Item Bags = new StealBag();
						StealBag bag = (StealBag)Bags;
						bag.BagColor = BoxColor;
						bag.Hue = BoxColor;
						bag.Name = BoxOrigin;
						bag.BagName = BoxOrigin;
						bag.BagMarkings = BoxCarving;
						FillMeUp( bag, from );
						from.AddToBackpack( bag );

					}
					Item Pedul = new StealBaseEmpty();
					Pedul.ItemID = PedType;
					Pedul.MoveToWorld (new Point3D(this.X, this.Y, this.Z), this.Map);
					from.SendMessage( "Your nimble fingers manage to steal the item." );
					LoggingFunctions.LogStandard( from, "has stolen an item from a pedestal." );

					Titles.AwardFame( from, 500, true );

					this.Delete();
				}
			}
			else
			{
				m_Tries++;
				from.SendMessage( "You fail to steal the item." );
			}

		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
            writer.Write( BoxType );
            writer.Write( BoxColor );
            writer.Write( PedType );
            writer.Write( BoxOrigin );
            writer.Write( BoxCarving );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
            BoxType = reader.ReadInt();
            BoxColor = reader.ReadInt();
            PedType = reader.ReadInt();
            BoxOrigin = reader.ReadString();
            BoxCarving = reader.ReadString();
		}

		public void FillMeUp( Container box, Mobile from )
		{
			Item i = null;
			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				i = Loot.RandomArty();
				box.DropItem(i);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				i = DungeonLoot.RandomSlayer();
				box.DropItem(i);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				i = Loot.RandomSArty();
				box.DropItem(i);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				if ( Server.Misc.GetPlayerInfo.EvilPlay( from ) == true && Utility.RandomMinMax( 0, 10 ) == 10 )
				{
					i = DungeonLoot.RandomEvil();
					box.DropItem(i);
				}
				else
				{
					Item relic = Loot.RandomRelic();
					if ( relic is DDRelicWeapon && Server.Misc.GetPlayerInfo.OrientalPlay( from ) == true ){ Server.Items.DDRelicWeapon.MakeOriental( relic ); }
					else if ( relic is DDRelicStatue && Server.Misc.GetPlayerInfo.OrientalPlay( from ) == true ){ Server.Items.DDRelicStatue.MakeOriental( relic ); }
					else if ( relic is DDRelicBanner && relic.ItemID != 0x2886 && relic.ItemID != 0x2887 && Server.Misc.GetPlayerInfo.OrientalPlay( from ) == true ){ Server.Items.DDRelicBanner.MakeOriental( relic ); }
					box.DropItem( relic );
				}
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				Item idropped = DungeonLoot.RandomRare();
				if ( idropped is OilLeather || idropped is OilMetal ){ idropped.Amount = Utility.RandomMinMax( 1, 8 ); }
				else if ( idropped is MagicalDyes ){ idropped.Amount = Utility.RandomMinMax( 3, 10 ); }
				else if (idropped.Stackable == true){ idropped.Amount = Utility.RandomMinMax( 5, 20 ); }

				if ( idropped is UnusualDyes && Server.Misc.GetPlayerInfo.EvilPlay( from ) ){ idropped.Hue = Utility.RandomEvilHue(); }

				box.DropItem( idropped );
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				i = DungeonLoot.RandomLoreBooks();
				box.DropItem(i);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				int scroll = Utility.RandomMinMax(1,5);
				if ( scroll > 2 ) { i = Loot.RandomScroll( 47, 63, SpellbookType.Regular ); box.DropItem(i); }
				else if ( scroll == 2 ) { i = Loot.RandomScroll( 20, 31, SpellbookType.Elementalism ); box.DropItem(i); }
				else { i = Loot.RandomScroll( 0, 17, SpellbookType.Necromancer ); box.DropItem(i); }
			}

			i = new Gold( ( from.Luck + Utility.RandomMinMax( 1000, 4000 ) ) );
			box.DropItem(i);

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				Item item = Loot.RandomArmorOrShieldOrWeaponOrJewelryOrClothing( Server.LootPackEntry.IsInIslesDread( from ) );
				item = Server.Misc.ContainerFunctions.LootMutate( from, Server.LootPack.GetRegularLuckChance( from ), item, box, Utility.RandomMinMax( 8, 10 ) );
				box.DropItem(item);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				Item lute = Loot.RandomInstrument();
				lute = Server.Misc.ContainerFunctions.LootMutate( from, Server.LootPack.GetRegularLuckChance( from ), lute, box, Utility.RandomMinMax( 8, 10 ) );
				box.DropItem(lute);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				i = Loot.RandomGem();
				box.DropItem(i);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				i = Loot.RandomPotion();
				box.DropItem(i);
			}

			if ( Server.Misc.GetPlayerInfo.LuckyPlayer( (int)( 20 + ( from.Luck / 2 ) ) ) == true )
			{
				Item wand = Loot.RandomWand();
				Server.Misc.MaterialInfo.ColorMetal( wand, 0 );
				string wandOwner = "";
				if ( Utility.RandomMinMax( 1, 3 ) == 1 ){ wandOwner = Server.LootPackEntry.MagicWandOwner() + " "; }
				wand.Name = wandOwner + wand.Name;
				box.DropItem( wand );
			}
		}
	}
}
