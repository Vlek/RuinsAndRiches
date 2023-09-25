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
public class LearnWoodBook : Item
{
    [Constructable]
    public LearnWoodBook( ) : base(0x02DD)
    {
        Weight = 1.0;
        Name   = "Scroll of Various Wood";
        ItemID = Utility.RandomList(0x02DD, 0x201A);
    }

    public override void GetProperties(ObjectPropertyList list)
    {
        base.GetProperties(list);
        list.Add("A Listing of Wood");
    }

    public class LearnWoodBookGump : Gump
    {
        public LearnWoodBookGump(Mobile from) : base(50, 50)
        {
            string color = "#ddbc4b";

            this.Closable   = true;
            this.Disposable = true;
            this.Dragable   = true;
            this.Resizable  = false;

            AddPage(0);
            AddImage(0, 0, 9546, Server.Misc.PlayerSettings.GetGumpHue(from));

            AddHtml(15, 15, 600, 20, @"<BODY><BASEFONT Color=" + color + ">INFORMATION ON VARIOUS TYPES OF WOOD</BASEFONT></BODY>", (bool)false, (bool)false);

            AddButton(867, 11, 4017, 4017, 0, GumpButtonType.Reply, 0);

            AddItem(9, 72, 7137);
            AddHtml(50, 76, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Regular</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 114, 7137, MaterialInfo.GetMaterialColor("ash", "", 0));
            AddHtml(50, 118, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Ash</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 156, 7137, MaterialInfo.GetMaterialColor("cherry", "", 0));
            AddHtml(50, 160, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Cherry</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 198, 7137, MaterialInfo.GetMaterialColor("ebony", "", 0));
            AddHtml(50, 202, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Ebony</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 240, 7137, MaterialInfo.GetMaterialColor("golden oak", "", 0));
            AddHtml(50, 244, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Golden Oak</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 282, 7137, MaterialInfo.GetMaterialColor("hickory", "", 0));
            AddHtml(50, 286, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Hickory</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 324, 7137, MaterialInfo.GetMaterialColor("mahogany", "", 0));
            AddHtml(50, 328, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Mahogany</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 366, 7137, MaterialInfo.GetMaterialColor("oak", "", 0));
            AddHtml(50, 370, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Oak</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 408, 7137, MaterialInfo.GetMaterialColor("pine", "", 0));
            AddHtml(50, 412, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Pine</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 450, 7137, MaterialInfo.GetMaterialColor("ghostwood", "", 0));
            AddHtml(50, 454, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Ghostwood</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 492, 7137, MaterialInfo.GetMaterialColor("rosewood", "", 0));
            AddHtml(50, 496, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Rosewood</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 534, 7137, MaterialInfo.GetMaterialColor("walnut", "", 0));
            AddHtml(50, 538, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Walnut</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 576, 7137, MaterialInfo.GetMaterialColor("petrified", "", 0));
            AddHtml(50, 580, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Petrified</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 618, 7137, MaterialInfo.GetMaterialColor("driftwood", "", 0));
            AddHtml(50, 622, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Driftwood</BASEFONT></BODY>", (bool)false, (bool)false);
            AddItem(9, 660, 7137, MaterialInfo.GetMaterialColor("elven", "", 0));
            AddHtml(50, 664, 122, 20, @"<BODY><BASEFONT Color=" + color + ">Elven</BASEFONT></BODY>", (bool)false, (bool)false);

            AddHtml(209, 67, 679, 702, @"<BODY><BASEFONT Color=" + color + ">Lumberjacking is a task carried out long before the mining of ore. You simply need to get an axe, double-click it, and then target a tree to begin chopping. Although you will normally get regular wood, you will eventually get skilled enough to chop other types of wood. With wood you can make arrows, bows, and crossbows with the bowcrafting skill. You can also make furniture, weapons, and armor with the carpentry skill.<br><br>The many types of wood are listed here, starting up and then going down to higher quality wood. Making a shield out of walnut will be a much better shield than one made of ash, for example. The same goes for bows, crossbows, and other weapons made of wood. Whatever the color of wood you use, the weapon, armor, or instrument will retain the color of the wood. The same goes for many of the furniture and containers you can make from wood. A wooden chest made from cherry wood will be red in color.<br><br>In order to make things from the wood, you need to turn the logs into boards. To do this, double-click the logs and target a saw mill. These mills are commonly found in carpenter shops. Then you can begin crafting with a carpentry tool, or bowcrafting with bowyer tools.</BASEFONT></BODY>", (bool)false, (bool)false);
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
            e.CloseGump(typeof(LearnWoodBookGump));
            e.SendGump(new LearnWoodBookGump(e));
            e.PlaySound(0x249);
            Server.Gumps.MyLibrary.readBook(this, e);
        }
    }

    public LearnWoodBook(Serial serial) : base(serial)
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
