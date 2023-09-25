using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells.Necromancy;
using Server.Spells;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Server.Gumps
{
    public class CaptchaGump : Gump
    {
        public delegate void PostCaptchaAction(Mobile from, object o);

        public static void SendGumpAfterCaptcha(Mobile from, object o)
        {
            if (o != null && o is Gump)
                from.SendGump((Gump)o);
        }

        public static void sendCaptcha(Mobile from, PostCaptchaAction act, object actionObject )
        {
            if (from == null || act == null)
                return;

            if (from is PlayerMobile)
            {
                PlayerMobile pm = (PlayerMobile)from;
                if (DateTime.Now > pm.NextCaptchaTime)
                {
					pm.CloseGump(typeof(CaptchaGump));
                    pm.SendGump(new CaptchaGump(pm, act, actionObject));
                    return;
                }
            }
            act(from, actionObject);
        }

        private Mobile m_From;
        private char m_A;
        private char m_B;
        private char m_C;
        private PostCaptchaAction m_Action;
        private object m_ActionObject;

        public CaptchaGump(Mobile from, PostCaptchaAction act, object ActionObject)
            : base(100, 100)
        {
            m_From = from;
            m_Action = act;
            m_ActionObject = ActionObject;
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            char a = (char)(Utility.Random(26) + 65);
            char b = (char)(Utility.Random(26) + 65);
            char c = (char)(Utility.Random(26) + 65);
            m_A = a;
            m_B = b;
            m_C = c;

            AddPage(0);
            setupBackground();
            int[,] a_data = getCharacterData(a);
            a_data = rotateVector(a_data, Utility.RandomMinMax(-30,30));

            int[,] b_data = getCharacterData(b);
            b_data = rotateVector(b_data, Utility.RandomMinMax(-30,30));

            int[,] c_data = getCharacterData(c);
            c_data = rotateVector(c_data, Utility.RandomMinMax(-30,30));

            printCharacter(a_data, 38, 11, Utility.Random(1500));
            printCharacter(b_data, 92, 11, Utility.Random(1500));
            printCharacter(c_data, 146, 11, Utility.Random(1500));
        }

        public int[,] rotateVector(int[,] letter, int deg)
        {
            int [,] letterCopy = new int[letter.GetLength(0),2];
            double cos = Math.Cos(Math.PI * (double)deg / 180.0);
            double sin = Math.Sin(Math.PI * (double)deg / 180.0);
            if ( cos < 0.0000000001 && cos > -0.0000000001)
                cos = 0.0;
            if ( sin < 0.0000000001 && sin > -0.0000000001)
                sin = 0.0;

            for (int i = 0; i < letter.GetLength(0); i++)
            {
                int x = letter[i,0] - 4;
                int y = letter[i,1] - 6;
                letterCopy[i,0] =(int)Math.Round( ((cos * (double)x ) - (sin * (double)y)) ) + 4;
                letterCopy[i,1] = (int) Math.Round((sin * (double)x ) + (cos * (double)y)) + 6;
            }
            return letterCopy;
        }

        private int[,] getCharacterData(char c)
        {
            char ch = Char.ToUpper(c);
            int c_num = (int)ch;
            if ((c_num < 65 || c_num > 90))
            {
                return null;
            }

            return Alphabet[(int)ch - 65];
        }

        //for convenience in modifying the fonts
        public static int[][,] Alphabet = new int[26][,]
        {
            new int[,]{ // A
				{4,0},{5,0},{3,1},{6,1},{2,2},
				{7,2},{1,3},{8,3},{0,4},{9,4},
				{0,5},{9,5},{0,6},{9,6},{0,7},
				{9,7},{0,8},{1,8},{2,8},{3,8},
				{4,8},{5,8},{6,8},{7,8},{8,8},
				{9,8},{0,9},{9,9},{0,10},{9,10},
				{0,11},{9,11},{0,12},{9,12},{0,13},
				{9,13},
			},
			new int[,]{ // B
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{6,0},{0,1},{7,1},{0,2},
				{8,2},{0,3},{8,3},{0,4},{8,4},
				{0,5},{7,5},{0,6},{1,6},{2,6},
				{3,6},{4,6},{5,6},{6,6},{7,6},
				{0,7},{7,7},{0,8},{8,8},{0,9},
				{8,9},{0,10},{8,10},{0,11},{7,11},
				{0,12},{1,12},{2,12},{3,12},{4,12},
				{5,12},{6,12},
			},
			new int[,]{ // C
				{1,0},{2,0},{3,0},{4,0},{5,0},
				{6,0},{7,0},{8,0},{0,1},{9,1},
				{0,2},{0,3},{0,4},{0,5},{0,6},
				{0,7},{0,8},{0,9},{0,10},{0,11},
				{0,12},{9,12},{1,13},{2,13},{3,13},
				{4,13},{5,13},{6,13},{7,13},{8,13},
			},
			new int[,]{ // D
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{6,0},{0,1},{7,1},{0,2},
				{8,2},{0,3},{9,3},{0,4},{9,4},
				{0,5},{9,5},{0,6},{9,6},{0,7},
				{9,7},{0,8},{9,8},{0,9},{9,9},
				{0,10},{9,10},{0,11},{8,11},{0,12},
				{7,12},{0,13},{1,13},{2,13},{3,13},
				{4,13},{5,13},{6,13},
			},
			new int[,]{ // E
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{6,0},{0,1},{0,2},{0,3},
				{0,4},{0,5},{0,6},{1,6},{2,6},
				{3,6},{4,6},{5,6},{6,6},{0,7},
				{0,8},{0,9},{0,10},{0,11},{0,12},
				{1,12},{2,12},{3,12},{4,12},{5,12},
				{6,12},
			},
			new int[,]{ // F
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{6,0},{0,1},{0,2},{0,3},
				{0,4},{0,5},{0,6},{1,6},{2,6},
				{3,6},{4,6},{5,6},{6,6},{0,7},
				{0,8},{0,9},{0,10},{0,11},{0,12},
			},
			new int[,]{ // G
				{2,0},{3,0},{4,0},{5,0},{6,0},
				{7,0},{1,1},{8,1},{0,2},{9,2},
				{0,3},{0,4},{0,5},{0,6},{0,7},
				{5,7},{6,7},{7,7},{8,7},{9,7},
				{0,8},{9,8},{0,9},{9,9},{0,10},
				{9,10},{1,11},{8,11},{2,12},{3,12},
				{4,12},{5,12},{6,12},{7,12},
			},
			new int[,]{ // H
				{0,0},{9,0},{0,1},{9,1},{0,2},
				{9,2},{0,3},{9,3},{0,4},{9,4},
				{0,5},{9,5},{0,6},{1,6},{2,6},
				{3,6},{4,6},{5,6},{6,6},{7,6},
				{8,6},{9,6},{0,7},{9,7},{0,8},
				{9,8},{0,9},{9,9},{0,10},{9,10},
				{0,11},{9,11},{0,12},{9,12},
			},
			new int[,]{ // I
				{2,0},{3,0},{4,0},{5,0},{6,0},
				{4,1},{4,2},{4,3},{4,4},{4,5},
				{4,6},{4,7},{4,8},{4,9},{4,10},
				{4,11},{2,12},{3,12},{4,12},{5,12},
				{6,12},
			},
			new int[,]{ // J
				{7,0},{7,1},{7,2},{7,3},{7,4},
				{7,5},{7,6},{7,7},{7,8},{0,9},
				{7,9},{0,10},{7,10},{1,11},{6,11},
				{2,12},{3,12},{4,12},{5,12},
			},
			new int[,]{ // K
				{1,0},{8,0},{1,1},{7,1},{1,2},
				{6,2},{1,3},{5,3},{1,4},{4,4},
				{1,5},{3,5},{1,6},{2,6},{1,7},
				{3,7},{1,8},{4,8},{1,9},{5,9},
				{1,10},{6,10},{1,11},{7,11},{1,12},
				{8,12},
			},
			new int[,]{ // L
				{0,0},{0,1},{0,2},{0,3},{0,4},
				{0,5},{0,6},{0,7},{0,8},{0,9},
				{0,10},{0,11},{0,12},{1,12},{2,12},
				{3,12},{4,12},{5,12},{6,12},
			},
			new int[,]{ // M
				{0,0},{8,0},{0,1},{1,1},{7,1},
				{8,1},{0,2},{2,2},{6,2},{8,2},
				{0,3},{3,3},{5,3},{8,3},{0,4},
				{4,4},{8,4},{0,5},{8,5},{0,6},
				{8,6},{0,7},{8,7},{0,8},{8,8},
				{0,9},{8,9},{0,10},{8,10},{0,11},
				{8,11},{0,12},{8,12},
			},
			new int[,]{ // N
				{0,0},{8,0},{0,1},{1,1},{8,1},
				{0,2},{2,2},{8,2},{0,3},{2,3},
				{8,3},{0,4},{3,4},{8,4},{0,5},
				{3,5},{8,5},{0,6},{4,6},{8,6},
				{0,7},{5,7},{8,7},{0,8},{5,8},
				{8,8},{0,9},{6,9},{8,9},{0,10},
				{6,10},{8,10},{0,11},{7,11},{8,11},
				{0,12},{8,12},
			},
			new int[,]{ // O
				{2,0},{3,0},{4,0},{5,0},{6,0},
				{1,1},{7,1},{0,2},{8,2},{0,3},
				{8,3},{0,4},{8,4},{0,5},{8,5},
				{0,6},{8,6},{0,7},{8,7},{0,8},
				{8,8},{0,9},{8,9},{0,10},{8,10},
				{1,11},{7,11},{2,12},{3,12},{4,12},
				{5,12},{6,12},
			},
			new int[,]{ // P
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{0,1},{6,1},{0,2},{7,2},
				{0,3},{7,3},{0,4},{7,4},{0,5},
				{6,5},{0,6},{1,6},{2,6},{3,6},
				{4,6},{5,6},{0,7},{0,8},{0,9},
				{0,10},{0,11},{0,12},
			},
			new int[,]{ // Q
				{2,0},{3,0},{4,0},{5,0},{6,0},
				{1,1},{7,1},{0,2},{8,2},{0,3},
				{8,3},{0,4},{8,4},{0,5},{8,5},
				{0,6},{8,6},{0,7},{5,7},{8,7},
				{0,8},{6,8},{8,8},{1,9},{7,9},
				{2,10},{3,10},{4,10},{5,10},{6,10},
				{8,10},{9,11},
			},
			new int[,]{ // R
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{0,1},{6,1},{0,2},{7,2},
				{0,3},{7,3},{0,4},{7,4},{0,5},
				{6,5},{0,6},{1,6},{2,6},{3,6},
				{4,6},{5,6},{0,7},{2,7},{0,8},
				{3,8},{0,9},{4,9},{0,10},{5,10},
				{0,11},{6,11},{0,12},{7,12},
			},
			new int[,]{ // S
				{2,0},{3,0},{4,0},{5,0},{6,0},
				{1,1},{7,1},{0,2},{8,2},{0,3},
				{8,3},{0,4},{1,5},{2,6},{3,6},
				{4,6},{5,6},{6,6},{7,7},{8,8},
				{0,9},{8,9},{0,10},{8,10},{1,11},
				{7,11},{2,12},{3,12},{4,12},{5,12},
				{6,12},
			},
			new int[,]{ // T
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{6,0},{7,0},{8,0},{4,1},
				{4,2},{4,3},{4,4},{4,5},{4,6},
				{4,7},{4,8},{4,9},{4,10},{4,11},
				{4,12},
			},
			new int[,]{ // U
				{0,0},{8,0},{0,1},{8,1},{0,2},
				{8,2},{0,3},{8,3},{0,4},{8,4},
				{0,5},{8,5},{0,6},{8,6},{0,7},
				{8,7},{0,8},{8,8},{0,9},{8,9},
				{0,10},{8,10},{1,11},{7,11},{2,12},
				{3,12},{4,12},{5,12},{6,12},
			},
			new int[,]{ // V
				{0,0},{8,0},{0,1},{8,1},{0,2},
				{8,2},{0,3},{8,3},{1,4},{7,4},
				{1,5},{7,5},{1,6},{7,6},{2,7},
				{6,7},{2,8},{6,8},{3,9},{5,9},
				{3,10},{5,10},{4,11},{4,12},
			},
			new int[,]{ // W
				{0,0},{8,0},{0,1},{8,1},{0,2},
				{8,2},{0,3},{8,3},{0,4},{8,4},
				{0,5},{8,5},{0,6},{8,6},{0,7},
				{4,7},{8,7},{0,8},{4,8},{8,8},
				{0,9},{4,9},{8,9},{0,10},{4,10},
				{8,10},{0,11},{3,11},{5,11},{8,11},
				{1,12},{2,12},{6,12},{7,12},
			},
			new int[,]{ // X
				{0,0},{8,0},{0,1},{8,1},{0,2},
				{8,2},{1,3},{7,3},{2,4},{6,4},
				{3,5},{5,5},{4,6},{3,7},{5,7},
				{2,8},{6,8},{1,9},{7,9},{0,10},
				{8,10},{0,11},{8,11},{0,12},{8,12},
			},
			new int[,]{ // Y
				{0,0},{8,0},{0,1},{8,1},{0,2},
				{8,2},{0,3},{8,3},{1,4},{7,4},
				{2,5},{6,5},{3,6},{5,6},{4,7},
				{4,8},{4,9},{4,10},{4,11},{4,12},
			},
			new int[,]{ // Z
				{0,0},{1,0},{2,0},{3,0},{4,0},
				{5,0},{6,0},{7,0},{8,0},{8,1},
				{8,2},{7,3},{6,4},{5,5},{4,6},
				{3,7},{2,8},{1,9},{0,10},{0,11},
				{0,12},{1,12},{2,12},{3,12},{4,12},
				{5,12},{6,12},{7,12},{8,12},
			},
        };

        private void printCharacter(int[,] letter, int x, int y, int hue )
        {
            if (letter == null)
                return;
            for (int pixel = 0; pixel < letter.GetLength(0); pixel++)
            {
                AddImage(x + letter[pixel, 0] * 3, y + letter[pixel, 1] * 3, 9158, hue);//tl
            }
        }

        private void setupBackground()
        {
          AddImage(0, 3, 9274); //9274 dark Grey Background
          AddImage(68, 3, 9274);
          AddImage(38, 11, 9158); //9158 are the Tiny dots on the gump
          AddImage(83, 11, 9158);
          AddImage(137, 11, 9158);
          AddImage(191, 11, 9158);
          AddImage(92, 11, 9158);
          AddImage(146, 11, 9158);
          AddImage(38, 56, 9158);
          AddImage(83, 56, 9158);
          AddImage(137, 56, 9158);
          AddImage(191, 56, 9158);
          AddImage(92, 56, 9158);
          AddImage(146, 56, 9158);
          AddImage(4, 129, 9157);
          AddImage(20, 129, 9157);
          AddImage(36, 129, 9157);
          AddImage(52, 129, 9157);
          AddImage(68, 129, 9157);
          AddImage(84, 129, 9157);
          AddImage(100, 129, 9157);
          AddImage(116, 129, 9157);
          AddImage(132, 129, 9157);
          AddImage(148, 129, 9157);
          AddImage(164, 129, 9157);
          AddImage(180, 129, 9157);
          AddImage(196, 116, 9155);
          AddImage(196, 100, 9155);
          AddImage(196, 84, 9155);
          AddImage(196, 68, 9155);
          AddImage(196, 52, 9155);
          AddImage(196, 36, 9155);
          AddImage(196, 20, 9155);
          AddImage(196, 4, 9155);
          AddImage(1, 1, 9151);
          AddImage(17, 1, 9151);
          AddImage(33, 1, 9151);
          AddImage(49, 1, 9151);
          AddImage(65, 1, 9151);
          AddImage(81, 1, 9151);
          AddImage(97, 1, 9151);
          AddImage(113, 1, 9151);
          AddImage(129, 1, 9151);
          AddImage(145, 1, 9151);
          AddImage(161, 1, 9151);
          AddImage(177, 1, 9151);
          AddImage(183, 1, 9151);
          AddImage(55, 101, 2443, 1153); //Image where you entry Text (1153 is the hue)
          AddButton(124, 101, 247, 248, 2, GumpButtonType.Reply, 0);
          AddImage(29, 34, 9158);
          AddImage(23, 34, 9158);
          AddImage(17, 34, 9158);
          AddImage(11, 34, 9158);
          AddImage(11, 40, 9158);
          AddImage(11, 46, 9158);
          AddImage(11, 52, 9158);
          AddImage(11, 58, 9158);
          AddImage(11, 64, 9158);
          AddImage(11, 70, 9158);
          AddImage(11, 76, 9158);
          AddImage(11, 82, 9158);
          AddImage(11, 88, 9158);
          AddImage(11, 94, 9158);
          AddImage(11, 100, 9158);
          AddImage(11, 106, 9158);
          AddImage(11, 112, 9158);
          AddImage(17, 112, 9158);
          AddImage(23, 112, 9158);
          AddImage(29, 112, 9158);
          AddImage(35, 112, 9158);
          AddImage(41, 112, 9158);
          AddImage(38, 115, 9158);
          AddImage(38, 112, 9158);
          AddImage(38, 109, 9158);
          AddImage(35, 106, 9158);
          AddImage(35, 118, 9158);
          AddImage(32, 121, 9158);
          AddImage(32, 103, 9158);
          AddTextEntry(57, 103, 53, 20, 0, 3, @"");
          AddLabel(38, 67, 1153, @"Type the three letters"); //1153 is the hue
          AddImage(1, 116, 9153);
          AddImage(1, 100, 9153);
          AddImage(1, 84, 9153);
          AddImage(1, 68, 9153);
          AddImage(1, 52, 9153);
          AddImage(1, 36, 9153);
          AddImage(1, 20, 9153);
          AddImage(1, 4, 9153);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_From == null || m_ActionObject == null || sender == null || info == null)
            {
                return;
            }
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 2:
                {
                    TextRelay tr_captcha = info.GetTextEntry(3);
                    if(tr_captcha.Text.Length != 3 )
                    {
                        from.SendMessage("You failed to prove that you're not A.F.K.");
                        return;
                    }

                    if (Char.ToUpper(tr_captcha.Text[0]) != m_A || Char.ToUpper(tr_captcha.Text[1]) != m_B || Char.ToUpper(tr_captcha.Text[2]) != m_C)
                    {
                        from.SendMessage("You failed to prove that you're not A.F.K.");
                        return;
                    }

                    //They Passed the Captcha!
                    if (from is PlayerMobile)
                    {
                        PlayerMobile pm = (PlayerMobile)from;
                        pm.NextCaptchaTime = DateTime.Now + TimeSpan.FromMinutes(Utility.RandomMinMax(30,45));
                    }

                    //call our delegate and pass it our mobile & argument
                    m_Action(m_From, m_ActionObject);
                }
                break;
            }
        }
    }
}namespace Server.Gumps
{
  public class FontsGump : Gump
  {

    public static void Initialize()
    {
      CommandSystem.Prefix = "[";
      Register("fonts", AccessLevel.Player, new CommandEventHandler(fonts_OnCommand));
      Register("dumpFonts", AccessLevel.Player, new CommandEventHandler(dumpFonts_OnCommand));

    }

    public static void Register(string command, AccessLevel access, CommandEventHandler handler)
    {
      CommandSystem.Register(command, access, handler);
    }

    [Usage("fonts")]
    [Description("Opens Stats font creator.")]
    public static void dumpFonts_OnCommand(CommandEventArgs e)
    {

      for (int alphabetIndex = 0; alphabetIndex < 26; alphabetIndex++)
      {
        Console.WriteLine("\t\t\tnew int[,]{ // " + (char)(alphabetIndex + 65));
        int[,] letter = CaptchaGump.Alphabet[alphabetIndex];

        for (int i = 0; i < letter.GetLength(0); i++)
        {

          if (i % 5 == 0)
            if (i != 0)
            {
              Console.Write("\n\t\t\t\t");
            }
            else
            {
              Console.Write("\t\t\t\t");
            }
          Console.Write("{" + letter[i, 0] + "," + letter[i, 1] + "},");
        }

        Console.WriteLine("\n\t\t\t},");
      }
    }

    [Usage("fonts")]
    [Description("Opens Stats font creator.")]
    public static void fonts_OnCommand(CommandEventArgs e)
    {
      Mobile from = e.Mobile;

      char a = '0';

      if (e.Arguments.Length != 1)
      {
        from.SendMessage("You must specify a letter to edit");
        return;
      }
      try
      {
        a = Convert.ToChar(e.Arguments[0]);
      }
      catch
      {
        from.SendMessage("Please only specify single characters separated by spaces.");
        return;
      }
      from.CloseGump(typeof(FontsGump));
      Gump font_gump = new FontsGump(from, a);
      from.SendGump(font_gump);
    }

    private char m_Char;

    public FontsGump(Mobile from, char a)
      : base(100, 100)
    {
      Closable = true;
      Disposable = true;
      Dragable = true;
      Resizable = false;
      AddPage(0);
      setupBackground();
      AddButton(226, 389, 247, 248, 50, GumpButtonType.Reply, 0);

      a = Char.ToUpper(a);
      m_Char = a;
      int[,] letter = CaptchaGump.Alphabet[((int)a) - 65];
      List<int> checks = new List<int>();

      //*
      for (int i = 0; i < letter.GetLength(0); i++)
      {
        checks.Add(letter[i, 1] * 14 + letter[i, 0]);
        //Console.WriteLine("Adding " + (letter[i, 1] * 14 + letter[i, 0]) + ":" + letter[i, 0] + "," + letter[i, 1]);
      }

      int gridX = 150;
      int gridY = 150;
      int gridId = 100;
      for (int i = 0; i < 14; i++)
      {
        for (int j = 0; j < 10; j++)
        {
          if (checks.Contains(i * 14 + j))
          {
            AddCheck(gridX, gridY, 2510, 2511, true, gridId);
          }
          else
          {
            AddCheck(gridX, gridY, 2510, 2511, false, gridId);
          }
          gridX += 13;
          gridId++;
        }
        gridX = 150;
        gridY += 12;
      }
      /**/
    }

    private void setupBackground()
    {
      AddImage(286, 195, 9274);
      AddImage(83, 413, 10460);
      AddImage(84, 37, 10460);
      AddImage(113, 37, 10460);
      AddImage(143, 37, 10460);
      AddImage(173, 37, 10460);
      AddImage(203, 37, 10460);
      AddImage(233, 37, 10460);
      AddImage(263, 37, 10460);
      AddImage(293, 37, 10460);
      AddImage(323, 37, 10460);
      AddImage(353, 37, 10460);
      AddImage(383, 37, 10460);
      AddImage(413, 37, 10460);
      AddImage(113, 413, 10460);
      AddImage(143, 413, 10460);
      AddImage(173, 413, 10460);
      AddImage(203, 413, 10460);
      AddImage(233, 413, 10460);
      AddImage(263, 413, 10460);
      AddImage(293, 413, 10460);
      AddImage(323, 413, 10460);
      AddImage(353, 413, 10460);
      AddImage(383, 413, 10460);
      AddImage(413, 413, 10460);
      AddImage(416, 121, 9275);
      AddImage(105, 121, 9275);
      AddImage(117, 195, 9274);
      AddImage(245, 195, 9274);
      AddImage(117, 285, 9274);
      AddImage(245, 285, 9274);
      AddImage(286, 285, 9274);
      AddImage(416, 67, 9275);
      AddImage(105, 75, 9275);
      AddImage(117, 67, 9274);
      AddImage(105, 67, 9275);
      AddImage(245, 67, 9274);
      AddImage(286, 67, 9274);
      AddImage(382, 45, 10410);
      AddImage(67, 45, 10400);
      AddImage(382, 193, 10411);
      AddImage(382, 339, 10412);
      AddImage(67, 193, 10401);
      AddImage(67, 339, 10402);
    }

    public override void OnResponse(NetState sender, RelayInfo info)
    {
      Mobile from = sender.Mobile;

      switch (info.ButtonID)
      {
        case 0:
          break;

        case 50:
          {
            int[,] letter = new int[info.Switches.Length, 2];
            for (int i = 0; i < info.Switches.Length; i++)
            {
              int switchNum = info.Switches[i] - 100;
              letter[i, 0] = switchNum % 10;
              letter[i, 1] = switchNum / 10;
            }
            CaptchaGump.Alphabet[((int)m_Char) - 65] = letter;
            break;
          }
      }
    }
  }
}
