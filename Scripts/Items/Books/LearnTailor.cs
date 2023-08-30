using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class LearnTailorBook : Item
	{
		[Constructable]
		public LearnTailorBook( ) : base( 0x02DD )
		{
			Weight = 1.0;
			Name = "Scroll of Tailoring";
			ItemID = Utility.RandomList( 0x02DD, 0x201A );
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			list.Add( "A Basic Guide to Tailoring" );
		}

		public class LearnTailorGump : Gump
		{
			public LearnTailorGump( Mobile from ): base( 50, 50 )
			{
				string color = "#ddbc4b";

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 9547, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 15, 15, 398, 20, @"<BODY><BASEFONT Color=" + color + ">BASIC GUIDE TO TAILORING</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(567, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 15, 49, 573, 333, @"<BODY><BASEFONT Color=" + color + ">You can sheer sheep with a bladed weapon to get wool by double clicking the weapon and then targeting the sheep. You can also find gardens that grow cotton and flax. You can gather these by double clicking the plants and then the plants will be placed in your pack. Once gathered, you can use them on a spinning wheel to make yarn and spools of thread.<br><br>Once you have the yarn or thread, you can use those on a loom to make bolts of cloth by double clicking the spool or thread and then selecting the loom. Taking scissors to these bolts of cloth will produce sheets of cloth that you can then use with a sewing kit to make clothing. You can also cut the cloth down further into bandages if you need them.</BASEFONT></BODY>", (bool)false, (bool)false);

				AddItem(16, 416, 4117);
				AddItem(544, 383, 4192);
				AddItem(352, 416, 19585);
				AddItem(184, 419, 3990);
				AddItem(520, 418, 4191);
				AddItem(346, 471, 3998);
				AddItem(320, 452, 3576);
				AddItem(360, 442, 3567);
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
				e.CloseGump( typeof( LearnTailorGump ) );
				e.SendGump( new LearnTailorGump( e ) );
				e.PlaySound( 0x249 );
				Server.Gumps.MyLibrary.readBook ( this, e );
			}
		}

		public LearnTailorBook(Serial serial) : base(serial)
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