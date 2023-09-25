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
	public class LearnLeatherBook : Item
	{
		[Constructable]
		public LearnLeatherBook( ) : base( 0x02DD )
		{
			Weight = 1.0;
			Name = "Scroll of Various Leather";
			ItemID = Utility.RandomList( 0x02DD, 0x201A );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "A Listing Of Leather" );
		}

		public class LearnLeatherGump : Gump
		{
			public LearnLeatherGump( Mobile from ): base( 50, 50 )
			{
				string color = "#ddbc4b";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9547, Server.Misc.PlayerSettings.GetGumpHue( from ));

				AddHtml( 15, 15, 398, 20, @"<BODY><BASEFONT Color=" + color + ">INFORMATION ON VARIOUS TYPES OF LEATHER</BASEFONT></BODY>", (bool)false, (bool)false);

				AddButton(567, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);

				AddItem(7, 43, 4199);
				AddHtml( 50, 50, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Regular</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 80, 4199, MaterialInfo.GetMaterialColor( "deep sea", "", 0 ));
				AddHtml( 50, 87, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Deep Sea</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 117, 4199, MaterialInfo.GetMaterialColor( "lizard", "", 0 ));
				AddHtml( 50, 124, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Lizard</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 154, 4199, MaterialInfo.GetMaterialColor( "serpent", "", 0 ));
				AddHtml( 50, 161, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Serpent</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 191, 4199, MaterialInfo.GetMaterialColor( "necrotic", "", 0 ));
				AddHtml( 50, 198, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Necrotic</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 228, 4199, MaterialInfo.GetMaterialColor( "volcanic", "", 0 ));
				AddHtml( 50, 235, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Volcanic</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 265, 4199, MaterialInfo.GetMaterialColor( "frozen", "", 0 ));
				AddHtml( 50, 272, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Frozen</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 302, 4199, MaterialInfo.GetMaterialColor( "goliath", "", 0 ));
				AddHtml( 50, 309, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Goliath</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 339, 4199, MaterialInfo.GetMaterialColor( "draconic", "", 0 ));
				AddHtml( 50, 346, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Draconic</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 376, 4199, MaterialInfo.GetMaterialColor( "hellish", "", 0 ));
				AddHtml( 50, 383, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Hellish</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 413, 4199, MaterialInfo.GetMaterialColor( "dinosaur", "", 0 ));
				AddHtml( 50, 420, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Dinosaur</BASEFONT></BODY>", (bool)false, (bool)false);
				AddItem(7, 450, 4199, MaterialInfo.GetMaterialColor( "alien", "", 0 ));
				AddHtml( 50, 457, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Alien</BASEFONT></BODY>", (bool)false, (bool)false);

				AddHtml( 192, 47, 400, 467, @"<BODY><BASEFONT Color=" + color + ">There are various types of hides you may acquire from skinning creatures throughout the land. For some examples - snakes have serpent hides, lizardmen have lizard hides, sea serpents have deep sea hides, polar bears have frozen hides, lava lizards have volcanic hides, dragons have draconic hides, zombies have necrotic hides, demons have hellish hides, and giants have goliath hides. Each type of hide is different in color, but also has various levels of protection when creating clothing with it.<br><br>The many types of leather are listed here, starting up and then going down to higher quality leather. Making a tunic out of draconic leather will be a much better tunic than one made of lizard leather, for example. <br><br>A tailor would need a certain skill level to work with each of these types of leather. Hides can be obtained from skinning certain creatures by double clickin a bladed weapon and then targeting a corpse. These hides can then be cut with scissors and made into sheets of leather. Then a sewing kit can be used to craft the leather into various armor and bags.</BASEFONT></BODY>", (bool)false, (bool)false);
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
				e.CloseGump( typeof( LearnLeatherGump ) );
				e.SendGump( new LearnLeatherGump( e ) );
				e.PlaySound( 0x249 );
				Server.Gumps.MyLibrary.readBook ( this, e );
			}
		}

		public LearnLeatherBook(Serial serial) : base(serial)
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
