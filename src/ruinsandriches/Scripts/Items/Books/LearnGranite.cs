using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Misc;
using Server.Network;

namespace Server.Items
{
	public class LearnGraniteBook : Item
	{
		[Constructable]
		public LearnGraniteBook( ) : base( 0x02DD )
		{
			Weight = 1.0;
			Name = "Scroll of Sand and Stone";
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "The Basics of Stone and Glass Crafting" );
		}

		public class LearnGraniteGump : Gump
		{
			public LearnGraniteGump( Mobile from ): base( 50, 50 )
			{
				string color = "#ddbc4b";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9546, Server.Misc.PlayerSettings.GetGumpHue( from ));

				AddHtml( 15, 15, 600, 20, @"<BODY><BASEFONT Color=" + color + ">CRAFTING WITH SAND AND STONE</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(867, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);

				AddItem(15, 72, 6003);
				AddHtml( 50, 76, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Regular</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 114, 6003, MaterialInfo.GetMaterialColor( "dull copper", "classic", 0 ));
				AddHtml( 50, 118, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Dull Copper</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 156, 6003, MaterialInfo.GetMaterialColor( "shadow iron", "classic", 0 ));
				AddHtml( 50, 160, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Shadow Iron</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 198, 6003, MaterialInfo.GetMaterialColor( "copper", "classic", 0 ));
				AddHtml( 50, 202, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Copper</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 240, 6003, MaterialInfo.GetMaterialColor( "bronze", "classic", 0 ));
				AddHtml( 50, 244, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Bronze</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 282, 6003, MaterialInfo.GetMaterialColor( "gold", "classic", 0 ));
				AddHtml( 50, 286, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Gold</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 324, 6003, MaterialInfo.GetMaterialColor( "agapite", "classic", 0 ));
				AddHtml( 50, 328, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Agapite</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 366, 6003, MaterialInfo.GetMaterialColor( "verite", "classic", 0 ));
				AddHtml( 50, 370, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Verite</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 408, 6003, MaterialInfo.GetMaterialColor( "valorite", "classic", 0 ));
				AddHtml( 50, 412, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Valorite</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 450, 6003, MaterialInfo.GetMaterialColor( "nepturite", "classic", 0 ));
				AddHtml( 50, 454, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Nepturite</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 492, 6003, MaterialInfo.GetMaterialColor( "obsidian", "classic", 0 ));
				AddHtml( 50, 496, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Obsidian</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 534, 6003, MaterialInfo.GetMaterialColor( "mithril", "classic", 0 ));
				AddHtml( 50, 538, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Mithril</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 576, 6003, MaterialInfo.GetMaterialColor( "xormite", "classic", 0 ));
				AddHtml( 50, 580, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Xormite</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(15, 618, 6003, MaterialInfo.GetMaterialColor( "dwarven", "classic", 0 ));
				AddHtml( 50, 622, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Dwarven</BASEFONT></BODY>", (bool)false, (bool)false);

				AddHtml( 209, 67, 679, 702, @"<BODY><BASEFONT Color=" + color + ">Mining is the skill one needs to find granite within caves and mountains. With this granite, stone crafters can make stone furniture and statues. You simply need to get a pick axe or a shovel, double-click it, and then target a mountain side or caven floor. Although you will normally get regular granite, you will eventually get skilled enough to dig up other types of granite.<br><br>The many types of granite are listed here, but only their color makes them unique. So making a statue from shadow iron granite will make a blackened statue.<br><br>In order to make things from the granite, you need to first learn how to dig for it. Legends tell of the gargoyles, and how they can teach the likes of men these secrets. Then if you carpentry skill is good enough, you can begin crafting with a mallet and chisel.<br><br>Mining is also the skill one needs to find sand on beaches and desert sands. With this sand, glass blowers can make items such as bottles and jars. You simply need to get a pick axe or a shovel, double-click it, and then target a the sand at your feet. Sand comes in piles and an alchemist can use a blow pipe to create bottles, for example. This artful crafting is said to also be taught by the gargoyles.</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile;
				from.SendSound( 0x249 );
			}
		}

		public override void OnDoubleClick( Mobile e )
		{
			if ( !IsChildOf( e.Backpack ) && this.Weight != -50.0 ) 
			{
				e.SendMessage( "This must be in your backpack to read." );
			}
			else
			{
				e.CloseGump( typeof( LearnGraniteGump ) );
				e.SendGump( new LearnGraniteGump( e ) );
				e.PlaySound( 0x249 );
				Server.Gumps.MyLibrary.readBook ( this, e );
			}
		}

		public LearnGraniteBook(Serial serial) : base(serial)
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