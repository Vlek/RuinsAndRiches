using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Items;

namespace Server.Engines.Harvest
{
	public class Lumberjacking : HarvestSystem
	{
		private static Lumberjacking m_System;

		public static Lumberjacking System
		{
			get
			{
				if ( m_System == null )
					m_System = new Lumberjacking();

				return m_System;
			}
		}

		private HarvestDefinition m_Definition;

		public HarvestDefinition Definition
		{
			get{ return m_Definition; }
		}

		private Lumberjacking()
		{
			HarvestResource[] res;
			HarvestVein[] veins;

			#region Lumberjacking
			HarvestDefinition lumber = new HarvestDefinition();

			// Resource banks are every 4x3 tiles
			lumber.BankWidth = 4;
			lumber.BankHeight = 3;

			// Every bank holds from 20 to 45 logs
			lumber.MinTotal = 20;
			lumber.MaxTotal = 45;

			// A resource bank will respawn its content every 20 to 30 minutes
			lumber.MinRespawn = TimeSpan.FromMinutes( 20.0 );
			lumber.MaxRespawn = TimeSpan.FromMinutes( 30.0 );

			// Skill checking is done on the Lumberjacking skill
			lumber.Skill = SkillName.Lumberjacking;

			// Set the list of harvestable tiles
			lumber.Tiles = m_TreeTiles;

			// Players must be within 2 tiles to harvest
			lumber.MaxRange = 2;

			// Ten logs per harvest action
			lumber.ConsumedPerHarvest = 5 * ( 1 * Server.Misc.MyServerSettings.Resources() );
			lumber.ConsumedPerIslesDreadHarvest = lumber.ConsumedPerHarvest + (int)(lumber.ConsumedPerHarvest/2) + Utility.RandomMinMax(5,10);

			// The chopping effect
			lumber.EffectActions = new int[]{ 13 };
			lumber.EffectSounds = new int[]{ 0x13E };
			lumber.EffectCounts = (Core.AOS ? new int[]{ 1 } : new int[]{ 1, 2, 2, 2, 3 });
			lumber.EffectDelay = TimeSpan.FromSeconds( 1.6 );
			lumber.EffectSoundDelay = TimeSpan.FromSeconds( 0.9 );

			lumber.NoResourcesMessage = 500493; // There's not enough wood here to harvest.
			lumber.FailMessage = 500495; // You hack at the tree for a while, but fail to produce any useable wood.
			lumber.OutOfRangeMessage = 500446; // That is too far away.
			lumber.PackFullMessage = 500720; // You don't have enough room in your backpack!
			lumber.ToolBrokeMessage = 500499; // You broke your axe.

			res = new HarvestResource[]
			{
				new HarvestResource(  00.0, 00.0, 85.0, "", typeof( Log ) ),
				new HarvestResource(  55.0, 25.0, 90.0, "", typeof( AshLog ) ),
				new HarvestResource(  60.0, 30.0, 95.0, "", typeof( CherryLog ) ),
				new HarvestResource(  65.0, 35.0, 100.0, "", typeof( EbonyLog ) ),
				new HarvestResource(  70.0, 40.0, 105.0, "", typeof( GoldenOakLog ) ),
				new HarvestResource(  75.0, 45.0, 110.0, "", typeof( HickoryLog ) ),
				new HarvestResource(  80.0, 50.0, 115.0, "", typeof( MahoganyLog ) ),
				new HarvestResource(  85.0, 55.0, 120.0, "", typeof( OakLog ) ),
				new HarvestResource(  90.0, 65.0, 125.0, "", typeof( PineLog ) ),
				new HarvestResource(  95.0, 75.0, 130.0, "", typeof( RosewoodLog ) ),
				new HarvestResource(  100.0, 85.0, 135.0, "", typeof( WalnutLog ) ),
				new HarvestResource(  100.1, 95.0, 140.0, "", typeof( ElvenLog ) )
			};

			veins = new HarvestVein[]
			{
				new HarvestVein( 30.0, 0.0, res[0], null ),	// Ordinary Logs
				new HarvestVein( 15.0, 0.5, res[1], res[0] ), // Ash
				new HarvestVein( 10.0, 0.5, res[2], res[0] ), // Cherry
				new HarvestVein( 09.0, 0.5, res[3], res[0] ), // Ebony
				new HarvestVein( 08.0, 0.5, res[4], res[0] ), // Golden Oak
				new HarvestVein( 07.0, 0.5, res[5], res[0] ), // Hickory
				new HarvestVein( 06.0, 0.5, res[6], res[0] ), // Mahogany
				new HarvestVein( 05.0, 0.5, res[7], res[0] ), // Oak
				new HarvestVein( 04.0, 0.5, res[8], res[0] ), // Pine
				new HarvestVein( 03.0, 0.5, res[9], res[0] ), // Rosewood
				new HarvestVein( 02.0, 0.5, res[10], res[0] ), // Walnut
				new HarvestVein( 01.0, 0.5, res[11], res[0] ) // Elven
			};

			lumber.BonusResources = new BonusHarvestResource[]
			{
				new BonusHarvestResource( 0, 83.9, null, null ),	//Nothing
				new BonusHarvestResource( 100, 10.0, "wood polish", typeof( OilWood ) ),
				new BonusHarvestResource( 100, 03.0, "reaper oil", typeof( ReaperOil ) ),
				new BonusHarvestResource( 100, 02.0, "mystical tree sap", typeof( MysticalTreeSap ) ),
				new BonusHarvestResource( 100, 01.0, "mushrooms", typeof( HomePlants_Mushroom ) )
			};

			lumber.Resources = res;
			lumber.Veins = veins;

			lumber.RaceBonus = Core.ML;
			lumber.RandomizeVeins = Core.ML;

			m_Definition = lumber;
			Definitions.Add( lumber );
			#endregion
		}

		public override bool CheckHarvest( Mobile from, Item tool )
		{
			if ( !base.CheckHarvest( from, tool ) )
				return false;		

			return true;
		}

		public override HarvestVein MutateVein( Mobile from, Item tool, HarvestDefinition def, HarvestBank bank, object toHarvest, HarvestVein vein )
		{
			if ( tool is LumberAxe )
			{
				int veinIndex = Array.IndexOf( def.Veins, vein );
				return def.Veins[0];
			}

			return base.MutateVein( from, tool, def, bank, toHarvest, vein );
		}

		public override bool CheckHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			if ( !base.CheckHarvest( from, tool, def, toHarvest ) )
				return false;

			if ( tool.Parent != from )
			{
				from.SendLocalizedMessage( 500487 ); // The axe must be equipped for any serious wood chopping.
				return false;
			}

			return true;
		}

		public override void OnBadHarvestTarget( Mobile from, Item tool, object toHarvest )
		{
			if ( toHarvest is Mobile )
			{
				Mobile obj = (Mobile)toHarvest;
				obj.PublicOverheadMessage( Server.Network.MessageType.Regular, 0x3E9, 500450 ); // You can only skin dead creatures.
			}
			else if ( toHarvest is Item )
			{
				Item obj = (Item)toHarvest;
				obj.PublicOverheadMessage( Server.Network.MessageType.Regular, 0x3E9, 500464 ); // Use this on corpses to carve away meat and hide
			}
			else if ( toHarvest is Targeting.StaticTarget || toHarvest is Targeting.LandTarget )
				from.SendLocalizedMessage( 500489 ); // You can't use an axe on that.
			else
				from.SendLocalizedMessage( 1005213 ); // You can't do that
		}

		public override void OnHarvestStarted( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
		{
			base.OnHarvestStarted( from, tool, def, toHarvest );
			
			from.RevealingAction();

			Server.Misc.WearAndTear.OnUsed( tool );
		}

		public static void Initialize()
		{
			Array.Sort( m_TreeTiles );
		}

		#region Tile lists
		private static int[] m_TreeTiles = new int[]
			{
				0x4CCA, 0x4CCB, 0x4CCC, 0x4CCD, 0x4CD0, 0x4CD3, 0x4CD6, 0x4CD8,
				0x4CDA, 0x4CDD, 0x4CE0, 0x4CE3, 0x4CE6, 0x4CF8, 0x4CFB, 0x4CFE,
				0x4D01, 0x4D41, 0x4D42, 0x4D43, 0x4D44, 0x4D57, 0x4D58, 0x4D59,
				0x4D5A, 0x4D5B, 0x4D6E, 0x4D6F, 0x4D70, 0x4D71, 0x4D72, 0x4D84,
				0x4D85, 0x4D86, 0x52B5, 0x52B6, 0x52B7, 0x52B8, 0x52B9, 0x52BA,
				0x52BB, 0x52BC, 0x52BD, 0x4C96,	0x4C95,	0x4CA8,	0x4CAA,	0x4CAB,
				0x4DA0,	0x4CEA,	0x4CE9,	0x4D94,	0x4D98,	0x4D9C,	0x4DA4,	0x4DA8,

				0x6B28, 0x6B29, 0x6B2A, 0x6B2B, 0x6B39, 0x6B3A, 0x6B3B, 0x6B3C, 
				0x6B3F, 0x6B41, 0x6B43, 0x6B46, 0x6B4A, 0x6B4C, 0x6B4E, 0x6B51, 
				0x6B3D, 

				0x4CCE, 0x4CCF, 0x4CD1, 0x4CD2, 0x4CD4, 0x4CD5, 0x4CD7, 0x4CD9,
				0x4CDB, 0x4CDC, 0x4CDE, 0x4CDF, 0x4CE1, 0x4CE2, 0x4CE4, 0x4CE5,
				0x4CE7, 0x4CE8, 0x4CF9, 0x4CFA, 0x4CFC, 0x4CFD, 0x4CFF, 0x4D00,
				0x4D02, 0x4D03, 0x4D45, 0x4D46, 0x4D47, 0x4D48, 0x4D49, 0x4D4A,
				0x4D4B, 0x4D4C, 0x4D4D, 0x4D4E, 0x4D4F, 0x4D50, 0x4D51, 0x4D52,
				0x4D53, 0x4D5C, 0x4D5D, 0x4D5E, 0x4D5F, 0x4D60, 0x4D61, 0x4D62,
				0x4D63, 0x4D64, 0x4D65, 0x4D66, 0x4D67, 0x4D68, 0x4D69, 0x4D73,
				0x4D74, 0x4D75, 0x4D76, 0x4D77, 0x4D78, 0x4D79, 0x4D7A, 0x4D7B,
				0x4D7C, 0x4D7D, 0x4D7E, 0x4D7F, 0x4D87, 0x4D88, 0x4D89, 0x4D8A,
				0x4D8B, 0x4D8C, 0x4D8D, 0x4D8E, 0x4D8F, 0x4D90, 0x4D95, 0x4D96,
				0x4D97, 0x4D99, 0x4D9A, 0x4D9B, 0x4D9D, 0x4D9E, 0x4D9F, 0x4DA1,
				0x4DA2, 0x4DA3, 0x4DA5, 0x4DA6, 0x4DA7, 0x4DA9, 0x4DAA, 0x4DAB,
				0x52BE, 0x52BF, 0x52C0, 0x52C1, 0x52C2, 0x52C3, 0x52C4, 0x52C5,
				0x52C6, 0x52C7, 0x624A, 0x624B, 0x624C, 0x624D,

				0x7B9C,	0x7B9D, 0x7B9E, 0x7B9F
			};
		#endregion
	}
}

namespace Server.Misc
{
    class WearAndTear
    {
		public static void OnUsed( Item tool )
		{
			if ( 50 > Utility.Random( 100 ) && tool is BaseWeapon ) // 50% chance to lower durability
			{
				if ( ((BaseWeapon)tool).WeaponAttributes.SelfRepair > Utility.Random( 10 ) )
				{
					((BaseWeapon)tool).HitPoints += 2;
				}
				else
				{
					int wear = Utility.Random( 2 );

					if ( wear > 0 && ((BaseWeapon)tool).MaxHitPoints > 0 )
					{
						if ( ((BaseWeapon)tool).HitPoints >= wear )
						{
							((BaseWeapon)tool).HitPoints -= wear;
							wear = 0;
						}
						else
						{
							wear -= ((BaseWeapon)tool).HitPoints;
							((BaseWeapon)tool).HitPoints = 0;
						}

						if ( wear > 0 )
						{
							if ( ((BaseWeapon)tool).MaxHitPoints > wear )
							{
								((BaseWeapon)tool).MaxHitPoints -= wear;

								if ( ((BaseWeapon)tool).Parent is Mobile && Utility.RandomMinMax(1,10) == 1 )
									((Mobile)(((BaseWeapon)tool).Parent)).LocalOverheadMessage( MessageType.Regular, 0x3B2, 1061121 ); // Your equipment is severely damaged.
							}
							else
							{
								tool.Delete();
							}
						}
					}
				}
			}
		}
	}
}