using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
	public class Actions : Item
	{
		private int m_Acts;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Acts{ get{ return m_Acts; } set{ m_Acts = value; } }

		[Constructable]
		public Actions() : base( 0x8AB )
		{
			Movable = false;
		}

		public Actions( Serial serial ) : base( serial )
		{
		}

		public bool facingNS( Mobile m )
		{
			if ( this.X == m.X )
				return true;

			return false;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !(from is BaseVendor ) )
				return;

			bool PlayRegular = true;
			bool PlayRepetitive = Utility.RandomBool();

			from.Direction = from.GetDirectionTo( GetWorldLocation() );

			if ( from is LeatherWorker || from is Tanner )
			{
				if ( ItemID == 0x1069 || ItemID == 0x106A || ItemID == 0x107A || ItemID == 0x107B )
				{
					if ( ItemID == 0x1069 ){ ItemID = 0x106A; }
					else if ( ItemID == 0x106A ){ ItemID = 0x1069; }
					else if ( ItemID == 0x107A ){ ItemID = 0x107B; }
					else if ( ItemID == 0x107B ){ ItemID = 0x107A; }
					Name = "stretched hide";
					from.Animate( 230, 5, 1, true, false, 0 ); 

					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else
				{
					Name = "leather";
					if ( m_Acts == 1 )
					{
						ItemID = Utility.RandomList( 0x13C5, 0x13C6, 0x13C7, 0x13CB, 0x13CC, 0x13CD, 0x13CE, 0x13D2, 0x13D3, 0x1DB9, 0x1DBA, 0x13D4, 0x13D5, 0x13D6, 0x13DA, 0x13DB, 0x13DC, 0x13DD, 0x13E1, 0x13E2 );
						from.PlaySound( 0x248 );
						m_Acts = 0;
						from.Animate( 230, 5, 1, true, false, 0 );
					}
					else
					{
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );

						ItemID = Utility.RandomList( 0x1067, 0x1068, 0x1081, 0x1082 );
						m_Acts = 1;
						from.Animate( 230, 5, 1, true, false, 0 );
					}
				}
			}
			else if ( from is Butcher )
			{
				EquipVendor( from, "cleaver" );
				Name = "carcass";
				BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
				weapon.PlaySwingAnimation( from );
				new Blood().MoveToWorld( Location, Map );
				from.PlaySound( 0x133 );
			}
			else if ( from is GypsyLady )
			{
				Name = "cards";
				from.PlaySound( 0x3D1 );
				ItemID++;
				if ( ItemID > 25896 )
					ItemID = 25891;
			}
			else if ( from is Alchemist )
			{
				if ( ItemID >= 0x5760 && ItemID <= 0x5769 )
				{
					Name = "cauldron";
					Hue = Utility.RandomTalkHue();
					from.PlaySound( Utility.RandomList( 0x020, 0x025, 0x04E ) );
					from.Animate( 230, 5, 1, true, false, 0 );
				}
				else if ( ItemID == 0x2827 )
				{
					Name = "bottle";

					if ( m_Acts == 1 )
					{
						Hue = Utility.RandomTalkHue();
						from.PlaySound( 0x240 );
						from.Animate( 230, 5, 1, true, false, 0 );
						m_Acts = 0;
					}
					else
					{
						from.PlaySound( 0x242 );
						m_Acts = 1;
					}
				}
			}
			else if ( from is Bowyer )
			{
				EquipVendor( from, "none" );
				if ( m_Acts == 1 )
				{
					m_Acts = 0;
					switch ( Utility.Random( 4 ) )
					{
						case 0: Name = "arrows"; 	ItemID = Utility.RandomList( 0xF40, 0xF41 );	break;
						case 1: Name = "bolts"; 	ItemID = Utility.RandomList( 0x1BFC, 0x1BFD );	break;
						case 2: Name = "crossbow"; 	ItemID = Utility.RandomList( 0x13FC, 0x13FD, 0xF4F, 0xF50 );	break;
						case 3: Name = "bow"; 		ItemID = Utility.RandomList( 0x13B1, 0x13B2 );	break;
					}
					from.PlaySound( 0x55 );
					from.Animate( 230, 5, 1, true, false, 0 );
				}
				else
				{
					m_Acts = 1;
					Name = "wood";
					ItemID = Utility.RandomList( 0x1BD8, 0x1BD9, 0x1BDB, 0x1BDC );
					from.Animate( 230, 5, 1, true, false, 0 );
					if ( PlayRegular )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
			}
			else if ( from is Fisherman )
			{
				if ( ItemID == 0x1797 )
				{
					EquipVendor( from, "pole" );
					Name = "water";
					from.Animate( 12, 5, 1, true, false, 0 );   
					Effects.SendLocationEffect( this.Location, this.Map, 0x352D, 16, 4 );
					Effects.PlaySound( this.Location, this.Map, 0x364 );
					((BaseVendor)from).m_NextAction = (DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 20 ) ) );
				}
				else if ( ItemID == 0x9CC || ItemID == 0x9CD || ItemID == 0x1E15 || ItemID == 0x1E16 || ItemID == 0x1E17 || ItemID == 0x1E18 || ItemID == 0x97A )
				{
					EquipVendor( from, "cleaver" );
					Name = "fish";
					BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );

					if ( m_Acts == 0 )
					{
						m_Acts++;
						if ( facingNS( from ) )
							ItemID = 0x9CC;
						else
							ItemID = 0x9CD;

						from.Animate( 230, 5, 1, true, false, 0 );
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
					else if ( m_Acts == 1 )
					{
						m_Acts++;
						if ( facingNS( from ) )
							ItemID = 0x1E15;
						else
							ItemID = 0x1E16;

						weapon.PlaySwingAnimation( from );
						new Blood().MoveToWorld( Location, Map );
						from.PlaySound( 0x133 );
					}
					else if ( m_Acts == 2 )
					{
						m_Acts++;
						if ( facingNS( from ) )
							ItemID = 0x1E17;
						else
							ItemID = 0x1E18;

						weapon.PlaySwingAnimation( from );
						new Blood().MoveToWorld( Location, Map );
						from.PlaySound( 0x133 );
					}
					else
					{
						m_Acts = 0;
						ItemID = 0x97A;
						weapon.PlaySwingAnimation( from );
						from.PlaySound( 0x133 );
					}
				}
			}
			else if ( from is Cook )
			{
				if ( ItemID == 0x568D || ItemID == 0x568E || ItemID == 0x568B || ItemID == 0x568C )
				{
					Name = "skillet";
					if ( m_Acts == 1 )
					{
						m_Acts = 0;

						if ( ItemID == 0x568D )
							ItemID = 0x568E;
						else
							ItemID = 0x568B;

						from.Animate( 230, 5, 1, true, false, 0 );
						from.PlaySound( 0x345 );
					}
					else
					{
						m_Acts = 1;
						ItemID = Utility.RandomList( 0x568C, 0x568D );
						from.Animate( 230, 5, 1, true, false, 0 );
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
				}
				else
				{
					if ( m_Acts == 1 )
					{
						m_Acts = 0;
						Name = "bowl of food";

						if ( ItemID == 0x15F8 )
							ItemID = Utility.RandomList( 0x15F9, 0x15FA, 0x15FB, 0x15FC );
						else
							ItemID = Utility.RandomList( 0x15FE, 0x15FF, 0x1600, 0x1601, 0x1602 );

						from.Animate( 230, 5, 1, true, false, 0 );
						if ( PlayRepetitive )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
					else
					{
						m_Acts = 1;
						Name = "bowl";
						ItemID = Utility.RandomList( 0x15F8, 0x15FD );
						from.Animate( 230, 5, 1, true, false, 0 );
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
				}
			}
			else if ( from is Herbalist )
			{
				Hue = 0x49E;
				Name = "pot";

				if ( m_Acts == 0 )
				{
					ItemID = 0x6529;
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts++;
					if ( PlayRegular )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else if ( m_Acts == 1 )
				{
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts++;
					from.PlaySound( 0x025 );
					ItemID = 0x653A;
				}
				else if ( m_Acts == 2 )
				{
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts++;
					ItemID = 0x653B;
					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else if ( m_Acts == 3 )
				{
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts++;
					ItemID = 0x653C;
					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else if ( m_Acts == 4 )
				{
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts++;
					ItemID = 0x653D;
					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else
				{
					Name = "potted plant";
					ItemID = Utility.RandomMinMax( 0x652A, 0x6539 );
					m_Acts = 0;
				}
			}
			else if ( from is Tailor || from is Weaver )
			{
				Name = "cloth";

				if ( m_Acts == 0 )
				{
					ItemID = Utility.RandomMinMax( 0x175D, 0x1768 );
					Hue = Utility.RandomColor(0);
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts = 1;
					if ( PlayRegular )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else
				{
					Name = "clothing";
					ItemID = Utility.RandomList( 0x1517, 0x1518, 0x1EFD, 0x1EFE, 0x1F9F, 0x1FA0, 0x1537, 0x1538, 0x152F, 0x1531, 0x1516, 0x152E, 0x1713, 0x1715, 0x1718, 0x171A, 0x171C );
					from.PlaySound( 0x248 );
					from.Animate( 230, 5, 1, true, false, 0 ); 
					m_Acts = 0;
				}
			}
			else if ( from is Tinker )
			{
				Name = "clock";

				if ( ItemID == 0x104B || ItemID == 0x104C )
				{
					ItemID = Utility.RandomList( 0xC1F, 0x104D, 0x104E, 0x104F, 0x1050 );
					from.Animate( 230, 5, 1, true, false, 0 ); 
					if ( PlayRegular )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else
				{
					ItemID = Utility.RandomList( 0x104B, 0x104C );
					from.PlaySound( 0x241 );
					from.Animate( 230, 5, 1, true, false, 0 ); 
				}
			}
			else if ( from is Lumberjack || from is Carpenter )
			{
				if ( ItemID == 0x653E || ItemID == 0x653E || ItemID == 0x1BE1 || ItemID == 0x1BDE )
				{
					EquipVendor( from, "axe" );
					if ( m_Acts == 0 )
					{
						m_Acts = 1;
						Name = "log";
						from.Animate( 230, 5, 1, true, false, 0 ); 
						ItemID = 0x653E;
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
					else if ( m_Acts == 1 )
					{
						m_Acts = 2;
						Name = "logs";
						BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.TwoHanded ) );
						weapon.PlaySwingAnimation( from );
						from.PlaySound( 0x13E );
						ItemID = Utility.RandomList( 0x1BDE, 0x1BE1 );
					}
					else 
					{
						m_Acts = 0;
						Name = "boards";
						BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.TwoHanded ) );
						weapon.PlaySwingAnimation( from );
						from.PlaySound( 0x13E );
						ItemID = 0x653E;
					}
				}
				else
				{
					EquipVendor( from, "hammer" );
					Name = "furniture";
					if ( m_Acts == 0 )
					{
						Name = "wood";
						m_Acts = 1;
						from.Animate( 230, 5, 1, true, false, 0 ); 
						ItemID = Utility.RandomList( 0x1BD8, 0x1BD9, 0x1BDB, 0x1BDC );
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
					else if ( m_Acts == 1 )
					{
						from.PlaySound( 0x23D );
						m_Acts = 2;
						if ( facingNS( from ) )
							ItemID = Utility.RandomList( 0x1E6F, 0x1E71, 0x1E76, 0x1E80 );
						else
							ItemID = Utility.RandomList( 0x1E78, 0x1E7A, 0x1E7E, 0x1E81 );

						BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
						weapon.PlaySwingAnimation( from );
					}
					else
					{
						from.PlaySound( 0x23D );
						m_Acts = 0;

						switch ( ItemID )
						{
							case 0x1E6F: Name = "chair";	ItemID = 0x0B4F; break;
							case 0x1E71: Name = "drawers";	ItemID = 0x0A2C; break;
							case 0x1E76: Name = "shelf";	ItemID = 0x0A9D; break;
							case 0x1E80: Name = "crate";	ItemID = 0x1FFF; break;
							case 0x1E78: Name = "chair";	ItemID = 0x0B4E; break;
							case 0x1E7A: Name = "drawers";	ItemID = 0x0A34; break;
							case 0x1E7E: Name = "shelf";	ItemID = 0x0A9E; break;
							case 0x1E81: Name = "crate";	ItemID = 0x0E7E; break;
						}
						BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
						weapon.PlaySwingAnimation( from );
					}
				}
			}
			else if ( from is Baker )
			{
				if ( m_Acts == 0 )
				{
					Name = "flour";
					m_Acts = 1;
					from.Animate( 230, 5, 1, true, false, 0 ); 

					ItemID = Utility.RandomList( 0x1039, 0x1045 );

					if ( PlayRegular )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else if ( m_Acts == 1 )
				{
					Name = "flour";
					m_Acts = 2;
					from.Animate( 230, 5, 1, true, false, 0 ); 

					ItemID = Utility.RandomList( 0x103A, 0x1046 );

					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else if ( m_Acts == 2 )
				{
					Name = "dough";
					m_Acts = 3;
					from.Animate( 230, 5, 1, true, false, 0 ); 
					ItemID = 0xA1E;
					from.PlaySound( 0x242 );
				}
				else if ( m_Acts == 3 )
				{
					if ( Utility.RandomBool() )
					{
						Name = "dough";
						ItemID = 0x103D;
					}
					else
					{
						Name = "cookie mix";
						ItemID = 0x103F;
					}
					m_Acts = 4;
					from.Animate( 230, 5, 1, true, false, 0 ); 

					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
				else
				{
					m_Acts = 0;
					if ( ItemID == 0x103D ){ Name = "bread"; ItemID = Utility.RandomList( 0x103C, 0x98C ); }
					else { Name = "cookies"; ItemID = Utility.RandomList( 0x160B, 0x160C ); }
					from.Animate( 230, 5, 1, true, false, 0 ); 

					if ( PlayRepetitive )
						from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
				}
			}
			else if ( from is Miner || from is Blacksmith || from is Weaponsmith || from is IronWorker || from is Armorer )
			{
				if ( ItemID == 0x1775 || ItemID == 0x1776 || ItemID == 0x1777 || ItemID == 0x1778 || ItemID == 0x19B9 )
				{
					EquipVendor( from, "pick" );
					Name = "rock";
					BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
					weapon.PlaySwingAnimation( from );
					from.PlaySound( Utility.RandomList( 0x125, 0x126 ) );

					if ( m_Acts == 0 ){ ItemID = 0x1776; m_Acts++; }
					else if ( m_Acts == 1 ){ ItemID = 0x1775; m_Acts++; }
					else if ( m_Acts == 2 ){ ItemID = 0x1777; m_Acts++; }
					else if ( m_Acts == 3 ){ ItemID = 0x1778; m_Acts++; }
					else { ItemID = 0x19B9; m_Acts = 0; }
				}
				else if ( ItemID == 0x19B8 || ( ItemID >= 0x1BEF && ItemID <= 0x1BF4 ) )
				{
					EquipVendor( from, "none" );
					if ( ItemID == 0x19B8 )
					{
						if ( facingNS( from ) )
							ItemID = Utility.RandomMinMax( 0x1BF2, 0x1BF4 );
						else
							ItemID = Utility.RandomMinMax( 0x1BEF, 0x1BF1 );

						Name = "ingots";
						from.Animate( 230, 5, 1, true, false, 0 );   
						from.PlaySound( Utility.RandomList( 0x02B, 0x047, 0x208 ) );
					}
					else
					{
						ItemID = 0x19B8;
						Name = "ore";
						from.Animate( 230, 5, 1, true, false, 0 ); 
						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
				}
				else
				{
					EquipVendor( from, "hammer" );
					Name = "anvil";
					if ( m_Acts == 0 )
					{
						m_Acts = 1;
							if ( Utility.RandomBool() )
								m_Acts = 2;

						from.Animate( 230, 5, 1, true, false, 0 ); 

						if ( facingNS( from ) )
							ItemID = 0x64F7;
						else
							ItemID = 0x650D;

						if ( PlayRegular )
							from.PlaySound( Utility.RandomList( 0x059, 0x057 ) );
					}
					else if ( m_Acts == 1 )
					{
						from.PlaySound( 0x2A );
						m_Acts = 2;
						BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
						weapon.PlaySwingAnimation( from );
					}
					else
					{
						from.PlaySound( 0x2A );
						m_Acts = 0;
						if ( from is Weaponsmith )
						{
							if ( facingNS( from ) )
								ItemID = Utility.RandomList( 25843, 25844, 25845, 25846, 25851, 25852, 25853, 25854, 25855, 25856, 25857, 25858 );
							else
								ItemID = Utility.RandomList( 25865, 25866, 25867, 25868, 25873, 25874, 25875, 25876, 25877, 25878, 25879, 25880 );
						}
						else if ( from is Armorer )
						{
							if ( facingNS( from ) )
								ItemID = Utility.RandomList( 25837, 25838, 25839, 25840, 25841, 25842, 25848, 25849, 25850 );
							else
								ItemID = Utility.RandomList( 25859, 25860, 25861, 25862, 25863, 25864, 25870, 25871, 25872 );
						}
						else
						{
							if ( facingNS( from ) )
								ItemID = Utility.RandomList( 25837, 25838, 25839, 25840, 25841, 25842, 25848, 25849, 25850, 25843, 25844, 25845, 25846, 25851, 25852, 25853, 25854, 25855, 25856, 25857, 25858 );
							else
								ItemID = Utility.RandomList( 25859, 25860, 25861, 25862, 25863, 25864, 25870, 25871, 25872, 25865, 25866, 25867, 25868, 25873, 25874, 25875, 25876, 25877, 25878, 25879, 25880 );
						}
						BaseWeapon weapon = ( BaseWeapon )( from.FindItemOnLayer( Layer.OneHanded ) );
						weapon.PlaySwingAnimation( from );
					}
				}
			}
			else if ( from is Bard || from is Minstrel )
			{
				if ( m_Acts == 0 )
				{
					SetInstrument( from, this );
					m_Acts = 1;
				}
				else
				{
					m_Acts = 0;
					if ( this.Name == "flute" ){ from.PlaySound( 0x502 ); }
					else if ( this.Name == "harp" ){ from.PlaySound( 0x45 ); }
					else if ( this.Name == "drum" ){ from.PlaySound( 0x38 ); }
					else if ( this.Name == "tambourine" ){ from.PlaySound( 0x52 ); }
					else if ( this.Name == "lute" ){ from.PlaySound( 0x4C ); }
					else if ( this.Name == "pipes" ){ from.PlaySound( 0x5B8 ); }
				}
			}
		}

		public static void EquipVendor( Mobile m, string item )
		{
			Item one = m.FindItemOnLayer( Layer.OneHanded );
				if ( one == null )
					one = m.FindItemOnLayer( Layer.FirstValid );
			Item two = m.FindItemOnLayer( Layer.TwoHanded );

			if ( item == "none" )
			{
				ClearHands( m );
			}
			else if ( item == "cleaver" && !(one is Cleaver) )
			{
				ClearHands( m );
				m.AddItem( new Cleaver() );
			}
			else if ( item == "bow" && !(two is BaseRanged) )
			{
				ClearHands( m );
				switch ( Utility.Random( 4 ) )
				{
					case 0: m.AddItem( new Bow() );	break;
					case 1: m.AddItem( new Bow() );	break;
					case 2: m.AddItem( new Crossbow() );	break;
					case 3: m.AddItem( new HeavyCrossbow() );	break;
				}
			}
			else if ( item == "pole" && !(two is FishingPole) )
			{
				ClearHands( m );
				m.AddItem( new FishingPole() );
			}
			else if ( item == "pick" && !(two is Pickaxe) )
			{
				ClearHands( m );
				m.AddItem( new Pickaxe() );
			}
			else if ( item == "axe" && !(two is Hatchet) )
			{
				ClearHands( m );
				m.AddItem( new Hatchet() );
			}
			else if ( item == "hammer" && !(one is Club) )
			{
				ClearHands( m );
				Item hammer = new Club();
				hammer.Name = "hammer";
				hammer.ItemID = 0x13E3;
				m.AddItem( hammer );
			}
		}

		public static void ClearHands( Mobile m )
		{
			Item one = m.FindItemOnLayer( Layer.OneHanded );
				if ( one == null )
					one = m.FindItemOnLayer( Layer.FirstValid );
			Item two = m.FindItemOnLayer( Layer.TwoHanded );

			if ( one != null ) { one.Delete(); }
			if ( two != null ) { two.Delete(); }
		}

		public static void SetInstrument( Mobile from, Item instrument )
		{
			string facing = "east";

			if ( from.X == instrument.X )
				facing = "south";

			if ( facing == "south" )
			{
				switch ( Utility.Random( 6 ) )
				{
					case 0:	instrument.ItemID = 0x64BF;	instrument.Name = "lute"; 		instrument.Z = from.Z + 9;	break;
					case 1:	instrument.ItemID = 0x64C1; instrument.Name = "flute"; 		instrument.Z = from.Z + 11;	break;
					case 2:	instrument.ItemID = 0x64C3;	instrument.Name = "harp"; 		instrument.Z = from.Z + 9;	break;
					case 3:	instrument.ItemID = 0x64C5; instrument.Name = "drum"; 		instrument.Z = from.Z + 7;	break;
					case 4:	instrument.ItemID = 0x64C9; instrument.Name = "tambourine"; instrument.Z = from.Z + 9;	break;
					case 5:	instrument.ItemID = 0x64CD; instrument.Name = "pipes"; 		instrument.Z = from.Z + 9;	break;
				}
			}
			else
			{
				switch ( Utility.Random( 6 ) )
				{
					case 0:	instrument.ItemID = 0x64BE;	instrument.Name = "lute"; 		instrument.Z = from.Z + 9;	break;
					case 1:	instrument.ItemID = 0x64C0; instrument.Name = "flute"; 		instrument.Z = from.Z + 11;	break;
					case 2:	instrument.ItemID = 0x64C2; instrument.Name = "harp"; 		instrument.Z = from.Z + 9;	break;
					case 3:	instrument.ItemID = 0x64C4; instrument.Name = "drum"; 		instrument.Z = from.Z + 7;	break;
					case 4:	instrument.ItemID = 0x64C8; instrument.Name = "tambourine"; instrument.Z = from.Z + 9;	break;
					case 5:	instrument.ItemID = 0x64CC; instrument.Name = "pipes"; 		instrument.Z = from.Z + 9;	break;
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_Acts );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Acts = reader.ReadInt();
		}
	}
}