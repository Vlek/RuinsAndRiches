using System;
using Server;
using Server.Items;
using System.Text;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
public class LearnScalesBook : Item
{
    [Constructable]
    public LearnScalesBook( ) : base(0x02DD)
    {
        Weight = 1.0;
        Name   = "Scroll of Reptile Scales";
        ItemID = Utility.RandomList(0x02DD, 0x201A);
    }

    public override void GetProperties(ObjectPropertyList list)
    {
        base.GetProperties(list);
        list.Add("A Listing Of Reptile Scales");
    }

    public class LearnScalesGump : Gump
    {
        public LearnScalesGump(Mobile from) : base(50, 50)
        {
            string color = "#ddbc4b";

            this.Closable   = true;
            this.Disposable = true;
            this.Dragable   = true;
            this.Resizable  = false;

            AddPage(0);

            AddImage(0, 0, 9547, Server.Misc.PlayerSettings.GetGumpHue(from));

            AddHtml(15, 15, 398, 20, @"<BODY><BASEFONT Color=" + color + ">TYPES OF REPTILE SCALES</BASEFONT></BODY>", (bool)false, (bool)false);

            AddButton(567, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);

            AddItem(20, 425, 9905, 0x66D);
            AddHtml(65, 425, 98, 20, @"<BODY><BASEFONT Color=" + color + ">Red</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(20, 455, 9905, 0x8A8);
            AddHtml(65, 455, 98, 20, @"<BODY><BASEFONT Color=" + color + ">Yellow</BASEFONT></BODY>", (bool)false, (bool)false);

            AddItem(240, 425, 9905, 0x455);
            AddHtml(285, 425, 98, 20, @"<BODY><BASEFONT Color=" + color + ">Black</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(240, 455, 9905, 0x851);
            AddHtml(285, 455, 98, 20, @"<BODY><BASEFONT Color=" + color + ">Green</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(240, 485, 9905, 0x8FD);
            AddHtml(285, 485, 98, 20, @"<BODY><BASEFONT Color=" + color + ">White</BASEFONT></BODY>", (bool)false, (bool)false);

            AddItem(440, 425, 9905, 0x8B0);
            AddHtml(485, 425, 98, 20, @"<BODY><BASEFONT Color=" + color + ">Blue</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(440, 455, 9905, 0x430);
            AddHtml(485, 455, 98, 20, @"<BODY><BASEFONT Color=" + color + ">Dinosaur</BASEFONT></BODY>", (bool)false, (bool)false);

            AddHtml(19, 47, 573, 364, @"<BODY><BASEFONT Color=" + color + ">Use a bladed item, like a dagger or knife, on a corpse by double-clicking the bladed item and then selecting the corpse. If there is something to be skinned from it, it will appear in their pack. If they have scales, then those will also appear in their pack.<br><br>Different types of scales can be found on many creatures like dragons and dinosaurs. You can use these scales to make different types of items by using a blacksmith hammer and making scalemail armor.<BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR><BR>There are 7 different types of scales:</BASEFONT></BODY>", (bool)false, (bool)false);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;
            from.SendSound(0x249);
        }
    }

    public override void OnDoubleClick(Mobile e)
    {
        if (!IsChildOf(e.Backpack) && this.Weight != -50.0)
        {
            e.SendMessage("This must be in your backpack to read.");
        }
        else
        {
            e.CloseGump(typeof(LearnScalesGump));
            e.SendGump(new LearnScalesGump(e));
            e.PlaySound(0x249);
            Server.Gumps.MyLibrary.readBook(this, e);
        }
    }

    public LearnScalesBook(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}
}
