using System;
using Server;
using Server.Network;
using Server.Multis;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Accounting;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;

namespace Server.Items
{
	[Flipable(0x4C53, 0x4C54)]
	public class ResearchBag : Item
	{
		public override bool DisplayWeight { get { return false; } }

		[Constructable]
		public ResearchBag() : base( 0x4C53 )
		{
			Name = "research pack";
			Weight = 1.0;
			Hue = 0xABE;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( BagOwner != null ){ list.Add( 1049644, "Belongs to " + BagOwner.Name + "" ); }
        }

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your pack to do any research. " + Research.GetMaxSchoolResearched( this ) + " - " + Research.GetMaxCircleResearched( this ) + "" );
			}
			else if ( from.Skills[SkillName.Inscribe].Value < 30 )
			{
				from.SendMessage( "You cannot understand anything that is in this bag." );
			}
			else if ( BagOwner != from )
			{
				from.SendMessage( "This bag doesn't belong to you so you throw it out." );
				bool remove = true;
				foreach ( Account a in Accounts.GetAccounts() )
				{
					if (a == null)
						break;

					int index = 0;

					for (int i = 0; i < a.Length; ++i)
					{
						Mobile m = a[i];

						if (m == null)
							continue;

						if ( m == BagOwner )
						{
							m.AddToBackpack( this );
							remove = false;
						}

						++index;
					}
				}
				if ( remove )
				{
					this.Delete();
				}
			}
			else
			{
				BagPage = 1;
				from.CloseGump( typeof( ResearchGump ) );
				from.SendGump( new ResearchGump( this, from ) );
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			if ( dropped is BlankScroll )
			{
				if ( BagScrolls > 500 )
				{
					from.SendMessage( "This pack can only hold 500 blank scrolls." );
				}
				else
				{
					from.PlaySound( 0x48 );
					int need = 500 - BagScrolls;
					int have = dropped.Amount;

					if ( need >= have ){ BagScrolls = BagScrolls + have; dropped.Delete(); }
					else { BagScrolls = 500; dropped.Amount = dropped.Amount - need; }

					from.SendMessage( "The blank scrolls have been added to your pack." );

					if( from.HasGump( typeof(ResearchGump)) )
					{
						from.CloseGump( typeof(ResearchGump) );
						from.SendGump( new ResearchGump( this, from ) );
					}
				}
			}
			else if ( dropped is ScribesPen )
			{
				BaseTool tool = (BaseTool)dropped;

				if ( BagQuills > 500 )
				{
					from.SendMessage( "This pack can only hold 500 quills." );
				}
				else
				{
					from.PlaySound( 0x48 );
					BagQuills = BagQuills + tool.UsesRemaining;
					dropped.Delete();
					if ( BagQuills > 500 ){ BagQuills = 500; }

					from.SendMessage( "The quills have been added to your pack." );

					if( from.HasGump( typeof(ResearchGump)) )
					{
						from.CloseGump( typeof(ResearchGump) );
						from.SendGump( new ResearchGump( this, from ) );
					}
				}
			}

			return false;
		}

        public static void InvokeCommand( string c, Mobile from )
        {
            CommandSystem.Handle(from, String.Format("{0}{1}", CommandSystem.Prefix, c));
        }

		public class ResearchGump : Gump
		{
			private ResearchBag m_Bag;
			private int m_Page;

			public ResearchGump( ResearchBag bag, Mobile from ) : base( 50, 50 )
			{
				from.SendSound( 0x55 );
				string color = "#6cb89a";
				string titleTxt = "";

				m_Bag = bag;
				m_Page = bag.BagPage;
					if ( !Research.GetRunes( bag, 26 ) && m_Page != 12 && m_Page != 2 ){ m_Page = bag.BagPage = 2; }

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);

				AddImage(0, 0, 7042, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddButton(859, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);
				AddItem(397, 17, 3636);
				AddItem(533, 9, 8273);
				AddItem(654, 11, 10282);
				AddHtml( 441, 16, 80, 20, @"<BODY><BASEFONT Color=" + color + ">" + (bag.BagScrolls).ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 567, 16, 80, 20, @"<BODY><BASEFONT Color=" + color + ">" + (bag.BagQuills).ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);
				AddHtml( 684, 16, 80, 20, @"<BODY><BASEFONT Color=" + color + ">" + (bag.BagInk).ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);

				if ( ( m_Page < 10 || m_Page > 20 ) && Research.GetRunes( bag, 26 ) ) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					int m = 44;	if ( Research.GetResearch( bag, 1 ) ){ m = -17; }

					int button_top_menu = 3609; if ( m_Page == 1 ){ button_top_menu = 4011; }
					AddButton(180+m, 75, button_top_menu, button_top_menu, 1, GumpButtonType.Reply, 0);
					AddItem(216+m, 78, 10174);
					button_top_menu = 3609; if ( m_Page == 2 ){ button_top_menu = 4011; }
					AddButton(280+m, 75, button_top_menu, button_top_menu, 2, GumpButtonType.Reply, 0);
					AddItem(316+m, 74, 19516);
					button_top_menu = 3609; if ( m_Page == 3 || ( m_Page > 20 && m_Page < 30 ) ){ button_top_menu = 4011; }
					AddButton(380+m, 75, button_top_menu, button_top_menu, 3, GumpButtonType.Reply, 0);
					AddItem(405+m, 74, 3834);
					button_top_menu = 3609; if ( m_Page == 4 ){ button_top_menu = 4011; }
					AddButton(480+m, 75, button_top_menu, button_top_menu, 4, GumpButtonType.Reply, 0);
					AddItem(505+m, 74, 8787);
					button_top_menu = 3609; if ( m_Page == 5 || ( m_Page > 30 && m_Page < 40 ) ){ button_top_menu = 4011; }
					AddButton(580+m, 75, button_top_menu, button_top_menu, 5, GumpButtonType.Reply, 0);
					AddItem(603+m, 72, 17087);
					if ( Research.GetResearch( bag, 1 ) )
					{
						button_top_menu = 3609; if ( m_Page == 6 || ( m_Page > 40 && m_Page < 50 ) ){ button_top_menu = 4011; }
						AddButton(680+m, 75, button_top_menu, button_top_menu, 6, GumpButtonType.Reply, 0);
						AddItem(718+m, 72, 19541);
					}
				}

				titleTxt = "SPELL RESEARCH";

				if ( m_Page == 1 ) // MAIN SCREEN /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "MAIN PACK";
					AddButton(777, 10, 3610, 3610, 11, GumpButtonType.Reply, 0); // HELP BUTTON

					int a = -28;

					AddItem(104+a, 160, 3636);
					AddHtml( 145+a, 163, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Scrolls</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 239+a, 163, 53, 20, @"<BODY><BASEFONT Color=" + color + ">" + (bag.BagScrolls).ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddItem(417+a, 148, 8273);
					AddHtml( 444+a, 163, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Quills</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 538+a, 163, 53, 20, @"<BODY><BASEFONT Color=" + color + ">" + (bag.BagQuills).ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddItem(698+a, 159, 10282);
					AddHtml( 727+a, 163, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Ink</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 821+a, 163, 53, 20, @"<BODY><BASEFONT Color=" + color + ">" + (bag.BagInk).ToString() + "</BASEFONT></BODY>", (bool)false, (bool)false);

					string msg = "Your pack is fully stocked with octopus ink.";
					if ( bag.BagInk < 500 ){ msg = "More octopus ink is rumored to be at " + bag.BagInkLocation + " in " + bag.BagInkWorld + "."; }

					AddHtml( 100+a, 207, 778, 20, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

					if ( Research.GetResearch( bag, 1 ) )
					{
						AddButton(121+a, 304, 4005, 4005, 1201, GumpButtonType.Reply, 0);
						AddHtml( 161+a, 304, 204, 20, @"<BODY><BASEFONT Color=" + color + ">Research Spell Bar I</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(436+a, 304, 4005, 4005, 1211, GumpButtonType.Reply, 0);
						AddHtml( 478+a, 304, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Open Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(693+a, 304, 4017, 4017, 1221, GumpButtonType.Reply, 0);
						AddHtml( 734+a, 304, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Close Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);

						AddButton(121+a, 344, 4005, 4005, 1202, GumpButtonType.Reply, 0);
						AddHtml( 161+a, 344, 204, 20, @"<BODY><BASEFONT Color=" + color + ">Research Spell Bar II</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(436+a, 344, 4005, 4005, 1212, GumpButtonType.Reply, 0);
						AddHtml( 478+a, 344, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Open Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(693+a, 344, 4017, 4017, 1222, GumpButtonType.Reply, 0);
						AddHtml( 734+a, 344, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Close Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);

						AddButton(121+a, 384, 4005, 4005, 1203, GumpButtonType.Reply, 0);
						AddHtml( 161+a, 384, 204, 20, @"<BODY><BASEFONT Color=" + color + ">Research Spell Bar III</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(436+a, 384, 4005, 4005, 1213, GumpButtonType.Reply, 0);
						AddHtml( 478+a, 384, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Open Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(693+a, 384, 4017, 4017, 1223, GumpButtonType.Reply, 0);
						AddHtml( 734+a, 384, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Close Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);

						AddButton(121+a, 424, 4005, 4005, 1204, GumpButtonType.Reply, 0);
						AddHtml( 161+a, 424, 204, 20, @"<BODY><BASEFONT Color=" + color + ">Research Spell Bar IV</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(436+a, 424, 4005, 4005, 1214, GumpButtonType.Reply, 0);
						AddHtml( 478+a, 424, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Open Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(693+a, 424, 4017, 4017, 1224, GumpButtonType.Reply, 0);
						AddHtml( 734+a, 424, 147, 20, @"<BODY><BASEFONT Color=" + color + ">Close Toolbar</BASEFONT></BODY>", (bool)false, (bool)false);
					}
				}
				if ( m_Page == 2 ) // RUNES FOUND /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					int icon = 0;
					int next = 1;
					string Rune = "";
					string rune = "";
					string missing = "";
					int r = 0;

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(145, 146, icon);
					AddHtml( 192, 156, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 146, icon);
					AddHtml( 377, 156, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 146, icon);
					AddHtml( 562, 156, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(700, 146, icon);
					AddHtml( 747, 156, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(145, 226, icon);
					AddHtml( 192, 236, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 226, icon);
					AddHtml( 377, 236, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 226, icon);
					AddHtml( 562, 236, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(700, 226, icon);
					AddHtml( 747, 236, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(145, 306, icon);
					AddHtml( 192, 316, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 306, icon);
					AddHtml( 377, 316, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 306, icon);
					AddHtml( 562, 316, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(700, 306, icon);
					AddHtml( 747, 316, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(145, 386, icon);
					AddHtml( 192, 396, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 386, icon);
					AddHtml( 377, 396, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 386, icon);
					AddHtml( 562, 396, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(700, 386, icon);
					AddHtml( 747, 396, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(145, 466, icon);
					AddHtml( 192, 476, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 466, icon);
					AddHtml( 377, 476, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 466, icon);
					AddHtml( 562, 476, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(700, 466, icon);
					AddHtml( 747, 476, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(145, 546, icon);
					AddHtml( 192, 556, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 546, icon);
					AddHtml( 377, 556, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 546, icon);
					AddHtml( 562, 556, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(700, 546, icon);
					AddHtml( 747, 556, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(330, 626, icon);
					AddHtml( 377, 636, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);
					r++;	Rune = Research.RuneName( r, 1 );	rune = Research.RuneName( r, 0 );	icon = 11277; if ( Research.GetRunes( bag, r ) ){ icon = Research.RuneIndex( rune, 1 ); } else if ( next > 0 ){ icon = 11278; next = 0; missing = Rune; }
					AddImage(515, 626, icon);
					AddHtml( 562, 636, 50, 20, @"<BODY><BASEFONT Color=" + color + ">" + Rune + "</BASEFONT></BODY>", (bool)false, (bool)false);

					string msg = "You have found all of the Cubes of Power.";
					if ( missing != "" ){ msg = "The Cube of " + missing + " is said to be in " + bag.RuneLocation + " in " + bag.RuneWorld + "."; }
					AddHtml( 104, 117, 778, 20, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddButton(777, 10, 3610, 3610, 12, GumpButtonType.Reply, 0); // HELP BUTTON
				}
				if ( m_Page == 3 || ( m_Page > 20 && m_Page < 30 ) ) // MAGERY RESEARCH
				{
					titleTxt = "MAGERY RESEARCH";
					int n = -35;

					int mcircleIcon = 3609; if ( m_Page == 21 || m_Page == 3 ){ mcircleIcon = 4017; }
					AddButton(105+n, 150, mcircleIcon, mcircleIcon, 21, GumpButtonType.Reply, 0);
					AddHtml( 145+n, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">1st Circle</BASEFONT></BODY>", (bool)false, (bool)false);

					if ( Research.GetWizardry( bag, 8 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 22 ){ mcircleIcon = 4017; }
						AddButton(325+n, 150, mcircleIcon, mcircleIcon, 22, GumpButtonType.Reply, 0);
						AddHtml( 365+n, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">2nd Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					if ( Research.GetWizardry( bag, 16 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 23 ){ mcircleIcon = 4017; }
						AddButton(545+n, 150, mcircleIcon, mcircleIcon, 23, GumpButtonType.Reply, 0);
						AddHtml( 585+n, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">3rd Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					if ( Research.GetWizardry( bag, 24 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 24 ){ mcircleIcon = 4017; }
						AddButton(765+n, 150, mcircleIcon, mcircleIcon, 24, GumpButtonType.Reply, 0);
						AddHtml( 805+n, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">4th Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					if ( Research.GetWizardry( bag, 32 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 25 ){ mcircleIcon = 4017; }
						AddButton(105+n, 190, mcircleIcon, mcircleIcon, 25, GumpButtonType.Reply, 0);
						AddHtml( 145+n, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">5th Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					if ( Research.GetWizardry( bag, 40 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 26 ){ mcircleIcon = 4017; }
						AddButton(325+n, 190, mcircleIcon, mcircleIcon, 26, GumpButtonType.Reply, 0);
						AddHtml( 365+n, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">6th Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					if ( Research.GetWizardry( bag, 48 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 27 ){ mcircleIcon = 4017; }
						AddButton(545+n, 190, mcircleIcon, mcircleIcon, 27, GumpButtonType.Reply, 0);
						AddHtml( 585+n, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">7th Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}
					if ( Research.GetWizardry( bag, 56 ) )
					{
						mcircleIcon = 3609; if ( m_Page == 28 ){ mcircleIcon = 4017; }
						AddButton(765+n, 190, mcircleIcon, mcircleIcon, 28, GumpButtonType.Reply, 0);
						AddHtml( 805+n, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">8th Circle</BASEFONT></BODY>", (bool)false, (bool)false);
					}

					string spellCircle = "first";
					int spellName = 1;
						if ( m_Page == 22 ){ spellName = 9; spellCircle = "second"; }
						else if ( m_Page == 23 ){ spellName = 17; spellCircle = "third"; }
						else if ( m_Page == 24 ){ spellName = 25; spellCircle = "fourth"; }
						else if ( m_Page == 25 ){ spellName = 33; spellCircle = "fifth"; }
						else if ( m_Page == 26 ){ spellName = 41; spellCircle = "sixth"; }
						else if ( m_Page == 27 ){ spellName = 49; spellCircle = "seventh"; }
						else if ( m_Page == 28 ){ spellName = 57; spellCircle = "eighth"; }

					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(115+n, 340, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 340, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+n, 340, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(115+n, 390, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 390, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+n, 390, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(115+n, 440, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 440, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+n, 440, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(115+n, 490, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 490, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+n, 490, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(670+n, 340, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+n, 340, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+n, 340, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(670+n, 390, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+n, 390, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+n, 390, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(670+n, 440, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+n, 440, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+n, 440, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;
					if ( Research.GetWizardry( bag, spellName ) )
					{
						AddButton(670+n, 490, 4005, 4005, 400+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+n, 490, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+n, 490, 4011, 4011, 300+spellName, GumpButtonType.Reply, 0);
					} spellName++;

					string msg = "You have researched all of the " + spellCircle + " circle magery spells.";
					string nextSpell = Research.NextWizardry( bag );

					if ( bag.BagMessage > 0 )
					{
						msg = bag.BagMsgString;
					}
					else if ( nextSpell != "" )
					{
						msg = "To learn the " + nextSpell + " spell you need to find " + bag.SpellsMageItem + " at " + bag.SpellsMageLocation + " in " + bag.SpellsMageWorld + ".";
					}

					AddHtml( 111+n, 278, 760, 45, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddButton(777, 10, 3610, 3610, 13, GumpButtonType.Reply, 0); // HELP BUTTON
				}
				if ( m_Page == 4 ) // NECROMANCY RESEARCH /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "NECROMANCY RESEARCH";

					int spellName = 1;
					int n = -35;

					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 235, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 235, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 235, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 265, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 265, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 265, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 295, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 295, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 295, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 325, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(154+n, 325, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 325, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 355, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 355, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 355, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 385, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 385, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 385, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 415, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 415, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 415, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 445, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 445, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 445, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(115+n, 475, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(155+n, 475, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 195+n, 475, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 235, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 235, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 235, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 265, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 265, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 265, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 295, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 295, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 295, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 325, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 325, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 325, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 355, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 355, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 355, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 385, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 385, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 385, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 415, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 415, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 415, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;
					if ( Research.GetNecromancy( bag, spellName ) )
					{
						AddButton(620+n, 445, 4005, 4005, 400+spellName+64, GumpButtonType.Reply, 0);
						AddButton(660+n, 445, 4011, 4011, 300+spellName+64, GumpButtonType.Reply, 0);
						AddHtml( 700+n, 445, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spellName+64, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName++;

					string msg = "You have researched all of the necromancy spells.";
					string nextSpell = Research.NextNecromancy( bag );

					if ( bag.BagMessage > 0 )
					{
						msg = bag.BagMsgString;
					}
					else if ( nextSpell != "" )
					{
						msg = "To learn the " + nextSpell + " spell you need to find " + bag.SpellsNecroItem + " at " + bag.SpellsNecroLocation + " in " + bag.SpellsNecroWorld + ".";
					}

					AddHtml( 113+n, 160, 760, 45, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddButton(777, 10, 3610, 3610, 14, GumpButtonType.Reply, 0); // HELP BUTTON
				}
				if ( m_Page == 5 || ( m_Page > 30 && m_Page < 40 ) ) // ANCIENT RESEARCH //////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "ANCIENT SPELL RESEARCH";

					int r = -28;

					int mcircleIcon = 3609; if ( m_Page == 31 || m_Page == 5 ){ mcircleIcon = 4017; }
					AddButton(105+r, 150, mcircleIcon, mcircleIcon, 31, GumpButtonType.Reply, 0);
					AddHtml( 185+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Conjuration</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(144+r, 143, Int32.Parse( Research.SpellInformation( 1, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 32 ){ mcircleIcon = 4017; }
					AddButton(298+r, 150, mcircleIcon, mcircleIcon, 32, GumpButtonType.Reply, 0);
					AddHtml( 378+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Death</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(337+r, 143, Int32.Parse( Research.SpellInformation( 2, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 33 ){ mcircleIcon = 4017; }
					AddButton(506+r, 150, mcircleIcon, mcircleIcon, 33, GumpButtonType.Reply, 0);
					AddHtml( 586+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Enchanting</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(545+r, 143, Int32.Parse( Research.SpellInformation( 3, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 34 ){ mcircleIcon = 4017; }
					AddButton(704+r, 150, mcircleIcon, mcircleIcon, 34, GumpButtonType.Reply, 0);
					AddHtml( 784+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Sorcery</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(743+r, 143, Int32.Parse( Research.SpellInformation( 4, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 35 ){ mcircleIcon = 4017; }
					AddButton(105+r, 190, mcircleIcon, mcircleIcon, 35, GumpButtonType.Reply, 0);
					AddHtml( 185+r, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Summoning</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(144+r, 183, Int32.Parse( Research.SpellInformation( 5, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 36 ){ mcircleIcon = 4017; }
					AddButton(298+r, 190, mcircleIcon, mcircleIcon, 36, GumpButtonType.Reply, 0);
					AddHtml( 378+r, 190, 95, 20, @"<BODY><BASEFONT Color=" + color + ">Thaumaturgy</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(337+r, 183, Int32.Parse( Research.SpellInformation( 6, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 37 ){ mcircleIcon = 4017; }
					AddButton(506+r, 190, mcircleIcon, mcircleIcon, 37, GumpButtonType.Reply, 0);
					AddHtml( 586+r, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Theurgy</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(545+r, 183, Int32.Parse( Research.SpellInformation( 7, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 38 ){ mcircleIcon = 4017; }
					AddButton(704+r, 190, mcircleIcon, mcircleIcon, 38, GumpButtonType.Reply, 0);
					AddHtml( 784+r, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Wizardry</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(743+r, 183, Int32.Parse( Research.SpellInformation( 8, 10 ) ) );

					string spellCircle = "conjuration";
					int spellName = 1;
						if ( m_Page == 32 ){ spellName = 2; spellCircle = "death"; }
						else if ( m_Page == 33 ){ spellName = 3; spellCircle = "enchanting"; }
						else if ( m_Page == 34 ){ spellName = 4; spellCircle = "sorcery"; }
						else if ( m_Page == 35 ){ spellName = 5; spellCircle = "summoning"; }
						else if ( m_Page == 36 ){ spellName = 6; spellCircle = "thaumaturgy"; }
						else if ( m_Page == 37 ){ spellName = 7; spellCircle = "theurgy"; }
						else if ( m_Page == 38 ){ spellName = 8; spellCircle = "wizardry"; }

					int BookIcon = Int32.Parse( Research.SpellInformation( spellName, 9 ) );

					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(115+r, 340, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+r, 340, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+r, 340, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(115+r, 390, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+r, 390, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+r, 390, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(115+r, 440, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+r, 440, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+r, 440, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(115+r, 490, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 195+r, 490, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(155+r, 490, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(670+r, 340, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+r, 340, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+r, 340, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(670+r, 390, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+r, 390, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+r, 390, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(670+r, 440, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+r, 440, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+r, 440, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						AddButton(670+r, 490, 4005, 4005, 600+spellName, GumpButtonType.Reply, 0);
						AddHtml( 750+r, 490, 176, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddButton(710+r, 490, 4011, 4011, 500+spellName, GumpButtonType.Reply, 0);
					} spellName+=8;

					string msg = "You have researched all of the ancient " + spellCircle + " magic.";
					string nextSpell = Research.NextResearch( bag );

					if ( bag.BagMessage > 0 )
					{
						msg = bag.BagMsgString;
					}
					else if ( nextSpell != "" )
					{
						msg = "To learn the magic of " + nextSpell + " you need to find " + bag.ResearchItem + " at " + bag.ResearchLocation + " in " + bag.ResearchWorld + ".";
					}

					AddHtml( 111+r, 278, 760, 45, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddButton(777, 10, 3610, 3610, 15, GumpButtonType.Reply, 0); // HELP BUTTON
				}
				if ( m_Page == 6 || ( m_Page > 40 && m_Page < 50 ) ) // ANCIENT PREPARED SPELLS ///////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					int r = -28;

					titleTxt = "PREPARED ANCIENT SPELLS";

					int mcircleIcon = 3609; if ( m_Page == 41 || m_Page == 6 ){ mcircleIcon = 4017; }
					AddButton(105+r, 150, mcircleIcon, mcircleIcon, 41, GumpButtonType.Reply, 0);
					AddHtml( 185+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Conjuration</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(144+r, 143, Int32.Parse( Research.SpellInformation( 1, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 42 ){ mcircleIcon = 4017; }
					AddButton(298+r, 150, mcircleIcon, mcircleIcon, 42, GumpButtonType.Reply, 0);
					AddHtml( 378+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Death</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(337+r, 143, Int32.Parse( Research.SpellInformation( 2, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 43 ){ mcircleIcon = 4017; }
					AddButton(506+r, 150, mcircleIcon, mcircleIcon, 43, GumpButtonType.Reply, 0);
					AddHtml( 586+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Enchanting</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(545+r, 143, Int32.Parse( Research.SpellInformation( 3, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 44 ){ mcircleIcon = 4017; }
					AddButton(704+r, 150, mcircleIcon, mcircleIcon, 44, GumpButtonType.Reply, 0);
					AddHtml( 784+r, 150, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Sorcery</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(743+r, 143, Int32.Parse( Research.SpellInformation( 4, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 45 ){ mcircleIcon = 4017; }
					AddButton(105+r, 190, mcircleIcon, mcircleIcon, 45, GumpButtonType.Reply, 0);
					AddHtml( 185+r, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Summoning</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(144+r, 183, Int32.Parse( Research.SpellInformation( 5, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 46 ){ mcircleIcon = 4017; }
					AddButton(298+r, 190, mcircleIcon, mcircleIcon, 46, GumpButtonType.Reply, 0);
					AddHtml( 378+r, 190, 95, 20, @"<BODY><BASEFONT Color=" + color + ">Thaumaturgy</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(337+r, 183, Int32.Parse( Research.SpellInformation( 6, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 47 ){ mcircleIcon = 4017; }
					AddButton(506+r, 190, mcircleIcon, mcircleIcon, 47, GumpButtonType.Reply, 0);
					AddHtml( 586+r, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Theurgy</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(545+r, 183, Int32.Parse( Research.SpellInformation( 7, 10 ) ) );

					mcircleIcon = 3609; if ( m_Page == 48 ){ mcircleIcon = 4017; }
					AddButton(704+r, 190, mcircleIcon, mcircleIcon, 48, GumpButtonType.Reply, 0);
					AddHtml( 784+r, 190, 85, 20, @"<BODY><BASEFONT Color=" + color + ">Wizardry</BASEFONT></BODY>", (bool)false, (bool)false);
					AddImage(743+r, 183, Int32.Parse( Research.SpellInformation( 8, 10 ) ) );

					string msg = bag.BagMsgString;
					AddHtml( 103+r, 236, 760, 45, @"<BODY><BASEFONT Color=" + color + ">" + msg + "</BASEFONT></BODY>", (bool)false, (bool)false);

					int spellName = 1;
						if ( m_Page == 42 ){ spellName = 2; }
						else if ( m_Page == 43 ){ spellName = 3; }
						else if ( m_Page == 44 ){ spellName = 4; }
						else if ( m_Page == 45 ){ spellName = 5; }
						else if ( m_Page == 46 ){ spellName = 6; }
						else if ( m_Page == 47 ){ spellName = 7; }
						else if ( m_Page == 48 ){ spellName = 8; }

					int BookIcon = Int32.Parse( Research.SpellInformation( spellName, 9 ) );
					int SmallIcon = Int32.Parse( Research.SpellInformation( spellName, 10 ) );
					int IsPrepared = 0;
					string PrepareColor = "#F25A5A";

					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(120+r, 305, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(170+r, 315, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(210+r, 315, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 120+r, 275, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 250+r, 315, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(120+r, 395, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(170+r, 405, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(210+r, 405, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 120+r, 365, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 250+r, 405, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(120+r, 485, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(170+r, 495, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(210+r, 495, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 120+r, 455, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 250+r, 495, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(120+r, 575, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(170+r, 585, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(210+r, 585, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 120+r, 545, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 250+r, 585, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;

					int shft = 50+r;

					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(620+shft, 305, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(670+shft, 315, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(710+shft, 315, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 620+shft, 275, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 750+shft, 315, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(620+shft, 395, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(670+shft, 405, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(710+shft, 405, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 620+shft, 365, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 750+shft, 405, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(620+shft, 485, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(670+shft, 495, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(710+shft, 495, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 620+shft, 455, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 750+shft, 495, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;
					if ( Research.GetResearch( bag, spellName ) )
					{
						PrepareColor = "" + color + ""; IsPrepared = Research.GetPrepared( bag, spellName ); if ( IsPrepared > 10 ){ PrepareColor = "#15E650"; } else if (IsPrepared > 0 ){ PrepareColor = "#F25A5A"; }
						AddImage(620+shft, 575, Int32.Parse( Research.SpellInformation( spellName, 11 ) ) );
						AddButton(670+shft, 585, 4011, 4011, 700+spellName, GumpButtonType.Reply, 0);
						AddButton(710+shft, 585, 4014, 4014, 800+spellName, GumpButtonType.Reply, 0);
						AddHtml( 620+shft, 545, 250, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spellName, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
						AddHtml( 750+shft, 585, 60, 20, @"<BODY><BASEFONT Color=" + PrepareColor + ">" + IsPrepared + "</BASEFONT></BODY>", (bool)false, (bool)false);
					} spellName+=8;

					AddButton(777, 10, 3610, 3610, 16, GumpButtonType.Reply, 0); // HELP BUTTON
				}
				else if ( m_Page == 11 ) //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "SPELL RESEARCH";

					AddHtml( 12, 60, 871, 639, @"<BODY><BASEFONT Color=" + color + ">Spell research is something that the most dedicated of wizards pursue. It requires the accumulation of knowledge of those that came before. Mages and Necromancers once practiced this strange magic, that was thought to be lost through the passage of time. No matter the research goal, one would need to find the cubes of power in order to scribe spells. These cubes are also required to cast any spell that was used in ancient times. Once all of the cubes of power are found, the true research can begin.<br><br>Some perform research to write commonly used spells, but cannot find the original scroll that contains the vital information needed to cast it. This research has a scribe searching for the pages of tomes that contain the information to write the spell to parchment. Creating scrolls in this manner require the use of octopus ink, which is scarce since the last octopus was seen centuries ago as the kraken were said to have wiped them out. The more difficult the spell, the more ink that is required to scribe the scroll. Your research will indicate where more octopus ink can be obtained. The better your skills in alchemy, cooking, and tasting the more use you will find from the collected ink. Modern spells can be learned in the areas of magery and necromancy. You can research each area simultaneously if you choose, but each area will require you to learn the magic in a specific order as the learned spell will help the researcher learn more of the next spell until all are discovered.<br><br>The main goal of spell research is for a spell caster to learn the ancient magic that has been long forgotten. This ancient magic consists of 64 different spells in 8 different schools of magic. These spells were once used by mages and necromancers alike, where those that reached the status of archmage benefited the most from the power these spells unleash. The magic cannot be written in books, but can only be scribed to individual scrolls that the caster can then read from. When read, the scroll crumples to dust. If one has attributes of lower reagent use, the scroll may not crumble and can be used again but that is not guaranteed especially for very powerful spells. Spells are cast with those skilled in either magery or necromancy, whichever is higher. The effectiveness of the spells is dependent on the combination of magery, necromancy, spiritualism, and psychology. If you are simply skilled in only a couple of these skills, then the spells will have only an average effect. It is those that pursue all four categories of wizardry that will gain the most benefit. When ancient spells are performed, it helps a researcher practice inscription, magery, necromancy, spiritualism, and psychology at the same time. This is why ancient spell research interests archmages, as they have achieved the level of grandmaster in both areas of magic. Some ancient magic has similarities to spells used today, as is to be expected that some of the knowledge survived the ages. So very few spells will be similar to current magery spells, and even fewer spells that are similar to modern necromancer spells. Although they are similar, the ancient spell usually proves to be much more powerful.<br><br>This bag will hold all of your research, as well as blank scrolls, quills, and octopus ink for a maximum quantity of 500 each. You can drop scribe pens and blank scrolls onto the bag to replenish those materials. Discovered ink will be placed in your bag when found. It will also hold all of the cubes of power as well as any ancient magic you put to parchment. This bag will hold 500 scrolls of each ancient magic spell. The bag is yours and no one else can look inside it or use the magic you researched within it. If you lose the bag, you should find a scribe immediately and give them another 500 gold where maybe you will have your research returned. If not, you will have to begin your research all over again with an empty bag.<br><br>There are a few different ways to cast the ancient magic. The first is within the bag from the prepared spell section. There is an arrow icon next to each spell that can cast it for you. The other is spell bars for much easier convenience, and they can be configured in the main section of this bag and only if you learned at least 1 of the ancient spells. You are able to have 4 different spell bars for ancient magic, and you can customize each in a variety of ways. The last way to cast these spells is by a typed command, which allows you to make macros for spell casting if you want. Each of these commands are listed below:<br><br>[CastAcidElemental<br><br>[CastAerialServant<br><br>[CastAirWalk<br><br>[CastAnimateBones<br><br>[CastAvalanche<br><br>[CastBanishDaemon<br><br>[CastBloodElemental<br><br>[CastCallDestruction<br><br>[CastCauseFear<br><br>[CastCharm<br><br>[CastClone<br><br>[CastConflagration<br><br>[CastConfusionBlast<br><br>[CastConjure<br><br>[CastCreateFire<br><br>[CastCreateGold<br><br>[CastCreateGolem<br><br>[CastDeathSpeak<br><br>[CastDeathVortex<br><br>[CastDevastation<br><br>[CastDivination<br><br>[CastElectricalElemental<br><br>[CastEnchant<br><br>[CastEndureCold<br><br>[CastEndureHeat<br><br>[CastEtherealTravel<br><br>[CastExplosion<br><br>[CastExtinguish<br><br>[CastFadefromSight<br><br>[CastFlameBolt<br><br>[CastFrostField<br><br>[CastFrostStrike<br><br>[CastGasCloud<br><br>[CastGemElemental<br><br>[CastGrantPeace<br><br>[CastHailStorm<br><br>[CastHealingTouch<br><br>[CastIceElemental<br><br>[CastIcicle<br><br>[CastIgnite<br><br>[CastIntervention<br><br>[CastInvokeDevil<br><br>[CastMagicSteed<br><br>[CastMaskofDeath<br><br>[CastMassDeath<br><br>[CastMassMight<br><br>[CastMassSleep<br><br>[CastMeteorShower<br><br>[CastMudElemental<br><br>[CastOpenGround<br><br>[CastPoisonElemental<br><br>[CastRestoration<br><br>[CastRingofFire<br><br>[CastRockFlesh<br><br>[CastSeeTruth<br><br>[CastSleep<br><br>[CastSleepField<br><br>[CastSneak<br><br>[CastSnowBall<br><br>[CastSpawnCreature<br><br>[CastSwarm<br><br>[CastWeedElemental<br><br>[CastWithstandDeath<br><br>[CastWizardEye<br><br><br><br><br><br></BASEFONT></BODY>", (bool)false, (bool)true);
				}
				else if ( m_Page == 12 ) //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "CUBES OF POWER";

					AddHtml( 12, 60, 871, 639, @"<BODY><BASEFONT Color=" + color + ">In order to pursue any type of spell research, you must first collect all of the Cubes of Power. There are 26 cubes in total, and they have been lost throughout the land of Sosaria centuries ago. When you begin your search for the cubes, you will have a clue on where the first cube is rumored to be. Once you find this cube, you will learn the whereabouts to another cube. As you find these cubes, they will appear in your pack. Each cube has a word of power engraved in the top, and you need to use these cubes to scribe the magic to scrolls. Once all of the cubes have been found, you can further your research into areas such as wizardry, necromancy, or the spells that were once used by long dead mages. Search the dungeon that the clue provides, and seek the runic pedestal with the small chest on top. If you search the contents, you may find the cube you seek.<br><br>Every cube you find, you will also receive a souvenir that is a replica of the cube you found. These can be used to decorate your home and display your goals in the realm of spell research. Each cube will have a soft glow to them, and their symbols are carved on the top.</BASEFONT></BODY>", (bool)false, (bool)false);
				}
				else if ( m_Page == 13 ) //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "MAGERY RESEARCH";

					AddHtml( 12, 60, 871, 639, @"<BODY><BASEFONT Color=" + color + ">Magery spell research is done in a linear order from the least difficult spell to the most difficult. As you collect the wisdom of wizards that lived long ago, you will gain additional knowledge to construct the next series of spells in the field of magery. There are 64 magery spells in total, and the wisdom of those that originally created them are lost throught the many lands. When you begin your search for these tomes, you will have a clue on where the first book is rumored to be. Once you find this book, you will learn the whereabouts to another book. As you find these tomes, the information on a particular spell will appear in your bag. Search the dungeon that the clue provides, and seek the runic pedestal with the small chest on top. If you search the contents, you may find the book you seek.<br><br>As you learn these spells, you can begin to scribe them. Each spell listed has a button to attempt to scribe the scroll (arrow button) or a button that displays the information about the spell (scroll button). Look over the information to see what you will need to attempt to scribe the scroll. All scrolls require a certain inscription skill and mana to attempt, but also a blank scroll, quill, and reagents. The more difficult the spell, the more octopus ink you will need to scribe the words onto parchment. You can also attempt to scribe the scroll from the information window by pressing the scroll button. If you fail in your attempt, there is a chance that some of the materials will be lost. Scribes that pursue this type of research are those that cannot find a scroll for a particular spell, so this research aids them toward obtaining the spell.</BASEFONT></BODY>", (bool)false, (bool)false);
				}
				else if ( m_Page == 14 ) //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "NECROMANCY RESEARCH";

					AddHtml( 12, 60, 871, 639, @"<BODY><BASEFONT Color=" + color + ">Necromancy spell research is done in a linear order from the least difficult spell to the most difficult. As you collect the wisdom of necromancers that lived long ago, you will gain additional knowledge to construct the next series of spells in the field of necromancy. There are 17 necromancy spells in total, and the wisdom of those that originally created them are lost throught the many lands. When you begin your search for these tomes, you will have a clue on where the first book is rumored to be. Once you find this book, you will learn the whereabouts to another book. As you find these tomes, the information on a particular spell will appear in your bag. Search the dungeon that the clue provides, and seek the runic pedestal with the small chest on top. If you search the contents, you may find the book you seek.<br><br>As you learn these spells, you can begin to scribe them. Each spell listed has a button to attempt to scribe the scroll (arrow button) or a button that displays the information about the spell (scroll button). Look over the information to see what you will need to attempt to scribe the scroll. All scrolls require a certain inscription skill and mana to attempt, but also a blank scroll, quill, and reagents. The more difficult the spell, the more octopus ink you will need to scribe the words onto parchment. You can also attempt to scribe the scroll from the information window by pressing the scroll button. If you fail in your attempt, there is a chance that some of the materials will be lost. Scribes that pursue this type of research are those that cannot find a scroll for a particular spell, so this research aids them toward obtaining the spell.</BASEFONT></BODY>", (bool)false, (bool)false);
				}
				else if ( m_Page == 15 ) //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "ANCIENT SPELL RESEARCH";

					AddHtml( 12, 60, 871, 639, @"<BODY><BASEFONT Color=" + color + ">Ancient spell research is done in a linear order from the least difficult spell to the most difficult where each school of magic is given a turn in the phases of discovery. This means that you will find the information for the easiest conjuration spell first. You will then need to find the information for the easiest death spell next. When you find the easiest spells for each of the 8 schools of magic, the rotation will begin again for the next least difficult spell for each school. This progression needs to be followed until all 64 spells are learned. The wizards that once used these spells died centuries ago, and the written tomes they possessed was lost throught the many lands. When you begin your search for these tomes, you will have a clue on where the first book is rumored to be. Once you find this book, you will learn the whereabouts to another book. As you find these tomes, the information on a particular spell will appear in your bag. Search the dungeon that the clue provides, and seek the runic pedestal with the small chest on top. If you search the contents, you may find the book you seek.<br><br>As you learn these spells, you can begin to scribe them if you have the skills, mana, and resources to do so. Once scribed, the scroll will remain in your bag until you choose to cast it. As you cast these spells, the scribed scrolls will be depleted. Those enhanced with lower reagent qualities, may be able to keep the scrolls from crumbling to dust upon casting but that is not guaranteed. You can learn more about casting these spells on the main screen's Help section or the prepared spells section. Each spell listed has a button to attempt to scribe the scroll (arrow button) or a button that displays the information about the spell (scroll button). Look over the information to see what you will need to attempt to scribe the scroll. All scrolls require a certain inscription skill and mana to attempt, but also a blank scroll, quill, and reagents. You can also attempt to scribe the scroll from the information window by pressing the scroll button if you choose to only scribe a single scroll. You can also press the other button to scribe as many scrolls as you have reagents, quills, and blank scrolls. When you scribe many at once, you only need the required mana as though you were scribing a single scroll, but the resources multiply toward the total quantity that is to be created. Lower reagent attributes do not work toward reagents needing to scribe these spells. If you fail in your attempt, there is a chance that some of the materials will be lost.<br><br><br><br></BASEFONT></BODY>", (bool)false, (bool)true);
				}
				else if ( m_Page == 16 ) //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				{
					titleTxt = "PREPARED ANCIENT SPELLS";

					AddHtml( 12, 60, 871, 639, @"<BODY><BASEFONT Color=" + color + ">As you learn these spells, you can begin to scribe them if you have the skills, mana, and resources to do so. Once scribed, the scroll will remain in your bag until you choose to cast it. As you cast these spells, the scribed scrolls will be depleted. Those enhanced with lower reagent qualities, may be able to keep the scrolls from crumbling to dust upon casting but that is not guaranteed. To cast a spell from this window, select the arrow button next to the spell icon. Each spell listed has a scroll button that displays the information about the spell. Look over the information to see what you will need to attempt to scribe the scroll. All scrolls require a certain inscription skill and mana to attempt, but also a blank scroll, quill, and reagents. You can attempt to scribe the scroll from the information window by pressing the scroll button if you choose to only scribe a single scroll. You can also press the other button to scribe as many scrolls as you have reagents, quills, and blank scrolls. When you scribe many at once, you only need the required mana as though you were scribing a single scroll, but the resources multiply toward the total quantity that is to be created. Lower reagent attributes do not work toward reagents needing to scribe these spells. If you fail in your attempt, there is a chance that some of the materials will be lost.</BASEFONT></BODY>", (bool)false, (bool)false);
				}

				bag.BagMsgString = "";
				bag.BagMessage = 0;

				AddHtml( 12, 12, 382, 20, @"<BODY><BASEFONT Color=" + color + ">" + titleTxt + "</BASEFONT></BODY>", (bool)false, (bool)false);
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile;

				from.SendSound( 0x55 );
				from.CloseGump( typeof( ResearchGump ) );

				// 1 - 9 : TOP SELECTION MENU
				// 11 - 19 : HELP BUTTONS
				// 21 - 29 : MAGERY CIRCLE CHOICES

				if ( m_Bag.BagPage > 10 && m_Bag.BagPage < 20 )
				{
					m_Bag.BagPage = m_Bag.BagPage-10;
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else if ( info.ButtonID > 0 && info.ButtonID < 100 )
				{
					m_Bag.BagPage = info.ButtonID;
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else if ( info.ButtonID > 300 && info.ButtonID < 400 )
				{
					from.SendGump( new SpellInformation( m_Bag, from, m_Bag.BagPage, (info.ButtonID-300), 0 ) );
				}
				else if ( info.ButtonID > 400 && info.ButtonID < 500 )
				{
					Research.CreateNormalSpell( m_Bag, from, (info.ButtonID-400) );
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else if ( info.ButtonID > 500 && info.ButtonID < 600 )
				{
					from.SendGump( new SpellInformation( m_Bag, from, m_Bag.BagPage, (info.ButtonID-500), 1 ) );
				}
				else if ( info.ButtonID > 600 && info.ButtonID < 700 )
				{
					Research.CreateResearchSpell( m_Bag, from, (info.ButtonID-600) );
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else if ( info.ButtonID > 700 && info.ButtonID < 800 )
				{
					from.SendGump( new SpellInformation( m_Bag, from, m_Bag.BagPage, (info.ButtonID-700), 1 ) );
				}
				else if ( info.ButtonID > 800 && info.ButtonID < 900 )
				{
					Research.CastSpell( from, (info.ButtonID-800) );
				}
				else if ( info.ButtonID > 1200 )
				{
					if ( info.ButtonID == 1201 ){ from.CloseGump( typeof( SetupBarsResearch1 ) ); from.SendGump( new SetupBarsResearch1( from, 1 ) ); }
					else if ( info.ButtonID == 1202 ){ from.CloseGump( typeof( SetupBarsResearch2 ) ); from.SendGump( new SetupBarsResearch2( from, 1 ) ); }
					else if ( info.ButtonID == 1203 ){ from.CloseGump( typeof( SetupBarsResearch3 ) ); from.SendGump( new SetupBarsResearch3( from, 1 ) ); }
					else if ( info.ButtonID == 1204 ){ from.CloseGump( typeof( SetupBarsResearch4 ) ); from.SendGump( new SetupBarsResearch4( from, 1 ) ); }

					else if ( info.ButtonID == 1211 ){ InvokeCommand( "researchtool1", from ); }
					else if ( info.ButtonID == 1212 ){ InvokeCommand( "researchtool2", from ); }
					else if ( info.ButtonID == 1213 ){ InvokeCommand( "researchtool3", from ); }
					else if ( info.ButtonID == 1214 ){ InvokeCommand( "researchtool4", from ); }

					else if ( info.ButtonID == 1221 ){ InvokeCommand( "researchclose1", from ); }
					else if ( info.ButtonID == 1222 ){ InvokeCommand( "researchclose2", from ); }
					else if ( info.ButtonID == 1223 ){ InvokeCommand( "researchclose3", from ); }
					else if ( info.ButtonID == 1224 ){ InvokeCommand( "researchclose4", from ); }

					if ( info.ButtonID > 1204 ){ from.SendGump( new ResearchGump( m_Bag, from ) ); }
				}
			}
		}

		public Mobile BagOwner;
		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Bag_Owner { get{ return BagOwner; } set{ BagOwner = value; } }

		public int BagInk;
		[CommandProperty(AccessLevel.Owner)]
		public int Bag_Ink { get { return BagInk; } set { BagInk = value; InvalidateProperties(); } }

		public int BagScrolls;
		[CommandProperty(AccessLevel.Owner)]
		public int Bag_Scrolls { get { return BagScrolls; } set { BagScrolls = value; InvalidateProperties(); } }

		public int BagQuills;
		[CommandProperty(AccessLevel.Owner)]
		public int Bag_Quills { get { return BagQuills; } set { BagQuills = value; InvalidateProperties(); } }

		public int BagPage;
		[CommandProperty(AccessLevel.Owner)]
		public int Bag_Page { get { return BagPage; } set { BagPage = value; InvalidateProperties(); } }

		public string BagInkLocation;
		[CommandProperty(AccessLevel.Owner)]
		public string Bag_InkLocation { get { return BagInkLocation; } set { BagInkLocation = value; InvalidateProperties(); } }

		public string BagInkWorld;
		[CommandProperty(AccessLevel.Owner)]
		public string Bag_InkWorld { get { return BagInkWorld; } set { BagInkWorld = value; InvalidateProperties(); } }

		public int BagMessage;
		[CommandProperty(AccessLevel.Owner)]
		public int Bag_Message { get { return BagMessage; } set { BagMessage = value; InvalidateProperties(); } }

		public string BagMsgString;
		[CommandProperty(AccessLevel.Owner)]
		public string Bag_MsgString { get { return BagMsgString; } set { BagMsgString = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string SpellsMagery;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_Magery { get { return SpellsMagery; } set { SpellsMagery = value; InvalidateProperties(); } }

		public string SpellsMageLocation;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_MageLocation { get { return SpellsMageLocation; } set { SpellsMageLocation = value; InvalidateProperties(); } }

		public string SpellsMageWorld;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_MageWorld { get { return SpellsMageWorld; } set { SpellsMageWorld = value; InvalidateProperties(); } }

		public string SpellsMageItem;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_MageItem { get { return SpellsMageItem; } set { SpellsMageItem = value; InvalidateProperties(); } }

		public string SpellsNecromancy;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_Necromancy { get { return SpellsNecromancy; } set { SpellsNecromancy = value; InvalidateProperties(); } }

		public string SpellsNecroLocation;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_NecroLocation { get { return SpellsNecroLocation; } set { SpellsNecroLocation = value; InvalidateProperties(); } }

		public string SpellsNecroWorld;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_NecroWorld { get { return SpellsNecroWorld; } set { SpellsNecroWorld = value; InvalidateProperties(); } }

		public string SpellsNecroItem;
		[CommandProperty(AccessLevel.Owner)]
		public string Spells_NecroItem { get { return SpellsNecroItem; } set { SpellsNecroItem = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string RuneFound;
		[CommandProperty(AccessLevel.Owner)]
		public string Rune_Found { get { return RuneFound; } set { RuneFound = value; InvalidateProperties(); } }

		public string RuneLocation;
		[CommandProperty(AccessLevel.Owner)]
		public string Rune_Location { get { return RuneLocation; } set { RuneLocation = value; InvalidateProperties(); } }

		public string RuneWorld;
		[CommandProperty(AccessLevel.Owner)]
		public string Rune_World { get { return RuneWorld; } set { RuneWorld = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string ResearchSpells;
		[CommandProperty(AccessLevel.Owner)]
		public string Research_Spells { get { return ResearchSpells; } set { ResearchSpells = value; InvalidateProperties(); } }

		public string ResearchLocation;
		[CommandProperty(AccessLevel.Owner)]
		public string Research_Location { get { return ResearchLocation; } set { ResearchLocation = value; InvalidateProperties(); } }

		public string ResearchWorld;
		[CommandProperty(AccessLevel.Owner)]
		public string Research_World { get { return ResearchWorld; } set { ResearchWorld = value; InvalidateProperties(); } }

		public string ResearchItem;
		[CommandProperty(AccessLevel.Owner)]
		public string Research_Item { get { return ResearchItem; } set { ResearchItem = value; InvalidateProperties(); } }

		public string ResearchPrep1;
		[CommandProperty(AccessLevel.Owner)]
		public string Research_Prep1 { get { return ResearchPrep1; } set { ResearchPrep1 = value; InvalidateProperties(); } }

		public string ResearchPrep2;
		[CommandProperty(AccessLevel.Owner)]
		public string Research_Prep2 { get { return ResearchPrep2; } set { ResearchPrep2 = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public string BarsCast1;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Bars_Cast1 { get { return BarsCast1; } set { BarsCast1 = value; InvalidateProperties(); } }

		public string BarsCast2;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Bars_Cast2 { get { return BarsCast2; } set { BarsCast2 = value; InvalidateProperties(); } }

		public string BarsCast3;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Bars_Cast3 { get { return BarsCast3; } set { BarsCast3 = value; InvalidateProperties(); } }

		public string BarsCast4;
		[CommandProperty( AccessLevel.GameMaster )]
		public string Bars_Cast4 { get { return BarsCast4; } set { BarsCast4 = value; InvalidateProperties(); } }

		/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		public ResearchBag(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);

            writer.Write( (Mobile)BagOwner );
            writer.Write( BagInk );
            writer.Write( BagScrolls );
            writer.Write( BagQuills );
            writer.Write( BagPage );
            writer.Write( BagInkLocation );
            writer.Write( BagInkWorld );
		    writer.Write( BagMessage );
		    writer.Write( BagMsgString );

            writer.Write( SpellsMagery );
            writer.Write( SpellsMageLocation );
            writer.Write( SpellsMageWorld );
            writer.Write( SpellsMageItem );
            writer.Write( SpellsNecromancy );
            writer.Write( SpellsNecroLocation );
            writer.Write( SpellsNecroWorld );
            writer.Write( SpellsNecroItem );

            writer.Write( RuneFound );
            writer.Write( RuneLocation );
            writer.Write( RuneWorld );

            writer.Write( ResearchSpells );
            writer.Write( ResearchLocation );
            writer.Write( ResearchWorld );
            writer.Write( ResearchItem );
            writer.Write( ResearchPrep1 );
            writer.Write( ResearchPrep2 );

            writer.Write( BarsCast1 );
            writer.Write( BarsCast2 );
            writer.Write( BarsCast3 );
            writer.Write( BarsCast4 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			BagOwner = reader.ReadMobile();
			BagInk = reader.ReadInt();
			BagScrolls = reader.ReadInt();
			BagQuills = reader.ReadInt();
			BagPage = reader.ReadInt();
			BagInkLocation = reader.ReadString();
			BagInkWorld = reader.ReadString();
		    BagMessage = reader.ReadInt();
		    BagMsgString = reader.ReadString();

			SpellsMagery = reader.ReadString();
			SpellsMageLocation = reader.ReadString();
			SpellsMageWorld = reader.ReadString();
			SpellsMageItem = reader.ReadString();
			SpellsNecromancy = reader.ReadString();
			SpellsNecroLocation = reader.ReadString();
			SpellsNecroWorld = reader.ReadString();
			SpellsNecroItem = reader.ReadString();

			RuneFound = reader.ReadString();
			RuneLocation = reader.ReadString();
			RuneWorld = reader.ReadString();

			ResearchSpells = reader.ReadString();
			ResearchLocation = reader.ReadString();
			ResearchWorld = reader.ReadString();
			ResearchItem = reader.ReadString();
			ResearchPrep1 = reader.ReadString();
			ResearchPrep2 = reader.ReadString();

			BarsCast1 = reader.ReadString();
			BarsCast2 = reader.ReadString();
			BarsCast3 = reader.ReadString();
			BarsCast4 = reader.ReadString();
		}

		private class SpellInformation : Gump
		{
			private ResearchBag m_Bag;
			private Mobile m_Scribe;
			private int m_Page;
			private int m_Spell;

			public SpellInformation( ResearchBag bag, Mobile from, int page, int spell, int area ) : base( 50, 50 )
			{
				from.SendSound( 0x55 );
				string color = "#ddbc4b";

				m_Bag = bag;
				m_Scribe = from;
				m_Page = page;
				m_Spell = spell;
				m_Bag.BagPage = m_Page;

				this.Closable=true;
				this.Disposable=true;
				this.Dragable=true;
				this.Resizable=false;

				AddPage(0);
				AddImage(0, 0, 9547, Server.Misc.PlayerSettings.GetGumpHue( from ));
				AddButton(567, 10, 4017, 4017, 0, GumpButtonType.Reply, 0);

				if ( area > 0 )
				{
					AddImage(15, 84, Int32.Parse( Research.SpellInformation( spell, 11 ) ) );

					string cubes = Research.SpellInformation( spell, 4 );
					if ( cubes.Length > 0 )
					{
						string[] cube = cubes.Split(' ');
						int box = 0;
						foreach (string rune in cube)
						{
							box++;

							if ( box == 1 ){ AddImage(68, 88, Research.RuneIndex( rune, 1 ) ); }
							else if ( box == 2 ){ AddImage(109, 88, Research.RuneIndex( rune, 1 ) ); }
							else if ( box == 3 ){ AddImage(150, 88, Research.RuneIndex( rune, 1 ) ); }
							else if ( box == 4 ){ AddImage(191, 88, Research.RuneIndex( rune, 1 ) ); }
						}
					}

					AddImage( 555, 82, Int32.Parse( Research.SpellInformation( spell, 10 ) ) );

					AddHtml( 12, 12, 317, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spell, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 18, 142, 564, 230, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spell, 3 ) + " School of Magic<br><br>" + Research.SpellInformation( spell, 6 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 252, 71, 74, 20, @"<BODY><BASEFONT Color=" + color + ">Mana:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 336, 71, 74, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spell, 7 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 252, 105, 74, 20, @"<BODY><BASEFONT Color=" + color + ">Skill:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 336, 105, 74, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.SpellInformation( spell, 8 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddItem(468, 70, 3827);
					AddHtml( 512, 69, 30, 20, @"<BODY><BASEFONT Color=" + color + ">1</BASEFONT></BODY>", (bool)false, (bool)false);
					AddItem(481, 97, 8273);
					AddHtml( 512, 105, 30, 20, @"<BODY><BASEFONT Color=" + color + ">1</BASEFONT></BODY>", (bool)false, (bool)false);

					string reagents = Research.SpellInformation( spell, 5 );
						if ( reagents.Contains(", ") ){ reagents = reagents.Replace(", ", "<br>"); }

					int g = 45;

					AddHtml( 348, 391+g, 234, 80, @"<BODY><BASEFONT Color=" + color + ">REAGENTS:<BR>" + reagents + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 155, 394+g, 120, 20, @"<BODY><BASEFONT Color=" + color + ">Scribe One</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 155, 440+g, 120, 20, @"<BODY><BASEFONT Color=" + color + ">Scribe Most</BASEFONT></BODY>", (bool)false, (bool)false);

					AddButton(111, 394+g, 4011, 4011, 500+spell, GumpButtonType.Reply, 0);
					AddButton(111, 440+g, 4029, 4029, 600+spell, GumpButtonType.Reply, 0);
					AddImage( 12, 394+g, Int32.Parse( Research.SpellInformation( spell, 9 ) ) );
				}
				else
				{
					AddButton(12, 356, 4011, 4011, spell, GumpButtonType.Reply, 0);
					AddHtml( 55, 356, 160, 20, @"<BODY><BASEFONT Color=" + color + ">Scribe Spell</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtml( 12, 14, 299, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spell, 2 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddItem(306, 17, 3636);
					AddItem(399, 9, 8273);
					AddItem(479, 13, 10282);
					AddHtml( 350, 15, 40, 20, @"<BODY><BASEFONT Color=" + color + ">1</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 433, 15, 40, 20, @"<BODY><BASEFONT Color=" + color + ">1</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 509, 15, 40, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spell, 1 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					AddHtmlLocalized( 12, 64, 578, 282, Int32.Parse( Research.ScrollInformation( spell, 6 ) ), 0x7FFF, false, false );

					AddHtml( 12, 450, 61, 20, @"<BODY><BASEFONT Color=" + color + ">Skill:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 12, 495, 61, 20, @"<BODY><BASEFONT Color=" + color + ">Mana:</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 90, 450, 61, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spell, 5 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);
					AddHtml( 90, 495, 61, 20, @"<BODY><BASEFONT Color=" + color + ">" + Research.ScrollInformation( spell, 4 ) + "</BASEFONT></BODY>", (bool)false, (bool)false);

					string reagents = Research.ScrollInformation( spell, 3 );
						if ( reagents.Contains(", ") ){ reagents = reagents.Replace(", ", "<br>"); }

					AddHtml( 486, 446, 166, 80, @"<BODY><BASEFONT Color=" + color + ">REAGENTS:<BR>" + reagents + "</BASEFONT></BODY>", (bool)false, (bool)false);
				}
			}

			public override void OnResponse( NetState state, RelayInfo info )
			{
				Mobile from = state.Mobile;
				from.SendSound( 0x55 );

				if ( info.ButtonID > 500 && info.ButtonID < 600 )
				{
					Research.CreateResearchSpell( m_Bag, from, info.ButtonID-500 );
					from.CloseGump( typeof( ResearchGump ) );
					from.CloseGump( typeof( SpellInformation ) );
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else if ( info.ButtonID > 600 && info.ButtonID < 700 )
				{
					Research.CreateManySpells( m_Bag, from, info.ButtonID-600 );
					from.CloseGump( typeof( ResearchGump ) );
					from.CloseGump( typeof( SpellInformation ) );
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else if ( info.ButtonID > 0 )
				{
					Research.CreateNormalSpell( m_Bag, from, info.ButtonID );
					from.CloseGump( typeof( ResearchGump ) );
					from.CloseGump( typeof( SpellInformation ) );
					from.SendGump( new ResearchGump( m_Bag, from ) );
				}
				else
				{
					from.CloseGump( typeof( ResearchGump ) );
					from.CloseGump( typeof( SpellInformation ) );
					from.SendGump( new ResearchGump( m_Bag, from ) );

				}
			}
		}
	}
}
