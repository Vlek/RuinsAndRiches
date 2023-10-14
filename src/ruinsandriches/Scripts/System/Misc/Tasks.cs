using Server.Accounting;
using Server.Commands.Generic;
using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Spells;
using Server.Targeting;
using Server;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System;

namespace Server.Items
{
public class TaskManager150Min : Item
{
    [Constructable]
    public TaskManager150Min() : base(0x0EDE)
    {
        Movable = false;
        Name    = "Task Manager 150 Min";
        Visible = false;
        TaskTimer thisTimer = new TaskTimer(this);
        thisTimer.Start();
    }

    public TaskManager150Min(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);        // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();

        if (Server.Misc.MyServerSettings.RunRoutinesAtStartup())
        {
            FirstTimer thisTimer = new FirstTimer(this);
            thisTimer.Start();
        }
        else
        {
            TaskTimer thisTimer = new TaskTimer(this);
            thisTimer.Start();
        }
    }

    public class TaskTimer : Timer
    {
        private Item i_item;
        public TaskTimer(Item task) : base(TimeSpan.FromMinutes(150.0))
        {
            Priority = TimerPriority.OneMinute;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(false, i_item);
        }
    }

    public class FirstTimer : Timer
    {
        private Item i_item;
        public FirstTimer(Item task) : base(TimeSpan.FromSeconds(5.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(true, i_item);
        }
    }

    public static void RunThis(bool DoAction, Item item)
    {
        ///// PLANT THE GARDENS //////////////////////////////////////
        Farms.PlantGardens();
        LoggingFunctions.LogServer("Done - Planting Gardens");
        TaskTimer thisTimer = new TaskTimer(item);
        thisTimer.Start();
    }
}
}

namespace Server.Items
{
public class TaskManager200Min : Item
{
    [Constructable]
    public TaskManager200Min() : base(0x0EDE)
    {
        Movable = false;
        Name    = "Task Manager 200 Minutes";
        Visible = false;
        TaskTimer thisTimer = new TaskTimer(this);
        thisTimer.Start();
    }

    public TaskManager200Min(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);        // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();

        if (Server.Misc.MyServerSettings.RunRoutinesAtStartup())
        {
            FirstTimer thisTimer = new FirstTimer(this);
            thisTimer.Start();
        }
        else
        {
            TaskTimer thisTimer = new TaskTimer(this);
            thisTimer.Start();
        }
    }

    public class TaskTimer : Timer
    {
        private Item i_item;
        public TaskTimer(Item task) : base(TimeSpan.FromMinutes(200.0))
        {
            Priority = TimerPriority.OneMinute;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(false, i_item);
        }
    }

    public class FirstTimer : Timer
    {
        private Item i_item;
        public FirstTimer(Item task) : base(TimeSpan.FromSeconds(10.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(true, i_item);
        }
    }

    public static void RunThis(bool DoAction, Item it)
    {
        TaskTimer thisTimer = new TaskTimer(it);
        thisTimer.Start();

        ArrayList spawns = new ArrayList();
        foreach (Item item in World.Items.Values)
        {
            if (item is PremiumSpawner)
            {
                PremiumSpawner spawner = (PremiumSpawner)item;

                if (spawner.SpawnID == 8888)
                {
                    bool reconfigure = true;

                    foreach (NetState state in NetState.Instances)
                    {
                        Mobile m = state.Mobile;

                        if (m is PlayerMobile && m.InRange(spawner.Location, (spawner.HomeRange + 20)))
                        {
                            reconfigure = false;
                        }
                    }

                    if (reconfigure)
                    {
                        spawns.Add(item);
                    }
                }
            }
            else if (item is Coffer)
            {
                Coffer coffer = (Coffer)item;
                Server.Items.Coffer.SetupCoffer(coffer);
            }
            else if (item is HayCrate || item is HollowStump)
            {
                item.Stackable = false;
            }
        }

        for (int i = 0; i < spawns.Count; ++i)
        {
            PremiumSpawner spawners = ( PremiumSpawner )spawns[i];
            Server.Mobiles.PremiumSpawner.Reconfigure(spawners, DoAction);
        }
    }
}
}

namespace Server.Items
{
public class TaskManager250Min : Item
{
    [Constructable]
    public TaskManager250Min() : base(0x0EDE)
    {
        Movable = false;
        Name    = "Task Manager 250 Minutes";
        Visible = false;
        TaskTimer thisTimer = new TaskTimer(this);
        thisTimer.Start();
    }

    public TaskManager250Min(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);        // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();

        if (Server.Misc.MyServerSettings.RunRoutinesAtStartup())
        {
            FirstTimer thisTimer = new FirstTimer(this);
            thisTimer.Start();
        }
        else
        {
            TaskTimer thisTimer = new TaskTimer(this);
            thisTimer.Start();
        }
    }

    public class TaskTimer : Timer
    {
        private Item i_item;
        public TaskTimer(Item task) : base(TimeSpan.FromMinutes(250.0))
        {
            Priority = TimerPriority.OneMinute;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(false, i_item);
        }
    }

    public class FirstTimer : Timer
    {
        private Item i_item;
        public FirstTimer(Item task) : base(TimeSpan.FromSeconds(5.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(true, i_item);
        }
    }

    public static void RunThis(bool DoAction, Item item)
    {
        TaskTimer thisTimer = new TaskTimer(item);
        thisTimer.Start();

        // SWITCH UP THE VENDOR BOOKS
        Server.Items.MerchantsBook.SetupSaleBooks();

        ///// ADD RANDOM CITIZENS IN SETTLEMENTS /////////////////////
        Server.Mobiles.Citizens.PopulateCities();
        Server.Items.TavernTable.PopulateHomes();
        Server.Items.WorkingSpots.PopulateVillages();
    }
}
}

namespace Server.Items
{
public class TaskManagerDaily : Item
{
    [Constructable]
    public TaskManagerDaily() : base(0x0EDE)
    {
        Movable = false;
        Name    = "Task Manager Daily";
        Visible = false;
        TaskTimer thisTimer = new TaskTimer(this);
        thisTimer.Start();
    }

    public TaskManagerDaily(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);        // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();

        if (Server.Misc.MyServerSettings.RunRoutinesAtStartup())
        {
            FirstTimer thisTimer = new FirstTimer(this);
            thisTimer.Start();
        }
        else
        {
            TaskTimer thisTimer = new TaskTimer(this);
            thisTimer.Start();
        }
    }

    public class TaskTimer : Timer
    {
        private Item i_item;
        public TaskTimer(Item task) : base(TimeSpan.FromHours(24.0))
        {
            Priority = TimerPriority.OneMinute;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(i_item);
        }
    }

    public class FirstTimer : Timer
    {
        private Item i_item;
        public FirstTimer(Item task) : base(TimeSpan.FromSeconds(10.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item   = task;
        }

        protected override void OnTick()
        {
            RunThis(i_item);
        }
    }

    public static void RunThis(Item item)
    {
        TaskTimer thisTimer = new TaskTimer(item);
        thisTimer.Start();

        LoggingFunctions.LogServer("Start - Arrange Quest Search Crates");

        ///// MOVE THE SEARCH PEDESTALS //////////////////////////////////////
        BuildQuests.SearchCreate();

        LoggingFunctions.LogServer("Done - Arrange Quest Search Crates");

        LoggingFunctions.LogServer("Start - Change Stealing Pedestals");

        ///// MAKE THE STEAL PEDS LOOK DIFFERENT /////////////////////////////
        BuildPedestals.CreateStealPeds();

        LoggingFunctions.LogServer("Done - Change Stealing Pedestals");

        LoggingFunctions.LogServer("Start - Remove Spread Out Monsters, Drinkers, And Healers");

        ///// CLEANUP THE CREATURES MASS SPREAD OUT IN THE LAND //////////////

        ArrayList targets  = new ArrayList();
        ArrayList healers  = new ArrayList();
        ArrayList exodus   = new ArrayList();
        ArrayList serpent  = new ArrayList();
        ArrayList gargoyle = new ArrayList();
        ArrayList cleanup  = new ArrayList();
        foreach (Mobile creature in World.Mobiles.Values)
        {
            if (creature is CodexGargoyleA || creature is CodexGargoyleB)
            {
                gargoyle.Add(creature);
            }
            else if (creature is BaseCreature && creature.Map == Map.Internal)
            {
                if (((BaseCreature)creature).IsStabled)
                {
                }                                                                 // DO NOTHING
                else if (creature is BaseMount && ((BaseMount)creature).Rider != null)
                {
                }                                                                                                  // DO NOTHING
                else
                {
                    cleanup.Add(creature);
                }
            }
            else if (creature.WhisperHue == 999 || creature.WhisperHue == 911)
            {
                if (creature != null)
                {
                    if (creature is Adventurers || creature is WanderingHealer || creature is Courier || creature is Syth || creature is Jedi)
                    {
                        healers.Add(creature);
                    }
                    else if (creature is Exodus)
                    {
                        exodus.Add(creature);
                    }
                    else if (creature is Jormungandr)
                    {
                        serpent.Add(creature);
                    }
                    else
                    {
                        targets.Add(creature);
                    }
                }
            }
        }
        Server.Multis.BaseBoat.ClearShip();                 // SAFETY CATCH TO CLEAR THE SHIPS OFF THE SEA
        for (int i = 0; i < targets.Count; ++i)
        {
            Mobile creature = ( Mobile )targets[i];
            if (creature.Hidden == false)
            {
                if (creature.WhisperHue == 911)
                {
                    Effects.SendLocationEffect(creature.Location, creature.Map, 0x3400, 60, 0x6E4, 0);
                    Effects.PlaySound(creature.Location, creature.Map, 0x108);
                }
                else
                {
                    creature.PlaySound(0x026);
                    Effects.SendLocationEffect(creature.Location, creature.Map, 0x352D, 16, 4);
                }
            }
            creature.Delete();
        }
        for (int i = 0; i < exodus.Count; ++i)
        {
            Mobile creature = ( Mobile )exodus[i];
            Server.Misc.IntelligentAction.BurnAway(creature);
            Worlds.MoveToRandomDungeon(creature);
            Server.Misc.IntelligentAction.BurnAway(creature);
        }
        for (int i = 0; i < serpent.Count; ++i)
        {
            Mobile creature = ( Mobile )serpent[i];
            creature.PlaySound(0x026);
            Effects.SendLocationEffect(creature.Location, creature.Map, 0x352D, 16, 4);
            Worlds.MoveToRandomOcean(creature);
            creature.PlaySound(0x026);
            Effects.SendLocationEffect(creature.Location, creature.Map, 0x352D, 16, 4);
        }
        for (int i = 0; i < gargoyle.Count; ++i)
        {
            Mobile creature = ( Mobile )gargoyle[i];
            Server.Misc.IntelligentAction.BurnAway(creature);
            Worlds.MoveToRandomDungeon(creature);
            Server.Misc.IntelligentAction.BurnAway(creature);
        }
        for (int i = 0; i < cleanup.Count; ++i)
        {
            Mobile creature = ( Mobile )cleanup[i];
            creature.Delete();
        }
        for (int i = 0; i < healers.Count; ++i)
        {
            Mobile healer = ( Mobile )healers[i];
            if (!(healer is Citizens))
            {
                Effects.SendLocationParticles(EffectItem.Create(healer.Location, healer.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
                healer.PlaySound(0x1FE);
            }
            healer.Delete();
        }

        ArrayList drinkers = new ArrayList();
        foreach (Mobile drunk in World.Mobiles.Values)
        {
            if (drunk is AdventurerWest || drunk is AdventurerSouth || drunk is AdventurerNorth || drunk is AdventurerEast || drunk is TavernPatronWest || drunk is TavernPatronSouth || drunk is TavernPatronNorth || drunk is TavernPatronEast)
            {
                if (drunk != null)
                {
                    drinkers.Add(drunk);
                }
            }
        }
        for (int i = 0; i < drinkers.Count; ++i)
        {
            Mobile drunk = ( Mobile )drinkers[i];
            drunk.Delete();
        }

        LoggingFunctions.LogServer("Done - Remove Spread Out Monsters, Drinkers, And Healers");
    }
}
}

namespace Server.Misc
{
class ServerUpdate
{
    public static void UpdateMaterialColors()
    {
        if (!Directory.Exists("Info"))
        {
            Directory.CreateDirectory("Info");
        }

        if (!File.Exists("Info/colors.set"))
        {
            LoggingFunctions.CreateFile("Info/colors.set");

            ArrayList list = new ArrayList();

            foreach (Item item in World.Items.Values)
            {
                if (IsColorUpdating(item))
                {
                    list.Add(item);
                }
            }
            for (int i = 0; i < list.Count; ++i)
            {
                Server.Misc.MaterialInfo.ConvertMaterial((Item)list[i]);
            }
        }
    }

    public static bool IsColorUpdating(Item item)
    {
        if (item is BaseArmor
            || item is BaseWeapon
            || item is BaseIngot
            || item is BaseGranite
            || item is BaseOre
            || item is BaseHides
            || item is BaseLeather
            || item is BaseLog
            || item is BaseWoodBoard
            || item is Container
            || item is HardScales
            || item is RareMetals
            || item is CaddelliteOre
            || item is TopazIngot
            || item is StarRubyIngot
            || item is SpinelIngot
            || item is SapphireIngot
            || item is RubyIngot
            || item is QuartzIngot
            || item is OnyxIngot
            || item is MarbleIngot
            || item is JadeIngot
            || item is IceIngot
            || item is GarnetIngot
            || item is EmeraldIngot
            || item is CaddelliteIngot
            || item is AmethystIngot
            || item is ShinySilverIngot
            || item is UnicornSkin
            || item is TrollSkin
            || item is SerpentSkin
            || item is NightmareSkin
            || item is DragonSkin
            || item is DemonSkin)
        {
            return true;
        }

        return false;
    }
}
}

namespace Server.Items
{
public class TaskManager : Item
{
    [Constructable]
    public TaskManager() : base(0x0EDE)
    {
        Movable = false;
        Name    = "Task Manager 1 Hour";
        Visible = false;
        TaskTimer thisTimer = new TaskTimer(this);
        thisTimer.Start();
    }

    public TaskManager(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0);        // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();

        if (Server.Misc.MyServerSettings.RunRoutinesAtStartup())
        {
            FirstTimer thisTimer = new FirstTimer(this);
            thisTimer.Start();
        }
        else
        {
            TaskTimer thisTimer = new TaskTimer(this);
            thisTimer.Start();
        }

        ColorTimer colorTimer = new ColorTimer(this);
        colorTimer.Start();
    }

    public class TaskTimer : Timer
    {
        private Item i_item;
        public TaskTimer(Item task) : base(TimeSpan.FromMinutes(60.0))
        {
            Priority = TimerPriority.OneMinute;
            i_item   = task;
        }

        protected override void OnTick()
        {
            TaskTimer thisTimer = new TaskTimer(i_item);
            thisTimer.Start();
            RunThis();
        }
    }

    public class FirstTimer : Timer
    {
        private Item i_item;
        public FirstTimer(Item task) : base(TimeSpan.FromSeconds(1.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item   = task;
        }

        protected override void OnTick()
        {
            TaskTimer thisTimer = new TaskTimer(i_item);
            thisTimer.Start();
            RunThis();
        }
    }

    public class ColorTimer : Timer
    {
        private Item i_item;
        public ColorTimer(Item task) : base(TimeSpan.FromSeconds(30.0))
        {
            Priority = TimerPriority.OneSecond;
            i_item   = task;
        }

        protected override void OnTick()
        {
            Server.Misc.ServerUpdate.UpdateMaterialColors();
        }
    }

    public static void RunThis()
    {
        LoggingFunctions.LogServer("Start - Moving Vendors Back");

        // SWITCH UP THE MAGIC MIRRORS
        Server.Items.MagicMirror.SetMirrors();

        // MOVE SHOPKEEPERS AND GUARDS TO WHERE THEY BELONG...IN CASE THEY MOVED FAR AWAY
        ArrayList vendors   = new ArrayList();
        ArrayList citizens  = new ArrayList();
        ArrayList wanderers = new ArrayList();
        foreach (Mobile vendor in World.Mobiles.Values)
        {
            if (vendor is BaseVendor && vendor.WhisperHue != 911 && vendor.WhisperHue != 999 && !(vendor is PlayerVendor) && !(vendor is PlayerBarkeeper))
            {
                vendors.Add(vendor);
            }
            else if (vendor is TownGuards)
            {
                vendors.Add(vendor);
            }
            else if (vendor is Citizens && vendor.Fame > 0)
            {
                citizens.Add(vendor);
            }
            else if (vendor is BaseCreature && (((BaseCreature)vendor).WhisperHue == 999 || ((BaseCreature)vendor).WhisperHue == 999) && vendor.Location == ((BaseCreature)vendor).Home)
            {
                wanderers.Add(vendor);
            }
        }
        for (int i = 0; i < vendors.Count; ++i)
        {
            Mobile       vendor = ( Mobile )vendors[i];
            BaseCreature vendur = ( BaseCreature )vendors[i];
            vendor.Location = vendur.Home;
        }
        for (int i = 0; i < citizens.Count; ++i)
        {
            Mobile citizen = ( Mobile )citizens[i];
            citizen.Fame = 0;
        }
        for (int i = 0; i < wanderers.Count; ++i)
        {
            Mobile wanderer = ( Mobile )wanderers[i];
            wanderer.Delete();
        }

        LoggingFunctions.LogServer("Done - Moving Vendors Back");

        LoggingFunctions.LogServer("Start - Changing Traps, Altars, And Chests");

        ArrayList targets = new ArrayList();
        foreach (Item item in World.Items.Values)
        {
            if (item is MushroomTrap || item is LandChest || item is StrangePortal || item is WaterChest || item is RavendarkStorm || item is HiddenTrap || item is DungeonChest || item is HiddenChest || item is AltarGodsEast || item is AltarGodsSouth || item is AltarShrineEast || item is AltarShrineSouth || item is AltarStatue || item is AltarSea || item is AltarDryad || item is AltarEvil || item is AltarDaemon)
            {
                if (item != null)
                {
                    targets.Add(item);
                }
            }
        }
        for (int i = 0; i < targets.Count; ++i)
        {
            Item item = ( Item )targets[i];

            if (item is MushroomTrap)
            {
                item.Hue = Utility.RandomList(0x47E, 0x48B, 0x495, 0xB95, 0x5B6, 0x5B7, 0x55F, 0x55C, 0x556, 0x54F, 0x489);

                switch (Utility.RandomMinMax(1, 6))
                {
                    case 1: item.Name = "strange mushroom"; break;
                    case 2: item.Name = "weird mushroom"; break;
                    case 3: item.Name = "odd mushroom"; break;
                    case 4: item.Name = "curious mushroom"; break;
                    case 5: item.Name = "peculiar mushroom"; break;
                    case 6: item.Name = "bizarre mushroom"; break;
                }
            }
            else if (item is AltarGodsEast)
            {
                Item shrine = new AltarGodsEast();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarGodsSouth)
            {
                Item shrine = new AltarGodsSouth();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarShrineEast)
            {
                Item shrine = new AltarShrineEast();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarShrineSouth)
            {
                Item shrine = new AltarShrineSouth();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarStatue)
            {
                Item shrine = new AltarStatue();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarSea)
            {
                Item shrine = new AltarSea();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                if (item.ItemID == 0x4FB1 || item.ItemID == 0x4FB2)
                {
                    shrine.Hue    = 0;
                    shrine.Name   = "Shrine of Poseidon";
                    shrine.ItemID = Utility.RandomList(0x4FB1, 0x4FB2);
                }
                else if (item.ItemID == 0x6395)
                {
                    shrine.Hue    = 0;
                    shrine.Name   = "Shrine of Neptune";
                    shrine.ItemID = 0x6395;
                }
                item.Delete();
            }
            else if (item is AltarEvil)
            {
                Item shrine = new AltarEvil();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarDryad)
            {
                Item shrine = new AltarDryad();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is AltarDaemon)
            {
                Item shrine = new AltarDaemon();
                shrine.Weight  = -2.0;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                if (item.ItemID == 0x6393 || item.ItemID == 0x6394)
                {
                    shrine.Hue    = 0;
                    shrine.Name   = "Shrine of Ktulu";
                    shrine.ItemID = item.ItemID;
                }
                item.Delete();
            }
            else if (item is AltarGargoyle)
            {
                Item shrine = new AltarGargoyle();
                shrine.Weight  = -2.0;
                shrine.ItemID  = item.ItemID;
                shrine.Movable = false;
                shrine.MoveToWorld(new Point3D(item.X, item.Y, item.Z), item.Map);
                item.Delete();
            }
            else if (item is DungeonChest)
            {
                DungeonChest box = (DungeonChest)item;
                if (box.ContainerLockable > 0 && box.ContainerTouched != 1)
                {
                    box.Locked = false;
                    switch (Utility.Random(3))
                    {
                        case 0: box.Locked = true; break;
                    }
                }
                else
                {
                    box.Locked = false;
                }
                if (box.ContainerLevel > 0 && box.ContainerTouched != 1)
                {
                    switch (Utility.Random(9))
                    {
                        case 0: box.TrapType = TrapType.DartTrap; break;
                        case 1: box.TrapType = TrapType.None; break;
                        case 2: box.TrapType = TrapType.ExplosionTrap; break;
                        case 3: box.TrapType = TrapType.MagicTrap; break;
                        case 4: box.TrapType = TrapType.PoisonTrap; break;
                        case 5: box.TrapType = TrapType.None; break;
                        case 6: box.TrapType = TrapType.None; break;
                        case 7: box.TrapType = TrapType.None; break;
                        case 8: box.TrapType = TrapType.None; break;
                    }
                }
            }
            else
            {
                item.Delete();
            }
        }
        LoggingFunctions.LogServer("Done - Changing Traps, Altars, And Chests");
    }
}
}
