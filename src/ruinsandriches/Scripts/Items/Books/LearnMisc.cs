using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class LearnMiscBook : Item
	{
		[Constructable]
		public LearnMiscBook( ) : base( 0x02DD )
		{
			Weight = 1.0;
			Name = "Scroll of Skinning";
			ItemID = Utility.RandomList( 0x02DD, 0x201A );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "A Basic Guide To Skinning Creatures" );
		}

		public class LearnMiscGump : Gump
		{
			public LearnMiscGump( Mobile from ): base( 50, 50 )
			{
				string color = "#ddbc4b";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9547, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 15, 15, 398, 20, @"<BODY><BASEFONT Color=" + color + ">SKINNING ANIMALS & CREATURES</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(567, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 19, 47, 573, 467, @"<BODY><BASEFONT Color=" + color + ">Use a bladed item, like a dagger or knife, on a corpse by double-clicking the bladed item and then selecting the corpse. If there is something to be skinned from it, it will appear in their pack. You may get items such as meat, feathers, hides, wool, or reptile scales. Animals are the best source of meat. To find feathers, birds are the obvious choice, but creatures like harpies also have feathers when skinned. Different types of hides can be found on many creatures like animals, reptiles, serpents, giants, demons, sea creatures, and dragons. You can use meat for nourishment, feathers to make arrows, wool for tailoring, hides to make leather armor, or reptile scales to make scalemail armor. The better your forensics skill, the more you can carve from a corpse.</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(17, 444, 2545);
				AddItem(27, 492, 19662);
				AddHtml( 62, 444, 110, 20, @"<BODY><BASEFONT Color=" + color + ">Meat</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 62, 485, 110, 20, @"<BODY><BASEFONT Color=" + color + ">Feathers</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(225, 453, 4216);
				AddHtml( 282, 460, 110, 20, @"<BODY><BASEFONT Color=" + color + ">Hides</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(484, 485, 3576);
				AddItem(486, 443, 9905);
				AddHtml( 533, 444, 110, 20, @"<BODY><BASEFONT Color=" + color + ">Scales</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 533, 485, 110, 20, @"<BODY><BASEFONT Color=" + color + ">Wool</BASEFONT></BODY>", (bool)false, (bool)false);
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
				e.CloseGump( typeof( LearnMiscGump ) );
				e.SendGump( new LearnMiscGump( e ) );
				e.PlaySound( 0x249 );
				Server.Gumps.MyLibrary.readBook ( this, e );
			}
		}

		public LearnMiscBook(Serial serial) : base(serial)
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
