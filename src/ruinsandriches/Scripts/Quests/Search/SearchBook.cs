using System;
using Server;
using Server.Network;
using System.Collections;
using Server.Items;
using Server.Misc;
using Server.Gumps;

namespace Server.Items
{
public class SearchBook : Item
{
    public Mobile owner;
    public int LegendLore;

    [CommandProperty(AccessLevel.GameMaster)]
    public Mobile Owner {
        get { return owner; } set { owner = value; }
    }

    [CommandProperty(AccessLevel.Owner)]
    public int Legend_Lore {
        get { return LegendLore; } set { LegendLore = value; InvalidateProperties(); }
    }

    [Constructable]
    public SearchBook(Mobile from, int paid) : base(0x22C5)
    {
        this.owner = from;
        LegendLore = (paid / 1000) - 4;
        Weight     = 1.0;
        Hue        = 0x978;
        Name       = "Artifact Encyclopedia";
    }

    public override void OnDoubleClick(Mobile from)
    {
        if (!IsChildOf(from.Backpack))
        {
            from.SendMessage("This must be in your backpack to read.");
            return;
        }
        else if (this.owner != from)
        {
            from.SendMessage("This is not your book.");
            return;
        }
        else
        {
            from.SendSound(0x55);
            from.CloseGump(typeof(SearchBookGump));
            from.SendGump(new SearchBookGump(from, this, 0));
        }
    }

    public override void AddNameProperties(ObjectPropertyList list)
    {
        base.AddNameProperties(list);
        if (owner != null)
        {
            list.Add(1070722, "Belongs to " + owner.Name + "");
        }

        string sLegend = LegendLore.ToString();
        list.Add(1049644, "Legend Lore: Level " + sLegend + "");
    }

    public class SearchBookGump : Gump
    {
        private SearchBook m_Book;

        public SearchBookGump(Mobile from, SearchBook wikipedia, int page) : base(100, 100)
        {
            m_Book = wikipedia;
            string     color = "#d6c382";
            SearchBook pedia = (SearchBook)wikipedia;

            int     NumberOfArtifacts = 347;                 // SEE LISTING BELOW AND MAKE SURE IT MATCHES THE AMOUNT
            decimal PageCount         = NumberOfArtifacts / 16;
            int     TotalBookPages    = (100000) + ((int)Math.Ceiling(PageCount));

            this.Closable   = true;
            this.Disposable = true;
            this.Dragable   = true;
            this.Resizable  = false;

            AddPage(0);

            AddImage(0, 0, 7005);
            AddImage(0, 0, 7006);
            AddImage(0, 0, 7024, 2736);
            AddButton(590, 48, 4017, 4017, 0, GumpButtonType.Reply, 0);

            int subItem = page * 16;

            int showItem1  = subItem + 1;
            int showItem2  = subItem + 2;
            int showItem3  = subItem + 3;
            int showItem4  = subItem + 4;
            int showItem5  = subItem + 5;
            int showItem6  = subItem + 6;
            int showItem7  = subItem + 7;
            int showItem8  = subItem + 8;
            int showItem9  = subItem + 9;
            int showItem10 = subItem + 10;
            int showItem11 = subItem + 11;
            int showItem12 = subItem + 12;
            int showItem13 = subItem + 13;
            int showItem14 = subItem + 14;
            int showItem15 = subItem + 15;
            int showItem16 = subItem + 16;

            int page_prev = (100000 + page) - 1;
            if (page_prev < 100000)
            {
                page_prev = TotalBookPages;
            }
            int page_next = (100000 + page) + 1;
            if (page_next > TotalBookPages)
            {
                page_next = 100000;
            }

            AddButton(75, 374, 4014, 4014, page_prev, GumpButtonType.Reply, 0);
            AddButton(590, 375, 4005, 4005, page_next, GumpButtonType.Reply, 0);

            AddHtml(77, 49, 259, 20, @"<BODY><BASEFONT Color=" + color + "><CENTER>DEATH MAGIC</CENTER></BASEFONT></BODY>", false, false);

            ///////////////////////////////////////////////////////////////////////////////////

            int x = 115;
            int y = 64;
            int s = 64;
            int z = 34;

            y = y + z;
            if (GetArtifactListForBook(showItem1, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem1, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem2, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem2, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem3, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem3, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem4, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem4, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem5, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem5, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem6, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem6, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem7, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem7, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem8, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem8, GumpButtonType.Reply, 0);
            }
            y = s - 3;
            y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem1, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem2, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem3, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem4, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem5, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem6, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem7, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem8, 1) + "</BASEFONT></BODY>", false, false); y = s - 3;

            ///////////////////////////////////////////////////////////////////////////////////

            x = 407;
            y = s;

            y = y + z;
            if (GetArtifactListForBook(showItem9, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem9, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem10, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem10, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem11, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem11, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem12, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem12, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem13, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem13, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem14, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem14, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem15, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem15, GumpButtonType.Reply, 0);
            }
            y = y + z;
            if (GetArtifactListForBook(showItem16, 1) != "")
            {
                AddButton(x, y, 2447, 2447, showItem16, GumpButtonType.Reply, 0);
            }
            y = s - 3;
            y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem9, 1) + "</BASEFONT></BODY>", false, false); y  = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem10, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem11, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem12, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem13, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem14, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem15, 1) + "</BASEFONT></BODY>", false, false); y = y + z;
            AddHtml(x + 20, y, 155, 20, @"<BODY><BASEFONT Color=" + color + ">" + GetArtifactListForBook(showItem16, 1) + "</BASEFONT></BODY>", false, false); y = s - 3;
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            from.SendSound(0x55);

            if (info.ButtonID >= 100000)
            {
                int page = info.ButtonID - 100000;
                from.SendGump(new SearchBookGump(from, m_Book, page));
            }
            else
            {
                string sType = GetArtifactListForBook(info.ButtonID, 2);
                string sName = GetArtifactListForBook(info.ButtonID, 1);
                if (sName != "")
                {
                    from.AddToBackpack(new SearchPage(from, m_Book.LegendLore, sType, sName));
                    from.SendMessage("You tear the page out of the book.");
                    m_Book.Delete();
                }
            }
        }
    }

    public SearchBook(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)1);                   // version
        writer.Write((Mobile)owner);
        writer.Write(LegendLore);
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
        owner      = reader.ReadMobile();
        LegendLore = reader.ReadInt();
    }

    public static Type GetArtifactType(int artifactIndex)
    {
        Type[] artifacts =
        {
            typeof(Artifact_AbysmalGloves),
            typeof(Artifact_AchillesShield),
            typeof(Artifact_AchillesSpear),
            typeof(Artifact_AcidProofRobe),
            typeof(Artifact_Aegis),
            typeof(Artifact_AegisOfGrace),
            typeof(Artifact_AilricsLongbow),
            typeof(Artifact_AlchemistsBauble),
            typeof(Artifact_SamuraiHelm),
            typeof(Artifact_AngelicEmbrace),
            typeof(Artifact_AngeroftheGods),
            typeof(Artifact_Annihilation),
            typeof(Artifact_ArcaneArms),
            typeof(Artifact_ArcaneCap),
            typeof(Artifact_ArcaneGloves),
            typeof(Artifact_ArcaneGorget),
            typeof(Artifact_ArcaneLeggings),
            typeof(Artifact_ArcaneShield),
            typeof(Artifact_ArcaneTunic),
            typeof(Artifact_ArcanicRobe),
            typeof(Artifact_ArcticDeathDealer),
            typeof(Artifact_ArmorOfFortune),
            typeof(Artifact_ArmorOfInsight),
            typeof(Artifact_ArmorOfNobility),
            typeof(Artifact_ArmsOfAegis),
            typeof(Artifact_ArmsOfFortune),
            typeof(Artifact_ArmsOfInsight),
            typeof(Artifact_ArmsOfNobility),
            typeof(Artifact_ArmsOfTheFallenKing),
            typeof(Artifact_ArmsOfTheHarrower),
            typeof(Artifact_ArmsOfToxicity),
            typeof(Artifact_AuraOfShadows),
            typeof(Artifact_AxeOfTheHeavens),
            typeof(Artifact_AxeoftheMinotaur),
            typeof(Artifact_BeggarsRobe),
            typeof(Artifact_BeltofHercules),
            typeof(Artifact_TheBeserkersMaul),
            typeof(Artifact_BladeDance),
            typeof(Artifact_BladeOfInsanity),
            typeof(Artifact_ConansSword),
            typeof(Artifact_BladeOfTheRighteous),
            typeof(Artifact_ShadowBlade),
            typeof(Artifact_BlazeOfDeath),
            typeof(Artifact_BlightGrippedLongbow),
            typeof(Artifact_BloodwoodSpirit),
            typeof(Artifact_BoneCrusher),
            typeof(Artifact_Bonesmasher),
            typeof(Artifact_BookOfKnowledge),
            typeof(Artifact_Boomstick),
            typeof(Artifact_BootsofHermes),
            typeof(Artifact_BootsofPyros),
            typeof(Artifact_BootsofHydros),
            typeof(Artifact_BootsofLithos),
            typeof(Artifact_BootsofStratos),
            typeof(Artifact_BowOfTheJukaKing),
            typeof(Artifact_BowofthePhoenix),
            typeof(Artifact_BraceletOfHealth),
            typeof(Artifact_BraceletOfTheElements),
            typeof(Artifact_BraceletOfTheVile),
            typeof(Artifact_BrambleCoat),
            typeof(Artifact_BraveKnightOfTheBritannia),
            typeof(Artifact_BreathOfTheDead),
            typeof(Artifact_BurglarsBandana),
            typeof(Artifact_Calm),
            typeof(Artifact_CandleCold),
            typeof(Artifact_CandleEnergy),
            typeof(Artifact_CandleFire),
            typeof(Artifact_CandleNecromancer),
            typeof(Artifact_CandlePoison),
            typeof(Artifact_CandleWizard),
            typeof(Artifact_CapOfFortune),
            typeof(Artifact_CapOfTheFallenKing),
            typeof(Artifact_CaptainJohnsHat),
            typeof(Artifact_CaptainQuacklebushsCutlass),
            typeof(Artifact_CavortingClub),
            typeof(Artifact_CircletOfTheSorceress),
            typeof(Artifact_GrayMouserCloak),
            typeof(Artifact_CoifOfBane),
            typeof(Artifact_CoifOfFire),
            typeof(Artifact_ColdBlood),
            typeof(Artifact_ColdForgedBlade),
            typeof(Artifact_CrimsonCincture),
            typeof(Artifact_CrownOfTalKeesh),
            typeof(Artifact_DaggerOfVenom),
            typeof(Artifact_DarkGuardiansChest),
            typeof(Artifact_DarkLordsPitchfork),
            typeof(Artifact_DarkNeck),
            typeof(Artifact_DetectiveBoots),
            typeof(Artifact_DivineArms),
            typeof(Artifact_DivineCountenance),
            typeof(Artifact_DivineGloves),
            typeof(Artifact_DivineGorget),
            typeof(Artifact_DivineLeggings),
            typeof(Artifact_DivineTunic),
            typeof(Artifact_DjinnisRing),
            typeof(Artifact_DreadPirateHat),
            typeof(Artifact_TheDryadBow),
            typeof(Artifact_DupresCollar),
            typeof(Artifact_DupresShield),
            typeof(Artifact_EarringsOfHealth),
            typeof(Artifact_EarringsOfTheElements),
            typeof(Artifact_EarringsOfTheMagician),
            typeof(Artifact_EarringsOfTheVile),
            typeof(Artifact_EmbroideredOakLeafCloak),
            typeof(Artifact_EnchantedTitanLegBone),
            typeof(Artifact_EssenceOfBattle),
            typeof(Artifact_EternalFlame),
            typeof(Artifact_EvilMageGloves),
            typeof(Artifact_Excalibur),
            typeof(Artifact_FangOfRactus),
            typeof(Artifact_FesteringWound),
            typeof(Artifact_FeyLeggings),
            typeof(Artifact_FleshRipper),
            typeof(Artifact_Fortifiedarms),
            typeof(Artifact_FortunateBlades),
            typeof(Artifact_Frostbringer),
            typeof(Artifact_FurCapeOfTheSorceress),
            typeof(Artifact_Fury),
            typeof(Artifact_MarbleShield),
            typeof(Artifact_GuantletsOfAnger),
            typeof(Artifact_GauntletsOfNobility),
            typeof(Artifact_GeishasObi),
            typeof(Artifact_GiantBlackjack),
            typeof(Artifact_GladiatorsCollar),
            typeof(Artifact_GlovesOfAegis),
            typeof(Artifact_GlovesOfCorruption),
            typeof(Artifact_GlovesOfDexterity),
            typeof(Artifact_GlovesOfFortune),
            typeof(Artifact_GlovesOfInsight),
            typeof(Artifact_GlovesOfRegeneration),
            typeof(Artifact_GlovesOfTheFallenKing),
            typeof(Artifact_GlovesOfTheHarrower),
            typeof(Artifact_GlovesOfThePugilist),
            typeof(Artifact_SamaritanRobe),
            typeof(Artifact_GorgetOfAegis),
            typeof(Artifact_GorgetOfFortune),
            typeof(Artifact_GorgetOfInsight),
            typeof(Artifact_GrimReapersLantern),
            typeof(Artifact_GrimReapersMask),
            typeof(Artifact_GrimReapersRobe),
            typeof(Artifact_GrimReapersScythe),
            typeof(Artifact_PyrosGrimoire),
            typeof(Artifact_TownGuardsHalberd),
            typeof(GwennosHarp),
            typeof(Artifact_HammerofThor),
            typeof(Artifact_HatOfTheMagi),
            typeof(Artifact_HeartOfTheLion),
            typeof(Artifact_HellForgedArms),
            typeof(Artifact_HelmOfAegis),
            typeof(Artifact_HelmOfBrilliance),
            typeof(Artifact_HelmOfInsight),
            typeof(Artifact_HelmOfSwiftness),
            typeof(Artifact_ConansHelm),
            typeof(Artifact_HolyKnightsArmPlates),
            typeof(Artifact_HolyKnightsBreastplate),
            typeof(Artifact_HolyKnightsGloves),
            typeof(Artifact_HolyKnightsGorget),
            typeof(Artifact_HolyKnightsLegging),
            typeof(Artifact_HolyKnightsPlateHelm),
            typeof(Artifact_LunaLance),
            typeof(Artifact_HolySword),
            typeof(Artifact_HoodedShroudOfShadows),
            typeof(HornOfKingTriton),
            typeof(Artifact_HuntersArms),
            typeof(Artifact_HuntersGloves),
            typeof(Artifact_HuntersGorget),
            typeof(Artifact_HuntersHeaddress),
            typeof(Artifact_HuntersLeggings),
            typeof(Artifact_HuntersTunic),
            typeof(Artifact_Indecency),
            typeof(Artifact_InquisitorsArms),
            typeof(Artifact_InquisitorsGorget),
            typeof(Artifact_InquisitorsHelm),
            typeof(Artifact_InquisitorsLeggings),
            typeof(Artifact_InquisitorsResolution),
            typeof(Artifact_InquisitorsTunic),
            typeof(IolosLute),
            typeof(Artifact_IronwoodCrown),
            typeof(Artifact_JackalsArms),
            typeof(Artifact_JackalsCollar),
            typeof(Artifact_JackalsGloves),
            typeof(Artifact_JackalsHelm),
            typeof(Artifact_JackalsLeggings),
            typeof(Artifact_JackalsTunic),
            typeof(Artifact_JadeScimitar),
            typeof(Artifact_JesterHatofChuckles),
            typeof(Artifact_JinBaoriOfGoodFortune),
            typeof(Artifact_KamiNarisIndestructableDoubleAxe),
            typeof(Artifact_KodiakBearMask),
            typeof(Artifact_PowerSurge),
            typeof(Artifact_LegacyOfTheDreadLord),
            typeof(Artifact_LegsOfFortune),
            typeof(Artifact_LegsOfInsight),
            typeof(Artifact_LeggingsOfAegis),
            typeof(Artifact_LeggingsOfBane),
            typeof(Artifact_LeggingsOfDeceit),
            typeof(Artifact_LeggingsOfEnlightenment),
            typeof(Artifact_LeggingsOfFire),
            typeof(Artifact_LegsOfTheFallenKing),
            typeof(Artifact_LegsOfTheHarrower),
            typeof(Artifact_LegsOfNobility),
            typeof(Artifact_HydrosLexicon),
            typeof(Artifact_ConansLoinCloth),
            typeof(Artifact_LongShot),
            typeof(Artifact_LuckyEarrings),
            typeof(Artifact_LuckyNecklace),
            typeof(Artifact_LuminousRuneBlade),
            typeof(Artifact_MadmansHatchet),
            typeof(Artifact_MagesBand),
            typeof(Artifact_MagiciansIllusion),
            typeof(Artifact_MagiciansMempo),
            typeof(Artifact_MantleofPyros),
            typeof(Artifact_MantleofHydros),
            typeof(Artifact_MantleofLithos),
            typeof(Artifact_MantleofStratos),
            typeof(Artifact_StratosManual),
            typeof(Artifact_DeathsMask),
            typeof(Artifact_MauloftheBeast),
            typeof(Artifact_MaulOfTheTitans),
            typeof(Artifact_MelisandesCorrodedHatchet),
            typeof(Artifact_GandalfsHat),
            typeof(Artifact_GandalfsRobe),
            typeof(Artifact_GandalfsStaff),
            typeof(Artifact_MidnightBracers),
            typeof(Artifact_MidnightGloves),
            typeof(Artifact_MidnightHelm),
            typeof(Artifact_MidnightLegs),
            typeof(Artifact_MidnightTunic),
            typeof(Artifact_MinersPickaxe),
            typeof(Artifact_ANecromancerShroud),
            typeof(Artifact_TheNightReaper),
            typeof(Artifact_NightsKiss),
            typeof(Artifact_NordicVikingSword),
            typeof(Artifact_VampiresRobe),
            typeof(Artifact_NoxBow),
            typeof(Artifact_NoxNightlight),
            typeof(Artifact_NoxRangersHeavyCrossbow),
            typeof(Artifact_OblivionsNeedle),
            typeof(Artifact_OrcChieftainHelm),
            typeof(Artifact_OrcishVisage),
            typeof(Artifact_OrnamentOfTheMagician),
            typeof(Artifact_OrnateCrownOfTheHarrower),
            typeof(Artifact_OssianGrimoire),
            typeof(Artifact_OverseerSunderedBlade),
            typeof(Artifact_Pacify),
            typeof(Artifact_PadsOfTheCuSidhe),
            typeof(Artifact_PendantOfTheMagi),
            typeof(Artifact_Pestilence),
            typeof(Artifact_PhantomStaff),
            typeof(Artifact_PixieSwatter),
            typeof(Artifact_PolarBearBoots),
            typeof(Artifact_PolarBearCape),
            typeof(Artifact_Quell),
            typeof(QuiverOfBlight),
            typeof(QuiverOfFire),
            typeof(QuiverOfIce),
            typeof(QuiverOfInfinity),
            typeof(QuiverOfLightning),
            typeof(QuiverOfRage),
            typeof(QuiverOfElements),
            typeof(Artifact_RaedsGlory),
            typeof(Artifact_RamusNecromanticScalpel),
            typeof(Artifact_ResilientBracer),
            typeof(Artifact_Retort),
            typeof(Artifact_RighteousAnger),
            typeof(Artifact_RingOfHealth),
            typeof(Artifact_RingOfProtection),
            typeof(Artifact_RingOfTheElements),
            typeof(Artifact_RingOfTheMagician),
            typeof(Artifact_RingOfTheVile),
            typeof(Artifact_TheRobeOfBritanniaAri),
            typeof(Artifact_RobeOfTeleportation),
            typeof(Artifact_RobeofPyros),
            typeof(Artifact_RobeOfTheEclipse),
            typeof(Artifact_RobeOfTheEquinox),
            typeof(Artifact_RobeofHydros),
            typeof(Artifact_RobeofLithos),
            typeof(Artifact_RobeofStratos),
            typeof(Artifact_RobeOfTreason),
            typeof(Artifact_RobinHoodsBow),
            typeof(Artifact_RobinHoodsFeatheredHat),
            typeof(Artifact_RodOfResurrection),
            typeof(Artifact_RoyalArchersBow),
            typeof(Artifact_LieutenantOfTheBritannianRoyalGuard),
            typeof(Artifact_RoyalGuardSurvivalKnife),
            typeof(Artifact_RoyalGuardsGorget),
            typeof(Artifact_RoyalGuardsChestplate),
            typeof(Artifact_LeggingsOfEmbers),
            typeof(Artifact_RuneCarvingKnife),
            typeof(Artifact_FalseGodsScepter),
            typeof(Artifact_SerpentsFang),
            typeof(Artifact_ShadowDancerArms),
            typeof(Artifact_ShadowDancerCap),
            typeof(Artifact_ShadowDancerGloves),
            typeof(Artifact_ShadowDancerGorget),
            typeof(Artifact_ShadowDancerLeggings),
            typeof(Artifact_ShadowDancerTunic),
            typeof(Artifact_ShaMontorrossbow),
            typeof(Artifact_ShardThrasher),
            typeof(Artifact_ShieldOfInvulnerability),
            typeof(Artifact_ShimmeringTalisman),
            typeof(Artifact_ShroudOfDeciet),
            typeof(Artifact_SilvanisFeywoodBow),
            typeof(Artifact_TheDragonSlayer),
            typeof(Artifact_SongWovenMantle),
            typeof(Artifact_SoulSeeker),
            typeof(Artifact_SpellWovenBritches),
            typeof(Artifact_PolarBearMask),
            typeof(Artifact_SpiritOfTheTotem),
            typeof(Artifact_SprintersSandals),
            typeof(Artifact_StaffOfPower),
            typeof(Artifact_StaffOfTheMagi),
            typeof(Artifact_StaffofSnakes),
            typeof(Artifact_StitchersMittens),
            typeof(Artifact_Stormbringer),
            typeof(Artifact_Subdue),
            typeof(Artifact_SwiftStrike),
            typeof(Artifact_GlassSword),
            typeof(Artifact_SinbadsSword),
            typeof(Artifact_TalonBite),
            typeof(Artifact_TheTaskmaster),
            typeof(Artifact_TitansHammer),
            typeof(Artifact_LithosTome),
            typeof(Artifact_TorchOfTrapFinding),
            typeof(Artifact_TotemArms),
            typeof(Artifact_TotemGloves),
            typeof(Artifact_TotemGorget),
            typeof(Artifact_TotemLeggings),
            typeof(Artifact_TotemOfVoid),
            typeof(Artifact_TotemTunic),
            typeof(Artifact_TunicOfAegis),
            typeof(Artifact_TunicOfBane),
            typeof(Artifact_TunicOfFire),
            typeof(Artifact_TunicOfTheFallenKing),
            typeof(Artifact_TunicOfTheHarrower),
            typeof(Artifact_BelmontWhip),
            typeof(Artifact_VampiricDaisho),
            typeof(Artifact_VioletCourage),
            typeof(Artifact_VoiceOfTheFallenKing),
            typeof(Artifact_WarriorsClasp),
            typeof(Artifact_WildfireBow),
            typeof(Artifact_Windsong),
            typeof(Artifact_ArcticBeacon),
            typeof(Artifact_WizardsPants),
            typeof(Artifact_WrathOfTheDryad),
            typeof(Artifact_YashimotosHatsuburi),
            typeof(Artifact_ZyronicClaw)
        };

        return artifacts[artifactIndex];
    }
}
}
