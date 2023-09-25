using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.ContextMenus;
using Server.Engines.CannedEvil;
using Server.Engines.Craft;
using Server.Engines.Plants;
using Server.Engines.VeteranRewards;
using Server.Ethics;
using Server.Factions.AI;
using Server.Factions;
using Server.Guilds;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Prompts;
using Server.Regions;
using Server.Spells.Fifth;
using Server.Spells.First;
using Server.Spells.Fourth;
using Server.Spells.Second;
using Server.Spells.Seventh;
using Server.Spells.Sixth;
using Server.Spells.Third;
using Server.Spells;
using Server.Targeting;
using Server.Targets;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.Data.Odbc;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System;

namespace Server.Items
{
	public class TribalPaint : Item
	{
		public override int LabelNumber{ get{ return 1040000; } } // savage kin paint

		[Constructable]
		public TribalPaint() : base( 0x9EC )
		{
		}

		public TribalPaint( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			this.Delete();
		}
	}
	public class TribalBerry : Item
	{
		[Constructable]
		public TribalBerry() : this( 1 )
		{
		}

		[Constructable]
		public TribalBerry( int amount ) : base( 0x9D0 )
		{
		}

		public TribalBerry( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			this.Delete();
		}
	}

	public class CharacterDatabase : Item
	{
		public Mobile CharacterOwner;
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Character_Owner { get{ return CharacterOwner; } set{ CharacterOwner = value; } }

		public int CharacterMOTD;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_MOTD { get { return CharacterMOTD; } set { CharacterMOTD = value; InvalidateProperties(); } }

		public int CharacterSkill;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Skill { get { return CharacterSkill; } set { CharacterSkill = value; InvalidateProperties(); } }

		public string CharacterKeys;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Keys { get { return CharacterKeys; } set { CharacterKeys = value; InvalidateProperties(); } }

		public string CharacterDiscovered;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Discovered { get { return CharacterDiscovered; } set { CharacterDiscovered = value; InvalidateProperties(); } }

		public int CharacterSheath;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Sheath { get { return CharacterSheath; } set { CharacterSheath = value; InvalidateProperties(); } }

		public int CharacterGuilds;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Guilds { get { return CharacterGuilds; } set { CharacterGuilds = value; InvalidateProperties(); } }

		public string CharacterBoatDoor;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_BoatDoor { get { return CharacterBoatDoor; } set { CharacterBoatDoor = value; InvalidateProperties(); } }

		public string CharacterPublicDoor;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_PublicDoor { get { return CharacterPublicDoor; } set { CharacterPublicDoor = value; InvalidateProperties(); } }

		public int CharacterBegging;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Begging { get { return CharacterBegging; } set { CharacterBegging = value; InvalidateProperties(); } }

		public int CharacterWepAbNames;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_WepAbNames { get { return CharacterWepAbNames; } set { CharacterWepAbNames = value; InvalidateProperties(); } }

		public int GumpHue;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Gump_Hue { get { return GumpHue; } set { GumpHue = value; InvalidateProperties(); } }

		public int WeaponBarOpen;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Weapon_yBarOpen { get { return WeaponBarOpen; } set { WeaponBarOpen = value; InvalidateProperties(); } }

		public string CharMusical;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Char_Musical { get{ return CharMusical; } set{ CharMusical = value; } }

		public string CharacterLoot;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Loot { get{ return CharacterLoot; } set{ CharacterLoot = value; } }

		public string CharacterWanted;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Character_Wanted { get{ return CharacterWanted; } set{ CharacterWanted = value; } }

		public int CharacterOriental;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Oriental { get { return CharacterOriental; } set { CharacterOriental = value; InvalidateProperties(); } }

		public int CharacterEvil;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Evil { get { return CharacterEvil; } set { CharacterEvil = value; InvalidateProperties(); } }

		public int CharacterElement;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Element { get { return CharacterElement; } set { CharacterElement = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string MessageQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Message_Quest { get { return MessageQuest; } set { MessageQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string ArtifactQuestTime;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Artifact_QuestTime { get { return ArtifactQuestTime; } set { ArtifactQuestTime = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string StandardQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Standard_Quest { get { return StandardQuest; } set { StandardQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string FishingQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Fishing_Quest { get { return FishingQuest; } set { FishingQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string AssassinQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Assassin_Quest { get { return AssassinQuest; } set { AssassinQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string BardsTaleQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string BardsTale_Quest { get { return BardsTaleQuest; } set { BardsTaleQuest = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string EpicQuestName;
		[CommandProperty( AccessLevel.GameMaster )]
		public string EpicQuest_Name { get{ return EpicQuestName; } set{ EpicQuestName = value; } }

		public int EpicQuestNumber;
		[CommandProperty( AccessLevel.GameMaster )]
		public int EpicQuest_Number { get { return EpicQuestNumber; } set { EpicQuestNumber = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string SpellBarsMage1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage1 { get { return SpellBarsMage1; } set { SpellBarsMage1 = value; InvalidateProperties(); } }

		public string SpellBarsMage2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage2 { get { return SpellBarsMage2; } set { SpellBarsMage2 = value; InvalidateProperties(); } }

		public string SpellBarsMage3;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage3 { get { return SpellBarsMage3; } set { SpellBarsMage3 = value; InvalidateProperties(); } }

		public string SpellBarsMage4;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Mage4 { get { return SpellBarsMage4; } set { SpellBarsMage4 = value; InvalidateProperties(); } }

		public string SpellBarsNecro1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Necro1 { get { return SpellBarsNecro1; } set { SpellBarsNecro1 = value; InvalidateProperties(); } }

		public string SpellBarsNecro2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Necro2 { get { return SpellBarsNecro2; } set { SpellBarsNecro2 = value; InvalidateProperties(); } }

		public string SpellBarsKnight1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Knight1 { get { return SpellBarsKnight1; } set { SpellBarsKnight1 = value; InvalidateProperties(); } }

		public string SpellBarsKnight2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Knight2 { get { return SpellBarsKnight2; } set { SpellBarsKnight2 = value; InvalidateProperties(); } }

		public string SpellBarsDeath1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Death1 { get { return SpellBarsDeath1; } set { SpellBarsDeath1 = value; InvalidateProperties(); } }

		public string SpellBarsDeath2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Death2 { get { return SpellBarsDeath2; } set { SpellBarsDeath2 = value; InvalidateProperties(); } }

		public string SpellBarsBard1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Bard1 { get { return SpellBarsBard1; } set { SpellBarsBard1 = value; InvalidateProperties(); } }

		public string SpellBarsBard2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Bard2 { get { return SpellBarsBard2; } set { SpellBarsBard2 = value; InvalidateProperties(); } }

		public string SpellBarsPriest1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Priest1 { get { return SpellBarsPriest1; } set { SpellBarsPriest1 = value; InvalidateProperties(); } }

		public string SpellBarsPriest2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Priest2 { get { return SpellBarsPriest2; } set { SpellBarsPriest2 = value; InvalidateProperties(); } }

		public string SpellBarsMonk1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Monk1 { get{ return SpellBarsMonk1; } set{ SpellBarsMonk1 = value; } }

		public string SpellBarsMonk2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Monk2 { get{ return SpellBarsMonk2; } set{ SpellBarsMonk2 = value; } }

		public string SpellBarsWizard1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Wizard1 { get { return SpellBarsWizard1; } set { SpellBarsWizard1 = value; InvalidateProperties(); } }

		public string SpellBarsWizard2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Wizard2 { get { return SpellBarsWizard2; } set { SpellBarsWizard2 = value; InvalidateProperties(); } }

		public string SpellBarsWizard3;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Wizard3 { get { return SpellBarsWizard3; } set { SpellBarsWizard3 = value; InvalidateProperties(); } }

		public string SpellBarsElly1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Elly1 { get { return SpellBarsElly1; } set { SpellBarsElly1 = value; InvalidateProperties(); } }

		public string SpellBarsElly2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string SpellBars_Elly2 { get { return SpellBarsElly2; } set { SpellBarsElly2 = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string ThiefQuest;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Thief_Quest { get{ return ThiefQuest; } set{ ThiefQuest = value; } }

		public string KilledSpecialMonsters;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Killed_SpecialMonsters { get{ return KilledSpecialMonsters; } set{ KilledSpecialMonsters = value; } }

		public string MusicPlaylist;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Music_Playlist { get{ return MusicPlaylist; } set{ MusicPlaylist = value; } }

		public int CharacterBarbaric;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Character_Conan { get { return CharacterBarbaric; } set { CharacterBarbaric = value; InvalidateProperties(); } }

		public int SkillDisplay;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Skill_Display { get { return SkillDisplay; } set { SkillDisplay = value; InvalidateProperties(); } }

		public int MagerySpellHue;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Magery_SpellHue { get { return MagerySpellHue; } set { MagerySpellHue = value; InvalidateProperties(); } }

		public int ClassicPoisoning;
		[CommandProperty( AccessLevel.GameMaster )]
		public int Classic_Poisoning { get { return ClassicPoisoning; } set { ClassicPoisoning = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string QuickBar;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Quick_Bar { get { return QuickBar; } set { QuickBar = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		[Constructable]
		public CharacterDatabase() : base( 0x3F1A )
		{
			LootType = LootType.Blessed;
			Visible = false;
			Movable = false;
			Weight = 1.0;
			Name = "Character Statue";
			Hue = 0;
		}

		public override bool DisplayLootType{ get{ return false; } }
		public override bool DisplayWeight{ get{ return false; } }

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( CharacterOwner != null ){ list.Add( 1070722, "Statue of " + CharacterOwner.Name + "" ); }
        }

		public CharacterDatabase( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)3 ); // version

			writer.Write( QuickBar );

			writer.Write( SpellBarsElly1 );
			writer.Write( SpellBarsElly2 );
			writer.Write( CharacterElement );

			writer.Write( (Mobile)CharacterOwner );
			writer.Write( CharacterMOTD );
			writer.Write( CharacterSkill );
			writer.Write( CharacterKeys );
			writer.Write( CharacterDiscovered );
			writer.Write( CharacterSheath );
			writer.Write( CharacterGuilds );
			writer.Write( CharacterBoatDoor );
			writer.Write( CharacterPublicDoor );
			writer.Write( CharacterBegging );
			writer.Write( CharacterWepAbNames );

			writer.Write( ArtifactQuestTime );

			writer.Write( StandardQuest );
			writer.Write( FishingQuest );
			writer.Write( AssassinQuest );
			writer.Write( MessageQuest );
			writer.Write( BardsTaleQuest );

			writer.Write( SpellBarsMage1 );
			writer.Write( SpellBarsMage2 );
			writer.Write( SpellBarsMage3 );
			writer.Write( SpellBarsMage4 );
			writer.Write( SpellBarsNecro1 );
			writer.Write( SpellBarsNecro2 );
			writer.Write( SpellBarsKnight1 );
			writer.Write( SpellBarsKnight2 );
			writer.Write( SpellBarsDeath1 );
			writer.Write( SpellBarsDeath2 );
			writer.Write( SpellBarsBard1 );
			writer.Write( SpellBarsBard2 );
			writer.Write( SpellBarsPriest1 );
			writer.Write( SpellBarsPriest2 );
			writer.Write( SpellBarsWizard1 );
			writer.Write( SpellBarsWizard2 );
			writer.Write( SpellBarsWizard3 );
			writer.Write( SpellBarsMonk1 );
			writer.Write( SpellBarsMonk2 );

			writer.Write( ThiefQuest );
			writer.Write( KilledSpecialMonsters );
			writer.Write( MusicPlaylist );
			writer.Write( CharacterWanted );
			writer.Write( CharacterLoot );
			writer.Write( CharMusical );
			writer.Write( EpicQuestName );
			writer.Write( CharacterBarbaric );
			writer.Write( SkillDisplay );
			writer.Write( MagerySpellHue );
			writer.Write( ClassicPoisoning );
			writer.Write( CharacterEvil );
			writer.Write( CharacterOriental );
			writer.Write( GumpHue );
			writer.Write( WeaponBarOpen );
			writer.Write( EpicQuestNumber );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch( version )
			{
				case 3:
				{
					QuickBar = reader.ReadString();
					goto case 2;
				}
				case 2:
				{
					SpellBarsElly1 = reader.ReadString();
					SpellBarsElly2 = reader.ReadString();
					CharacterElement = reader.ReadInt();
					goto case 1;
				}
				case 1:
				{
					CharacterOwner = reader.ReadMobile();
					CharacterMOTD = reader.ReadInt();
					CharacterSkill = reader.ReadInt();
					CharacterKeys = reader.ReadString();
					CharacterDiscovered = reader.ReadString();
					CharacterSheath = reader.ReadInt();
					CharacterGuilds = reader.ReadInt();
					CharacterBoatDoor = reader.ReadString();
					CharacterPublicDoor = reader.ReadString();
					CharacterBegging = reader.ReadInt();
					CharacterWepAbNames = reader.ReadInt();

					ArtifactQuestTime = reader.ReadString();

					StandardQuest = reader.ReadString();
					FishingQuest = reader.ReadString();
					AssassinQuest = reader.ReadString();
					MessageQuest = reader.ReadString();
					BardsTaleQuest = reader.ReadString();

					SpellBarsMage1 = reader.ReadString();
					SpellBarsMage2 = reader.ReadString();
					SpellBarsMage3 = reader.ReadString();
					SpellBarsMage4 = reader.ReadString();
					SpellBarsNecro1 = reader.ReadString();
					SpellBarsNecro2 = reader.ReadString();
					SpellBarsKnight1 = reader.ReadString();
					SpellBarsKnight2 = reader.ReadString();
					SpellBarsDeath1 = reader.ReadString();
					SpellBarsDeath2 = reader.ReadString();
					SpellBarsBard1 = reader.ReadString();
					SpellBarsBard2 = reader.ReadString();
					SpellBarsPriest1 = reader.ReadString();
					SpellBarsPriest2 = reader.ReadString();
					SpellBarsWizard1 = reader.ReadString();
					SpellBarsWizard2 = reader.ReadString();
					SpellBarsWizard3 = reader.ReadString();
					SpellBarsMonk1 = reader.ReadString();
					SpellBarsMonk2 = reader.ReadString();

					ThiefQuest = reader.ReadString();
					KilledSpecialMonsters = reader.ReadString();
					MusicPlaylist = reader.ReadString();
					CharacterWanted = reader.ReadString();
					CharacterLoot = reader.ReadString();
					CharMusical = reader.ReadString();
					EpicQuestName = reader.ReadString();
					CharacterBarbaric = reader.ReadInt();
					SkillDisplay = reader.ReadInt();
					MagerySpellHue = reader.ReadInt();
					ClassicPoisoning = reader.ReadInt();
					CharacterEvil = reader.ReadInt();
					CharacterOriental = reader.ReadInt();
					GumpHue = reader.ReadInt();
					WeaponBarOpen = reader.ReadInt();
					EpicQuestNumber = reader.ReadInt();
					break;
				}
			}
			Hue = 0;
		}
	}
}

namespace Server.Items
{
	public class SavageBook : DynamicBook
	{
		[Constructable]
		public SavageBook( )
		{
			Weight = 1.0;
			Hue = 0;
			ItemID = 0x2253;

			BookRegion = null;	BookMap = null;		BookWorld = null;	BookItem = null;	BookTrue = 1;	BookPower = 0;

			SetBookCover( 73, this );
			SetStaticText( this );
			BookTitle = "The Savaged Empire";
			Name = BookTitle;
			BookAuthor = "Brom the Conquerer";
		}

		public SavageBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			SetStaticText( this );
		}
	}

	public class WelcomeBookWanted : DynamicBook
	{
		[Constructable]
		public WelcomeBookWanted( )
		{
			Weight = 1.0;
			Hue = 0;
			ItemID = 0xFBE;

			BookRegion = null;	BookMap = null;		BookWorld = null;	BookItem = null;	BookTrue = 1;	BookPower = 0;

			SetBookCover( 60, this );
			SetStaticText( this );
			BookTitle = "Life of a Fugitive";
			Name = BookTitle;
			BookAuthor = "Seryl the Assassin";
		}

		public WelcomeBookWanted( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			SetStaticText( this );
		}
	}

	public class WelcomeBookElf : DynamicBook
	{
		[Constructable]
		public WelcomeBookElf( )
		{
			Weight = 1.0;
			Hue = 0;
			ItemID = 0xFBE;

			BookRegion = null;	BookMap = null;		BookWorld = null;	BookItem = null;	BookTrue = 1;	BookPower = 0;

			SetBookCover( 64, this );
			SetStaticText( this );
			BookTitle = "Elven Lore";
			Name = BookTitle;
			BookAuthor = "Horance the Mage";
		}

		public WelcomeBookElf( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
			SetStaticText( this );
		}
	}

	public class DoorTimeLord : Item
	{
		[Constructable]
		public DoorTimeLord() : base( 0x675 )
		{
			Name = "metal door";
			Weight = 1.0;
		}

		public DoorTimeLord( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
			if ( m.InRange( this.GetWorldLocation(), 2 ) && MyServerSettings.AllowAlienChoice() )
			{
				DoTeleport( m );
			}
			else if ( !MyServerSettings.AllowAlienChoice() )
			{
				m.SendMessage( "This door doesn't seem to budge." );
			}
			else
			{
				m.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public virtual void DoTeleport( Mobile m )
		{
			Point3D p = this.Location;

			if ( m.Y < this.Y ){ p = new Point3D(this.X, (this.Y+1), this.Z); }
			else if ( m.Y > this.Y ){ p = new Point3D(this.X, (this.Y-1), this.Z); }
			m.PlaySound( 0xEC );

			Server.Mobiles.BaseCreature.TeleportPets( m, p, m.Map );

			m.MoveToWorld( p, m.Map );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class AmethystWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }

		[Constructable]
		public AmethystWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the amethyst wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "amethyst", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "amethyst scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public AmethystWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dire wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class DireWolf : BaseCreature
	{
		[Constructable]
		public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dire wolf";
			Body = 225;
			BaseSoundID = 0xE5;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 83.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 7; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 4 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public DireWolf(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}

namespace Server.Mobiles
{
	[CorpseName( "a nightmare corpse" )]
	public class AncientNightmare : BaseCreature
	{
		public override bool HasBreath{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public AncientNightmare() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ancient nightmare";
			Body = 795;
			BaseSoundID = 0xA8;

			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Psychology, 10.4, 50.0 );
			SetSkill( SkillName.Magery, 10.4, 50.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 80.5, 92.5 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 13, 19 ) ) );

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Hellish; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }

		public AncientNightmare( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Engines.CannedEvil;// using System.Collections.Generic;

namespace Server.Mobiles
{
	public abstract class BaseChampion : BaseCreature
	{
		public BaseChampion( AIType aiType ) : this( aiType, FightMode.Closest )
		{
		}

		public BaseChampion( AIType aiType, FightMode mode ) : base( aiType, mode, 18, 1, 0.1, 0.2 )
		{
		}

		public BaseChampion( Serial serial ) : base( serial )
		{
		}

		public abstract ChampionSkullType SkullType{ get; }

		public abstract Type[] UniqueList{ get; }
		public abstract Type[] SharedList{ get; }
		public abstract Type[] DecorativeList{ get; }
		public abstract MonsterStatuetteType[] StatueTypes{ get; }

		public virtual bool NoGoodies{ get{ return false; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public Item GetArtifact()
		{
			double random = Utility.RandomDouble();
			if ( 0.05 >= random )
				return CreateArtifact( UniqueList );
			else if ( 0.15 >= random )
				return CreateArtifact( SharedList );
			else if ( 0.30 >= random )
				return CreateArtifact( DecorativeList );
			return null;
		}

		public Item CreateArtifact( Type[] list )
		{
			if( list.Length == 0 )
				return null;

			int random = Utility.Random( list.Length );

			Type type = list[random];

			Item artifact = Loot.Construct( type );

			if( artifact is MonsterStatuette && StatueTypes.Length > 0 )
			{
				((MonsterStatuette)artifact).Type = StatueTypes[Utility.Random( StatueTypes.Length )];
				((MonsterStatuette)artifact).LootType = LootType.Regular;
			}

			return artifact;
		}

		private PowerScroll CreateRandomPowerScroll()
		{
			int level;
			double random = Utility.RandomDouble();

			if ( 0.05 >= random )
				level = 20;
			else if ( 0.4 >= random )
				level = 15;
			else
				level = 10;

			return PowerScroll.CreateRandomNoCraft( level, level );
		}

		public void GivePowerScrolls()
		{
			if ( Map != Map.Lodor )
				return;

			List<Mobile> toGive = new List<Mobile>();
			List<DamageStore> rights = BaseCreature.GetLootingRights( this.DamageEntries, this.HitsMax );

			for ( int i = rights.Count - 1; i >= 0; --i )
			{
				DamageStore ds = rights[i];

				if ( ds.m_HasRight )
					toGive.Add( ds.m_Mobile );
			}

			if ( toGive.Count == 0 )
				return;

			for( int i = 0; i < toGive.Count; i++ )
			{
				Mobile m = toGive[i];

				if( !(m is PlayerMobile) )
					continue;

				bool gainedPath = false;

				int pointsToGain = 800;

				if( VirtueHelper.Award( m, VirtueName.Valor, pointsToGain, ref gainedPath ) )
				{
					if( gainedPath )
						m.SendLocalizedMessage( 1054032 ); // You have gained a path in Valor!
					else
						m.SendLocalizedMessage( 1054030 ); // You have gained in Valor!

					//No delay on Valor gains
				}
			}

			// Randomize
			for ( int i = 0; i < toGive.Count; ++i )
			{
				int rand = Utility.Random( toGive.Count );
				Mobile hold = toGive[i];
				toGive[i] = toGive[rand];
				toGive[rand] = hold;
			}

			for ( int i = 0; i < 6; ++i )
			{
				Mobile m = toGive[i % toGive.Count];

				PowerScroll ps = CreateRandomPowerScroll();

				GivePowerScrollTo( m, ps );
			}
		}

		public static void GivePowerScrollTo( Mobile m, PowerScroll ps )
		{
			if( ps == null || m == null )	//sanity
				return;

			m.SendLocalizedMessage( 1049524 ); // You have received a scroll of power!

			if( !Core.SE || m.Alive )
				m.AddToBackpack( ps );
			else
			{
				if( m.Corpse != null && !m.Corpse.Deleted )
					m.Corpse.DropItem( ps );
				else
					m.AddToBackpack( ps );
			}

			if( m is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m;

				for( int j = 0; j < pm.JusticeProtectors.Count; ++j )
				{
					Mobile prot = pm.JusticeProtectors[j];

					if( prot.Map != m.Map || prot.Kills >= 5 || prot.Criminal || !JusticeVirtue.CheckMapRegion( m, prot ) )
						continue;

					int chance = 0;

					switch( VirtueHelper.GetLevel( prot, VirtueName.Justice ) )
					{
						case VirtueLevel.Seeker: chance = 60; break;
						case VirtueLevel.Follower: chance = 80; break;
						case VirtueLevel.Knight: chance = 100; break;
					}

					if( chance > Utility.Random( 100 ) )
					{
						PowerScroll powerScroll = new PowerScroll( ps.Skill, ps.Value );

						prot.SendLocalizedMessage( 1049368 ); // You have been rewarded for your dedication to Justice!

						if( !Core.SE || prot.Alive )
							prot.AddToBackpack( powerScroll );
						else
						{
							if( prot.Corpse != null && !prot.Corpse.Deleted )
								prot.Corpse.DropItem( powerScroll );
							else
								prot.AddToBackpack( powerScroll );
						}
					}
				}
			}
		}

		public override bool OnBeforeDeath()
		{
			if ( !NoKillAwards )
			{
				GivePowerScrolls();

				if( NoGoodies )
					return base.OnBeforeDeath();

				Map map = this.Map;

				if ( map != null )
				{
					for ( int x = -12; x <= 12; ++x )
					{
						for ( int y = -12; y <= 12; ++y )
						{
							double dist = Math.Sqrt(x*x+y*y);

							if ( dist <= 12 )
								new GoodiesTimer( map, X + x, Y + y ).Start();
						}
					}
				}
			}

			return base.OnBeforeDeath();
		}

		public override void OnDeath( Container c )
		{
			if ( Map == Map.Lodor )
			{
				//TODO: Confirm SE change or AoS one too?
				List<DamageStore> rights = BaseCreature.GetLootingRights( this.DamageEntries, this.HitsMax );
				List<Mobile> toGive = new List<Mobile>();

				for ( int i = rights.Count - 1; i >= 0; --i )
				{
					DamageStore ds = rights[i];

					if ( ds.m_HasRight )
						toGive.Add( ds.m_Mobile );
				}

				if ( toGive.Count > 0 )
					toGive[Utility.Random( toGive.Count )].AddToBackpack( new ChampionSkull( SkullType ) );
				else
					c.DropItem( new ChampionSkull( SkullType ) );
			}

			base.OnDeath( c );
		}

		private class GoodiesTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public GoodiesTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 10.0 ) )
			{
				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				int z = m_Map.GetAverageZ( m_X, m_Y );
				bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

				for ( int i = -3; !canFit && i <= 3; ++i )
				{
					canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

					if ( canFit )
						z += i;
				}

				if ( !canFit )
					return;

				Gold g = new Gold( 500, 1000 );

				g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 3 ) )
					{
						case 0: // Fire column
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );
							Effects.PlaySound( g, g.Map, 0x208 );

							break;
						}
						case 1: // Explosion
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 );
							Effects.PlaySound( g, g.Map, 0x307 );

							break;
						}
						case 2: // Ball of fire
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 10, 5052 );

							break;
						}
					}
				}
			}
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Network;// using Server.Factions.AI;

namespace Server.Factions
{
	public abstract class BaseFactionGuard : BaseCreature
	{
		private Faction m_Faction;
		private Town m_Town;
		private Orders m_Orders;

		public override bool BardImmune{ get{ return true; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set{ Unregister(); m_Faction = value; Register(); }
		}

		public Orders Orders
		{
			get{ return m_Orders; }
		}

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set{ Unregister(); m_Town = value; Register(); }
		}

		public void Register()
		{
			if ( m_Town != null && m_Faction != null )
				m_Town.RegisterGuard( this );
		}

		public void Unregister()
		{
			if ( m_Town != null )
				m_Town.UnregisterGuard( this );
		}

		public abstract GuardAI GuardAI{ get; }

		protected override BaseAI ForcedAI
		{
			get { return new FactionGuardAI( this ); }
		}

		public override TimeSpan ReacquireDelay{ get{ return TimeSpan.FromSeconds( 2.0 ); } }

		public override bool IsEnemy( Mobile m )
		{
			Faction ourFaction = m_Faction;
			Faction theirFaction = Faction.Find( m );

			if ( theirFaction == null && m is BaseFactionGuard )
				theirFaction = ((BaseFactionGuard)m).Faction;

			if ( ourFaction != null && theirFaction != null && ourFaction != theirFaction )
			{
				ReactionType reactionType = Orders.GetReaction( theirFaction ).Type;

				if ( reactionType == ReactionType.Attack )
					return true;

				if ( theirFaction != null )
				{
					List<AggressorInfo> list = m.Aggressed;

					for ( int i = 0; i < list.Count; ++i )
					{
						AggressorInfo ai = list[i];

						if ( ai.Defender is BaseFactionGuard )
						{
							BaseFactionGuard bf = (BaseFactionGuard)ai.Defender;

							if ( bf.Faction == ourFaction )
								return true;
						}
					}
				}
			}

			return false;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m.Player && m.Alive && InRange( m, 10 ) && !InRange( oldLocation, 10 ) && InLOS( m ) && m_Orders.GetReaction( Faction.Find( m ) ).Type == ReactionType.Warn )
			{
				Direction = GetDirectionTo( m );

				string warning = null;

				switch ( Utility.Random( 6 ) )
				{
					case 0: warning = "I warn you, {0}, you would do well to leave this area before someone shows you the world of gray."; break;
					case 1: warning = "It would be wise to leave this area, {0}, lest your head become my commanders' trophy."; break;
					case 2: warning = "You are bold, {0}, for one of the meager {1}. Leave now, lest you be taught the taste of dirt."; break;
					case 3: warning = "Your presence here is an insult, {0}. Be gone now, knave."; break;
					case 4: warning = "Dost thou wish to be hung by your toes, {0}? Nay? Then come no closer."; break;
					case 5: warning = "Hey, {0}. Yeah, you. Get out of here before I beat you with a stick."; break;
				}

				Faction faction = Faction.Find( m );

				Say( warning, m.Name, faction == null ? "civilians" : faction.Definition.FriendlyName );
			}
		}

		private const int ListenRange = 12;

		public override bool HandlesOnSpeech( Mobile from )
		{
			if ( InRange( from, ListenRange ) )
				return true;

			return base.HandlesOnSpeech( from );
		}

		private DateTime m_OrdersEnd;

		private void ChangeReaction( Faction faction, ReactionType type )
		{
			if ( faction == null )
			{
				switch ( type )
				{
					case ReactionType.Ignore:	Say( 1005179 ); break; // Civilians will now be ignored.
					case ReactionType.Warn:		Say( 1005180 ); break; // Civilians will now be warned of their impending deaths.
					case ReactionType.Attack:	return;
				}
			}
			else
			{
				TextDefinition def = null;

				switch ( type )
				{
					case ReactionType.Ignore:	def = faction.Definition.GuardIgnore; break;
					case ReactionType.Warn:		def = faction.Definition.GuardWarn; break;
					case ReactionType.Attack:	def = faction.Definition.GuardAttack; break;
				}

				if ( def != null && def.Number > 0 )
					Say( def.Number );
				else if ( def != null && def.String != null )
					Say( def.String );
			}

			m_Orders.SetReaction( faction, type );
		}

		private bool WasNamed( string speech )
		{
			string name = this.Name;

			return ( name != null && Insensitive.StartsWith( speech, name ) );
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			base.OnSpeech( e );

			Mobile from = e.Mobile;

			if ( !e.Handled && InRange( from, ListenRange ) && from.Alive )
			{
				if ( e.HasKeyword( 0xE6 ) && (Insensitive.Equals( e.Speech, "orders" ) || WasNamed( e.Speech )) ) // *orders*
				{
					if ( m_Town == null || !m_Town.IsSheriff( from ) )
					{
						this.Say( 1042189 ); // I don't work for you!
					}
					else if ( Town.FromRegion( this.Region ) == m_Town )
					{
						this.Say( 1042180 ); // Your orders, sire?
						m_OrdersEnd = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
					}
				}
				else if ( DateTime.Now < m_OrdersEnd )
				{
					if ( m_Town != null && m_Town.IsSheriff( from ) && Town.FromRegion( this.Region ) == m_Town )
					{
						m_OrdersEnd = DateTime.Now + TimeSpan.FromSeconds( 10.0 );

						bool understood = true;
						ReactionType newType = 0;

						if ( Insensitive.Contains( e.Speech, "attack" ) )
							newType = ReactionType.Attack;
						else if ( Insensitive.Contains( e.Speech, "warn" ) )
							newType = ReactionType.Warn;
						else if ( Insensitive.Contains( e.Speech, "ignore" ) )
							newType = ReactionType.Ignore;
						else
							understood = false;

						if ( understood )
						{
							understood = false;

							if ( Insensitive.Contains( e.Speech, "civil" ) )
							{
								ChangeReaction( null, newType );
								understood = true;
							}

							List<Faction> factions = Faction.Factions;

							for ( int i = 0; i < factions.Count; ++i )
							{
								Faction faction = factions[i];

								if ( faction != m_Faction && Insensitive.Contains( e.Speech, faction.Definition.Keyword ) )
								{
									ChangeReaction( faction, newType );
									understood = true;
								}
							}
						}
						else if ( Insensitive.Contains( e.Speech, "patrol" ) )
						{
							Home = Location;
							RangeHome = 6;
							Combatant = null;
							m_Orders.Movement = MovementType.Patrol;
							Say( 1005146 ); // This spot looks like it needs protection!  I shall guard it with my life.
							understood = true;
						}
						else if ( Insensitive.Contains( e.Speech, "follow" ) )
						{
							Home = Location;
							RangeHome = 6;
							Combatant = null;
							m_Orders.Follow = from;
							m_Orders.Movement = MovementType.Follow;
							Say( 1005144 ); // Yes, Sire.
							understood = true;
						}

						if ( !understood )
							Say( 1042183 ); // I'm sorry, I don't understand your orders...
					}
				}
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_Faction != null && Map == Faction.Facet )
				list.Add( 1060846, m_Faction.Definition.PropName ); // Guard: ~1_val~
		}

		public override void OnSingleClick( Mobile from )
		{
			if ( m_Faction != null && Map == Faction.Facet )
			{
				string text = String.Concat( "(Guard, ", m_Faction.Definition.FriendlyName, ")" );

				int hue = ( Faction.Find( from ) == m_Faction ? 98 : 38 );

				PrivateOverheadMessage( MessageType.Label, hue, true, text, from.NetState );
			}

			base.OnSingleClick( from );
		}

		public virtual void GenerateRandomHair()
		{
			Utility.AssignRandomHair( this );
			Utility.AssignRandomFacialHair( this, HairHue );
		}

		private static Type[] m_StrongPotions = new Type[]
		{
			typeof( GreaterHealPotion ), typeof( GreaterHealPotion ), typeof( GreaterHealPotion ),
			typeof( GreaterCurePotion ), typeof( GreaterCurePotion ), typeof( GreaterCurePotion ),
			typeof( GreaterStrengthPotion ), typeof( GreaterStrengthPotion ),
			typeof( GreaterAgilityPotion ), typeof( GreaterAgilityPotion ),
			typeof( TotalRefreshPotion ), typeof( TotalRefreshPotion ),
			typeof( GreaterExplosionPotion )
		};

		private static Type[] m_WeakPotions = new Type[]
		{
			typeof( HealPotion ), typeof( HealPotion ), typeof( HealPotion ),
			typeof( CurePotion ), typeof( CurePotion ), typeof( CurePotion ),
			typeof( StrengthPotion ), typeof( StrengthPotion ),
			typeof( AgilityPotion ), typeof( AgilityPotion ),
			typeof( RefreshPotion ), typeof( RefreshPotion ),
			typeof( ExplosionPotion )
		};

		public void PackStrongPotions( int min, int max )
		{
			PackStrongPotions( Utility.RandomMinMax( min, max ) );
		}

		public void PackStrongPotions( int count )
		{
			for ( int i = 0; i < count; ++i )
				PackStrongPotion();
		}

		public void PackStrongPotion()
		{
			PackItem( Loot.Construct( m_StrongPotions ) );
		}

		public void PackWeakPotions( int min, int max )
		{
			PackWeakPotions( Utility.RandomMinMax( min, max ) );
		}

		public void PackWeakPotions( int count )
		{
			for ( int i = 0; i < count; ++i )
				PackWeakPotion();
		}

		public void PackWeakPotion()
		{
			PackItem( Loot.Construct( m_WeakPotions ) );
		}

		public Item Immovable( Item item )
		{
			item.Movable = false;
			return item;
		}

		public Item Newbied( Item item )
		{
			item.LootType = LootType.Newbied;
			return item;
		}

		public Item Rehued( Item item, int hue )
		{
			item.Hue = hue;
			return item;
		}

		public Item Layered( Item item, Layer layer )
		{
			item.Layer = layer;
			return item;
		}

		public Item Resourced( BaseWeapon weapon, CraftResource resource )
		{
			weapon.Resource = resource;
			return weapon;
		}

		public Item Resourced( BaseArmor armor, CraftResource resource )
		{
			armor.Resource = resource;
			return armor;
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();
			Unregister();
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			c.Delete();
		}

		public virtual void GenerateBody( bool isFemale, bool randomHair )
		{
			Hue = Utility.RandomSkinColor();

			if ( isFemale )
			{
				Female = true;
				Body = 401;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Female = false;
				Body = 400;
				Name = NameList.RandomName( "male" );
			}

			if ( randomHair )
				GenerateRandomHair();
		}

		public override bool ClickTitle{ get{ return false; } }

		public BaseFactionGuard( string title ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			m_Orders = new Orders( this );
			Title = title;

			RangeHome = 6;
		}

		public BaseFactionGuard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
			Town.WriteReference( writer, m_Town );

			m_Orders.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Faction = Faction.ReadReference( reader );
			m_Town = Town.ReadReference( reader );
			m_Orders = new Orders( this, reader );

			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Register ) );
		}
	}

	public class VirtualMount : IMount
	{
		private VirtualMountItem m_Item;

		public Mobile Rider
		{
			get{ return m_Item.Rider; }
			set{}
		}

		public VirtualMount( VirtualMountItem item )
		{
			m_Item = item;
		}

		public virtual void OnRiderDamaged( int amount, Mobile from, bool willKill )
		{
		}
	}

	public class VirtualMountItem : Item, IMountItem
	{
		private Mobile m_Rider;
		private VirtualMount m_Mount;

		public Mobile Rider{ get{ return m_Rider; } }

		public VirtualMountItem( Mobile mob ) : base( 0x3EA0 )
		{
			Layer = Layer.Mount;

			m_Rider = mob;
			m_Mount = new VirtualMount( this );
		}

		public IMount Mount
		{
			get{ return m_Mount; }
		}

		public VirtualMountItem( Serial serial ) : base( serial )
		{
			m_Mount = new VirtualMount( this );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (Mobile) m_Rider );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Rider = reader.ReadMobile();

			if ( m_Rider == null )
				Delete();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Network;// using Server.Regions;

namespace Server.Factions
{
	public enum AllowedPlacing
	{
		Everywhere,

		AnyFactionTown,
		ControlledFactionTown,
		FactionStronghold
	}

	public abstract class BaseFactionTrap : BaseTrap
	{
		private Faction m_Faction;
		private Mobile m_Placer;
		private DateTime m_TimeOfPlacement;

		private Timer m_Concealing;

		[CommandProperty( AccessLevel.GameMaster )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set{ m_Faction = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Placer
		{
			get{ return m_Placer; }
			set{ m_Placer = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime TimeOfPlacement
		{
			get{ return m_TimeOfPlacement; }
			set{ m_TimeOfPlacement = value; }
		}

		public virtual int EffectSound{ get{ return 0; } }

		public virtual int SilverFromDisarm{ get{ return 100; } }

		public virtual int MessageHue{ get{ return 0; } }

		public virtual int AttackMessage{ get{ return 0; } }
		public virtual int DisarmMessage{ get{ return 0; } }

		public virtual AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.Everywhere; } }

		public virtual TimeSpan ConcealPeriod
		{
			get{ return TimeSpan.FromMinutes( 1.0 ); }
		}

		public virtual TimeSpan DecayPeriod
		{
			get
			{
				if ( Core.AOS )
					return TimeSpan.FromDays( 1.0 );

				return TimeSpan.MaxValue; // no decay
			}
		}

		public override void OnTrigger( Mobile from )
		{
			if ( !IsEnemy( from ) )
				return;

			Conceal();

			DoVisibleEffect();
			Effects.PlaySound( this.Location, this.Map, this.EffectSound );
			DoAttackEffect( from );

			int silverToAward = ( from.Alive ? 20 : 40 );

			if ( silverToAward > 0 && m_Placer != null && m_Faction != null )
			{
				PlayerState victimState = PlayerState.Find( from );

				if ( victimState != null && victimState.CanGiveSilverTo( m_Placer ) && victimState.KillPoints > 0 )
				{
					int silverGiven = m_Faction.AwardSilver( m_Placer, silverToAward );

					if ( silverGiven > 0 )
					{
						// TODO: Get real message
						if ( from.Alive )
							m_Placer.SendMessage( "You have earned {0} silver pieces because {1} fell for your trap.", silverGiven, from.Name );
						else
							m_Placer.SendLocalizedMessage( 1042736, String.Format( "{0} silver\t{1}", silverGiven, from.Name ) ); // You have earned ~1_SILVER_AMOUNT~ pieces for vanquishing ~2_PLAYER_NAME~!
					}

					victimState.OnGivenSilverTo( m_Placer );
				}
			}

			from.LocalOverheadMessage( MessageType.Regular, MessageHue, AttackMessage );
		}

		public abstract void DoVisibleEffect();
		public abstract void DoAttackEffect( Mobile m );

		public virtual int IsValidLocation()
		{
			return IsValidLocation( GetWorldLocation(), Map );
		}

		public virtual int IsValidLocation( Point3D p, Map m )
		{
			if( m == null )
				return 502956; // You cannot place a trap on that.

			if( Core.ML )
			{
				foreach( Item item in m.GetItemsInRange( p, 0 ) )
				{
					if( item is BaseFactionTrap && ((BaseFactionTrap)item).Faction == this.Faction )
						return 1075263; // There is already a trap belonging to your faction at this location.;
				}
			}

			switch( AllowedPlacing )
			{
				case AllowedPlacing.FactionStronghold:
				{
					StrongholdRegion region = (StrongholdRegion) Region.Find( p, m ).GetRegion( typeof( StrongholdRegion ) );

					if ( region != null && region.Faction == m_Faction )
						return 0;

					return 1010355; // This trap can only be placed in your stronghold
				}
				case AllowedPlacing.AnyFactionTown:
				{
					Town town = Town.FromRegion( Region.Find( p, m ) );

					if ( town != null )
						return 0;

					return 1010356; // This trap can only be placed in a faction town
				}
				case AllowedPlacing.ControlledFactionTown:
				{
					Town town = Town.FromRegion( Region.Find( p, m ) );

					if ( town != null && town.Owner == m_Faction )
						return 0;

					return 1010357; // This trap can only be placed in a town your faction controls
				}
			}

			return 0;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );

			if ( !CheckDecay() && CheckRange( m.Location, oldLocation, 6 ) )
			{
				if ( Faction.Find( m ) != null && ((m.Skills[SkillName.Searching].Value - 80.0) / 20.0) > Utility.RandomDouble() )
					PrivateOverheadLocalizedMessage( m, 1010154, MessageHue, "", "" ); // [Faction Trap]
			}
		}

		public void PrivateOverheadLocalizedMessage( Mobile to, int number, int hue, string name, string args )
		{
			if ( to == null )
				return;

			NetState ns = to.NetState;

			if ( ns != null )
				ns.Send( new MessageLocalized( Serial, ItemID, MessageType.Regular, hue, 3, number, name, args ) );
		}

		public BaseFactionTrap( Faction f, Mobile m, int itemID ) : base( itemID )
		{
			Visible = false;

			m_Faction = f;
			m_TimeOfPlacement = DateTime.Now;
			m_Placer = m;
		}

		public BaseFactionTrap( Serial serial ) : base( serial )
		{
		}

		public virtual bool CheckDecay()
		{
			TimeSpan decayPeriod = DecayPeriod;

			if ( decayPeriod == TimeSpan.MaxValue )
				return false;

			if ( (m_TimeOfPlacement + decayPeriod) < DateTime.Now )
			{
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Delete ) );
				return true;
			}

			return false;
		}

		public virtual void BeginConceal()
		{
			if ( m_Concealing != null )
				m_Concealing.Stop();

			m_Concealing = Timer.DelayCall( ConcealPeriod, new TimerCallback( Conceal ) );
		}

		public virtual void Conceal()
		{
			if ( m_Concealing != null )
				m_Concealing.Stop();

			m_Concealing = null;

			if ( !Deleted )
				Visible = false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
			writer.Write( (Mobile) m_Placer );
			writer.Write( (DateTime) m_TimeOfPlacement );

			if ( Visible )
				BeginConceal();
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Faction = Faction.ReadReference( reader );
			m_Placer = reader.ReadMobile();
			m_TimeOfPlacement = reader.ReadDateTime();

			if ( Visible )
				BeginConceal();

			CheckDecay();
		}

		public override void OnDelete()
		{
			if ( m_Faction != null && m_Faction.Traps.Contains( this ) )
				m_Faction.Traps.Remove( this );

			base.OnDelete();
		}

		public virtual bool IsEnemy( Mobile mob )
		{
			if ( mob.Hidden && mob.AccessLevel > AccessLevel.Player )
				return false;

			if ( !mob.Alive || mob.IsDeadBondedPet )
				return false;

			Faction faction = Faction.Find( mob, true );

			if ( faction == null && mob is BaseFactionGuard )
				faction = ((BaseFactionGuard)mob).Faction;

			if ( faction == null )
				return false;

			return ( faction != m_Faction );
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Targeting;// using Server.Items;// using Server;// using Server.Engines.Craft;

namespace Server.Factions
{
	public abstract class BaseFactionTrapDeed : Item, ICraftable
	{
		public abstract Type TrapType{ get; }

		private Faction m_Faction;

		[CommandProperty( AccessLevel.GameMaster )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;

				if ( m_Faction != null )
					Hue = m_Faction.Definition.HuePrimary;
			}
		}

		public BaseFactionTrapDeed( int itemID ) : base( itemID )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public BaseFactionTrapDeed( bool createdFromDeed ) : this( 0x14F0 )
		{
		}

		public BaseFactionTrapDeed( Serial serial ) : base( serial )
		{
		}

		public virtual BaseFactionTrap Construct( Mobile from )
		{
			try{ return Activator.CreateInstance( TrapType, new object[]{ m_Faction, from } ) as BaseFactionTrap; }
			catch{ return null; }
		}

		public override void OnDoubleClick( Mobile from )
		{
			Faction faction = Faction.Find( from );

			if ( faction == null )
				from.SendLocalizedMessage( 1010353, "", 0x23 ); // Only faction members may place faction traps
			else if ( faction != m_Faction )
				from.SendLocalizedMessage( 1010354, "", 0x23 ); // You may only place faction traps created by your faction
			else if( faction.Traps.Count >= faction.MaximumTraps )
				from.SendLocalizedMessage( 1010358, "", 0x23 ); // Your faction already has the maximum number of traps placed
			else
			{
				BaseFactionTrap trap = Construct( from );

				if ( trap == null )
					return;

				int message = trap.IsValidLocation( from.Location, from.Map );

				if ( message > 0 )
				{
					from.SendLocalizedMessage( message, "", 0x23 );
					trap.Delete();
				}
				else
				{
					from.SendLocalizedMessage( 1010360 ); // You arm the trap and carefully hide it from view
					trap.MoveToWorld( from.Location, from.Map );
					faction.Traps.Add( trap );
					Delete();
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Faction = Faction.ReadReference( reader );
		}
		#region ICraftable Members

		public int OnCraft( int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, BaseTool tool, CraftItem craftItem, int resHue )
		{
			ItemID = 0x14F0;
			Faction = Faction.Find( from );

			return 1;
		}

		#endregion
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Mobiles;

namespace Server.Factions
{
	public abstract class BaseFactionVendor : BaseVendor
	{
		private Town m_Town;
		private Faction m_Faction;

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set{ Unregister(); m_Town = value; Register(); }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set{ Unregister(); m_Faction = value; Register(); }
		}

		public void Register()
		{
			if ( m_Town != null && m_Faction != null )
				m_Town.RegisterVendor( this );
		}

		public override bool OnMoveOver( Mobile m )
		{
			if ( Core.ML )
				return true;

			return base.OnMoveOver( m );
		}

		public void Unregister()
		{
			if ( m_Town != null )
				m_Town.UnregisterVendor( this );
		}

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			Unregister();
		}

		public override bool CheckVendorAccess( Mobile from )
		{
			return true;
		}

		public BaseFactionVendor( Town town, Faction faction, string title ) : base( title )
		{
			Frozen = true;
			CantWalk = true;
			Female = false;
			BodyValue = 400;
			Name = NameList.RandomName( "male" );

			RangeHome = 0;

			m_Town = town;
			m_Faction = faction;
			Register();
		}

		public BaseFactionVendor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Faction );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Town = Town.ReadReference( reader );
					m_Faction = Faction.ReadReference( reader );
					Register();
					break;
				}
			}

			Frozen = true;
		}
	}
}
// using System;// using System.Collections.Generic;

namespace Server.Factions
{
	public abstract class BaseMonolith : BaseSystemController
	{
		private Town m_Town;
		private Faction m_Faction;
		private Sigil m_Sigil;

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Sigil Sigil
		{
			get{ return m_Sigil; }
			set
			{
				if ( m_Sigil == value )
					return;

				m_Sigil = value;

				if ( m_Sigil != null && m_Sigil.LastMonolith != null && m_Sigil.LastMonolith != this && m_Sigil.LastMonolith.Sigil == m_Sigil )
					m_Sigil.LastMonolith.Sigil = null;

				if ( m_Sigil != null )
					m_Sigil.LastMonolith = this;

				UpdateSigil();
			}
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set
			{
				m_Town = value;
				OnTownChanged();
			}
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;
				Hue = ( m_Faction == null ? 0 : m_Faction.Definition.HuePrimary );
			}
		}

		public override void OnLocationChange( Point3D oldLocation )
		{
			base.OnLocationChange( oldLocation );
			UpdateSigil();
		}

		public override void OnMapChange()
		{
			base.OnMapChange();
			UpdateSigil();
		}

		public virtual void UpdateSigil()
		{
			if ( m_Sigil == null || m_Sigil.Deleted )
				return;

			m_Sigil.MoveToWorld( new Point3D( X, Y, Z + 18 ), Map );
		}

		public virtual void OnTownChanged()
		{
		}

		public BaseMonolith( Town town, Faction faction ) : base( 0x1183 )
		{
			Movable = false;
			Town = town;
			Faction = faction;
			m_Monoliths.Add( this );
		}

		public BaseMonolith( Serial serial ) : base( serial )
		{
			m_Monoliths.Add( this );
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();
			m_Monoliths.Remove( this );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Faction );

			writer.Write( (Item) m_Sigil );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Town = Town.ReadReference( reader );
					Faction = Faction.ReadReference( reader );
					m_Sigil = reader.ReadItem() as Sigil;
					break;
				}
			}
		}

		private static List<BaseMonolith> m_Monoliths = new List<BaseMonolith>();

		public static List<BaseMonolith> Monoliths
		{
			get{ return m_Monoliths; }
			set{ m_Monoliths = value; }
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;

namespace Server.Items
{
	public class AssassinShroud : BaseOuterTorso // OBSOLETE SEE SCHOLAR ROBE
	{
		[Constructable]
		public AssassinShroud() : this( 0 )
		{
		}

		[Constructable]
		public AssassinShroud( int hue ) : base( 0x2652, hue )
		{
			Name = "scholar robe";
			Weight = 3.0;
		}

		public AssassinShroud( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			if ( Name == "assassin shroud" ){ Name = "scholar robe"; }
		}
	}
}

namespace Server.Items
{
	public abstract class BasePigmentsOfIslesDread : Item, IUsesRemaining
	{
		public override int LabelNumber { get { return 1070933; } } // Pigments of IslesDread

		private int m_UsesRemaining;
		private TextDefinition m_Label;

		protected TextDefinition Label
		{
			get { return m_Label; }
			set { m_Label = value; InvalidateProperties(); }
		}

		#region Old Item Serialization Vars
		/* DO NOT USE! Only used in serialization of pigments that originally derived from Item */
		private bool m_InheritsItem;

		protected bool InheritsItem
		{
			get{ return m_InheritsItem; }
		}
		#endregion

		public BasePigmentsOfIslesDread() : base( 0xEFF )
		{
			Weight = 1.0;
			m_UsesRemaining = 1;
		}

		public BasePigmentsOfIslesDread(  int uses ) : base( 0xEFF )
		{
			Weight = 1.0;
			m_UsesRemaining = uses;
		}

		public BasePigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if( m_Label != null && m_Label > 0 )
				TextDefinition.AddTo( list, m_Label );

			list.Add( 1060584, m_UsesRemaining.ToString() ); // uses remaining: ~1_val~
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( IsAccessibleTo( from ) && from.InRange( GetWorldLocation(), 3 ) )
			{
				from.SendLocalizedMessage( 1070929 ); // Select the artifact or enhanced magic item to dye.
				from.BeginTarget( 3, false, Server.Targeting.TargetFlags.None, new TargetStateCallback( InternalCallback ), this );
			}
			else
				from.SendLocalizedMessage( 502436 ); // That is not accessible.
		}

		private void InternalCallback( Mobile from, object targeted, object state )
		{
			BasePigmentsOfIslesDread pigment = (BasePigmentsOfIslesDread)state;

			if( pigment.Deleted || pigment.UsesRemaining <= 0 || !from.InRange( pigment.GetWorldLocation(), 3 ) || !pigment.IsAccessibleTo( from ))
				return;

			Item i = targeted as Item;

			if( i == null )
				from.SendLocalizedMessage( 1070931 ); // You can only dye artifacts and enhanced magic items with this tub.
			else if( !from.InRange( i.GetWorldLocation(), 3 ) || !IsAccessibleTo( from ) )
				from.SendLocalizedMessage( 502436 ); // That is not accessible.
			else if( from.Items.Contains( i ) )
				from.SendLocalizedMessage( 1070930 ); // Can't dye artifacts or enhanced magic items that are being worn.
			else if( i.IsLockedDown )
				from.SendLocalizedMessage( 1070932 ); // You may not dye artifacts and enhanced magic items which are locked down.
			else if( i is MetalPigmentsOfIslesDread )
				from.SendLocalizedMessage( 1042417 ); // You cannot dye that.
			else if( i is LesserPigmentsOfIslesDread )
				from.SendLocalizedMessage( 1042417 ); // You cannot dye that.
			else if( i is PigmentsOfIslesDread )
				from.SendLocalizedMessage( 1042417 ); // You cannot dye that.
			else if( !IsValidItem( i ) )
				from.SendLocalizedMessage( 1070931 ); // You can only dye artifacts and enhanced magic items with this tub.	//Yes, it says tub on OSI.  Don't ask me why ;p
			else
			{
				//Notes: on OSI there IS no hue check to see if it's already hued.  and no messages on successful hue either
				i.Hue = Hue;

				if( --pigment.UsesRemaining <= 0 )
					pigment.Delete();

				from.PlaySound(0x23E); // As per OSI TC1
			}
		}

		public static bool IsValidItem( Item i )
		{
			if( i is BasePigmentsOfIslesDread )
				return false;

			Type t = i.GetType();

			CraftResource resource = CraftResource.None;

			if( i is BaseWeapon )
				resource = ((BaseWeapon)i).Resource;
			else if( i is BaseArmor )
				resource = ((BaseArmor)i).Resource;
			else if (i is BaseClothing)
				resource = ((BaseClothing)i).Resource;

			if( !CraftResources.IsStandard( resource ) )
				return true;

			if ( i is IIslesDreadDyable )
				return true;

			return(
				IsInTypeList( t, TreasuresOfTokuno.LesserArtifactsTotal )
				|| IsInTypeList( t, TreasuresOfTokuno.GreaterArtifacts )
				|| IsInTypeList( t, StealableArtifactsSpawner.TypesOfEntires )
				);
		}

		private static bool IsInTypeList( Type t, Type[] list )
		{
			for( int i = 0; i < list.Length; i++ )
			{
				if( list[i] == t ) return true;
			}

			return false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );

			writer.WriteEncodedInt( m_UsesRemaining );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_UsesRemaining = reader.ReadEncodedInt();
					break;
				}
				case 0: // Old pigments that inherited from item
				{
					m_InheritsItem = true;

					if ( this is LesserPigmentsOfIslesDread )
						((LesserPigmentsOfIslesDread)this).Type = (LesserPigmentType)reader.ReadEncodedInt();
					else if ( this is PigmentsOfIslesDread )
						((PigmentsOfIslesDread)this).Type = (PigmentType)reader.ReadEncodedInt();
					else if ( this is MetalPigmentsOfIslesDread )
						reader.ReadEncodedInt();

					m_UsesRemaining = reader.ReadEncodedInt();

					break;
				}
			}


		}

		#region IUsesRemaining Members

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

		public bool ShowUsesRemaining
		{
			get { return true; }
			set {}
		}

		#endregion
	}
}// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.ContextMenus;

namespace Server.Engines.Quests
{
	public class TalkEntry : ContextMenuEntry
	{
		private BaseQuester m_Quester;

		public TalkEntry( BaseQuester quester ) : base( quester.TalkNumber )
		{
			m_Quester = quester;
		}

		public override void OnClick()
		{
			Mobile from = Owner.From;

			if ( from.CheckAlive() && from is PlayerMobile && m_Quester.CanTalkTo( (PlayerMobile)from ) )
				m_Quester.OnTalk( (PlayerMobile)from, true );
		}
	}

	public abstract class BaseQuester : BaseVendor
	{
        protected List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool IsActiveVendor{ get{ return false; } }
		public override bool IsInvulnerable{ get{ return true; } }
		public override bool DisallowAllMoves{ get{ return true; } }
		public override bool ClickTitle{ get { return false; } }
		public override bool CanTeach{ get{ return false; } }

		public virtual int TalkNumber{ get{ return 6146; } } // Talk

		public override void InitSBInfo()
		{
		}

		public BaseQuester() : this( null )
		{
		}

		public BaseQuester( string title ) : base( title )
		{
		}

		public BaseQuester( Serial serial ) : base( serial )
		{
		}

		public abstract void OnTalk( PlayerMobile player, bool contextMenu );

		public virtual bool CanTalkTo( PlayerMobile to )
		{
			return true;
		}

		public virtual int GetAutoTalkRange( PlayerMobile m )
		{
			return -1;
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		protected Item SetHue( Item item, int hue )
		{
			item.Hue = hue;
			return item;
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.AddCustomContextEntries( from, list );

			if ( from.Alive && from is PlayerMobile && TalkNumber > 0 && CanTalkTo( (PlayerMobile)from ) )
				list.Add( new TalkEntry( this ) );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m.Alive && m is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m;

				int range = GetAutoTalkRange( pm );

				if ( m.Alive && range >= 0 && InRange( m, range ) && !InRange( oldLocation, range ) && CanTalkTo( pm ) )
					OnTalk( pm, false );
			}
		}

		public void FocusTo( Mobile to )
		{
			QuestSystem.FocusTo( this, to );
		}

		public static Container GetNewContainer()
		{
			Bag bag = new Bag();
			bag.Hue = QuestSystem.RandomBrightHue();
			return bag;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public abstract class BaseSystemController : Item
	{
		private int m_LabelNumber;

		public virtual int DefaultLabelNumber{ get{ return base.LabelNumber; } }
		public new virtual string DefaultName{ get{ return null; } }

		public override int LabelNumber
		{
			get
			{
				if ( m_LabelNumber > 0 )
					return m_LabelNumber;

				return DefaultLabelNumber;
			}
		}

		public virtual void AssignName( TextDefinition name )
		{
			if ( name != null && name.Number > 0 )
			{
				m_LabelNumber = name.Number;
				Name = null;
			}
			else if ( name != null && name.String != null )
			{
				m_LabelNumber = 0;
				Name = name.String;
			}
			else
			{
				m_LabelNumber = 0;
				Name = DefaultName;
			}

			InvalidateProperties();
		}

		public BaseSystemController( int itemID ) : base( itemID )
		{
		}

		public BaseSystemController( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BlackDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public BlackDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a black dragon";
			Body = 12;
			Hue = 0x966;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Black", "", c, 25, 0 );
				}
			}
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Black ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public BlackDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Spells;

namespace Server.Ethics.Hero
{
	public sealed class Bless : Power
	{
		public Bless()
		{
			m_Definition = new PowerDefinition(
					15,
					"Bless",
					"Erstok Ontawl",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, true, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Where do you wish to bless?" );
		}

		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;

			IPoint3D p = obj as IPoint3D;

			if ( p == null )
				return;

			if ( !CheckInvoke( from ) )
				return;

			bool powerFunctioned = false;

			SpellHelper.GetSurfaceTop( ref p );

			foreach ( Mobile mob in from.Mobile.GetMobilesInRange( 6 ) )
			{
				if ( mob != from.Mobile && SpellHelper.ValidIndirectTarget( from.Mobile, mob ) )
					continue;

				if ( mob.GetStatMod( "Holy Bless" ) != null )
					continue;

				if ( !from.Mobile.CanBeBeneficial( mob, false ) )
					continue;

				from.Mobile.DoBeneficial( mob );

				mob.AddStatMod( new StatMod( StatType.All, "Holy Bless", 10, TimeSpan.FromMinutes( 30.0 ) ) );

				mob.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Waist );
				mob.PlaySound( 0x1EA );

				powerFunctioned = true;
			}

			if ( powerFunctioned )
			{
				SpellHelper.Turn( from.Mobile, p );

				Effects.PlaySound( p, from.Mobile.Map, 0x299 );

				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You consecrate the area." );

				FinishInvoke( from );
			}
			else
			{
				from.Mobile.FixedEffect( 0x3735, 6, 30 );
				from.Mobile.PlaySound( 0x5C );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;// using Server.Spells;

namespace Server.Ethics.Evil
{
	public sealed class Blight : Power
	{
		public Blight()
		{
			m_Definition = new PowerDefinition(
					15,
					"Blight",
					"Velgo Ontawl",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, true, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Where do you wish to blight?" );
		}

		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;

			IPoint3D p = obj as IPoint3D;

			if ( p == null )
				return;

			if ( !CheckInvoke( from ) )
				return;

			bool powerFunctioned = false;

			SpellHelper.GetSurfaceTop( ref p );

			foreach ( Mobile mob in from.Mobile.GetMobilesInRange( 6 ) )
			{
				if ( mob == from.Mobile || !SpellHelper.ValidIndirectTarget( from.Mobile, mob ) )
					continue;

				if ( mob.GetStatMod( "Holy Curse" ) != null )
					continue;

				if ( !from.Mobile.CanBeHarmful( mob, false ) )
					continue;

				from.Mobile.DoHarmful( mob, true );

				mob.AddStatMod( new StatMod( StatType.All, "Holy Curse", -10, TimeSpan.FromMinutes( 30.0 ) ) );

				mob.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Waist );
				mob.PlaySound( 0x1FB );

				powerFunctioned = true;
			}

			if ( powerFunctioned )
			{
				SpellHelper.Turn( from.Mobile, p );

				Effects.PlaySound( p, from.Mobile.Map, 0x1FB );

				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You curse the area." );

				FinishInvoke( from );
			}
			else
			{
				from.Mobile.FixedEffect( 0x3735, 6, 30 );
				from.Mobile.PlaySound( 0x5C );
			}
		}
	}
}// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class BlueDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 13 ); }

		[Constructable]
		public BlueDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a blue dragon";
			Body = 12;
			Hue = 0x1F4;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Energy, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Fire, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Blue", "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Blue ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public BlueDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class Britain : Town
	{
		public Britain()
		{
			Definition =
				new TownDefinition(
					0,
					0x1869,
					"Britain",
					"Britain",
					new TextDefinition( 1011433, "BRITAIN" ),
					new TextDefinition( 1011561, "TOWN STONE FOR BRITAIN" ),
					new TextDefinition( 1041034, "The Faction Sigil Monolith of Britain" ),
					new TextDefinition( 1041404, "The Faction Town Sigil Monolith of Britain" ),
					new TextDefinition( 1041413, "Faction Town Stone of Britain" ),
					new TextDefinition( 1041395, "Faction Town Sigil of Britain" ),
					new TextDefinition( 1041386, "Corrupted Faction Town Sigil of Britain" ),
					new Point3D( 1592, 1680, 10 ),
					new Point3D( 1588, 1676, 10 ) );
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bullradon corpse" )]
	public class Bullradon : BaseCreature
	{
		[Constructable]
		public Bullradon() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a bullradon";
			Body = 0x11C;

			SetStr( 146, 175 );
			SetDex( 111, 150 );
			SetInt( 46, 60 );

			SetHits( 131, 160 );
			SetMana( 0 );

			SetDamage( 6, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 70 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Poison, 40, 60 );
			SetResistance( ResistanceType.Energy, 30, 50 );

			SetSkill( SkillName.MagicResist, 37.6, 42.5 );
			SetSkill( SkillName.Tactics, 70.6, 83.0 );
			SetSkill( SkillName.FistFighting, 50.1, 57.5 );

			Fame = 2000;
			Karma = -2000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 68.7;
		}

		public override int GetAngerSound()
		{
			return 0x4F8;
		}

		public override int GetIdleSound()
		{
			return 0x4F7;
		}

		public override int GetAttackSound()
		{
			return 0x4F6;
		}

		public override int GetHurtSound()
		{
			return 0x4F9;
		}

		public override int GetDeathSound()
		{
			return 0x4F5;
		}

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 15; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }

		public Bullradon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}// using System;// using System.Xml;// using Server;// using Server.Regions;// using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class CancelQuestRegion : BaseRegion
	{
		private Type m_Quest;

		public Type Quest{ get{ return m_Quest; } }

		public CancelQuestRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
			ReadType( xml["quest"], "type", ref m_Quest );
		}

		public override bool OnMoveInto( Mobile m, Direction d, Point3D newLocation, Point3D oldLocation )
		{
			if ( !base.OnMoveInto ( m, d, newLocation, oldLocation ) )
				return false;

			if ( m.AccessLevel > AccessLevel.Player )
				return true;

			if ( m_Quest == null )
				return true;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null && player.Quest != null && player.Quest.GetType() == m_Quest )
			{
				if ( !player.HasGump( typeof( QuestCancelGump ) ) )
					player.Quest.BeginCancelQuest();

				return false;
			}

			return true;
		}
	}
}
// using System;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a cave bear corpse" )]
	public class CaveBear : BaseCreature
	{
		[Constructable]
		public CaveBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a cave bear";
			Body = 190;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public CaveBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;

namespace Server.Engines.CannedEvil
{
	public class ChampionAltar : PentagramAddon
	{
		private ChampionSpawn m_Spawn;

		public ChampionAltar( ChampionSpawn spawn )
		{
			m_Spawn = spawn;
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if ( m_Spawn != null )
				m_Spawn.Delete();
		}

		public ChampionAltar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Spawn );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Spawn = reader.ReadItem() as ChampionSpawn;

					if ( m_Spawn == null )
						Delete();

					break;
				}
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;

namespace Server.Engines.CannedEvil
{
	public class ChampionPlatform : BaseAddon
	{
		private ChampionSpawn m_Spawn;

		public ChampionPlatform( ChampionSpawn spawn )
		{
			m_Spawn = spawn;

			for ( int x = -2; x <= 2; ++x )
				for ( int y = -2; y <= 2; ++y )
					AddComponent( 0x750, x, y, -5 );

			for ( int x = -1; x <= 1; ++x )
				for ( int y = -1; y <= 1; ++y )
					AddComponent( 0x750, x, y, 0 );

			for ( int i = -1; i <= 1; ++i )
			{
				AddComponent( 0x751, i, 2, 0 );
				AddComponent( 0x752, 2, i, 0 );

				AddComponent( 0x753, i, -2, 0 );
				AddComponent( 0x754, -2, i, 0 );
			}

			AddComponent( 0x759, -2, -2, 0 );
			AddComponent( 0x75A, 2, 2, 0 );
			AddComponent( 0x75B, -2, 2, 0 );
			AddComponent( 0x75C, 2, -2, 0 );
		}

		public void AddComponent( int id, int x, int y, int z )
		{
			AddonComponent ac = new AddonComponent( id );

			ac.Hue = 0x497;

			AddComponent( ac, x, y, z );
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if ( m_Spawn != null )
				m_Spawn.Delete();
		}

		public ChampionPlatform( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Spawn );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Spawn = reader.ReadItem() as ChampionSpawn;

					if ( m_Spawn == null )
						Delete();

					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Engines.CannedEvil;

namespace Server.Items
{
	public class ChampionSkull : Item
	{
		private ChampionSkullType m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public ChampionSkullType Type{ get{ return m_Type; } set{ m_Type = value; InvalidateProperties(); } }

		public override int LabelNumber{ get{ return 1049479 + (int)m_Type; } }

		[Constructable]
		public ChampionSkull( ChampionSkullType type ) : base( 0x1AE1 )
		{
			m_Type = type;
			LootType = LootType.Cursed;

			// TODO: All hue values
			switch ( type )
			{
				case ChampionSkullType.Power: Hue = 0x159; break;
				case ChampionSkullType.Venom: Hue = 0x172; break;
				case ChampionSkullType.Greed: Hue = 0x1EE; break;
				case ChampionSkullType.Death: Hue = 0x025; break;
				case ChampionSkullType.Pain:  Hue = 0x035; break;
			}
		}

		public ChampionSkull( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (int) m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				case 0:
				{
					m_Type = (ChampionSkullType)reader.ReadInt();

					break;
				}
			}

			if( version == 0 )
			{
				if ( LootType != LootType.Cursed )
					LootType = LootType.Cursed;

				if ( Insured )
					Insured = false;
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Targeting;// using Server.Mobiles;

namespace Server.Engines.CannedEvil
{
	public class ChampionSkullBrazier : AddonComponent
	{
		private ChampionSkullPlatform m_Platform;
		private ChampionSkullType m_Type;
		private Item m_Skull;

		[CommandProperty( AccessLevel.GameMaster )]
		public ChampionSkullPlatform Platform{ get{ return m_Platform; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public ChampionSkullType Type{ get{ return m_Type; } set{ m_Type = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Item Skull{ get{ return m_Skull; } set{ m_Skull = value; if ( m_Platform != null ) m_Platform.Validate(); } }

		public override int LabelNumber{ get{ return 1049489 + (int)m_Type; } }

		public ChampionSkullBrazier( ChampionSkullPlatform platform, ChampionSkullType type ) : base( 0x19BB )
		{
			Hue = 0x455;
			Light = LightType.Circle300;

			m_Platform = platform;
			m_Type = type;
		}

		public ChampionSkullBrazier( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Platform != null )
				m_Platform.Validate();

			BeginSacrifice( from );
		}

		public void BeginSacrifice( Mobile from )
		{
			if ( Deleted )
				return;

			if ( m_Skull != null && m_Skull.Deleted )
				Skull = null;

			if ( from.Map != this.Map || !from.InRange( GetWorldLocation(), 3 ) )
			{
				from.SendLocalizedMessage( 500446 ); // That is too far away.
			}
			else if ( m_Skull == null )
			{
				from.SendLocalizedMessage( 1049485 ); // What would you like to sacrifice?
				from.Target = new SacrificeTarget( this );
			}
			else
			{
				SendLocalizedMessageTo( from, 1049487, "" ); // I already have my champions awakening skull!
			}
		}

		public void EndSacrifice( Mobile from, ChampionSkull skull )
		{
			if ( Deleted )
				return;

			if ( m_Skull != null && m_Skull.Deleted )
				Skull = null;

			if ( from.Map != this.Map || !from.InRange( GetWorldLocation(), 3 ) )
			{
				from.SendLocalizedMessage( 500446 ); // That is too far away.
			}
			else if ( skull == null )
			{
				SendLocalizedMessageTo( from, 1049488, "" ); // That is not my champions awakening skull!
			}
			else if ( m_Skull != null )
			{
				SendLocalizedMessageTo( from, 1049487, "" ); // I already have my champions awakening skull!
			}
			else if ( !skull.IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1049486 ); // You can only sacrifice items that are in your backpack!
			}
			else
			{
				if ( skull.Type == this.Type )
				{
					skull.Movable = false;
					skull.MoveToWorld( GetWorldTop(), this.Map );

					this.Skull = skull;
				}
				else
				{
					SendLocalizedMessageTo( from, 1049488, "" ); // That is not my champions awakening skull!
				}
			}
		}

		private class SacrificeTarget : Target
		{
			private ChampionSkullBrazier m_Brazier;

			public SacrificeTarget( ChampionSkullBrazier brazier ) : base( 12, false, TargetFlags.None )
			{
				m_Brazier = brazier;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				m_Brazier.EndSacrifice( from, targeted as ChampionSkull );
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (int) m_Type );
			writer.Write( m_Platform );
			writer.Write( m_Skull );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Type = (ChampionSkullType)reader.ReadInt();
					m_Platform = reader.ReadItem() as ChampionSkullPlatform;
					m_Skull = reader.ReadItem();

					if ( m_Platform == null )
						Delete();

					break;
				}
			}

			if ( Hue == 0x497 )
				Hue = 0x455;

			if ( Light != LightType.Circle300 )
				Light = LightType.Circle300;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Engines.CannedEvil
{
	public class ChampionSkullPlatform : BaseAddon
	{
		private ChampionSkullBrazier m_Power, m_Enlightenment, m_Venom, m_Pain, m_Greed, m_Death;

		[Constructable]
		public ChampionSkullPlatform()
		{
			AddComponent( new AddonComponent( 0x71A ), -1, -1, -1 );
			AddComponent( new AddonComponent( 0x709 ),  0, -1, -1 );
			AddComponent( new AddonComponent( 0x709 ),  1, -1, -1 );
			AddComponent( new AddonComponent( 0x709 ), -1,  0, -1 );
			AddComponent( new AddonComponent( 0x709 ),  0,  0, -1 );
			AddComponent( new AddonComponent( 0x709 ),  1,  0, -1 );
			AddComponent( new AddonComponent( 0x709 ), -1,  1, -1 );
			AddComponent( new AddonComponent( 0x709 ),  0,  1, -1 );
			AddComponent( new AddonComponent( 0x71B ),  1,  1, -1 );

			AddComponent( new AddonComponent( 0x50F ),  0, -1, 4 );
			AddComponent( m_Power = new ChampionSkullBrazier( this, ChampionSkullType.Power ),  0, -1, 5 );

			AddComponent( new AddonComponent( 0x50F ),  1, -1, 4 );
			AddComponent( m_Enlightenment = new ChampionSkullBrazier( this, ChampionSkullType.Enlightenment ),  1, -1, 5 );

			AddComponent( new AddonComponent( 0x50F ), -1,  0, 4 );
			AddComponent( m_Venom = new ChampionSkullBrazier( this, ChampionSkullType.Venom ), -1,  0, 5 );

			AddComponent( new AddonComponent( 0x50F ),  1,  0, 4 );
			AddComponent( m_Pain = new ChampionSkullBrazier( this, ChampionSkullType.Pain ),  1,  0, 5 );

			AddComponent( new AddonComponent( 0x50F ), -1,  1, 4 );
			AddComponent( m_Greed = new ChampionSkullBrazier( this, ChampionSkullType.Greed ), -1,  1, 5 );

			AddComponent( new AddonComponent( 0x50F ),  0,  1, 4 );
			AddComponent( m_Death = new ChampionSkullBrazier( this, ChampionSkullType.Death ),  0,  1, 5 );

			AddonComponent comp = new LocalizedAddonComponent( 0x20D2, 1049495 );
			comp.Hue = 0x482;
			AddComponent( comp, 0, 0, 5 );

			comp = new LocalizedAddonComponent( 0x0BCF, 1049496 );
			comp.Hue = 0x482;
			AddComponent( comp, 0, 2, -7 );

			comp = new LocalizedAddonComponent( 0x0BD0, 1049497 );
			comp.Hue = 0x482;
			AddComponent( comp, 2, 0, -7 );
		}

		public void Validate()
		{
			if ( Validate( m_Power ) && Validate( m_Enlightenment ) && Validate( m_Venom ) && Validate( m_Pain ) && Validate( m_Greed ) && Validate( m_Death ) )
			{
				Clear( m_Power );
				Clear( m_Enlightenment );
				Clear( m_Venom );
				Clear( m_Pain );
				Clear( m_Greed );
				Clear( m_Death );
			}
		}

		public void Clear( ChampionSkullBrazier brazier )
		{
			if ( brazier != null )
			{
				Effects.SendBoltEffect( brazier );

				if ( brazier.Skull != null )
					brazier.Skull.Delete();
			}
		}

		public bool Validate( ChampionSkullBrazier brazier )
		{
			return ( brazier != null && brazier.Skull != null && !brazier.Skull.Deleted );
		}

		public ChampionSkullPlatform( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Power );
			writer.Write( m_Enlightenment );
			writer.Write( m_Venom );
			writer.Write( m_Pain );
			writer.Write( m_Greed );
			writer.Write( m_Death );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Power = reader.ReadItem() as ChampionSkullBrazier;
					m_Enlightenment = reader.ReadItem() as ChampionSkullBrazier;
					m_Venom = reader.ReadItem() as ChampionSkullBrazier;
					m_Pain = reader.ReadItem() as ChampionSkullBrazier;
					m_Greed = reader.ReadItem() as ChampionSkullBrazier;
					m_Death = reader.ReadItem() as ChampionSkullBrazier;

					break;
				}
			}
		}
	}
}
// using System;// using Server;

namespace Server.Engines.CannedEvil
{
	public enum ChampionSkullType
	{
		Power,
		Enlightenment,
		Venom,
		Pain,
		Greed,
		Death
	}
}
// using System;// using System.Collections;// using Server;// using Server.Gumps;// using Server.Items;// using Server.Mobiles;// using Server.Regions;// using System.Collections.Generic;

namespace Server.Engines.CannedEvil
{
	public class ChampionSpawn : Item
	{
		private bool m_Active;
		private bool m_RandomizeType;
		private ChampionSpawnType m_Type;
		private List<Mobile> m_Creatures;
		private List<Item> m_RedSkulls;
		private List<Item> m_WhiteSkulls;
		private ChampionPlatform m_Platform;
		private ChampionAltar m_Altar;
		private int m_Kills;
		private Mobile m_Champion;

		//private int m_SpawnRange;
		private Rectangle2D m_SpawnArea;
		private ChampionSpawnRegion m_Region;

		private TimeSpan m_ExpireDelay;
		private DateTime m_ExpireTime;

		private TimeSpan m_RestartDelay;
		private DateTime m_RestartTime;

		private Timer m_Timer, m_RestartTimer;

		private IdolOfTheChampion m_Idol;

		private bool m_HasBeenAdvanced;
		private bool m_ConfinedRoaming;

		private Dictionary<Mobile, int> m_DamageEntries;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool ConfinedRoaming
		{
			get { return m_ConfinedRoaming; }
			set { m_ConfinedRoaming = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool HasBeenAdvanced
		{
			get { return m_HasBeenAdvanced; }
			set { m_HasBeenAdvanced = value; }
		}

		[Constructable]
		public ChampionSpawn() : base( 0xBD2 )
		{
			Movable = false;
			Visible = false;

			m_Creatures = new List<Mobile>();
			m_RedSkulls = new List<Item>();
			m_WhiteSkulls = new List<Item>();

			m_Platform = new ChampionPlatform( this );
			m_Altar = new ChampionAltar( this );
			m_Idol = new IdolOfTheChampion( this );

			m_ExpireDelay = TimeSpan.FromMinutes( 10.0 );
			m_RestartDelay = TimeSpan.FromMinutes( 10.0 );

			m_DamageEntries = new Dictionary<Mobile, int>();

			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( SetInitialSpawnArea ) );
		}

		public void SetInitialSpawnArea()
		{
			//Previous default used to be 24;
			SpawnArea = new Rectangle2D( new Point2D( X - 24, Y - 24 ), new Point2D( X + 24, Y + 24 ) );
		}

		public void UpdateRegion()
		{
			if( m_Region != null )
				m_Region.Unregister();

			if( !Deleted && this.Map != Map.Internal )
			{
				m_Region = new ChampionSpawnRegion( this );
				m_Region.Register();
			}

			/*
			if( m_Region == null )
			{
				m_Region = new ChampionSpawnRegion( this );
			}
			else
			{
				m_Region.Unregister();
				//Why doesn't Region allow me to set it's map/Area meself? ><
				m_Region = new ChampionSpawnRegion( this );
			}
			*/
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool RandomizeType
		{
			get { return m_RandomizeType; }
			set { m_RandomizeType = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Kills
		{
			get
			{
				return m_Kills;
			}
			set
			{
				m_Kills = value;
				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Rectangle2D SpawnArea
		{
			get
			{
				return m_SpawnArea;
			}
			set
			{
				m_SpawnArea = value;
				InvalidateProperties();
				UpdateRegion();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan RestartDelay
		{
			get
			{
				return m_RestartDelay;
			}
			set
			{
				m_RestartDelay = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime RestartTime
		{
			get
			{
				return m_RestartTime;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan ExpireDelay
		{
			get
			{
				return m_ExpireDelay;
			}
			set
			{
				m_ExpireDelay = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime ExpireTime
		{
			get
			{
				return m_ExpireTime;
			}
			set
			{
				m_ExpireTime = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public ChampionSpawnType Type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Active
		{
			get
			{
				return m_Active;
			}
			set
			{
				if( value )
					Start();
				else
					Stop();

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Champion
		{
			get
			{
				return m_Champion;
			}
			set
			{
				m_Champion = value;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level
		{
			get
			{
				return m_RedSkulls.Count;
			}
			set
			{
				for( int i = m_RedSkulls.Count - 1; i >= value; --i )
				{
					m_RedSkulls[i].Delete();
					m_RedSkulls.RemoveAt( i );
				}

				for( int i = m_RedSkulls.Count; i < value; ++i )
				{
					Item skull = new Item( 0x1854 );

					skull.Hue = 0x26;
					skull.Movable = false;
					skull.Light = LightType.Circle150;

					skull.MoveToWorld( GetRedSkullLocation( i ), Map );

					m_RedSkulls.Add( skull );
				}

				InvalidateProperties();
			}
		}

		public int MaxKills
		{
			get
			{
				return 250 - (Level * 12);
			}
		}

		public bool IsChampionSpawn( Mobile m )
		{
			return m_Creatures.Contains( m );
		}

		public void SetWhiteSkullCount( int val )
		{
			for( int i = m_WhiteSkulls.Count - 1; i >= val; --i )
			{
				m_WhiteSkulls[i].Delete();
				m_WhiteSkulls.RemoveAt( i );
			}

			for( int i = m_WhiteSkulls.Count; i < val; ++i )
			{
				Item skull = new Item( 0x1854 );

				skull.Movable = false;
				skull.Light = LightType.Circle150;

				skull.MoveToWorld( GetWhiteSkullLocation( i ), Map );

				m_WhiteSkulls.Add( skull );

				Effects.PlaySound( skull.Location, skull.Map, 0x29 );
				Effects.SendLocationEffect( new Point3D( skull.X + 1, skull.Y + 1, skull.Z ), skull.Map, 0x3728, 10 );
			}
		}

		public void Start()
		{
			if( m_Active || Deleted )
				return;

			m_Active = true;
			m_HasBeenAdvanced = false;

			if( m_Timer != null )
				m_Timer.Stop();

			m_Timer = new SliceTimer( this );
			m_Timer.Start();

			if( m_RestartTimer != null )
				m_RestartTimer.Stop();

			m_RestartTimer = null;

			if( m_Altar != null )
			{
				if ( m_Champion != null )
					m_Altar.Hue = 0x26;
				else
					m_Altar.Hue = 0;
			}

			if ( m_Platform != null )
				m_Platform.Hue = 0x452;
		}

		public void Stop()
		{
			if( !m_Active || Deleted )
				return;

			m_Active = false;
			m_HasBeenAdvanced = false;

			if( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;

			if( m_RestartTimer != null )
				m_RestartTimer.Stop();

			m_RestartTimer = null;

			if( m_Altar != null )
				m_Altar.Hue = 0;

			if ( m_Platform != null )
				m_Platform.Hue = 0x497;
		}

		public void BeginRestart( TimeSpan ts )
		{
			if( m_RestartTimer != null )
				m_RestartTimer.Stop();

			m_RestartTime = DateTime.Now + ts;

			m_RestartTimer = new RestartTimer( this, ts );
			m_RestartTimer.Start();
		}

		public void EndRestart()
		{
			if( RandomizeType )
			{
				switch( Utility.Random( 5 ) )
				{
					case 0: Type = ChampionSpawnType.VerminHorde; break;
					case 1: Type = ChampionSpawnType.UnholyTerror; break;
					case 2: Type = ChampionSpawnType.ColdBlood; break;
					case 3: Type = ChampionSpawnType.Abyss; break;
					case 4: Type = ChampionSpawnType.Arachnid; break;
				}
			}

			m_HasBeenAdvanced = false;

			Start();
		}

		#region Scroll of Transcendence
		private ScrollofTranscendence CreateRandomSoT( bool felucca )
		{
			int level = Utility.RandomMinMax( 1, 5 );

			if ( felucca )
				level += 5;

			return ScrollofTranscendence.CreateRandom(level, level);
		}
		#endregion

		public static void GiveScrollTo( Mobile killer, SpecialScroll scroll )
		{
			if( scroll == null || killer == null )	//sanity
				return;

			if ( scroll is ScrollofTranscendence )
				killer.SendLocalizedMessage( 1094936 ); // You have received a Scroll of Transcendence!
			else
				killer.SendLocalizedMessage( 1049524 ); // You have received a scroll of power!

			if ( killer.Alive )
				killer.AddToBackpack( scroll );
			else
			{
				if( killer.Corpse != null && !killer.Corpse.Deleted )
					killer.Corpse.DropItem( scroll );
				else
					killer.AddToBackpack( scroll );
			}

			// Justice reward
			PlayerMobile pm = (PlayerMobile)killer;
			for (int j = 0; j < pm.JusticeProtectors.Count; ++j)
			{
				Mobile prot = (Mobile)pm.JusticeProtectors[j];

				if ( prot.Map != killer.Map || prot.Kills >= 5 || prot.Criminal || !JusticeVirtue.CheckMapRegion( killer, prot ) )
					continue;

				int chance = 0;

				switch ( VirtueHelper.GetLevel( prot, VirtueName.Justice ) )
				{
					case VirtueLevel.Seeker: chance = 60; break;
					case VirtueLevel.Follower: chance = 80; break;
					case VirtueLevel.Knight: chance = 100; break;
				}

				if ( chance > Utility.Random( 100 ) )
				{
					try
					{
						prot.SendLocalizedMessage( 1049368 ); // You have been rewarded for your dedication to Justice!

						SpecialScroll scrollDupe = Activator.CreateInstance( scroll.GetType() ) as SpecialScroll;

						if ( scrollDupe != null )
						{
							scrollDupe.Skill = scroll.Skill;
							scrollDupe.Value = scroll.Value;
							prot.AddToBackpack( scrollDupe );
						}
					}
					catch{}
				}
			}
		}

		public void OnSlice()
		{
			if( !m_Active || Deleted )
				return;

			if( m_Champion != null )
			{
				if( m_Champion.Deleted )
				{
					RegisterDamageTo( m_Champion );

					if( m_Champion is BaseChampion )
						AwardArtifact( ((BaseChampion)m_Champion).GetArtifact() );

					m_DamageEntries.Clear();

					if( m_Platform != null )
						m_Platform.Hue = 0x497;

					if( m_Altar != null )
					{
						m_Altar.Hue = 0;

						if( !Core.ML || Map == Map.Lodor )
						{
							new StarRoomGate( true, m_Altar.Location, m_Altar.Map );
						}
					}

					m_Champion = null;
					Stop();

					BeginRestart( m_RestartDelay );
				}
			}
			else
			{
				int kills = m_Kills;

				for ( int i = 0; i < m_Creatures.Count; ++i )
				{
					Mobile m = m_Creatures[i];

					if ( m.Deleted )
					{
						if( m.Corpse != null && !m.Corpse.Deleted )
						{
							((Corpse)m.Corpse).BeginDecay( TimeSpan.FromMinutes( 1 ));
						}
						m_Creatures.RemoveAt( i );
						--i;
						++m_Kills;

						Mobile killer = m.FindMostRecentDamager( false );

						RegisterDamageTo( m );

						if( killer is BaseCreature )
							killer = ((BaseCreature)killer).GetMaster();

						if( killer is PlayerMobile )
						{
							#region Scroll of Transcendence
							if ( Core.ML )
							{
								if ( Map == Map.Lodor )
								{
									if ( Utility.RandomDouble() < 0.001 )
									{
										PlayerMobile pm = (PlayerMobile)killer;
										double random = Utility.Random ( 49 );

										if ( random <= 24 )
										{
											ScrollofTranscendence SoTF = CreateRandomSoT( true );
											GiveScrollTo( pm, (SpecialScroll)SoTF );
										}
										else
										{
											PowerScroll PS = PowerScroll.CreateRandomNoCraft(5, 5);
											GiveScrollTo( pm, (SpecialScroll)PS );
										}
									}
								}

								if ( Map == Map.Underworld || Map == Map.IslesDread || Map == Map.SerpentIsland )
								{
									if ( Utility.RandomDouble() < 0.0015 )
									{
										killer.SendLocalizedMessage( 1094936 ); // You have received a Scroll of Transcendence!
										ScrollofTranscendence SoTT = CreateRandomSoT( false );
										killer.AddToBackpack( SoTT );
									}
								}
							}
							#endregion

							int mobSubLevel = GetSubLevelFor( m ) + 1;

							if( mobSubLevel >= 0 )
							{
								bool gainedPath = false;

								int pointsToGain = mobSubLevel * 40;

								if( VirtueHelper.Award( killer, VirtueName.Valor, pointsToGain, ref gainedPath ) )
								{
									if( gainedPath )
										m.SendLocalizedMessage( 1054032 ); // You have gained a path in Valor!
									else
										m.SendLocalizedMessage( 1054030 ); // You have gained in Valor!

									//No delay on Valor gains
								}

								PlayerMobile.ChampionTitleInfo info = ((PlayerMobile)killer).ChampionTitles;

								info.Award( m_Type, mobSubLevel );
							}
						}
					}
				}

				// Only really needed once.
				if ( m_Kills > kills )
					InvalidateProperties();

				double n = m_Kills / (double)MaxKills;
				int p = (int)(n * 100);

				if( p >= 90 )
					AdvanceLevel();
				else if( p > 0 )
					SetWhiteSkullCount( p / 20 );

				if( DateTime.Now >= m_ExpireTime )
					Expire();

				Respawn();
			}
		}

		public void AdvanceLevel()
		{
			m_ExpireTime = DateTime.Now + m_ExpireDelay;

			if( Level < 16 )
			{
				m_Kills = 0;
				++Level;
				InvalidateProperties();
				SetWhiteSkullCount( 0 );

				if( m_Altar != null )
				{
					Effects.PlaySound( m_Altar.Location, m_Altar.Map, 0x29 );
					Effects.SendLocationEffect( new Point3D( m_Altar.X + 1, m_Altar.Y + 1, m_Altar.Z ), m_Altar.Map, 0x3728, 10 );
				}
			}
			else
			{
				SpawnChampion();
			}
		}

		public void SpawnChampion()
		{
			if( m_Altar != null )
				m_Altar.Hue = 0x26;

			if ( m_Platform != null )
				m_Platform.Hue = 0x452;

			m_Kills = 0;
			Level = 0;
			InvalidateProperties();
			SetWhiteSkullCount( 0 );

			try
			{
				m_Champion = Activator.CreateInstance( ChampionSpawnInfo.GetInfo( m_Type ).Champion ) as Mobile;
			}
			catch { }

			if( m_Champion != null )
				m_Champion.MoveToWorld( new Point3D( X, Y, Z - 15 ), Map );
		}

		public void Respawn()
		{
			if( !m_Active || Deleted || m_Champion != null )
				return;

			while( m_Creatures.Count < (200 - (GetSubLevel() * 40)) )
			{
				Mobile m = Spawn();

				if( m == null )
					return;

				Point3D loc = GetSpawnLocation();

				// Allow creatures to turn into Paragons at Underworld champions.
				m.OnBeforeSpawn( loc, Map );

				m_Creatures.Add( m );
				m.MoveToWorld( loc, Map );

				if( m is BaseCreature )
				{
					BaseCreature bc = m as BaseCreature;
					bc.Tamable = false;

					if( !m_ConfinedRoaming )
					{
						bc.Home = this.Location;
						bc.RangeHome = (int)(Math.Sqrt( m_SpawnArea.Width * m_SpawnArea.Width + m_SpawnArea.Height * m_SpawnArea.Height )/2);
					}
					else
					{
						bc.Home = bc.Location;

						Point2D xWall1 = new Point2D( m_SpawnArea.X, bc.Y );
						Point2D xWall2 = new Point2D( m_SpawnArea.X + m_SpawnArea.Width, bc.Y );
						Point2D yWall1 = new Point2D( bc.X, m_SpawnArea.Y );
						Point2D yWall2 = new Point2D( bc.X, m_SpawnArea.Y + m_SpawnArea.Height );

						double minXDist = Math.Min( bc.GetDistanceToSqrt( xWall1 ), bc.GetDistanceToSqrt( xWall2 ) );
						double minYDist = Math.Min( bc.GetDistanceToSqrt( yWall1 ), bc.GetDistanceToSqrt( yWall2 ) );

						bc.RangeHome = (int)Math.Min( minXDist, minYDist );
					}
				}
			}
		}

		public Point3D GetSpawnLocation()
		{
			Map map = Map;

			if( map == null )
				return Location;

			// Try 20 times to find a spawnable location.
			for( int i = 0; i < 20; i++ )
			{
				/*
				int x = Location.X + (Utility.Random( (m_SpawnRange * 2) + 1 ) - m_SpawnRange);
				int y = Location.Y + (Utility.Random( (m_SpawnRange * 2) + 1 ) - m_SpawnRange);
				*/

				int x = Utility.Random( m_SpawnArea.X, m_SpawnArea.Width );
				int y = Utility.Random( m_SpawnArea.Y, m_SpawnArea.Height );

				int z = Map.GetAverageZ( x, y );

				if( Map.CanSpawnMobile( new Point2D( x, y ), z ) )
					return new Point3D( x, y, z );
			}

			return Location;
		}

		private const int Level1 = 4;  // First spawn level from 0-4 red skulls
		private const int Level2 = 8;  // Second spawn level from 5-8 red skulls
		private const int Level3 = 12; // Third spawn level from 9-12 red skulls

		public int GetSubLevel()
		{
			int level = this.Level;

			if( level <= Level1 )
				return 0;
			else if( level <= Level2 )
				return 1;
			else if( level <= Level3 )
				return 2;

			return 3;
		}

		public int GetSubLevelFor( Mobile m )
		{
			Type[][] types = ChampionSpawnInfo.GetInfo( m_Type ).SpawnTypes;
			Type t = m.GetType();

			for( int i = 0; i < types.GetLength( 0 ); i++ )
			{
				Type[] individualTypes = types[i];

				for( int j = 0; j < individualTypes.Length; j++ )
				{
					if( t == individualTypes[j] )
						return i;
				}
			}

			return -1;
		}

		public Mobile Spawn()
		{
			Type[][] types = ChampionSpawnInfo.GetInfo( m_Type ).SpawnTypes;

			int v = GetSubLevel();

			if( v >= 0 && v < types.Length )
				return Spawn( types[v] );

			return null;
		}

		public Mobile Spawn( params Type[] types )
		{
			try
			{
				return Activator.CreateInstance( types[Utility.Random( types.Length )] ) as Mobile;
			}
			catch
			{
				return null;
			}
		}

		public void Expire()
		{
			m_Kills = 0;

			if( m_WhiteSkulls.Count == 0 )
			{
				// They didn't even get 20%, go back a level

				if( Level > 0 )
					--Level;

				InvalidateProperties();
			}
			else
			{
				SetWhiteSkullCount( 0 );
			}

			m_ExpireTime = DateTime.Now + m_ExpireDelay;
		}

		public Point3D GetRedSkullLocation( int index )
		{
			int x, y;

			if( index < 5 )
			{
				x = index - 2;
				y = -2;
			}
			else if( index < 9 )
			{
				x = 2;
				y = index - 6;
			}
			else if( index < 13 )
			{
				x = 10 - index;
				y = 2;
			}
			else
			{
				x = -2;
				y = 14 - index;
			}

			return new Point3D( X + x, Y + y, Z - 15 );
		}

		public Point3D GetWhiteSkullLocation( int index )
		{
			int x, y;

			switch( index )
			{
				default:
				case 0: x = -1; y = -1; break;
				case 1: x =  1; y = -1; break;
				case 2: x =  1; y =  1; break;
				case 3: x = -1; y =  1; break;
			}

			return new Point3D( X + x, Y + y, Z - 15 );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( "champion spawn" );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if( m_Active )
			{
				list.Add( 1060742 ); // active
				list.Add( 1060658, "Type\t{0}", m_Type ); // ~1_val~: ~2_val~
				list.Add( 1060659, "Level\t{0}", Level ); // ~1_val~: ~2_val~
				list.Add( 1060660, "Kills\t{0} of {1} ({2:F1}%)", m_Kills, MaxKills, 100.0 * ((double)m_Kills / MaxKills) ); // ~1_val~: ~2_val~
				//list.Add( 1060661, "Spawn Range\t{0}", m_SpawnRange ); // ~1_val~: ~2_val~
			}
			else
			{
				list.Add( 1060743 ); // inactive
			}
		}

		public override void OnSingleClick( Mobile from )
		{
			if( m_Active )
				LabelTo( from, "{0} (Active; Level: {1}; Kills: {2}/{3})", m_Type, Level, m_Kills, MaxKills );
			else
				LabelTo( from, "{0} (Inactive)", m_Type );
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendGump( new PropertiesGump( from, this ) );
		}

		public override void OnLocationChange( Point3D oldLoc )
		{
			if( Deleted )
				return;

			if( m_Platform != null )
				m_Platform.Location = new Point3D( X, Y, Z - 20 );

			if( m_Altar != null )
				m_Altar.Location = new Point3D( X, Y, Z - 15 );

			if( m_Idol != null )
				m_Idol.Location = new Point3D( X, Y, Z - 15 );

			if( m_RedSkulls != null )
			{
				for( int i = 0; i < m_RedSkulls.Count; ++i )
					m_RedSkulls[i].Location = GetRedSkullLocation( i );
			}

			if( m_WhiteSkulls != null )
			{
				for( int i = 0; i < m_WhiteSkulls.Count; ++i )
					m_WhiteSkulls[i].Location = GetWhiteSkullLocation( i );
			}

			m_SpawnArea.X += Location.X - oldLoc.X;
			m_SpawnArea.Y += Location.Y - oldLoc.Y;

			UpdateRegion();
		}

		public override void OnMapChange()
		{
			if( Deleted )
				return;

			if( m_Platform != null )
				m_Platform.Map = Map;

			if( m_Altar != null )
				m_Altar.Map = Map;

			if( m_Idol != null )
				m_Idol.Map = Map;

			if( m_RedSkulls != null )
			{
				for( int i = 0; i < m_RedSkulls.Count; ++i )
					m_RedSkulls[i].Map = Map;
			}

			if( m_WhiteSkulls != null )
			{
				for( int i = 0; i < m_WhiteSkulls.Count; ++i )
					m_WhiteSkulls[i].Map = Map;
			}

			UpdateRegion();
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if( m_Platform != null )
				m_Platform.Delete();

			if( m_Altar != null )
				m_Altar.Delete();

			if( m_Idol != null )
				m_Idol.Delete();

			if( m_RedSkulls != null )
			{
				for( int i = 0; i < m_RedSkulls.Count; ++i )
					m_RedSkulls[i].Delete();

				m_RedSkulls.Clear();
			}

			if( m_WhiteSkulls != null )
			{
				for( int i = 0; i < m_WhiteSkulls.Count; ++i )
					m_WhiteSkulls[i].Delete();

				m_WhiteSkulls.Clear();
			}

			if( m_Creatures != null )
			{
				for( int i = 0; i < m_Creatures.Count; ++i )
				{
					Mobile mob = m_Creatures[i];

					if( !mob.Player )
						mob.Delete();
				}

				m_Creatures.Clear();
			}

			if( m_Champion != null && !m_Champion.Player )
				m_Champion.Delete();

			Stop();

			UpdateRegion();
		}

		public ChampionSpawn( Serial serial ) : base( serial )
		{
		}

		public virtual void RegisterDamageTo( Mobile m )
		{
			if( m == null )
				return;

			foreach( DamageEntry de in m.DamageEntries )
			{
				if( de.HasExpired )
					continue;

				Mobile damager = de.Damager;

				Mobile master = damager.GetDamageMaster( m );

				if( master != null )
					damager = master;

				RegisterDamage( damager, de.DamageGiven );
			}
		}

		public void RegisterDamage( Mobile from, int amount )
		{
			if( from == null || !from.Player )
				return;

			if( m_DamageEntries.ContainsKey( from ) )
				m_DamageEntries[from] += amount;
			else
				m_DamageEntries.Add( from, amount );
		}

		public void AwardArtifact( Item artifact )
		{
			if (artifact == null )
				return;

			int totalDamage = 0;

			Dictionary<Mobile, int> validEntries = new Dictionary<Mobile, int>();

			foreach (KeyValuePair<Mobile, int> kvp in m_DamageEntries)
			{
				if( IsEligible( kvp.Key, artifact ) )
				{
					validEntries.Add( kvp.Key, kvp.Value );
					totalDamage += kvp.Value;
				}
			}

			int randomDamage = Utility.RandomMinMax( 1, totalDamage );

			totalDamage = 0;

			foreach (KeyValuePair<Mobile, int> kvp in validEntries)
			{
				totalDamage += kvp.Value;

				if( totalDamage > randomDamage )
				{
					GiveArtifact( kvp.Key, artifact );
					break;
				}
			}
		}

		public void GiveArtifact( Mobile to, Item artifact )
		{
			if ( to == null || artifact == null )
				return;

			Container pack = to.Backpack;

			if ( pack == null || !pack.TryDropItem( to, artifact, false ) )
				artifact.Delete();
			else
				to.SendLocalizedMessage( 1062317 ); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.
		}

		public bool IsEligible( Mobile m, Item Artifact )
		{
			return m.Player && m.Alive && m.Region != null && m.Region == m_Region && m.Backpack != null && m.Backpack.CheckHold( m, Artifact, false );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)5 ); // version

			writer.Write( m_DamageEntries.Count );
			foreach (KeyValuePair<Mobile, int> kvp in m_DamageEntries)
			{
				writer.Write( kvp.Key );
				writer.Write( kvp.Value );
			}

			writer.Write( m_ConfinedRoaming );
			writer.WriteItem<IdolOfTheChampion>( m_Idol );
			writer.Write( m_HasBeenAdvanced );
			writer.Write( m_SpawnArea );

			writer.Write( m_RandomizeType );

			//			writer.Write( m_SpawnRange );
			writer.Write( m_Kills );

			writer.Write( (bool)m_Active );
			writer.Write( (int)m_Type );
			writer.Write( m_Creatures, true );
			writer.Write( m_RedSkulls, true );
			writer.Write( m_WhiteSkulls, true );
			writer.WriteItem<ChampionPlatform>( m_Platform );
			writer.WriteItem<ChampionAltar>( m_Altar );
			writer.Write( m_ExpireDelay );
			writer.WriteDeltaTime( m_ExpireTime );
			writer.Write( m_Champion );
			writer.Write( m_RestartDelay );

			writer.Write( m_RestartTimer != null );

			if( m_RestartTimer != null )
				writer.WriteDeltaTime( m_RestartTime );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			m_DamageEntries = new Dictionary<Mobile, int>();

			int version = reader.ReadInt();

			switch( version )
			{
				case 5:
				{
					int entries = reader.ReadInt();
					Mobile m;
					int damage;
					for( int i = 0; i < entries; ++i )
					{
						m = reader.ReadMobile();
						damage = reader.ReadInt();

						if ( m == null )
							continue;

						m_DamageEntries.Add( m, damage );
					}

					goto case 4;
				}
				case 4:
				{
					m_ConfinedRoaming = reader.ReadBool();
					m_Idol = reader.ReadItem<IdolOfTheChampion>();
					m_HasBeenAdvanced = reader.ReadBool();

					goto case 3;
				}
				case 3:
				{
					m_SpawnArea = reader.ReadRect2D();

					goto case 2;
				}
				case 2:
				{
					m_RandomizeType = reader.ReadBool();

					goto case 1;
				}
				case 1:
				{
					if( version < 3 )
					{
						int oldRange = reader.ReadInt();

						m_SpawnArea = new Rectangle2D( new Point2D( X - oldRange, Y - oldRange ), new Point2D( X + oldRange, Y + oldRange ) );
					}

					m_Kills = reader.ReadInt();

					goto case 0;
				}
				case 0:
				{
					if( version < 1 )
						m_SpawnArea = new Rectangle2D( new Point2D( X - 24, Y - 24 ), new Point2D( X + 24, Y + 24 ) );	//Default was 24

					bool active = reader.ReadBool();
					m_Type = (ChampionSpawnType)reader.ReadInt();
					m_Creatures = reader.ReadStrongMobileList();
					m_RedSkulls = reader.ReadStrongItemList();
					m_WhiteSkulls = reader.ReadStrongItemList();
					m_Platform = reader.ReadItem<ChampionPlatform>();
					m_Altar = reader.ReadItem<ChampionAltar>();
					m_ExpireDelay = reader.ReadTimeSpan();
					m_ExpireTime = reader.ReadDeltaTime();
					m_Champion = reader.ReadMobile();
					m_RestartDelay = reader.ReadTimeSpan();

					if( reader.ReadBool() )
					{
						m_RestartTime = reader.ReadDeltaTime();
						BeginRestart( m_RestartTime - DateTime.Now );
					}

					if( version < 4 )
					{
						m_Idol = new IdolOfTheChampion( this );
						m_Idol.MoveToWorld( new Point3D( X, Y, Z - 15 ), Map );
					}

					if( m_Platform == null || m_Altar == null || m_Idol == null )
						Delete();
					else if( active )
						Start();

					break;
				}
			}

			Timer.DelayCall( TimeSpan.Zero, new TimerCallback( UpdateRegion ) );
		}
	}

	public class ChampionSpawnRegion : BaseRegion
	{
		public override bool YoungProtected { get { return false; } }

		private ChampionSpawn m_Spawn;

		public ChampionSpawn ChampionSpawn
		{
			get { return m_Spawn; }
		}

		public ChampionSpawnRegion( ChampionSpawn spawn ) : base( null, spawn.Map, Region.Find( spawn.Location, spawn.Map ), spawn.SpawnArea )
		{
			m_Spawn = spawn;
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			base.AlterLightLevel( m, ref global, ref personal );
			global = Math.Max( global, 1 + m_Spawn.Level );	//This is a guesstimate.  TODO: Verify & get exact values // OSI testing: at 2 red skulls, light = 0x3 ; 1 red = 0x3.; 3 = 8; 9 = 0xD 8 = 0xD 12 = 0x12 10 = 0xD
		}
	}

	public class IdolOfTheChampion : Item
	{
		private ChampionSpawn m_Spawn;

		public ChampionSpawn Spawn { get { return m_Spawn; } }

		public override string DefaultName
		{
			get { return "Idol of the Champion"; }
		}

		public IdolOfTheChampion( ChampionSpawn spawn ): base( 0x1F18 )
		{
			m_Spawn = spawn;
			Movable = false;
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if ( m_Spawn != null )
				m_Spawn.Delete();
		}

		public IdolOfTheChampion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Spawn );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Spawn = reader.ReadItem() as ChampionSpawn;

					if ( m_Spawn == null )
						Delete();

					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Mobiles;

namespace Server.Engines.CannedEvil
{
	public enum ChampionSpawnType
	{
		Abyss,
		Arachnid,
		ColdBlood,
		ForestLord,
		VerminHorde,
		UnholyTerror,
		SleepingDragon,
		Glade,
		Pestilence
	}

	public class ChampionSpawnInfo
	{
		private string m_Name;
		private Type m_Champion;
		private Type[][] m_SpawnTypes;
		private string[] m_LevelNames;

		public string Name { get { return m_Name; } }
		public Type Champion { get { return m_Champion; } }
		public Type[][] SpawnTypes { get { return m_SpawnTypes; } }
		public string[] LevelNames { get { return m_LevelNames; } }

		public ChampionSpawnInfo( string name, Type champion, string[] levelNames, Type[][] spawnTypes )
		{
			m_Name = name;
			m_Champion = champion;
			m_LevelNames = levelNames;
			m_SpawnTypes = spawnTypes;
		}

		public static ChampionSpawnInfo[] Table{ get { return m_Table; } }

		private static readonly ChampionSpawnInfo[] m_Table = new ChampionSpawnInfo[]
			{
				new ChampionSpawnInfo( "Abyss", typeof( Imp ), new string[]{ "Foe", "Assassin", "Conqueror" }, new Type[][]	// Abyss
				{																											// Abyss
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Arachnid", typeof( Imp ), new string[]{ "Bane", "Killer", "Vanquisher" }, new Type[][]	// Arachnid
				{																											// Arachnid
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Cold Blood", typeof( Imp ), new string[]{ "Blight", "Slayer", "Destroyer" }, new Type[][]	// Cold Blood
				{																											// Cold Blood
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Forest Lord", typeof( Imp ), new string[]{ "Enemy", "Curse", "Slaughterer" }, new Type[][]	// Forest Lord
				{																											// Forest Lord
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Vermin Horde", typeof( Imp ), new string[]{ "Adversary", "Subjugator", "Eradicator" }, new Type[][]	// Vermin Horde
				{																											// Vermin Horde
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Unholy Terror", typeof( Imp ), new string[]{ "Scourge", "Punisher", "Nemesis" }, new Type[][]	// Unholy Terror
				{																											// Unholy Terror
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Sleeping Dragon", typeof( Imp ), new string[]{ "Rival", "Challenger", "Antagonist" } , new Type[][]
				{																											// Unholy Terror
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }				} ),
				new ChampionSpawnInfo( "Glade", typeof( Imp ), new string[]{ "Banisher", "Enforcer", "Eradicator" } , new Type[][]
				{																											// Glade
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }
				} ),
				new ChampionSpawnInfo( "The Corrupt", typeof( Imp ), new string[]{ "Cleanser", "Expunger", "Depurator" } , new Type[][]
				{																											// Unholy Terror
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }	,
					new Type[]{ typeof( Imp ) }
				} )
			};

		public static ChampionSpawnInfo GetInfo( ChampionSpawnType type )
		{
			int v = (int)type;

			if( v < 0 || v >= m_Table.Length )
				v = 0;

			return m_Table[v];
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;

namespace Server.Engines.Chat
{
	public class Channel
	{
		private string m_Name;
		private string m_Password;
		private List<ChatUser> m_Users, m_Banned, m_Moderators, m_Voices;
		private bool m_VoiceRestricted;
		private bool m_AlwaysAvailable;

		public Channel( string name )
		{
			m_Name = name;

			m_Users = new List<ChatUser>();
			m_Banned = new List<ChatUser>();
			m_Moderators = new List<ChatUser>();
			m_Voices = new List<ChatUser>();
		}

		public Channel( string name, string password ) : this( name )
		{
			m_Password = password;
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				SendCommand( ChatCommand.RemoveChannel, m_Name );
				m_Name = value;
				SendCommand( ChatCommand.AddChannel, m_Name );
				SendCommand( ChatCommand.JoinedChannel, m_Name );
			}
		}

		public string Password
		{
			get
			{
				return m_Password;
			}
			set
			{
				string newValue = null;

				if ( value != null )
				{
					newValue = value.Trim();

					if ( String.IsNullOrEmpty( newValue ) )
						newValue = null;
				}

				m_Password = newValue;
			}
		}

		public bool Contains( ChatUser user )
		{
			return m_Users.Contains( user );
		}

		public bool IsBanned( ChatUser user )
		{
			return m_Banned.Contains( user );
		}

		public bool CanTalk( ChatUser user )
		{
			return ( !m_VoiceRestricted || m_Voices.Contains( user ) || m_Moderators.Contains( user ) );
		}

		public bool IsModerator( ChatUser user )
		{
			return m_Moderators.Contains( user );
		}

		public bool IsVoiced( ChatUser user )
		{
			return m_Voices.Contains( user );
		}

		public bool ValidatePassword( string password )
		{
			return ( m_Password == null || Insensitive.Equals( m_Password, password ) );
		}

		public bool ValidateModerator( ChatUser user )
		{
			if ( user != null && !IsModerator( user ) )
			{
				user.SendMessage( 29 ); // You must have operator status to do this.
				return false;
			}

			return true;
		}

		public bool ValidateAccess( ChatUser from, ChatUser target )
		{
			if ( from != null && target != null && from.Mobile.AccessLevel < target.Mobile.AccessLevel )
			{
				from.Mobile.SendMessage( "Your access level is too low to do this." );
				return false;
			}

			return true;
		}

		public bool AddUser( ChatUser user )
		{
			return AddUser( user, null );
		}

		public bool AddUser( ChatUser user, string password )
		{
			if ( Contains( user ) )
			{
				user.SendMessage( 46, m_Name ); // You are already in the conference '%1'.
				return true;
			}
			else if ( IsBanned( user ) )
			{
				user.SendMessage( 64 ); // You have been banned from this conference.
				return false;
			}
			else if ( !ValidatePassword( password ) )
			{
				user.SendMessage( 34 ); // That is not the correct password.
				return false;
			}
			else
			{
				if ( user.CurrentChannel != null )
					user.CurrentChannel.RemoveUser( user ); // Remove them from their current channel first

				ChatSystem.SendCommandTo( user.Mobile, ChatCommand.JoinedChannel, m_Name );

				SendCommand( ChatCommand.AddUserToChannel, user.GetColorCharacter() + user.Username );

				m_Users.Add( user );
				user.CurrentChannel = this;

				if ( user.Mobile.AccessLevel >= AccessLevel.GameMaster || (!m_AlwaysAvailable && m_Users.Count == 1) )
					AddModerator( user );

				SendUsersTo( user );

				return true;
			}
		}

		public void RemoveUser( ChatUser user )
		{
			if ( Contains( user ) )
			{
				m_Users.Remove( user );
				user.CurrentChannel = null;

				if ( m_Moderators.Contains( user ) )
					m_Moderators.Remove( user );

				if ( m_Voices.Contains( user ) )
					m_Voices.Remove( user );

				SendCommand( ChatCommand.RemoveUserFromChannel, user, user.Username );
				ChatSystem.SendCommandTo( user.Mobile, ChatCommand.LeaveChannel );

				if ( m_Users.Count == 0 && !m_AlwaysAvailable )
					RemoveChannel( this );
			}
		}

		public void AdBan( ChatUser user )
		{
			AddBan( user, null );
		}

		public void AddBan( ChatUser user, ChatUser moderator )
		{
			if ( !ValidateModerator( moderator ) || !ValidateAccess( moderator, user ) )
				return;

			if ( !m_Banned.Contains( user ) )
				m_Banned.Add( user );

			Kick( user, moderator, true );
		}

		public void RemoveBan( ChatUser user )
		{
			if ( m_Banned.Contains( user ) )
				m_Banned.Remove( user );
		}

		public void Kick( ChatUser user )
		{
			Kick( user, null );
		}

		public void Kick( ChatUser user, ChatUser moderator )
		{
			Kick( user, moderator, false );
		}

		public void Kick( ChatUser user, ChatUser moderator, bool wasBanned )
		{
			if ( !ValidateModerator( moderator ) || !ValidateAccess( moderator, user ) )
				return;

			if ( Contains( user ) )
			{
				if ( moderator != null )
				{
					if ( wasBanned )
						user.SendMessage( 63, moderator.Username ); // %1, a conference moderator, has banned you from the conference.
					else
						user.SendMessage( 45, moderator.Username ); // %1, a conference moderator, has kicked you out of the conference.
				}

				RemoveUser( user );
				ChatSystem.SendCommandTo( user.Mobile, ChatCommand.AddUserToChannel, user.GetColorCharacter() + user.Username );

				SendMessage( 44, user.Username ) ; // %1 has been kicked out of the conference.
			}

			if ( wasBanned && moderator != null )
				moderator.SendMessage( 62, user.Username ); // You are banning %1 from this conference.
		}

		public bool VoiceRestricted
		{
			get
			{
				return m_VoiceRestricted;
			}
			set
			{
				m_VoiceRestricted = value;

				if ( value )
					SendMessage( 56 ); // From now on, only moderators will have speaking privileges in this conference by default.
				else
					SendMessage( 55 ); // From now on, everyone in the conference will have speaking privileges by default.
			}
		}

		public bool AlwaysAvailable
		{
			get
			{
				return m_AlwaysAvailable;
			}
			set
			{
				m_AlwaysAvailable = value;
			}
		}

		public void AddVoiced( ChatUser user )
		{
			AddVoiced( user, null );
		}

		public void AddVoiced( ChatUser user, ChatUser moderator )
		{
			if ( !ValidateModerator( moderator ) )
				return;

			if ( !IsBanned( user ) && !IsModerator( user ) && !IsVoiced( user ) )
			{
				m_Voices.Add( user );

				if ( moderator != null )
					user.SendMessage( 54, moderator.Username ); // %1, a conference moderator, has granted you speaking priviledges in this conference.

				SendMessage( 52, user, user.Username ); // %1 now has speaking privileges in this conference.
				SendCommand( ChatCommand.AddUserToChannel, user, user.GetColorCharacter() + user.Username );
			}
		}

		public void RemoveVoiced( ChatUser user, ChatUser moderator )
		{
			if ( !ValidateModerator( moderator ) || !ValidateAccess( moderator, user ) )
				return;

			if ( !IsModerator( user ) && IsVoiced( user ) )
			{
				m_Voices.Remove( user );

				if ( moderator != null )
					user.SendMessage( 53, moderator.Username ); // %1, a conference moderator, has removed your speaking priviledges for this conference.

				SendMessage( 51, user, user.Username ); // %1 no longer has speaking privileges in this conference.
				SendCommand( ChatCommand.AddUserToChannel, user, user.GetColorCharacter() + user.Username );
			}
		}

		public void AddModerator( ChatUser user )
		{
			AddModerator( user, null );
		}

		public void AddModerator( ChatUser user, ChatUser moderator )
		{
			if ( !ValidateModerator( moderator ) )
				return;

			if ( IsBanned( user ) || IsModerator( user ) )
				return;

			if ( IsVoiced( user ) )
				m_Voices.Remove( user );

			m_Moderators.Add( user );

			if ( moderator != null )
				user.SendMessage( 50, moderator.Username ); // %1 has made you a conference moderator.

			SendMessage( 48, user, user.Username ); // %1 is now a conference moderator.
			SendCommand( ChatCommand.AddUserToChannel, user.GetColorCharacter() + user.Username );
		}

		public void RemoveModerator( ChatUser user )
		{
			RemoveModerator( user, null );
		}

		public void RemoveModerator( ChatUser user, ChatUser moderator )
		{
			if ( !ValidateModerator( moderator ) || !ValidateAccess( moderator, user ) )
				return;

			if ( IsModerator( user ) )
			{
				m_Moderators.Remove( user );

				if ( moderator != null )
					user.SendMessage( 49, moderator.Username ); // %1 has removed you from the list of conference moderators.

				SendMessage( 47, user, user.Username ); // %1 is no longer a conference moderator.
				SendCommand( ChatCommand.AddUserToChannel, user.GetColorCharacter() + user.Username );
			}
		}

		public void SendMessage( int number )
		{
			SendMessage( number, null, null, null );
		}

		public void SendMessage( int number, string param1 )
		{
			SendMessage( number, null, param1, null );
		}

		public void SendMessage( int number, string param1, string param2 )
		{
			SendMessage( number, null, param1, param2 );
		}

		public void SendMessage( int number, ChatUser initiator )
		{
			SendMessage( number, initiator, null, null );
		}

		public void SendMessage( int number, ChatUser initiator, string param1 )
		{
			SendMessage( number, initiator, param1, null );
		}

		public void SendMessage( int number, ChatUser initiator, string param1, string param2 )
		{
			for ( int i = 0; i < m_Users.Count; ++i )
			{
				ChatUser user = m_Users[i];

				if ( user == initiator )
					continue;

				if ( user.CheckOnline() )
					user.SendMessage( number, param1, param2 );
				else if ( !Contains( user ) )
					--i;
			}
		}

		public void SendIgnorableMessage( int number, ChatUser from, string param1, string param2 )
		{
			for ( int i = 0; i < m_Users.Count; ++i )
			{
				ChatUser user = m_Users[i];

				if ( user.IsIgnored( from ) )
					continue;

				if ( user.CheckOnline() )
					user.SendMessage( number, from.Mobile, param1, param2 );
				else if ( !Contains( user ) )
					--i;
			}
		}

		public void SendCommand( ChatCommand command )
		{
			SendCommand( command, null, null, null );
		}

		public void SendCommand( ChatCommand command, string param1 )
		{
			SendCommand( command, null, param1, null );
		}

		public void SendCommand( ChatCommand command, string param1, string param2 )
		{
			SendCommand( command, null, param1, param2 );
		}

		public void SendCommand( ChatCommand command, ChatUser initiator )
		{
			SendCommand( command, initiator, null, null );
		}

		public void SendCommand( ChatCommand command, ChatUser initiator, string param1 )
		{
			SendCommand( command, initiator, param1, null );
		}

		public void SendCommand( ChatCommand command, ChatUser initiator, string param1, string param2 )
		{
			for ( int i = 0; i < m_Users.Count; ++i )
			{
				ChatUser user = m_Users[i];

				if ( user == initiator )
					continue;

				if ( user.CheckOnline() )
					ChatSystem.SendCommandTo( user.Mobile, command, param1, param2 );
				else if ( !Contains( user ) )
					--i;
			}
		}

		public void SendUsersTo( ChatUser to )
		{
			for ( int i = 0; i < m_Users.Count; ++i )
			{
				ChatUser user = m_Users[i];

				ChatSystem.SendCommandTo( to.Mobile, ChatCommand.AddUserToChannel, user.GetColorCharacter() + user.Username );
			}
		}

		private static List<Channel> m_Channels = new List<Channel>();

		public static List<Channel> Channels
		{
			get
			{
				return m_Channels;
			}
		}

		public static void SendChannelsTo( ChatUser user )
		{
			for ( int i = 0; i < m_Channels.Count; ++i )
			{
				Channel channel = m_Channels[i];

				if ( !channel.IsBanned( user ) )
					ChatSystem.SendCommandTo( user.Mobile, ChatCommand.AddChannel, channel.Name, "0" );
			}
		}

		public static Channel AddChannel( string name )
		{
			return AddChannel( name, null );
		}

		public static Channel AddChannel( string name, string password )
		{
			Channel channel = FindChannelByName( name );

			if ( channel == null )
			{
				channel = new Channel( name, password );
				m_Channels.Add( channel );
			}

			ChatUser.GlobalSendCommand( ChatCommand.AddChannel, name, "0" ) ;

			return channel;
		}

		public static void RemoveChannel( string name )
		{
			RemoveChannel( FindChannelByName( name ) );
		}

		public static void RemoveChannel( Channel channel )
		{
			if ( channel == null )
				return;

			if ( m_Channels.Contains( channel ) && channel.m_Users.Count == 0 )
			{
				ChatUser.GlobalSendCommand( ChatCommand.RemoveChannel, channel.Name ) ;

				channel.m_Moderators.Clear();
				channel.m_Voices.Clear();

				m_Channels.Remove( channel );
			}
		}

		public static Channel FindChannelByName( string name )
		{
			for ( int i = 0; i < m_Channels.Count; ++i )
			{
				Channel channel = m_Channels[i];

				if ( channel.m_Name == name )
					return channel;
			}

			return null;
		}

		public static void Initialize()
		{
			AddStaticChannel( "Newbie Help" );
		}

		public static void AddStaticChannel( string name )
		{
			AddChannel( name ).AlwaysAvailable = true;
		}
	}
}// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Gumps;// using Server.Items;// using Server.Spells;// using Server.Multis;// using Server.Network;// using Server.Targeting;// using Server.Accounting;// using Server.ContextMenus;// using Server.Engines.VeteranRewards;

namespace Server.Mobiles
{
	public enum StatueType
	{
		Marble,
		Jade,
		Bronze
	}

	public enum StatuePose
	{
		Ready,
		Casting,
		Salute,
		AllPraiseMe,
		Fighting,
		HandsOnHips
	}

	public enum StatueMaterial
	{
		Antique,
		Dark,
		Medium,
		Light
	}

	public class CharacterStatue : Mobile, IRewardItem
	{
		private StatueType m_Type;
		private StatuePose m_Pose;
		private StatueMaterial m_Material;

		[CommandProperty( AccessLevel.GameMaster )]
		public StatueType StatueType
		{
			get { return m_Type; }
			set { m_Type = value; InvalidateHues(); InvalidatePose(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public StatuePose Pose
		{
			get { return m_Pose; }
			set { m_Pose = value; InvalidatePose(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public StatueMaterial Material
		{
			get { return m_Material; }
			set { m_Material = value; InvalidateHues(); InvalidatePose(); }
		}

		private Mobile m_SculptedBy;
		private DateTime m_SculptedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile SculptedBy
		{
			get{ return m_SculptedBy; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime SculptedOn
		{
			get{ return m_SculptedOn; }
		}

		private CharacterStatuePlinth m_Plinth;

		public CharacterStatuePlinth Plinth
		{
			get { return m_Plinth; }
			set { m_Plinth = value; }
		}

		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; }
		}

		public CharacterStatue( Mobile from, StatueType type ) : base()
		{
			m_Type = type;
			m_Pose = StatuePose.Ready;
			m_Material = StatueMaterial.Antique;

			Direction = Direction.South;
			AccessLevel = AccessLevel.Counselor;
			Hits = HitsMax;
			Blessed = true;
			Frozen = true;

			CloneBody( from );
			CloneClothes( from );
			InvalidateHues();
		}

		public CharacterStatue( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			DisplayPaperdollTo( from );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_SculptedBy != null )
			{
				if ( m_SculptedBy.Title != null )
					list.Add( 1076202, m_SculptedBy.Title + " " + m_SculptedBy.Name ); // Sculpted by ~1_Name~
				else
					list.Add( 1076202, m_SculptedBy.Name ); // Sculpted by ~1_Name~
			}
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( from.Alive && m_SculptedBy != null )
			{
				BaseHouse house = BaseHouse.FindHouseAt( this );

				if ( ( house != null && house.IsCoOwner( from ) ) || (int) from.AccessLevel > (int) AccessLevel.Counselor )
					list.Add( new DemolishEntry( this ) );
			}
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if ( m_Plinth != null && !m_Plinth.Deleted )
				m_Plinth.Delete();
		}

		protected override void OnMapChange( Map oldMap )
		{
			InvalidatePose();

			if ( m_Plinth != null )
				m_Plinth.Map = Map;
		}

		protected override void OnLocationChange( Point3D oldLocation )
		{
			InvalidatePose();

			if ( m_Plinth != null )
				m_Plinth.Location = new Point3D( X, Y, Z - 5 );
		}

		public override bool CanBeRenamedBy( Mobile from )
		{
			return false;
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public void OnRequestedAnimation( Mobile from )
		{
			from.Send( new UpdateStatueAnimation( this, 1, m_Animation, m_Frames ) );
		}

		public override void OnAosSingleClick( Mobile from )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (int) m_Type );
			writer.Write( (int) m_Pose );
			writer.Write( (int) m_Material );

			writer.Write( (Mobile) m_SculptedBy );
			writer.Write( (DateTime) m_SculptedOn );

			writer.Write( (Item) m_Plinth );
			writer.Write( (bool) m_IsRewardItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Type = (StatueType) reader.ReadInt();
			m_Pose = (StatuePose) reader.ReadInt();
			m_Material = (StatueMaterial) reader.ReadInt();

			m_SculptedBy = reader.ReadMobile();
			m_SculptedOn = reader.ReadDateTime();

			m_Plinth = reader.ReadItem() as CharacterStatuePlinth;
			m_IsRewardItem = reader.ReadBool();

			InvalidatePose();

			Frozen = true;

			if( m_SculptedBy == null || Map == Map.Internal )
			{
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Delete ) );
			}
		}

		public void Sculpt( Mobile by )
		{
			m_SculptedBy = by;
			m_SculptedOn = DateTime.Now;

			InvalidateProperties();
		}

		public void Demolish( Mobile by )
		{
			CharacterStatueDeed deed = new CharacterStatueDeed( null );

			if ( by.PlaceInBackpack( deed ) )
			{
				Delete();

				deed.Statue = this;
				deed.IsRewardItem = m_IsRewardItem;

				if ( m_Plinth != null )
					m_Plinth.Delete();
			}
			else
			{
				by.SendLocalizedMessage( 500720 ); // You don't have enough room in your backpack!
				deed.Delete();
			}
		}

		public void Restore( CharacterStatue from )
		{
			m_Material = from.Material;
			m_Pose = from.Pose;

			Direction = from.Direction;

			CloneBody( from );
			CloneClothes( from );

			InvalidateHues();
			InvalidatePose();
		}

		public void CloneBody( Mobile from )
		{
			Name = from.Name;
			BodyValue = from.BodyValue;
			HairItemID = from.HairItemID;
			FacialHairItemID = from.FacialHairItemID;
		}

		public void CloneClothes( Mobile from )
		{
			for ( int i = Items.Count - 1; i >= 0; i -- )
				Items[ i ].Delete();

			for ( int i = from.Items.Count - 1; i >= 0; i -- )
			{
				Item item = from.Items[ i ];

				if ( item.Layer != Layer.Backpack && item.Layer != Layer.Mount && item.Layer != Layer.Bank )
					AddItem( CloneItem( item ) );
			}
		}

		public Item CloneItem( Item item )
		{
			Item cloned = new Item( item.ItemID );
			cloned.Layer = item.Layer;
			cloned.Name = item.Name;
			cloned.Hue = item.Hue;
			cloned.Weight = item.Weight;
			cloned.Movable = false;

			return cloned;
		}

		public void InvalidateHues()
		{
			Hue = 0xB8F + (int) m_Type * 4 + (int) m_Material;

			HairHue = Hue;

			if ( FacialHairItemID > 0 )
				FacialHairHue = Hue;

			for ( int i = Items.Count - 1; i >= 0; i -- )
				Items[ i ].Hue = Hue;

			if ( m_Plinth != null )
				m_Plinth.InvalidateHue();
		}

		private int m_Animation;
		private int m_Frames;

		public void InvalidatePose()
		{
			switch ( m_Pose )
			{
				case StatuePose.Ready:
						m_Animation = 4;
						m_Frames = 0;
						break;
				case StatuePose.Casting:
						m_Animation = 16;
						m_Frames = 2;
						break;
				case StatuePose.Salute:
						m_Animation = 33;
						m_Frames = 1;
						break;
				case StatuePose.AllPraiseMe:
						m_Animation = 17;
						m_Frames = 4;
						break;
				case StatuePose.Fighting:
						m_Animation = 31;
						m_Frames = 5;
						break;
				case StatuePose.HandsOnHips:
						m_Animation = 6;
						m_Frames = 1;
						break;
			}

			if( Map != null )
			{
				ProcessDelta();

				Packet p = null;

				IPooledEnumerable eable = Map.GetClientsInRange( Location );

				foreach( NetState state in eable )
				{
					state.Mobile.ProcessDelta();

					if( p == null )
						p = Packet.Acquire( new UpdateStatueAnimation( this, 1, m_Animation, m_Frames ) );

					state.Send( p );
				}

				Packet.Release( p );

				eable.Free();
			}
		}

		private class DemolishEntry : ContextMenuEntry
		{
			private CharacterStatue m_Statue;

			public DemolishEntry( CharacterStatue statue ) : base( 6275, 2 )
			{
				m_Statue = statue;
			}

			public override void OnClick()
			{
				if ( m_Statue.Deleted )
					return;

				m_Statue.Demolish( Owner.From );
			}
		}
	}

	public class CharacterStatueDeed : Item, IRewardItem
	{
		public override int LabelNumber
		{
			get
			{
				if ( m_Statue != null )
				{
					switch ( m_Statue.StatueType )
					{
						case StatueType.Marble: return 1076189;
						case StatueType.Jade: return 1076188;
						case StatueType.Bronze: return 1076190;
					}
				}

				return 1076173;
			}
		}

		private CharacterStatue m_Statue;
		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public CharacterStatue Statue
		{
			get { return m_Statue; }
			set { m_Statue = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public StatueType StatueType
		{
			get
			{
				if ( m_Statue != null )
					return m_Statue.StatueType;

				return StatueType.Marble;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; InvalidateProperties(); }
		}

		public CharacterStatueDeed( CharacterStatue statue ) : base( 0x14F0 )
		{
			m_Statue = statue;

			LootType = LootType.Blessed;
			Weight = 1.0;
		}

		public CharacterStatueDeed( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_IsRewardItem )
				list.Add( 1076222 ); // 6th Year Veteran Reward

			if ( m_Statue != null )
				list.Add( 1076231, m_Statue.Name ); // Statue of ~1_Name~
		}

		public override void OnDoubleClick( Mobile from )
		{
			Account acct = from.Account as Account;

			if ( acct != null && from.AccessLevel == AccessLevel.Player )
			{
				TimeSpan time = TimeSpan.FromDays( RewardSystem.RewardInterval.TotalDays * 6 ) - ( DateTime.Now - acct.Created );

				if ( time > TimeSpan.Zero )
				{
					from.SendLocalizedMessage( 1008126, true, Math.Ceiling( time.TotalDays / RewardSystem.RewardInterval.TotalDays ).ToString() ); // Your account is not old enough to use this item. Months until you can use this item :
					return;
				}
			}

			if ( IsChildOf( from.Backpack ) )
			{
				if ( !from.IsBodyMod )
				{
					from.SendLocalizedMessage( 1076194 ); // Select a place where you would like to put your statue.
					from.Target = new CharacterStatueTarget( this, StatueType );
				}
				else
					from.SendLocalizedMessage( 1073648 ); // You may only proceed while in your original state...
			}
			else
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		}

		public override void OnDelete()
		{
			base.OnDelete();

			if ( m_Statue != null )
				m_Statue.Delete();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (Mobile) m_Statue );
			writer.Write( (bool) m_IsRewardItem );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Statue = reader.ReadMobile() as CharacterStatue;
			m_IsRewardItem = reader.ReadBool();
		}
	}

	public class CharacterStatueTarget : Target
	{
		private Item m_Maker;
		private StatueType m_Type;

		public CharacterStatueTarget( Item maker, StatueType type ) : base( -1, true, TargetFlags.None )
		{
			m_Maker = maker;
			m_Type = type;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			IPoint3D p = targeted as IPoint3D;
			Map map = from.Map;

			if ( p == null || map == null || m_Maker == null || m_Maker.Deleted )
				return;

			if ( m_Maker.IsChildOf( from.Backpack ) )
			{
				SpellHelper.GetSurfaceTop( ref p );
				BaseHouse house = null;
				Point3D loc = new Point3D( p );

				if ( targeted is Item && !((Item) targeted).IsLockedDown && !((Item) targeted).IsSecure && !(targeted is AddonComponent) )
				{
					from.SendLocalizedMessage( 1076191 ); // Statues can only be placed in houses.
					return;
				}
				else if ( from.IsBodyMod )
				{
					from.SendLocalizedMessage( 1073648 ); // You may only proceed while in your original state...
					return;
				}

				AddonFitResult result = CouldFit( loc, map, from, ref house );

				if ( result == AddonFitResult.Valid )
				{
					CharacterStatue statue = new CharacterStatue( from, m_Type );
					CharacterStatuePlinth plinth = new CharacterStatuePlinth( statue );

					house.Addons.Add( plinth );

					if ( m_Maker is IRewardItem )
						statue.IsRewardItem = ( (IRewardItem) m_Maker).IsRewardItem;

					statue.Plinth = plinth;
					plinth.MoveToWorld( loc, map );
					statue.InvalidatePose();

					from.CloseGump( typeof( CharacterStatueGump ) );
					from.SendGump( new CharacterStatueGump( m_Maker, statue, from ) );
				}
				else if ( result == AddonFitResult.Blocked )
					from.SendLocalizedMessage( 500269 ); // You cannot build that there.
				else if ( result == AddonFitResult.NotInHouse )
					from.SendLocalizedMessage( 1076192 ); // Statues can only be placed in houses where you are the owner or co-owner.
				else if ( result == AddonFitResult.DoorTooClose )
					from.SendLocalizedMessage( 500271 ); // You cannot build near the door.
			}
			else
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		}

		public static AddonFitResult CouldFit( Point3D p, Map map, Mobile from, ref BaseHouse house )
		{
			if ( !map.CanFit( p.X, p.Y, p.Z, 20, true, true, true ) )
				return AddonFitResult.Blocked;
			else if ( !BaseAddon.CheckHouse( from, p, map, 20, ref house ) )
				return AddonFitResult.NotInHouse;
			else
				return CheckDoors( p, 20, house );
		}

		public static AddonFitResult CheckDoors( Point3D p, int height, BaseHouse house )
		{
			ArrayList doors = house.Doors;

			for ( int i = 0; i < doors.Count; i ++ )
			{
				BaseDoor door = doors[ i ] as BaseDoor;

				Point3D doorLoc = door.GetWorldLocation();
				int doorHeight = door.ItemData.CalcHeight;

				if ( Utility.InRange( doorLoc, p, 1 ) && (p.Z == doorLoc.Z || ((p.Z + height) > doorLoc.Z && (doorLoc.Z + doorHeight) > p.Z)) )
					return AddonFitResult.DoorTooClose;
			}

			return AddonFitResult.Valid;
		}
	}
}// using System;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Network;

namespace Server.Gumps
{
	public class CharacterStatueGump : Gump
	{
		private Item m_Maker;
		private CharacterStatue m_Statue;
		private Timer m_Timer;
		private Mobile m_Owner;

		private enum Buttons
		{
			Close,
			Sculpt,
			PosePrev,
			PoseNext,
			DirPrev,
			DirNext,
			MatPrev,
			MatNext,
			Restore
		}

		public CharacterStatueGump( Item maker, CharacterStatue statue, Mobile owner ) : base( 60, 36 )
		{
			m_Maker = maker;
			m_Statue = statue;
			m_Owner = owner;

			if ( m_Statue == null )
				return;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage( 0 );

			AddImage(30, 22, 1140);
			AddHtml( 91, 71, 270, 26, @"<BODY><BASEFONT Color=#111111><BIG><CENTER>Character Statue Carving</CENTER></BIG></BASEFONT></BODY>", (bool)false, (bool)false);

			AddHtml( 92, 110, 104, 19, @"<BODY><BASEFONT Color=#111111><BIG>Direction</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 92, 135, 104, 19, @"<BODY><BASEFONT Color=#111111><BIG>" + GetDirectionNumber( m_Statue.Direction ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(93, 165, 4014, 4014, (int)Buttons.DirNext, GumpButtonType.Reply, 0);
			AddButton(130, 165, 4005, 4005, (int)Buttons.DirPrev, GumpButtonType.Reply, 0);

			AddHtml( 255, 110, 104, 19, @"<BODY><BASEFONT Color=#111111><BIG>Material</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
			AddHtml( 255, 135, 104, 19, @"<BODY><BASEFONT Color=#111111><BIG>" + GetMaterialNumber( m_Statue.StatueType, m_Statue.Material ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);

			AddButton(294, 165, 4014, 4014, (int)Buttons.MatNext, GumpButtonType.Reply, 0);
			AddButton(331, 165, 4005, 4005, (int)Buttons.MatPrev, GumpButtonType.Reply, 0);

			AddButton(66, 232, 241, 243, (int)Buttons.Close, GumpButtonType.Reply, 0);
			AddButton(319, 232, 247, 248, (int)Buttons.Sculpt, GumpButtonType.Reply, 0);

			// restore
			if ( m_Maker is CharacterStatueDeed )
			{
				AddButton(197, 219, 2322, 2324, (int)Buttons.Restore, GumpButtonType.Reply, 0);
			}

			m_Timer = Timer.DelayCall( TimeSpan.FromSeconds( 2.5 ), TimeSpan.FromSeconds( 2.5 ), new TimerCallback( CheckOnline ) );
		}

		private void CheckOnline()
		{
			if ( m_Owner != null && m_Owner.NetState == null )
			{
				if ( m_Timer != null )
					m_Timer.Stop();

				if ( m_Statue != null && !m_Statue.Deleted )
					m_Statue.Delete();
			}
		}

		private string GetMaterialNumber( StatueType type, StatueMaterial material )
		{
			switch ( material )
			{
				case StatueMaterial.Antique:

					switch ( type )
					{
						case StatueType.Bronze: return "Bronze";
						case StatueType.Jade: return "Jade";
						case StatueType.Marble: return "Marble";
					}

					return "Bronze";
				case StatueMaterial.Dark:

					if ( type == StatueType.Marble )
						return "Dark";

					return "Dark";
				case StatueMaterial.Medium: return "Medium";
				case StatueMaterial.Light: return "Light";
				default: return "Bronze";
			}
		}

		private string GetDirectionNumber( Direction direction )
		{
			switch ( direction )
			{
				case Direction.North: return "North";
				case Direction.Right: return "Right";
				case Direction.East: return "East";
				case Direction.Down: return "Down";
				case Direction.South: return "South";
				case Direction.Left: return "Left";
				case Direction.West: return "West";
				case Direction.Up: return "Up";
				default: return "South";
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( m_Statue == null || m_Statue.Deleted )
				return;

			bool sendGump = false;

			if ( info.ButtonID == (int) Buttons.Sculpt )
			{
				if ( m_Maker is CharacterStatueDeed )
				{
					CharacterStatue backup = ( (CharacterStatueDeed) m_Maker ).Statue;

					if ( backup != null )
						backup.Delete();
				}

				if ( m_Maker != null )
					m_Maker.Delete();

				m_Statue.Sculpt( state.Mobile );
			}
			else if ( info.ButtonID == (int) Buttons.PosePrev )
			{
				m_Statue.Pose = (StatuePose) ( ( (int) m_Statue.Pose + 5 ) % 6 );
				sendGump = true;
			}
			else if ( info.ButtonID == (int) Buttons.PoseNext )
			{
				m_Statue.Pose = (StatuePose) ( ( (int) m_Statue.Pose + 1 ) % 6 );
				sendGump = true;
			}
			else if ( info.ButtonID == (int) Buttons.DirPrev )
			{
				m_Statue.Direction = (Direction) ( ( (int) m_Statue.Direction + 7 ) % 8 );
				m_Statue.InvalidatePose();
				sendGump = true;
			}
			else if ( info.ButtonID == (int) Buttons.DirNext )
			{
				m_Statue.Direction = (Direction) ( ( (int) m_Statue.Direction + 1 ) % 8 );
				m_Statue.InvalidatePose();
				sendGump = true;
			}
			else if ( info.ButtonID == (int) Buttons.MatPrev )
			{
				m_Statue.Material = (StatueMaterial) ( ( (int) m_Statue.Material + 3 ) % 4 );
				sendGump = true;
			}
			else if ( info.ButtonID == (int) Buttons.MatNext )
			{
				m_Statue.Material = (StatueMaterial) ( ( (int) m_Statue.Material + 1 ) % 4 );
				sendGump = true;
			}
			else if ( info.ButtonID == (int) Buttons.Restore )
			{
				if ( m_Maker is CharacterStatueDeed )
				{
					CharacterStatue backup = ( (CharacterStatueDeed) m_Maker ).Statue;

					if ( backup != null )
						m_Statue.Restore( backup );
				}

				sendGump = true;
			}
			else
			{
				m_Statue.Delete();
			}

			if ( sendGump )
				state.Mobile.SendGump( new CharacterStatueGump( m_Maker, m_Statue, m_Owner ) );

			if ( m_Timer != null )
				m_Timer.Stop();
		}

		public override void OnServerClose( NetState owner )
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			if ( m_Statue != null && !m_Statue.Deleted )
				m_Statue.Delete();
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using Server.Targets;// using Server.Engines.VeteranRewards;

namespace Server.Items
{
	public class CharacterStatueMaker : Item, IRewardItem
	{
		public override int LabelNumber{ get{ return 1076173; } } // Character Statue Maker

		private bool m_IsRewardItem;
		private StatueType m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public StatueType StatueType
		{
			get{ return m_Type; }
			set{ m_Type = value; InvalidateHue(); }
		}

		public CharacterStatueMaker( StatueType type ) : base( 0x32F0 )
		{
			m_Type = type;
			InvalidateHue();
			Weight = 5.0;
		}

		public CharacterStatueMaker( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_IsRewardItem && !RewardSystem.CheckIsUsableBy( from, this, new object[] { m_Type } ) )
				return;

			if ( IsChildOf( from.Backpack ) )
			{
				if ( !from.IsBodyMod )
				{
					from.SendLocalizedMessage( 1076194 ); // Select a place where you would like to put your statue.
					from.Target = new CharacterStatueTarget( this, m_Type );
				}
				else
					from.SendLocalizedMessage( 1073648 ); // You may only proceed while in your original state...
			}
			else
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_IsRewardItem )
				list.Add( 1076222 ); // 6th Year Veteran Reward
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (bool) m_IsRewardItem );
			writer.Write( (int) m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_IsRewardItem = reader.ReadBool();
			m_Type = (StatueType) reader.ReadInt();
		}

		public void InvalidateHue()
		{
			Hue = 0xB8F + (int) m_Type * 4;
		}
	}

	public class MarbleStatueMaker : CharacterStatueMaker
	{
		[Constructable]
		public MarbleStatueMaker() : base( StatueType.Marble )
		{
		}

		public MarbleStatueMaker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class JadeStatueMaker : CharacterStatueMaker
	{
		[Constructable]
		public JadeStatueMaker() : base( StatueType.Jade )
		{
		}

		public JadeStatueMaker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class BronzeStatueMaker : CharacterStatueMaker
	{
		[Constructable]
		public BronzeStatueMaker() : base( StatueType.Bronze )
		{
		}

		public BronzeStatueMaker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}// using System;// using System.Globalization;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Multis;// using Server.Targets;

namespace Server.Items
{
	public class CharacterStatuePlinth : Static, IAddon
	{
		public Item Deed{ get{ return new CharacterStatueDeed( m_Statue ); } }
		public override int LabelNumber{ get{ return 1076201; } } // Character Statue

		private CharacterStatue m_Statue;

		public CharacterStatuePlinth( CharacterStatue statue ) : base( 0x32F2 )
		{
			m_Statue = statue;

			InvalidateHue();
		}

		public CharacterStatuePlinth( Serial serial ) : base( serial )
		{
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if ( m_Statue != null && !m_Statue.Deleted )
				m_Statue.Delete();
		}

		public override void OnMapChange()
		{
			if ( m_Statue != null )
				m_Statue.Map = Map;
		}

		public override void OnLocationChange( Point3D oldLocation )
		{
			if ( m_Statue != null )
				m_Statue.Location = new Point3D( X, Y, Z + 5 );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Statue != null )
				from.SendGump( new CharacterPlinthGump( m_Statue ) );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (Mobile) m_Statue );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Statue = reader.ReadMobile() as CharacterStatue;

			if( m_Statue == null || m_Statue.SculptedBy == null || Map == Map.Internal )
			{
				Timer.DelayCall( TimeSpan.Zero, new TimerCallback( Delete ) );
			}
		}

		public void InvalidateHue()
		{
			if ( m_Statue != null )
				Hue = 0xB8F + (int) m_Statue.StatueType * 4 + (int) m_Statue.Material;
		}

		public virtual bool CouldFit( IPoint3D p, Map map )
		{
			Point3D point = new Point3D( p.X, p.Y, p.Z );

			if ( map == null || !map.CanFit( point, 20 ) )
				return false;

			BaseHouse house = BaseHouse.FindHouseAt( point, map, 20 );

			if ( house == null )
				return false;

			AddonFitResult result = CharacterStatueTarget.CheckDoors( point, 20, house );

			if ( result == AddonFitResult.Valid )
				return true;

			return false;
		}

		private class CharacterPlinthGump : Gump
		{
			public CharacterPlinthGump( CharacterStatue statue ) : base( 60, 30 )
			{
				Closable = true;
				Disposable = true;
				Dragable = true;
				Resizable = false;

				AddPage( 0 );
				AddImage( 0, 0, 0x24F4 );
				AddHtml( 55, 50, 150, 20, statue.Name, false, false );
				AddHtml( 55, 75, 150, 20, statue.SculptedOn.ToString( "G", new CultureInfo("de-DE") ), false, false );
				AddHtmlLocalized( 55, 100, 150, 20, GetTypeNumber( statue.StatueType ), 0, false, false );
			}

			public int GetTypeNumber( StatueType type )
			{
				switch ( type )
				{
					case StatueType.Marble: return 1076181;
					case StatueType.Jade: return 1076180;
					case StatueType.Bronze: return 1076230;
					default: return 1076181;
				}
			}
		}
	}
}// using System;// using Server;// using Server.Misc;// using Server.Network;// using Server.Accounting;

namespace Server.Engines.Chat
{
	public class ChatSystem
	{
		private static bool m_Enabled = true;

		public static bool Enabled
		{
			get{ return m_Enabled; }
			set{ m_Enabled = value; }
		}

		public static void Initialize()
		{
			PacketHandlers.Register( 0xB5, 0x40, true, new OnPacketReceive( OpenChatWindowRequest ) );
			PacketHandlers.Register( 0xB3, 0, true, new OnPacketReceive( ChatAction ) );
		}

		public static void SendCommandTo( Mobile to, ChatCommand type )
		{
			SendCommandTo( to, type, null, null );
		}

		public static void SendCommandTo( Mobile to, ChatCommand type, string param1 )
		{
			SendCommandTo( to, type, param1, null );
		}

		public static void SendCommandTo( Mobile to, ChatCommand type, string param1, string param2 )
		{
			if ( to != null )
				to.Send( new ChatMessagePacket( null, (int)type + 20, param1, param2 ) );
		}

		public static void OpenChatWindowRequest( NetState state, PacketReader pvSrc )
		{
			Mobile from = state.Mobile;

			if ( !m_Enabled )
			{
				from.SendMessage( "The chat system has been disabled." );
				return;
			}

			pvSrc.Seek( 2, System.IO.SeekOrigin.Begin );
			string chatName = pvSrc.ReadUnicodeStringSafe( ( 0x40 - 2 ) >> 1 ).Trim();

			Account acct = state.Account as Account;

			string accountChatName = null;

			if ( acct != null )
				accountChatName = acct.GetTag( "ChatName" );

			if ( accountChatName != null )
				accountChatName = accountChatName.Trim();

			if ( accountChatName != null && accountChatName.Length > 0 )
			{
				if ( chatName.Length > 0 && chatName != accountChatName )
					from.SendMessage( "You cannot change chat nickname once it has been set." );
			}
			else
			{
				if ( chatName == null || chatName.Length == 0 )
				{
					SendCommandTo( from, ChatCommand.AskNewNickname );
					return;
				}

				if ( NameVerification.Validate( chatName, 2, 31, true, true, true, 0, NameVerification.SpaceDashPeriodQuote ) && chatName.ToLower().IndexOf( "system" ) == -1 )
				{
					// TODO: Optimize this search

					foreach ( Account checkAccount in Accounts.GetAccounts() )
					{
						string existingName = checkAccount.GetTag( "ChatName" );

						if ( existingName != null )
						{
							existingName = existingName.Trim();

							if ( Insensitive.Equals( existingName, chatName ) )
							{
								from.SendMessage( "Nickname already in use." );
								SendCommandTo( from, ChatCommand.AskNewNickname );
								return;
							}
						}
					}

					accountChatName = chatName;

					if ( acct != null )
						acct.AddTag( "ChatName", chatName );
				}
				else
				{
					from.SendLocalizedMessage( 501173 ); // That name is disallowed.
					SendCommandTo( from, ChatCommand.AskNewNickname );
					return;
				}
			}

			SendCommandTo( from, ChatCommand.OpenChatWindow, accountChatName );
			ChatUser.AddChatUser( from );
		}

		public static ChatUser SearchForUser( ChatUser from, string name )
		{
			ChatUser user = ChatUser.GetChatUser( name );

			if ( user == null )
				from.SendMessage( 32, name ); // There is no player named '%1'.

			return user;
		}

		public static void ChatAction( NetState state, PacketReader pvSrc )
		{
			if ( !m_Enabled )
				return;

			try
			{
				Mobile from = state.Mobile;
				ChatUser user = ChatUser.GetChatUser( from );

				if ( user == null )
					return;

				string lang = pvSrc.ReadStringSafe( 4 );
				int actionID = pvSrc.ReadInt16();
				string param = pvSrc.ReadUnicodeString();

				ChatActionHandler handler = ChatActionHandlers.GetHandler( actionID );

				if ( handler != null )
				{
					Channel channel = user.CurrentChannel;

					if ( handler.RequireConference && channel == null )
					{
						user.SendMessage( 31 ); /* You must be in a conference to do this.
												 * To join a conference, select one from the Conference menu.
												 */
					}
					else if ( handler.RequireModerator && !user.IsModerator )
					{
						user.SendMessage( 29 ); // You must have operator status to do this.
					}
					else
					{
						handler.Callback( user, channel, param );
					}
				}
				else
				{
					Console.WriteLine( "Client: {0}: Unknown chat action 0x{1:X}: {2}", state, actionID, param );
				}
			}
			catch ( Exception e )
			{
				Console.WriteLine( e );
			}
		}
	}
}
// using System;

namespace Server.Engines.Chat
{
	public delegate void OnChatAction( ChatUser from, Channel channel, string param );

	public class ChatActionHandler
	{
		private bool m_RequireModerator;
		private bool m_RequireConference;
		private OnChatAction m_Callback;

		public bool RequireModerator{ get{ return m_RequireModerator; } }
		public bool RequireConference{ get{ return m_RequireConference; } }
		public OnChatAction Callback{ get{ return m_Callback; } }

		public ChatActionHandler( bool requireModerator, bool requireConference, OnChatAction callback )
		{
			m_RequireModerator = requireModerator;
			m_RequireConference = requireConference;
			m_Callback = callback;
		}
	}
}
// using System;

namespace Server.Engines.Chat
{
	public class ChatActionHandlers
	{
		private static ChatActionHandler[] m_Handlers;

		static ChatActionHandlers()
		{
			m_Handlers = new ChatActionHandler[0x100];

			Register( 0x41,  true,  true, new OnChatAction( ChangeChannelPassword ) );

			Register( 0x58, false, false, new OnChatAction( LeaveChat ) );

			Register( 0x61, false,  true, new OnChatAction( ChannelMessage ) );
			Register( 0x62, false, false, new OnChatAction( JoinChannel ) );
			Register( 0x63, false, false, new OnChatAction( JoinNewChannel ) );
			Register( 0x64,  true,  true, new OnChatAction( RenameChannel ) );
			Register( 0x65, false, false, new OnChatAction( PrivateMessage ) );
			Register( 0x66, false, false, new OnChatAction( AddIgnore ) );
			Register( 0x67, false, false, new OnChatAction( RemoveIgnore ) );
			Register( 0x68, false, false, new OnChatAction( ToggleIgnore ) );
			Register( 0x69,  true,  true, new OnChatAction( AddVoice ) );
			Register( 0x6A,  true,  true, new OnChatAction( RemoveVoice ) );
			Register( 0x6B,  true,  true, new OnChatAction( ToggleVoice ) );
			Register( 0x6C,  true,  true, new OnChatAction( AddModerator ) );
			Register( 0x6D,  true,  true, new OnChatAction( RemoveModerator ) );
			Register( 0x6E,  true,  true, new OnChatAction( ToggleModerator ) );
			Register( 0x6F, false, false, new OnChatAction( AllowPrivateMessages ) );
			Register( 0x70, false, false, new OnChatAction( DisallowPrivateMessages ) );
			Register( 0x71, false, false, new OnChatAction( TogglePrivateMessages ) );
			Register( 0x72, false, false, new OnChatAction( ShowCharacterName ) );
			Register( 0x73, false, false, new OnChatAction( HideCharacterName ) );
			Register( 0x74, false, false, new OnChatAction( ToggleCharacterName ) );
			Register( 0x75, false, false, new OnChatAction( QueryWhoIs ) );
			Register( 0x76,  true,  true, new OnChatAction( Kick ) );
			Register( 0x77,  true,  true, new OnChatAction( EnableDefaultVoice ) );
			Register( 0x78,  true,  true, new OnChatAction( DisableDefaultVoice ) );
			Register( 0x79,  true,  true, new OnChatAction( ToggleDefaultVoice ) );
			Register( 0x7A, false,  true, new OnChatAction( EmoteMessage ) );
		}

		public static void Register( int actionID, bool requireModerator, bool requireConference, OnChatAction callback )
		{
			if ( actionID >= 0 && actionID < m_Handlers.Length )
				m_Handlers[actionID] = new ChatActionHandler( requireModerator, requireConference, callback );
		}

		public static ChatActionHandler GetHandler( int actionID )
		{
			if ( actionID >= 0 && actionID < m_Handlers.Length )
				return m_Handlers[actionID];

			return null;
		}

		public static void ChannelMessage( ChatUser from, Channel channel, string param )
		{
			if ( channel.CanTalk( from ) )
				channel.SendIgnorableMessage( 57, from, from.GetColorCharacter() + from.Username, param ); // %1: %2
			else
				from.SendMessage( 36 ); // The moderator of this conference has not given you speaking priviledges.
		}

		public static void EmoteMessage( ChatUser from, Channel channel, string param )
		{
			if ( channel.CanTalk( from ) )
				channel.SendIgnorableMessage( 58, from, from.GetColorCharacter() + from.Username, param ); // %1 %2
			else
				from.SendMessage( 36 ); // The moderator of this conference has not given you speaking priviledges.
		}

		public static void PrivateMessage( ChatUser from, Channel channel, string param )
		{
			int indexOf = param.IndexOf( ' ' );

			string name = param.Substring( 0, indexOf );
			string text = param.Substring( indexOf + 1 );

			ChatUser target = ChatSystem.SearchForUser( from, name );

			if ( target == null )
				return;

			if ( target.IsIgnored( from ) )
				from.SendMessage( 35, target.Username ); // %1 has chosen to ignore you. None of your messages to them will get through.
			else if ( target.IgnorePrivateMessage )
				from.SendMessage( 42, target.Username ); // %1 has chosen to not receive private messages at the moment.
			else
				target.SendMessage( 59, from.Mobile, from.GetColorCharacter() + from.Username, text ); // [%1]: %2
		}

		public static void LeaveChat( ChatUser from, Channel channel, string param )
		{
			ChatUser.RemoveChatUser( from );
		}

		public static void ChangeChannelPassword( ChatUser from, Channel channel, string param )
		{
			channel.Password = param;
			from.SendMessage( 60 ); // The password to the conference has been changed.
		}

		public static void AllowPrivateMessages( ChatUser from, Channel channel, string param )
		{
			from.IgnorePrivateMessage = false;
			from.SendMessage( 37 ); // You can now receive private messages.
		}

		public static void DisallowPrivateMessages( ChatUser from, Channel channel, string param )
		{
			from.IgnorePrivateMessage = true;
			from.SendMessage( 38 ); /* You will no longer receive private messages.
									 * Those who send you a message will be notified that you are blocking incoming messages.
									 */
		}

		public static void TogglePrivateMessages( ChatUser from, Channel channel, string param )
		{
			from.IgnorePrivateMessage = !from.IgnorePrivateMessage;
			from.SendMessage( from.IgnorePrivateMessage ? 38 : 37 ); // See above for messages
		}

		public static void ShowCharacterName( ChatUser from, Channel channel, string param )
		{
			from.Anonymous = false;
			from.SendMessage( 39 ); // You are now showing your character name to any players who inquire with the whois command.
		}

		public static void HideCharacterName( ChatUser from, Channel channel, string param )
		{
			from.Anonymous = true;
			from.SendMessage( 40 ); // You are no longer showing your character name to any players who inquire with the whois command.
		}

		public static void ToggleCharacterName( ChatUser from, Channel channel, string param )
		{
			from.Anonymous = !from.Anonymous;
			from.SendMessage( from.Anonymous ? 40 : 39 ); // See above for messages
		}

		public static void JoinChannel( ChatUser from, Channel channel, string param )
		{
			string name;
			string password = null;

			int start = param.IndexOf( '\"' );

			if ( start >= 0 )
			{
				int end = param.IndexOf( '\"', ++start );

				if ( end >= 0 )
				{
					name = param.Substring( start, end - start );
					password = param.Substring( ++end );
				}
				else
				{
					name = param.Substring( start );
				}
			}
			else
			{
				int indexOf = param.IndexOf( ' ' );

				if ( indexOf >= 0 )
				{
					name = param.Substring( 0, indexOf++ );
					password = param.Substring( indexOf );
				}
				else
				{
					name = param;
				}
			}

			if ( password != null )
				password = password.Trim();

			if ( password != null && password.Length == 0 )
				password = null;

			Channel joined = Channel.FindChannelByName( name );

			if ( joined == null )
				from.SendMessage( 33, name ); // There is no conference named '%1'.
			else
				joined.AddUser( from, password );
		}

		public static void JoinNewChannel( ChatUser from, Channel channel, string param )
		{
			if ( (param = param.Trim()).Length == 0 )
				return;

			string name;
			string password = null;

			int start = param.IndexOf( '{' );

			if ( start >= 0 )
			{
				name = param.Substring( 0, start++ );

				int end = param.IndexOf( '}', start );

				if ( end >= start )
					password = param.Substring( start, end - start );
			}
			else
			{
				name = param;
			}

			if ( password != null )
				password = password.Trim();

			if ( password != null && password.Length == 0 )
				password = null;

			Channel.AddChannel( name, password ).AddUser( from, password );
		}

		public static void AddIgnore( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target == null )
				return;

			from.AddIgnored( target );
		}

		public static void RemoveIgnore( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target == null )
				return;

			from.RemoveIgnored( target );
		}

		public static void ToggleIgnore( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target == null )
				return;

			if ( from.IsIgnored( target ) )
				from.RemoveIgnored( target );
			else
				from.AddIgnored( target );
		}

		public static void AddVoice( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target != null )
				channel.AddVoiced( target, from );
		}

		public static void RemoveVoice( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target != null )
				channel.RemoveVoiced( target, from );
		}

		public static void ToggleVoice( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target == null )
				return;

			if ( channel.IsVoiced( target ) )
				channel.RemoveVoiced( target, from );
			else
				channel.AddVoiced( target, from );
		}

		public static void AddModerator( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target != null )
				channel.AddModerator( target, from );
		}

		public static void RemoveModerator( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target != null )
				channel.RemoveModerator( target, from );
		}

		public static void ToggleModerator( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target == null )
				return;

			if ( channel.IsModerator( target ) )
				channel.RemoveModerator( target, from );
			else
				channel.AddModerator( target, from );
		}

		public static void RenameChannel( ChatUser from, Channel channel, string param )
		{
			channel.Name = param;
		}

		public static void QueryWhoIs( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target == null )
				return;

			if ( target.Anonymous )
				from.SendMessage( 41, target.Username ); // %1 is remaining anonymous.
			else
				from.SendMessage( 43, target.Username, target.Mobile.Name ); // %2 is known in the lands of Britannia as %2.
		}

		public static void Kick( ChatUser from, Channel channel, string param )
		{
			ChatUser target = ChatSystem.SearchForUser( from, param );

			if ( target != null )
				channel.Kick( target, from );
		}

		public static void EnableDefaultVoice( ChatUser from, Channel channel, string param )
		{
			channel.VoiceRestricted = false;
		}

		public static void DisableDefaultVoice( ChatUser from, Channel channel, string param )
		{
			channel.VoiceRestricted = true;
		}

		public static void ToggleDefaultVoice( ChatUser from, Channel channel, string param )
		{
			channel.VoiceRestricted = !channel.VoiceRestricted;
		}
	}
}
// using System;

namespace Server.Engines.Chat
{
	public enum ChatCommand
	{
		/// <summary>
		/// Add a channel to top list.
		/// </summary>
		AddChannel = 0x3E8,
		/// <summary>
		/// Remove channel from top list.
		/// </summary>
		RemoveChannel = 0x3E9,
		/// <summary>
		/// Queries for a new chat nickname.
		/// </summary>
		AskNewNickname = 0x3EB,
		/// <summary>
		/// Closes the chat window.
		/// </summary>
		CloseChatWindow = 0x3EC,
		/// <summary>
		/// Opens the chat window.
		/// </summary>
		OpenChatWindow = 0x3ED,
		/// <summary>
		/// Add a user to current channel.
		/// </summary>
		AddUserToChannel = 0x3EE,
		/// <summary>
		/// Remove a user from current channel.
		/// </summary>
		RemoveUserFromChannel = 0x3EF,
		/// <summary>
		/// Send a message putting generic conference name at top when player leaves a channel.
		/// </summary>
		LeaveChannel = 0x3F0,
		/// <summary>
		/// Send a message putting Channel name at top and telling player he joined the channel.
		/// </summary>
		JoinedChannel = 0x3F1
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server.Chat
{
	public class ChatSystem
	{
		public static void Initialize()
		{
			EventSink.ChatRequest += new ChatRequestEventHandler( EventSink_ChatRequest );
		}

		private static void EventSink_ChatRequest( ChatRequestEventArgs e )
		{
			// e.Mobile.SendMessage( "Chat is not currently supported." );
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Accounting;

namespace Server.Engines.Chat
{
	public class ChatUser
	{
		private Mobile m_Mobile;
		private Channel m_Channel;
		private bool m_Anonymous;
		private bool m_IgnorePrivateMessage;
		private List<ChatUser> m_Ignored, m_Ignoring;

		public ChatUser( Mobile m )
		{
			m_Mobile = m;
			m_Ignored = new List<ChatUser>();
			m_Ignoring = new List<ChatUser>();
		}

		public Mobile Mobile
		{
			get
			{
				return m_Mobile;
			}
		}

		public List<ChatUser> Ignored
		{
			get
			{
				return m_Ignored;
			}
		}

		public List<ChatUser> Ignoring
		{
			get
			{
				return m_Ignoring;
			}
		}

		public string Username
		{
			get
			{
				Account acct = m_Mobile.Account as Account;

				if ( acct != null )
					return acct.GetTag( "ChatName" );

				return null;
			}
			set
			{
				Account acct = m_Mobile.Account as Account;

				if ( acct != null )
					acct.SetTag( "ChatName", value );
			}
		}

		public Channel CurrentChannel
		{
			get
			{
				return m_Channel;
			}
			set
			{
				m_Channel = value;
			}
		}

		public bool IsOnline
		{
			get
			{
				return ( m_Mobile.NetState != null );
			}
		}

		public bool Anonymous
		{
			get
			{
				return m_Anonymous;
			}
			set
			{
				m_Anonymous = value;
			}
		}

		public bool IgnorePrivateMessage
		{
			get
			{
				return m_IgnorePrivateMessage;
			}
			set
			{
				m_IgnorePrivateMessage = value;
			}
		}

		public const char NormalColorCharacter = '0';
		public const char ModeratorColorCharacter = '1';
		public const char VoicedColorCharacter = '2';

		public char GetColorCharacter()
		{
			if ( m_Channel != null && m_Channel.IsModerator( this ) )
				return ModeratorColorCharacter;

			if ( m_Channel != null && m_Channel.IsVoiced( this ) )
				return VoicedColorCharacter;

			return NormalColorCharacter;
		}

		public bool CheckOnline()
		{
			if ( IsOnline )
				return true;

			RemoveChatUser( this );
			return false;
		}

		public void SendMessage( int number )
		{
			SendMessage( number, null, null );
		}

		public void SendMessage( int number, string param1 )
		{
			SendMessage( number, param1, null );
		}

		public void SendMessage( int number, string param1, string param2 )
		{
			if ( m_Mobile.NetState != null )
				m_Mobile.Send( new ChatMessagePacket( m_Mobile, number, param1, param2 ) );
		}

		public void SendMessage( int number, Mobile from, string param1, string param2 )
		{
			if ( m_Mobile.NetState != null )
				m_Mobile.Send( new ChatMessagePacket( from, number, param1, param2 ) );
		}

		public bool IsIgnored( ChatUser check )
		{
			return m_Ignored.Contains( check );
		}

		public bool IsModerator
		{
			get
			{
				return ( m_Channel != null && m_Channel.IsModerator( this ) );
			}
		}

		public void AddIgnored( ChatUser user )
		{
			if ( IsIgnored( user ) )
			{
				SendMessage( 22, user.Username ); // You are already ignoring %1.
			}
			else
			{
				m_Ignored.Add( user );
				user.m_Ignoring.Add( this );

				SendMessage( 23, user.Username ); // You are now ignoring %1.
			}
		}

		public void RemoveIgnored( ChatUser user )
		{
			if ( IsIgnored( user ) )
			{
				m_Ignored.Remove( user );
				user.m_Ignoring.Remove( this );

				SendMessage( 24, user.Username ); // You are no longer ignoring %1.

				if ( m_Ignored.Count == 0 )
					SendMessage( 26 ); // You are no longer ignoring anyone.
			}
			else
			{
				SendMessage( 25, user.Username ); // You are not ignoring %1.
			}
		}

		private static List<ChatUser> m_Users = new List<ChatUser>();
		private static Dictionary<Mobile, ChatUser> m_Table = new Dictionary<Mobile, ChatUser>();

		public static ChatUser AddChatUser( Mobile from )
		{
			ChatUser user = GetChatUser( from );

			if ( user == null )
			{
				user = new ChatUser( from );

				m_Users.Add( user );
				m_Table[from] = user;

				Channel.SendChannelsTo( user );

				List<Channel> list = Channel.Channels;

				for ( int i = 0; i < list.Count; ++i )
				{
					Channel c = list[i];

					if ( c.AddUser( user ) )
						break;
				}

				//ChatSystem.SendCommandTo( user.m_Mobile, ChatCommand.AddUserToChannel, user.GetColorCharacter() + user.Username );
			}

			return user;
		}

		public static void RemoveChatUser( ChatUser user )
		{
			if ( user == null )
				return;

			for ( int i = 0; i < user.m_Ignoring.Count; ++i )
				user.m_Ignoring[i].RemoveIgnored( user );

			if ( m_Users.Contains( user ) )
			{
				ChatSystem.SendCommandTo( user.Mobile, ChatCommand.CloseChatWindow );

				if ( user.m_Channel != null )
					user.m_Channel.RemoveUser( user );

				m_Users.Remove( user );
				m_Table.Remove( user.m_Mobile );
			}
		}

		public static void RemoveChatUser( Mobile from )
		{
			ChatUser user = GetChatUser( from );

			RemoveChatUser( user );
		}

		public static ChatUser GetChatUser( Mobile from )
		{
			ChatUser c;
			m_Table.TryGetValue( from, out c );
			return c;
		}

		public static ChatUser GetChatUser( string username )
		{
			for ( int i = 0; i < m_Users.Count; ++i )
			{
				ChatUser user = m_Users[i];

				if ( user.Username == username )
					return user;
			}

			return null;
		}

		public static void GlobalSendCommand( ChatCommand command )
		{
			GlobalSendCommand( command, null, null, null );
		}

		public static void GlobalSendCommand( ChatCommand command, string param1 )
		{
			GlobalSendCommand( command, null, param1, null );
		}

		public static void GlobalSendCommand( ChatCommand command, string param1, string param2 )
		{
			GlobalSendCommand( command, null, param1, param2 );
		}

		public static void GlobalSendCommand( ChatCommand command, ChatUser initiator )
		{
			GlobalSendCommand( command, initiator, null, null );
		}

		public static void GlobalSendCommand( ChatCommand command, ChatUser initiator, string param1 )
		{
			GlobalSendCommand( command, initiator, param1, null );
		}

		public static void GlobalSendCommand( ChatCommand command, ChatUser initiator, string param1, string param2 )
		{
			for ( int i = 0; i < m_Users.Count; ++i )
			{
				ChatUser user = m_Users[i];

				if ( user == initiator )
					continue;

				if ( user.CheckOnline() )
					ChatSystem.SendCommandTo( user.m_Mobile, command, param1, param2 );
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;

namespace Server
{
	public class CompassionVirtue
	{
		private static TimeSpan LossDelay = TimeSpan.FromDays( 7.0 );
		private const int LossAmount = 500;

		public static void Initialize()
		{
			VirtueGump.Register( 105, new OnVirtueUsed( OnVirtueUsed ) );
		}

		public static void OnVirtueUsed( Mobile from )
		{
			from.SendLocalizedMessage( 1053001 ); // This virtue is not activated through the virtue menu.
		}

		public static void CheckAtrophy( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return;

			try
			{
				if ( (pm.LastCompassionLoss + LossDelay) < DateTime.Now )
				{
					VirtueHelper.Atrophy( from, VirtueName.Compassion, LossAmount );
					//OSI has no cliloc message for losing compassion.  Weird.
					pm.LastCompassionLoss = DateTime.Now;
				}
			}
			catch
			{
			}
		}
	}
}
// using System;// using System.Text;// using System.Threading;

namespace Server.Engines.MyRunUO
{
	public class Config
	{
		// Is MyRunUO enabled?
		public static bool Enabled = false;

		// Details required for database connection string
		public static string DatabaseDriver			= "{MySQL ODBC 3.51 Driver}";
		public static string DatabaseServer			= "localhost";
		public static string DatabaseName			= "MyRunUO";
		public static string DatabaseUserID			= "username";
		public static string DatabasePassword		= "password";

		// Should the database use transactions? This is recommended
		public static bool UseTransactions = true;

		// Use optimized table loading techniques? (LOAD DATA INFILE)
		public static bool LoadDataInFile = true;

		// This must be enabled if the database server is on a remote machine.
		public static bool DatabaseNonLocal = ( DatabaseServer != "localhost" );

		// Text encoding used
		public static Encoding EncodingIO = Encoding.ASCII;

		// Database communication is done in a separate thread. This value is the 'priority' of that thread, or, how much CPU it will try to use
		public static ThreadPriority DatabaseThreadPriority = ThreadPriority.BelowNormal;

		// Any character with an AccessLevel equal to or higher than this will not be displayed
		public static AccessLevel HiddenAccessLevel	= AccessLevel.Counselor;

		// Export character database every 30 minutes
		public static TimeSpan CharacterUpdateInterval = TimeSpan.FromMinutes( 30.0 );

		// Export online list database every 5 minutes
		public static TimeSpan StatusUpdateInterval = TimeSpan.FromMinutes( 5.0 );

		public static string CompileConnectionString()
		{
			string connectionString = String.Format( "DRIVER={0};SERVER={1};DATABASE={2};UID={3};PASSWORD={4};",
				DatabaseDriver, DatabaseServer, DatabaseName, DatabaseUserID, DatabasePassword );

			return connectionString;
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class CouncilOfMages : Faction
	{
		private static Faction m_Instance;

		public static Faction Instance{ get{ return m_Instance; } }

		public CouncilOfMages()
		{
			m_Instance = this;

			Definition =
				new FactionDefinition(
					1,
					1325, // blue
					1310, // bluish white
					1325, // join stone : blue
					1325, // broadcast : blue
					0x77, 0x3EB1, // war horse
					"Council of Mages", "council", "CoM",
					new TextDefinition( 1011535, "COUNCIL OF MAGES" ),
					new TextDefinition( 1060770, "Council of Mages faction" ),
					new TextDefinition( 1011422, "<center>COUNCIL OF MAGES</center>" ),
					new TextDefinition( 1011449,
						"The council of Mages have their roots in the city of Elidor, where " +
						"they once convened. They began as a small movement, dedicated to " +
						"calling forth the Stranger, who saved the lands once before.  A " +
						"series of war and murders and misbegotten trials by those loyal to " +
						"Lord British has caused the group to take up the banner of war." ),
					new TextDefinition( 1011455, "This city is controlled by the Council of Mages." ),
					new TextDefinition( 1042253, "This sigil has been corrupted by the Council of Mages" ),
					new TextDefinition( 1041044, "The faction signup stone for the Council of Mages" ),
					new TextDefinition( 1041382, "The Faction Stone of the Council of Mages" ),
					new TextDefinition( 1011464, ": Council of Mages" ),
					new TextDefinition( 1005187, "Members of the Council of Mages will now be ignored." ),
					new TextDefinition( 1005188, "Members of the Council of Mages will now be warned to leave." ),
					new TextDefinition( 1005189, "Members of the Council of Mages will now be beaten with a stick." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 )
						},
						new Point3D( 3750, 2241, 20 ),
						new Point3D( 3795, 2259, 20 ),
						new Point3D[]
						{
							new Point3D( 3793, 2255, 20 ),
							new Point3D( 3793, 2252, 20 ),
							new Point3D( 3793, 2249, 20 ),
							new Point3D( 3793, 2246, 20 ),
							new Point3D( 3797, 2255, 20 ),
							new Point3D( 3797, 2252, 20 ),
							new Point3D( 3797, 2249, 20 ),
							new Point3D( 3797, 2246, 20 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060789, "Inquisitor of the Council" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060788, "Archon of Principle" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060787, "Luminary" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060787, "Luminary" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060786, "Diviner" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060786, "Diviner" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060786, "Diviner" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060785, "Mystic" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060785, "Mystic" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060785, "Mystic" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionSorceress ),	0x0E89, 7000, 3000, 10,		new TextDefinition( 1011507, "SORCERESS" ),		new TextDefinition( 1011501, "Hire Sorceress" ) ),
						new GuardDefinition( typeof( FactionWizard ),		0x13F8, 8000, 4000, 10,		new TextDefinition( 1011508, "ELDER WIZARD" ),	new TextDefinition( 1011502, "Hire Elder Wizard" ) ),
					}
				);
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dark unicorn corpse" )]
	public class DarkUnicorn : BaseCreature
	{
		[Constructable]
		public DarkUnicorn() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dark unicorn";
			Body = 27;
			BaseSoundID = 0xA8;

			SetStr( 596, 625 );
			SetDex( 186, 205 );
			SetInt( 186, 225 );

			SetHits( 398, 415 );

			SetDamage( 22, 28 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Psychology, 30.4, 70.0 );
			SetSkill( SkillName.Magery, 30.4, 70.0 );
			SetSkill( SkillName.MagicResist, 105.3, 120.0 );
			SetSkill( SkillName.Tactics, 117.6, 120.0 );
			SetSkill( SkillName.FistFighting, 100.5, 112.5 );

			Fame = 19000;
			Karma = -19000;

			VirtualArmor = 70;

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

		public override int GetAngerSound()
		{
			if ( !Controlled )
				return 0x16A;

			return base.GetAngerSound();
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }

		public DarkUnicorn( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}
// using System;// using System.Threading;// using System.Collections;// using System.Data;// using System.Data.Odbc;

namespace Server.Engines.MyRunUO
{
	public class DatabaseCommandQueue
	{
		private Queue m_Queue;
		private ManualResetEvent m_Sync;
		private Thread m_Thread;

		private bool m_HasCompleted;

		private string m_CompletionString;
		private string m_ConnectionString;

		public bool HasCompleted
		{
			get{ return m_HasCompleted; }
		}

		public void Enqueue( object obj )
		{
			lock ( m_Queue.SyncRoot )
			{
				m_Queue.Enqueue( obj );
				try{ m_Sync.Set(); }
				catch{}
			}
		}

		public DatabaseCommandQueue( string completionString, string threadName ) : this( Config.CompileConnectionString(), completionString, threadName )
		{
		}

		public DatabaseCommandQueue( string connectionString, string completionString, string threadName )
		{
			m_CompletionString = completionString;
			m_ConnectionString = connectionString;

			m_Queue = Queue.Synchronized( new Queue() );

			m_Queue.Enqueue( null ); // signal connect

			/*m_Queue.Enqueue( "DELETE FROM myrunuo_characters" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_characters_layers" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_characters_skills" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_guilds" );
			m_Queue.Enqueue( "DELETE FROM myrunuo_guilds_wars" );*/

			m_Sync = new ManualResetEvent( true );

			m_Thread = new Thread( new ThreadStart( Thread_Start ) );
			m_Thread.Name = threadName;//"MyRunUO Database Command Queue";
			m_Thread.Priority = Config.DatabaseThreadPriority;
			m_Thread.Start();
		}

		private void Thread_Start()
		{
			bool connected = false;

			OdbcConnection connection = null;
			OdbcCommand command = null;
			OdbcTransaction transact = null;

			DateTime start = DateTime.Now;

			bool shouldWriteException = true;

			while ( true )
			{
				m_Sync.WaitOne();

				while ( m_Queue.Count > 0 )
				{
					try
					{
						object obj = m_Queue.Dequeue();

						if ( obj == null )
						{
							if ( connected )
							{
								if ( transact != null )
								{
									try{ transact.Commit(); }
									catch ( Exception commitException )
									{
										Console.WriteLine( "MyRunUO: Exception caught when committing transaction" );
										Console.WriteLine( commitException );

										try
										{
											transact.Rollback();
											Console.WriteLine( "MyRunUO: Transaction has been rolled back" );
										}
										catch ( Exception rollbackException )
										{
											Console.WriteLine( "MyRunUO: Exception caught when rolling back transaction" );
											Console.WriteLine( rollbackException );
										}
									}
								}

								try{ connection.Close(); }
								catch{}

								try{ connection.Dispose(); }
								catch{}

								try{ command.Dispose(); }
								catch{}

								try{ m_Sync.Close(); }
								catch{}

								Console.WriteLine( m_CompletionString, (DateTime.Now - start).TotalSeconds );
								m_HasCompleted = true;

								return;
							}
							else
							{
								try
								{
									connected = true;
									connection = new OdbcConnection( m_ConnectionString );
									connection.Open();
									command = connection.CreateCommand();

									if ( Config.UseTransactions )
									{
										transact = connection.BeginTransaction();
										command.Transaction = transact;
									}
								}
								catch ( Exception e )
								{
									try{ if ( transact != null ) transact.Rollback(); }
									catch{}

									try{ if ( connection != null ) connection.Close(); }
									catch{}

									try{ if ( connection != null ) connection.Dispose(); }
									catch{}

									try{ if ( command != null ) command.Dispose(); }
									catch{}

									try{ m_Sync.Close(); }
									catch{}

									Console.WriteLine( "MyRunUO: Unable to connect to the database" );
									Console.WriteLine( e );
									m_HasCompleted = true;
									return;
								}
							}
						}
						else if ( obj is string )
						{
							command.CommandText = (string)obj;
							command.ExecuteNonQuery();
						}
						else
						{
							string[] parms = (string[])obj;

							command.CommandText = parms[0];

							if ( command.ExecuteScalar() == null )
							{
								command.CommandText = parms[1];
								command.ExecuteNonQuery();
							}
						}
					}
					catch ( Exception e )
					{
						if ( shouldWriteException )
						{
							Console.WriteLine( "MyRunUO: Exception caught in database thread" );
							Console.WriteLine( e );
							shouldWriteException = false;
						}
					}
				}

				lock ( m_Queue.SyncRoot )
				{
					if ( m_Queue.Count == 0 )
						m_Sync.Reset();
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class DeepSeaDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public DeepSeaDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the sea wyrm";
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 1365;
			BaseSoundID = 362;
			CanSwim = true;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;

			VirtualArmor = 60;

			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: PackItem( new SeaweedLegs() ); break;
					case 1: PackItem( new SeaweedGloves() ); break;
					case 2: PackItem( new SeaweedGorget() ); break;
					case 3: PackItem( new SeaweedArms() ); break;
					case 4: PackItem( new SeaweedChest() ); break;
					case 5: PackItem( new SeaweedHelm() ); break;
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H

		public override bool BleedImmune{ get{ return true; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override MeatType MeatType{ get{ return MeatType.Fish; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Spined; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Blue ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DeepSeaDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class DesertWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 50; } }
		public override int BreathFireDamage{ get{ return 50; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x96D; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } }
		public override int BreathEffectSound{ get{ return 0x654; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 8 ); }

		[Constructable]
		public DesertWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the desert wyrm";
			BaseSoundID = 362;
			Hue = 1719;
			Body = Server.Misc.MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Yellow; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public DesertWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class Dragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public Dragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a red dragon";
			Body = 59;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Red", "", c, 25, 0x845 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public Dragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Mobiles;

namespace Server.Engines.Quests
{
	public abstract class DynamicTeleporter : Item
	{
		public override int LabelNumber{ get{ return 1049382; } } // a magical teleporter

		public DynamicTeleporter() : this( 0x1822, 0x482 )
		{
		}

		public DynamicTeleporter( int itemID, int hue ) : base( itemID )
		{
			Movable = false;
			Hue = hue;
		}

		public abstract bool GetDestination( PlayerMobile player, ref Point3D loc, ref Map map );

		public virtual int NotWorkingMessage{ get{ return 500309; } } // Nothing Happens.

		public override bool OnMoveOver( Mobile m )
		{
			PlayerMobile pm = m as PlayerMobile;

			if ( pm != null )
			{
				Point3D loc = Point3D.Zero;
				Map map = null;

				if ( GetDestination( pm, ref loc, ref map ) )
				{
					BaseCreature.TeleportPets( pm, loc, map );

					pm.PlaySound( 0x1FE );
					pm.MoveToWorld( loc, map );

					return false;
				}
				else
				{
					pm.SendLocalizedMessage( this.NotWorkingMessage );
				}
			}

			return base.OnMoveOver( m );
		}

		public DynamicTeleporter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderBlackBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ElderBlackBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder black bear";
			Body = 177;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public ElderBlackBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderBrownBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ElderBrownBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder brown bear";
			Body = 23;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public ElderBrownBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 23;
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class ElderPolarBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ElderPolarBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder polar bear";
			Body = 179;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 18; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public ElderPolarBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Net;// using System.Collections;// using Server;// using Server.Mobiles;// using System.Collections.Generic;

namespace Server.Factions
{
	public class Election
	{
		public static readonly TimeSpan PendingPeriod = TimeSpan.FromDays( 5.0 );
		public static readonly TimeSpan CampaignPeriod = TimeSpan.FromDays( 1.0 );
		public static readonly TimeSpan VotingPeriod = TimeSpan.FromDays( 3.0 );

		public const int MaxCandidates = 10;
		public const int CandidateRank = 5;

		private Faction m_Faction;
		private List<Candidate> m_Candidates;

		private ElectionState m_State;
		private DateTime m_LastStateTime;

		public Faction Faction{ get{ return m_Faction; } }

		public List<Candidate> Candidates { get { return m_Candidates; } }

		public ElectionState State{ get{ return m_State; } set{ m_State = value; m_LastStateTime = DateTime.Now; } }
		public DateTime LastStateTime{ get{ return m_LastStateTime; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public ElectionState CurrentState{ get{ return m_State; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public TimeSpan NextStateTime
		{
			get
			{
				TimeSpan period;

				switch ( m_State )
				{
					default:
					case ElectionState.Pending: period = PendingPeriod; break;
					case ElectionState.Election: period = VotingPeriod; break;
					case ElectionState.Campaign: period = CampaignPeriod; break;
				}

				TimeSpan until = (m_LastStateTime + period) - DateTime.Now;

				if ( until < TimeSpan.Zero )
					until = TimeSpan.Zero;

				return until;
			}
			set
			{
				TimeSpan period;

				switch ( m_State )
				{
					default:
					case ElectionState.Pending: period = PendingPeriod; break;
					case ElectionState.Election: period = VotingPeriod; break;
					case ElectionState.Campaign: period = CampaignPeriod; break;
				}

				m_LastStateTime = DateTime.Now - period + value;
			}
		}

		private Timer m_Timer;

		public void StartTimer()
		{
			m_Timer = Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 1.0 ), new TimerCallback( Slice ) );
		}

		public Election( Faction faction )
		{
			m_Faction = faction;
			m_Candidates = new List<Candidate>();

			StartTimer();
		}

		public Election( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					m_Faction = Faction.ReadReference( reader );

					m_LastStateTime = reader.ReadDateTime();
					m_State = (ElectionState)reader.ReadEncodedInt();

					m_Candidates = new List<Candidate>();

					int count = reader.ReadEncodedInt();

					for ( int i = 0; i < count; ++i )
					{
						Candidate cd = new Candidate( reader );

						if ( cd.Mobile != null )
							m_Candidates.Add( cd );
					}

					break;
				}
			}

			StartTimer();
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );

			writer.Write( (DateTime) m_LastStateTime );
			writer.WriteEncodedInt( (int) m_State );

			writer.WriteEncodedInt( m_Candidates.Count );

			for ( int i = 0; i < m_Candidates.Count; ++i )
				m_Candidates[i].Serialize( writer );
		}

		public void AddCandidate( Mobile mob )
		{
			if ( IsCandidate( mob ) )
				return;

			m_Candidates.Add( new Candidate( mob ) );
			mob.SendLocalizedMessage( 1010117 ); // You are now running for office.
		}

		public void RemoveVoter( Mobile mob )
		{
			if ( m_State == ElectionState.Election )
			{
				for ( int i = 0; i < m_Candidates.Count; ++i )
				{
					List<Voter> voters = m_Candidates[i].Voters;

					for ( int j = 0; j < voters.Count; ++j )
					{
						Voter voter = voters[j];

						if ( voter.From == mob )
							voters.RemoveAt( j-- );
					}
				}
			}
		}

		public void RemoveCandidate( Mobile mob )
		{
			Candidate cd = FindCandidate( mob );

			if ( cd == null )
				return;

			m_Candidates.Remove( cd );
			mob.SendLocalizedMessage( 1038031 );

			if ( m_State == ElectionState.Election )
			{
				if ( m_Candidates.Count == 1 )
				{
					m_Faction.Broadcast( 1038031 ); // There are no longer any valid candidates in the Faction Commander election.

					Candidate winner = m_Candidates[0];

					Mobile winMob = winner.Mobile;
					PlayerState pl = PlayerState.Find( winMob );

					if ( pl == null || pl.Faction != m_Faction || winMob == m_Faction.Commander )
					{
						m_Faction.Broadcast( 1038026 ); // Faction leadership has not changed.
					}
					else
					{
						m_Faction.Broadcast( 1038028 ); // The faction has a new commander.
						m_Faction.Commander = winMob;
					}

					m_Candidates.Clear();
					State = ElectionState.Pending;
				}
				else if ( m_Candidates.Count == 0 ) // well, I guess this'll never happen
				{
					m_Faction.Broadcast( 1038031 ); // There are no longer any valid candidates in the Faction Commander election.

					m_Candidates.Clear();
					State = ElectionState.Pending;
				}
			}
		}

		public bool IsCandidate( Mobile mob )
		{
			return ( FindCandidate( mob ) != null );
		}

		public bool CanVote( Mobile mob )
		{
			return ( m_State == ElectionState.Election && !HasVoted( mob ) );
		}

		public bool HasVoted( Mobile mob )
		{
			return ( FindVoter( mob ) != null );
		}

		public Candidate FindCandidate( Mobile mob )
		{
			for ( int i = 0; i < m_Candidates.Count; ++i )
			{
				if ( m_Candidates[i].Mobile == mob )
					return m_Candidates[i];
			}

			return null;
		}

		public Candidate FindVoter( Mobile mob )
		{
			for ( int i = 0; i < m_Candidates.Count; ++i )
			{
				List<Voter> voters = m_Candidates[i].Voters;

				for ( int j = 0; j < voters.Count; ++j )
				{
					Voter voter = voters[j];

					if ( voter.From == mob )
						return m_Candidates[i];
				}
			}

			return null;
		}

		public bool CanBeCandidate( Mobile mob )
		{
			if ( IsCandidate( mob ) )
				return false;

			if ( m_Candidates.Count >= MaxCandidates )
				return false;

			if ( m_State != ElectionState.Campaign )
				return false; // sanity..

			PlayerState pl = PlayerState.Find( mob );

			return ( pl != null && pl.Faction == m_Faction && pl.Rank.Rank >= CandidateRank );
		}

		public void Slice()
		{
			if ( m_Faction.Election != this )
			{
				if ( m_Timer != null )
					m_Timer.Stop();

				m_Timer = null;

				return;
			}

			switch ( m_State )
			{
				case ElectionState.Pending:
				{
					if ( (m_LastStateTime + PendingPeriod) > DateTime.Now )
						break;

					m_Faction.Broadcast( 1038023 ); // Campaigning for the Faction Commander election has begun.

					m_Candidates.Clear();
					State = ElectionState.Campaign;

					break;
				}
				case ElectionState.Campaign:
				{
					if ( (m_LastStateTime + CampaignPeriod) > DateTime.Now )
						break;

					if ( m_Candidates.Count == 0 )
					{
						m_Faction.Broadcast( 1038025 ); // Nobody ran for office.
						State = ElectionState.Pending;
					}
					else if ( m_Candidates.Count == 1 )
					{
						m_Faction.Broadcast( 1038029 ); // Only one member ran for office.

						Candidate winner = m_Candidates[0];

						Mobile mob = winner.Mobile;
						PlayerState pl = PlayerState.Find( mob );

						if ( pl == null || pl.Faction != m_Faction || mob == m_Faction.Commander )
						{
							m_Faction.Broadcast( 1038026 ); // Faction leadership has not changed.
						}
						else
						{
							m_Faction.Broadcast( 1038028 ); // The faction has a new commander.
							m_Faction.Commander = mob;
						}

						m_Candidates.Clear();
						State = ElectionState.Pending;
					}
					else
					{
						m_Faction.Broadcast( 1038030 );
						State = ElectionState.Election;
					}

					break;
				}
				case ElectionState.Election:
				{
					if ( (m_LastStateTime + VotingPeriod) > DateTime.Now )
						break;

					m_Faction.Broadcast( 1038024 ); // The results for the Faction Commander election are in

					Candidate winner = null;

					for ( int i = 0; i < m_Candidates.Count; ++i )
					{
						Candidate cd = m_Candidates[i];

						PlayerState pl = PlayerState.Find( cd.Mobile );

						if ( pl == null || pl.Faction != m_Faction )
							continue;

						//cd.CleanMuleVotes();

						if ( winner == null || cd.Votes > winner.Votes )
							winner = cd;
					}

					if ( winner == null )
					{
						m_Faction.Broadcast( 1038026 ); // Faction leadership has not changed.
					}
					else if ( winner.Mobile == m_Faction.Commander )
					{
						m_Faction.Broadcast( 1038027 ); // The incumbent won the election.
					}
					else
					{
						m_Faction.Broadcast( 1038028 ); // The faction has a new commander.
						m_Faction.Commander = winner.Mobile;
					}

					m_Candidates.Clear();
					State = ElectionState.Pending;

					break;
				}
			}
		}
	}

	public class Voter
	{
		private Mobile m_From;
		private Mobile m_Candidate;

		private IPAddress m_Address;
		private DateTime m_Time;

		public Mobile From
		{
			get{ return m_From; }
		}

		public Mobile Candidate
		{
			get{ return m_Candidate; }
		}

		public IPAddress Address
		{
			get{ return m_Address; }
		}

		public DateTime Time
		{
			get{ return m_Time; }
		}

		public object[] AcquireFields()
		{
			TimeSpan gameTime = TimeSpan.Zero;

			if ( m_From is PlayerMobile )
				gameTime = ((PlayerMobile)m_From).GameTime;

			int kp = 0;

			PlayerState pl = PlayerState.Find( m_From );

			if ( pl != null )
				kp = pl.KillPoints;

			int sk = m_From.Skills.Total;

			int factorSkills = 50 + ( (sk * 100 ) / 10000 );
			int factorKillPts = 100 + (kp*2);
			int factorGameTime = 50 + (int) ( (gameTime.Ticks * 100) / TimeSpan.TicksPerDay );

			int totalFactor = ( factorSkills * factorKillPts * Math.Max( factorGameTime, 100 ) ) / 10000;

			if ( totalFactor > 100 )
				totalFactor = 100;
			else if ( totalFactor < 0 )
				totalFactor = 0;

			return new object[]{ m_From, m_Address, m_Time, totalFactor };
		}

		public Voter( Mobile from, Mobile candidate )
		{
			m_From = from;
			m_Candidate = candidate;

			if ( m_From.NetState != null )
				m_Address = m_From.NetState.Address;
			else
				m_Address = IPAddress.None;

			m_Time = DateTime.Now;
		}

		public Voter( GenericReader reader, Mobile candidate )
		{
			m_Candidate = candidate;

			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					m_From = reader.ReadMobile();
					m_Address = Utility.Intern( reader.ReadIPAddress() );
					m_Time = reader.ReadDateTime();

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 );

			writer.Write( (Mobile) m_From );
			writer.Write( (IPAddress) m_Address );
			writer.Write( (DateTime) m_Time );
		}
	}

	public class Candidate
	{
		private Mobile m_Mobile;
		private List<Voter> m_Voters;

		public Mobile Mobile{ get{ return m_Mobile; } }
		public List<Voter> Voters { get { return m_Voters; } }

		public int Votes{ get{ return m_Voters.Count; } }

		public void CleanMuleVotes()
		{
			for ( int i = 0; i < m_Voters.Count; ++i )
			{
				Voter voter = (Voter)m_Voters[i];

				if ( (int)voter.AcquireFields()[3] < 90 )
					m_Voters.RemoveAt( i-- );
			}
		}

		public Candidate( Mobile mob )
		{
			m_Mobile = mob;
			m_Voters = new List<Voter>();
		}

		public Candidate( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 1:
				{
					m_Mobile = reader.ReadMobile();

					int count = reader.ReadEncodedInt();
					m_Voters = new List<Voter>( count );

					for ( int i = 0; i < count; ++i )
					{
						Voter voter = new Voter( reader, m_Mobile );

						if ( voter.From != null )
							m_Voters.Add( voter );
					}

					break;
				}
				case 0:
				{
					m_Mobile = reader.ReadMobile();

					List<Mobile> mobs = reader.ReadStrongMobileList();
					m_Voters = new List<Voter>( mobs.Count );

					for ( int i = 0; i < mobs.Count; ++i )
						m_Voters.Add( new Voter( mobs[i], m_Mobile ) );

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version

			writer.Write( (Mobile) m_Mobile );

			writer.WriteEncodedInt( (int) m_Voters.Count );

			for ( int i = 0; i < m_Voters.Count; ++i )
				((Voter)m_Voters[i]).Serialize( writer );
		}
	}

	public enum ElectionState
	{
		Pending,
		Campaign,
		Election
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class ElectionGump : FactionGump
	{
		private PlayerMobile m_From;
		private Election m_Election;

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			switch ( info.ButtonID )
			{
				case 0: // back
				{
					m_From.SendGump( new FactionStoneGump( m_From, m_Election.Faction ) );
					break;
				}
				case 1: // vote
				{
					if ( m_Election.State == ElectionState.Election )
						m_From.SendGump( new VoteGump( m_From, m_Election ) );

					break;
				}
				case 2: // campaign
				{
					if ( m_Election.CanBeCandidate( m_From ) )
						m_Election.AddCandidate( m_From );

					break;
				}
			}
		}

		public ElectionGump( PlayerMobile from, Election election ) : base( 50, 50 )
		{
			m_From = from;
			m_Election = election;

			AddPage( 0 );

			AddBackground( 0, 0, 420, 180, 5054 );
			AddBackground( 10, 10, 400, 160, 3000 );

			AddHtmlText( 20, 20, 380, 20, election.Faction.Definition.Header, false, false );

			// NOTE: Gump not entirely OSI-accurate, intentionally so

			switch ( election.State )
			{
				case ElectionState.Pending:
				{
					TimeSpan toGo = ( election.LastStateTime + Election.PendingPeriod ) - DateTime.Now;
					int days = (int) (toGo.TotalDays + 0.5);

					AddHtmlLocalized( 20, 40, 380, 20, 1038034, false, false ); // A new election campaign is pending

					if ( days > 0 )
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1018062, false, false ); // Days until next election :
						AddLabel( 300, 60, 0, days.ToString() );
					}
					else
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1018059, false, false ); // Election campaigning begins tonight.
					}

					break;
				}
				case ElectionState.Campaign:
				{
					TimeSpan toGo = ( election.LastStateTime + Election.CampaignPeriod ) - DateTime.Now;
					int days = (int) (toGo.TotalDays + 0.5);

					AddHtmlLocalized( 20, 40, 380, 20, 1018058, false, false ); // There is an election campaign in progress.

					if ( days > 0 )
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1038033, false, false ); // Days to go:
						AddLabel( 300, 60, 0, days.ToString() );
					}
					else
					{
						AddHtmlLocalized( 20, 60, 280, 20, 1018061, false, false ); // Campaign in progress. Voting begins tonight.
					}

					if ( m_Election.CanBeCandidate( m_From ) )
					{
						AddButton( 20, 110, 4005, 4007, 2, GumpButtonType.Reply, 0 );
						AddHtmlLocalized( 55, 110, 350, 20, 1011427, false, false ); // CAMPAIGN FOR LEADERSHIP
					}
					else
					{
						PlayerState pl = PlayerState.Find( m_From );

						if ( pl == null || pl.Rank.Rank < Election.CandidateRank )
							AddHtmlLocalized( 20, 100, 380, 20, 1010118, false, false ); // You must have a higher rank to run for office
					}

					break;
				}
				case ElectionState.Election:
				{
					TimeSpan toGo = ( election.LastStateTime + Election.VotingPeriod ) - DateTime.Now;
					int days = (int) Math.Ceiling( toGo.TotalDays );

					AddHtmlLocalized( 20, 40, 380, 20, 1018060, false, false ); // There is an election vote in progress.

					AddHtmlLocalized( 20, 60, 280, 20, 1038033, false, false );
					AddLabel( 300, 60, 0, days.ToString() );

					AddHtmlLocalized( 55, 100, 380, 20, 1011428, false, false ); // VOTE FOR LEADERSHIP
					AddButton( 20, 100, 4005, 4007, 1, GumpButtonType.Reply, 0 );

					break;
				}
			}

			AddButton( 20, 140, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 55, 140, 350, 20, 1011012, false, false ); // CANCEL
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class ElectionManagementGump : Gump
	{
		public string Right( string text )
		{
			return String.Format( "<DIV ALIGN=RIGHT>{0}</DIV>", text );
		}

		public string Center( string text )
		{
			return String.Format( "<CENTER>{0}</CENTER>", text );
		}

		public string Color( string text, int color )
		{
			return String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text );
		}

		public static string FormatTimeSpan( TimeSpan ts )
		{
			return String.Format( "{0:D2}:{1:D2}:{2:D2}:{3:D2}", ts.Days, ts.Hours % 24, ts.Minutes % 60, ts.Seconds % 60 );
		}

		public const int LabelColor = 0xFFFFFF;

		private Election m_Election;
		private Candidate m_Candidate;
		private int m_Page;

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			int bid = info.ButtonID;

			if ( m_Candidate == null )
			{
				if ( bid == 0 )
				{
				}
				else if ( bid == 1 )
				{
				}
				else
				{
					bid -= 2;

					if ( bid >= 0 && bid < m_Election.Candidates.Count )
						from.SendGump( new ElectionManagementGump( m_Election, m_Election.Candidates[bid], 0 ) );
				}
			}
			else
			{
				if ( bid == 0 )
				{
					from.SendGump( new ElectionManagementGump( m_Election ) );
				}
				else if ( bid == 1 )
				{
					m_Election.RemoveCandidate( m_Candidate.Mobile );
					from.SendGump( new ElectionManagementGump( m_Election ) );
				}
				else if ( bid == 2 && m_Page > 0 )
				{
					from.SendGump( new ElectionManagementGump( m_Election, m_Candidate, m_Page - 1 ) );
				}
				else if ( bid == 3 && (m_Page + 1) * 10 < m_Candidate.Voters.Count )
				{
					from.SendGump( new ElectionManagementGump( m_Election, m_Candidate, m_Page + 1 ) );
				}
				else
				{
					bid -= 4;

					if ( bid >= 0 && bid < m_Candidate.Voters.Count )
					{
						m_Candidate.Voters.RemoveAt( bid );
						from.SendGump( new ElectionManagementGump( m_Election, m_Candidate, m_Page ) );
					}
				}
			}
		}

		public ElectionManagementGump( Election election ) : this( election, null, 0 )
		{
		}

		public ElectionManagementGump( Election election, Candidate candidate, int page ) : base( 40, 40 )
		{
			m_Election = election;
			m_Candidate = candidate;
			m_Page = page;

			AddPage( 0 );

			if ( candidate != null )
			{
				AddBackground( 0, 0, 448, 354, 9270 );
				AddAlphaRegion( 10, 10, 428, 334 );

				AddHtml( 10, 10, 428, 20, Color( Center( "Candidate Management" ), LabelColor ), false, false );

				AddHtml(  45, 35, 100, 20, Color( "Player Name:", LabelColor ), false, false );
				AddHtml( 145, 35, 100, 20, Color( candidate.Mobile == null ? "null" : candidate.Mobile.Name, LabelColor ), false, false );

				AddHtml(  45, 55, 100, 20, Color( "Vote Count:", LabelColor ), false, false );
				AddHtml( 145, 55, 100, 20, Color( candidate.Votes.ToString(), LabelColor ), false, false );

				AddButton( 12, 73, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				AddHtml(  45, 75, 100, 20, Color( "Drop Candidate", LabelColor ), false, false );

				AddImageTiled( 13, 99, 422, 242, 9264 );
				AddImageTiled( 14, 100, 420, 240, 9274 );
				AddAlphaRegion( 14, 100, 420, 240 );

				AddHtml( 14, 100, 420, 20, Color( Center( "Voters" ), LabelColor ), false, false );

				if ( page > 0 )
					AddButton( 397, 104, 0x15E3, 0x15E7, 2, GumpButtonType.Reply, 0 );
				else
					AddImage( 397, 104, 0x25EA );

				if ( (page + 1) * 10 < candidate.Voters.Count )
					AddButton( 414, 104, 0x15E1, 0x15E5, 3, GumpButtonType.Reply, 0 );
				else
					AddImage( 414, 104, 0x25E6 );

				AddHtml( 14, 120, 30, 20, Color( Center( "DEL" ), LabelColor ), false, false );
				AddHtml( 47, 120, 150, 20, Color( "Name", LabelColor ), false, false );
				AddHtml( 195, 120, 100, 20, Color( Center( "Address" ), LabelColor ), false, false );
				AddHtml( 295, 120, 80, 20, Color( Center( "Time" ), LabelColor ), false, false );
				AddHtml( 355, 120, 60, 20, Color( Center( "Legit" ), LabelColor ), false, false );

				int idx = 0;

				for ( int i = page*10; i >= 0 && i < candidate.Voters.Count && i < (page+1)*10; ++i, ++idx )
				{
					Voter voter = (Voter)candidate.Voters[i];

					AddButton( 13, 138 + (idx * 20), 4002, 4004, 4 + i, GumpButtonType.Reply, 0 );

					object[] fields = voter.AcquireFields();

					int x = 45;

					for ( int j = 0; j < fields.Length; ++j )
					{
						object obj = fields[j];

						if ( obj is Mobile )
						{
							AddHtml( x + 2, 140 + (idx * 20), 150, 20, Color( ((Mobile)obj).Name, LabelColor ), false, false );
							x += 150;
						}
						else if ( obj is System.Net.IPAddress )
						{
							AddHtml( x, 140 + (idx * 20), 100, 20, Color( Center( obj.ToString() ), LabelColor ), false, false );
							x += 100;
						}
						else if ( obj is DateTime )
						{
							AddHtml( x, 140 + (idx * 20), 80, 20, Color( Center( FormatTimeSpan( ((DateTime)obj) - election.LastStateTime ) ), LabelColor ), false, false );
							x += 80;
						}
						else if ( obj is int )
						{
							AddHtml( x, 140 + (idx * 20), 60, 20, Color( Center( (int)obj + "%" ), LabelColor ), false, false );
							x += 60;
						}
					}
				}
			}
			else
			{
				AddBackground( 0, 0, 288, 334, 9270 );
				AddAlphaRegion( 10, 10, 268, 314 );

				AddHtml( 10, 10, 268, 20, Color( Center( "Election Management" ), LabelColor ), false, false );

				AddHtml(  45, 35, 100, 20, Color( "Current State:", LabelColor ), false, false );
				AddHtml( 145, 35, 100, 20, Color( election.State.ToString(), LabelColor ), false, false );

				AddButton( 12, 53, 4005, 4007, 1, GumpButtonType.Reply, 0 );
				AddHtml(  45, 55, 100, 20, Color( "Transition Time:", LabelColor ), false, false );
				AddHtml( 145, 55, 100, 20, Color( FormatTimeSpan( election.NextStateTime ), LabelColor ), false, false );

				AddImageTiled( 13, 79, 262, 242, 9264 );
				AddImageTiled( 14, 80, 260, 240, 9274 );
				AddAlphaRegion( 14, 80, 260, 240 );

				AddHtml( 14, 80, 260, 20, Color( Center( "Candidates" ), LabelColor ), false, false );
				AddHtml( 14, 100, 30, 20, Color( Center( "-->" ), LabelColor ), false, false );
				AddHtml( 47, 100, 150, 20, Color( "Name", LabelColor ), false, false );
				AddHtml( 195, 100, 80, 20, Color( Center( "Votes" ), LabelColor ), false, false );

				for ( int i = 0; i < election.Candidates.Count; ++i )
				{
					Candidate cd = election.Candidates[i];
					Mobile mob = cd.Mobile;

					if ( mob == null )
						continue;

					AddButton( 13, 118 + (i * 20), 4005, 4007, 2 + i, GumpButtonType.Reply, 0 );
					AddHtml( 47, 120 + (i * 20), 150, 20, Color( mob.Name, LabelColor ), false, false );
					AddHtml( 195, 120 + (i * 20), 80, 20, Color( Center( cd.Votes.ToString() ), LabelColor ), false, false );
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class EmeraldWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public EmeraldWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the emerald wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "emerald", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "emerald scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public EmeraldWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Network;

namespace Server.Items
{
	public class EnchantedSextant : Item
	{
		//TODO: Sosaria/Haven
		private static readonly Point2D[] m_SosariaBanks = new Point2D[]
			{
				new Point2D( 652, 820 ),
				new Point2D( 1813, 2825 ),
				new Point2D( 3734, 2149 ),
				new Point2D( 2503, 552 ),
				new Point2D( 3764, 1317 ),
				new Point2D( 587, 2146 ),
				new Point2D( 1655, 1606 ),
				new Point2D( 1425, 1690 ),
				new Point2D( 4471, 1156 ),
				new Point2D( 1317, 3773 ),
				new Point2D( 2881, 684 ),
				new Point2D( 2731, 2192 ),
				new Point2D( 3620, 2617 ),
				new Point2D( 2880, 3472 ),
				new Point2D( 1897, 2684 ),
				new Point2D( 5346, 74 ),
				new Point2D( 5275, 3977 ),
				new Point2D( 5669, 3131 )
			};

		private static readonly Point2D[] m_LodorBanks = new Point2D[]
			{
				new Point2D( 652, 820 ),
				new Point2D( 1813, 2825 ),
				new Point2D( 3734, 2149 ),
				new Point2D( 2503, 552 ),
				new Point2D( 3764, 1317 ),
				new Point2D( 3695, 2511 ),
				new Point2D( 587, 2146 ),
				new Point2D( 1655, 1606 ),
				new Point2D( 1425, 1690 ),
				new Point2D( 4471, 1156 ),
				new Point2D( 1317, 3773 ),
				new Point2D( 2881, 684 ),
				new Point2D( 2731, 2192 ),
				new Point2D( 2880, 3472 ),
				new Point2D( 1897, 2684 ),
				new Point2D( 5346, 74 ),
				new Point2D( 5275, 3977 ),
				new Point2D( 5669, 3131 )
			};

		private static readonly Point2D[] m_UnderworldBanks = new Point2D[]
			{
				new Point2D( 854, 680 ),
				new Point2D( 855, 603 ),
				new Point2D( 1226, 554 ),
				new Point2D( 1610, 556 )
			};

		private static readonly Point2D[] m_SerpentIslandBanks = new Point2D[]
			{
				new Point2D( 996, 519 ),
				new Point2D( 2048, 1345 )
			};

		private const double m_LongDistance = 300.0;
		private const double m_ShortDistance = 5.0;

		public override int LabelNumber { get { return 1046226; } } // an enchanted sextant

		[Constructable]
		public EnchantedSextant() : base( 0x1058 )
		{
			Weight = 2.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				return;
			}

			Point2D[] banks;
			PMList moongates;
			if ( from.Map == Map.Sosaria )
			{
				banks = m_SosariaBanks;
				moongates = PMList.Sosaria;
			}
			else if ( from.Map == Map.Lodor )
			{
				banks = m_LodorBanks;
				moongates = PMList.Lodor;
			}
			else if ( from.Map == Map.Underworld )
			{
#if false
				banks = m_UnderworldBanks;
				moongates = PMList.Underworld;
#else
				from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, 0x482, 3, 1061684, "", "" ) ); // The magic of the sextant fails...
				return;
#endif
			}
			else if ( from.Map == Map.SerpentIsland )
			{
				banks = m_SerpentIslandBanks;
				moongates = PMList.SerpentIsland;
			}
			else
			{
				banks = null;
				moongates = null;
			}

			Point3D closestMoongate = Point3D.Zero;
			double moongateDistance = double.MaxValue;
			if ( moongates != null )
			{
				foreach ( PMEntry entry in moongates.Entries )
				{
					double dist = from.GetDistanceToSqrt( entry.Location );
					if ( moongateDistance > dist )
					{
						closestMoongate = entry.Location;
						moongateDistance = dist;
					}
				}
			}

			Point2D closestBank = Point2D.Zero;
			double bankDistance = double.MaxValue;
			if ( banks != null )
			{
				foreach ( Point2D p in banks )
				{
					double dist = from.GetDistanceToSqrt( p );
					if ( bankDistance > dist )
					{
						closestBank = p;
						bankDistance = dist;
					}
				}
			}

			int moonMsg;
			if ( moongateDistance == double.MaxValue )
				moonMsg = 1048021; // The sextant fails to find a Moongate nearby.
			else if ( moongateDistance > m_LongDistance )
				moonMsg = 1046449 + (int)from.GetDirectionTo( closestMoongate ); // A moongate is * from here
			else if ( moongateDistance > m_ShortDistance )
				moonMsg = 1048010 + (int)from.GetDirectionTo( closestMoongate ); // There is a Moongate * of here.
			else
				moonMsg = 1048018; // You are next to a Moongate at the moment.

			from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, 0x482, 3, moonMsg, "", "" ) );

			int bankMsg;
			if ( bankDistance == double.MaxValue )
				bankMsg = 1048020; // The sextant fails to find a Bank nearby.
			else if ( bankDistance > m_LongDistance )
				bankMsg = 1046462 + (int)from.GetDirectionTo( closestBank ); // A town is * from here
			else if ( bankDistance > m_ShortDistance )
				bankMsg = 1048002 + (int)from.GetDirectionTo( closestBank ); // There is a city Bank * of here.
			else
				bankMsg = 1048019; // You are next to a Bank at the moment.

			from.Send( new MessageLocalized( Serial, ItemID, MessageType.Label, 0x5AA, 3, bankMsg, "", "" ) );
		}

		public EnchantedSextant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Ethics
{
	public abstract class Ethic
	{
		public static readonly bool Enabled = false;

		public static Ethic Find( Item item )
		{
			if ( ( item.SavedFlags & 0x100 ) != 0 )
			{
				if ( item.Hue == Hero.Definition.PrimaryHue )
					return Hero;

				item.SavedFlags &= ~0x100;
			}

			if ( ( item.SavedFlags & 0x200 ) != 0 )
			{
				if ( item.Hue == Evil.Definition.PrimaryHue )
					return Evil;

				item.SavedFlags &= ~0x200;
			}

			return null;
		}

		public static bool CheckTrade( Mobile from, Mobile to, Mobile newOwner, Item item )
		{
			Ethic itemEthic = Find( item );

			if ( itemEthic == null || Find( newOwner ) == itemEthic )
				return true;

			if ( itemEthic == Hero )
				( from == newOwner ? to : from ).SendMessage( "Only heros may receive this item." );
			else if ( itemEthic == Evil )
				( from == newOwner ? to : from ).SendMessage( "Only the evil may receive this item." );

			return false;
		}

		public static bool CheckEquip( Mobile from, Item item )
		{
			Ethic itemEthic = Find( item );

			if ( itemEthic == null || Find( from ) == itemEthic )
				return true;

			if ( itemEthic == Hero )
				from.SendMessage( "Only heros may wear this item." );
			else if ( itemEthic == Evil )
				from.SendMessage( "Only the evil may wear this item." );

			return false;
		}

		public static bool IsImbued( Item item )
		{
			return IsImbued( item, false );
		}

		public static bool IsImbued( Item item, bool recurse )
		{
			if ( Find( item ) != null )
				return true;

			if ( recurse )
			{
				foreach ( Item child in item.Items )
				{
					if ( IsImbued( child, true ) )
						return true;
				}
			}

			return false;
		}

		public static void Initialize()
		{
			if( Enabled )
				EventSink.Speech += new SpeechEventHandler( EventSink_Speech );
		}

		public static void EventSink_Speech( SpeechEventArgs e )
		{
			if ( e.Blocked || e.Handled )
				return;

			Player pl = Player.Find( e.Mobile );

			if ( pl == null )
			{
				for ( int i = 0; i < Ethics.Length; ++i )
				{
					Ethic ethic = Ethics[i];

					if ( !ethic.IsEligible( e.Mobile ) )
						continue;

					if ( !Insensitive.Equals( ethic.Definition.JoinPhrase.String, e.Speech ) )
						continue;

					bool isNearAnkh = false;

					foreach ( Item item in e.Mobile.GetItemsInRange( 2 ) )
					{
						if ( item is Items.AnkhNorth || item is Items.AnkhWest )
						{
							isNearAnkh = true;
							break;
						}
					}

					if ( !isNearAnkh )
						continue;

					pl = new Player( ethic, e.Mobile );

					pl.Attach();

					e.Mobile.FixedEffect( 0x373A, 10, 30 );
					e.Mobile.PlaySound( 0x209 );

					e.Handled = true;
					break;
				}
			}
			else
			{
				Ethic ethic = pl.Ethic;

				for ( int i = 0; i < ethic.Definition.Powers.Length; ++i )
				{
					Power power = ethic.Definition.Powers[i];

					if ( !Insensitive.Equals( power.Definition.Phrase.String, e.Speech ) )
						continue;

					if ( !power.CheckInvoke( pl ) )
						continue;

					power.BeginInvoke( pl );
					e.Handled = true;

					break;
				}
			}
		}

		protected EthicDefinition m_Definition;

		protected PlayerCollection m_Players;

		public EthicDefinition Definition
		{
			get { return m_Definition; }
		}

		public PlayerCollection Players
		{
			get { return m_Players; }
		}

		public static Ethic Find( Mobile mob )
		{
			return Find( mob, false, false );
		}

		public static Ethic Find( Mobile mob, bool inherit )
		{
			return Find( mob, inherit, false );
		}

		public static Ethic Find( Mobile mob, bool inherit, bool allegiance )
		{
			Player pl = Player.Find( mob );

			if ( pl != null )
				return pl.Ethic;

			if ( inherit && mob is BaseCreature )
			{
				BaseCreature bc = (BaseCreature) mob;

				if ( bc.Controlled )
					return Find( bc.ControlMaster, false );
				else if ( bc.Summoned )
					return Find( bc.SummonMaster, false );
				else if ( allegiance )
					return bc.EthicAllegiance;
			}

			return null;
		}

		public Ethic()
		{
			m_Players = new PlayerCollection();
		}

		public abstract bool IsEligible( Mobile mob );

		public virtual void Deserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					int playerCount = reader.ReadEncodedInt();

					for ( int i = 0; i < playerCount; ++i )
					{
						Player pl = new Player( this, reader );

						if ( pl.Mobile != null )
							Timer.DelayCall( TimeSpan.Zero, new TimerCallback( pl.CheckAttach ) );
					}

					break;
				}
			}
		}

		public virtual void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( 0 ); // version

			writer.WriteEncodedInt( m_Players.Count );

			for ( int i = 0; i < m_Players.Count; ++i )
				m_Players[i].Serialize( writer );
		}

		public static readonly Ethic Hero = new Hero.HeroEthic();
		public static readonly Ethic Evil = new Evil.EvilEthic();

		public static readonly Ethic[] Ethics = new Ethic[]
			{
				Hero,
				Evil
			};
	}
}
// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics
{
	public class EthicDefinition
	{
		private int m_PrimaryHue;

		private TextDefinition m_Title;
		private TextDefinition m_Adjunct;

		private TextDefinition m_JoinPhrase;

		private Power[] m_Powers;

		public int PrimaryHue { get { return m_PrimaryHue; } }

		public TextDefinition Title { get { return m_Title; } }
		public TextDefinition Adjunct { get { return m_Adjunct; } }

		public TextDefinition JoinPhrase { get { return m_JoinPhrase; } }

		public Power[] Powers { get { return m_Powers; } }

		public EthicDefinition( int primaryHue, TextDefinition title, TextDefinition adjunct, TextDefinition joinPhrase, Power[] powers )
		{
			m_PrimaryHue = primaryHue;

			m_Title = title;
			m_Adjunct = adjunct;

			m_JoinPhrase = joinPhrase;

			m_Powers = powers;
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;// using Server.Factions;

namespace Server.Ethics.Hero
{
	public sealed class HeroEthic : Ethic
	{
		public HeroEthic()
		{
			m_Definition = new EthicDefinition(
					0x482,
					"Hero", "(Hero)",
					"I will defend the virtues",
					new Power[]
					{
						new HolySense(),
						new HolyItem(),
						new SummonFamiliar(),
						new HolyBlade(),
						new Bless(),
						new HolyShield(),
						new HolySteed(),
						new HolyWord()
					}
				);
		}

		public override bool IsEligible( Mobile mob )
		{
			if ( mob.Kills >= 5 )
				return false;

			Faction fac = Faction.Find( mob );

			return ( fac is TrueBritannians || fac is CouncilOfMages );
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Factions;

namespace Server.Ethics.Evil
{
	public sealed class EvilEthic : Ethic
	{
		public EvilEthic()
		{
			m_Definition = new EthicDefinition(
					0x455,
					"Evil", "(Evil)",
					"I am evil incarnate",
					new Power[]
					{
						new UnholySense(),
						new UnholyItem(),
						new SummonFamiliar(),
						new VileBlade(),
						new Blight(),
						new UnholyShield(),
						new UnholySteed(),
						new UnholyWord()
					}
				);
		}

		public override bool IsEligible( Mobile mob )
		{
			Faction fac = Faction.Find( mob );

			return ( fac is Minax || fac is Shadowlords );
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Guilds;// using Server.Mobiles;// using Server.Prompts;// using Server.Targeting;// using Server.Accounting;// using Server.Commands;// using Server.Commands.Generic;

namespace Server.Factions
{
	[CustomEnum( new string[]{ "Minax", "Council of Mages", "True Britannians", "Shadowlords" } )]
	public abstract class Faction : IComparable
	{
		public int ZeroRankOffset;

		private FactionDefinition m_Definition;
		private FactionState m_State;
		private StrongholdRegion m_StrongholdRegion;

		public StrongholdRegion StrongholdRegion
		{
			get{ return m_StrongholdRegion; }
			set{ m_StrongholdRegion = value; }
		}

		public FactionDefinition Definition
		{
			get{ return m_Definition; }
			set
			{
				m_Definition = value;
				m_StrongholdRegion = new StrongholdRegion( this );
			}
		}

		public FactionState State
		{
			get{ return m_State; }
			set{ m_State = value; }
		}

		public Election Election
		{
			get{ return m_State.Election; }
			set{ m_State.Election = value; }
		}

		public Mobile Commander
		{
			get{ return m_State.Commander; }
			set{ m_State.Commander = value; }
		}

		public int Tithe
		{
			get{ return m_State.Tithe; }
			set{ m_State.Tithe = value; }
		}

		public int Silver
		{
			get{ return m_State.Silver; }
			set{ m_State.Silver = value; }
		}

		public List<PlayerState> Members
		{
			get{ return m_State.Members; }
			set{ m_State.Members = value; }
		}

		public static readonly TimeSpan LeavePeriod = TimeSpan.FromDays( 3.0 );

		public bool FactionMessageReady
		{
			get{ return m_State.FactionMessageReady; }
		}

		public void Broadcast( string text )
		{
			Broadcast( 0x3B2, text );
		}

		public void Broadcast( int hue, string text )
		{
			List<PlayerState> members = Members;

			for ( int i = 0; i < members.Count; ++i )
				members[i].Mobile.SendMessage( hue, text );
		}

		public void Broadcast( int number )
		{
			List<PlayerState> members = Members;

			for ( int i = 0; i < members.Count; ++i )
				members[i].Mobile.SendLocalizedMessage( number );
		}

		public void Broadcast( string format, params object[] args )
		{
			Broadcast( String.Format( format, args ) );
		}

		public void Broadcast( int hue, string format, params object[] args )
		{
			Broadcast( hue, String.Format( format, args ) );
		}

		public void BeginBroadcast( Mobile from )
		{
			from.SendLocalizedMessage( 1010265 ); // Enter Faction Message
			from.Prompt = new BroadcastPrompt( this );
		}

		public void EndBroadcast( Mobile from, string text )
		{
			if ( from.AccessLevel == AccessLevel.Player )
				m_State.RegisterBroadcast();

			Broadcast( Definition.HueBroadcast, "{0} [Commander] {1} : {2}", from.Name, Definition.FriendlyName, text );
		}

		private class BroadcastPrompt : Prompt
		{
			private Faction m_Faction;

			public BroadcastPrompt( Faction faction )
			{
				m_Faction = faction;
			}

			public override void OnResponse( Mobile from, string text )
			{
				m_Faction.EndBroadcast( from, text );
			}
		}

		public static void HandleAtrophy()
		{
			foreach ( Faction f in Factions )
			{
				if ( !f.State.IsAtrophyReady )
					return;
			}

			List<PlayerState> activePlayers = new List<PlayerState>();

			foreach ( Faction f in Factions )
			{
				foreach ( PlayerState ps in f.Members )
				{
					if ( ps.KillPoints > 0 && ps.IsActive )
						activePlayers.Add( ps );
				}
			}

			int distrib = 0;

			foreach ( Faction f in Factions )
				distrib += f.State.CheckAtrophy();

			if ( activePlayers.Count == 0 )
				return;

			for ( int i = 0; i < distrib; ++i )
				activePlayers[Utility.Random( activePlayers.Count )].KillPoints++;
		}

		public static void DistributePoints( int distrib ) {
			List<PlayerState> activePlayers = new List<PlayerState>();

			foreach ( Faction f in Factions ) {
				foreach ( PlayerState ps in f.Members ) {
					if ( ps.KillPoints > 0 && ps.IsActive ) {
						activePlayers.Add( ps );
					}
				}
			}

			if ( activePlayers.Count > 0 ) {
				for ( int i = 0; i < distrib; ++i ) {
					activePlayers[Utility.Random( activePlayers.Count )].KillPoints++;
				}
			}
		}

		public void BeginHonorLeadership( Mobile from )
		{
			from.SendLocalizedMessage( 502090 ); // Click on the player whom you wish to honor.
			from.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( HonorLeadership_OnTarget ) );
		}

		public void HonorLeadership_OnTarget( Mobile from, object obj )
		{
			if ( obj is Mobile )
			{
				Mobile recv = (Mobile) obj;

				PlayerState giveState = PlayerState.Find( from );
				PlayerState recvState = PlayerState.Find( recv );

				if ( giveState == null )
					return;

				if ( recvState == null || recvState.Faction != giveState.Faction )
				{
					from.SendLocalizedMessage( 1042497 ); // Only faction mates can be honored this way.
				}
				else if ( giveState.KillPoints < 5 )
				{
					from.SendLocalizedMessage( 1042499 ); // You must have at least five kill points to honor them.
				}
				else
				{
					recvState.LastHonorTime = DateTime.Now;
					giveState.KillPoints -= 5;
					recvState.KillPoints += 4;

					// TODO: Confirm no message sent to giver
					recv.SendLocalizedMessage( 1042500 ); // You have been honored with four kill points.
				}
			}
			else
			{
				from.SendLocalizedMessage( 1042496 ); // You may only honor another player.
			}
		}

		public virtual void AddMember( Mobile mob )
		{
			Members.Insert( ZeroRankOffset, new PlayerState( mob, this, Members ) );

			mob.AddToBackpack( FactionItem.Imbue( new Robe(), this, false, Definition.HuePrimary ) );
			mob.SendLocalizedMessage( 1010374 ); // You have been granted a robe which signifies your faction

			mob.InvalidateProperties();
			mob.Delta( MobileDelta.Noto );

			mob.FixedEffect( 0x373A, 10, 30 );
			mob.PlaySound( 0x209 );
		}

		public static bool IsNearType( Mobile mob, Type type, int range )
		{
			bool mobs = type.IsSubclassOf( typeof( Mobile ) );
			bool items = type.IsSubclassOf( typeof( Item ) );

			IPooledEnumerable eable;

			if ( mobs )
				eable = mob.GetMobilesInRange( range );
			else if ( items )
				eable = mob.GetItemsInRange( range );
			else
				return false;

			foreach ( object obj in eable )
			{
				if ( type.IsAssignableFrom( obj.GetType() ) )
				{
					eable.Free();
					return true;
				}
			}

			eable.Free();
			return false;
		}

		public static bool IsNearType( Mobile mob, Type[] types, int range )
		{
			IPooledEnumerable eable = mob.GetObjectsInRange( range );

			foreach( object obj in eable )
			{
				Type objType = obj.GetType();

				for( int i = 0; i < types.Length; i++ )
				{
					if( types[i].IsAssignableFrom( objType ) )
					{
						eable.Free();
						return true;
					}
				}
			}

			eable.Free();
			return false;
		}

		public void RemovePlayerState( PlayerState pl )
		{
			if ( pl == null || !Members.Contains( pl ) )
				return;

			int killPoints = pl.KillPoints;

			if ( pl.RankIndex != -1 ) {
				while ( ( pl.RankIndex + 1 ) < ZeroRankOffset ) {
					PlayerState pNext = Members[pl.RankIndex+1] as PlayerState;
					Members[pl.RankIndex+1] = pl;
					Members[pl.RankIndex] = pNext;
					pl.RankIndex++;
					pNext.RankIndex--;
				}

				ZeroRankOffset--;
			}

			Members.Remove( pl );

			PlayerMobile pm = (PlayerMobile)pl.Mobile;
			if ( pm == null )
				return;

			Mobile mob = pl.Mobile;
			if ( pm.FactionPlayerState == pl ) {
				pm.FactionPlayerState = null;

				mob.InvalidateProperties();
				mob.Delta( MobileDelta.Noto );

				if ( Election.IsCandidate( mob ) )
					Election.RemoveCandidate( mob );

				if ( pl.Finance != null )
					pl.Finance.Finance = null;

				if ( pl.Sheriff != null )
					pl.Sheriff.Sheriff = null;

				Election.RemoveVoter( mob );

				if ( Commander == mob )
					Commander = null;

				pm.ValidateEquipment();
			}

			if ( killPoints > 0 )
				DistributePoints( killPoints );
		}

		public void RemoveMember( Mobile mob )
		{
			PlayerState pl = PlayerState.Find( mob );

			if ( pl == null || !Members.Contains( pl ) )
				return;

			int killPoints = pl.KillPoints;

			if( mob.Backpack != null )
			{
				//Ordinarily, through normal faction removal, this will never find any sigils.
				//Only with a leave delay less than the ReturnPeriod or a Faction Kick/Ban, will this ever do anything
				Item[] sigils = mob.Backpack.FindItemsByType( typeof( Sigil ) );

				for ( int i = 0; i < sigils.Length; ++i )
					((Sigil)sigils[i]).ReturnHome();
			}

			if ( pl.RankIndex != -1 ) {
				while ( ( pl.RankIndex + 1 ) < ZeroRankOffset ) {
					PlayerState pNext = Members[pl.RankIndex+1];
					Members[pl.RankIndex+1] = pl;
					Members[pl.RankIndex] = pNext;
					pl.RankIndex++;
					pNext.RankIndex--;
				}

				ZeroRankOffset--;
			}

			Members.Remove( pl );

			if ( mob is PlayerMobile )
				((PlayerMobile)mob).FactionPlayerState = null;

			mob.InvalidateProperties();
			mob.Delta( MobileDelta.Noto );

			if ( Election.IsCandidate( mob ) )
				Election.RemoveCandidate( mob );

			Election.RemoveVoter( mob );

			if ( pl.Finance != null )
				pl.Finance.Finance = null;

			if ( pl.Sheriff != null )
				pl.Sheriff.Sheriff = null;

			if ( Commander == mob )
				Commander = null;

			if ( mob is PlayerMobile )
				((PlayerMobile)mob).ValidateEquipment();

			if ( killPoints > 0 )
				DistributePoints( killPoints );
		}

		public void JoinGuilded( PlayerMobile mob, Guild guild )
		{
			if ( mob.Young )
			{
				guild.RemoveMember( mob );
				mob.SendLocalizedMessage( 1042283 ); // You have been kicked out of your guild!  Young players may not remain in a guild which is allied with a faction.
			}
			else if ( AlreadyHasCharInFaction( mob ) )
			{
				guild.RemoveMember( mob );
				mob.SendLocalizedMessage( 1005281 ); // You have been kicked out of your guild due to factional overlap
			}
			else if ( IsFactionBanned( mob ) )
			{
				guild.RemoveMember( mob );
				mob.SendLocalizedMessage( 1005052 ); // You are currently banned from the faction system
			}
			else
			{
				AddMember( mob );
				mob.SendLocalizedMessage( 1042756, true, " " + m_Definition.FriendlyName ); // You are now joining a faction:
			}
		}

		public void JoinAlone( Mobile mob )
		{
			AddMember( mob );
			mob.SendLocalizedMessage( 1005058 ); // You have joined the faction
		}

		private bool AlreadyHasCharInFaction( Mobile mob )
		{
			Account acct = mob.Account as Account;

			if ( acct != null )
			{
				for ( int i = 0; i < acct.Length; ++i )
				{
					Mobile c = acct[i];

					if ( Find( c ) != null )
						return true;
				}
			}

			return false;
		}

		public static bool IsFactionBanned( Mobile mob )
		{
			Account acct = mob.Account as Account;

			if ( acct == null )
				return false;

			return ( acct.GetTag( "FactionBanned" ) != null );
		}

		public void OnJoinAccepted( Mobile mob )
		{
			PlayerMobile pm = mob as PlayerMobile;

			if ( pm == null )
				return; // sanity

			PlayerState pl = PlayerState.Find( pm );

			if ( pm.Young )
				pm.SendLocalizedMessage( 1010104 ); // You cannot join a faction as a young player
			else if ( pl != null && pl.IsLeaving )
				pm.SendLocalizedMessage( 1005051 ); // You cannot use the faction stone until you have finished quitting your current faction
			else if ( AlreadyHasCharInFaction( pm ) )
				pm.SendLocalizedMessage( 1005059 ); // You cannot join a faction because you already declared your allegiance with another character
			else if ( IsFactionBanned( mob ) )
				pm.SendLocalizedMessage( 1005052 ); // You are currently banned from the faction system
			else if ( pm.Guild != null )
			{
				Guild guild = pm.Guild as Guild;

				if ( guild.Leader != pm )
					pm.SendLocalizedMessage( 1005057 ); // You cannot join a faction because you are in a guild and not the guildmaster
				else if ( !Guild.NewGuildSystem && guild.Type != GuildType.Regular )
					pm.SendLocalizedMessage( 1042161 ); // You cannot join a faction because your guild is an Order or Chaos type.
				else if ( !Guild.NewGuildSystem && guild.Enemies != null && guild.Enemies.Count > 0 )	//CAN join w/wars in new system
					pm.SendLocalizedMessage( 1005056 ); // You cannot join a faction with active Wars
				else if ( Guild.NewGuildSystem && guild.Alliance != null )
					pm.SendLocalizedMessage( 1080454 ); // Your guild cannot join a faction while in alliance with non-factioned guilds.
				else if ( !CanHandleInflux( guild.Members.Count ) )
					pm.SendLocalizedMessage( 1018031 ); // In the interest of faction stability, this faction declines to accept new members for now.
				else
				{
					List<Mobile> members = new List<Mobile>( guild.Members );

					for ( int i = 0; i < members.Count; ++i )
					{
						PlayerMobile member = members[i] as PlayerMobile;

						if ( member == null )
							continue;

						JoinGuilded( member, guild );
					}
				}
			}
			else if ( !CanHandleInflux( 1 ) )
			{
				pm.SendLocalizedMessage( 1018031 ); // In the interest of faction stability, this faction declines to accept new members for now.
			}
			else
			{
				JoinAlone( mob );
			}
		}

		public bool IsCommander( Mobile mob )
		{
			if ( mob == null )
				return false;

			return ( mob.AccessLevel >= AccessLevel.GameMaster || mob == Commander );
		}

		public Faction()
		{
			m_State = new FactionState( this );
		}

		public override string ToString()
		{
			return m_Definition.FriendlyName;
		}

		public int CompareTo( object obj )
		{
			return m_Definition.Sort - ((Faction)obj).m_Definition.Sort;
		}

		public static bool CheckLeaveTimer( Mobile mob )
		{
			PlayerState pl = PlayerState.Find( mob );

			if ( pl == null || !pl.IsLeaving )
				return false;

			if ( (pl.Leaving + LeavePeriod) >= DateTime.Now )
				return false;

			mob.SendLocalizedMessage( 1005163 ); // You have now quit your faction

			pl.Faction.RemoveMember( mob );

			return true;
		}

		public static void Initialize()
		{
			EventSink.Login += new LoginEventHandler( EventSink_Login );
			EventSink.Logout += new LogoutEventHandler( EventSink_Logout );

			Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 10.0 ), new TimerCallback( HandleAtrophy ) );

			Timer.DelayCall( TimeSpan.FromSeconds( 30.0 ), TimeSpan.FromSeconds( 30.0 ), new TimerCallback( ProcessTick ) );

			CommandSystem.Register( "FactionElection", AccessLevel.GameMaster, new CommandEventHandler( FactionElection_OnCommand ) );
			CommandSystem.Register( "FactionCommander", AccessLevel.Administrator, new CommandEventHandler( FactionCommander_OnCommand ) );
			CommandSystem.Register( "FactionItemReset", AccessLevel.Administrator, new CommandEventHandler( FactionItemReset_OnCommand ) );
			CommandSystem.Register( "FactionReset", AccessLevel.Administrator, new CommandEventHandler( FactionReset_OnCommand ) );
			CommandSystem.Register( "FactionTownReset", AccessLevel.Administrator, new CommandEventHandler( FactionTownReset_OnCommand ) );
		}

		public static void FactionTownReset_OnCommand( CommandEventArgs e )
		{
			List<BaseMonolith> monoliths = BaseMonolith.Monoliths;

			for ( int i = 0; i < monoliths.Count; ++i )
				monoliths[i].Sigil = null;

			List<Town> towns = Town.Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				towns[i].Silver = 0;
				towns[i].Sheriff = null;
				towns[i].Finance = null;
				towns[i].Tax = 0;
				towns[i].Owner = null;
			}

			List<Sigil> sigils = Sigil.Sigils;

			for ( int i = 0; i < sigils.Count; ++i )
			{
				sigils[i].Corrupted = null;
				sigils[i].Corrupting = null;
				sigils[i].LastStolen = DateTime.MinValue;
				sigils[i].GraceStart = DateTime.MinValue;
				sigils[i].CorruptionStart = DateTime.MinValue;
				sigils[i].PurificationStart = DateTime.MinValue;
				sigils[i].LastMonolith = null;
				sigils[i].ReturnHome();
			}

			List<Faction> factions = Faction.Factions;

			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction f = factions[i];

				List<FactionItem> list = new List<FactionItem>( f.State.FactionItems );

				for ( int j = 0; j < list.Count; ++j )
				{
					FactionItem fi = list[j];

					if ( fi.Expiration == DateTime.MinValue )
						fi.Item.Delete();
					else
						fi.Detach();
				}
			}
		}

		public static void FactionReset_OnCommand( CommandEventArgs e )
		{
			List<BaseMonolith> monoliths = BaseMonolith.Monoliths;

			for ( int i = 0; i < monoliths.Count; ++i )
				monoliths[i].Sigil = null;

			List<Town> towns = Town.Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				towns[i].Silver = 0;
				towns[i].Sheriff = null;
				towns[i].Finance = null;
				towns[i].Tax = 0;
				towns[i].Owner = null;
			}

			List<Sigil> sigils = Sigil.Sigils;

			for ( int i = 0; i < sigils.Count; ++i )
			{
				sigils[i].Corrupted = null;
				sigils[i].Corrupting = null;
				sigils[i].LastStolen = DateTime.MinValue;
				sigils[i].GraceStart = DateTime.MinValue;
				sigils[i].CorruptionStart = DateTime.MinValue;
				sigils[i].PurificationStart = DateTime.MinValue;
				sigils[i].LastMonolith = null;
				sigils[i].ReturnHome();
			}

			List<Faction> factions = Faction.Factions;

			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction f = factions[i];

				List<PlayerState> playerStateList = new List<PlayerState>( f.Members );

				for( int j = 0; j < playerStateList.Count; ++j )
					f.RemoveMember( playerStateList[j].Mobile );

				List<FactionItem> factionItemList = new List<FactionItem>( f.State.FactionItems );

				for( int j = 0; j < factionItemList.Count; ++j )
				{
					FactionItem fi = (FactionItem)factionItemList[j];

					if ( fi.Expiration == DateTime.MinValue )
						fi.Item.Delete();
					else
						fi.Detach();
				}

				List<BaseFactionTrap> factionTrapList = new List<BaseFactionTrap>( f.Traps );

				for( int j = 0; j < factionTrapList.Count; ++j )
					factionTrapList[j].Delete();
			}
		}

		public static void FactionItemReset_OnCommand( CommandEventArgs e )
		{
			ArrayList pots = new ArrayList();

			foreach ( Item item in World.Items.Values )
			{
				if ( item is IFactionItem )
					pots.Add( item );
			}

			int[] hues = new int[Factions.Count * 2];

			for ( int i = 0; i < Factions.Count; ++i )
			{
				hues[0+(i*2)] = Factions[i].Definition.HuePrimary;
				hues[1+(i*2)] = Factions[i].Definition.HueSecondary;
			}

			int count = 0;

			for ( int i = 0; i < pots.Count; ++i )
			{
				Item item = (Item)pots[i];
				IFactionItem fci = (IFactionItem)item;

				if ( fci.FactionItemState != null || item.LootType != LootType.Blessed )
					continue;

				bool isHued = false;

				for ( int j = 0; j < hues.Length; ++j )
				{
					if ( item.Hue == hues[j] )
					{
						isHued = true;
						break;
					}
				}

				if ( isHued )
				{
					fci.FactionItemState = null;
					++count;
				}
			}

			e.Mobile.SendMessage( "{0} items reset", count );
		}

		public static void FactionCommander_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Target a player to make them the faction commander." );
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( FactionCommander_OnTarget ) );
		}

		public static void FactionCommander_OnTarget( Mobile from, object obj )
		{
			if ( obj is PlayerMobile )
			{
				Mobile targ = (Mobile)obj;
				PlayerState pl = PlayerState.Find( targ );

				if ( pl != null )
				{
					pl.Faction.Commander = targ;
					from.SendMessage( "You have appointed them as the faction commander." );
				}
				else
				{
					from.SendMessage( "They are not in a faction." );
				}
			}
			else
			{
				from.SendMessage( "That is not a player." );
			}
		}

		public static void FactionElection_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Target a faction stone to open its election properties." );
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( FactionElection_OnTarget ) );
		}

		public static void FactionElection_OnTarget( Mobile from, object obj )
		{
			if ( obj is FactionStone )
			{
				Faction faction = ((FactionStone)obj).Faction;

				if ( faction != null )
					from.SendGump( new ElectionManagementGump( faction.Election ) );
					//from.SendGump( new Gumps.PropertiesGump( from, faction.Election ) );
				else
					from.SendMessage( "That stone has no faction assigned." );
			}
			else
			{
				from.SendMessage( "That is not a faction stone." );
			}
		}

		public static void FactionKick_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendMessage( "Target a player to remove them from their faction." );
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( FactionKick_OnTarget ) );
		}

		public static void FactionKick_OnTarget( Mobile from, object obj )
		{
			if ( obj is Mobile )
			{
				Mobile mob = (Mobile) obj;
				PlayerState pl = PlayerState.Find( (Mobile) mob );

				if ( pl != null )
				{
					pl.Faction.RemoveMember( mob );

					mob.SendMessage( "You have been kicked from your faction." );
					from.SendMessage( "They have been kicked from their faction." );
				}
				else
				{
					from.SendMessage( "They are not in a faction." );
				}
			}
			else
			{
				from.SendMessage( "That is not a player." );
			}
		}

		public static void ProcessTick()
		{
			List<Sigil> sigils = Sigil.Sigils;

			for ( int i = 0; i < sigils.Count; ++i )
			{
				Sigil sigil = sigils[i];

				if ( !sigil.IsBeingCorrupted && sigil.GraceStart != DateTime.MinValue && (sigil.GraceStart + Sigil.CorruptionGrace) < DateTime.Now )
				{
					if ( sigil.LastMonolith is StrongholdMonolith && ( sigil.Corrupted == null || sigil.LastMonolith.Faction != sigil.Corrupted ))
					{
						sigil.Corrupting = sigil.LastMonolith.Faction;
						sigil.CorruptionStart = DateTime.Now;
					}
					else
					{
						sigil.Corrupting = null;
						sigil.CorruptionStart = DateTime.MinValue;
					}

					sigil.GraceStart = DateTime.MinValue;
				}

				if ( sigil.LastMonolith == null || sigil.LastMonolith.Sigil == null )
				{
					if ( (sigil.LastStolen + Sigil.ReturnPeriod) < DateTime.Now )
						sigil.ReturnHome();
				}
				else
				{
					if ( sigil.IsBeingCorrupted && (sigil.CorruptionStart + Sigil.CorruptionPeriod) < DateTime.Now )
					{
						sigil.Corrupted = sigil.Corrupting;
						sigil.Corrupting = null;
						sigil.CorruptionStart = DateTime.MinValue;
						sigil.GraceStart = DateTime.MinValue;
					}
					else if ( sigil.IsPurifying && (sigil.PurificationStart + Sigil.PurificationPeriod) < DateTime.Now )
					{
						sigil.PurificationStart = DateTime.MinValue;
						sigil.Corrupted = null;
						sigil.Corrupting = null;
						sigil.CorruptionStart = DateTime.MinValue;
						sigil.GraceStart = DateTime.MinValue;
					}
				}
			}
		}

		public static void HandleDeath( Mobile mob )
		{
			HandleDeath( mob, null );
		}

		#region Skill Loss
		public const double SkillLossFactor = 1.0 / 3;
		public static readonly TimeSpan SkillLossPeriod = TimeSpan.FromMinutes( 20.0 );

		private static Dictionary<Mobile, SkillLossContext> m_SkillLoss = new Dictionary<Mobile, SkillLossContext>();

		private class SkillLossContext
		{
			public Timer m_Timer;
			public List<SkillMod> m_Mods;
		}

		public static bool InSkillLoss( Mobile mob )
		{
			return m_SkillLoss.ContainsKey( mob );
		}

		public static void ApplySkillLoss( Mobile mob )
		{
			if ( InSkillLoss( mob ) )
				return;

			SkillLossContext context = new SkillLossContext();
			m_SkillLoss[mob] = context;

			List<SkillMod> mods = context.m_Mods = new List<SkillMod>();

			for ( int i = 0; i < mob.Skills.Length; ++i )
			{
				Skill sk = mob.Skills[i];
				double baseValue = sk.Base;

				if ( baseValue > 0 )
				{
					SkillMod mod = new DefaultSkillMod( sk.SkillName, true, -(baseValue * SkillLossFactor) );

					mods.Add( mod );
					mob.AddSkillMod( mod );
				}
			}

			context.m_Timer = Timer.DelayCall( SkillLossPeriod, new TimerStateCallback( ClearSkillLoss_Callback ), mob );
		}

		private static void ClearSkillLoss_Callback( object state )
		{
			ClearSkillLoss( (Mobile) state );
		}

		public static bool ClearSkillLoss( Mobile mob )
		{
			SkillLossContext context;

			if ( !m_SkillLoss.TryGetValue( mob, out context ) )
				return false;

			m_SkillLoss.Remove( mob );

			List<SkillMod> mods = context.m_Mods;

			for ( int i = 0; i < mods.Count; ++i )
				mob.RemoveSkillMod( mods[i] );

			context.m_Timer.Stop();

			return true;
		}
		#endregion

		public int AwardSilver( Mobile mob, int silver )
		{
			if ( silver <= 0 )
				return 0;

			int tithed = ( silver * Tithe ) / 100;

			Silver += tithed;

			silver = silver - tithed;

			if ( silver > 0 )
				mob.AddToBackpack( new Silver( silver ) );

			return silver;
		}

		public virtual int MaximumTraps{ get{ return 15; } }

		public List<BaseFactionTrap> Traps
		{
			get{ return m_State.Traps; }
			set{ m_State.Traps = value; }
		}

		public const int StabilityFactor = 300; // 300% greater (3 times) than smallest faction
		public const int StabilityActivation = 200; // Stablity code goes into effect when largest faction has > 200 people

		public static Faction FindSmallestFaction()
		{
			List<Faction> factions = Factions;
			Faction smallest = null;

			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction faction = factions[i];

				if ( smallest == null || faction.Members.Count < smallest.Members.Count )
					smallest = faction;
			}

			return smallest;
		}

		public static bool StabilityActive()
		{
			List<Faction> factions = Factions;

			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction faction = factions[i];

				if ( faction.Members.Count > StabilityActivation )
					return true;
			}

			return false;
		}

		public bool CanHandleInflux( int influx )
		{
			if( !StabilityActive())
				return true;

			Faction smallest = FindSmallestFaction();

			if ( smallest == null )
				return true; // sanity

			if ( StabilityFactor > 0 && (((this.Members.Count + influx) * 100) / StabilityFactor) > smallest.Members.Count )
				return false;

			return true;
		}

		public static void HandleDeath( Mobile victim, Mobile killer )
		{
			if ( killer == null )
				killer = victim.FindMostRecentDamager( true );

			PlayerState killerState = PlayerState.Find( killer );

			Container pack = victim.Backpack;

			if ( pack != null )
			{
				Container killerPack = ( killer == null ? null : killer.Backpack );
				Item[] sigils = pack.FindItemsByType( typeof( Sigil ) );

				for ( int i = 0; i < sigils.Length; ++i )
				{
					Sigil sigil = (Sigil)sigils[i];

					if ( killerState != null && killerPack != null )
					{
						if ( killer.GetDistanceToSqrt( victim ) > 64 ) {
							sigil.ReturnHome();
							killer.SendLocalizedMessage( 1042230 ); // The sigil has gone back to its home location.
						}
						else if ( Sigil.ExistsOn( killer ) )
						{
							sigil.ReturnHome();
							killer.SendLocalizedMessage( 1010258 ); // The sigil has gone back to its home location because you already have a sigil.
						}
						else if ( !killerPack.TryDropItem( killer, sigil, false ) )
						{
							sigil.ReturnHome();
							killer.SendLocalizedMessage( 1010259 ); // The sigil has gone home because your backpack is full.
						}
					}
					else
					{
						sigil.ReturnHome();
					}
				}
			}

			if ( killerState == null )
				return;

			if ( victim is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)victim;
				Faction victimFaction = bc.FactionAllegiance;

				if ( bc.Map == Faction.Facet && victimFaction != null && killerState.Faction != victimFaction )
				{
					int silver = killerState.Faction.AwardSilver( killer, bc.FactionSilverWorth );

					if ( silver > 0 )
						killer.SendLocalizedMessage( 1042748, silver.ToString( "N0" ) ); // Thou hast earned ~1_AMOUNT~ silver for vanquishing the vile creature.
				}

				#region Ethics
				if ( bc.Map == Faction.Facet && bc.GetEthicAllegiance( killer ) == BaseCreature.Allegiance.Enemy )
				{
					Ethics.Player killerEPL = Ethics.Player.Find( killer );

					if ( killerEPL != null && ( 100 - killerEPL.Power ) > Utility.Random( 100 ) )
					{
						++killerEPL.Power;
						++killerEPL.History;
					}
				}
				#endregion

				return;
			}

			PlayerState victimState = PlayerState.Find( victim );

			if ( victimState == null )
				return;

			if ( killer == victim || killerState.Faction != victimState.Faction )
				ApplySkillLoss( victim );

			if ( killerState.Faction != victimState.Faction )
			{
				if ( victimState.KillPoints <= -6 )
				{
					killer.SendLocalizedMessage( 501693 ); // This victim is not worth enough to get kill points from.

					#region Ethics
					Ethics.Player killerEPL = Ethics.Player.Find( killer );
					Ethics.Player victimEPL = Ethics.Player.Find( victim );

					if ( killerEPL != null && victimEPL != null && victimEPL.Power > 0 && victimState.CanGiveSilverTo( killer ) )
					{
						int powerTransfer = Math.Max( 1, victimEPL.Power / 5 );

						if ( powerTransfer > ( 100 - killerEPL.Power ) )
							powerTransfer = 100 - killerEPL.Power;

						if ( powerTransfer > 0 )
						{
							victimEPL.Power -= ( powerTransfer + 1 ) / 2;
							killerEPL.Power += powerTransfer;

							killerEPL.History += powerTransfer;

							victimState.OnGivenSilverTo( killer );
						}
					}
					#endregion
				}
				else
				{
					int award = Math.Max( victimState.KillPoints / 10, 1 );

					if ( award > 40 )
						award = 40;

					if ( victimState.CanGiveSilverTo( killer ) )
					{
						if ( victimState.KillPoints > 0 )
						{
							victimState.IsActive = true;

							if ( 1 > Utility.Random( 3 ) )
								killerState.IsActive = true;

							int silver = 0;

							silver = killerState.Faction.AwardSilver( killer, award * 40 );

							if ( silver > 0 )
								killer.SendLocalizedMessage( 1042736, String.Format( "{0:N0} silver\t{1}", silver, victim.Name ) ); // You have earned ~1_SILVER_AMOUNT~ pieces for vanquishing ~2_PLAYER_NAME~!
						}

						victimState.KillPoints -= award;
						killerState.KillPoints += award;

						int offset = ( award != 1 ? 0 : 2 ); // for pluralization

						string args = String.Format( "{0}\t{1}\t{2}", award, victim.Name, killer.Name );

						killer.SendLocalizedMessage( 1042737 + offset, args ); // Thou hast been honored with ~1_KILL_POINTS~ kill point(s) for vanquishing ~2_DEAD_PLAYER~!
						victim.SendLocalizedMessage( 1042738 + offset, args ); // Thou has lost ~1_KILL_POINTS~ kill point(s) to ~3_ATTACKER_NAME~ for being vanquished!

						#region Ethics
						Ethics.Player killerEPL = Ethics.Player.Find( killer );
						Ethics.Player victimEPL = Ethics.Player.Find( victim );

						if ( killerEPL != null && victimEPL != null && victimEPL.Power > 0 )
						{
							int powerTransfer = Math.Max( 1, victimEPL.Power / 5 );

							if ( powerTransfer > ( 100 - killerEPL.Power ) )
								powerTransfer = 100 - killerEPL.Power;

							if ( powerTransfer > 0 )
							{
								victimEPL.Power -= ( powerTransfer + 1 ) / 2;
								killerEPL.Power += powerTransfer;

								killerEPL.History += powerTransfer;
							}
						}
						#endregion

						victimState.OnGivenSilverTo( killer );
					}
					else
					{
						killer.SendLocalizedMessage( 1042231 ); // You have recently defeated this enemy and thus their death brings you no honor.
					}
				}
			}
		}

		private static void EventSink_Logout( LogoutEventArgs e )
		{
			Mobile mob = e.Mobile;

			Container pack = mob.Backpack;

			if ( pack == null )
				return;

			Item[] sigils = pack.FindItemsByType( typeof( Sigil ) );

			for ( int i = 0; i < sigils.Length; ++i )
				((Sigil)sigils[i]).ReturnHome();
		}

		private static void EventSink_Login( LoginEventArgs e )
		{
			Mobile mob = e.Mobile;

			CheckLeaveTimer( mob );
		}

		public static readonly Map Facet = Map.Lodor;

		public static void WriteReference( GenericWriter writer, Faction fact )
		{
			int idx = Factions.IndexOf( fact );

			writer.WriteEncodedInt( (int) (idx + 1) );
		}

		public static List<Faction> Factions{ get{ return Reflector.Factions; } }

		public static Faction ReadReference( GenericReader reader )
		{
			int idx = reader.ReadEncodedInt() - 1;

			if ( idx >= 0 && idx < Factions.Count )
				return Factions[idx];

			return null;
		}

		public static Faction Find( Mobile mob )
		{
			return Find( mob, false, false );
		}

		public static Faction Find( Mobile mob, bool inherit )
		{
			return Find( mob, inherit, false );
		}

		public static Faction Find( Mobile mob, bool inherit, bool creatureAllegiances )
		{
			PlayerState pl = PlayerState.Find( mob );

			if ( pl != null )
				return pl.Faction;

			if ( inherit && mob is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)mob;

				if ( bc.Controlled )
					return Find( bc.ControlMaster, false );
				else if ( bc.Summoned )
					return Find( bc.SummonMaster, false );
				else if ( creatureAllegiances && mob is BaseFactionGuard )
					return ((BaseFactionGuard)mob).Faction;
				else if ( creatureAllegiances )
					return bc.FactionAllegiance;
			}

			return null;
		}

		public static Faction Parse( string name )
		{
			List<Faction> factions = Factions;

			for ( int i = 0; i < factions.Count; ++i )
			{
				Faction faction = factions[i];

				if ( Insensitive.Equals( faction.Definition.FriendlyName, name ) )
					return faction;
			}

			return null;
		}
	}

	public enum FactionKickType
	{
		Kick,
		Ban,
		Unban
	}

	public class FactionKickCommand : BaseCommand
	{
		private FactionKickType m_KickType;

		public FactionKickCommand( FactionKickType kickType )
		{
			m_KickType = kickType;

			AccessLevel = AccessLevel.GameMaster;
			Supports = CommandSupport.AllMobiles;
			ObjectTypes = ObjectTypes.Mobiles;

			switch ( m_KickType )
			{
				case FactionKickType.Kick:
				{
					Commands = new string[]{ "FactionKick" };
					Usage = "FactionKick";
					Description = "Kicks the targeted player out of his current faction. This does not prevent them from rejoining.";
					break;
				}
				case FactionKickType.Ban:
				{
					Commands = new string[]{ "FactionBan" };
					Usage = "FactionBan";
					Description = "Bans the account of a targeted player from joining factions. All players on the account are removed from their current faction, if any.";
					break;
				}
				case FactionKickType.Unban:
				{
					Commands = new string[]{ "FactionUnban" };
					Usage = "FactionUnban";
					Description = "Unbans the account of a targeted player from joining factions.";
					break;
				}
			}
		}

		public override void Execute( CommandEventArgs e, object obj )
		{
			Mobile mob = (Mobile)obj;

			switch ( m_KickType )
			{
				case FactionKickType.Kick:
				{
					PlayerState pl = PlayerState.Find( mob );

					if ( pl != null )
					{
						pl.Faction.RemoveMember( mob );
						mob.SendMessage( "You have been kicked from your faction." );
						AddResponse( "They have been kicked from their faction." );
					}
					else
					{
						LogFailure( "They are not in a faction." );
					}

					break;
				}
				case FactionKickType.Ban:
				{
					Account acct = mob.Account as Account;

					if ( acct != null )
					{
						if ( acct.GetTag( "FactionBanned" ) == null )
						{
							acct.SetTag( "FactionBanned", "true" );
							AddResponse( "The account has been banned from joining factions." );
						}
						else
						{
							AddResponse( "The account is already banned from joining factions." );
						}

						for ( int i = 0; i < acct.Length; ++i )
						{
							mob = acct[i];

							if ( mob != null )
							{
								PlayerState pl = PlayerState.Find( mob );

								if ( pl != null )
								{
									pl.Faction.RemoveMember( mob );
									mob.SendMessage( "You have been kicked from your faction." );
									AddResponse( "They have been kicked from their faction." );
								}
							}
						}
					}
					else
					{
						LogFailure( "They have no assigned account." );
					}

					break;
				}
				case FactionKickType.Unban:
				{
					Account acct = mob.Account as Account;

					if ( acct != null )
					{
						if ( acct.GetTag( "FactionBanned" ) == null )
						{
							AddResponse( "The account is not already banned from joining factions." );
						}
						else
						{
							acct.RemoveTag( "FactionBanned" );
							AddResponse( "The account may now freely join factions." );
						}
					}
					else
					{
						LogFailure( "They have no assigned account." );
					}

					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionBerserker : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionBerserker() : base( "the berserker" )
		{
			GenerateBody( false, false );

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.Swords, 100.0, 110.0 );
			SetSkill( SkillName.FistFighting, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.Psychology, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );

			AddItem( Immovable( Rehued( new BodySash(), 1645 ) ) );
			AddItem( Immovable( Rehued( new Kilt(), 1645 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1645 ) ) );
			AddItem( Newbied( new DoubleAxe() ) );

			HairItemID = 0x2047; // Afro
			HairHue = 0x29;

			FacialHairItemID = 0x204B; // Medium Short Beard
			FacialHairHue = 0x29;

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionBerserker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionBoardVendor : BaseFactionVendor
	{
		public FactionBoardVendor( Town town, Faction faction ) : base( town, faction, "the LumberMan" ) // NOTE: title inconsistant, as OSI
		{
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionBoard() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new HalfApron() );
		}

		public FactionBoardVendor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SBFactionBoard : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFactionBoard()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 5; ++i )
					Add( new GenericBuyInfo( typeof( Board ), 3, 20, 0x1BD7, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionBottleVendor : BaseFactionVendor
	{
		public FactionBottleVendor( Town town, Faction faction ) : base( town, faction, "the Bottle Seller" )
		{
			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.Tasting, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionBottle() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Robe( Utility.RandomPinkHue() ) );
		}

		public FactionBottleVendor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SBFactionBottle : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFactionBottle()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 5; ++i )
					Add( new GenericBuyInfo( typeof( Bottle ), 5, 20, 0xF0E, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionDeathKnight : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionDeathKnight() : base( "the death knight" )
		{
			GenerateBody( false, false );
			Hue = 1;

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.Swords, 100.0, 110.0 );
			SetSkill( SkillName.FistFighting, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.Psychology, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );

			Item shroud = new Item( 0x204E );
			shroud.Layer = Layer.OuterTorso;

			AddItem( Immovable( Rehued( shroud, 1109 ) ) );
			AddItem( Newbied( Rehued( new ExecutionersAxe(), 2211 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionDeathKnight( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class FactionDefinition
	{
		private int m_Sort;

		private int m_HuePrimary;
		private int m_HueSecondary;
		private int m_HueJoin;
		private int m_HueBroadcast;

		private int m_WarHorseBody;
		private int m_WarHorseItem;

		private string m_FriendlyName;
		private string m_Keyword;
		private string m_Abbreviation;

		private TextDefinition m_Name;
		private TextDefinition m_PropName;
		private TextDefinition m_Header;
		private TextDefinition m_About;
		private TextDefinition m_CityControl;
		private TextDefinition m_SigilControl;
		private TextDefinition m_SignupName;
		private TextDefinition m_FactionStoneName;
		private TextDefinition m_OwnerLabel;

		private TextDefinition m_GuardIgnore, m_GuardWarn, m_GuardAttack;

		private StrongholdDefinition m_Stronghold;

		private RankDefinition[] m_Ranks;
		private GuardDefinition[] m_Guards;

		public int Sort{ get{ return m_Sort; } }

		public int HuePrimary{ get{ return m_HuePrimary; } }
		public int HueSecondary{ get{ return m_HueSecondary; } }
		public int HueJoin{ get{ return m_HueJoin; } }
		public int HueBroadcast{ get{ return m_HueBroadcast; } }

		public int WarHorseBody{ get{ return m_WarHorseBody; } }
		public int WarHorseItem{ get{ return m_WarHorseItem; } }

		public string FriendlyName{ get{ return m_FriendlyName; } }
		public string Keyword{ get{ return m_Keyword; } }
		public string Abbreviation{ get { return m_Abbreviation; } }

		public TextDefinition Name{ get{ return m_Name; } }
		public TextDefinition PropName{ get{ return m_PropName; } }
		public TextDefinition Header{ get{ return m_Header; } }
		public TextDefinition About{ get{ return m_About; } }
		public TextDefinition CityControl{ get{ return m_CityControl; } }
		public TextDefinition SigilControl{ get{ return m_SigilControl; } }
		public TextDefinition SignupName{ get{ return m_SignupName; } }
		public TextDefinition FactionStoneName{ get{ return m_FactionStoneName; } }
		public TextDefinition OwnerLabel{ get{ return m_OwnerLabel; } }

		public TextDefinition GuardIgnore{ get{ return m_GuardIgnore; } }
		public TextDefinition GuardWarn{ get{ return m_GuardWarn; } }
		public TextDefinition GuardAttack{ get{ return m_GuardAttack; } }

		public StrongholdDefinition Stronghold{ get{ return m_Stronghold; } }

		public RankDefinition[] Ranks{ get{ return m_Ranks; } }
		public GuardDefinition[] Guards{ get{ return m_Guards; } }

		public FactionDefinition( int sort, int huePrimary, int hueSecondary, int hueJoin, int hueBroadcast, int warHorseBody, int warHorseItem, string friendlyName, string keyword, string abbreviation, TextDefinition name, TextDefinition propName, TextDefinition header, TextDefinition about, TextDefinition cityControl, TextDefinition sigilControl, TextDefinition signupName, TextDefinition factionStoneName, TextDefinition ownerLabel, TextDefinition guardIgnore, TextDefinition guardWarn, TextDefinition guardAttack, StrongholdDefinition stronghold, RankDefinition[] ranks, GuardDefinition[] guards )
		{
			m_Sort = sort;
			m_HuePrimary = huePrimary;
			m_HueSecondary = hueSecondary;
			m_HueJoin = hueJoin;
			m_HueBroadcast = hueBroadcast;
			m_WarHorseBody = warHorseBody;
			m_WarHorseItem = warHorseItem;
			m_FriendlyName = friendlyName;
			m_Keyword = keyword;
			m_Abbreviation = abbreviation;
			m_Name = name;
			m_PropName = propName;
			m_Header = header;
			m_About = about;
			m_CityControl = cityControl;
			m_SigilControl = sigilControl;
			m_SignupName = signupName;
			m_FactionStoneName = factionStoneName;
			m_OwnerLabel = ownerLabel;
			m_GuardIgnore = guardIgnore;
			m_GuardWarn = guardWarn;
			m_GuardAttack = guardAttack;
			m_Stronghold = stronghold;
			m_Ranks = ranks;
			m_Guards = guards;
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionDragoon : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }

		[Constructable]
		public FactionDragoon() : base( "the dragoon" )
		{
			GenerateBody( false, false );

			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 151, 175 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );

			VirtualArmor = 32;

			SetSkill( SkillName.Bludgeoning, 110.0, 120.0 );
			SetSkill( SkillName.FistFighting, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );

			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.Psychology, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );

			AddItem( Immovable( Rehued( new Cloak(), 1645 ) ) );

			AddItem( Immovable( Rehued( new PlateChest(), 1645 ) ) );
			AddItem( Immovable( Rehued( new PlateLegs(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateGorget(), 1109 ) ) );
			AddItem( Immovable( Rehued( new PlateHelm(), 1109 ) ) );

			AddItem( Newbied( new WarHammer() ) );

			AddItem( Immovable( Rehued( new VirtualMountItem( this ), 1109 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionDragoon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class FactionExplosionTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044599; } } // faction explosion trap

		public override int AttackMessage{ get{ return 1010543; } } // You are enveloped in an explosion of fire!
		public override int DisarmMessage{ get{ return 1010539; } } // You carefully remove the pressure trigger and disable the trap.
		public override int EffectSound{ get{ return 0x307; } }
		public override int MessageHue{ get{ return 0x78; } }

		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.AnyFactionTown; } }

		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( GetWorldLocation(), Map, 0x36BD, 15, 10 );
		}

		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}

		[Constructable]
		public FactionExplosionTrap() : this( null )
		{
		}

		public FactionExplosionTrap( Faction f ) : this( f, null )
		{
		}

		public FactionExplosionTrap( Faction f, Mobile m ) : base( f, m, 0x11C1 )
		{
		}

		public FactionExplosionTrap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FactionExplosionTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionExplosionTrap ); } }
		public override int LabelNumber{ get{ return 1044603; } } // faction explosion trap deed

		public FactionExplosionTrapDeed() : base( 0x36D2 )
		{
		}

		public FactionExplosionTrapDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class FactionGasTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044598; } } // faction gas trap

		public override int AttackMessage{ get{ return 1010542; } } // A noxious green cloud of poison gas envelops you!
		public override int DisarmMessage{ get{ return 502376; } } // The poison leaks harmlessly away due to your deft touch.
		public override int EffectSound{ get{ return 0x230; } }
		public override int MessageHue{ get{ return 0x44; } }

		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.FactionStronghold; } }

		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x3709, 28, 10, 0x1D3, 5 );
		}

		public override void DoAttackEffect( Mobile m )
		{
			m.ApplyPoison( m, Poison.Lethal );
		}

		[Constructable]
		public FactionGasTrap() : this( null )
		{
		}

		public FactionGasTrap( Faction f ) : this( f, null )
		{
		}

		public FactionGasTrap( Faction f, Mobile m ) : base( f, m, 0x113C )
		{
		}

		public FactionGasTrap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FactionGasTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionGasTrap ); } }
		public override int LabelNumber{ get{ return 1044602; } } // faction gas trap deed

		public FactionGasTrapDeed() : base( 0x11AB )
		{
		}

		public FactionGasTrapDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server.Factions
{
	public abstract class FactionGump : Gump
	{
		public virtual int ButtonTypes{ get{ return 10; } }

		public int ToButtonID( int type, int index )
		{
			return 1 + (index * ButtonTypes) + type;
		}

		public bool FromButtonID( int buttonID, out int type, out int index )
		{
			int offset = buttonID - 1;

			if ( offset >= 0 )
			{
				type = offset % ButtonTypes;
				index = offset / ButtonTypes;
				return true;
			}
			else
			{
				type = index = 0;
				return false;
			}
		}

		public static bool Exists( Mobile mob )
		{
			return ( mob.FindGump( typeof( FactionGump ) ) != null );
		}

		public void AddHtmlText( int x, int y, int width, int height, TextDefinition text, bool back, bool scroll )
		{
			if ( text != null && text.Number > 0 )
				AddHtmlLocalized( x, y, width, height, text.Number, back, scroll );
			else if ( text != null && text.String != null )
				AddHtml( x, y, width, height, text.String, back, scroll );
		}

		public FactionGump( int x, int y ) : base( x, y )
		{
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionHenchman : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee; } }

		[Constructable]
		public FactionHenchman() : base( "the henchman" )
		{
			GenerateBody( false, true );

			SetStr( 91, 115 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamage( 10, 14 );

			SetResistance( ResistanceType.Physical, 10, 30 );
			SetResistance( ResistanceType.Fire, 10, 30 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Energy, 10, 30 );
			SetResistance( ResistanceType.Poison, 10, 30 );

			VirtualArmor = 8;

			SetSkill( SkillName.Fencing, 80.0, 90.0 );
			SetSkill( SkillName.FistFighting, 80.0, 90.0 );
			SetSkill( SkillName.Tactics, 80.0, 90.0 );
			SetSkill( SkillName.MagicResist, 80.0, 90.0 );
			SetSkill( SkillName.Healing, 80.0, 90.0 );
			SetSkill( SkillName.Anatomy, 80.0, 90.0 );

			AddItem( new StuddedChest() );
			AddItem( new StuddedLegs() );
			AddItem( new StuddedArms() );
			AddItem( new StuddedGloves() );
			AddItem( new StuddedGorget() );
			AddItem( new Boots() );
			AddItem( Newbied( new Spear() ) );

			PackItem( new Bandage( Utility.RandomMinMax( 10, 20 ) ) );
			PackWeakPotions( 1, 4 );
		}

		public FactionHenchman( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Network;// using System.Collections.Generic;

namespace Server.Factions
{
	public class FactionHorseVendor : BaseFactionVendor
	{
		public FactionHorseVendor( Town town, Faction faction ) : base( town, faction, "the Horse Breeder" )
		{
			SetSkill( SkillName.Druidism, 64.0, 100.0 );
			SetSkill( SkillName.Taming, 90.0, 100.0 );
			SetSkill( SkillName.Veterinary, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
		}

		public override VendorShoeType ShoeType
		{
			get{ return Female ? VendorShoeType.ThighBoots : VendorShoeType.Boots; }
		}

		public override int GetShoeHue()
		{
			return 0;
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( Utility.RandomBool() ? (Item)new QuarterStaff() : (Item)new ShepherdsCrook() );
		}

		public FactionHorseVendor( Serial serial ) : base( serial )
		{
		}

		public override void VendorBuy( Mobile from )
		{
			if ( this.Faction == null || Faction.Find( from, true ) != this.Faction )
				PrivateOverheadMessage( MessageType.Regular, 0x3B2, 1042201, from.NetState ); // You are not in my faction, I cannot sell you a horse!
			else if ( FactionGump.Exists( from ) )
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			else if ( from is PlayerMobile )
				from.SendGump( new HorseBreederGump( (PlayerMobile) from, this.Faction ) );
		}

		public override void VendorSell( Mobile from )
		{
		}

        public override bool OnBuyItems( Mobile buyer, List<BuyItemResponse> list )
		{
			return false;
		}

        public override bool OnSellItems( Mobile seller, List<SellItemResponse> list )
		{
			return false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Engines.Craft;

namespace Server.Factions
{
	public class FactionImbueGump : FactionGump
	{
		private Item m_Item;
		private Mobile m_Mobile;
		private Faction m_Faction;
		private CraftSystem m_CraftSystem;
		private BaseTool m_Tool;
		private object m_Notice;
		private int m_Quality;

		private FactionItemDefinition m_Definition;

		public FactionImbueGump( int quality, Item item, Mobile from, CraftSystem craftSystem, BaseTool tool, object notice, int availableSilver, Faction faction, FactionItemDefinition def ) : base( 100, 200 )
		{
			m_Item = item;
			m_Mobile = from;
			m_Faction = faction;
			m_CraftSystem = craftSystem;
			m_Tool = tool;
			m_Notice = notice;
			m_Quality = quality;
			m_Definition = def;

			AddPage( 0 );

			AddBackground( 0, 0, 320, 270, 5054 );
			AddBackground( 10, 10, 300, 250, 3000 );

			AddHtmlLocalized( 20, 20, 210, 25, 1011569, false, false ); // Imbue with Faction properties?

			AddHtmlLocalized( 20, 60, 170, 25, 1018302, false, false ); // Item quality:
			AddHtmlLocalized( 175, 60, 100, 25, 1018305 - m_Quality, false, false ); //	Exceptional, Average, Low

			AddHtmlLocalized( 20, 80, 170, 25, 1011572, false, false ); // Item Cost :
			AddLabel( 175, 80, 0x34, def.SilverCost.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 100, 170, 25, 1011573, false, false ); // Your Silver :
			AddLabel( 175, 100, 0x34, availableSilver.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddRadio( 20, 140, 210, 211, true, 1 );
			AddLabel( 55, 140, m_Faction.Definition.HuePrimary - 1, "*****" );
			AddHtmlLocalized( 150, 140, 150, 25, 1011570, false, false ); // Primary Color

			AddRadio( 20, 160, 210, 211, false, 2 );
			AddLabel( 55, 160, m_Faction.Definition.HueSecondary - 1, "*****" );
			AddHtmlLocalized( 150, 160, 150, 25, 1011571, false, false ); // Secondary Color

			AddHtmlLocalized( 55, 200, 200, 25, 1011011, false, false ); // CONTINUE
			AddButton( 20, 200, 4005, 4007, 1, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 230, 200, 25, 1011012, false, false ); // CANCEL
			AddButton( 20, 230, 4005, 4007, 0, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
			{
				Container pack = m_Mobile.Backpack;

				if ( pack != null && m_Item.IsChildOf( pack ) )
				{
					if ( pack.ConsumeTotal( typeof( Silver ), m_Definition.SilverCost ) )
					{
						int hue;

						if ( m_Item is SpellScroll )
							hue = 0;
						else if ( info.IsSwitched( 1 ) )
							hue = m_Faction.Definition.HuePrimary;
						else
							hue = m_Faction.Definition.HueSecondary;

						FactionItem.Imbue( m_Item, m_Faction, true, hue );
					}
					else
					{
						m_Mobile.SendLocalizedMessage( 1042204 ); // You do not have enough silver.
					}
				}
			}

			if ( m_Tool != null && !m_Tool.Deleted && m_Tool.UsesRemaining > 0 )
				m_Mobile.SendGump( new CraftGump( m_Mobile, m_CraftSystem, m_Tool, m_Notice ) );
			else if ( m_Notice is string )
				m_Mobile.SendMessage( (string) m_Notice );
			else if ( m_Notice is int && ((int)m_Notice) > 0 )
				m_Mobile.SendLocalizedMessage( (int) m_Notice );
		}
	}
}
// using System;

namespace Server.Factions
{
	public interface IFactionItem
	{
		FactionItem FactionItemState{ get; set; }
	}

	public class FactionItem
	{
		public static readonly TimeSpan ExpirationPeriod = TimeSpan.FromDays( 21.0 );

		private Item m_Item;
		private Faction m_Faction;
		private DateTime m_Expiration;

		public Item Item{ get{ return m_Item; } }
		public Faction Faction{ get{ return m_Faction; } }
		public DateTime Expiration{ get{ return m_Expiration; } }

		public bool HasExpired
		{
			get
			{
				if ( m_Item == null || m_Item.Deleted )
					return true;

				return ( m_Expiration != DateTime.MinValue && DateTime.Now >= m_Expiration );
			}
		}

		public void StartExpiration()
		{
			m_Expiration = DateTime.Now + ExpirationPeriod;
		}

		public void CheckAttach()
		{
			if ( !HasExpired )
				Attach();
			else
				Detach();
		}

		public void Attach()
		{
			if ( m_Item is IFactionItem )
				((IFactionItem)m_Item).FactionItemState = this;

			if ( m_Faction != null )
				m_Faction.State.FactionItems.Add( this );
		}

		public void Detach()
		{
			if ( m_Item is IFactionItem )
				((IFactionItem)m_Item).FactionItemState = null;

			if ( m_Faction != null && m_Faction.State.FactionItems.Contains( this ) )
				m_Faction.State.FactionItems.Remove( this );
		}

		public FactionItem( Item item, Faction faction )
		{
			m_Item = item;
			m_Faction = faction;
		}

		public FactionItem( GenericReader reader, Faction faction )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					m_Item = reader.ReadItem();
					m_Expiration = reader.ReadDateTime();
					break;
				}
			}

			m_Faction = faction;
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 );

			writer.Write( (Item) m_Item );
			writer.Write( (DateTime) m_Expiration );
		}

		public static int GetMaxWearables( Mobile mob )
		{
			PlayerState pl = PlayerState.Find( mob );

			if ( pl == null )
				return 0;

			if ( pl.Faction.IsCommander( mob ) )
				return 9;

			return pl.Rank.MaxWearables;
		}

		public static FactionItem Find( Item item )
		{
			if ( item is IFactionItem )
			{
				FactionItem state = ((IFactionItem)item).FactionItemState;

				if ( state != null && state.HasExpired )
				{
					state.Detach();
					state = null;
				}

				return state;
			}

			return null;
		}

		public static Item Imbue( Item item, Faction faction, bool expire, int hue )
		{
			if ( !(item is IFactionItem) )
				return item;

			FactionItem state = Find( item );

			if ( state == null )
			{
				state = new FactionItem( item, faction );
				state.Attach();
			}

			if ( expire )
				state.StartExpiration();

			item.Hue = hue;
			return item;
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionItemDefinition
	{
		private int m_SilverCost;
		private Type m_VendorType;

		public int SilverCost{ get{ return m_SilverCost; } }
		public Type VendorType{ get{ return m_VendorType; } }

		public FactionItemDefinition( int silverCost, Type vendorType )
		{
			m_SilverCost = silverCost;
			m_VendorType = vendorType;
		}

		private static FactionItemDefinition m_MetalArmor	= new FactionItemDefinition( 1000, typeof( Blacksmith ) );
		private static FactionItemDefinition m_Weapon		= new FactionItemDefinition( 1000, typeof( Blacksmith ) );
		private static FactionItemDefinition m_RangedWeapon	= new FactionItemDefinition( 1000, typeof( Bowyer ) );
		private static FactionItemDefinition m_LeatherArmor	= new FactionItemDefinition(  750, typeof( Tailor ) );
		private static FactionItemDefinition m_Clothing		= new FactionItemDefinition(  200, typeof( Tailor ) );
		private static FactionItemDefinition m_Scroll		= new FactionItemDefinition(  500, typeof( Mage ) );

		public static FactionItemDefinition Identify( Item item )
		{
			if ( item is BaseArmor )
			{
				if ( CraftResources.GetType( ((BaseArmor)item).Resource ) == CraftResourceType.Leather )
					return m_LeatherArmor;

				return m_MetalArmor;
			}

			if ( item is BaseRanged )
				return m_RangedWeapon;
			else if ( item is BaseWeapon )
				return m_Weapon;
			else if ( item is BaseClothing )
				return m_Clothing;
			else if ( item is SpellScroll )
				return m_Scroll;

			return null;
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionKnight : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionKnight() : base( "the knight" )
		{
			GenerateBody( false, false );

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.Swords, 100.0, 110.0 );
			SetSkill( SkillName.FistFighting, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.Psychology, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );

			AddItem( Immovable( Rehued( new ChainChest(), 2125 ) ) );
			AddItem( Immovable( Rehued( new ChainLegs(), 2125 ) ) );
			AddItem( Immovable( Rehued( new ChainCoif(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 2125 ) ) );

			AddItem( Immovable( Rehued( new BodySash(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Kilt(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1254 ) ) );

			AddItem( Newbied( new Bardiche() ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionKnight( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionMercenary : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Melee | GuardAI.Smart; } }

		[Constructable]
		public FactionMercenary() : base( "the mercenary" )
		{
			GenerateBody( false, true );

			SetStr( 116, 125 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetResistance( ResistanceType.Physical, 20, 40 );
			SetResistance( ResistanceType.Fire, 20, 40 );
			SetResistance( ResistanceType.Cold, 20, 40 );
			SetResistance( ResistanceType.Energy, 20, 40 );
			SetResistance( ResistanceType.Poison, 20, 40 );

			VirtualArmor = 16;

			SetSkill( SkillName.Fencing, 90.0, 100.0 );
			SetSkill( SkillName.FistFighting, 90.0, 100.0 );
			SetSkill( SkillName.Tactics, 90.0, 100.0 );
			SetSkill( SkillName.MagicResist, 90.0, 100.0 );
			SetSkill( SkillName.Healing, 90.0, 100.0 );
			SetSkill( SkillName.Anatomy, 90.0, 100.0 );

			AddItem( new ChainChest() );
			AddItem( new ChainLegs() );
			AddItem( new RingmailArms() );
			AddItem( new RingmailGloves() );
			AddItem( new ChainCoif() );
			AddItem( new Boots() );
			AddItem( Newbied( new ShortSpear() ) );

			PackItem( new Bandage( Utility.RandomMinMax( 20, 30 ) ) );
			PackStrongPotions( 3, 8 );
		}

		public FactionMercenary( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionNecromancer : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }

		[Constructable]
		public FactionNecromancer() : base( "the necromancer" )
		{
			GenerateBody( false, false );
			Hue = 1;

			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 151, 175 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );

			VirtualArmor = 32;

			SetSkill( SkillName.Bludgeoning, 110.0, 120.0 );
			SetSkill( SkillName.FistFighting, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );

			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.Psychology, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );

			Item shroud = new Item( 0x204E );
			shroud.Layer = Layer.OuterTorso;

			AddItem( Immovable( Rehued( shroud, 1109 ) ) );
			AddItem( Newbied( Rehued( new GnarledStaff(), 2211 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionNecromancer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionOreVendor : BaseFactionVendor
	{
		public FactionOreVendor( Town town, Faction faction ) : base( town, faction, "the Ore Man" )
		{
			// NOTE: Skills verified
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Lumberjacking, 60.0, 83.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionOre() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new HalfApron() );
		}

		public FactionOreVendor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SBFactionOre : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFactionOre()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 5; ++i )
					Add( new GenericBuyInfo( typeof( IronOre ), 16, 20, 0x19B8, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionPaladin : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Melee | GuardAI.Smart | GuardAI.Curse | GuardAI.Bless; } }

		[Constructable]
		public FactionPaladin() : base( "the paladin" )
		{
			GenerateBody( false, false );

			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 81, 95 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );

			VirtualArmor = 32;

			SetSkill( SkillName.Swords, 110.0, 120.0 );
			SetSkill( SkillName.FistFighting, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );

			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.Psychology, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );

			AddItem( Immovable( Rehued( new PlateChest(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateLegs(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateHelm(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGorget(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateArms(), 2125 ) ) );
			AddItem( Immovable( Rehued( new PlateGloves(), 2125 ) ) );

			AddItem( Immovable( Rehued( new BodySash(), 1254 ) ) );
			AddItem( Immovable( Rehued( new Cloak(), 1254 ) ) );

			AddItem( Newbied( new Halberd() ) );

			AddItem( Immovable( Rehued( new VirtualMountItem( this ), 1254 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionPaladin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;

namespace Server.Factions
{
	public class FactionReagentVendor : BaseFactionVendor
	{
		public FactionReagentVendor( Town town, Faction faction ) : base( town, faction, "the Reagent Man" )
		{
			SetSkill( SkillName.Psychology, 65.0, 88.0 );
			SetSkill( SkillName.Inscribe, 60.0, 83.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.FistFighting, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBFactionReagent() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Robe( Utility.RandomBlueHue() ) );
			AddItem( new GnarledStaff() );
		}

		public FactionReagentVendor( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class SBFactionReagent : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFactionReagent()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				for ( int i = 0; i < 2; ++i )
				{
					Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 20, 0xF7A, 0 ) );
					Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 20, 0xF7B, 0 ) );
					Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 20, 0xF86, 0 ) );
					Add( new GenericBuyInfo( typeof( Garlic ), 3, 20, 0xF84, 0 ) );
					Add( new GenericBuyInfo( typeof( Ginseng ), 3, 20, 0xF85, 0 ) );
					Add( new GenericBuyInfo( typeof( Nightshade ), 3, 20, 0xF88, 0 ) );
					Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 20, 0xF8D, 0 ) );
					Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 20, 0xF8C, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class FactionSawTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1041047; } } // faction saw trap

		public override int AttackMessage{ get{ return 1010544; } } // The blade cuts deep into your skin!
		public override int DisarmMessage{ get{ return 1010540; } } // You carefully dismantle the saw mechanism and disable the trap.
		public override int EffectSound{ get{ return 0x218; } }
		public override int MessageHue{ get{ return 0x5A; } }

		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.ControlledFactionTown; } }

		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x11AD, 25, 10 );
		}

		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}

		[Constructable]
		public FactionSawTrap() : this( null )
		{
		}

		public FactionSawTrap( Serial serial ) : base( serial )
		{
		}

		public FactionSawTrap( Faction f ) : this( f, null )
		{
		}

		public FactionSawTrap( Faction f, Mobile m ) : base( f, m, 0x11AC )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FactionSawTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionSawTrap ); } }
		public override int LabelNumber{ get{ return 1044604; } } // faction saw trap deed

		public FactionSawTrapDeed() : base( 0x1107 )
		{
		}

		public FactionSawTrapDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionSorceress : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Bless | GuardAI.Curse; } }

		[Constructable]
		public FactionSorceress() : base( "the sorceress" )
		{
			GenerateBody( true, false );

			SetStr( 126, 150 );
			SetDex( 61, 85 );
			SetInt( 126, 150 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 50 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 30, 50 );
			SetResistance( ResistanceType.Energy, 30, 50 );
			SetResistance( ResistanceType.Poison, 30, 50 );

			VirtualArmor = 24;

			SetSkill( SkillName.Bludgeoning, 100.0, 110.0 );
			SetSkill( SkillName.FistFighting, 100.0, 110.0 );
			SetSkill( SkillName.Tactics, 100.0, 110.0 );
			SetSkill( SkillName.MagicResist, 100.0, 110.0 );
			SetSkill( SkillName.Healing, 100.0, 110.0 );
			SetSkill( SkillName.Anatomy, 100.0, 110.0 );

			SetSkill( SkillName.Magery, 100.0, 110.0 );
			SetSkill( SkillName.Psychology, 100.0, 110.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );

			AddItem( Immovable( Rehued( new WizardsHat(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherGorget(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherGloves(), 1325 ) ) );
			AddItem( Immovable( Rehued( new LeatherLegs(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Skirt(), 1325 ) ) );
			AddItem( Immovable( Rehued( new FemaleLeatherChest(), 1325 ) ) );
			AddItem( Newbied( Rehued( new QuarterStaff(), 1310 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionSorceress( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class FactionSpikeTrap : BaseFactionTrap
	{
		public override int LabelNumber{ get{ return 1044601; } } // faction spike trap

		public override int AttackMessage{ get{ return 1010545; } } // Large spikes in the ground spring up piercing your skin!
		public override int DisarmMessage{ get{ return 1010541; } } // You carefully dismantle the trigger on the spikes and disable the trap.
		public override int EffectSound{ get{ return 0x22E; } }
		public override int MessageHue{ get{ return 0x5A; } }

		public override AllowedPlacing AllowedPlacing{ get{ return AllowedPlacing.ControlledFactionTown; } }

		public override void DoVisibleEffect()
		{
			Effects.SendLocationEffect( this.Location, this.Map, 0x11A4, 12, 6 );
		}

		public override void DoAttackEffect( Mobile m )
		{
			m.Damage( Utility.Dice( 6, 10, 40 ), m );
		}

		[Constructable]
		public FactionSpikeTrap() : this( null )
		{
		}

		public FactionSpikeTrap( Faction f ) : this( f, null )
		{
		}

		public FactionSpikeTrap( Faction f, Mobile m ) : base( f, m, 0x11A0 )
		{
		}

		public FactionSpikeTrap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FactionSpikeTrapDeed : BaseFactionTrapDeed
	{
		public override Type TrapType{ get{ return typeof( FactionSpikeTrap ); } }
		public override int LabelNumber{ get{ return 1044605; } } // faction spike trap deed

		public FactionSpikeTrapDeed() : base( 0x11A5 )
		{
		}

		public FactionSpikeTrapDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;

namespace Server.Factions
{
	public class FactionState
	{
		private Faction m_Faction;
		private Mobile m_Commander;
		private int m_Tithe;
		private int m_Silver;
		private List<PlayerState> m_Members;
		private Election m_Election;
		private List<FactionItem> m_FactionItems;
		private List<BaseFactionTrap> m_FactionTraps;
		private DateTime m_LastAtrophy;

		private const int BroadcastsPerPeriod = 2;
		private static readonly TimeSpan BroadcastPeriod = TimeSpan.FromHours( 1.0 );

		private DateTime[] m_LastBroadcasts = new DateTime[BroadcastsPerPeriod];

		public DateTime LastAtrophy{ get{ return m_LastAtrophy; } set{ m_LastAtrophy = value; } }

		public bool FactionMessageReady
		{
			get
			{
				for ( int i = 0; i < m_LastBroadcasts.Length; ++i )
				{
					if ( DateTime.Now >= (m_LastBroadcasts[i] + BroadcastPeriod) )
						return true;
				}

				return false;
			}
		}

		public bool IsAtrophyReady{ get{ return DateTime.Now >= (m_LastAtrophy + TimeSpan.FromHours( 47.0 )); } }

		public int CheckAtrophy()
		{
			if ( DateTime.Now < (m_LastAtrophy + TimeSpan.FromHours( 47.0 )) )
				return 0;

			int distrib = 0;
			m_LastAtrophy = DateTime.Now;

			List<PlayerState> members = new List<PlayerState>( m_Members );

			for ( int i = 0; i < members.Count; ++i )
			{
				PlayerState ps = members[i];

				if ( ps.IsActive )
				{
					ps.IsActive = false;
					continue;
				}
				else if ( ps.KillPoints > 0 )
				{
					int atrophy = ( ps.KillPoints + 9 ) / 10;
					ps.KillPoints -= atrophy;
					distrib += atrophy;
				}
			}

			return distrib;
		}

		public void RegisterBroadcast()
		{
			for ( int i = 0; i < m_LastBroadcasts.Length; ++i )
			{
				if ( DateTime.Now >= (m_LastBroadcasts[i] + BroadcastPeriod) )
				{
					m_LastBroadcasts[i] = DateTime.Now;
					break;
				}
			}
		}

		public List<FactionItem> FactionItems
		{
			get{ return m_FactionItems; }
			set{ m_FactionItems = value; }
		}

		public List<BaseFactionTrap> Traps
		{
			get{ return m_FactionTraps; }
			set{ m_FactionTraps = value; }
		}

		public Election Election
		{
			get{ return m_Election; }
			set{ m_Election = value; }
		}

		public Mobile Commander
		{
			get{ return m_Commander; }
			set
			{
				if ( m_Commander != null )
					m_Commander.InvalidateProperties();

				m_Commander = value;

				if ( m_Commander != null )
				{
					m_Commander.SendLocalizedMessage( 1042227 ); // You have been elected Commander of your faction

					m_Commander.InvalidateProperties();

					PlayerState pl = PlayerState.Find( m_Commander );

					if ( pl != null && pl.Finance != null )
						pl.Finance.Finance = null;

					if ( pl != null && pl.Sheriff != null )
						pl.Sheriff.Sheriff = null;
				}
			}
		}

		public int Tithe
		{
			get{ return m_Tithe; }
			set{ m_Tithe = value; }
		}

		public int Silver
		{
			get{ return m_Silver; }
			set{ m_Silver = value; }
		}

		public List<PlayerState> Members
		{
			get{ return m_Members; }
			set{ m_Members = value; }
		}

		public FactionState( Faction faction )
		{
			m_Faction = faction;
			m_Tithe = 50;
			m_Members = new List<PlayerState>();
			m_Election = new Election( faction );
			m_FactionItems = new List<FactionItem>();
			m_FactionTraps = new List<BaseFactionTrap>();
		}

		public FactionState( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 5:
				{
					m_LastAtrophy = reader.ReadDateTime();
					goto case 4;
				}
				case 4:
				{
					int count = reader.ReadEncodedInt();

					for ( int i = 0; i < count; ++i )
					{
						DateTime time = reader.ReadDateTime();

						if ( i < m_LastBroadcasts.Length )
							m_LastBroadcasts[i] = time;
					}

					goto case 3;
				}
				case 3:
				case 2:
				case 1:
				{
					m_Election = new Election( reader );

					goto case 0;
				}
				case 0:
				{
					m_Faction = Faction.ReadReference( reader );

					m_Commander = reader.ReadMobile();

					if ( version < 5 )
						m_LastAtrophy = DateTime.Now;

					if ( version < 4 )
					{
						DateTime time = reader.ReadDateTime();

						if ( m_LastBroadcasts.Length > 0 )
							m_LastBroadcasts[0] = time;
					}

					m_Tithe = reader.ReadEncodedInt();
					m_Silver = reader.ReadEncodedInt();

					int memberCount = reader.ReadEncodedInt();

					m_Members = new List<PlayerState>();

					for ( int i = 0; i < memberCount; ++i )
					{
						PlayerState pl = new PlayerState( reader, m_Faction, m_Members );

						if ( pl.Mobile != null )
							m_Members.Add( pl );
					}

					m_Faction.State = this;

					m_Faction.ZeroRankOffset = m_Members.Count;
					m_Members.Sort();

					for ( int i = m_Members.Count - 1; i >= 0; i-- ) {
						PlayerState player = m_Members[i];

						if ( player.KillPoints <= 0 )
							m_Faction.ZeroRankOffset = i;
						else
							player.RankIndex = i;
					}

					m_FactionItems = new List<FactionItem>();

					if ( version >= 2 )
					{
						int factionItemCount = reader.ReadEncodedInt();

						for ( int i = 0; i < factionItemCount; ++i )
						{
							FactionItem factionItem = new FactionItem( reader, m_Faction );

							Timer.DelayCall( TimeSpan.Zero, new TimerCallback( factionItem.CheckAttach ) ); // sandbox attachment
						}
					}

					m_FactionTraps = new List<BaseFactionTrap>();

					if ( version >= 3 )
					{
						int factionTrapCount = reader.ReadEncodedInt();

						for ( int i = 0; i < factionTrapCount; ++i )
						{
							BaseFactionTrap trap = reader.ReadItem() as BaseFactionTrap;

							if ( trap != null && !trap.CheckDecay() )
								m_FactionTraps.Add( trap );
						}
					}

					break;
				}
			}

			if ( version < 1 )
				m_Election = new Election( m_Faction );
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 5 ); // version

			writer.Write( m_LastAtrophy );

			writer.WriteEncodedInt( (int) m_LastBroadcasts.Length );

			for ( int i = 0; i < m_LastBroadcasts.Length; ++i )
				writer.Write( (DateTime) m_LastBroadcasts[i] );

			m_Election.Serialize( writer );

			Faction.WriteReference( writer, m_Faction );

			writer.Write( (Mobile) m_Commander );

			writer.WriteEncodedInt( (int) m_Tithe );
			writer.WriteEncodedInt( (int) m_Silver );

			writer.WriteEncodedInt( (int) m_Members.Count );

			for ( int i = 0; i < m_Members.Count; ++i )
			{
				PlayerState pl = (PlayerState) m_Members[i];

				pl.Serialize( writer );
			}

			writer.WriteEncodedInt( (int) m_FactionItems.Count );

			for ( int i = 0; i < m_FactionItems.Count; ++i )
				m_FactionItems[i].Serialize( writer );

			writer.WriteEncodedInt( (int) m_FactionTraps.Count );

			for ( int i = 0; i < m_FactionTraps.Count; ++i )
				writer.Write( (Item) m_FactionTraps[i] );
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class FactionStone : BaseSystemController
	{
		private Faction m_Faction;

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;

				AssignName( m_Faction == null ? null : m_Faction.Definition.FactionStoneName );
			}
		}

		public override string DefaultName { get { return "faction stone"; } }

		[Constructable]
		public FactionStone() : this( null )
		{
		}

		[Constructable]
		public FactionStone( Faction faction ) : base( 0xEDC )
		{
			Movable = false;
			Faction = faction;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Faction == null )
				return;

			if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			}
			else if ( FactionGump.Exists( from ) )
			{
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			}
			else if ( from is PlayerMobile )
			{
				Faction existingFaction = Faction.Find( from );

				if ( existingFaction == m_Faction || from.AccessLevel >= AccessLevel.GameMaster )
				{
					PlayerState pl = PlayerState.Find( from );

					if ( pl != null && pl.IsLeaving )
						from.SendLocalizedMessage( 1005051 ); // You cannot use the faction stone until you have finished quitting your current faction
					else
						from.SendGump( new FactionStoneGump( (PlayerMobile) from, m_Faction ) );
				}
				else if ( existingFaction != null )
				{
					// TODO: Validate
					from.SendLocalizedMessage( 1005053 ); // This is not your faction stone!
				}
				else
				{
					from.SendGump( new JoinStoneGump( (PlayerMobile) from, m_Faction ) );
				}
			}
		}

		public FactionStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Faction = Faction.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using System.Collections.Generic;

namespace Server.Factions
{
	public class FactionStoneGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;

		public override int ButtonTypes{ get{ return 4; } }

		public FactionStoneGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;

			AddPage( 0 );

			AddBackground( 0, 0, 550, 440, 5054 );
			AddBackground( 10, 10, 530, 420, 3000 );

			#region General
			AddPage( 1 );

			AddHtmlText( 20, 30, 510, 20, faction.Definition.Header, false, false );

			AddHtmlLocalized( 20, 60, 100, 20, 1011429, false, false ); // Led By :
			AddHtml( 125, 60, 200, 20, faction.Commander != null ? faction.Commander.Name : "Nobody", false, false );

			AddHtmlLocalized( 20, 80, 100, 20, 1011457, false, false ); // Tithe rate :
			if ( faction.Tithe >= 0 && faction.Tithe <= 100 && (faction.Tithe % 10) == 0 )
				AddHtmlLocalized( 125, 80, 350, 20, 1011480 + (faction.Tithe / 10), false, false );
			else
				AddHtml( 125, 80, 350, 20, faction.Tithe + "%", false, false );

			AddHtmlLocalized( 20, 100, 100, 20, 1011458, false, false ); // Traps placed :
			AddHtml( 125, 100, 50, 20, faction.Traps.Count.ToString(), false, false );

			AddHtmlLocalized( 55, 225, 200, 20, 1011428, false, false ); // VOTE FOR LEADERSHIP
			AddButton( 20, 225, 4005, 4007, ToButtonID( 0, 0 ), GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 150, 100, 20, 1011430, false, false ); // CITY STATUS
			AddButton( 20, 150, 4005, 4007, 0, GumpButtonType.Page, 2 );

			AddHtmlLocalized( 55, 175, 100, 20, 1011444, false, false ); // STATISTICS
			AddButton( 20, 175, 4005, 4007, 0, GumpButtonType.Page, 4 );

			bool isMerchantQualified = MerchantTitles.HasMerchantQualifications( from );

			PlayerState pl = PlayerState.Find( from );

			if ( pl != null && pl.MerchantTitle != MerchantTitle.None )
			{
				AddHtmlLocalized( 55, 200, 250, 20, 1011460, false, false ); // UNDECLARE FACTION MERCHANT
				AddButton( 20, 200, 4005, 4007, ToButtonID( 1, 0 ), GumpButtonType.Reply, 0 );
			}
			else if ( isMerchantQualified )
			{
				AddHtmlLocalized( 55, 200, 250, 20, 1011459, false, false ); // DECLARE FACTION MERCHANT
				AddButton( 20, 200, 4005, 4007, 0, GumpButtonType.Page, 5 );
			}
			else
			{
				AddHtmlLocalized( 55, 200, 250, 20, 1011467, false, false ); // MERCHANT OPTIONS
				AddImage( 20, 200, 4020 );
			}

			AddHtmlLocalized( 55, 250, 300, 20, 1011461, false, false ); // COMMANDER OPTIONS
			if ( faction.IsCommander( from ) )
				AddButton( 20, 250, 4005, 4007, 0, GumpButtonType.Page, 6 );
			else
				AddImage( 20, 250, 4020 );

			AddHtmlLocalized( 55, 275, 300, 20, 1011426, false, false ); // LEAVE THIS FACTION
			AddButton( 20, 275, 4005, 4007, ToButtonID( 0, 1 ), GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 300, 200, 20, 1011441, false, false ); // EXIT
			AddButton( 20, 300, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			#endregion

			#region City Status
			AddPage( 2 );

			AddHtmlLocalized( 20, 30, 250, 20, 1011430, false, false ); // CITY STATUS

			List<Town> towns = Town.Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				Town town = towns[i];

				AddHtmlText( 40, 55 + (i * 30), 150, 20, town.Definition.TownName, false, false );

				if ( town.Owner == null )
				{
					AddHtmlLocalized( 200, 55 + (i * 30), 150, 20, 1011462, false, false ); // : Neutral
				}
				else
				{
					AddHtmlLocalized( 200, 55 + (i * 30), 150, 20, town.Owner.Definition.OwnerLabel, false, false );

					BaseMonolith monolith = town.Monolith;

					AddImage( 20, 60 + (i * 30), ( monolith != null && monolith.Sigil != null && monolith.Sigil.IsPurifying ) ? 0x938 : 0x939 );
				}
			}

			AddImage( 20, 300, 2361 );
			AddHtmlLocalized( 45, 295, 300, 20, 1011491, false, false ); // sigil may be recaptured

			AddImage( 20, 320, 2360 );
			AddHtmlLocalized( 45, 315, 300, 20, 1011492, false, false ); // sigil may not be recaptured

			AddHtmlLocalized( 55, 350, 100, 20, 1011447, false, false ); // BACK
			AddButton( 20, 350, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region Statistics
			AddPage( 4 );

			AddHtmlLocalized( 20, 30, 150, 20, 1011444, false, false ); // STATISTICS

			AddHtmlLocalized( 20, 100, 100, 20, 1011445, false, false ); // Name :
			AddHtml( 120, 100, 150, 20, from.Name, false, false );

			AddHtmlLocalized( 20, 130, 100, 20, 1018064, false, false ); // score :
			AddHtml( 120, 130, 100, 20, (pl != null ? pl.KillPoints : 0).ToString(), false, false );

			AddHtmlLocalized( 20, 160, 100, 20, 1011446, false, false ); // Rank :
			AddHtml( 120, 160, 100, 20, (pl != null ? pl.Rank.Rank : 0).ToString(), false, false );

			AddHtmlLocalized( 55, 250, 100, 20, 1011447, false, false ); // BACK
			AddButton( 20, 250, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region Merchant Options
			if ( ( pl == null || pl.MerchantTitle == MerchantTitle.None ) && isMerchantQualified )
			{
				AddPage( 5 );

				AddHtmlLocalized( 20, 30, 250, 20, 1011467, false, false ); // MERCHANT OPTIONS

				AddHtmlLocalized( 20, 80, 300, 20, 1011473, false, false ); // Select the title you wish to display

				MerchantTitleInfo[] infos = MerchantTitles.Info;

				for ( int i = 0; i < infos.Length; ++i )
				{
					MerchantTitleInfo info = infos[i];

					if ( MerchantTitles.IsQualified( from, info ) )
						AddButton( 20, 100 + (i * 30), 4005, 4007, ToButtonID( 1, i + 1 ), GumpButtonType.Reply, 0 );
					else
						AddImage( 20, 100 + (i * 30), 4020 );

					AddHtmlText( 55, 100 + (i * 30), 200, 20, info.Label, false, false );
				}

				AddHtmlLocalized( 55, 340, 100, 20, 1011447, false, false ); // BACK
				AddButton( 20, 340, 4005, 4007, 0, GumpButtonType.Page, 1 );
			}
			#endregion

			#region Commander Options
			if ( faction.IsCommander( from ) )
			{
				#region General
				AddPage( 6 );

				AddHtmlLocalized( 20, 30, 200, 20, 1011461, false, false ); // COMMANDER OPTIONS

				AddHtmlLocalized( 20, 70, 120, 20, 1011457, false, false ); // Tithe rate :
				if ( faction.Tithe >= 0 && faction.Tithe <= 100 && (faction.Tithe % 10) == 0 )
					AddHtmlLocalized( 140, 70, 250, 20, 1011480 + (faction.Tithe / 10), false, false );
				else
					AddHtml( 140, 70, 250, 20, faction.Tithe + "%", false, false );

				AddHtmlLocalized( 20, 100, 120, 20, 1011474, false, false ); // Silver available :
				AddHtml( 140, 100, 50, 20, faction.Silver.ToString( "N0" ), false, false ); // NOTE: Added 'N0' formatting

				AddHtmlLocalized( 55, 130, 200, 20, 1011478, false, false ); // CHANGE TITHE RATE
				AddButton( 20, 130, 4005, 4007, 0, GumpButtonType.Page, 8 );

				AddHtmlLocalized( 55, 160, 200, 20, 1018301, false, false ); // TRANSFER SILVER
				if ( faction.Silver >= 10000 )
					AddButton( 20, 160, 4005, 4007, 0, GumpButtonType.Page, 7 );
				else
					AddImage( 20, 160, 4020 );

				AddHtmlLocalized( 55, 310, 100, 20, 1011447, false, false ); // BACK
				AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Page, 1 );
				#endregion

				#region Town Finance
				if ( faction.Silver >= 10000 )
				{
					AddPage( 7 );

					AddHtmlLocalized( 20, 30, 250, 20, 1011476, false, false ); // TOWN FINANCE

					AddHtmlLocalized( 20, 50, 400, 20, 1011477, false, false ); // Select a town to transfer 10000 silver to

					for ( int i = 0; i < towns.Count; ++i )
					{
						Town town = towns[i];

						AddHtmlText( 55, 75 + (i * 30), 200, 20, town.Definition.TownName, false, false );

						if ( town.Owner == faction )
							AddButton( 20, 75 + (i * 30), 4005, 4007, ToButtonID( 2, i ), GumpButtonType.Reply, 0 );
						else
							AddImage( 20, 75 + (i * 30), 4020 );
					}

					AddHtmlLocalized( 55, 310, 100, 20, 1011447, false, false ); // BACK
					AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Page, 1 );
				}
				#endregion

				#region Change Tithe Rate
				AddPage( 8 );

				AddHtmlLocalized( 20, 30, 400, 20, 1011479, false, false ); // Select the % for the new tithe rate

				int y = 55;

				for ( int i = 0; i <= 10; ++i )
				{
					if ( i == 5 )
						y += 5;

					AddHtmlLocalized( 55, y, 300, 20, 1011480 + i, false, false );
					AddButton( 20, y, 4005, 4007, ToButtonID( 3, i ), GumpButtonType.Reply, 0 );

					y += 20;

					if ( i == 5 )
						y += 5;
				}

				AddHtmlLocalized( 55, 310, 300, 20, 1011447, false, false ); // BACK
				AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Page, 1 );
				#endregion
			}
			#endregion
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int type, index;

			if ( !FromButtonID( info.ButtonID, out type, out index ) )
				return;

			switch ( type )
			{
				case 0: // general
				{
					switch ( index )
					{
						case 0: // vote
						{
							m_From.SendGump( new ElectionGump( m_From, m_Faction.Election ) );
							break;
						}
						case 1: // leave
						{
							m_From.SendGump( new LeaveFactionGump( m_From, m_Faction ) );
							break;
						}
					}

					break;
				}
				case 1: // merchant title
				{
					if ( index >= 0 && index <= MerchantTitles.Info.Length )
					{
						PlayerState pl = PlayerState.Find( m_From );

						MerchantTitle newTitle = (MerchantTitle)index;
						MerchantTitleInfo mti = MerchantTitles.GetInfo( newTitle );

						if ( mti == null )
						{
							m_From.SendLocalizedMessage( 1010120 ); // Your merchant title has been removed

							if ( pl != null )
								pl.MerchantTitle = newTitle;
						}
						else if ( MerchantTitles.IsQualified( m_From, mti ) )
						{
							m_From.SendLocalizedMessage( mti.Assigned );

							if ( pl != null )
								pl.MerchantTitle = newTitle;
						}
					}

					break;
				}
				case 2: // transfer silver
				{
					if ( !m_Faction.IsCommander( m_From ) )
						return;

					List<Town> towns = Town.Towns;

					if ( index >= 0 && index < towns.Count )
					{
						Town town = towns[index];

						if ( town.Owner == m_Faction )
						{
							if ( m_Faction.Silver >= 10000 )
							{
								m_Faction.Silver -= 10000;
								town.Silver += 10000;

								// 10k in silver has been received by:
								m_From.SendLocalizedMessage( 1042726, true, " " + town.Definition.FriendlyName );
							}
						}
					}

					break;
				}
				case 3: // change tithe
				{
					if ( !m_Faction.IsCommander( m_From ) )
						return;

					if ( index >= 0 && index <= 10 )
						m_Faction.Tithe = index*10;

					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionTrapRemovalKit : Item
	{
		private int m_Charges;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; }
		}

		public override int LabelNumber{ get{ return 1041508; } } // a faction trap removal kit

		[Constructable]
		public FactionTrapRemovalKit() : base( 7867 )
		{
			LootType = LootType.Blessed;
			m_Charges = 25;
		}

		public void ConsumeCharge( Mobile consumer )
		{
			--m_Charges;

			if ( m_Charges <= 0 )
			{
				Delete();

				if ( consumer != null )
					consumer.SendLocalizedMessage( 1042531 ); // You have used all of the parts in your trap removal kit.
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			// NOTE: OSI does not list uses remaining; intentional difference
			list.Add( 1060584, m_Charges.ToString() ); // uses remaining: ~1_val~
		}

		public FactionTrapRemovalKit( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.WriteEncodedInt( (int) m_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_Charges = reader.ReadEncodedInt();
					break;
				}
				case 0:
				{
					m_Charges = 25;
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Mobiles;

namespace Server.Factions
{
	[CorpseName( "a war horse corpse" )]
	public class FactionWarHorse : BaseMount
	{
		private Faction m_Faction;

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;

				Body = ( m_Faction == null ? 0xE2 : m_Faction.Definition.WarHorseBody );
				ItemID = ( m_Faction == null ? 0x3EA0 : m_Faction.Definition.WarHorseItem );
			}
		}

		public const int SilverPrice = 500;
		public const int GoldPrice = 3000;

		[Constructable]
		public FactionWarHorse() : this( null )
		{
		}

		public FactionWarHorse( Faction faction ) : base( "a war horse", 0xE2, 0x3EA0, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0xA8;

			SetStr( 400 );
			SetDex( 125 );
			SetInt( 51, 55 );

			SetHits( 240 );
			SetMana( 0 );

			SetDamage( 5, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.FistFighting, 29.3, 44.0 );

			Fame = 300;
			Karma = 300;

			Tamable = true;
			ControlSlots = 1;

			Faction = faction;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public FactionWarHorse( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerState pl = PlayerState.Find( from );

			if ( pl == null )
				from.SendLocalizedMessage( 1010366 ); // You cannot mount a faction war horse!
			else if ( pl.Faction != this.Faction )
				from.SendLocalizedMessage( 1010367 ); // You cannot ride an opposing faction's war horse!
			else if ( pl.Rank.Rank < 2 )
				from.SendLocalizedMessage( 1010368 ); // You must achieve a faction rank of at least two before riding a war horse!
			else
				base.OnDoubleClick( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Faction = Faction.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Factions
{
	public class FactionWizard : BaseFactionGuard
	{
		public override GuardAI GuardAI{ get{ return GuardAI.Magic | GuardAI.Smart | GuardAI.Bless | GuardAI.Curse; } }

		[Constructable]
		public FactionWizard() : base( "the wizard" )
		{
			GenerateBody( false, false );

			SetStr( 151, 175 );
			SetDex( 61, 85 );
			SetInt( 151, 175 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 60 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Energy, 40, 60 );
			SetResistance( ResistanceType.Poison, 40, 60 );

			VirtualArmor = 32;

			SetSkill( SkillName.Bludgeoning, 110.0, 120.0 );
			SetSkill( SkillName.FistFighting, 110.0, 120.0 );
			SetSkill( SkillName.Tactics, 110.0, 120.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Healing, 110.0, 120.0 );
			SetSkill( SkillName.Anatomy, 110.0, 120.0 );

			SetSkill( SkillName.Magery, 110.0, 120.0 );
			SetSkill( SkillName.Psychology, 110.0, 120.0 );
			SetSkill( SkillName.Meditation, 110.0, 120.0 );

			AddItem( Immovable( Rehued( new WizardsHat(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Sandals(), 1325 ) ) );
			AddItem( Immovable( Rehued( new Robe(), 1310 ) ) );
			AddItem( Immovable( Rehued( new LeatherGloves(), 1325 ) ) );
			AddItem( Newbied( Rehued( new GnarledStaff(), 1310 ) ) );

			PackItem( new Bandage( Utility.RandomMinMax( 30, 40 ) ) );
			PackStrongPotions( 6, 12 );
		}

		public FactionWizard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Targeting;// using System.Collections.Generic;

namespace Server.Factions
{
	public class FinanceGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;
		private Town m_Town;

		private static int[] m_PriceOffsets = new int[]
			{
				-30, -25, -20, -15, -10, -5,
				+50, +100, +150, +200, +250, +300
			};

		public override int ButtonTypes{ get{ return 2; } }

		public FinanceGump( PlayerMobile from, Faction faction, Town town ) : base( 50, 50 )
		{
			m_From = from;
			m_Faction = faction;
			m_Town = town;

			AddPage( 0 );

			AddBackground( 0, 0, 320, 410, 5054 );
			AddBackground( 10, 10, 300, 390, 3000 );

			#region General
			AddPage( 1 );

			AddHtmlLocalized( 20, 30, 260, 25, 1011541, false, false ); // FINANCE MINISTER

			AddHtmlLocalized( 55, 90, 200, 25, 1011539, false, false ); // CHANGE PRICES
			AddButton( 20, 90, 4005, 4007, 0, GumpButtonType.Page, 2 );

			AddHtmlLocalized( 55, 120, 200, 25, 1011540, false, false ); // BUY SHOPKEEPERS
			AddButton( 20, 120, 4005, 4007, 0, GumpButtonType.Page, 3 );

			AddHtmlLocalized( 55, 150, 200, 25, 1011495, false, false ); // VIEW FINANCES
			AddButton( 20, 150, 4005, 4007, 0, GumpButtonType.Page, 4 );

			AddHtmlLocalized( 55, 360, 200, 25, 1011441, false, false ); // EXIT
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			#endregion

			#region Change Prices
			AddPage( 2 );

			AddHtmlLocalized( 20, 30, 200, 25, 1011539, false, false ); // CHANGE PRICES

			for ( int i = 0; i < m_PriceOffsets.Length; ++i )
			{
				int ofs = m_PriceOffsets[i];

				int x = 20 + ((i / 6) * 150);
				int y = 90 + ((i % 6) * 30);

				AddRadio( x, y, 208, 209, ( town.Tax == ofs ), i+1 );

				if ( ofs < 0 )
					AddLabel( x + 35, y, 0x26, String.Concat( "- ", -ofs, "%" ) );
				else
					AddLabel( x + 35, y, 0x12A, String.Concat( "+ ", ofs, "%" ) );
			}

			AddRadio( 20, 270, 208, 209, ( town.Tax == 0 ), 0 );
			AddHtmlLocalized( 55, 270, 90, 25, 1011542, false, false ); // normal

			AddHtmlLocalized( 55, 330, 200, 25, 1011509, false, false ); // Set Prices
			AddButton( 20, 330, 4005, 4007, ToButtonID( 0, 0 ), GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region Buy Shopkeepers
			AddPage( 3 );

			AddHtmlLocalized( 20, 30, 200, 25, 1011540, false, false ); // BUY SHOPKEEPERS

			List<VendorList> vendorLists = town.VendorLists;

			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList list = vendorLists[i];

				AddButton( 20, 90 + (i * 40), 4005, 4007, 0, GumpButtonType.Page, 5 + i );
				AddItem( 55, 90 + (i * 40), list.Definition.ItemID );
				AddHtmlText( 100, 90 + (i * 40), 200, 25, list.Definition.Label, false, false );
			}

			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false );	//	Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region View Finances
			AddPage( 4 );

			int financeUpkeep = town.FinanceUpkeep;
			int sheriffUpkeep = town.SheriffUpkeep;
			int dailyIncome = town.DailyIncome;
			int netCashFlow = town.NetCashFlow;

			AddHtmlLocalized( 20, 30, 300, 25, 1011524, false, false ); // FINANCE STATEMENT

			AddHtmlLocalized( 20, 80, 300, 25, 1011538, false, false ); // Current total money for town :
			AddLabel( 20, 100, 0x44, town.Silver.ToString() );

			AddHtmlLocalized( 20, 130, 300, 25, 1011520, false, false ); // Finance Minister Upkeep :
			AddLabel( 20, 150, 0x44, financeUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 180, 300, 25, 1011521, false, false ); // Sheriff Upkeep :
			AddLabel( 20, 200, 0x44, sheriffUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 230, 300, 25, 1011522, false, false ); // Town Income :
			AddLabel( 20, 250, 0x44, dailyIncome.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 280, 300, 25, 1011523, false, false ); // Net Cash flow per day :
			AddLabel( 20, 300, 0x44, netCashFlow.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region Shopkeeper Pages
			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList vendorList = vendorLists[i];

				AddPage( 5 + i );

				AddHtmlText( 60, 30, 300, 25, vendorList.Definition.Header, false, false );
				AddItem( 20, 30, vendorList.Definition.ItemID );

				AddHtmlLocalized( 20, 90, 200, 25, 1011514, false, false ); // You have :
				AddLabel( 230, 90, 0x26, vendorList.Vendors.Count.ToString() );

				AddHtmlLocalized( 20, 120, 200, 25, 1011515, false, false ); // Maximum :
				AddLabel( 230, 120, 0x256, vendorList.Definition.Maximum.ToString() );

				AddHtmlLocalized( 20, 150, 200, 25, 1011516, false, false ); // Cost :
				AddLabel( 230, 150, 0x44, vendorList.Definition.Price.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlLocalized( 20, 180, 200, 25, 1011517, false, false ); // Daily Pay :
				AddLabel( 230, 180, 0x37, vendorList.Definition.Upkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlLocalized( 20, 210, 200, 25, 1011518, false, false ); // Current Silver :
				AddLabel( 230, 210, 0x44, town.Silver.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlLocalized( 20, 240, 200, 25, 1011519, false, false ); // Current Payroll :
				AddLabel( 230, 240, 0x44, financeUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlText( 55, 300, 200, 25, vendorList.Definition.Label, false, false );
				if ( town.Silver >= vendorList.Definition.Price )
					AddButton( 20, 300, 4005, 4007, ToButtonID( 1, i ), GumpButtonType.Reply, 0 );
				else
					AddImage( 20, 300, 4020 );

				AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
				AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 3 );
			}
			#endregion
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( !m_Town.IsFinance( m_From ) || m_Town.Owner != m_Faction )
			{
				m_From.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}

			int type, index;

			if ( !FromButtonID( info.ButtonID, out type, out index ) )
				return;

			switch ( type )
			{
				case 0: // general
				{
					switch ( index )
					{
						case 0: // set price
						{
							int[] switches = info.Switches;

							if ( switches.Length == 0 )
								break;

							int opt = switches[0];
							int newTax = 0;

							if ( opt >= 1 && opt <= m_PriceOffsets.Length )
								newTax = m_PriceOffsets[opt - 1];

							if ( m_Town.Tax == newTax )
								break;

							if ( m_From.AccessLevel == AccessLevel.Player && !m_Town.TaxChangeReady )
							{
								TimeSpan remaining = DateTime.Now - ( m_Town.LastTaxChange + Town.TaxChangePeriod );

								if ( remaining.TotalMinutes < 4 )
									m_From.SendLocalizedMessage( 1042165 ); // You must wait a short while before changing prices again.
								else if ( remaining.TotalMinutes < 10 )
									m_From.SendLocalizedMessage( 1042166 ); // You must wait several minutes before changing prices again.
								else if ( remaining.TotalHours < 1 )
									m_From.SendLocalizedMessage( 1042167 ); // You must wait up to an hour before changing prices again.
								else if ( remaining.TotalHours < 4 )
									m_From.SendLocalizedMessage( 1042168 ); // You must wait a few hours before changing prices again.
								else
									m_From.SendLocalizedMessage( 1042169 ); // You must wait several hours before changing prices again.
							}
							else
							{
								m_Town.Tax = newTax;

								if ( m_From.AccessLevel == AccessLevel.Player )
									m_Town.LastTaxChange = DateTime.Now;
							}

							break;
						}
					}

					break;
				}
				case 1: // make vendor
				{
					List<VendorList> vendorLists = m_Town.VendorLists;

					if ( index >= 0 && index < vendorLists.Count )
					{
						VendorList vendorList = vendorLists[index];

						Town town = Town.FromRegion( m_From.Region );

						if ( Town.FromRegion( m_From.Region ) != m_Town )
						{
							m_From.SendLocalizedMessage( 1010305 ); // You must be in your controlled city to buy Items
						}
						else if ( vendorList.Vendors.Count >= vendorList.Definition.Maximum )
						{
							m_From.SendLocalizedMessage( 1010306 ); // You currently have too many of this enhancement type to place another
						}
						else if ( m_Town.Silver >= vendorList.Definition.Price )
						{
							BaseFactionVendor vendor = vendorList.Construct( m_Town, m_Faction );

							if ( vendor != null )
							{
								m_Town.Silver -= vendorList.Definition.Price;

								vendor.MoveToWorld( m_From.Location, m_From.Map );
								vendor.Home = vendor.Location;
							}
						}
					}

					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class GarnetWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public GarnetWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the garnet wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "garnet", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "garnet scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public GarnetWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server.Commands;// using System.Collections.Generic;

namespace Server.Factions
{
	public class Generator
	{
		public static void Initialize()
		{
			CommandSystem.Register( "GenerateFactions", AccessLevel.Administrator, new CommandEventHandler( GenerateFactions_OnCommand ) );
		}

		public static void GenerateFactions_OnCommand( CommandEventArgs e )
		{
			new FactionPersistance();

			List<Faction> factions = Faction.Factions;

			foreach ( Faction faction in factions )
				Generate( faction );

			List<Town> towns = Town.Towns;

			foreach ( Town town in towns )
				Generate( town );
		}

		public static void Generate( Town town )
		{
			Map facet = Faction.Facet;

			TownDefinition def = town.Definition;

			if ( !CheckExistance( def.Monolith, facet, typeof( TownMonolith ) ) )
			{
				TownMonolith mono = new TownMonolith( town );
				mono.MoveToWorld( def.Monolith, facet );
				mono.Sigil = new Sigil( town );
			}

			if ( !CheckExistance( def.TownStone, facet, typeof( TownStone ) ) )
				new TownStone( town ).MoveToWorld( def.TownStone, facet );
		}

		public static void Generate( Faction faction )
		{
			Map facet = Faction.Facet;

			List<Town> towns = Town.Towns;

			StrongholdDefinition stronghold = faction.Definition.Stronghold;

			if ( !CheckExistance( stronghold.JoinStone, facet, typeof( JoinStone ) ) )
				new JoinStone( faction ).MoveToWorld( stronghold.JoinStone, facet );

			if ( !CheckExistance( stronghold.FactionStone, facet, typeof( FactionStone ) ) )
				new FactionStone( faction ).MoveToWorld( stronghold.FactionStone, facet );

			for ( int i = 0; i < stronghold.Monoliths.Length; ++i )
			{
				Point3D monolith = stronghold.Monoliths[i];

				if ( !CheckExistance( monolith, facet, typeof( StrongholdMonolith ) ) )
					new StrongholdMonolith( towns[i], faction ).MoveToWorld( monolith, facet );
			}
		}

		private static bool CheckExistance( Point3D loc, Map facet, Type type )
		{
			foreach ( Item item in facet.GetItemsInRange( loc, 0 ) )
			{
				if ( type.IsAssignableFrom( item.GetType() ) )
					return true;
			}

			return false;
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class GlowBeetle : BaseCreature
	{
		[Constructable]
		public GlowBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a glow beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;

			SetStr( 156, 180 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			SetHits( 110, 150 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 90, 100 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 26;

			AddItem( new LighterSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( Utility.RandomMinMax( 1, 4 ) == 1 )
			{
				int goo = 0;

				foreach ( Item splash in this.GetItemsInRange( 10 ) ){ if ( splash is MonsterSplatter && splash.Name == "glowing goo" ){ goo++; } }

				if ( goo == 0 )
				{
					MonsterSplatter.AddSplatter( this.X, this.Y, this.Z, this.Map, this.Location, this, "glowing goo", 0xB93, 1 );
				}
			}
		}

		public GlowBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;

			Body = 0xA9;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a gorceratops corpse" )]
	public class Gorceratops : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Gorceratops () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorceratops";
			Body = 0x11C;
			BaseSoundID = 0x4F5;
			Hue = Utility.RandomList( 0x7D7, 0x7D8, 0x7D9, 0x7DA, 0x7DB, 0x7DC );

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 63.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Scales{ get{ return 4; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public Gorceratops( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a gorgon corpse" )]
	public class Gorgon : BaseCreature
	{
		[Constructable]
		public Gorgon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gorgon";
			Body = 0x11C;
			BaseSoundID = 362;
			Hue = 0x961;

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public void TurnStone()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m == this || !CanBeHarmful( m ) )
					continue;

				if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
					list.Add( m );
				else if ( m.Player )
					list.Add( m );
			}

			foreach ( Mobile m in list )
			{
				DoHarmful( m );

				m.PlaySound(0x16B);
				m.FixedEffect(0x376A, 6, 1);

				int duration = Utility.RandomMinMax(4, 8);
				m.Paralyze(TimeSpan.FromSeconds(duration));

				m.SendMessage( "You are petrified from the gorgon breath!" );
			}
		}

		public override void OnGaveMeleeAttack( Mobile m )
		{
			base.OnGaveMeleeAttack( m );

			if ( 1 == Utility.RandomMinMax( 1, 20 ) )
			{
				Container cont = m.Backpack;
				Item iStone = Server.Items.HiddenTrap.GetMyItem( m );

				if ( iStone != null )
				{
					if ( m.CheckSkill( SkillName.MagicResist, 0, 100 ) || Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
					{
					}
					else if ( Server.Items.HiddenTrap.CheckInsuranceOnTrap( iStone, m ) == true )
					{
						m.LocalOverheadMessage(MessageType.Emote, 1150, true, "The gorgon almost turned one of your protected items to stone!");
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "One of your items has been turned to stone!");
						m.PlaySound( 0x1FB );
						Item rock = new BrokenGear();
						rock.ItemID = iStone.GraphicID;
						rock.Hue = 2101;
						rock.Weight = iStone.Weight * 3;
						rock.Name = "useless stone";
						iStone.Delete();
						m.AddToBackpack ( rock );
					}
				}
			}

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public Gorgon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x11C;
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;

namespace Server.Items
{
	public class DarkenedSky : Kama
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070966; } } // Darkened Sky

		[Constructable]
		public DarkenedSky() : base()
		{
			WeaponAttributes.HitLightning = 60;
			Attributes.WeaponSpeed = 25;
			Attributes.WeaponDamage = 50;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = pois = chaos = direct = 0;
			cold = nrgy = 50;
		}

		public DarkenedSky( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}

	public class KasaOfTheRajin : Kasa
	{
		public override int LabelNumber { get { return 1070969; } } // Kasa of the Raj-in

		public override int BasePhysicalResistance { get { return 12; } }
		public override int BaseFireResistance { get { return 17; } }
		public override int BaseColdResistance { get { return 21; } }
		public override int BasePoisonResistance { get { return 17; } }
		public override int BaseEnergyResistance { get { return 17; } }

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		[Constructable]
		public KasaOfTheRajin() : base()
		{
			Attributes.SpellDamage = 12;
		}

		public KasaOfTheRajin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)2 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version <= 1 )
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}

			if( version == 0 )
				LootType = LootType.Regular;
		}

	}

	public class RuneBeetleCarapace : PlateDo
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber{ get{ return 1070968; } } // Rune Beetle Carapace

		public override int BaseColdResistance { get { return 14; } }
		public override int BaseEnergyResistance { get { return 14; } }

		[Constructable]
		public RuneBeetleCarapace() : base()
		{
			Attributes.BonusMana = 10;
			Attributes.RegenMana = 3;
			Attributes.LowerManaCost = 15;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public RuneBeetleCarapace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}

	public class Stormgrip : LeatherNinjaMitts
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber{ get{ return 1070970; } } // Stormgrip

		public override int BasePhysicalResistance { get { return 10; } }
		public override int BaseColdResistance { get { return 18; } }
		public override int BaseEnergyResistance { get { return 18; } }

		[Constructable]
		public Stormgrip() : base()
		{
			Attributes.BonusInt = 8;
			Attributes.Luck = 125;
			Attributes.WeaponDamage = 25;
		}

		public Stormgrip( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}

	public class SwordOfTheStampede : NoDachi
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070964; } } // Sword of the Stampede

		[Constructable]
		public SwordOfTheStampede() : base()
		{
			WeaponAttributes.HitHarm = 100;
			Attributes.AttackChance = 10;
			Attributes.WeaponDamage = 60;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = pois = nrgy = chaos = direct = 0;
			cold = 100;
		}

		public SwordOfTheStampede( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}

	public class SwordsOfProsperity : Daisho
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070963; } } // Swords of Prosperity

		[Constructable]
		public SwordsOfProsperity() : base()
		{
			WeaponAttributes.MageWeapon = 30;
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
			Attributes.Luck = 200;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = cold = pois = nrgy = chaos = direct = 0;
			fire = 100;
		}

		public SwordsOfProsperity( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}

	public class TheHorselord : Yumi
	{
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		public override int LabelNumber { get { return 1070967; } } // The Horselord

		[Constructable]
		public TheHorselord() : base()
		{
			Attributes.BonusDex = 5;
			Attributes.RegenMana = 1;
			Attributes.Luck = 125;
			Attributes.WeaponDamage = 50;

			Slayer = SlayerName.ElementalBan;
			Slayer2 = SlayerName.ReptilianDeath;
		}

		public TheHorselord( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class TomeOfLostKnowledge : Spellbook
	{
		public override int LabelNumber { get { return 1070971; } } // Tome of Lost Knowledge

		[Constructable]
		public TomeOfLostKnowledge() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x530;

			SkillBonuses.SetValues( 0, SkillName.Magery, 15.0 );
			Attributes.BonusInt = 8;
			Attributes.LowerManaCost = 15;
			Attributes.SpellDamage = 15;
		}

		public TomeOfLostKnowledge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class WindsEdge : Tessen
	{
		public override int LabelNumber { get { return 1070965; } } // Wind's Edge

		[Constructable]
		public WindsEdge() : base()
		{
			WeaponAttributes.HitLeechMana = 40;

			Attributes.WeaponDamage = 50;
			Attributes.WeaponSpeed = 50;
			Attributes.DefendChance = 10;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;
			nrgy = 100;
		}

		public WindsEdge( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public enum PigmentType
	{
		None,
		ParagonGold,
		VioletCouragePurple,
		InvulnerabilityBlue,
		LunaWhite,
		DryadGreen,
		ShadowDancerBlack,
		BerserkerRed,
		NoxGreen,
		RumRed,
		FireOrange,
		FadedCoal,
		Coal,
		FadedGold,
		StormBronze,
		Rose,
		MidnightCoal,
		FadedBronze,
		FadedRose,
		DeepRose
	}

	public class PigmentsOfIslesDread : BasePigmentsOfIslesDread
	{
		private static int[][] m_Table = new int[][]
		{
			// Hue, Label
			new int[]{ /*PigmentType.None,*/ 0, -1 },
			new int[]{ /*PigmentType.ParagonGold,*/ 0x501, 1070987 },
			new int[]{ /*PigmentType.VioletCouragePurple,*/ 0x486, 1070988 },
			new int[]{ /*PigmentType.InvulnerabilityBlue,*/ 0x4F2, 1070989 },
			new int[]{ /*PigmentType.LunaWhite,*/ 0x47E, 1070990 },
			new int[]{ /*PigmentType.DryadGreen,*/ 0x48F, 1070991 },
			new int[]{ /*PigmentType.ShadowDancerBlack,*/ 0x455, 1070992 },
			new int[]{ /*PigmentType.BerserkerRed,*/ 0x21, 1070993 },
			new int[]{ /*PigmentType.NoxGreen,*/ 0x58C, 1070994 },
			new int[]{ /*PigmentType.RumRed,*/ 0x66C, 1070995 },
			new int[]{ /*PigmentType.FireOrange,*/ 0x54F, 1070996 },
			new int[]{ /*PigmentType.Fadedcoal,*/ 0x96A, 1079579 },
			new int[]{ /*PigmentType.Coal,*/ 0x96B, 1079580 },
			new int[]{ /*PigmentType.FadedGold,*/ 0x972, 1079581 },
			new int[]{ /*PigmentType.StormBronze,*/ 0x977, 1079582 },
			new int[]{ /*PigmentType.Rose,*/ 0x97C, 1079583 },
			new int[]{ /*PigmentType.MidnightCoal,*/ 0x96C, 1079584 },
			new int[]{ /*PigmentType.FadedBronze,*/ 0x975, 1079585 },
			new int[]{ /*PigmentType.FadedRose,*/ 0x97B, 1079586 },
			new int[]{ /*PigmentType.DeepRose,*/ 0x97E, 1079587 }
		};

		public static int[] GetInfo( PigmentType type )
		{
			int v = (int)type;

			if( v < 0 || v >= m_Table.Length )
				v = 0;

			return m_Table[v];
		}

		private PigmentType m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public PigmentType Type
		{
			get { return m_Type; }
			set
			{
				m_Type = value;

				int v = (int)m_Type;

				if ( v >= 0 && v < m_Table.Length )
				{
					Hue = m_Table[v][0];
					Label = m_Table[v][1];
				}
				else
				{
					Hue = 0;
					Label = -1;
				}
			}
		}

		public override int LabelNumber { get { return 1070933; } } // Pigments of IslesDread

		[Constructable]
		public PigmentsOfIslesDread() : this( PigmentType.None, 10 )
		{
		}

		[Constructable]
		public PigmentsOfIslesDread( PigmentType type ) : this( type, (type == PigmentType.None||type >= PigmentType.FadedCoal)? 10 : 50 )
		{
		}

		[Constructable]
		public PigmentsOfIslesDread( PigmentType type, int uses ) : base( uses )
		{
			Weight = 1.0;
			Type = type;
		}

		public PigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );

			writer.WriteEncodedInt( (int)m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = ( InheritsItem ? 0 : reader.ReadInt() ); // Required for BasePigmentsOfIslesDread insertion

			switch ( version )
			{
				case 1: Type = (PigmentType)reader.ReadEncodedInt(); break;
				case 0: break;
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class GreenDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public GreenDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a green dragon";
			Body = 12;
			Hue = 2001;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Green", "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Green ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public GreenDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server.Items;// using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a griffon corpse" )]
	public class Griffon : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Griffon() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a griffon";
			Body = 0x31F;
			BaseSoundID = 0x2EE;

			SetStr( 196, 220 );
			SetDex( 186, 210 );
			SetInt( 151, 175 );

			SetHits( 158, 172 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 3500;
			Karma = 3500;

			VirtualArmor = 32;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override int Meat{ get{ return 12; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }

		public Griffon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 0x31F;
		}
	}
}
// using System;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a grizzly bear corpse" )]
	[TypeAlias( "Server.Mobiles.Grizzlybear" )]
	public class GrizzlyBear : BaseCreature
	{
		[Constructable]
		public GrizzlyBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a grizzly bear";
			Body = 212;
			BaseSoundID = 0xA3;

			SetStr( 126, 155 );
			SetDex( 81, 105 );
			SetInt( 16, 40 );

			SetHits( 76, 93 );
			SetMana( 0 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 45.1, 70.0 );

			Fame = 1000;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 59.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public GrizzlyBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Targeting;// using Server.Factions.AI;// using Server.Spells;// using Server.Spells.First;// using Server.Spells.Second;// using Server.Spells.Third;// using Server.Spells.Fourth;// using Server.Spells.Fifth;// using Server.Spells.Sixth;// using Server.Spells.Seventh;

namespace Server.Factions
{
	public enum GuardAI
	{
		Bless	= 0x01, // heal, cure, +stats
		Curse	= 0x02, // poison, -stats
		Melee	= 0x04, // weapons
		Magic	= 0x08, // damage spells
		Smart	= 0x10  // smart weapons/damage spells
	}

	public class ComboEntry
	{
		private Type m_Spell;
		private TimeSpan m_Hold;
		private int m_Chance;

		public Type Spell{ get{ return m_Spell; } }
		public TimeSpan Hold{ get{ return m_Hold; } }
		public int Chance{ get{ return m_Chance; } }

		public ComboEntry( Type spell ) : this( spell, 100, TimeSpan.Zero )
		{
		}

		public ComboEntry( Type spell, int chance ) : this( spell, chance, TimeSpan.Zero )
		{
		}

		public ComboEntry( Type spell, int chance, TimeSpan hold )
		{
			m_Spell = spell;
			m_Chance = chance;
			m_Hold = hold;
		}
	}

	public class SpellCombo
	{
		private int m_Mana;
		private ComboEntry[] m_Entries;

		public int Mana{ get{ return m_Mana; } }
		public ComboEntry[] Entries{ get{ return m_Entries; } }

		public SpellCombo( int mana, params ComboEntry[] entries )
		{
			m_Mana = mana;
			m_Entries = entries;
		}

		public static readonly SpellCombo Simple = new SpellCombo( 50,
			new ComboEntry( typeof( ParalyzeSpell ), 20 ),
			new ComboEntry( typeof( ExplosionSpell ), 100, TimeSpan.FromSeconds( 2.8 ) ),
			new ComboEntry( typeof( PoisonSpell ), 30 ),
			new ComboEntry( typeof( EnergyBoltSpell ) )
		);

		public static readonly SpellCombo Strong = new SpellCombo( 90,
			new ComboEntry( typeof( ParalyzeSpell ), 20 ),
			new ComboEntry( typeof( ExplosionSpell ), 50, TimeSpan.FromSeconds( 2.8 ) ),
			new ComboEntry( typeof( PoisonSpell ), 30 ),
			new ComboEntry( typeof( ExplosionSpell ), 100, TimeSpan.FromSeconds( 2.8 ) ),
			new ComboEntry( typeof( EnergyBoltSpell ) ),
			new ComboEntry( typeof( PoisonSpell ), 30 ),
			new ComboEntry( typeof( EnergyBoltSpell ) )
		);

		public static Spell Process( Mobile mob, Mobile targ, ref SpellCombo combo, ref int index, ref DateTime releaseTime )
		{
			while ( ++index < combo.m_Entries.Length )
			{
				ComboEntry entry = combo.m_Entries[index];

				if ( entry.Spell == typeof( PoisonSpell ) && targ.Poisoned )
					continue;

				if ( entry.Chance > Utility.Random( 100 ) )
				{
					releaseTime = DateTime.Now + entry.Hold;
					return (Spell) Activator.CreateInstance( entry.Spell, new object[]{ mob, null } );
				}
			}

			combo = null;
			index = -1;
			return null;
		}
	}

	public class FactionGuardAI : BaseAI
	{
		private BaseFactionGuard m_Guard;

		private BandageContext m_Bandage;
		private DateTime m_BandageStart;

		private SpellCombo m_Combo;
		private int m_ComboIndex = -1;
		private DateTime m_ReleaseTarget;

		private const int ManaReserve = 30;

		public bool IsAllowed( GuardAI flag )
		{
			return ( ( m_Guard.GuardAI & flag ) == flag );
		}

		public bool IsDamaged
		{
			get{ return ( m_Guard.Hits < m_Guard.HitsMax ); }
		}

		public bool IsPoisoned
		{
			get{ return m_Guard.Poisoned; }
		}

		public TimeSpan TimeUntilBandage
		{
			get
			{
				if ( m_Bandage != null && m_Bandage.Timer == null )
					m_Bandage = null;

				if ( m_Bandage == null )
					return TimeSpan.MaxValue;

				TimeSpan ts = ( m_BandageStart + m_Bandage.Timer.Delay ) - DateTime.Now;

				if ( ts < TimeSpan.FromSeconds( -1.0 ) )
				{
					m_Bandage = null;
					return TimeSpan.MaxValue;
				}

				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;

				return ts;
			}
		}

		public bool DequipWeapon()
		{
			Container pack = m_Guard.Backpack;

			if ( pack == null )
				return false;

			Item weapon = m_Guard.Weapon as Item;

			if ( weapon != null && weapon.Parent == m_Guard && !(weapon is Fists) )
			{
				pack.DropItem( weapon );
				return true;
			}

			return false;
		}

		public bool EquipWeapon()
		{
			Container pack = m_Guard.Backpack;

			if ( pack == null )
				return false;

			Item weapon = pack.FindItemByType( typeof( BaseWeapon ) );

			if ( weapon == null )
				return false;

			return m_Guard.EquipItem( weapon );
		}

		public bool StartBandage()
		{
			m_Bandage = null;

			Container pack = m_Guard.Backpack;

			if ( pack == null )
				return false;

			Item bandage = pack.FindItemByType( typeof( Bandage ) );

			if ( bandage == null )
				return false;

			m_Bandage = BandageContext.BeginHeal( m_Guard, m_Guard );
			m_BandageStart = DateTime.Now;
			return ( m_Bandage != null );
		}

		public bool UseItemByType( Type type )
		{
			Container pack = m_Guard.Backpack;

			if ( pack == null )
				return false;

			Item item = pack.FindItemByType( type );

			if ( item == null )
				return false;

			bool requip = DequipWeapon();

			item.OnDoubleClick( m_Guard );

			if ( requip )
				EquipWeapon();

			return true;
		}

		public int GetStatMod( Mobile mob, StatType type )
		{
			StatMod mod = mob.GetStatMod( String.Format( "[Magic] {0} Offset", type ) );

			if ( mod == null )
				return 0;

			return mod.Offset;
		}

		public Spell RandomOffenseSpell()
		{
			int maxCircle = (int)((m_Guard.Skills.Magery.Value + 20.0) / (100.0 / 7.0));

			if ( maxCircle < 1 )
				maxCircle = 1;

			switch ( Utility.Random( maxCircle*2 ) )
			{
				case  0: case  1: return new MagicArrowSpell( m_Guard, null );
				case  2: case  3: return new HarmSpell( m_Guard, null );
				case  4: case  5: return new FireballSpell( m_Guard, null );
				case  6: case  7: return new LightningSpell( m_Guard, null );
				case  8: return new MindBlastSpell( m_Guard, null );
				case  9: return new ParalyzeSpell( m_Guard, null );
				case 10: return new EnergyBoltSpell( m_Guard, null );
				case 11: return new ExplosionSpell( m_Guard, null );
				default: return new FlameStrikeSpell( m_Guard, null );
			}
		}

		public Mobile FindDispelTarget( bool activeOnly )
		{
			if ( m_Mobile.Deleted || m_Mobile.Int < 95 || CanDispel( m_Mobile ) || m_Mobile.AutoDispel )
				return null;

			if ( activeOnly )
			{
				List<AggressorInfo> aggressed = m_Mobile.Aggressed;
				List<AggressorInfo> aggressors = m_Mobile.Aggressors;

				Mobile active = null;
				double activePrio = 0.0;

				Mobile comb = m_Mobile.Combatant;

				if ( comb != null && !comb.Deleted && comb.Alive && !comb.IsDeadBondedPet && m_Mobile.InRange( comb, 12 ) && CanDispel( comb ) )
				{
					active = comb;
					activePrio = m_Mobile.GetDistanceToSqrt( comb );

					if ( activePrio <= 2 )
						return active;
				}

				for ( int i = 0; i < aggressed.Count; ++i )
				{
					AggressorInfo info = aggressed[i];
					Mobile m = info.Defender;

					if ( m != comb && m.Combatant == m_Mobile && m_Mobile.InRange( m, 12 ) && CanDispel( m ) )
					{
						double prio = m_Mobile.GetDistanceToSqrt( m );

						if ( active == null || prio < activePrio )
						{
							active = m;
							activePrio = prio;

							if ( activePrio <= 2 )
								return active;
						}
					}
				}

				for ( int i = 0; i < aggressors.Count; ++i )
				{
					AggressorInfo info = aggressors[i];
					Mobile m = info.Attacker;

					if ( m != comb && m.Combatant == m_Mobile && m_Mobile.InRange( m, 12 ) && CanDispel( m ) )
					{
						double prio = m_Mobile.GetDistanceToSqrt( m );

						if ( active == null || prio < activePrio )
						{
							active = m;
							activePrio = prio;

							if ( activePrio <= 2 )
								return active;
						}
					}
				}

				return active;
			}
			else
			{
				Map map = m_Mobile.Map;

				if ( map != null )
				{
					Mobile active = null, inactive = null;
					double actPrio = 0.0, inactPrio = 0.0;

					Mobile comb = m_Mobile.Combatant;

					if ( comb != null && !comb.Deleted && comb.Alive && !comb.IsDeadBondedPet && CanDispel( comb ) )
					{
						active = inactive = comb;
						actPrio = inactPrio = m_Mobile.GetDistanceToSqrt( comb );
					}

					foreach ( Mobile m in m_Mobile.GetMobilesInRange( 12 ) )
					{
						if ( m != m_Mobile && CanDispel( m ) )
						{
							double prio = m_Mobile.GetDistanceToSqrt( m );

							if ( !activeOnly && (inactive == null || prio < inactPrio) )
							{
								inactive = m;
								inactPrio = prio;
							}

							if ( (m_Mobile.Combatant == m || m.Combatant == m_Mobile) && (active == null || prio < actPrio) )
							{
								active = m;
								actPrio = prio;
							}
						}
					}

					return active != null ? active : inactive;
				}
			}

			return null;
		}

		public bool CanDispel( Mobile m )
		{
			return ( m is BaseCreature && ((BaseCreature)m).Summoned && m_Mobile.CanBeHarmful( m, false ) && !((BaseCreature)m).IsAnimatedDead );
		}

		public void RunTo( Mobile m )
		{
			/*if ( m.Paralyzed || m.Frozen )
			{
				if ( m_Mobile.InRange( m, 1 ) )
					RunFrom( m );
				else if ( !m_Mobile.InRange( m, m_Mobile.RangeFight > 2 ? m_Mobile.RangeFight : 2 ) && !MoveTo( m, true, 1 ) )
					OnFailedMove();
			}
			else
			{*/
				if ( !m_Mobile.InRange( m, m_Mobile.RangeFight ) )
				{
					if ( !MoveTo( m, true, 1 ) )
						OnFailedMove();
				}
				else if ( m_Mobile.InRange( m, m_Mobile.RangeFight - 1 ) )
				{
					RunFrom( m );
				}
			/*}*/
		}

		public void RunFrom( Mobile m )
		{
			Run( (m_Mobile.GetDirectionTo( m ) - 4) & Direction.Mask );
		}

		public void OnFailedMove()
		{
			/*if ( !m_Mobile.DisallowAllMoves && 20 > Utility.Random( 100 ) && IsAllowed( GuardAI.Magic ) )
			{
				if ( m_Mobile.Target != null )
					m_Mobile.Target.Cancel( m_Mobile, TargetCancelType.Canceled );

				new TeleportSpell( m_Mobile, null ).Cast();

				m_Mobile.DebugSay( "I am stuck, I'm going to try teleporting away" );
			}
			else*/ if ( AcquireFocusMob( m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true ) )
			{
				if ( m_Mobile.Debug )
					m_Mobile.DebugSay( "My move is blocked, so I am going to attack {0}", m_Mobile.FocusMob.Name );

				m_Mobile.Combatant = m_Mobile.FocusMob;
				Action = ActionType.Combat;
			}
			else
			{
				m_Mobile.DebugSay( "I am stuck" );
			}
		}

		public void Run( Direction d )
		{
			if ( (m_Mobile.Spell != null && m_Mobile.Spell.IsCasting) || m_Mobile.Paralyzed || m_Mobile.Frozen || m_Mobile.DisallowAllMoves )
				return;

			m_Mobile.Direction = d | Direction.Running;

			if ( !DoMove( m_Mobile.Direction, true ) )
				OnFailedMove();
		}

		public FactionGuardAI( BaseFactionGuard guard ) : base( guard )
		{
			m_Guard = guard;
		}

		public override bool Think()
		{
			if ( m_Mobile.Deleted )
				return false;

			Mobile combatant = m_Guard.Combatant;

			if ( combatant == null || combatant.Deleted || !combatant.Alive || combatant.IsDeadBondedPet || !m_Mobile.CanSee( combatant ) || !m_Mobile.CanBeHarmful( combatant, false ) || combatant.Map != m_Mobile.Map )
			{
				// Our combatant is deleted, dead, hidden, or we cannot hurt them
				// Try to find another combatant

				if ( AcquireFocusMob( m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true ) )
				{
					m_Mobile.Combatant = combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else
				{
					m_Mobile.Combatant = combatant = null;
				}
			}

			if ( combatant != null && (!m_Mobile.InLOS( combatant ) || !m_Mobile.InRange( combatant, 12 )) )
			{
				if ( AcquireFocusMob( m_Mobile.RangePerception, m_Mobile.FightMode, false, false, true ) )
				{
					m_Mobile.Combatant = combatant = m_Mobile.FocusMob;
					m_Mobile.FocusMob = null;
				}
				else if ( !m_Mobile.InRange( combatant, 36 ) )
				{
					m_Mobile.Combatant = combatant = null;
				}
			}

			Mobile dispelTarget = FindDispelTarget( true );

			if ( m_Guard.Target != null && m_ReleaseTarget == DateTime.MinValue )
				m_ReleaseTarget = DateTime.Now + TimeSpan.FromSeconds( 10.0 );

			if ( m_Guard.Target != null && DateTime.Now > m_ReleaseTarget )
			{
				Target targ = m_Guard.Target;

				Mobile toHarm = ( dispelTarget == null ? combatant : dispelTarget );

				if ( (targ.Flags & TargetFlags.Harmful) != 0 && toHarm != null )
				{
					if ( m_Guard.Map == toHarm.Map && ( targ.Range < 0 || m_Guard.InRange( toHarm, targ.Range ) ) && m_Guard.CanSee( toHarm ) && m_Guard.InLOS( toHarm ) )
						targ.Invoke( m_Guard, toHarm );
					else if ( targ is DispelSpell.InternalTarget )
						targ.Cancel( m_Guard, TargetCancelType.Canceled );
				}
				else if ( (targ.Flags & TargetFlags.Beneficial) != 0 )
				{
					targ.Invoke( m_Guard, m_Guard );
				}
				else
				{
					targ.Cancel( m_Guard, TargetCancelType.Canceled );
				}

				m_ReleaseTarget = DateTime.MinValue;
			}

			if ( dispelTarget != null )
			{
				if ( Action != ActionType.Combat )
					Action = ActionType.Combat;

				m_Guard.Warmode = true;

				RunFrom( dispelTarget );
			}
			else if ( combatant != null )
			{
				if ( Action != ActionType.Combat )
					Action = ActionType.Combat;

				m_Guard.Warmode = true;

				RunTo( combatant );
			}
			else if ( m_Guard.Orders.Movement != MovementType.Stand )
			{
				Mobile toFollow = null;

				if ( m_Guard.Town != null && m_Guard.Orders.Movement == MovementType.Follow )
				{
					toFollow = m_Guard.Orders.Follow;

					if ( toFollow == null )
						toFollow = m_Guard.Town.Sheriff;
				}

				if ( toFollow != null && toFollow.Map == m_Guard.Map && toFollow.InRange( m_Guard, m_Guard.RangePerception * 3 ) && Town.FromRegion( toFollow.Region ) == m_Guard.Town )
				{
					if ( Action != ActionType.Combat )
						Action = ActionType.Combat;

					if ( m_Mobile.CurrentSpeed != m_Mobile.ActiveSpeed )
						m_Mobile.CurrentSpeed = m_Mobile.ActiveSpeed;

					m_Guard.Warmode = true;

					RunTo( toFollow );
				}
				else
				{
					if ( Action != ActionType.Wander )
						Action = ActionType.Wander;

					if ( m_Mobile.CurrentSpeed != m_Mobile.PassiveSpeed )
						m_Mobile.CurrentSpeed = m_Mobile.PassiveSpeed;

					m_Guard.Warmode = false;

					WalkRandomInHome( 2, 2, 1 );
				}
			}
			else
			{
				if ( Action != ActionType.Wander )
					Action = ActionType.Wander;

				m_Guard.Warmode = false;
			}

			if ( (IsDamaged || IsPoisoned) && m_Guard.Skills.Healing.Base > 20.0 )
			{
				TimeSpan ts = TimeUntilBandage;

				if ( ts == TimeSpan.MaxValue )
					StartBandage();
			}

			if ( m_Mobile.Spell == null && DateTime.Now >= m_Mobile.NextSpellTime )
			{
				Spell spell = null;

				DateTime toRelease = DateTime.MinValue;

				if ( IsPoisoned )
				{
					Poison p = m_Guard.Poison;

					TimeSpan ts = TimeUntilBandage;

					if ( p != Poison.Lesser || ts == TimeSpan.MaxValue || TimeUntilBandage < TimeSpan.FromSeconds( 1.5 ) || (m_Guard.HitsMax - m_Guard.Hits) > Utility.Random( 250 ) )
					{
						if ( IsAllowed( GuardAI.Bless ) )
							spell = new CureSpell( m_Guard, null );
						else
							UseItemByType( typeof( BaseCurePotion ) );
					}
				}
				else if ( IsDamaged && (m_Guard.HitsMax - m_Guard.Hits) > Utility.Random( 200 ) )
				{
					if( IsAllowed( GuardAI.Magic ) && ((m_Guard.Hits * 100) / Math.Max( m_Guard.HitsMax, 1 )) < 10 && m_Guard.Home != Point3D.Zero && !Utility.InRange( m_Guard.Location, m_Guard.Home, 15 ) && m_Guard.Mana >= 11 )
					{
						spell = new RecallSpell( m_Guard, null, new RunebookEntry( m_Guard.Home, m_Guard.Map, "Guard's Home", null ), null  );
					}
					else if ( IsAllowed( GuardAI.Bless ) )
					{
						if ( m_Guard.Mana >= 11 && (m_Guard.Hits + 30) < m_Guard.HitsMax )
							spell = new GreaterHealSpell( m_Guard, null );
						else if ( (m_Guard.Hits + 10) < m_Guard.HitsMax && (m_Guard.Mana < 11 || (m_Guard.NextCombatTime - DateTime.Now) > TimeSpan.FromSeconds( 2.0 )) )
							spell = new HealSpell( m_Guard, null );
					}
					else if ( m_Guard.CanBeginAction( typeof( BaseHealPotion ) ) )
					{
						UseItemByType( typeof( BaseHealPotion ) );
					}
				}
				else if ( dispelTarget != null && (IsAllowed( GuardAI.Magic ) || IsAllowed( GuardAI.Bless ) || IsAllowed( GuardAI.Curse )) )
				{
					if ( !dispelTarget.Paralyzed && m_Guard.Mana > (ManaReserve + 20) && 40 > Utility.Random( 100 ) )
						spell = new ParalyzeSpell( m_Guard, null );
					else
						spell = new DispelSpell( m_Guard, null );
				}

				if ( combatant != null )
				{
					if ( m_Combo != null )
					{
						if ( spell == null )
						{
							spell = SpellCombo.Process( m_Guard, combatant, ref m_Combo, ref m_ComboIndex, ref toRelease );
						}
						else
						{
							m_Combo = null;
							m_ComboIndex = -1;
						}
					}
					else if ( 20 > Utility.Random( 100 ) && IsAllowed( GuardAI.Magic ) )
					{
						if ( 80 > Utility.Random( 100 ) )
						{
							m_Combo = ( IsAllowed( GuardAI.Smart ) ? SpellCombo.Simple : SpellCombo.Strong );
							m_ComboIndex = -1;

							if ( m_Guard.Mana >= (ManaReserve + m_Combo.Mana) )
								spell = SpellCombo.Process( m_Guard, combatant, ref m_Combo, ref m_ComboIndex, ref toRelease );
							else
							{
								m_Combo = null;

								if ( m_Guard.Mana >= (ManaReserve + 40) )
									spell = RandomOffenseSpell();
							}
						}
						else if ( m_Guard.Mana >= (ManaReserve + 40) )
						{
							spell = RandomOffenseSpell();
						}
					}

					if ( spell == null && 2 > Utility.Random( 100 ) && m_Guard.Mana >= (ManaReserve + 10) )
					{
						int strMod = GetStatMod( m_Guard, StatType.Str );
						int dexMod = GetStatMod( m_Guard, StatType.Dex );
						int intMod = GetStatMod( m_Guard, StatType.Int );

						List<Type> types = new List<Type>();

						if ( strMod <= 0 )
							types.Add( typeof( StrengthSpell ) );

						if ( dexMod <= 0 && IsAllowed( GuardAI.Melee ) )
							types.Add( typeof( AgilitySpell ) );

						if ( intMod <= 0 && IsAllowed( GuardAI.Magic ) )
							types.Add( typeof( CunningSpell ) );

						if ( IsAllowed( GuardAI.Bless ) )
						{
							if ( types.Count > 1 )
								spell = new BlessSpell( m_Guard, null );
							else if ( types.Count == 1 )
								spell = (Spell) Activator.CreateInstance( types[0], new object[]{ m_Guard, null } );
						}
						else if ( types.Count > 0 )
						{
							if ( types[0] == typeof( StrengthSpell ) )
								UseItemByType( typeof( BaseStrengthPotion ) );
							else if ( types[0] == typeof( AgilitySpell ) )
								UseItemByType( typeof( BaseAgilityPotion ) );
						}
					}

					if ( spell == null && 2 > Utility.Random( 100 ) && m_Guard.Mana >= (ManaReserve + 10) && IsAllowed( GuardAI.Curse ) )
					{
						if ( !combatant.Poisoned && 40 > Utility.Random( 100 ) )
						{
							spell = new PoisonSpell( m_Guard, null );
						}
						else
						{
							int strMod = GetStatMod( combatant, StatType.Str );
							int dexMod = GetStatMod( combatant, StatType.Dex );
							int intMod = GetStatMod( combatant, StatType.Int );

							List<Type> types = new List<Type>();

							if ( strMod >= 0 )
								types.Add( typeof( WeakenSpell ) );

							if ( dexMod >= 0 && IsAllowed( GuardAI.Melee ) )
								types.Add( typeof( ClumsySpell ) );

							if ( intMod >= 0 && IsAllowed( GuardAI.Magic ) )
								types.Add( typeof( FeeblemindSpell ) );

							if ( types.Count > 1 )
								spell = new CurseSpell( m_Guard, null );
							else if ( types.Count == 1 )
								spell = (Spell) Activator.CreateInstance( types[0], new object[]{ m_Guard, null } );
						}
					}
				}

				if ( spell != null && (m_Guard.HitsMax - m_Guard.Hits + 10) > Utility.Random( 100 ) )
				{
					Type type = null;

					if ( spell is GreaterHealSpell )
						type = typeof( BaseHealPotion );
					else if ( spell is CureSpell )
						type = typeof( BaseCurePotion );
					else if ( spell is StrengthSpell )
						type = typeof( BaseStrengthPotion );
					else if ( spell is AgilitySpell )
						type = typeof( BaseAgilityPotion );

					if ( type == typeof( BaseHealPotion ) && !m_Guard.CanBeginAction( type ) )
						type = null;

					if ( type != null && m_Guard.Target == null && UseItemByType( type ) )
					{
						if ( spell is GreaterHealSpell )
						{
							if ( (m_Guard.Hits + 30) > m_Guard.HitsMax && (m_Guard.Hits + 10) < m_Guard.HitsMax )
								spell = new HealSpell( m_Guard, null );
						}
						else
						{
							spell = null;
						}
					}
				}
				else if ( spell == null && m_Guard.Stam < (m_Guard.StamMax / 3) && IsAllowed( GuardAI.Melee ) )
				{
					UseItemByType( typeof( BaseRefreshPotion ) );
				}

				if ( spell == null || !spell.Cast() )
					EquipWeapon();
			}
			else if ( m_Mobile.Spell is Spell && ((Spell)m_Mobile.Spell).State == SpellState.Sequencing )
			{
				EquipWeapon();
			}

			return true;
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class GuardDefinition
	{
		private Type m_Type;

		private int m_Price;
		private int m_Upkeep;
		private int m_Maximum;

		private int m_ItemID;

		private TextDefinition m_Header;
		private TextDefinition m_Label;

		public Type Type{ get{ return m_Type; } }

		public int Price{ get{ return m_Price; } }
		public int Upkeep{ get{ return m_Upkeep; } }
		public int Maximum{ get{ return m_Maximum; } }
		public int ItemID{ get{ return m_ItemID; } }

		public TextDefinition Header{ get{ return m_Header; } }
		public TextDefinition Label{ get{ return m_Label; } }

		public GuardDefinition( Type type, int itemID, int price, int upkeep, int maximum, TextDefinition header, TextDefinition label )
		{
			m_Type = type;

			m_Price = price;
			m_Upkeep = upkeep;
			m_Maximum = maximum;
			m_ItemID = itemID;

			m_Header = header;
			m_Label = label;
		}
	}
}
// using System;// using Server;// using System.Collections.Generic;

namespace Server.Factions
{
	public class GuardList
	{
		private GuardDefinition m_Definition;
		private List<BaseFactionGuard> m_Guards;

		public GuardDefinition Definition{ get{ return m_Definition; } }
		public List<BaseFactionGuard> Guards{ get{ return m_Guards; } }

		public BaseFactionGuard Construct()
		{
			try{ return Activator.CreateInstance( m_Definition.Type ) as BaseFactionGuard; }
			catch{ return null; }
		}

		public GuardList( GuardDefinition definition )
		{
			m_Definition = definition;
			m_Guards = new List<BaseFactionGuard>();
		}
	}
}
// using System;// using Server;

namespace Server.Items
{
	public class HarrowerGate : Moongate
	{
		private Mobile m_Harrower;

		public override int LabelNumber{ get{ return 1049498; } } // dark moongate

		public HarrowerGate( Mobile harrower, Point3D loc, Map map, Point3D targLoc, Map targMap ) : base( targLoc, targMap )
		{
			m_Harrower = harrower;

			Dispellable = false;
			ItemID = 0x1FD4;
			Light = LightType.Circle300;

			MoveToWorld( loc, map );
		}

		public HarrowerGate( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Harrower );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Harrower = reader.ReadMobile();

					if ( m_Harrower == null )
						Delete();

					break;
				}
			}

			if ( Light != LightType.Circle300 )
				Light = LightType.Circle300;
		}
	}
}
// using System;// using System.Collections;// using Server.Items;// using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a hippogriff corpse" )]
	public class Hippogriff : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Hippogriff() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hippogriff";
			Body = 188;
			BaseSoundID = 0x2EE;

			SetStr( 196, 220 );
			SetDex( 186, 210 );
			SetInt( 151, 175 );

			SetHits( 158, 172 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 3500;
			Karma = 3500;

			VirtualArmor = 32;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override int Meat{ get{ return 12; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }

		public Hippogriff( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = 188;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Hero
{
	public sealed class HolyBlade : Power
	{
		public HolyBlade()
		{
			m_Definition = new PowerDefinition(
					10,
					"Holy Blade",
					"Erstok Reyam",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using Server;// using Server.Ethics;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a holy corpse" )]
	public class HolyFamiliar : BaseCreature
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }

		[Constructable]
		public HolyFamiliar()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a silver wolf";
			Body = 225;
			Hue = 1154;
			BaseSoundID = 0xE5;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = 2500;

			VirtualArmor = 22;

			Tamable = false;
			ControlSlots = 1;
		}

		public override int Meat { get { return 1; } }
		public override int Hides { get { return 7; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }
		public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

		public HolyFamiliar( Serial serial )
			: base( serial )
		{
		}

		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Hero.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Hero.Definition.Adjunct.String );

			return base.ApplyNameSuffix( suffix );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Items;

namespace Server.Ethics.Hero
{
	public sealed class HolyItem : Power
	{
		public HolyItem()
		{
			m_Definition = new PowerDefinition(
					5,
					"Holy Item",
					"Vidda K'balc",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, false, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Which item do you wish to imbue?" );
		}

		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;

			Item item = obj as Item;

			if ( item == null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
				return;
			}

			if ( item.Parent != from.Mobile )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may only imbue items you are wearing." );
				return;
			}

			if ( ( item.SavedFlags & 0x300 ) != 0 )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "That has already beem imbued." );
				return;
			}

			bool canImbue = ( item is Spellbook || item is BaseClothing || item is BaseArmor || item is BaseWeapon ) && ( item.Name == null );

			if ( canImbue )
			{
				if ( !CheckInvoke( from ) )
					return;

				item.Hue = Ethic.Hero.Definition.PrimaryHue;
				item.SavedFlags |= 0x100;

				from.Mobile.FixedEffect( 0x375A, 10, 20 );
				from.Mobile.PlaySound( 0x209 );

				FinishInvoke( from );
			}
			else
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Hero
{
	public sealed class HolySense : Power
	{
		public HolySense()
		{
			m_Definition = new PowerDefinition(
					0,
					"Holy Sense",
					"Drewrok Erstok",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			Ethic opposition = Ethic.Evil;

			int enemyCount = 0;

			int maxRange = 18 + from.Power;

			Player primary = null;

			foreach ( Player pl in opposition.Players )
			{
				Mobile mob = pl.Mobile;

				if ( mob == null || mob.Map != from.Mobile.Map || !mob.Alive )
					continue;

				if ( !mob.InRange( from.Mobile, Math.Max( 18, maxRange - pl.Power ) ) )
					continue;

				if ( primary == null || pl.Power > primary.Power )
					primary = pl;

				++enemyCount;
			}

			StringBuilder sb = new StringBuilder();

			sb.Append( "You sense " );
			sb.Append( enemyCount == 0 ? "no" : enemyCount.ToString() );
			sb.Append( enemyCount == 1 ? " enemy" : " enemies" );

			if ( primary != null )
			{
				sb.Append( ", and a strong presense" );

				switch ( from.Mobile.GetDirectionTo( primary.Mobile ) )
				{
					case Direction.West:
						sb.Append( " to the west." );
						break;
					case Direction.East:
						sb.Append( " to the east." );
						break;
					case Direction.North:
						sb.Append( " to the north." );
						break;
					case Direction.South:
						sb.Append( " to the south." );
						break;

					case Direction.Up:
						sb.Append( " to the north-west." );
						break;
					case Direction.Down:
						sb.Append( " to the south-east." );
						break;
					case Direction.Left:
						sb.Append( " to the south-west." );
						break;
					case Direction.Right:
						sb.Append( " to the north-east." );
						break;
				}
			}
			else
			{
				sb.Append( '.' );
			}

			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x59, false, sb.ToString() );

			FinishInvoke( from );
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Hero
{
	public sealed class HolyShield : Power
	{
		public HolyShield()
		{
			m_Definition = new PowerDefinition(
					20,
					"Holy Shield",
					"Erstok K'blac",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			if ( from.IsShielded )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of a holy shield." );
				return;
			}

			from.BeginShield();

			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of a holy shield." );

			FinishInvoke( from );
		}
	}
}// using System;// using Server;// using Server.Ethics;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a holy corpse" )]
	public class HolySteed : BaseMount
	{
		public override bool IsDispellable { get{ return false; } }
		public override bool IsBondable { get { return false; } }

		public override bool HasBreath { get { return true; } }
		public override bool CanBreath { get { return true; } }

		[Constructable]
		public HolySteed()
			: base( "a silver steed", 0x75, 0x3EA8, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 80.5, 92.5 );

			Fame = 14000;
			Karma = 14000;

			VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 1;
		}

		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public HolySteed( Serial serial )
			: base( serial )
		{
		}

		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Hero.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Hero.Definition.Adjunct.String );

			return base.ApplyNameSuffix( suffix );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Ethic.Find( from ) != Ethic.Hero )
				from.SendMessage( "You may not ride this steed." );
			else
				base.OnDoubleClick( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Ethics.Hero
{
	public sealed class HolySteed : Power
	{
		public HolySteed()
		{
			m_Definition = new PowerDefinition(
					30,
					"Holy Steed",
					"Trubechs Yeliab",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			if ( from.Steed != null && from.Steed.Deleted )
				from.Steed = null;

			if ( from.Steed != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy steed." );
				return;
			}

			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}

			Mobiles.HolySteed steed = new Mobiles.HolySteed();

			if ( Mobiles.BaseCreature.Summon( steed, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Steed = steed;

				FinishInvoke( from );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Hero
{
	public sealed class HolyWord : Power
	{
		public HolyWord()
		{
			m_Definition = new PowerDefinition(
					100,
					"Holy Word",
					"Erstok Oostrac",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using Server.Gumps;// using Server.Targeting;// using Server.Regions;

namespace Server
{
	public class HonorVirtue
	{

		private static readonly TimeSpan UseDelay = TimeSpan.FromMinutes( 5.0 );

		public static void Initialize()
		{
			VirtueGump.Register( 107, new OnVirtueUsed( OnVirtueUsed ) );
		}

		private static void OnVirtueUsed( Mobile from )
		{
			if ( from.Alive )
			{
				from.SendLocalizedMessage( 1063160 ); // Target what you wish to honor.
				from.Target = new InternalTarget();
			}
		}

		private class InternalTarget : Target
		{
			public InternalTarget() : base( 12, false, TargetFlags.None )
			{
				CheckLOS = true;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				PlayerMobile pm = from as PlayerMobile;
				if ( pm == null )
					return;

				if ( targeted == pm )
				{
					EmbraceHonor( pm );
				}
				else if ( targeted is Mobile )
					Honor( pm, (Mobile) targeted );
			}

			protected override void OnTargetOutOfRange( Mobile from, object targeted )
			{
				from.SendLocalizedMessage( 1063232 ); // You are too far away to honor your opponent
			}
		}

		private static int GetHonorDuration( PlayerMobile from )
		{
			switch ( VirtueHelper.GetLevel( from, VirtueName.Honor ) )
			{
				case VirtueLevel.Seeker: return 30;
				case VirtueLevel.Follower: return 90;
				case VirtueLevel.Knight: return 300;

				default: return 0 ;
			}
		}

		private static void EmbraceHonor( PlayerMobile pm )
		{
			if ( pm.HonorActive )
			{
				pm.SendLocalizedMessage( 1063230 ); // You must wait awhile before you can embrace honor again.
				return;
			}

			if ( GetHonorDuration( pm ) == 0 )
			{
				pm.SendLocalizedMessage( 1063234 ); // You do not have enough honor to do that
				return;
			}

			TimeSpan waitTime = DateTime.Now - pm.LastHonorUse;
			if ( waitTime < UseDelay )
			{
				TimeSpan remainingTime = UseDelay - waitTime;
				int remainingMinutes = (int) Math.Ceiling( remainingTime.TotalMinutes );

				pm.SendLocalizedMessage( 1063240, remainingMinutes.ToString() ); // You must wait ~1_HONOR_WAIT~ minutes before embracing honor again
				return;
			}

			pm.SendGump( new HonorSelf( pm ) );

		}

		public static void ActivateEmbrace( PlayerMobile pm )
		{
			int duration = GetHonorDuration( pm );
			int usedPoints;

			if ( pm.Virtues.Honor < 4399)
               			 usedPoints = 400;
			else if ( pm.Virtues.Honor < 10599 )
                		usedPoints = 600;
			else
                		usedPoints = 1000;

			VirtueHelper.Atrophy( pm, VirtueName.Honor, usedPoints );

			pm.HonorActive = true;
			pm.SendLocalizedMessage( 1063235 ); // You embrace your honor

			Timer.DelayCall( TimeSpan.FromSeconds( duration ),
				delegate() {
					pm.HonorActive = false;
					pm.LastHonorUse = DateTime.Now;
					pm.SendLocalizedMessage( 1063236 ); // You no longer embrace your honor
				} );
		}

		private static void Honor( PlayerMobile source, Mobile target )
		{
			IHonorTarget honorTarget = target as IHonorTarget;
			GuardedRegion reg = (GuardedRegion) source.Region.GetRegion( typeof( GuardedRegion ) );
			Map map = source.Map;

			if ( honorTarget == null )
				return;

			if ( honorTarget.ReceivedHonorContext != null )
			{
				if ( honorTarget.ReceivedHonorContext.Source == source )
					return;

				if ( honorTarget.ReceivedHonorContext.CheckDistance() )
				{
					source.SendLocalizedMessage( 1063233 ); // Somebody else is honoring this opponent
					return;
				}
			}

			if ( target.Hits < target.HitsMax )
			{
				source.SendLocalizedMessage( 1063166 ); // You cannot honor this monster because it is too damaged.
				return;
			}

			BaseCreature cret = target as BaseCreature;
			if ( target.Body.IsHuman && (cret == null || (!cret.AlwaysAttackable && !cret.AlwaysMurderer)) )
			{
				if ( map != null && (map.Rules & MapRules.HarmfulRestrictions) == 0 )
				{
					//Allow honor on blue if in Fel
				}
				else
				{
					source.SendLocalizedMessage( 1001018 ); // You cannot perform negative acts
					return;					//cannot honor in trammel town on blue
				}
			}

			if( Core.ML && target is PlayerMobile )
			{
				source.SendLocalizedMessage( 1075614 ); // You cannot honor other players.
				return;
			}

			if ( source.SentHonorContext != null )
				source.SentHonorContext.Cancel();

			new HonorContext( source, target );

			source.Direction = source.GetDirectionTo( target );

			if ( !source.Mounted )
				source.Animate( 32, 5, 1, true, true, 0 );

		}
	}

	public interface IHonorTarget
	{
		HonorContext ReceivedHonorContext{ get; set; }
	}

	public class HonorContext
	{
		private PlayerMobile m_Source;
		private Mobile m_Target;

		private double m_HonorDamage;
		private int m_TotalDamage;

		private int m_Perfection;

		private enum FirstHit
		{
			NotDelivered,
			Delivered,
			Granted
		}

		private FirstHit m_FirstHit;
		private bool m_Poisoned;
		private Point3D m_InitialLocation;
		private Map m_InitialMap;

		private InternalTimer m_Timer;

		public PlayerMobile Source{ get{ return m_Source; } }
		public Mobile Target{ get{ return m_Target; } }

		public HonorContext( PlayerMobile source, Mobile target )
		{
			m_Source = source;
			m_Target = target;

			m_FirstHit = FirstHit.NotDelivered;
			m_Poisoned = false;

			m_InitialLocation = source.Location;
			m_InitialMap = source.Map;

			source.SentHonorContext = this;
			((IHonorTarget)target).ReceivedHonorContext = this;

			m_Timer = new InternalTimer( this );
			m_Timer.Start();
			source.m_hontime = (DateTime.Now + TimeSpan.FromMinutes( 40 ));

			Timer.DelayCall( TimeSpan.FromMinutes( 40 ),
				delegate() {
					if (source.m_hontime < DateTime.Now && source.SentHonorContext != null)
					{
						Cancel();
					}
				} );
		}

		public void OnSourceDamaged( Mobile from, int amount )
		{
			if ( from != m_Target )
				return;

			if ( m_FirstHit == FirstHit.NotDelivered )
				m_FirstHit = FirstHit.Granted;
		}

		public void OnTargetPoisoned()
		{
			m_Poisoned = true; // Set this flag for OnTargetDamaged which will be called next
		}

		public void OnTargetDamaged( Mobile from, int amount )
		{
			if ( m_FirstHit == FirstHit.NotDelivered )
				m_FirstHit = FirstHit.Delivered;

			if ( m_Poisoned )
			{
				m_HonorDamage += amount * 0.8;
				m_Poisoned = false; // Reset the flag

				return;
			}

			m_TotalDamage += amount;

			if ( from == m_Source )
			{
				if ( m_Target.CanSee( m_Source ) && m_Target.InLOS( m_Source ) && ( m_Source.InRange( m_Target, 1 )
					|| ( m_Source.Location == m_InitialLocation && m_Source.Map == m_InitialMap ) ) )
				{
					m_HonorDamage += amount;
				}
				else
				{
					m_HonorDamage += amount * 0.8;
				}
			}
			else if ( from is BaseCreature && ((BaseCreature)from).GetMaster() == m_Source )
			{
				m_HonorDamage += amount * 0.8;
			}
		}

		public void OnTargetHit( Mobile from )
		{
			if ( from != m_Source || m_Perfection == 100 )
				return;

			int bushido = (int) from.Skills.Bushido.Value;
			if ( bushido < 50 )
				return;

			m_Perfection += bushido / 10;

			if ( m_Perfection >= 100 )
			{
				m_Perfection = 100;
				m_Source.SendLocalizedMessage( 1063254 ); // You have Achieved Perfection in inflicting damage to this opponent!
			}
			else
			{
				m_Source.SendLocalizedMessage( 1063255 ); // You gain in Perfection as you precisely strike your opponent.
			}
		}

		public void OnTargetMissed( Mobile from )
		{
			if ( from != m_Source || m_Perfection == 0 )
				return;

			m_Perfection -= 25;

			if ( m_Perfection <= 0 )
			{
				m_Perfection = 0;
				m_Source.SendLocalizedMessage( 1063256 ); // You have lost all Perfection in fighting this opponent.
			}
			else
			{
				m_Source.SendLocalizedMessage( 1063257 ); // You have lost some Perfection in fighting this opponent.
			}
		}

		public void OnSourceBeneficialAction( Mobile to )
		{
			if ( to != m_Target )
				return;

			if ( m_Perfection >= 0 )
			{
				m_Perfection = 0;
				m_Source.SendLocalizedMessage( 1063256 ); // You have lost all Perfection in fighting this opponent.
			}
		}

		public void OnSourceKilled()
		{
			return;
		}

		public void OnTargetKilled()
		{
			Cancel();

			int targetFame = m_Target.Fame;

			if ( m_Perfection > 0 )
			{
				int restore = Math.Min( m_Perfection * ( targetFame + 5000 ) / 25000, 10 );

				m_Source.Hits += restore;
				m_Source.Stam += restore;
				m_Source.Mana += restore;
			}

			if ( m_Source.Virtues.Honor > targetFame )
				return;

			double dGain = ( targetFame / 100 ) * (m_HonorDamage / m_TotalDamage );	//Initial honor gain is 100th of the monsters honor

			if ( m_HonorDamage == m_TotalDamage && m_FirstHit == FirstHit.Granted)
				dGain = dGain * 1.5;							//honor gain is increased alot more if the combat was fully honorable
			else
				dGain = dGain * 0.9;

			int gain = Math.Min( (int)dGain, 200 );

			if ( gain < 1 )
				gain=1;		//Minimum gain of 1 honor when the honor is under the monsters fame

			if ( VirtueHelper.IsHighestPath( m_Source, VirtueName.Honor ) )
			{
				m_Source.SendLocalizedMessage( 1063228 ); // You cannot gain more Honor.
				return;
			}

			bool gainedPath = false;
			if ( VirtueHelper.Award( m_Source, VirtueName.Honor, (int) gain, ref gainedPath ) )
			{
				if ( gainedPath )
					m_Source.SendLocalizedMessage( 1063226 ); // You have gained a path in Honor!
				else
					m_Source.SendLocalizedMessage( 1063225 ); // You have gained in Honor.
			}
		}

		public int PerfectionDamageBonus
		{
			get { return m_Perfection; }
		}

		public int PerfectionLuckBonus
		{
			get{ return (m_Perfection * m_Perfection) / 10; }
		}

		public bool CheckDistance()
		{
			return true;
		}

		public void Cancel()
		{
			m_Source.SentHonorContext = null;
			((IHonorTarget)m_Target).ReceivedHonorContext = null;

			m_Timer.Stop();
		}

		private class InternalTimer : Timer
		{
			private HonorContext m_Context;

			public InternalTimer( HonorContext context ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Context = context;
			}

			protected override void OnTick()
			{
				m_Context.CheckDistance();
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class HorseBreederGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;

		public HorseBreederGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;

			AddPage( 0 );

			AddBackground( 0, 0, 320, 280, 5054 );
			AddBackground( 10, 10, 300, 260, 3000 );

			AddHtmlText( 20, 30, 300, 25, faction.Definition.Header, false, false );

			AddHtmlLocalized( 20, 60, 300, 25, 1018306, false, false ); // Purchase a Faction War Horse
			AddItem( 70, 120, 0x3FFE );

			AddItem( 150, 120, 0xEF2 );
			AddLabel( 190, 122, 0x3E3, FactionWarHorse.SilverPrice.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddItem( 150, 150, 0xEEF );
			AddLabel( 190, 152, 0x3E3, FactionWarHorse.GoldPrice.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 55, 210, 200, 25, 1011011, false, false ); // CONTINUE
			AddButton( 20, 210, 4005, 4007, 1, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 240, 200, 25, 1011012, false, false ); // CANCEL
			AddButton( 20, 240, 4005, 4007, 0, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID != 1 )
				return;

			if ( Faction.Find( m_From ) != m_Faction )
				return;

			Container pack = m_From.Backpack;

			if ( pack == null )
				return;

			FactionWarHorse horse = new FactionWarHorse( m_Faction );

			if ( (m_From.Followers + horse.ControlSlots) > m_From.FollowersMax )
			{
				// TODO: Message?
				horse.Delete();
			}
			else
			{
				if ( pack.GetAmount( typeof( Silver ) ) < FactionWarHorse.SilverPrice )
				{
					sender.Mobile.SendLocalizedMessage( 1042204 ); // You do not have enough silver.
					horse.Delete();
				}
				else if ( pack.GetAmount( typeof( Gold ) ) < FactionWarHorse.GoldPrice )
				{
					sender.Mobile.SendLocalizedMessage( 1042205 ); // You do not have enough gold.
					horse.Delete();
				}
				else if ( pack.ConsumeTotal( typeof( Silver ), FactionWarHorse.SilverPrice ) && pack.ConsumeTotal( typeof( Gold ), FactionWarHorse.GoldPrice ) )
				{
					horse.Controlled = true;
					horse.ControlMaster = m_From;

					horse.ControlOrder = OrderType.Follow;
					horse.ControlTarget = m_From;

					horse.MoveToWorld( m_From.Location, m_From.Map );
				}
				else
				{
					horse.Delete();
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class IceDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public IceDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the ice wyrm";
			Body = 46;
			Hue = 1154;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 60 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;

			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: PackItem( new IcySkinLegs() ); break;
					case 1: PackItem( new IcySkinGloves() ); break;
					case 2: PackItem( new IcySkinGorget() ); break;
					case 3: PackItem( new IcySkinArms() ); break;
					case 4: PackItem( new IcySkinChest() ); break;
					case 5: PackItem( new IcySkinHelm() ); break;
				}
			}

			AddItem( new LighterSource() );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "ice scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Frozen; } else { return HideType.Draconic; } } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public IceDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class JoinStone : BaseSystemController
	{
		private Faction m_Faction;

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Faction
		{
			get{ return m_Faction; }
			set
			{
				m_Faction = value;

				Hue = ( m_Faction == null ? 0 : m_Faction.Definition.HueJoin );
				AssignName( m_Faction == null ? null : m_Faction.Definition.SignupName );
			}
		}

		public override string DefaultName { get { return "faction signup stone"; } }

		[Constructable]
		public JoinStone() : this( null )
		{
		}

		[Constructable]
		public JoinStone( Faction faction ) : base( 0xEDC )
		{
			Movable = false;
			Faction = faction;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Faction == null )
				return;

			if ( !from.InRange( GetWorldLocation(), 2 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
			else if ( FactionGump.Exists( from ) )
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			else if ( Faction.Find( from ) == null && from is PlayerMobile )
				from.SendGump( new JoinStoneGump( (PlayerMobile) from, m_Faction ) );
		}

		public JoinStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Faction = Faction.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class JoinStoneGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;

		public JoinStoneGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;

			AddPage( 0 );

			AddBackground( 0, 0, 550, 440, 5054 );
			AddBackground( 10, 10, 530, 420, 3000 );

			AddHtmlText( 20, 30, 510, 20, faction.Definition.Header, false, false );
			AddHtmlText( 20, 130, 510, 100, faction.Definition.About, true, true );

			AddHtmlLocalized( 20, 60, 100, 20, 1011429, false, false ); // Led By :
			AddHtml( 125, 60, 200, 20, faction.Commander != null ? faction.Commander.Name : "Nobody", false, false );

			AddHtmlLocalized( 20, 80, 100, 20, 1011457, false, false ); // Tithe rate :
			if ( faction.Tithe >= 0 && faction.Tithe <= 100 && (faction.Tithe % 10) == 0 )
				AddHtmlLocalized( 125, 80, 350, 20, 1011480 + (faction.Tithe / 10), false, false );
			else
				AddHtml( 125, 80, 350, 20, faction.Tithe + "%", false, false );

			AddButton( 20, 400, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 55, 400, 200, 20, 1011425, false, false ); // JOIN THIS FACTION

			AddButton( 300, 400, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 335, 400, 200, 20, 1011012, false, false ); // CANCEL
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				m_Faction.OnJoinAccepted( m_From );
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class JungleWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 10 ); }

		[Constructable]
		public JungleWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the jungle wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0x7D1;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Poison, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Green; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public JungleWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;

namespace Server
{
	public class JusticeVirtue
	{
		private static TimeSpan LossDelay = TimeSpan.FromDays( 7.0 );
		private const int LossAmount = 950;

		public static void Initialize()
		{
			VirtueGump.Register( 109, new OnVirtueUsed( OnVirtueUsed ) );
		}

		public static bool CheckMapRegion( Mobile first, Mobile second )
		{
			Map map = first.Map;

			if ( second.Map != map )
				return false;

			return GetMapRegion( map, first.Location ) == GetMapRegion( map, second.Location );
		}

		public static int GetMapRegion( Map map, Point3D loc )
		{
			if ( map == null || map.MapID >= 2 )
				return 0;

			if ( loc.X < 5120 )
				return 0;

			if ( loc.Y < 2304 )
				return 1;

			return 2;
		}

		public static void OnVirtueUsed( Mobile from )
		{
			if ( !from.CheckAlive() )
				return;

			PlayerMobile protector = from as PlayerMobile;

			if ( protector == null )
				return;

			if ( !VirtueHelper.IsSeeker( protector, VirtueName.Justice ) )
			{
				protector.SendLocalizedMessage( 1049610 ); // You must reach the first path in this virtue to invoke it.
			}
			else if ( !protector.CanBeginAction( typeof( JusticeVirtue ) ) )
			{
				protector.SendLocalizedMessage( 1049370 ); // You must wait a while before offering your protection again.
			}
			else if ( protector.JusticeProtectors.Count > 0 )
			{
				protector.SendLocalizedMessage( 1049542 ); // You cannot protect someone while being protected.
			}
			else if ( protector.Map != Map.Lodor )
			{
				protector.SendLocalizedMessage( 1049372 ); // You cannot use this ability here.
			}
			else
			{
				protector.BeginTarget( 14, false, TargetFlags.None, new TargetCallback( OnVirtueTargeted ) );
				protector.SendLocalizedMessage( 1049366 ); // Choose the player you wish to protect.
			}
		}

		public static void OnVirtueTargeted( Mobile from, object obj )
		{
			PlayerMobile protector = from as PlayerMobile;
			PlayerMobile pm = obj as PlayerMobile;

			if ( protector == null )
				return;

			if ( !VirtueHelper.IsSeeker( protector, VirtueName.Justice ) )
				protector.SendLocalizedMessage( 1049610 ); // You must reach the first path in this virtue to invoke it.
			else if ( !protector.CanBeginAction( typeof( JusticeVirtue ) ) )
				protector.SendLocalizedMessage( 1049370 ); // You must wait a while before offering your protection again.
			else if ( protector.JusticeProtectors.Count > 0 )
				protector.SendLocalizedMessage( 1049542 ); // You cannot protect someone while being protected.
			else if ( protector.Map != Map.Lodor )
				protector.SendLocalizedMessage( 1049372 ); // You cannot use this ability here.
			else if ( pm == null )
				protector.SendLocalizedMessage( 1049678 ); // Only players can be protected.
			else if ( pm.Map != Map.Lodor )
				protector.SendLocalizedMessage( 1049372 ); // You cannot use this ability here.
			else if ( pm == protector || pm.Criminal || pm.Kills >= 5 )
				protector.SendLocalizedMessage( 1049436 ); // That player cannot be protected.
			else if ( pm.JusticeProtectors.Count > 0 )
				protector.SendLocalizedMessage( 1049369 ); // You cannot protect that player right now.
			else if ( pm.HasGump( typeof( AcceptProtectorGump ) ) )
				protector.SendLocalizedMessage( 1049369 ); // You cannot protect that player right now.
			else
				pm.SendGump( new AcceptProtectorGump( protector, pm ) );
		}

		public static void OnVirtueAccepted( PlayerMobile protector, PlayerMobile protectee )
		{
			if ( !VirtueHelper.IsSeeker( protector, VirtueName.Justice ) )
			{
				protector.SendLocalizedMessage( 1049610 ); // You must reach the first path in this virtue to invoke it.
			}
			else if ( !protector.CanBeginAction( typeof( JusticeVirtue ) ) )
			{
				protector.SendLocalizedMessage( 1049370 ); // You must wait a while before offering your protection again.
			}
			else if ( protector.JusticeProtectors.Count > 0 )
			{
				protector.SendLocalizedMessage( 1049542 ); // You cannot protect someone while being protected.
			}
			else if ( protector.Map != Map.Lodor )
			{
				protector.SendLocalizedMessage( 1049372 ); // You cannot use this ability here.
			}
			else if ( protectee.Map != Map.Lodor )
			{
				protector.SendLocalizedMessage( 1049372 ); // You cannot use this ability here.
			}
			else if ( protectee == protector || protectee.Criminal || protectee.Kills >= 5 )
			{
				protector.SendLocalizedMessage( 1049436 ); // That player cannot be protected.
			}
			else if ( protectee.JusticeProtectors.Count > 0 )
			{
				protector.SendLocalizedMessage( 1049369 ); // You cannot protect that player right now.
			}
			else
			{
				protectee.JusticeProtectors.Add( protector );

				string args = String.Format( "{0}\t{1}", protector.Name, protectee.Name );

				protectee.SendLocalizedMessage( 1049451, args ); // You are now being protected by ~1_NAME~.
				protector.SendLocalizedMessage( 1049452, args ); // You are now protecting ~2_NAME~.
			}
		}

		public static void OnVirtueRejected( PlayerMobile protector, PlayerMobile protectee )
		{
			string args = String.Format( "{0}\t{1}", protector.Name, protectee.Name );

			protectee.SendLocalizedMessage( 1049453, args ); // You have declined protection from ~1_NAME~.
			protector.SendLocalizedMessage( 1049454, args ); // ~2_NAME~ has declined your protection.

			if ( protector.BeginAction( typeof( JusticeVirtue ) ) )
				Timer.DelayCall( TimeSpan.FromMinutes( 15.0 ), new TimerStateCallback( RejectDelay_Callback ), protector );
		}

		public static void RejectDelay_Callback( object state )
		{
			Mobile m = state as Mobile;

			if ( m != null )
				m.EndAction( typeof( JusticeVirtue ) );
		}

		public static void CheckAtrophy( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return;

			try
			{
				if ( (pm.LastJusticeLoss + LossDelay) < DateTime.Now )
				{
					if ( VirtueHelper.Atrophy( from, VirtueName.Justice, LossAmount ) )
						from.SendLocalizedMessage( 1049373 ); // You have lost some Justice.

					pm.LastJusticeLoss = DateTime.Now;
				}
			}
			catch
			{
			}
		}
	}

	public class AcceptProtectorGump : Gump
	{
		private PlayerMobile m_Protector;
		private PlayerMobile m_Protectee;

		public AcceptProtectorGump( PlayerMobile protector, PlayerMobile protectee ) : base( 150, 50 )
		{
			m_Protector = protector;
			m_Protectee = protectee;

			Closable = false;

			AddPage( 0 );

			AddBackground( 0, 0, 396, 218, 3600 );

			AddImageTiled( 15, 15, 365, 190, 2624 );
			AddAlphaRegion( 15, 15, 365, 190 );

			AddHtmlLocalized( 30, 20, 360, 25, 1049365, 0x7FFF, false, false ); // Another player is offering you their <a href="?ForceTopic88">protection</a>:
			AddLabel( 90, 55, 1153, protector.Name );

			AddImage( 50, 45, 9005 );
			AddImageTiled( 80, 80, 200, 1, 9107 );
			AddImageTiled( 95, 82, 200, 1, 9157 );

			AddRadio( 30, 110, 9727, 9730, true, 1 );
			AddHtmlLocalized( 65, 115, 300, 25, 1049444, 0x7FFF, false, false ); // Yes, I would like their protection.

			AddRadio( 30, 145, 9727, 9730, false, 0 );
			AddHtmlLocalized( 65, 148, 300, 25, 1049445, 0x7FFF, false, false ); // No thanks, I can take care of myself.

			AddButton( 160, 175, 247, 248, 2, GumpButtonType.Reply, 0 );

			AddImage( 215, 0, 50581 );

			AddImageTiled( 15, 14, 365, 1, 9107 );
			AddImageTiled( 380, 14, 1, 190, 9105 );
			AddImageTiled( 15, 205, 365, 1, 9107 );
			AddImageTiled( 15, 14, 1, 190, 9105 );
			AddImageTiled( 0, 0, 395, 1, 9157 );
			AddImageTiled( 394, 0, 1, 217, 9155 );
			AddImageTiled( 0, 216, 395, 1, 9157 );
			AddImageTiled( 0, 0, 1, 217, 9155 );
		}

		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 2 )
			{
				bool okay = info.IsSwitched( 1 );

				if ( okay )
					JusticeVirtue.OnVirtueAccepted( m_Protector, m_Protectee );
				else
					JusticeVirtue.OnVirtueRejected( m_Protector, m_Protectee );
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Network;// using Server.Factions;// using Server.Mobiles;

namespace Server.Factions
{
	public class Keywords
	{
		public static void Initialize()
		{
			EventSink.Speech += new SpeechEventHandler( EventSink_Speech );
		}

		private static void ShowScore_Sandbox( object state )
		{
			PlayerState pl = (PlayerState)state;

			if ( pl != null )
				pl.Mobile.PublicOverheadMessage( MessageType.Regular, pl.Mobile.SpeechHue, true, pl.KillPoints.ToString( "N0" ) ); // NOTE: Added 'N0'
		}

		private static void EventSink_Speech( SpeechEventArgs e )
		{
			Mobile from = e.Mobile;
			int[] keywords = e.Keywords;

			for ( int i = 0; i < keywords.Length; ++i )
			{
				switch ( keywords[i] )
				{
					case 0x00E4: // *i wish to access the city treasury*
					{
						Town town = Town.FromRegion( from.Region );

						if ( town == null || !town.IsFinance( from ) || !from.Alive )
							break;

						if ( FactionGump.Exists( from ) )
							from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
						else if ( town.Owner != null && from is PlayerMobile )
							from.SendGump( new FinanceGump( (PlayerMobile)from, town.Owner, town ) );

						break;
					}
					case 0x0ED: // *i am sheriff*
					{
						Town town = Town.FromRegion( from.Region );

						if ( town == null || !town.IsSheriff( from ) || !from.Alive )
							break;

						if ( FactionGump.Exists( from ) )
							from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
						else if ( town.Owner != null )
							from.SendGump( new SheriffGump( (PlayerMobile)from, town.Owner, town ) );

						break;
					}
					case 0x00EF: // *you are fired*
					{
						Town town = Town.FromRegion( from.Region );

						if ( town == null )
							break;

						if ( town.IsFinance( from ) || town.IsSheriff( from ) )
							town.BeginOrderFiring( from );

						break;
					}
					case 0x00E5: // *i wish to resign as finance minister*
					{
						PlayerState pl = PlayerState.Find( from );

						if ( pl != null && pl.Finance != null )
						{
							pl.Finance.Finance = null;
							from.SendLocalizedMessage( 1005081 ); // You have been fired as Finance Minister
						}

						break;
					}
					case 0x00EE: // *i wish to resign as sheriff*
					{
						PlayerState pl = PlayerState.Find( from );

						if ( pl != null && pl.Sheriff != null )
						{
							pl.Sheriff.Sheriff = null;
							from.SendLocalizedMessage( 1010270 ); // You have been fired as Sheriff
						}

						break;
					}
					case 0x00E9: // *what is my faction term status*
					{
						PlayerState pl = PlayerState.Find( from );

						if ( pl != null && pl.IsLeaving )
						{
							if ( Faction.CheckLeaveTimer( from ) )
								break;

							TimeSpan remaining = ( pl.Leaving + Faction.LeavePeriod ) - DateTime.Now;

							if( remaining.TotalDays >= 1 )
								from.SendLocalizedMessage( 1042743, remaining.TotalDays.ToString( "N0" ) ) ;// Your term of service will come to an end in ~1_DAYS~ days.
							else if( remaining.TotalHours >= 1 )
								from.SendLocalizedMessage( 1042741, remaining.TotalHours.ToString( "N0" ) ); // Your term of service will come to an end in ~1_HOURS~ hours.
							else
								from.SendLocalizedMessage( 1042742 ); // Your term of service will come to an end in less than one hour.
						}
						else if ( pl != null )
						{
							from.SendLocalizedMessage( 1042233 ); // You are not in the process of quitting the faction.
						}

						break;
					}
					case 0x00EA: // *message faction*
					{
						Faction faction = Faction.Find( from );

						if ( faction == null || !faction.IsCommander( from ) )
							break;

						if ( from.AccessLevel == AccessLevel.Player && !faction.FactionMessageReady )
							from.SendLocalizedMessage( 1010264 ); // The required time has not yet passed since the last message was sent
						else
							faction.BeginBroadcast( from );

						break;
					}
					case 0x00EC: // *showscore*
					{
						PlayerState pl = PlayerState.Find( from );

						if ( pl != null )
							Timer.DelayCall( TimeSpan.Zero, new TimerStateCallback( ShowScore_Sandbox ), pl );

						break;
					}
					case 0x0178: // i honor your leadership
					{
						Faction faction = Faction.Find( from );

						if ( faction != null )
							faction.BeginHonorLeadership( from );

						break;
					}
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class LavaDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public LavaDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the fire wyrm";
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0xB71;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;

			if ( 1 == Utility.RandomMinMax( 0, 2 ) )
			{
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: PackItem( new LavaSkinLegs() ); break;
					case 1: PackItem( new LavaSkinGloves() ); break;
					case 2: PackItem( new LavaSkinGorget() ); break;
					case 3: PackItem( new LavaSkinArms() ); break;
					case 4: PackItem( new LavaSkinChest() ); break;
					case 5: PackItem( new LavaSkinHelm() ); break;
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Volcanic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Red ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public LavaDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;

namespace Server.Engines.MyRunUO
{
	public class LayerComparer : IComparer
	{
		private static Layer PlateArms = (Layer)255;
		private static Layer ChainTunic = (Layer)254;
		private static Layer LeatherShorts = (Layer)253;

		private static Layer[] m_DesiredLayerOrder = new Layer[]
		{
			Layer.Cloak,
			Layer.Bracelet,
			Layer.Ring,
			Layer.Shirt,
			Layer.Pants,
			Layer.InnerLegs,
			Layer.Shoes,
			LeatherShorts,
			Layer.Arms,
			Layer.InnerTorso,
			LeatherShorts,
			PlateArms,
			Layer.MiddleTorso,
			Layer.OuterLegs,
			Layer.Neck,
			Layer.Waist,
			Layer.Gloves,
			Layer.OuterTorso,
			Layer.OneHanded,
			Layer.TwoHanded,
			Layer.FacialHair,
			Layer.Hair,
			Layer.Helm,
			Layer.Talisman
		};

		private static int[] m_TranslationTable;

		public static int[] TranslationTable
		{
			get{ return m_TranslationTable; }
		}

		static LayerComparer()
		{
			m_TranslationTable = new int[256];

			for ( int i = 0; i < m_DesiredLayerOrder.Length; ++i )
				m_TranslationTable[(int)m_DesiredLayerOrder[i]] = m_DesiredLayerOrder.Length - i;
		}

		public static bool IsValid( Item item )
		{
			return ( m_TranslationTable[(int)item.Layer] > 0 );
		}

		public static readonly IComparer Instance = new LayerComparer();

		public LayerComparer()
		{
		}

		public Layer Fix( int itemID, Layer oldLayer )
		{
			if ( itemID == 0x1410 || itemID == 0x1417 ) // platemail arms
				return PlateArms;

			if ( itemID == 0x13BF || itemID == 0x13C4 ) // chainmail tunic
				return ChainTunic;

			if ( itemID == 0x1C08 || itemID == 0x1C09 ) // leather skirt
				return LeatherShorts;

			if ( itemID == 0x1C00 || itemID == 0x1C01 ) // leather shorts
				return LeatherShorts;

			return oldLayer;
		}

		public int Compare( object x, object y )
		{
			Item a = (Item)x;
			Item b = (Item)y;

			Layer aLayer = a.Layer;
			Layer bLayer = b.Layer;

			aLayer = Fix( a.ItemID, aLayer );
			bLayer = Fix( b.ItemID, bLayer );

			return m_TranslationTable[(int)bLayer] - m_TranslationTable[(int)aLayer];
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Guilds;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class LeaveFactionGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;

		public LeaveFactionGump( PlayerMobile from, Faction faction ) : base( 20, 30 )
		{
			m_From = from;
			m_Faction = faction;

			AddBackground( 0, 0, 270, 120, 5054 );
			AddBackground( 10, 10, 250, 100, 3000 );

			if ( from.Guild is Guild && ((Guild)from.Guild).Leader == from )
				AddHtmlLocalized( 20, 15, 230, 60, 1018057, true, true ); // Are you sure you want your entire guild to leave this faction?
			else
				AddHtmlLocalized( 20, 15, 230, 60, 1018063, true, true ); // Are you sure you want to leave this faction?

			AddHtmlLocalized( 55, 80, 75, 20, 1011011, false, false ); // CONTINUE
			AddButton( 20, 80, 4005, 4007, 1, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 170, 80, 75, 20, 1011012, false, false ); // CANCEL
			AddButton( 135, 80, 4005, 4007, 2, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			switch ( info.ButtonID )
			{
				case 1: // continue
				{
					Guild guild = m_From.Guild as Guild;

					if ( guild == null )
					{
						PlayerState pl = PlayerState.Find( m_From );

						if ( pl != null )
						{
							pl.Leaving = DateTime.Now;

							if ( Faction.LeavePeriod == TimeSpan.FromDays( 3.0 ) )
								m_From.SendLocalizedMessage( 1005065 ); // You will be removed from the faction in 3 days
							else
								m_From.SendMessage( "You will be removed from the faction in {0} days.", Faction.LeavePeriod.TotalDays );
						}
					}
					else if ( guild.Leader != m_From )
					{
						m_From.SendLocalizedMessage( 1005061 ); // You cannot quit the faction because you are not the guild master
					}
					else
					{
						m_From.SendLocalizedMessage( 1042285 ); // Your guild is now quitting the faction.

						for ( int i = 0; i < guild.Members.Count; ++i )
						{
							Mobile mob = (Mobile) guild.Members[i];
							PlayerState pl = PlayerState.Find( mob );

							if ( pl != null )
							{
								pl.Leaving = DateTime.Now;

								if ( Faction.LeavePeriod == TimeSpan.FromDays( 3.0 ) )
									mob.SendLocalizedMessage( 1005060 ); // Your guild will quit the faction in 3 days
								else
									mob.SendMessage( "Your guild will quit the faction in {0} days.", Faction.LeavePeriod.TotalDays );
							}
						}
					}

					break;
				}
				case 2: // cancel
				{
					m_From.SendLocalizedMessage( 500737 ); // Canceled resignation.
					break;
				}
			}
		}
	}
}
// using Server;// using System;// using Server.Misc;// using Server.Mobiles;

namespace Server.Items
{
	public class AncientFarmersKasa : Kasa
	{
		public override int LabelNumber{ get{ return 1070922; } } // Ancient Farmer's Kasa
		public override int BaseColdResistance { get { return 19; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get { return 255; } }

		[Constructable]
		public AncientFarmersKasa() : base()
		{
			Attributes.BonusStr = 5;
			Attributes.BonusStam = 5;
			Attributes.RegenStam = 5;

			SkillBonuses.SetValues( 0, SkillName.Druidism, 5.0 );
		}

		public AncientFarmersKasa( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version <= 1 )
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}

			if( version == 0 )
				SkillBonuses.SetValues( 0, SkillName.Druidism, 5.0 );
		}
	}

	public class AncientSamuraiDo : PlateDo
	{
		public override int LabelNumber { get { return 1070926; } } // Ancient Samurai Do

		public override int BasePhysicalResistance { get { return 15; } }
		public override int BaseFireResistance { get { return 12; } }
		public override int BaseColdResistance { get { return 10; } }
		public override int BasePoisonResistance { get { return 11; } }
		public override int BaseEnergyResistance { get { return 8; } }

		[Constructable]
		public AncientSamuraiDo() : base()
		{
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
			SkillBonuses.SetValues( 0, SkillName.Parry, 10.0 );
		}

		public AncientSamuraiDo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class ArmsOfTacticalExcellence : LeatherHiroSode
	{
		public override int LabelNumber { get { return 1070921; } } // Arms of Tactical Excellence

		public override int BaseFireResistance { get { return 9; } }
		public override int BaseColdResistance { get { return 13; } }
		public override int BasePoisonResistance { get { return 8; } }

		[Constructable]
		public ArmsOfTacticalExcellence() : base()
		{
			Attributes.BonusDex = 5;
			SkillBonuses.SetValues( 0, SkillName.Tactics, 12.0 );
		}

		public ArmsOfTacticalExcellence( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class BlackLotusHood : ClothNinjaHood
	{
		public override int LabelNumber { get { return 1070919; } } // Black Lotus Hood

		public override int BasePhysicalResistance { get { return 0; } }
		public override int BaseFireResistance { get { return 11; } }
		public override int BaseColdResistance { get { return 15; } }
		public override int BasePoisonResistance { get { return 11; } }
		public override int BaseEnergyResistance { get { return 11; } }

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }

		[Constructable]
		public BlackLotusHood() : base()
		{
			Attributes.LowerManaCost = 6;
			Attributes.AttackChance = 6;
			ClothingAttributes.SelfRepair = 5;
		}

		public BlackLotusHood( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version == 0 )
			{
				MaxHitPoints = 255;
				HitPoints = 255;
			}
		}
	}

	public class DaimyosHelm : PlateBattleKabuto
	{
		public override int LabelNumber { get { return 1070920; } } // Daimyo's Helm

		public override int BaseColdResistance { get { return 10; } }

		[Constructable]
		public DaimyosHelm() : base()
		{
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
			ArmorAttributes.SelfRepair = 3;
			Attributes.WeaponSpeed = 10;
		}

		public DaimyosHelm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class DemonForks : Sai
	{
		public override int LabelNumber{ get{ return 1070917; } } // Demon Forks

		[Constructable]
		public DemonForks() : base()
		{
			WeaponAttributes.ResistFireBonus = 10;
			WeaponAttributes.ResistPoisonBonus = 10;

			Attributes.ReflectPhysical = 10;
			Attributes.WeaponDamage = 35;
			Attributes.DefendChance = 10;
		}

		public DemonForks( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class DragonNunchaku : Nunchaku
	{
		public override int LabelNumber{ get{ return 1070914; } } // Dragon Nunchaku

		[Constructable]
		public DragonNunchaku() : base()
		{
			WeaponAttributes.ResistFireBonus = 5;
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitFireball = 50;

			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 20;
		}

		public DragonNunchaku( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class Exiler : Tetsubo
	{
		public override int LabelNumber{ get{ return 1070913; } } // Exiler

		[Constructable]
		public Exiler() : base()
		{
			WeaponAttributes.HitDispel = 33;
			Slayer = SlayerName.Exorcism;

			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 20;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = chaos = direct = 0;

			nrgy = 100;
		}

		public Exiler( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class GlovesOfTheSun : LeatherNinjaMitts
	{
		public override int LabelNumber { get { return 1070924; } } // Gloves of the Sun

		public override int BaseFireResistance { get { return 24; } }

		[Constructable]
		public GlovesOfTheSun() : base()
		{
			Attributes.RegenHits = 2;
			Attributes.NightSight = 1;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 18;
		}

		public GlovesOfTheSun( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class HanzosBow : Yumi
	{
		public override int LabelNumber { get { return 1070918; } } // Hanzo's Bow

		[Constructable]
		public HanzosBow() : base()
		{
			WeaponAttributes.HitLeechHits = 40;
			WeaponAttributes.SelfRepair = 3;

			Attributes.WeaponDamage = 50;

			SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10 );
		}

		public HanzosBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class LegsOfStability : PlateSuneate
	{
		public override int LabelNumber { get { return 1070925; } } // Legs of Stability

		public override int BasePhysicalResistance { get { return 20; } }
		public override int BasePoisonResistance { get { return 18; } }

		[Constructable]
		public LegsOfStability() : base()
		{
			Attributes.BonusStam = 5;

			ArmorAttributes.SelfRepair = 3;
			ArmorAttributes.LowerStatReq = 100;
			ArmorAttributes.MageArmor = 1;
		}

		public LegsOfStability( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class PeasantsBokuto : Bokuto
	{
		public override int LabelNumber { get { return 1070912; } } // Peasant's Bokuto

		[Constructable]
		public PeasantsBokuto() : base()
		{
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitLowerDefend = 30;

			Attributes.WeaponDamage = 35;
			Attributes.WeaponSpeed = 10;
			Slayer = SlayerName.SnakesBane;
		}

		public PeasantsBokuto( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class PilferedDancerFans : Tessen
	{
		public override int LabelNumber { get { return 1070916; } } // Pilfered Dancer Fans

		[Constructable]
		public PilferedDancerFans() : base()
		{
			Attributes.WeaponDamage = 20;
			Attributes.WeaponSpeed = 20;
			Attributes.CastRecovery = 2;
			Attributes.DefendChance = 5;
			Attributes.SpellChanneling = 1;
		}

		public PilferedDancerFans( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class TheDestroyer : NoDachi
	{
		public override int LabelNumber { get { return 1070915; } } // The Destroyer

		[Constructable]
		public TheDestroyer() : base()
		{
			WeaponAttributes.HitLeechStam = 40;

			Attributes.BonusStr = 6;
			Attributes.AttackChance = 10;
			Attributes.WeaponDamage = 50;
		}

		public TheDestroyer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	public class TomeOfEnlightenment : Spellbook
	{
		public override int LabelNumber { get { return 1070934; } } // Tome of Enlightenment

		[Constructable]
		public TomeOfEnlightenment() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x455;

			Attributes.BonusInt = 5;
			Attributes.SpellDamage = 10;
			Attributes.CastSpeed = 1;
		}

		public TomeOfEnlightenment( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class LeurociansMempoOfFortune : LeatherMempo
	{
		public override int LabelNumber { get { return 1071460; } } // Leurocian's mempo of fortune

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public LeurociansMempoOfFortune() : base()
		{
			LootType = LootType.Regular;
			Hue = 0x501;

			Attributes.Luck = 300;
			Attributes.RegenMana = 1;
		}

		public LeurociansMempoOfFortune( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
		public override int InitMinHits { get { return 255; } }
		public override int InitMaxHits { get { return 255; } }
	}

	//Non weapon/armor ones:

	public class AncientUrn : Item
	{
		private static string[] m_Names = new string[]
			{
				"Akira",
				"Avaniaga",
				"Aya",
				"Chie",
				"Emiko",
				"Fumiyo",
				"Gennai",
				"Gennosuke",
				"Genjo",
				"Hamato",
				"Harumi",
				"Ikuyo",
				"Juri",
				"Kaori",
				"Kaoru",
				"Kiyomori",
				"Mayako",
				"Motoki",
				"Musashi",
				"Nami",
				"Nobukazu",
				"Roku",
				"Romi",
				"Ryo",
				"Sanzo",
				"Sakamae",
				"Satoshi",
				"Takamori",
				"Takuro",
				"Teruyo",
				"Toshiro",
				"Yago",
				"Yeijiro",
				"Yoshi",
				"Zeshin"
			};

		public static string[] Names { get { return m_Names; } }

		private string m_UrnName;

		[CommandProperty( AccessLevel.GameMaster )]
		public string UrnName
		{
			get { return m_UrnName; }
			set { m_UrnName = value; }
		}

		public override int LabelNumber { get { return 1071014; } } // Ancient Urn

		[Constructable]
		public AncientUrn( string urnName ) : base( 0x241D )
		{
			m_UrnName = urnName;
			Weight = 1.0;
		}

		[Constructable]
		public AncientUrn() : this( m_Names[Utility.Random( m_Names.Length )] )
		{
		}

		public AncientUrn( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
			writer.Write( m_UrnName );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_UrnName = reader.ReadString();

			Utility.Intern( ref m_UrnName );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( 1070935, m_UrnName ); // Ancient Urn of ~1_name~
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, 1070935, m_UrnName ); // Ancient Urn of ~1_name~
		}

	}

	public class HonorableSwords : Item
	{
		private string m_SwordsName;

		[CommandProperty( AccessLevel.GameMaster )]
		public string SwordsName
		{
			get { return m_SwordsName; }
			set { m_SwordsName = value; }
		}

		public override int LabelNumber { get { return 1071015; } } // Honorable Swords

		[Constructable]
		public HonorableSwords( string swordsName ) : base( 0x2853 )
		{
			m_SwordsName = swordsName;

			Weight = 5.0;
		}

		[Constructable]
		public HonorableSwords() : this( AncientUrn.Names[Utility.Random( AncientUrn.Names.Length )] )
		{
		}

		public HonorableSwords( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
			writer.Write( m_SwordsName );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_SwordsName = reader.ReadString();

			Utility.Intern( ref m_SwordsName );
		}

		public override void AddNameProperty( ObjectPropertyList list )
		{
			list.Add( 1070936, m_SwordsName ); // Honorable Swords of ~1_name~
		}

		public override void OnSingleClick( Mobile from )
		{
			LabelTo( from, 1070936, m_SwordsName ); // Honorable Swords of ~1_name~
		}
	}

	[Furniture]
	[Flipable( 0x2811, 0x2812 )]
	public class ChestOfHeirlooms : LockableContainer
	{
		public override int LabelNumber{ get{ return 1070937; } } // Chest of heirlooms

		[Constructable]
		public ChestOfHeirlooms() : base( 0x2811 )
		{
			Locked = true;
			LockLevel = 95;
			MaxLockLevel = 140;
			RequiredSkill = 95;

			TrapType = TrapType.ExplosionTrap;
			TrapLevel = 10;
			TrapPower = 100;

			GumpID = 0x10C;

			for ( int i = 0; i < 10; ++i )
			{
				Item item = Loot.ChestOfHeirloomsContains();

				int attributeCount = Utility.RandomMinMax( 1, 5 );
				int min = 20;
				int max = 80;

				if ( item is BaseWeapon )
				{
					BaseWeapon weapon = (BaseWeapon)item;

					if ( Core.AOS )
						BaseRunicTool.ApplyAttributesTo( weapon, attributeCount, min, max );
					else
					{
						weapon.DamageLevel = (WeaponDamageLevel)Utility.Random( 6 );
						weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random( 6 );
						weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random( 6 );
					}
				}
				else if ( item is BaseArmor )
				{
					BaseArmor armor = (BaseArmor)item;

					if ( Core.AOS )
						BaseRunicTool.ApplyAttributesTo( armor, attributeCount, min, max );
					else
					{
						armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random( 6 );
						armor.Durability = (ArmorDurabilityLevel)Utility.Random( 6 );
					}
				}
				else if( item is BaseHat && Core.AOS )
					BaseRunicTool.ApplyAttributesTo( (BaseHat)item, attributeCount, min, max );
				else if( item is BaseJewel && Core.AOS )
					BaseRunicTool.ApplyAttributesTo( (BaseJewel)item, attributeCount, min, max );

				DropItem( item );
			}
		}

		public ChestOfHeirlooms( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class FluteOfRenewal : BambooFlute
	{
		public override int LabelNumber { get { return 1070927; } } // Flute of Renewal

		[Constructable]
		public FluteOfRenewal() : base()
		{
			Slayer = SlayerGroup.Groups[Utility.Random( SlayerGroup.Groups.Length )].Super.Name;

			ReplenishesCharges = true;
		}

		public override int InitMinUses { get { return 300; } }
		public override int InitMaxUses { get { return 300; } }

		public FluteOfRenewal( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if( version == 0 && Slayer == SlayerName.Fey )
				Slayer = SlayerGroup.Groups[Utility.Random( SlayerGroup.Groups.Length )].Super.Name;
		}
	}

	public enum LesserPigmentType
	{
		None,
		PaleOrange,
		FreshRose,
		ChaosBlue,
		Silver,
		NobleGold,
		LightGreen,
		PaleBlue,
		FreshPlum,
		DeepBrown,
		BurntBrown
	}

	public class LesserPigmentsOfIslesDread : BasePigmentsOfIslesDread
	{

		private static int[][] m_Table = new int[][]
		{
			// Hue, Label
			new int[]{ /*PigmentType.None,*/ 0, -1 },
			new int[]{ /*PigmentType.PaleOrange,*/ 0x02E, 1071458 },
			new int[]{ /*PigmentType.FreshRose,*/ 0x4B9, 1071455 },
			new int[]{ /*PigmentType.ChaosBlue,*/ 0x005, 1071459 },
			new int[]{ /*PigmentType.Silver,*/ 0x3E9, 1071451 },
			new int[]{ /*PigmentType.NobleGold,*/ 0x227, 1071457 },
			new int[]{ /*PigmentType.LightGreen,*/ 0x1C8, 1071454 },
			new int[]{ /*PigmentType.PaleBlue,*/ 0x24F, 1071456 },
			new int[]{ /*PigmentType.FreshPlum,*/ 0x145, 1071450 },
			new int[]{ /*PigmentType.DeepBrown,*/ 0x3F0, 1071452 },
			new int[]{ /*PigmentType.BurntBrown,*/ 0x41A, 1071453 }
		};

		public static int[] GetInfo( LesserPigmentType type )
		{
			int v = (int)type;

			if( v < 0 || v >= m_Table.Length )
				v = 0;

			return m_Table[v];
		}

		private LesserPigmentType m_Type;

		[CommandProperty( AccessLevel.GameMaster )]
		public LesserPigmentType Type
		{
			get { return m_Type; }
			set
			{
				m_Type = value;

				int v = (int)m_Type;

				if ( v >= 0 && v < m_Table.Length )
				{
					Hue = m_Table[v][0];
					Label = m_Table[v][1];
				}
				else
				{
					Hue = 0;
					Label = -1;
				}
			}
		}

		[Constructable]
		public LesserPigmentsOfIslesDread() : this( (LesserPigmentType)Utility.Random(0,11) )
		{
		}

		[Constructable]
		public LesserPigmentsOfIslesDread( LesserPigmentType type ) : base( 1 )
		{
			Weight = 1.0;
			Type = type;
		}

		public LesserPigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)1 );

			writer.WriteEncodedInt( (int)m_Type );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = ( InheritsItem ? 0 : reader.ReadInt() ); // Required for BasePigmentsOfIslesDread insertion

			switch ( version )
			{
				case 1: Type = (LesserPigmentType)reader.ReadEncodedInt(); break;
				case 0: break;
			}
		}
	}

	public class MetalPigmentsOfIslesDread : BasePigmentsOfIslesDread
	{
		[Constructable]
		public MetalPigmentsOfIslesDread() : base( 1 )
		{
			RandomHue();
			Label = -1;
		}

		public MetalPigmentsOfIslesDread( Serial serial ) : base( serial )
		{
		}

		public void RandomHue()
		{
			int a = Utility.Random(0,30);
			if ( a != 0 )
				Hue = a + 0x960;
			else
				Hue = 0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = ( InheritsItem ? 0 : reader.ReadInt() ); // Required for BasePigmentsOfIslesDread insertion
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class Lion : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Lion() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lion";
			Body = 187;
			BaseSoundID = 0x3EE;

			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );

			SetHits( 64, 88 );
			SetMana( 0 );

			SetDamage( 8, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 750;
			Karma = 0;

			VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public Lion(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
			Body = 187;
		}
	}
}
// using System;

namespace Server.Factions
{
	public class Renika : Town
	{
		public Renika()
		{
			Definition =
				new TownDefinition(
					7,
					0x1870,
					"Renika",
					"Renika",
					new TextDefinition( 1011440, "Renika" ),
					new TextDefinition( 1011568, "TOWN STONE FOR Renika" ),
					new TextDefinition( 1041041, "The Faction Sigil Monolith of Renika" ),
					new TextDefinition( 1041411, "The Faction Town Sigil Monolith of Renika" ),
					new TextDefinition( 1041420, "Faction Town Stone of Renika" ),
					new TextDefinition( 1041402, "Faction Town Sigil of Renika" ),
					new TextDefinition( 1041393, "Corrupted Faction Town Sigil of Renika" ),
					new Point3D( 3714, 2235, 20 ),
					new Point3D( 3712, 2230, 20 ) );
		}
	}
}
// using System;

namespace Server.Factions
{
	public enum MerchantTitle
	{
		None,
		Scribe,
		Carpenter,
		Blacksmith,
		Bowyer,
		Tialor
	}

	public class MerchantTitleInfo
	{
		private SkillName m_Skill;
		private double m_Requirement;
		private TextDefinition m_Title;
		private TextDefinition m_Label;
		private TextDefinition m_Assigned;

		public SkillName Skill{ get{ return m_Skill; } }
		public double Requirement{ get{ return m_Requirement; } }
		public TextDefinition Title{ get{ return m_Title; } }
		public TextDefinition Label{ get{ return m_Label; } }
		public TextDefinition Assigned{ get{ return m_Assigned; } }

		public MerchantTitleInfo( SkillName skill, double requirement, TextDefinition title, TextDefinition label, TextDefinition assigned )
		{
			m_Skill = skill;
			m_Requirement = requirement;
			m_Title = title;
			m_Label = label;
			m_Assigned = assigned;
		}
	}

	public class MerchantTitles
	{
		private static MerchantTitleInfo[] m_Info = new MerchantTitleInfo[]
			{
				new MerchantTitleInfo( SkillName.Inscribe,		90.0,	new TextDefinition( 1060773, "Scribe" ),		new TextDefinition( 1011468, "SCRIBE" ),		new TextDefinition( 1010121, "You now have the faction title of scribe" ) ),
				new MerchantTitleInfo( SkillName.Carpentry,		90.0,	new TextDefinition( 1060774, "Carpenter" ),		new TextDefinition( 1011469, "CARPENTER" ),		new TextDefinition( 1010122, "You now have the faction title of carpenter" ) ),
				new MerchantTitleInfo( SkillName.Tinkering,		90.0,	new TextDefinition( 1022984, "Tinker" ),		new TextDefinition( 1011470, "TINKER" ),		new TextDefinition( 1010123, "You now have the faction title of tinker" ) ),
				new MerchantTitleInfo( SkillName.Blacksmith,	90.0,	new TextDefinition( 1023016, "Blacksmith" ),	new TextDefinition( 1011471, "BLACKSMITH" ),	new TextDefinition( 1010124, "You now have the faction title of blacksmith" ) ),
				new MerchantTitleInfo( SkillName.Bowcraft,		90.0,	new TextDefinition( 1023022, "Bowyer" ),		new TextDefinition( 1011472, "BOWYER" ),		new TextDefinition( 1010125, "You now have the faction title of Bowyer" ) ),
				new MerchantTitleInfo( SkillName.Tailoring,		90.0,	new TextDefinition( 1022982, "Tailor" ),		new TextDefinition( 1018300, "TAILOR" ),		new TextDefinition( 1042162, "You now have the faction title of Tailor" ) ),
			};

		public static MerchantTitleInfo[] Info{ get{ return m_Info; } }

		public static MerchantTitleInfo GetInfo( MerchantTitle title )
		{
			int idx = (int)title - 1;

			if ( idx >= 0 && idx < m_Info.Length )
				return m_Info[idx];

			return null;
		}

		public static bool HasMerchantQualifications( Mobile mob )
		{
			for ( int i = 0; i < m_Info.Length; ++i )
			{
				if ( IsQualified( mob, m_Info[i] ) )
					return true;
			}

			return false;
		}

		public static bool IsQualified( Mobile mob, MerchantTitle title )
		{
			return IsQualified( mob, GetInfo( title ) );
		}

		public static bool IsQualified( Mobile mob, MerchantTitleInfo info )
		{
			if ( mob == null || info == null )
				return false;

			return ( mob.Skills[info.Skill].Value >= info.Requirement );
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class MetalDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public MetalDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a metallic dragon";
			Body = 59;
			BaseSoundID = 362;
			Hue = MaterialInfo.GetMaterialColor( "copper", "monster", Hue );

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnAfterSpawn()
		{
			bool IsChromatic = false;
			switch ( Utility.RandomMinMax( 0, 20 ) )
			{
				case 0: Hue = MaterialInfo.GetMaterialColor( "jade", "monster", 0 ); IsChromatic = true; break;  // jade
				case 1: Hue = MaterialInfo.GetMaterialColor( "onyx", "monster", 0 ); IsChromatic = true; break;  // onyx
				case 2: Hue = MaterialInfo.GetMaterialColor( "quartz", "monster", 0 ); IsChromatic = true; break;  // quartz
				case 3: Hue = MaterialInfo.GetMaterialColor( "ruby", "monster", 0 ); IsChromatic = true; break;  // ruby
				case 4: Hue = MaterialInfo.GetMaterialColor( "sapphire", "monster", 0 ); IsChromatic = true; break;  // sapphire
				case 5: Hue = MaterialInfo.GetMaterialColor( "spinel", "monster", 0 ); IsChromatic = true; break;  // spinel
				case 6: Hue = MaterialInfo.GetMaterialColor( "topaz", "monster", 0 ); IsChromatic = true; break;  // topaz
				case 7: Hue = MaterialInfo.GetMaterialColor( "amethyst", "monster", 0 ); IsChromatic = true; break;  // amethyst
				case 8: Hue = MaterialInfo.GetMaterialColor( "emerald", "monster", 0 ); IsChromatic = true; break;  // emerald
				case 9: Hue = MaterialInfo.GetMaterialColor( "garnet", "monster", 0 ); IsChromatic = true; break;  // garnet
				case 10: Hue = MaterialInfo.GetMaterialColor( "silver", "monster", 0 ); break;  // silver
				case 11: Hue = MaterialInfo.GetMaterialColor( "star ruby", "monster", 0 ); IsChromatic = true; break; // star ruby
				case 12: Hue = MaterialInfo.GetMaterialColor( "copper", "monster", Hue ); break; // Copper
				case 13: Hue = MaterialInfo.GetMaterialColor( "verite", "monster", Hue ); break; // Verite
				case 14: Hue = MaterialInfo.GetMaterialColor( "valorite", "monster", Hue ); break; // Valorite
				case 15: Hue = MaterialInfo.GetMaterialColor( "agapite", "monster", Hue ); break; // Agapite
				case 16: Hue = MaterialInfo.GetMaterialColor( "bronze", "monster", Hue ); break; // Bronze
				case 17: Hue = MaterialInfo.GetMaterialColor( "dull copper", "monster", Hue ); break; // Dull Copper
				case 18: Hue = MaterialInfo.GetMaterialColor( "gold", "monster", Hue ); break; // Gold
				case 19: Hue = MaterialInfo.GetMaterialColor( "shadow iron", "monster", Hue ); break; // Shadow Iron
				case 20:
					if ( Worlds.IsExploringSeaAreas( this ) == true ){ Hue = MaterialInfo.GetMaterialColor( "nepturite", "monster", 0 ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Savaged Empire" ){ Hue = MaterialInfo.GetMaterialColor( "steel", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" ){ Hue = MaterialInfo.GetMaterialColor( "obsidian", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Island of Umber Veil" ){ Hue = MaterialInfo.GetMaterialColor( "brass", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" && this.Map == Map.SavagedEmpire ){ Hue = MaterialInfo.GetMaterialColor( "xormite", "monster", Hue ); }
					else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" ){ Hue = MaterialInfo.GetMaterialColor( "copper", "mithril", Hue ); }
					break; // Special
			}

			if ( IsChromatic ){ this.Name = "a chromatic dragon"; }

			base.OnAfterSpawn();
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			string metal = "Iron";

			if ( this.Hue == MaterialInfo.GetMaterialColor( "onyx", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "onyx scales" );
				c.DropItem(scale);
				metal = "Onyx";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "quartz", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "quartz scales" );
				c.DropItem(scale);
				metal = "Quartz";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "ruby", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "ruby scales" );
				c.DropItem(scale);
				metal = "Ruby";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "sapphire", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "sapphire scales" );
				c.DropItem(scale);
				metal = "Sapphire";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "spinel", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "spinel scales" );
				c.DropItem(scale);
				metal = "Spinel";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "topaz", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "topaz scales" );
				c.DropItem(scale);
				metal = "Topaz";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "amethyst", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "amethyst scales" );
				c.DropItem(scale);
				metal = "Amethyst";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "emerald", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "emerald scales" );
				c.DropItem(scale);
				metal = "Emerald";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "garnet", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "garnet scales" );
				c.DropItem(scale);
				metal = "Garnet";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "silver", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "silver scales" );
				c.DropItem(scale);
				metal = "Silver";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "star ruby", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "star ruby scales" );
				c.DropItem(scale);
				metal = "Star Ruby";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "jade", "monster", 0 ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "jade scales" );
				c.DropItem(scale);
				metal = "Jade";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "copper", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "copper scales" );
				c.DropItem(scale);
				metal = "Copper";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "verite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "verite scales" );
				c.DropItem(scale);
				metal = "Verite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "valorite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "valorite scales" );
				c.DropItem(scale);
				metal = "Valorite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "agapite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "agapite scales" );
				c.DropItem(scale);
				metal = "Agapite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "bronze", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "bronze scales" );
				c.DropItem(scale);
				metal = "Bronze";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "dull copper", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "dull copper scales" );
				c.DropItem(scale);
				metal = "Dull Copper";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "gold", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "gold scales" );
				c.DropItem(scale);
				metal = "Golden";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "shadow iron", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "shadow iron scales" );
				c.DropItem(scale);
				metal = "Shadow Iron";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "brass", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "brass scales" );
				c.DropItem(scale);
				metal = "Brass";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "steel", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "steel scales" );
				c.DropItem(scale);
				metal = "Steel";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "mithril", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "mithril scales" );
				c.DropItem(scale);
				metal = "Mithril";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "xormite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "xormite scales" );
				c.DropItem(scale);
				metal = "Xormite";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "obsidian", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "obsidian scales" );
				c.DropItem(scale);
				metal = "Obsidian";
			}
			else if ( this.Hue == MaterialInfo.GetMaterialColor( "nepturite", "monster", Hue ) )
			{
				Item scale = new HardScales( Utility.RandomMinMax( 10, 50 ), "nepturite scales" );
				c.DropItem(scale);
				metal = "Nepturite";
			}

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", metal, "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public MetalDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class Minax : Faction
	{
		private static Faction m_Instance;

		public static Faction Instance{ get{ return m_Instance; } }

		public Minax()
		{
			m_Instance = this;

			Definition =
				new FactionDefinition(
					0,
					1645, // dark red
					1109, // shadow
					1645, // join stone : dark red
					1645, // broadcast : dark red
					0x78, 0x3EAF, // war horse
					"Minax", "minax", "Min",
					new TextDefinition( 1011534, "MINAX" ),
					new TextDefinition( 1060769, "Minax faction" ),
					new TextDefinition( 1011421, "<center>FOLLOWERS OF MINAX</center>" ),
					new TextDefinition( 1011448,
						"The followers of Minax have taken control in the old lands, " +
						"and intend to hold it for as long as they can. Allying themselves " +
						"with orcs, headless, gazers, trolls, and other beasts, they seek " +
						"revenge against Lord British, for slights both real and imagined, " +
						"though some of the followers wish only to wreak havoc on the " +
						"unsuspecting populace." ),
					new TextDefinition( 1011453, "This city is controlled by Minax." ),
					new TextDefinition( 1042252, "This sigil has been corrupted by the Followers of Minax" ),
					new TextDefinition( 1041043, "The faction signup stone for the Followers of Minax" ),
					new TextDefinition( 1041381, "The Faction Stone of Minax" ),
					new TextDefinition( 1011463, ": Minax" ),
					new TextDefinition( 1005190, "Followers of Minax will now be ignored." ),
					new TextDefinition( 1005191, "Followers of Minax will now be told to go away." ),
					new TextDefinition( 1005192, "Followers of Minax will now be hanged by their toes." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 )
						},
						new Point3D( 1172, 2593, 0 ),
						new Point3D( 1117, 2587, 18 ),
						new Point3D[]
						{
							new Point3D( 1113, 2601, 18 ),
							new Point3D( 1113, 2598, 18 ),
							new Point3D( 1113, 2595, 18 ),
							new Point3D( 1113, 2592, 18 ),
							new Point3D( 1116, 2601, 18 ),
							new Point3D( 1116, 2598, 18 ),
							new Point3D( 1116, 2595, 18 ),
							new Point3D( 1116, 2592, 18 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060784, "Avenger of Mondain" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060783, "Dread Knight" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060782, "Warlord" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060782, "Warlord" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060781, "Executioner" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060781, "Executioner" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060781, "Executioner" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060780, "Defiler" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060780, "Defiler" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060780, "Defiler" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionBerserker ),	0x0F4B, 7000, 3000, 10,		new TextDefinition( 1011505, "BERSERKER" ),		new TextDefinition( 1011499, "Hire Berserker" ) ),
						new GuardDefinition( typeof( FactionDragoon ),		0x1439, 8000, 4000, 10,		new TextDefinition( 1011506, "DRAGOON" ),		new TextDefinition( 1011500, "Hire Dragoon" ) ),
					}
				);
		}
	}
}
// using System;

namespace Server.Factions
{
	public class Montor : Town
	{
		public Montor()
		{
			Definition =
				new TownDefinition(
					2,
					0x186B,
					"Montor",
					"Montor",
					new TextDefinition( 1011437, "Montor" ),
					new TextDefinition( 1011564, "TOWN STONE FOR Montor" ),
					new TextDefinition( 1041036, "The Faction Sigil Monolith of Montor" ),
					new TextDefinition( 1041406, "The Faction Town Sigil Monolith Montor" ),
					new TextDefinition( 1041415, "Faction Town Stone of Montor" ),
					new TextDefinition( 1041397, "Faction Town Sigil of Montor" ),
					new TextDefinition( 1041388, "Corrupted Faction Town Sigil of Montor" ),
					new Point3D( 2471, 439, 15 ),
					new Point3D( 2469, 445, 15 ) );
		}
	}
}
// using System;

namespace Server.Factions
{
	public class Elidor : Town
	{
		public Elidor()
		{
			Definition =
				new TownDefinition(
					3,
					0x186C,
					"Elidor",
					"Elidor",
					new TextDefinition( 1011435, "Elidor" ),
					new TextDefinition( 1011563, "TOWN STONE FOR Elidor" ),
					new TextDefinition( 1041037, "The Faction Sigil Monolith of Elidor" ),
					new TextDefinition( 1041407, "The Faction Town Sigil Monolith of Elidor" ),
					new TextDefinition( 1041416, "Faction Town Stone of Elidor" ),
					new TextDefinition( 1041398, "Faction Town Sigil of Elidor" ),
					new TextDefinition( 1041389, "Corrupted Faction Town Sigil of Elidor" ),
					new Point3D( 4436, 1083, 0 ),
					new Point3D( 4432, 1086, 0 ) );
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class MountainWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }

		[Constructable]
		public MountainWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the mountain wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0x360;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public MountainWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.IO;// using System.Text;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Misc;// using Server.Items;// using Server.Guilds;// using Server.Mobiles;// using Server.Accounting;// using Server.Commands;

namespace Server.Engines.MyRunUO
{
	public class MyRunUO : Timer
	{
		private static double CpuInterval = 0.1; // Processor runs every 0.1 seconds
		private static double CpuPercent = 0.25; // Processor runs for 25% of Interval, or ~25ms. This should take around 25% cpu

		public static void Initialize()
		{
			if ( Config.Enabled )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), Config.CharacterUpdateInterval, new TimerCallback( Begin ) );

				CommandSystem.Register( "UpdateMyRunUO", AccessLevel.Administrator, new CommandEventHandler( UpdateMyRunUO_OnCommand ) );

				CommandSystem.Register( "PublicChar", AccessLevel.Player, new CommandEventHandler( PublicChar_OnCommand ) );
				CommandSystem.Register( "PrivateChar", AccessLevel.Player, new CommandEventHandler( PrivateChar_OnCommand ) );
			}
		}

		[Usage( "PublicChar" )]
		[Description( "Enables showing extended character stats and skills in MyRunUO." )]
		public static void PublicChar_OnCommand( CommandEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;

			if ( pm != null )
			{
				if ( pm.PublicMyRunUO )
				{
					pm.SendMessage( "You have already chosen to show your skills and stats." );
				}
				else
				{
					pm.PublicMyRunUO = true;
					pm.SendMessage( "All of your skills and stats will now be shown publicly in MyRunUO." );
				}
			}
		}

		[Usage( "PrivateChar" )]
		[Description( "Disables showing extended character stats and skills in MyRunUO." )]
		public static void PrivateChar_OnCommand( CommandEventArgs e )
		{
			PlayerMobile pm = e.Mobile as PlayerMobile;

			if ( pm != null )
			{
				if ( !pm.PublicMyRunUO )
				{
					pm.SendMessage( "You have already chosen to not show your skills and stats." );
				}
				else
				{
					pm.PublicMyRunUO = false;
					pm.SendMessage( "Only a general level of your top three skills will be shown in MyRunUO." );
				}
			}
		}

		[Usage( "UpdateMyRunUO" )]
		[Description( "Starts the process of updating the MyRunUO character and guild database." )]
		public static void UpdateMyRunUO_OnCommand( CommandEventArgs e )
		{
			if ( m_Command != null && m_Command.HasCompleted )
				m_Command = null;

			if ( m_Timer == null && m_Command == null )
			{
				Begin();
				e.Mobile.SendMessage( "MyRunUO update process has been started." );
			}
			else
			{
				e.Mobile.SendMessage( "MyRunUO database is already being updated." );
			}
		}

		public static void Begin()
		{
			if ( m_Command != null && m_Command.HasCompleted )
				m_Command = null;

			if ( m_Timer != null || m_Command != null )
				return;

			m_Timer = new MyRunUO();
			m_Timer.Start();
		}

		private static Timer m_Timer;

		private Stage m_Stage;
		private ArrayList m_List;
		private List<IAccount> m_Collecting;
		private int m_Index;

		private static DatabaseCommandQueue m_Command;

		private string m_SkillsPath;
		private string m_LayersPath;
		private string m_MobilesPath;

		private StreamWriter m_OpSkills;
		private StreamWriter m_OpLayers;
		private StreamWriter m_OpMobiles;

		private DateTime m_StartTime;

		public MyRunUO() : base( TimeSpan.FromSeconds( CpuInterval ), TimeSpan.FromSeconds( CpuInterval ) )
		{
			m_List = new ArrayList();
			m_Collecting = new List<IAccount>();

			m_StartTime = DateTime.Now;
			Console.WriteLine( "MyRunUO: Updating character database" );
		}

		protected override void OnTick()
		{
			bool shouldExit = false;

			try
			{
				shouldExit = Process( DateTime.Now + TimeSpan.FromSeconds( CpuInterval * CpuPercent ) );

				if ( shouldExit )
					Console.WriteLine( "MyRunUO: Database statements compiled in {0:F2} seconds", (DateTime.Now - m_StartTime).TotalSeconds );
			}
			catch ( Exception e )
			{
				Console.WriteLine( "MyRunUO: {0}: Exception cought while processing", m_Stage );
				Console.WriteLine( e );
				shouldExit = true;
			}

			if ( shouldExit )
			{
				m_Command.Enqueue( null );

				Stop();
				m_Timer = null;
			}
		}

		private enum Stage
		{
			CollectingMobiles,
			DumpingMobiles,
			CollectingGuilds,
			DumpingGuilds,
			Complete
		}

		public bool Process( DateTime endTime )
		{
			switch ( m_Stage )
			{
				case Stage.CollectingMobiles: CollectMobiles( endTime ); break;
				case Stage.DumpingMobiles: DumpMobiles( endTime ); break;
				case Stage.CollectingGuilds: CollectGuilds( endTime ); break;
				case Stage.DumpingGuilds: DumpGuilds( endTime ); break;
			}

			return ( m_Stage == Stage.Complete );
		}

		private static ArrayList m_MobilesToUpdate = new ArrayList();

		public static void QueueMobileUpdate( Mobile m )
		{
			if ( !Config.Enabled || Config.LoadDataInFile )
				return;

			m_MobilesToUpdate.Add( m );
		}

		public void CollectMobiles( DateTime endTime )
		{
			if ( Config.LoadDataInFile )
			{
				if ( m_Index == 0 )
					 m_Collecting.AddRange( Accounts.GetAccounts() );

				for ( int i = m_Index; i < m_Collecting.Count; ++i )
				{
					IAccount acct = m_Collecting[i];

					for ( int j = 0; j < acct.Length; ++j )
					{
						Mobile mob = acct[j];

						if ( mob != null && mob.AccessLevel < Config.HiddenAccessLevel )
							m_List.Add( mob );
					}

					++m_Index;

					if ( DateTime.Now >= endTime )
						break;
				}

				if ( m_Index == m_Collecting.Count )
				{
					m_Collecting = new List<IAccount>();
					m_Stage = Stage.DumpingMobiles;
					m_Index = 0;
				}
			}
			else
			{
				m_List = m_MobilesToUpdate;
				m_MobilesToUpdate = new ArrayList();
				m_Stage = Stage.DumpingMobiles;
				m_Index = 0;
			}
		}

		public void CheckConnection()
		{
			if ( m_Command == null )
			{
				m_Command = new DatabaseCommandQueue( "MyRunUO: Characeter database updated in {0:F1} seconds", "MyRunUO Character Database Thread" );

				if ( Config.LoadDataInFile )
				{
					m_OpSkills = GetUniqueWriter( "skills", out m_SkillsPath );
					m_OpLayers = GetUniqueWriter( "layers", out m_LayersPath );
					m_OpMobiles = GetUniqueWriter( "mobiles", out m_MobilesPath );

					m_Command.Enqueue( "TRUNCATE TABLE myrunuo_characters" );
					m_Command.Enqueue( "TRUNCATE TABLE myrunuo_characters_layers" );
					m_Command.Enqueue( "TRUNCATE TABLE myrunuo_characters_skills" );
				}

				m_Command.Enqueue( "TRUNCATE TABLE myrunuo_guilds" );
				m_Command.Enqueue( "TRUNCATE TABLE myrunuo_guilds_wars" );
			}
		}

		public void ExecuteNonQuery( string text )
		{
			m_Command.Enqueue( text );
		}

		public void ExecuteNonQuery( string format, params string[] args )
		{
			ExecuteNonQuery( String.Format( format, args ) );
		}

		public void ExecuteNonQueryIfNull( string select, string insert )
		{
			m_Command.Enqueue( new string[]{ select, insert } );
		}

		private void AppendCharEntity( string input, int charIndex, ref StringBuilder sb, char c )
		{
			if ( sb == null )
			{
				if ( charIndex > 0 )
					sb = new StringBuilder( input, 0, charIndex, input.Length + 20 );
				else
					sb = new StringBuilder( input.Length + 20 );
			}

			sb.Append( "&#" );
			sb.Append( (int)c );
			sb.Append( ";" );
		}

		private void AppendEntityRef( string input, int charIndex, ref StringBuilder sb, string ent )
		{
			if ( sb == null )
			{
				if ( charIndex > 0 )
					sb = new StringBuilder( input, 0, charIndex, input.Length + 20 );
				else
					sb = new StringBuilder( input.Length + 20 );
			}

			sb.Append( ent );
		}

		private string SafeString( string input )
		{
			if ( input == null )
				return "";

			StringBuilder sb = null;

			for ( int i = 0; i < input.Length; ++i )
			{
				char c = input[i];

				if ( c < 0x20 || c > 0x80 )
				{
					AppendCharEntity( input, i, ref sb, c );
				}
				else
				{
					switch ( c )
					{
						case '&':	AppendEntityRef( input, i, ref sb, "&amp;" ); break;
						case '>':	AppendEntityRef( input, i, ref sb, "&gt;" ); break;
						case '<':	AppendEntityRef( input, i, ref sb, "&lt;" ); break;
						case '"':	AppendEntityRef( input, i, ref sb, "&quot;" ); break;
						case '\'':
						case ':':
						case '/':
						case '\\':	AppendCharEntity( input, i, ref sb, c ); break;
						default:
						{
							if ( sb != null )
								sb.Append( c );

							break;
						}
					}
				}
			}

			if ( sb != null )
				return sb.ToString();

			return input;
		}

		public const char LineStart = '\"';
		public const string EntrySep = "\",\"";
		public const string LineEnd = "\"\n";

		public void InsertMobile( Mobile mob )
		{
			string guildTitle = mob.GuildTitle;

			if ( guildTitle == null || (guildTitle = guildTitle.Trim()).Length == 0 )
				guildTitle = "NULL";
			else
				guildTitle = SafeString( guildTitle );

			string notoTitle = SafeString( Titles.ComputeTitle( null, mob ) );
			string female = ( mob.Female ? "1" : "0" );

			bool pubBool = ( mob is PlayerMobile ) && ( ((PlayerMobile)mob).PublicMyRunUO );

			string pubString = ( pubBool ? "1" : "0" );

			string guildId = ( mob.Guild == null ? "NULL" : mob.Guild.Id.ToString() );

			if ( Config.LoadDataInFile )
			{
				m_OpMobiles.Write( LineStart );
				m_OpMobiles.Write( mob.Serial.Value );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( SafeString( mob.Name ) );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.RawStr );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.RawDex );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.RawInt );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( female );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.Kills );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( guildId );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( guildTitle );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( notoTitle );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( mob.Hue );
				m_OpMobiles.Write( EntrySep );
				m_OpMobiles.Write( pubString );
				m_OpMobiles.Write( LineEnd );
			}
			else
			{
				ExecuteNonQuery( "INSERT INTO myrunuo_characters (char_id, char_name, char_str, char_dex, char_int, char_female, char_counts, char_guild, char_guildtitle, char_nototitle, char_bodyhue, char_public ) VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, '{9}', {10}, {11})", mob.Serial.Value.ToString(), SafeString( mob.Name ), mob.RawStr.ToString(), mob.RawDex.ToString(), mob.RawInt.ToString(), female, mob.Kills.ToString(), guildId, guildTitle, notoTitle, mob.Hue.ToString(), pubString );
			}
		}

		public void InsertSkills( Mobile mob )
		{
			Skills skills = mob.Skills;
			string serial = mob.Serial.Value.ToString();

			for ( int i = 0; i < skills.Length; ++i )
			{
				Skill skill = skills[i];

				if ( skill.BaseFixedPoint > 0 )
				{
					if ( Config.LoadDataInFile )
					{
						m_OpSkills.Write( LineStart );
						m_OpSkills.Write( serial );
						m_OpSkills.Write( EntrySep );
						m_OpSkills.Write( i );
						m_OpSkills.Write( EntrySep );
						m_OpSkills.Write( skill.BaseFixedPoint );
						m_OpSkills.Write( LineEnd );
					}
					else
					{
						ExecuteNonQuery( "INSERT INTO myrunuo_characters_skills (char_id, skill_id, skill_value) VALUES ({0}, {1}, {2})", serial, i.ToString(), skill.BaseFixedPoint.ToString() );
					}
				}
			}
		}

		private ArrayList m_Items = new ArrayList();

		private void InsertItem( string serial, int index, int itemID, int hue )
		{
			if ( Config.LoadDataInFile )
			{
				m_OpLayers.Write( LineStart );
				m_OpLayers.Write( serial );
				m_OpLayers.Write( EntrySep );
				m_OpLayers.Write( index );
				m_OpLayers.Write( EntrySep );
				m_OpLayers.Write( itemID );
				m_OpLayers.Write( EntrySep );
				m_OpLayers.Write( hue );
				m_OpLayers.Write( LineEnd );
			}
			else
			{
				ExecuteNonQuery( "INSERT INTO myrunuo_characters_layers (char_id, layer_id, item_id, item_hue) VALUES ({0}, {1}, {2}, {3})", serial, index.ToString(), itemID.ToString(), hue.ToString() );
			}
		}

		public void InsertItems( Mobile mob )
		{
			ArrayList items = m_Items;
			items.AddRange( mob.Items );
			string serial = mob.Serial.Value.ToString();

			items.Sort( LayerComparer.Instance );

			int index = 0;

			bool hidePants = false;
			bool alive = mob.Alive;
			bool hideHair = !alive;

			for ( int i = 0; i < items.Count; ++i )
			{
				Item item = (Item)items[i];

				if ( !LayerComparer.IsValid( item ) )
					break;

				if ( !alive && item.ItemID != 8270 )
					continue;

				if ( item.ItemID == 0x46AA || item.ItemID == 0x46AB ) // plate legs
					hidePants = true;
				else if ( hidePants && item.Layer == Layer.Pants )
					continue;

				if ( !hideHair && item.Layer == Layer.Helm )
					hideHair = true;

				InsertItem( serial, index++, item.ItemID, item.Hue );
			}

			if ( mob.FacialHairItemID != 0 && alive )
				InsertItem( serial, index++, mob.FacialHairItemID, mob.FacialHairHue );

			if ( mob.HairItemID != 0 && !hideHair )
				InsertItem( serial, index++, mob.HairItemID, mob.HairHue );

			items.Clear();
		}

		public void DeleteMobile( Mobile mob )
		{
			ExecuteNonQuery( "DELETE FROM myrunuo_characters WHERE char_id = {0}", mob.Serial.Value.ToString() );
			ExecuteNonQuery( "DELETE FROM myrunuo_characters_skills WHERE char_id = {0}", mob.Serial.Value.ToString() );
			ExecuteNonQuery( "DELETE FROM myrunuo_characters_layers WHERE char_id = {0}", mob.Serial.Value.ToString() );
		}

		public StreamWriter GetUniqueWriter( string type, out string filePath )
		{
			filePath = Path.Combine( Core.BaseDirectory, String.Format( "myrunuodb_{0}.txt", type ) ).Replace( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );

			try
			{
				return new StreamWriter( filePath );
			}
			catch
			{
				for ( int i = 0; i < 100; ++i )
				{
					try
					{
						filePath = Path.Combine( Core.BaseDirectory, String.Format( "myrunuodb_{0}_{1}.txt", type, i ) ).Replace( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar );
						return new StreamWriter( filePath );
					}
					catch
					{
					}
				}
			}

			return null;
		}

		public void DumpMobiles( DateTime endTime )
		{
			CheckConnection();

			for ( int i = m_Index; i < m_List.Count; ++i )
			{
				Mobile mob = (Mobile)m_List[i];

				if ( mob is PlayerMobile )
					((PlayerMobile)mob).ChangedMyRunUO = false;

				if ( !mob.Deleted && mob.AccessLevel < Config.HiddenAccessLevel )
				{
					if ( !Config.LoadDataInFile )
						DeleteMobile( mob );

					InsertMobile( mob );
					InsertSkills( mob );
					InsertItems( mob );
				}
				else if ( !Config.LoadDataInFile )
				{
					DeleteMobile( mob );
				}

				++m_Index;

				if ( DateTime.Now >= endTime )
					break;
			}

			if ( m_Index == m_List.Count )
			{
				m_List.Clear();
				m_Stage = Stage.CollectingGuilds;
				m_Index = 0;

				if ( Config.LoadDataInFile )
				{
					m_OpSkills.Close();
					m_OpLayers.Close();
					m_OpMobiles.Close();

					ExecuteNonQuery( "LOAD DATA {0}INFILE '{1}' INTO TABLE myrunuo_characters FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'", Config.DatabaseNonLocal ? "LOCAL " : "", m_MobilesPath );
					ExecuteNonQuery( "LOAD DATA {0}INFILE '{1}' INTO TABLE myrunuo_characters_skills FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'", Config.DatabaseNonLocal ? "LOCAL " : "", m_SkillsPath );
					ExecuteNonQuery( "LOAD DATA {0}INFILE '{1}' INTO TABLE myrunuo_characters_layers FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'", Config.DatabaseNonLocal ? "LOCAL " : "", m_LayersPath );
				}
			}
		}

		public void CollectGuilds( DateTime endTime )
		{
			m_List.AddRange( Guild.List.Values );
			m_Stage = Stage.DumpingGuilds;
			m_Index = 0;
		}

		public void InsertGuild( Guild guild )
		{
			string guildType = "Standard";

			switch ( guild.Type )
			{
				case GuildType.Chaos: guildType = "Chaos"; break;
				case GuildType.Order: guildType = "Order"; break;
			}

			ExecuteNonQuery( "INSERT INTO myrunuo_guilds (guild_id, guild_name, guild_abbreviation, guild_website, guild_charter, guild_type, guild_wars, guild_members, guild_master) VALUES ({0}, '{1}', {2}, {3}, {4}, '{5}', {6}, {7}, {8})", guild.Id.ToString(), SafeString( guild.Name ), guild.Abbreviation == "none" ? "NULL" : "'" + SafeString( guild.Abbreviation ) + "'", guild.Website == null ? "NULL" : "'" + SafeString( guild.Website ) + "'", guild.Charter == null ? "NULL" : "'" + SafeString( guild.Charter ) + "'", guildType, guild.Enemies.Count.ToString(), guild.Members.Count.ToString(), guild.Leader.Serial.Value.ToString() );
		}

		public void InsertWars( Guild guild )
		{
			List<Guild> wars = guild.Enemies;

			string ourId = guild.Id.ToString();

			for ( int i = 0; i < wars.Count; ++i )
			{
				Guild them = wars[i];
				string theirId = them.Id.ToString();

				ExecuteNonQueryIfNull(
					String.Format( "SELECT guild_1 FROM myrunuo_guilds_wars WHERE (guild_1={0} AND guild_2={1}) OR (guild_1={1} AND guild_2={0})", ourId, theirId ),
					String.Format( "INSERT INTO myrunuo_guilds_wars (guild_1, guild_2) VALUES ({0}, {1})", ourId, theirId ) );
			}
		}

		public void DumpGuilds( DateTime endTime )
		{
			CheckConnection();

			for ( int i = m_Index; i < m_List.Count; ++i )
			{
				Guild guild = (Guild)m_List[i];

				if ( !guild.Disbanded )
				{
					InsertGuild( guild );
					InsertWars( guild );
				}

				++m_Index;

				if ( DateTime.Now >= endTime )
					break;
			}

			if ( m_Index == m_List.Count )
			{
				m_List.Clear();
				m_Stage = Stage.Complete;
				m_Index = 0;
			}
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Commands;// using Server.Network;

namespace Server.Engines.MyRunUO
{
	public class MyRunUOStatus
	{
		public static void Initialize()
		{
			if ( Config.Enabled )
			{
				Timer.DelayCall( TimeSpan.FromSeconds( 20.0 ), Config.StatusUpdateInterval, new TimerCallback( Begin ) );

				CommandSystem.Register( "UpdateWebStatus", AccessLevel.Administrator, new CommandEventHandler( UpdateWebStatus_OnCommand ) );
			}
		}

		[Usage( "UpdateWebStatus" )]
		[Description( "Starts the process of updating the MyRunUO online status database." )]
		public static void UpdateWebStatus_OnCommand( CommandEventArgs e )
		{
			if ( m_Command == null || m_Command.HasCompleted )
			{
				Begin();
				e.Mobile.SendMessage( "Web status update process has been started." );
			}
			else
			{
				e.Mobile.SendMessage( "Web status database is already being updated." );
			}
		}

		private static DatabaseCommandQueue m_Command;

		public static void Begin()
		{
			if ( m_Command != null && !m_Command.HasCompleted )
				return;

			DateTime start = DateTime.Now;
			Console.WriteLine( "MyRunUO: Updating status database" );

			try
			{
				m_Command = new DatabaseCommandQueue( "MyRunUO: Status database updated in {0:F1} seconds", "MyRunUO Status Database Thread" );

				m_Command.Enqueue( "DELETE FROM myrunuo_status" );

				List<NetState> online = NetState.Instances;

				for ( int i = 0; i < online.Count; ++i )
				{
					NetState ns = online[i];
					Mobile mob = ns.Mobile;

					if ( mob != null )
						m_Command.Enqueue( String.Format( "INSERT INTO myrunuo_status VALUES ({0})", mob.Serial.Value.ToString() ) );
				}
			}
			catch ( Exception e )
			{
				Console.WriteLine( "MyRunUO: Error updating status database" );
				Console.WriteLine( e );
			}

			if ( m_Command != null )
				m_Command.Enqueue( null );
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class NightWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0x496; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0x37BC; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 23 ); }

		[Constructable]
		public NightWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the night wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = 0x8FD;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Fire, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Black; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public NightWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class OnyxWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 20; } }
		public override int BreathFireDamage{ get{ return 20; } }
		public override int BreathColdDamage{ get{ return 20; } }
		public override int BreathPoisonDamage{ get{ return 20; } }
		public override int BreathEnergyDamage{ get{ return 20; } }
		public override int BreathEffectHue{ get{ return 0x496; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override int BreathEffectItemID{ get{ return 0x37BC; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 23 ); }

		[Constructable]
		public OnyxWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the onyx wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "onyx", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "onyx scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public OnyxWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;

namespace Server.Factions.AI
{
	public enum ReactionType
	{
		Ignore,
		Warn,
		Attack
	}

	public enum MovementType
	{
		Stand,
		Patrol,
		Follow
	}

	public class Reaction
	{
		private Faction m_Faction;
		private ReactionType m_Type;

		public Faction Faction{ get{ return m_Faction; } }
		public ReactionType Type{ get{ return m_Type; } set{ m_Type = value; } }

		public Reaction( Faction faction, ReactionType type )
		{
			m_Faction = faction;
			m_Type = type;
		}

		public Reaction( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					m_Faction = Faction.ReadReference( reader );
					m_Type = (ReactionType) reader.ReadEncodedInt();

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version

			Faction.WriteReference( writer, m_Faction );
			writer.WriteEncodedInt( (int) m_Type );
		}
	}

	public class Orders
	{
		private BaseFactionGuard m_Guard;

		private List<Reaction> m_Reactions;
		private MovementType m_Movement;
		private Mobile m_Follow;

		public BaseFactionGuard Guard{ get{ return m_Guard; } }

		public MovementType Movement{ get{ return m_Movement; } set{ m_Movement = value; } }
		public Mobile Follow{ get{ return m_Follow; } set{ m_Follow = value; } }

		public Reaction GetReaction( Faction faction )
		{
			Reaction reaction;

			for ( int i = 0; i < m_Reactions.Count; ++i )
			{
				reaction = m_Reactions[i];

				if ( reaction.Faction == faction )
					return reaction;
			}

			reaction = new Reaction( faction, ( faction == null || faction == m_Guard.Faction ) ? ReactionType.Ignore : ReactionType.Attack );
			m_Reactions.Add( reaction );

			return reaction;
		}

		public void SetReaction( Faction faction, ReactionType type )
		{
			Reaction reaction = GetReaction( faction );

			reaction.Type = type;
		}

		public Orders( BaseFactionGuard guard )
		{
			m_Guard = guard;
			m_Reactions = new List<Reaction>();
			m_Movement = MovementType.Patrol;
		}

		public Orders( BaseFactionGuard guard, GenericReader reader )
		{
			m_Guard = guard;

			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 1:
				{
					m_Follow = reader.ReadMobile();
					goto case 0;
				}
				case 0:
				{
					int count = reader.ReadEncodedInt();
					m_Reactions = new List<Reaction>( count );

					for ( int i = 0; i < count; ++i )
						m_Reactions.Add( new Reaction( reader ) );

					m_Movement = (MovementType)reader.ReadEncodedInt();

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version

			writer.Write( (Mobile) m_Follow );

			writer.WriteEncodedInt( (int) m_Reactions.Count );

			for ( int i = 0; i < m_Reactions.Count; ++i )
				m_Reactions[i].Serialize( writer );

			writer.WriteEncodedInt( (int) m_Movement );
		}
	}
}
// using System;// using Server;

namespace Server.Network
{
	public class UpdateStatueAnimation : Packet
	{
		public UpdateStatueAnimation( Mobile m, int status, int animation, int frame ) : base( 0xBF, 17 )
		{
			m_Stream.Write( (short) 0x11 );
			m_Stream.Write( (short) 0x19 );
			m_Stream.Write( (byte) 0x5 );
			m_Stream.Write( (int) m.Serial );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (byte) 0xFF );
			m_Stream.Write( (byte) status );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (byte) animation );
			m_Stream.Write( (byte) 0 );
			m_Stream.Write( (byte) frame );
		}
	}
}// using System;// using Server;// using Server.Network;

namespace Server.Engines.Chat
{
	public sealed class ChatMessagePacket : Packet
	{
		public ChatMessagePacket( Mobile who, int number, string param1, string param2 ) : base( 0xB2 )
		{
			if ( param1 == null )
				param1 = String.Empty;

			if ( param2 == null )
				param2 = String.Empty;

			EnsureCapacity( 13 + ((param1.Length + param2.Length) * 2) );

			m_Stream.Write( (ushort) (number - 20) );

			if ( who != null )
				m_Stream.WriteAsciiFixed( who.Language, 4 );
			else
				m_Stream.Write( (int) 0 );

			m_Stream.WriteBigUniNull( param1 );
			m_Stream.WriteBigUniNull( param2 );
		}
	}
}
// using System;// using System.Collections.Generic;

namespace Server.Factions
{
	public class FactionPersistance : Item
	{
		private static FactionPersistance m_Instance;

		public static FactionPersistance Instance{ get{ return m_Instance; } }

		public override string DefaultName
		{
			get { return "Faction Persistance - Internal"; }
		}

		public FactionPersistance() : base( 1 )
		{
			Movable = false;

			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}

		private enum PersistedType
		{
			Terminator,
			Faction,
			Town
		}

		public FactionPersistance( Serial serial ) : base( serial )
		{
			m_Instance = this;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			List<Faction> factions = Faction.Factions;

			for ( int i = 0; i < factions.Count; ++i )
			{
				writer.WriteEncodedInt( (int) PersistedType.Faction );
				factions[i].State.Serialize( writer );
			}

			List<Town> towns = Town.Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				writer.WriteEncodedInt( (int) PersistedType.Town );
				towns[i].State.Serialize( writer );
			}

			writer.WriteEncodedInt( (int) PersistedType.Terminator );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					PersistedType type;

					while ( (type = (PersistedType)reader.ReadEncodedInt()) != PersistedType.Terminator )
					{
						switch ( type )
						{
							case PersistedType.Faction: new FactionState( reader ); break;
							case PersistedType.Town: new TownState( reader ); break;
						}
					}

					break;
				}
			}
		}

		public override void Delete()
		{
		}
	}
}
// using System;

namespace Server.Ethics
{
	public class EthicsPersistance : Item
	{
		private static EthicsPersistance m_Instance;

		public static EthicsPersistance Instance { get { return m_Instance; } }

		public override string DefaultName
		{
			get { return "Ethics Persistance - Internal"; }
		}

		[Constructable]
		public EthicsPersistance()
			: base( 1 )
		{
			Movable = false;

			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}

		public EthicsPersistance( Serial serial )
			: base( serial )
		{
			m_Instance = this;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			for ( int i = 0; i < Ethics.Ethic.Ethics.Length; ++i )
				Ethics.Ethic.Ethics[i].Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					for ( int i = 0; i < Ethics.Ethic.Ethics.Length; ++i )
						Ethics.Ethic.Ethics[i].Deserialize( reader );

					break;
				}
			}
		}

		public override void Delete()
		{
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Ethics
{
	public class PlayerCollection : System.Collections.ObjectModel.Collection<Player>
	{
	}

	[PropertyObject]
	public class Player
	{
		public static Player Find( Mobile mob )
		{
			return Find( mob, false );
		}

		public static Player Find( Mobile mob, bool inherit )
		{
			PlayerMobile pm = mob as PlayerMobile;

			if ( pm == null )
			{
				if ( inherit && mob is BaseCreature )
				{
					BaseCreature bc = mob as BaseCreature;

					if ( bc != null && bc.Controlled )
						pm = bc.ControlMaster as PlayerMobile;
					else if ( bc != null && bc.Summoned )
						pm = bc.SummonMaster as PlayerMobile;
				}

				if ( pm == null )
					return null;
			}

			Player pl = pm.EthicPlayer;

			if ( pl != null && !pl.Ethic.IsEligible( pl.Mobile ) )
				pm.EthicPlayer = pl = null;

			return pl;
		}

		private Ethic m_Ethic;
		private Mobile m_Mobile;

		private int m_Power;
		private int m_History;

		private Mobile m_Steed;
		private Mobile m_Familiar;

		private DateTime m_Shield;

		public Ethic Ethic { get { return m_Ethic; } }
		public Mobile Mobile { get { return m_Mobile; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public int Power { get { return m_Power; } set { m_Power = value; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public int History { get { return m_History; } set { m_History = value; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Mobile Steed { get { return m_Steed; } set { m_Steed = value; } }

		[CommandProperty( AccessLevel.GameMaster, AccessLevel.Administrator )]
		public Mobile Familiar { get { return m_Familiar; } set { m_Familiar = value; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsShielded
		{
			get
			{
				if ( m_Shield == DateTime.MinValue )
					return false;

				if ( DateTime.Now < ( m_Shield + TimeSpan.FromHours( 1.0 ) ) )
					return true;

				FinishShield();
				return false;
			}
		}

		public void BeginShield()
		{
			m_Shield = DateTime.Now;
		}

		public void FinishShield()
		{
			m_Shield = DateTime.MinValue;
		}

		public Player( Ethic ethic, Mobile mobile )
		{
			m_Ethic = ethic;
			m_Mobile = mobile;

			m_Power = 5;
			m_History = 5;
		}

		public void CheckAttach()
		{
			if ( m_Ethic.IsEligible( m_Mobile ) )
				Attach();
		}

		public void Attach()
		{
			if ( m_Mobile is PlayerMobile )
				( m_Mobile as PlayerMobile ).EthicPlayer = this;

			m_Ethic.Players.Add( this );
		}

		public void Detach()
		{
			if ( m_Mobile is PlayerMobile )
				( m_Mobile as PlayerMobile ).EthicPlayer = null;

			m_Ethic.Players.Remove( this );
		}

		public Player( Ethic ethic, GenericReader reader )
		{
			m_Ethic = ethic;

			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					m_Mobile = reader.ReadMobile();

					m_Power = reader.ReadEncodedInt();
					m_History = reader.ReadEncodedInt();

					m_Steed = reader.ReadMobile();
					m_Familiar = reader.ReadMobile();

					m_Shield = reader.ReadDeltaTime();

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( 0 ); // version

			writer.Write( m_Mobile );

			writer.WriteEncodedInt( m_Power );
			writer.WriteEncodedInt( m_History );

			writer.Write( m_Steed );
			writer.Write( m_Familiar );

			writer.WriteDeltaTime( m_Shield );
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using System.Collections.Generic;

namespace Server.Factions
{
	public class PlayerState : IComparable
	{
		private Mobile m_Mobile;
		private Faction m_Faction;
		private List<PlayerState> m_Owner;
		private int m_KillPoints;
		private DateTime m_Leaving;
		private MerchantTitle m_MerchantTitle;
		private RankDefinition m_Rank;
		private List<SilverGivenEntry> m_SilverGiven;
		private bool m_IsActive;

		private Town m_Sheriff;
		private Town m_Finance;

		private DateTime m_LastHonorTime;

		public Mobile Mobile{ get{ return m_Mobile; } }
		public Faction Faction{ get{ return m_Faction; } }
		public List<PlayerState> Owner { get { return m_Owner; } }
		public MerchantTitle MerchantTitle{ get{ return m_MerchantTitle; } set{ m_MerchantTitle = value; Invalidate(); } }
		public Town Sheriff{ get{ return m_Sheriff; } set{ m_Sheriff = value; Invalidate(); } }
		public Town Finance{ get{ return m_Finance; } set{ m_Finance = value; Invalidate(); } }
		public List<SilverGivenEntry> SilverGiven { get { return m_SilverGiven; } }

		public int KillPoints {
			get { return m_KillPoints; }
			set {
				if ( m_KillPoints != value ) {
					if ( value > m_KillPoints ) {
						if ( m_KillPoints <= 0 ) {
							if ( value <= 0 ) {
								m_KillPoints = value;
								Invalidate();
								return;
							}

							m_Owner.Remove( this );
							m_Owner.Insert( m_Faction.ZeroRankOffset, this );

							m_RankIndex = m_Faction.ZeroRankOffset;
							m_Faction.ZeroRankOffset++;
						}
						while ( ( m_RankIndex - 1 ) >= 0 ) {
							PlayerState p = m_Owner[m_RankIndex-1] as PlayerState;
							if ( value > p.KillPoints ) {
								m_Owner[m_RankIndex] = p;
								m_Owner[m_RankIndex-1] = this;
								RankIndex--;
								p.RankIndex++;
							}
							else
								break;
						}
					}
					else {
						if ( value <= 0 ) {
							if ( m_KillPoints <= 0 ) {
								m_KillPoints = value;
								Invalidate();
								return;
							}

							while ( ( m_RankIndex + 1 ) < m_Faction.ZeroRankOffset ) {
								PlayerState p = m_Owner[m_RankIndex+1] as PlayerState;
								m_Owner[m_RankIndex+1] = this;
								m_Owner[m_RankIndex] = p;
								RankIndex++;
								p.RankIndex--;
							}

							m_RankIndex = -1;
							m_Faction.ZeroRankOffset--;
						}
						else {
							while ( ( m_RankIndex + 1 ) < m_Faction.ZeroRankOffset ) {
								PlayerState p = m_Owner[m_RankIndex+1] as PlayerState;
								if ( value < p.KillPoints ) {
									m_Owner[m_RankIndex+1] = this;
									m_Owner[m_RankIndex] = p;
									RankIndex++;
									p.RankIndex--;
								}
								else
									break;
							}
						}
					}

					m_KillPoints = value;
					Invalidate();
				}
			}
		}

		private bool m_InvalidateRank = true;
		private int  m_RankIndex = -1;

		public int RankIndex { get { return m_RankIndex; } set { if ( m_RankIndex != value ) { m_RankIndex = value; m_InvalidateRank = true; } } }

		public RankDefinition Rank {
			get {
				if ( m_InvalidateRank ) {
					RankDefinition[] ranks = m_Faction.Definition.Ranks;
					int percent;

					if ( m_Owner.Count == 1 )
						percent = 1000;
					else if ( m_RankIndex == -1 )
						percent = 0;
					else
						percent = ( ( m_Faction.ZeroRankOffset - m_RankIndex ) * 1000 ) / m_Faction.ZeroRankOffset;

					for ( int i = 0; i < ranks.Length; i++ ) {
						RankDefinition check = ranks[i];

						if ( percent >= check.Required ) {
							m_Rank = check;
							m_InvalidateRank = false;
							break;
						}
					}

					Invalidate();
				}

				return m_Rank;
			}
		}

		public DateTime LastHonorTime{ get{ return m_LastHonorTime; } set{ m_LastHonorTime = value; } }
		public DateTime Leaving{ get{ return m_Leaving; } set{ m_Leaving = value; } }
		public bool IsLeaving{ get{ return ( m_Leaving > DateTime.MinValue ); } }

		public bool IsActive{ get{ return m_IsActive; } set{ m_IsActive = value; } }

		public bool CanGiveSilverTo( Mobile mob )
		{
			if ( m_SilverGiven == null )
				return true;

			for ( int i = 0; i < m_SilverGiven.Count; ++i )
			{
				SilverGivenEntry sge = m_SilverGiven[i];

				if ( sge.IsExpired )
					m_SilverGiven.RemoveAt( i-- );
				else if ( sge.GivenTo == mob )
					return false;
			}

			return true;
		}

		public void OnGivenSilverTo( Mobile mob )
		{
			if ( m_SilverGiven == null )
				m_SilverGiven = new List<SilverGivenEntry>();

			m_SilverGiven.Add( new SilverGivenEntry( mob ) );
		}

		public void Invalidate()
		{
			if ( m_Mobile is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m_Mobile;
				pm.InvalidateProperties();
				pm.InvalidateMyRunUO();
			}
		}

		public void Attach()
		{
			if ( m_Mobile is PlayerMobile )
				((PlayerMobile)m_Mobile).FactionPlayerState = this;
		}

		public PlayerState( Mobile mob, Faction faction, List<PlayerState> owner )
		{
			m_Mobile = mob;
			m_Faction = faction;
			m_Owner = owner;

			Attach();
			Invalidate();
		}

		public PlayerState( GenericReader reader, Faction faction, List<PlayerState> owner )
		{
			m_Faction = faction;
			m_Owner = owner;

			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 1:
				{
					m_IsActive = reader.ReadBool();
					m_LastHonorTime = reader.ReadDateTime();
					goto case 0;
				}
				case 0:
				{
					m_Mobile = reader.ReadMobile();

					m_KillPoints = reader.ReadEncodedInt();
					m_MerchantTitle = (MerchantTitle)reader.ReadEncodedInt();

					m_Leaving = reader.ReadDateTime();

					break;
				}
			}

			Attach();
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version

			writer.Write( m_IsActive );
			writer.Write( m_LastHonorTime );

			writer.Write( (Mobile) m_Mobile );

			writer.WriteEncodedInt( (int) m_KillPoints );
			writer.WriteEncodedInt( (int) m_MerchantTitle );

			writer.Write( (DateTime) m_Leaving );
		}

		public static PlayerState Find( Mobile mob )
		{
			if ( mob is PlayerMobile )
				return ((PlayerMobile)mob).FactionPlayerState;

			return null;
		}

		public int CompareTo( object obj )
		{
			return ((PlayerState)obj).m_KillPoints - m_KillPoints;
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class PoisonBeetle : BaseCreature
	{
		[Constructable]
		public PoisonBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a poisonous beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;
			Hue = 1167;

			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			SetHits( 80, 110 );

			SetDamage( 3, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 80 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 16;

			Item Venom = new VenomSack();
				Venom.Name = "lethal venom sack";
				AddItem( Venom );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

		public PoisonBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;

			Body = 0xA9;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics
{
	public abstract class Power
	{
		protected PowerDefinition m_Definition;

		public PowerDefinition Definition { get { return m_Definition; } }

		public virtual bool CheckInvoke( Player from )
		{
			if ( !from.Mobile.CheckAlive() )
				return false;

			if ( from.Power < m_Definition.Power )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You lack the power to invoke this ability." );
				return false;
			}

			return true;
		}

		public abstract void BeginInvoke( Player from );

		public virtual void FinishInvoke( Player from )
		{
			from.Power -= m_Definition.Power;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics
{
	public class PowerDefinition
	{
		private int m_Power;

		private TextDefinition m_Name;
		private TextDefinition m_Phrase;
		private TextDefinition m_Description;

		public int Power { get { return m_Power; } }

		public TextDefinition Name { get { return m_Name; } }
		public TextDefinition Phrase { get { return m_Phrase; } }
		public TextDefinition Description { get { return m_Description; } }

		public PowerDefinition( int power, TextDefinition name, TextDefinition phrase, TextDefinition description )
		{
			m_Power = power;

			m_Name = name;
			m_Phrase = phrase;
			m_Description = description;
		}
	}
}// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class QuartzWyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public QuartzWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the quartz wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "quartz", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 70, 80 );
			SetResistance( ResistanceType.Poison, 60, 70 );
			SetResistance( ResistanceType.Energy, 60, 70 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "quartz scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public QuartzWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;// using Server.ContextMenus;

namespace Server.Engines.Quests
{
	public class QuestCallbackEntry : ContextMenuEntry
	{
		private QuestCallback m_Callback;

		public QuestCallbackEntry( int number, QuestCallback callback ) : this( number, -1, callback )
		{
		}

		public QuestCallbackEntry( int number, int range, QuestCallback callback ) : base( number, range )
		{
			m_Callback = callback;
		}

		public override void OnClick()
		{
			if ( m_Callback != null )
				m_Callback();
		}
	}
}
// using System;// using System.Xml;// using Server;// using Server.Regions;// using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class QuestCompleteObjectiveRegion : BaseRegion
	{
		private Type m_Quest;
		private Type m_Objective;

		public Type Quest{ get{ return m_Quest ; } }
		public Type Objective{ get{ return m_Objective; } }

		public QuestCompleteObjectiveRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
			XmlElement questEl = xml["quest"];

			ReadType( questEl, "type", ref m_Quest );
			ReadType( questEl, "complete", ref m_Objective );
		}

		public override void OnEnter( Mobile m )
		{
			base.OnEnter( m );

			if ( m_Quest != null && m_Objective != null )
			{
				PlayerMobile player = m as PlayerMobile;

				if ( player != null && player.Quest != null && player.Quest.GetType() == m_Quest )
				{
					QuestObjective obj = player.Quest.FindObjective( m_Objective );

					if ( obj != null && !obj.Completed )
						obj.Complete();
				}
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server.Engines.Quests
{
	public abstract class QuestConversation
	{
		private QuestSystem m_System;
		private bool m_HasBeenRead;

		public abstract object Message{ get; }

		public virtual QuestItemInfo[] Info{ get{ return null; } }
		public virtual bool Logged{ get{ return true; } }

		public QuestSystem System
		{
			get{ return m_System; }
			set{ m_System = value; }
		}

		public bool HasBeenRead
		{
			get{ return m_HasBeenRead; }
			set{ m_HasBeenRead = value; }
		}

		public QuestConversation()
		{
		}

		public virtual void BaseDeserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					m_HasBeenRead = reader.ReadBool();

					break;
				}
			}

			ChildDeserialize( reader );
		}

		public virtual void ChildDeserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();
		}

		public virtual void BaseSerialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (bool) m_HasBeenRead );

			ChildSerialize( writer );
		}

		public virtual void ChildSerialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public virtual void OnRead()
		{
		}
	}

	public class QuestConversationsGump : BaseQuestGump
	{
		private ArrayList m_Conversations;

		public QuestConversationsGump( QuestConversation conv ) : this( BuildList( conv ) )
		{
		}

		public QuestConversationsGump( ArrayList conversations ) : base( 30, 50 )
		{
			m_Conversations = conversations;

			Closable = false;

			AddPage( 0 );

			AddImage( 349, 10, 9392 );
			AddImageTiled( 349, 130, 100, 120, 9395 );
			AddImageTiled( 149, 10, 200, 140, 9391 );
			AddImageTiled( 149, 250, 200, 140, 9397 );
			AddImage( 349, 250, 9398 );
			AddImage( 35, 10, 9390 );
			AddImageTiled( 35, 150, 120, 100, 9393 );
			AddImage( 35, 250, 9396 );

			AddHtmlLocalized( 110, 60, 200, 20, 1049069, White, false, false ); // <STRONG>Conversation Event</STRONG>

			AddImage( 65, 14, 10102 );
			AddImageTiled( 81, 14, 349, 17, 10101 );
			AddImage( 426, 14, 10104 );

			AddImageTiled( 55, 40, 388, 323, 2624 );
			AddAlphaRegion( 55, 40, 388, 323 );

			AddImageTiled( 75, 90, 200, 1, 9101 );
			AddImage( 75, 58, 9781 );
			AddImage( 380, 45, 223 );

			AddButton( 220, 335, 2313, 2312, 1, GumpButtonType.Reply, 0 );
			AddImage( 0, 0, 10440 );

			AddPage( 1 );

			for ( int i = 0; i < conversations.Count; ++i )
			{
				QuestConversation conv = (QuestConversation)conversations[conversations.Count - 1 - i];

				if ( i > 0 )
				{
					AddButton( 65, 366, 9909, 9911, 0, GumpButtonType.Page, 1 + i );
					AddHtmlLocalized( 90, 367, 50, 20, 1043354, Black, false, false ); // Previous

					AddPage( 1 + i );
				}

				AddHtmlObject( 70, 110, 365, 220, conv.Message, LightGreen, false, true );

				if ( i > 0 )
				{
					AddButton( 420, 366, 9903, 9905, 0, GumpButtonType.Page, i );
					AddHtmlLocalized( 370, 367, 50, 20, 1043353, Black, false, false ); // Next
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			for ( int i = m_Conversations.Count - 1; i >= 0; --i )
			{
				QuestConversation qc = (QuestConversation)m_Conversations[i];

				if ( !qc.HasBeenRead )
				{
					qc.HasBeenRead = true;
					qc.OnRead();
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Mobiles;

namespace Server.Engines.Quests
{
	public abstract class QuestItem : Item
	{
		public QuestItem( int itemID ) : base( itemID )
		{
		}

		public QuestItem( Serial serial ) : base( serial )
		{
		}

		public abstract bool CanDrop( PlayerMobile pm );

		public virtual bool Accepted { get { return Deleted; } }

		public override bool DropToWorld( Mobile from, Point3D p )
		{
			bool ret = base.DropToWorld( from, p );

			if ( ret && !Accepted && Parent != from.Backpack )
			{
				if ( from.AccessLevel > AccessLevel.Player )
				{
					return true;
				}
				else if ( !(from is PlayerMobile) || CanDrop( (PlayerMobile)from ) )
				{
					return true;
				}
				else
				{
					from.SendLocalizedMessage( 1049343 ); // You can only drop quest items into the top-most level of your backpack while you still need them for your quest.
					return false;
				}
			}
			else
			{
				return ret;
			}
		}

		public override bool DropToMobile( Mobile from, Mobile target, Point3D p )
		{
			bool ret = base.DropToMobile( from, target, p );

			if ( ret && !Accepted && Parent != from.Backpack )
			{
				if ( from.AccessLevel > AccessLevel.Player )
				{
					return true;
				}
				else if ( !(from is PlayerMobile) || CanDrop( (PlayerMobile)from ) )
				{
					return true;
				}
				else
				{
					from.SendLocalizedMessage( 1049344 ); // You decide against trading the item.  You still need it for your quest.
					return false;
				}
			}
			else
			{
				return ret;
			}
		}

		public override bool DropToItem( Mobile from, Item target, Point3D p )
		{
			bool ret = base.DropToItem( from, target, p );

			if ( ret && !Accepted && Parent != from.Backpack )
			{
				if ( from.AccessLevel > AccessLevel.Player )
				{
					return true;
				}
				else if ( !(from is PlayerMobile) || CanDrop( (PlayerMobile)from ) )
				{
					return true;
				}
				else
				{
					from.SendLocalizedMessage( 1049343 ); // You can only drop quest items into the top-most level of your backpack while you still need them for your quest.
					return false;
				}
			}
			else
			{
				return ret;
			}
		}

		public override DeathMoveResult OnParentDeath( Mobile parent )
		{
			if ( parent is PlayerMobile && !CanDrop( (PlayerMobile)parent ) )
				return DeathMoveResult.MoveToBackpack;
			else
				return base.OnParentDeath( parent );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Gumps;

namespace Server.Engines.Quests
{
	public class QuestItemInfo
	{
		private object m_Name;
		private int m_ItemID;

		public object Name
		{
			get{ return m_Name; }
			set{ m_Name = value; }
		}

		public int ItemID
		{
			get{ return m_ItemID; }
			set{ m_ItemID = value; }
		}

		public QuestItemInfo( object name, int itemID )
		{
			m_Name = name;
			m_ItemID = itemID;
		}
	}

	public class QuestItemInfoGump : BaseQuestGump
	{
		public QuestItemInfoGump( QuestItemInfo[] info ) : base( 485, 75 )
		{
			int height = 100 + (info.Length * 75);

			AddPage( 0 );

			AddBackground( 5, 10, 145, height, 5054 );

			AddImageTiled( 13, 20, 125, 10, 2624 );
			AddAlphaRegion( 13, 20, 125, 10 );

			AddImageTiled( 13, height - 10, 128, 10, 2624 );
			AddAlphaRegion( 13, height - 10, 128, 10 );

			AddImageTiled( 13, 20, 10, height - 30, 2624 );
			AddAlphaRegion( 13, 20, 10, height - 30 );

			AddImageTiled( 131, 20, 10, height - 30, 2624 );
			AddAlphaRegion( 131, 20, 10, height - 30 );

			AddHtmlLocalized( 67, 35, 120, 20, 1011233, White, false, false ); // INFO

			AddImage( 62, 52, 9157 );
			AddImage( 72, 52, 9157 );
			AddImage( 82, 52, 9157 );

			AddButton( 25, 31, 1209, 1210, 777, GumpButtonType.Reply, 0 );

			AddPage( 1 );

			for ( int i = 0; i < info.Length; ++i )
			{
				QuestItemInfo cur = info[i];

				AddHtmlObject( 25, 65 + (i * 75), 110, 20, cur.Name, 1153, false, false );
				AddItem( 45, 85 + (i * 75), cur.ItemID );
			}
		}
	}
}
// using System;// using System.Xml;// using Server;// using Server.Regions;// using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class QuestNoEntryRegion : BaseRegion
	{
		private Type m_Quest;
		private Type m_MinObjective;
		private Type m_MaxObjective;
		private int m_Message;

		public Type Quest{ get{ return m_Quest; } }
		public Type MinObjective{ get{ return m_MinObjective; } }
		public Type MaxObjective{ get{ return m_MaxObjective; } }
		public int Message{ get{ return m_Message; } }

		public QuestNoEntryRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
			XmlElement questEl = xml["quest"];

			ReadType( questEl, "type", ref m_Quest );
			ReadType( questEl, "min", ref m_MinObjective, false );
			ReadType( questEl, "max", ref m_MaxObjective, false );
			ReadInt32( questEl, "message", ref m_Message, false );
		}

		public override bool OnMoveInto( Mobile m, Direction d, Point3D newLocation, Point3D oldLocation )
		{
			if ( !base.OnMoveInto ( m, d, newLocation, oldLocation ) )
				return false;

			if ( m.AccessLevel > AccessLevel.Player )
				return true;

			if( m is BaseCreature )
			{
				BaseCreature bc = m as BaseCreature;

				if( !bc.Controlled && !bc.Summoned )
					return true;
			}

			if ( m_Quest == null )
				return true;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null && player.Quest != null && player.Quest.GetType() == m_Quest
				&& ( m_MinObjective == null || player.Quest.FindObjective( m_MinObjective ) != null )
				&& ( m_MaxObjective == null || player.Quest.FindObjective( m_MaxObjective ) == null ) )
			{
				return true;
			}
			else
			{
				if ( m_Message != 0 )
					m.SendLocalizedMessage( m_Message );

				return false;
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Items;

namespace Server.Engines.Quests
{
	public abstract class QuestObjective
	{
		private QuestSystem m_System;
		private bool m_HasBeenRead;
		private int m_CurProgress;
		private bool m_HasCompleted;

		public abstract object Message{ get; }

		public virtual int MaxProgress{ get{ return 1; } }
		public virtual QuestItemInfo[] Info{ get{ return null; } }

		public QuestSystem System
		{
			get{ return m_System; }
			set{ m_System = value; }
		}

		public bool HasBeenRead
		{
			get{ return m_HasBeenRead; }
			set{ m_HasBeenRead = value; }
		}

		public int CurProgress
		{
			get{ return m_CurProgress; }
			set{ m_CurProgress = value; CheckCompletionStatus(); }
		}

		public bool HasCompleted
		{
			get{ return m_HasCompleted; }
			set{ m_HasCompleted = value; }
		}

		public virtual bool Completed
		{
			get{ return m_CurProgress >= MaxProgress; }
		}

		public bool IsSingleObjective
		{
			get{ return ( MaxProgress == 1 ); }
		}

		public QuestObjective()
		{
		}

		public virtual void BaseDeserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 1:
				{
					m_HasBeenRead = reader.ReadBool();
					goto case 0;
				}
				case 0:
				{
					m_CurProgress = reader.ReadEncodedInt();
					m_HasCompleted = reader.ReadBool();

					break;
				}
			}

			ChildDeserialize( reader );
		}

		public virtual void ChildDeserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();
		}

		public virtual void BaseSerialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 1 ); // version

			writer.Write( (bool) m_HasBeenRead );
			writer.WriteEncodedInt( (int) m_CurProgress );
			writer.Write( (bool) m_HasCompleted );

			ChildSerialize( writer );
		}

		public virtual void ChildSerialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public virtual void Complete()
		{
			CurProgress = MaxProgress;
		}

		public virtual void RenderMessage( BaseQuestGump gump )
		{
			gump.AddHtmlObject( 70, 130, 300, 100, this.Message, BaseQuestGump.Blue, false, false );
		}

		public virtual void RenderProgress( BaseQuestGump gump )
		{
			gump.AddHtmlObject( 70, 260, 270, 100, this.Completed ? 1049077 : 1049078, BaseQuestGump.Blue, false, false );
		}

		public virtual void CheckCompletionStatus()
		{
			if ( Completed && !HasCompleted )
			{
				HasCompleted = true;
				OnComplete();
			}
		}

		public virtual void OnRead()
		{
		}

		public virtual bool GetTimerEvent()
		{
			return !Completed;
		}

		public virtual void CheckProgress()
		{
		}

		public virtual void OnComplete()
		{
		}

		public virtual bool GetKillEvent( BaseCreature creature, Container corpse )
		{
			return !Completed;
		}

		public virtual void OnKill( BaseCreature creature, Container corpse )
		{
		}

		public virtual bool IgnoreYoungProtection( Mobile from )
		{
			return false;
		}
	}

	public class QuestLogUpdatedGump : BaseQuestGump
	{
		private QuestSystem m_System;

		public QuestLogUpdatedGump( QuestSystem system ) : base( 3, 30 )
		{
			m_System = system;

			AddPage( 0 );

			AddImage( 20, 5, 1417 );

			AddHtmlLocalized( 0, 78, 120, 40, 1049079, White, false, false ); // Quest Log Updated

			AddImageTiled( 0, 78, 120, 40, 2624 );
			AddAlphaRegion( 0, 78, 120, 40 );

			AddButton( 30, 15, 5575, 5576, 1, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				m_System.ShowQuestLog();
		}
	}

	public class QuestObjectivesGump : BaseQuestGump
	{
		private ArrayList m_Objectives;

		public QuestObjectivesGump( QuestObjective obj ) : this( BuildList( obj ) )
		{
		}

		public QuestObjectivesGump( ArrayList objectives ) : base( 90, 50 )
		{
			m_Objectives = objectives;

			Closable = false;

			AddPage( 0 );

			AddImage( 0, 0, 3600 );
			AddImageTiled( 0, 14, 15, 375, 3603 );
			AddImageTiled( 380, 14, 14, 375, 3605 );
			AddImage( 0, 376, 3606 );
			AddImageTiled( 15, 376, 370, 16, 3607 );
			AddImageTiled( 15, 0, 370, 16, 3601 );
			AddImage( 380, 0, 3602 );
			AddImage( 380, 376, 3608 );

			AddImageTiled( 15, 15, 365, 365, 2624 );
			AddAlphaRegion( 15, 15, 365, 365 );

			AddImage( 20, 87, 1231 );
			AddImage( 75, 62, 9307 );

			AddHtmlLocalized( 117, 35, 230, 20, 1046026, Blue, false, false ); // Quest Log

			AddImage( 77, 33, 9781 );
			AddImage( 65, 110, 2104 );

			AddHtmlLocalized( 79, 106, 230, 20, 1049073, Blue, false, false ); // Objective:

			AddImageTiled( 68, 125, 120, 1, 9101 );
			AddImage( 65, 240, 2104 );

			AddHtmlLocalized( 79, 237, 230, 20, 1049076, Blue, false, false ); // Progress details:

			AddImageTiled( 68, 255, 120, 1, 9101 );
			AddButton( 175, 355, 2313, 2312, 1, GumpButtonType.Reply, 0 );

			AddImage( 341, 15, 10450 );
			AddImage( 341, 330, 10450 );
			AddImage( 15, 330, 10450 );
			AddImage( 15, 15, 10450 );

			AddPage( 1 );

			for ( int i = 0; i < objectives.Count; ++i )
			{
				QuestObjective obj = (QuestObjective)objectives[objectives.Count - 1 - i];

				if ( i > 0 )
				{
					AddButton( 55, 346, 9909, 9911, 0, GumpButtonType.Page, 1 + i );
					AddHtmlLocalized( 82, 347, 50, 20, 1043354, White, false, false ); // Previous

					AddPage( 1 + i );
				}

				obj.RenderMessage( this );
				obj.RenderProgress( this );

				if ( i > 0 )
				{
					AddButton( 317, 346, 9903, 9905, 0, GumpButtonType.Page, i );
					AddHtmlLocalized( 278, 347, 50, 20, 1043353, White, false, false ); // Next
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			for ( int i = m_Objectives.Count - 1; i >= 0; --i )
			{
				QuestObjective obj = (QuestObjective)m_Objectives[i];

				if ( !obj.HasBeenRead )
				{
					obj.HasBeenRead = true;
					obj.OnRead();
				}
			}
		}
	}
}
// using System;// using System.Xml;// using Server;// using Server.Regions;// using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class QuestOfferRegion : BaseRegion
	{
		private Type m_Quest;

		public Type Quest{ get{ return m_Quest ; } }

		public QuestOfferRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
			ReadType( xml["quest"], "type", ref m_Quest );
		}

		public override void OnEnter( Mobile m )
		{
			base.OnEnter( m );

			if ( m_Quest == null )
				return;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null && player.Quest == null && QuestSystem.CanOfferQuest( m, m_Quest ) )
			{
				try
				{
					QuestSystem qs = (QuestSystem) Activator.CreateInstance( m_Quest, new object[] { player } );
					qs.SendOffer();
				}
				catch ( Exception ex )
				{
					Console.WriteLine( "Error creating quest {0}: {1}", m_Quest, ex );
				}
			}
		}
	}
}
// using System;

namespace Server.Engines.Quests
{
	public class QuestRestartInfo
	{
		private Type m_QuestType;
		private DateTime m_RestartTime;

		public Type QuestType
		{
			get{ return m_QuestType; }
			set{ m_QuestType = value; }
		}

		public DateTime RestartTime
		{
			get{ return m_RestartTime; }
			set{ m_RestartTime = value; }
		}

		public void Reset( TimeSpan restartDelay )
		{
			if ( restartDelay < TimeSpan.MaxValue )
				m_RestartTime = DateTime.Now + restartDelay;
			else
				m_RestartTime = DateTime.MaxValue;
		}

		public QuestRestartInfo( Type questType, TimeSpan restartDelay )
		{
			m_QuestType = questType;
			Reset( restartDelay );
		}

		public QuestRestartInfo( Type questType, DateTime restartTime )
		{
			m_QuestType = questType;
			m_RestartTime = restartTime;
		}
	}
}
// using System;

namespace Server.Engines.Quests
{
	public class QuestSerializer
	{
		public static object Construct( Type type )
		{
			try
			{
				return Activator.CreateInstance( type );
			}
			catch
			{
				return null;
			}
		}

		public static void Write( Type type, Type[] referenceTable, GenericWriter writer )
		{
			if ( type == null )
			{
				writer.WriteEncodedInt( (int) 0x00 );
			}
			else
			{
				for ( int i = 0; i < referenceTable.Length; ++i )
				{
					if ( referenceTable[i] == type )
					{
						writer.WriteEncodedInt( (int) 0x01 );
						writer.WriteEncodedInt( (int) i );
						return;
					}
				}

				writer.WriteEncodedInt( (int) 0x02 );
				writer.Write( type.FullName );
			}
		}

		public static Type ReadType( Type[] referenceTable, GenericReader reader )
		{
			int encoding = reader.ReadEncodedInt();

			switch ( encoding )
			{
				default:
				case 0x00: // null
				{
					return null;
				}
				case 0x01: // indexed
				{
					int index = reader.ReadEncodedInt();

					if ( index >= 0 && index < referenceTable.Length )
						return referenceTable[index];

					return null;
				}
				case 0x02: // by name
				{
					string fullName = reader.ReadString();

					if ( fullName == null )
						return null;

					return ScriptCompiler.FindTypeByFullName( fullName, false );
				}
			}
		}

		public static QuestSystem DeserializeQuest( GenericReader reader )
		{
			int encoding = reader.ReadEncodedInt();

			switch ( encoding )
			{
				default:
				case 0x00: // null
				{
					return null;
				}
				case 0x01:
				{
					Type type = ReadType( QuestSystem.QuestTypes, reader );

					QuestSystem qs = Construct( type ) as QuestSystem;

					if ( qs != null )
						qs.BaseDeserialize( reader );

					return qs;
				}
			}
		}

		public static void Serialize( QuestSystem qs, GenericWriter writer )
		{
			if ( qs == null )
			{
				writer.WriteEncodedInt( 0x00 );
			}
			else
			{
				writer.WriteEncodedInt( 0x01 );

				Write( qs.GetType(), QuestSystem.QuestTypes, writer );

				qs.BaseSerialize( writer );
			}
		}

		public static QuestObjective DeserializeObjective( Type[] referenceTable, GenericReader reader )
		{
			int encoding = reader.ReadEncodedInt();

			switch ( encoding )
			{
				default:
				case 0x00: // null
				{
					return null;
				}
				case 0x01:
				{
					Type type = ReadType( referenceTable, reader );

					QuestObjective obj = Construct( type ) as QuestObjective;

					if ( obj != null )
						obj.BaseDeserialize( reader );

					return obj;
				}
			}
		}

		public static void Serialize( Type[] referenceTable, QuestObjective obj, GenericWriter writer )
		{
			if ( obj == null )
			{
				writer.WriteEncodedInt( 0x00 );
			}
			else
			{
				writer.WriteEncodedInt( 0x01 );

				Write( obj.GetType(), referenceTable, writer );

				obj.BaseSerialize( writer );
			}
		}

		public static QuestConversation DeserializeConversation( Type[] referenceTable, GenericReader reader )
		{
			int encoding = reader.ReadEncodedInt();

			switch ( encoding )
			{
				default:
				case 0x00: // null
				{
					return null;
				}
				case 0x01:
				{
					Type type = ReadType( referenceTable, reader );

					QuestConversation conv = Construct( type ) as QuestConversation;

					if ( conv != null )
						conv.BaseDeserialize( reader );

					return conv;
				}
			}
		}

		public static void Serialize( Type[] referenceTable, QuestConversation conv, GenericWriter writer )
		{
			if ( conv == null )
			{
				writer.WriteEncodedInt( 0x00 );
			}
			else
			{
				writer.WriteEncodedInt( 0x01 );

				Write( conv.GetType(), referenceTable, writer );

				conv.BaseSerialize( writer );
			}
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.ContextMenus;

namespace Server.Engines.Quests
{
	public delegate void QuestCallback();

	public abstract class QuestSystem
	{
		public static readonly Type[] QuestTypes = new Type[]
			{
			};

		public abstract object Name{ get; }
		public abstract object OfferMessage{ get; }

		public abstract int Picture{ get; }

		public abstract bool IsTutorial{ get; }
		public abstract TimeSpan RestartDelay{ get; }

		public abstract Type[] TypeReferenceTable{ get; }

		private PlayerMobile m_From;
		private ArrayList m_Objectives;
		private ArrayList m_Conversations;

		public PlayerMobile From
		{
			get{ return m_From; }
			set{ m_From = value; }
		}

		public ArrayList Objectives
		{
			get{ return m_Objectives; }
			set{ m_Objectives = value; }
		}

		public ArrayList Conversations
		{
			get{ return m_Conversations; }
			set{ m_Conversations = value; }
		}

		private Timer m_Timer;

		public virtual void StartTimer()
		{
			if ( m_Timer != null )
				return;

			m_Timer = Timer.DelayCall( TimeSpan.FromSeconds( 0.5 ), TimeSpan.FromSeconds( 0.5 ), new TimerCallback( Slice ) );
		}

		public virtual void StopTimer()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			m_Timer = null;
		}

		public virtual void Slice()
		{
			for ( int i = m_Objectives.Count - 1; i >= 0; --i )
			{
				QuestObjective obj = (QuestObjective)m_Objectives[i];

				if ( obj.GetTimerEvent() )
					obj.CheckProgress();
			}
		}

		public virtual void OnKill( BaseCreature creature, Container corpse )
		{
			for ( int i = m_Objectives.Count - 1; i >= 0; --i )
			{
				QuestObjective obj = (QuestObjective)m_Objectives[i];

				if ( obj.GetKillEvent( creature, corpse ) )
					obj.OnKill( creature, corpse );
			}
		}

		public virtual bool IgnoreYoungProtection( Mobile from )
		{
			for ( int i = m_Objectives.Count - 1; i >= 0; --i )
			{
				QuestObjective obj = (QuestObjective)m_Objectives[i];

				if ( obj.IgnoreYoungProtection( from ) )
					return true;
			}

			return false;
		}

		public QuestSystem( PlayerMobile from )
		{
			m_From = from;
			m_Objectives = new ArrayList();
			m_Conversations = new ArrayList();
		}

		public QuestSystem()
		{
		}

		public virtual void BaseDeserialize( GenericReader reader )
		{
			Type[] referenceTable = this.TypeReferenceTable;

			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 0:
				{
					int count = reader.ReadEncodedInt();

					m_Objectives = new ArrayList( count );

					for ( int i = 0; i < count; ++i )
					{
						QuestObjective obj = QuestSerializer.DeserializeObjective( referenceTable, reader );

						if ( obj != null )
						{
							obj.System = this;
							m_Objectives.Add( obj );
						}
					}

					count = reader.ReadEncodedInt();

					m_Conversations = new ArrayList( count );

					for ( int i = 0; i < count; ++i )
					{
						QuestConversation conv = QuestSerializer.DeserializeConversation( referenceTable, reader );

						if ( conv != null )
						{
							conv.System = this;
							m_Conversations.Add( conv );
						}
					}

					break;
				}
			}

			ChildDeserialize( reader );
		}

		public virtual void ChildDeserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();
		}

		public virtual void BaseSerialize( GenericWriter writer )
		{
			Type[] referenceTable = this.TypeReferenceTable;

			writer.WriteEncodedInt( (int) 0 ); // version

			writer.WriteEncodedInt( (int) m_Objectives.Count );

			for ( int i = 0; i < m_Objectives.Count; ++i )
				QuestSerializer.Serialize( referenceTable, (QuestObjective) m_Objectives[i], writer );

			writer.WriteEncodedInt( (int) m_Conversations.Count );

			for ( int i = 0; i < m_Conversations.Count; ++i )
				QuestSerializer.Serialize( referenceTable, (QuestConversation) m_Conversations[i], writer );

			ChildSerialize( writer );
		}

		public virtual void ChildSerialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public bool IsObjectiveInProgress( Type type )
		{
			QuestObjective obj = FindObjective( type );

			return ( obj != null && !obj.Completed );
		}

		public QuestObjective FindObjective( Type type )
		{
			for ( int i = m_Objectives.Count - 1; i >= 0; --i )
			{
				QuestObjective obj = (QuestObjective)m_Objectives[i];

				if ( obj.GetType() == type )
					return obj;
			}

			return null;
		}

		public virtual void SendOffer()
		{
			m_From.SendGump( new QuestOfferGump( this ) );
		}

		public virtual void GetContextMenuEntries( List<ContextMenuEntry> list )
		{
			if ( m_Objectives.Count > 0 )
				list.Add( new QuestCallbackEntry( 6154, new QuestCallback( ShowQuestLog ) ) ); // View Quest Log

			if ( m_Conversations.Count > 0 )
				list.Add( new QuestCallbackEntry( 6156, new QuestCallback( ShowQuestConversation ) ) ); // Quest Conversation

			list.Add( new QuestCallbackEntry( 6155, new QuestCallback( BeginCancelQuest ) ) ); // Cancel Quest
		}

		public virtual void ShowQuestLogUpdated()
		{
			m_From.CloseGump( typeof( QuestLogUpdatedGump ) );
			m_From.SendGump( new QuestLogUpdatedGump( this ) );
		}

		public virtual void ShowQuestLog()
		{
			if ( m_Objectives.Count > 0 )
			{
				m_From.CloseGump( typeof( QuestItemInfoGump ) );
				m_From.CloseGump( typeof( QuestLogUpdatedGump ) );
				m_From.CloseGump( typeof( QuestObjectivesGump ) );
				m_From.CloseGump( typeof( QuestConversationsGump ) );

				m_From.SendGump( new QuestObjectivesGump( m_Objectives ) );

				QuestObjective last = (QuestObjective)m_Objectives[m_Objectives.Count - 1];

				if ( last.Info != null )
					m_From.SendGump( new QuestItemInfoGump( last.Info ) );
			}
		}

		public virtual void ShowQuestConversation()
		{
			if ( m_Conversations.Count > 0 )
			{
				m_From.CloseGump( typeof( QuestItemInfoGump ) );
				m_From.CloseGump( typeof( QuestObjectivesGump ) );
				m_From.CloseGump( typeof( QuestConversationsGump ) );

				m_From.SendGump( new QuestConversationsGump( m_Conversations ) );

				QuestConversation last = (QuestConversation)m_Conversations[m_Conversations.Count - 1];

				if ( last.Info != null )
					m_From.SendGump( new QuestItemInfoGump( last.Info ) );
			}
		}

		public virtual void BeginCancelQuest()
		{
			m_From.SendGump( new QuestCancelGump( this ) );
		}

		public virtual void EndCancelQuest( bool shouldCancel )
		{
			if ( m_From.Quest != this )
				return;

			if ( shouldCancel )
			{
				m_From.SendLocalizedMessage( 1049015 ); // You have canceled your quest.
				Cancel();
			}
			else
			{
				m_From.SendLocalizedMessage( 1049014 ); // You have chosen not to cancel your quest.
			}
		}

		public virtual void Cancel()
		{
			ClearQuest( false );
		}

		public virtual void Complete()
		{
			ClearQuest( true );
		}

		public virtual void ClearQuest( bool completed )
		{
			StopTimer();

			if ( m_From.Quest == this )
			{
				m_From.Quest = null;

				TimeSpan restartDelay = this.RestartDelay;

				if ( ( completed && restartDelay > TimeSpan.Zero ) || ( !completed && restartDelay == TimeSpan.MaxValue ) )
				{
					List<QuestRestartInfo> doneQuests = m_From.DoneQuests;

					if ( doneQuests == null )
						m_From.DoneQuests = doneQuests = new List<QuestRestartInfo>();

					bool found = false;

					Type ourQuestType = this.GetType();

					for ( int i = 0; i < doneQuests.Count; ++i )
					{
						QuestRestartInfo restartInfo = doneQuests[i];

						if ( restartInfo.QuestType == ourQuestType )
						{
							restartInfo.Reset( restartDelay );
							found = true;
							break;
						}
					}

					if ( !found )
						doneQuests.Add( new QuestRestartInfo( ourQuestType, restartDelay ) );
				}
			}
		}

		public virtual void AddConversation( QuestConversation conv )
		{
			conv.System = this;

			if ( conv.Logged )
				m_Conversations.Add( conv );

			m_From.CloseGump( typeof( QuestItemInfoGump ) );
			m_From.CloseGump( typeof( QuestObjectivesGump ) );
			m_From.CloseGump( typeof( QuestConversationsGump ) );

			if ( conv.Logged )
				m_From.SendGump( new QuestConversationsGump( m_Conversations ) );
			else
				m_From.SendGump( new QuestConversationsGump( conv ) );

			if ( conv.Info != null )
				m_From.SendGump( new QuestItemInfoGump( conv.Info ) );
		}

		public virtual void AddObjective( QuestObjective obj )
		{
			obj.System = this;
			m_Objectives.Add( obj );

			ShowQuestLogUpdated();
		}

		public virtual void Accept()
		{
			if ( m_From.Quest != null )
				return;

			m_From.Quest = this;
			m_From.SendLocalizedMessage( 1049019 ); // You have accepted the Quest.

			StartTimer();
		}

		public virtual void Decline()
		{
			m_From.SendLocalizedMessage( 1049018 ); // You have declined the Quest.
		}

		public static bool CanOfferQuest( Mobile check, Type questType )
		{
			bool inRestartPeriod;

			return CanOfferQuest( check, questType, out inRestartPeriod );
		}

		public static bool CanOfferQuest( Mobile check, Type questType, out bool inRestartPeriod )
		{
			inRestartPeriod = false;

			PlayerMobile pm = check as PlayerMobile;

			if ( pm == null )
				return false;

			if ( pm.HasGump( typeof( QuestOfferGump ) ) )
				return false;

			List<QuestRestartInfo> doneQuests = pm.DoneQuests;

			if ( doneQuests != null )
			{
				for ( int i = 0; i < doneQuests.Count; ++i )
				{
					QuestRestartInfo restartInfo = doneQuests[i];

					if ( restartInfo.QuestType == questType )
					{
						DateTime endTime = restartInfo.RestartTime;

						if ( DateTime.Now < endTime )
						{
							inRestartPeriod = true;
							return false;
						}

						doneQuests.RemoveAt( i-- );
						return true;
					}
				}
			}

			return true;
		}

		public static void FocusTo( Mobile who, Mobile to )
		{
			if ( Utility.RandomBool() )
			{
				who.Animate( 17, 7, 1, true, false, 0 );
			}
			else
			{
				switch ( Utility.Random( 3 ) )
				{
					case 0: who.Animate( 32, 7, 1, true, false, 0 ); break;
					case 1: who.Animate( 33, 7, 1, true, false, 0 ); break;
					case 2: who.Animate( 34, 7, 1, true, false, 0 ); break;
				}
			}

			who.Direction = who.GetDirectionTo( to );
		}

		public static int RandomBrightHue()
		{
			if ( 0.1 > Utility.RandomDouble() )
				return Utility.RandomList( 0x62, 0x71 );

			return Utility.RandomList( 0x03, 0x0D, 0x13, 0x1C, 0x21, 0x30, 0x37, 0x3A, 0x44, 0x59 );
		}
	}

	public class QuestCancelGump : BaseQuestGump
	{
		private QuestSystem m_System;

		public QuestCancelGump( QuestSystem system ) : base( 120, 50 )
		{
			m_System = system;

			Closable = false;

			AddPage( 0 );

			AddImageTiled( 0, 0, 348, 262, 2702 );
			AddAlphaRegion( 0, 0, 348, 262 );

			AddImage( 0, 15, 10152 );
			AddImageTiled( 0, 30, 17, 200, 10151 );
			AddImage( 0, 230, 10154 );

			AddImage( 15, 0, 10252 );
			AddImageTiled( 30, 0, 300, 17, 10250 );
			AddImage( 315, 0, 10254 );

			AddImage( 15, 244, 10252 );
			AddImageTiled( 30, 244, 300, 17, 10250 );
			AddImage( 315, 244, 10254 );

			AddImage( 330, 15, 10152 );
			AddImageTiled( 330, 30, 17, 200, 10151 );
			AddImage( 330, 230, 10154 );

			AddImage( 333, 2, 10006 );
			AddImage( 333, 248, 10006 );
			AddImage( 2, 248, 10006 );
			AddImage( 2, 2, 10006 );

			AddHtmlLocalized( 25, 22, 200, 20, 1049000, 32000, false, false ); // Confirm Quest Cancellation
			AddImage( 25, 40, 3007 );

			if ( system.IsTutorial )
			{
				AddHtmlLocalized( 25, 55, 300, 120, 1060836, White, false, false ); // This quest will give you valuable information, skills and equipment that will help you advance in the game at a quicker pace.<BR><BR>Are you certain you wish to cancel at this time?
			}
			else
			{
				AddHtmlLocalized( 25, 60, 300, 20, 1049001, White, false, false ); // You have chosen to abort your quest:
				AddImage( 25, 81, 0x25E7 );
				AddHtmlObject( 48, 80, 280, 20, system.Name, DarkGreen, false, false );

				AddHtmlLocalized( 25, 120, 280, 20, 1049002, White, false, false ); // Can this quest be restarted after quitting?
				AddImage( 25, 141, 0x25E7 );
				AddHtmlLocalized( 48, 140, 280, 20, (system.RestartDelay < TimeSpan.MaxValue) ? 1049016 : 1049017, DarkGreen, false, false ); // Yes/No
			}

			AddRadio( 25, 175, 9720, 9723, true, 1 );
			AddHtmlLocalized( 60, 180, 280, 20, 1049005, White, false, false ); // Yes, I really want to quit!

			AddRadio( 25, 210, 9720, 9723, false, 0 );
			AddHtmlLocalized( 60, 215, 280, 20, 1049006, White, false, false ); // No, I don't want to quit.

			AddButton( 265, 220, 247, 248, 1, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				m_System.EndCancelQuest( info.IsSwitched( 1 ) );
		}
	}

	public class QuestOfferGump : BaseQuestGump
	{
		private QuestSystem m_System;

		public QuestOfferGump( QuestSystem system ) : base( 75, 25 )
		{
			m_System = system;

			Closable = false;

			AddPage( 0 );

			AddImageTiled( 50, 20, 400, 400, 2624 );
			AddAlphaRegion( 50, 20, 400, 400 );

			AddImage( 90, 33, 9005 );
			AddHtmlLocalized( 130, 45, 270, 20, 1049010, White, false, false ); // Quest Offer
			AddImageTiled( 130, 65, 175, 1, 9101 );

			AddImage( 140, 110, 1209 );
			AddHtmlObject( 160, 108, 250, 20, system.Name, DarkGreen, false, false );

			AddHtmlObject( 98, 140, 312, 200, system.OfferMessage, LightGreen, false, true );

			AddRadio( 85, 350, 9720, 9723, true, 1 );
			AddHtmlLocalized( 120, 356, 280, 20, 1049011, White, false, false ); // I accept!

			AddRadio( 85, 385, 9720, 9723, false, 0 );
			AddHtmlLocalized( 120, 391, 280, 20, 1049012, White, false, false ); // No thanks, I decline.

			AddButton( 340, 390, 247, 248, 1, GumpButtonType.Reply, 0 );

			AddImageTiled( 50, 29, 30, 390, 10460 );
			AddImageTiled( 34, 140, 17, 279, 9263 );

			AddImage( 48, 135, 10411 );
			AddImage( -16, 285, 10402 );
			AddImage( 0, 10, 10421 );
			AddImage( 25, 0, 10420 );

			AddImageTiled( 83, 15, 350, 15, 10250 );

			AddImage( 34, 419, 10306 );
			AddImage( 442, 419, 10304 );
			AddImageTiled( 51, 419, 392, 17, 10101 );

			AddImageTiled( 415, 29, 44, 390, 2605 );
			AddImageTiled( 415, 29, 30, 390, 10460 );
			AddImage( 425, 0, 10441 );

			AddImage( 370, 50, 1417 );
			AddImage( 379, 60, system.Picture );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
			{
				if ( info.IsSwitched( 1 ) )
					m_System.Accept();
				else
					m_System.Decline();
			}
		}
	}

	public abstract class BaseQuestGump : Gump
	{
		public const int Black = 0x0000;
		public const int White = 0x7FFF;
		public const int DarkGreen = 10000;
		public const int LightGreen = 90000;
		public const int Blue = 19777215;

		public static int C16232( int c16 )
		{
			c16 &= 0x7FFF;

			int r = ( ((c16 >> 10) & 0x1F) << 3 );
			int g = ( ((c16 >> 05) & 0x1F) << 3 );
			int b = ( ((c16 >> 00) & 0x1F) << 3 );

			return (r << 16) | (g << 8) | (b << 0);
		}

		public static int C16216( int c16 )
		{
			return c16 & 0x7FFF;
		}

		public static int C32216( int c32 )
		{
			c32 &= 0xFFFFFF;

			int r = ( ((c32 >> 16) & 0xFF) >> 3 );
			int g = ( ((c32 >> 08) & 0xFF) >> 3 );
			int b = ( ((c32 >> 00) & 0xFF) >> 3 );

			return (r << 10) | (g << 5) | (b << 0);
		}

		public static string Color( string text, int color )
		{
			return String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text );
		}

		public static ArrayList BuildList( object obj )
		{
			ArrayList list = new ArrayList();

			list.Add( obj );

			return list;
		}

		public void AddHtmlObject( int x, int y, int width, int height, object message, int color, bool back, bool scroll )
		{
			if ( message is string )
			{
				string html = (string)message;

				AddHtml( x, y, width, height, Color( html, C16232( color ) ), back, scroll );
			}
			else if ( message is int )
			{
				int html = (int)message;

				AddHtmlLocalized( x, y, width, height, html, C16216( color ), back, scroll );
			}
		}

		public BaseQuestGump( int x, int y ) : base( x, y )
		{
		}
	}
}
// using System;

namespace Server.Factions
{
	public class RankDefinition
	{
		private int m_Rank;
		private int m_Required;
		private int m_MaxWearables;
		private TextDefinition m_Title;

		public int Rank{ get{ return m_Rank; } }
		public int Required{ get{ return m_Required; } }
		public int MaxWearables{ get{ return m_MaxWearables; } }
		public TextDefinition Title{ get{ return m_Title; } }

		public RankDefinition( int rank, int required, int maxWearables, TextDefinition title )
		{
			m_Rank = rank;
			m_Required = required;
			m_Title = title;
			m_MaxWearables = maxWearables;
		}
	}
}
// using System;// using Server.Items;// using Server.Mobiles;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a raptor corpse" )]
	public class Raptor : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Raptor() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a raptor";
			Body = 218;
			BaseSoundID = 0x5A;

			SetStr( 126, 150 );
			SetDex( 56, 75 );
			SetInt( 11, 20 );

			SetHits( 76, 90 );
			SetMana( 0 );

			SetDamage( 6, 24 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 45 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 80.7;
		}

		public override void OnAfterSpawn()
		{
			base.OnAfterSpawn();

			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" ){ this.Body = 219; Utility.RandomList( 219, 116 ); this.Name = "a darkrazor"; }
			else if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Isles of Dread" ){ this.Body = 117; }
		}

		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }

		public override int GetAttackSound(){ return 0x622; }	// A
		public override int GetDeathSound(){ return 0x623; }	// D
		public override int GetHurtSound(){ return 0x624; }		// H

		public Raptor(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server.Items;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a ravenous corpse" )]
	public class Ravenous : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Ravenous() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a ravenous";
			Body = 218;
			BaseSoundID = 0x5A;
			Hue = 0x84E;

			SetStr( 166, 190 );
			SetDex( 96, 115 );
			SetInt( 51, 60 );

			SetHits( 116, 130 );
			SetMana( 0 );

			SetDamage( 12, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 45 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 25, 35 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 90.7;
		}

		public override int GetAttackSound(){ return 0x622; }	// A
		public override int GetDeathSound(){ return 0x623; }	// D
		public override int GetHurtSound(){ return 0x624; }		// H

		public override HideType HideType{ get{ return HideType.Dinosaur; } }
		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }

		public Ravenous(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Reflection;// using System.Collections;// using Server;// using System.Collections.Generic;

namespace Server.Factions
{
	public class Reflector
	{
		private static List<Type> m_Types = new List<Type>();

		private static List<Town> m_Towns;

		public static List<Town> Towns
		{
			get
			{
				if ( m_Towns == null )
					ProcessTypes();

				return m_Towns;
			}
		}

		private static List<Faction> m_Factions;

		public static List<Faction> Factions
		{
			get
			{
				if ( m_Factions == null )
					Reflector.ProcessTypes();

				return m_Factions;
			}
		}

		public static void Configure()
		{
			EventSink.WorldSave += new WorldSaveEventHandler( EventSink_WorldSave );
		}

		private static void EventSink_WorldSave( WorldSaveEventArgs e )
		{
			m_Types.Clear();
		}

		public static void Serialize( GenericWriter writer, Type type )
		{
			int index = m_Types.IndexOf( type );

			writer.WriteEncodedInt( (int) (index + 1) );

			if ( index == -1 )
			{
				writer.Write( type == null ? null : type.FullName );
				m_Types.Add( type );
			}
		}

		public static Type Deserialize( GenericReader reader )
		{
			int index = reader.ReadEncodedInt();

			if ( index == 0 )
			{
				string typeName = reader.ReadString();

				if ( typeName == null )
					m_Types.Add( null );
				else
					m_Types.Add( ScriptCompiler.FindTypeByFullName( typeName, false ) );

				return m_Types[m_Types.Count - 1];
			}
			else
			{
				return m_Types[index - 1];
			}
		}

		private static object Construct( Type type )
		{
			try{ return Activator.CreateInstance( type ); }
			catch{ return null; }
		}

		private static void ProcessTypes()
		{
			m_Factions = new List<Faction>();
			m_Towns = new List<Town>();

			Assembly[] asms = ScriptCompiler.Assemblies;

			for ( int i = 0; i < asms.Length; ++i )
			{
				Assembly asm = asms[i];
				TypeCache tc = ScriptCompiler.GetTypeCache( asm );
				Type[] types = tc.Types;

				for ( int j = 0; j < types.Length; ++j )
				{
					Type type = types[j];

					if ( type.IsSubclassOf( typeof( Faction ) ) )
					{
						Faction faction = Construct( type ) as Faction;

						if ( faction != null )
							Faction.Factions.Add( faction );
					}
					else if ( type.IsSubclassOf( typeof( Town ) ) )
					{
						Town town = Construct( type ) as Town;

						if ( town != null )
							Town.Towns.Add( town );
					}
				}
			}
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;

namespace Server.Engines.CannedEvil
{
	public class RestartTimer : Timer
	{
		private ChampionSpawn m_Spawn;

		public RestartTimer( ChampionSpawn spawn, TimeSpan delay ) : base( delay )
		{
			m_Spawn = spawn;
			Priority = TimerPriority.FiveSeconds;
		}

		protected override void OnTick()
		{
			m_Spawn.EndRestart();
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;

namespace Server.Engines.VeteranRewards
{
	public class RewardCategory
	{
		private int m_Name;
		private string m_NameString;
		private List<RewardEntry> m_Entries;

		public int Name{ get{ return m_Name; } }
		public string NameString{ get{ return m_NameString; } }
		public List<RewardEntry> Entries { get { return m_Entries; } }

		public RewardCategory( int name )
		{
			m_Name = name;
			m_Entries = new List<RewardEntry>();
		}

		public RewardCategory( string name )
		{
			m_NameString = name;
			m_Entries = new List<RewardEntry>();
		}
	}
}
// using System;// using System.Collections;// using System.Collections.Generic;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server.Engines.VeteranRewards
{
	public class RewardChoiceGump : Gump
	{
		private Mobile m_From;

		private void RenderBackground()
		{
			AddPage( 0 );

			AddBackground( 10, 10, 600, 450, 2600 );

			AddButton( 530, 415, 4017, 4019, 0, GumpButtonType.Reply, 0 );

			AddButton( 60, 415, 4014, 4016, 0, GumpButtonType.Page, 1 );
			AddHtmlLocalized( 95, 415, 200, 20, 1049755, false, false ); // Main Menu
		}

		private void RenderCategories()
		{
			TimeSpan rewardInterval = RewardSystem.RewardInterval;

			string intervalAsString;

			if ( rewardInterval == TimeSpan.FromDays( 30.0 ) )
				intervalAsString = "month";
			else if ( rewardInterval == TimeSpan.FromDays( 60.0 ) )
				intervalAsString = "two months";
			else if ( rewardInterval == TimeSpan.FromDays( 90.0 ) )
				intervalAsString = "three months";
			else if ( rewardInterval == TimeSpan.FromDays( 365.0 ) )
				intervalAsString = "year";
			else
				intervalAsString = String.Format( "{0} day{1}", rewardInterval.TotalDays, rewardInterval.TotalDays == 1 ? "" : "s" );

			AddPage( 1 );

			AddHtml( 60, 35, 500, 70, "<B>Game Rewards Program</B><BR>" +
									"Thank you for being a part of the game community for a full " + intervalAsString + ".  " +
									"As a token of our appreciation,  you may select from the following in-game reward items listed below.  " +
									"The gift items will be attributed to the character you have logged-in with on the shard you are on when you chose the item(s).  " +
									"The number of rewards you are entitled to are listed below and are for your entire account.  " +
									"To read more about these rewards before making a selection, feel free to visit the uo.com site at " +
									"<A HREF=\"http://www.uo.com/rewards\">http://www.uo.com/rewards</A>.", true, true );

			int cur, max;

			RewardSystem.ComputeRewardInfo( m_From, out cur, out max );

			AddHtmlLocalized( 60, 105, 300, 35, 1006006, false, false ); // Your current total of rewards to choose:
			AddLabel( 370, 107, 50, (max - cur).ToString() );

			AddHtmlLocalized( 60, 140, 300, 35, 1006007, false, false ); // You have already chosen:
			AddLabel( 370, 142, 50, cur.ToString() );

			RewardCategory[] categories = RewardSystem.Categories;

			int page = 2;

			for ( int i = 0; i < categories.Length; ++i )
			{
				if ( !RewardSystem.HasAccess( m_From, categories[i] ) )
				{
					page += 1;
					continue;
				}

				AddButton( 100, 180 + (i * 40), 4005, 4005, 0, GumpButtonType.Page, page );

				page += PagesPerCategory( categories[ i ] );

				if ( categories[i].NameString != null )
					AddHtml( 135, 180 + (i * 40), 300, 20, categories[i].NameString, false, false );
				else
					AddHtmlLocalized( 135, 180 + (i * 40), 300, 20, categories[i].Name, false, false );
			}

			page = 2;

			for ( int i = 0; i < categories.Length; ++i )
				RenderCategory( categories[ i ], i, ref page );
		}

		private int PagesPerCategory( RewardCategory category )
		{
			List<RewardEntry> entries = category.Entries;
			int j = 0, i = 0;

			for ( j = 0; j < entries.Count; j++ )
			{
				if ( RewardSystem.HasAccess( m_From, entries[ j ] ) )
					i++;
			}

			return (int) Math.Ceiling( i / 24.0 );
		}

		private int GetButtonID( int type, int index )
		{
			return 2 + (index * 20) + type;
		}

		private void RenderCategory( RewardCategory category, int index, ref int page )
		{
			AddPage( page );

			List<RewardEntry> entries = category.Entries;

			int i = 0;

			for ( int j = 0; j < entries.Count; ++j )
			{
				RewardEntry entry = entries[j];

				if ( !RewardSystem.HasAccess( m_From, entry ) )
					continue;

				if ( i == 24 )
				{
					AddButton( 305, 415, 0xFA5, 0xFA7, 0, GumpButtonType.Page, ++page );
					AddHtmlLocalized( 340, 415, 200, 20, 1011066, false, false ); // Next page

					AddPage( page );

					AddButton( 270, 415, 0xFAE, 0xFB0, 0, GumpButtonType.Page, page - 1 );
					AddHtmlLocalized( 185, 415, 200, 20, 1011067, false, false ); // Previous page

					i = 0;
				}

				AddButton( 55 + ((i / 12) * 250), 80 + ((i % 12) * 25), 5540, 5541, GetButtonID( index, j ), GumpButtonType.Reply, 0 );

				if ( entry.NameString != null )
					AddHtml( 80 + ((i / 12) * 250), 80 + ((i % 12) * 25), 250, 20, entry.NameString, false, false );
				else
					AddHtmlLocalized( 80 + ((i / 12) * 250), 80 + ((i % 12) * 25), 250, 20, entry.Name, false, false );
				++i;
			}

			page += 1;
		}

		public RewardChoiceGump( Mobile from ) : base( 0, 0 )
		{
			m_From = from;

			from.CloseGump( typeof( RewardChoiceGump ) );

			RenderBackground();
			RenderCategories();
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int buttonID = info.ButtonID - 1;

			if ( buttonID == 0 )
			{
				int cur, max;

				RewardSystem.ComputeRewardInfo( m_From, out cur, out max );

				if ( cur < max )
					m_From.SendGump( new RewardNoticeGump( m_From ) );
			}
			else
			{
				--buttonID;

				int type = (buttonID % 20);
				int index = (buttonID / 20);

				RewardCategory[] categories = RewardSystem.Categories;

				if ( type >= 0 && type < categories.Length )
				{
					RewardCategory category = categories[type];

					if ( index >= 0 && index < category.Entries.Count )
					{
						RewardEntry entry = category.Entries[index];

						if ( !RewardSystem.HasAccess( m_From, entry ) )
							return;

						m_From.SendGump( new RewardConfirmGump( m_From, entry ) );
					}
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server.Engines.VeteranRewards
{
	public class RewardConfirmGump : Gump
	{
		private Mobile m_From;
		private RewardEntry m_Entry;

		public RewardConfirmGump( Mobile from, RewardEntry entry ) : base( 0, 0 )
		{
			m_From = from;
			m_Entry = entry;

			from.CloseGump( typeof( RewardConfirmGump ) );

			AddPage( 0 );

			AddBackground( 10, 10, 500, 300, 2600 );

			AddHtmlLocalized( 30, 55, 300, 35, 1006000, false, false ); // You have selected:

			if ( entry.NameString != null )
				AddHtml( 335, 55, 150, 35, entry.NameString, false, false );
			else
				AddHtmlLocalized( 335, 55, 150, 35, entry.Name, false, false );

			AddHtmlLocalized( 30, 95, 300, 35, 1006001, false, false ); // This will be assigned to this character:
			AddLabel( 335, 95, 0, from.Name );

			AddHtmlLocalized( 35, 160, 450, 90, 1006002, true, true ); // Are you sure you wish to select this reward for this character?  You will not be able to transfer this reward to another character on another shard.  Click 'ok' below to confirm your selection or 'cancel' to go back to the selection screen.

			AddButton( 60, 265, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 95, 266, 150, 35, 1006044, false, false ); // Ok

			AddButton( 295, 265, 4017, 4019, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 330, 266, 150, 35, 1006045, false, false ); // Cancel
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
			{
				if ( !RewardSystem.HasAccess( m_From, m_Entry ) )
					return;

				Item item = m_Entry.Construct();

				if ( item != null )
				{
					if ( item is Server.Items.RedSoulstone )
						((Server.Items.RedSoulstone) item).Account = m_From.Account.Username;

					if ( RewardSystem.ConsumeRewardPoint( m_From ) )
						m_From.AddToBackpack( item );
					else
						item.Delete();
				}
			}

			int cur, max;

			RewardSystem.ComputeRewardInfo( m_From, out cur, out max );

			if ( cur < max )
				m_From.SendGump( new RewardNoticeGump( m_From ) );
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Multis;// using Server.Network;

namespace Server.Gumps
{
	public class RewardDemolitionGump : Gump
	{
		private IAddon m_Addon;

		private enum Buttons
		{
			Cancel,
			Confirm,
		}

		public RewardDemolitionGump( IAddon addon, int question ) : base( 150, 50 )
		{
			m_Addon = addon;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddBackground( 0, 0, 220, 170, 0x13BE );
			AddBackground( 10, 10, 200, 150, 0xBB8 );

			AddHtmlLocalized( 20, 30, 180, 60, question, false, false ); // Do you wish to re-deed this decoration?

			AddHtmlLocalized( 55, 100, 150, 25, 1011011, false, false ); // CONTINUE
			AddButton( 20, 100, 0xFA5, 0xFA7, (int) Buttons.Confirm, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 125, 150, 25, 1011012, false, false ); // CANCEL
			AddButton( 20, 125, 0xFA5, 0xFA7, (int) Buttons.Cancel, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Item item = m_Addon as Item;

			if ( item == null || item.Deleted )
				return;

			if ( info.ButtonID == (int) Buttons.Confirm )
			{
				Mobile m = sender.Mobile;
				BaseHouse house = BaseHouse.FindHouseAt( m );

				if ( house != null && house.IsOwner( m ) )
				{
					if ( m.InRange( item.Location, 2 ) )
					{
						Item deed = m_Addon.Deed;

						if ( deed != null )
						{
							m.AddToBackpack( deed );
							house.Addons.Remove( item );
							item.Delete();
						}
					}
					else
						m.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				}
				else
					m.SendLocalizedMessage( 1049784 ); // You can only re-deed this decoration if you are the house owner or originally placed the decoration.
			}
		}
	}
}// using System;

namespace Server.Engines.VeteranRewards
{
	public class RewardEntry
	{
		private RewardList m_List;
		private RewardCategory m_Category;
		private Type m_ItemType;
		private Expansion m_RequiredExpansion;
		private int m_Name;
		private string m_NameString;
		private object[] m_Args;

		public RewardList List{ get{ return m_List; } set{ m_List = value; } }
		public RewardCategory Category{ get{ return m_Category; } }
		public Type ItemType{ get{ return m_ItemType; } }
		public Expansion RequiredExpansion{ get{ return m_RequiredExpansion; } }
		public int Name{ get{ return m_Name; } }
		public string NameString{ get{ return m_NameString; } }
		public object[] Args{ get{ return m_Args; } }

		public Item Construct()
		{
			try
			{
				Item item = Activator.CreateInstance( m_ItemType, m_Args ) as Item;

				if ( item is IRewardItem )
					((IRewardItem)item).IsRewardItem = true;

				return item;
			}
			catch
			{
			}

			return null;
		}

		public RewardEntry( RewardCategory category, int name, Type itemType, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = Expansion.None;
			m_Name = name;
			m_Args = args;
			category.Entries.Add( this );
		}

		public RewardEntry( RewardCategory category, string name, Type itemType, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = Expansion.None;
			m_NameString = name;
			m_Args = args;
			category.Entries.Add( this );
		}

		public RewardEntry( RewardCategory category, int name, Type itemType, Expansion requiredExpansion, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = requiredExpansion;
			m_Name = name;
			m_Args = args;
			category.Entries.Add( this );
		}

		public RewardEntry( RewardCategory category, string name, Type itemType, Expansion requiredExpansion, params object[] args )
		{
			m_Category = category;
			m_ItemType = itemType;
			m_RequiredExpansion = requiredExpansion;
			m_NameString = name;
			m_Args = args;
			category.Entries.Add( this );
		}
	}
}
// using System;

namespace Server.Engines.VeteranRewards
{
	public class RewardList
	{
		private TimeSpan m_Age;
		private RewardEntry[] m_Entries;

		public TimeSpan Age{ get{ return m_Age; } }
		public RewardEntry[] Entries{ get{ return m_Entries; } }

		public RewardList( TimeSpan interval, int index, RewardEntry[] entries )
		{
			m_Age = TimeSpan.FromDays( interval.TotalDays * index );
			m_Entries = entries;

			for ( int i = 0; i < entries.Length; ++i )
				entries[i].List = this;
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server.Engines.VeteranRewards
{
	public class RewardNoticeGump : Gump
	{
		private Mobile m_From;

		public RewardNoticeGump( Mobile from ) : base( 0, 0 )
		{
			m_From = from;

			from.CloseGump( typeof( RewardNoticeGump ) );

			AddPage( 0 );

			AddBackground( 10, 10, 500, 135, 2600 );

			/* You have reward items available.
			 * Click 'ok' below to get the selection menu or 'cancel' to be prompted upon your next login.
			 */
			AddHtmlLocalized( 52, 35, 420, 55, 1006046, true, true );

			AddButton( 60, 95, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 95, 96, 150, 35, 1006044, false, false ); // Ok

			AddButton( 285, 95, 4017, 4019, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 320, 96, 150, 35, 1006045, false, false ); // Cancel
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
				m_From.SendGump( new RewardChoiceGump( m_From ) );
		}
	}
}
// using System;// using System.Collections.Generic;
// using Server;// using Server.Gumps;// using Server.Network;

namespace Server.Gumps
{
	public interface IRewardOption
	{
		void GetOptions( RewardOptionList list );
		void OnOptionSelected( Mobile from, int choice );
	}

	public class RewardOptionGump : Gump
	{
		private RewardOptionList m_Options = new RewardOptionList();
		private IRewardOption m_Option;

		public RewardOptionGump( IRewardOption option ) : this( option, 0 )
		{
		}

		public RewardOptionGump( IRewardOption option, int title ) : base( 60, 36 )
		{
			m_Option = option;

			if ( m_Option != null )
				m_Option.GetOptions( m_Options );

			AddPage( 0 );

			AddBackground( 0, 0, 273, 324, 0x13BE );
			AddImageTiled( 10, 10, 253, 20, 0xA40 );
			AddImageTiled( 10, 40, 253, 244, 0xA40 );
			AddImageTiled( 10, 294, 253, 20, 0xA40 );
			AddAlphaRegion( 10, 10, 253, 304 );

			AddButton( 10, 294, 0xFB1, 0xFB2, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 45, 296, 450, 20, 1060051, 0x7FFF, false, false ); // CANCEL

			if ( title > 0 )
				AddHtmlLocalized( 14, 12, 273, 20, title, 0x7FFF, false, false );
			else
				AddHtmlLocalized( 14, 12, 273, 20, 1080392, 0x7FFF, false, false ); // Select your choice from the menu below.

			AddPage( 1 );

			for ( int i = 0; i < m_Options.Count; i++ )
			{
				AddButton( 19, 49 + i * 24, 0x845, 0x846, m_Options[ i ].ID, GumpButtonType.Reply, 0 );
				AddHtmlLocalized( 44, 47 + i * 24, 213, 20, m_Options[ i ].Cliloc, 0x7FFF, false, false );
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Option != null && Contains( info.ButtonID ) )
				m_Option.OnOptionSelected( sender.Mobile, info.ButtonID );
		}

		private bool Contains( int chosen )
		{
			if ( m_Options == null )
				return false;

			foreach ( RewardOption option in m_Options )
			{
				if ( option.ID == chosen )
					return true;
			}

			return false;
		}
	}

	public class RewardOption
	{
		private int m_ID;
		private int m_Cliloc;

		public int ID{ get{ return m_ID; } }
		public int Cliloc{ get{ return m_Cliloc; } }

		public RewardOption( int id, int cliloc )
		{
			m_ID = id;
			m_Cliloc = cliloc;
		}
	}

	public class RewardOptionList : List<RewardOption>
	{
		public RewardOptionList() : base()
		{
		}

		public void Add( int id, int cliloc )
		{
			Add( new RewardOption( id, cliloc ) );
		}
	}
}// using System;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Accounting;// using System.Collections;// using System.Collections.Generic;

namespace Server.Engines.VeteranRewards
{
	public class RewardSystem
	{
		private static RewardCategory[] m_Categories;
		private static RewardList[] m_Lists;

		public static RewardCategory[] Categories
		{
			get
			{
				if ( m_Categories == null )
					SetupRewardTables();

				return m_Categories;
			}
		}

		public static RewardList[] Lists
		{
			get
			{
				if ( m_Lists == null )
					SetupRewardTables();

				return m_Lists;
			}
		}

		public static bool Enabled = false; // change to true to enable vet rewards
		public static bool SkillCapRewards = true; // assuming vet rewards are enabled, should total skill cap bonuses be awarded? (720 skills total at 4th level)
		public static TimeSpan RewardInterval = TimeSpan.FromDays( 30.0 );

		public static bool HasAccess( Mobile mob, RewardCategory category )
		{
			List<RewardEntry> entries = category.Entries;

			for ( int j = 0; j < entries.Count; ++j )
			{
				//RewardEntry entry = entries[j];
				if ( RewardSystem.HasAccess( mob, entries[j] ) )
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasAccess( Mobile mob, RewardEntry entry )
		{
			if ( Core.Expansion < entry.RequiredExpansion )
			{
				return false;
			}

			TimeSpan ts;
			return HasAccess( mob, entry.List, out ts );
		}

		public static bool HasAccess( Mobile mob, RewardList list, out TimeSpan ts )
		{
			if ( list == null )
			{
				ts = TimeSpan.Zero;
				return false;
			}

			Account acct = mob.Account as Account;

			if ( acct == null )
			{
				ts = TimeSpan.Zero;
				return false;
			}

			TimeSpan totalTime = (DateTime.Now - acct.Created);

			ts = ( list.Age - totalTime );

			if ( ts <= TimeSpan.Zero )
				return true;

			return false;
		}

		public static int GetRewardLevel( Mobile mob )
		{
			Account acct = mob.Account as Account;

			if ( acct == null )
				return 0;

			return GetRewardLevel( acct );
		}

		public static int GetRewardLevel( Account acct )
		{
			TimeSpan totalTime = (DateTime.Now - acct.Created);

			int level = (int)(totalTime.TotalDays / RewardInterval.TotalDays);

			if ( level < 0 )
				level = 0;

			return level;
		}

		public static bool HasHalfLevel( Mobile mob )
		{
			Account acct = mob.Account as Account;

			if ( acct == null )
				return false;

			return HasHalfLevel( acct );
		}

		public static bool HasHalfLevel( Account acct )
		{
			TimeSpan totalTime = (DateTime.Now - acct.Created);

			Double level = (totalTime.TotalDays / RewardInterval.TotalDays);

			return level >= 0.5;
		}

		public static bool ConsumeRewardPoint( Mobile mob )
		{
			int cur, max;

			ComputeRewardInfo( mob, out cur, out max );

			if ( cur >= max )
				return false;

			Account acct = mob.Account as Account;

			if ( acct == null )
				return false;

			//if ( mob.AccessLevel < AccessLevel.GameMaster )
				acct.SetTag( "numRewardsChosen", (cur + 1).ToString() );

			return true;
		}

		public static void ComputeRewardInfo( Mobile mob, out int cur, out int max )
		{
			int level;

			ComputeRewardInfo( mob, out cur, out max, out level );
		}

		public static void ComputeRewardInfo( Mobile mob, out int cur, out int max, out int level )
		{
			Account acct = mob.Account as Account;

			if ( acct == null )
			{
				cur = max = level = 0;
				return;
			}

			level = GetRewardLevel( acct );

			if ( level == 0 )
			{
				cur = max = 0;
				return;
			}

			string tag = acct.GetTag( "numRewardsChosen" );

			if ( String.IsNullOrEmpty( tag ) )
				cur = 0;
			else
				cur = Utility.ToInt32( tag );

			if ( level >= 6 )
				max = 9 + ((level - 6) * 2);
			else
				max = 2 + level;
		}

		public static bool CheckIsUsableBy( Mobile from, Item item, object[] args )
		{
			if ( m_Lists == null )
				SetupRewardTables();

			bool isRelaxedRules = ( item is DyeTub || item is MonsterStatuette );

			Type type = item.GetType();

			for ( int i = 0; i < m_Lists.Length; ++i )
			{
				RewardList list = m_Lists[i];
				RewardEntry[] entries = list.Entries;
				TimeSpan ts;

				for ( int j = 0; j < entries.Length; ++j )
				{
					if ( entries[j].ItemType == type )
					{
						if ( args == null && entries[j].Args.Length == 0 )
						{
							if ( (!isRelaxedRules || i > 0) && !HasAccess( from, list, out ts ) )
							{
								from.SendLocalizedMessage( 1008126, true, Math.Ceiling( ts.TotalDays / 30.0 ).ToString() ); // Your account is not old enough to use this item. Months until you can use this item :
								return false;
							}

							return true;
						}

						if ( args.Length == entries[j].Args.Length )
						{
							bool match = true;

							for ( int k = 0; match && k < args.Length; ++k )
								match = ( args[k].Equals( entries[j].Args[k] ) );

							if ( match )
							{
								if ( (!isRelaxedRules || i > 0) && !HasAccess( from, list, out ts ) )
								{
									from.SendLocalizedMessage( 1008126, true, Math.Ceiling( ts.TotalDays / 30.0 ).ToString() ); // Your account is not old enough to use this item. Months until you can use this item :
									return false;
								}

								return true;
							}
						}
					}
				}
			}

			// no entry?
			return true;
		}

		public static int GetRewardYearLabel( Item item, object[] args )
		{
			int level = GetRewardYear( item, args );
			int cliloc = 1076216 + level;
			if( level > 9 )
				cliloc += 4231;
			return cliloc;
		}

		public static int GetRewardYear( Item item, object[] args )
		{
			if ( m_Lists == null )
				SetupRewardTables();

			Type type = item.GetType();

			for ( int i = 0; i < m_Lists.Length; ++i )
			{
				RewardList list = m_Lists[i];
				RewardEntry[] entries = list.Entries;

				for ( int j = 0; j < entries.Length; ++j )
				{
					if ( entries[j].ItemType == type )
					{
						if ( args == null && entries[j].Args.Length == 0 )
							return i + 1;

						if ( args.Length == entries[j].Args.Length )
						{
							bool match = true;

							for ( int k = 0; match && k < args.Length; ++k )
								match = ( args[k].Equals( entries[j].Args[k] ) );

							if ( match )
								return i + 1;
						}
					}
				}
			}

			// no entry?
			return 0;
		}

		public static void SetupRewardTables()
		{
			RewardCategory monsterStatues = new RewardCategory( 1049750 );
			RewardCategory cloaksAndRobes = new RewardCategory( 1049752 );
			RewardCategory etherealSteeds = new RewardCategory( 1049751 );
			RewardCategory specialDyeTubs = new RewardCategory( 1049753 );
			RewardCategory houseAddOns    = new RewardCategory( 1049754 );
			RewardCategory miscellaneous  = new RewardCategory( 1078596 );

			m_Categories = new RewardCategory[]
				{
					monsterStatues,
					cloaksAndRobes,
					etherealSteeds,
					specialDyeTubs,
					houseAddOns,
					miscellaneous
				};

			const int Bronze = 0x972;
			const int Copper = 0x96D;
			const int Golden = 0x8A5;
			const int Agapite = 0x979;
			const int Verite = 0x89F;
			const int Valorite = 0x8AB;
			const int IceGreen = 0x47F;
			const int IceBlue = 0x482;
			const int DarkGray = 0x497;
			const int Fire = 0x489;
			const int IceWhite = 0x47E;
			const int JetBlack = 0x001;
			const int Pink		= 0x490;
			const int Crimson	= 0x485;

			m_Lists = new RewardList[]
				{
					new RewardList( RewardInterval, 1, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1006008, typeof( RewardBlackDyeTub ) ),
						new RewardEntry( specialDyeTubs, 1006013, typeof( FurnitureDyeTub ) ),
						new RewardEntry( specialDyeTubs, 1006047, typeof( SpecialDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1006009, typeof( RewardCloak ), Bronze, 1041286 ),
						new RewardEntry( cloaksAndRobes, 1006010, typeof( RewardRobe ), Bronze, 1041287 ),
						new RewardEntry( cloaksAndRobes, 1080366, typeof( RewardDress ), Expansion.ML, Bronze, 1080366 ),
						new RewardEntry( cloaksAndRobes, 1006011, typeof( RewardCloak ), Copper, 1041288 ),
						new RewardEntry( cloaksAndRobes, 1006012, typeof( RewardRobe ), Copper, 1041289 ),
						new RewardEntry( cloaksAndRobes, 1080367, typeof( RewardDress ), Expansion.ML, Copper, 1080367 ),
						new RewardEntry( monsterStatues, 1006024, typeof( MonsterStatuette ), MonsterStatuetteType.Crocodile ),
						new RewardEntry( monsterStatues, 1006025, typeof( MonsterStatuette ), MonsterStatuetteType.Daemon ),
						new RewardEntry( monsterStatues, 1006026, typeof( MonsterStatuette ), MonsterStatuetteType.Dragon ),
						new RewardEntry( monsterStatues, 1006027, typeof( MonsterStatuette ), MonsterStatuetteType.EarthElemental ),
						new RewardEntry( monsterStatues, 1006028, typeof( MonsterStatuette ), MonsterStatuetteType.Ettin ),
						new RewardEntry( monsterStatues, 1006029, typeof( MonsterStatuette ), MonsterStatuetteType.Gargoyle ),
						new RewardEntry( monsterStatues, 1006030, typeof( MonsterStatuette ), MonsterStatuetteType.Gorilla ),
						new RewardEntry( monsterStatues, 1006031, typeof( MonsterStatuette ), MonsterStatuetteType.Lich ),
						new RewardEntry( monsterStatues, 1006032, typeof( MonsterStatuette ), MonsterStatuetteType.Lizardman ),
						new RewardEntry( monsterStatues, 1006033, typeof( MonsterStatuette ), MonsterStatuetteType.Ogre ),
						new RewardEntry( monsterStatues, 1006034, typeof( MonsterStatuette ), MonsterStatuetteType.Orc ),
						new RewardEntry( monsterStatues, 1006035, typeof( MonsterStatuette ), MonsterStatuetteType.Ratman ),
						new RewardEntry( monsterStatues, 1006036, typeof( MonsterStatuette ), MonsterStatuetteType.Skeleton ),
						new RewardEntry( monsterStatues, 1006037, typeof( MonsterStatuette ), MonsterStatuetteType.Troll ),
						new RewardEntry( houseAddOns,    1062692, typeof( ContestMiniHouseDeed ), Expansion.AOS, MiniHouseType.SerpentIslandMountainPass ),
						new RewardEntry( houseAddOns,    1072216, typeof( ContestMiniHouseDeed ), Expansion.SE, MiniHouseType.ChurchAtNight ),
						new RewardEntry( miscellaneous,  1076155, typeof( RedSoulstone ), Expansion.ML ),
						new RewardEntry( miscellaneous,  1080523, typeof( CommodityDeedBox ), Expansion.ML ),
					} ),
					new RewardList( RewardInterval, 2, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1006052, typeof( LeatherDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1006014, typeof( RewardCloak ), Agapite, 1041290 ),
						new RewardEntry( cloaksAndRobes, 1006015, typeof( RewardRobe ), Agapite, 1041291 ),
						new RewardEntry( cloaksAndRobes, 1080369, typeof( RewardDress ), Expansion.ML, Agapite, 1080369 ),
						new RewardEntry( cloaksAndRobes, 1006016, typeof( RewardCloak ), Golden, 1041292 ),
						new RewardEntry( cloaksAndRobes, 1006017, typeof( RewardRobe ), Golden, 1041293 ),
						new RewardEntry( cloaksAndRobes, 1080368, typeof( RewardDress ), Expansion.ML, Golden, 1080368 ),
						new RewardEntry( houseAddOns,    1006048, typeof( BannerDeed ) ),
						new RewardEntry( houseAddOns, 	 1006049, typeof( FlamingHeadDeed ) ),
						new RewardEntry( houseAddOns, 	 1080409, typeof( MinotaurStatueDeed ), Expansion.ML )
					} ),
					new RewardList( RewardInterval, 3, new RewardEntry[]
					{
						new RewardEntry( cloaksAndRobes, 1006020, typeof( RewardCloak ), Verite, 1041294 ),
						new RewardEntry( cloaksAndRobes, 1006021, typeof( RewardRobe ), Verite, 1041295 ),
						new RewardEntry( cloaksAndRobes, 1080370, typeof( RewardDress ), Expansion.ML, Verite, 1080370 ),
						new RewardEntry( cloaksAndRobes, 1006022, typeof( RewardCloak ), Valorite, 1041296 ),
						new RewardEntry( cloaksAndRobes, 1006023, typeof( RewardRobe ), Valorite, 1041297 ),
						new RewardEntry( cloaksAndRobes, 1080371, typeof( RewardDress ), Expansion.ML, Valorite, 1080371 ),
						new RewardEntry( monsterStatues, 1006038, typeof( MonsterStatuette ), MonsterStatuetteType.Cow ),
						new RewardEntry( monsterStatues, 1006039, typeof( MonsterStatuette ), MonsterStatuetteType.Zombie ),
						new RewardEntry( monsterStatues, 1006040, typeof( MonsterStatuette ), MonsterStatuetteType.Llama ),
						new RewardEntry( etherealSteeds, 1006019, typeof( EtherealHorse ) ),
						new RewardEntry( etherealSteeds, 1006050, typeof( EtherealOstard ) ),
						new RewardEntry( etherealSteeds, 1006051, typeof( EtherealLlama ) ),
						new RewardEntry( houseAddOns,	 1080407, typeof( PottedCactusDeed ), Expansion.ML )

					} ),
					new RewardList( RewardInterval, 4, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1049740, typeof( RunebookDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1049725, typeof( RewardCloak ), DarkGray, 1049757 ),
						new RewardEntry( cloaksAndRobes, 1049726, typeof( RewardRobe ), DarkGray, 1049756 ),
						new RewardEntry( cloaksAndRobes, 1080374, typeof( RewardDress ), Expansion.ML, DarkGray, 1080374 ),
						new RewardEntry( cloaksAndRobes, 1049727, typeof( RewardCloak ), IceGreen, 1049759 ),
						new RewardEntry( cloaksAndRobes, 1049728, typeof( RewardRobe ), IceGreen, 1049758 ),
						new RewardEntry( cloaksAndRobes, 1080372, typeof( RewardDress ), Expansion.ML, IceGreen, 1080372 ),
						new RewardEntry( cloaksAndRobes, 1049729, typeof( RewardCloak ), IceBlue, 1049761 ),
						new RewardEntry( cloaksAndRobes, 1049730, typeof( RewardRobe ), IceBlue, 1049760 ),
						new RewardEntry( cloaksAndRobes, 1080373, typeof( RewardDress ), Expansion.ML, IceBlue, 1080373 ),
						new RewardEntry( monsterStatues, 1049742, typeof( MonsterStatuette ), MonsterStatuetteType.Ophidian ),
						new RewardEntry( monsterStatues, 1049743, typeof( MonsterStatuette ), MonsterStatuetteType.Reaper ),
						new RewardEntry( monsterStatues, 1049744, typeof( MonsterStatuette ), MonsterStatuetteType.Mongbat ),
						new RewardEntry( etherealSteeds, 1049746, typeof( EtherealKirin ) ),
						new RewardEntry( etherealSteeds, 1049745, typeof( EtherealUnicorn ) ),
						new RewardEntry( etherealSteeds, 1049747, typeof( EtherealRidgeback ) ),
						new RewardEntry( houseAddOns,    1049737, typeof( DecorativeShieldDeed ) ),
						new RewardEntry( houseAddOns, 	 1049738, typeof( HangingSkeletonDeed ) )
					} ),
					new RewardList( RewardInterval, 5, new RewardEntry[]
					{
						new RewardEntry( specialDyeTubs, 1049741, typeof( StatuetteDyeTub ) ),
						new RewardEntry( cloaksAndRobes, 1049731, typeof( RewardCloak ), JetBlack, 1049763 ),
						new RewardEntry( cloaksAndRobes, 1049732, typeof( RewardRobe ), JetBlack, 1049762 ),
						new RewardEntry( cloaksAndRobes, 1080377, typeof( RewardDress ), Expansion.ML, JetBlack, 1080377 ),
						new RewardEntry( cloaksAndRobes, 1049733, typeof( RewardCloak ), IceWhite, 1049765 ),
						new RewardEntry( cloaksAndRobes, 1049734, typeof( RewardRobe ), IceWhite, 1049764 ),
						new RewardEntry( cloaksAndRobes, 1080376, typeof( RewardDress ), Expansion.ML, IceWhite, 1080376 ),
						new RewardEntry( cloaksAndRobes, 1049735, typeof( RewardCloak ), Fire, 1049767 ),
						new RewardEntry( cloaksAndRobes, 1049736, typeof( RewardRobe ), Fire, 1049766 ),
						new RewardEntry( cloaksAndRobes, 1080375, typeof( RewardDress ), Expansion.ML, Fire, 1080375 ),
						new RewardEntry( monsterStatues, 1049768, typeof( MonsterStatuette ), MonsterStatuetteType.Gazer ),
						new RewardEntry( monsterStatues, 1049769, typeof( MonsterStatuette ), MonsterStatuetteType.FireElemental ),
						new RewardEntry( monsterStatues, 1049770, typeof( MonsterStatuette ), MonsterStatuetteType.Wolf ),
						new RewardEntry( etherealSteeds, 1049749, typeof( EtherealSwampDragon ) ),
						new RewardEntry( etherealSteeds, 1049748, typeof( EtherealBeetle ) ),
						new RewardEntry( houseAddOns,    1049739, typeof( StoneAnkhDeed ) ),
						new RewardEntry( houseAddOns,    1080384, typeof( BloodyPentagramDeed ), Expansion.ML )
					} ),
					new RewardList( RewardInterval, 6, new RewardEntry[]
					{
						new RewardEntry( houseAddOns,	1076188, typeof( CharacterStatueMaker ), Expansion.ML, StatueType.Jade ),
						new RewardEntry( houseAddOns,	1076189, typeof( CharacterStatueMaker ), Expansion.ML, StatueType.Marble ),
						new RewardEntry( houseAddOns,	1076190, typeof( CharacterStatueMaker ), Expansion.ML, StatueType.Bronze ),
						new RewardEntry( houseAddOns,	1080527, typeof( RewardBrazierDeed ), Expansion.ML )
					} ),
					new RewardList( RewardInterval, 7, new RewardEntry[]
					{
						new RewardEntry( houseAddOns,	1080550, typeof( TreeStumpDeed ), Expansion.ML )
					} ),
					new RewardList( RewardInterval, 8, new RewardEntry[]
					{
						new RewardEntry( miscellaneous,	1076158, typeof( WeaponEngravingTool ), Expansion.ML )
					} ),
					new RewardList( RewardInterval, 9, new RewardEntry[]
					{
						new RewardEntry( etherealSteeds,	1076159, typeof( RideablePolarBear ), Expansion.ML ),
						new RewardEntry( houseAddOns,		1080549, typeof( WallBannerDeed ), Expansion.ML )
					} ),
					new RewardList( RewardInterval, 10, new RewardEntry[]
					{
						new RewardEntry( monsterStatues,	1080520, typeof( MonsterStatuette ), Expansion.ML, MonsterStatuetteType.Harrower ),
						new RewardEntry( monsterStatues,	1080521, typeof( MonsterStatuette ), Expansion.ML, MonsterStatuetteType.Efreet ),

						new RewardEntry( cloaksAndRobes,	1080382, typeof( RewardCloak ), Expansion.ML, Pink, 1080382 ),
						new RewardEntry( cloaksAndRobes,	1080380, typeof( RewardRobe ), Expansion.ML, Pink, 1080380 ),
						new RewardEntry( cloaksAndRobes,	1080378, typeof( RewardDress ), Expansion.ML, Pink, 1080378 ),
						new RewardEntry( cloaksAndRobes,	1080383, typeof( RewardCloak ), Expansion.ML, Crimson, 1080383 ),
						new RewardEntry( cloaksAndRobes,	1080381, typeof( RewardRobe ), Expansion.ML, Crimson, 1080381 ),
						new RewardEntry( cloaksAndRobes,	1080379, typeof( RewardDress ), Expansion.ML, Crimson, 1080379 ),

						new RewardEntry( etherealSteeds,	1080386, typeof( EtherealCuSidhe ), Expansion.ML ),

						new RewardEntry( houseAddOns,		1080548, typeof( MiningCartDeed ), Expansion.ML ),
						new RewardEntry( houseAddOns,		1080397, typeof( AnkhOfSacrificeDeed ), Expansion.ML )
					} )
				};
		}

		public static void Initialize()
		{
			if ( Enabled )
				EventSink.Login += new LoginEventHandler( EventSink_Login );
		}

		private static void EventSink_Login( LoginEventArgs e )
		{
			if ( !e.Mobile.Alive )
				return;

			int cur, max, level;

			ComputeRewardInfo( e.Mobile, out cur, out max, out level );

			if ( e.Mobile.SkillsCap == 7000 || e.Mobile.SkillsCap == 7050 || e.Mobile.SkillsCap == 7100 || e.Mobile.SkillsCap == 7150 || e.Mobile.SkillsCap == 7200 )
			{
				if ( level > 4 )
					level = 4;
				else if ( level < 0 )
					level = 0;

				if ( SkillCapRewards )
					e.Mobile.SkillsCap = 7000 + (level * 50);
				else
					e.Mobile.SkillsCap = 7000;
			}

			if ( Core.ML && e.Mobile is PlayerMobile && !((PlayerMobile)e.Mobile).HasStatReward && HasHalfLevel( e.Mobile ) )
			{
				((PlayerMobile)e.Mobile).HasStatReward = true;
				e.Mobile.StatCap += 5;
			}

			if ( cur < max )
				e.Mobile.SendGump( new RewardNoticeGump( e.Mobile ) );
		}
	}

	public interface IRewardItem
	{
		bool IsRewardItem{ get; set; }
	}
}// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class RubyWyrm : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public RubyWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the ruby wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "ruby", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "ruby scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public RubyWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server.Mobiles;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class SabretoothBear : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public SabretoothBear() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sabreclaw bear";
			Body = 34;
			BaseSoundID = 0xA3;

			SetStr( 226, 255 );
			SetDex( 121, 145 );
			SetInt( 16, 40 );

			SetHits( 176, 193 );
			SetMana( 0 );

			SetDamage( 14, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Cold, 35, 45 );
			SetResistance( ResistanceType.Poison, 15, 20 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.MagicResist, 35.1, 50.0 );
			SetSkill( SkillName.Tactics, 90.1, 120.0 );
			SetSkill( SkillName.FistFighting, 65.1, 90.0 );

			Fame = 1500;
			Karma = 0;

			VirtualArmor = 35;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 69.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public override int GetAngerSound()
		{
			return 0x518;
		}

		public override int GetIdleSound()
		{
			return 0x517;
		}

		public override int GetAttackSound()
		{
			return 0x516;
		}

		public override int GetHurtSound()
		{
			return 0x519;
		}

		public override int GetDeathSound()
		{
			return 0x515;
		}

		public SabretoothBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;// using Server.Network;

namespace Server
{
	public class SacrificeVirtue
	{
		private static TimeSpan GainDelay = TimeSpan.FromDays( 1.0 );
		private static TimeSpan LossDelay = TimeSpan.FromDays( 7.0 );
		private const int LossAmount = 500;

		public static void Initialize()
		{
			VirtueGump.Register( 110, new OnVirtueUsed( OnVirtueUsed ) );
		}

		public static void OnVirtueUsed( Mobile from )
		{
			if ( !from.Hidden )
			{
				if ( from.Alive )
					from.Target = new InternalTarget();
				else
					Resurrect( from );
			}
			else
				from.SendLocalizedMessage( 1052015 ); // You cannot do that while hidden.
		}

		public static void CheckAtrophy( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return;

			try
			{
				if ( (pm.LastSacrificeLoss + LossDelay) < DateTime.Now )
				{
					if ( VirtueHelper.Atrophy( from, VirtueName.Sacrifice, LossAmount ) )
						from.SendLocalizedMessage( 1052041 ); // You have lost some Sacrifice.

					VirtueLevel level = VirtueHelper.GetLevel( from, VirtueName.Sacrifice );

					pm.AvailableResurrects = (int)level;
					pm.LastSacrificeLoss = DateTime.Now;
				}
			}
			catch
			{
			}
		}

		public static void Resurrect( Mobile from )
		{
			if ( from.Alive )
				return;

			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return;

			if ( from.Criminal )
			{
				from.SendLocalizedMessage( 1052007 ); // You cannot use this ability while flagged as a criminal.
			}
			else if ( !VirtueHelper.IsSeeker( from, VirtueName.Sacrifice ) )
			{
				from.SendLocalizedMessage( 1052004 ); // You cannot use this ability.
			}
			else if ( pm.AvailableResurrects <= 0 )
			{
				from.SendLocalizedMessage( 1052005 ); // You do not have any resurrections left.
			}
			else
			{
				/*
				 * We need to wait for them to accept the gump or they can just use
				 * Sacrifice and cancel to have items in their backpack for free.
				 */
				from.CloseGump( typeof( ResurrectGump ) );
				from.SendGump( new ResurrectGump( from, true ) );
			}
		}

		public static void Sacrifice( Mobile from, object targeted )
		{
			if ( !from.CheckAlive() )
				return;

			PlayerMobile pm = from as PlayerMobile;

			if ( pm == null )
				return;

			Mobile targ = targeted as Mobile;

			if ( targ == null )
				return;

			if ( !ValidateCreature( targ ) )
			{
				from.SendLocalizedMessage( 1052014 ); // You cannot sacrifice your fame for that creature.
			}
			else if ( ((targ.Hits * 100) / Math.Max( targ.HitsMax, 1 )) < 90 )
			{
				from.SendLocalizedMessage( 1052013 ); // You cannot sacrifice for this monster because it is too damaged.
			}
			else if ( from.Hidden )
			{
				from.SendLocalizedMessage( 1052015 ); // You cannot do that while hidden.
			}
			else if ( VirtueHelper.IsHighestPath( from, VirtueName.Sacrifice ) )
			{
				from.SendLocalizedMessage( 1052068 ); // You have already attained the highest path in this virtue.
			}
			else if ( from.Fame < 2500 )
			{
				from.SendLocalizedMessage( 1052017 ); // You do not have enough fame to sacrifice.
			}
			else if ( DateTime.Now < (pm.LastSacrificeGain + GainDelay) )
			{
				from.SendLocalizedMessage( 1052016 ); // You must wait approximately one day before sacrificing again.
			}
			else
			{
				int toGain;

				if( from.Fame < 5000 )
					toGain = 500;
				else if( from.Fame < 10000 )
					toGain = 1000;
				else
					toGain = 2000;

				from.Fame = 0;

				// I have seen the error of my ways!
				targ.PublicOverheadMessage( MessageType.Regular, 0x3B2, 1052009 );

				from.SendLocalizedMessage( 1052010 ); // You have set the creature free.

				Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerCallback( targ.Delete ) );

				pm.LastSacrificeGain = DateTime.Now;

				bool gainedPath = false;

				if ( VirtueHelper.Award( from, VirtueName.Sacrifice, toGain, ref gainedPath ) )
				{
					if ( gainedPath )
					{
						from.SendLocalizedMessage( 1052008 ); // You have gained a path in Sacrifice!

						if ( pm.AvailableResurrects < 3 )
							++pm.AvailableResurrects;
					}
					else
					{
						from.SendLocalizedMessage( 1054160 ); // You have gained in sacrifice.
					}
				}

				from.SendLocalizedMessage( 1052016 ); // You must wait approximately one day before sacrificing again.
			}
		}

		public static bool ValidateCreature( Mobile m )
		{
			if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned) )
				return false;

			return ( m is Lich );
		}

		private class InternalTarget : Target
		{
			public InternalTarget() : base( 8, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				Sacrifice( from, targeted );
			}
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class SapphireWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public SapphireWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the sapphire wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "sapphire", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "sapphire scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public SapphireWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class Shadowlords : Faction
	{
		private static Faction m_Instance;

		public static Faction Instance{ get{ return m_Instance; } }

		public Shadowlords()
		{
			m_Instance = this;

			Definition =
				new FactionDefinition(
					3,
					1109, // shadow
					2211, // green
					1109, // join stone : shadow
					2211, // broadcast : green
					0x79, 0x3EB0, // war horse
					"Shadowlords", "shadow", "SL",
					new TextDefinition( 1011537, "SHADOWLORDS" ),
					new TextDefinition( 1060772, "Shadowlords faction" ),
					new TextDefinition( 1011424, "<center>SHADES OF DARKNESS</center>" ),
					new TextDefinition( 1011451,
						"The Shadow Lords are a faction that has sprung up within the ranks of " +
						"Minax. Comprised mostly of undead and those who would seek to be " +
						"necromancers, they pose a threat to both the sides of good and evil. " +
						"Their plans have disrupted the hold Minax has over Lodor, and their " +
						"ultimate goal is to destroy all life." ),
					new TextDefinition( 1011456, "This city is controlled by the Shadow Lords." ),
					new TextDefinition( 1042255, "This sigil has been corrupted by the Shadowlords" ),
					new TextDefinition( 1041046, "The faction signup stone for the Shadowlords" ),
					new TextDefinition( 1041384, "The Faction Stone of the Shadowlords" ),
					new TextDefinition( 1011466, ": Shadowlords" ),
					new TextDefinition( 1005184, "Minions of the Shadowlords will now be ignored." ),
					new TextDefinition( 1005185, "Minions of the Shadowlords will now be warned of their impending deaths." ),
					new TextDefinition( 1005186, "Minions of the Shadowlords will now be attacked at will." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 )
						},
						new Point3D( 969, 768, 0 ),
						new Point3D( 947, 713, 0 ),
						new Point3D[]
						{
							new Point3D( 953, 713, 20 ),
							new Point3D( 953, 709, 20 ),
							new Point3D( 953, 705, 20 ),
							new Point3D( 953, 701, 20 ),
							new Point3D( 957, 713, 20 ),
							new Point3D( 957, 709, 20 ),
							new Point3D( 957, 705, 20 ),
							new Point3D( 957, 701, 20 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060799, "Purveyor of Darkness" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060798, "Agent of Evil" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060797, "Bringer of Sorrow" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060797, "Bringer of Sorrow" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060796, "Keeper of Lies" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060795, "Servant" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060795, "Servant" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060795, "Servant" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionDeathKnight ),	0x0F45, 7000, 3000, 10,		new TextDefinition( 1011512, "DEATH KNIGHT" ),	new TextDefinition( 1011503, "Hire Death Knight" ) ),
						new GuardDefinition( typeof( FactionNecromancer ),	0x13F8, 8000, 4000, 10,		new TextDefinition( 1011513, "SHADOW MAGE" ),	new TextDefinition( 1011504, "Hire Shadow Mage" ) ),
					}
				);
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Targeting;// using System.Collections.Generic;

namespace Server.Factions
{
	public class SheriffGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;
		private Town m_Town;

		private void CenterItem( int itemID, int x, int y, int w, int h )
		{
			Rectangle2D rc = ItemBounds.Table[itemID];
			AddItem( x + ((w - rc.Width) / 2) - rc.X, y + ((h - rc.Height) / 2) - rc.Y, itemID );
		}

		public SheriffGump( PlayerMobile from, Faction faction, Town town ) : base( 50, 50 )
		{
			m_From = from;
			m_Faction = faction;
			m_Town = town;

			AddPage( 0 );

			AddBackground( 0, 0, 320, 410, 5054 );
			AddBackground( 10, 10, 300, 390, 3000 );

			#region General
			AddPage( 1 );

			AddHtmlLocalized( 20, 30, 260, 25, 1011431, false, false ); // Sheriff

			AddHtmlLocalized( 55, 90, 200, 25, 1011494, false, false ); // HIRE GUARDS
			AddButton( 20, 90, 4005, 4007, 0, GumpButtonType.Page, 3 );

			AddHtmlLocalized( 55, 120, 200, 25, 1011495, false, false ); // VIEW FINANCES
			AddButton( 20, 120, 4005, 4007, 0, GumpButtonType.Page, 2 );

			AddHtmlLocalized( 55, 360, 200, 25, 1011441, false, false ); // Exit
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			#endregion

			#region Finances
			AddPage( 2 );

			int financeUpkeep = town.FinanceUpkeep;
			int sheriffUpkeep = town.SheriffUpkeep;
			int dailyIncome = town.DailyIncome;
			int netCashFlow = town.NetCashFlow;

			AddHtmlLocalized( 20, 30, 300, 25, 1011524, false, false ); // FINANCE STATEMENT

			AddHtmlLocalized( 20, 80, 300, 25, 1011538, false, false ); // Current total money for town :
			AddLabel( 20, 100, 0x44, town.Silver.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 130, 300, 25, 1011520, false, false ); // Finance Minister Upkeep :
			AddLabel( 20, 150, 0x44, financeUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 180, 300, 25, 1011521, false, false ); // Sheriff Upkeep :
			AddLabel( 20, 200, 0x44, sheriffUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 230, 300, 25, 1011522, false, false ); // Town Income :
			AddLabel( 20, 250, 0x44, dailyIncome.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 20, 280, 300, 25, 1011523, false, false ); // Net Cash flow per day :
			AddLabel( 20, 300, 0x44, netCashFlow.ToString( "N0" ) ); // NOTE: Added 'N0'

			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region Hire Guards
			AddPage( 3 );

			AddHtmlLocalized( 20, 30, 300, 25, 1011494, false, false ); // HIRE GUARDS

			List<GuardList> guardLists = town.GuardLists;

			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];
				int y = 90 + (i * 60);

				AddButton( 20, y, 4005, 4007, 0, GumpButtonType.Page, 4 + i );
				CenterItem( guardList.Definition.ItemID, 50, y - 20, 70, 60 );
				AddHtmlText( 120, y, 200, 25, guardList.Definition.Header, false, false );
			}

			AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
			AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 1 );
			#endregion

			#region Guard Pages
			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];

				AddPage( 4 + i );

				AddHtmlText( 90, 30, 300, 25, guardList.Definition.Header, false, false );
				CenterItem( guardList.Definition.ItemID, 10, 10, 80, 80 );

				AddHtmlLocalized( 20, 90, 200, 25, 1011514, false, false ); // You have :
				AddLabel( 230, 90, 0x26, guardList.Guards.Count.ToString() );

				AddHtmlLocalized( 20, 120, 200, 25, 1011515, false, false ); // Maximum :
				AddLabel( 230, 120, 0x12A, guardList.Definition.Maximum.ToString() );

				AddHtmlLocalized( 20, 150, 200, 25, 1011516, false, false ); // Cost :
				AddLabel( 230, 150, 0x44, guardList.Definition.Price.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlLocalized( 20, 180, 200, 25, 1011517, false, false ); // Daily Pay :
				AddLabel( 230, 180, 0x37, guardList.Definition.Upkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlLocalized( 20, 210, 200, 25, 1011518, false, false ); // Current Silver :
				AddLabel( 230, 210, 0x44, town.Silver.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlLocalized( 20, 240, 200, 25, 1011519, false, false ); // Current Payroll :
				AddLabel( 230, 240, 0x44, sheriffUpkeep.ToString( "N0" ) ); // NOTE: Added 'N0'

				AddHtmlText( 55, 300, 200, 25, guardList.Definition.Label, false, false );
				AddButton( 20, 300, 4005, 4007, 1 + i, GumpButtonType.Reply, 0 );

				AddHtmlLocalized( 55, 360, 200, 25, 1011067, false, false ); // Previous page
				AddButton( 20, 360, 4005, 4007, 0, GumpButtonType.Page, 3 );
			}
			#endregion
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( !m_Town.IsSheriff( m_From ) || m_Town.Owner != m_Faction )
			{
				m_From.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}

			int index = info.ButtonID - 1;

			if ( index >= 0 && index < m_Town.GuardLists.Count )
			{
				GuardList guardList = m_Town.GuardLists[index];
				Town town = Town.FromRegion( m_From.Region );

				if ( Town.FromRegion( m_From.Region ) != m_Town )
				{
					m_From.SendLocalizedMessage( 1010305 ); // You must be in your controlled city to buy Items
				}
				else if ( guardList.Guards.Count >= guardList.Definition.Maximum )
				{
					m_From.SendLocalizedMessage( 1010306 ); // You currently have too many of this enhancement type to place another
				}
				else if ( m_Town.Silver >= guardList.Definition.Price )
				{
					BaseFactionGuard guard = guardList.Construct();

					if ( guard != null )
					{
						guard.Faction = m_Faction;
						guard.Town = m_Town;

						m_Town.Silver -= guardList.Definition.Price;

						guard.MoveToWorld( m_From.Location, m_From.Map );
						guard.Home = guard.Location;
					}
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Mobiles;// using Server.Network;// using System.Collections.Generic;

namespace Server.Factions
{
	public class Sigil : BaseSystemController
	{
		public const int OwnershipHue = 0xB;

		// ?? time corrupting faction has to return the sigil before corruption time resets ?
		public static readonly TimeSpan CorruptionGrace = TimeSpan.FromMinutes( (Core.SE) ? 30.0 : 15.0 );

		// Sigil must be held at a stronghold for this amount of time in order to become corrupted
		public static readonly TimeSpan CorruptionPeriod = ( (Core.SE) ? TimeSpan.FromHours( 10.0 ) : TimeSpan.FromHours( 24.0 ) );

		// After a sigil has been corrupted it must be returned to the town within this period of time
		public static readonly TimeSpan ReturnPeriod = TimeSpan.FromHours( 1.0 );

		// Once it's been returned the corrupting faction owns the town for this period of time
		public static readonly TimeSpan PurificationPeriod = TimeSpan.FromDays( 3.0 );

		private BaseMonolith m_LastMonolith;

		private Town m_Town;
		private Faction m_Corrupted;
		private Faction m_Corrupting;

		private DateTime m_LastStolen;
		private DateTime m_GraceStart;
		private DateTime m_CorruptionStart;
		private DateTime m_PurificationStart;

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime LastStolen
		{
			get{ return m_LastStolen; }
			set{ m_LastStolen = value; }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime GraceStart
		{
			get{ return m_GraceStart; }
			set{ m_GraceStart = value; }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime CorruptionStart
		{
			get{ return m_CorruptionStart; }
			set{ m_CorruptionStart = value; }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public DateTime PurificationStart
		{
			get{ return m_PurificationStart; }
			set{ m_PurificationStart = value; }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set{ m_Town = value; Update(); }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Corrupted
		{
			get{ return m_Corrupted; }
			set{ m_Corrupted = value; Update(); }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Faction Corrupting
		{
			get{ return m_Corrupting; }
			set{ m_Corrupting = value; Update(); }
		}

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public BaseMonolith LastMonolith
		{
			get{ return m_LastMonolith; }
			set{ m_LastMonolith = value; }
		}

		[CommandProperty( AccessLevel.Counselor )]
		public bool IsBeingCorrupted
		{
			get{ return ( m_LastMonolith is StrongholdMonolith && m_LastMonolith.Faction == m_Corrupting && m_Corrupting != null ); }
		}

		[CommandProperty( AccessLevel.Counselor )]
		public bool IsCorrupted
		{
			get{ return ( m_Corrupted != null ); }
		}

		[CommandProperty( AccessLevel.Counselor )]
		public bool IsPurifying
		{
			get{ return ( m_PurificationStart != DateTime.MinValue ); }
		}

		[CommandProperty( AccessLevel.Counselor )]
		public bool IsCorrupting
		{
			get{ return ( m_Corrupting != null && m_Corrupting != m_Corrupted ); }
		}

		public void Update()
		{
			ItemID = ( m_Town == null ? 0x1869 : m_Town.Definition.SigilID );

			if ( m_Town == null )
				AssignName( null );
			else if ( IsCorrupted || IsPurifying )
				AssignName( m_Town.Definition.CorruptedSigilName );
			else
				AssignName( m_Town.Definition.SigilName );

			InvalidateProperties();
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( IsCorrupted )
				TextDefinition.AddTo( list, m_Corrupted.Definition.SigilControl );
			else
				list.Add( 1042256 ); // This sigil is not corrupted.

			if ( IsCorrupting )
				list.Add( 1042257 ); // This sigil is in the process of being corrupted.
			else if ( IsPurifying )
				list.Add( 1042258 ); // This sigil has recently been corrupted, and is undergoing purification.
			else
				list.Add( 1042259 ); // This sigil is not in the process of being corrupted.
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( IsCorrupted )
			{
				if ( m_Corrupted.Definition.SigilControl.Number > 0 )
					LabelTo( from, m_Corrupted.Definition.SigilControl.Number );
				else if ( m_Corrupted.Definition.SigilControl.String != null )
					LabelTo( from, m_Corrupted.Definition.SigilControl.String );
			}
			else
			{
				LabelTo( from, 1042256 ); // This sigil is not corrupted.
			}

			if ( IsCorrupting )
				LabelTo( from, 1042257 ); // This sigil is in the process of being corrupted.
			else if ( IsPurifying )
				LabelTo( from, 1042258 ); // This sigil has been recently corrupted, and is undergoing purification.
			else
				LabelTo( from, 1042259 ); // This sigil is not in the process of being corrupted.
		}

		public override bool CheckLift( Mobile from, Item item, ref LRReason reject )
		{
			from.SendLocalizedMessage( 1005225 ); // You must use the stealing skill to pick up the sigil
			return false;
		}

		private Mobile FindOwner( object parent )
		{
			if ( parent is Item )
				return ((Item)parent).RootParent as Mobile;

			if ( parent is Mobile )
				return (Mobile) parent;

			return null;
		}

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );

			Mobile mob = FindOwner( parent );

			if ( mob != null )
				mob.SolidHueOverride = OwnershipHue;
		}

		public override void OnRemoved( object parent )
		{
			base.OnRemoved( parent );

			Mobile mob = FindOwner( parent );

			if ( mob != null )
				mob.SolidHueOverride = -1;
		}

		public Sigil( Town town ) : base( 0x1869 )
		{
			Movable = false;
			Town = town;

			m_Sigils.Add( this );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.BeginTarget( 1, false, Targeting.TargetFlags.None, new TargetCallback( Sigil_OnTarget ) );
				from.SendLocalizedMessage( 1042251 ); // Click on a sigil monolith or player
			}
		}

		public static bool ExistsOn( Mobile mob )
		{
			Container pack = mob.Backpack;

			return ( pack != null && pack.FindItemByType( typeof( Sigil ) ) != null );
		}

		private void BeginCorrupting( Faction faction )
		{
			m_Corrupting = faction;
			m_CorruptionStart = DateTime.Now;
		}

		private void ClearCorrupting()
		{
			m_Corrupting = null;
			m_CorruptionStart = DateTime.MinValue;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public TimeSpan TimeUntilCorruption
		{
			get
			{
				if ( !IsBeingCorrupted )
					return TimeSpan.Zero;

				TimeSpan ts = ( m_CorruptionStart + CorruptionPeriod ) - DateTime.Now;

				if ( ts < TimeSpan.Zero )
					ts = TimeSpan.Zero;

				return ts;
			}
		}

		private void Sigil_OnTarget( Mobile from, object obj )
		{
			if ( Deleted || !IsChildOf( from.Backpack ) )
				return;

			#region Give To Mobile
			if ( obj is Mobile )
			{
				if ( obj is PlayerMobile )
				{
					PlayerMobile targ = (PlayerMobile)obj;

					Faction toFaction = Faction.Find( targ );
					Faction fromFaction = Faction.Find( from );

					if ( toFaction == null )
						from.SendLocalizedMessage( 1005223 ); // You cannot give the sigil to someone not in a faction
					else if ( fromFaction != toFaction )
						from.SendLocalizedMessage( 1005222 ); // You cannot give the sigil to someone not in your faction
					else if ( Sigil.ExistsOn( targ ) )
						from.SendLocalizedMessage( 1005220 ); // You cannot give this sigil to someone who already has a sigil
					else if( !targ.Alive )
						from.SendLocalizedMessage( 1042248 ); // You cannot give a sigil to a dead person.
					else if ( from.NetState != null && targ.NetState != null )
					{
						Container pack = targ.Backpack;

						if ( pack != null )
							pack.DropItem( this );
					}
				}
				else
				{
					from.SendLocalizedMessage( 1005221 ); //You cannot give the sigil to them
				}
			}
			#endregion
			else if ( obj is BaseMonolith )
			{
				#region Put in Stronghold
				if ( obj is StrongholdMonolith )
				{
					StrongholdMonolith m = (StrongholdMonolith)obj;

					if ( m.Faction == null || m.Faction != Faction.Find( from ) )
						from.SendLocalizedMessage( 1042246 ); // You can't place that on an enemy monolith
					else if ( m.Town == null || m.Town != m_Town )
						from.SendLocalizedMessage( 1042247 ); // That is not the correct faction monolith
					else
					{
						m.Sigil = this;

						Faction newController = m.Faction;
						Faction oldController = m_Corrupting;

						if ( oldController == null )
						{
							if ( m_Corrupted != newController )
								BeginCorrupting( newController );
						}
						else if ( m_GraceStart > DateTime.MinValue && (m_GraceStart + CorruptionGrace) < DateTime.Now )
						{
							if ( m_Corrupted != newController )
								BeginCorrupting( newController ); // grace time over, reset period
							else
								ClearCorrupting();

							m_GraceStart = DateTime.MinValue;
						}
						else if ( newController == oldController )
						{
							m_GraceStart = DateTime.MinValue; // returned within grace period
						}
						else if ( m_GraceStart == DateTime.MinValue )
						{
							m_GraceStart = DateTime.Now;
						}

						m_PurificationStart = DateTime.MinValue;
					}
				}
				#endregion

				#region Put in Town
				else if ( obj is TownMonolith )
				{
					TownMonolith m = (TownMonolith)obj;

					if ( m.Town == null || m.Town != m_Town )
						from.SendLocalizedMessage( 1042245 ); // This is not the correct town sigil monolith
					else if ( m_Corrupted == null || m_Corrupted != Faction.Find( from ) )
						from.SendLocalizedMessage( 1042244 ); // Your faction did not corrupt this sigil.  Take it to your stronghold.
					else
					{
						m.Sigil = this;

						m_Corrupting = null;
						m_PurificationStart = DateTime.Now;
						m_CorruptionStart = DateTime.MinValue;

						m_Town.Capture( m_Corrupted );
						m_Corrupted = null;
					}
				}
				#endregion
			}
			else
			{
				from.SendLocalizedMessage( 1005224 );	//	You can't use the sigil on that
			}

			Update();
		}

		public Sigil( Serial serial ) : base( serial )
		{
			m_Sigils.Add( this );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Corrupted );
			Faction.WriteReference( writer, m_Corrupting );

			writer.Write( (Item) m_LastMonolith );

			writer.Write( m_LastStolen );
			writer.Write( m_GraceStart );
			writer.Write( m_CorruptionStart );
			writer.Write( m_PurificationStart );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Town = Town.ReadReference( reader );
					m_Corrupted = Faction.ReadReference( reader );
					m_Corrupting = Faction.ReadReference( reader );

					m_LastMonolith = reader.ReadItem() as BaseMonolith;

					m_LastStolen = reader.ReadDateTime();
					m_GraceStart = reader.ReadDateTime();
					m_CorruptionStart = reader.ReadDateTime();
					m_PurificationStart = reader.ReadDateTime();

					Update();

					Mobile mob = RootParent as Mobile;

					if ( mob != null )
						mob.SolidHueOverride = OwnershipHue;

					break;
				}
			}
		}

		public bool ReturnHome()
		{
			BaseMonolith monolith = m_LastMonolith;

			if ( monolith == null && m_Town != null )
				monolith = m_Town.Monolith;

			if ( monolith != null && !monolith.Deleted )
				monolith.Sigil = this;

			return ( monolith != null && !monolith.Deleted );
		}

		public override void OnParentDeleted( object parent )
		{
			base.OnParentDeleted( parent );

			ReturnHome();
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			m_Sigils.Remove( this );
		}

		public override void Delete()
		{
			if ( ReturnHome() )
				return;

			base.Delete();
		}

		private static List<Sigil> m_Sigils = new List<Sigil>();

		public static List<Sigil> Sigils{ get{ return m_Sigils; } }
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class Silver : Item
	{
		public override double DefaultWeight
		{
			get { return 0.02; }
		}

		[Constructable]
		public Silver() : this( 1 )
		{
		}

		[Constructable]
		public Silver( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		[Constructable]
		public Silver( int amount ) : base( 0xEF0 )
		{
			Stackable = true;
			Amount = amount;
		}

		public Silver( Serial serial ) : base( serial )
		{
		}

		public override int GetDropSound()
		{
			if ( Amount <= 1 )
				return 0x2E4;
			else if ( Amount <= 5 )
				return 0x2E5;
			else
				return 0x2E6;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class SilverGivenEntry
	{
		public static readonly TimeSpan ExpirePeriod = TimeSpan.FromHours( 3.0 );

		private Mobile m_GivenTo;
		private DateTime m_TimeOfGift;

		public Mobile GivenTo{ get{ return m_GivenTo; } }
		public DateTime TimeOfGift{ get{ return m_TimeOfGift; } }

		public bool IsExpired{ get{ return ( m_TimeOfGift + ExpirePeriod ) < DateTime.Now; } }

		public SilverGivenEntry( Mobile givenTo )
		{
			m_GivenTo = givenTo;
			m_TimeOfGift = DateTime.Now;
		}
	}
}
// using System;

namespace Server.Factions
{
	public class SkaraBraee : Town
	{
		public SkaraBraee()
		{
			Definition =
				new TownDefinition(
					6,
					0x186F,
					"Skara Brae",
					"Skara Brae",
					new TextDefinition( 1011439, "SKARA BRAE" ),
					new TextDefinition( 1011567, "TOWN STONE FOR SKARA BRAE" ),
					new TextDefinition( 1041040, "The Faction Sigil Monolith of Skara Brae" ),
					new TextDefinition( 1041410, "The Faction Town Sigil Monolith of Skara Brae" ),
					new TextDefinition( 1041419, "Faction Town Stone of Skara Brae" ),
					new TextDefinition( 1041401, "Faction Town Sigil of Skara Brae" ),
					new TextDefinition( 1041392, "Corrupted Faction Town Sigil of Skara Brae" ),
					new Point3D( 576, 2200, 0 ),
					new Point3D( 572, 2196, 0 ) );
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Items;

namespace Server.Engines.CannedEvil
{
	public class SliceTimer : Timer
	{
		private ChampionSpawn m_Spawn;

		public SliceTimer( ChampionSpawn spawn ) : base( TimeSpan.FromSeconds( 1.0 ),  TimeSpan.FromSeconds( 1.0 ) )
		{
			m_Spawn = spawn;
			Priority = TimerPriority.OneSecond;
		}

		protected override void OnTick()
		{
			m_Spawn.OnSlice();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class SpinelWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x9C2; } }
		public override int BreathEffectSound{ get{ return 0x665; } }
		public override int BreathEffectItemID{ get{ return 0x3818; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 1 ); }

		[Constructable]
		public SpinelWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the spinel wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "spinel", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Energy, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "spinel scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public SpinelWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server;

namespace Server.Items
{
	public class StarRoomGate : Moongate
	{
		private bool m_Decays;
		private DateTime m_DecayTime;
		private Timer m_Timer;

		public override int LabelNumber{ get{ return 1049498; } } // dark moongate

		[Constructable]
		public StarRoomGate() : this( false )
		{
		}

		[Constructable]
		public StarRoomGate( bool decays, Point3D loc, Map map ) : this( decays )
		{
			MoveToWorld( loc, map );
			Effects.PlaySound( loc, map, 0x20E );
		}

		[Constructable]
		public StarRoomGate( bool decays ) : base( new Point3D( 5143, 1774, 0 ), Map.Lodor )
		{
			Dispellable = false;
			ItemID = 0x1FD4;

			if ( decays )
			{
				m_Decays = true;
				m_DecayTime = DateTime.Now + TimeSpan.FromMinutes( 2.0 );

				m_Timer = new InternalTimer( this, m_DecayTime );
				m_Timer.Start();
			}
		}

		public StarRoomGate( Serial serial ) : base( serial )
		{
		}

		public override void OnAfterDelete()
		{
			if ( m_Timer != null )
				m_Timer.Stop();

			base.OnAfterDelete();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Decays );

			if ( m_Decays )
				writer.WriteDeltaTime( m_DecayTime );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Decays = reader.ReadBool();

					if ( m_Decays )
					{
						m_DecayTime = reader.ReadDeltaTime();

						m_Timer = new InternalTimer( this, m_DecayTime );
						m_Timer.Start();
					}

					break;
				}
			}
		}

		private class InternalTimer : Timer
		{
			private Item m_Item;

			public InternalTimer( Item item, DateTime end ) : base( end - DateTime.Now )
			{
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a pile of stones" )]
	public class StoneDragon : BaseCreature
	{
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 9 ); }

		[Constructable]
		public StoneDragon () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a stone dragon";
			Body = 12;
			Hue = 2500;
			BaseSoundID = 268;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 75, 85 );
			SetResistance( ResistanceType.Energy, 15, 20 );

			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "marble scales" );
   			c.DropItem(scale);

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "Stone", "", c, 25, 0 );
				}
			}
		}

		public override void CheckReflect( Mobile caster, ref bool reflect )
		{
			reflect = true; // Every spell is reflected back to the caster
		}

		public override bool OnBeforeDeath()
		{
			this.Body = 0x33D;
			return base.OnBeforeDeath();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public StoneDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class StrongholdDefinition
	{
		private Rectangle2D[] m_Area;
		private Point3D m_JoinStone;
		private Point3D m_FactionStone;
		private Point3D[] m_Monoliths;

		public Rectangle2D[] Area{ get{ return m_Area; } }

		public Point3D JoinStone{ get{ return m_JoinStone; } }
		public Point3D FactionStone{ get{ return m_FactionStone; } }

		public Point3D[] Monoliths{ get{ return m_Monoliths; } }

		public StrongholdDefinition( Rectangle2D[] area, Point3D joinStone, Point3D factionStone, Point3D[] monoliths )
		{
			m_Area = area;
			m_JoinStone = joinStone;
			m_FactionStone = factionStone;
			m_Monoliths = monoliths;
		}
	}
}
// using System;

namespace Server.Factions
{
	public class StrongholdMonolith : BaseMonolith
	{
		public override int DefaultLabelNumber{ get{ return 1041042; } } // A Faction Sigil Monolith

		public override void OnTownChanged()
		{
			AssignName( Town == null ? null : Town.Definition.StrongholdMonolithName );
		}

		public StrongholdMonolith() : this( null, null )
		{
		}

		public StrongholdMonolith( Town town, Faction faction ) : base( town, faction )
		{
		}

		public StrongholdMonolith( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Regions;

namespace Server.Factions
{
	public class StrongholdRegion : BaseRegion
	{
		private Faction m_Faction;

		public Faction Faction
		{
			get{ return m_Faction; }
			set{ m_Faction = value; }
		}

		public StrongholdRegion( Faction faction ) : base( faction.Definition.FriendlyName, Faction.Facet, Region.DefaultPriority, faction.Definition.Stronghold.Area )
		{
			m_Faction = faction;

			Register();
		}

		public override bool OnMoveInto( Mobile m, Direction d, Point3D newLocation, Point3D oldLocation )
		{
			if ( !base.OnMoveInto( m, d, newLocation, oldLocation ) )
				return false;

			if ( m.AccessLevel >= AccessLevel.Counselor || Contains( oldLocation ) )
				return true;

			return ( Faction.Find( m, true, true ) != null );
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Ethics.Evil
{
	public sealed class SummonFamiliar : Power
	{
		public SummonFamiliar()
		{
			m_Definition = new PowerDefinition(
					5,
					"Summon Familiar",
					"Trubechs Vingir",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			if ( from.Familiar != null && from.Familiar.Deleted )
				from.Familiar = null;

			if ( from.Familiar != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have an unholy familiar." );
				return;
			}

			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}

			UnholyFamiliar familiar = new UnholyFamiliar();

			if ( Mobiles.BaseCreature.Summon( familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Familiar = familiar;

				FinishInvoke( from );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Ethics.Hero
{
	public sealed class SummonFamiliar : Power
	{
		public SummonFamiliar()
		{
			m_Definition = new PowerDefinition(
					5,
					"Summon Familiar",
					"Trubechs Vingir",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			if ( from.Familiar != null && from.Familiar.Deleted )
				from.Familiar = null;

			if ( from.Familiar != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have a holy familiar." );
				return;
			}

			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}

			HolyFamiliar familiar = new HolyFamiliar();

			if ( Mobiles.BaseCreature.Summon( familiar, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Familiar = familiar;

				FinishInvoke( from );
			}
		}
	}
}// using System;// using Server;// using Server.Items;// using Server.Engines.Plants;

namespace Server.Mobiles
{
	[CorpseName( "a swamp drake corpse" )]
	public class SwampDrake : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x3F; } }
		public override int BreathEffectSound{ get{ return 0x658; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 18 ); }

		[Constructable]
		public SwampDrake () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a swamp drake";
			Body = 55;
			BaseSoundID = 362;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 241, 258 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Poison, 50, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.FistFighting, 65.1, 80.0 );

			Fame = 5500;
			Karma = -5500;

			VirtualArmor = 46;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 84.3;

			PackReg( 3 );

			if ( Utility.Random( 100 ) > 60 )
			{
				int seed_to_give = Utility.Random( 100 );

				if ( seed_to_give > 90 )
				{
					PlantType type;
					switch ( Utility.Random( 17 ) )
					{
						case 0: type = PlantType.CampionFlowers; break;
						case 1: type = PlantType.Poppies; break;
						case 2: type = PlantType.Snowdrops; break;
						case 3: type = PlantType.Bulrushes; break;
						case 4: type = PlantType.Lilies; break;
						case 5: type = PlantType.PampasGrass; break;
						case 6: type = PlantType.Rushes; break;
						case 7: type = PlantType.ElephantEarPlant; break;
						case 8: type = PlantType.Fern; break;
						case 9: type = PlantType.PonytailPalm; break;
						case 10: type = PlantType.SmallPalm; break;
						case 11: type = PlantType.CenturyPlant; break;
						case 12: type = PlantType.WaterPlant; break;
						case 13: type = PlantType.SnakePlant; break;
						case 14: type = PlantType.PricklyPearCactus; break;
						case 15: type = PlantType.BarrelCactus; break;
						default: type = PlantType.TribarrelCactus; break;
					}
						PlantHue hue;
						switch ( Utility.Random( 4 ) )
						{
							case 0: hue = PlantHue.Pink; break;
							case 1: hue = PlantHue.Magenta; break;
							case 2: hue = PlantHue.FireRed; break;
							default: hue = PlantHue.Aqua; break;
						}

						PackItem( new Seed( type, hue, false ) );
				}
				else if ( seed_to_give > 70 )
				{
					PackItem( Engines.Plants.Seed.RandomPeculiarSeed( Utility.RandomMinMax( 1, 4 ) ) );
				}
				else if ( seed_to_give > 40 )
				{
					PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				}
				else
				{
					PackItem( new Engines.Plants.Seed() );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.MedScrolls, 2 );
		}

		public override int TreasureMapLevel{ get{ return 2; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Green ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public SwampDrake( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a beetle's corpse" )]
	public class TigerBeetle : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public TigerBeetle () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger beetle";
			Body = 0xA9;
			BaseSoundID = 0x388;

			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			SetHits( 80, 110 );

			SetDamage( 3, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Fire, 80 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 80, 90 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 16;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public TigerBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;

			Body = 0xA9;
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class TopazWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public TopazWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the topaz wyrm";
			BaseSoundID = 362;
			Body = Server.Misc.MyServerSettings.WyrmBody();
			Hue = Server.Misc.MaterialInfo.GetMaterialColor( "topaz", "monster", 0 );

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Item scale = new HardScales( Utility.RandomMinMax( 15, 20 ), "topaz scales" );
   			c.DropItem(scale);
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int GetAttackSound(){ return 0x63E; }	// A
		public override int GetDeathSound(){ return 0x63F; }	// D
		public override int GetHurtSound(){ return 0x640; }		// H
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }

		public TopazWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using System.Collections;// using Server;// using Server.Targeting;// using Server.Mobiles;// using Server.Commands;// using System.Collections.Generic;

namespace Server.Factions
{
	[CustomEnum( new string[]{ "Britain", "Renika", "Montor", "Elidor", "Skara Brae", "Moon", "Luna", "Yew" } )]
	public abstract class Town : IComparable
	{
		private TownDefinition m_Definition;
		private TownState m_State;

		public TownDefinition Definition
		{
			get{ return m_Definition; }
			set{ m_Definition = value; }
		}

		public TownState State
		{
			get{ return m_State; }
			set{ m_State = value; ConstructGuardLists(); }
		}

		public int Silver
		{
			get{ return m_State.Silver; }
			set{ m_State.Silver = value; }
		}

		public Faction Owner
		{
			get{ return m_State.Owner; }
			set{ Capture( value ); }
		}

		public Mobile Sheriff
		{
			get{ return m_State.Sheriff; }
			set{ m_State.Sheriff = value; }
		}

		public Mobile Finance
		{
			get{ return m_State.Finance; }
			set{ m_State.Finance = value; }
		}

		public int Tax
		{
			get{ return m_State.Tax; }
			set{ m_State.Tax = value; }
		}

		public DateTime LastTaxChange
		{
			get{ return m_State.LastTaxChange; }
			set{ m_State.LastTaxChange = value; }
		}

		public static readonly TimeSpan TaxChangePeriod = TimeSpan.FromHours( 12.0 );
		public static readonly TimeSpan IncomePeriod = TimeSpan.FromDays( 1.0 );

		public bool TaxChangeReady
		{
			get{ return ( m_State.LastTaxChange + TaxChangePeriod ) < DateTime.Now; }
		}

		public static Town FromRegion( Region reg )
		{
			if ( reg.Map != Faction.Facet )
				return null;

			List<Town> towns = Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				Town town = towns[i];

				if ( reg.IsPartOf( town.Definition.Region ) )
					return town;
			}

			return null;
		}

		public int FinanceUpkeep
		{
			get
			{
				List<VendorList> vendorLists = VendorLists;
				int upkeep = 0;

				for ( int i = 0; i < vendorLists.Count; ++i )
					upkeep += vendorLists[i].Vendors.Count * vendorLists[i].Definition.Upkeep;

				return upkeep;
			}
		}

		public int SheriffUpkeep
		{
			get
			{
				List<GuardList> guardLists = GuardLists;
				int upkeep = 0;

				for ( int i = 0; i < guardLists.Count; ++i )
					upkeep += guardLists[i].Guards.Count * guardLists[i].Definition.Upkeep;

				return upkeep;
			}
		}

		public int DailyIncome
		{
			get{ return (10000 * (100 + m_State.Tax)) / 100; }
		}

		public int NetCashFlow
		{
			get{ return DailyIncome - FinanceUpkeep - SheriffUpkeep; }
		}

		public TownMonolith Monolith
		{
			get
			{
				List<BaseMonolith> monoliths = BaseMonolith.Monoliths;

				foreach ( BaseMonolith monolith in monoliths )
				{
					if ( monolith is TownMonolith )
					{
						TownMonolith townMonolith = (TownMonolith)monolith;

						if ( townMonolith.Town == this )
							return townMonolith;
					}
				}

				return null;
			}
		}

		public DateTime LastIncome
		{
			get{ return m_State.LastIncome; }
			set{ m_State.LastIncome = value; }
		}

		public void BeginOrderFiring( Mobile from )
		{
			bool isFinance = IsFinance( from );
			bool isSheriff = IsSheriff( from );
			string type = null;

			// NOTE: Messages not OSI-accurate, intentional
			if ( isFinance && isSheriff ) // GM only
				type = "vendor or guard";
			else if ( isFinance )
				type = "vendor";
			else if ( isSheriff )
				type = "guard";

			from.SendMessage( "Target the {0} you wish to dismiss.", type );
			from.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( EndOrderFiring ) );
		}

		public void EndOrderFiring( Mobile from, object obj )
		{
			bool isFinance = IsFinance( from );
			bool isSheriff = IsSheriff( from );
			string type = null;

			if ( isFinance && isSheriff ) // GM only
				type = "vendor or guard";
			else if ( isFinance )
				type = "vendor";
			else if ( isSheriff )
				type = "guard";

			if ( obj is BaseFactionVendor )
			{
				BaseFactionVendor vendor = (BaseFactionVendor)obj;

				if ( vendor.Town == this && isFinance )
					vendor.Delete();
			}
			else if ( obj is BaseFactionGuard )
			{
				BaseFactionGuard guard = (BaseFactionGuard)obj;

				if ( guard.Town == this && isSheriff )
					guard.Delete();
			}
			else
			{
				from.SendMessage( "That is not a {0}!", type );
			}
		}

		private Timer m_IncomeTimer;

		public void StartIncomeTimer()
		{
			if ( m_IncomeTimer != null )
				m_IncomeTimer.Stop();

			m_IncomeTimer = Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), TimeSpan.FromMinutes( 1.0 ), new TimerCallback( CheckIncome ) );
		}

		public void StopIncomeTimer()
		{
			if ( m_IncomeTimer != null )
				m_IncomeTimer.Stop();

			m_IncomeTimer = null;
		}

		public void CheckIncome()
		{
			if ( (LastIncome + IncomePeriod) > DateTime.Now || Owner == null )
				return;

			ProcessIncome();
		}

		public void ProcessIncome()
		{
			LastIncome = DateTime.Now;

			int flow = NetCashFlow;

			if ( (Silver + flow) < 0 )
			{
				ArrayList toDelete = BuildFinanceList();

				while ( (Silver + flow) < 0 && toDelete.Count > 0 )
				{
					int index = Utility.Random( toDelete.Count );
					Mobile mob = (Mobile)toDelete[index];

					mob.Delete();

					toDelete.RemoveAt( index );
					flow = NetCashFlow;
				}
			}

			Silver += flow;
		}

		public ArrayList BuildFinanceList()
		{
			ArrayList list = new ArrayList();

			List<VendorList> vendorLists = VendorLists;

			for ( int i = 0; i < vendorLists.Count; ++i )
				list.AddRange( vendorLists[i].Vendors );

			List<GuardList> guardLists = GuardLists;

			for ( int i = 0; i < guardLists.Count; ++i )
				list.AddRange( guardLists[i].Guards );

			return list;
		}

		private List<VendorList> m_VendorLists;
		private List<GuardList> m_GuardLists;

		public List<VendorList> VendorLists
		{
			get{ return m_VendorLists; }
			set{ m_VendorLists = value; }
		}

		public List<GuardList> GuardLists
		{
			get{ return m_GuardLists; }
			set{ m_GuardLists = value; }
		}

		public void ConstructGuardLists()
		{
			GuardDefinition[] defs = ( Owner == null ? new GuardDefinition[0] : Owner.Definition.Guards );

			m_GuardLists = new List<GuardList>();

			for ( int i = 0; i < defs.Length; ++i )
				m_GuardLists.Add( new GuardList( defs[i] ) );
		}

		public GuardList FindGuardList( Type type )
		{
			List<GuardList> guardLists = GuardLists;

			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];

				if ( guardList.Definition.Type == type )
					return guardList;
			}

			return null;
		}

		public void ConstructVendorLists()
		{
			VendorDefinition[] defs = VendorDefinition.Definitions;

			m_VendorLists = new List<VendorList>();

			for ( int i = 0; i < defs.Length; ++i )
				m_VendorLists.Add( new VendorList( defs[i] ) );
		}

		public VendorList FindVendorList( Type type )
		{
			List<VendorList> vendorLists = VendorLists;

			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList vendorList = vendorLists[i];

				if ( vendorList.Definition.Type == type )
					return vendorList;
			}

			return null;
		}

		public bool RegisterGuard( BaseFactionGuard guard )
		{
			if ( guard == null )
				return false;

			GuardList guardList = FindGuardList( guard.GetType() );

			if ( guardList == null )
				return false;

			guardList.Guards.Add( guard );
			return true;
		}

		public bool UnregisterGuard( BaseFactionGuard guard )
		{
			if ( guard == null )
				return false;

			GuardList guardList = FindGuardList( guard.GetType() );

			if ( guardList == null )
				return false;

			if ( !guardList.Guards.Contains( guard ) )
				return false;

			guardList.Guards.Remove( guard );
			return true;
		}

		public bool RegisterVendor( BaseFactionVendor vendor )
		{
			if ( vendor == null )
				return false;

			VendorList vendorList = FindVendorList( vendor.GetType() );

			if ( vendorList == null )
				return false;

			vendorList.Vendors.Add( vendor );
			return true;
		}

		public bool UnregisterVendor( BaseFactionVendor vendor )
		{
			if ( vendor == null )
				return false;

			VendorList vendorList = FindVendorList( vendor.GetType() );

			if ( vendorList == null )
				return false;

			if ( !vendorList.Vendors.Contains( vendor ) )
				return false;

			vendorList.Vendors.Remove( vendor );
			return true;
		}

		public static void Initialize()
		{
			List<Town> towns = Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				towns[i].Sheriff = towns[i].Sheriff;
				towns[i].Finance = towns[i].Finance;
			}

			CommandSystem.Register( "GrantTownSilver", AccessLevel.Administrator, new CommandEventHandler( GrantTownSilver_OnCommand ) );
		}

		public Town()
		{
			m_State = new TownState( this );
			ConstructVendorLists();
			ConstructGuardLists();
			StartIncomeTimer();
		}

		public bool IsSheriff( Mobile mob )
		{
			if ( mob == null || mob.Deleted )
				return false;

			return ( mob.AccessLevel >= AccessLevel.GameMaster || mob == Sheriff );
		}

		public bool IsFinance( Mobile mob )
		{
			if ( mob == null || mob.Deleted )
				return false;

			return ( mob.AccessLevel >= AccessLevel.GameMaster || mob == Finance );
		}

		public static List<Town> Towns { get { return Reflector.Towns; } }

		public const int SilverCaptureBonus = 10000;

		public void Capture( Faction f )
		{
			if ( m_State.Owner == f )
				return;

			if ( m_State.Owner == null ) // going from unowned to owned
			{
				LastIncome = DateTime.Now;
				f.Silver += SilverCaptureBonus;
			}
			else if ( f == null ) // going from owned to unowned
			{
				LastIncome = DateTime.MinValue;
			}
			else // otherwise changing hands, income timer doesn't change
			{
				f.Silver += SilverCaptureBonus;
			}

			m_State.Owner = f;

			Sheriff = null;
			Finance = null;

			TownMonolith monolith = this.Monolith;

			if ( monolith != null )
				monolith.Faction = f;

			List<VendorList> vendorLists = VendorLists;

			for ( int i = 0; i < vendorLists.Count; ++i )
			{
				VendorList vendorList = vendorLists[i];
				List<BaseFactionVendor> vendors = vendorList.Vendors;

				for ( int j = vendors.Count - 1; j >= 0; --j )
					vendors[j].Delete();
			}

			List<GuardList> guardLists = GuardLists;

			for ( int i = 0; i < guardLists.Count; ++i )
			{
				GuardList guardList = guardLists[i];
				List<BaseFactionGuard> guards = guardList.Guards;

				for ( int j = guards.Count - 1; j >= 0; --j )
					guards[j].Delete();
			}

			ConstructGuardLists();
		}

		public int CompareTo( object obj )
		{
			return m_Definition.Sort - ((Town)obj).m_Definition.Sort;
		}

		public override string ToString()
		{
			return m_Definition.FriendlyName;
		}

		public static void WriteReference( GenericWriter writer, Town town )
		{
			int idx = Towns.IndexOf( town );

			writer.WriteEncodedInt( (int) (idx + 1) );
		}

		public static Town ReadReference( GenericReader reader )
		{
			int idx = reader.ReadEncodedInt() - 1;

			if ( idx >= 0 && idx < Towns.Count )
				return Towns[idx];

			return null;
		}

		public static Town Parse( string name )
		{
			List<Town> towns = Towns;

			for ( int i = 0; i < towns.Count; ++i )
			{
				Town town = towns[i];

				if ( Insensitive.Equals( town.Definition.FriendlyName, name ) )
					return town;
			}

			return null;
		}

		public static void GrantTownSilver_OnCommand( CommandEventArgs e )
		{
			Town town = FromRegion( e.Mobile.Region );

			if ( town == null )
				e.Mobile.SendMessage( "You are not in a faction town." );
			else if ( e.Length == 0 )
				e.Mobile.SendMessage( "Format: GrantTownSilver <amount>" );
			else
			{
				town.Silver += e.GetInt32( 0 );
				e.Mobile.SendMessage( "You have granted {0:N0} silver to the town. It now has {1:N0} silver.", e.GetInt32( 0 ), town.Silver );
			}
		}
	}
}
// using System;

namespace Server.Factions
{
	public class TownDefinition
	{
		private int m_Sort;
		private int m_SigilID;

		private string m_Region;

		private string m_FriendlyName;

		private TextDefinition m_TownName;
		private TextDefinition m_TownStoneHeader;
		private TextDefinition m_StrongholdMonolithName;
		private TextDefinition m_TownMonolithName;
		private TextDefinition m_TownStoneName;
		private TextDefinition m_SigilName;
		private TextDefinition m_CorruptedSigilName;

		private Point3D m_Monolith;
		private Point3D m_TownStone;

		public int Sort{ get{ return m_Sort; } }
		public int SigilID{ get{ return m_SigilID; } }

		public string Region{ get{ return m_Region; } }
		public string FriendlyName{ get{ return m_FriendlyName; } }

		public TextDefinition TownName{ get{ return m_TownName; } }
		public TextDefinition TownStoneHeader{ get{ return m_TownStoneHeader; } }
		public TextDefinition StrongholdMonolithName{ get{ return m_StrongholdMonolithName; } }
		public TextDefinition TownMonolithName{ get{ return m_TownMonolithName; } }
		public TextDefinition TownStoneName{ get{ return m_TownStoneName; } }
		public TextDefinition SigilName{ get{ return m_SigilName; } }
		public TextDefinition CorruptedSigilName{ get{ return m_CorruptedSigilName; } }

		public Point3D Monolith{ get{ return m_Monolith; } }
		public Point3D TownStone{ get{ return m_TownStone; } }

		public TownDefinition( int sort, int sigilID, string region, string friendlyName, TextDefinition townName, TextDefinition townStoneHeader, TextDefinition strongholdMonolithName, TextDefinition townMonolithName, TextDefinition townStoneName, TextDefinition sigilName, TextDefinition corruptedSigilName, Point3D monolith, Point3D townStone )
		{
			m_Sort = sort;
			m_SigilID = sigilID;
			m_Region = region;
			m_FriendlyName = friendlyName;
			m_TownName = townName;
			m_TownStoneHeader = townStoneHeader;
			m_StrongholdMonolithName = strongholdMonolithName;
			m_TownMonolithName = townMonolithName;
			m_TownStoneName = townStoneName;
			m_SigilName = sigilName;
			m_CorruptedSigilName = corruptedSigilName;
			m_Monolith = monolith;
			m_TownStone = townStone;
		}
	}
}
// using System;

namespace Server.Factions
{
	public class TownMonolith : BaseMonolith
	{
		public override int DefaultLabelNumber{ get{ return 1041403; } } // A Faction Town Sigil Monolith

		public override void OnTownChanged()
		{
			AssignName( Town == null ? null : Town.Definition.TownMonolithName );
		}

		public TownMonolith() : this( null )
		{
		}

		public TownMonolith( Town town ) : base( town, null )
		{
		}

		public TownMonolith( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class TownState
	{
		private Town m_Town;
		private Faction m_Owner;

		private Mobile m_Sheriff;
		private Mobile m_Finance;

		private int m_Silver;
		private int m_Tax;

		private DateTime m_LastTaxChange;
		private DateTime m_LastIncome;

		public Town Town
		{
			get{ return m_Town; }
			set{ m_Town = value; }
		}

		public Faction Owner
		{
			get{ return m_Owner; }
			set{ m_Owner = value; }
		}

		public Mobile Sheriff
		{
			get{ return m_Sheriff; }
			set
			{
				if ( m_Sheriff != null )
				{
					PlayerState pl = PlayerState.Find( m_Sheriff );

					if ( pl != null )
						pl.Sheriff = null;
				}

				m_Sheriff = value;

				if ( m_Sheriff != null )
				{
					PlayerState pl = PlayerState.Find( m_Sheriff );

					if ( pl != null )
						pl.Sheriff = m_Town;
				}
			}
		}

		public Mobile Finance
		{
			get{ return m_Finance; }
			set
			{
				if ( m_Finance != null )
				{
					PlayerState pl = PlayerState.Find( m_Finance );

					if ( pl != null )
						pl.Finance = null;
				}

				m_Finance = value;

				if ( m_Finance != null )
				{
					PlayerState pl = PlayerState.Find( m_Finance );

					if ( pl != null )
						pl.Finance = m_Town;
				}
			}
		}

		public int Silver
		{
			get{ return m_Silver; }
			set{ m_Silver = value; }
		}

		public int Tax
		{
			get{ return m_Tax; }
			set{ m_Tax = value; }
		}

		public DateTime LastTaxChange
		{
			get{ return m_LastTaxChange; }
			set{ m_LastTaxChange = value; }
		}

		public DateTime LastIncome
		{
			get{ return m_LastIncome; }
			set{ m_LastIncome = value; }
		}

		public TownState( Town town )
		{
			m_Town = town;
		}

		public TownState( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			switch ( version )
			{
				case 3:
				{
					m_LastIncome = reader.ReadDateTime();

					goto case 2;
				}
				case 2:
				{
					m_Tax = reader.ReadEncodedInt();
					m_LastTaxChange = reader.ReadDateTime();

					goto case 1;
				}
				case 1:
				{
					m_Silver = reader.ReadEncodedInt();

					goto case 0;
				}
				case 0:
				{
					m_Town = Town.ReadReference( reader );
					m_Owner = Faction.ReadReference( reader );

					m_Sheriff = reader.ReadMobile();
					m_Finance = reader.ReadMobile();

					m_Town.State = this;

					break;
				}
			}
		}

		public void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 3 ); // version

			writer.Write( (DateTime) m_LastIncome );

			writer.WriteEncodedInt( (int) m_Tax );
			writer.Write( (DateTime) m_LastTaxChange );

			writer.WriteEncodedInt( (int) m_Silver );

			Town.WriteReference( writer, m_Town );
			Faction.WriteReference( writer, m_Owner );

			writer.Write( (Mobile) m_Sheriff );
			writer.Write( (Mobile) m_Finance );
		}
	}
}
// using System;// using Server;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class TownStone : BaseSystemController
	{
		private Town m_Town;

		[CommandProperty( AccessLevel.Counselor, AccessLevel.Administrator )]
		public Town Town
		{
			get{ return m_Town; }
			set
			{
				m_Town = value;

				AssignName( m_Town == null ? null : m_Town.Definition.TownStoneName );
			}
		}

		public override string DefaultName { get { return "faction town stone"; } }

		[Constructable]
		public TownStone() : this( null )
		{
		}

		[Constructable]
		public TownStone( Town town ) : base( 0xEDE )
		{
			Movable = false;
			Town = town;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( m_Town == null )
				return;

			Faction faction = Faction.Find( from );

			if ( faction == null && from.AccessLevel < AccessLevel.GameMaster )
				return; // TODO: Message?

			if ( m_Town.Owner == null || ( from.AccessLevel < AccessLevel.GameMaster && faction != m_Town.Owner ) )
				from.SendLocalizedMessage( 1010332 ); // Your faction does not control this town
			else if ( !m_Town.Owner.IsCommander( from ) )
				from.SendLocalizedMessage( 1005242 ); // Only faction Leaders can use townstones
			else if ( FactionGump.Exists( from ) )
				from.SendLocalizedMessage( 1042160 ); // You already have a faction menu open.
			else if ( from is PlayerMobile )
				from.SendGump( new TownStoneGump( (PlayerMobile)from, m_Town.Owner, m_Town ) );
		}

		public TownStone( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			Town.WriteReference( writer, m_Town );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					Town = Town.ReadReference( reader );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;// using Server.Targeting;

namespace Server.Factions
{
	public class TownStoneGump : FactionGump
	{
		private PlayerMobile m_From;
		private Faction m_Faction;
		private Town m_Town;

		public TownStoneGump( PlayerMobile from, Faction faction, Town town ) : base( 50, 50 )
		{
			m_From = from;
			m_Faction = faction;
			m_Town = town;

			AddPage( 0 );

			AddBackground( 0, 0, 320, 250, 5054 );
			AddBackground( 10, 10, 300, 230, 3000 );

			AddHtmlText( 25, 30, 250, 25, town.Definition.TownStoneHeader, false, false );

			AddHtmlLocalized( 55, 60, 150, 25, 1011557, false, false ); // Hire Sheriff
			AddButton( 20, 60, 4005, 4007, 1, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 90, 150, 25, 1011559, false, false ); // Hire Finance Minister
			AddButton( 20, 90, 4005, 4007, 2, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 120, 150, 25, 1011558, false, false ); // Fire Sheriff
			AddButton( 20, 120, 4005, 4007, 3, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 150, 150, 25, 1011560, false, false ); // Fire Finance Minister
			AddButton( 20, 150, 4005, 4007, 4, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 55, 210, 150, 25, 1011441, false, false ); // EXIT
			AddButton( 20, 210, 4005, 4007, 0, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( m_Town.Owner != m_Faction || !m_Faction.IsCommander( m_From ) )
			{
				m_From.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}

			switch ( info.ButtonID )
			{
				case 1: // hire sheriff
				{
					if ( m_Town.Sheriff != null )
					{
						m_From.SendLocalizedMessage( 1010342 ); // You must fire your Sheriff before you can elect a new one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010347 ); // Who shall be your new sheriff
						m_From.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( HireSheriff_OnTarget ) );
					}

					break;
				}
				case 2: // hire finance minister
				{
					if ( m_Town.Finance != null )
					{
						m_From.SendLocalizedMessage( 1010345 ); // You must fire your finance minister before you can elect a new one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010348 ); // Who shall be your new Minister of Finances?
						m_From.BeginTarget( 12, false, TargetFlags.None, new TargetCallback( HireFinanceMinister_OnTarget ) );
					}

					break;
				}
				case 3: // fire sheriff
				{
					if ( m_Town.Sheriff == null )
					{
						m_From.SendLocalizedMessage( 1010350 ); // You need to elect a sheriff before you can fire one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010349 ); // You have fired your sheriff
						m_Town.Sheriff.SendLocalizedMessage( 1010270 ); // You have been fired as Sheriff
						m_Town.Sheriff = null;
					}

					break;
				}
				case 4: // fire finance minister
				{
					if ( m_Town.Finance == null )
					{
						m_From.SendLocalizedMessage( 1010352 ); // You need to elect a financial minister before you can fire one
					}
					else
					{
						m_From.SendLocalizedMessage( 1010351 ); // You have fired your financial Minister
						m_Town.Finance.SendLocalizedMessage( 1010151 ); // You have been fired as Finance Minister
						m_Town.Finance = null;
					}

					break;
				}
			}
		}

		private void HireSheriff_OnTarget( Mobile from, object obj )
		{
			if ( m_Town.Owner != m_Faction || !m_Faction.IsCommander( from ) )
			{
				from.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}
			else if ( m_Town.Sheriff != null )
			{
				from.SendLocalizedMessage( 1010342 ); // You must fire your Sheriff before you can elect a new one
			}
			else if ( obj is Mobile )
			{
				Mobile targ = (Mobile)obj;
				PlayerState pl = PlayerState.Find( targ );

				if ( pl == null )
				{
					from.SendLocalizedMessage( 1010337 ); // You must pick someone in a faction
				}
				else if ( pl.Faction != m_Faction )
				{
					from.SendLocalizedMessage( 1010338 ); // You must pick someone in the correct faction
				}
				else if ( m_Faction.Commander == targ )
				{
					from.SendLocalizedMessage( 1010335 ); // You cannot elect a commander to a town position
				}
				else if ( pl.Sheriff != null || pl.Finance != null )
				{
					from.SendLocalizedMessage( 1005245 ); // You must pick someone who does not already hold a city post
				}
				else
				{
					m_Town.Sheriff = targ;
					targ.SendLocalizedMessage( 1010340 ); // You are now the Sheriff
					from.SendLocalizedMessage( 1010341 ); // You have elected a Sheriff
				}
			}
			else
			{
				from.SendLocalizedMessage( 1010334 ); // You must select a player to hold a city position!
			}
		}

		private void HireFinanceMinister_OnTarget( Mobile from, object obj )
		{
			if ( m_Town.Owner != m_Faction || !m_Faction.IsCommander( from ) )
			{
				from.SendLocalizedMessage( 1010339 ); // You no longer control this city
				return;
			}
			else if ( m_Town.Finance != null )
			{
				from.SendLocalizedMessage( 1010342 ); // You must fire your Sheriff before you can elect a new one
			}
			else if ( obj is Mobile )
			{
				Mobile targ = (Mobile)obj;
				PlayerState pl = PlayerState.Find( targ );

				if ( pl == null )
				{
					from.SendLocalizedMessage( 1010337 ); // You must pick someone in a faction
				}
				else if ( pl.Faction != m_Faction )
				{
					from.SendLocalizedMessage( 1010338 ); // You must pick someone in the correct faction
				}
				else if ( m_Faction.Commander == targ )
				{
					from.SendLocalizedMessage( 1010335 ); // You cannot elect a commander to a town position
				}
				else if ( pl.Sheriff != null || pl.Finance != null )
				{
					from.SendLocalizedMessage( 1005245 ); // You must pick someone who does not already hold a city post
				}
				else
				{
					m_Town.Finance = targ;
					targ.SendLocalizedMessage( 1010343 ); // You are now the Financial Minister
					from.SendLocalizedMessage( 1010344 ); // You have elected a Financial Minister
				}
			}
			else
			{
				from.SendLocalizedMessage( 1010334 ); // You must select a player to hold a city position!
			}
		}
	}
}
// using System;// using Server;// using Server.Network;// using System.Collections;// using System.Collections.Generic;// using Server.Items;// using Server.Gumps;// using Server.Misc;// using Server.Mobiles;

namespace Server.Misc
{
	public enum TreasuresOfTokunoEra
	{
		None,
		ToTOne,
		ToTTwo,
		ToTThree
	}

	public class TreasuresOfTokuno
	{
		public const int ItemsPerReward = 10;

		private static Type[] m_LesserArtifactsTotal = new Type[]
			{
				typeof( AncientFarmersKasa ), typeof( AncientSamuraiDo ), typeof( ArmsOfTacticalExcellence ), typeof( BlackLotusHood ),
 				typeof( DaimyosHelm ), typeof( DemonForks ), typeof( DragonNunchaku ), typeof( Exiler ), typeof( GlovesOfTheSun ),
 				typeof( HanzosBow ), typeof( LegsOfStability ), typeof( PeasantsBokuto ), typeof( PilferedDancerFans ), typeof( TheDestroyer ),
				typeof( TomeOfEnlightenment ), typeof( AncientUrn ), typeof( HonorableSwords ), typeof( PigmentsOfIslesDread ), typeof( FluteOfRenewal ),
				typeof( LeurociansMempoOfFortune ), typeof( LesserPigmentsOfIslesDread ), typeof( MetalPigmentsOfIslesDread ), typeof( ChestOfHeirlooms )
 			};

		public static Type[] LesserArtifactsTotal { get { return m_LesserArtifactsTotal; } }

		private static TreasuresOfTokunoEra _DropEra = TreasuresOfTokunoEra.None;
		private static TreasuresOfTokunoEra _RewardEra = TreasuresOfTokunoEra.ToTOne;

		public static TreasuresOfTokunoEra DropEra
		{
			get { return _DropEra; }
			set { _DropEra = value; }
		}

		public static TreasuresOfTokunoEra RewardEra
		{
			get { return _RewardEra; }
			set { _RewardEra = value; }
		}

		private static Type[][] m_LesserArtifacts = new Type[][]
		{
			// ToT One Rewards
			new Type[] {
				typeof( AncientFarmersKasa ), typeof( AncientSamuraiDo ), typeof( ArmsOfTacticalExcellence ), typeof( BlackLotusHood ),
				typeof( DaimyosHelm ), typeof( DemonForks ), typeof( DragonNunchaku ), typeof( Exiler ), typeof( GlovesOfTheSun ),
				typeof( HanzosBow ), typeof( LegsOfStability ), typeof( PeasantsBokuto ), typeof( PilferedDancerFans ), typeof( TheDestroyer ),
				typeof( TomeOfEnlightenment ), typeof( AncientUrn ), typeof( HonorableSwords ), typeof( PigmentsOfIslesDread ),
				typeof( FluteOfRenewal ), typeof( ChestOfHeirlooms )
			},
			// ToT Two Rewards
			new Type[] {
				typeof( MetalPigmentsOfIslesDread ), typeof( AncientFarmersKasa ), typeof( AncientSamuraiDo ), typeof( ArmsOfTacticalExcellence ),
				typeof( MetalPigmentsOfIslesDread ), typeof( BlackLotusHood ), typeof( DaimyosHelm ), typeof( DemonForks ),
				typeof( MetalPigmentsOfIslesDread ), typeof( DragonNunchaku ), typeof( Exiler ), typeof( GlovesOfTheSun ), typeof( HanzosBow ),
				typeof( MetalPigmentsOfIslesDread ), typeof( LegsOfStability ), typeof( PeasantsBokuto ), typeof( PilferedDancerFans ), typeof( TheDestroyer ),
				typeof( MetalPigmentsOfIslesDread ), typeof( TomeOfEnlightenment ), typeof( AncientUrn ), typeof( HonorableSwords ),
				typeof( MetalPigmentsOfIslesDread ), typeof( FluteOfRenewal ), typeof( ChestOfHeirlooms )
			},
			// ToT Three Rewards
			new Type[] {
				typeof( LesserPigmentsOfIslesDread ), typeof( AncientFarmersKasa ), typeof( AncientSamuraiDo ), typeof( ArmsOfTacticalExcellence ),
				typeof( LesserPigmentsOfIslesDread ), typeof( BlackLotusHood ), typeof( DaimyosHelm ), typeof( HanzosBow ),
				typeof( LesserPigmentsOfIslesDread ), typeof( DemonForks ), typeof( DragonNunchaku ), typeof( Exiler ), typeof( GlovesOfTheSun ),
				typeof( LesserPigmentsOfIslesDread ), typeof( LegsOfStability ), typeof( PeasantsBokuto ), typeof( PilferedDancerFans ), typeof( TheDestroyer ),
				typeof( LesserPigmentsOfIslesDread ), typeof( TomeOfEnlightenment ), typeof( AncientUrn ), typeof( HonorableSwords ), typeof( FluteOfRenewal ),
				typeof( LesserPigmentsOfIslesDread ), typeof( LeurociansMempoOfFortune ), typeof( ChestOfHeirlooms )
			}
		};

		public static Type[] LesserArtifacts
		{
			get { return m_LesserArtifacts[(int)RewardEra-1]; }
		}

		private static Type[][] m_GreaterArtifacts = null;

		public static Type[] GreaterArtifacts
		{
			get
			{
				if( m_GreaterArtifacts == null )
				{
					m_GreaterArtifacts = new Type[ToTRedeemGump.NormalRewards.Length][];

					for( int i = 0; i < m_GreaterArtifacts.Length; i++ )
					{
						m_GreaterArtifacts[i] = new Type[ToTRedeemGump.NormalRewards[i].Length];

						for( int j = 0; j < m_GreaterArtifacts[i].Length; j++ )
						{
							m_GreaterArtifacts[i][j] = ToTRedeemGump.NormalRewards[i][j].Type;
						}
					}
				}

				return m_GreaterArtifacts[(int)RewardEra-1];
			}
		}

		private static bool CheckLocation( Mobile m )
		{
			Region r = m.Region;

			if( r.IsPartOf( typeof( Server.Regions.HouseRegion ) ) || Server.Multis.BaseBoat.FindBoatAt( m, m.Map ) != null )
				return false;
			//TODO: a CanReach of something check as opposed to above?

			if( r.IsPartOf( "Yomotsu Mines" ) || r.IsPartOf( "Fan Dancer's Dojo" ) )
				return true;

			return (m.Map == Map.IslesDread);
		}

		public static void HandleKill( Mobile victim, Mobile killer )
		{
			PlayerMobile pm = killer as PlayerMobile;
			BaseCreature bc = victim as BaseCreature;

			if( DropEra == TreasuresOfTokunoEra.None || pm == null || bc == null || !CheckLocation( bc ) || !CheckLocation( pm )|| !killer.InRange( victim, 18 ))
				return;

			if( bc.Controlled || bc.Owners.Count > 0 || bc.Fame <= 0 )
				return;

			//25000 for 1/100 chance, 10 hyrus
			//1500, 1/1000 chance, 20 lizard men for that chance.

			pm.ToTTotalMonsterFame += (int)(bc.Fame * (1 + Math.Sqrt( pm.Luck ) / 100));

			//This is the Exponentional regression with only 2 datapoints.
			//A log. func would also work, but it didn't make as much sense.
			//This function isn't OSI exact beign that I don't know OSI's func they used ;p
			int x = pm.ToTTotalMonsterFame;

			//const double A = 8.63316841 * Math.Pow( 10, -4 );
			const double A = 0.000863316841;
			//const double B = 4.25531915 * Math.Pow( 10, -6 );
			const double B = 0.00000425531915;

			double chance = A * Math.Pow( 10, B * x );

			if( chance > Utility.RandomDouble() )
			{
				Item i = null;

				try
				{
					i = Activator.CreateInstance( m_LesserArtifacts[(int)DropEra-1][Utility.Random( m_LesserArtifacts[(int)DropEra-1].Length )] ) as Item;
				}
				catch
				{ }

				if( i != null )
				{
					pm.SendLocalizedMessage( 1062317 ); // For your valor in combating the fallen beast, a special artifact has been bestowed on you.

					if( !pm.PlaceInBackpack( i ) )
					{
						if( pm.BankBox != null && pm.BankBox.TryDropItem( killer, i, false ) )
							pm.SendLocalizedMessage( 1079730 ); // The item has been placed into your bank box.
						else
						{
							pm.SendLocalizedMessage( 1072523 ); // You find an artifact, but your backpack and bank are too full to hold it.
							i.MoveToWorld( pm.Location, pm.Map );
						}
					}

					pm.ToTTotalMonsterFame = 0;
				}
			}
		}
	}
}

namespace Server.Mobiles
{
	public class IharaSoko : BaseVendor
	{
		public override bool IsActiveVendor { get { return false; } }
		public override bool IsInvulnerable { get { return true; } }
		public override bool DisallowAllMoves { get { return true; } }
		public override bool ClickTitle { get { return true; } }
		public override bool CanTeach { get { return false; } }

        protected List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		public override void InitSBInfo()
		{
		}

		public override void InitOutfit()
		{
			AddItem( new Waraji( 0x711 ) );
			AddItem( new Backpack() );
			AddItem( new Kamishimo( 0x483 ) );

			Item item = new LightPlateJingasa();
			item.Hue = 0x711;

			AddItem( item );
		}

		[Constructable]
		public IharaSoko() : base( "the Imperial Minister of Trade" )
		{
			Name = "Ihara Soko";
			Female = false;
			Body = 0x190;
			Hue = 0x8403;
		}

		public IharaSoko( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override bool CanBeDamaged()
		{
			return false;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if( m.Alive && m is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile)m;

				int range = 3;

				if( m.Alive && Math.Abs( Z - m.Z ) < 16 && InRange( m, range ) && !InRange( oldLocation, range ) )
				{
					if( pm.ToTItemsTurnedIn >= TreasuresOfTokuno.ItemsPerReward )
					{
						SayTo( pm, 1070980 ); // Congratulations! You have turned in enough minor treasures to earn a greater reward.

						pm.CloseGump( typeof( ToTTurnInGump ) );	//Sanity

						if( !pm.HasGump( typeof( ToTRedeemGump ) ) )
							pm.SendGump( new ToTRedeemGump( this, false ) );
					}
					else
					{
						if( pm.ToTItemsTurnedIn == 0 )
							SayTo( pm, 1071013 ); // Bring me 10 of the lost treasures of IslesDread and I will reward you with a valuable item.
						else
							SayTo( pm, 1070981, String.Format( "{0}\t{1}", pm.ToTItemsTurnedIn, TreasuresOfTokuno.ItemsPerReward ) ); // You have turned in ~1_COUNT~ minor artifacts. Turn in ~2_NUM~ to receive a reward.

						ArrayList buttons = ToTTurnInGump.FindRedeemableItems( pm );

						if( buttons.Count > 0 && !pm.HasGump( typeof( ToTTurnInGump ) ) )
							pm.SendGump( new ToTTurnInGump( this, buttons ) );
					}
				}

				int leaveRange = 7;

				if( !InRange( m, leaveRange ) && InRange( oldLocation, leaveRange ) )
				{
					pm.CloseGump( typeof( ToTRedeemGump ) );
					pm.CloseGump( typeof( ToTTurnInGump ) );
				}
			}
		}

		//public override void TurnToIslesDread(){}
	}
}

namespace Server.Gumps
{
	public class ItemTileButtonInfo : ImageTileButtonInfo
	{
		private Item m_Item;

		public Item Item
		{
			get { return m_Item; }
			set { m_Item = value; }
		}

		public ItemTileButtonInfo( Item i ) : base( i.ItemID, i.Hue, ((i.Name == null || i.Name.Length <= 0)? (TextDefinition)i.LabelNumber : (TextDefinition)i.Name ) )
		{
			m_Item = i;
		}
	}

	public class ToTTurnInGump : BaseImageTileButtonsGump
	{
		public static ArrayList FindRedeemableItems( Mobile m )
		{
			Backpack pack = (Backpack)m.Backpack;
			if( pack == null )
				return new ArrayList();

			ArrayList items = new ArrayList( pack.FindItemsByType( TreasuresOfTokuno.LesserArtifactsTotal ) );
			ArrayList buttons = new ArrayList();

			for( int i = 0; i < items.Count; i++ )
			{
				Item item = (Item)items[i];
				if( item is ChestOfHeirlooms && !((ChestOfHeirlooms)item).Locked )
					continue;

				if( item is ChestOfHeirlooms && ((ChestOfHeirlooms)item).TrapLevel != 10 )
					continue;

				if( item is PigmentsOfIslesDread && ((PigmentsOfIslesDread)item).Type != PigmentType.None )
					continue;

				buttons.Add( new ItemTileButtonInfo( item ) );
			}

			return buttons;
		}

		Mobile m_Collector;

		public ToTTurnInGump( Mobile collector, ArrayList buttons ) : base( 1071012, buttons ) // Click a minor artifact to give it to Ihara Soko.
		{
			m_Collector = collector;
		}

		public ToTTurnInGump( Mobile collector, ItemTileButtonInfo[] buttons ) : base( 1071012, buttons ) // Click a minor artifact to give it to Ihara Soko.
		{
			m_Collector = collector;
		}

		public override void HandleButtonResponse( NetState sender, int adjustedButton, ImageTileButtonInfo buttonInfo )
		{
			PlayerMobile pm = sender.Mobile as PlayerMobile;

			Item item = ((ItemTileButtonInfo)buttonInfo).Item;

			if( !( pm != null && item.IsChildOf( pm.Backpack ) && pm.InRange( m_Collector.Location, 7 )) )
				return;

			item.Delete();

			if( ++pm.ToTItemsTurnedIn >= TreasuresOfTokuno.ItemsPerReward )
			{
				m_Collector.SayTo( pm, 1070980 ); // Congratulations! You have turned in enough minor treasures to earn a greater reward.

				pm.CloseGump( typeof( ToTTurnInGump ) );	//Sanity

				if( !pm.HasGump( typeof( ToTRedeemGump ) ) )
					pm.SendGump( new ToTRedeemGump( m_Collector, false ) );
			}
			else
			{
				m_Collector.SayTo( pm, 1070981, String.Format( "{0}\t{1}", pm.ToTItemsTurnedIn, TreasuresOfTokuno.ItemsPerReward ) ); // You have turned in ~1_COUNT~ minor artifacts. Turn in ~2_NUM~ to receive a reward.

				ArrayList buttons = FindRedeemableItems( pm );

				pm.CloseGump( typeof( ToTTurnInGump ) ); //Sanity

				if( buttons.Count > 0 )
					pm.SendGump( new ToTTurnInGump( m_Collector, buttons ) );
			}
		}

		public override void HandleCancel( NetState sender )
		{
			PlayerMobile pm = sender.Mobile as PlayerMobile;

			if( pm == null || !pm.InRange( m_Collector.Location, 7 ) )
				return;

			if( pm.ToTItemsTurnedIn == 0 )
				m_Collector.SayTo( pm, 1071013 ); // Bring me 10 of the lost treasures of IslesDread and I will reward you with a valuable item.
			else if( pm.ToTItemsTurnedIn < TreasuresOfTokuno.ItemsPerReward )	//This case should ALWAYS be true with this gump, jsut a sanity check
				m_Collector.SayTo( pm, 1070981, String.Format( "{0}\t{1}", pm.ToTItemsTurnedIn, TreasuresOfTokuno.ItemsPerReward ) ); // You have turned in ~1_COUNT~ minor artifacts. Turn in ~2_NUM~ to receive a reward.
			else
				m_Collector.SayTo( pm, 1070982 ); // When you wish to choose your reward, you have but to approach me again.
		}

	}
}

namespace Server.Gumps
{
	public class ToTRedeemGump : BaseImageTileButtonsGump
	{
		public class TypeTileButtonInfo : ImageTileButtonInfo
		{
			private Type m_Type;

			public Type Type { get { return m_Type; } }

			public TypeTileButtonInfo( Type type, int itemID, int hue, TextDefinition label, int localizedToolTip ) : base( itemID, hue, label, localizedToolTip )
			{
				m_Type = type;
			}

			public TypeTileButtonInfo( Type type, int itemID, TextDefinition label ) : this( type, itemID, 0, label, -1 )
			{
			}

			public TypeTileButtonInfo( Type type, int itemID, TextDefinition label, int localizedToolTip ) : this( type, itemID, 0, label, localizedToolTip )
			{
			}
		}

		public class PigmentsTileButtonInfo : ImageTileButtonInfo
		{
			private PigmentType m_Pigment;

			public PigmentType Pigment
			{
				get
				{
					return m_Pigment;
				}

				set
				{
					m_Pigment = value;
				}
			}

			public PigmentsTileButtonInfo( PigmentType p ) : base( 0xEFF, PigmentsOfIslesDread.GetInfo( p )[0], PigmentsOfIslesDread.GetInfo( p )[1] )
			{
				m_Pigment = p;
			}
		}

		#region ToT Normal Rewards Table
		private static TypeTileButtonInfo[][] m_NormalRewards = new TypeTileButtonInfo[][]
		{
			// ToT One Rewards
			new TypeTileButtonInfo[] {
				new TypeTileButtonInfo( typeof( SwordsOfProsperity ),	 0x27A9, 1070963, 1071002 ),
				new TypeTileButtonInfo( typeof( SwordOfTheStampede ),	 0x27A2, 1070964, 1070978 ),
				new TypeTileButtonInfo( typeof( WindsEdge ),			 0x27A3, 1070965, 1071003 ),
				new TypeTileButtonInfo( typeof( DarkenedSky ),			 0x27AD, 1070966, 1071004 ),
				new TypeTileButtonInfo( typeof( TheHorselord ),			 0x27A5, 1070967, 1071005 ),
				new TypeTileButtonInfo( typeof( RuneBeetleCarapace ),	 0x277D, 1070968, 1071006 ),
				new TypeTileButtonInfo( typeof( KasaOfTheRajin ),		 0x2798, 1070969, 1071007 ),
				new TypeTileButtonInfo( typeof( Stormgrip ),			 0x2792, 1070970, 1071008 ),
				new TypeTileButtonInfo( typeof( TomeOfLostKnowledge ),	 0x0EFA, 0x530, 1070971, 1071009 ),
				new TypeTileButtonInfo( typeof( PigmentsOfIslesDread ),		 0x0EFF, 1070933, 1071011 )
			},
			// ToT Two Rewards
			new TypeTileButtonInfo[] {
				new TypeTileButtonInfo( typeof( SwordsOfProsperity ),	 0x27A9, 1070963, 1071002 ),
				new TypeTileButtonInfo( typeof( SwordOfTheStampede ),	 0x27A2, 1070964, 1070978 ),
				new TypeTileButtonInfo( typeof( WindsEdge ),			 0x27A3, 1070965, 1071003 ),
				new TypeTileButtonInfo( typeof( DarkenedSky ),			 0x27AD, 1070966, 1071004 ),
				new TypeTileButtonInfo( typeof( TheHorselord ),			 0x27A5, 1070967, 1071005 ),
				new TypeTileButtonInfo( typeof( RuneBeetleCarapace ),	 0x277D, 1070968, 1071006 ),
				new TypeTileButtonInfo( typeof( KasaOfTheRajin ),		 0x2798, 1070969, 1071007 ),
				new TypeTileButtonInfo( typeof( Stormgrip ),			 0x2792, 1070970, 1071008 ),
				new TypeTileButtonInfo( typeof( TomeOfLostKnowledge ),	 0x0EFA, 0x530, 1070971, 1071009 ),
				new TypeTileButtonInfo( typeof( PigmentsOfIslesDread ),		 0x0EFF, 1070933, 1071011 )
			},
			// ToT Three Rewards
			new TypeTileButtonInfo[] {
				new TypeTileButtonInfo( typeof( SwordsOfProsperity ),	 0x27A9, 1070963, 1071002 ),
				new TypeTileButtonInfo( typeof( SwordOfTheStampede ),	 0x27A2, 1070964, 1070978 ),
				new TypeTileButtonInfo( typeof( WindsEdge ),			 0x27A3, 1070965, 1071003 ),
				new TypeTileButtonInfo( typeof( DarkenedSky ),			 0x27AD, 1070966, 1071004 ),
				new TypeTileButtonInfo( typeof( TheHorselord ),			 0x27A5, 1070967, 1071005 ),
				new TypeTileButtonInfo( typeof( RuneBeetleCarapace ),	 0x277D, 1070968, 1071006 ),
				new TypeTileButtonInfo( typeof( KasaOfTheRajin ),		 0x2798, 1070969, 1071007 ),
				new TypeTileButtonInfo( typeof( Stormgrip ),			 0x2792, 1070970, 1071008 ),
				new TypeTileButtonInfo( typeof( TomeOfLostKnowledge ),	 0x0EFA, 0x530, 1070971, 1071009 )
			}
		};
		#endregion

		public static TypeTileButtonInfo[][] NormalRewards
		{
			get { return m_NormalRewards; }
		}

		#region ToT Pigment Rewards Table
		private static PigmentsTileButtonInfo[][] m_PigmentRewards = new PigmentsTileButtonInfo[][]
		{
			// ToT One Pigment Rewards
			new PigmentsTileButtonInfo[] {
				new PigmentsTileButtonInfo( PigmentType.ParagonGold ),
				new PigmentsTileButtonInfo( PigmentType.VioletCouragePurple ),
				new PigmentsTileButtonInfo( PigmentType.InvulnerabilityBlue ),
				new PigmentsTileButtonInfo( PigmentType.LunaWhite ),
				new PigmentsTileButtonInfo( PigmentType.DryadGreen ),
				new PigmentsTileButtonInfo( PigmentType.ShadowDancerBlack ),
				new PigmentsTileButtonInfo( PigmentType.BerserkerRed ),
				new PigmentsTileButtonInfo( PigmentType.NoxGreen ),
				new PigmentsTileButtonInfo( PigmentType.RumRed ),
				new PigmentsTileButtonInfo( PigmentType.FireOrange )
			},
			// ToT Two Pigment Rewards
			new PigmentsTileButtonInfo[] {
				new PigmentsTileButtonInfo( PigmentType.FadedCoal ),
				new PigmentsTileButtonInfo( PigmentType.Coal ),
				new PigmentsTileButtonInfo( PigmentType.FadedGold ),
				new PigmentsTileButtonInfo( PigmentType.StormBronze ),
				new PigmentsTileButtonInfo( PigmentType.Rose ),
				new PigmentsTileButtonInfo( PigmentType.MidnightCoal ),
				new PigmentsTileButtonInfo( PigmentType.FadedBronze ),
				new PigmentsTileButtonInfo( PigmentType.FadedRose ),
				new PigmentsTileButtonInfo( PigmentType.DeepRose )
			},
			// ToT Three Pigment Rewards
			new PigmentsTileButtonInfo[] {
				new PigmentsTileButtonInfo( PigmentType.ParagonGold ),
				new PigmentsTileButtonInfo( PigmentType.VioletCouragePurple ),
				new PigmentsTileButtonInfo( PigmentType.InvulnerabilityBlue ),
				new PigmentsTileButtonInfo( PigmentType.LunaWhite ),
				new PigmentsTileButtonInfo( PigmentType.DryadGreen ),
				new PigmentsTileButtonInfo( PigmentType.ShadowDancerBlack ),
				new PigmentsTileButtonInfo( PigmentType.BerserkerRed ),
				new PigmentsTileButtonInfo( PigmentType.NoxGreen ),
				new PigmentsTileButtonInfo( PigmentType.RumRed ),
				new PigmentsTileButtonInfo( PigmentType.FireOrange )
			}
		};
		#endregion

		public static PigmentsTileButtonInfo[][] PigmentRewards
		{
			get { return m_PigmentRewards; }
		}

		private Mobile m_Collector;

		public ToTRedeemGump( Mobile collector, bool pigments ) : base( pigments ? 1070986 : 1070985, pigments ? (ImageTileButtonInfo[])m_PigmentRewards[(int)TreasuresOfTokuno.RewardEra-1] : (ImageTileButtonInfo[])m_NormalRewards[(int)TreasuresOfTokuno.RewardEra-1] )
		{
			m_Collector = collector;
		}

		public override void HandleButtonResponse( NetState sender, int adjustedButton, ImageTileButtonInfo buttonInfo )
		{
			PlayerMobile pm = sender.Mobile as PlayerMobile;

			if( pm == null || !pm.InRange( m_Collector.Location, 7 ) || !(pm.ToTItemsTurnedIn >= TreasuresOfTokuno.ItemsPerReward) )
				return;

			bool pigments = (buttonInfo is PigmentsTileButtonInfo);

			Item item = null;

			if( pigments )
			{
				PigmentsTileButtonInfo p = buttonInfo as PigmentsTileButtonInfo;

				item = new PigmentsOfIslesDread( p.Pigment );
			}
			else
			{
				TypeTileButtonInfo t = buttonInfo as TypeTileButtonInfo;

				if( t.Type == typeof( PigmentsOfIslesDread ) )	//Special case of course.
				{
					pm.CloseGump( typeof( ToTTurnInGump ) );	//Sanity
					pm.CloseGump( typeof( ToTRedeemGump ) );

					pm.SendGump( new ToTRedeemGump( m_Collector, true ) );

					return;
				}

				try
				{
					item = (Item)Activator.CreateInstance( t.Type );
				}
				catch { }
			}

			if( item == null )
				return; //Sanity

			if( pm.AddToBackpack( item ) )
			{
				pm.ToTItemsTurnedIn -= TreasuresOfTokuno.ItemsPerReward;
				m_Collector.SayTo( pm, 1070984, (item.Name == null || item.Name.Length <= 0)? String.Format( "#{0}", item.LabelNumber ) : item.Name ); // You have earned the gratitude of the Empire. I have placed the ~1_OBJTYPE~ in your backpack.
			}
			else
			{
				item.Delete();
				m_Collector.SayTo( pm, 500722 ); // You don't have enough room in your backpack!
				m_Collector.SayTo( pm, 1070982 ); // When you wish to choose your reward, you have but to approach me again.
			}
		}

		public override void HandleCancel( NetState sender )
		{
			PlayerMobile pm = sender.Mobile as PlayerMobile;

			if( pm == null || !pm.InRange( m_Collector.Location, 7 ) )
				return;

			if( pm.ToTItemsTurnedIn == 0 )
				m_Collector.SayTo( pm, 1071013 ); // Bring me 10 of the lost treasures of IslesDread and I will reward you with a valuable item.
			else if( pm.ToTItemsTurnedIn < TreasuresOfTokuno.ItemsPerReward )	//This and above case should ALWAYS be FALSE with this gump, jsut a sanity check
				m_Collector.SayTo( pm, 1070981, String.Format( "{0}\t{1}", pm.ToTItemsTurnedIn, TreasuresOfTokuno.ItemsPerReward ) ); // You have turned in ~1_COUNT~ minor artifacts. Turn in ~2_NUM~ to receive a reward.
			else
				m_Collector.SayTo( pm, 1070982 ); // When you wish to choose your reward, you have but to approach me again.

		}
	}
}

/* Notes

Pigments of tokuno do NOT check for if item is already hued 0;  APPARENTLY he still accepts it if it's < 10 charges.

Chest of Heirlooms don't show if unlocked.

Chest of heirlooms, locked, HARD to pick at 100 lock picking but not impossible.  had 95 health to 0, cause it's trapped >< (explosion i think)
*/

// using System;// using System.Collections.Generic;

namespace Server.Misc
{
	public class TreasuresOfTokunoPersistance : Item
	{
		private static TreasuresOfTokunoPersistance m_Instance;

		public static TreasuresOfTokunoPersistance Instance{ get{ return m_Instance; } }

		public override string DefaultName
		{
			get { return "TreasuresOfTokuno Persistance - Internal"; }
		}

		public static void Initialize()
		{
			if ( m_Instance == null )
				new TreasuresOfTokunoPersistance();
		}

		public TreasuresOfTokunoPersistance() : base( 1 )
		{
			Movable = false;

			if ( m_Instance == null || m_Instance.Deleted )
				m_Instance = this;
			else
				base.Delete();
		}

		public TreasuresOfTokunoPersistance( Serial serial ) : base( serial )
		{
			m_Instance = this;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.WriteEncodedInt( (int)TreasuresOfTokuno.RewardEra );
			writer.WriteEncodedInt( (int)TreasuresOfTokuno.DropEra );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					TreasuresOfTokuno.RewardEra = (TreasuresOfTokunoEra)reader.ReadEncodedInt();
					TreasuresOfTokuno.DropEra = (TreasuresOfTokunoEra)reader.ReadEncodedInt();

					break;
				}
			}
		}

		public override void Delete()
		{
		}
	}
}// using System;

namespace Server.Factions
{
	public class Moon : Town
	{
		public Moon()
		{
			Definition =
				new TownDefinition(
					1,
					0x186A,
					"Moon",
					"Moon",
					new TextDefinition( 1011434, "Moon" ),
					new TextDefinition( 1011562, "TOWN STONE FOR Moon" ),
					new TextDefinition( 1041035, "The Faction Sigil Monolith of Moon" ),
					new TextDefinition( 1041405, "The Faction Town Sigil Monolith of Moon" ),
					new TextDefinition( 1041414, "Faction Town Stone of Moon" ),
					new TextDefinition( 1041396, "Faction Town Sigil of Moon" ),
					new TextDefinition( 1041387, "Corrupted Faction Town Sigil of Moon" ),
					new Point3D( 1914, 2717, 20 ),
					new Point3D( 1909, 2720, 20 ) );
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class TrueBritannians : Faction
	{
		private static Faction m_Instance;

		public static Faction Instance{ get{ return m_Instance; } }

		public TrueBritannians()
		{
			m_Instance = this;

			Definition =
				new FactionDefinition(
					2,
					1254, // dark purple
					2125, // gold
					2214, // join stone : gold
					2125, // broadcast : gold
					0x76, 0x3EB2, // war horse
					"True Britannians", "true", "TB",
					new TextDefinition( 1011536, "LORD BRITISH" ),
					new TextDefinition( 1060771, "True Britannians faction" ),
					new TextDefinition( 1011423, "<center>TRUE BRITANNIANS</center>" ),
					new TextDefinition( 1011450,
						"True Britannians are loyal to the throne of Lord British. They refuse " +
						"to give up their homelands to the vile Minax, and detest the Shadowlords " +
						"for their evil ways. In addition, the Council of Mages threatens the " +
						"existence of their ruler, and as such they have armed themselves, and " +
						"prepare for war with all." ),
					new TextDefinition( 1011454, "This city is controlled by Lord British." ),
					new TextDefinition( 1042254, "This sigil has been corrupted by the True Britannians" ),
					new TextDefinition( 1041045, "The faction signup stone for the True Britannians" ),
					new TextDefinition( 1041383, "The Faction Stone of the True Britannians" ),
					new TextDefinition( 1011465, ": True Britannians" ),
					new TextDefinition( 1005181, "Followers of Lord British will now be ignored." ),
					new TextDefinition( 1005182, "Followers of Lord British will now be warned of their impending doom." ),
					new TextDefinition( 1005183, "Followers of Lord British will now be attacked on sight." ),
					new StrongholdDefinition(
						new Rectangle2D[]
						{
							new Rectangle2D( 5192, 3934, 1, 1 )
						},
						new Point3D( 1419, 1622, 20 ),
						new Point3D( 1330, 1621, 50 ),
						new Point3D[]
						{
							new Point3D( 1328, 1627, 50 ),
							new Point3D( 1328, 1621, 50 ),
							new Point3D( 1334, 1627, 50 ),
							new Point3D( 1334, 1621, 50 ),
							new Point3D( 1340, 1627, 50 ),
							new Point3D( 1340, 1621, 50 ),
							new Point3D( 1345, 1621, 50 ),
							new Point3D( 1345, 1627, 50 )
						} ),
					new RankDefinition[]
					{
						new RankDefinition( 10, 991, 8, new TextDefinition( 1060794, "Knight of the Codex" ) ),
						new RankDefinition(  9, 950, 7, new TextDefinition( 1060793, "Knight of Virtue" ) ),
						new RankDefinition(  8, 900, 6, new TextDefinition( 1060792, "Crusader" ) ),
						new RankDefinition(  7, 800, 6, new TextDefinition( 1060792, "Crusader" ) ),
						new RankDefinition(  6, 700, 5, new TextDefinition( 1060791, "Sentinel" ) ),
						new RankDefinition(  5, 600, 5, new TextDefinition( 1060791, "Sentinel" ) ),
						new RankDefinition(  4, 500, 5, new TextDefinition( 1060791, "Sentinel" ) ),
						new RankDefinition(  3, 400, 4, new TextDefinition( 1060790, "Defender" ) ),
						new RankDefinition(  2, 200, 4, new TextDefinition( 1060790, "Defender" ) ),
						new RankDefinition(  1,   0, 4, new TextDefinition( 1060790, "Defender" ) )
					},
					new GuardDefinition[]
					{
						new GuardDefinition( typeof( FactionHenchman ),		0x1403, 5000, 1000, 10,		new TextDefinition( 1011526, "HENCHMAN" ),		new TextDefinition( 1011510, "Hire Henchman" ) ),
						new GuardDefinition( typeof( FactionMercenary ),	0x0F62, 6000, 2000, 10,		new TextDefinition( 1011527, "MERCENARY" ),		new TextDefinition( 1011511, "Hire Mercenary" ) ),
						new GuardDefinition( typeof( FactionKnight ),		0x0F4D, 7000, 3000, 10,		new TextDefinition( 1011528, "KNIGHT" ),		new TextDefinition( 1011497, "Hire Knight" ) ),
						new GuardDefinition( typeof( FactionPaladin ),		0x143F, 8000, 4000, 10,		new TextDefinition( 1011529, "PALADIN" ),		new TextDefinition( 1011498, "Hire Paladin" ) ),
					}
				);
		}
	}
}
// using System;// using Server;// using Server.Ethics;// using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an evil corpse" )]
	public class UnholyFamiliar : BaseCreature
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }

		[Constructable]
		public UnholyFamiliar()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dark wolf";
			Body = 225;
			Hue = 1109;
			BaseSoundID = 0xE5;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 57.6, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 80.0 );

			Fame = 2500;
			Karma = 2500;

			VirtualArmor = 22;

			Tamable = false;
			ControlSlots = 1;
		}

		public override int Meat { get { return 1; } }
		public override int Hides { get { return 7; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }
		public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

		public UnholyFamiliar( Serial serial )
			: base( serial )
		{
		}

		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Evil.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Evil.Definition.Adjunct.String );

			return base.ApplyNameSuffix( suffix );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Items;

namespace Server.Ethics.Evil
{
	public sealed class UnholyItem : Power
	{
		public UnholyItem()
		{
			m_Definition = new PowerDefinition(
					5,
					"Unholy Item",
					"Vidda K'balc",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			from.Mobile.BeginTarget( 12, false, Targeting.TargetFlags.None, new TargetStateCallback( Power_OnTarget ), from );
			from.Mobile.SendMessage( "Which item do you wish to imbue?" );
		}

		private void Power_OnTarget( Mobile fromMobile, object obj, object state )
		{
			Player from = state as Player;

			Item item = obj as Item;

			if ( item == null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
				return;
			}

			if ( item.Parent != from.Mobile )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may only imbue items you are wearing." );
				return;
			}

			if ( ( item.SavedFlags & 0x300 ) != 0 )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "That has already beem imbued." );
				return;
			}

			bool canImbue = ( item is Spellbook || item is BaseClothing || item is BaseArmor || item is BaseWeapon ) && ( item.Name == null );

			if ( canImbue )
			{
				if ( !CheckInvoke( from ) )
					return;

				item.Hue = Ethic.Evil.Definition.PrimaryHue;
				item.SavedFlags |= 0x200;

				from.Mobile.FixedEffect( 0x375A, 10, 20 );
				from.Mobile.PlaySound( 0x209 );

				FinishInvoke( from );
			}
			else
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You may not imbue that." );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Evil
{
	public sealed class UnholySense : Power
	{
		public UnholySense()
		{
			m_Definition = new PowerDefinition(
					0,
					"Unholy Sense",
					"Drewrok Velgo",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			Ethic opposition = Ethic.Hero;

			int enemyCount = 0;

			int maxRange = 18 + from.Power;

			Player primary = null;

			foreach ( Player pl in opposition.Players )
			{
				Mobile mob = pl.Mobile;

				if ( mob == null || mob.Map != from.Mobile.Map || !mob.Alive )
					continue;

				if ( !mob.InRange( from.Mobile, Math.Max( 18, maxRange - pl.Power ) ) )
					continue;

				if ( primary == null || pl.Power > primary.Power )
					primary = pl;

				++enemyCount;
			}

			StringBuilder sb = new StringBuilder();

			sb.Append( "You sense " );
			sb.Append( enemyCount == 0 ? "no" : enemyCount.ToString() );
			sb.Append( enemyCount == 1 ? " enemy" : " enemies" );

			if ( primary != null )
			{
				sb.Append( ", and a strong presense" );

				switch ( from.Mobile.GetDirectionTo( primary.Mobile ) )
				{
					case Direction.West:
						sb.Append( " to the west." );
						break;
					case Direction.East:
						sb.Append( " to the east." );
						break;
					case Direction.North:
						sb.Append( " to the north." );
						break;
					case Direction.South:
						sb.Append( " to the south." );
						break;

					case Direction.Up:
						sb.Append( " to the north-west." );
						break;
					case Direction.Down:
						sb.Append( " to the south-east." );
						break;
					case Direction.Left:
						sb.Append( " to the south-west." );
						break;
					case Direction.Right:
						sb.Append( " to the north-east." );
						break;
				}
			}
			else
			{
				sb.Append( '.' );
			}

			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x59, false, sb.ToString() );

			FinishInvoke( from );
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Evil
{
	public sealed class UnholyShield : Power
	{
		public UnholyShield()
		{
			m_Definition = new PowerDefinition(
					20,
					"Unholy Shield",
					"Velgo K'blac",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			if ( from.IsShielded )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are already under the protection of an unholy shield." );
				return;
			}

			from.BeginShield();

			from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You are now under the protection of an unholy shield." );

			FinishInvoke( from );
		}
	}
}// using System;// using Server;// using Server.Mobiles;// using Server.Ethics;

namespace Server.Mobiles
{
	[CorpseName( "an unholy corpse" )]
	public class UnholySteed : BaseMount
	{
		public override bool IsDispellable { get { return false; } }
		public override bool IsBondable { get { return false; } }

		public override bool HasBreath { get { return true; } }
		public override bool CanBreath { get { return true; } }

		[Constructable]
		public UnholySteed()
			: base( "a dark steed", 0x74, 0x3EA7, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 496, 525 );
			SetDex( 86, 105 );
			SetInt( 86, 125 );

			SetHits( 298, 315 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 40 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 80.5, 92.5 );

			Fame = 14000;
			Karma = -14000;

			VirtualArmor = 60;

			Tamable = false;
			ControlSlots = 1;
		}

		public override FoodType FavoriteFood { get { return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public UnholySteed( Serial serial )
			: base( serial )
		{
		}

		public override string ApplyNameSuffix( string suffix )
		{
			if ( suffix.Length == 0 )
				suffix = Ethic.Evil.Definition.Adjunct.String;
			else
				suffix = String.Concat( suffix, " ", Ethic.Evil.Definition.Adjunct.String );

			return base.ApplyNameSuffix( suffix );
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( Ethic.Find( from ) != Ethic.Evil )
				from.SendMessage( "You may not ride this steed." );
			else
				base.OnDoubleClick( from );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;// using Server.Mobiles;

namespace Server.Ethics.Evil
{
	public sealed class UnholySteed : Power
	{
		public UnholySteed()
		{
			m_Definition = new PowerDefinition(
					30,
					"Unholy Steed",
					"Trubechs Yeliab",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
			if ( from.Steed != null && from.Steed.Deleted )
				from.Steed = null;

			if ( from.Steed != null )
			{
				from.Mobile.LocalOverheadMessage( Server.Network.MessageType.Regular, 0x3B2, false, "You already have an unholy steed." );
				return;
			}

			if ( ( from.Mobile.Followers + 1 ) > from.Mobile.FollowersMax )
			{
				from.Mobile.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return;
			}

			Mobiles.UnholySteed steed = new Mobiles.UnholySteed();

			if ( Mobiles.BaseCreature.Summon( steed, from.Mobile, from.Mobile.Location, 0x217, TimeSpan.FromHours( 1.0 ) ) )
			{
				from.Steed = steed;

				FinishInvoke( from );
			}
		}
	}
}// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Evil
{
	public sealed class UnholyWord : Power
	{
		public UnholyWord()
		{
			m_Definition = new PowerDefinition(
					100,
					"Unholy Word",
					"Velgo Oostrac",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using System.Collections;// using Server;// using Server.Items;// using Server.Gumps;// using Server.Mobiles;// using Server.Targeting;// using Server.Engines.CannedEvil;

namespace Server
{
	public class ValorVirtue
	{
		private static TimeSpan LossDelay = TimeSpan.FromDays( 7.0 );
		private const int LossAmount = 250;

		public static void Initialize()
		{
			VirtueGump.Register( 112, new OnVirtueUsed( OnVirtueUsed ) );
		}

		public static void OnVirtueUsed( Mobile from )
		{
			if( from.Alive )
			{
				from.SendLocalizedMessage( 1054034 ); // Target the Champion Idol of the Champion you wish to challenge!.
				from.Target = new InternalTarget();
			}
		}

		public static void CheckAtrophy( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if( pm == null )
				return;

			try
			{
				if( (pm.LastValorLoss + LossDelay) < DateTime.Now )
				{
					if( VirtueHelper.Atrophy( from, VirtueName.Valor, LossAmount ) )
						from.SendLocalizedMessage( 1054040 ); // You have lost some Valor.

					pm.LastValorLoss = DateTime.Now;
				}
			}
			catch
			{
			}
		}

		public static void Valor( Mobile from, object targ )
		{
			IdolOfTheChampion idol = targ as IdolOfTheChampion;

			if( idol == null || idol.Deleted || idol.Spawn == null || idol.Spawn.Deleted )
				from.SendLocalizedMessage( 1054035 ); // You must target a Champion Idol to challenge the Champion's spawn!
			else if( from.Hidden )
				from.SendLocalizedMessage( 1052015 ); // You cannot do that while hidden.
			else if( idol.Spawn.HasBeenAdvanced )
				from.SendLocalizedMessage( 1054038 ); // The Champion of this region has already been challenged!
			else
			{
				VirtueLevel vl = VirtueHelper.GetLevel( from, VirtueName.Valor );
				if( idol.Spawn.Active )
				{
					if( idol.Spawn.Champion != null )	//TODO: Message?
						return;

					int needed, consumed;
					switch( idol.Spawn.GetSubLevel() )
					{
						case 0:
						{
							needed = consumed = 2500;
							break;
						}
						case 1:
						{
							needed = consumed = 5000;
							break;
						}
						case 2:
						{
							needed = 10000;
							consumed = 7500;
							break;
						}
						default:
						{
							needed = 20000;
							consumed = 10000;
							break;
						}
					}

					if( from.Virtues.GetValue( (int)VirtueName.Valor ) >= needed )
					{
						VirtueHelper.Atrophy( from, VirtueName.Valor, consumed );
						from.SendLocalizedMessage( 1054037 ); // Your challenge is heard by the Champion of this region! Beware its wrath!
						idol.Spawn.HasBeenAdvanced = true;
						idol.Spawn.AdvanceLevel();
					}
					else
						from.SendLocalizedMessage( 1054039 ); // The Champion of this region ignores your challenge. You must further prove your valor.
				}
				else
				{
					if( vl == VirtueLevel.Knight )
					{
						VirtueHelper.Atrophy( from, VirtueName.Valor, 11000 );
						from.SendLocalizedMessage( 1054037 ); // Your challenge is heard by the Champion of this region! Beware its wrath!
						idol.Spawn.EndRestart();
						idol.Spawn.HasBeenAdvanced = true;
					}
					else
					{
						from.SendLocalizedMessage( 1054036 ); // You must be a Knight of Valor to summon the champion's spawn in this manner!
					}
				}
			}

		}

		private class InternalTarget : Target
		{
			public InternalTarget()	: base( 14, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				Valor( from, targeted );
			}
		}
	}
}
// using System;// using Server;

namespace Server.Factions
{
	public class VendorDefinition
	{
		private Type m_Type;

		private int m_Price;
		private int m_Upkeep;
		private int m_Maximum;

		private int m_ItemID;

		private TextDefinition m_Header;
		private TextDefinition m_Label;

		public Type Type{ get{ return m_Type; } }

		public int Price{ get{ return m_Price; } }
		public int Upkeep{ get{ return m_Upkeep; } }
		public int Maximum{ get{ return m_Maximum; } }
		public int ItemID{ get{ return m_ItemID; } }

		public TextDefinition Header{ get{ return m_Header; } }
		public TextDefinition Label{ get{ return m_Label; } }

		public VendorDefinition( Type type, int itemID, int price, int upkeep, int maximum, TextDefinition header, TextDefinition label )
		{
			m_Type = type;

			m_Price = price;
			m_Upkeep = upkeep;
			m_Maximum = maximum;
			m_ItemID = itemID;

			m_Header = header;
			m_Label = label;
		}

		private static VendorDefinition[] m_Definitions = new VendorDefinition[]
			{
				new VendorDefinition( typeof( FactionBottleVendor ), 0xF0E,
					5000,
					1000,
					10,
					new TextDefinition( 1011549, "POTION BOTTLE VENDOR" ),
					new TextDefinition( 1011544, "Buy Potion Bottle Vendor" )
				),
				new VendorDefinition( typeof( FactionBoardVendor ), 0x1BD7,
					3000,
					500,
					10,
					new TextDefinition( 1011552, "WOOD VENDOR" ),
					new TextDefinition( 1011545, "Buy Wooden Board Vendor" )
				),
				new VendorDefinition( typeof( FactionOreVendor ), 0x19B8,
					3000,
					500,
					10,
					new TextDefinition( 1011553, "IRON ORE VENDOR" ),
					new TextDefinition( 1011546, "Buy Iron Ore Vendor" )
				),
				new VendorDefinition( typeof( FactionReagentVendor ), 0xF86,
					5000,
					1000,
					10,
					new TextDefinition( 1011554, "REAGENT VENDOR" ),
					new TextDefinition( 1011547, "Buy Reagent Vendor" )
				),
				new VendorDefinition( typeof( FactionHorseVendor ), 0x20DD,
					5000,
					1000,
					1,
					new TextDefinition( 1011556, "HORSE BREEDER" ),
					new TextDefinition( 1011555, "Buy Horse Breeder" )
				)
			};

		public static VendorDefinition[] Definitions{ get{ return m_Definitions; } }
	}
}
// using System;// using Server;// using System.Collections.Generic;

namespace Server.Factions
{
	public class VendorList
	{
		private VendorDefinition m_Definition;
		private List<BaseFactionVendor> m_Vendors;

		public VendorDefinition Definition{ get{ return m_Definition; } }
		public List<BaseFactionVendor> Vendors { get { return m_Vendors; } }

		public BaseFactionVendor Construct( Town town, Faction faction )
		{
			try{ return Activator.CreateInstance( m_Definition.Type, new object[]{ town, faction } ) as BaseFactionVendor; }
			catch{ return null; }
		}

		public VendorList( VendorDefinition definition )
		{
			m_Definition = definition;
			m_Vendors = new List<BaseFactionVendor>();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class Luna : Town
	{
		public Luna()
		{
			Definition =
				new TownDefinition(
					5,
					0x186E,
					"Luna",
					"Luna",
					new TextDefinition( 1016413, "Luna" ),
					new TextDefinition( 1011566, "TOWN STONE FOR Luna" ),
					new TextDefinition( 1041039, "The Faction Sigil Monolith of Luna" ),
					new TextDefinition( 1041409, "The Faction Town Sigil Monolith of Luna" ),
					new TextDefinition( 1041418, "Faction Town Stone of Luna" ),
					new TextDefinition( 1041400, "Faction Town Sigil of Luna" ),
					new TextDefinition( 1041391, "Corrupted Faction Town Sigil of Luna" ),
					new Point3D( 2982, 818, 0 ),
					new Point3D( 2985, 821, 0 ) );
		}
	}
}
// using System;// using System.Collections.Generic;// using System.Text;

namespace Server.Ethics.Evil
{
	public sealed class VileBlade : Power
	{
		public VileBlade()
		{
			m_Definition = new PowerDefinition(
					10,
					"Vile Blade",
					"Velgo Reyam",
					""
				);
		}

		public override void BeginInvoke( Player from )
		{
		}
	}
}// using System;// using System.Collections;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server
{
	public delegate void OnVirtueUsed( Mobile from );

	public class VirtueGump : Gump
	{
		private static Hashtable m_Callbacks = new Hashtable();

		public static void Initialize()
		{
			// DISABLED
		}

		public static void Register( int gumpID, OnVirtueUsed callback )
		{
			m_Callbacks[gumpID] = callback;
		}

		private static void EventSink_VirtueItemRequest( VirtueItemRequestEventArgs e )
		{
			if ( e.Beholder != e.Beheld )
				return;

			e.Beholder.CloseGump( typeof( VirtueGump ) );

			if ( e.Beholder.Kills >= 5 )
			{
				e.Beholder.SendLocalizedMessage( 1049609 ); // Murderers cannot invoke this virtue.
				return;
			}

			OnVirtueUsed callback = (OnVirtueUsed)m_Callbacks[e.GumpID];

			if ( callback != null )
				callback( e.Beholder );
			else
				e.Beholder.SendLocalizedMessage( 1052066 ); // That virtue is not active yet.
		}

		private static void EventSink_VirtueMacroRequest( VirtueMacroRequestEventArgs e )
		{
			int virtueID = 0;

			switch ( e.VirtueID )
			{
				case 0:	// Honor
					virtueID = 107;	break;
				case 1:	// Sacrifice
					virtueID = 110; break;
				case 2:	// Valor;
					virtueID = 112;	break;
			}

			EventSink_VirtueItemRequest( new VirtueItemRequestEventArgs( e.Mobile, e.Mobile, virtueID ) );
		}

		private static void EventSink_VirtueGumpRequest( VirtueGumpRequestEventArgs e )
		{
			Mobile beholder = e.Beholder;
			Mobile beheld = e.Beheld;

			if ( beholder == beheld && beholder.Kills >= 5 )
			{
				beholder.SendLocalizedMessage( 1049609 ); // Murderers cannot invoke this virtue.
			}
			else if ( beholder.Map == beheld.Map && beholder.InRange( beheld, 12 ) )
			{
				beholder.CloseGump( typeof( VirtueGump ) );
				beholder.SendGump( new VirtueGump( beholder, beheld ) );
			}
		}

		private Mobile m_Beholder, m_Beheld;

		public VirtueGump( Mobile beholder, Mobile beheld ) : base( 0, 0 )
		{
			m_Beholder = beholder;
			m_Beheld = beheld;

			Serial = beheld.Serial;

			AddPage( 0 );

			AddImage( 30, 40, 104 );

			AddPage( 1 );

			Add( new InternalEntry( 61, 71, 108, GetHueFor( 0 ) ) ); // Humility
			Add( new InternalEntry( 123, 46, 112, GetHueFor( 4 ) ) ); // Valor
			Add( new InternalEntry( 187, 70, 107, GetHueFor( 5 ) ) ); // Honor
			Add( new InternalEntry( 35, 135, 110, GetHueFor( 1 ) ) ); // Sacrifice
			Add( new InternalEntry( 211, 133, 105, GetHueFor( 2 ) ) ); // Compassion
			Add( new InternalEntry( 61, 195, 111, GetHueFor( 3 ) ) ); // Spiritulaity
			Add( new InternalEntry( 186, 195, 109, GetHueFor( 6 ) ) ); // Justice
			Add( new InternalEntry( 121, 221, 106, GetHueFor( 7 ) ) ); // Honesty

			if ( m_Beholder == m_Beheld )
			{
				AddButton( 57, 269, 2027, 2027, 1, GumpButtonType.Reply, 0 );
				AddButton( 186, 269, 2071, 2071, 2, GumpButtonType.Reply, 0 );
			}
		}

		private static int[] m_Table = new int[24]
			{
				0x0481, 0x0963, 0x0965,
				0x060A, 0x060F, 0x002A,
				0x08A4, 0x08A7, 0x0034,
				0x0965, 0x08FD, 0x0480,
				0x00EA, 0x0845, 0x0020,
				0x0011, 0x0269, 0x013D,
				0x08A1, 0x08A3, 0x0042,
				0x0543, 0x0547, 0x0061
			};

		private int GetHueFor( int index )
		{
			if ( m_Beheld.Virtues.GetValue( index ) == 0 )
				return 2402;

			int value = m_Beheld.Virtues.GetValue( index );

			if ( value < 4000 )
				return 2402;

			if( value >= 30000 )
				value = 20000;	//Sanity


			int vl;

			if( value < 10000 )
				vl = 0;
			else if( value >= 20000 && index == 5)
 				vl = 2;
			else if( value >= 21000 && index != 1)
				vl = 2;
			else if( value >= 22000 && index == 1)
				vl = 2;
			else
				vl = 1;


			return m_Table[(index * 3) + (int) vl];
		}

		private class InternalEntry : GumpImage
		{
			public InternalEntry( int x, int y, int gumpID, int hue ) : base( x, y, gumpID, hue )
			{
			}

			public override string Compile()
			{
				return String.Format( "{{ gumppic {0} {1} {2} hue={3} class=VirtueGumpItem }}", X, Y, GumpID, Hue );
			}

			private static byte[] m_Class = Gump.StringToBuffer( " class=VirtueGumpItem" );

			public override void AppendTo( IGumpWriter disp )
			{
				base.AppendTo( disp );

				disp.AppendLayout( m_Class );
			}
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 1 && m_Beholder == m_Beheld )
				m_Beholder.SendGump( new VirtueStatusGump( m_Beholder ) );
		}
	}
}
// using System;

namespace Server
{
	public enum VirtueLevel
	{
		None,
		Seeker,
		Follower,
		Knight
	}

	public enum VirtueName
	{
		Humility,
		Sacrifice,
		Compassion,
		Spirituality,
		Valor,
		Honor,
		Justice,
		Honesty
	}

	public class VirtueHelper
	{
		public static bool HasAny( Mobile from, VirtueName virtue )
		{
			return ( from.Virtues.GetValue( (int)virtue ) > 0 );
		}

		public static bool IsHighestPath( Mobile from, VirtueName virtue )
		{
			return ( from.Virtues.GetValue( (int)virtue ) >= GetMaxAmount( virtue ) );
		}

		public static VirtueLevel GetLevel( Mobile from, VirtueName virtue )
		{
			int v = from.Virtues.GetValue( (int)virtue );
			int vl;
			int vmax = GetMaxAmount( virtue );

			if ( v < 4000 )
				vl = 0;
			else if ( v >= vmax)
				vl = 3;
			else
				vl = ( v + 9999 ) / 10000;

			return (VirtueLevel)vl;
		}

		public static int GetMaxAmount( VirtueName virtue )
		{
			if( virtue == VirtueName.Honor )
				return 20000;

			if( virtue == VirtueName.Sacrifice )
				return 22000;

			return 21000;
		}

		public static bool Award( Mobile from, VirtueName virtue, int amount, ref bool gainedPath )
		{
			int current = from.Virtues.GetValue( (int)virtue );

			int maxAmount = GetMaxAmount( virtue );

			if ( current >= maxAmount )
				return false;

			if( (current + amount) >= maxAmount )
				amount = maxAmount - current;

			VirtueLevel oldLevel = GetLevel( from, virtue );

			from.Virtues.SetValue( (int)virtue, current + amount );

			gainedPath = ( GetLevel( from, virtue ) != oldLevel );

			return true;
		}

		public static bool Atrophy( Mobile from, VirtueName virtue )
		{
			return Atrophy( from, virtue, 1 );
		}
		public static bool Atrophy( Mobile from, VirtueName virtue, int amount )
		{
			int current = from.Virtues.GetValue( (int)virtue );

			if( (current - amount) >= 0 )
				from.Virtues.SetValue( (int)virtue, current - amount );
			else
				from.Virtues.SetValue( (int)virtue, 0 );

			return ( current > 0 );
		}

		public static bool IsSeeker( Mobile from, VirtueName virtue )
		{
			return ( GetLevel( from, virtue ) >= VirtueLevel.Seeker );
		}

		public static bool IsFollower( Mobile from, VirtueName virtue )
		{
			return ( GetLevel( from, virtue ) >= VirtueLevel.Follower );
		}

		public static bool IsKnight( Mobile from, VirtueName virtue )
		{
			return ( GetLevel( from, virtue ) >= VirtueLevel.Knight );
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server
{
	public class VirtueInfoGump : Gump
	{
		private Mobile m_Beholder;
		private int m_Desc;
		private string m_Page;
		private VirtueName m_Virtue;

		public VirtueInfoGump( Mobile beholder, VirtueName virtue, int description ) : this( beholder, virtue, description, null )
		{
		}

		public VirtueInfoGump( Mobile beholder, VirtueName virtue, int description, string webPage ) : base( 0, 0 )
		{
			m_Beholder = beholder;
			m_Virtue = virtue;
			m_Desc = description;
			m_Page = webPage;

			int value = beholder.Virtues.GetValue( (int)virtue );

			AddPage( 0 );

			AddImage( 30, 40, 2080 );
			AddImage( 47, 77, 2081 );
			AddImage( 47, 147, 2081 );
			AddImage( 47, 217, 2081 );
			AddImage( 47, 267, 2083 );
			AddImage( 70, 213, 2091 );

			AddPage( 1 );

			int maxValue = VirtueHelper.GetMaxAmount( m_Virtue );

			int valueDesc;
			int dots;

			if( value < 4000 )
				dots = value / 400;
			else if( value < 10000 )
				dots = (value - 4000) / 600;
			else if( value < maxValue )
				dots = (value - 10000) / ((maxValue-10000)/10);
			else
				dots = 10;

			for ( int i = 0; i < 10; ++i )
				AddImage( 95 + (i * 17), 50, i < dots ? 2362 : 2360 );

			if( value < 1 )
				valueDesc = 1052044; // You have not started on the path of this Virtue.
			else if( value < 400 )
				valueDesc = 1052045; // You have barely begun your journey through the path of this Virtue.
			else if( value < 2000 )
				valueDesc = 1052046; // You have progressed in this Virtue, but still have much to do.
			else if( value < 3600 )
				valueDesc = 1052047; // Your journey through the path of this Virtue is going well.
			else if( value < 4000 )
				valueDesc = 1052048; // You feel very close to achieving your next path in this Virtue.
			else if( dots < 1 )
				valueDesc = 1052049; // You have achieved a path in this Virtue.
			else if( dots < 9 )
				valueDesc = 1052047; // Your journey through the path of this Virtue is going well.
			else if( dots < 10 )
				valueDesc = 1052048; // You feel very close to achieving your next path in this Virtue.
			else
				valueDesc = 1052050; // You have achieved the highest path in this Virtue.

			AddHtmlLocalized( 157, 73, 200, 40, 1051000 + (int)virtue, false, false );
			AddHtmlLocalized( 75, 95, 220, 140, description, false, false );
			AddHtmlLocalized( 70, 224, 229, 60, valueDesc, false, false );

			AddButton( 65, 277, 1209, 1209, 1, GumpButtonType.Reply, 0 );

			AddButton( 280, 43, 4014, 4014, 2, GumpButtonType.Reply, 0 );

			AddHtmlLocalized( 83, 275, 400, 40, (webPage == null) ? 1052055 : 1052052, false, false ); // This virtue is not yet defined. OR -click to learn more (opens webpage)

		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			switch ( info.ButtonID )
			{
				case 1:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, m_Virtue, m_Desc, m_Page ) );

					if( m_Page != null )
						state.Send( new LaunchBrowser( m_Page ) ); //No message about web browser starting on OSI
					break;
				}
				case 2:
				{
					m_Beholder.SendGump( new VirtueStatusGump( m_Beholder ) );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Network;

namespace Server
{
	public class VirtueStatusGump : Gump
	{
		private Mobile m_Beholder;

		public VirtueStatusGump( Mobile beholder ) : base( 0, 0 )
		{
			m_Beholder = beholder;

			AddPage( 0 );

			AddImage( 30, 40, 2080 );
			AddImage( 47, 77, 2081 );
			AddImage( 47, 147, 2081 );
			AddImage( 47, 217, 2081 );
			AddImage( 47, 267, 2083 );
			AddImage( 70, 213, 2091 );

			AddPage( 1 );

			AddHtml( 140, 73, 200, 20, "The Virtues", false, false );

			AddHtmlLocalized( 80, 100, 100, 40, 1051000, false, false ); // Humility
			AddHtmlLocalized( 80, 129, 100, 40, 1051001, false, false ); // Sacrifice
			AddHtmlLocalized( 80, 159, 100, 40, 1051002, false, false ); // Compassion
			AddHtmlLocalized( 80, 189, 100, 40, 1051003, false, false ); // Spirituality
			AddHtmlLocalized( 200, 100, 200, 40, 1051004, false, false ); // Valor
			AddHtmlLocalized( 200, 129, 200, 40, 1051005, false, false ); // Honor
			AddHtmlLocalized( 200, 159, 200, 40, 1051006, false, false ); // Justice
			AddHtmlLocalized( 200, 189, 200, 40, 1051007, false, false ); // Honesty

			AddHtmlLocalized( 75, 224, 220, 60, 1052062, false, false ); // Click on a blue gem to view your status in that virtue.

			AddButton( 60, 100, 1210, 1210, 1, GumpButtonType.Reply, 0 );
			AddButton( 60, 129, 1210, 1210, 2, GumpButtonType.Reply, 0 );
			AddButton( 60, 159, 1210, 1210, 3, GumpButtonType.Reply, 0 );
			AddButton( 60, 189, 1210, 1210, 4, GumpButtonType.Reply, 0 );
			AddButton( 180, 100, 1210, 1210, 5, GumpButtonType.Reply, 0 );
			AddButton( 180, 129, 1210, 1210, 6, GumpButtonType.Reply, 0 );
			AddButton( 180, 159, 1210, 1210, 7, GumpButtonType.Reply, 0 );
			AddButton( 180, 189, 1210, 1210, 8, GumpButtonType.Reply, 0 );

			AddButton( 280, 43, 4014, 4014, 9, GumpButtonType.Reply, 0 );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			switch ( info.ButtonID )
			{
				case 1:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Humility, 1052051 ) );
					break;
				}
				case 2:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Sacrifice, 1052053, @"http://update.uo.com/design_389.html" ) );
					break;
				}
				case 3:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Compassion, 1053000, @"http://update.uo.com/design_412.html" ) );
					break;
				}
				case 4:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Spirituality, 1052056 ) );
					break;
				}
				case 5:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Valor, 1054033, @"http://update.uo.com/design_427.html" ) );
					break;
				}
				case 6:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Honor, 1052058, @"http://guide.uo.com/virtues_2.html" ) );
					break;
				}
				case 7:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Justice, 1052059, @"http://update.uo.com/design_413.html" ) );
					break;
				}
				case 8:
				{
					m_Beholder.SendGump( new VirtueInfoGump( m_Beholder, VirtueName.Honesty, 1052060 ) );
					break;
				}
				case 9:
				{
					m_Beholder.SendGump( new VirtueGump( m_Beholder, m_Beholder ) );
					break;
				}
			}
		}
	}
}
// using System;// using Server;// using Server.Gumps;// using Server.Mobiles;// using Server.Network;

namespace Server.Factions
{
	public class VoteGump : FactionGump
	{
		private PlayerMobile m_From;
		private Election m_Election;

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 0 )
			{
				m_From.SendGump( new FactionStoneGump( m_From, m_Election.Faction ) );
			}
			else
			{
				if ( !m_Election.CanVote( m_From ) )
					return;

				int index = info.ButtonID - 1;

				if ( index >= 0 && index < m_Election.Candidates.Count )
					m_Election.Candidates[index].Voters.Add( new Voter( m_From, m_Election.Candidates[index].Mobile ) );

				m_From.SendGump( new VoteGump( m_From, m_Election ) );
			}
		}

		public VoteGump( PlayerMobile from, Election election ) : base( 50, 50 )
		{
			m_From = from;
			m_Election = election;

			bool canVote = election.CanVote( from );

			AddPage( 0 );

			AddBackground( 0, 0, 420, 350, 5054 );
			AddBackground( 10, 10, 400, 330, 3000 );

			AddHtmlText( 20, 20, 380, 20, election.Faction.Definition.Header, false, false );

			if ( canVote )
				AddHtmlLocalized( 20, 60, 380, 20, 1011428, false, false ); // VOTE FOR LEADERSHIP
			else
				AddHtmlLocalized( 20, 60, 380, 20, 1038032, false, false ); // You have already voted in this election.

			for ( int i = 0; i < election.Candidates.Count; ++i )
			{
				Candidate cd = election.Candidates[i];

				if ( canVote )
					AddButton( 20, 100 + (i * 20), 4005, 4007, i + 1, GumpButtonType.Reply, 0 );

				AddLabel( 55, 100 + (i * 20), 0, cd.Mobile.Name );
				AddLabel( 300, 100 + (i * 20), 0, cd.Votes.ToString() );
			}

			AddButton( 20, 310, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 55, 310, 100, 20, 1011012, false, false ); // CANCEL
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water beetle corpse" )]
	public class WaterBeetle : BaseCreature
	{
		[Constructable]
		public WaterBeetle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water beetle";
			Body = 0xA9;
			Hue = 1365;
			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 6, 10 );

			CanSwim = true;

			SetHits( 80, 110 );

			SetDamage( 3, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Tactics, 55.1, 70.0 );
			SetSkill( SkillName.FistFighting, 60.1, 75.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 16;
		}

		public override bool BleedImmune{ get{ return true; } }

		public override int GetAngerSound()
		{
			return 0x21D;
		}

		public override int GetIdleSound()
		{
			return 0x21D;
		}

		public override int GetAttackSound()
		{
			return 0x162;
		}

		public override int GetHurtSound()
		{
			return 0x163;
		}

		public override int GetDeathSound()
		{
			return 0x21D;
		}

		public WaterBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = 0xA9;
		}
	}
}
// using System;// using Server;// using Server.Items;// using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class WhiteDragon : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public WhiteDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a white dragon";
			Body = 12;
			Hue = 0x9C2;
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 478, 495 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 65 );
			SetResistance( ResistanceType.Cold, 60, 70 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Poison, 25, 35 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.Psychology, 30.1, 40.0 );
			SetSkill( SkillName.Magery, 30.1, 40.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 60;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			Mobile killer = this.LastKiller;
			if ( killer != null )
			{
				if ( killer is BaseCreature )
					killer = ((BaseCreature)killer).GetMaster();

				if ( killer is PlayerMobile )
				{
					Server.Mobiles.Dragons.DropSpecial( this, killer, "", "White", "", c, 25, 0 );
				}
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.White ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public WhiteDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;// using Server;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyrm corpse" )]
	public class WhiteWyrm : BaseCreature
	{
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0x481; } }
		public override int BreathEffectSound{ get{ return 0x64F; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 12 ); }

		[Constructable]
		public WhiteWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the white wyrm";
			BaseSoundID = 362;
			Hue = 0x9C2;
			Body = Server.Misc.MyServerSettings.WyrmBody();

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 433, 456 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 55, 70 );
			SetResistance( ResistanceType.Fire, 15, 25 );
			SetResistance( ResistanceType.Cold, 80, 90 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.Psychology, 99.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.MagicResist, 99.1, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.FistFighting, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			VirtualArmor = 64;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 96.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

		public override int TreasureMapLevel{ get{ return 5; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ if ( Utility.RandomBool() ){ return HideType.Frozen; } else { return HideType.Draconic; } } }
		public override int Scales{ get{ return 9; } }
		public override ScaleType ScaleType{ get{ return ScaleType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public WhiteWyrm( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			Body = Server.Misc.MyServerSettings.WyrmBody();
		}
	}
}
// using System;// using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wyvern corpse" )]
	public class Wyvern : BaseCreature
	{
		[Constructable]
		public Wyvern () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wyvern";
			Body = 62;
			BaseSoundID = 362;

			SetStr( 202, 240 );
			SetDex( 153, 172 );
			SetInt( 51, 90 );

			SetHits( 125, 141 );

			SetDamage( 8, 19 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 90, 100 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Poisoning, 60.1, 80.0 );
			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.FistFighting, 65.1, 80.0 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 40;

			Item Venom = new VenomSack();
				Venom.Name = "deadly venom sack";
				AddItem( Venom );

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 63.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.MedScrolls );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Draconic; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override int GetAttackSound()
		{
			return 713;
		}

		public override int GetAngerSound()
		{
			return 718;
		}

		public override int GetDeathSound()
		{
			return 716;
		}

		public override int GetHurtSound()
		{
			return 721;
		}

		public override int GetIdleSound()
		{
			return 725;
		}

		public Wyvern( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
// using System;

namespace Server.Factions
{
	public class Yew : Town
	{
		public Yew()
		{
			Definition =
				new TownDefinition(
					4,
					0x186D,
					"Yew",
					"Yew",
					new TextDefinition( 1011438, "YEW" ),
					new TextDefinition( 1011565, "TOWN STONE FOR YEW" ),
					new TextDefinition( 1041038, "The Faction Sigil Monolith of Yew" ),
					new TextDefinition( 1041408, "The Faction Town Sigil Monolith of Yew" ),
					new TextDefinition( 1041417, "Faction Town Stone of Yew" ),
					new TextDefinition( 1041399, "Faction Town Sigil of Yew" ),
					new TextDefinition( 1041390, "Corrupted Faction Town Sigil of Yew" ),
					new Point3D( 548, 979, 0 ),
					new Point3D( 542, 980, 0 ) );
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "an axebeak corpse" )]
	public class AxeBeak : BaseCreature
	{
		[Constructable]
		public AxeBeak() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "an axebeak";
			Body = 25;
			BaseSoundID = 0x8F;

			SetStr( 96, 120 );
			SetDex( 86, 110 );
			SetInt( 51, 75 );

			SetHits( 58, 72 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 10, 20 );
			SetResistance( ResistanceType.Cold, 10, 30 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 10, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.FistFighting, 60.1, 90.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 28;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 39.1;
		}

		public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			base.OnCarve( from, corpse, with );

			if ( Utility.RandomMinMax( 1, 5 ) == 1 )
			{
				Item egg = new Eggs( Utility.RandomMinMax( 1, 5 ) );
				corpse.DropItem( egg );
			}
		}

		public override void OnAfterSpawn()
		{
			Region reg = Region.Find( this.Location, this.Map );

			if ( reg.IsPartOf( "Dungeon Covetous" ) )
			{
				AI = AIType.AI_Melee;
				FightMode = FightMode.Closest;
				Tamable = false;
				NameHue = 0x22;
			}

			base.OnAfterSpawn();
		}

		public override int Meat{ get{ return 4; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Feathers{ get{ return 50; } }
		public override int Hides{ get{ return 5; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override int Scales{ get{ return 2; } }
		public override ScaleType ScaleType{ get{ return ( ScaleType.Dinosaur ); } }
		public override HideType HideType{ get{ return HideType.Dinosaur; } }

		public AxeBeak(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a basilisk corpse" )]
	public class Basilisk : BaseCreature
	{
		[Constructable]
		public Basilisk () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a basilisk";
			Body = 483;
			Hue = 0x9C4;
			BaseSoundID = 0x5A;

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 106, 123 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, 15, 25 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 45.1, 60.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.FistFighting, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;
		}

		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 15; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override void OnAfterSpawn()
		{
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
			{
				this.Body = 743;
			}

			base.OnAfterSpawn();
		}

		public void TurnStone()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m == this || !CanBeHarmful( m ) )
					continue;

				if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
					list.Add( m );
				else if ( m.Player )
					list.Add( m );
			}

			foreach ( Mobile m in list )
			{
				if ( !m.CheckSkill( SkillName.MagicResist, 0, 80 ) && !Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
				{
					DoHarmful( m );

					m.PlaySound(0x204);
					m.FixedEffect(0x376A, 6, 1);

					int duration = Utility.RandomMinMax(4, 8);
					m.Paralyze(TimeSpan.FromSeconds(duration));

					m.SendMessage( "You are petrified!" );
				}
			}
		}

		public override void OnGaveMeleeAttack( Mobile m )
		{
			base.OnGaveMeleeAttack( m );

			if ( 1 == Utility.RandomMinMax( 1, 20 ) )
			{
				Container cont = m.Backpack;
				Item iStone = Server.Items.HiddenTrap.GetMyItem( m );

				if ( iStone != null )
				{
					if ( m.CheckSkill( SkillName.MagicResist, 0, 80 ) || Server.Items.HiddenTrap.IAmAWeaponSlayer( m, this ) )
					{
					}
					else if ( Server.Items.HiddenTrap.CheckInsuranceOnTrap( iStone, m ) == true )
					{
						m.LocalOverheadMessage(MessageType.Emote, 1150, true, "The basilisk almost turned one of your protected items to stone!");
					}
					else
					{
						m.LocalOverheadMessage(MessageType.Emote, 0xB1F, true, "One of your items has been turned to stone!");
						m.PlaySound( 0x1FB );
						Item rock = new BrokenGear();
						rock.ItemID = iStone.GraphicID;
						rock.Hue = 2101;
						rock.Weight = iStone.Weight * 3;
						rock.Name = "useless stone";
						iStone.Delete();
						m.AddToBackpack ( rock );
					}
				}
			}

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() )
				TurnStone();
		}

		public Basilisk( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a manticore corpse" )]
	public class Manticore : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		public override int BreathPhysicalDamage{ get{ return 100; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectSound{ get{ return 0x536; } }
		public override int BreathEffectItemID{ get{ return 0x10B5; } } // DART
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 5 ); }

		[Constructable]
		public Manticore () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a manticore";
			Body = 843;
			BaseSoundID = 0x3EE;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 241, 258 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 45, 50 );
			SetResistance( ResistanceType.Fire, 50, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.1, 90.0 );
			SetSkill( SkillName.FistFighting, 65.1, 80.0 );

			Fame = 5500;
			Karma = -5500;

			VirtualArmor = 46;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 94.3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 20; } }
		public override HideType HideType{ get{ return HideType.Hellish; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Manticore( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class Panda : BaseCreature
	{
		[Constructable]
		public Panda() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a panda bear";
			Body = 671;
			BaseSoundID = 0xA3;

			SetStr( 76, 100 );
			SetDex( 26, 45 );
			SetInt( 23, 47 );

			SetHits( 46, 60 );
			SetMana( 0 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 30 );
			SetResistance( ResistanceType.Cold, 15, 20 );
			SetResistance( ResistanceType.Poison, 10, 15 );

			SetSkill( SkillName.MagicResist, 25.1, 35.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.FistFighting, 40.1, 60.0 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 41.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 6 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public Panda( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a hell lion corpse" )]
	[TypeAlias( "Server.Mobiles.Preditorhellcat" )]
	public class PredatorHellCat : BaseCreature
	{
		public override bool HasBreath{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 17 ); }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public PredatorHellCat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hell lion";
			Body = 340;
			Hue = 0x4AA;
			BaseSoundID = 0x3EE;

			SetStr( 161, 185 );
			SetDex( 96, 115 );
			SetInt( 76, 100 );

			SetHits( 97, 131 );

			SetDamage( 5, 17 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Energy, 5, 15 );

			SetSkill( SkillName.MagicResist, 75.1, 90.0 );
			SetSkill( SkillName.Tactics, 50.1, 65.0 );
			SetSkill( SkillName.FistFighting, 50.1, 65.0 );

			Fame = 2500;
			Karma = -2500;

			VirtualArmor = 30;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 89.1;

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Volcanic; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public PredatorHellCat(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class SabretoothTiger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public SabretoothTiger() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a sabretooth tiger";
			Body = 340;
			BaseSoundID = 0x462;
			Hue = 0x54F;

			SetStr( 400 );
			SetDex( 300 );
			SetInt( 120 );

			SetMana( 0 );

			SetDamage( 25, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 15, 25 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.FistFighting, 120.0 );

			Fame = 3000;
			Karma = 0;

			VirtualArmor = 50;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 90.1;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 16; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 8 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public SabretoothTiger( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	public class Tiger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Tiger() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger";
			Body = 340;
			BaseSoundID = 0x3EE;
			Hue = 0x54F;

			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );

			SetHits( 64, 88 );
			SetMana( 0 );

			SetDamage( 8, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 750;
			Karma = 0;

			VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 10; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public Tiger(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a feline corpse" )]
	[TypeAlias( "Server.Mobiles.WhiteTiger" )]
	public class WhiteTiger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public WhiteTiger() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tiger";
			Body = 340;
			BaseSoundID = 0x3EE;
			Hue = 0x9C2;

			SetStr( 112, 160 );
			SetDex( 120, 190 );
			SetInt( 50, 76 );

			SetHits( 64, 88 );
			SetMana( 0 );

			SetDamage( 8, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 5, 10 );

			SetSkill( SkillName.MagicResist, 15.1, 30.0 );
			SetSkill( SkillName.Tactics, 45.1, 60.0 );
			SetSkill( SkillName.FistFighting, 45.1, 60.0 );

			Fame = 750;
			Karma = 0;

			VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 61.1;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Frozen; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 4 ); } }
		public override FurType FurType{ get{ return FurType.White; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public WhiteTiger(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
namespace Server.Mobiles
{
	[CorpseName( "a zebra corpse" )]
	public class Zebra : BaseCreature
	{
		[Constructable]
		public Zebra() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a zebra";
			Body = 115;
			BaseSoundID = 0xA8;

			SetStr( 22, 98 );
			SetDex( 56, 75 );
			SetInt( 6, 10 );

			SetHits( 28, 45 );
			SetMana( 0 );

			SetDamage( 3, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.FistFighting, 29.3, 44.0 );

			Fame = 300;
			Karma = 0;
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override int Furs{ get{ return Utility.RandomList( 0, 0, 0, 5 ); } }
		public override FurType FurType{ get{ return FurType.Regular; } }

		public Zebra( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}

namespace Server.Items
{
	public class SalesBook : Item
	{
		public static SalesBook m_Book;

		[Constructable]
		public SalesBook() : base( 0x2254 )
		{
			Weight = 1.0;
			Movable = false;
			Hue = 0x515;
			Name = "Steel Crafted Items";
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.SendSound( 0x55 );
			from.CloseGump( typeof( SalesBookGump ) );
			from.SendGump( new SalesBookGump( from, this, 0 ) );
		}

		public class SalesBookGump : Gump
		{
			public SalesBookGump( Mobile from, SalesBook wikipedia, int page ): base( 100, 100 )
			{
				m_Book = wikipedia;
				SalesBook pedia = (SalesBook)wikipedia;

				int NumberOfsellings = 121;	// SEE LISTING BELOW AND MAKE SURE IT MATCHES THE AMOUNT
											// DO THIS NUMBER+1 IN THE OnResponse SECTION BELOW

				string BookTitle = "";

				if ( m_Book.Name == "Steel Crafted Items" )
				{
					NumberOfsellings = 121;
					BookTitle = "Steel Crafted";
				}
				else if ( m_Book.Name == "Mithril Crafted Items" )
				{
					NumberOfsellings = 121;
					BookTitle = "Mithril Crafted";
				}
				else if ( m_Book.Name == "Brass Crafted Items" )
				{
					NumberOfsellings = 121;
					BookTitle = "Brass Crafted";
				}

				decimal PageCount = NumberOfsellings / 16;
				int TotalBookPages = ( 100000 ) + ( (int)Math.Ceiling( PageCount ) );

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				int subItem = page * 16;

				int showItem1 = subItem + 1;
				int showItem2 = subItem + 2;
				int showItem3 = subItem + 3;
				int showItem4 = subItem + 4;
				int showItem5 = subItem + 5;
				int showItem6 = subItem + 6;
				int showItem7 = subItem + 7;
				int showItem8 = subItem + 8;
				int showItem9 = subItem + 9;
				int showItem10 = subItem + 10;
				int showItem11 = subItem + 11;
				int showItem12 = subItem + 12;
				int showItem13 = subItem + 13;
				int showItem14 = subItem + 14;
				int showItem15 = subItem + 15;
				int showItem16 = subItem + 16;

				int page_prev = ( 100000 + page ) - 1;
					if ( page_prev < 100000 ){ page_prev = TotalBookPages; }
				int page_next = ( 100000 + page ) + 1;
					if ( page_next > TotalBookPages ){ page_next = 100000; }

				AddImage(40, 36, 1054);

				AddHtml( 162, 64, 200, 34, @"<BODY><BASEFONT Color=#111111><BIG><CENTER>" + BookTitle + "</CENTER></BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 444, 64, 180, 34, @"<BODY><BASEFONT Color=#111111><BIG><CENTER>" + BookTitle + "</CENTER></BIG></BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(93, 53, 1055, 1055, page_prev, GumpButtonType.Reply, 0);
				AddButton(625, 53, 1056, 1056, page_next, GumpButtonType.Reply, 0);

				///////////////////////////////////////////////////////////////////////////////////

				AddHtml( 126, 112, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem1, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 148, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem2, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 184, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem3, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 220, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem4, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 256, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem5, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 292, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem6, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 328, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem7, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 126, 364, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem8, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);

				if ( GetSalesForBook( m_Book.Name, showItem1, 1, from ) != "" ){ AddHtml( 328, 112, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem1, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem2, 1, from ) != "" ){ AddHtml( 328, 148, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem2, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem3, 1, from ) != "" ){ AddHtml( 328, 184, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem3, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem4, 1, from ) != "" ){ AddHtml( 328, 220, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem4, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem5, 1, from ) != "" ){ AddHtml( 328, 256, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem5, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem6, 1, from ) != "" ){ AddHtml( 328, 292, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem6, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem7, 1, from ) != "" ){ AddHtml( 328, 328, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem7, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem8, 1, from ) != "" ){ AddHtml( 328, 364, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem8, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }

				if ( GetSalesForBook( m_Book.Name, showItem1, 1, from ) != "" ){ AddButton(104, 115, 30008, 30008, showItem1, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem2, 1, from ) != "" ){ AddButton(104, 151, 30008, 30008, showItem2, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem3, 1, from ) != "" ){ AddButton(104, 187, 30008, 30008, showItem3, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem4, 1, from ) != "" ){ AddButton(104, 223, 30008, 30008, showItem4, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem5, 1, from ) != "" ){ AddButton(104, 259, 30008, 30008, showItem5, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem6, 1, from ) != "" ){ AddButton(104, 295, 30008, 30008, showItem6, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem7, 1, from ) != "" ){ AddButton(104, 331, 30008, 30008, showItem7, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem8, 1 , from) != "" ){ AddButton(104, 367, 30008, 30008, showItem8, GumpButtonType.Reply, 0); }

				///////////////////////////////////////////////////////////////////////////////////

				AddHtml( 443, 112, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem9, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 148, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem10, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 184, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem11, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 220, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem12, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 256, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem13, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 292, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem14, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 328, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem15, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 443, 364, 240, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem16, 1, from ) + "</BIG></BASEFONT></BODY>", (bool)false, (bool)false);

				if ( GetSalesForBook( m_Book.Name, showItem9, 1, from ) != "" ){ AddHtml( 645, 112, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem9, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem10, 1, from ) != "" ){ AddHtml( 645, 148, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem10, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem11, 1, from ) != "" ){ AddHtml( 645, 184, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem11, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem12, 1, from ) != "" ){ AddHtml( 645, 220, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem12, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem13, 1, from ) != "" ){ AddHtml( 645, 256, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem13, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem14, 1, from ) != "" ){ AddHtml( 645, 292, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem14, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem15, 1, from ) != "" ){ AddHtml( 645, 328, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem15, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }
				if ( GetSalesForBook( m_Book.Name, showItem16, 1, from ) != "" ){ AddHtml( 645, 364, 70, 34, @"<BODY><BASEFONT Color=#111111><BIG>" + GetSalesForBook( m_Book.Name, showItem16, 3, from ) + "G</BIG></BASEFONT></BODY>", (bool)false, (bool)false); }

				if ( GetSalesForBook( m_Book.Name, showItem9, 1, from ) != "" ){ AddButton(421, 115, 30008, 30008, showItem9, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem10, 1, from ) != "" ){ AddButton(421, 151, 30008, 30008, showItem10, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem11, 1, from ) != "" ){ AddButton(421, 187, 30008, 30008, showItem11, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem12, 1, from ) != "" ){ AddButton(421, 223, 30008, 30008, showItem12, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem13, 1, from ) != "" ){ AddButton(421, 259, 30008, 30008, showItem13, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem14, 1, from ) != "" ){ AddButton(421, 295, 30008, 30008, showItem14, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem15, 1, from ) != "" ){ AddButton(421, 331, 30008, 30008, showItem15, GumpButtonType.Reply, 0); }
				if ( GetSalesForBook( m_Book.Name, showItem16, 1, from ) != "" ){ AddButton(421, 367, 30008, 30008, showItem16, GumpButtonType.Reply, 0); }
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile;
				Container pack = from.Backpack;
				from.SendSound( 0x55 );
				int NumItemsPlusOne = 121;

				if ( m_Book.Name == "Steel Crafted Items" )
				{
					NumItemsPlusOne = 121;
				}
				else if ( m_Book.Name == "Mithril Crafted Items" )
				{
					NumItemsPlusOne = 121;
				}
				else if ( m_Book.Name == "Brass Crafted Items" )
				{
					NumItemsPlusOne = 121;
				}

				if ( info.ButtonID >= 100000 )
				{
					int page = info.ButtonID - 100000;
					from.SendGump( new SalesBookGump( from, m_Book, page ) );
				}
				else if ( info.ButtonID < NumItemsPlusOne )
				{
					string sType = GetSalesForBook( m_Book.Name, info.ButtonID, 2, from );
					string sName = GetSalesForBook( m_Book.Name, info.ButtonID, 1, from );
					int cost = Int32.Parse( GetSalesForBook( m_Book.Name, info.ButtonID, 3, from ) );
					string spentMessage = "You pay a total of " + cost.ToString() + " gold.";

					if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ) // LET US SEE IF THEY ARE BEGGING
					{
						cost = cost - (int)( ( from.Skills[SkillName.Begging].Value * 0.005 ) * cost ); if ( cost < 1 ){ cost = 1; }
						spentMessage = "You only pay a total of " + cost.ToString() + " gold because of your begging.";
					}

					bool nearBook = false;
					foreach ( Item tome in from.GetItemsInRange( 10 ) )
					{
						if ( tome == m_Book ){ nearBook = true; }
					}

					if ( sName != "" && nearBook == true )
					{
						if ( from.TotalGold >= cost )
						{
							Item item = null;
							Type itemType = ScriptCompiler.FindTypeByName( sType );
							item = (Item)Activator.CreateInstance(itemType);

							pack.ConsumeTotal(typeof(Gold), cost);
							from.SendMessage( spentMessage );

							if ( m_Book.Name == "Steel Crafted Items" )
							{
								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = CraftResource.Steel; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = CraftResource.Steel; }
							}
							else if ( m_Book.Name == "Mithril Crafted Items" )
							{
								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = CraftResource.Mithril; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = CraftResource.Mithril; }
							}
							else if ( m_Book.Name == "Brass Crafted Items" )
							{
								if ( item is BaseWeapon ){ BaseWeapon weapon = (BaseWeapon)item; weapon.Resource = CraftResource.Brass; }
								else if ( item is BaseArmor ){ BaseArmor armor = (BaseArmor)item; armor.Resource = CraftResource.Brass; }
							}

							from.AddToBackpack ( item );
							if ( Server.Mobiles.BaseVendor.BeggingPose(from) > 0 ){ Titles.AwardKarma( from, -Server.Mobiles.BaseVendor.BeggingKarma( from ), true ); } // DO ANY KARMA LOSS

							int OneSay = 0;

							foreach ( Mobile who in from.GetMobilesInRange( 10 ) )
							{
								if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && OneSay == 0 && m_Book.Name == "Steel Crafted Items" )
								{
									who.PlaySound( 0x2A );

									switch( Utility.Random( 2 ) )
									{
										case 0: who.Say( "I have spent years learning the art of steel." ); 	break;
										case 1: who.Say( "Let me see what I can make here." );					break;
										case 2: who.Say( "People come from afar for orkish steel." ); 			break;
										case 3: who.Say( "You won't see many items like this." );				break;
										case 4: who.Say( "I think I can forge that for you." );					break;
										case 5: who.Say( "The fires are hot so I am ready to forge steel." );	break;
									}

									OneSay = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && OneSay == 0 && m_Book.Name == "Mithril Crafted Items" )
								{
									who.PlaySound( 0x2A );

									switch( Utility.Random( 2 ) )
									{
										case 0: who.Say( "I have spent years learning the art of mithril." ); 	break;
										case 1: who.Say( "Let me see what I can make here." );					break;
										case 2: who.Say( "People find their way here for our mithril." ); 		break;
										case 3: who.Say( "You won't see many items like this." );				break;
										case 4: who.Say( "I think I can forge that for you." );					break;
										case 5: who.Say( "The fires are hot so I am ready to forge mithril." );	break;
									}

									OneSay = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && OneSay == 0 && m_Book.Name == "Brass Crafted Items" )
								{
									who.PlaySound( 0x2A );

									switch( Utility.Random( 2 ) )
									{
										case 0: who.Say( "I have spent years learning the art of brass." ); 	break;
										case 1: who.Say( "Let me see what I can make here." );					break;
										case 2: who.Say( "People find their way here for our brass." ); 		break;
										case 3: who.Say( "You won't see many items like this." );				break;
										case 4: who.Say( "I think I can forge that for you." );					break;
										case 5: who.Say( "The fires are hot so I am ready to forge brass." );	break;
									}

									OneSay = 1;
								}
							}
						}
						else
						{
							int NoGold = 0;

							foreach ( Mobile who in from.GetMobilesInRange( 10 ) )
							{
								if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && NoGold == 0 && m_Book.Name == "Steel Crafted Items" )
								{
									who.Say( "You don't seem to have enough gold for me to make that." );
									NoGold = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && NoGold == 0 && m_Book.Name == "Mithril Crafted Items" )
								{
									who.Say( "You don't seem to have enough gold for me to make that." );
									NoGold = 1;
								}
								else if ( ( who is IronWorker || who is Weaponsmith || who is Armorer  || who is Blacksmith ) && NoGold == 0 && m_Book.Name == "Brass Crafted Items" )
								{
									who.Say( "You don't seem to have enough gold for me to make that." );
									NoGold = 1;
								}
							}
						}
					}
				}
			}
		}

		public SalesBook( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int)1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		public static string GetSalesForBook( string book, int selling, int part, Mobile player )
		{
			double barter = player.Skills[SkillName.Mercantile].Value * 0.001;

			string item = "";
			string name = "";
			int cost = 0;

			int sales = 1;
			int rate = 4; // STANDARD MARKUP

			double markup = 1;

			if ( m_Book.Name == "Steel Crafted Items" )
			{
				markup = 3.00 * rate;
			}
			else if ( m_Book.Name == "Brass Crafted Items" )
			{
				markup = 6.00 * rate;
			}
			else if ( m_Book.Name == "Mithril Crafted Items" )
			{
				markup = 9.00 * rate;
			}

			markup = markup - ( markup * barter );

			if ( book == "Steel Crafted Items" || book == "Mithril Crafted Items" || book == "Brass Crafted Items" )
			{
				if ( selling == sales ) { name="AssassinSpike"; item="Assassin Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="ElvenSpellblade"; item="Assassin Sword"; cost = 33; } sales++;
				if ( selling == sales ) { name="Axe"; item="Axe"; cost = 40; } sales++;
				if ( selling == sales ) { name="OrnateAxe"; item="Barbarian Axe"; cost = 42; } sales++;
				if ( selling == sales ) { name="VikingSword"; item="Barbarian Sword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Bardiche"; item="Bardiche"; cost = 60; } sales++;
				if ( selling == sales ) { name="Bascinet"; item="Bascinet"; cost = 18; } sales++;
				if ( selling == sales ) { name="BattleAxe"; item="Battle Axe"; cost = 26; } sales++;
				if ( selling == sales ) { name="DiamondMace"; item="Battle Mace"; cost = 31; } sales++;
				if ( selling == sales ) { name="BladedStaff"; item="Bladed Staff"; cost = 40; } sales++;
				if ( selling == sales ) { name="Broadsword"; item="Broadsword"; cost = 35; } sales++;
				if ( selling == sales ) { name="Buckler"; item="Buckler"; cost = 50; } sales++;
				if ( selling == sales ) { name="ButcherKnife"; item="Butcher Knife"; cost = 14; } sales++;
				if ( selling == sales ) { name="ChainChest"; item="Chain Chest"; cost = 143; } sales++;
				if ( selling == sales ) { name="ChainCoif"; item="Chain Coif"; cost = 17; } sales++;
				if ( selling == sales ) { name="ChainHatsuburi"; item="Chain Hatsuburi"; cost = 76; } sales++;
				if ( selling == sales ) { name="ChainLegs"; item="Chain Legs"; cost = 149; } sales++;
				if ( selling == sales ) { name="ChampionShield"; item="Champion Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="ChaosShield"; item="Chaos Shield"; cost = 241; } sales++;
				if ( selling == sales ) { name="Claymore"; item="Claymore"; cost = 55; } sales++;
				if ( selling == sales ) { name="Cleaver"; item="Cleaver"; cost = 15; } sales++;
				if ( selling == sales ) { name="CloseHelm"; item="Close Helm"; cost = 18; } sales++;
				if ( selling == sales ) { name="CrescentBlade"; item="Crescent Blade"; cost = 37; } sales++;
				if ( selling == sales ) { name="CrestedShield"; item="Crested Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Cutlass"; item="Cutlass"; cost = 24; } sales++;
				if ( selling == sales ) { name="Dagger"; item="Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="Daisho"; item="Daisho"; cost = 66; } sales++;
				if ( selling == sales ) { name="DarkShield"; item="Dark Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="DecorativePlateKabuto"; item="Decorative Plate Kabuto"; cost = 95; } sales++;
				if ( selling == sales ) { name="DoubleAxe"; item="Double Axe"; cost = 52; } sales++;
				if ( selling == sales ) { name="DoubleBladedStaff"; item="Double Bladed Staff"; cost = 35; } sales++;
				if ( selling == sales ) { name="DreadHelm"; item="Dread Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="ElvenShield"; item="Elven Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="RadiantScimitar"; item="Falchion"; cost = 35; } sales++;
				if ( selling == sales ) { name="FemalePlateChest"; item="Female Plate Chest"; cost = 113; } sales++;
				if ( selling == sales ) { name="ExecutionersAxe"; item="Great Axe"; cost = 30; } sales++;
				if ( selling == sales ) { name="GuardsmanShield"; item="Guardsman Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Halberd"; item="Halberd"; cost = 42; } sales++;
				if ( selling == sales ) { name="Hammers"; item="Hammer"; cost = 28; } sales++;
				if ( selling == sales ) { name="HammerPick"; item="Hammer Pick"; cost = 26; } sales++;
				if ( selling == sales ) { name="Harpoon"; item="Harpoon"; cost = 40; } sales++;
				if ( selling == sales ) { name="HeaterShield"; item="Heater Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="HeavyPlateJingasa"; item="Heavy Plate Jingasa"; cost = 76; } sales++;
				if ( selling == sales ) { name="Helmet"; item="Helmet"; cost = 18; } sales++;
				if ( selling == sales ) { name="OrcHelm"; item="Horned Helm"; cost = 24; } sales++;
				if ( selling == sales ) { name="JeweledShield"; item="Jeweled Shield"; cost = 231; } sales++;
				if ( selling == sales ) { name="Kama"; item="Kama"; cost = 61; } sales++;
				if ( selling == sales ) { name="Katana"; item="Katana"; cost = 33; } sales++;
				if ( selling == sales ) { name="Kryss"; item="Kryss"; cost = 32; } sales++;
				if ( selling == sales ) { name="Lajatang"; item="Lajatang"; cost = 108; } sales++;
				if ( selling == sales ) { name="Lance"; item="Lance"; cost = 34; } sales++;
				if ( selling == sales ) { name="LargeBattleAxe"; item="Large Battle Axe"; cost = 33; } sales++;
				if ( selling == sales ) { name="LargeKnife"; item="Large Knife"; cost = 21; } sales++;
				if ( selling == sales ) { name="BronzeShield"; item="Large Shield"; cost = 66; } sales++;
				if ( selling == sales ) { name="LightPlateJingasa"; item="Light Plate Jingasa"; cost = 56; } sales++;
				if ( selling == sales ) { name="Longsword"; item="Longsword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Mace"; item="Mace"; cost = 28; } sales++;
				if ( selling == sales ) { name="ElvenMachete"; item="Machete"; cost = 35; } sales++;
				if ( selling == sales ) { name="Maul"; item="Maul"; cost = 21; } sales++;
				if ( selling == sales ) { name="MetalKiteShield"; item="Metal Kite Shield"; cost = 123; } sales++;
				if ( selling == sales ) { name="MetalShield"; item="Metal Shield"; cost = 121; } sales++;
				if ( selling == sales ) { name="NoDachi"; item="NoDachi"; cost = 82; } sales++;
				if ( selling == sales ) { name="NorseHelm"; item="Norse Helm"; cost = 18; } sales++;
				if ( selling == sales ) { name="OrderShield"; item="Order Shield"; cost = 241; } sales++;
				if ( selling == sales ) { name="OrnateAxe"; item="Barbarian Axe"; cost = 241; } sales++;
				if ( selling == sales ) { name="Pike"; item="Pike"; cost = 39; } sales++;
				if ( selling == sales ) { name="Pitchfork"; item="Trident"; cost = 19; } sales++;
				if ( selling == sales ) { name="PlateArms"; item="Plate Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="PlateBattleKabuto"; item="Plate Battle Kabuto"; cost = 94; } sales++;
				if ( selling == sales ) { name="PlateChest"; item="Plate Chest"; cost = 243; } sales++;
				if ( selling == sales ) { name="PlateDo"; item="Plate Do"; cost = 310; } sales++;
				if ( selling == sales ) { name="PlateGloves"; item="Plate Gloves"; cost = 155; } sales++;
				if ( selling == sales ) { name="PlateGorget"; item="Plate Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="PlateHaidate"; item="Plate Haidate"; cost = 235; } sales++;
				if ( selling == sales ) { name="PlateHatsuburi"; item="Plate Hatsuburi"; cost = 76; } sales++;
				if ( selling == sales ) { name="PlateHelm"; item="Plate Helm"; cost = 21; } sales++;
				if ( selling == sales ) { name="PlateHiroSode"; item="Plate Hiro Sode"; cost = 222; } sales++;
				if ( selling == sales ) { name="PlateLegs"; item="Plate Legs"; cost = 218; } sales++;
				if ( selling == sales ) { name="PlateMempo"; item="Plate Mempo"; cost = 76; } sales++;
				if ( selling == sales ) { name="PlateSuneate"; item="Plate Suneate"; cost = 224; } sales++;
				if ( selling == sales ) { name="RingmailArms"; item="Ringmail Arms"; cost = 85; } sales++;
				if ( selling == sales ) { name="RingmailChest"; item="Ringmail Chest"; cost = 121; } sales++;
				if ( selling == sales ) { name="RingmailGloves"; item="Ringmail Gloves"; cost = 93; } sales++;
				if ( selling == sales ) { name="RingmailLegs"; item="Ringmail Legs"; cost = 90; } sales++;
				if ( selling == sales ) { name="RoyalArms"; item="Royal Arms"; cost = 188; } sales++;
				if ( selling == sales ) { name="RoyalBoots"; item="Royal Boots"; cost = 40; } sales++;
				if ( selling == sales ) { name="RoyalChest"; item="Royal Chest"; cost = 242; } sales++;
				if ( selling == sales ) { name="RoyalGloves"; item="Royal Gloves"; cost = 144; } sales++;
				if ( selling == sales ) { name="RoyalGorget"; item="Royal Gorget"; cost = 104; } sales++;
				if ( selling == sales ) { name="RoyalHelm"; item="Royal Helm"; cost = 20; } sales++;
				if ( selling == sales ) { name="RoyalShield"; item="Royal Shield"; cost = 230; } sales++;
				if ( selling == sales ) { name="RoyalsLegs"; item="Royal Legs"; cost = 218; } sales++;
				if ( selling == sales ) { name="RoyalSword"; item="Royal Sword"; cost = 55; } sales++;
				if ( selling == sales ) { name="Sai"; item="Sai"; cost = 56; } sales++;
				if ( selling == sales ) { name="Scepter"; item="Scepter"; cost = 39; } sales++;
				if ( selling == sales ) { name="Sceptre"; item="Sceptre"; cost = 38; } sales++;
				if ( selling == sales ) { name="Scimitar"; item="Scimitar"; cost = 36; } sales++;
				if ( selling == sales ) { name="Scythe"; item="Scythe"; cost = 39; } sales++;
				if ( selling == sales ) { name="ShortSpear"; item="Short Spear"; cost = 23; } sales++;
				if ( selling == sales ) { name="ShortSword"; item="Short Sword"; cost = 35; } sales++;
				if ( selling == sales ) { name="BoneHarvester"; item="Sickle"; cost = 35; } sales++;
				if ( selling == sales ) { name="SkinningKnife"; item="Skinning Knife"; cost = 14; } sales++;
				if ( selling == sales ) { name="SmallPlateJingasa"; item="Small Plate Jingasa"; cost = 66; } sales++;
				if ( selling == sales ) { name="Spear"; item="Spear"; cost = 31; } sales++;
				if ( selling == sales ) { name="SpikedClub"; item="Spiked Club"; cost = 28; } sales++;
				if ( selling == sales ) { name="StandardPlateKabuto"; item="Standard Plate Kabuto"; cost = 74; } sales++;
				if ( selling == sales ) { name="WizardStaff"; item="Stave"; cost = 40; } sales++;
				if ( selling == sales ) { name="ThinLongsword"; item="Sword"; cost = 27; } sales++;
				if ( selling == sales ) { name="Tekagi"; item="Tekagi"; cost = 55; } sales++;
				if ( selling == sales ) { name="Tessen"; item="Tessen"; cost = 83; } sales++;
				if ( selling == sales ) { name="Tetsubo"; item="Tetsubo"; cost = 43; } sales++;
				if ( selling == sales ) { name="TwoHandedAxe"; item="Two Handed Axe"; cost = 32; } sales++;
				if ( selling == sales ) { name="Wakizashi"; item="Wakizashi"; cost = 38; } sales++;
				if ( selling == sales ) { name="WarAxe"; item="War Axe"; cost = 29; } sales++;
				if ( selling == sales ) { name="RuneBlade"; item="War Blades"; cost = 55; } sales++;
				if ( selling == sales ) { name="WarCleaver"; item="War Cleaver"; cost = 25; } sales++;
				if ( selling == sales ) { name="Leafblade"; item="War Dagger"; cost = 21; } sales++;
				if ( selling == sales ) { name="WarFork"; item="War Fork"; cost = 32; } sales++;
				if ( selling == sales ) { name="WarHammer"; item="War Hammer"; cost = 24; } sales++;
				if ( selling == sales ) { name="WarMace"; item="War Mace"; cost = 31; } sales++;
			}

			if ( part == 2 ){ item = name; }
			else if ( part == 3 ){ item = ((int)(cost*markup)).ToString(); }

			return item;
		}
	}
}
