using System;
using Server;
using System.Collections.Generic;
using Server.Commands;
using Server.Engines.Craft;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class MyNecromancerSpellbook : NecromancerSpellbook
	{
		[Constructable]
		public MyNecromancerSpellbook()
		{
			Hue = Utility.RandomEvilHue();

			string sEvil = "Evil";
			switch ( Utility.RandomMinMax( 0, 7 ) )
			{
				case 0: sEvil = "Evil";			break;
				case 1: sEvil = "Vile";			break;
				case 2: sEvil = "Sinister";		break;
				case 3: sEvil = "Wicked";		break;
				case 4: sEvil = "Corrupt";		break;
				case 5: sEvil = "Hateful";		break;
				case 6: sEvil = "Malevolent";	break;
				case 7: sEvil = "Nefarious";	break;
			}

			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + sEvil + " Spellbook";			break;
				case 1: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of " + sEvil + " Spells";		break;
				case 2: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of " + sEvil + " Magic";		break;
				case 3: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of " + sEvil + " Witchery";		break;
			}

			this.Content = (ulong)( Utility.RandomMinMax( 0, (int)(ulong)0x1FFFF ) );

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MyNecromancerSpellbook( Serial serial ) : base( serial )
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

	public class MyElementalSpellbook : ElementalSpellbook ////////////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MyElementalSpellbook()
		{
			Hue = 0;

			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + " Spellbook";			break;
				case 1: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the Elements";	break;
				case 2: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of Elemental Magic";	break;
				case 3: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of Elementalism";	break;
			}

			switch ( Utility.Random( 12 ) )
			{
				case 0: this.Content = 0xF;			break;
				case 1: this.Content = 0xFF;		break;
				case 2: this.Content = 0xFFF;		break;
				case 3: this.Content = 0xFFFF;		break;
				case 4: this.Content = 0xFFFFF;		break;
				case 5: this.Content = 0xFFFFFF;	break;
				case 6: this.Content = 0xFFFFFFF;	break;
				case 7: this.Content = 0xFFFFFFFF;	break;
			}

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MyElementalSpellbook( Serial serial ) : base( serial )
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

	public class MySpellbook : Spellbook ////////////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MySpellbook()
		{
			Hue = Utility.RandomColor(0);

			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " Spellbook";			break;
				case 1: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of Spells";		break;
				case 2: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of Magic";		break;
				case 3: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of Wizardry";	break;
			}

			switch ( Utility.Random( 20 ) )
			{
				case 0: this.Content = 0xF;					break;
				case 1: this.Content = 0xFF;				break;
				case 2: this.Content = 0xFFF;				break;
				case 3: this.Content = 0xFFFF;				break;
				case 4: this.Content = 0xFFFFF;				break;
				case 5: this.Content = 0xFFFFFF;			break;
				case 6: this.Content = 0xFFFFFFF;			break;
				case 7: this.Content = 0xFFFFFFFF;			break;
				case 8: this.Content = 0xFFFFFFFFF;			break;
				case 9: this.Content = 0xFFFFFFFFFF;		break;
				case 10: this.Content = 0xFFFFFFFFFFF;		break;
				case 11: this.Content = 0xFFFFFFFFFFFF;		break;
				case 12: this.Content = 0xFFFFFFFFFFFFF;	break;
				case 13: this.Content = 0xFFFFFFFFFFFFFF;	break;
				case 14: this.Content = 0xFFFFFFFFFFFFFFF;	break;
				case 15: this.Content = 0xFFFFFFFFFFFFFFFF;	break;
			}

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MySpellbook( Serial serial ) : base( serial )
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

	public class MyNinjabook : BookOfNinjitsu ///////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MyNinjabook()
		{
			Hue = Utility.RandomColor(0);

			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the Ninja Arts";	break;
				case 1: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of Ninjitsu";			break;
				case 2: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the Ninja";		break;
				case 3: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the Ninja Way";	break;
			}

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MyNinjabook( Serial serial ) : base( serial )
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

	public class MySamuraibook : BookOfBushido //////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MySamuraibook()
		{
			Hue = Utility.RandomColor(0);

			string Adj = "Bushido";
				if ( Utility.RandomMinMax( 0, 1 ) == 1 ){ Adj = "Samurai"; }

			switch ( Utility.RandomMinMax( 0, 2 ) )
			{
				case 0: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj + " Code";	break;
				case 1: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj;			break;
				case 2: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "orient" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj + " Way";	break;
			}

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MySamuraibook( Serial serial ) : base( serial )
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

	public class MyPaladinbook : BookOfChivalry /////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MyPaladinbook()
		{
			Hue = Utility.RandomColor(0);

			string Adj = "Knight";
			switch ( Utility.RandomMinMax( 0, 3 ) )
			{
				case 0: Adj = "Cavalier"; break;
				case 1: Adj = "Paladin"; break;
				case 2: Adj = "Knight"; break;
				case 3: Adj = "Templar"; break;
			}

			switch ( Utility.RandomMinMax( 0, 2 ) )
			{
				case 0: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj + " Code";	break;
				case 1: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj;			break;
				case 2: this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj + " Way";	break;
			}

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MyPaladinbook( Serial serial ) : base( serial )
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

	public class MySongbook : SongBook //////////////////////////////////////////////////////////////////////////////////////////////////////////////
	{
		[Constructable]
		public MySongbook()
		{
			Hue = Utility.RandomColor(0);

			string Adj = "Bard";
			switch ( Utility.RandomMinMax( 0, 6 ) )
			{
				case 0: Adj = "Bard"; break;
				case 1: Adj = "Minstrel"; break;
				case 2: Adj = "Balladeer"; break;
				case 3: Adj = "Troubadour"; break;
				case 4: Adj = "Musician"; break;
				case 5: Adj = "Poet"; break;
				case 6: Adj = "Singer"; break;
			}

			this.Name = Server.Misc.RandomThings.GetRandomBelongsTo( "regular" ) + " " + Server.Misc.RandomThings.GetRandomBookType(1) + " of the " + Adj;

			this.Content = (ulong)( Utility.RandomMinMax( 0, (int)(ulong)0xFFFF ) );

			Server.Misc.BookProperties.GetBookProperties( this, Utility.RandomMinMax(3,7), Utility.RandomMinMax(25,75) );
		}

		public MySongbook( Serial serial ) : base( serial )
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

namespace Server.Misc
{
    class BookProperties
    {
		public static void GetBookProperties( Spellbook book, int nCycle, int nChance )
		{
			int cycle = nCycle;
			int chance = nChance;
			SkillName skill = SkillName.Begging;
			SkillName skill2 = SkillName.Begging;
			bool unique = false;

			if ( book is MySpellbook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_MageSkills[Utility.Random(m_MageSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_MageSkills[Utility.Random(m_MageSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is MyNecromancerSpellbook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_NecroSkills[Utility.Random(m_NecroSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_NecroSkills[Utility.Random(m_NecroSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is MyElementalSpellbook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_ElementalSkills[Utility.Random(m_ElementalSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_ElementalSkills[Utility.Random(m_ElementalSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is DeathKnightSpellbook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_DeathSkills[Utility.Random(m_DeathSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_DeathSkills[Utility.Random(m_DeathSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is MySongbook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_BardSkills[Utility.Random(m_BardSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_BardSkills[Utility.Random(m_BardSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is MyPaladinbook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_PaladinSkills[Utility.Random(m_PaladinSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_PaladinSkills[Utility.Random(m_PaladinSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is MySamuraibook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_BushidoSkills[Utility.Random(m_BushidoSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_BushidoSkills[Utility.Random(m_BushidoSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}
			else if ( book is MyNinjabook )
			{
				if ( chance >= Utility.Random( 100 ) )
				{
					skill = m_NinjaSkills[Utility.Random(m_NinjaSkills.Length)];
					book.SkillBonuses.SetValues( 0, skill, Utility.RandomMinMax( 1, 20 ) );
					if ( chance >= Utility.Random( 200 ) )
					{
						while ( !unique )
						{
							skill2 = m_NinjaSkills[Utility.Random(m_NinjaSkills.Length)];
							book.SkillBonuses.SetValues( 1, skill2, Utility.RandomMinMax( 1, 20 ) );
							if ( skill != skill2 ){ unique = true; }
						}
					}
				}
			}

			if ( book is MyNecromancerSpellbook || book is MySpellbook )
			{
				if ( chance > Utility.Random( 100 ) )
				{
					SlayerName slayer = BaseRunicTool.GetRandomSlayer();

					if ( slayer != SlayerName.None )
					{
						book.Slayer = slayer;
					}
				}
				if ( (int)(chance/2) > Utility.Random( 100 ) )
				{
					SlayerName slayer2 = BaseRunicTool.GetRandomSlayer();

					if ( slayer2 != SlayerName.None && slayer2 != book.Slayer )
					{
						book.Slayer2 = slayer2;
					}
				}

				cycle = nCycle; chance = nChance;

				while ( cycle > 0 )
				{
					if ( chance >= Utility.RandomMinMax( 1, 100 ) )
					{
						switch ( Utility.RandomMinMax( 0, 16 ) )
						{
							case 0: book.Attributes.BonusDex = Utility.RandomMinMax( 1, 5 ); break;
							case 1: book.Attributes.BonusHits = Utility.RandomMinMax( 5,20 ); break;
							case 2: book.Attributes.BonusInt = Utility.RandomMinMax( 1, 5 ); break;
							case 3: book.Attributes.BonusMana = Utility.RandomMinMax( 5,20 ); break;
							case 4: book.Attributes.BonusStam = Utility.RandomMinMax( 5,20 ); break;
							case 5: book.Attributes.BonusStr = Utility.RandomMinMax( 1, 5 ); break;
							case 6: book.Attributes.CastRecovery = Utility.RandomMinMax( 1, 5 ); break;
							case 7: book.Attributes.CastSpeed = Utility.RandomMinMax( 1, 5 ); break;
							case 8: book.Attributes.LowerManaCost = Utility.RandomMinMax( 2, 20 ); break;
							case 9: book.Attributes.LowerRegCost = Utility.RandomMinMax( 2, 20 ); break;
							case 10: book.Attributes.Luck = Utility.RandomMinMax( 1, 20 ); break;
							case 11: book.Attributes.NightSight = 1; break;
							case 12: book.Attributes.ReflectPhysical = Utility.RandomMinMax( 5, 25 ); break;
							case 13: book.Attributes.RegenHits = Utility.RandomMinMax( 1, 5 ); break;
							case 14: book.Attributes.RegenMana = Utility.RandomMinMax( 1, 5 ); break;
							case 15: book.Attributes.RegenStam = Utility.RandomMinMax( 1, 5 ); break;
							case 16: book.Attributes.SpellDamage = Utility.RandomMinMax( 5, 25 ); break;
						}
					}

					cycle--;
					chance = chance + 25;
				}
			}
			else
			{
				cycle = nCycle; chance = nChance;

				while ( cycle > 0 )
				{
					if ( chance >= Utility.RandomMinMax( 1, 100 ) )
					{
						switch ( Utility.RandomMinMax( 0, 15 ) )
						{
							case 0: book.Attributes.BonusDex = Utility.RandomMinMax( 1, 5 ); break;
							case 1: book.Attributes.BonusHits = Utility.RandomMinMax( 5,20 ); break;
							case 2: book.Attributes.BonusInt = Utility.RandomMinMax( 1, 5 ); break;
							case 3: book.Attributes.BonusMana = Utility.RandomMinMax( 5,20 ); break;
							case 4: book.Attributes.BonusStam = Utility.RandomMinMax( 5,20 ); break;
							case 5: book.Attributes.AttackChance = Utility.RandomMinMax( 1, 15 ); break;
							case 6: book.Attributes.DefendChance = Utility.RandomMinMax( 1, 15 ); break;
							case 7: book.Attributes.EnhancePotions = Utility.RandomMinMax( 5, 25 ); break;
							case 8: book.Attributes.WeaponDamage = Utility.RandomMinMax( 1, 25 ); break;
							case 9: book.Attributes.WeaponSpeed = Utility.RandomMinMax( 1, 2 ); break;
							case 10: book.Attributes.Luck = Utility.RandomMinMax( 1, 20 ); break;
							case 11: book.Attributes.NightSight = 1; break;
							case 12: book.Attributes.ReflectPhysical = Utility.RandomMinMax( 5, 25 ); break;
							case 13: book.Attributes.RegenHits = Utility.RandomMinMax( 1, 5 ); break;
							case 14: book.Attributes.RegenMana = Utility.RandomMinMax( 1, 5 ); break;
							case 15: book.Attributes.RegenStam = Utility.RandomMinMax( 1, 5 ); break;
						}
					}

					cycle--;
					chance = chance + 25;
				}
			}

			if ( chance >= Utility.Random( 100 ) )
			{
				if ( book is DeathKnightSpellbook ){ book.SkillBonuses.SetValues( 2, m_MiscDeadSkills[Utility.Random(m_MiscDeadSkills.Length)], Utility.RandomMinMax( 1, 10 ) ); }
				else { book.SkillBonuses.SetValues( 2, m_MiscSkills[Utility.Random(m_MiscSkills.Length)], Utility.RandomMinMax( 1, 10 ) ); }
			}
		}

		private static SkillName[] m_MageSkills = new SkillName[]
			{
				SkillName.Psychology,
				SkillName.Magery,
				SkillName.MagicResist,
				SkillName.Meditation
			};

		private static SkillName[] m_ElementalSkills = new SkillName[]
			{
				SkillName.Elementalism,
				SkillName.Focus,
				SkillName.MagicResist,
				SkillName.Meditation
			};

		private static SkillName[] m_NecroSkills = new SkillName[]
			{
				SkillName.MagicResist,
				SkillName.Spiritualism,
				SkillName.Meditation,
				SkillName.Necromancy
			};

		private static SkillName[] m_NinjaSkills = new SkillName[]
			{
				SkillName.Hiding,
				SkillName.Tactics,
				SkillName.Poisoning,
				SkillName.Swords,
				SkillName.Fencing,
				SkillName.Stealth,
				SkillName.Ninjitsu
			};

		private static SkillName[] m_BushidoSkills = new SkillName[]
			{
				SkillName.Bushido,
				SkillName.Tactics,
				SkillName.Focus,
				SkillName.Swords,
				SkillName.Healing,
				SkillName.Parry
			};

		private static SkillName[] m_PaladinSkills = new SkillName[]
			{
				SkillName.Knightship,
				SkillName.Tactics,
				SkillName.Focus,
				SkillName.Swords,
				SkillName.Healing,
				SkillName.Parry
			};

		private static SkillName[] m_BardSkills = new SkillName[]
			{
				SkillName.Discordance,
				SkillName.Musicianship,
				SkillName.Peacemaking,
				SkillName.Provocation
			};

		private static SkillName[] m_DeathSkills = new SkillName[]
			{
				SkillName.Knightship,
				SkillName.Tactics,
				SkillName.Focus,
				SkillName.Swords,
				SkillName.Parry
			};

		private static SkillName[] m_MiscDeadSkills = new SkillName[]
			{
				SkillName.Alchemy,
				SkillName.Marksmanship,
				SkillName.Searching,
				SkillName.Fencing,
				SkillName.Forensics,
				SkillName.Lockpicking,
				SkillName.Poisoning,
				SkillName.Bludgeoning,
				SkillName.RemoveTrap,
				SkillName.MagicResist,
				SkillName.Spiritualism,
				SkillName.Meditation,
				SkillName.Necromancy
			};

		private static SkillName[] m_MiscSkills = new SkillName[]
			{
				SkillName.Alchemy,
				SkillName.Anatomy,
				SkillName.Druidism,
				SkillName.Taming,
				SkillName.Marksmanship,
				SkillName.ArmsLore,
				SkillName.Begging,
				SkillName.Blacksmith,
				SkillName.Camping,
				SkillName.Carpentry,
				SkillName.Cartography,
				SkillName.Cooking,
				SkillName.Searching,
				SkillName.Fencing,
				SkillName.Seafaring,
				SkillName.Bowcraft,
				SkillName.Forensics,
				SkillName.Herding,
				SkillName.Inscribe,
				SkillName.Mercantile,
				SkillName.Lockpicking,
				SkillName.Lumberjacking,
				SkillName.Bludgeoning,
				SkillName.Mining,
				SkillName.RemoveTrap,
				SkillName.Snooping,
				SkillName.Stealing,
				SkillName.Tailoring,
				SkillName.Tasting,
				SkillName.Tinkering,
				SkillName.Tracking,
				SkillName.Veterinary,
				SkillName.FistFighting
			};
	}
}
