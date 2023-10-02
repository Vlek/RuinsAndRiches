using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using System.Text;
using Server;
using Server.Commands;
using Server.Commands.Generic;
using System.IO;
using Server.Mobiles;
using Server.Gumps;
using Server.Accounting;

namespace Server
{
public class Announce
{
    public static void Initialize()
    {
        EventSink.Login        += new LoginEventHandler(World_Login);
        EventSink.Logout       += new LogoutEventHandler(World_Logout);
        EventSink.Disconnected += new DisconnectedEventHandler(World_Leave);
        EventSink.PlayerDeath  += new PlayerDeathEventHandler(OnDeath);
    }

    private static void World_Login(LoginEventArgs args)
    {
        Mobile       m  = args.Mobile;
        PlayerMobile pm = (PlayerMobile)m;
        PlayerMobile z  = (PlayerMobile)m;
        Mobile       s  = args.Mobile;

        if (m.Hue >= 33770)
        {
            m.Hue = m.Hue - 32768;
        }

        m.SetRace();

        if (m.BankBox.FindItemByType(typeof(CharacterDatabase)) != null)
        {
            CharacterDatabase database = (CharacterDatabase)(m.BankBox.FindItemByType(typeof(CharacterDatabase)));

            ArrayList process = new ArrayList();
            foreach (Mobile v in World.Mobiles.Values)
            {
                if (!v.Deleted && v is PlayerMobile)
                {
                    process.Add(v);
                }
            }
            for (int i = 0; i < process.Count; ++i)
            {
                s = ( Mobile )process[i];
                z = (PlayerMobile)s;

                if (s.BankBox.FindItemByType(typeof(CharacterDatabase)) != null)
                {
                    database = (CharacterDatabase)(s.BankBox.FindItemByType(typeof(CharacterDatabase)));

                    z.ArtifactQuestTime     = database.ArtifactQuestTime;
                    z.AssassinQuest         = database.AssassinQuest;
                    z.BardsTaleQuest        = database.BardsTaleQuest;
                    z.CharacterBarbaric     = database.CharacterBarbaric;
                    z.CharacterBegging      = database.CharacterBegging;
                    z.CharacterBoatDoor     = database.CharacterBoatDoor;
                    z.CharacterDiscovered   = database.CharacterDiscovered;
                    z.CharacterElement      = database.CharacterElement;
                    z.CharacterEvil         = database.CharacterEvil;
                    z.CharacterGuilds       = database.CharacterGuilds;
                    z.CharacterKeys         = database.CharacterKeys;
                    z.CharacterLoot         = database.CharacterLoot;
                    z.CharacterMOTD         = database.CharacterMOTD;
                    z.CharacterOriental     = database.CharacterOriental;
                    z.CharacterPublicDoor   = database.CharacterPublicDoor;
                    z.CharacterSheath       = database.CharacterSheath;
                    z.CharacterSkill        = database.CharacterSkill;
                    z.CharacterWanted       = database.CharacterWanted;
                    z.CharacterWepAbNames   = database.CharacterWepAbNames;
                    z.CharMusical           = database.CharMusical;
                    z.ClassicPoisoning      = database.ClassicPoisoning;
                    z.EpicQuestName         = database.EpicQuestName;
                    z.EpicQuestNumber       = database.EpicQuestNumber;
                    z.FishingQuest          = database.FishingQuest;
                    z.GumpHue               = database.GumpHue;
                    z.KilledSpecialMonsters = database.KilledSpecialMonsters;
                    z.MagerySpellHue        = database.MagerySpellHue;
                    z.MessageQuest          = database.MessageQuest;
                    z.MusicPlaylist         = database.MusicPlaylist;
                    z.QuickBar              = database.QuickBar;
                    z.SkillDisplay          = database.SkillDisplay;
                    z.SpellBarsBard1        = database.SpellBarsBard1;
                    z.SpellBarsBard2        = database.SpellBarsBard2;
                    z.SpellBarsDeath1       = database.SpellBarsDeath1;
                    z.SpellBarsDeath2       = database.SpellBarsDeath2;
                    z.SpellBarsElly1        = database.SpellBarsElly1;
                    z.SpellBarsElly2        = database.SpellBarsElly2;
                    z.SpellBarsKnight1      = database.SpellBarsKnight1;
                    z.SpellBarsKnight2      = database.SpellBarsKnight2;
                    z.SpellBarsMage1        = database.SpellBarsMage1;
                    z.SpellBarsMage2        = database.SpellBarsMage2;
                    z.SpellBarsMage3        = database.SpellBarsMage3;
                    z.SpellBarsMage4        = database.SpellBarsMage4;
                    z.SpellBarsMonk1        = database.SpellBarsMonk1;
                    z.SpellBarsMonk2        = database.SpellBarsMonk2;
                    z.SpellBarsNecro1       = database.SpellBarsNecro1;
                    z.SpellBarsNecro2       = database.SpellBarsNecro2;
                    z.SpellBarsPriest1      = database.SpellBarsPriest1;
                    z.SpellBarsPriest2      = database.SpellBarsPriest2;
                    z.SpellBarsWizard1      = database.SpellBarsWizard1;
                    z.SpellBarsWizard2      = database.SpellBarsWizard2;
                    z.SpellBarsWizard3      = database.SpellBarsWizard3;
                    z.StandardQuest         = database.StandardQuest;
                    z.ThiefQuest            = database.ThiefQuest;
                    z.WeaponBarOpen         = database.WeaponBarOpen;

                    database.Delete();
                }
            }
        }

        if (((PlayerMobile)m).GumpHue > 0 && m.RecordSkinColor == 0)
        {
            m.RecordsHair(true);

            // THESE 3 LINES CAN BE REMOVED...MAYBE BY 1-JAN-2022. STORAGE VALUES REPLACED.
            m.RecordHairColor  = ((PlayerMobile)m).WeaponBarOpen;
            m.RecordBeardColor = ((PlayerMobile)m).WeaponBarOpen;
            m.RecordSkinColor  = ((PlayerMobile)m).GumpHue;

            ((PlayerMobile)m).WeaponBarOpen = 1;
            ((PlayerMobile)m).GumpHue       = 1;
        }

        if (m.RecordSkinColor >= 33770)
        {
            m.RecordSkinColor = m.RecordSkinColor - 32768; m.Hue = m.RecordSkinColor;
        }

        m.RecordFeatures(false);

        if (!MyServerSettings.AllowCustomTitles())
        {
            m.Title = null;
        }

        LoggingFunctions.LogAccess(m, "login");

        if (m.Region.GetLogoutDelay(m) == TimeSpan.Zero && !m.Poisoned)
        {
            m.Hits = 1000; m.Stam = 1000; m.Mana = 1000;
        }                                                                                                                                   // FULLY REST UP ON LOGIN

        if (m.FindItemOnLayer(Layer.Shoes) != null)
        {
            Item shoes = m.FindItemOnLayer(Layer.Shoes);
            if (shoes is BootsofHermes || shoes is Artifact_BootsofHermes || shoes is Artifact_SprintersSandals || (shoes is HikingBoots && m.RaceID > 0))
            {
                if (Server.Misc.MyServerSettings.NoMountsInCertainRegions() && Server.Mobiles.AnimalTrainer.IsNoMountRegion(m, Region.Find(m.Location, m.Map)))
                {
                    m.Send(SpeedControl.Disable);
                    shoes.Weight = 5.0;
                    if (!(shoes is HikingBoots))
                    {
                        m.SendMessage("These shoes seem to have their magic diminished here.");
                    }
                }
                else
                {
                    m.Send(SpeedControl.MountSpeed);
                    shoes.Weight = 3.0;
                }
            }
        }

        if (Server.Misc.MyServerSettings.NoMountsInCertainRegions() && Server.Mobiles.AnimalTrainer.IsNoMountRegion(m, Region.Find(m.Location, m.Map)) && !Server.Mobiles.AnimalTrainer.AllowMagicSpeed(m, Region.Find(m.Location, m.Map)))
        {
            m.Send(SpeedControl.Disable);
            Server.Spells.Mystic.WindRunner.RemoveEffect(m);
            Server.Spells.Syth.SythSpeed.RemoveEffect(m);
            Server.Spells.Jedi.Celerity.RemoveEffect(m);
            Server.Spells.Shinobi.CheetahPaws.RemoveEffect(m);
        }
    }

    private static void World_Leave(DisconnectedEventArgs args)
    {
        if (Server.Misc.MyServerSettings.SaveOnCharacterLogout())
        {
            World.Save(true, false);
        }
    }

    private static void World_Logout(LogoutEventArgs args)
    {
        Mobile m = args.Mobile;
        LoggingFunctions.LogAccess(m, "logout");
    }

    public static void OnDeath(PlayerDeathEventArgs args)
    {
        Mobile m = args.Mobile;
        GhostHelper.OnGhostWalking(m);
    }
}
}
