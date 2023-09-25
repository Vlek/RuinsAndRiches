using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using System.Collections;

namespace Server.Items
{
    public class DungeonMastersGuide : Item
	{
        [Constructable]
        public DungeonMastersGuide() : base( 0x3046 )
		{
            Name = "Dungeon Masters Guide";
			Weight = 1.0;
        }

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
            list.Add( 1049644, "Dungeons & Dragons");
        }

		public override void OnDoubleClick( Mobile e )
		{
			e.CloseGump( typeof( DMGuideGump ) );
			e.SendGump( new DMGuideGump( e ) );
			e.SendSound( 0x55 );
		}

		public class DMGuideGump : Gump
		{
			public DMGuideGump( Mobile from ): base( 50, 50 )
			{
				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(1, 1, 11415, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddHtml( 15, 15, 341, 20, @"<BODY><BASEFONT Color=#DC7676>DUNGEON MASTERS GUIDE</BASEFONT></BODY>", (bool)false, (bool)false);
				AddButton(667, 12, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddHtml( 15, 80, 290, 340, @"<BODY><BASEFONT Color=#DC7676>" + Server.Misc.Worlds.GetDungeonListing() + "</BASEFONT></BODY>", (bool)false, (bool)true);
				AddHtml( 15, 50, 675, 20, @"<BODY><BASEFONT Color=#DC7676>This book contains a listing of almost all of the dungeons in the many world of " + MyServerSettings.ServerName() + ".</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse( NetState state, RelayInfo info ) 
			{
				Mobile from = state.Mobile; 
				from.SendSound( 0x55 );
			}
		}

        public DungeonMastersGuide( Serial serial ) : base( serial )
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