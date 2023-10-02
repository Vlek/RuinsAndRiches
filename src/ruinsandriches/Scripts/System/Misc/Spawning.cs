using CPA = Server.CommandPropertyAttribute;
using Server.Commands;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System;

namespace Server.Commands
{
public class OptionsGumps
{
    public OptionsGumps()
    {
    }

    public static void Initialize()
    {
        CommandSystem.Register("GumpSaveRegion", AccessLevel.Administrator, new CommandEventHandler(OptionsGumps1_OnCommand));
        CommandSystem.Register("GumpSaveCoordinate", AccessLevel.Administrator, new CommandEventHandler(OptionsGumps2_OnCommand));
        CommandSystem.Register("GumpRemoveID", AccessLevel.Administrator, new CommandEventHandler(OptionsGumps3_OnCommand));
        CommandSystem.Register("GumpRemoveCoordinate", AccessLevel.Administrator, new CommandEventHandler(OptionsGumps4_OnCommand));
        CommandSystem.Register("GumpRemoveRegion", AccessLevel.Administrator, new CommandEventHandler(OptionsGumps5_OnCommand));
    }

    [Usage("[GumpSaveRegion")]
    [Description("Gump to Save inside Region")]
    private static void OptionsGumps1_OnCommand(CommandEventArgs e)
    {
        e.Mobile.SendGump(new GumpSaveRegion(e));
    }

    [Usage("[GumpSaveCoordinate")]
    [Description("Gump to save by coordinates")]
    private static void OptionsGumps2_OnCommand(CommandEventArgs e)
    {
        e.Mobile.SendGump(new GumpSaveCoordinate(e));
    }

    [Usage("[GumpRemoveID")]
    [Description("Gump to remove by ID")]
    private static void OptionsGumps3_OnCommand(CommandEventArgs e)
    {
        e.Mobile.SendGump(new GumpRemoveID(e));
    }

    [Usage("[GumpRemoveCoordinate")]
    [Description("Gump to remove by coordinates")]
    private static void OptionsGumps4_OnCommand(CommandEventArgs e)
    {
        e.Mobile.SendGump(new GumpRemoveCoordinate(e));
    }

    [Usage("[GumpRemoveRegion")]
    [Description("Gump to remove inside region")]
    private static void OptionsGumps5_OnCommand(CommandEventArgs e)
    {
        e.Mobile.SendGump(new GumpRemoveRegion(e));
    }
}
}

namespace Server.Gumps
{
public class GumpSaveRegion : Gump
{
    private CommandEventArgs m_CommandEventArgs;

    public GumpSaveRegion(CommandEventArgs e) : base(50, 50)
    {
        m_CommandEventArgs = e;
        Closable           = true;
        Dragable           = true;
        Mobile from = e.Mobile;

        AddPage(1);
        //x, y, width, hight
        AddBackground(0, 0, 232, 210, 5054);

        AddImageTiled(15, 30, 120, 20, 3004);
        AddTextEntry(15, 30, 120, 20, 0, 0, @"region to save");
        AddLabel(15, 10, 52, "Enter a Region:");
        AddButton(140, 32, 0x15E1, 0x15E5, 101, GumpButtonType.Reply, 0);

        AddLabel(15, 60, 52, "Tip:");
        AddHtml(15, 80, 200, 110, "This will SAVE the spawners, in a specified region, to Data/Spawns/'region name'.map. Type [where if you don't know the region you are. Copy to the text box the name of the region. You also can open Data/Regions.xml to a full list of regions.<BR>Example: you type [where and appear 'your region is town of Britain'. Type 'Britain' in text box.", true, true);
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile from = state.Mobile;

        switch (info.ButtonID)
        {
            case 0:                     // close the gump
            {
                break;
            }

            case 101:
            {
                TextRelay oRegion = info.GetTextEntry(0);
                string    sRegion = oRegion.Text;
                if (sRegion != "")
                {
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}Spawngen save {1}", prefix, sRegion));
                }
                else
                {
                    from.SendMessage("You must specify a region!");
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}GumpSaveRegion", prefix));
                }
                break;
            }
        }
    }
}

public class GumpRemoveRegion : Gump
{
    private CommandEventArgs m_CommandEventArgs;

    public GumpRemoveRegion(CommandEventArgs e) : base(50, 50)
    {
        m_CommandEventArgs = e;
        Closable           = true;
        Dragable           = true;
        Mobile from = e.Mobile;

        AddPage(1);

        AddBackground(0, 0, 232, 210, 5054);

        AddImageTiled(15, 30, 120, 20, 3004);
        AddTextEntry(15, 30, 120, 20, 0, 0, @"region to remove");
        AddLabel(15, 10, 52, "Enter a Region:");
        AddButton(140, 32, 0x15E1, 0x15E5, 101, GumpButtonType.Reply, 0);

        AddLabel(15, 60, 52, "Tip:");
        AddHtml(15, 80, 200, 110, "This will REMOVE the spawners, in a specified region. Type [where if you don't know the region you are. Copy to the text box the name of the region. You also can open Data/Regions.xml to a full list of regions.<BR>Example: you type [where and appear 'your region is town of Britain'. Type 'Britain' in text box.", true, true);
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile from = state.Mobile;

        switch (info.ButtonID)
        {
            case 0:                     // close the gump
            {
                break;
            }

            case 101:
            {
                TextRelay oRegion = info.GetTextEntry(0);
                string    sRegion = oRegion.Text;
                if (sRegion != "")
                {
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}Spawngen remove {1}", prefix, sRegion));
                }
                else
                {
                    from.SendMessage("You must specify a region!");
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}GumpRemoveRegion", prefix));
                }
                break;
            }
        }
    }
}

public class GumpRemoveID : Gump
{
    private CommandEventArgs m_CommandEventArgs;

    public GumpRemoveID(CommandEventArgs e) : base(50, 50)
    {
        m_CommandEventArgs = e;
        Closable           = true;
        Dragable           = true;
        Mobile from = e.Mobile;

        AddPage(1);

        AddBackground(0, 0, 232, 210, 5054);

        AddImageTiled(15, 30, 120, 20, 3004);
        AddTextEntry(15, 30, 120, 20, 0, 0, @"SpawnID to remove");
        AddLabel(15, 10, 52, "Enter a SpawnID:");
        AddButton(140, 32, 0x15E1, 0x15E5, 101, GumpButtonType.Reply, 0);

        AddLabel(15, 60, 52, "Tip:");
        AddHtml(15, 80, 200, 110, "This command was made to UNLOAD your own custom maps. This will REMOVE the spawners with the specified ID. Type '[get spawnid' in a spawner to know your ID. Remember: 'By Hand' spawns, i.e., those done with '[add premiumspawner' have ID = 1.", true, true);
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile from = state.Mobile;

        switch (info.ButtonID)
        {
            case 0:                     // close the gump
            {
                break;
            }

            case 101:
            {
                TextRelay oID = info.GetTextEntry(0);
                string    sID = oID.Text;
                if (sID != "")
                {
                    try
                    {
                        int    UnloadID = Convert.ToInt32(sID);
                        string prefix   = Server.Commands.CommandSystem.Prefix;
                        CommandSystem.Handle(from, String.Format("{0}Spawngen unload {1}", prefix, UnloadID));
                    }
                    catch
                    {
                        from.SendMessage("SpawnID must be a number!");
                        string prefix = Server.Commands.CommandSystem.Prefix;
                        CommandSystem.Handle(from, String.Format("{0}GumpRemoveID", prefix));
                    }
                }

                else
                {
                    from.SendMessage("You must specify an SpawnID!");
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}GumpRemoveID", prefix));
                }
                break;
            }
        }
    }
}

public class GumpSaveCoordinate : Gump
{
    private CommandEventArgs m_CommandEventArgs;

    public GumpSaveCoordinate(CommandEventArgs e) : base(50, 50)
    {
        m_CommandEventArgs = e;
        Closable           = true;
        Dragable           = true;
        Mobile from = e.Mobile;

        AddPage(1);

        AddBackground(0, 0, 232, 235, 5054);

        AddImageTiled(15, 30, 37, 20, 3004);
        AddTextEntry(15, 30, 37, 20, 0, 0, @"X1");

        AddImageTiled(57, 30, 37, 20, 3004);
        AddTextEntry(57, 30, 37, 20, 0, 1, @"Y1");

        AddImageTiled(15, 55, 37, 20, 3004);
        AddTextEntry(15, 55, 37, 20, 0, 2, @"X2");

        AddImageTiled(57, 55, 37, 20, 3004);
        AddTextEntry(57, 55, 37, 20, 0, 3, @"Y2");

        AddLabel(15, 10, 52, "Enter Coordinates:");
        AddButton(140, 32, 0x15E1, 0x15E5, 101, GumpButtonType.Reply, 0);

        AddLabel(15, 85, 52, "Tip:");
        AddHtml(15, 105, 200, 110, "This will SAVE spawners inside specified coordinates. You can use [where in the first point and again [where in the second point to get the X and Y coordinates. You need 2: X1, Y1 for first point and X2, Y2 for the second point. The objective is determine a 'box'. This command will save all spawners inside this box.", true, true);
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile from = state.Mobile;

        switch (info.ButtonID)
        {
            case 0:                     // close the gump
            {
                break;
            }

            case 101:
            {
                TextRelay oX1 = info.GetTextEntry(0);
                TextRelay oY1 = info.GetTextEntry(1);
                TextRelay oX2 = info.GetTextEntry(2);
                TextRelay oY2 = info.GetTextEntry(3);
                string    sX1 = oX1.Text;
                string    sY1 = oY1.Text;
                string    sX2 = oX2.Text;
                string    sY2 = oY2.Text;
                if (sX1 != "" && sY1 != "" && sX2 != "" && sY2 != "")
                {
                    try
                    {
                        int    iX1    = Convert.ToInt32(sX1);
                        int    iY1    = Convert.ToInt32(sY1);
                        int    iX2    = Convert.ToInt32(sX2);
                        int    iY2    = Convert.ToInt32(sY2);
                        string prefix = Server.Commands.CommandSystem.Prefix;
                        CommandSystem.Handle(from, String.Format("{0}Spawngen save {1} {2} {3} {4}", prefix, iX1, iY1, iX2, iY2));
                    }
                    catch
                    {
                        from.SendMessage("Coordinates must be numbers!");
                        string prefix = Server.Commands.CommandSystem.Prefix;
                        CommandSystem.Handle(from, String.Format("{0}GumpSaveCoordinate", prefix));
                    }
                }

                else
                {
                    from.SendMessage("You must specify all coordinates!");
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}GumpSaveCoordinate", prefix));
                }
                break;
            }
        }
    }
}

public class GumpRemoveCoordinate : Gump
{
    private CommandEventArgs m_CommandEventArgs;

    public GumpRemoveCoordinate(CommandEventArgs e) : base(50, 50)
    {
        m_CommandEventArgs = e;
        Closable           = true;
        Dragable           = true;
        Mobile from = e.Mobile;

        AddPage(1);

        AddBackground(0, 0, 232, 235, 5054);

        AddImageTiled(15, 30, 37, 20, 3004);
        AddTextEntry(15, 30, 37, 20, 0, 0, @"X1");

        AddImageTiled(57, 30, 37, 20, 3004);
        AddTextEntry(57, 30, 37, 20, 0, 1, @"Y1");

        AddImageTiled(15, 55, 37, 20, 3004);
        AddTextEntry(15, 55, 37, 20, 0, 2, @"X2");

        AddImageTiled(57, 55, 37, 20, 3004);
        AddTextEntry(57, 55, 37, 20, 0, 3, @"Y2");

        AddLabel(15, 10, 52, "Enter Coordinates:");
        AddButton(140, 32, 0x15E1, 0x15E5, 101, GumpButtonType.Reply, 0);

        AddLabel(15, 85, 52, "Tip:");
        AddHtml(15, 105, 200, 110, "This will REMOVE spawners inside specified coordinates. You can use [where in the first point and again [where in the second point to get the X and Y coordinates. You need 2: X1, Y1 for first point and X2, Y2 for the second point. The objective is determine a 'box'. This command will remove all spawners inside this box.", true, true);
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile from = state.Mobile;

        switch (info.ButtonID)
        {
            case 0:                     // close the gump
            {
                break;
            }

            case 101:
            {
                TextRelay oX1 = info.GetTextEntry(0);
                TextRelay oY1 = info.GetTextEntry(1);
                TextRelay oX2 = info.GetTextEntry(2);
                TextRelay oY2 = info.GetTextEntry(3);
                string    sX1 = oX1.Text;
                string    sY1 = oY1.Text;
                string    sX2 = oX2.Text;
                string    sY2 = oY2.Text;
                if (sX1 != "" && sY1 != "" && sX2 != "" && sY2 != "")
                {
                    try
                    {
                        int    iX1    = Convert.ToInt32(sX1);
                        int    iY1    = Convert.ToInt32(sY1);
                        int    iX2    = Convert.ToInt32(sX2);
                        int    iY2    = Convert.ToInt32(sY2);
                        string prefix = Server.Commands.CommandSystem.Prefix;
                        CommandSystem.Handle(from, String.Format("{0}Spawngen remove {1} {2} {3} {4}", prefix, iX1, iY1, iX2, iY2));
                    }
                    catch
                    {
                        from.SendMessage("Coordinates must be numbers!");
                        string prefix = Server.Commands.CommandSystem.Prefix;
                        CommandSystem.Handle(from, String.Format("{0}GumpRemoveCoordinate", prefix));
                    }
                }

                else
                {
                    from.SendMessage("You must specify all coordinates!");
                    string prefix = Server.Commands.CommandSystem.Prefix;
                    CommandSystem.Handle(from, String.Format("{0}GumpRemoveCoordinate", prefix));
                }
                break;
            }
        }
    }
}
}
namespace Server.Mobiles
{
public class PremiumSpawnerGump : Gump
{
    private PremiumSpawner m_Spawner;

    public void AddBlackAlpha(int x, int y, int width, int height)
    {
        AddImageTiled(x, y, width, height, 2624);
        AddAlphaRegion(x, y, width, height);
    }

    public PremiumSpawnerGump(PremiumSpawner spawner) : base(50, 50)
    {
        m_Spawner = spawner;

        AddPage(1);

        AddBackground(0, 0, 350, 360, 5054);

        AddLabel(80, 1, 52, "Creatures List 1");

        AddLabel(215, 3, 52, "PREMIUM SPAWNER");
        AddBlackAlpha(213, 23, 125, 270);

        AddButton(260, 40, 0xFB7, 0xFB9, 100, GumpButtonType.Reply, 0);
        AddLabel(260, 60, 52, "Okay");

        AddButton(260, 90, 0xFB4, 0xFB6, 200, GumpButtonType.Reply, 0);
        AddLabel(232, 110, 52, "Bring to Home");

        AddButton(260, 140, 0xFA8, 0xFAA, 300, GumpButtonType.Reply, 0);
        AddLabel(232, 160, 52, "Total Respawn");

        AddButton(260, 190, 0xFAB, 0xFAD, 400, GumpButtonType.Reply, 0);
        AddLabel(245, 210, 52, "Properties");

        AddButton(260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(256, 260, 52, "Cancel");

        AddButton(230, 320, 5603, 5607, 0, GumpButtonType.Page, 6);
        AddButton(302, 320, 5601, 5605, 0, GumpButtonType.Page, 2);
        AddLabel(258, 320, 52, "- 1 -");

        for (int i = 0; i < 15; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 119, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 117, 21, 0xBBC);

            string str = "";

            if (i < spawner.CreaturesName.Count)
            {
                str = (string)spawner.CreaturesName[i];
                int count = m_Spawner.CountCreatures(str);

                AddLabel(192, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 114, 21, 0, 100 + i, str);
        }

        AddPage(2);

        AddBackground(0, 0, 350, 360, 5054);

        AddLabel(80, 1, 52, "Creatures List 2");

        AddLabel(215, 3, 52, "PREMIUM SPAWNER");
        AddBlackAlpha(213, 23, 125, 270);

        AddButton(260, 40, 0xFB7, 0xFB9, 101, GumpButtonType.Reply, 0);
        AddLabel(260, 60, 52, "Okay");

        AddButton(260, 90, 0xFB4, 0xFB6, 200, GumpButtonType.Reply, 0);
        AddLabel(232, 110, 52, "Bring to Home");

        AddButton(260, 140, 0xFA8, 0xFAA, 300, GumpButtonType.Reply, 0);
        AddLabel(232, 160, 52, "Total Respawn");

        AddButton(260, 190, 0xFAB, 0xFAD, 400, GumpButtonType.Reply, 0);
        AddLabel(245, 210, 52, "Properties");

        AddButton(260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(256, 260, 52, "Cancel");

        AddButton(230, 320, 5603, 5607, 0, GumpButtonType.Page, 1);
        AddButton(302, 320, 5601, 5605, 0, GumpButtonType.Page, 3);
        AddLabel(258, 320, 52, "- 2 -");

        for (int i = 0; i < 15; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 119, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 117, 21, 0xBBC);

            string str = "";

            if (i < spawner.SubSpawnerA.Count)
            {
                str = (string)spawner.SubSpawnerA[i];
                int count = m_Spawner.CountCreaturesA(str);

                AddLabel(192, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 114, 21, 0, 200 + i, str);
        }

        AddPage(3);

        AddBackground(0, 0, 350, 360, 5054);

        AddLabel(80, 1, 52, "Creatures List 3");

        AddLabel(215, 3, 52, "PREMIUM SPAWNER");
        AddBlackAlpha(213, 23, 125, 270);

        AddButton(260, 40, 0xFB7, 0xFB9, 102, GumpButtonType.Reply, 0);
        AddLabel(260, 60, 52, "Okay");

        AddButton(260, 90, 0xFB4, 0xFB6, 200, GumpButtonType.Reply, 0);
        AddLabel(232, 110, 52, "Bring to Home");

        AddButton(260, 140, 0xFA8, 0xFAA, 300, GumpButtonType.Reply, 0);
        AddLabel(232, 160, 52, "Total Respawn");

        AddButton(260, 190, 0xFAB, 0xFAD, 400, GumpButtonType.Reply, 0);
        AddLabel(245, 210, 52, "Properties");

        AddButton(260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(256, 260, 52, "Cancel");

        AddButton(230, 320, 5603, 5607, 0, GumpButtonType.Page, 2);
        AddButton(302, 320, 5601, 5605, 0, GumpButtonType.Page, 4);
        AddLabel(258, 320, 52, "- 3 -");

        for (int i = 0; i < 15; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 119, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 117, 21, 0xBBC);

            string str = "";

            if (i < spawner.SubSpawnerB.Count)
            {
                str = (string)spawner.SubSpawnerB[i];
                int count = m_Spawner.CountCreaturesB(str);

                AddLabel(192, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 114, 21, 0, 300 + i, str);
        }

        AddPage(4);

        AddBackground(0, 0, 350, 360, 5054);

        AddLabel(80, 1, 52, "Creatures List 4");

        AddLabel(215, 3, 52, "PREMIUM SPAWNER");
        AddBlackAlpha(213, 23, 125, 270);

        AddButton(260, 40, 0xFB7, 0xFB9, 103, GumpButtonType.Reply, 0);
        AddLabel(260, 60, 52, "Okay");

        AddButton(260, 90, 0xFB4, 0xFB6, 200, GumpButtonType.Reply, 0);
        AddLabel(232, 110, 52, "Bring to Home");

        AddButton(260, 140, 0xFA8, 0xFAA, 300, GumpButtonType.Reply, 0);
        AddLabel(232, 160, 52, "Total Respawn");

        AddButton(260, 190, 0xFAB, 0xFAD, 400, GumpButtonType.Reply, 0);
        AddLabel(245, 210, 52, "Properties");

        AddButton(260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(256, 260, 52, "Cancel");

        AddButton(230, 320, 5603, 5607, 0, GumpButtonType.Page, 3);
        AddButton(302, 320, 5601, 5605, 0, GumpButtonType.Page, 5);
        AddLabel(258, 320, 52, "- 4 -");

        for (int i = 0; i < 15; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 119, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 117, 21, 0xBBC);

            string str = "";

            if (i < spawner.SubSpawnerC.Count)
            {
                str = (string)spawner.SubSpawnerC[i];
                int count = m_Spawner.CountCreaturesC(str);

                AddLabel(192, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 114, 21, 0, 400 + i, str);
        }

        AddPage(5);

        AddBackground(0, 0, 350, 360, 5054);

        AddLabel(80, 1, 52, "Creatures List 5");

        AddLabel(215, 3, 52, "PREMIUM SPAWNER");
        AddBlackAlpha(213, 23, 125, 270);

        AddButton(260, 40, 0xFB7, 0xFB9, 104, GumpButtonType.Reply, 0);
        AddLabel(260, 60, 52, "Okay");

        AddButton(260, 90, 0xFB4, 0xFB6, 200, GumpButtonType.Reply, 0);
        AddLabel(232, 110, 52, "Bring to Home");

        AddButton(260, 140, 0xFA8, 0xFAA, 300, GumpButtonType.Reply, 0);
        AddLabel(232, 160, 52, "Total Respawn");

        AddButton(260, 190, 0xFAB, 0xFAD, 400, GumpButtonType.Reply, 0);
        AddLabel(245, 210, 52, "Properties");

        AddButton(260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(256, 260, 52, "Cancel");

        AddButton(230, 320, 5603, 5607, 0, GumpButtonType.Page, 4);
        AddButton(302, 320, 5601, 5605, 0, GumpButtonType.Page, 6);
        AddLabel(258, 320, 52, "- 5 -");

        for (int i = 0; i < 15; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 119, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 117, 21, 0xBBC);

            string str = "";

            if (i < spawner.SubSpawnerD.Count)
            {
                str = (string)spawner.SubSpawnerD[i];
                int count = m_Spawner.CountCreaturesD(str);

                AddLabel(192, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 114, 21, 0, 500 + i, str);
        }

        AddPage(6);

        AddBackground(0, 0, 350, 360, 5054);

        AddLabel(80, 1, 52, "Creatures List 6");

        AddLabel(215, 3, 52, "PREMIUM SPAWNER");
        AddBlackAlpha(213, 23, 125, 270);

        AddButton(260, 40, 0xFB7, 0xFB9, 105, GumpButtonType.Reply, 0);
        AddLabel(260, 60, 52, "Okay");

        AddButton(260, 90, 0xFB4, 0xFB6, 200, GumpButtonType.Reply, 0);
        AddLabel(232, 110, 52, "Bring to Home");

        AddButton(260, 140, 0xFA8, 0xFAA, 300, GumpButtonType.Reply, 0);
        AddLabel(232, 160, 52, "Total Respawn");

        AddButton(260, 190, 0xFAB, 0xFAD, 400, GumpButtonType.Reply, 0);
        AddLabel(245, 210, 52, "Properties");

        AddButton(260, 240, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(256, 260, 52, "Cancel");

        AddButton(230, 320, 5603, 5607, 0, GumpButtonType.Page, 5);
        AddButton(302, 320, 5601, 5605, 0, GumpButtonType.Page, 1);
        AddLabel(258, 320, 52, "- 6 -");

        for (int i = 0; i < 15; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 119, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 117, 21, 0xBBC);

            string str = "";

            if (i < spawner.SubSpawnerE.Count)
            {
                str = (string)spawner.SubSpawnerE[i];
                int count = m_Spawner.CountCreaturesE(str);

                AddLabel(192, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 114, 21, 0, 600 + i, str);
        }
    }

    public List <string> CreateArray(RelayInfo info, Mobile from)
    {
        List <string> creaturesName = new List <string>();

        for (int i = 0; i < 15; i++)
        {
            TextRelay te = info.GetTextEntry(100 + i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creaturesName.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creaturesName;
    }

    public List <string> CreateArrayA(RelayInfo info, Mobile from)
    {
        List <string> creatureNameAA = new List <string>();

        for (int i = 0; i < 15; i++)
        {
            TextRelay te = info.GetTextEntry(200 + i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creatureNameAA.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creatureNameAA;
    }

    public List <string> CreateArrayB(RelayInfo info, Mobile from)
    {
        List <string> creatureNameBB = new List <string>();

        for (int i = 0; i < 15; i++)
        {
            TextRelay te = info.GetTextEntry(300 + i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creatureNameBB.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creatureNameBB;
    }

    public List <string> CreateArrayC(RelayInfo info, Mobile from)
    {
        List <string> creatureNameCC = new List <string>();

        for (int i = 0; i < 15; i++)
        {
            TextRelay te = info.GetTextEntry(400 + i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creatureNameCC.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creatureNameCC;
    }

    public List <string> CreateArrayD(RelayInfo info, Mobile from)
    {
        List <string> creatureNameDD = new List <string>();

        for (int i = 0; i < 15; i++)
        {
            TextRelay te = info.GetTextEntry(500 + i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creatureNameDD.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creatureNameDD;
    }

    public List <string> CreateArrayE(RelayInfo info, Mobile from)
    {
        List <string> creatureNameEE = new List <string>();

        for (int i = 0; i < 15; i++)
        {
            TextRelay te = info.GetTextEntry(600 + i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creatureNameEE.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creatureNameEE;
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        if (m_Spawner.Deleted)
        {
            return;
        }

        switch (info.ButtonID)
        {
            case 0:                     // Closed
            {
                break;
            }
            case 100:                     // Okay
            {
                m_Spawner.CreaturesName = CreateArray(info, state.Mobile);
                break;
            }
            case 101:                     // Okay
            {
                m_Spawner.SubSpawnerA = CreateArrayA(info, state.Mobile);
                break;
            }
            case 102:                     // Okay
            {
                m_Spawner.SubSpawnerB = CreateArrayB(info, state.Mobile);
                break;
            }
            case 103:                     // Okay
            {
                m_Spawner.SubSpawnerC = CreateArrayC(info, state.Mobile);
                break;
            }
            case 104:                     // Okay
            {
                m_Spawner.SubSpawnerD = CreateArrayD(info, state.Mobile);
                break;
            }
            case 105:                     // Okay
            {
                m_Spawner.SubSpawnerE = CreateArrayE(info, state.Mobile);
                break;
            }
            case 200:                     // Bring everything home
            {
                m_Spawner.BringToHome();

                break;
            }
            case 300:                     // Complete respawn
            {
                m_Spawner.Respawn();

                break;
            }
            case 400:                     // Props
            {
                state.Mobile.SendGump(new PropertiesGump(state.Mobile, m_Spawner));
                state.Mobile.SendGump(new PremiumSpawnerGump(m_Spawner));

                break;
            }
            default:
            {
                int buttonID = info.ButtonID - 4;
                int index    = buttonID / 2;
                int type     = buttonID % 2;

                TextRelay entry = info.GetTextEntry(index);

                if (entry != null && entry.Text.Length > 0)
                {
                    if (type == 0)                               // Spawn creature
                    {
                        m_Spawner.Spawn(entry.Text);
                    }
                    else                             // Remove creatures
                    {
                        m_Spawner.RemoveCreatures(entry.Text);
                    }

                    m_Spawner.CreaturesName = CreateArray(info, state.Mobile);
                    m_Spawner.SubSpawnerA   = CreateArrayA(info, state.Mobile);
                    m_Spawner.SubSpawnerB   = CreateArrayB(info, state.Mobile);
                    m_Spawner.SubSpawnerC   = CreateArrayC(info, state.Mobile);
                    m_Spawner.SubSpawnerD   = CreateArrayD(info, state.Mobile);
                    m_Spawner.SubSpawnerE   = CreateArrayE(info, state.Mobile);
                }

                break;
            }
        }
    }
}
}
namespace Server.Mobiles
{
public class PremiumSpawner : Item
{
    private int m_Team;
    private int m_HomeRange;                      // = old SpawnRange
    private int m_WalkingRange = -1;              // = old HomeRange
    private int m_SpawnID      = 1;
    private int m_Count;
    private int m_CountA;
    private int m_CountB;
    private int m_CountC;
    private int m_CountD;
    private int m_CountE;
    private TimeSpan m_MinDelay;
    private TimeSpan m_MaxDelay;
    private List <string> m_CreaturesName;            // creatures to be spawned
    private List <IEntity> m_Creatures;               // spawned creatures
    private List <string> m_CreaturesNameA;
    private List <IEntity> m_CreaturesA;
    private List <string> m_CreaturesNameB;
    private List <IEntity> m_CreaturesB;
    private List <string> m_CreaturesNameC;
    private List <IEntity> m_CreaturesC;
    private List <string> m_CreaturesNameD;
    private List <IEntity> m_CreaturesD;
    private List <string> m_CreaturesNameE;
    private List <IEntity> m_CreaturesE;
    private DateTime m_End;
    private InternalTimer m_Timer;
    private bool m_Running;
    private bool m_Group;
    private WayPoint m_WayPoint;

    public bool IsFull {
        get { return m_Creatures != null && m_Creatures.Count >= m_Count; }
    }
    public bool IsFulla {
        get { return m_CreaturesA != null && m_CreaturesA.Count >= m_CountA; }
    }
    public bool IsFullb {
        get { return m_CreaturesB != null && m_CreaturesB.Count >= m_CountB; }
    }
    public bool IsFullc {
        get { return m_CreaturesC != null && m_CreaturesC.Count >= m_CountC; }
    }
    public bool IsFulld {
        get { return m_CreaturesD != null && m_CreaturesD.Count >= m_CountD; }
    }
    public bool IsFulle {
        get { return m_CreaturesE != null && m_CreaturesE.Count >= m_CountE; }
    }

    public List <string> CreaturesName
    {
        get { return m_CreaturesName; }
        set
        {
            m_CreaturesName = value;
            if (m_CreaturesName.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public List <string> SubSpawnerA
    {
        get { return m_CreaturesNameA; }
        set
        {
            m_CreaturesNameA = value;
            if (m_CreaturesNameA.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public List <string> SubSpawnerB
    {
        get { return m_CreaturesNameB; }
        set
        {
            m_CreaturesNameB = value;
            if (m_CreaturesNameB.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public List <string> SubSpawnerC
    {
        get { return m_CreaturesNameC; }
        set
        {
            m_CreaturesNameC = value;
            if (m_CreaturesNameC.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public List <string> SubSpawnerD
    {
        get { return m_CreaturesNameD; }
        set
        {
            m_CreaturesNameD = value;
            if (m_CreaturesNameD.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public List <string> SubSpawnerE
    {
        get { return m_CreaturesNameE; }
        set
        {
            m_CreaturesNameE = value;
            if (m_CreaturesNameE.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public virtual int CreaturesNameCount {
        get { return m_CreaturesName.Count; }
    }
    public virtual int CreaturesNameCountA {
        get { return m_CreaturesNameA.Count; }
    }
    public virtual int CreaturesNameCountB {
        get { return m_CreaturesNameB.Count; }
    }
    public virtual int CreaturesNameCountC {
        get { return m_CreaturesNameC.Count; }
    }
    public virtual int CreaturesNameCountD {
        get { return m_CreaturesNameD.Count; }
    }
    public virtual int CreaturesNameCountE {
        get { return m_CreaturesNameE.Count; }
    }

    public override void OnAfterDuped(Item newItem)
    {
        PremiumSpawner s = newItem as PremiumSpawner;

        if (s == null)
        {
            return;
        }

        s.m_CreaturesName  = new List <string>(m_CreaturesName);
        s.m_CreaturesNameA = new List <string>(m_CreaturesNameA);
        s.m_CreaturesNameB = new List <string>(m_CreaturesNameB);
        s.m_CreaturesNameC = new List <string>(m_CreaturesNameC);
        s.m_CreaturesNameD = new List <string>(m_CreaturesNameD);
        s.m_CreaturesNameE = new List <string>(m_CreaturesNameE);
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Count
    {
        get { return m_Count; }
        set { m_Count = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int CountA
    {
        get { return m_CountA; }
        set { m_CountA = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int CountB
    {
        get { return m_CountB; }
        set { m_CountB = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int CountC
    {
        get { return m_CountC; }
        set { m_CountC = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int CountD
    {
        get { return m_CountD; }
        set { m_CountD = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int CountE
    {
        get { return m_CountE; }
        set { m_CountE = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public WayPoint WayPoint
    {
        get
        {
            return m_WayPoint;
        }
        set
        {
            m_WayPoint = value;
        }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public bool Running
    {
        get { return m_Running; }
        set
        {
            if (value)
            {
                Start();
            }
            else
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int HomeRange
    {
        get { return m_HomeRange; }
        set { m_HomeRange = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int WalkingRange
    {
        get { return m_WalkingRange; }
        set { m_WalkingRange = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int SpawnID
    {
        get { return m_SpawnID; }
        set { m_SpawnID = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Team
    {
        get { return m_Team; }
        set { m_Team = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public TimeSpan MinDelay
    {
        get { return m_MinDelay; }
        set { m_MinDelay = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public TimeSpan MaxDelay
    {
        get { return m_MaxDelay; }
        set { m_MaxDelay = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public TimeSpan NextSpawn
    {
        get
        {
            if (m_Running)
            {
                return m_End - DateTime.Now;
            }
            else
            {
                return TimeSpan.FromSeconds(0);
            }
        }
        set
        {
            Start();
            DoTimer(value);
        }
    }

    public static void ActivateSpawner(Mobile m)
    {
        if (m is BaseCreature && ((BaseCreature)m).SpawnerID > 0 && !((BaseCreature)m).Controlled)
        {
            bool run = true;

            foreach (Item item in m.GetItemsInRange(10))
            {
                if (item is PremiumSpawner && item.Serial == ((BaseCreature)m).SpawnerID)
                {
                    ((PremiumSpawner)item).Running = true;
                    run = false;
                }
            }

            if (run)
            {
                foreach (Item item in World.Items.Values)
                {
                    if (item is PremiumSpawner && item.Serial == ((BaseCreature)m).SpawnerID)
                    {
                        ((PremiumSpawner)item).Running = true;
                    }
                }
            }
        }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public bool Group
    {
        get { return m_Group; }
        set { m_Group = value; InvalidateProperties(); }
    }

    [Constructable]
    public PremiumSpawner(int amount, int subamountA, int subamountB, int subamountC, int subamountD, int subamountE, int spawnid, int minDelay, int maxDelay, int team, int homeRange, int walkingRange, string creatureName, string creatureNameA, string creatureNameB, string creatureNameC, string creatureNameD, string creatureNameE) : base(0x6519)
    {
        List <string> creaturesName = new List <string>();
        creaturesName.Add(creatureName);

        List <string> creatureNameAA = new List <string>();
        creaturesName.Add(creatureNameA);

        List <string> creatureNameBB = new List <string>();
        creaturesName.Add(creatureNameB);

        List <string> creatureNameCC = new List <string>();
        creaturesName.Add(creatureNameC);

        List <string> creatureNameDD = new List <string>();
        creaturesName.Add(creatureNameD);

        List <string> creatureNameEE = new List <string>();
        creaturesName.Add(creatureNameE);

        InitSpawn(amount, subamountA, subamountB, subamountC, subamountD, subamountE, spawnid, TimeSpan.FromMinutes(minDelay), TimeSpan.FromMinutes(maxDelay), team, homeRange, walkingRange, creaturesName, creatureNameAA, creatureNameBB, creatureNameCC, creatureNameDD, creatureNameEE);
    }

    [Constructable]
    public PremiumSpawner(string creatureName) : base(0x6519)
    {
        List <string> creaturesName = new List <string>();
        creaturesName.Add(creatureName);

        List <string> creatureNameAA = new List <string>();
        List <string> creatureNameBB = new List <string>();
        List <string> creatureNameCC = new List <string>();
        List <string> creatureNameDD = new List <string>();
        List <string> creatureNameEE = new List <string>();

        InitSpawn(1, 0, 0, 0, 0, 0, 1, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(10), 0, 4, -1, creaturesName, creatureNameAA, creatureNameBB, creatureNameCC, creatureNameDD, creatureNameEE);
    }

    [Constructable]
    public PremiumSpawner() : base(0x6519)
    {
        List <string> creaturesName = new List <string>();

        List <string> creatureNameAA = new List <string>();
        List <string> creatureNameBB = new List <string>();
        List <string> creatureNameCC = new List <string>();
        List <string> creatureNameDD = new List <string>();
        List <string> creatureNameEE = new List <string>();

        InitSpawn(1, 0, 0, 0, 0, 0, 1, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(10), 0, 4, -1, creaturesName, creatureNameAA, creatureNameBB, creatureNameCC, creatureNameDD, creatureNameEE);
    }

    public PremiumSpawner(int amount, int subamountA, int subamountB, int subamountC, int subamountD, int subamountE, int spawnid, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, int walkingRange, List <string> creaturesName, List <string> creatureNameAA, List <string> creatureNameBB, List <string> creatureNameCC, List <string> creatureNameDD, List <string> creatureNameEE)
        : base(0x6519)
    {
        InitSpawn(amount, subamountA, subamountB, subamountC, subamountD, subamountE, spawnid, minDelay, maxDelay, team, homeRange, walkingRange, creaturesName, creatureNameAA, creatureNameBB, creatureNameCC, creatureNameDD, creatureNameEE);
    }

    public override string DefaultName
    {
        get { return "PremiumSpawner"; }
    }

    public void InitSpawn(int amount, int subamountA, int subamountB, int subamountC, int subamountD, int subamountE, int SpawnID, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, int walkingRange, List <string> creaturesName, List <string> creatureNameAA, List <string> creatureNameBB, List <string> creatureNameCC, List <string> creatureNameDD, List <string> creatureNameEE)
    {
        Name             = "PremiumSpawner";
        m_SpawnID        = SpawnID;
        Visible          = false;
        Movable          = false;
        m_Running        = true;
        m_Group          = false;
        m_MinDelay       = minDelay;
        m_MaxDelay       = maxDelay;
        m_Count          = amount;
        m_CountA         = subamountA;
        m_CountB         = subamountB;
        m_CountC         = subamountC;
        m_CountD         = subamountD;
        m_CountE         = subamountE;
        m_Team           = team;
        m_HomeRange      = homeRange;
        m_WalkingRange   = walkingRange;
        m_CreaturesName  = creaturesName;
        m_CreaturesNameA = creatureNameAA;
        m_CreaturesNameB = creatureNameBB;
        m_CreaturesNameC = creatureNameCC;
        m_CreaturesNameD = creatureNameDD;
        m_CreaturesNameE = creatureNameEE;
        m_Creatures      = new List <IEntity>();
        m_CreaturesA     = new List <IEntity>();
        m_CreaturesB     = new List <IEntity>();
        m_CreaturesC     = new List <IEntity>();
        m_CreaturesD     = new List <IEntity>();
        m_CreaturesE     = new List <IEntity>();
        DoTimer(TimeSpan.FromSeconds(1));
    }

    public PremiumSpawner(Serial serial) : base(serial)
    {
    }

    public override void OnDoubleClick(Mobile from)
    {
        if (from.AccessLevel < AccessLevel.GameMaster)
        {
            return;
        }

        PremiumSpawnerGump g = new PremiumSpawnerGump(this);
        from.SendGump(g);
    }

    public override void GetProperties(ObjectPropertyList list)
    {
        base.GetProperties(list);

        if (m_Running)
        {
            list.Add(1060742);                       // active

            list.Add(1060656, m_Count.ToString());
            list.Add(1061169, m_HomeRange.ToString());
            list.Add(1060658, "walking range\t{0}", m_WalkingRange);

            list.Add(1060663, "SpawnID\t{0}", m_SpawnID.ToString());

//				list.Add( 1060659, "group\t{0}", m_Group );
//				list.Add( 1060660, "team\t{0}", m_Team );
            list.Add(1060661, "speed\t{0} to {1}", m_MinDelay, m_MaxDelay);

            for (int i = 0; i < 2 && i < m_CreaturesName.Count; ++i)
            {
                list.Add(1060662 + i, "{0}\t{1}", m_CreaturesName[i], CountCreatures(m_CreaturesName[i]));
            }
        }
        else
        {
            list.Add(1060743);                       // inactive
        }
    }

    public override void OnSingleClick(Mobile from)
    {
        base.OnSingleClick(from);

        if (m_Running)
        {
            LabelTo(from, "[Running]");
        }
        else
        {
            LabelTo(from, "[Off]");
        }
    }

    public void Start()
    {
        if (!m_Running)
        {
            if (m_CreaturesName.Count > 0 || m_CreaturesNameA.Count > 0 || m_CreaturesNameB.Count > 0 || m_CreaturesNameC.Count > 0 || m_CreaturesNameD.Count > 0 || m_CreaturesNameE.Count > 0)
            {
                m_Running = true;
                DoTimer();
            }
        }
    }

    public void Stop()
    {
        if (m_Running)
        {
            m_Timer.Stop();
            m_Running = false;
        }
    }

    public static string ParseType(string s)
    {
        return s.Split(null, 2)[0];
    }

    public void Defrag()
    {
        bool removed = false;

        for (int i = 0; i < m_Creatures.Count; ++i)
        {
            IEntity e = m_Creatures[i];

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    m_Creatures.RemoveAt(i);
                    --i;
                    removed = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    m_Creatures.RemoveAt(i);
                    --i;
                    removed = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        m_Creatures.RemoveAt(i);
                        --i;
                        removed = true;
                    }
                }
            }
            else
            {
                m_Creatures.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        for (int i = 0; i < m_CreaturesA.Count; ++i)
        {
            IEntity e = m_CreaturesA[i];

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    m_CreaturesA.RemoveAt(i);
                    --i;
                    removed = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    m_CreaturesA.RemoveAt(i);
                    --i;
                    removed = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        m_CreaturesA.RemoveAt(i);
                        --i;
                        removed = true;
                    }
                }
            }
            else
            {
                m_CreaturesA.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        for (int i = 0; i < m_CreaturesB.Count; ++i)
        {
            IEntity e = m_CreaturesB[i];

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    m_CreaturesB.RemoveAt(i);
                    --i;
                    removed = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    m_CreaturesB.RemoveAt(i);
                    --i;
                    removed = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        m_CreaturesB.RemoveAt(i);
                        --i;
                        removed = true;
                    }
                }
            }
            else
            {
                m_CreaturesB.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        for (int i = 0; i < m_CreaturesC.Count; ++i)
        {
            IEntity e = m_CreaturesC[i];

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    m_CreaturesC.RemoveAt(i);
                    --i;
                    removed = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    m_CreaturesC.RemoveAt(i);
                    --i;
                    removed = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        m_CreaturesC.RemoveAt(i);
                        --i;
                        removed = true;
                    }
                }
            }
            else
            {
                m_CreaturesC.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        for (int i = 0; i < m_CreaturesD.Count; ++i)
        {
            IEntity e = m_CreaturesD[i];

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    m_CreaturesD.RemoveAt(i);
                    --i;
                    removed = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    m_CreaturesD.RemoveAt(i);
                    --i;
                    removed = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        m_CreaturesD.RemoveAt(i);
                        --i;
                        removed = true;
                    }
                }
            }
            else
            {
                m_CreaturesD.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        for (int i = 0; i < m_CreaturesE.Count; ++i)
        {
            IEntity e = m_CreaturesE[i];

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    m_CreaturesE.RemoveAt(i);
                    --i;
                    removed = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    m_CreaturesE.RemoveAt(i);
                    --i;
                    removed = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;
                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        m_CreaturesE.RemoveAt(i);
                        --i;
                        removed = true;
                    }
                }
            }
            else
            {
                m_CreaturesE.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        if (removed)
        {
            InvalidateProperties();
        }
    }

    public void OnTick()
    {
        DoTimer();

        if (m_Group)
        {
            Defrag();

            if (m_Creatures.Count == 0 || m_CreaturesA.Count == 0 || m_CreaturesB.Count == 0 || m_CreaturesC.Count == 0 || m_CreaturesD.Count == 0 || m_CreaturesE.Count == 0)
            {
                Respawn();
            }
            else
            {
                return;
            }
        }
        else
        {
            Spawn();
            SpawnA();
            SpawnB();
            SpawnC();
            SpawnD();
            SpawnE();
        }
    }

    public static void Reconfigure(PremiumSpawner spawner, bool respawn)
    {
        if (spawner.SpawnID == 8888)
        {
            spawner.Count = ( int )(spawner.CountE * 0.15);
            if (Utility.RandomMinMax(1, 10) == 1)
            {
                spawner.Count = ( int )(spawner.CountE * 0.20);
            }
            if (spawner.Count < 1)
            {
                spawner.Count = 1;
            }

            spawner.CountA = ( int )(spawner.CountE * 0.12);
            if (spawner.CountA < 1 && Utility.RandomMinMax(1, 5) == 1)
            {
                spawner.CountA = 1;
            }

            spawner.CountB = ( int )(spawner.CountE * 0.09);
            if (spawner.CountB < 1 && Utility.RandomMinMax(1, 5) == 1)
            {
                spawner.CountB = 1;
            }

            spawner.CountC = ( int )(spawner.CountE * 0.06);
            if (spawner.CountC < 1 && Utility.RandomMinMax(1, 5) == 1)
            {
                spawner.CountC = 1;
            }

            spawner.CountD = ( int )(spawner.CountE * 0.03);
            if (spawner.CountD < 1 && Utility.RandomMinMax(1, 5) == 1)
            {
                spawner.CountD = 1;
            }

            if (respawn)
            {
                spawner.Respawn();
            }
            else
            {
                spawner.RemoveCreatures();
                spawner.RemoveCreaturesA();
                spawner.RemoveCreaturesB();
                spawner.RemoveCreaturesC();
                spawner.RemoveCreaturesD();
                spawner.RemoveCreaturesE();
            }
        }
    }

    public static void SpreadOut(Mobile m)
    {
        if (m is BaseVendor || m is Adventurers || m is Jedi)
        {
            ///////////////// SPREAD WANDERING HEALERS AROUND THE LAND /////////////////
            if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.Lodor)
            {
                m.Location = Worlds.GetRandomLocation("the Land of Lodoria", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Land of Sosaria", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.SerpentIsland)
            {
                m.Location = Worlds.GetRandomLocation("the Serpent Island", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.IslesDread)
            {
                m.Location = Worlds.GetRandomLocation("the Isles of Dread", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 1125 && m.Y >= 298 && m.X <= 1131 && m.Y <= 305 && m.Map == Map.SavagedEmpire)
            {
                m.Location = Worlds.GetRandomLocation("the Savaged Empire", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 5457 && m.Y >= 3300 && m.X <= 5459 && m.Y <= 3302 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Land of Ambrosia", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 608 && m.Y >= 4090 && m.X <= 704 && m.Y <= 4096 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Island of Umber Veil", "land"); m.WhisperHue = 911;
            }
            else if (m.X >= 6126 && m.Y >= 827 && m.X <= 6132 && m.Y <= 833 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Bottle World of Kuldar", "land"); m.WhisperHue = 911;
            }
            else if (m.X == 4 && m.Y == 4 && m.Map == Map.Underworld)
            {
                m.Location = Worlds.GetRandomLocation("the Underworld", "land"); m.WhisperHue = 911;
            }
        }
        else
        {
            ///////////////// SPREAD SEA SPAWNS OVER THE OCEANS AROUND THE LAND /////////////////
            if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.Lodor)
            {
                m.Location = Worlds.GetRandomLocation("the Land of Lodoria", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Land of Sosaria", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.SerpentIsland)
            {
                m.Location = Worlds.GetRandomLocation("the Serpent Island", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 0 && m.Y >= 0 && m.X <= 6 && m.Y <= 6 && m.Map == Map.IslesDread)
            {
                m.Location = Worlds.GetRandomLocation("the Isles of Dread", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 1125 && m.Y >= 298 && m.X <= 1131 && m.Y <= 305 && m.Map == Map.SavagedEmpire)
            {
                m.Location = Worlds.GetRandomLocation("the Savaged Empire", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 5457 && m.Y >= 3300 && m.X <= 5459 && m.Y <= 3302 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Land of Ambrosia", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 608 && m.Y >= 4090 && m.X <= 704 && m.Y <= 4096 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Island of Umber Veil", "sea"); m.WhisperHue = 999;
            }
            else if (m.X >= 6126 && m.Y >= 827 && m.X <= 6132 && m.Y <= 833 && m.Map == Map.Sosaria)
            {
                m.Location = Worlds.GetRandomLocation("the Bottle World of Kuldar", "sea"); m.WhisperHue = 999;
            }
            else if (m.X == 3 && m.Y == 3 && m.Map == Map.Underworld)
            {
                m.Location = Worlds.GetRandomLocation("the Underworld", "sea"); m.WhisperHue = 999;
            }
            else if (m.X == 4 && m.Y == 4 && m.Map == Map.Underworld)
            {
                m.Location = Worlds.GetRandomLocation("the Underworld", "land"); m.WhisperHue = 911;
            }

            if (m.WhisperHue == 999 && (m is Balron || m is Daemon || m is RidingDragon || m is Dragons || m is Wyrms))
            {
                m.CanSwim = true;
            }
        }

        if (Worlds.IsMassSpawnZone(m.Map, m.X, m.Y))
        {
            m.Delete();
        }
    }

    public static void SpreadItems(Item i)
    {
        if (i is LandChest || i is StrangePortal)
        {
            ///////////////// SPREAD CORPSES AND PORTALS AROUND THE LAND /////////////////
            if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.Lodor)
            {
                i.Location = Worlds.GetRandomLocation("the Land of Lodoria", "land");
            }
            else if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Land of Sosaria", "land");
            }
            else if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.SerpentIsland)
            {
                i.Location = Worlds.GetRandomLocation("the Serpent Island", "land");
            }
            else if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.IslesDread)
            {
                i.Location = Worlds.GetRandomLocation("the Isles of Dread", "land");
            }
            else if (i.X >= 1125 && i.Y >= 298 && i.X <= 1131 && i.Y <= 305 && i.Map == Map.SavagedEmpire)
            {
                i.Location = Worlds.GetRandomLocation("the Savaged Empire", "land");
            }
            else if (i.X >= 5457 && i.Y >= 3300 && i.X <= 5459 && i.Y <= 3302 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Land of Ambrosia", "land");
            }
            else if (i.X >= 608 && i.Y >= 4090 && i.X <= 704 && i.Y <= 4096 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Island of Umber Veil", "land");
            }
            else if (i.X == 4 && i.Y == 4 && i.Map == Map.Underworld)
            {
                i.Location = Worlds.GetRandomLocation("the Underworld", "land");
            }
        }
        else if (i is WaterChest)
        {
            ///////////////// SPREAD BOATS OVER THE OCEANS /////////////////
            if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.Lodor)
            {
                i.Location = Worlds.GetRandomLocation("the Land of Lodoria", "sea");
            }
            else if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Land of Sosaria", "sea");
            }
            else if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.SerpentIsland)
            {
                i.Location = Worlds.GetRandomLocation("the Serpent Island", "sea");
            }
            else if (i.X >= 0 && i.Y >= 0 && i.X <= 6 && i.Y <= 6 && i.Map == Map.IslesDread)
            {
                i.Location = Worlds.GetRandomLocation("the Isles of Dread", "sea");
            }
            else if (i.X >= 1125 && i.Y >= 298 && i.X <= 1131 && i.Y <= 305 && i.Map == Map.SavagedEmpire)
            {
                i.Location = Worlds.GetRandomLocation("the Savaged Empire", "sea");
            }
            else if (i.X >= 5457 && i.Y >= 3300 && i.X <= 5459 && i.Y <= 3302 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Land of Ambrosia", "sea");
            }
            else if (i.X >= 608 && i.Y >= 4090 && i.X <= 704 && i.Y <= 4096 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Island of Umber Veil", "sea");
            }
            else if (i.X >= 6126 && i.Y >= 827 && i.X <= 6132 && i.Y <= 833 && i.Map == Map.Sosaria)
            {
                i.Location = Worlds.GetRandomLocation("the Bottle World of Kuldar", "sea");
            }
            else if (i.X == 3 && i.Y == 3 && i.Map == Map.Underworld)
            {
                i.Location = Worlds.GetRandomLocation("the Underworld", "sea");
            }
        }

        if (Worlds.IsMassSpawnZone(i.Map, i.X, i.Y))
        {
            i.Delete();
        }
    }

    public void Respawn()             // remove all creatures and spawn all again
    {
        RemoveCreatures();
        RemoveCreaturesA();
        RemoveCreaturesB();
        RemoveCreaturesC();
        RemoveCreaturesD();
        RemoveCreaturesE();

        for (int i = 0; i < m_Count; i++)
        {
            Spawn();
        }
        for (int i = 0; i < m_CountA; i++)
        {
            SpawnA();
        }
        for (int i = 0; i < m_CountB; i++)
        {
            SpawnB();
        }
        for (int i = 0; i < m_CountC; i++)
        {
            SpawnC();
        }
        for (int i = 0; i < m_CountD; i++)
        {
            SpawnD();
        }
        for (int i = 0; i < m_CountE; i++)
        {
            SpawnE();
        }
    }

    public void Spawn()
    {
        if (CreaturesNameCount > 0)
        {
            Spawn(Utility.Random(CreaturesNameCount));
        }
    }

    public void SpawnA()
    {
        if (CreaturesNameCountA > 0)
        {
            SpawnA(Utility.Random(CreaturesNameCountA));
        }
    }

    public void SpawnB()
    {
        if (CreaturesNameCountB > 0)
        {
            SpawnB(Utility.Random(CreaturesNameCountB));
        }
    }

    public void SpawnC()
    {
        if (CreaturesNameCountC > 0)
        {
            SpawnC(Utility.Random(CreaturesNameCountC));
        }
    }

    public void SpawnD()
    {
        if (CreaturesNameCountD > 0)
        {
            SpawnD(Utility.Random(CreaturesNameCountD));
        }
    }

    public void SpawnE()
    {
        if (CreaturesNameCountE > 0)
        {
            SpawnE(Utility.Random(CreaturesNameCountE));
        }
    }

    public void Spawn(string creatureName)
    {
        for (int i = 0; i < m_CreaturesName.Count; i++)
        {
            if (m_CreaturesName[i] == creatureName)
            {
                Spawn(i);
                break;
            }
        }
    }

    public void SpawnA(string creatureNameA)
    {
        for (int i = 0; i < m_CreaturesNameA.Count; i++)
        {
            if ((string)m_CreaturesNameA[i] == creatureNameA)
            {
                SpawnA(i);
                break;
            }
        }
    }

    public void SpawnB(string creatureNameB)
    {
        for (int i = 0; i < m_CreaturesNameB.Count; i++)
        {
            if ((string)m_CreaturesNameB[i] == creatureNameB)
            {
                SpawnB(i);
                break;
            }
        }
    }

    public void SpawnC(string creatureNameC)
    {
        for (int i = 0; i < m_CreaturesNameC.Count; i++)
        {
            if ((string)m_CreaturesNameC[i] == creatureNameC)
            {
                SpawnC(i);
                break;
            }
        }
    }

    public void SpawnD(string creatureNameD)
    {
        for (int i = 0; i < m_CreaturesNameD.Count; i++)
        {
            if ((string)m_CreaturesNameD[i] == creatureNameD)
            {
                SpawnD(i);
                break;
            }
        }
    }

    public void SpawnE(string creatureNameE)
    {
        for (int i = 0; i < m_CreaturesNameE.Count; i++)
        {
            if ((string)m_CreaturesNameE[i] == creatureNameE)
            {
                SpawnE(i);
                break;
            }
        }
    }

    protected virtual IEntity CreateSpawnedObject(int index)
    {
        if (index >= m_CreaturesName.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_CreaturesName[index]));

        if (type != null)
        {
            try
            {
                return Build(CommandSystem.Split(m_CreaturesName[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    protected virtual IEntity CreateSpawnedObjectA(int index)
    {
        if (index >= m_CreaturesNameA.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_CreaturesNameA[index]));

        if (type != null)
        {
            try
            {
                return Build(CommandSystem.Split(m_CreaturesNameA[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    protected virtual IEntity CreateSpawnedObjectB(int index)
    {
        if (index >= m_CreaturesNameB.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_CreaturesNameB[index]));

        if (type != null)
        {
            try
            {
                return Build(CommandSystem.Split(m_CreaturesNameB[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    protected virtual IEntity CreateSpawnedObjectC(int index)
    {
        if (index >= m_CreaturesNameC.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_CreaturesNameC[index]));

        if (type != null)
        {
            try
            {
                return Build(CommandSystem.Split(m_CreaturesNameC[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    protected virtual IEntity CreateSpawnedObjectD(int index)
    {
        if (index >= m_CreaturesNameD.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_CreaturesNameD[index]));

        if (type != null)
        {
            try
            {
                return Build(CommandSystem.Split(m_CreaturesNameD[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    protected virtual IEntity CreateSpawnedObjectE(int index)
    {
        if (index >= m_CreaturesNameE.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_CreaturesNameE[index]));

        if (type != null)
        {
            try
            {
                return Build(CommandSystem.Split(m_CreaturesNameE[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    public static IEntity Build(string[] args)
    {
        string name = args[0];

        Add.FixArgs(ref args);

        string[,] props = null;

        for (int i = 0; i < args.Length; ++i)
        {
            if (Insensitive.Equals(args[i], "set"))
            {
                int remains = args.Length - i - 1;

                if (remains >= 2)
                {
                    props = new string[remains / 2, 2];

                    remains /= 2;

                    for (int j = 0; j < remains; ++j)
                    {
                        props[j, 0] = args[i + (j * 2) + 1];
                        props[j, 1] = args[i + (j * 2) + 2];
                    }

                    Add.FixSetString(ref args, i);
                }

                break;
            }
        }

        Type type = ScriptCompiler.FindTypeByName(name);

        if (!Add.IsEntity(type))
        {
            return null;
        }

        PropertyInfo[] realProps = null;

        if (props != null)
        {
            realProps = new PropertyInfo[props.GetLength(0)];

            PropertyInfo[] allProps = type.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            for (int i = 0; i < realProps.Length; ++i)
            {
                PropertyInfo thisProp = null;

                string propName = props[i, 0];

                for (int j = 0; thisProp == null && j < allProps.Length; ++j)
                {
                    if (Insensitive.Equals(propName, allProps[j].Name))
                    {
                        thisProp = allProps[j];
                    }
                }

                if (thisProp != null)
                {
                    CPA attr = Properties.GetCPA(thisProp);

                    if (attr != null && AccessLevel.GameMaster >= attr.WriteLevel && thisProp.CanWrite && !attr.ReadOnly)
                    {
                        realProps[i] = thisProp;
                    }
                }
            }
        }

        ConstructorInfo[] ctors = type.GetConstructors();

        for (int i = 0; i < ctors.Length; ++i)
        {
            ConstructorInfo ctor = ctors[i];

            if (!Add.IsConstructable(ctor, AccessLevel.GameMaster))
            {
                continue;
            }

            ParameterInfo[] paramList = ctor.GetParameters();

            if (args.Length == paramList.Length)
            {
                object[] paramValues = Add.ParseValues(paramList, args);

                if (paramValues == null)
                {
                    continue;
                }

                object built = ctor.Invoke(paramValues);

                if (built != null && realProps != null)
                {
                    for (int j = 0; j < realProps.Length; ++j)
                    {
                        if (realProps[j] == null)
                        {
                            continue;
                        }

                        string result = Properties.InternalSetValue(built, realProps[j], props[j, 1]);
                    }
                }

                return (IEntity)built;
            }
        }

        return null;
    }

    public void Spawn(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || CreaturesNameCount == 0 || index >= CreaturesNameCount || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_Creatures.Count >= m_Count)
        {
            return;
        }

        IEntity ent = CreateSpawnedObject(index);

        if (ent is Mobile)
        {
            Mobile m = (Mobile)ent;

            if (m is Fox)
            {
                m.Delete();

                switch (Utility.RandomMinMax(1, 5))
                {
                    case 1: m = new Squirrel(); break;
                    case 2: m = new Ferret(); break;
                    case 3: m = new Rabbit(); break;
                    case 4: m = new Rabbit(); break;
                    case 5: m = new Fox(); break;
                }
            }
            if (!MyServerSettings.AllowElephants() && m is Mastadon)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && m is Mammoth)
            {
                m.Delete(); m = new PolarBear();
            }
            else if (!MyServerSettings.AllowElephants() && m is Elephant)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && (m is Zebra || m is ZebraRiding))
            {
                m.Delete(); m = new Horse();
            }
            else if (!MyServerSettings.AllowFox() && m is Fox)
            {
                m.Delete(); m = new GreyWolf();
            }

            m_Creatures.Add(m);

            Point3D loc = (m is BaseVendor ? this.Location : GetSpawnPosition());

            if (m is WanderingHealer || m is Adventurers || m is Jedi)
            {
                loc = GetSpawnPosition();
            }
            else if (m is Syth && SpawnID == 9999)
            {
                loc = GetSpawnSpotLandDungeon();
            }

            m.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            m.MoveToWorld(loc, map);

            if (m is BaseCreature)
            {
                BaseCreature c = (BaseCreature)m;

                if (m_WalkingRange >= 0)
                {
                    c.RangeHome = m_WalkingRange;
                }
                else
                {
                    c.RangeHome = m_HomeRange;
                }

                c.CurrentWayPoint = m_WayPoint;

                if (m_Team > 0)
                {
                    c.Team = m_Team;
                }

                c.Home = this.Location;

                Server.Misc.MorphingTime.SetGender(m);

                if (Region.Find(this.Location, this.Map) != Region.Find(m.Location, m.Map))
                {
                    m.Delete(); Defrag(); return;
                }                                                                                                                                          // REMOVE IF NOT IN SAME REGION

                if ((this.Count + this.CountA + this.CountB + this.CountC + this.CountD + this.CountE) == 1)
                {
                    c.SpawnerID = this.Serial;
                    Running     = false;
                }
            }

            m.OnAfterSpawn();
        }
        else if (ent is Item)
        {
            Item item = (Item)ent;

            m_Creatures.Add(item);

            Point3D loc = GetSpawnPosition();

            item.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            item.MoveToWorld(loc, map);

            if (Region.Find(this.Location, this.Map) != Region.Find(item.Location, item.Map))
            {
                item.Delete(); Defrag(); return;
            }                                                                                                                                               // REMOVE IF NOT IN SAME REGION

            item.OnAfterSpawn();
        }
    }

    public void SpawnA(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || CreaturesNameCountA == 0 || index >= CreaturesNameCountA || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_CreaturesA.Count >= m_CountA)
        {
            return;
        }

        IEntity ent = CreateSpawnedObjectA(index);

        if (ent is Mobile)
        {
            Mobile m = (Mobile)ent;

            if (m is Fox)
            {
                m.Delete();

                switch (Utility.RandomMinMax(1, 5))
                {
                    case 1: m = new Squirrel(); break;
                    case 2: m = new Ferret(); break;
                    case 3: m = new Rabbit(); break;
                    case 4: m = new Rabbit(); break;
                    case 5: m = new Fox(); break;
                }
            }
            if (!MyServerSettings.AllowElephants() && m is Mastadon)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && m is Mammoth)
            {
                m.Delete(); m = new PolarBear();
            }
            else if (!MyServerSettings.AllowElephants() && m is Elephant)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && (m is Zebra || m is ZebraRiding))
            {
                m.Delete(); m = new Horse();
            }
            else if (!MyServerSettings.AllowFox() && m is Fox)
            {
                m.Delete(); m = new GreyWolf();
            }

            m_CreaturesA.Add(m);

            Point3D loc = (m is BaseVendor ? this.Location : GetSpawnPosition());

            if (m is WanderingHealer || m is Adventurers || m is Jedi)
            {
                loc = GetSpawnPosition();
            }
            else if (m is Syth && SpawnID == 9999)
            {
                loc = GetSpawnSpotLandDungeon();
            }

            m.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            m.MoveToWorld(loc, map);

            if (m is BaseCreature)
            {
                BaseCreature c = (BaseCreature)m;

                if (m_WalkingRange >= 0)
                {
                    c.RangeHome = m_WalkingRange;
                }
                else
                {
                    c.RangeHome = m_HomeRange;
                }

                c.CurrentWayPoint = m_WayPoint;

                if (m_Team > 0)
                {
                    c.Team = m_Team;
                }

                c.Home = this.Location;

                Server.Misc.MorphingTime.SetGender(m);

                if (Region.Find(this.Location, this.Map) != Region.Find(m.Location, m.Map))
                {
                    m.Delete(); Defrag(); return;
                }                                                                                                                                          // REMOVE IF NOT IN SAME REGION
            }

            m.OnAfterSpawn();
        }
        else if (ent is Item)
        {
            Item item = (Item)ent;

            m_CreaturesA.Add(item);

            Point3D loc = GetSpawnPosition();

            item.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            item.MoveToWorld(loc, map);

            if (Region.Find(this.Location, this.Map) != Region.Find(item.Location, item.Map))
            {
                item.Delete(); Defrag(); return;
            }                                                                                                                                               // REMOVE IF NOT IN SAME REGION

            item.OnAfterSpawn();
        }
    }

    public void SpawnB(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || CreaturesNameCountB == 0 || index >= CreaturesNameCountB || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_CreaturesB.Count >= m_CountB)
        {
            return;
        }

        IEntity ent = CreateSpawnedObjectB(index);

        if (ent is Mobile)
        {
            Mobile m = (Mobile)ent;

            if (m is Fox)
            {
                m.Delete();

                switch (Utility.RandomMinMax(1, 5))
                {
                    case 1: m = new Squirrel(); break;
                    case 2: m = new Ferret(); break;
                    case 3: m = new Rabbit(); break;
                    case 4: m = new Rabbit(); break;
                    case 5: m = new Fox(); break;
                }
            }
            if (!MyServerSettings.AllowElephants() && m is Mastadon)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && m is Mammoth)
            {
                m.Delete(); m = new PolarBear();
            }
            else if (!MyServerSettings.AllowElephants() && m is Elephant)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && (m is Zebra || m is ZebraRiding))
            {
                m.Delete(); m = new Horse();
            }
            else if (!MyServerSettings.AllowFox() && m is Fox)
            {
                m.Delete(); m = new GreyWolf();
            }

            m_CreaturesB.Add(m);

            Point3D loc = (m is BaseVendor ? this.Location : GetSpawnPosition());

            if (m is WanderingHealer || m is Adventurers || m is Jedi)
            {
                loc = GetSpawnPosition();
            }
            else if (m is Syth && SpawnID == 9999)
            {
                loc = GetSpawnSpotLandDungeon();
            }

            m.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            m.MoveToWorld(loc, map);

            if (m is BaseCreature)
            {
                BaseCreature c = (BaseCreature)m;

                if (m_WalkingRange >= 0)
                {
                    c.RangeHome = m_WalkingRange;
                }
                else
                {
                    c.RangeHome = m_HomeRange;
                }

                c.CurrentWayPoint = m_WayPoint;

                if (m_Team > 0)
                {
                    c.Team = m_Team;
                }

                c.Home = this.Location;

                Server.Misc.MorphingTime.SetGender(m);

                if (Region.Find(this.Location, this.Map) != Region.Find(m.Location, m.Map))
                {
                    m.Delete(); Defrag(); return;
                }                                                                                                                                          // REMOVE IF NOT IN SAME REGION
            }

            m.OnAfterSpawn();
        }
        else if (ent is Item)
        {
            Item item = (Item)ent;

            m_CreaturesB.Add(item);

            Point3D loc = GetSpawnPosition();

            item.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            item.MoveToWorld(loc, map);

            if (Region.Find(this.Location, this.Map) != Region.Find(item.Location, item.Map))
            {
                item.Delete(); Defrag(); return;
            }                                                                                                                                               // REMOVE IF NOT IN SAME REGION

            item.OnAfterSpawn();
        }
    }

    public void SpawnC(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || CreaturesNameCountC == 0 || index >= CreaturesNameCountC || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_CreaturesC.Count >= m_CountC)
        {
            return;
        }

        IEntity ent = CreateSpawnedObjectC(index);

        if (ent is Mobile)
        {
            Mobile m = (Mobile)ent;

            if (m is Fox)
            {
                m.Delete();

                switch (Utility.RandomMinMax(1, 5))
                {
                    case 1: m = new Squirrel(); break;
                    case 2: m = new Ferret(); break;
                    case 3: m = new Rabbit(); break;
                    case 4: m = new Rabbit(); break;
                    case 5: m = new Fox(); break;
                }
            }
            if (!MyServerSettings.AllowElephants() && m is Mastadon)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && m is Mammoth)
            {
                m.Delete(); m = new PolarBear();
            }
            else if (!MyServerSettings.AllowElephants() && m is Elephant)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && (m is Zebra || m is ZebraRiding))
            {
                m.Delete(); m = new Horse();
            }
            else if (!MyServerSettings.AllowFox() && m is Fox)
            {
                m.Delete(); m = new GreyWolf();
            }

            m_CreaturesC.Add(m);


            Point3D loc = (m is BaseVendor ? this.Location : GetSpawnPosition());

            if (m is WanderingHealer || m is Adventurers || m is Jedi)
            {
                loc = GetSpawnPosition();
            }
            else if (m is Syth && SpawnID == 9999)
            {
                loc = GetSpawnSpotLandDungeon();
            }

            m.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            m.MoveToWorld(loc, map);

            if (m is BaseCreature)
            {
                BaseCreature c = (BaseCreature)m;

                if (m_WalkingRange >= 0)
                {
                    c.RangeHome = m_WalkingRange;
                }
                else
                {
                    c.RangeHome = m_HomeRange;
                }

                c.CurrentWayPoint = m_WayPoint;

                if (m_Team > 0)
                {
                    c.Team = m_Team;
                }

                c.Home = this.Location;

                Server.Misc.MorphingTime.SetGender(m);

                if (Region.Find(this.Location, this.Map) != Region.Find(m.Location, m.Map))
                {
                    m.Delete(); Defrag(); return;
                }                                                                                                                                          // REMOVE IF NOT IN SAME REGION
            }

            m.OnAfterSpawn();
        }
        else if (ent is Item)
        {
            Item item = (Item)ent;

            m_CreaturesC.Add(item);

            Point3D loc = GetSpawnPosition();

            item.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            item.MoveToWorld(loc, map);

            if (Region.Find(this.Location, this.Map) != Region.Find(item.Location, item.Map))
            {
                item.Delete(); Defrag(); return;
            }                                                                                                                                               // REMOVE IF NOT IN SAME REGION

            item.OnAfterSpawn();
        }
    }

    public void SpawnD(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || CreaturesNameCountD == 0 || index >= CreaturesNameCountD || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_CreaturesD.Count >= m_CountD)
        {
            return;
        }

        IEntity ent = CreateSpawnedObjectD(index);

        if (ent is Mobile)
        {
            Mobile m = (Mobile)ent;

            if (m is Fox)
            {
                m.Delete();

                switch (Utility.RandomMinMax(1, 5))
                {
                    case 1: m = new Squirrel(); break;
                    case 2: m = new Ferret(); break;
                    case 3: m = new Rabbit(); break;
                    case 4: m = new Rabbit(); break;
                    case 5: m = new Fox(); break;
                }
            }
            if (!MyServerSettings.AllowElephants() && m is Mastadon)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && m is Mammoth)
            {
                m.Delete(); m = new PolarBear();
            }
            else if (!MyServerSettings.AllowElephants() && m is Elephant)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && (m is Zebra || m is ZebraRiding))
            {
                m.Delete(); m = new Horse();
            }
            else if (!MyServerSettings.AllowFox() && m is Fox)
            {
                m.Delete(); m = new GreyWolf();
            }

            m_CreaturesD.Add(m);

            Point3D loc = (m is BaseVendor ? this.Location : GetSpawnPosition());

            if (m is WanderingHealer || m is Adventurers || m is Jedi)
            {
                loc = GetSpawnPosition();
            }
            else if (m is Syth && SpawnID == 9999)
            {
                loc = GetSpawnSpotLandDungeon();
            }

            m.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            m.MoveToWorld(loc, map);

            if (m is BaseCreature)
            {
                BaseCreature c = (BaseCreature)m;

                if (m_WalkingRange >= 0)
                {
                    c.RangeHome = m_WalkingRange;
                }
                else
                {
                    c.RangeHome = m_HomeRange;
                }

                c.CurrentWayPoint = m_WayPoint;

                if (m_Team > 0)
                {
                    c.Team = m_Team;
                }

                c.Home = this.Location;

                Server.Misc.MorphingTime.SetGender(m);

                if (Region.Find(this.Location, this.Map) != Region.Find(m.Location, m.Map))
                {
                    m.Delete(); Defrag(); return;
                }                                                                                                                                          // REMOVE IF NOT IN SAME REGION
            }

            m.OnAfterSpawn();
        }
        else if (ent is Item)
        {
            Item item = (Item)ent;

            m_CreaturesD.Add(item);

            Point3D loc = GetSpawnPosition();

            item.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            item.MoveToWorld(loc, map);

            if (Region.Find(this.Location, this.Map) != Region.Find(item.Location, item.Map))
            {
                item.Delete(); Defrag(); return;
            }                                                                                                                                               // REMOVE IF NOT IN SAME REGION

            item.OnAfterSpawn();
        }
    }

    public void SpawnE(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || CreaturesNameCountE == 0 || index >= CreaturesNameCountE || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_CreaturesE.Count >= m_CountE)
        {
            return;
        }

        IEntity ent = CreateSpawnedObjectE(index);

        if (ent is Mobile)
        {
            Mobile m = (Mobile)ent;

            if (m is Fox)
            {
                m.Delete();

                switch (Utility.RandomMinMax(1, 5))
                {
                    case 1: m = new Squirrel(); break;
                    case 2: m = new Ferret(); break;
                    case 3: m = new Rabbit(); break;
                    case 4: m = new Rabbit(); break;
                    case 5: m = new Fox(); break;
                }
            }
            if (!MyServerSettings.AllowElephants() && m is Mastadon)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && m is Mammoth)
            {
                m.Delete(); m = new PolarBear();
            }
            else if (!MyServerSettings.AllowElephants() && m is Elephant)
            {
                m.Delete(); m = new GrizzlyBearRiding();
            }
            else if (!MyServerSettings.AllowElephants() && (m is Zebra || m is ZebraRiding))
            {
                m.Delete(); m = new Horse();
            }
            else if (!MyServerSettings.AllowFox() && m is Fox)
            {
                m.Delete(); m = new GreyWolf();
            }

            m_CreaturesE.Add(m);

            Point3D loc = (m is BaseVendor ? this.Location : GetSpawnPosition());

            if (m is WanderingHealer || m is Adventurers || m is Jedi)
            {
                loc = GetSpawnPosition();
            }
            else if (m is Syth && SpawnID == 9999)
            {
                loc = GetSpawnSpotLandDungeon();
            }

            m.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            m.MoveToWorld(loc, map);

            if (m is BaseCreature)
            {
                BaseCreature c = (BaseCreature)m;

                if (m_WalkingRange >= 0)
                {
                    c.RangeHome = m_WalkingRange;
                }
                else
                {
                    c.RangeHome = m_HomeRange;
                }

                c.CurrentWayPoint = m_WayPoint;

                if (m_Team > 0)
                {
                    c.Team = m_Team;
                }

                c.Home = this.Location;

                Server.Misc.MorphingTime.SetGender(m);

                if (Region.Find(this.Location, this.Map) != Region.Find(m.Location, m.Map))
                {
                    m.Delete(); Defrag(); return;
                }                                                                                                                                          // REMOVE IF NOT IN SAME REGION
            }

            m.OnAfterSpawn();
        }
        else if (ent is Item)
        {
            Item item = (Item)ent;

            m_CreaturesE.Add(item);

            Point3D loc = GetSpawnPosition();

            item.OnBeforeSpawn(loc, map);
            InvalidateProperties();

            item.MoveToWorld(loc, map);

            if (Region.Find(this.Location, this.Map) != Region.Find(item.Location, item.Map))
            {
                item.Delete(); Defrag(); return;
            }                                                                                                                                               // REMOVE IF NOT IN SAME REGION

            item.OnAfterSpawn();
        }
    }

    public Point3D GetSpawnPosition()
    {
        Map map = Map;

        if (map == null)
        {
            return Location;
        }

        // Try 10 times to find a Spawnable location.
        for (int i = 0; i < 10; i++)
        {
            int x, y;

            if (m_HomeRange > 0)
            {
                x = Location.X + (Utility.Random((m_HomeRange * 2) + 1) - m_HomeRange);
                y = Location.Y + (Utility.Random((m_HomeRange * 2) + 1) - m_HomeRange);
            }
            else
            {
                x = Location.X;
                y = Location.Y;
            }

            int z = Map.GetAverageZ(x, y);

            Region regSpawner = Region.Find(this.Location, this.Map);
            Region regSpawn1  = Region.Find(new Point3D(x, y, this.Z), this.Map);
            Region regSpawn2  = Region.Find(new Point3D(x, y, z), this.Map);

            if (Map.CanSpawnMobile(new Point2D(x, y), this.Z) && regSpawner == regSpawn1)
            {
                return new Point3D(x, y, this.Z);
            }
            else if (Map.CanSpawnMobile(new Point2D(x, y), z) && regSpawner == regSpawn2)
            {
                return new Point3D(x, y, z);
            }
        }

        return this.Location;
    }

    public Point3D GetSpawnSpotLandDungeon()
    {
        if (Utility.RandomBool())
        {
            return Server.Misc.Worlds.GetRandomDungeonSpot(Map);
        }

        return Server.Misc.Worlds.GetRandomLocation(Server.Misc.Worlds.GetMyWorld(Map, Location, X, Y), "land");
    }

    public void DoTimer()
    {
        if (!m_Running)
        {
            return;
        }

        int minSeconds = (int)m_MinDelay.TotalSeconds;
        int maxSeconds = (int)m_MaxDelay.TotalSeconds;

        TimeSpan delay = TimeSpan.FromSeconds(Utility.RandomMinMax(minSeconds, maxSeconds));
        DoTimer(delay);
    }

    public void DoTimer(TimeSpan delay)
    {
        if (!m_Running)
        {
            return;
        }

        m_End = DateTime.Now + delay;

        if (m_Timer != null)
        {
            m_Timer.Stop();
        }

        m_Timer = new InternalTimer(this, delay);
        m_Timer.Start();
    }

    private class InternalTimer : Timer
    {
        private PremiumSpawner m_PremiumSpawner;

        public InternalTimer(PremiumSpawner spawner, TimeSpan delay) : base(delay)
        {
            if (spawner.IsFull || spawner.IsFulla || spawner.IsFullb || spawner.IsFullc || spawner.IsFulld || spawner.IsFulle)
            {
                Priority = TimerPriority.FiveSeconds;
            }
            else
            {
                Priority = TimerPriority.OneSecond;
            }

            m_PremiumSpawner = spawner;
        }

        protected override void OnTick()
        {
            if (m_PremiumSpawner != null)
            {
                if (!m_PremiumSpawner.Deleted)
                {
                    m_PremiumSpawner.OnTick();
                }
            }
        }
    }

    public int CountCreatures(string creatureName)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_Creatures.Count; ++i)
        {
            if (Insensitive.Equals(creatureName, m_Creatures[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public int CountCreaturesA(string creatureNameA)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_CreaturesA.Count; ++i)
        {
            if (Insensitive.Equals(creatureNameA, m_CreaturesA[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public int CountCreaturesB(string creatureNameB)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_CreaturesB.Count; ++i)
        {
            if (Insensitive.Equals(creatureNameB, m_CreaturesB[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public int CountCreaturesC(string creatureNameC)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_CreaturesC.Count; ++i)
        {
            if (Insensitive.Equals(creatureNameC, m_CreaturesC[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public int CountCreaturesD(string creatureNameD)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_CreaturesD.Count; ++i)
        {
            if (Insensitive.Equals(creatureNameD, m_CreaturesD[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public int CountCreaturesE(string creatureNameE)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_CreaturesE.Count; ++i)
        {
            if (Insensitive.Equals(creatureNameE, m_CreaturesE[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public void RemoveCreatures(string creatureName)
    {
        Defrag();

        for (int i = 0; i < m_Creatures.Count; ++i)
        {
            IEntity e = m_Creatures[i];

            if (Insensitive.Equals(creatureName, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesA(string creatureNameA)
    {
        Defrag();

        for (int i = 0; i < m_CreaturesA.Count; ++i)
        {
            IEntity e = m_CreaturesA[i];

            if (Insensitive.Equals(creatureNameA, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesB(string creatureNameB)
    {
        Defrag();

        for (int i = 0; i < m_CreaturesB.Count; ++i)
        {
            IEntity e = m_CreaturesB[i];

            if (Insensitive.Equals(creatureNameB, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesC(string creatureNameC)
    {
        Defrag();

        for (int i = 0; i < m_CreaturesC.Count; ++i)
        {
            IEntity e = m_CreaturesC[i];

            if (Insensitive.Equals(creatureNameC, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesD(string creatureNameD)
    {
        Defrag();

        for (int i = 0; i < m_CreaturesD.Count; ++i)
        {
            IEntity e = m_CreaturesD[i];

            if (Insensitive.Equals(creatureNameD, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesE(string creatureNameE)
    {
        Defrag();

        for (int i = 0; i < m_CreaturesE.Count; ++i)
        {
            IEntity e = m_CreaturesE[i];

            if (Insensitive.Equals(creatureNameE, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveCreatures()
    {
        Defrag();

        for (int i = 0; i < m_Creatures.Count; ++i)
        {
            m_Creatures[i].Delete();
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesA()
    {
        Defrag();

        for (int i = 0; i < m_CreaturesA.Count; ++i)
        {
            m_CreaturesA[i].Delete();
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesB()
    {
        Defrag();

        for (int i = 0; i < m_CreaturesB.Count; ++i)
        {
            m_CreaturesB[i].Delete();
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesC()
    {
        Defrag();

        for (int i = 0; i < m_CreaturesC.Count; ++i)
        {
            m_CreaturesC[i].Delete();
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesD()
    {
        Defrag();

        for (int i = 0; i < m_CreaturesD.Count; ++i)
        {
            m_CreaturesD[i].Delete();
        }

        InvalidateProperties();
    }

    public void RemoveCreaturesE()
    {
        Defrag();

        for (int i = 0; i < m_CreaturesE.Count; ++i)
        {
            m_CreaturesE[i].Delete();
        }

        InvalidateProperties();
    }

    public void BringToHome()
    {
        Defrag();

        for (int i = 0; i < m_Creatures.Count; ++i)
        {
            IEntity e = m_Creatures[i];

            if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                m.MoveToWorld(Location, Map);
            }
            else if (e is Item)
            {
                Item item = (Item)e;

                item.MoveToWorld(Location, Map);
            }
        }

        for (int i = 0; i < m_CreaturesA.Count; ++i)
        {
            object o = m_CreaturesA[i];

            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.MoveToWorld(Location, Map);
            }
            else if (o is Item)
            {
                Item item = (Item)o;

                item.MoveToWorld(Location, Map);
            }
        }

        for (int i = 0; i < m_CreaturesB.Count; ++i)
        {
            object o = m_CreaturesB[i];

            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.MoveToWorld(Location, Map);
            }
            else if (o is Item)
            {
                Item item = (Item)o;

                item.MoveToWorld(Location, Map);
            }
        }

        for (int i = 0; i < m_CreaturesC.Count; ++i)
        {
            object o = m_CreaturesC[i];

            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.MoveToWorld(Location, Map);
            }
            else if (o is Item)
            {
                Item item = (Item)o;

                item.MoveToWorld(Location, Map);
            }
        }

        for (int i = 0; i < m_CreaturesD.Count; ++i)
        {
            object o = m_CreaturesD[i];

            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.MoveToWorld(Location, Map);
            }
            else if (o is Item)
            {
                Item item = (Item)o;

                item.MoveToWorld(Location, Map);
            }
        }

        for (int i = 0; i < m_CreaturesE.Count; ++i)
        {
            object o = m_CreaturesE[i];

            if (o is Mobile)
            {
                Mobile m = (Mobile)o;

                m.MoveToWorld(Location, Map);
            }
            else if (o is Item)
            {
                Item item = (Item)o;

                item.MoveToWorld(Location, Map);
            }
        }
    }

    public override void OnDelete()
    {
        base.OnDelete();

        RemoveCreatures();
        RemoveCreaturesA();
        RemoveCreaturesB();
        RemoveCreaturesC();
        RemoveCreaturesD();
        RemoveCreaturesE();
        if (m_Timer != null)
        {
            m_Timer.Stop();
        }
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)4);                    // version
        writer.Write(m_WalkingRange);

        writer.Write(m_SpawnID);
        writer.Write(m_CountA);
        writer.Write(m_CountB);
        writer.Write(m_CountC);
        writer.Write(m_CountD);
        writer.Write(m_CountE);

        writer.Write(m_WayPoint);

        writer.Write(m_Group);

        writer.Write(m_MinDelay);
        writer.Write(m_MaxDelay);
        writer.Write(m_Count);
        writer.Write(m_Team);
        writer.Write(m_HomeRange);
        writer.Write(m_Running);

        if (m_Running)
        {
            writer.WriteDeltaTime(m_End);
        }

        writer.Write(m_CreaturesName.Count);

        for (int i = 0; i < m_CreaturesName.Count; ++i)
        {
            writer.Write(m_CreaturesName[i]);
        }

        writer.Write(m_CreaturesNameA.Count);

        for (int i = 0; i < m_CreaturesNameA.Count; ++i)
        {
            writer.Write((string)m_CreaturesNameA[i]);
        }

        writer.Write(m_CreaturesNameB.Count);

        for (int i = 0; i < m_CreaturesNameB.Count; ++i)
        {
            writer.Write((string)m_CreaturesNameB[i]);
        }

        writer.Write(m_CreaturesNameC.Count);

        for (int i = 0; i < m_CreaturesNameC.Count; ++i)
        {
            writer.Write((string)m_CreaturesNameC[i]);
        }

        writer.Write(m_CreaturesNameD.Count);

        for (int i = 0; i < m_CreaturesNameD.Count; ++i)
        {
            writer.Write((string)m_CreaturesNameD[i]);
        }

        writer.Write(m_CreaturesNameE.Count);

        for (int i = 0; i < m_CreaturesNameE.Count; ++i)
        {
            writer.Write((string)m_CreaturesNameE[i]);
        }

        writer.Write(m_Creatures.Count);

        for (int i = 0; i < m_Creatures.Count; ++i)
        {
            IEntity e = m_Creatures[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }

        writer.Write(m_CreaturesA.Count);

        for (int i = 0; i < m_CreaturesA.Count; ++i)
        {
            IEntity e = m_CreaturesA[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }

        writer.Write(m_CreaturesB.Count);

        for (int i = 0; i < m_CreaturesB.Count; ++i)
        {
            IEntity e = m_CreaturesB[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }

        writer.Write(m_CreaturesC.Count);

        for (int i = 0; i < m_CreaturesC.Count; ++i)
        {
            IEntity e = m_CreaturesC[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }

        writer.Write(m_CreaturesD.Count);

        for (int i = 0; i < m_CreaturesD.Count; ++i)
        {
            IEntity e = m_CreaturesD[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }

        writer.Write(m_CreaturesE.Count);

        for (int i = 0; i < m_CreaturesE.Count; ++i)
        {
            IEntity e = m_CreaturesE[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }
    }

    private static WarnTimer m_WarnTimer;

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();

        switch (version)
        {
            case 4:
            {
                m_WalkingRange = reader.ReadInt();
                m_SpawnID      = reader.ReadInt();
                m_CountA       = reader.ReadInt();
                m_CountB       = reader.ReadInt();
                m_CountC       = reader.ReadInt();
                m_CountD       = reader.ReadInt();
                m_CountE       = reader.ReadInt();

                goto case 3;
            }
            case 3:
            case 2:
            {
                m_WayPoint = reader.ReadItem() as WayPoint;

                goto case 1;
            }

            case 1:
            {
                m_Group = reader.ReadBool();

                goto case 0;
            }

            case 0:
            {
                m_MinDelay  = reader.ReadTimeSpan();
                m_MaxDelay  = reader.ReadTimeSpan();
                m_Count     = reader.ReadInt();
                m_Team      = reader.ReadInt();
                m_HomeRange = reader.ReadInt();
                m_Running   = reader.ReadBool();

                TimeSpan ts = TimeSpan.Zero;

                if (m_Running)
                {
                    ts = reader.ReadDeltaTime() - DateTime.Now;
                }

                int size = reader.ReadInt();
                m_CreaturesName = new List <string>(size);
                for (int i = 0; i < size; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_CreaturesName.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int sizeA = reader.ReadInt();
                m_CreaturesNameA = new List <string>(sizeA);
                for (int i = 0; i < sizeA; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_CreaturesNameA.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int sizeB = reader.ReadInt();
                m_CreaturesNameB = new List <string>(sizeB);
                for (int i = 0; i < sizeB; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_CreaturesNameB.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int sizeC = reader.ReadInt();
                m_CreaturesNameC = new List <string>(sizeC);
                for (int i = 0; i < sizeC; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_CreaturesNameC.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int sizeD = reader.ReadInt();
                m_CreaturesNameD = new List <string>(sizeD);
                for (int i = 0; i < sizeD; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_CreaturesNameD.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int sizeE = reader.ReadInt();
                m_CreaturesNameE = new List <string>(sizeE);
                for (int i = 0; i < sizeE; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_CreaturesNameE.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int count = reader.ReadInt();
                m_Creatures = new List <IEntity>(count);
                for (int i = 0; i < count; ++i)
                {
                    IEntity e = World.FindEntity(reader.ReadInt());

                    if (e != null)
                    {
                        m_Creatures.Add(e);
                    }
                }

                int countA = reader.ReadInt();
                m_CreaturesA = new List <IEntity>(countA);
                for (int i = 0; i < countA; ++i)
                {
                    IEntity e = World.FindEntity(reader.ReadInt());

                    if (e != null)
                    {
                        m_CreaturesA.Add(e);
                    }
                }

                int countB = reader.ReadInt();
                m_CreaturesB = new List <IEntity>(countB);
                for (int i = 0; i < countB; ++i)
                {
                    IEntity e = World.FindEntity(reader.ReadInt());

                    if (e != null)
                    {
                        m_CreaturesB.Add(e);
                    }
                }

                int countC = reader.ReadInt();
                m_CreaturesC = new List <IEntity>(countC);
                for (int i = 0; i < countC; ++i)
                {
                    IEntity e = World.FindEntity(reader.ReadInt());

                    if (e != null)
                    {
                        m_CreaturesC.Add(e);
                    }
                }

                int countD = reader.ReadInt();
                m_CreaturesD = new List <IEntity>(countD);
                for (int i = 0; i < countD; ++i)
                {
                    IEntity e = World.FindEntity(reader.ReadInt());

                    if (e != null)
                    {
                        m_CreaturesD.Add(e);
                    }
                }

                int countE = reader.ReadInt();
                m_CreaturesE = new List <IEntity>(countE);
                for (int i = 0; i < countE; ++i)
                {
                    IEntity e = World.FindEntity(reader.ReadInt());

                    if (e != null)
                    {
                        m_CreaturesE.Add(e);
                    }
                }

                if (m_Running)
                {
                    DoTimer(ts);
                }

                break;
            }
        }

        if (version < 3 && Weight == 0)
        {
            Weight = -1;
        }
    }

    private class WarnTimer : Timer
    {
        private List <WarnEntry> m_List;

        private class WarnEntry
        {
            public Point3D m_Point;
            public Map m_Map;
            public string m_Name;

            public WarnEntry(Point3D p, Map map, string name)
            {
                m_Point = p;
                m_Map   = map;
                m_Name  = name;
            }
        }

        public WarnTimer() : base(TimeSpan.FromSeconds(1.0))
        {
            m_List = new List <WarnEntry>();
            Start();
        }

        public void Add(Point3D p, Map map, string name)
        {
            m_List.Add(new WarnEntry(p, map, name));
        }

        protected override void OnTick()
        {
            try
            {
                Console.WriteLine("Warning: {0} bad spawns detected, logged: 'PremiumBadspawn.log'", m_List.Count);

                using (StreamWriter op = new StreamWriter("PremiumBadspawn.log", true))
                {
                    op.WriteLine("# Bad spawns : {0}", DateTime.Now);
                    op.WriteLine("# Format: X Y Z F Name");
                    op.WriteLine();

                    foreach (WarnEntry e in m_List)
                    {
                        op.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", e.m_Point.X, e.m_Point.Y, e.m_Point.Z, e.m_Map, e.m_Name);
                    }

                    op.WriteLine();
                    op.WriteLine();
                }
            }
            catch
            {
            }
        }
    }
}
}
namespace Server.Commands
{
public class PSpawnerCount
{
    public static void Initialize()
    {
        Register("pscount", AccessLevel.Administrator, new CommandEventHandler(Clearall_OnCommand));
    }

    public static void Register(string command, AccessLevel access, CommandEventHandler handler)
    {
        CommandSystem.Register(command, access, handler);
    }

    [Usage("pscount")]
    [Description("Count PremiumSpawners.")]
    public static void Clearall_OnCommand(CommandEventArgs e)
    {
        Mobile   from = e.Mobile;
        DateTime time = DateTime.Now;

        List <Item> pspawnerlist = new List <Item>();

        foreach (Item pspawner in World.Items.Values)
        {
            if (pspawner.Parent == null && pspawner is PremiumSpawner)
            {
                pspawnerlist.Add(pspawner);
            }
        }

        from.SendMessage("Premium Spawners: {0}", pspawnerlist.Count);
    }
}
}
namespace Server.Commands
{
public class RunUOSpawnerExporter
{
    public const bool Enabled = true;

    public static void Initialize()
    {
        CommandSystem.Register("RunUOSpawnerExporter", AccessLevel.Administrator, new CommandEventHandler(RunUOSpawnerExporter_OnCommand));
        CommandSystem.Register("RSE", AccessLevel.Administrator, new CommandEventHandler(RunUOSpawnerExporter_OnCommand));
    }

    public static int ConvertToInt(TimeSpan ts)
    {
        return (ts.Hours * 60) + ts.Minutes + (ts.Seconds / 60);
    }

    [Usage("RunUOSpawnerExporter")]
    [Aliases("RSE")]
    [Description("Convert RunUO Spawners to PremiumSpawners.")]
    public static void RunUOSpawnerExporter_OnCommand(CommandEventArgs e)
    {
        Map         map  = e.Mobile.Map;
        List <Item> list = new List <Item>();

        if (!Directory.Exists(@".\Data\Spawns\"))
        {
            Directory.CreateDirectory(@".\Data\Spawns\");
        }

        using (StreamWriter op = new StreamWriter(String.Format(@".\Data\Spawns\{0}-exported.map", map)))
        {
            if (map == null || map == Map.Internal)
            {
                e.Mobile.SendMessage("You may not run that command here.");
                return;
            }

            e.Mobile.SendMessage("Converting Spawners...");

            op.WriteLine("#######################################");

            foreach (Item item in World.Items.Values)
            {
                if (item.Map == map && item.Parent == null && item is Spawner)
                {
                    list.Add(item);
                }
            }

            foreach (Spawner spawner in list)
            {
                string mapfinal = "";

                string walkrange = "";

                if (map == Map.Maps[0])
                {
                    mapfinal = "1";
                }
                else if (map == Map.Maps[1])
                {
                    mapfinal = "2";
                }
                else if (map == Map.Maps[2])
                {
                    mapfinal = "3";
                }
                else if (map == Map.Maps[3])
                {
                    mapfinal = "4";
                }
                else if (map == Map.Maps[4])
                {
                    mapfinal = "5";
                }
                else if (map == Map.Maps[5])
                {
                    mapfinal = "6";
                }
                else if (map == Map.Maps[6])
                {
                    mapfinal = "7";
                }
                else if (map == Map.Maps[35])
                {
                    mapfinal = "35";
                }
                else if (map == Map.Maps[36])
                {
                    mapfinal = "36";
                }
                else
                {
                    mapfinal = "6";
                }

                if (spawner.WalkingRange == -1)
                {
                    walkrange = spawner.HomeRange.ToString();
                }
                else
                {
                    walkrange = spawner.WalkingRange.ToString();
                }

                int MinDelay = ConvertToInt(spawner.MinDelay);

                if (MinDelay < 1)
                {
                    MinDelay = 1;
                }

                int MaxDelay = ConvertToInt(spawner.MaxDelay);

                if (MaxDelay < MinDelay)
                {
                    MaxDelay = MinDelay;
                }

                string towrite = "*|";

                if (spawner.SpawnNames.Count > 0)
                {
                    towrite = "*|" + spawner.SpawnNames[0];

                    for (int i = 1; i < spawner.SpawnNames.Count; ++i)
                    {
                        towrite = towrite + ":" + spawner.SpawnNames[i].ToString();
                    }
                }

                if (spawner.SpawnNames.Count > 0 && spawner.Running == true)
                {
                    op.WriteLine("{0}||||||{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|1|{9}|0|0|0|0|0", towrite, spawner.X, spawner.Y, spawner.Z, mapfinal, MinDelay, MaxDelay, walkrange, spawner.HomeRange, spawner.Count);
                }

                if (spawner.SpawnNames.Count == 0)
                {
                    op.WriteLine("## Void: {0}||||||{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|1|{9}|0|0|0|0|0", towrite, spawner.X, spawner.Y, spawner.Z, mapfinal, MinDelay, MaxDelay, walkrange, spawner.HomeRange, spawner.Count);
                }

                if (spawner.SpawnNames.Count > 0 && spawner.Running == false)
                {
                    op.WriteLine("## Inactive: {0}||||||{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|1|{9}|0|0|0|0|0", towrite, spawner.X, spawner.Y, spawner.Z, mapfinal, MinDelay, MaxDelay, walkrange, spawner.HomeRange, spawner.Count);
                }
            }
            e.Mobile.SendMessage(String.Format("You exported {0} RunUO Spawner{1} from this facet.", list.Count, list.Count == 1 ? "" : "s"));
        }
    }
}
}
namespace Server.Mobiles
{
public class Spawner : Item, ISpawner
{
    private int m_Team;
    private int m_HomeRange;
    private int m_WalkingRange;
    private int m_Count;
    private TimeSpan m_MinDelay;
    private TimeSpan m_MaxDelay;
    private List <string> m_SpawnNames;
    private List <ISpawnable> m_Spawned;
    private DateTime m_End;
    private InternalTimer m_Timer;
    private bool m_Running;
    private bool m_Group;
    private WayPoint m_WayPoint;

    public bool IsFull {
        get { return m_Spawned != null && m_Spawned.Count >= m_Count; }
    }

    public List <string> SpawnNames
    {
        get { return m_SpawnNames; }
        set
        {
            m_SpawnNames = value;
            if (m_SpawnNames.Count < 1)
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    public virtual int SpawnNamesCount {
        get { return m_SpawnNames.Count; }
    }

    public override void OnAfterDuped(Item newItem)
    {
        Spawner s = newItem as Spawner;

        if (s == null)
        {
            return;
        }

        s.m_SpawnNames = new List <string>(m_SpawnNames);
        s.m_Spawned    = new List <ISpawnable>();
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Count
    {
        get { return m_Count; }
        set { m_Count = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public WayPoint WayPoint
    {
        get
        {
            return m_WayPoint;
        }
        set
        {
            m_WayPoint = value;
        }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public bool Running
    {
        get { return m_Running; }
        set
        {
            if (value)
            {
                Start();
            }
            else
            {
                Stop();
            }

            InvalidateProperties();
        }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int HomeRange
    {
        get { return m_HomeRange; }
        set { m_HomeRange = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int WalkingRange
    {
        get { return m_WalkingRange; }
        set { m_WalkingRange = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public int Team
    {
        get { return m_Team; }
        set { m_Team = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public TimeSpan MinDelay
    {
        get { return m_MinDelay; }
        set { m_MinDelay = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public TimeSpan MaxDelay
    {
        get { return m_MaxDelay; }
        set { m_MaxDelay = value; InvalidateProperties(); }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public TimeSpan NextSpawn
    {
        get
        {
            if (m_Running)
            {
                return m_End - DateTime.Now;
            }
            else
            {
                return TimeSpan.FromSeconds(0);
            }
        }
        set
        {
            Start();
            DoTimer(value);
        }
    }

    [CommandProperty(AccessLevel.GameMaster)]
    public bool Group
    {
        get { return m_Group; }
        set { m_Group = value; InvalidateProperties(); }
    }

    [Constructable]
    public Spawner()
        : this(null)
    {
    }

    [Constructable]
    public Spawner(string spawnName)
        : this(1, 5, 10, 0, 4, spawnName)
    {
    }

    [Constructable]
    public Spawner(int amount, int minDelay, int maxDelay, int team, int homeRange, string spawnName)
        : base(0x6519)
    {
        List <string> spawnNames = new List <string>();

        if (!String.IsNullOrEmpty(spawnName))
        {
            spawnNames.Add(spawnName);
        }

        InitSpawner(amount, TimeSpan.FromMinutes(minDelay), TimeSpan.FromMinutes(maxDelay), team, homeRange, spawnNames);
    }

    public Spawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, List <string> spawnNames)
        : base(0x6519)
    {
        InitSpawner(amount, minDelay, maxDelay, team, homeRange, spawnNames);
    }

    public override string DefaultName
    {
        get { return "Spawner"; }
    }

    private void InitSpawner(int amount, TimeSpan minDelay, TimeSpan maxDelay, int team, int homeRange, List <string> spawnNames)
    {
        Visible        = false;
        Movable        = false;
        m_Running      = true;
        m_Group        = false;
        m_MinDelay     = minDelay;
        m_MaxDelay     = maxDelay;
        m_Count        = amount;
        m_Team         = team;
        m_HomeRange    = homeRange;
        m_WalkingRange = -1;
        m_SpawnNames   = spawnNames;
        m_Spawned      = new List <ISpawnable>();
        DoTimer(TimeSpan.FromSeconds(1));
    }

    public Spawner(Serial serial) : base(serial)
    {
    }

    public override void OnDoubleClick(Mobile from)
    {
        if (from.AccessLevel < AccessLevel.GameMaster)
        {
            return;
        }

        SpawnerGump g = new SpawnerGump(this);
        from.SendGump(g);
    }

    public override void GetProperties(ObjectPropertyList list)
    {
        base.GetProperties(list);

        if (m_Running)
        {
            list.Add(1060742);                                              // active

            list.Add(1060656, m_Count.ToString());                          // amount to make: ~1_val~
            list.Add(1061169, m_HomeRange.ToString());                      // range ~1_val~
            list.Add(1060658, "walking range\t{0}", m_WalkingRange);        // ~1_val~: ~2_val~

            list.Add(1060659, "group\t{0}", m_Group);                       // ~1_val~: ~2_val~
            list.Add(1060660, "team\t{0}", m_Team);                         // ~1_val~: ~2_val~
            list.Add(1060661, "speed\t{0} to {1}", m_MinDelay, m_MaxDelay); // ~1_val~: ~2_val~

            for (int i = 0; i < 2 && i < m_SpawnNames.Count; ++i)
            {
                list.Add(1060662 + i, "{0}\t{1}", m_SpawnNames[i], CountCreatures(m_SpawnNames[i]));
            }
        }
        else
        {
            list.Add(1060743);                       // inactive
        }
    }

    public override void OnSingleClick(Mobile from)
    {
        base.OnSingleClick(from);

        if (m_Running)
        {
            LabelTo(from, "[Running]");
        }
        else
        {
            LabelTo(from, "[Off]");
        }
    }

    public void Start()
    {
        if (!m_Running)
        {
            if (SpawnNamesCount > 0)
            {
                m_Running = true;
                DoTimer();
            }
        }
    }

    public void Stop()
    {
        if (m_Running)
        {
            m_Timer.Stop();
            m_Running = false;
        }
    }

    public static string ParseType(string s)
    {
        return s.Split(null, 2)[0];
    }

    public void Defrag()
    {
        bool removed = false;

        for (int i = 0; i < m_Spawned.Count; ++i)
        {
            ISpawnable e = m_Spawned[i];

            bool toRemove = false;

            if (e is Item)
            {
                Item item = (Item)e;

                if (item.Deleted || item.Parent != null)
                {
                    toRemove = true;
                }
            }
            else if (e is Mobile)
            {
                Mobile m = (Mobile)e;

                if (m.Deleted)
                {
                    toRemove = true;
                }
                else if (m is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)m;

                    if (bc.Controlled || bc.IsStabled)
                    {
                        bc.SpawnerID = 0;
                        toRemove     = true;
                    }
                }
            }

            if (toRemove)
            {
                m_Spawned.RemoveAt(i);
                --i;
                removed = true;
            }
        }

        if (removed)
        {
            InvalidateProperties();
        }
    }

    bool ISpawner.UnlinkOnTaming {
        get { return true; }
    }

    void ISpawner.Remove(ISpawnable spawn)
    {
        m_Spawned.Remove(spawn);

        InvalidateProperties();
    }

    public void OnTick()
    {
        DoTimer();

        if (m_Group)
        {
            Defrag();

            if (m_Spawned.Count == 0)
            {
                Respawn();
            }
            else
            {
                return;
            }
        }
        else
        {
            Spawn();
        }
    }

    public void Respawn()
    {
        RemoveSpawned();

        for (int i = 0; i < m_Count; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        if (SpawnNamesCount > 0)
        {
            Spawn(Utility.Random(SpawnNamesCount));
        }
    }

    public void Spawn(string creatureName)
    {
        for (int i = 0; i < m_SpawnNames.Count; i++)
        {
            if (m_SpawnNames[i] == creatureName)
            {
                Spawn(i);
                break;
            }
        }
    }

    protected virtual ISpawnable CreateSpawnedObject(int index)
    {
        if (index >= m_SpawnNames.Count)
        {
            return null;
        }

        Type type = ScriptCompiler.FindTypeByName(ParseType(m_SpawnNames[index]));

        if (type != null)
        {
            try
            {
                return Build(type, CommandSystem.Split(m_SpawnNames[index]));
            }
            catch
            {
            }
        }

        return null;
    }

    public static ISpawnable Build(Type type, string[] args)
    {
        bool isISpawnable = typeof(ISpawnable).IsAssignableFrom(type);

        if (!isISpawnable)
        {
            return null;
        }

        Add.FixArgs(ref args);

        string[,] props = null;

        for (int i = 0; i < args.Length; ++i)
        {
            if (Insensitive.Equals(args[i], "set"))
            {
                int remains = args.Length - i - 1;

                if (remains >= 2)
                {
                    props = new string[remains / 2, 2];

                    remains /= 2;

                    for (int j = 0; j < remains; ++j)
                    {
                        props[j, 0] = args[i + (j * 2) + 1];
                        props[j, 1] = args[i + (j * 2) + 2];
                    }

                    Add.FixSetString(ref args, i);
                }

                break;
            }
        }

        PropertyInfo[] realProps = null;

        if (props != null)
        {
            realProps = new PropertyInfo[props.GetLength(0)];

            PropertyInfo[] allProps = type.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);

            for (int i = 0; i < realProps.Length; ++i)
            {
                PropertyInfo thisProp = null;

                string propName = props[i, 0];

                for (int j = 0; thisProp == null && j < allProps.Length; ++j)
                {
                    if (Insensitive.Equals(propName, allProps[j].Name))
                    {
                        thisProp = allProps[j];
                    }
                }

                if (thisProp != null)
                {
                    CPA attr = Properties.GetCPA(thisProp);

                    if (attr != null && AccessLevel.GameMaster >= attr.WriteLevel && thisProp.CanWrite && !attr.ReadOnly)
                    {
                        realProps[i] = thisProp;
                    }
                }
            }
        }

        ConstructorInfo[] ctors = type.GetConstructors();

        for (int i = 0; i < ctors.Length; ++i)
        {
            ConstructorInfo ctor = ctors[i];

            if (!Add.IsConstructable(ctor, AccessLevel.GameMaster))
            {
                continue;
            }

            ParameterInfo[] paramList = ctor.GetParameters();

            if (args.Length == paramList.Length)
            {
                object[] paramValues = Add.ParseValues(paramList, args);

                if (paramValues == null)
                {
                    continue;
                }

                object built = ctor.Invoke(paramValues);

                if (built != null && realProps != null)
                {
                    for (int j = 0; j < realProps.Length; ++j)
                    {
                        if (realProps[j] == null)
                        {
                            continue;
                        }

                        string result = Properties.InternalSetValue(built, realProps[j], props[j, 1]);
                    }
                }

                return (ISpawnable)built;
            }
        }

        return null;
    }

    public Point3D HomeLocation {
        get { return this.Location; }
    }

    public void Spawn(int index)
    {
        Map map = Map;

        if (map == null || map == Map.Internal || SpawnNamesCount == 0 || index >= SpawnNamesCount || Parent != null)
        {
            return;
        }

        Defrag();

        if (m_Spawned.Count >= m_Count)
        {
            return;
        }

        ISpawnable spawned = CreateSpawnedObject(index);

        if (spawned == null)
        {
            return;
        }

        spawned.Spawner = this;
        m_Spawned.Add(spawned);

        Point3D loc = (spawned is BaseVendor ? this.Location : GetSpawnPosition());

        spawned.OnBeforeSpawn(loc, map);

        InvalidateProperties();

        spawned.MoveToWorld(loc, map);
        spawned.OnAfterSpawn();

        if (spawned is BaseCreature)
        {
            BaseCreature bc = (BaseCreature)spawned;

            if (m_WalkingRange >= 0)
            {
                bc.RangeHome = m_WalkingRange;
            }
            else
            {
                bc.RangeHome = m_HomeRange;
            }

            bc.CurrentWayPoint = m_WayPoint;

            if (m_Team > 0)
            {
                bc.Team = m_Team;
            }

            bc.Home = this.HomeLocation;
        }
    }

    public Point3D GetSpawnPosition()
    {
        Map map = Map;

        if (map == null)
        {
            return Location;
        }

        // Try 10 times to find a Spawnable location.
        for (int i = 0; i < 10; i++)
        {
            int x, y;

            if (m_HomeRange > 0)
            {
                x = Location.X + (Utility.Random((m_HomeRange * 2) + 1) - m_HomeRange);
                y = Location.Y + (Utility.Random((m_HomeRange * 2) + 1) - m_HomeRange);
            }
            else
            {
                x = Location.X;
                y = Location.Y;
            }

            int z = Map.GetAverageZ(x, y);

            if (Map.CanSpawnMobile(new Point2D(x, y), this.Z))
            {
                return new Point3D(x, y, this.Z);
            }
            else if (Map.CanSpawnMobile(new Point2D(x, y), z))
            {
                return new Point3D(x, y, z);
            }
        }

        return this.Location;
    }

    public void DoTimer()
    {
        if (!m_Running)
        {
            return;
        }

        int minSeconds = (int)m_MinDelay.TotalSeconds;
        int maxSeconds = (int)m_MaxDelay.TotalSeconds;

        TimeSpan delay = TimeSpan.FromSeconds(Utility.RandomMinMax(minSeconds, maxSeconds));
        DoTimer(delay);
    }

    public void DoTimer(TimeSpan delay)
    {
        if (!m_Running)
        {
            return;
        }

        m_End = DateTime.Now + delay;

        if (m_Timer != null)
        {
            m_Timer.Stop();
        }

        m_Timer = new InternalTimer(this, delay);
        m_Timer.Start();
    }

    private class InternalTimer : Timer
    {
        private Spawner m_Spawner;

        public InternalTimer(Spawner spawner, TimeSpan delay) : base(delay)
        {
            if (spawner.IsFull)
            {
                Priority = TimerPriority.FiveSeconds;
            }
            else
            {
                Priority = TimerPriority.OneSecond;
            }

            m_Spawner = spawner;
        }

        protected override void OnTick()
        {
            if (m_Spawner != null)
            {
                if (!m_Spawner.Deleted)
                {
                    m_Spawner.OnTick();
                }
            }
        }
    }

    public int CountCreatures(string creatureName)
    {
        Defrag();

        int count = 0;

        for (int i = 0; i < m_Spawned.Count; ++i)
        {
            if (Insensitive.Equals(creatureName, m_Spawned[i].GetType().Name))
            {
                ++count;
            }
        }

        return count;
    }

    public void RemoveSpawned(string creatureName)
    {
        Defrag();

        for (int i = 0; i < m_Spawned.Count; ++i)
        {
            IEntity e = m_Spawned[i];

            if (Insensitive.Equals(creatureName, e.GetType().Name))
            {
                e.Delete();
            }
        }

        InvalidateProperties();
    }

    public void RemoveSpawned()
    {
        Defrag();

        for (int i = 0; i < m_Spawned.Count; ++i)
        {
            m_Spawned[i].Delete();
        }

        InvalidateProperties();
    }

    public void BringToHome()
    {
        Defrag();

        for (int i = 0; i < m_Spawned.Count; ++i)
        {
            ISpawnable e = m_Spawned[i];

            e.MoveToWorld(this.Location, this.Map);
        }
    }

    public override void OnDelete()
    {
        base.OnDelete();

        RemoveSpawned();

        if (m_Timer != null)
        {
            m_Timer.Stop();
        }
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);

        writer.Write((int)4);                    // version
        writer.Write(m_WalkingRange);

        writer.Write(m_WayPoint);

        writer.Write(m_Group);

        writer.Write(m_MinDelay);
        writer.Write(m_MaxDelay);
        writer.Write(m_Count);
        writer.Write(m_Team);
        writer.Write(m_HomeRange);
        writer.Write(m_Running);

        if (m_Running)
        {
            writer.WriteDeltaTime(m_End);
        }

        writer.Write(m_SpawnNames.Count);

        for (int i = 0; i < m_SpawnNames.Count; ++i)
        {
            writer.Write(m_SpawnNames[i]);
        }

        writer.Write(m_Spawned.Count);

        for (int i = 0; i < m_Spawned.Count; ++i)
        {
            IEntity e = m_Spawned[i];

            if (e is Item)
            {
                writer.Write((Item)e);
            }
            else if (e is Mobile)
            {
                writer.Write((Mobile)e);
            }
            else
            {
                writer.Write(Serial.MinusOne);
            }
        }
    }

    private static WarnTimer m_WarnTimer;

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);

        int version = reader.ReadInt();

        switch (version)
        {
            case 4:
            {
                m_WalkingRange = reader.ReadInt();

                goto case 3;
            }
            case 3:
            case 2:
            {
                m_WayPoint = reader.ReadItem() as WayPoint;

                goto case 1;
            }

            case 1:
            {
                m_Group = reader.ReadBool();

                goto case 0;
            }

            case 0:
            {
                m_MinDelay  = reader.ReadTimeSpan();
                m_MaxDelay  = reader.ReadTimeSpan();
                m_Count     = reader.ReadInt();
                m_Team      = reader.ReadInt();
                m_HomeRange = reader.ReadInt();
                m_Running   = reader.ReadBool();

                TimeSpan ts = TimeSpan.Zero;

                if (m_Running)
                {
                    ts = reader.ReadDeltaTime() - DateTime.Now;
                }

                int size = reader.ReadInt();

                m_SpawnNames = new List <string>(size);

                for (int i = 0; i < size; ++i)
                {
                    string creatureString = reader.ReadString();

                    m_SpawnNames.Add(creatureString);
                    string typeName = ParseType(creatureString);

                    if (ScriptCompiler.FindTypeByName(typeName) == null)
                    {
                        if (m_WarnTimer == null)
                        {
                            m_WarnTimer = new WarnTimer();
                        }

                        m_WarnTimer.Add(Location, Map, typeName);
                    }
                }

                int count = reader.ReadInt();

                m_Spawned = new List <ISpawnable>(count);

                for (int i = 0; i < count; ++i)
                {
                    ISpawnable e = World.FindEntity(reader.ReadInt()) as ISpawnable;

                    if (e != null)
                    {
                        e.Spawner = this;
                        m_Spawned.Add(e);
                    }
                }

                if (m_Running)
                {
                    DoTimer(ts);
                }

                break;
            }
        }

        if (version < 3 && Weight == 0)
        {
            Weight = -1;
        }
    }

    private class WarnTimer : Timer
    {
        private List <WarnEntry> m_List;

        private class WarnEntry
        {
            public Point3D m_Point;
            public Map m_Map;
            public string m_Name;

            public WarnEntry(Point3D p, Map map, string name)
            {
                m_Point = p;
                m_Map   = map;
                m_Name  = name;
            }
        }

        public WarnTimer() : base(TimeSpan.FromSeconds(1.0))
        {
            m_List = new List <WarnEntry>();
            Start();
        }

        public void Add(Point3D p, Map map, string name)
        {
            m_List.Add(new WarnEntry(p, map, name));
        }

        protected override void OnTick()
        {
            try
            {
                Console.WriteLine("Warning: {0} bad spawns detected, logged: 'badspawn.log'", m_List.Count);

                using (StreamWriter op = new StreamWriter("badspawn.log", true))
                {
                    op.WriteLine("# Bad spawns : {0}", DateTime.Now);
                    op.WriteLine("# Format: X Y Z F Name");
                    op.WriteLine();

                    foreach (WarnEntry e in m_List)
                    {
                        op.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", e.m_Point.X, e.m_Point.Y, e.m_Point.Z, e.m_Map, e.m_Name);
                    }

                    op.WriteLine();
                    op.WriteLine();
                }
            }
            catch
            {
            }
        }
    }
}
}
namespace Server
{
public class SpawnGenerator
{
    private static int m_Count;
    private static int m_MapOverride        = -1;
    private static int m_IDOverride         = -1;
    private static double m_MinTimeOverride = -1;
    private static double m_MaxTimeOverride = -1;
    private const bool TotalRespawn         = true;
    private const int Team = 0;

    public static void Initialize()
    {
        CommandSystem.Register("SpawnGen", AccessLevel.Administrator, new CommandEventHandler(SpawnGen_OnCommand));
    }

    [Usage("SpawnGen [<filename>]|[unload <id>]|[remove <region>|<rect>]|[save <region>|<rect>][savebyhand][cleanfacet]")]
    [Description("Complex command, it generate and remove spawners.")]
    private static void SpawnGen_OnCommand(CommandEventArgs e)
    {
        //wrog use
        if (e.ArgString == null || e.ArgString == "")
        {
            e.Mobile.SendMessage("Usage: SpawnGen [<filename>]|[remove <region>|<rect>|<ID>]|[save <region>|<rect>|<ID>]");
        }
        //[spawngen remove and [spawngen remove region
        else if (e.Arguments[0].ToLower() == "remove" && e.Arguments.Length == 2)
        {
            Remove(e.Mobile, e.Arguments[1].ToLower());
        }
        //[spawngen remove x1 y1 x2 y2
        else if (e.Arguments[0].ToLower() == "remove" && e.Arguments.Length == 5)
        {
            int x1 = Utility.ToInt32(e.Arguments[1]);
            int y1 = Utility.ToInt32(e.Arguments[2]);
            int x2 = Utility.ToInt32(e.Arguments[3]);
            int y2 = Utility.ToInt32(e.Arguments[4]);
            RemoveByCoord(e.Mobile, x1, y1, x2, y2);
        }
        //[spawngen remove
        else if (e.ArgString.ToLower() == "remove")
        {
            Remove(e.Mobile, "");
        }
        //[spawngen save and [spawngen save region
        else if (e.Arguments[0].ToLower() == "save" && e.Arguments.Length == 2)
        {
            Save(e.Mobile, e.Arguments[1].ToLower());
        }
        //[spawngen unload SpawnID
        else if (e.Arguments[0].ToLower() == "unload" && e.Arguments.Length == 2)
        {
            int ID = Utility.ToInt32(e.Arguments[1]);
            Unload(ID);
        }
        //[spawngen savebyhand
        else if (e.Arguments[0].ToLower() == "savebyhand")
        {
            SaveByHand();
        }
        //[spawngen cleanfacet
        else if (e.Arguments[0].ToLower() == "cleanfacet")
        {
            CleanFacet(e.Mobile);
        }
        ////[spawngen save x1 y1 x2 y2
        else if (e.Arguments[0].ToLower() == "save" && e.Arguments.Length == 5)
        {
            int x1 = Utility.ToInt32(e.Arguments[1]);
            int y1 = Utility.ToInt32(e.Arguments[2]);
            int x2 = Utility.ToInt32(e.Arguments[3]);
            int y2 = Utility.ToInt32(e.Arguments[4]);
            SaveByCoord(e.Mobile, x1, y1, x2, y2);
        }
        //[spawngen save
        else if (e.ArgString.ToLower() == "save")
        {
            Save(e.Mobile, "");
        }
        else
        {
            Parse(e.Mobile, e.ArgString);
        }
    }

    public static void Talk(string alfa)
    {
        World.Broadcast(0x35, true, "Spawns are being {0}, please wait.", alfa);
    }

    public static string GetRegion(Item item)
    {
        Region re      = Region.Find(item.Location, item.Map);
        string regname = re.ToString().ToLower();
        return regname;
    }

    //[spawngen remove and [spawngen remove region
    private static void Remove(Mobile from, string region)
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();

        string prefix = Server.Commands.CommandSystem.Prefix;

        if (region == null || region == "")
        {
            CommandSystem.Handle(from, String.Format("{0}Global remove where premiumspawner", prefix));
        }
        else
        {
            foreach (Item itemdel in World.Items.Values)
            {
                if (itemdel is PremiumSpawner && itemdel.Map == from.Map)
                {
                    if (GetRegion(itemdel) == region)
                    {
                        itemtodo.Add(itemdel);
                        count += 1;
                    }
                }
            }

            GenericRemove(itemtodo, count, aTime);
        }
    }

    //[spawngen unload SpawnID
    private static void Unload(int ID)
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();

        foreach (Item itemremove in World.Items.Values)
        {
            if (itemremove is PremiumSpawner && ((PremiumSpawner)itemremove).SpawnID == ID)
            {
                itemtodo.Add(itemremove);
                count += 1;
            }
        }

        GenericRemove(itemtodo, count, aTime);
    }

    //[spawngen remove x1 y1 x2 y2
    private static void RemoveByCoord(Mobile from, int x1, int y1, int x2, int y2)
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();

        foreach (Item itemremove in World.Items.Values)
        {
            if (itemremove is PremiumSpawner && ((itemremove.X >= x1 && itemremove.X <= x2) && (itemremove.Y >= y1 && itemremove.Y <= y2) && itemremove.Map == from.Map))
            {
                itemtodo.Add(itemremove);
                count += 1;
            }
        }

        GenericRemove(itemtodo, count, aTime);
    }

    //[spawngen cleanfacet
    //this is the old [SpawnRem
    public static void CleanFacet(Mobile from)
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();

        foreach (Item itemremove in World.Items.Values)
        {
            if (itemremove is PremiumSpawner && itemremove.Map == from.Map && itemremove.Parent == null)
            {
                itemtodo.Add(itemremove);
                count += 1;
            }
        }

        GenericRemove(itemtodo, count, aTime);
    }

    private static void GenericRemove(List <Item> colecao, int count, DateTime aTime)
    {
        if (colecao.Count == 0)
        {
            World.Broadcast(0x35, true, "There are no PremiumSpawners to be removed.");
        }
        else
        {
            Talk("removed");

            foreach (Item item in colecao)
            {
                item.Delete();
            }

            DateTime bTime = DateTime.Now;
            World.Broadcast(0x35, true, "{0} PremiumSpawners have been removed in {1:F1} seconds.", count, (bTime - aTime).TotalSeconds);
        }
    }

    //[spawngen save and [spawngen save region
    private static void Save(Mobile from, string region)
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();
        string      mapanome = region;

        if (region == "")
        {
            mapanome = "Spawns";
        }

        foreach (Item itemsave in World.Items.Values)
        {
            if (itemsave is PremiumSpawner && (region == null || region == ""))
            {
                itemtodo.Add(itemsave);
                count += 1;
            }

            else if (itemsave is PremiumSpawner && itemsave.Map == from.Map)
            {
                if (GetRegion(itemsave) == region)
                {
                    itemtodo.Add(itemsave);
                    count += 1;
                }
            }
        }

        GenericSave(itemtodo, mapanome, count, aTime);
    }

    //[spawngen SaveByHand
    private static void SaveByHand()
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();
        string      mapanome = "SpawnsByHand";

        foreach (Item itemsave in World.Items.Values)
        {
            if (itemsave is PremiumSpawner && ((PremiumSpawner)itemsave).SpawnID == 1)
            {
                itemtodo.Add(itemsave);
                count += 1;
            }
        }

        GenericSave(itemtodo, mapanome, count, aTime);
    }

    //[spawngen save x1 y1 x2 y2
    private static void SaveByCoord(Mobile from, int x1, int y1, int x2, int y2)
    {
        DateTime    aTime    = DateTime.Now;
        int         count    = 0;
        List <Item> itemtodo = new List <Item>();
        string      mapanome = "SpawnsByCoords";

        foreach (Item itemsave in World.Items.Values)
        {
            if (itemsave is PremiumSpawner && ((itemsave.X >= x1 && itemsave.X <= x2) && (itemsave.Y >= y1 && itemsave.Y <= y2) && itemsave.Map == from.Map))
            {
                itemtodo.Add(itemsave);
                count += 1;
            }
        }

        GenericSave(itemtodo, mapanome, count, aTime);
    }

    private static void GenericSave(List <Item> colecao, string mapa, int count, DateTime startTime)
    {
        List <Item> itemssave = new List <Item>(colecao);
        string      mapanome  = mapa;

        if (itemssave.Count == 0)
        {
            World.Broadcast(0x35, true, "There are no PremiumSpawners to be saved.");
        }
        else
        {
            Talk("saved");

            if (!Directory.Exists("Data/Spawns"))
            {
                Directory.CreateDirectory("Data/Spawns");
            }

            string escreva = "Data/Spawns/" + mapanome + ".map";

            using (StreamWriter op = new StreamWriter(escreva))
            {
                foreach (PremiumSpawner itemsave2 in itemssave)
                {
                    int mapnumber = 0;
                    switch (itemsave2.Map.ToString())
                    {
                        case "Lodor":
                            mapnumber = 1;
                            break;
                        case "Sosaria":
                            mapnumber = 2;
                            break;
                        case "Underworld":
                            mapnumber = 3;
                            break;
                        case "SerpentIsland":
                            mapnumber = 4;
                            break;
                        case "IslesDread":
                            mapnumber = 5;
                            break;
                        case "SavagedEmpire":
                            mapnumber = 6;
                            break;
                        case "Atlantis":
                            mapnumber = 7;
                            break;
                        default:
                            mapnumber = 8;
                            Console.WriteLine("Monster Parser: Warning, unknown map {0}", itemsave2.Map);
                            break;
                    }

                    string   timer1a = itemsave2.MinDelay.ToString();
                    string[] timer1b = timer1a.Split(':');                                               //Broke the string hh:mm:ss in an array (hh, mm, ss)
                    int      timer1c = (Utility.ToInt32(timer1b[0]) * 60) + Utility.ToInt32(timer1b[1]); //multiply hh * 60 to find mm, then add mm
                    string   timer1d = timer1c.ToString();
                    if (Utility.ToInt32(timer1b[0]) == 0 && Utility.ToInt32(timer1b[1]) == 0)            //If hh and mm are 0, use seconds, else drop ss
                    {
                        timer1d = Utility.ToInt32(timer1b[2]) + "s";
                    }

                    string   timer2a = itemsave2.MaxDelay.ToString();
                    string[] timer2b = timer2a.Split(':');
                    int      timer2c = (Utility.ToInt32(timer2b[0]) * 60) + Utility.ToInt32(timer2b[1]);
                    string   timer2d = timer2c.ToString();
                    if (Utility.ToInt32(timer2b[0]) == 0 && Utility.ToInt32(timer2b[1]) == 0)
                    {
                        timer2d = Utility.ToInt32(timer2b[2]) + "s";
                    }

                    string towrite  = "";
                    string towriteA = "";
                    string towriteB = "";
                    string towriteC = "";
                    string towriteD = "";
                    string towriteE = "";

                    if (itemsave2.CreaturesName.Count > 0)
                    {
                        towrite = itemsave2.CreaturesName[0].ToString();
                    }

                    if (itemsave2.SubSpawnerA.Count > 0)
                    {
                        towriteA = itemsave2.SubSpawnerA[0].ToString();
                    }

                    if (itemsave2.SubSpawnerB.Count > 0)
                    {
                        towriteB = itemsave2.SubSpawnerB[0].ToString();
                    }

                    if (itemsave2.SubSpawnerC.Count > 0)
                    {
                        towriteC = itemsave2.SubSpawnerC[0].ToString();
                    }

                    if (itemsave2.SubSpawnerD.Count > 0)
                    {
                        towriteD = itemsave2.SubSpawnerD[0].ToString();
                    }

                    if (itemsave2.SubSpawnerE.Count > 0)
                    {
                        towriteE = itemsave2.SubSpawnerE[0].ToString();
                    }

                    for (int i = 1; i < itemsave2.CreaturesName.Count; ++i)
                    {
                        if (itemsave2.CreaturesName.Count > 0)
                        {
                            towrite = towrite + ":" + itemsave2.CreaturesName[i].ToString();
                        }
                    }

                    for (int i = 1; i < itemsave2.SubSpawnerA.Count; ++i)
                    {
                        if (itemsave2.SubSpawnerA.Count > 0)
                        {
                            towriteA = towriteA + ":" + itemsave2.SubSpawnerA[i].ToString();
                        }
                    }

                    for (int i = 1; i < itemsave2.SubSpawnerB.Count; ++i)
                    {
                        if (itemsave2.SubSpawnerB.Count > 0)
                        {
                            towriteB = towriteB + ":" + itemsave2.SubSpawnerB[i].ToString();
                        }
                    }

                    for (int i = 1; i < itemsave2.SubSpawnerC.Count; ++i)
                    {
                        if (itemsave2.SubSpawnerC.Count > 0)
                        {
                            towriteC = towriteC + ":" + itemsave2.SubSpawnerC[i].ToString();
                        }
                    }

                    for (int i = 1; i < itemsave2.SubSpawnerD.Count; ++i)
                    {
                        if (itemsave2.SubSpawnerD.Count > 0)
                        {
                            towriteD = towriteD + ":" + itemsave2.SubSpawnerD[i].ToString();
                        }
                    }

                    for (int i = 1; i < itemsave2.SubSpawnerE.Count; ++i)
                    {
                        if (itemsave2.SubSpawnerE.Count > 0)
                        {
                            towriteE = towriteE + ":" + itemsave2.SubSpawnerE[i].ToString();
                        }
                    }

                    op.WriteLine("*|{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}|{15}|{16}|{17}|{18}|{19}|{20}", towrite, towriteA, towriteB, towriteC, towriteD, towriteE, itemsave2.X, itemsave2.Y, itemsave2.Z, mapnumber, timer1d, timer2d, itemsave2.WalkingRange, itemsave2.HomeRange, itemsave2.SpawnID, itemsave2.Count, itemsave2.CountA, itemsave2.CountB, itemsave2.CountC, itemsave2.CountD, itemsave2.CountE);
                }
            }

            DateTime endTime = DateTime.Now;
            World.Broadcast(0x35, true, "{0} spawns have been saved. The entire process took {1:F1} seconds.", count, (endTime - startTime).TotalSeconds);
        }
    }

    public static void Parse(Mobile from, string filename)
    {
        string monster_path1 = Path.Combine(Core.BaseDirectory, "Data/Spawns");
        if (filename == "Spawns.map")
        {
            monster_path1 = Path.Combine(Core.BaseDirectory, "Info/Custom");
        }
        string monster_path = Path.Combine(monster_path1, filename);
        m_Count = 0;

        if (File.Exists(monster_path))
        {
            from.SendMessage("Spawning {0}...", filename);
            m_MapOverride     = -1;
            m_IDOverride      = -1;
            m_MinTimeOverride = -1;
            m_MaxTimeOverride = -1;

            using (StreamReader ip = new StreamReader(monster_path))
            {
                string line;

                while ((line = ip.ReadLine()) != null)
                {
                    string[] split  = line.Split('|');
                    string[] splitA = line.Split(' ');

                    if (splitA.Length == 2)
                    {
                        if (splitA[0].ToLower() == "overridemap")
                        {
                            m_MapOverride = Utility.ToInt32(splitA[1]);
                        }
                        if (splitA[0].ToLower() == "overrideid")
                        {
                            m_IDOverride = Utility.ToInt32(splitA[1]);
                        }
                        if (splitA[0].ToLower() == "overridemintime")
                        {
                            m_MinTimeOverride = Utility.ToDouble(splitA[1]);
                        }
                        if (splitA[0].ToLower() == "overridemaxtime")
                        {
                            m_MaxTimeOverride = Utility.ToDouble(splitA[1]);
                        }
                    }

                    if (split.Length < 19)
                    {
                        continue;
                    }

                    switch (split[0].ToLower())
                    {
                        //Comment Line
                        case "##":
                            break;
                        //Place By class
                        case "*":
                            PlaceNPC(split[2].Split(':'), split[3].Split(':'), split[4].Split(':'), split[5].Split(':'), split[6].Split(':'), split[7], split[8], split[9], split[10], split[11], split[12], split[14], split[13], split[15], split[16], split[17], split[18], split[19], split[20], split[21], split[1].Split(':'));
                            break;
                        //Place By Type
                        case "r":
                            PlaceNPC(split[2].Split(':'), split[3].Split(':'), split[4].Split(':'), split[5].Split(':'), split[6].Split(':'), split[7], split[8], split[9], split[10], split[11], split[12], split[14], split[13], split[15], split[16], split[17], split[18], split[19], split[20], split[1], "bloodmoss", "sulfurousash", "spiderssilk", "mandrakeroot", "gravedust", "nightshade", "ginseng", "garlic", "batwing", "pigiron", "noxcrystal", "daemonblood", "blackpearl");
                            break;
                    }
                }
            }

            m_MapOverride     = -1;
            m_IDOverride      = -1;
            m_MinTimeOverride = -1;
            m_MaxTimeOverride = -1;

            from.SendMessage("Done, added {0} spawners", m_Count);
        }
        else
        {
            from.SendMessage("{0} not found!", monster_path);
        }
    }

    public static void PlaceNPC(string[] fakespawnsA, string[] fakespawnsB, string[] fakespawnsC, string[] fakespawnsD, string[] fakespawnsE, string sx, string sy, string sz, string sm, string smintime, string smaxtime, string swalkingrange, string shomerange, string sspawnid, string snpccount, string sfakecountA, string sfakecountB, string sfakecountC, string sfakecountD, string sfakecountE, params string[] types)
    {
        if (types.Length == 0)
        {
            return;
        }

        int x   = Utility.ToInt32(sx);
        int y   = Utility.ToInt32(sy);
        int z   = Utility.ToInt32(sz);
        int map = Utility.ToInt32(sm);

        //MinTime
        string samintime = smintime;

        if (smintime.Contains("s") || smintime.Contains("m") || smintime.Contains("h"))
        {
            samintime = smintime.Remove(smintime.Length - 1);
        }

        double dmintime = Utility.ToDouble(samintime);

        if (m_MinTimeOverride != -1)
        {
            dmintime = m_MinTimeOverride;
        }

        TimeSpan mintime = TimeSpan.FromMinutes(dmintime);

        if (smintime.Contains("s"))
        {
            mintime = TimeSpan.FromSeconds(dmintime);
        }
        else if (smintime.Contains("m"))
        {
            mintime = TimeSpan.FromMinutes(dmintime);
        }
        else if (smintime.Contains("h"))
        {
            mintime = TimeSpan.FromHours(dmintime);
        }

        //MaxTime

        string samaxtime = smaxtime;

        if (smaxtime.Contains("s") || smaxtime.Contains("m") || smaxtime.Contains("h"))
        {
            samaxtime = smaxtime.Remove(smaxtime.Length - 1);
        }

        double dmaxtime = Utility.ToDouble(samaxtime);

        if (m_MaxTimeOverride != -1)
        {
            if (m_MaxTimeOverride < dmintime)
            {
                dmaxtime = dmintime;
            }
            else
            {
                dmaxtime = m_MaxTimeOverride;
            }
        }

        TimeSpan maxtime = TimeSpan.FromMinutes(dmaxtime);

        if (smaxtime.Contains("s"))
        {
            maxtime = TimeSpan.FromSeconds(dmaxtime);
        }
        else if (smaxtime.Contains("m"))
        {
            maxtime = TimeSpan.FromMinutes(dmaxtime);
        }
        else if (smaxtime.Contains("h"))
        {
            maxtime = TimeSpan.FromHours(dmaxtime);
        }

        //
        int homerange    = Utility.ToInt32(shomerange);
        int walkingrange = Utility.ToInt32(swalkingrange);
        int spawnid      = Utility.ToInt32(sspawnid);
        int npccount     = Utility.ToInt32(snpccount);
        int fakecountA   = Utility.ToInt32(sfakecountA);
        int fakecountB   = Utility.ToInt32(sfakecountB);
        int fakecountC   = Utility.ToInt32(sfakecountC);
        int fakecountD   = Utility.ToInt32(sfakecountD);
        int fakecountE   = Utility.ToInt32(sfakecountE);

        if (m_MapOverride != -1)
        {
            map = m_MapOverride;
        }

        if (m_IDOverride != -1)
        {
            spawnid = m_IDOverride;
        }

        switch (map)
        {
            case 0:                    //Sosaria and Lodor
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.Lodor, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.Sosaria, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 1:                    //Lodor
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.Lodor, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 2:                    //Sosaria
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.Sosaria, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 3:                    //Underworld
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.Underworld, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 4:                    //SerpentIsland
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.SerpentIsland, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 5:                    //IslesDread
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.IslesDread, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 6:                    //SavagedEmpire
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.SavagedEmpire, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            case 7:                    //Atlantis
                MakeSpawner(types, fakespawnsA, fakespawnsB, fakespawnsC, fakespawnsD, fakespawnsE, x, y, z, Map.Atlantis, mintime, maxtime, walkingrange, homerange, spawnid, npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE);
                break;
            default:
                Console.WriteLine("Spawn Parser: Warning, unknown map {0}", map);
                break;
        }
    }

    private static void MakeSpawner(string[] types, string[] fakespawnsA, string[] fakespawnsB, string[] fakespawnsC, string[] fakespawnsD, string[] fakespawnsE, int x, int y, int z, Map map, TimeSpan mintime, TimeSpan maxtime, int walkingrange, int homerange, int spawnid, int npccount, int fakecountA, int fakecountB, int fakecountC, int fakecountD, int fakecountE)
    {
        if (types.Length == 0)
        {
            return;
        }

        List <string> tipos = new List <string>(types);
        List <string> noneA = new List <string>();
        List <string> noneB = new List <string>();
        List <string> noneC = new List <string>();
        List <string> noneD = new List <string>();
        List <string> noneE = new List <string>();

        if (fakespawnsA[0] != "")
        {
            noneA = new List <string>(fakespawnsA);
        }

        if (fakespawnsB[0] != "")
        {
            noneB = new List <string>(fakespawnsB);
        }

        if (fakespawnsC[0] != "")
        {
            noneC = new List <string>(fakespawnsC);
        }

        if (fakespawnsD[0] != "")
        {
            noneD = new List <string>(fakespawnsD);
        }

        if (fakespawnsE[0] != "")
        {
            noneE = new List <string>(fakespawnsE);
        }

        PremiumSpawner spawner = new PremiumSpawner(npccount, fakecountA, fakecountB, fakecountC, fakecountD, fakecountE, spawnid, mintime, maxtime, Team, walkingrange, homerange, tipos, noneA, noneB, noneC, noneD, noneE);

        spawner.MoveToWorld(new Point3D(x, y, z), map);

        if (spawner.SpawnID == 9999)
        {
            spawner.MinDelay  = TimeSpan.FromSeconds(1.0);
            spawner.MaxDelay  = TimeSpan.FromSeconds(1.0);
            spawner.NextSpawn = TimeSpan.FromSeconds(1.0);
            spawner.Respawn();
        }
        else if (spawner.SpawnID == 8888)
        {
            spawner.MinDelay  = TimeSpan.FromMinutes(10.0);
            spawner.MaxDelay  = TimeSpan.FromMinutes(15.0);
            spawner.NextSpawn = TimeSpan.FromSeconds(1.0);
            Server.Mobiles.PremiumSpawner.Reconfigure(spawner, true);
        }
        else if (TotalRespawn && spawner.Running == true)
        {
            spawner.Respawn();
        }

        m_Count++;
    }
}
}
namespace Server.Gumps
{
public class SpawnEditorGump : Gump
{
    private int m_page;
    private ArrayList m_tempList;
    public Item m_selSpawner;

    public int page
    {
        get { return m_page; }
        set { m_page = value; }
    }

    public Item selSpawner
    {
        get { return m_selSpawner; }
        set { m_selSpawner = value; }
    }

    public ArrayList tempList
    {
        get { return m_tempList; }
        set { m_tempList = value; }
    }

    public static void Initialize()
    {
        CommandSystem.Register("SpawnEditor", AccessLevel.GameMaster, new CommandEventHandler(SpawnEditor_OnCommand));
        CommandSystem.Register("Editor", AccessLevel.GameMaster, new CommandEventHandler(SpawnEditor_OnCommand));
    }

    public static void Register(string command, AccessLevel access, CommandEventHandler handler)
    {
        CommandSystem.Register(command, access, handler);
    }

    [Usage("SpawnEditor")]
    [Aliases("Editor")]
    [Description("Used to find and edit spawns")]
    public static void SpawnEditor_OnCommand(CommandEventArgs e)
    {
        Mobile from = e.Mobile;
        SpawnEditor_OnCommand(from);
    }

    public static void SpawnEditor_OnCommand(Mobile from)
    {
        ArrayList worldList = new ArrayList();
        ArrayList facetList = new ArrayList();

        Type type = ScriptCompiler.FindTypeByName("PremiumSpawner", true);

        if (type == typeof(Item) || type.IsSubclassOf(typeof(Item)))
        {
            bool isAbstract = type.IsAbstract;

            foreach (Item item in World.Items.Values)
            {
                if (isAbstract ? item.GetType().IsSubclassOf(type) : item.GetType() == type)
                {
                    worldList.Add(item);
                }
            }
        }

        foreach (PremiumSpawner worldSpnr in worldList)
        {
            if (worldSpnr.Map == from.Map)
            {
                facetList.Add(worldSpnr);
            }
        }

//TODO: Sort spawner list

        SpawnEditor_OnCommand(from, 0, facetList);
    }

    public static void SpawnEditor_OnCommand(Mobile from, int page, ArrayList currentList)
    {
        SpawnEditor_OnCommand(from, page, currentList, 0);
    }

    public static void SpawnEditor_OnCommand(Mobile from, int page, ArrayList currentList, int selected)
    {
        SpawnEditor_OnCommand(from, page, currentList, selected, null);
    }

    public static void SpawnEditor_OnCommand(Mobile from, int page, ArrayList currentList, int selected, Item selSpawner)
    {
        from.SendGump(new SpawnEditorGump(from, page, currentList, selected, selSpawner));
    }

    public SpawnEditorGump(Mobile from, int page, ArrayList currentList, int selected, Item spwnr) : base(50, 40)
    {
        tempList = new ArrayList();
        Mobile m = from;
        m_page = page;
        Region r        = from.Region;
        Map    map      = from.Map;
        int    buttony  = 60;
        int    buttonID = 1;
        int    listnum  = 0;

        tempList = currentList;

        selSpawner = spwnr;

        AddPage(0);

        AddBackground(0, 0, 600, 450, 5054);
        AddImageTiled(8, 8, 584, 40, 2624);
        AddAlphaRegion(8, 8, 584, 40);
        AddImageTiled(8, 50, 250, 396, 2624);
        AddAlphaRegion(8, 50, 250, 396);
        AddImageTiled(260, 50, 332, 396, 2624);
        AddAlphaRegion(260, 50, 332, 396);
        AddLabel(220, 20, 52, "PREMIUM SPAWNER EDITOR");
        AddButton(550, 405, 0x158A, 0x158B, 10002, GumpButtonType.Reply, 1);                   //Quit Button
        AddButton(275, 412, 0x845, 0x846, 10008, GumpButtonType.Reply, 0);
        AddLabel(300, 410, 52, "Refresh");

        if (currentList.Count == 0)
        {
            AddLabel(50, 210, 52, "No Premium Spawners Found");
        }
        else
        {
            if (page == 0)
            {
                if (currentList.Count < 15)
                {
                    listnum = currentList.Count;
                }
                else
                {
                    listnum = 15;
                }

                for (int x = 0; x < listnum; x++)
                {
                    Item spawnr = null;

                    if (currentList[x] is Item)
                    {
                        spawnr = currentList[x] as Item;
                    }

                    string gumpMsg = "";

                    Point3D spawnr3D     = new Point3D((new Point2D(spawnr.X, spawnr.Y)), spawnr.Z);
                    Region  spawnrRegion = Region.Find(spawnr3D, map);

                    if (spawnrRegion.ToString() == "")
                    {
                        gumpMsg = "PremiumSpawner at " + spawnr.X.ToString() + ", " + spawnr.Y.ToString();
                    }
                    else
                    {
                        gumpMsg = spawnrRegion.ToString();
                    }

                    AddButton(25, buttony, 0x845, 0x846, buttonID, GumpButtonType.Reply, 0);
                    AddLabel(55, buttony, 52, gumpMsg);
                    buttony  += 25;
                    buttonID += 1;
                }
            }

            else if (page > 0)
            {
                if (currentList.Count < 15 + (15 * page))
                {
                    listnum = currentList.Count;
                }
                else
                {
                    listnum = 15 + (15 * page);
                }

                for (int x = 15 * page; x < listnum; x++)
                {
                    Item spawnr = null;
                    buttonID = x + 1;

                    if (currentList[x] is Item)
                    {
                        spawnr = currentList[x] as Item;
                    }

                    string gumpMsg = "";

                    Point3D spawnr3D     = new Point3D((new Point2D(spawnr.X, spawnr.Y)), spawnr.Z);
                    Region  spawnrRegion = Region.Find(spawnr3D, map);

                    if (spawnrRegion.ToString() == "")
                    {
                        gumpMsg = "PremiumSpawner at " + spawnr.X.ToString() + ", " + spawnr.Y.ToString();
                    }
                    else
                    {
                        gumpMsg = spawnrRegion.ToString();
                    }

                    AddButton(25, buttony, 0x845, 0x846, buttonID, GumpButtonType.Reply, 0);
                    AddLabel(55, buttony, 52, gumpMsg);
                    buttony += 25;
                }
            }
        }

        if (page == 0 && currentList.Count > 15)
        {
            AddButton(450, 20, 0x15E1, 0x15E5, 10000, GumpButtonType.Reply, 0);
        }
        else if (page > 0 && currentList.Count > 15 + (page * 15))
        {
            AddButton(450, 20, 0x15E1, 0x15E5, 10000, GumpButtonType.Reply, 0);
        }

        if (page != 0)
        {
            AddButton(150, 20, 0x15E3, 0x15E7, 10001, GumpButtonType.Reply, 0);
        }

        int pageNum  = (int)currentList.Count / 15;
        int rem      = currentList.Count % 15;
        int totPages = 0;

        string stotPages = "";

        if (rem > 0)
        {
            totPages  = pageNum + 1;
            stotPages = totPages.ToString();
        }
        else
        {
            stotPages = pageNum.ToString();
        }

        string pageText = "Page " + (page + 1) + " of " + stotPages;

        AddLabel(40, 20, 52, pageText);

        if (selected == 0)
        {
            InitializeStartingRightPanel();
        }
        else if (selected == 1)
        {
            InitializeSelectedRightPanel();
        }
    }

    public void InitializeStartingRightPanel()
    {
        AddLabel(275, 65, 52, "Filter to current region only");
        AddButton(500, 65, 0x15E1, 0x15E5, 10003, GumpButtonType.Reply, 0);

        AddTextField(275, 140, 50, 20, 0);
        AddLabel(275, 115, 52, "Filter by Distance");
        AddButton(500, 115, 0x15E1, 0x15E5, 10004, GumpButtonType.Reply, 0);

        AddTextField(275, 190, 120, 20, 1);
        AddLabel(275, 165, 52, "Search Spawners by Creature");
        AddButton(500, 165, 0x15E1, 0x15E5, 10009, GumpButtonType.Reply, 0);

        AddTextField(275, 240, 50, 20, 2);
        AddLabel(275, 215, 52, "Search Spawners by SpawnID");
        AddButton(500, 215, 0x15E1, 0x15E5, 10010, GumpButtonType.Reply, 0);
    }

    public void InitializeSelectedRightPanel()
    {
        string spX     = selSpawner.X.ToString();
        string spY     = selSpawner.Y.ToString();
        string spnText = "PremiumSpawner at " + spX + ", " + spY;

        AddLabel(350, 65, 52, spnText);

        PremiumSpawner initSpn = selSpawner as PremiumSpawner;
        int            strNum  = 0;
        string         spns    = "Containing: ";
        string         spnsNEW = "";
        string         spns1   = "";
        string         spns2   = "";
        string         spns3   = "";

        for (int i = 0; i < initSpn.CreaturesName.Count; i++)
        {
            if (strNum == 0)
            {
                if (i < initSpn.CreaturesName.Count - 1)
                {
                    if (spns.Length + initSpn.CreaturesName[i].ToString().Length < 50)
                    {
                        spnsNEW += (string)initSpn.CreaturesName[i] + ", ";
                    }
                    else
                    {
                        strNum = 1;
                        spns1 += (string)initSpn.CreaturesName[i] + ", ";
                    }
                }
                else
                {
                    spnsNEW += (string)initSpn.CreaturesName[i];
                }
            }
            else if (strNum == 1)
            {
                if (i < initSpn.CreaturesName.Count - 1)
                {
                    if (spns1.Length + initSpn.CreaturesName[i].ToString().Length < 50)
                    {
                        spns1 += (string)initSpn.CreaturesName[i] + ", ";
                    }
                    else
                    {
                        strNum = 2;
                        spns2 += (string)initSpn.CreaturesName[i] + ", ";
                    }
                }
                else
                {
                    if (spns1.Length + initSpn.CreaturesName[i].ToString().Length < 50)
                    {
                        spns1 += (string)initSpn.CreaturesName[i];
                    }
                    else
                    {
                        strNum = 3;
                        spns2 += (string)initSpn.CreaturesName[i];
                    }
                }
            }
            else if (strNum == 2)
            {
                if (i < initSpn.CreaturesName.Count - 1)
                {
                    if (spns2.Length + initSpn.CreaturesName[i].ToString().Length < 50)
                    {
                        spns2 += (string)initSpn.CreaturesName[i] + ", ";
                    }
                    else
                    {
                        strNum = 3;
                        spns3 += (string)initSpn.CreaturesName[i] + ", ";
                    }
                }
                else
                {
                    if (spns2.Length + initSpn.CreaturesName[i].ToString().Length < 50)
                    {
                        spns2 += (string)initSpn.CreaturesName[i];
                    }
                    else
                    {
                        strNum = 4;
                        spns3 += (string)initSpn.CreaturesName[i];
                    }
                }
            }
            else if (strNum == 3)
            {
                if (i < initSpn.CreaturesName.Count - 1)
                {
                    spns3 += (string)initSpn.CreaturesName[i] + ", ";
                }
                else
                {
                    spns3 += (string)initSpn.CreaturesName[i];
                }
            }
        }

        string spnsNEWa = "";
        string spns1a   = "";
        string spns2a   = "";
        string spns3a   = "";

        for (int i = 0; i < initSpn.SubSpawnerA.Count; i++)
        {
            if (strNum == 0)
            {
                if (i < initSpn.SubSpawnerA.Count - 1)
                {
                    if (spns.Length + initSpn.SubSpawnerA[i].ToString().Length < 50)
                    {
                        spnsNEWa += (string)initSpn.SubSpawnerA[i] + ", ";
                    }
                    else
                    {
                        strNum  = 1;
                        spns1a += (string)initSpn.SubSpawnerA[i] + ", ";
                    }
                }
                else
                {
                    spnsNEWa += (string)initSpn.SubSpawnerA[i];
                }
            }
            else if (strNum == 1)
            {
                if (i < initSpn.SubSpawnerA.Count - 1)
                {
                    if (spns1a.Length + initSpn.SubSpawnerA[i].ToString().Length < 50)
                    {
                        spns1a += (string)initSpn.SubSpawnerA[i] + ", ";
                    }
                    else
                    {
                        strNum  = 2;
                        spns2a += (string)initSpn.SubSpawnerA[i] + ", ";
                    }
                }
                else
                {
                    if (spns1a.Length + initSpn.SubSpawnerA[i].ToString().Length < 50)
                    {
                        spns1a += (string)initSpn.SubSpawnerA[i];
                    }
                    else
                    {
                        strNum  = 3;
                        spns2a += (string)initSpn.SubSpawnerA[i];
                    }
                }
            }
            else if (strNum == 2)
            {
                if (i < initSpn.SubSpawnerA.Count - 1)
                {
                    if (spns2a.Length + initSpn.SubSpawnerA[i].ToString().Length < 50)
                    {
                        spns2a += (string)initSpn.SubSpawnerA[i] + ", ";
                    }
                    else
                    {
                        strNum  = 3;
                        spns3a += (string)initSpn.SubSpawnerA[i] + ", ";
                    }
                }
                else
                {
                    if (spns2a.Length + initSpn.SubSpawnerA[i].ToString().Length < 50)
                    {
                        spns2a += (string)initSpn.SubSpawnerA[i];
                    }
                    else
                    {
                        strNum  = 4;
                        spns3a += (string)initSpn.SubSpawnerA[i];
                    }
                }
            }
            else if (strNum == 3)
            {
                if (i < initSpn.SubSpawnerA.Count - 1)
                {
                    spns3a += (string)initSpn.SubSpawnerA[i] + ", ";
                }
                else
                {
                    spns3a += (string)initSpn.SubSpawnerA[i];
                }
            }
        }

        string spnsNEWb = "";
        string spns1b   = "";
        string spns2b   = "";
        string spns3b   = "";

        for (int i = 0; i < initSpn.SubSpawnerB.Count; i++)
        {
            if (strNum == 0)
            {
                if (i < initSpn.SubSpawnerB.Count - 1)
                {
                    if (spns.Length + initSpn.SubSpawnerB[i].ToString().Length < 50)
                    {
                        spnsNEWb += (string)initSpn.SubSpawnerB[i] + ", ";
                    }
                    else
                    {
                        strNum  = 1;
                        spns1b += (string)initSpn.SubSpawnerB[i] + ", ";
                    }
                }
                else
                {
                    spnsNEWb += (string)initSpn.SubSpawnerB[i];
                }
            }
            else if (strNum == 1)
            {
                if (i < initSpn.SubSpawnerB.Count - 1)
                {
                    if (spns1b.Length + initSpn.SubSpawnerB[i].ToString().Length < 50)
                    {
                        spns1b += (string)initSpn.SubSpawnerB[i] + ", ";
                    }
                    else
                    {
                        strNum  = 2;
                        spns2b += (string)initSpn.SubSpawnerB[i] + ", ";
                    }
                }
                else
                {
                    if (spns1b.Length + initSpn.SubSpawnerB[i].ToString().Length < 50)
                    {
                        spns1b += (string)initSpn.SubSpawnerB[i];
                    }
                    else
                    {
                        strNum  = 3;
                        spns2b += (string)initSpn.SubSpawnerB[i];
                    }
                }
            }
            else if (strNum == 2)
            {
                if (i < initSpn.SubSpawnerB.Count - 1)
                {
                    if (spns2b.Length + initSpn.SubSpawnerB[i].ToString().Length < 50)
                    {
                        spns2b += (string)initSpn.SubSpawnerB[i] + ", ";
                    }
                    else
                    {
                        strNum  = 3;
                        spns3b += (string)initSpn.SubSpawnerB[i] + ", ";
                    }
                }
                else
                {
                    if (spns2b.Length + initSpn.SubSpawnerB[i].ToString().Length < 50)
                    {
                        spns2b += (string)initSpn.SubSpawnerB[i];
                    }
                    else
                    {
                        strNum  = 4;
                        spns3b += (string)initSpn.SubSpawnerB[i];
                    }
                }
            }
            else if (strNum == 3)
            {
                if (i < initSpn.SubSpawnerB.Count - 1)
                {
                    spns3b += (string)initSpn.SubSpawnerB[i] + ", ";
                }
                else
                {
                    spns3b += (string)initSpn.SubSpawnerB[i];
                }
            }
        }

        string spnsNEWc = "";
        string spns1c   = "";
        string spns2c   = "";
        string spns3c   = "";

        for (int i = 0; i < initSpn.SubSpawnerC.Count; i++)
        {
            if (strNum == 0)
            {
                if (i < initSpn.SubSpawnerC.Count - 1)
                {
                    if (spns.Length + initSpn.SubSpawnerC[i].ToString().Length < 50)
                    {
                        spnsNEWc += (string)initSpn.SubSpawnerC[i] + ", ";
                    }
                    else
                    {
                        strNum  = 1;
                        spns1c += (string)initSpn.SubSpawnerC[i] + ", ";
                    }
                }
                else
                {
                    spnsNEWc += (string)initSpn.SubSpawnerC[i];
                }
            }
            else if (strNum == 1)
            {
                if (i < initSpn.SubSpawnerC.Count - 1)
                {
                    if (spns1c.Length + initSpn.SubSpawnerC[i].ToString().Length < 50)
                    {
                        spns1c += (string)initSpn.SubSpawnerC[i] + ", ";
                    }
                    else
                    {
                        strNum  = 2;
                        spns2c += (string)initSpn.SubSpawnerC[i] + ", ";
                    }
                }
                else
                {
                    if (spns1c.Length + initSpn.SubSpawnerC[i].ToString().Length < 50)
                    {
                        spns1c += (string)initSpn.SubSpawnerC[i];
                    }
                    else
                    {
                        strNum  = 3;
                        spns2c += (string)initSpn.SubSpawnerC[i];
                    }
                }
            }
            else if (strNum == 2)
            {
                if (i < initSpn.SubSpawnerC.Count - 1)
                {
                    if (spns2c.Length + initSpn.SubSpawnerC[i].ToString().Length < 50)
                    {
                        spns2c += (string)initSpn.SubSpawnerC[i] + ", ";
                    }
                    else
                    {
                        strNum  = 3;
                        spns3c += (string)initSpn.SubSpawnerC[i] + ", ";
                    }
                }
                else
                {
                    if (spns2c.Length + initSpn.SubSpawnerC[i].ToString().Length < 50)
                    {
                        spns2c += (string)initSpn.SubSpawnerC[i];
                    }
                    else
                    {
                        strNum  = 4;
                        spns3c += (string)initSpn.SubSpawnerC[i];
                    }
                }
            }
            else if (strNum == 3)
            {
                if (i < initSpn.SubSpawnerC.Count - 1)
                {
                    spns3c += (string)initSpn.SubSpawnerC[i] + ", ";
                }
                else
                {
                    spns3c += (string)initSpn.SubSpawnerC[i];
                }
            }
        }

        string spnsNEWd = "";
        string spns1d   = "";
        string spns2d   = "";
        string spns3d   = "";

        for (int i = 0; i < initSpn.SubSpawnerD.Count; i++)
        {
            if (strNum == 0)
            {
                if (i < initSpn.SubSpawnerD.Count - 1)
                {
                    if (spns.Length + initSpn.SubSpawnerD[i].ToString().Length < 50)
                    {
                        spnsNEWd += (string)initSpn.SubSpawnerD[i] + ", ";
                    }
                    else
                    {
                        strNum  = 1;
                        spns1d += (string)initSpn.SubSpawnerD[i] + ", ";
                    }
                }
                else
                {
                    spnsNEWd += (string)initSpn.SubSpawnerD[i];
                }
            }
            else if (strNum == 1)
            {
                if (i < initSpn.SubSpawnerD.Count - 1)
                {
                    if (spns1d.Length + initSpn.SubSpawnerD[i].ToString().Length < 50)
                    {
                        spns1d += (string)initSpn.SubSpawnerD[i] + ", ";
                    }
                    else
                    {
                        strNum  = 2;
                        spns2d += (string)initSpn.SubSpawnerD[i] + ", ";
                    }
                }
                else
                {
                    if (spns1d.Length + initSpn.SubSpawnerD[i].ToString().Length < 50)
                    {
                        spns1d += (string)initSpn.SubSpawnerD[i];
                    }
                    else
                    {
                        strNum  = 3;
                        spns2d += (string)initSpn.SubSpawnerD[i];
                    }
                }
            }
            else if (strNum == 2)
            {
                if (i < initSpn.SubSpawnerD.Count - 1)
                {
                    if (spns2d.Length + initSpn.SubSpawnerD[i].ToString().Length < 50)
                    {
                        spns2d += (string)initSpn.SubSpawnerD[i] + ", ";
                    }
                    else
                    {
                        strNum  = 3;
                        spns3d += (string)initSpn.SubSpawnerD[i] + ", ";
                    }
                }
                else
                {
                    if (spns2d.Length + initSpn.SubSpawnerD[i].ToString().Length < 50)
                    {
                        spns2d += (string)initSpn.SubSpawnerD[i];
                    }
                    else
                    {
                        strNum  = 4;
                        spns3d += (string)initSpn.SubSpawnerD[i];
                    }
                }
            }
            else if (strNum == 3)
            {
                if (i < initSpn.SubSpawnerD.Count - 1)
                {
                    spns3d += (string)initSpn.SubSpawnerD[i] + ", ";
                }
                else
                {
                    spns3d += (string)initSpn.SubSpawnerD[i];
                }
            }
        }

        string spnsNEWe = "";
        string spns1e   = "";
        string spns2e   = "";
        string spns3e   = "";

        for (int i = 0; i < initSpn.SubSpawnerE.Count; i++)
        {
            if (strNum == 0)
            {
                if (i < initSpn.SubSpawnerE.Count - 1)
                {
                    if (spns.Length + initSpn.SubSpawnerE[i].ToString().Length < 50)
                    {
                        spnsNEWe += (string)initSpn.SubSpawnerE[i] + ", ";
                    }
                    else
                    {
                        strNum  = 1;
                        spns1e += (string)initSpn.SubSpawnerE[i] + ", ";
                    }
                }
                else
                {
                    spnsNEWe += (string)initSpn.SubSpawnerE[i];
                }
            }
            else if (strNum == 1)
            {
                if (i < initSpn.SubSpawnerE.Count - 1)
                {
                    if (spns1e.Length + initSpn.SubSpawnerE[i].ToString().Length < 50)
                    {
                        spns1e += (string)initSpn.SubSpawnerE[i] + ", ";
                    }
                    else
                    {
                        strNum  = 2;
                        spns2e += (string)initSpn.SubSpawnerE[i] + ", ";
                    }
                }
                else
                {
                    if (spns1e.Length + initSpn.SubSpawnerE[i].ToString().Length < 50)
                    {
                        spns1e += (string)initSpn.SubSpawnerE[i];
                    }
                    else
                    {
                        strNum  = 3;
                        spns2e += (string)initSpn.SubSpawnerE[i];
                    }
                }
            }
            else if (strNum == 2)
            {
                if (i < initSpn.SubSpawnerE.Count - 1)
                {
                    if (spns2e.Length + initSpn.SubSpawnerE[i].ToString().Length < 50)
                    {
                        spns2e += (string)initSpn.SubSpawnerE[i] + ", ";
                    }
                    else
                    {
                        strNum  = 3;
                        spns3e += (string)initSpn.SubSpawnerE[i] + ", ";
                    }
                }
                else
                {
                    if (spns2e.Length + initSpn.SubSpawnerE[i].ToString().Length < 50)
                    {
                        spns2e += (string)initSpn.SubSpawnerE[i];
                    }
                    else
                    {
                        strNum  = 4;
                        spns3e += (string)initSpn.SubSpawnerE[i];
                    }
                }
            }
            else if (strNum == 3)
            {
                if (i < initSpn.SubSpawnerE.Count - 1)
                {
                    spns3e += (string)initSpn.SubSpawnerE[i] + ", ";
                }
                else
                {
                    spns3e += (string)initSpn.SubSpawnerE[i];
                }
            }
        }

        AddLabel(275, 85, 52, spns);
        AddLabel(280, 110, 52, "[1]");
        AddLabel(280, 180, 52, "[2]");
        AddLabel(280, 250, 52, "[3]");
        AddLabel(425, 110, 52, "[4]");
        AddLabel(425, 180, 52, "[5]");
        AddLabel(425, 250, 52, "[6]");
        AddHtml(300, 110, 115, 65, spnsNEW, true, true);
        AddHtml(300, 180, 115, 65, spnsNEWa, true, true);
        AddHtml(300, 250, 115, 65, spnsNEWb, true, true);
        AddHtml(445, 110, 115, 65, spnsNEWc, true, true);
        AddHtml(445, 180, 115, 65, spnsNEWd, true, true);
        AddHtml(445, 250, 115, 65, spnsNEWe, true, true);
        if (spns1 != "")
        {
            AddLabel(275, 105, 200, spns1);
        }

        if (spns2 != "")
        {
            AddLabel(275, 125, 200, spns2);
        }

        if (spns3 != "")
        {
            AddLabel(275, 145, 200, spns3);
        }

        AddLabel(320, 320, 52, "Go to Spawner");
        AddButton(525, 320, 0x15E1, 0x15E5, 10005, GumpButtonType.Reply, 1);
        AddLabel(320, 345, 52, "Delete Selected Spawner");
        AddButton(525, 345, 0x15E1, 0x15E5, 10006, GumpButtonType.Reply, 0);
        AddLabel(320, 370, 52, "Edit Spawns");
        AddButton(525, 370, 0x15E1, 0x15E5, 10007, GumpButtonType.Reply, 0);
    }

    public List <string> CreateArray(RelayInfo info, Mobile from)
    {
        List <string> creaturesName = new List <string>();

        for (int i = 0; i < 13; i++)
        {
            TextRelay te = info.GetTextEntry(i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    Type type = SpawnerType.GetType(str);

                    if (type != null)
                    {
                        creaturesName.Add(str);
                    }
                    else
                    {
                        AddLabel(70, 230, 39, "Invalid Search String");
                    }
                }
            }
        }

        return creaturesName;
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        Mobile    from        = state.Mobile;
        int       buttonNum   = 0;
        ArrayList currentList = new ArrayList(tempList);
        int       page        = m_page;

        if (info.ButtonID > 0 && info.ButtonID < 10000)
        {
            buttonNum = 1;
        }
        else if (info.ButtonID > 20004)
        {
            buttonNum = 30000;
        }
        else
        {
            buttonNum = info.ButtonID;
        }

        switch (buttonNum)
        {
            case 0:
            {
                //Close
                break;
            }
            case 1:
            {
                selSpawner = currentList[info.ButtonID - 1] as Item;
                SpawnEditor_OnCommand(from, page, currentList, 1, selSpawner);
                break;
            }
            case 10000:
            {
                if (m_page * 10 < currentList.Count)
                {
                    page = m_page += 1;
                    SpawnEditor_OnCommand(from, page, currentList);
                }
                break;
            }
            case 10001:
            {
                if (m_page != 0)
                {
                    page = m_page -= 1;
                    SpawnEditor_OnCommand(from, page, currentList);
                }
                break;
            }
            case 10002:
            {
                //Close
                break;
            }
            case 10003:
            {
                FilterByRegion(from, tempList, from.Region, from.Map, page);
                break;
            }
            case 10004:
            {
                TextRelay oDis = info.GetTextEntry(0);
                string    sDis = (oDis == null ? "" : oDis.Text.Trim());
                if (sDis != "")
                {
                    try
                    {
                        int distance = Convert.ToInt32(sDis);
                        FilterByDistance(tempList, from, distance, page);
                    }
                    catch
                    {
                        from.SendMessage("Distance must be a number");
                        SpawnEditor_OnCommand(from, page, currentList);
                    }
                }
                else
                {
                    from.SendMessage("You must specify a distance");
                    SpawnEditor_OnCommand(from, page, currentList);
                }
                break;
            }
            case 10005:
            {
                from.Location = new Point3D(selSpawner.X, selSpawner.Y, selSpawner.Z);
                SpawnEditor_OnCommand(from, page, currentList, 1, selSpawner);
                break;
            }
            case 10006:
            {
                selSpawner.Delete();
                SpawnEditor_OnCommand(from);
                break;
            }
            case 10007:
            {
                from.SendGump(new PremiumSpawnerGump(selSpawner as PremiumSpawner));
                SpawnEditor_OnCommand(from, page, currentList, 1, selSpawner);
                break;
            }
            case 10008:
            {
                SpawnEditor_OnCommand(from);
                break;
            }
            case 10009:
            {
                TextRelay oSearch = info.GetTextEntry(1);
                string    sSearch = (oSearch == null ? null : oSearch.Text.Trim());
                SearchByName(tempList, from, sSearch, page);
                break;
            }
            case 10010:
            {
                TextRelay oID = info.GetTextEntry(2);
                string    sID = (oID == null ? "" : oID.Text.Trim());
                if (sID != "")
                {
                    try
                    {
                        int SearchID = Convert.ToInt32(sID);
                        SearchByID(tempList, from, SearchID, page);
                    }
                    catch
                    {
                        from.SendMessage("SpawnID must be a number");
                        SpawnEditor_OnCommand(from, page, currentList);
                    }
                }
                else
                {
                    from.SendMessage("You must specify a SpawnID");
                    SpawnEditor_OnCommand(from, page, currentList);
                }
                break;
            }
            case 20000:
            {
                PremiumSpawner spawner = selSpawner as PremiumSpawner;
                spawner.CreaturesName = CreateArray(info, state.Mobile);
                break;
            }
            case 20001:
            {
                PremiumSpawner spawner = selSpawner as PremiumSpawner;
                SpawnEditor_OnCommand(from, page, currentList, 2, selSpawner);
                spawner.BringToHome();
                break;
            }
            case 20002:
            {
                PremiumSpawner spawner = selSpawner as PremiumSpawner;
                SpawnEditor_OnCommand(from, page, currentList, 2, selSpawner);
                spawner.Respawn();
                break;
            }
            case 20003:
            {
                PremiumSpawner spawner = selSpawner as PremiumSpawner;
                SpawnEditor_OnCommand(from, page, currentList, 2, selSpawner);
                state.Mobile.SendGump(new PropertiesGump(state.Mobile, spawner));
                break;
            }
            case 30000:
            {
                int buttonID = info.ButtonID - 20004;
                int index    = buttonID / 2;
                int type     = buttonID % 2;

                PremiumSpawner spawner = selSpawner as PremiumSpawner;

                TextRelay entry = info.GetTextEntry(index);

                if (entry != null && entry.Text.Length > 0)
                {
                    if (type == 0)                               // Spawn creature
                    {
                        spawner.Spawn(entry.Text);
                    }
                    else                             // Remove creatures
                    {
                        spawner.RemoveCreatures(entry.Text);
                    }
                    //spawner.RemoveCreaturesA( entry.Text );

                    spawner.CreaturesName = CreateArray(info, state.Mobile);
                }

                break;
            }
        }
    }

    public static void FilterByRegion(Mobile from, ArrayList facetList, Region regr, Map regmap, int page)
    {
        ArrayList filregList = new ArrayList();

        foreach (Item regItem in facetList)
        {
            Point2D p2 = new Point2D(regItem.X, regItem.Y);
            Point3D p  = new Point3D(p2, regItem.Z);

            if (Region.Find(p, regmap) == regr)
            {
                filregList.Add(regItem);
            }
        }

        from.SendGump(new SpawnEditorGump(from, 0, filregList, 0, null));
    }

    public static void FilterByDistance(ArrayList currentList, Mobile m, int dis, int page)
    {
        ArrayList fildisList = new ArrayList();

        for (int z = 0; z < currentList.Count; z++)
        {
            Item disItem = currentList[z] as Item;

            if (disItem.X >= m.X - dis && disItem.X <= m.X + dis && disItem.Y >= m.Y - dis && disItem.Y <= m.Y + dis)
            {
                fildisList.Add(disItem);
            }
        }

        m.SendGump(new SpawnEditorGump(m, 0, fildisList, 0, null));
    }

    public static void SearchByName(ArrayList currentList, Mobile from, string search, int page)
    {
        ArrayList searchList = new ArrayList();

        foreach (PremiumSpawner spn in currentList)
        {
            foreach (string str in spn.CreaturesName)
            {
                if (str.ToLower().IndexOf(search) >= 0)
                {
                    searchList.Add(spn);
                }
            }

            foreach (string str in spn.SubSpawnerA)
            {
                if (str.ToLower().IndexOf(search) >= 0)
                {
                    searchList.Add(spn);
                }
            }

            foreach (string str in spn.SubSpawnerB)
            {
                if (str.ToLower().IndexOf(search) >= 0)
                {
                    searchList.Add(spn);
                }
            }

            foreach (string str in spn.SubSpawnerC)
            {
                if (str.ToLower().IndexOf(search) >= 0)
                {
                    searchList.Add(spn);
                }
            }

            foreach (string str in spn.SubSpawnerD)
            {
                if (str.ToLower().IndexOf(search) >= 0)
                {
                    searchList.Add(spn);
                }
            }

            foreach (string str in spn.SubSpawnerE)
            {
                if (str.ToLower().IndexOf(search) >= 0)
                {
                    searchList.Add(spn);
                }
            }
        }

        from.SendGump(new SpawnEditorGump(from, 0, searchList, 0, null));
    }

    public static void SearchByID(ArrayList currentList, Mobile from, int SearchID, int page)
    {
        ArrayList searchList = new ArrayList();

        foreach (PremiumSpawner spn in currentList)
        {
            if (((PremiumSpawner)spn).SpawnID == SearchID)
            {
                searchList.Add(spn);
            }
        }

        from.SendGump(new SpawnEditorGump(from, 0, searchList, 0, null));
    }

    public void AddTextField(int x, int y, int width, int height, int index)
    {
        AddBackground(x - 2, y - 2, width + 4, height + 4, 0x2486);
        AddTextEntry(x + 2, y + 2, width - 4, height - 4, 0, index, "");
    }
}
}
namespace Server.Mobiles
{
public class SpawnerGump : Gump
{
    private Spawner m_Spawner;

    public SpawnerGump(Spawner spawner) : base(50, 50)
    {
        m_Spawner = spawner;

        AddPage(0);

        AddBackground(0, 0, 410, 371, 5054);

        AddLabel(95, 1, 0, "Creatures List");

        AddButton(5, 347, 0xFB1, 0xFB3, 0, GumpButtonType.Reply, 0);
        AddLabel(38, 347, 0x384, "Cancel");

        AddButton(5, 325, 0xFB7, 0xFB9, 1, GumpButtonType.Reply, 0);
        AddLabel(38, 325, 0x384, "Okay");

        AddButton(110, 325, 0xFB4, 0xFB6, 2, GumpButtonType.Reply, 0);
        AddLabel(143, 325, 0x384, "Bring to Home");

        AddButton(110, 347, 0xFA8, 0xFAA, 3, GumpButtonType.Reply, 0);
        AddLabel(143, 347, 0x384, "Total Respawn");

        for (int i = 0; i < 13; i++)
        {
            AddButton(5, (22 * i) + 20, 0xFA5, 0xFA7, 4 + (i * 2), GumpButtonType.Reply, 0);
            AddButton(38, (22 * i) + 20, 0xFA2, 0xFA4, 5 + (i * 2), GumpButtonType.Reply, 0);

            AddImageTiled(71, (22 * i) + 20, 309, 23, 0xA40);
            AddImageTiled(72, (22 * i) + 21, 307, 21, 0xBBC);

            string str = "";

            if (i < spawner.SpawnNames.Count)
            {
                str = (string)spawner.SpawnNames[i];
                int count = m_Spawner.CountCreatures(str);

                AddLabel(382, (22 * i) + 20, 0, count.ToString());
            }

            AddTextEntry(75, (22 * i) + 21, 304, 21, 0, i, str);
        }
    }

    public List <string> CreateArray(RelayInfo info, Mobile from)
    {
        List <string> creaturesName = new List <string>();

        for (int i = 0; i < 13; i++)
        {
            TextRelay te = info.GetTextEntry(i);

            if (te != null)
            {
                string str = te.Text;

                if (str.Length > 0)
                {
                    str = str.Trim();

                    string t = Spawner.ParseType(str);

                    Type type = ScriptCompiler.FindTypeByName(t);

                    if (type != null)
                    {
                        creaturesName.Add(str);
                    }
                    else
                    {
                        from.SendMessage("{0} is not a valid type name.", t);
                    }
                }
            }
        }

        return creaturesName;
    }

    public override void OnResponse(NetState state, RelayInfo info)
    {
        if (m_Spawner.Deleted)
        {
            return;
        }

        switch (info.ButtonID)
        {
            case 0:                     // Closed
            {
                break;
            }
            case 1:                     // Okay
            {
                m_Spawner.SpawnNames = CreateArray(info, state.Mobile);

                break;
            }
            case 2:                     // Bring everything home
            {
                m_Spawner.BringToHome();

                break;
            }
            case 3:                     // Complete respawn
            {
                m_Spawner.Respawn();

                break;
            }
            default:
            {
                int buttonID = info.ButtonID - 4;
                int index    = buttonID / 2;
                int type     = buttonID % 2;

                TextRelay entry = info.GetTextEntry(index);

                if (entry != null && entry.Text.Length > 0)
                {
                    if (type == 0)                               // Spawn creature
                    {
                        m_Spawner.Spawn(entry.Text);
                    }
                    else                             // Remove creatures
                    {
                        m_Spawner.RemoveSpawned(entry.Text);
                    }

                    m_Spawner.SpawnNames = CreateArray(info, state.Mobile);
                }

                break;
            }
        }
    }
}
}

namespace Server.Mobiles
{
public class SpawnerType
{
    public static Type GetType(string name)
    {
        return ScriptCompiler.FindTypeByName(name);
    }
}
}

/*
 *      Premium Spawner project was born as a "mod" of "Ultimate Spawner"
 * script created by a brazilian scripter called Atomic, who had a SHARD
 * called AtomicShard. It was based on a script that reads the spawns
 * information from a bunch of "maps" files and then place it in the
 * world. The original script was modified by Nerun (myself) and when the
 * number of changes to the original script became great, i changed the
 * name of my version. The Premium is the successor of the Ultimate Spawner
 * v4.0 R5 (until then, the simple addition of "R", followed by a number
 * differentiated my version from original script designed by Atomic).
 * The fundamental differences between the default RunUO Spawner system are:
 *
 * - "Premium" has new properties:
 *      1. SpawnID - Spawners IDentity: used to unload or save spawns
 *      2. OverrideMap - automatically change all map files from the
 *              spawners entries bellow it
 *      3. OverrideID - works as OverrideMap, but for SpawnID
 *      4. OverrideMinTime - works as OverrideMap, but for MinDelay
 *      5. OverrideMaxTime - works as OverrideMap, but for MaxDelay
 *
 * - "Premium" has it own engine, not using the default "Spawner"
 * that comes with RunUO, instead it uses the "PremiumSpawner". You can
 * use both systems simultaneously.
 *
 * - "Premium" has map files (pre-spawned world).
 *
 * - "Premium" is user friendly.
 *
 *      The basics of basics that you need to know is that this system is
 * useful to remain "safe" (in a ".map" file) the spawners that you created
 * with so much effort. Well, suppose you have to erase everything and start
 * the world from scratch. You will have to place more than ten thousand
 * spawns, by hand, again? NO! You just use a command prompt, everything
 * will be generated again, and without effort. All effort is done in the
 * process of map file creation (that you can do in-game).
 *      The current release is in version 5.2.x, and is considered very
 * mature (in terms of stability, reliability, features and ease of use)
 * and complete (in terms of world spawns).
 *
 * INDEX:
 *      1. PREMIUM SPAWNER INSTALATION
 *      2. PART I - Main Menu
 *      3. PART II - Writing a Map File (Basics)
 *      4. PART III - using Maps "In-Game" (Básics)
 *      5. PART IV - Writing a Map File (Advanced)
 *      6. PART V - using Maps "In-Game" (Advanced)
 *      7. PART VI - Edition Options
 *
 * >>>>>>>>>>>>>>>>>>>>>>>>>>>
 * PREMIUM SPAWNER INSTALATION
 * <<<<<<<<<<<<<<<<<<<<<<<<<<<
 *
 *      Spawner creation system, Premium "Spawner" consists in a collection
 * of scripts. As I added many scripts, I will not list them here. Today this
 * system is distributed in a package called "Nerun's Distro". There were
 * several packages in the beginning, but for convenience I have grouped in
 * a single distribution. This package also includes other resources, such as
 * spawns maps for use with this system, as gumps (menus) easy to use to further
 * facilitate the settlement of your world. This distro can be found in the
 * RunUO forum at http://www.runuo.com/.
 *
 * To install the distro:
 *
 * 1) Unrar "Distro SVN x.rar".
 *
 * 2) You will se two folders inside: "Data" and "Scripts". Plus some files
 * (including this tutiorial, changes history, benchmark tests, SpawnsID of
 *  all maps etc). Read the files for more usefull information if you want.
 *
 * 3) Cut the folders "Data" and "Scripts".
 *
 * 4) Go to "c:\RunUO 2.1\" (or where you install it) and paste it there. Windows
 * Explorer will say that those folders already exists, and will ask if you
 * want to overwrite, click "yes to all".
 *
 * >>>>>>>>>>>>>>>>>>
 * PART I - Main Menu
 * <<<<<<<<<<<<<<<<<<
 *
 *      To access the Main Menu wrote "[spawner" (without quotes) in the
 * command prompt. There are a lot of options in the menu, in two pages. These
 * options are self-explained:
 *
 * GUMP NAME                                    COMMAND PROMPT
 * ===========================================================
 * WORLD CREATION OPTIONS:
 *      Create World Gump ------------------ [createworld
 * SPAWN OPTIONS:
 *      Spawn Sosaria/Lodor -------------- [spawntrammel or [spawnfelucca
 *      Spawn Underworld --------------------- [spawnilshenar
 *      Spawn SerpentIsland ------------------------ [spawnmalas
 *      Spawn IslesDread ----------------------- [spawntokuno
 *      Spawn Ter Mur ---------------------- [spawntermur
 * UNLOAD SPAWNS
 *      Unload Sosaria/Lodor spawns ------ [unloadtrammel or [unloadfelucca
 *      Unload Underworld spawns ------------- [unloadilshenar
 *      Unload SerpentIsland spawns ---------------- [unloadmalas
 *      Unload IslesDread spawns --------------- [unloadtokuno
 *      Unload Ter Mur Spawns -------------- [unloadtermur
 * SAVE OPTIONS:
 *      Save All spawns (spawns.map) ------- [spawngen save
 *      Save 'By Hand' spawns (byhand.map) - [spawngen savebyhand
 *      Save spawns inside region ---------- [spawngen save RegionName
 *      Save spawns by coordinates --------- [spawngen save x1 y1 x2 y2
 * REMOVE OPTIONS:
 *      Remove All spawners (all facets) --- [spawngen remove
 *      Remove All spawners (current map) -- [spawnrem
 *      Remove spawners by ID -------------- [spawngen unload SpawnID
 *      Remove spawners by Coordinates ----- [spawngen remove x1 y1 x2 y2
 *      Remove spawners inside Region ------ [spawngen remove RegionName
 * EDITION OPTIONS:
 *      Spawn Editor ----------------------- [editor
 *      Clear All Facets ------------------- [clearall
 *      Set my own body to GM Style -------- [gmbody
 * CONVERSION UTILITY:
 *      RunUO Spawns to PremiumSpawner ----- [rse
 *
 *      As you can see, it centered on a single menu all the system commands,
 * you do not know how to write each line to use them, simply click, follow
 * the instructions and it is done. The following sections will describe how to
 * create a map file, and how to use the command line instead of the Menu.
 *
 * >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 * PART II - Writing a Map File (Basics)
 * <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 *
 *      Notepad can be used to create map files. You will see the following
 * basic information on a map:
 *
 ## Britain Graveyard:
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|4|0|0|0
 ##
 ##     This map above provides information from all spawns of the Britain
 ##Graveyard. Let's analyze it:
 ##
 ##- 1st Line: Starts with "##", this double "sharp" marks the beginning of
 ##a comment. In other words, what comes after him will not be read by the
 ##script. It is usually used to provide information about the script:
 ##Dungeon map name, actual review and so on.
 ##
 ##- 2nd Line: The spawner itself. Each line is a spawner, but the advantage
 ##of PremiumSpawner is that it contains up to 6 FakeSpawners within
 ##themselves, which are nothing more than spawners with the same
 ##attributes of distance, time etc, but with different creatures and
 ##amounts:
 ##
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|
 ##     4|0|0|0
 ##
 ##-  All Spawners starts with "*" followed by "|". This "|" separates the
 ##information into the line. The first 6 spaces are the names of the
 ##creatures, which in this case are:
 ##
 ##     Spawner 1: Spectre OR Wraith (the ":" serves to add several
 ##              creatures in a random list)
 ##
 ##     Spawner 2: Skeleton
 ##
 ##     Spawner 3: Zombie
 ##
 ##     Spawner 4: Empty (none)
 ##
 ##     Spawner 5: Empty (none)
 ##
 ##     Spawner 6: Empty (none)
 ##
 ##Each of them are called "Fake Spawner": are 6 spawners inside only
 ##one spawner.
 ##
 ##-  The three numbers that come after the creatures lists define the place
 ##where the spawner will be created. Following the "XYZ" format (all
 ##details of Spawners are separated by a "|"). In this case, the spawner
 ##will appear at coordinates "1369 | 1475 | 10", in other words,
 ##X = 1369, Y = 1475 and Z = 10. If you type "[go 1369 1475 10" you will
 ##go to the place where this Spawner will appear.
 ##
 ##-  The fourth number says in wich facet the Spawner will be placed. Note
 ##that this number is 2. The definition of the maps follow this pattern:
 ##
 ##     0 = Lodor AND Sosaria
 ##
 ##     1 = Lodor
 ##
 ##     2 = Sosaria
 ##
 ##     3 = Underworld
 ##
 ##     4 = SerpentIsland
 ##
 ##     5 = IslesDread
 ##
 ##So deduct that the spawner will be placed in Sosaria, because the room
 ##number (the map) is the number 2.
 ##
 ##-  Next 2 numbers after facet number: defines respectively the minimum
 ##and the maximum respawn time. That is, the creatures that spawn will
 ##respawn in a randomly chosen interval between the minimum and maximum
 ##time. In the example We have "5 | 10 |" (always a "|"). Time is in
 ##minutes, so creatures will respawn between 5 and 10 min after being
 ##killed by players.
 ##
 ##-  Next 2 numbers after respawn time: defines WalkingRange and HomeRange.
 ##In this case, 30 WalkingRange and 20 HomeRange. The creatures will walk
 ##for up to 30 "boxes" (those who we see in a maximum zoom in game)
 ##away from the spawner. But they will "respawn" randomly within a
 ##radius of up to 20 "boxes" from the spawner. Note that the HomeRange
 ##is always less than or equal to WalkingRange, NEVER MORE.
 ##
 ##-  Next number after Ranges: identifies the spawn, is a "SpawnID", it
 ##tell us to which "spawn group" it belongs. By default, it is always
 ##1. If you create any spawner in game using the "[add premiumspawner"
 ##command, the SpawnID will be the number 1. This identifies the
 ##spawners created "by hand". But the maps can have any number of
 ##SpawnID. It is advisable that all spawners of the same map, have the
 ##same SpawnID. We will see why bellow.
 ##
 ##-  The last 6 numbers, also important, say how many monsters defined at
 ##the beginning of the spawner (the first 6 spaces) will be generated
 ##by that spawner. If the numbers are "2 | 3 | 4 | 0 | 0 | 0" will be
 ##generated 2 Specters OR Wraiths (or 1 of each), 3 skeletons and 4
 ##Zombies. The latest figures are 0: nothing is created in the past
 ##3 spawners, even if you define a value, nothing could be generated,
 ##because no creature was listed there (as we saw).
 ##
 ##     As observation, note that most of spawner's properties, as
 ##described above, can be defined without the need to "see" where the
 ##spawner will appear, but the coordinates will need to "see". Because if
 ##you choose coordinates randomly, risks creating a spawner in an
 ##inaccessible place, for example, in the middle of the ocean! So you must
 ##go to the place where you would like spawner appear and use the command
 ##"[get location" or "[where" in that place. Then write down the details
 ##that will appear on the screen.
 ##     Made the map, just save it in the folder Data / Spawns (if there
 ##isn't a folder Date/Spawns, it's time to create one. Click "Save As",
 ##select the Save as Type "All Files" and then type a name for the map, not
 ##forgetting to set ".map" at the end of the name. In the above example,
 ##if we had made that map, we could give him the name "graveyard.map".
 ##
 ##SUMMARIZING
 ##     Default spawner format:
 ##
 *|List1|List2|List3|List4|List5|List6|X|Y|Z|facet|MinTime|MaxTime|
 ##WalkingRange|HomeRange|SpawnID|Count1|Count2|Count3|Count4|Count5|Count6
 ##
 ##
 ##>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 ##PART III - using Maps "In-Game" (Básics)
 ##<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 ##
 ##     This is simple, are just a commands list to be used in game for
 ##the PremiumSpawner's engine generates spawners from the maps created. On
 ##the assumption that you already installed the required scripts in RunUO
 ##folder, you can use the following commands:
 ##
 ##- [spawngen MapName.map
 ##     Read maps and create spawners. In the example you should use
 ##     "[spawngen graveyard.map" (no quotes).
 ##
 ##- [spawngen remove
 ##     Dungerous command! It will DELETE all PremiumSpawners of ALL facets
 ##     of UO, done "by hand" or "by map"!
 ##
 ##- [spawngen save
 ##     Usefull command: saves in a file called "Spawns.map" ALL the
 ##     PremiumSpawners in ALL UO facets, done "by hand" or "by map"!
 ##     Usefull if tou did a lot of custom maps and use this distro too.
 ##     After this, a simple "[spawngen spawns.map" will spawn everything
 ##     again.
 ##
 ##- [spawnrem
 ##     It will DELETE all PremiumSpawners of actual facet (that one
 ##     where your character is standing). Other facets will remain
 ##     spawned.
 ##
 ##
 ##>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 ##PART IV - Writing a Map File (Advanced)
 ##<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 ##
 ##Multiple Creatures and Randomness
 ##---------------------------------
 ##
 ##     You have learned to create maps using the class method, in other
 ##words, you type the name of the creature and then the statistics (count,
 ##delay, range etc). But what if you want more than one type of creature in
 ##the same spawner?
 ##
 ##     Use the method of two dots (":"). In this case, simply separate
 ##the creatures that you want with a ":" as in the example below:
 ##
 *|Spectre:Wraith||||||1369|1475|10|2|5|10|30|20|1|10|0|0|0|0|0
 ##
 ##     As a result, the spawner randomly selecs within the amount
 ##indicated, among the creatures on the list, separated by two dots.
 ##Remembering that you can put as many creatures you like, all separated by
 ##":". In the example, we could have 7 Wraith and 3 Specter, or 5 of each,
 ##this number will vary, but the tendency is to remain in the ratio of
 ##count / creatures. In the example: count = 10, creatures = 2. Ratio 5.
 ##So the spawns will tend to 5 Wraith and 5 Specter. Now let's play with
 ##statistics. And if we want to have a greater chance of appearing more
 ##Spectres than Wraiths? So we can write in this way:
 ##
 *|Spectre:Spectre:Wraith||||||1369|1475|10|2|5|10|30|20|1|10|0|0|0|0|0
 ##
 ##     The ratio now is 3.3 for creature, so the chances will be now:
 ##66.6% Spectres and 33.3% Wraiths.
 ##     As an advise, never place inside the same Spawner (FakeSpawner),
 ##"target" creatures with "non-target" creatures or items. What i want to
 ##say is: don't place a Spectre, a Wraith and a dog or a bottle to spawn
 ##together:
 ##
 *|Spectre:Wraith:Dog||||||1369|1475|10|2|5|10|30|20|1|10|0|0|0|0|0
 ##
 ##     If you do it, sometime the players will kill all monsters, but
 ##will not kill the dogs, and all the 10 creatures of that spawner will
 ##be just dogs! It happens because the Spawner spawn just the remaning
 ##amount (amount not spawned). If it spawn 10 creatures: 5 Spectres,
 ##3 Wraiths and 2 Dog, and if players kill all monsters except the dogs,
 ##next time the spawner will spawn 8 creatures (cause Dogs are alive) and
 ##it can spawn a few Spectres and Wraiths and a lot of Dogs again! And
 ##so on... I dit it in past releases, already fixed.
 ##
 ##Override Maps
 ##-------------
 ##
 ##     And if you want to do a map that works both in Sosaria and Lodor?
 ##Instead of edit the facet number in each line (spawner) of your map,
 ##you can superscribe the facet number with a simple, only, command line.
 ##In our example above, that generates spawns only in Sosaria, to generates
 ##spawns in Sosaria AND Lodor, we adds an "overridemap":
 ##
 ##overridemap 0
 ## Britain Graveyard:
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|4|0|0|0
 ##
 ##     Here, the number "2" of that spawner (the facet), will be read as "0"
 ##by the spawn generator engine. Facet numbers are the same as described in
 ##"PART II - Writing a Map File (Basics)".
 ##
 ##Override SpawnID
 ##----------------
 ##
 ##     Do the same as OverrideMap, but for SpawnIDs. SpawnID "1" will be read
 ##as "14", as bellow:
 ##
 ##overrideid 14
 ##overridemap 0
 ## Britain Graveyard:
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|4|0|0|0
 ##
 ##Override DelayTime
 ##------------------
 ##
 ##     Do the same as OverrideMap and OverrideID, but for delay time.
 ##
 ##     overridemintime
 ##
 ##     and or
 ##
 ##     overridemaxtime
 ##
 ##Exemple:
 ##
 ##overridemintime 10
 ##overridemaxtime 20
 ##overrideid 14
 ##overridemap 0
 ## Britain Graveyard:
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|4|0|0|0
 ##
 ##     The delays (min 5 and max 10 minutes) will be read as 10 and 20
 ##minutes.
 ##
 ##
 ##>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
 ##PART V - using Maps "In-Game" (Advanced)
 ##<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
 ##
 ##Settlement In-Game
 ##------------------
 ##
 ##     Another way to settlement your world (place spawns) is to go "in-game"
 ##and adds spawners by hand, with command [add premiumspawner CreatureName.
 ##And "set" the attributes (x = number):
 ##
 ##[set count x homerange x spawnrange x maxdelay x mindelay x
 ##
 ##Commands to Save and to Remove Spawns
 ##-------------------------------------
 ##
 ##     After spawn the desired area, you need to save yours spawns either with
 ##[spawngen save or with some advanced options. Just type [spawner and look under
 ##SAVE/REMOVE OPTIONS. There is a GUMP for each command. But you can use the
 ##command prompt instead:
 ##
 ##[spawngen savebyhand
 ##     To save spawns done "by hand" ([add premiumspawner... all by hand premium
 ##     spawners has SpawnID = 1). Spawns will be saved in "byhand.map" file in
 ##     Data/Monsters folder.
 ##
 ##[spawngen save x1 y1 x2 y2
 ##     To save all premium spawners in a spawns.map file. All premium spawners
 ##     inside the rectangle area (x1 y1 x2 y2) will be saved.
 ##
 ##     X and Y are coordinates:
 ##
 ##     (x1,y1)------+      All premium spawners between coordinates (x1,y1)
 |          |      and coordinates (x2,y2) will be saved.
 |          |
 |          |
 +---------(x2,y2)
 |
 | [spawngen save <region>
 |      Save premium spawners inside a region defined by RunUO to a spawns.map
 |      file, in Data/Monsters.
 |      Complete list of regions are in Data/System/XML/Regions.xml.
 |      Use [where to see the region where you are.
 |      Open Regions.xml to understand regions:
 |
 |      <region priority="50" name="Montor">
 |              <rect x="2411" y="366" width="135" height="241" />
 |              <rect x="2548" y="495" width="72" height="55" />
 |              <rect x="2564" y="585" width="3" height="42" />
 |              <rect x="2567" y="585" width="61" height="61" />
 |              <rect x="2499" y="627" width="68" height="63" />
 |              <inn x="2457" y="397" width="40" height="8" />
 |              <inn x="2465" y="405" width="8" height="8" />
 |              <inn x="2481" y="405" width="8" height="8" />
 |              <go location="(2466,544,0)" />
 |              <music name="Montor" />
 |      </region>
 |
 |      As you see, a Region is a lot of rectangles.
 |
 | NOTE: "[spawngen remove" can be used with the same options as for
 | "[spawngen save" above, but will remove spawns instead of save.
 |
 | NOTE: Go to Data/Monsters and rename spawns.map or byhand.map to another name,
 | because each time you save with those options, the old file will be deleted and
 | a new one will be saved over it.
 |
 | EXAMPLE:
 | "[spawngen save Montor" (save spawns inside Montor region)
 | We can rename the spawns.map to Montor.map.
 |
 | Unloading Maps (recommended)
 | ----------------------------
 |
 |      The better way to remove spawns instead of using "[spawngen remove"
 | and other Spartan options is the "Unload" method:
 |
 | [spawngen unload SpawnID
 |
 |      If you define a SpawnID to each custom map you has you can unload
 | or remove the entire map easier. Example: Graveyards.map saw above. All the
 | premium spawners inside that map has SpawnID = 1. Lets see:
 |
 ## Britain Graveyard:
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|4|0|0|0
 ##
 ##     The problem is that 1 is the default number to "by hand" maps.
 ##Lets change the ID of this map. In the example above we just need to change
 ##one number (that between numbers 20 and 2). But if the map had 100, maybe
 ##1000 premium spawners? hard work uh? Because of it there is the "overrideid"
 ##option. It set all the SpawnIDs bellow it to the desired ID. So lets do it:
 ##
 ##overrideid 14
 ## Britain Graveyard:
 *|Spectre:Wraith|Skeleton|Zombie||||1369|1475|10|2|5|10|30|20|1|2|3|4|0|0|0
 ##
 ##     Although each spawner still have 1 as ID on each line, the
 ##"overrideid 14" will force the spawn generator engine to read that "1" as
 ##if "14". Later in the game, if I want to remove this map is just type
 ##"[spawngen unload 14" and ready. None of my other spawns will be changed
 ##or removed.
 ##
 ##>>>>>>>>>>>>>>>>>>>>>>>>>
 ##PART VI - Edition Options
 ##<<<<<<<<<<<<<<<<<<<<<<<<<
 ##
 ##[editor
 ##     Opens the spawn editor of course. This will list all the
 ##     PremiumSpawners in the left side. In the right column you can see
 ##     a bunch of options to select only the desired spawners, go to it,
 ##     see it properties, and see it creatures.
 ##
 ##[clearall
 ##     Works as [Clearfacet but for ALL facets. Caution here.
 ##
 ##[GMbody
 ##     Will set some common attributes to GMs. Target yourself. A lot of
 ##     items, skills, stats, robes, full spellbooks etc, will appear in
 ##     your backpack. You always set your body to human body. You add
 ##     titles to [GM], [Admin], etc.
 */
