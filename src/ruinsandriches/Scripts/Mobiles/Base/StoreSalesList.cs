using System;
using System.Collections.Generic;
using System.Collections;
using Server.Engines.Apiculture;
using Server.Items;
using Server.Misc;
using Server.Multis;
using Server.Guilds;
using Server.Engines.Mahjong;
using Server.Spells.Elementalism;

namespace Server.Mobiles
{
	public abstract class SBInfo
	{
		public SBInfo()
		{
		}

		public abstract IShopSellInfo SellInfo { get; }

        public abstract List<GenericBuyInfo> BuyInfo { get; }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSHidesMain: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSHidesMain()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo(typeof( Hides ), 6, Utility.Random( 120,950 ), 0x63DB, 0 ) );
					if ( Utility.RandomMinMax(1,17) > 3 ){ Add( new GenericBuyInfo(typeof( HornedHides ), 8, Utility.Random( 100,850 ), 0x63DB, MaterialInfo.GetMaterialColor( "lizard", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 4 ){ Add( new GenericBuyInfo(typeof( BarbedHides ), 10, Utility.Random( 90,800 ), 0x63DB, MaterialInfo.GetMaterialColor( "serpent", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 6 ){ Add( new GenericBuyInfo(typeof( VolcanicHides ), 12, Utility.Random( 70,700 ), 0x63DB, MaterialInfo.GetMaterialColor( "volcanic", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 7 ){ Add( new GenericBuyInfo(typeof( FrozenHides ), 12, Utility.Random( 60,650 ), 0x63DB, MaterialInfo.GetMaterialColor( "frozen", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 8 ){ Add( new GenericBuyInfo(typeof( GoliathHides ), 14, Utility.Random( 50,600 ), 0x63DB, MaterialInfo.GetMaterialColor( "goliath", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 9 ){ Add( new GenericBuyInfo(typeof( DraconicHides ), 14, Utility.Random( 40,550 ), 0x63DB, MaterialInfo.GetMaterialColor( "draconic", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 10 ){ Add( new GenericBuyInfo(typeof( HellishHides ), 16, Utility.Random( 30,500 ), 0x63DB, MaterialInfo.GetMaterialColor( "hellish", "", 0 ) ) ); }
				}
				else
				{
					Add( new GenericBuyInfo( typeof( Hides ), 6, Utility.Random( 10,100 ), 0x1079, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( Hides ), 3 );
					Add( typeof( SpinedHides ), 4 );
					Add( typeof( HornedHides ), 4 );
					Add( typeof( BarbedHides ), 5 );
					Add( typeof( NecroticHides ), 5 );
					Add( typeof( VolcanicHides ), 6 );
					Add( typeof( FrozenHides ), 6 );
					Add( typeof( GoliathHides ), 7 );
					Add( typeof( DraconicHides ), 7 );
					Add( typeof( HellishHides ), 8 );
					Add( typeof( DinosaurHides ), 8 );
					Add( typeof( AlienHides ), 8 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){Add( typeof( Hides ), 3 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( SpinedHides ), 4 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( HornedHides ), 4 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( BarbedHides ), 5 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( NecroticHides ), 5 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( VolcanicHides ), 6 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( FrozenHides ), 6 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( GoliathHides ), 7 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( DraconicHides ), 7 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( HellishHides ), 8 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( DinosaurHides ), 8 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( AlienHides ), 8 ); }
				}
				Add( typeof( Hides ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hides ), 2 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinedHides ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( HornedHides ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( BarbedHides ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( NecroticHides ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( VolcanicHides ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( FrozenHides ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoliathHides ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DraconicHides ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( HellishHides ), 7 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DinosaurHides ), 7 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( AlienHides ), 7 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( UnicornSkin ), 30 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemonSkin ), 40 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DragonSkin ), 50 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( NightmareSkin ), 30 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( SerpentSkin ), 10 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( TrollSkin ), 20 ); }
			}
		}
	}
	public class RSHidesDead: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSHidesDead(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,17) > 5 ){ Add( new GenericBuyInfo(typeof( NecroticHides ), 10, Utility.Random( 80,750 ), 0x63DB, MaterialInfo.GetMaterialColor( "necrotic", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSHidesDino: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSHidesDino(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,17) > 11 ){ Add( new GenericBuyInfo(typeof( DinosaurHides ), 16, Utility.Random( 20,450 ), 0x63DB, MaterialInfo.GetMaterialColor( "dinosaur", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSHidesSea: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSHidesSea(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,17) > 2 ){ Add( new GenericBuyInfo(typeof( SpinedHides ), 8, Utility.Random( 110,900 ), 0x63DB, MaterialInfo.GetMaterialColor( "deep sea", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSHidesUnderworld: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSHidesUnderworld(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() && Utility.RandomBool() )
				{
					if ( Utility.RandomMinMax(1,17) > 12 ){ Add( new GenericBuyInfo(typeof( AlienHides ), 16, Utility.Random( 10,400 ), 0x63DB, MaterialInfo.GetMaterialColor( "alien", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSLeatherMain: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSLeatherMain()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo(typeof( Leather ), 6, Utility.Random( 120,950 ), 0x63DC, 0 ) );
					if ( Utility.RandomMinMax(1,17) > 3 ){ Add( new GenericBuyInfo(typeof( HornedLeather ), 8, Utility.Random( 100,850 ), 0x63DC, MaterialInfo.GetMaterialColor( "lizard", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 4 ){ Add( new GenericBuyInfo(typeof( BarbedLeather ), 10, Utility.Random( 90,800 ), 0x63DC, MaterialInfo.GetMaterialColor( "serpent", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 6 ){ Add( new GenericBuyInfo(typeof( VolcanicLeather ), 12, Utility.Random( 70,700 ), 0x63DC, MaterialInfo.GetMaterialColor( "volcanic", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 7 ){ Add( new GenericBuyInfo(typeof( FrozenLeather ), 12, Utility.Random( 60,650 ), 0x63DC, MaterialInfo.GetMaterialColor( "frozen", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 8 ){ Add( new GenericBuyInfo(typeof( GoliathLeather ), 14, Utility.Random( 50,600 ), 0x63DC, MaterialInfo.GetMaterialColor( "goliath", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 9 ){ Add( new GenericBuyInfo(typeof( DraconicLeather ), 14, Utility.Random( 40,550 ), 0x63DC, MaterialInfo.GetMaterialColor( "draconic", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,17) > 10 ){ Add( new GenericBuyInfo(typeof( HellishLeather ), 16, Utility.Random( 30,500 ), 0x63DC, MaterialInfo.GetMaterialColor( "hellish", "", 0 ) ) ); }
				}
				else
				{
					Add( new GenericBuyInfo( typeof( Leather ), 6, Utility.Random( 10,100 ), 0x1082, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( Leather ), 3 );
					Add( typeof( SpinedLeather ), 4 );
					Add( typeof( HornedLeather ), 4 );
					Add( typeof( BarbedLeather ), 5 );
					Add( typeof( NecroticLeather ), 5 );
					Add( typeof( VolcanicLeather ), 6 );
					Add( typeof( FrozenLeather ), 6 );
					Add( typeof( GoliathLeather ), 7 );
					Add( typeof( DraconicLeather ), 7 );
					Add( typeof( HellishLeather ), 8 );
					Add( typeof( DinosaurLeather ), 8 );
					Add( typeof( AlienLeather ), 8 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){Add( typeof( Leather ), 3 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( SpinedLeather ), 4 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( HornedLeather ), 4 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( BarbedLeather ), 5 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( NecroticLeather ), 5 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( VolcanicLeather ), 6 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( FrozenLeather ), 6 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( GoliathLeather ), 7 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( DraconicLeather ), 7 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( HellishLeather ), 8 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( DinosaurLeather ), 8 ); }
					if ( MyServerSettings.BuyChance() ){Add( typeof( AlienLeather ), 8 ); }
				}
				Add( typeof( Hides ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hides ), 2 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinedHides ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( HornedHides ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( BarbedHides ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( NecroticHides ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( VolcanicHides ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( FrozenHides ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoliathHides ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DraconicHides ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( HellishHides ), 7 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DinosaurHides ), 7 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( AlienHides ), 7 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( UnicornSkin ), 30 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemonSkin ), 40 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DragonSkin ), 50 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( NightmareSkin ), 30 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( SerpentSkin ), 10 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( TrollSkin ), 20 ); }
			}
		}
	}
	public class RSLeatherDead: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLeatherDead(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,17) > 5 ){ Add( new GenericBuyInfo(typeof( NecroticLeather ), 10, Utility.Random( 80,750 ), 0x63DC, MaterialInfo.GetMaterialColor( "necrotic", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSLeatherDino: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLeatherDino(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,17) > 11 ){ Add( new GenericBuyInfo(typeof( DinosaurLeather ), 16, Utility.Random( 20,450 ), 0x63DC, MaterialInfo.GetMaterialColor( "dinosaur", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSLeatherSea: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLeatherSea(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,17) > 2 ){ Add( new GenericBuyInfo(typeof( SpinedLeather ), 8, Utility.Random( 110,900 ), 0x63DC, MaterialInfo.GetMaterialColor( "deep sea", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSLeatherUnderworld: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLeatherUnderworld(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() && Utility.RandomBool() )
				{
					if ( Utility.RandomMinMax(1,17) > 12 ){ Add( new GenericBuyInfo(typeof( AlienLeather ), 16, Utility.Random( 10,400 ), 0x63DC, MaterialInfo.GetMaterialColor( "alien", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSLogsMain: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSLogsMain()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( Log ), 5, Utility.Random( 150,950 ), 0x1BDF, 0 ) );
					if ( Utility.RandomMinMax(1,20) > 2 ){ Add( new GenericBuyInfo( typeof( AshLog ), 6, Utility.Random( 140,900 ), 0x1BDF, MaterialInfo.GetMaterialColor( "ash", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 3 ){ Add( new GenericBuyInfo( typeof( CherryLog ), 6, Utility.Random( 130,850 ), 0x1BDF, MaterialInfo.GetMaterialColor( "cherry", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 4 ){ Add( new GenericBuyInfo( typeof( EbonyLog ), 8, Utility.Random( 120,800 ), 0x1BDF, MaterialInfo.GetMaterialColor( "ebony", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 5 ){ Add( new GenericBuyInfo( typeof( GoldenOakLog ), 8, Utility.Random( 110,750 ), 0x1BDF, MaterialInfo.GetMaterialColor( "golden oak", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 6 ){ Add( new GenericBuyInfo( typeof( HickoryLog ), 10, Utility.Random( 100,700 ), 0x1BDF, MaterialInfo.GetMaterialColor( "hickory", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 7 ){ Add( new GenericBuyInfo( typeof( MahoganyLog ), 10, Utility.Random( 90,650 ), 0x1BDF, MaterialInfo.GetMaterialColor( "mahogany", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 9 ){ Add( new GenericBuyInfo( typeof( OakLog ), 12, Utility.Random( 70,550 ), 0x1BDF, MaterialInfo.GetMaterialColor( "oak", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 10 ){ Add( new GenericBuyInfo( typeof( PineLog ), 12, Utility.Random( 60,500 ), 0x1BDF, MaterialInfo.GetMaterialColor( "pine", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 12 ){ Add( new GenericBuyInfo( typeof( RosewoodLog ), 14, Utility.Random( 40,400 ), 0x1BDF, MaterialInfo.GetMaterialColor( "rosewood", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 13 ){ Add( new GenericBuyInfo( typeof( WalnutLog ), 14, Utility.Random( 30,350 ), 0x1BDF, MaterialInfo.GetMaterialColor( "walnut", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 15 ){ Add( new GenericBuyInfo( typeof( ElvenLog ), 28, Utility.Random( 10,250 ), 0x1BDF, MaterialInfo.GetMaterialColor( "elven", "", 0 ) ) ); }
				}
				else
				{
					Add( new GenericBuyInfo( typeof( Log ), 5, Utility.Random( 10,100 ), 0x1BE0, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( Log ), 2 );
					Add( typeof( AshLog ), 3 );
					Add( typeof( CherryLog ), 3 );
					Add( typeof( EbonyLog ), 4 );
					Add( typeof( GoldenOakLog ), 4 );
					Add( typeof( HickoryLog ), 5 );
					Add( typeof( MahoganyLog ), 5 );
					Add( typeof( DriftwoodLog ), 5 );
					Add( typeof( OakLog ), 6 );
					Add( typeof( PineLog ), 6 );
					Add( typeof( GhostLog ), 6 );
					Add( typeof( RosewoodLog ), 7 );
					Add( typeof( WalnutLog ), 7 );
					Add( typeof( ElvenLog ), 14 );
					Add( typeof( PetrifiedLog ), 8 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( Log ), 2 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( AshLog ), 3 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( CherryLog ), 3 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( EbonyLog ), 4 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GoldenOakLog ), 4 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( HickoryLog ), 5 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( MahoganyLog ), 5 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( DriftwoodLog ), 5 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( OakLog ), 6 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( PineLog ), 6 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GhostLog ), 6 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( RosewoodLog ), 7 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( WalnutLog ), 7 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ElvenLog ), 14 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( PetrifiedLog ), 8 ); }
				}

				if ( MyServerSettings.BuyChance() ){Add( typeof( Log ), 1 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( AshLog ), 2 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( CherryLog ), 2 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( EbonyLog ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenOakLog ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( HickoryLog ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( MahoganyLog ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DriftwoodLog ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( OakLog ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( PineLog ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( GhostLog ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( RosewoodLog ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( WalnutLog ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElvenLog ), 12 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( PetrifiedLog ), 7 ); }
			}
		}
	}
	public class RSLogsGhost: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLogsGhost(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 11 ){ Add( new GenericBuyInfo( typeof( GhostLog ), 12, Utility.Random( 50,450 ), 0x1BDF, MaterialInfo.GetMaterialColor( "ghostwood", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSLogsSea: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLogsSea(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 8 ){ Add( new GenericBuyInfo( typeof( DriftwoodLog ), 10, Utility.Random( 80,600 ), 0x1BDF, MaterialInfo.GetMaterialColor( "driftwood", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSLogsUnderworld: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSLogsUnderworld(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() && Utility.RandomBool() )
				{
					if ( Utility.RandomMinMax(1,20) > 14 ){ Add( new GenericBuyInfo( typeof( PetrifiedLog ), 16, Utility.Random( 20,300 ), 0x1BDF, MaterialInfo.GetMaterialColor( "petrified", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSBoardsMain: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSBoardsMain()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( Board ), 5, Utility.Random( 150,950 ), 0x1BD9, 0 ) );
					if ( Utility.RandomMinMax(1,20) > 2 ){ Add( new GenericBuyInfo( typeof( AshBoard ), 6, Utility.Random( 140,900 ), 0x1BD9, MaterialInfo.GetMaterialColor( "ash", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 3 ){ Add( new GenericBuyInfo( typeof( CherryBoard ), 6, Utility.Random( 130,850 ), 0x1BD9, MaterialInfo.GetMaterialColor( "cherry", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 4 ){ Add( new GenericBuyInfo( typeof( EbonyBoard ), 8, Utility.Random( 120,800 ), 0x1BD9, MaterialInfo.GetMaterialColor( "ebony", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 5 ){ Add( new GenericBuyInfo( typeof( GoldenOakBoard ), 8, Utility.Random( 110,750 ), 0x1BD9, MaterialInfo.GetMaterialColor( "golden oak", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 6 ){ Add( new GenericBuyInfo( typeof( HickoryBoard ), 10, Utility.Random( 100,700 ), 0x1BD9, MaterialInfo.GetMaterialColor( "hickory", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 7 ){ Add( new GenericBuyInfo( typeof( MahoganyBoard ), 10, Utility.Random( 90,650 ), 0x1BD9, MaterialInfo.GetMaterialColor( "mahogany", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 9 ){ Add( new GenericBuyInfo( typeof( OakBoard ), 12, Utility.Random( 70,550 ), 0x1BD9, MaterialInfo.GetMaterialColor( "oak", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 10 ){ Add( new GenericBuyInfo( typeof( PineBoard ), 12, Utility.Random( 60,500 ), 0x1BD9, MaterialInfo.GetMaterialColor( "pine", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 12 ){ Add( new GenericBuyInfo( typeof( RosewoodBoard ), 14, Utility.Random( 40,400 ), 0x1BD9, MaterialInfo.GetMaterialColor( "rosewood", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 13 ){ Add( new GenericBuyInfo( typeof( WalnutBoard ), 14, Utility.Random( 30,350 ), 0x1BD9, MaterialInfo.GetMaterialColor( "walnut", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 15 ){ Add( new GenericBuyInfo( typeof( ElvenBoard ), 28, Utility.Random( 10,250 ), 0x1BD9, MaterialInfo.GetMaterialColor( "elven", "", 0 ) ) ); }
				}
				else
				{
					Add( new GenericBuyInfo( typeof( Board ), 5, Utility.Random( 10,100 ), 0x1BD7, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( Board ), 2 );
					Add( typeof( AshBoard ), 3 );
					Add( typeof( CherryBoard ), 3 );
					Add( typeof( EbonyBoard ), 4 );
					Add( typeof( GoldenOakBoard ), 4 );
					Add( typeof( HickoryBoard ), 5 );
					Add( typeof( MahoganyBoard ), 5 );
					Add( typeof( DriftwoodBoard ), 5 );
					Add( typeof( OakBoard ), 6 );
					Add( typeof( PineBoard ), 6 );
					Add( typeof( GhostBoard ), 6 );
					Add( typeof( RosewoodBoard ), 7 );
					Add( typeof( WalnutBoard ), 7 );
					Add( typeof( ElvenBoard ), 14 );
					Add( typeof( PetrifiedBoard ), 8 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( Board ), 2 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( AshBoard ), 3 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( CherryBoard ), 3 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( EbonyBoard ), 4 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GoldenOakBoard ), 4 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( HickoryBoard ), 5 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( MahoganyBoard ), 5 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( DriftwoodBoard ), 5 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( OakBoard ), 6 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( PineBoard ), 6 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GhostBoard ), 6 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( RosewoodBoard ), 7 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( WalnutBoard ), 7 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ElvenBoard ), 14 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( PetrifiedBoard ), 8 ); }
				}

				if ( MyServerSettings.BuyChance() ){Add( typeof( Log ), 1 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( AshLog ), 2 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( CherryLog ), 2 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( EbonyLog ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenOakLog ), 3 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( HickoryLog ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( MahoganyLog ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( DriftwoodLog ), 4 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( OakLog ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( PineLog ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( GhostLog ), 5 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( RosewoodLog ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( WalnutLog ), 6 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElvenLog ), 12 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( PetrifiedLog ), 7 ); }
			}
		}
	}
	public class RSBoardsGhost: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSBoardsGhost(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 11 ){ Add( new GenericBuyInfo( typeof( GhostBoard ), 12, Utility.Random( 50,450 ), 0x1BD9, MaterialInfo.GetMaterialColor( "ghostwood", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSBoardsSea: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSBoardsSea(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 8 ){ Add( new GenericBuyInfo( typeof( DriftwoodBoard ), 10, Utility.Random( 80,600 ), 0x1BD9, MaterialInfo.GetMaterialColor( "driftwood", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSBoardsUnderworld: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSBoardsUnderworld(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() && Utility.RandomBool() )
				{
					if ( Utility.RandomMinMax(1,20) > 14 ){ Add( new GenericBuyInfo( typeof( PetrifiedBoard ), 16, Utility.Random( 20,300 ), 0x1BD9, MaterialInfo.GetMaterialColor( "petrified", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////

	public class RSOreMain: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSOreMain()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( IronOre ), 5, Utility.Random( 160,950 ), 0x63DA, 0 ) );
					if ( Utility.RandomMinMax(1,20) > 2 ){ Add( new GenericBuyInfo( typeof( DullCopperOre ), 16, Utility.Random( 150,900 ), 0x63DA, MaterialInfo.GetMaterialColor( "dull copper", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 3 ){ Add( new GenericBuyInfo( typeof( ShadowIronOre ), 24, Utility.Random( 140,850 ), 0x63DA, MaterialInfo.GetMaterialColor( "shadow iron", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 4 ){ Add( new GenericBuyInfo( typeof( CopperOre ), 32, Utility.Random( 130,800 ), 0x63DA, MaterialInfo.GetMaterialColor( "copper", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 5 ){ Add( new GenericBuyInfo( typeof( BronzeOre ), 40, Utility.Random( 120,750 ), 0x63DA, MaterialInfo.GetMaterialColor( "bronze", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 6 ){ Add( new GenericBuyInfo( typeof( GoldOre ), 48, Utility.Random( 110,700 ), 0x63DA, MaterialInfo.GetMaterialColor( "gold", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 7 ){ Add( new GenericBuyInfo( typeof( AgapiteOre ), 56, Utility.Random( 100,650 ), 0x63DA, MaterialInfo.GetMaterialColor( "agapite", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 8 ){ Add( new GenericBuyInfo( typeof( VeriteOre ), 64, Utility.Random( 90,600 ), 0x63DA, MaterialInfo.GetMaterialColor( "verite", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 9 ){ Add( new GenericBuyInfo( typeof( ValoriteOre ), 72, Utility.Random( 80,550 ), 0x63DA, MaterialInfo.GetMaterialColor( "valorite", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 16 ){ Add( new GenericBuyInfo( typeof( DwarvenOre ), 192, Utility.Random( 10,200 ), 0x63DA, MaterialInfo.GetMaterialColor( "dwarven", "", 0 ) ) ); }
				}
				else
				{
					Add( new GenericBuyInfo( typeof( IronOre ), 5, Utility.Random( 10,100 ), 0x19B9, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( IronOre ), 2 );
					Add( typeof( DullCopperOre ), 8 );
					Add( typeof( ShadowIronOre ), 12 );
					Add( typeof( CopperOre ), 16 );
					Add( typeof( BronzeOre ), 20 );
					Add( typeof( GoldOre ), 24 );
					Add( typeof( AgapiteOre ), 28 );
					Add( typeof( VeriteOre ), 32 );
					Add( typeof( ValoriteOre ), 36 );
					Add( typeof( NepturiteOre ), 36 );
					Add( typeof( MithrilOre ), 48 );
					Add( typeof( XormiteOre ), 48 );
					Add( typeof( DwarvenOre ), 96 );
					Add( typeof( ObsidianOre ), 36 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( IronOre ), 2 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( DullCopperOre ), 8 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ShadowIronOre ), 12 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( CopperOre ), 16 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( BronzeOre ), 20 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GoldOre ), 24 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( AgapiteOre ), 28 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( VeriteOre ), 32 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ValoriteOre ), 36 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( NepturiteOre ), 36 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( MithrilOre ), 48 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( XormiteOre ), 48 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( DwarvenOre ), 96 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ObsidianOre ), 36 ); }
				}
			}
		}
	}
	public class RSOreSerpentIsland: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSOreSerpentIsland(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 11 ){ Add( new GenericBuyInfo( typeof( ObsidianOre ), 72, Utility.Random( 60,450 ), 0x63DA, MaterialInfo.GetMaterialColor( "obsidian", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSOreSea: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSOreSea(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 10 ){ Add( new GenericBuyInfo( typeof( NepturiteOre ), 72, Utility.Random( 70,500 ), 0x63DA, MaterialInfo.GetMaterialColor( "nepturite", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSOreUnderworld: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSOreUnderworld(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() && Utility.RandomBool() )
				{
					if ( Utility.RandomMinMax(1,20) > 14 ){ Add( new GenericBuyInfo( typeof( MithrilOre ), 96, Utility.Random( 30,300 ), 0x63DA, MaterialInfo.GetMaterialColor( "mithril", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 15 ){ Add( new GenericBuyInfo( typeof( XormiteOre ), 96, Utility.Random( 20,250 ), 0x63DA, MaterialInfo.GetMaterialColor( "xormite", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSIngotsMain: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSIngotsMain()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( IronIngot ), 5, Utility.Random( 160,950 ), 0x1BF1, 0 ) );
					if ( Utility.RandomMinMax(1,20) > 2 ){ Add( new GenericBuyInfo( typeof( DullCopperIngot ), 16, Utility.Random( 150,900 ), 0x1BF1, MaterialInfo.GetMaterialColor( "dull copper", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 3 ){ Add( new GenericBuyInfo( typeof( ShadowIronIngot ), 24, Utility.Random( 140,850 ), 0x1BF1, MaterialInfo.GetMaterialColor( "shadow iron", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 4 ){ Add( new GenericBuyInfo( typeof( CopperIngot ), 32, Utility.Random( 130,800 ), 0x1BF1, MaterialInfo.GetMaterialColor( "copper", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 5 ){ Add( new GenericBuyInfo( typeof( BronzeIngot ), 40, Utility.Random( 120,750 ), 0x1BF1, MaterialInfo.GetMaterialColor( "bronze", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 6 ){ Add( new GenericBuyInfo( typeof( GoldIngot ), 48, Utility.Random( 110,700 ), 0x1BF1, MaterialInfo.GetMaterialColor( "gold", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 7 ){ Add( new GenericBuyInfo( typeof( AgapiteIngot ), 56, Utility.Random( 100,650 ), 0x1BF1, MaterialInfo.GetMaterialColor( "agapite", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 8 ){ Add( new GenericBuyInfo( typeof( VeriteIngot ), 64, Utility.Random( 90,600 ), 0x1BF1, MaterialInfo.GetMaterialColor( "verite", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 9 ){ Add( new GenericBuyInfo( typeof( ValoriteIngot ), 72, Utility.Random( 80,550 ), 0x1BF1, MaterialInfo.GetMaterialColor( "valorite", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 16 ){ Add( new GenericBuyInfo( typeof( DwarvenIngot ), 192, Utility.Random( 10,200 ), 0x1BF1, MaterialInfo.GetMaterialColor( "dwarven", "", 0 ) ) ); }
				}
				else
				{
					Add( new GenericBuyInfo( typeof( IronIngot ), 5, Utility.Random( 10,100 ), 0x1BF2, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( IronIngot ), 2 );
					Add( typeof( TopazIngot ), 120 );
					Add( typeof( ShinySilverIngot ), 120 );
					Add( typeof( AmethystIngot ), 120 );
					Add( typeof( EmeraldIngot ), 120 );
					Add( typeof( GarnetIngot ), 120 );
					Add( typeof( IceIngot ), 120 );
					Add( typeof( JadeIngot ), 120 );
					Add( typeof( MarbleIngot ), 120 );
					Add( typeof( OnyxIngot ), 120 );
					Add( typeof( QuartzIngot ), 120 );
					Add( typeof( RubyIngot ), 120 );
					Add( typeof( SapphireIngot ), 120 );
					Add( typeof( SpinelIngot ), 120 );
					Add( typeof( StarRubyIngot ), 120 );
					Add( typeof( DullCopperIngot ), 8 );
					Add( typeof( ShadowIronIngot ), 12 );
					Add( typeof( CopperIngot ), 16 );
					Add( typeof( BronzeIngot ), 20 );
					Add( typeof( GoldIngot ), 24 );
					Add( typeof( AgapiteIngot ), 28 );
					Add( typeof( VeriteIngot ), 32 );
					Add( typeof( ValoriteIngot ), 36 );
					Add( typeof( NepturiteIngot ), 36 );
					Add( typeof( SteelIngot ), 40 );
					Add( typeof( BrassIngot ), 44 );
					Add( typeof( MithrilIngot ), 48 );
					Add( typeof( XormiteIngot ), 48 );
					Add( typeof( DwarvenIngot ), 96 );
					Add( typeof( ObsidianIngot ), 36 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( IronIngot ), 2 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( TopazIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ShinySilverIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( AmethystIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( EmeraldIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GarnetIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( IceIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( JadeIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( MarbleIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( OnyxIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( QuartzIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( RubyIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( SapphireIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( SpinelIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( StarRubyIngot ), 120 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( DullCopperIngot ), 8 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ShadowIronIngot ), 12 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( CopperIngot ), 16 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( BronzeIngot ), 20 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( GoldIngot ), 24 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( AgapiteIngot ), 28 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( VeriteIngot ), 32 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ValoriteIngot ), 36 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( NepturiteIngot ), 36 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( SteelIngot ), 40 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( BrassIngot ), 44 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( MithrilIngot ), 48 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( XormiteIngot ), 48 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( DwarvenIngot ), 96 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( ObsidianIngot ), 36 ); }
				}
			}
		}
	}
	public class RSIngotsSerpentIsland: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSIngotsSerpentIsland(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 11 ){ Add( new GenericBuyInfo( typeof( ObsidianIngot ), 72, Utility.Random( 60,450 ), 0x1BF1, MaterialInfo.GetMaterialColor( "obsidian", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSIngotsSavagedEmpire: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSIngotsSavagedEmpire(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 12 ){ Add( new GenericBuyInfo( typeof( SteelIngot ), 80, Utility.Random( 50,400 ), 0x1BF1, MaterialInfo.GetMaterialColor( "steel", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSIngotsUmberVeil: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSIngotsUmberVeil(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 13 ){ Add( new GenericBuyInfo( typeof( BrassIngot ), 88, Utility.Random( 40,350 ), 0x1BF1, MaterialInfo.GetMaterialColor( "brass", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSIngotsSea: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSIngotsSea(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					if ( Utility.RandomMinMax(1,20) > 10 ){ Add( new GenericBuyInfo( typeof( NepturiteIngot ), 72, Utility.Random( 70,500 ), 0x1BF1, MaterialInfo.GetMaterialColor( "nepturite", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	public class RSIngotsUnderworld: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();
		public RSIngotsUnderworld(){}
		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }
		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() && Utility.RandomBool() )
				{
					if ( Utility.RandomMinMax(1,20) > 14 ){ Add( new GenericBuyInfo( typeof( MithrilIngot ), 96, Utility.Random( 30,300 ), 0x1BF1, MaterialInfo.GetMaterialColor( "mithril", "", 0 ) ) ); }
					if ( Utility.RandomMinMax(1,20) > 15 ){ Add( new GenericBuyInfo( typeof( XormiteIngot ), 96, Utility.Random( 20,250 ), 0x1BF1, MaterialInfo.GetMaterialColor( "xormite", "", 0 ) ) ); }
				}
			}
		}
		public class InternalSellInfo : GenericSellInfo { public InternalSellInfo(){} }
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSCloth: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSCloth()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( UncutCloth ), 3, Utility.Random( 100,950 ), Utility.RandomList( 0x1761, 0x1762, 0x1763, 0x1764 ), Utility.RandomDyedHue() ) );
					Add( new GenericBuyInfo( typeof( BoltOfCloth ), 100, Utility.Random( 100,950 ), Utility.RandomList( 0xf9B, 0xf9C, 0xf96, 0xf97 ), Utility.RandomDyedHue() ) );
				}
				else
				{
					Add( new GenericBuyInfo( typeof( UncutCloth ), 3, Utility.Random( 4,60 ), Utility.RandomList( 0x1761, 0x1762, 0x1763, 0x1764 ), Utility.RandomDyedHue() ) );
					Add( new GenericBuyInfo( typeof( BoltOfCloth ), 100, Utility.Random( 4,60 ), Utility.RandomList( 0xf9B, 0xf9C, 0xf96, 0xf97 ), Utility.RandomDyedHue() ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( BoltOfCloth ), 50 );
					Add( typeof( UncutCloth ), 1 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( UncutCloth ), 1 ); }
					if ( MyServerSettings.BuyChance() ){ Add( typeof( BoltOfCloth ), 50 ); }
				}
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSBottles: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSBottles()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( Bottle ), 5, Utility.Random( 100,950 ), 0x63DE, 0 ) );
				}
				else
				{
					Add( new GenericBuyInfo( typeof( Bottle ), 5, Utility.Random( 1,15 ), 0xF0E, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( Bottle ), 3 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( Bottle ), 3 ); }
				}
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSJars: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSJars()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( Jar ), 6, Utility.Random( 100,950 ), 0x0E47, 0 ) );
				}
				else
				{
					Add( new GenericBuyInfo( typeof( Jar ), 6, Utility.Random( 1,15 ), 0x10B4, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( Jar ), 3 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( Jar ), 3 ); }
				}
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RSScrolls: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public RSScrolls()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( new GenericBuyInfo( typeof( BlankScroll ), 6, Utility.Random( 100,950 ), 0x63DD, 0 ) );
				}
				else
				{
					Add( new GenericBuyInfo( typeof( BlankScroll ), 6, Utility.Random( 1,15 ), 0x0E34, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.SoldResource() )
				{
					Add( typeof( BlankScroll ), 3 );
				}
				else
				{
					if ( MyServerSettings.BuyChance() ){ Add( typeof( BlankScroll ), 3 ); }
				}
			}
		}
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBPaganReagents: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBPaganReagents()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( SetStock.BuyChance() ){Add( typeof( DecoBlackmoor ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoBloodspawn ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoBrimstone ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoDragonsBlood2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoEyeOfNewt ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGarlic ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGarlic2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGarlicBulb ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGarlicBulb2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGinseng ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGinseng2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGinsengRoot ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoGinsengRoot2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoMandrake ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoMandrake2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoMandrake3 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoMandrakeRoot ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoMandrakeRoot2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoNightshade ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoNightshade2 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoNightshade3 ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoObsidian ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoPumice ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
				if ( SetStock.BuyChance() ){Add( typeof( DecoWyrmsHeart ), Utility.RandomMinMax(50,500) ); } // DO NOT WANT?
			}
		}
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBElfRares: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElfRares()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Futon ), Utility.Random( 1000,5000 ), 1, 0x295C, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArtifactVase ), Utility.Random( 1000,5000 ), 1, 0x0B48, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArtifactLargeVase ), Utility.Random( 1000,5000 ), 1, 0x0B47, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenBookcaseDeed ), Utility.Random( 1000,5000 ), 1, 0x3F22, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenBedDeed ), Utility.Random( 1000,5000 ), 1, 0x3F1E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenArmoireDeed ), Utility.Random( 1000,5000 ), 1, 0x3F21, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StandingBrokenChairDeed ), Utility.Random( 1000,5000 ), 1, 0x3F24, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenVanityDeed ), Utility.Random( 1000,5000 ), 1, 0x3F20, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenFallenChairDeed ), Utility.Random( 1000,5000 ), 1, 0x3F24, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenCoveredChairDeed ), Utility.Random( 1000,5000 ), 1, 0x3F26, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BrokenChestOfDrawersDeed ), Utility.Random( 1000,5000 ), 1, 0x3F23, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TapestryOfSosaria ), Utility.Random( 1000,5000 ), 1, 0x234E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RoseOfMoon ), Utility.Random( 1000,5000 ), 1, 0x234C, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HearthOfHomeFireDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( VanityDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlueDecorativeRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlueFancyRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BluePlainRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BoilingCauldronDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CinnamonFancyRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CurtainsDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FountainDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GoldenDecorativeRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingAxesDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingSwordsDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HouseLadderDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LargeFishingNetDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( PinkFancyRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RedPlainRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ScarecrowDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SmallFishingNetDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TableWithBlueClothDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TableWithOrangeClothDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TableWithPurpleClothDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TableWithRedClothDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( UnmadeBedDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WallBannerDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreeStumpDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecorativeShieldDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MiningCartDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( PottedCactusDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StoneAnkhDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BannerDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Tub ), Utility.Random( 1000,5000 ), 1, 0xe83, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WaterBarrel ), Utility.Random( 1000,5000 ), 1, 0xe77, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ClosedBarrel ), Utility.Random( 1000,5000 ), 1, 0x0FAE, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Bucket ), Utility.Random( 1000,5000 ), 1, 0x14e0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoTray ), Utility.Random( 1000,5000 ), 1, 0x992, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoTray2 ), Utility.Random( 1000,5000 ), 1, 0x991, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoBottlesOfLiquor ), Utility.Random( 1000,5000 ), 1, 0x99E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Checkers ), Utility.Random( 1000,5000 ), 1, 0xE1A, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Chessmen3 ), Utility.Random( 1000,5000 ), 1, 0xE14, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Chessmen2 ), Utility.Random( 1000,5000 ), 1, 0xE12, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Chessmen ), Utility.Random( 1000,5000 ), 1, 0xE13, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( Checkers2 ), Utility.Random( 1000,5000 ), 1, 0xE1B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoHay2 ), Utility.Random( 1000,5000 ), 1, 0xF34, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoBridle2 ), Utility.Random( 1000,5000 ), 1, 0x1375, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoBridle ), Utility.Random( 1000,5000 ), 1, 0x1374, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBChainmailArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBChainmailArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChainCoif ), 17, Utility.Random( 1,15 ), 0x13BB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChainChest ), 143, Utility.Random( 1,15 ), 0x13BF, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( ChainLegs ), 149, Utility.Random( 1,15 ), 0x13BE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChainSkirt ), 149, Utility.Random( 1,15 ), 0x63B4, MaterialInfo.PlainIronColor(0x63B4) ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChainCoif ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChainChest ), 71 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChainLegs ), 74 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChainSkirt ), 74 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHelmetArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHelmetArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateHelm ), 21, Utility.Random( 1,15 ), 0x1412, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CloseHelm ), 18, Utility.Random( 1,15 ), 0x1408, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CloseHelm ), 18, Utility.Random( 1,15 ), 0x1409, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Helmet ), 31, Utility.Random( 1,15 ), 0x140A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Helmet ), 18, Utility.Random( 1,15 ), 0x140B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NorseHelm ), 18, Utility.Random( 1,15 ), 0x140E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NorseHelm ), 18, Utility.Random( 1,15 ), 0x140F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bascinet ), 18, Utility.Random( 1,15 ), 0x140C, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( PlateHelm ), 21, Utility.Random( 1,15 ), 0x1419, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DreadHelm ), 21, Utility.Random( 1,15 ), 0x2FBB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalHelm ), 21, Utility.Random( 1,15 ), 0x2B10, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bascinet ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CloseHelm ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Helmet ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NorseHelm ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateHelm ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DreadHelm ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalHelm ), 10 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBLeatherArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBLeatherArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherArms ), 80, Utility.Random( 1,15 ), 0x13CD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherChest ), 101, Utility.Random( 1,15 ), 0x13CC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherGloves ), 60, Utility.Random( 1,15 ), 0x13C6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherGorget ), 74, Utility.Random( 1,15 ), 0x13C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherLegs ), 80, Utility.Random( 1,15 ), 0x13cb, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherCap ), 10, Utility.Random( 1,15 ), 0x1DB9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FemaleLeatherChest ), 116, Utility.Random( 1,15 ), 0x1C06, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherBustierArms ), 97, Utility.Random( 1,15 ), 0x1C0A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherShorts ), 86, Utility.Random( 1,15 ), 0x1C00, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( LeatherSkirt ), 87, Utility.Random( 1,15 ), 0x1C08, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherCloak ), 120, Utility.Random( 1,15 ), 0x1515, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherRobe ), 160, Utility.Random( 1,15 ), 0x1F03, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PugilistMits ), 18, Utility.Random( 1,15 ), 0x13C6, 0x966 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ThrowingGloves ), 26, Utility.Random( 1,15 ), 0x13C6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Whips ), 16, Utility.Random( 1,15 ), 0x6453, MaterialInfo.PlainLeatherColor() ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDragonArms ), 43200, 1, 0x13CD, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDragonChest ), 44000, 1, 0x13CC, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDragonGloves ), 42900, 1, 0x13C6, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDragonGorget ), 42700, 1, 0x13C7, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDragonLegs ), 43200, 1, 0x13cb, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDragonHelm ), 42800, 1, 0x1DB9, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinNightmareArms ), 43200, 1, 0x13CD, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinNightmareChest ), 44000, 1, 0x13CC, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinNightmareGloves ), 42900, 1, 0x13C6, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinNightmareGorget ), 42700, 1, 0x13C7, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinNightmareLegs ), 43200, 1, 0x13cb, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinNightmareHelm ), 42800, 1, 0x1DB9, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinSerpentArms ), 43200, 1, 0x13CD, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinSerpentChest ), 44000, 1, 0x13CC, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinSerpentGloves ), 42900, 1, 0x13C6, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinSerpentGorget ), 42700, 1, 0x13C7, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinSerpentLegs ), 43200, 1, 0x13cb, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinSerpentHelm ), 42800, 1, 0x1DB9, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinTrollArms ), 43200, 1, 0x13CD, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinTrollChest ), 44000, 1, 0x13CC, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinTrollGloves ), 42900, 1, 0x13C6, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinTrollGorget ), 42700, 1, 0x13C7, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinTrollLegs ), 43200, 1, 0x13cb, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinTrollHelm ), 42800, 1, 0x1DB9, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinUnicornArms ), 43200, 1, 0x13CD, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinUnicornChest ), 44000, 1, 0x13CC, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinUnicornGloves ), 42900, 1, 0x13C6, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinUnicornGorget ), 42700, 1, 0x13C7, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinUnicornLegs ), 43200, 1, 0x13cb, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinUnicornHelm ), 42800, 1, 0x1DB9, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDemonArms ), 43200, 1, 0x13CD, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDemonChest ), 44000, 1, 0x13CC, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDemonGloves ), 42900, 1, 0x13C6, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDemonGorget ), 42700, 1, 0x13C7, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDemonLegs ), 43200, 1, 0x13cb, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SkinDemonHelm ), 42800, 1, 0x1DB9, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Whips ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherArms ), 40 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherChest ), 52 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherGloves ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherGorget ), 37 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherLegs ), 40 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherCap ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemaleLeatherChest ), 18 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemaleStuddedChest ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherShorts ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherSkirt ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherBustierArms ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherCloak ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherRobe ), 80 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PugilistMits ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedBustierArms ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDragonArms ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDragonChest ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDragonGloves ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDragonGorget ), 370 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDragonLegs ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDragonHelm ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinNightmareArms ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinNightmareChest ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinNightmareGloves ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinNightmareGorget ), 370 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinNightmareLegs ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinNightmareHelm ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinSerpentArms ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinSerpentChest ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinSerpentGloves ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinSerpentGorget ), 370 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinSerpentLegs ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinSerpentHelm ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinTrollArms ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinTrollChest ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinTrollGloves ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinTrollGorget ), 370 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinTrollLegs ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinTrollHelm ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinUnicornArms ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinUnicornChest ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinUnicornGloves ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinUnicornGorget ), 370 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinUnicornLegs ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinUnicornHelm ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDemonArms ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDemonChest ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDemonGloves ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDemonGorget ), 370 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDemonLegs ), 400 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinDemonHelm ), 100 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMetalShields : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMetalShields()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BronzeShield ), 66, Utility.Random( 1,15 ), 0x1B72, Server.Misc.MaterialInfo.PlainIronColor(0x1B72) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Buckler ), 50, Utility.Random( 1,15 ), 0x1B73, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MetalKiteShield ), 123, Utility.Random( 1,15 ), 0x1B74, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HeaterShield ), 231, Utility.Random( 1,15 ), 0x1B76, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenKiteShield ), 70, Utility.Random( 1,15 ), 0x1B78, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( MetalShield ), 121, Utility.Random( 1,15 ), 0x1B7B, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GuardsmanShield ), 231, Utility.Random( 1,15 ), 0x2FCB, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ElvenShield ), 231, Utility.Random( 1,15 ), 0x2FCA, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DarkShield ), 231, Utility.Random( 1,15 ), 0x2FC8, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CrestedShield ), 231, Utility.Random( 1,15 ), 0x2FC9, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ChampionShield ), 231, Utility.Random( 1,15 ), 0x2B74, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JeweledShield ), 231, Utility.Random( 1,15 ), 0x2B75, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalShield ), 231, Utility.Random( 1,15 ), 0x2B01, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChaosShield ), 256, Utility.Random( 1,15 ), 0x1BC3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OrderShield ), 256, Utility.Random( 1,15 ), 0x1BC4, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Buckler ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BronzeShield ), 33 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MetalShield ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MetalKiteShield ), 62 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HeaterShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenKiteShield ), 35 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GuardsmanShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElvenShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DarkShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CrestedShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChampionShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JeweledShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChaosShield ), 115 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OrderShield ), 115 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBPlateArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBPlateArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateGorget ), 104, Utility.Random( 1,15 ), 0x1413, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateChest ), 243, Utility.Random( 1,15 ), 0x1415, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateLegs ), 218, Utility.Random( 1,15 ), 0x46AA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateSkirt ), 218, Utility.Random( 1,15 ), 0x1C08, MaterialInfo.PlainIronColor(0x1C08) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateArms ), 188, Utility.Random( 1,15 ), 0x1410, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( PlateGloves ), 155, Utility.Random( 1,15 ), 0x1414, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FemalePlateChest ), 207, Utility.Random( 1,15 ), 0x1C04, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalGorget ), 104, Utility.Random( 1,15 ), 0x2B0E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalChest ), 243, Utility.Random( 1,15 ), 0x2B08, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalsLegs ), 218, Utility.Random( 1,15 ), 0x2B06, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalArms ), 188, Utility.Random( 1,15 ), 0x2B12, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalGloves ), 155, Utility.Random( 1,15 ), 0x2B0C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalBoots ), 104, Utility.Random( 1,15 ), 0x2B12, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateArms ), 94 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateChest ), 121 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateGloves ), 72 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateGorget ), 52 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateLegs ), 109 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateSkirt ), 109 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemalePlateChest ), 113 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalArms ), 94 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalChest ), 121 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalGloves ), 72 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalGorget ), 52 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalsLegs ), 109 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalBoots ), 94 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBLotsOfArrows: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBLotsOfArrows()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( ManyArrows100 ), 200, 10, 0xF41, 0 ) );
				Add( new GenericBuyInfo( typeof( ManyBolts100 ), 200, 10, 0x1BFD, 0 ) );
				Add( new GenericBuyInfo( typeof( ManyArrows1000 ), 2000, 10, 0xF41, 0 ) );
				Add( new GenericBuyInfo( typeof( ManyBolts1000 ), 2000, 10, 0x1BFD, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRingmailArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRingmailArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RingmailChest ), 121, Utility.Random( 1,15 ), 0x13ec, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RingmailLegs ), 90, Utility.Random( 1,15 ), 0x13F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RingmailSkirt ), 90, Utility.Random( 1,15 ), 0x63B4, 0xABF ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RingmailArms ), 85, Utility.Random( 1,15 ), 0x13EE, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( RingmailGloves ), 93, Utility.Random( 1,15 ), 0x13eb, 0 ) ); }

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( RingmailArms ), 42 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RingmailChest ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RingmailGloves ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RingmailLegs ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RingmailSkirt ), 45 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBStuddedArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBStuddedArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedArms ), 87, Utility.Random( 1,15 ), 0x13DC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedChest ), 128, Utility.Random( 1,15 ), 0x13DB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedGloves ), 79, Utility.Random( 1,15 ), 0x13D5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedGorget ), 73, Utility.Random( 1,15 ), 0x13D6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedLegs ), 103, Utility.Random( 1,15 ), 0x13DA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedSkirt ), 103, Utility.Random( 1,15 ), 0x1C08, 0xAC0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FemaleStuddedChest ), 142, Utility.Random( 1,15 ), 0x1C02, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( StuddedBustierArms ), 120, Utility.Random( 1,15 ), 0x1c0c, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedArms ), 43 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedChest ), 64 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedGloves ), 39 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedGorget ), 36 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedLegs ), 51 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedSkirt ), 51 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemaleStuddedChest ), 71 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedBustierArms ), 60 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBWoodenShields: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWoodenShields()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( WoodenShield ), 30, Utility.Random( 1,15 ), 0x1B7A, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenShield ), 15 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSEArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSEArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateHatsuburi ), 76, Utility.Random( 1,15 ), 0x2775, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HeavyPlateJingasa ), 76, Utility.Random( 1,15 ), 0x2777, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DecorativePlateKabuto ), 95, Utility.Random( 1,15 ), 0x2778, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateDo ), 310, Utility.Random( 1,15 ), 0x277D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateHiroSode ), 222, Utility.Random( 1,15 ), 0x2780, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateSuneate ), 224, Utility.Random( 1,15 ), 0x2788, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlateHaidate ), 235, Utility.Random( 1,15 ), 0x278D, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( ChainHatsuburi ), 76, Utility.Random( 1,15 ), 0x2774, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateHatsuburi ), 38 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HeavyPlateJingasa ), 38 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DecorativePlateKabuto ), 47 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateDo ), 155 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateHiroSode ), 111 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateSuneate ), 112 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlateHaidate), 117 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChainHatsuburi ), 38 ); } // DO NOT WANT?

			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSEBowyer: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSEBowyer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Yumi ), 53, Utility.Random( 1,15 ), 0x27A5, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Fukiya ), 20, Utility.Random( 1,15 ), 0x27AA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Nunchaku ), 35, Utility.Random( 1,15 ), 0x27AE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FukiyaDarts ), 3, Utility.Random( 1,15 ), 0x2806, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Yumi ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Fukiya ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nunchaku ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FukiyaDarts ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSECarpenter: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSECarpenter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bokuto ), 21, Utility.Random( 1,15 ), 0x27A8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tetsubo ), 43, Utility.Random( 1,15 ), 0x27A6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Fukiya ), 20, Utility.Random( 1,15 ), 0x27AA, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tetsubo ), 21 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Fukiya ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bokuto ), 10 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSEFood: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSEFood()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wasabi ), 2, Utility.Random( 1,15 ), 0x24E8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wasabi ), 2, Utility.Random( 1,15 ), 0x24E9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BentoBox ), 6, Utility.Random( 1,15 ), 0x2836, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BentoBox ), 6, Utility.Random( 1,15 ), 0x2837, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( GreenTeaBasket ), 2, Utility.Random( 1,15 ), 0x284B, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Wasabi ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BentoBox ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreenTeaBasket ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSELeatherArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSELeatherArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherJingasa ), 11, Utility.Random( 1,15 ), 0x2776, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherDo ), 87, Utility.Random( 1,15 ), 0x277B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherHiroSode ), 49, Utility.Random( 1,15 ), 0x277E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherSuneate ), 55, Utility.Random( 1,15 ), 0x2786, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherHaidate), 54, Utility.Random( 1,15 ), 0x278A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherNinjaPants ), 49, Utility.Random( 1,15 ), 0x2791, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherNinjaJacket ), 51, Utility.Random( 1,15 ), 0x2793, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherNinjaMitts ), 60, Utility.Random( 1,15 ), 0x2792, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherNinjaHood ), 10, Utility.Random( 1,15 ), 0x278E, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NinjaTabi ), 15, Utility.Random( 1,15 ), 0x2797, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OniwabanBoots ), 120, Utility.Random( 1,15 ), 0x64BA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OniwabanGloves ), 60, Utility.Random( 1,15 ), 0x64B9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OniwabanHood ), 10, Utility.Random( 1,15 ), 0x64BB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OniwabanLeggings ), 80, Utility.Random( 1,15 ), 0x64BC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OniwabanTunic ), 101, Utility.Random( 1,15 ), 0x64BD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShinobiRobe ), 160, Utility.Random( 1,15 ), 0x5C10, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShinobiCowl ), 10, Utility.Random( 1,15 ), 0x5C13, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShinobiHood ), 10, Utility.Random( 1,15 ), 0x5C11, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShinobiMask ), 10, Utility.Random( 1,15 ), 0x5C12, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedMempo ), 61, Utility.Random( 1,15 ), 0x279D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedDo ), 130, Utility.Random( 1,15 ), 0x277C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedHiroSode ), 73, Utility.Random( 1,15 ), 0x277F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedSuneate ), 78, Utility.Random( 1,15 ), 0x2787, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( StuddedHaidate ), 76, Utility.Random( 1,15 ), 0x278B, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherJingasa ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherDo ), 42 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherHiroSode ), 23 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherSuneate ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherHaidate), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherNinjaPants ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherNinjaJacket ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherNinjaMitts ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherNinjaHood ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NinjaTabi ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OniwabanBoots ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OniwabanGloves ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OniwabanHood ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OniwabanLeggings ), 40 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OniwabanTunic ), 52 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedMempo ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedDo ), 66 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedHiroSode ), 32 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedSuneate ), 40 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedHaidate ), 37 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShinobiRobe ), 80 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShinobiCowl ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShinobiHood ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShinobiMask ), 5 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSEWeapons: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSEWeapons()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NoDachi ), 82, Utility.Random( 1,15 ), 0x27A2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tessen ), 83, Utility.Random( 1,15 ), 0x27A3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wakizashi ), 38, Utility.Random( 1,15 ), 0x27A4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tetsubo ), 43, Utility.Random( 1,15 ), 0x27A6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lajatang ), 108, Utility.Random( 1,15 ), 0x27A7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Daisho ), 66, Utility.Random( 1,15 ), 0x27A9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tekagi ), 55, Utility.Random( 1,15 ), 0x27AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Shuriken ), 18, Utility.Random( 1,15 ), 0x27AC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Kama ), 61, Utility.Random( 1,15 ), 0x27AD, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Sai ), 56, Utility.Random( 1,15 ), 0x27AF, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( NoDachi ), 41 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tessen ), 41 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Wakizashi ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tetsubo ), 21 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lajatang ), 54 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Daisho ), 33 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tekagi ), 22 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shuriken), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Kama ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sai ), 28 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBAxeWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAxeWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ExecutionersAxe ), 30, Utility.Random( 1,15 ), 0xF45, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BattleAxe ), 26, Utility.Random( 1,15 ), 0xF47, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TwoHandedAxe ), 32, Utility.Random( 1,15 ), 0x1443, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Axe ), 40, Utility.Random( 1,15 ), 0xF49, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DoubleAxe ), 52, Utility.Random( 1,15 ), 0xF4B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pickaxe ), 22, Utility.Random( 1,15 ), 0xE86, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LargeBattleAxe ), 33, Utility.Random( 1,15 ), 0x13FB, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( WarAxe ), 29, Utility.Random( 1,15 ), 0x13B0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OrnateAxe ), 55, Utility.Random( 1,15 ), 0x2D28, 0 ) ); }

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( OrnateAxe ),27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BattleAxe ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DoubleAxe ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ExecutionersAxe ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeBattleAxe ),16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pickaxe ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TwoHandedAxe ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WarAxe ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Axe ), 20 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBKnifeWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKnifeWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ButcherKnife ), 14, Utility.Random( 1,15 ), 0x13F6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dagger ), 21, Utility.Random( 1,15 ), 0xF52, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cleaver ), 15, Utility.Random( 1,15 ), 0xEC3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LargeKnife ), 21, Utility.Random( 1,15 ), 0x2674, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( SkinningKnife ), 14, Utility.Random( 1,15 ), 0xEC4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AssassinSpike ), 21, Utility.Random( 1,15 ), 0x2D21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Leafblade ), 21, Utility.Random( 1,15 ), 0x2D22, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WarCleaver ), 25, Utility.Random( 1,15 ), 0x2D2F, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( ButcherKnife ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cleaver ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dagger ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeKnife ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinningKnife ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AssassinSpike ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Leafblade ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WarCleaver ), 12 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMaceWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMaceWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DiamondMace ), 31, Utility.Random( 1,15 ), 0x2D24, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HammerPick ), 26, Utility.Random( 1,15 ), 0x143D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Club ), 16, Utility.Random( 1,15 ), 0x13B4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Hammers ), 28, Utility.Random( 1,15 ), 0x267E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Mace ), 28, Utility.Random( 1,15 ), 0xF5C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Maul ), 21, Utility.Random( 1,15 ), 0x143B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SpikedClub ), 28, Utility.Random( 1,15 ), 0x2AB5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WarHammer ), 25, Utility.Random( 1,15 ), 0x1439, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( WarMace ), 31, Utility.Random( 1,15 ), 0x1407, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Club ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HammerPick ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Mace ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpikedClub ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hammers ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Maul ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WarHammer ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WarMace ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DiamondMace ), 15 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBPoleArmWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBPoleArmWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bardiche ), 60, Utility.Random( 1,15 ), 0xF4D, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Halberd ), 42, Utility.Random( 1,15 ), 0x143E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bardiche ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Halberd ), 21 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRangedWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRangedWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bow ), 40, Utility.Random( 1,15 ), 0x13B2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Crossbow ), 55, Utility.Random( 1,15 ), 0xF50, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HeavyCrossbow ), 55, Utility.Random( 1,15 ), 0x13FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RepeatingCrossbow ), 46, Utility.Random( 1,15 ), 0x26C3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CompositeBow ), 45, Utility.Random( 1,15 ), 0x26C2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MagicalShortbow ), 42, Utility.Random( 1,15 ), 0x2D2B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ElvenCompositeLongbow ), 42, Utility.Random( 1,15 ), 0x2D1E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bolt ), 2, Utility.Random( 30, 60 ), 0x1BFB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Arrow ), 2, Utility.Random( 30, 60 ), 0xF3F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Feather ), 2, Utility.Random( 30, 60 ), 0x4CCD, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Shaft ), 3, Utility.Random( 30, 60 ), 0x1BD4, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bolt ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Arrow ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shaft ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Feather ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HeavyCrossbow ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bow ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Crossbow ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CompositeBow ), 23 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RepeatingCrossbow ), 22 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicalShortbow ), 18 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElvenCompositeLongbow ), 18 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSpearForkWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSpearForkWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pitchforks ), 19, Utility.Random( 1,15 ), 0xE88, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShortSpear ), 23, Utility.Random( 1,15 ), 0x1403, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Spear ), 31, Utility.Random( 1,15 ), 0xF62, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pitchfork ), 19, Utility.Random( 1,15 ), 0xE87, MaterialInfo.PlainIronColor(0xE87) ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Spear ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitchfork ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitchforks ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShortSpear ), 11 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBStavesWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBStavesWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WildStaff ), 20, Utility.Random( 1,15 ), 0x2D25, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GnarledStaff ), 16, Utility.Random( 1,15 ), 0x13F8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( QuarterStaff ), 19, Utility.Random( 1,15 ), 0xE89, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( ShepherdsCrook ), 20, Utility.Random( 1,15 ), 0xE81, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( GnarledStaff ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuarterStaff ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShepherdsCrook ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WildStaff ), 10 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSwordWeapon: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSwordWeapon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cutlass ), 24, Utility.Random( 1,15 ), 0x1441, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Katana ), 33, Utility.Random( 1,15 ), 0x13FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Kryss ), 32, Utility.Random( 1,15 ), 0x1401, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Broadsword ), 35, Utility.Random( 1,15 ), 0xF5E, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Longsword ), 55, Utility.Random( 1,15 ), 0xF61, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ThinLongsword ), 27, Utility.Random( 1,15 ), 0x13B8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( VikingSword ), 55, Utility.Random( 1,15 ), 0x13B9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Claymore ), 60, Utility.Random( 1,15 ), 0x568F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Scimitar ), 36, Utility.Random( 1,15 ), 0x13B6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShortSword ), 35, Utility.Random( 1,15 ), 0x2672, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BoneHarvester ), 35, Utility.Random( 1,15 ), 0x26BB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CrescentBlade ), 37, Utility.Random( 1,15 ), 0x26C1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DoubleBladedStaff ), 35, Utility.Random( 1,15 ), 0x26BF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lance ), 34, Utility.Random( 1,15 ), 0x26C0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pike ), 39, Utility.Random( 1,15 ), 0x26BE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Scythe ), 39, Utility.Random( 1,15 ), 0x26BA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RuneBlade ), 55, Utility.Random( 1,15 ), 0x2D32, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RadiantScimitar ), 35, Utility.Random( 1,15 ), 0x2D33, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ElvenSpellblade ), 33, Utility.Random( 1,15 ), 0x2D20, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ElvenMachete ), 35, Utility.Random( 1,15 ), 0x2D35, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Broadsword ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cutlass ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Katana ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Kryss ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Longsword ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scimitar ), 18 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ThinLongsword ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VikingSword ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Claymore ), 29 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scythe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BoneHarvester ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scepter ), 18 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShortSword ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BladedStaff ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pike ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DoubleBladedStaff ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lance ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CrescentBlade ), 18 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RuneBlade ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RadiantScimitar ), 17 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElvenSpellblade ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElvenMachete ), 17 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBElfWizard : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElfWizard()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BagOfSending ), 4000, Utility.Random( 1,10 ), 0xE76, 0x8AD ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BallOfSummoning ), 3000, Utility.Random( 1,10 ), 0xE2E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BraceletOfBinding ), 3500, Utility.Random( 1,10 ), 0x4CF1, 0x489 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PowderOfTranslocation ), 500, Utility.Random( 5,20 ), 0x26B8, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBElfHealer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElfHealer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FountainOfLifeDeed ), 7400, 1, 0x14F0, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBUndertaker: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBUndertaker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( PowerCoil ), Utility.Random( 10000,20000 ), Utility.Random( 1,5 ), 0x8A7, 0 ) );
				Add( new GenericBuyInfo( typeof( EmbalmingFluid ), Utility.Random( 100,200 ), Utility.Random( 15,55 ), 0xE0F, 0xBA1 ) );

				if ( MyServerSettings.MonstersAllowed() )
				{
					Add( new GenericBuyInfo( typeof( BloodyDrink ), 6, Utility.Random( 10,30 ), 0x180F, 0xB1E ) );
					Add( new GenericBuyInfo( typeof( FreshBrain ), 6, Utility.Random( 10,30 ), 0x64B8, 0 ) );
					if ( Utility.RandomBool() )
					{
						Add( new GenericBuyInfo( typeof( BloodyDrink ), 6, Utility.Random( 10,30 ), 0x180F, 0xB1E ) );
						Add( new GenericBuyInfo( typeof( FreshBrain ), 6, Utility.Random( 10,30 ), 0x64B8, 0 ) );
					}
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( FrankenArmRight ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenHead ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenLegLeft ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenLegRight ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenTorso ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenArmLeft ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenBrain ), Utility.Random( 25,100 ) );
				Add( typeof( FrankenJournal ), Utility.Random( 300,750 ) );
				Add( typeof( PowerCoil ), Utility.Random( 3500,4500 ) );
				Add( typeof( CorpseSailor ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( CorpseChest ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BuriedBody ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BoneContainer ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( LeftLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( TastyHeart ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( BodyPart ), Utility.RandomMinMax( 30, 90 ) );
				Add( typeof( Head ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( LeftArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Torso ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bone ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RibCage ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( BonePile ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bones ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( GraveChest ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( EmbalmingFluid ), Utility.RandomMinMax( 25, 45 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DracolichSkull ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBAlchemist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MortarPestle ), 8, Utility.Random( 1,15 ), 0x4CE9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 1,15 ), 0x640B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemicalElixirs ), 50, Utility.Random( 1,15 ), 0x2219, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemicalMixtures ), 50, Utility.Random( 1,15 ), 0x2223, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BookOfPoisons ), 50, Utility.Random( 1,15 ), 0x2253, 0xB51 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HeatingStand ), 2, Utility.Random( 1,15 ), 0x1849, 0 ) ); }

				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 1,15 ), 0x266F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 1,15 ), 0xF7B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 1,15 ), 0xF86, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 1,15 ), 0xF88, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 1,15 ), 0xF8D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 1,15 ), 0xF8C, 0 ) ); }

				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 1,15 ), 0x2FD3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ButterflyWings ), 6, Utility.Random( 1,15 ), 0x3002, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 1,15 ), 0x2FDA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FairyEgg ), 6, Utility.Random( 1,15 ), 0x2FDB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GargoyleEar ), 6, Utility.Random( 1,15 ), 0x2FD9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 1,15 ), 0x2FF8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 1,15 ), 0x3003, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PixieSkull ), 6, Utility.Random( 1,15 ), 0x2FE1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 1,15 ), 0x2FE8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SeaSalt ), 6, Utility.Random( 1,15 ), 0x2FE9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 1,15 ), 0x2FF7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 1,15 ), 0x2FE0, 0 ) ); }

				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BottleOfAcid ), 600, Utility.Random( 1,15 ), 0x180F, 1167 ) ); }

				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,15 ), 0xF0B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, Utility.Random( 1,15 ), 0xF08, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, Utility.Random( 1,15 ), 0xF06, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 1,15 ), 0x25FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, Utility.Random( 1,15 ), 0xF09, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, Utility.Random( 1,15 ), 0x2600, 0 ) ); }
 				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserCurePotion ), 15, Utility.Random( 1,15 ), 0x233B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 21, Utility.Random( 1,15 ), 0x2407, 0 ) ); }

				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( HealPotion ), 30, Utility.Random( 1,15 ), 0xF0C, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( PoisonPotion ), 30, Utility.Random( 1,15 ), 0xF0A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CurePotion ), 30, Utility.Random( 1,15 ), 0xF07, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ExplosionPotion ), 42, Utility.Random( 1,15 ), 0xF0D, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ConflagrationPotion ), 30, Utility.Random( 1,15 ), 0x180F, 0xAD8 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ConfusionBlastPotion ), 30, Utility.Random( 1,15 ), 0x180F, 0x48D ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( FrostbitePotion ), 30, Utility.Random( 1,15 ), 0x180F, 0xAF3 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( TotalRefreshPotion ), 30, Utility.Random( 1,15 ), 0x25FF, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterAgilityPotion ), 60, Utility.Random( 1,15 ), 0x256A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterConflagrationPotion ), 60, Utility.Random( 1,15 ), 0x2406, 0xAD8 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterConfusionBlastPotion ), 60, Utility.Random( 1,15 ), 0x2406, 0x48D ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 60, Utility.Random( 1,15 ), 0x24EA, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterExplosionPotion ), 60, Utility.Random( 1,15 ), 0x2408, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterFrostbitePotion ), 60, Utility.Random( 1,15 ), 0x2406, 0xAF3 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 60, Utility.Random( 1,15 ), 0x25FE, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterPoisonPotion ), 60, Utility.Random( 1,15 ), 0x2601, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GreaterStrengthPotion ), 60, Utility.Random( 1,15 ), 0x25F7, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( DeadlyPoisonPotion ), 60, Utility.Random( 1,15 ), 0x2669, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LesserInvisibilityPotion ), 860, Utility.Random( 1,3 ), 0x23BD, 0x490 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LesserManaPotion ), 860, Utility.Random( 1,3 ), 0x23BD, 0x48D ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LesserRejuvenatePotion ), 860, Utility.Random( 1,3 ), 0x23BD, 0x48E ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( InvisibilityPotion ), 890, Utility.Random( 1,3 ), 0x180F, 0x490 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ManaPotion ), 890, Utility.Random( 1,3 ), 0x180F, 0x48D ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RejuvenatePotion ), 890, Utility.Random( 1,3 ), 0x180F, 0x48E ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GreaterInvisibilityPotion ), 8120, 1, 0x2406, 0x490 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GreaterManaPotion ), 8120, 1, 0x2406, 0x48D ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GreaterRejuvenatePotion ), 8120, 1, 0x2406, 0x48E ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( InvulnerabilityPotion ), 8300, 1, 0x180F, 0x48F ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AutoResPotion ), 8600, 1, 0x0E0F, 0x494 ) ); }

				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemistPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0xAFE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DruidPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x8A1 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullMinotaur ), Utility.Random( 50,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullWyrm ), Utility.Random( 200,400 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGreatDragon ), Utility.Random( 300,600 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDragon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDemon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGiant ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CanopicJar ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchCauldron ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DragonTooth ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EnchantedSeaweed ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GhostlyDust ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenSerpentVenom ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LichDust ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverSerpentVenom ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( UnicornHorn ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemigodBlood ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemonClaw ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DragonBlood ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackPearl ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bloodmoss ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MandrakeRoot ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Garlic ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ginseng ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nightshade ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpidersSilk ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( SulfurousAsh ), 1 ); } // DO NOT WANT?

				if ( MyServerSettings.BuyChance() ){Add( typeof( Brimstone ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ButterflyWings ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EyeOfToad ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FairyEgg ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GargoyleEar ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BeetleShell ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MoonCrystal ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PixieSkull ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RedLotus ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SeaSalt ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverWidow ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SwampBerries ), 3 ); } // DO NOT WANT?

				if ( MyServerSettings.BuyChance() ){Add( typeof( MortarPestle ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AgilityPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AutoResPotion ), 94 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BottleOfAcid ), 32 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ConflagrationPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FrostbitePotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ConfusionBlastPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CurePotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DeadlyPoisonPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ExplosionPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterAgilityPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterConflagrationPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterFrostbitePotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterConfusionBlastPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterCurePotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterExplosionPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterHealPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterInvisibilityPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterManaPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterPoisonPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterRejuvenatePotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreaterStrengthPotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HealPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( InvisibilityPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( InvulnerabilityPotion ), 53 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PotionOfWisdom ), Utility.Random( 250,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PotionOfDexterity ), Utility.Random( 250,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PotionOfMight ), Utility.Random( 250,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserCurePotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserExplosionPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserHealPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserInvisibilityPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserManaPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserPoisonPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserRejuvenatePotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ManaPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NightSightPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PoisonPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RefreshPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RejuvenatePotion ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StrengthPotion ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TotalRefreshPotion ), 28 ); } // DO NOT WANT?

				Add( typeof( SpecialSeaweed ), Utility.Random( 15, 35 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMixologist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMixologist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ElixirAlchemy ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirAnatomy ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirAnimalLore ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirAnimalTaming ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirArchery ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirArmsLore ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirBegging ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirBlacksmith ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirMacing ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirCamping ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirCarpentry ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirCartography ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirCooking ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirDetectHidden ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirDiscordance ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirEvalInt ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirFencing ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirFishing ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirFletching ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirFocus ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirForensics ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirHealing ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirHerding ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirHiding ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirInscribe ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirItemID ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirLockpicking ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirLumberjacking ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirMagicResist ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirMeditation ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirMining ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirMusicianship ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirParry ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirPeacemaking ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirPoisoning ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirProvocation ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirRemoveTrap ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirSnooping ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirSpiritSpeak ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirStealing ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirStealth ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirSwords ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirTactics ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirTailoring ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirTasteID ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirTinkering ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirTracking ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirVeterinary ), Utility.Random( 14, 35 ) );
				Add( typeof( ElixirWrestling ), Utility.Random( 14, 35 ) );
				Add( typeof( MixtureSlime ), Utility.Random( 14, 35 ) );
				Add( typeof( MixtureIceSlime ), Utility.Random( 14, 35 ) );
				Add( typeof( MixtureFireSlime ), Utility.Random( 14, 35 ) );
				Add( typeof( MixtureDiseasedSlime ), Utility.Random( 14, 35 ) );
				Add( typeof( MixtureRadiatedSlime ), Utility.Random( 14, 35 ) );
				Add( typeof( LiquidFire ), Utility.Random( 14, 35 ) );
				Add( typeof( LiquidGoo ), Utility.Random( 14, 35 ) );
				Add( typeof( LiquidIce ), Utility.Random( 14, 35 ) );
				Add( typeof( LiquidRot ), Utility.Random( 14, 35 ) );
				Add( typeof( LiquidPain ), Utility.Random( 14, 35 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedAlligator ), BaseCaged.Price( "Alligator" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedApe ), BaseCaged.Price( "Ape" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedBlackBear ), BaseCaged.Price( "BlackBear" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedBlackWolf ), BaseCaged.Price( "BlackWolf" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedBoar ), BaseCaged.Price( "Boar" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedBobcat ), BaseCaged.Price( "Bobcat" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedBrownBear ), BaseCaged.Price( "BrownBear" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedCat ), BaseCaged.Price( "Cat" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedCougar ), BaseCaged.Price( "Cougar" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedDireBear ), BaseCaged.Price( "DireBear" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedDireBoar ), BaseCaged.Price( "DireBoar" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedDog ), BaseCaged.Price( "Dog" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedEagle ), BaseCaged.Price( "Eagle" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() && MyServerSettings.AllowElephants() ){Add( new GenericBuyInfo( typeof( CagedElephant ), BaseCaged.Price( "Elephant" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedFerret ), BaseCaged.Price( "Ferret" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() && MyServerSettings.AllowFox() ){Add( new GenericBuyInfo( typeof( CagedFox ), BaseCaged.Price( "Fox" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedFrog ), BaseCaged.Price( "Frog" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantHawk ), BaseCaged.Price( "GiantHawk" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantLizard ), BaseCaged.Price( "GiantLizard" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantRat ), BaseCaged.Price( "GiantRat" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantRaven ), BaseCaged.Price( "GiantRaven" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantSerpent ), BaseCaged.Price( "GiantSerpent" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantSnake ), BaseCaged.Price( "GiantSnake" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGiantToad ), BaseCaged.Price( "GiantToad" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedGoat ), BaseCaged.Price( "Goat" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGorilla ), BaseCaged.Price( "Gorilla" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGreyWolf ), BaseCaged.Price( "GreyWolf" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( Utility.RandomMinMax(1,1000) == 1 ){Add( new GenericBuyInfo( typeof( CagedGriffonRiding ), BaseCaged.Price( "GriffonRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedGrizzlyBearRiding ), BaseCaged.Price( "GrizzlyBearRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedHawk ), BaseCaged.Price( "Hawk" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( Utility.RandomMinMax(1,1000) == 1 ){Add( new GenericBuyInfo( typeof( CagedHippogriffRiding ), BaseCaged.Price( "HippogriffRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedHugeLizard ), BaseCaged.Price( "HugeLizard" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedJackal ), BaseCaged.Price( "Jackal" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedJaguar ), BaseCaged.Price( "Jaguar" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedLionRiding ), BaseCaged.Price( "LionRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( Utility.RandomMinMax(1,1000) == 1 ){Add( new GenericBuyInfo( typeof( CagedManticoreRiding ), BaseCaged.Price( "ManticoreRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedMouse ), BaseCaged.Price( "Mouse" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedPandaRiding ), BaseCaged.Price( "PandaRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedPanther ), BaseCaged.Price( "Panther" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedPig ), BaseCaged.Price( "Pig" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedPolarBear ), BaseCaged.Price( "PolarBear" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedRabbit ), BaseCaged.Price( "Rabbit" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedRat ), BaseCaged.Price( "Rat" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedSheep ), BaseCaged.Price( "Sheep" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedTigerRiding ), BaseCaged.Price( "TigerRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedTimberWolf ), BaseCaged.Price( "TimberWolf" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedWhiteWolf ), BaseCaged.Price( "WhiteWolf" ), 1, BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedWolfDire ), BaseCaged.Price( "WolfDire" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }

				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StableStone ), 5000, Utility.Random( 1,3 ), 0x14E7, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( StableStone ), 2500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AlienEgg ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DragonEgg ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedAlligator ), BaseCaged.Sell( "Alligator" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedApe ), BaseCaged.Sell( "Ape" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedBlackBear ), BaseCaged.Sell( "BlackBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedBlackWolf ), BaseCaged.Sell( "BlackWolf" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedBoar ), BaseCaged.Sell( "Boar" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedBobcat ), BaseCaged.Sell( "Bobcat" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedBrownBear ), BaseCaged.Sell( "BrownBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedBull ), BaseCaged.Sell( "Bull" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedCat ), BaseCaged.Sell( "Cat" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedCaveBearRiding ), BaseCaged.Sell( "CaveBearRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedChicken ), BaseCaged.Sell( "Chicken" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedTurkey ), BaseCaged.Sell( "Turkey" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedCougar ), BaseCaged.Sell( "Cougar" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedCow ), BaseCaged.Sell( "Cow" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedDesertOstard ), BaseCaged.Sell( "DesertOstard" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedDireBear ), BaseCaged.Sell( "DireBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedDireBoar ), BaseCaged.Sell( "DireBoar" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedDog ), BaseCaged.Sell( "Dog" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedEagle ), BaseCaged.Sell( "Eagle" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedElderBlackBearRiding ), BaseCaged.Sell( "ElderBlackBearRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedElderBrownBearRiding ), BaseCaged.Sell( "ElderBrownBearRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedElderPolarBearRiding ), BaseCaged.Sell( "ElderPolarBearRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedElephant ), BaseCaged.Sell( "Elephant" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedFerret ), BaseCaged.Sell( "Ferret" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedForestOstard ), BaseCaged.Sell( "ForestOstard" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedFox ), BaseCaged.Sell( "Fox" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedFrog ), BaseCaged.Sell( "Frog" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantHawk ), BaseCaged.Sell( "GiantHawk" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantLizard ), BaseCaged.Sell( "GiantLizard" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantRat ), BaseCaged.Sell( "GiantRat" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantRaven ), BaseCaged.Sell( "GiantRaven" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantSerpent ), BaseCaged.Sell( "GiantSerpent" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantSnake ), BaseCaged.Sell( "GiantSnake" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGiantToad ), BaseCaged.Sell( "GiantToad" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGoat ), BaseCaged.Sell( "Goat" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGorilla ), BaseCaged.Sell( "Gorilla" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGreatBear ), BaseCaged.Sell( "GreatBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGreyWolf ), BaseCaged.Sell( "GreyWolf" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedGrizzlyBearRiding ), BaseCaged.Sell( "GrizzlyBearRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedHawk ), BaseCaged.Sell( "Hawk" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedHorse ), BaseCaged.Sell( "Horse" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedHugeLizard ), BaseCaged.Sell( "HugeLizard" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedJackal ), BaseCaged.Sell( "Jackal" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedJaguar ), BaseCaged.Sell( "Jaguar" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedKodiakBear ), BaseCaged.Sell( "KodiakBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedLionRiding ), BaseCaged.Sell( "LionRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedManticoreRiding ), BaseCaged.Sell( "ManticoreRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedMouse ), BaseCaged.Sell( "Mouse" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackBear ), BaseCaged.Sell( "PackBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackHorse ), BaseCaged.Sell( "PackHorse" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackLlama ), BaseCaged.Sell( "PackLlama" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackMule ), BaseCaged.Sell( "PackMule" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackStegosaurus ), BaseCaged.Sell( "PackStegosaurus" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackTurtle ), BaseCaged.Sell( "PackTurtle" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPandaRiding ), BaseCaged.Sell( "PandaRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPanther ), BaseCaged.Sell( "Panther" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPig ), BaseCaged.Sell( "Pig" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPolarBear ), BaseCaged.Sell( "PolarBear" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedRabbit ), BaseCaged.Sell( "Rabbit" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedRaptorRiding ), BaseCaged.Sell( "RaptorRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedRat ), BaseCaged.Sell( "Rat" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedRidableLlama ), BaseCaged.Sell( "RidableLlama" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedRidgeback ), BaseCaged.Sell( "Ridgeback" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedSheep ), BaseCaged.Sell( "Sheep" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedSnowOstard ), BaseCaged.Sell( "SnowOstard" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedSwampDragon ), BaseCaged.Sell( "SwampDragon" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedTigerRiding ), BaseCaged.Sell( "TigerRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedTimberWolf ), BaseCaged.Sell( "TimberWolf" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedWhiteWolf ), BaseCaged.Sell( "WhiteWolf" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedWolfDire ), BaseCaged.Sell( "WolfDire" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedZebraRiding ), BaseCaged.Sell( "ZebraRiding" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackNecroSpider ), BaseCaged.Sell( "PackNecroSpider" ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CagedPackNecroHound ), BaseCaged.Sell( "PackNecroHound" ) ); } // DO NOT WANT?
				Add( typeof( SlaversNet ), Utility.Random( 800, 2000 ) );
			}
		}
	}
	public class SBHumanAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHumanAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedBull ), BaseCaged.Price( "Bull" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedChicken ), BaseCaged.Price( "Chicken" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedTurkey ), BaseCaged.Price( "Turkey" ), Utility.Random( 1,3 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedCow ), BaseCaged.Price( "Cow" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedHorse ), BaseCaged.Price( "Horse" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedRidableLlama ), BaseCaged.Price( "RidableLlama" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedPackHorse ), BaseCaged.Price( "PackHorse" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackLlama ), BaseCaged.Price( "PackLlama" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackMule ), BaseCaged.Price( "PackMule" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() && MyServerSettings.AllowZebras() ){Add( new GenericBuyInfo( typeof( CagedZebraRiding ), BaseCaged.Price( "ZebraRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	public class SBDeadAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDeadAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedPackNecroSpider ), BaseCaged.Price( "PackNecroSpider" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackNecroHound ), BaseCaged.Price( "PackNecroHound" ), Utility.Random( 1,5 ), BaseCaged.Cage( "large" ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	public class SBGargoyleAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGargoyleAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedSwampDragon ), BaseCaged.Price( "SwampDragon" ), Utility.Random( 1,5 ), BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedCaveBearRiding ), BaseCaged.Price( "CaveBearRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	public class SBElfAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElfAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedDesertOstard ), BaseCaged.Price( "DesertOstard" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedForestOstard ), BaseCaged.Price( "ForestOstard" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedKodiakBear ), BaseCaged.Price( "KodiakBear" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedSnowOstard ), BaseCaged.Price( "SnowOstard" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedBull ), BaseCaged.Price( "Bull" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedChicken ), BaseCaged.Price( "Chicken" ), Utility.Random( 1,5 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedTurkey ), BaseCaged.Price( "Turkey" ), Utility.Random( 1,3 ), BaseCaged.Cage( "small" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedCow ), BaseCaged.Price( "Cow" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CagedHorse ), BaseCaged.Price( "Horse" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedPackHorse ), BaseCaged.Price( "PackHorse" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackMule ), BaseCaged.Price( "PackMule" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellRareChance() && MyServerSettings.AllowZebras() ){Add( new GenericBuyInfo( typeof( CagedZebraRiding ), BaseCaged.Price( "ZebraRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	public class SBBarbarianAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBarbarianAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedElderBlackBearRiding ), BaseCaged.Price( "ElderBlackBearRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedElderBrownBearRiding ), BaseCaged.Price( "ElderBrownBearRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedElderPolarBearRiding ), BaseCaged.Price( "ElderPolarBearRiding" ), 1, BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedGreatBear ), BaseCaged.Price( "GreatBear" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackBear ), BaseCaged.Price( "PackBear" ), Utility.Random( 1,5 ), BaseCaged.Cage( "medium" ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	public class SBOrkAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBOrkAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackStegosaurus ), BaseCaged.Price( "Stegosaurus" ), Utility.Random( 1,5 ), BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedPackTurtle ), BaseCaged.Price( "PackTurle" ), Utility.Random( 1,5 ), BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CagedRidgeback ), BaseCaged.Price( "Ridgeback" ), Utility.Random( 1,5 ), BaseCaged.Cage( "large" ), 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CagedRaptorRiding ), BaseCaged.Price( "RaptorRiding" ), 1, BaseCaged.Cage( "medium" ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBArchitect : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBArchitect()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( InteriorDecorator ), 100, Utility.Random( 1,15 ), 0x1EBA, 0 ) );
				Add( new GenericBuyInfo( typeof( HousePlacementTool ), 50, Utility.Random( 1,15 ), 0x14F0, 0 ) );
				if ( Server.Misc.MyServerSettings.LawnsAllowed() ){ Add( new GenericBuyInfo( typeof( LawnTools ), 500, Utility.Random( 1,5 ), 0x63E6, 0 ) ); }
				if ( Server.Misc.MyServerSettings.ShantysAllowed() ){ Add( new GenericBuyInfo( typeof( ShantyTools ), 400, Utility.Random( 1,5 ), 0x63E8, 0 ) ); }
				Add( new GenericBuyInfo( "house teleporter", typeof( PlayersHouseTeleporter ), 4000, Utility.Random( 1,10 ), 0x181D, 0 ) );
				Add( new GenericBuyInfo( "house high teleporter", typeof( PlayersZTeleporter ), 2000, Utility.Random( 1,10 ), 0x181D, 0 ) );
				if ( Server.Items.MovingBox.IsEnabled() ){ Add( new GenericBuyInfo( typeof( MovingBox ), 500, Utility.Random( 1,15 ), 0xE3D, 0xAC0 ) ); }
				if ( Server.Items.BasementDoor.IsEnabled() ){ Add( new GenericBuyInfo( typeof( BasementDoor ), 2500, Utility.Random( 1,15 ), 0x02C1, 0 ) ); }
				Add( new GenericBuyInfo( typeof( house_sign_sign_post_a ), 5, Utility.Random( 1,15 ), 2967, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_post_b ), 5, Utility.Random( 1,15 ), 2970, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_merc ), 10, Utility.Random( 1,15 ), 3082, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_armor ), 10, Utility.Random( 1,15 ), 3008, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bake ), 10, Utility.Random( 1,15 ), 2980, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bank ), 10, Utility.Random( 1,15 ), 3084, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bard ), 10, Utility.Random( 1,15 ), 3004, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_smith ), 10, Utility.Random( 1,15 ), 3016, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bow ), 10, Utility.Random( 1,15 ), 3022, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_ship ), 10, Utility.Random( 1,15 ), 2998, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_fletch ), 10, Utility.Random( 1,15 ), 3006, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_heal ), 10, Utility.Random( 1,15 ), 2988, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_inn ), 10, Utility.Random( 1,15 ), 2996, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_gem ), 10, Utility.Random( 1,15 ), 3010, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_book ), 10, Utility.Random( 1,15 ), 2966, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_mage ), 10, Utility.Random( 1,15 ), 2990, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_necro ), 10, Utility.Random( 1,15 ), 2811, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_supply ), 10, Utility.Random( 1,15 ), 3020, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_herb ), 10, Utility.Random( 1,15 ), 3014, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_pen ), 10, Utility.Random( 1,15 ), 3000, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_sew ), 10, Utility.Random( 1,15 ), 2982, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_tavern ), 10, Utility.Random( 1,15 ), 3012, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_tinker ), 10, Utility.Random( 1,15 ), 2984, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_wood ), 10, Utility.Random( 1,15 ), 2992, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StoneWellDeed ), 500, 1, 0xF3A, 0xB97 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RedWellDeed ), 500, 1, 0xF3A, 0xB97 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MarbleWellDeed ), 500, 1, 0xF3A, 0xB97 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BrownWellDeed ), 500, 1, 0xF3A, 0xB97 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackWellDeed ), 500, 1, 0xF3A, 0xB97 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodWellDeed ), 500, 1, 0xF3A, 0xB97 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( InteriorDecorator ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HousePlacementTool ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LawnTools ), 200 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShantyTools ), 150 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlayersHouseTeleporter ), 2000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlayersZTeleporter ), 1000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_post_a ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_post_b ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_merc ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_armor ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bake ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bank ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bard ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_smith ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bow ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_ship ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_fletch ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_heal ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_inn ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_gem ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_book ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_mage ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_necro ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_supply ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_herb ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_pen ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_sew ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_tavern ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_tinker ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_wood ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RedWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarbleWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrownWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodWellDeed ), 250 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSailor : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSailor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Harpoon ), 40, Utility.Random( 3,31 ), 0xF63, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( HarpoonRope ), 2, Utility.Random( 50,250 ), 0x52B1, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( FishingPole ), 15, Utility.Random( 3,31 ), 0xDC0, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( SwordsAndShackles ), 50, Utility.Random( 1,15 ), 0x529D, 0x944 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BoatStain ), 26, Utility.Random( 1,15 ), 0x14E0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sextant ), 13, Utility.Random( 1,15 ), 0x1057, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GrapplingHook ), 58, Utility.Random( 1,15 ), 0x4F40, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DockingLantern ), 58, Utility.Random( 3,31 ), 0x40FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041205", typeof( SmallBoatDeed ), 9500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHighSeas : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHighSeas()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Harpoon ), 20 ); }
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( HarpoonRope ), 1 ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( SeaShell ), 58 );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( DockingLantern ), 29 );}
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( RawFishSteak ), 1 );}
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Fish ), 1 );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( FishingPole ), 7 );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sextant ), 6 );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( GrapplingHook ), 29 );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( PirateChest ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( SunkenChest ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( FishingNet ), Utility.RandomMinMax( 20, 40 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpecialFishingNet ), Utility.RandomMinMax( 60, 80 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( FabledFishingNet ), Utility.RandomMinMax( 100, 120 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( NeptunesFishingNet ), Utility.RandomMinMax( 140, 160 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( PrizedFish ), Utility.RandomMinMax( 60, 120 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( WondrousFish ), Utility.RandomMinMax( 60, 120 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( TrulyRareFish ), Utility.RandomMinMax( 60, 120 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( PeculiarFish ), Utility.RandomMinMax( 60, 120 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpecialSeaweed ), Utility.RandomMinMax( 40, 160 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SunkenBag ), Utility.RandomMinMax( 100, 500 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShipwreckedItem ), Utility.RandomMinMax( 20, 60 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( HighSeasRelic ), Utility.RandomMinMax( 20, 60 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( BoatStain ), 13 );}
				if ( 1 > 0 ){Add( typeof( SwordsAndShackles ), 25 ); }
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MegalodonTooth ), Utility.RandomMinMax( 500, 2000 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( AdmiralsHeartyRum ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShipModelOfTheHMSCape ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SeahorseStatuette ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( GhostShipAnchor ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( AquariumEastAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( LightHouseAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarlinEastAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarlinSouthAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( DolphinSouthSmallAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullEastLargeAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullEastSmallAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullSouthLargeAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullSouthSmallAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( DolphinSouthLargeAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( DolphinEastLargeAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( AquariumSouthAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( DolphinEastSmallAddonDeed ), Utility.RandomMinMax( 200, 800 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( SeaShell ), Utility.RandomMinMax( 100, 120 ) );}
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBKungFu: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKungFu()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BookOfBushido), 140, Utility.RandomMinMax( 1, 5 ), 0x238C, 0 ) );
				Add( new GenericBuyInfo( typeof( BookOfNinjitsu ), 140, Utility.RandomMinMax( 1, 5 ), 0x23A0, 0 ) );
				Add( new GenericBuyInfo( typeof( MysticSpellbook ), 190, Utility.RandomMinMax( 1, 5 ), 0x1A97, 0xB61 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShinobiScroll ), 280, Utility.RandomMinMax( 1, 5 ), 0x5C15, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BambooFlute ), 21, 20, 0x2805, 0 ) );}
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ThrowingWeapon ), 2, Utility.Random( 20, 120 ), 0x52B2, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BookOfBushido ), 70 );
				Add( typeof( BookOfNinjitsu ), 70 );
				Add( typeof( MysticSpellbook ), 90 );
				Add( typeof( ShinobiScroll ), 140 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( MySamuraibook ), Utility.Random( 50, 200 ) );}
				if ( MyServerSettings.BuyChance() ){Add( typeof( MyNinjabook ), Utility.Random( 50, 200 ) );}
				Add( typeof( BambooFlute ), 10 );
				Add( typeof( ThrowingWeapon ), 1 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBaker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBaker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 5, Utility.Random( 1,15 ), 0x103C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ApplePie ), 7, Utility.Random( 1,15 ), 0x1041, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cake ), 13, Utility.Random( 1,15 ), 0x9E9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Muffins ), 3, Utility.Random( 1,15 ), 0x9EA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SackFlour ), 3, Utility.Random( 1,15 ), 0x1039, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FrenchBread ), 5, Utility.Random( 1,15 ), 0x98C, 0 ) ); }
             	if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cookies ), 3, Utility.Random( 1,15 ), 0x160b, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CheesePizza ), 8, 10, 0x1040, 0 ) ); } // OSI just has Pizza
				if ( MyServerSettings.SellChance() ){Add (new GenericBuyInfo( typeof( BowlFlour ), 7, Utility.Random( 1,15 ), 0xA1E, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BreadLoaf ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FrenchBread ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cake ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cookies ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Muffins ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheesePizza ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ApplePie ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PeachCobbler ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Quiche ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dough ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitcher ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SackFlour ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Eggs ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBanker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBanker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "1041243", typeof( ContractOfEmployment ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) );
				Add( new GenericBuyInfo( "1062332", typeof( VendorRentalContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0x672 ) );
				Add( new GenericBuyInfo( "1047016", typeof( CommodityDeed ), 5, Utility.Random( 1,15 ), 0x14F0, 0x47 ) );
				Add (new GenericBuyInfo( typeof( MetalVault ), 5000, Utility.Random( 1,5 ), 0x4FE3, 0 ) );
				Add (new GenericBuyInfo( typeof( MetalSafe ), 5000, Utility.Random( 1,5 ), 0x436, 0 ) );
				Add (new GenericBuyInfo( typeof( IronSafe ), 5000, Utility.Random( 1,5 ), 0x5329, 0 ) );
				Add (new GenericBuyInfo( typeof( Safe ), 500000, Utility.Random( 1,5 ), 0x436, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( GoldBricks ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				Add( typeof( TreasurePile05AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePile04AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePile3AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePile03AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePile2AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePile02AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePile01AddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( TreasurePileAddonDeed ), Utility.Random( 200,600 ) );
				Add( typeof( MetalVault ), Utility.Random( 1000,2000 ) );
				Add( typeof( MetalSafe ), Utility.Random( 1000,2000 ) );
				Add( typeof( IronSafe ), Utility.Random( 1000,2000 ) );
				Add( typeof( Safe ), Utility.Random( 100000,200000 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBard: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBard()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Drums ), 21, Utility.Random( 1,15 ), 0x0E9C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tambourine ), 21, Utility.Random( 1,15 ), 0x0E9E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LapHarp ), 21, Utility.Random( 1,15 ), 0x0EB2, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Lute ), 21, Utility.Random( 1,15 ), 0x0EB3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BambooFlute ), 21, Utility.Random( 1,15 ), 0x2805, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Trumpet ), 21, Utility.Random( 1,15 ), 0x6458, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SongBook ), 24, Utility.Random( 1,5 ), 0x225A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( EnergyCarolScroll ), 32, 1, 0x1F48, 0x96 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( FireCarolScroll ), 32, 1, 0x1F49, 0x96 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( IceCarolScroll ), 32, 1, 0x1F34, 0x96 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( KnightsMinneScroll ), 32, 1, 0x1F31, 0x96 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( PoisonCarolScroll ), 32, 1, 0x1F33, 0x96 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( JarsOfWaxInstrument ), 160, Utility.Random( 1,5 ), 0x1005, 0x845 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( JarsOfWaxInstrument ), 80 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LapHarp ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lute ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Drums ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Harp ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tambourine ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BambooFlute ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Trumpet ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MySongbook ), Utility.Random( 50,200 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SongBook ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EnergyCarolScroll ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FireCarolScroll ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IceCarolScroll ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( KnightsMinneScroll ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PoisonCarolScroll ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ArmysPaeonScroll ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagesBalladScroll ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EnchantingEtudeScroll ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SheepfoeMamboScroll ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SinewyEtudeScroll ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EnergyThrenodyScroll ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FireThrenodyScroll ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IceThrenodyScroll ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PoisonThrenodyScroll ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FoeRequiemScroll ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicFinaleScroll ), 10 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBarkeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBarkeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, Utility.Random( 1,15 ), 0x99F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, Utility.Random( 1,15 ), 0x9C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, Utility.Random( 1,15 ), 0x99B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, Utility.Random( 1,15 ), 0x9C8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, Utility.Random( 1,15 ), 0x9F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 11, Utility.Random( 1,15 ), 0x1F95, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 11, Utility.Random( 1,15 ), 0x1F97, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 11, Utility.Random( 1,15 ), 0x1F99, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 11, Utility.Random( 1,15 ), 0x1F9B, 0 ) ); }
				if ( 1 > 0 ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 11, Utility.Random( 1,15 ), 0x1F9D, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CheeseWheel ), 21, Utility.Random( 1,15 ), 0x97E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CookedBird ), 17, Utility.Random( 1,15 ), 0x9B7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LambLeg ), 8, Utility.Random( 1,15 ), 0x160A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 3, Utility.Random( 1,15 ), 0x15F9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x15FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 2, Utility.Random( 1,15 ), 0x15FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x1600, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfFoodPotatos ), 3, Utility.Random( 1,15 ), 0x1601, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 3, Utility.Random( 1,15 ), 0x1604, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 3, Utility.Random( 1,15 ), 0x1606, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ApplePie ), 7, Utility.Random( 1,15 ), 0x1041, 0 ) ); } //OSI just has Pie, not Apple/Fruit/Meat
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( tarotpoker ), 5, Utility.Random( 1,15 ), 0x12AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Engines.Mahjong.MahjongGame ), 6, Utility.Random( 1,15 ), 0xFAA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backgammon ), 2, Utility.Random( 1,15 ), 0xE1C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dices ), 2, Utility.Random( 1,15 ), 0xFA7, 0x982 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Waterskin ), 5, Utility.Random( 1,15 ), 0xA21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanFighterItem ), 5000, Utility.Random( 1,15 ), 0x1419, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanArcherItem ), 6000, Utility.Random( 1,15 ), 0xF50, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanWizardItem ), 7000, Utility.Random( 1,15 ), 0xE30, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041243", typeof( ContractOfEmployment ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( "a barkeep contract", typeof( BarkeepContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
				Add( new GenericBuyInfo( typeof( TavernTable ), Utility.Random( 900,1100 ), Utility.Random( 10,30 ), 0x55D9, 0 ) );
				if ( Multis.BaseHouse.NewVendorSystem )
					if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1062332", typeof( VendorRentalContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0x672 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCarrots ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmptyPewterBowl ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfFoodPotatos ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfStew ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfTomatoSoup ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BeverageBottle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Jug ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitcher ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GlassMug ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BreadLoaf ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheeseWheel ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ribs ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Peach ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pear ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Grapes ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Apple ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Banana ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Candle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Chessboard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheckerBoard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( tarotpoker ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MahjongGame ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backgammon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dices ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ContractOfEmployment ), 626 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Waterskin ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RomulanAle ), Utility.Random( 20,100 ) ); } // DO NOT WANT?
				Add( typeof( TavernTable ), Utility.Random( Utility.Random( 350,450 ) ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBeekeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBeekeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( JarHoney ), 600, Utility.Random( 1,15 ), 0x9EC, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( Beeswax ), 1000, Utility.Random( 1,15 ), 0x1422, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( apiBeeHiveDeed ), 2000, Utility.Random( 1,10 ), 2330, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( HiveTool ), 100, Utility.Random( 1,15 ), 2549, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( apiSmallWaxPot ), 250, Utility.Random( 1,15 ), 2532, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( apiLargeWaxPot ), 400, Utility.Random( 1,15 ), 2541, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( WaxingPot ), 50, Utility.Random( 1,15 ), 0x142B, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( JarHoney ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Beeswax ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( apiBeeHiveDeed ), 1000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HiveTool ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( apiSmallWaxPot ), 125 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( apiLargeWaxPot ), 200 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WaxingPot ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( ColorCandleShort ), 85 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( ColorCandleLong ), 90 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( Candle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( CandleLarge ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( Candelabra ), 140 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( CandelabraStand ), 210 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( CandleLong ), 80 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( CandleShort ), 75 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( CandleSkull ), 95 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( CandleReligious ), 120 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WallSconce ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( JarsOfWaxMetal ), 80 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( JarsOfWaxLeather ), 80 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( JarsOfWaxInstrument ), 80 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBlacksmith : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBlacksmith()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tongs ), 13, Utility.Random( 1,15 ), 0xFBB, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( SmithHammer ), 21, Utility.Random( 1,15 ), 0x0FB4, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tongs ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmithHammer ), 10 ); } // DO NOT WANT?
				Add( typeof( MagicHammer ), Utility.Random( 300,400 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBowyer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBowyer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( FletcherTools ), 2, Utility.Random( 1,15 ), 0x1F2C, 0xB61 ) );
				Add( new GenericBuyInfo( typeof( ArcherQuiver ), 32, Utility.Random( 1,5 ), Utility.RandomList( 0x2B02, 0x2B03, 0x5770, 0x5770 ), 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( FletcherTools ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ArcherQuiver ), 16 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBButcher : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBButcher()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bacon ), 7, Utility.Random( 1,15 ), 0x979, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ham ), 26, Utility.Random( 1,15 ), 0x9C9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sausage ), 18, Utility.Random( 1,15 ), 0x9C0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RawChickenLeg ), 6, Utility.Random( 1,15 ), 0x1607, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RawBird ), 9, Utility.Random( 1,15 ), 0x9B9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RawPig ), 18, Utility.Random( 1,15 ), 0x9D3, 0xB01 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RawLambLeg ), 9, Utility.Random( 1,15 ), 0x1609, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( RawRibs ), 16, Utility.Random( 1,15 ), 0x9F1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ButcherKnife ), 13, Utility.Random( 1,15 ), 0x13F6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cleaver ), 13, Utility.Random( 1,15 ), 0xEC3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SkinningKnife ), 13, Utility.Random( 1,15 ), 0xEC4, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( RawPig ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RawRibs ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RawLambLeg ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RawChickenLeg ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RawBird ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bacon ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sausage ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ham ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ButcherKnife ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cleaver ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinningKnife ), 7 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBCarpenter: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCarpenter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Hatchet ), 25, Utility.Random( 1,15 ), 0xF44, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LumberAxe ), 27, Utility.Random( 1,15 ), 0xF43, 0x96D ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Nails ), 3, Utility.Random( 1,15 ), 0x102E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Axle ), 2, Utility.Random( 1,15 ), 0x105B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DrawKnife ), 10, Utility.Random( 1,15 ), 0x10E4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Froe ), 10, Utility.Random( 1,15 ), 0x10E5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Scorp ), 10, Utility.Random( 1,15 ), 0x10E7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Inshave ), 10, Utility.Random( 1,15 ), 0x10E6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DovetailSaw ), 12, Utility.Random( 1,15 ), 0x1028, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Saw ), 15, Utility.Random( 1,15 ), 0x1034, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Hammer ), 17, Utility.Random( 1,15 ), 0x102A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, Utility.Random( 1,15 ), 0x102C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmoothingPlane ), 10, Utility.Random( 1,15 ), 0x1032, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( JointingPlane ), 11, Utility.Random( 1,15 ), 0x1030, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( WoodworkingTools ), 10, Utility.Random( 10,30 ), 0x4F52, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AdventurerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F91, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArmsCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BakerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F92, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BeekeeperCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F95, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlacksmithCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BowyerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F97, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ButcherCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F89, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CarpenterCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8A, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FletcherCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F88, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HealerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F98, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HugeCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F86, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JewelerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LibrarianCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F96, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MusicianCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F94, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NecromancerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9A, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ProvisionerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SailorCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9C, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StableCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F87, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SupplyCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TailorCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TavernCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F99, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TinkerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F90, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasureCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F93, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WizardryCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8C, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C43, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C45, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C47, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C89, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x38B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x38D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CCB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireI ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CCD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireJ ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D26, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BF1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C31, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C63, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CAD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CEF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C3B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C65, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C67, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CBF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C4B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C6B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C15, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C2B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C2D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C33, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C5F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C61, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C79, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfI ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfJ ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CAF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfK ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CEB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfL ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CED, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfM ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D05, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C29, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C5D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewCarpenterShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C6F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewCarpenterShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CD7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewCarpenterShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CFB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C51, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C53, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C75, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C77, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CDD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CDF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CFF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D01, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDarkBookShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BF9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDarkBookShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BFB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDarkShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BFD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C7F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C81, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C83, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C85, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C87, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersI ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CBB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersJ ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CBD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersK ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D0B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersL ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D20, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersM ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D22, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersN ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D24, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C27, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C5B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C1B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewHelmShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BFF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewHunterShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C4D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewKitchenShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C19, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewKitchenShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C39, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewOldBookShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x19FF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewPotionShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewRuinedBookShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0xC14, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C35, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C3D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C69, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C7B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D07, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C37, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C7D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D09, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C4F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C73, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CDB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CFD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSupplyShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C57, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSupplyShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C9D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSupplyShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C3F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C6D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTannerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C23, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTannerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C49, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C25, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C59, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C9F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTinkerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C71, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTinkerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CD9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTinkerShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D03, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTortureShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C2F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C17, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C1D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C21, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C55, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C9B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterFancy ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x544F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterWood ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5451, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterWooden ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5453, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterStained ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5455, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterPolished ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5457, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterRustic ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5459, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterDark ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x545B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterLight ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x545D, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hatchet ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LumberAxe ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBox ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmallCrate ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MediumCrate ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeCrate ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenChest ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeTable ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nightstand ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( YewWoodTable ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Throne ), 24 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenThrone ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Stool ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FootStool ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FancyWoodenChairCushion ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenChairCushion ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenChair ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BambooChair ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBench ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Saw ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scorp ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmoothingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DrawKnife ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Froe ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hammer ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Inshave ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodworkingTools ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JointingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MouldingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DovetailSaw ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Axle ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Club ), 13 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBCobbler : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCobbler()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ThighBoots ), 15, Utility.Random( 1,15 ), 0x1711, Utility.RandomNeutralHue() ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Shoes ), 8, Utility.Random( 1,15 ), 0x170f, Utility.RandomNeutralHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Boots ), 10, Utility.Random( 1,15 ), 0x170b, Utility.RandomNeutralHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sandals ), 5, Utility.Random( 1,15 ), 0x170d, Utility.RandomNeutralHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BarbarianBoots ), 15, Utility.Random( 1,5 ), 0x406, 0x220 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherSandals ), 60, Utility.Random( 1,15 ), 0x170d, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherShoes ), 75, Utility.Random( 1,15 ), 0x170f, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherBoots ), 90, Utility.Random( 1,15 ), 0x170b, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherThighBoots ), 105, Utility.Random( 1,15 ), 0x1711, MaterialInfo.PlainLeatherColor() ) ); }
				if ( MyServerSettings.SellChance() && MyServerSettings.MonstersAllowed() ){Add( new GenericBuyInfo( typeof( HikingBoots ), 800, Utility.Random( 1,15 ), 0x2FC4, MaterialInfo.PlainLeatherColor() ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicBoots ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shoes ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Boots ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ThighBoots ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sandals ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BarbarianBoots ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicBoots ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherSandals ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherShoes ), 37 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherBoots ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherThighBoots ), 52 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( LeatherSoftBoots ), 60 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBCook : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCook()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 5, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 5, Utility.Random( 1,15 ), 0x103C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ApplePie ), 7, Utility.Random( 1,15 ), 0x1041, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cake ), 13, Utility.Random( 1,15 ), 0x9E9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Muffins ), 3, Utility.Random( 1,15 ), 0x9EA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CheeseWheel ), 21, Utility.Random( 1,15 ), 0x97E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CookedBird ), 17, Utility.Random( 1,15 ), 0x9B7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LambLeg ), 8, Utility.Random( 1,15 ), 0x160A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, Utility.Random( 1,15 ), 0x1608, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 3, Utility.Random( 1,15 ), 0x15F9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x15FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 2, Utility.Random( 1,15 ), 0x15FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x1600, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfFoodPotatos ), 3, Utility.Random( 1,15 ), 0x1601, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 3, Utility.Random( 1,15 ), 0x1604, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 3, Utility.Random( 1,15 ), 0x1606, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoastPig ), 106, Utility.Random( 1,15 ), 0x9BB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SackFlour ), 3, Utility.Random( 1,15 ), 0x1039, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RollingPin ), 2, Utility.Random( 1,15 ), 0x1043, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FlourSifter ), 2, Utility.Random( 1,15 ), 0x103E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1044567", typeof( Skillet ), 3, Utility.Random( 1,15 ), 0x97F, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheeseWheel ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CookedBird ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoastPig ), 53 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cake ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SackFlour ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BreadLoaf ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ChickenLeg ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LambLeg ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Skillet ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FlourSifter ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RollingPin ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Muffins ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ApplePie ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCarrots ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmptyPewterBowl ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfFoodPotatos ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfStew ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfTomatoSoup ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBFarmer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFarmer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cabbage ), 5, Utility.Random( 1,15 ), 0xC7B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cantaloupe ), 6, Utility.Random( 1,15 ), 0xC79, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Carrot ), 3, Utility.Random( 1,15 ), 0xC78, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HoneydewMelon ), 7, Utility.Random( 1,15 ), 0xC74, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Squash ), 3, Utility.Random( 1,15 ), 0xC72, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lettuce ), 5, Utility.Random( 1,15 ), 0xC70, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Onion ), 3, Utility.Random( 1,15 ), 0xC6D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pumpkin ), 11, Utility.Random( 1,15 ), 0xC6A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GreenGourd ), 3, Utility.Random( 1,15 ), 0xC66, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( YellowGourd ), 3, Utility.Random( 1,15 ), 0xC64, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Watermelon ), 7, Utility.Random( 1,15 ), 0xC5C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Eggs ), 3, Utility.Random( 1,15 ), 0x9B5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, Utility.Random( 1,15 ), 0x9AD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Peach ), 3, Utility.Random( 1,15 ), 0x9D2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pear ), 3, Utility.Random( 1,15 ), 0x994, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lemon ), 3, Utility.Random( 1,15 ), 0x1728, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lime ), 3, Utility.Random( 1,15 ), 0x172A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Grapes ), 3, Utility.Random( 1,15 ), 0x9D1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Apple ), 3, Utility.Random( 1,15 ), 0x9D0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SheafOfHay ), 2, Utility.Random( 1,15 ), 0xF36, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitcher ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Eggs ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Apple ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Grapes ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Watermelon ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( YellowGourd ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreenGourd ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pumpkin ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Onion ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lettuce ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Squash ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Carrot ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HoneydewMelon ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cantaloupe ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cabbage ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lemon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lime ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Peach ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pear ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SheafOfHay ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pumpkin ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PumpkinLarge ), Utility.Random( 10,25 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PumpkinTall ), Utility.Random( 35,50 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PumpkinGreen ), Utility.Random( 60,75 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PumpkinGiant ), Utility.Random( 85,100 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBFisherman : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFisherman()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RawFishSteak ), 3, Utility.Random( 1,15 ), 0x97A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 1,15 ), 0x9CC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 1,15 ), 0x9CD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 1,15 ), 0x9CE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 1,15 ), 0x9CF, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( FishingPole ), 15, Utility.Random( 1,15 ), 0xDC0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GrapplingHook ), 58, Utility.Random( 1,15 ), 0x4F40, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( RawFishSteak ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Fish ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FishingPole ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GrapplingHook ), 29 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBFortuneTeller : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFortuneTeller()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 10,60 ), 0xE21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 1,15 ), 0x25FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,15 ), 0xF0B, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserHealPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RefreshPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Garlic ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ginseng ), 2 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBFurtrader : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBFurtrader()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Furs ), 5, Utility.Random( 1,25 ), 0x11F4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FursWhite ), 8, Utility.Random( 1,25 ), 0x11F4, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurCape ), 16, Utility.Random( 1,5 ), 0x230A, 0x907 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurRobe ), 20, Utility.Random( 1,5 ), 0x1F03, 0x907 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurBoots ), 10, Utility.Random( 1,5 ), 0x2307, 0x907 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurCap ), 8, Utility.Random( 1,5 ), 0x1DB9, 0x907 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurSarong ), 14, Utility.Random( 1,5 ), 0x230C, 0x907 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurArms ), 100, Utility.Random( 1,15 ), 0x2B77, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurTunic ), 121, Utility.Random( 1,15 ), 0x2B79, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FurLegs ), 100, Utility.Random( 1,15 ), 0x2B78, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BarbarianBoots ), 15, Utility.Random( 1,5 ), 0x406, 0x220 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurCape ), 18, Utility.Random( 1,5 ), 0x230A, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurRobe ), 24, Utility.Random( 1,5 ), 0x1F03, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurBoots ), 12, Utility.Random( 1,5 ), 0x2307, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurCap ), 16, Utility.Random( 1,5 ), 0x1DB9, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurSarong ), 16, Utility.Random( 1,5 ), 0x230C, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurArms ), 100, Utility.Random( 1,15 ), 0x2B77, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurTunic ), 121, Utility.Random( 1,15 ), 0x2B79, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteFurLegs ), 100, Utility.Random( 1,15 ), 0x2B78, 0x481 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BearMask ), Utility.Random( 28,50 ), Utility.Random( 1,5 ), 0x1545, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DeerMask ), Utility.Random( 28,50 ), Utility.Random( 1,5 ), 0x1547, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WolfMask ), Utility.Random( 28,50 ), Utility.Random( 1,5 ), 0x2B6D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DemonSkin ), 1235, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DragonSkin ), 1235, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NightmareSkin ), 1228, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SerpentSkin ), 1214, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TrollSkin ), 1221, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( UnicornSkin ), 1228, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Furs ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FursWhite ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurCape ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurCape ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurRobe ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurRobe ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurBoots ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurBoots ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurSarong ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurSarong ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurCap ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurCap ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurArms ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurTunic ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FurLegs ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurArms ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurTunic ), 60 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteFurLegs ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BearMask ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DeerMask ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WolfMask ), 14 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBGlassblower : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGlassblower()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( "Crafting Glass With Glassblowing", typeof( GlassblowingBook ), 10637, Utility.Random( 1,15 ), 0xFF4, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( "Finding Glass-Quality Sand", typeof( SandMiningBook ), 10637, Utility.Random( 1,15 ), 0xFF4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1044608", typeof( Blowpipe ), 21, Utility.Random( 1,15 ), 0xE8A, 0x3B9 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Monocle ), 24, Utility.Random( 1,25 ), 0x543B, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( GlassblowingBook ), 5000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SandMiningBook ), 5000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Blowpipe ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Monocle ), 12 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHairStylist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHairStylist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "special beard dye", typeof( SpecialBeardDye ), 500, Utility.Random( 1,15 ), 0xE26, 0 ) );
				Add( new GenericBuyInfo( "special hair dye", typeof( SpecialHairDye ), 500, Utility.Random( 1,15 ), 0xE26, 0 ) );
				Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 100, Utility.Random( 1,15 ), 0xEFF, 0 ) );
				Add( new GenericBuyInfo( "hair dye bottle", typeof( HairDyeBottle ), 1000, Utility.Random( 1,15 ), 0xE0F, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DisguiseKit ), 700, Utility.Random( 1,5 ), 0xE05, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( HairDye ), 50 );
				Add( typeof( SpecialBeardDye ), 250 );
				Add( typeof( SpecialHairDye ), 250 );
				Add( typeof( HairDyeBottle ), 300 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHealer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHealer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 10,150 ), 0xE21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 1,15 ), 0x25FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,15 ), 0xF0B, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GraveShovel ), 12, Utility.Random( 1,15 ), 0xF39, 0x966 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserHealPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RefreshPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Garlic ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ginseng ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FirstAidKit ), Utility.Random( 100,250 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBDruid : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDruid()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 10,150 ), 0xE21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 1,15 ), 0x25FD, 0 ) ); }
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 10,100 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 10,100 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 10,100 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 10,100 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 10,100 ), 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 10,100 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 10,100 ), 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 10,100 ), 0xF8C, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 10,100 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( ButterflyWings ), 6, Utility.Random( 10,100 ), 0x3002, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 10,100 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( FairyEgg ), 6, Utility.Random( 10,100 ), 0x2FDB, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 10,100 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 10,100 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 10,100 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SeaSalt ), 6, Utility.Random( 10,100 ), 0x2FE9, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 10,100 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 10,100 ), 0x2FE0, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,15 ), 0xF0B, 0 ) ); }
				Add( new GenericBuyInfo( typeof( DruidCauldron ), 16, Utility.Random( 1,15 ), 0x640A, 0 ) );
				Add( new GenericBuyInfo( typeof( BookDruidBrewing ), 50, Utility.Random( 1,15 ), 0x5688, 0x85D ) );
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( AppleTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( CherryBlossomTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( DarkBrownTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( GreyTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( LightBrownTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( PeachTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( PearTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				Add( new GenericBuyInfo( typeof( DruidPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x8A1 ) );
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserHealPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RefreshPotion ), 7 ); } // DO NOT WANT?
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 1 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( ButterflyWings ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( FairyEgg ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SeaSalt ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DruidCauldron ), 8 ); } // DO NOT WANT?
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBDruidTree : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDruidTree()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 10,150 ), 0xE21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 1,15 ), 0x25FD, 0 ) ); }
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 10,100 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 10,100 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 10,100 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 10,100 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 10,100 ), 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 10,100 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 10,100 ), 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 10,100 ), 0xF8C, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 10,100 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( ButterflyWings ), 6, Utility.Random( 10,100 ), 0x3002, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 10,100 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( FairyEgg ), 6, Utility.Random( 10,100 ), 0x2FDB, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 10,100 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 10,100 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 10,100 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SeaSalt ), 6, Utility.Random( 10,100 ), 0x2FE9, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 10,100 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 10,100 ), 0x2FE0, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,15 ), 0xF0B, 0 ) ); }
				Add( new GenericBuyInfo( typeof( DruidCauldron ), 16, Utility.Random( 1,15 ), 0x640A, 0 ) );
				Add( new GenericBuyInfo( typeof( BookDruidBrewing ), 50, Utility.Random( 1,15 ), 0x5688, 0x85D ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				Add( new GenericBuyInfo( typeof( DruidPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x8A1 ) );
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AppleTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CherryBlossomTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DarkBrownTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GreyTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LightBrownTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PeachTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PearTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ShieldOfEarthPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x300 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( WoodlandProtectionPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x7E2 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ProtectiveFairyPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x9FF ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( HerbalHealingPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x279 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GraspingRootsPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x83F ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( BlendWithForestPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x59C ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( SwarmOfInsectsPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xA70 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( VolcanicEruptionPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x54E ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( TreefellowPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x223 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( StoneCirclePotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x396 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( DruidicRunePotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x487 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( LureStonePotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x967 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NaturesPassagePotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x48B ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( MushroomGatewayPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x3B7 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( RestorativeSoilPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x479 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( FireflyPotion ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x491 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserHealPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RefreshPotion ), 7 ); } // DO NOT WANT?
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 1 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( ButterflyWings ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( FairyEgg ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SeaSalt ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DruidCauldron ), 8 ); } // DO NOT WANT?
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHerbalist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHerbalist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 10,100 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 10,100 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 10,100 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 10,100 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 10,100 ), 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 10,100 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 10,100 ), 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 10,100 ), 0xF8C, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 10,100 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( ButterflyWings ), 6, Utility.Random( 10,100 ), 0x3002, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 10,100 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( FairyEgg ), 6, Utility.Random( 10,100 ), 0x2FDB, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 10,100 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 10,100 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 10,100 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SeaSalt ), 6, Utility.Random( 10,100 ), 0x2FE9, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 10,100 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 10,100 ), 0x2FE0, 0 ) );
				Add( new GenericBuyInfo( typeof( MortarPestle ), 8, Utility.Random( 1,15 ), 0x4CE9, 0 ) );
				Add( new GenericBuyInfo( typeof( DruidCauldron ), 16, Utility.Random( 1,15 ), 0x640A, 0 ) );
				Add( new GenericBuyInfo( typeof( BookDruidBrewing ), 50, Utility.Random( 1,15 ), 0x5688, 0x85D ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemistPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0xAFE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DruidPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x8A1 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingPlantA ), Utility.Random( 5000,10000 ), 1, 0x113F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingPlantB ), Utility.Random( 5000,10000 ), 1, 0x1151, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingPlantC ), Utility.Random( 5000,10000 ), 1, 0x1164, 0 ) ); }

				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( HomePlants_Flower ), Utility.Random( 50, 100 ), Utility.Random( 1, 5 ), 0x11C6, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( HomePlants_Leaf ), Utility.Random( 50, 100 ), Utility.Random( 1, 5 ), 0x11C6, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( HomePlants_Mushroom ), Utility.Random( 50, 100 ), Utility.Random( 1, 5 ), 0x11C6, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( HomePlants_Cactus ), Utility.Random( 50, 100 ), Utility.Random( 1, 5 ), 0x11C6, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( HomePlants_Lilly ), Utility.Random( 50, 100 ), Utility.Random( 1, 5 ), 0x11C6, 0 ) ); }
				if ( SetStock.SellChance() ){Add( new GenericBuyInfo( typeof( HomePlants_Grass ), Utility.Random( 50, 100 ), Utility.Random( 1, 5 ), 0x11C6, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 1 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( ButterflyWings ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( FairyEgg ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SeaSalt ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( MortarPestle ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DruidCauldron ), 8 ); } // DO NOT WANT?
				Add( typeof( HomePlants_Flower ), Utility.Random( 10, 25 ) );
				Add( typeof( HomePlants_Leaf ), Utility.Random( 10, 25 ) );
				Add( typeof( HomePlants_Mushroom ), Utility.Random( 10, 25 ) );
				Add( typeof( HomePlants_Cactus ), Utility.Random( 10, 25 ) );
				Add( typeof( HomePlants_Lilly ), Utility.Random( 10, 25 ) );
				Add( typeof( HomePlants_Grass ), Utility.Random( 10, 25 ) );
				Add( typeof( SpecialSeaweed ), Utility.Random( 15, 35 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( HangingPlantA ), Utility.Random( 10, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HangingPlantB ), Utility.Random( 10, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HangingPlantC ), Utility.Random( 10, 100 ) ); } // DO NOT WANT?
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHolyMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHolyMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Spellbook ), 18, Utility.Random( 1,15 ), 0xEFA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ScribesPen ), 8, Utility.Random( 1,15 ), 0x2051, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, Utility.Random( 1,15 ), 0x1718, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WitchHat ), 11, Utility.Random( 1,15 ), 0x2FC3, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RecallRune ), 15, Utility.Random( 1,15 ), 0x1f14, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 1,15 ), 0x266F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 1,15 ), 0xF7B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 1,15 ), 0xF86, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 1,15 ), 0xF88, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 1,15 ), 0xF8D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 1,15 ), 0xF8C, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( reagents_magic_jar1 ), 2000, Utility.Random( 1,15 ), 0x1007, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length && i < 8; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), Utility.Random( 1,15 ), itemID, 0 ) ); }
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicTalisman ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackPearl ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bloodmoss ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MandrakeRoot ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Garlic ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ginseng ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nightshade ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpidersSilk ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( SulfurousAsh ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RecallRune ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Spellbook ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( MysticalPearl ), 250 ); } // DO NOT WANT?

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					if ( MyServerSettings.BuyChance() ){Add( types[i], ((i / 8) + 1) * 4 ); } // DO NOT WANT?

				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ClumsyMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CreateFoodMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FeebleMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HealMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicArrowMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( NightSightMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ReactiveArmorMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WeaknessMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AgilityMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CunningMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CureMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HarmMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicTrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUntrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ProtectionMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( StrengthMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BlessMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireballMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicLockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUnlockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TelekinesisMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TeleportMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WallofStoneMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchCureMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchProtectionMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CurseMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireFieldMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GreaterHealMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( LightningMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaDrainMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RecallMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BladeSpiritsMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( IncognitoMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicReflectionMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MindBlastMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonCreatureMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyBoltMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ExplosionMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( InvisibilityMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MarkMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassCurseMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeFieldMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RevealMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ChainLightningMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyFieldMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FlameStrikeMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GateTravelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaVampireMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassDispelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MeteorSwarmMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PolymorphMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AirElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthquakeMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyVortexMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ResurrectionMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonDaemonMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WaterElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MySpellbook ), Utility.Random( 100,500 ) ); } // DO NOT WANT?
				Add( typeof( TomeOfWands ), Utility.Random( 100,400 ) );
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStaff ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStick ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRuneCasting: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRuneCasting()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( RuneMagicBook ), 500 );
				Add( typeof( RuneJournal ), 500 );
				Add( typeof( RuneBag ), 200 );
				Add( typeof( An ), 50 );
				Add( typeof( Bet ), 50 );
				Add( typeof( Corp ), 50 );
				Add( typeof( Des ), 50 );
				Add( typeof( Ex ), 50 );
				Add( typeof( Flam ), 50 );
				Add( typeof( Grav ), 50 );
				Add( typeof( Hur ), 50 );
				Add( typeof( In ), 50 );
				Add( typeof( Jux ), 50 );
				Add( typeof( Kal ), 50 );
				Add( typeof( Lor ), 50 );
				Add( typeof( Mani ), 50 );
				Add( typeof( Nox ), 50 );
				Add( typeof( Ort ), 50 );
				Add( typeof( Por ), 50 );
				Add( typeof( Quas ), 50 );
				Add( typeof( Rel ), 50 );
				Add( typeof( Sanct ), 50 );
				Add( typeof( Tym ), 50 );
				Add( typeof( Uus ), 50 );
				Add( typeof( Vas ), 50 );
				Add( typeof( Wis ), 50 );
				Add( typeof( Xen ), 50 );
				Add( typeof( Ylem ), 50 );
				Add( typeof( Zu ), 50 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBEnchanter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBEnchanter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( ClumsyMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CreateFoodMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( FeebleMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HealMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( MagicArrowMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( NightSightMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( ReactiveArmorMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( WeaknessMagicStaff ), Utility.Random( 100,200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( AgilityMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CunningMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CureMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HarmMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( MagicTrapMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( MagicUntrapMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( ProtectionMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( StrengthMagicStaff ), Utility.Random( 200,400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( BlessMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( FireballMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( MagicLockMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( MagicUnlockMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( PoisonMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( TelekinesisMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( TeleportMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( WallofStoneMagicStaff ), Utility.Random( 300,600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( ArchCureMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( ArchProtectionMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( CurseMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( FireFieldMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( GreaterHealMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( LightningMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( ManaDrainMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( RecallMagicStaff ), Utility.Random( 400,800 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( BladeSpiritsMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( DispelFieldMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( IncognitoMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( MagicReflectionMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( MindBlastMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( ParalyzeMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( PoisonFieldMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( SummonCreatureMagicStaff ), Utility.Random( 500,1000 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( DispelMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( EnergyBoltMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( ExplosionMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( InvisibilityMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( MarkMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( MassCurseMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( ParalyzeFieldMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellRareChance() ){ Add( new GenericBuyInfo( typeof( RevealMagicStaff ), Utility.Random( 600,1200 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( ChainLightningMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EnergyFieldMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( FlameStrikeMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GateTravelMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( ManaVampireMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( MassDispelMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( MeteorSwarmMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( PolymorphMagicStaff ), Utility.Random( 700,1400 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }

				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( AirElementalMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EarthElementalMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EarthquakeMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EnergyVortexMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( FireElementalMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( ResurrectionMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( SummonDaemonMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( WaterElementalMagicStaff ), Utility.Random( 800,1600 ), 1, Utility.RandomList( 0xDF2, 0xDF3, 0xDF4, 0xDF5 ), 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHouseDeed: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHouseDeed()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBInnKeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBInnKeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, Utility.Random( 1,15 ), 0x99F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, Utility.Random( 1,15 ), 0x9C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, Utility.Random( 1,15 ), 0x99B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, Utility.Random( 1,15 ), 0x9C8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, Utility.Random( 1,15 ), 0x9F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 11, Utility.Random( 1,15 ), 0x1F95, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 11, Utility.Random( 1,15 ), 0x1F97, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 11, Utility.Random( 1,15 ), 0x1F99, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 11, Utility.Random( 1,15 ), 0x1F9B, 0 ) ); }
				if ( 1 > 0 ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 11, Utility.Random( 1,15 ), 0x1F9D, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CheeseWheel ), 21, Utility.Random( 1,15 ), 0x97E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CookedBird ), 17, Utility.Random( 1,15 ), 0x9B7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LambLeg ), 8, Utility.Random( 1,15 ), 0x160A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, Utility.Random( 1,15 ), 0x1608, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ribs ), 7, Utility.Random( 1,15 ), 0x9F2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 3, Utility.Random( 1,15 ), 0x15F9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x15FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 2, Utility.Random( 1,15 ), 0x15FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x1600, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfFoodPotatos ), 3, Utility.Random( 1,15 ), 0x1601, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 3, Utility.Random( 1,15 ), 0x1604, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 3, Utility.Random( 1,15 ), 0x1606, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ApplePie ), 7, Utility.Random( 1,15 ), 0x1041, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Peach ), 3, Utility.Random( 1,15 ), 0x9D2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pear ), 3, Utility.Random( 1,15 ), 0x994, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Grapes ), 3, Utility.Random( 1,15 ), 0x9D1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Apple ), 3, Utility.Random( 1,15 ), 0x9D0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Banana ), 2, Utility.Random( 1,15 ), 0x171F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Torch ), 7, Utility.Random( 1,15 ), 0xF6B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Candle ), 6, Utility.Random( 1,15 ), 0xA28, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backpack ), 15, Utility.Random( 1,15 ), 0x53D5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( tarotpoker ), 5, Utility.Random( 1,15 ), 0x12AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backgammon ), 2, Utility.Random( 1,15 ), 0xE1C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dices ), 2, Utility.Random( 1,15 ), 0xFA7, 0x982 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Engines.Mahjong.MahjongGame ), 6, Utility.Random( 1,15 ), 0xFAA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanFighterItem ), 5000, Utility.Random( 1,15 ), 0x1419, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanArcherItem ), 6000, Utility.Random( 1,15 ), 0xF50, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanWizardItem ), 7000, Utility.Random( 1,15 ), 0xE30, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041243", typeof( ContractOfEmployment ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "a barkeep contract", typeof( BarkeepContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
				if ( Multis.BaseHouse.NewVendorSystem )
					if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1062332", typeof( VendorRentalContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0x672 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BeverageBottle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Jug ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitcher ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GlassMug ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BreadLoaf ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheeseWheel ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ribs ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Peach ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pear ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Grapes ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Apple ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Banana ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Torch ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Candle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( tarotpoker ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MahjongGame ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Chessboard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheckerBoard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backgammon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dices ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ContractOfEmployment ), 626 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCarrots ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmptyPewterBowl ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfFoodPotatos ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfStew ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfTomatoSoup ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBJewel: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBJewel()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldRing ), 27, Utility.Random( 1,15 ), 0x4CFA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Necklace ), 26, Utility.Random( 1,15 ), 0x4CFE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldNecklace ), 27, Utility.Random( 1,15 ), 0x4CFF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldBeadNecklace ), 27, Utility.Random( 1,15 ), 0x4CFD, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Beads ), 27, Utility.Random( 1,15 ), 0x4CFE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldBracelet ), 27, Utility.Random( 1,15 ), 0x4CF1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldEarrings ), 27, Utility.Random( 1,15 ), 0x4CFB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ),  68, Utility.Random( 1,15 ), 0x1ED0, 0, new object[] {  500 } ) ); } // 500 charges
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 131, Utility.Random( 1,15 ), 0x1ED0, 0, new object[] { 1000 } ) ); } // 1000 charges
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 256, Utility.Random( 1,15 ), 0x1ED0, 0, new object[] { 2000 } ) ); } // 2000 charges
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1060740", typeof( ReceiverCrystal ), 6, Utility.Random( 1,15 ), 0x1ED0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StarSapphire ), 125, Utility.Random( 1,15 ), 0xF21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Emerald ), 100, Utility.Random( 1,15 ), 0xF10, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sapphire ), 100, Utility.Random( 1,15 ), 0xF19, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ruby ), 75, Utility.Random( 1,15 ), 0xF13, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Citrine ), 50, Utility.Random( 1,15 ), 0xF15, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Amethyst ), 100, Utility.Random( 1,15 ), 0xF16, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tourmaline ), 75, Utility.Random( 1,15 ), 0xF2D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Amber ), 50, Utility.Random( 1,15 ), 0xF25, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Diamond ), 200, Utility.Random( 1,15 ), 0xF26, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Crystals ), 5 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( Amber ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Amethyst ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Citrine ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Diamond ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Emerald ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ruby ), 37 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sapphire ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphire ), 62 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tourmaline ), 47 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Krystal ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldRing ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverRing ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Necklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldNecklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldBeadNecklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverNecklace ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverBeadNecklace ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Beads ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldBracelet ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverBracelet ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldEarrings ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverEarrings ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.SellChance() ){Add( typeof( MysticalPearl ), 500 ); } // DO NOT WANT?
				if ( MyServerSettings.SellChance() ){Add( typeof( LargeCrystal ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				Add( typeof( MagicJewelryRing ), Utility.Random( 50,300 ) );
				Add( typeof( MagicJewelryCirclet ), Utility.Random( 50,300 ) );
				Add( typeof( MagicJewelryNecklace ), Utility.Random( 50,300 ) );
				Add( typeof( MagicJewelryEarrings ), Utility.Random( 50,300 ) );
				Add( typeof( MagicJewelryBracelet ), Utility.Random( 50,300 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( AgapiteAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AgapiteBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AgapiteRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AgapiteEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmberAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmberBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmberRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmberEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrassAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrassBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrassRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrassEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BronzeAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BronzeBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BronzeRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BronzeEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CaddelliteAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CaddelliteBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CaddelliteRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CaddelliteEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CopperAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CopperBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CopperRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CopperEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DiamondAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DiamondBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DiamondRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DiamondEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DullCopperAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DullCopperBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DullCopperRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DullCopperEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldenEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadeAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadeBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadeRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadeEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MithrilAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MithrilBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MithrilRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MithrilEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NepturiteAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NepturiteBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NepturiteRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NepturiteEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ObsidianAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ObsidianBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ObsidianRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ObsidianEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PearlAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PearlBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PearlRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PearlEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphireAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphireBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphireRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphireEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShadowIronAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShadowIronBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShadowIronRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShadowIronEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilveryAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilveryBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilveryRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilveryEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphireAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphireBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphireRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphireEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SteelAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SteelBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SteelRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SteelEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TourmalineAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TourmalineBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TourmalineRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TourmalineEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ValoriteAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ValoriteBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ValoriteRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ValoriteEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VeriteAmulet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VeriteBracelet ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VeriteRing ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VeriteEarrings ), Utility.Random( 11,16 ) ); } // DO NOT WANT?
				Add( typeof( DrakkhenEggRed ), Utility.Random( 8000,10000 ) );
				Add( typeof( DrakkhenEggBlack ), Utility.Random( 8000,10000 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBWarriorGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWarriorGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "warhorse", typeof( Warhorse ), 10000, Utility.Random( 1,10 ), 0x55DC, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBKeeperOfChivalry : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKeeperOfChivalry()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BookOfChivalry ), 140, Utility.Random( 1,15 ), 0x2252, 0 ) );
				Add( new GenericBuyInfo( "silver griffon", typeof( PaladinWarhorse ), 10000, Utility.Random( 1,10 ), 0x4C59, 0x99B ) );
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GwennoGraveAddonDeed ), Utility.Random( 5000,10000 ), 1, 0x14F0, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( MyPaladinbook ), Utility.Random( 50,200 ) ); } // DO NOT WANT?
				Add( typeof( BookOfChivalry ), 70 );
				Add( typeof( HolyManSpellbook ), Utility.Random( 50,200 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBLeatherWorker: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBLeatherWorker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Waterskin ), 5, Utility.Random( 1,15 ), 0xA21, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DemonSkin ), 1235, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "demon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DragonSkin ), 1235, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "dragon skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NightmareSkin ), 1228, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "nightmare skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SerpentSkin ), 1214, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "serpent skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TrollSkin ), 1221, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "troll skin", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( UnicornSkin ), 1228, Utility.Random( 1,10 ), 0x1081, MaterialInfo.GetMaterialColor( "unicorn skin", "", 0 ) ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( ThighBoots ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicBoots ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicBelt ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicSash ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( ThrowingGloves ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( PugilistGlove ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( PugilistGloves ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Waterskin ), 2 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMapmaker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMapmaker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlankMap ), 5, Utility.Random( 1,15 ), 0x14EC, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( MapmakersPen ), 8, Utility.Random( 1,15 ), 0x2052, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( MasterSkeletonsKey ), Utility.Random( 100,500 ), 1, 0x410B, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( MapmakersPen ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlankMap ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CityMap ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LocalMap ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMap ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PresetMapEntry ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapLodor ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapSosaria ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapBottle ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapSerpent ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapUmber ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapAmbrosia ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapIslesOfDread ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapSavage ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WorldMapUnderworld ), Utility.Random( 20,300 ) ); } // DO NOT WANT?
				Add( typeof( AlternateRealityMap ), Utility.Random( 500,1000 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMiller : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMiller()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( SackFlour ), 3, Utility.Random( 1,15 ), 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( SheafOfHay ), 2, Utility.Random( 1,15 ), 0xF36, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( SackFlour ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SheafOfHay ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMiner: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMiner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bag ), 6, Utility.Random( 1,15 ), 0xE76, 0xABE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Candle ), 6, Utility.Random( 1,15 ), 0xA28, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Torch ), 8, Utility.Random( 1,15 ), 0xF6B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lantern ), 2, Utility.Random( 1,15 ), 0xA25, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pickaxe ), 25, Utility.Random( 1,15 ), 0xE86, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Shovel ), 12, Utility.Random( 1,15 ), 0xF39, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( OreShovel ), 10, Utility.Random( 1,15 ), 0xF39, 0x96D ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pickaxe ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shovel ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OreShovel ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lantern ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Torch ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bag ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Candle ), 3 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMonk : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMonk()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( MonkRobe ), 136, Utility.Random( 1,15 ), 0x0289, 0x21E ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBPlayerBarkeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBPlayerBarkeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, Utility.Random( 1,15 ), 0x99F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, Utility.Random( 1,15 ), 0x9C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, Utility.Random( 1,15 ), 0x99B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, Utility.Random( 1,15 ), 0x9C8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, Utility.Random( 1,15 ), 0x9F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 11, Utility.Random( 1,15 ), 0x1F95, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 11, Utility.Random( 1,15 ), 0x1F97, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 11, Utility.Random( 1,15 ), 0x1F99, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 11, Utility.Random( 1,15 ), 0x1F9B, 0 ) ); }
				if ( 1 > 0 ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 11, Utility.Random( 1,15 ), 0x1F9D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( tarotpoker ), 5, Utility.Random( 1,15 ), 0x12AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backgammon ), 2, Utility.Random( 1,15 ), 0xE1C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dices ), 2, Utility.Random( 1,15 ), 0xFA7, 0x982 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Engines.Mahjong.MahjongGame ), 6, Utility.Random( 1,15 ), 0xFAA, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBProvisioner : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBProvisioner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1060834", typeof( Engines.Plants.PlantBowl ), 2, Utility.Random( 1,15 ), 0x15FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Arrow ), 2, Utility.Random( 1,15 ), 0xF3F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bolt ), 5, Utility.Random( 1,15 ), 0x1BFB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backpack ), 15, Utility.Random( 1,15 ), 0x53D5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pouch ), 6, Utility.Random( 1,15 ), 0xE79, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Bag ), 6, Utility.Random( 1,15 ), 0xE76, 0xABE ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( BigBag ), Utility.Random( 6,10 ), Utility.Random( 1,5 ), 0x5776, 0xB61 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( LargeBag ), Utility.Random( 6,10 ), Utility.Random( 1,5 ), 0x1E3F, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GiantBag ), Utility.Random( 6,10 ), Utility.Random( 1,5 ), 0x1248, 0xB61 ) ); }
				if ( MyServerSettings.SellRareChance() && Utility.RandomBool() ){Add( new GenericBuyInfo( typeof( EnormousBag ), Utility.Random( 12,20 ), 1, 0x55DD, 0xB61 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( LargeSack ), Utility.Random( 6,10 ), Utility.Random( 1,5 ), 0x1C10, 0xB61 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( LargeBackpack ), Utility.Random( 6,10 ), Utility.Random( 1,5 ), 0x4C53, 0xB61 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Candle ), 6, Utility.Random( 1,15 ), 0xA28, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Torch ), 8, Utility.Random( 1,15 ), 0xF6B, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( TenFootPole ), Utility.Random( 500,1000 ), Utility.Random( 1,15 ), 0xE8A, 0x972 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lantern ), 2, Utility.Random( 1,15 ), 0xA25, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lockpick ), 12, Utility.Random( 1,15 ), 0x14FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FloppyHat ), 7, Utility.Random( 1,15 ), 0x1713, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WideBrimHat ), 8, Utility.Random( 1,15 ), 0x1714, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cap ), 10, Utility.Random( 1,15 ), 0x1715, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TallStrawHat ), 8, Utility.Random( 1,15 ), 0x1716, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StrawHat ), 7, Utility.Random( 1,15 ), 0x1717, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardsHat ), 11, Utility.Random( 1,15 ), 0x1718, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WitchHat ), 11, Utility.Random( 1,15 ), 0x2FC3, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherCap ), 10, Utility.Random( 1,15 ), 0x1DB9, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FeatheredHat ), 10, Utility.Random( 1,15 ), 0x171A, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TricorneHat ), 8, Utility.Random( 1,15 ), 0x171B, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PirateHat ), 8, Utility.Random( 1,15 ), 0x2FBC, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bandana ), 6, Utility.Random( 1,15 ), 0x1540, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SkullCap ), 7, Utility.Random( 1,15 ), 0x1544, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ThrowingWeapon ), 2, Utility.Random( 20, 120 ), 0x52B2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LambLeg ), 8, Utility.Random( 1,15 ), 0x160A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, Utility.Random( 1,15 ), 0x1608, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CookedBird ), 17, Utility.Random( 1,15 ), 0x9B7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, Utility.Random( 1,15 ), 0x99F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, Utility.Random( 1,15 ), 0x9C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, Utility.Random( 1,15 ), 0x99B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, Utility.Random( 1,15 ), 0x9C8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pear ), 3, Utility.Random( 1,15 ), 0x994, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Apple ), 3, Utility.Random( 1,15 ), 0x9D0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Waterskin ), 5, Utility.Random( 1,15 ), 0xA21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RedBook ), 15, Utility.Random( 1,15 ), 0xFF1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlueBook ), 15, Utility.Random( 1,15 ), 0xFF2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TanBook ), 15, Utility.Random( 1,15 ), 0xFF0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBox ), 14, Utility.Random( 1,15 ), 0xE7D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Key ), 2, Utility.Random( 1,15 ), 0x100E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MerchantCrate ), 500, 1, 0xE3D, 0x83F ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bedroll ), 5, Utility.Random( 1,15 ), 0xA59, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmallTent ), 200, Utility.Random( 1,5 ), 0x1914, Utility.RandomList( 0x96D, 0x96E, 0x96F, 0x970, 0x971, 0x972, 0x973, 0x974, 0x975, 0x976, 0x977, 0x978, 0x979, 0x97A, 0x97B, 0x97C, 0x97D, 0x97E ) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CampersTent ), 500, Utility.Random( 1,5 ), 0x0A59, Utility.RandomList( 0x96D, 0x96E, 0x96F, 0x970, 0x971, 0x972, 0x973, 0x974, 0x975, 0x976, 0x977, 0x978, 0x979, 0x97A, 0x97B, 0x97C, 0x97D, 0x97E ) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Kindling ), 2, Utility.Random( 1,15 ), 0xDE1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( tarotpoker ), 5, Utility.Random( 1,15 ), 0x12AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backgammon ), 2, Utility.Random( 1,15 ), 0xE1C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Engines.Mahjong.MahjongGame ), 6, Utility.Random( 1,15 ), 0xFAA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dices ), 2, Utility.Random( 1,15 ), 0xFA7, 0x982 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmallBagBall ), 3, Utility.Random( 1,15 ), 0x2256, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LargeBagBall ), 3, Utility.Random( 1,15 ), 0x2257, 0 ) ); }

				if( !Guild.NewGuildSystem )
					if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041055", typeof( GuildDeed ), 12450, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( IvoryTusk ), Utility.Random( 50,250 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MerchantCrate ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmallTent ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CampersTent ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Arrow ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bolt ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backpack ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pouch ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bag ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Candle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Torch ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lantern ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lockpick ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FloppyHat ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WideBrimHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cap ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TallStrawHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StrawHat ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WizardsHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherCap ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FeatheredHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TricorneHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PirateHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bandana ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullCap ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ThrowingWeapon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Waterskin ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RedBook ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlueBook ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TanBook ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBox ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Kindling ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( tarotpoker ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MahjongGame ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Chessboard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheckerBoard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backgammon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dices ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Amber ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Amethyst ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Citrine ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Diamond ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Emerald ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ruby ), 37 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sapphire ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphire ), 62 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tourmaline ), 47 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldRing ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverRing ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Necklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldNecklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldBeadNecklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverNecklace ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverBeadNecklace ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Beads ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldBracelet ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverBracelet ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldEarrings ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverEarrings ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryRing ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryCirclet ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryNecklace ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryEarrings ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryBracelet ), Utility.Random( 50,300 ) ); } // DO NOT WANT?

				if( !Guild.NewGuildSystem )
					if ( MyServerSettings.BuyChance() ){Add( typeof( GuildDeed ), 6225 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRancher : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRancher()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 631, Utility.Random( 1,15 ), 291, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRanger : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRanger()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new AnimalBuyInfo( 1, typeof( Cat ), 138, Utility.Random( 1,15 ), 201, 0 ) ); }
				if ( 1 > 0 ){Add( new AnimalBuyInfo( 1, typeof( Dog ), 181, Utility.Random( 1,15 ), 217, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 491, Utility.Random( 1,15 ), 292, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 606, Utility.Random( 1,15 ), 291, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new AnimalBuyInfo( 5, typeof( PackMule ), 10000, 1, 291, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 10,60 ), 0xE21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Crossbow ), 55, Utility.Random( 1,15 ), 0xF50, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HeavyCrossbow ), 55, Utility.Random( 1,15 ), 0x13FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RepeatingCrossbow ), 46, Utility.Random( 1,15 ), 0x26C3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CompositeBow ), 45, Utility.Random( 1,15 ), 0x26C2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bolt ), 2, Utility.Random( 30, 60 ), 0x1BFB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bow ), 40, Utility.Random( 1,15 ), 0x13B2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Arrow ), 2, Utility.Random( 30, 60 ), 0xF3F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Feather ), 2, Utility.Random( 30, 60 ), 0x4CCD, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Shaft ), 3, Utility.Random( 30, 60 ), 0x1BD4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ArcherQuiver ), 32, Utility.Random( 1,5 ), Utility.RandomList( 0x2B02, 0x2B03, 0x5770, 0x5770 ), 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RangerArms ), 87, Utility.Random( 1,15 ), 0x13DC, 0x59C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RangerChest ), 128, Utility.Random( 1,15 ), 0x13DB, 0x59C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RangerGloves ), 79, Utility.Random( 1,15 ), 0x13D5, 0x59C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RangerGorget ), 73, Utility.Random( 1,15 ), 0x13D6, 0x59C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RangerLegs ), 103, Utility.Random( 1,15 ), 0x13DA, 0x59C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmallTent ), 200, Utility.Random( 1,5 ), 0x1914, Utility.RandomList( 0x96D, 0x96E, 0x96F, 0x970, 0x971, 0x972, 0x973, 0x974, 0x975, 0x976, 0x977, 0x978, 0x979, 0x97A, 0x97B, 0x97C, 0x97D, 0x97E ) ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( CampersTent ), 500, Utility.Random( 1,5 ), 0x0A59, Utility.RandomList( 0x96D, 0x96E, 0x96F, 0x970, 0x971, 0x972, 0x973, 0x974, 0x975, 0x976, 0x977, 0x978, 0x979, 0x97A, 0x97B, 0x97C, 0x97D, 0x97E ) ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( MyTentEastAddonDeed ), 1000, 1, 0xA58, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( MyTentSouthAddonDeed ), 1000, 1, 0xA59, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TrapKit ), 420, Utility.Random( 1,5 ), 0x1EBB, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( MyTentEastAddonDeed ), 200 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MyTentSouthAddonDeed ), 200 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmallTent ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CampersTent ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Crossbow ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HeavyCrossbow ), 28 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RepeatingCrossbow ), 23 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CompositeBow ), 22 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bolt ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Arrow ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bow ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Feather ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shaft ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Arrow ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ArcherQuiver ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RangerArms ), 43 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RangerChest ), 64 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RangerGloves ), 40 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RangerLegs ), 51 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RangerGorget ), 36 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TrapKit ), 210 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRealEstateBroker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRealEstateBroker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( InteriorDecorator ), 100, Utility.Random( 1,15 ), 0x1EBA, 0 ) );
				Add( new GenericBuyInfo( typeof( HousePlacementTool ), 50, Utility.Random( 1,15 ), 0x14F0, 0 ) );
				if ( Server.Misc.MyServerSettings.LawnsAllowed() ){ Add( new GenericBuyInfo( typeof( LawnTools ), 500, Utility.Random( 1,5 ), 0x63E6, 0 ) ); }
				if ( Server.Misc.MyServerSettings.ShantysAllowed() ){ Add( new GenericBuyInfo( typeof( ShantyTools ), 400, Utility.Random( 1,5 ), 0x63E8, 0 ) ); }
				Add( new GenericBuyInfo( "house teleporter", typeof( PlayersHouseTeleporter ), 4000, Utility.Random( 1,10 ), 0x181D, 0 ) );
				Add( new GenericBuyInfo( "house high teleporter", typeof( PlayersZTeleporter ), 2000, Utility.Random( 1,10 ), 0x181D, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_post_a ), 5, Utility.Random( 1,15 ), 2967, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_post_b ), 5, Utility.Random( 1,15 ), 2970, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_merc ), 10, Utility.Random( 1,15 ), 3082, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_armor ), 10, Utility.Random( 1,15 ), 3008, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bake ), 10, Utility.Random( 1,15 ), 2980, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bank ), 10, Utility.Random( 1,15 ), 3084, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bard ), 10, Utility.Random( 1,15 ), 3004, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_smith ), 10, Utility.Random( 1,15 ), 3016, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_bow ), 10, Utility.Random( 1,15 ), 3022, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_ship ), 10, Utility.Random( 1,15 ), 2998, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_fletch ), 10, Utility.Random( 1,15 ), 3006, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_heal ), 10, Utility.Random( 1,15 ), 2988, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_inn ), 10, Utility.Random( 1,15 ), 2996, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_gem ), 10, Utility.Random( 1,15 ), 3010, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_book ), 10, Utility.Random( 1,15 ), 2966, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_mage ), 10, Utility.Random( 1,15 ), 2990, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_necro ), 10, Utility.Random( 1,15 ), 2811, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_supply ), 10, Utility.Random( 1,15 ), 3020, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_herb ), 10, Utility.Random( 1,15 ), 3014, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_pen ), 10, Utility.Random( 1,15 ), 3000, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_sew ), 10, Utility.Random( 1,15 ), 2982, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_tavern ), 10, Utility.Random( 1,15 ), 3012, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_tinker ), 10, Utility.Random( 1,15 ), 2984, 0 ) );
				Add( new GenericBuyInfo( typeof( house_sign_sign_wood ), 10, Utility.Random( 1,15 ), 2992, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( InteriorDecorator ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HousePlacementTool ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LawnTools ), 200 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShantyTools ), 150 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlayersHouseTeleporter ), 2000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlayersZTeleporter ), 1000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_post_a ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_post_b ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_merc ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_armor ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bake ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bank ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bard ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_smith ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_bow ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_ship ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_fletch ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_heal ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_inn ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_gem ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_book ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_mage ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_necro ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_supply ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_herb ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_pen ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_sew ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_tavern ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_tinker ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( house_sign_sign_wood ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RedWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarbleWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrownWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackWellDeed ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodWellDeed ), 250 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBScribe: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBScribe()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ScribesPen ), 16, Utility.Random( 1,15 ), 0x2051, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Monocle ), 24, Utility.Random( 1,25 ), 0x543B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BrownBook ), 15, Utility.Random( 1,15 ), 0xFEF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TanBook ), 15, Utility.Random( 1,15 ), 0xFF0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlueBook ), 15, Utility.Random( 1,15 ), 0xFF2, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( "1041267", typeof( Runebook ), 3500, Utility.Random( 1,3 ), 0x0F3D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Mailbox ), 158, Utility.Random( 1,5 ), 0x4142, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( ScribesPen ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Monocle ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BrownBook ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TanBook ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlueBook ), 7 ); } // DO NOT WANT?
				Add( typeof( JokeBook ), Utility.Random( 750,1500 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DynamicBook ), Utility.Random( 10,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DataPad ), Utility.Random( 5, 150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NecromancerSpellbook ), 55 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfBushido ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfNinjitsu ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MysticSpellbook ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DeathKnightSpellbook ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Runebook ), Utility.Random( 100,350 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfChivalry ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfChivalry ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HolyManSpellbook ), Utility.Random( 50,200 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmallHollowBook ), Utility.Random( 25,250 ) ); }
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeHollowBook ), Utility.Random( 35,300 ) ); }
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSage: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( LearnLeatherBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnMiscBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnMetalBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnWoodBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnReagentsBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnGraniteBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnScalesBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnTailorBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnTraps ), 5, Utility.Random( 1,15 ), 0xFF2, 0 ) );
				Add( new GenericBuyInfo( typeof( SwordsAndShackles ), 50, Utility.Random( 1,15 ), 0x529D, 0x944 ) );
				Add( new GenericBuyInfo( typeof( BookDruidBrewing ), 50, Utility.Random( 1,15 ), 0x5688, 0x85D ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( AlchemicalElixirs ), 50, Utility.Random( 1,15 ), 0x2219, 0 ) );
				Add( new GenericBuyInfo( typeof( AlchemicalMixtures ), 50, Utility.Random( 1,15 ), 0x2223, 0 ) );
				Add( new GenericBuyInfo( typeof( BookOfPoisons ), 50, Utility.Random( 1,15 ), 0x2253, 0xB51 ) );
				Add( new GenericBuyInfo( typeof( WorkShoppes ), 50, Utility.Random( 1,15 ), 0x2259, 0xB50 ) );
				Add( new GenericBuyInfo( typeof( LearnTitles ), 5, Utility.Random( 1,15 ), 0xFF2, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ScribesPen ), 8, Utility.Random( 1,15 ), 0x2051, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Monocle ), 24, Utility.Random( 1,25 ), 0x543B, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( "1041267", typeof( Runebook ), 3500, Utility.Random( 1,3 ), 0x0F3D, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( ScribesPen ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Monocle ), 12 ); } // DO NOT WANT?
				Add( typeof( TomeOfWands ), Utility.Random( 100,400 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( NecromancerSpellbook ), 55 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfBushido ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfNinjitsu ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MysticSpellbook ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DeathKnightSpellbook ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Runebook ), Utility.Random( 100,350 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfChivalry ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BookOfChivalry ), 70 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HolyManSpellbook ), Utility.Random( 50,200 ) ); } // DO NOT WANT?
				if ( 1 > 0 ){Add( typeof( SwordsAndShackles ), 25 ); }
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSECook: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSECook()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wasabi ), 2, Utility.Random( 1,15 ), 0x24E8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wasabi ), 2, Utility.Random( 1,15 ), 0x24E9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SushiRolls ), 3, Utility.Random( 1,15 ), 0x283E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SushiPlatter ), 3, Utility.Random( 1,15 ), 0x2840, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GreenTea ), 3, Utility.Random( 1,15 ), 0x284C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MisoSoup ), 3, Utility.Random( 1,15 ), 0x284D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WhiteMisoSoup ), 3, Utility.Random( 1,15 ), 0x284E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RedMisoSoup ), 3, Utility.Random( 1,15 ), 0x284F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AwaseMisoSoup ), 3, Utility.Random( 1,15 ), 0x2850, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BentoBox ), 6, Utility.Random( 1,15 ), 0x2836, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( BentoBox ), 6, Utility.Random( 1,15 ), 0x2837, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Wasabi ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BentoBox ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GreenTea ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SushiRolls ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SushiPlatter ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MisoSoup ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RedMisoSoup ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WhiteMisoSoup ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AwaseMisoSoup ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSEHats: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSEHats()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Kasa ), 31, Utility.Random( 1,15 ), 0x2798, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherJingasa ), 11, Utility.Random( 1,15 ), 0x2776, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ClothNinjaHood ), 33, Utility.Random( 1,15 ), 0x278F, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Kasa ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherJingasa ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ClothNinjaHood ), 16 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBShipwright : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBShipwright()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041205", typeof( SmallBoatDeed ), 10000, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041206", typeof( SmallDragonBoatDeed ), 11000, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041207", typeof( MediumBoatDeed ), 12000, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041208", typeof( MediumDragonBoatDeed ), 13000, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041209", typeof( LargeBoatDeed ), 14000, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041210", typeof( LargeDragonBoatDeed ), 15000, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( DockingLantern ), 58, Utility.Random( 1,15 ), 0x40FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sextant ), 13, Utility.Random( 1,15 ), 0x1057, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GrapplingHook ), 58, Utility.Random( 1,15 ), 0x4F40, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BoatStain ), 26, Utility.Random( 1,15 ), 0x14E0, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBDevon : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDevon()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( MagicSextant ), Utility.Random( 500,1000 ), Utility.Random( 5,15 ), 0x26A0, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSmithTools: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSmithTools()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Tongs ), 13, Utility.Random( 1,15 ), 0xFBB, 0 ) ); }

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tongs ), 7 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBStoneCrafter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBStoneCrafter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Nails ), 3, Utility.Random( 1,15 ), 0x102E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Axle ), 2, Utility.Random( 1,15 ), 0x105B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DrawKnife ), 10, Utility.Random( 1,15 ), 0x10E4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Froe ), 10, Utility.Random( 1,15 ), 0x10E5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Scorp ), 10, Utility.Random( 1,15 ), 0x10E7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Inshave ), 10, Utility.Random( 1,15 ), 0x10E6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DovetailSaw ), 12, Utility.Random( 1,15 ), 0x1028, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Saw ), 15, Utility.Random( 1,15 ), 0x1034, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Hammer ), 17, Utility.Random( 1,15 ), 0x102A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, Utility.Random( 1,15 ), 0x102C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmoothingPlane ), 10, Utility.Random( 1,15 ), 0x1032, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( JointingPlane ), 11, Utility.Random( 1,15 ), 0x1030, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( WoodworkingTools ), 10, Utility.Random( 10,30 ), 0x4F52, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( "Making Valuables With Stonecrafting", typeof( MasonryBook ), 10625, Utility.Random( 1,15 ), 0xFBE, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( "Mining For Quality Stone", typeof( StoneMiningBook ), 10625, Utility.Random( 1,15 ), 0xFBE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1044515", typeof( MalletAndChisel ), 3, Utility.Random( 1,15 ), 0x12B3, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "Jade Statue Maker", typeof( JadeStatueMaker ), 50000, 1, 0x32F2, 0xB93 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "Marble Statue Maker", typeof( MarbleStatueMaker ), 50000, 1, 0x32F2, 0xB8F ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "Bronze Statue Maker", typeof( BronzeStatueMaker ), 50000, 1, 0x32F2, 0xB97 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( MasonryBook ), 5000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneMiningBook ), 5000 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MalletAndChisel ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBox ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmallCrate ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MediumCrate ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeCrate ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenChest ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LargeTable ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nightstand ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( YewWoodTable ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Throne ), 24 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenThrone ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Stool ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FootStool ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FancyWoodenChairCushion ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenChairCushion ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenChair ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BambooChair ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBench ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Saw ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scorp ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmoothingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DrawKnife ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Froe ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hammer ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Inshave ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodworkingTools ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JointingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MouldingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DovetailSaw ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Axle ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenShield ), 31 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GnarledStaff ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuarterStaff ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShepherdsCrook ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Club ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Log ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RockUrn ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RockVase ), 30 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBTailor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTailor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SewingKit ), 3, Utility.Random( 1,15 ), 0x4C81, 0xB61 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Scissors ), 11, Utility.Random( 1,15 ), 0xF9F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DyeTub ), 8, Utility.Random( 1,15 ), 0xFAB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dyes ), 8, Utility.Random( 1,15 ), 0xFA9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Shirt ), 12, Utility.Random( 1,15 ), 0x1517, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ShortPants ), 7, Utility.Random( 1,15 ), 0x152E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FancyShirt ), 21, Utility.Random( 1,15 ), 0x1EFD, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalCoat ), 21, Utility.Random( 1,15 ), 0x307, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalShirt ), 21, Utility.Random( 1,15 ), 0x30B, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RusticShirt ), 21, Utility.Random( 1,15 ), 0x30D, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SquireShirt ), 21, Utility.Random( 1,15 ), 0x311, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FormalCoat ), 21, Utility.Random( 1,15 ), 0x403, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardShirt ), 21, Utility.Random( 1,15 ), 0x407, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BeggarVest ), 12, Utility.Random( 1,15 ), 0x308, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalVest ), 12, Utility.Random( 1,15 ), 0x30C, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RusticVest ), 12, Utility.Random( 1,15 ), 0x30E, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SailorPants ), 7, Utility.Random( 1,15 ), 0x309, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PiratePants ), 10, Utility.Random( 1,15 ), 0x404, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalSkirt ), 11, Utility.Random( 1,15 ), 0x30A, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Skirt ), 12, Utility.Random( 1,15 ), 0x1516, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalLongSkirt ), 12, Utility.Random( 1,15 ), 0x408, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LongPants ), 10, Utility.Random( 1,15 ), 0x1539, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FancyDress ), 26, Utility.Random( 1,15 ), 0x1EFF, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PlainDress ), 13, Utility.Random( 1,15 ), 0x1F01, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Kilt ), 11, Utility.Random( 1,15 ), 0x1537, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HalfApron ), 10, Utility.Random( 1,15 ), 0x153b, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LoinCloth ), 10, Utility.Random( 1,15 ), 0x2B68, 637 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalLoinCloth ), 10, Utility.Random( 1,15 ), 0x55DB, 637 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Robe ), 18, Utility.Random( 1,15 ), 0x1F03, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( JokerRobe ), 40, Utility.Random( 1,5 ), 0x2B6B, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AssassinRobe ), 40, Utility.Random( 1,5 ), 0x2B69, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FancyRobe ), 40, Utility.Random( 1,5 ), 0x2B6A, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GildedRobe ), 40, Utility.Random( 1,5 ), 0x2B6C, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OrnateRobe ), 40, Utility.Random( 1,5 ), 0x2B6E, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MagistrateRobe ), 40, Utility.Random( 1,5 ), 0x2B70, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RoyalRobe ), 40, Utility.Random( 1,5 ), 0x2B73, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SorcererRobe ), 40, Utility.Random( 1,5 ), 0x3175, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ScholarRobe ), 40, Utility.Random( 1,5 ), 0x2652, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NecromancerRobe ), 40, Utility.Random( 1,5 ), 0x2FBA, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SpiderRobe ), 40, Utility.Random( 1,5 ), 0x2FC6, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( VagabondRobe ), 40, Utility.Random( 1,5 ), 0x567D, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PirateCoat ), 40, Utility.Random( 1,5 ), 0x567E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ExquisiteRobe ), 40, Utility.Random( 1,5 ), 0x283, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ProphetRobe ), 40, Utility.Random( 1,5 ), 0x284, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ElegantRobe ), 40, Utility.Random( 1,5 ), 0x285, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FormalRobe ), 40, Utility.Random( 1,5 ), 0x286, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ArchmageRobe ), 40, Utility.Random( 1,5 ), 0x287, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PriestRobe ), 40, Utility.Random( 1,5 ), 0x288, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CultistRobe ), 40, Utility.Random( 1,5 ), 0x289, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GildedDarkRobe ), 40, Utility.Random( 1,5 ), 0x28A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GildedLightRobe ), 40, Utility.Random( 1,5 ), 0x301, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SageRobe ), 40, Utility.Random( 1,5 ), 0x302, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cloak ), 8, Utility.Random( 1,15 ), 0x1515, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Doublet ), 13, Utility.Random( 1,15 ), 0x1F7B, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tunic ), 18, Utility.Random( 1,15 ), 0x1FA1, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( JesterSuit ), 26, Utility.Random( 1,15 ), 0x1F9F, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( JesterHat ), 12, Utility.Random( 1,15 ), 0x171C, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FloppyHat ), 7, Utility.Random( 1,15 ), 0x1713, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WideBrimHat ), 8, Utility.Random( 1,15 ), 0x1714, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cap ), 10, Utility.Random( 1,15 ), 0x1715, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TallStrawHat ), 8, Utility.Random( 1,15 ), 0x1716, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StrawHat ), 7, Utility.Random( 1,15 ), 0x1717, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardsHat ), 11, Utility.Random( 1,15 ), 0x1718, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WitchHat ), 11, Utility.Random( 1,15 ), 0x2FC3, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherCap ), 10, Utility.Random( 1,15 ), 0x1DB9, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FeatheredHat ), 10, Utility.Random( 1,15 ), 0x171A, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TricorneHat ), 8, Utility.Random( 1,15 ), 0x171B, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PirateHat ), 8, Utility.Random( 1,15 ), 0x2FBC, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bandana ), 6, Utility.Random( 1,15 ), 0x1540, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SkullCap ), 7, Utility.Random( 1,15 ), 0x1544, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ClothHood ), 12, Utility.Random( 1,15 ), 0x2B71, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ClothCowl ), 12, Utility.Random( 1,15 ), 0x3176, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HoodedMantle ), 12, Utility.Random( 1,15 ), 0x5C14, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardHood ), 12, Utility.Random( 1,15 ), 0x310, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FancyHood ), 12, Utility.Random( 1,15 ), 0x4D09, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cloth ), 2, Utility.Random( 1,15 ), 0x1766, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( UncutCloth ), 2, Utility.Random( 1,15 ), 0x1767, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Cotton ), 102, Utility.Random( 1,15 ), 0xDF9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wool ), 62, Utility.Random( 1,15 ), 0xDF8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Flax ), 102, Utility.Random( 1,15 ), 0x1A9C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SpoolOfThread ), 18, Utility.Random( 1,15 ), 0x543A, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( JokerRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AssassinRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FancyRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GildedRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OrnateRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagistrateRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SorcererRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ScholarRobe ), 29 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NecromancerRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpiderRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VagabondRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PirateCoat ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ExquisiteRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ProphetRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ElegantRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FormalRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ArchmageRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PriestRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CultistRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GildedDarkRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GildedLightRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SageRobe ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scissors ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SewingKit ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dyes ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DyeTub ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FancyShirt ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shirt ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ShortPants ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LongPants ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cloak ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FancyDress ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Robe ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlainDress ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Skirt ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalCoat ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalShirt ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RusticShirt ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SquireShirt ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FormalCoat ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WizardShirt ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BeggarVest ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalVest ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RusticVest ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SailorPants ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PiratePants ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalSkirt ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Skirt ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RoyalLongSkirt ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Kilt ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Doublet ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tunic ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JesterSuit ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FullApron ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HalfApron ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LoinCloth ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JesterHat ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FloppyHat ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WideBrimHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cap ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullCap ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ClothCowl ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HoodedMantle ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WizardHood ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ClothHood ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FancyHood ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bandana ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TallStrawHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StrawHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WizardsHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bonnet ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FeatheredHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TricorneHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PirateHat ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpoolOfThread ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Flax ), 51 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Cotton ), 51 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Wool ), 31 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicRobe ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicHat ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicCloak ), 30 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicBelt ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MagicSash ), 20 ); } // DO NOT WANT?
				Add( typeof( MagicScissors ), Utility.Random( 300,400 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBJester: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBJester()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BagOfTricks ), 200, Utility.Random( 1,15 ), 0x1E3F, 0 ) );
				Add( new GenericBuyInfo( typeof( JesterHat ), 12, Utility.Random( 1,15 ), 0x171C, 0 ) );
				Add( new GenericBuyInfo( typeof( JokerHat ), 12, Utility.Random( 1,15 ), 0x171C, 0 ) );
				Add( new GenericBuyInfo( typeof( JesterSuit ), 26, Utility.Random( 1,15 ), 0x1F9F, 0 ) );
				Add( new GenericBuyInfo( typeof( JesterGarb ), 26, Utility.Random( 1,15 ), 0x1F9F, 0 ) );
				Add( new GenericBuyInfo( typeof( FoolsCoat ), 26, Utility.Random( 1,15 ), 0x1F9F, 0 ) );
				Add( new GenericBuyInfo( typeof( JokerRobe ), 26, Utility.Random( 1,15 ), 0x1F9F, 0 ) );
				Add( new GenericBuyInfo( typeof( JesterShoes ), 26, Utility.Random( 1,15 ), 0x170f, 0 ) );
				Add( new GenericBuyInfo( typeof( ThrowingGloves ), 26, Utility.Random( 1,15 ), 0x13C6, 0 ) );
				Add( new GenericBuyInfo( typeof( ThrowingWeapon ), 2, Utility.Random( 20, 200 ), 0x52B2, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MyCircusTentEastAddonDeed ), 1000, 1, 0xA58, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MyCircusTentSouthAddonDeed ), 1000, 1, 0xA59, Utility.RandomDyedHue() ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BagOfTricks ), 100 );
				Add( typeof( JesterHat ), 6 );
				Add( typeof( JokerHat ), 6 );
				Add( typeof( JesterSuit ), 13 );
				Add( typeof( JesterGarb ), 13 );
				Add( typeof( FoolsCoat ), 13 );
				Add( typeof( JokerRobe ), 13 );
				Add( typeof( JesterShoes ), 13 );
				Add( typeof( ThrowingGloves ), 13 );
				Add( typeof( ThrowingWeapon ), 1 );
				Add( typeof( MyCircusTentEastAddonDeed ), 200 );
				Add( typeof( MyCircusTentSouthAddonDeed ), 200 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBTanner : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTanner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FemaleStuddedChest ), 62, Utility.Random( 1,15 ), 0x1C02, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FemalePlateChest ), 207, Utility.Random( 1,15 ), 0x1C04, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( FemaleLeatherChest ), 36, Utility.Random( 1,15 ), 0x1C06, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherShorts ), 28, Utility.Random( 1,15 ), 0x1C00, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherSkirt ), 25, Utility.Random( 1,15 ), 0x1C08, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LeatherBustierArms ), 30, Utility.Random( 1,15 ), 0x1C0B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StuddedBustierArms ), 50, Utility.Random( 1,15 ), 0x1C0C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bag ), 6, Utility.Random( 1,15 ), 0xE76, 0xABE ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pouch ), 6, Utility.Random( 1,15 ), 0xE79, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Backpack ), 15, Utility.Random( 1,15 ), 0x53D5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SkinningKnife ), 15, Utility.Random( 1,15 ), 0xEC4, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bag ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pouch ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backpack ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkinningKnife ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemaleStuddedChest ), 31 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StuddedBustierArms ), 23 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemalePlateChest), 103 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FemaleLeatherChest ), 18 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherBustierArms ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherShorts ), 14 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LeatherSkirt ), 12 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBTavernKeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTavernKeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, Utility.Random( 1,15 ), 0x99F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, Utility.Random( 1,15 ), 0x9C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, Utility.Random( 1,15 ), 0x99B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, Utility.Random( 1,15 ), 0x9C8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, Utility.Random( 1,15 ), 0x9F0, 0 ) ); }
				if ( 1 > 0 ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 11, Utility.Random( 1,15 ), 0x1F95, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 11, Utility.Random( 1,15 ), 0x1F97, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 11, Utility.Random( 1,15 ), 0x1F99, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 11, Utility.Random( 1,15 ), 0x1F9B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 11, Utility.Random( 1,15 ), 0x1F9D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( CheeseWheel ), 21, Utility.Random( 1,15 ), 0x97E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CookedBird ), 17, Utility.Random( 1,15 ), 0x9B7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LambLeg ), 8, Utility.Random( 1,15 ), 0x160A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, Utility.Random( 1,15 ), 0x1608, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ribs ), 7, Utility.Random( 1,15 ), 0x9F2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 3, Utility.Random( 1,15 ), 0x15F9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x15FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 2, Utility.Random( 1,15 ), 0x15FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x1600, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfFoodPotatos ), 3, Utility.Random( 1,15 ), 0x1601, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 3, Utility.Random( 1,15 ), 0x1604, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 3, Utility.Random( 1,15 ), 0x1606, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ApplePie ), 7, Utility.Random( 1,15 ), 0x1041, 0 ) ); } //OSI just has Pie, not Apple/Fruit/Meat
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( tarotpoker ), 5, Utility.Random( 1,15 ), 0x12AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 2, Utility.Random( 1,15 ), 0xFA6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backgammon ), 2, Utility.Random( 1,15 ), 0xE1C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dices ), 2, Utility.Random( 1,15 ), 0xFA7, 0x982 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Engines.Mahjong.MahjongGame ), 6, Utility.Random( 1,15 ), 0xFAA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Waterskin ), 5, Utility.Random( 1,15 ), 0xA21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanFighterItem ), 5000, Utility.Random( 1,15 ), 0x1419, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanArcherItem ), 6000, Utility.Random( 1,15 ), 0xF50, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( HenchmanWizardItem ), 7000, Utility.Random( 1,15 ), 0xE30, 0xB96 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041243", typeof( ContractOfEmployment ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "a barkeep contract", typeof( BarkeepContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0 ) ); }
				Add( new GenericBuyInfo( typeof( TavernTable ), Utility.Random( 900,1100 ), Utility.Random( 10,30 ), 0x55D9, 0 ) );

				if ( Multis.BaseHouse.NewVendorSystem )
					if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1062332", typeof( VendorRentalContract ), 1252, Utility.Random( 1,15 ), 0x14F0, 0x672 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCarrots ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmptyPewterBowl ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfCorn ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfLettuce ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfPeas ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PewterBowlOfFoodPotatos ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfStew ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBowlOfTomatoSoup ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BeverageBottle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Waterskin ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Jug ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pitcher ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GlassMug ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BreadLoaf ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheeseWheel ), 12 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ribs ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Peach ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pear ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Grapes ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Apple ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Banana ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Candle ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( tarotpoker ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MahjongGame ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Chessboard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CheckerBoard ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backgammon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dices ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ContractOfEmployment ), 626 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RomulanAle ), Utility.Random( 20,100 ) ); } // DO NOT WANT?
				Add( typeof( TavernTable ), Utility.Random( Utility.Random( 350,450 ) ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBThief : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBThief()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Backpack ), 15, Utility.Random( 1,15 ), 0x53D5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pouch ), 6, Utility.Random( 1,15 ), 0xE79, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Torch ), 8, Utility.Random( 1,15 ), 0xF6B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lantern ), 2, Utility.Random( 1,15 ), 0xA25, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( LearnStealingBook ), 5, Utility.Random( 1,15 ), 0x4C5C, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( LearnTraps ), 5, Utility.Random( 1,15 ), 0xFF2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lockpick ), 12, Utility.Random( 1,15 ), 0x14FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SkeletonsKey ), Utility.Random( 25,100 ), 1, 0x410A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBox ), 14, Utility.Random( 1,15 ), 0x9AA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Key ), 2, Utility.Random( 1,15 ), 0x100E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 100, Utility.Random( 1,15 ), 0xEFF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "hair dye bottle", typeof( HairDyeBottle ), 1000, Utility.Random( 1,15 ), 0xE0F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DisguiseKit ), 700, Utility.Random( 1,5 ), 0xE05, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Backpack ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pouch ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Torch ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lantern ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lockpick ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenBox ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HairDye ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HairDyeBottle ), 300 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkeletonsKey ), 10 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBTinker: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTinker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Clock ), 22, Utility.Random( 1,15 ), 0x104B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Nails ), 3, Utility.Random( 1,15 ), 0x102E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ClockParts ), 3, Utility.Random( 1,15 ), 0x104F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AxleGears ), 3, Utility.Random( 1,15 ), 0x1051, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Gears ), 2, Utility.Random( 1,15 ), 0x1053, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Hinge ), 2, Utility.Random( 1,15 ), 0x1055, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sextant ), 13, Utility.Random( 1,15 ), 0x1057, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SextantParts ), 5, Utility.Random( 1,15 ), 0x1059, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Axle ), 2, Utility.Random( 1,15 ), 0x105B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Springs ), 3, Utility.Random( 1,15 ), 0x105D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1024111", typeof( Key ), 8, Utility.Random( 1,15 ), 0x100F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1024112", typeof( Key ), 8, Utility.Random( 1,15 ), 0x1010, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( "1024115", typeof( Key ), 8, Utility.Random( 1,15 ), 0x1013, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( KeyRing ), 8, Utility.Random( 1,15 ), 0x1010, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Lockpick ), 12, Utility.Random( 1,15 ), 0x14FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SkeletonsKey ), Utility.Random( 25,100 ), 1, 0x410A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TinkersTools ), 7, Utility.Random( 1,15 ), 0x1EBC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SewingKit ), 3, Utility.Random( 1,15 ), 0x4C81, 0xB61 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DrawKnife ), 10, Utility.Random( 1,15 ), 0x10E4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Froe ), 10, Utility.Random( 1,15 ), 0x10E5, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Scorp ), 10, Utility.Random( 1,15 ), 0x10E7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Inshave ), 10, Utility.Random( 1,15 ), 0x10E6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ButcherKnife ), 13, Utility.Random( 1,15 ), 0x13F6, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Scissors ), 11, Utility.Random( 1,15 ), 0xF9F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tongs ), 13, Utility.Random( 1,15 ), 0xFBB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DovetailSaw ), 12, Utility.Random( 1,15 ), 0x1028, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Saw ), 15, Utility.Random( 1,15 ), 0x1034, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Hammer ), 17, Utility.Random( 1,15 ), 0x102A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmithHammer ), 23, Utility.Random( 1,15 ), 0x0FB4, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Shovel ), 12, Utility.Random( 1,15 ), 0xF39, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( OreShovel ), 10, Utility.Random( 1,15 ), 0xF39, 0x96D ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, Utility.Random( 1,15 ), 0x102C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( JointingPlane ), 10, Utility.Random( 1,15 ), 0x1030, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SmoothingPlane ), 11, Utility.Random( 1,15 ), 0x1032, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( WoodworkingTools ), 10, Utility.Random( 10,30 ), 0x4F52, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Pickaxe ), 25, Utility.Random( 1,15 ), 0xE86, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ThrowingWeapon ), 2, Utility.Random( 20, 120 ), 0x52B2, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WallTorch ), 50, Utility.Random( 5,20 ), 0xA07, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ColoredWallTorch ), 100, Utility.Random( 5,20 ), 0x3D89, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( light_dragon_brazier ), 750, Utility.Random( 1,15 ), 0x194E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TrapKit ), 420, Utility.Random( 1,5 ), 0x1EBB, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( LootChest ), 600 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Shovel ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OreShovel ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SewingKit ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scissors ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tongs ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Key ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DovetailSaw ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MouldingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nails ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JointingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmoothingPlane ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Saw ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Clock ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ClockParts ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AxleGears ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Gears ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hinge ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sextant ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SextantParts ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Axle ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Springs ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DrawKnife ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Froe ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Inshave ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodworkingTools ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scorp ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Lockpick ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkeletonsKey ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TinkerTools ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Log ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Pickaxe ), 16 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Hammer ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SmithHammer ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ButcherKnife ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CrystalScales ), Utility.Random( 250,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GolemManual ), Utility.Random( 500,750 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PowerCrystal ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ArcaneGem ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ClockworkAssembly ), 15 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BottleOil ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ThrowingWeapon ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TrapKit ), 210 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkA ), Utility.Random( 5, 10 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkB ), Utility.Random( 10, 20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkC ), Utility.Random( 15, 30 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkD ), Utility.Random( 20, 40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkE ), Utility.Random( 25, 50 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkF ), Utility.Random( 30, 60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkG ), Utility.Random( 35, 70 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkH ), Utility.Random( 40, 80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkI ), Utility.Random( 45, 90 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkJ ), Utility.Random( 50, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkK ), Utility.Random( 55, 110 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkL ), Utility.Random( 60, 120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkM ), Utility.Random( 65, 130 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkN ), Utility.Random( 70, 140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkO ), Utility.Random( 75, 150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkP ), Utility.Random( 80, 160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkQ ), Utility.Random( 85, 170 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkR ), Utility.Random( 90, 180 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkS ), Utility.Random( 95, 190 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkT ), Utility.Random( 100, 200 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkU ), Utility.Random( 105, 210 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkV ), Utility.Random( 110, 220 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkW ), Utility.Random( 115, 230 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkX ), Utility.Random( 120, 240 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkY ), Utility.Random( 125, 250 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpaceJunkZ ), Utility.Random( 130, 260 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LandmineSetup ), Utility.Random( 100, 300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlasmaGrenade ), Utility.Random( 28, 38 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( ThermalDetonator ), Utility.Random( 28, 38 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PuzzleCube ), Utility.Random( 45, 90 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PlasmaTorch ), Utility.Random( 45, 90 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DuctTape ), Utility.Random( 45, 90 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotBatteries ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotSheetMetal ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotOil ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotGears ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotEngineParts ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotCircuitBoard ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotBolt ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotTransistor ), Utility.Random( 5, 100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RobotSchematics ), Utility.Random( 500,750 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DataPad ), Utility.Random( 5, 150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MaterialLiquifier ), Utility.Random( 100, 300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Chainsaw ), Utility.Random( 130, 260 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PortableSmelter ), Utility.Random( 130, 260 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////

	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBVagabond : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBVagabond()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldRing ), 27, Utility.Random( 1,15 ), 0x4CFA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Necklace ), 26, Utility.Random( 1,15 ), 0x4CFE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldNecklace ), 27, Utility.Random( 1,15 ), 0x4CFF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldBeadNecklace ), 27, Utility.Random( 1,15 ), 0x4CFD, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Beads ), 27, Utility.Random( 1,15 ), 0x4CFE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldBracelet ), 27, Utility.Random( 1,15 ), 0x4CF1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GoldEarrings ), 27, Utility.Random( 1,15 ), 0x4CFB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( StarSapphire ), 125, Utility.Random( 1,15 ), 0xF21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Emerald ), 100, Utility.Random( 1,15 ), 0xF10, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Sapphire ), 100, Utility.Random( 1,15 ), 0xF19, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ruby ), 75, Utility.Random( 1,15 ), 0xF13, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Citrine ), 50, Utility.Random( 1,15 ), 0xF15, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Amethyst ), 100, Utility.Random( 1,15 ), 0xF16, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Tourmaline ), 75, Utility.Random( 1,15 ), 0xF2D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Amber ), 50, Utility.Random( 1,15 ), 0xF25, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Diamond ), 200, Utility.Random( 1,15 ), 0xF26, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Amber ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Amethyst ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Citrine ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Diamond ), 100 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Emerald ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ruby ), 37 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Sapphire ), 50 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarSapphire ), 62 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Tourmaline ), 47 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldRing ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverRing ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Necklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldNecklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldBeadNecklace ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverNecklace ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverBeadNecklace ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Beads ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldBracelet ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverBracelet ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GoldEarrings ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverEarrings ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryRing ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryCirclet ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryNecklace ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryEarrings ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicJewelryBracelet ), Utility.Random( 50,300 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBVarietyDealer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBVarietyDealer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( ArtifactVase ), Utility.Random( 1000,5000 ), 1, 0x0B48, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArtifactLargeVase ), Utility.Random( 1000,5000 ), 1, 0x0B47, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TapestryOfSosaria ), Utility.Random( 1000,5000 ), 1, 0x234E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlueDecorativeRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlueFancyRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BluePlainRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CinnamonFancyRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CurtainsDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FountainDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GoldenDecorativeRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingAxesDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HangingSwordsDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( PinkFancyRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( RedPlainRugDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WallBannerDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecorativeShieldDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StoneAnkhDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BannerDeed ), Utility.Random( 1000,5000 ), 1, 0x14F0, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoTray ), Utility.Random( 1000,5000 ), 1, 0x992, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DecoTray2 ), Utility.Random( 1000,5000 ), 1, 0x991, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile01AddonDeed ), Utility.Random( 8000,12000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile02AddonDeed ), Utility.Random( 8000,12000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile03AddonDeed ), Utility.Random( 8000,12000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile04AddonDeed ), Utility.Random( 8000,12000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile05AddonDeed ), Utility.Random( 8000,12000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePileAddonDeed ), Utility.Random( 12000,20000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile2AddonDeed ), Utility.Random( 12000,20000 ), 1, 0x0E41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasurePile3AddonDeed ), Utility.Random( 12000,20000 ), 1, 0x0E41, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( LootChest ), 600 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPainting ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingA ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingB ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingC ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingD ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingE ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingF ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxPaintingG ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxSculptors ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxSculptorsA ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxSculptorsB ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxSculptorsC ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxSculptorsD ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( WaxSculptorsE ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( DragonLamp ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( DragonPedStatue ), Utility.Random( 50,500 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBVeterinarian : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBVeterinarian()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 10,150 ), 0xE21, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 1,15 ), 0x25FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,15 ), 0xF0B, 0 ) ); }
				if ( MyServerSettings.SellCommonChance() ){Add( new GenericBuyInfo( typeof( StableStone ), 5000, Utility.Random( 1,3 ), 0x14E7, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( LesserHealPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RefreshPotion ), 7 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Garlic ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ginseng ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyCommonChance() ){Add( typeof( StableStone ), 2500 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AlienEgg ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DragonEgg ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( FirstAidKit ), Utility.Random( 100,250 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBWaiter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWaiter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, Utility.Random( 1,15 ), 0x99F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, Utility.Random( 1,15 ), 0x9C7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, Utility.Random( 1,15 ), 0x99B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, Utility.Random( 1,15 ), 0x9C8, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, Utility.Random( 1,15 ), 0x9F0, 0 ) ); }
				if ( 1 > 0 ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 11, Utility.Random( 1,15 ), 0x1F95, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 11, Utility.Random( 1,15 ), 0x1F97, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 11, Utility.Random( 1,15 ), 0x1F99, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 11, Utility.Random( 1,15 ), 0x1F9B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 11, Utility.Random( 1,15 ), 0x1F9D, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, Utility.Random( 1,15 ), 0x103B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CheeseWheel ), 21, Utility.Random( 1,15 ), 0x97E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CookedBird ), 17, Utility.Random( 1,15 ), 0x9B7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LambLeg ), 8, Utility.Random( 1,15 ), 0x160A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 3, Utility.Random( 1,15 ), 0x15F9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x15FC, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 2, Utility.Random( 1,15 ), 0x15FD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 3, Utility.Random( 1,15 ), 0x15FE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 3, Utility.Random( 1,15 ), 0x15FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 3, Utility.Random( 1,15 ), 0x1600, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PewterBowlOfFoodPotatos ), 3, Utility.Random( 1,15 ), 0x1601, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 3, Utility.Random( 1,15 ), 0x1604, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 3, Utility.Random( 1,15 ), 0x1606, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ApplePie ), 7, Utility.Random( 1,15 ), 0x1041, 0 ) ); } //OSI just has Pie, not Apple/Fruit/Meat
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBWeaponSmith: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWeaponSmith()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WeaponAbilityBook ), 5, Utility.Random( 1,15 ), 0x2254, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( RareAnvil ), Utility.Random( 200,1000 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBWeaver: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWeaver()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Dyes ), 8, Utility.Random( 1,15 ), 0xFA9, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DyeTub ), 8, Utility.Random( 1,15 ), 0xFAB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DarkYarn ), 18, Utility.Random( 1,15 ), 0xE1D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LightYarn ), 18, Utility.Random( 1,15 ), 0xE1E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LightYarnUnraveled ), 18, Utility.Random( 1,15 ), 0xE1F, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( PaintCanvas ), 500, Utility.Random( 1,15 ), 0xA6C, 0x47E ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( Scissors ), 11, Utility.Random( 1,15 ), 0xF9F, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( Scissors ), 6 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Dyes ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DyeTub ), 4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LightYarnUnraveled ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LightYarn ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DarkYarn ), 9 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PaintCanvas ), 250 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBNecroMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBNecroMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BatWing ), 3, 20, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, 20, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, 20, 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, 20, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, 20, 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 20, 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 20, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, 20, 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, 20, 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( GargoyleEar ), 6, 20, 0x2FD9, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, 20, 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, 20, 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( PixieSkull ), 6, 20, 0x2FE1, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, 20, 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, 20, 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, 20, 0x2FE0, 0 ) );
				Add( new GenericBuyInfo( typeof( BitterRoot ), 5, 20, 0x640C, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackSand ), 7, 20, 0x640D, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodRose ), 5, 20, 0x640E, 0 ) );
				Add( new GenericBuyInfo( typeof( DriedToad ), 7, 20, 0x640F, 0 ) );
				Add( new GenericBuyInfo( typeof( Maggot ), 5, 20, 0x6410, 0 ) );
				Add( new GenericBuyInfo( typeof( MummyWrap ), 7, 20, 0x6411, 0 ) );
				Add( new GenericBuyInfo( typeof( VioletFungus ), 5, 20, 0x6412, 0 ) );
				Add( new GenericBuyInfo( typeof( WerewolfClaw ), 7, 20, 0x6413, 0 ) );
				Add( new GenericBuyInfo( typeof( Wolfsbane ), 5, 20, 0x6414, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodOathScroll ), 25, 5, 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( CorpseSkinScroll ), 28, 5, 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( CurseWeaponScroll ), 12, 5, 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( PolishBoneBrush ), 12, 10, 0x1371, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveShovel ), 12, Utility.Random( 1,15 ), 0xF39, 0x966 ) );
				Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 1,15 ), 0x640B, 0 ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BatWing ), 1 );
				Add( typeof( DaemonBlood ), 3 );
				Add( typeof( PigIron ), 2 );
				Add( typeof( NoxCrystal ), 3 );
				Add( typeof( GraveDust ), 1 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( GargoyleEar ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( PixieSkull ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				Add( typeof( BitterRoot ), 2 );
				Add( typeof( BlackSand ), 3 );
				Add( typeof( BloodRose ), 2 );
				Add( typeof( DriedToad ), 3 );
				Add( typeof( Maggot ), 2 );
				Add( typeof( MummyWrap ), 3 );
				Add( typeof( VioletFungus ), 2 );
				Add( typeof( WerewolfClaw ), 3 );
				Add( typeof( Wolfsbane ), 2 );
				Add( typeof( ExorcismScroll ), 72 );
				Add( typeof( AnimateDeadScroll ), 26 );
				Add( typeof( BloodOathScroll ), 26 );
				Add( typeof( CorpseSkinScroll ), 26 );
				Add( typeof( CurseWeaponScroll ), 26 );
				Add( typeof( EvilOmenScroll ), 26 );
				Add( typeof( PainSpikeScroll ), 26 );
				Add( typeof( SummonFamiliarScroll ), 26 );
				Add( typeof( HorrificBeastScroll ), 27 );
				Add( typeof( MindRotScroll ), 39 );
				Add( typeof( PoisonStrikeScroll ), 39 );
				Add( typeof( WraithFormScroll ), 51 );
				Add( typeof( LichFormScroll ), 64 );
				Add( typeof( StrangleScroll ), 64 );
				Add( typeof( WitherScroll ), 64 );
				Add( typeof( VampiricEmbraceScroll ), 101 );
				Add( typeof( VengefulSpiritScroll ), 114 );
				Add( typeof( PolishBoneBrush ), 6 );
				Add( typeof( PolishedSkull ), 3 );
				Add( typeof( PolishedBone ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchCauldron ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullMinotaur ), Utility.Random( 50,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullWyrm ), Utility.Random( 200,400 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGreatDragon ), Utility.Random( 300,600 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDragon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDemon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGiant ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				Add( typeof( CorpseSailor ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( CorpseChest ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BuriedBody ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BoneContainer ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( LeftLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( TastyHeart ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( BodyPart ), Utility.RandomMinMax( 30, 90 ) );
				Add( typeof( Head ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( LeftArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Torso ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bone ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RibCage ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( BonePile ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bones ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( GraveChest ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenCoffin ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenCasket ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneCoffin ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneCasket ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DracolichSkull ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStaff ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStick ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBNecromancer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBNecromancer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 1, 0x2253, 0 ) );
				Add( new GenericBuyInfo( typeof( NecroSkinPotion ), 1000, 1, 0x1006, 0 ) );
				Add( new GenericBuyInfo( typeof( BookofDead ), 25000, 1,  0x1C11, 2500 ) );
				Add( new GenericBuyInfo( typeof( DarkHeart ), 500, 5, 0xF91, 0x386 ) );
				Add( new GenericBuyInfo( typeof( BatWing ), 3, 20, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, 20, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, 20, 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, 20, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, 20, 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 20, 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 20, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, 20, 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, 20, 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( GargoyleEar ), 6, 20, 0x2FD9, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, 20, 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, 20, 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( PixieSkull ), 6, 20, 0x2FE1, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, 20, 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, 20, 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, 20, 0x2FE0, 0 ) );
				Add( new GenericBuyInfo( typeof( BitterRoot ), 5, 20, 0x640C, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackSand ), 7, 20, 0x640D, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodRose ), 5, 20, 0x640E, 0 ) );
				Add( new GenericBuyInfo( typeof( DriedToad ), 7, 20, 0x640F, 0 ) );
				Add( new GenericBuyInfo( typeof( Maggot ), 5, 20, 0x6410, 0 ) );
				Add( new GenericBuyInfo( typeof( MummyWrap ), 7, 20, 0x6411, 0 ) );
				Add( new GenericBuyInfo( typeof( VioletFungus ), 5, 20, 0x6412, 0 ) );
				Add( new GenericBuyInfo( typeof( WerewolfClaw ), 7, 20, 0x6413, 0 ) );
				Add( new GenericBuyInfo( typeof( Wolfsbane ), 5, 20, 0x6414, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodOathScroll ), 25, 5, 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( CorpseSkinScroll ), 28, 5, 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( CurseWeaponScroll ), 12, 5, 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( PolishBoneBrush ), 12, 10, 0x1371, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveShovel ), 12, Utility.Random( 1,15 ), 0xF39, 0x966 ) );
				Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 1,15 ), 0x640B, 0 ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }
				Add( new GenericBuyInfo( "undead horse", typeof( NecroHorse ), 10000, 5, 0x2617, 0xB97 ) );
				Add( new GenericBuyInfo( "daemon servant", typeof( DaemonMount ), 15000, 5, 11669, 0x4AA ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BatWing ), 1 );
				Add( typeof( DaemonBlood ), 3 );
				Add( typeof( PigIron ), 2 );
				Add( typeof( NoxCrystal ), 3 );
				Add( typeof( GraveDust ), 1 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( GargoyleEar ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( PixieSkull ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				Add( typeof( BitterRoot ), 2 );
				Add( typeof( BlackSand ), 3 );
				Add( typeof( BloodRose ), 2 );
				Add( typeof( DriedToad ), 3 );
				Add( typeof( Maggot ), 2 );
				Add( typeof( MummyWrap ), 3 );
				Add( typeof( VioletFungus ), 2 );
				Add( typeof( WerewolfClaw ), 3 );
				Add( typeof( Wolfsbane ), 2 );
				Add( typeof( ExorcismScroll ), 72 );
				Add( typeof( AnimateDeadScroll ), 26 );
				Add( typeof( BloodOathScroll ), 26 );
				Add( typeof( CorpseSkinScroll ), 26 );
				Add( typeof( CurseWeaponScroll ), 26 );
				Add( typeof( EvilOmenScroll ), 26 );
				Add( typeof( PainSpikeScroll ), 26 );
				Add( typeof( SummonFamiliarScroll ), 26 );
				Add( typeof( HorrificBeastScroll ), 27 );
				Add( typeof( MindRotScroll ), 39 );
				Add( typeof( PoisonStrikeScroll ), 39 );
				Add( typeof( WraithFormScroll ), 51 );
				Add( typeof( LichFormScroll ), 64 );
				Add( typeof( StrangleScroll ), 64 );
				Add( typeof( WitherScroll ), 64 );
				Add( typeof( VampiricEmbraceScroll ), 101 );
				Add( typeof( VengefulSpiritScroll ), 114 );
				Add( typeof( PolishBoneBrush ), 6 );
				Add( typeof( PolishedSkull ), 3 );
				Add( typeof( PolishedBone ), 3 );
				Add( typeof( NecromancerSpellbook ), 55 );
				Add( typeof( DeathKnightSpellbook ), Utility.Random( 100,300 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDragon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDemon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGiant ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchCauldron ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( BoneContainer ), 250 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ClumsyMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CreateFoodMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FeebleMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HealMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicArrowMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( NightSightMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ReactiveArmorMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WeaknessMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AgilityMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CunningMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CureMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HarmMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicTrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUntrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ProtectionMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( StrengthMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BlessMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireballMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicLockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUnlockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TelekinesisMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TeleportMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WallofStoneMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchCureMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchProtectionMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CurseMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireFieldMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GreaterHealMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( LightningMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaDrainMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RecallMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BladeSpiritsMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( IncognitoMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicReflectionMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MindBlastMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonCreatureMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyBoltMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ExplosionMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( InvisibilityMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MarkMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassCurseMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeFieldMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RevealMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ChainLightningMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyFieldMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FlameStrikeMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GateTravelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaVampireMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassDispelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MeteorSwarmMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PolymorphMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AirElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthquakeMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyVortexMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ResurrectionMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonDaemonMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WaterElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MyNecromancerSpellbook ), Utility.Random( 100,500 ) ); } // DO NOT WANT?
				Add( typeof( CorpseSailor ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( CorpseChest ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BodyPart ), Utility.RandomMinMax( 30, 90 ) );
				Add( typeof( BuriedBody ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BoneContainer ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( LeftLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( TastyHeart ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( Head ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( LeftArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Torso ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bone ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RibCage ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( BonePile ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bones ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( GraveChest ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenCoffin ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenCasket ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneCoffin ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneCasket ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DracolichSkull ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStaff ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStick ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBWitches : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBWitches()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 1, 0x2253, 0 ) ); }
				Add( new GenericBuyInfo( typeof( BatWing ), 3, Utility.Random( 10,100 ), 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, Utility.Random( 10,100 ), 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, Utility.Random( 10,100 ), 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, Utility.Random( 10,100 ), 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, Utility.Random( 10,100 ), 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 10,100 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 10,100 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 10,100 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 10,100 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( GargoyleEar ), 6, Utility.Random( 10,100 ), 0x2FD9, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 10,100 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 10,100 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( PixieSkull ), 6, Utility.Random( 10,100 ), 0x2FE1, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 10,100 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 10,100 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 10,100 ), 0x2FE0, 0 ) );
				Add( new GenericBuyInfo( typeof( BitterRoot ), 5, Utility.Random( 10,100 ), 0x640C, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackSand ), 7, Utility.Random( 10,100 ), 0x640D, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodRose ), 5, Utility.Random( 10,100 ), 0x640E, 0 ) );
				Add( new GenericBuyInfo( typeof( DriedToad ), 7, Utility.Random( 10,100 ), 0x640F, 0 ) );
				Add( new GenericBuyInfo( typeof( Maggot ), 5, Utility.Random( 10,100 ), 0x6410, 0 ) );
				Add( new GenericBuyInfo( typeof( MummyWrap ), 7, Utility.Random( 10,100 ), 0x6411, 0 ) );
				Add( new GenericBuyInfo( typeof( VioletFungus ), 5, Utility.Random( 10,100 ), 0x6412, 0 ) );
				Add( new GenericBuyInfo( typeof( WerewolfClaw ), 7, Utility.Random( 10,100 ), 0x6413, 0 ) );
				Add( new GenericBuyInfo( typeof( Wolfsbane ), 5, Utility.Random( 10,100 ), 0x6414, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BloodOathScroll ), 25, 5, 0x2263, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CorpseSkinScroll ), 28, 5, 0x2263, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CurseWeaponScroll ), 12, 5, 0x2263, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( TarotDeck ), 5, Utility.Random( 1,15 ), 0x12AB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PolishBoneBrush ), 12, 10, 0x1371, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GraveShovel ), 12, Utility.Random( 1,15 ), 0xF39, 0x966 ) ); }
				Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 1,15 ), 0x640B, 0 ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) );
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlackDyeTub ), 5000, 1, 0xFAB, 0x1 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( reagents_magic_jar2 ), 1500, Utility.Random( 1,15 ), 0x1007, 0xB97 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( HellsGateScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x54F ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ManaLeechScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xB87 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NecroCurePoisonScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x8A2 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NecroPoisonScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x4F8 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NecroUnlockScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x493 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( PhantasmScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x6DE ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( RetchedAirScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xA97 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( SpectreShadowScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x17E ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( UndeadEyesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x491 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( VampireGiftScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xB85 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( WallOfSpikesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xB8F ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( BloodPactScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x5B5 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GhostlyImagesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xBF ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GhostPhaseScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x47E ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GraveyardGatewayScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x2EA ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( HellsBrandScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x54C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BatWing ), 1 );
				Add( typeof( DaemonBlood ), 3 );
				Add( typeof( PigIron ), 2 );
				Add( typeof( NoxCrystal ), 3 );
				Add( typeof( GraveDust ), 1 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( GargoyleEar ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( PixieSkull ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				Add( typeof( BitterRoot ), 2 );
				Add( typeof( BlackSand ), 3 );
				Add( typeof( BloodRose ), 2 );
				Add( typeof( DriedToad ), 3 );
				Add( typeof( Maggot ), 2 );
				Add( typeof( MummyWrap ), 3 );
				Add( typeof( VioletFungus ), 2 );
				Add( typeof( WerewolfClaw ), 3 );
				Add( typeof( Wolfsbane ), 2 );
				Add( typeof( ExorcismScroll ), 72 );
				Add( typeof( AnimateDeadScroll ), 26 );
				Add( typeof( BloodOathScroll ), 26 );
				Add( typeof( CorpseSkinScroll ), 26 );
				Add( typeof( CurseWeaponScroll ), 26 );
				Add( typeof( EvilOmenScroll ), 26 );
				Add( typeof( PainSpikeScroll ), 26 );
				Add( typeof( SummonFamiliarScroll ), 26 );
				Add( typeof( HorrificBeastScroll ), 27 );
				Add( typeof( MindRotScroll ), 39 );
				Add( typeof( PoisonStrikeScroll ), 39 );
				Add( typeof( WraithFormScroll ), 51 );
				Add( typeof( LichFormScroll ), 64 );
				Add( typeof( StrangleScroll ), 64 );
				Add( typeof( WitherScroll ), 64 );
				Add( typeof( VampiricEmbraceScroll ), 101 );
				Add( typeof( VengefulSpiritScroll ), 114 );
				Add( typeof( PolishBoneBrush ), 6 );
				Add( typeof( PolishedSkull ), 3 );
				Add( typeof( PolishedBone ), 3 );
				Add( typeof( NecromancerSpellbook ), 55 );
				Add( typeof( DeathKnightSpellbook ), Utility.Random( 100,300 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullMinotaur ), Utility.Random( 50,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullWyrm ), Utility.Random( 200,400 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGreatDragon ), Utility.Random( 300,600 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDragon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDemon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGiant ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WitchCauldron ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MyNecromancerSpellbook ), Utility.Random( 100,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BlackDyeTub ), 2500 ); } // DO NOT WANT?
				Add( typeof( CorpseSailor ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( CorpseChest ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BuriedBody ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BodyPart ), Utility.RandomMinMax( 30, 90 ) );
				Add( typeof( BoneContainer ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( LeftLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( TastyHeart ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( Head ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( LeftArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Torso ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bone ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RibCage ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( BonePile ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bones ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( GraveChest ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DracolichSkull ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStaff ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStick ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMortician : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMortician()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GraveShovel ), 12, Utility.Random( 1,15 ), 0xF39, 0x966 ) ); }
				Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 1,15 ), 0x640B, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PolishBoneBrush ), 12, 10, 0x1371, 0 ) ); }
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) );
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( HellsGateScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x54F ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ManaLeechScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xB87 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NecroCurePoisonScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x8A2 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NecroPoisonScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x4F8 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( NecroUnlockScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x493 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( PhantasmScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x6DE ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( RetchedAirScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xA97 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( SpectreShadowScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x17E ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( UndeadEyesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x491 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( VampireGiftScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xB85 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( WallOfSpikesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xB8F ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( BloodPactScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x5B5 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GhostlyImagesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0xBF ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GhostPhaseScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x47E ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( GraveyardGatewayScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x2EA ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( HellsBrandScroll ), Utility.Random( 10,100 ), Utility.Random( 1,5 ), 0x1007, 0x54C ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WoodenCoffin ), 100, 1, 0x2800, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WoodenCasket ), 100, 1, 0x27E9, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StoneCoffin ), 180, 1, 0x27E0, 0 ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StoneCasket ), 180, 1, 0x2802, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullMinotaur ), Utility.Random( 50,150 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullWyrm ), Utility.Random( 200,400 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGreatDragon ), Utility.Random( 300,600 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDragon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullDemon ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SkullGiant ), Utility.Random( 100,300 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WitchCauldron ), 8 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MyNecromancerSpellbook ), Utility.Random( 100,500 ) ); } // DO NOT WANT?
				Add( typeof( CorpseSailor ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( CorpseChest ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BuriedBody ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BodyPart ), Utility.RandomMinMax( 30, 90 ) );
				Add( typeof( BoneContainer ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( LeftLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( TastyHeart ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( Head ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( LeftArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Torso ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bone ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RibCage ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( BonePile ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bones ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( GraveChest ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
				Add( typeof( PolishBoneBrush ), 6 );
				Add( typeof( PolishedSkull ), 3 );
				Add( typeof( PolishedBone ), 3 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenCoffin ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WoodenCasket ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneCoffin ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StoneCasket ), 45 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DracolichSkull ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Spellbook ), 18, Utility.Random( 1,15 ), 0xEFA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, Utility.Random( 1,15 ), 0x2253, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ScribesPen ), 8, Utility.Random( 1,15 ), 0x2051, 0 ) ); }
				if ( 1 > 0 ){Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, Utility.Random( 1,15 ), 0x1718, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WitchHat ), 11, Utility.Random( 1,15 ), 0x2FC3, Utility.RandomDyedHue() ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RecallRune ), 15, Utility.Random( 1,15 ), 0x1F14, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 1,15 ), 0x266F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 1,15 ), 0xF7B, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 1,15 ), 0xF84, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 1,15 ), 0xF85, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 1,15 ), 0xF86, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 1,15 ), 0xF88, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 1,15 ), 0xF8D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 1,15 ), 0xF8C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BatWing ), 3, Utility.Random( 1,15 ), 0xF78, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, Utility.Random( 1,15 ), 0xF7D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( PigIron ), 5, Utility.Random( 1,15 ), 0xF8A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, Utility.Random( 1,15 ), 0xF8E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GraveDust ), 3, Utility.Random( 1,15 ), 0xF8F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BitterRoot ), 5, Utility.Random( 1,15 ), 0x640C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackSand ), 7, Utility.Random( 1,15 ), 0x640D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BloodRose ), 5, Utility.Random( 1,15 ), 0x640E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DriedToad ), 7, Utility.Random( 1,15 ), 0x640F, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Maggot ), 5, Utility.Random( 1,15 ), 0x6410, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MummyWrap ), 7, Utility.Random( 1,15 ), 0x6411, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( VioletFungus ), 5, Utility.Random( 1,15 ), 0x6412, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WerewolfClaw ), 7, Utility.Random( 1,15 ), 0x6413, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Wolfsbane ), 5, Utility.Random( 1,15 ), 0x6414, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BloodOathScroll ), 25, Utility.Random( 1,15 ), 0x2263, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CorpseSkinScroll ), 28, Utility.Random( 1,15 ), 0x2263, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( CurseWeaponScroll ), 12, Utility.Random( 1,15 ), 0x2263, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( IronFlask ), 500, Utility.Random( 1,15 ), 0x282E, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }

				Type[] types = Loot.RegularScrollTypes;

				int circles = 3;

				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), Utility.Random( 1,15 ), itemID, 0 ) ); }
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicTalisman ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WizardsHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackPearl ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Bloodmoss ),4 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MandrakeRoot ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Garlic ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Ginseng ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Nightshade ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpidersSilk ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( SulfurousAsh ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BatWing ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DaemonBlood ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PigIron ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NoxCrystal ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GraveDust ), 1 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BitterRoot ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackSand ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BloodRose ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( DriedToad ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Maggot ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MummyWrap ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VioletFungus ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WerewolfClaw ), 3 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Wolfsbane ), 2 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RecallRune ), 13 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( Spellbook ), 25 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( NecromancerSpellbook ), 55 ); } // DO NOT WANT?
				if ( MyServerSettings.SellCommonChance() ){Add( typeof( MysticalPearl ), 250 ); } // DO NOT WANT?

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					if ( MyServerSettings.BuyChance() ){Add( types[i], ((i / 8) + 1) * 4 ); } // DO NOT WANT?

				if ( MyServerSettings.BuyChance() ){Add( typeof( ExorcismScroll ), 72 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AnimateDeadScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( BloodOathScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CorpseSkinScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( CurseWeaponScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EvilOmenScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PainSpikeScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SummonFamiliarScroll ), 26 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( HorrificBeastScroll ), 27 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MindRotScroll ), 39 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( PoisonStrikeScroll ), 39 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WraithFormScroll ), 51 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( LichFormScroll ), 64 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StrangleScroll ), 64 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitherScroll ), 64 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VampiricEmbraceScroll ), 101 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( VengefulSpiritScroll ), 114 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ClumsyMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CreateFoodMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FeebleMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HealMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicArrowMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( NightSightMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ReactiveArmorMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WeaknessMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AgilityMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CunningMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CureMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HarmMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicTrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUntrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ProtectionMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( StrengthMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BlessMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireballMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicLockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUnlockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TelekinesisMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TeleportMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WallofStoneMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchCureMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchProtectionMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CurseMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireFieldMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GreaterHealMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( LightningMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaDrainMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RecallMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BladeSpiritsMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( IncognitoMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicReflectionMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MindBlastMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonCreatureMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyBoltMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ExplosionMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( InvisibilityMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MarkMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassCurseMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeFieldMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RevealMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ChainLightningMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyFieldMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FlameStrikeMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GateTravelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaVampireMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassDispelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MeteorSwarmMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PolymorphMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AirElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthquakeMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyVortexMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ResurrectionMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonDaemonMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WaterElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MyNecromancerSpellbook ), Utility.Random( 100,500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( MySpellbook ), Utility.Random( 100,500 ) ); } // DO NOT WANT?
				Add( typeof( TomeOfWands ), Utility.Random( 100,400 ) );
				if ( MyServerSettings.SellChance() ){Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.SellChance() ){ Add( typeof( WizardStaff ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.SellChance() ){ Add( typeof( WizardStick ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.SellChance() ){ Add( typeof( MageEye ), 1 ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBElementalist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElementalist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( ElementalSpellbook ), 80, Utility.Random( 1,5 ), Utility.RandomList( 0x641F, 0x6420, 0x6421, 0x6422 ), 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,30 ), 0xF0B, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( TotalRefreshPotion ), 30, Utility.Random( 1,30 ), 0x25FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( LesserManaPotion ), 860, Utility.Random( 1,25 ), 0x23BD, 0x48D ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( ManaPotion ), 890, Utility.Random( 1,15 ), 0x180F, 0x48D ) ); }
				if ( MyServerSettings.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GreaterManaPotion ), 8120, Utility.Random( 1,5 ), 0x2406, 0x48D ) ); }

				int id=299;
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Armor_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Bolt_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Mend_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; Add( new GenericBuyInfo( typeof( Elemental_Sanctuary_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Pain_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Protection_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Purge_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Steed_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Call_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Force_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Wall_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Warp_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				/*
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Field_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Restoration_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Strike_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Void_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Blast_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Echo_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Fiend_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Hold_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Barrage_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Rune_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Storm_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Summon_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Devastation_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Fall_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Gate_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Havoc_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Apocalypse_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Lord_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Soul_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				id++; if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( Elemental_Spirit_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) ); }
				*/
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MagicTalisman ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WizardsHat ), 5 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( WitchHat ), 5 ); } // DO NOT WANT?
				Add( typeof( ElementalSpellbook ), 35 );
				Add( typeof( MyElementalSpellbook ), 500 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStaff ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( WizardStick ), 19 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){ Add( typeof( MageEye ), 1 ); } // DO NOT WANT?

				int id=299;
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Armor_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Bolt_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Mend_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Sanctuary_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Pain_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Protection_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Purge_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Steed_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Call_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Force_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Wall_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Warp_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Field_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Restoration_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Strike_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Void_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Blast_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Echo_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Fiend_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Hold_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Barrage_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Rune_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Storm_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Summon_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Devastation_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Fall_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Gate_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Havoc_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Apocalypse_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Lord_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Soul_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
				id++; if ( MyServerSettings.BuyChance() ){ Add( typeof( Elemental_Spirit_Scroll ), ElementalSpell.ScrollPrice( id, true ) ); }
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBGodlySewing: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGodlySewing()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GodSewing ), 1000, 20, 0x0F9F, 0x501 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBGodlySmithing: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGodlySmithing()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GodSmithing ), 1000, 20, 0x0FB5, 0x501 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBGodlyBrewing: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGodlyBrewing()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GodBrewing ), 1000, 20, 0x0E28, 0x501 ) );
				Add( new GenericBuyInfo( typeof( reagents_magic_jar1 ), 2000, Utility.Random( 1,15 ), 0x1007, 0 ) );
				Add( new GenericBuyInfo( typeof( reagents_magic_jar2 ), 1500, Utility.Random( 1,15 ), 0x1007, 0xB97 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMazeStore: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMazeStore()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( reagents_magic_jar1 ), 2000, 20, 0x1007, 0 ) );
				Add( new GenericBuyInfo( typeof( reagents_magic_jar2 ), 1500, 20, 0x1007, 0xB97 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBArtyReview: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBArtyReview()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Artifact_AbysmalGloves ), 0, 1, 5062, 1172 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AchillesShield ), 0, 1, 7026, 0xB1B ) );
				Add( new GenericBuyInfo( typeof( Artifact_AchillesSpear ), 0, 1, 3938, 0xB1B ) );
				Add( new GenericBuyInfo( typeof( Artifact_AcidProofRobe ), 0, 1, 7939, 1167 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Aegis ), 0, 1, 7030, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AegisOfGrace ), 0, 1, 9797, 1645 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AilricsLongbow ), 0, 1, 11550, 1460 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AlchemistsBauble ), 0, 1, 11408, 1420 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SamuraiHelm ), 0, 1, 10117, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AngelicEmbrace ), 0, 1, 5136, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AngeroftheGods ), 0, 1, 3934, 1265 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Annihilation ), 0, 1, 3917, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneArms ), 0, 1, 5069, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneCap ), 0, 1, 7609, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneGloves ), 0, 1, 5062, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneGorget ), 0, 1, 5063, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneLeggings ), 0, 1, 5067, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneShield ), 0, 1, 7032, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcaneTunic ), 0, 1, 5068, 1366 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcanicRobe ), 0, 1, 7939, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcticDeathDealer ), 0, 1, 5127, 0xB3E ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmorOfFortune ), 0, 1, 5083, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmorOfInsight ), 0, 1, 5141, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmorOfNobility ), 0, 1, 5100, 1278 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfAegis ), 0, 1, 5136, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfFortune ), 0, 1, 5084, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfInsight ), 0, 1, 5136, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfNobility ), 0, 1, 5102, 1278 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfTheFallenKing ), 0, 1, 5069, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfTheHarrower ), 0, 1, 5198, 1270 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArmsOfToxicity ), 0, 1, 5069, 1272 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AuraOfShadows ), 0, 1, 2584, 2020 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AxeOfTheHeavens ), 0, 1, 3915, 1237 ) );
				Add( new GenericBuyInfo( typeof( Artifact_AxeoftheMinotaur ), 0, 1, 5115, 1157 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BeggarsRobe ), 0, 1, 22141, 2424 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BeltofHercules ), 0, 1, 10128, 2900 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TheBeserkersMaul ), 0, 1, 5179, 33 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BladeDance ), 0, 1, 11570, 1644 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BladeOfInsanity ), 0, 1, 5119, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ConansSword ), 0, 1, 22159, 2101 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BladeOfTheRighteous ), 0, 1, 3937, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowBlade ), 0, 1, 3937, 1899 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BlazeOfDeath ), 0, 1, 5182, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BlightGrippedLongbow ), 0, 1, 11550, 2212 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BloodwoodSpirit ), 0, 1, 11413, 39 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BoneCrusher ), 0, 1, 5126, 1548 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Bonesmasher ), 0, 1, 11556, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BookOfKnowledge ), 0, 1, 3834, 2815 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Boomstick ), 0, 1, 11557, 37 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BootsofHermes ), 0, 1, 12228, 2989 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BootsofPyros ), 0, 1, 0x2FC4, 0x981 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BootsofHydros ), 0, 1, 0x2FC4, 0x97F ) );
				Add( new GenericBuyInfo( typeof( Artifact_BootsofLithos ), 0, 1, 0x2FC4, 0x85D ) );
				Add( new GenericBuyInfo( typeof( Artifact_BootsofStratos ), 0, 1, 0x2FC4, 0xAFE ) );
				Add( new GenericBuyInfo( typeof( Artifact_BowOfTheJukaKing ), 0, 1, 5042, 1120 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BowofthePhoenix ), 0, 1, 11550, 1161 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BraceletOfHealth ), 0, 1, 19692, 33 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BraceletOfTheElements ), 0, 1, 19697, 1257 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BraceletOfTheVile ), 0, 1, 19697, 1271 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BrambleCoat ), 0, 1, 5068, 1 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BraveKnightOfTheBritannia ), 0, 1, 5119, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BreathOfTheDead ), 0, 1, 9915, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BurglarsBandana ), 0, 1, 5440, 16 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Calm ), 0, 1, 5182, 715 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CandleCold ), 0, 1, 2600, 1165 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CandleEnergy ), 0, 1, 2600, 1168 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CandleFire ), 0, 1, 2600, 1166 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CandleNecromancer ), 0, 1, 2600, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CandlePoison ), 0, 1, 2600, 1167 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CandleWizard ), 0, 1, 2600, 2966 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CapOfFortune ), 0, 1, 7609, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CapOfTheFallenKing ), 0, 1, 7609, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CaptainJohnsHat ), 0, 1, 5915, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CaptainQuacklebushsCutlass ), 0, 1, 5185, 1644 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CavortingClub ), 0, 1, 5044, 1427 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CircletOfTheSorceress ), 0, 1, 0x2B6F, 2062 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GrayMouserCloak ), 0, 1, 5397, 2407 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CoifOfBane ), 0, 1, 5051, 1269 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CoifOfFire ), 0, 1, 5051, 1359 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ColdBlood ), 0, 1, 3779, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ColdForgedBlade ), 0, 1, 11552, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CrimsonCincture ), 0, 1, 5435, 1157 ) );
				Add( new GenericBuyInfo( typeof( Artifact_CrownOfTalKeesh ), 0, 1, 5440, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DaggerOfVenom ), 0, 1, 3922, 1270 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DarkGuardiansChest ), 0, 1, 5141, 1141 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DarkLordsPitchfork ), 0, 1, 3719, 1157 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DarkNeck ), 0, 1, 5139, 2025 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DetectiveBoots ), 0, 1, 5899, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DivineArms ), 0, 1, 5069, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DivineCountenance ), 0, 1, 5449, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DivineGloves ), 0, 1, 5062, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DivineGorget ), 0, 1, 5063, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DivineLeggings ), 0, 1, 5067, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DivineTunic ), 0, 1, 5068, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DjinnisRing ), 0, 1, 19701, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DreadPirateHat ), 0, 1, 5915, 1175 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TheDryadBow ), 0, 1, 5041, 1167 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DupresCollar ), 0, 1, 5139, 794 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DupresShield ), 0, 1, 7108, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EarringsOfHealth ), 0, 1, 19707, 33 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EarringsOfTheElements ), 0, 1, 19707, 1257 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EarringsOfTheMagician ), 0, 1, 19707, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EarringsOfTheVile ), 0, 1, 19707, 1271 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EmbroideredOakLeafCloak ), 0, 1, 5397, 1155 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EnchantedTitanLegBone ), 0, 1, 5123, 2213 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EssenceOfBattle ), 0, 1, 19702, 1360 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EternalFlame ), 0, 1, 2584, 1355 ) );
				Add( new GenericBuyInfo( typeof( Artifact_EvilMageGloves ), 0, 1, 0x13C6, 0x8E4 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Excalibur ), 0, 1, 22159, 2101 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FangOfRactus ), 0, 1, 5121, 279 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FesteringWound ), 0, 1, 5121, 1272 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FeyLeggings ), 0, 1, 5054, 0xB51 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FleshRipper ), 0, 1, 11553, 833 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Fortifiedarms ), 0, 1, 5198, 1165 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FortunateBlades ), 0, 1, 10153, 2213 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Frostbringer ), 0, 1, 5042, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FurCapeOfTheSorceress ), 0, 1, 5397, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Fury ), 0, 1, 5119, 1357 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MarbleShield ), 0, 1, 7030, 2961 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GuantletsOfAnger ), 0, 1, 5140, 667 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GauntletsOfNobility ), 0, 1, 5099, 1278 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GeishasObi ), 0, 1, 10144, 31 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GiantBlackjack ), 0, 1, 5044, 1175 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GladiatorsCollar ), 0, 1, 5139, 621 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfAegis ), 0, 1, 5140, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfCorruption ), 0, 1, 5062, 2070 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfDexterity ), 0, 1, 5062, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfFortune ), 0, 1, 5077, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfInsight ), 0, 1, 5140, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfRegeneration ), 0, 1, 5062, 1284 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfTheFallenKing ), 0, 1, 5062, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfTheHarrower ), 0, 1, 5200, 1270 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlovesOfThePugilist ), 0, 1, 5062, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SamaritanRobe ), 0, 1, 7939, 675 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GorgetOfAegis ), 0, 1, 5139, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GorgetOfFortune ), 0, 1, 5078, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GorgetOfInsight ), 0, 1, 5139, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GrimReapersLantern ), 0, 1, 2584, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GrimReapersMask ), 0, 1, 5201, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GrimReapersRobe ), 0, 1, 7939, 0xAF0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GrimReapersScythe ), 0, 1, 9914, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PyrosGrimoire ), 0, 1, 0x6422, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TownGuardsHalberd ), 0, 1, 5182, 1407 ) );
				Add( new GenericBuyInfo( typeof( GwennosHarp ), 0, 1, 3762, 2500 ) );
				Add( new GenericBuyInfo( typeof( HornOfKingTriton ), 0, 1, 3762, 2500 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HammerofThor ), 0, 1, 4021, 1072 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HatOfTheMagi ), 0, 1, 5912, 0xB33 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HeartOfTheLion ), 0, 1, 5141, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HellForgedArms ), 0, 1, 5136, 1208 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HelmOfAegis ), 0, 1, 5138, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HelmOfBrilliance ), 0, 1, 5134, 2900 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HelmOfInsight ), 0, 1, 5138, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HelmOfSwiftness ), 0, 1, 5134, 1426 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ConansHelm ), 0, 1, 9797, 2101 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolyKnightsArmPlates ), 0, 1, 11018, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolyKnightsBreastplate ), 0, 1, 11016, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolyKnightsGloves ), 0, 1, 11020, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolyKnightsGorget ), 0, 1, 11022, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolyKnightsLegging ), 0, 1, 11014, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolyKnightsPlateHelm ), 0, 1, 11024, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LunaLance ), 0, 1, 9920, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HolySword ), 0, 1, 3937, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HoodedShroudOfShadows ), 0, 1, 12217, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HuntersArms ), 0, 1, 5069, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HuntersGloves ), 0, 1, 5062, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HuntersGorget ), 0, 1, 5063, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HuntersHeaddress ), 0, 1, 5447, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HuntersLeggings ), 0, 1, 5067, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HuntersTunic ), 0, 1, 5068, 1428 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Indecency ), 0, 1, 5083, 2075 ) );
				Add( new GenericBuyInfo( typeof( Artifact_InquisitorsArms ), 0, 1, 5136, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_InquisitorsGorget ), 0, 1, 5139, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_InquisitorsHelm ), 0, 1, 5138, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_InquisitorsLeggings ), 0, 1, 5137, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_InquisitorsResolution ), 0, 1, 5140, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_InquisitorsTunic ), 0, 1, 5141, 1266 ) );
				Add( new GenericBuyInfo( typeof( IolosLute ), 0, 1, 3763, 2500 ) );
				Add( new GenericBuyInfo( typeof( Artifact_IronwoodCrown ), 0, 1, 5134, 2913 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JackalsArms ), 0, 1, 5136, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JackalsCollar ), 0, 1, 5139, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JackalsGloves ), 0, 1, 5140, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JackalsHelm ), 0, 1, 5138, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JackalsLeggings ), 0, 1, 5137, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JackalsTunic ), 0, 1, 5141, 1745 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JadeScimitar ), 0, 1, 5046, 2964 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JesterHatofChuckles ), 0, 1, 5916, 3 ) );
				Add( new GenericBuyInfo( typeof( Artifact_JinBaoriOfGoodFortune ), 0, 1, 10145, 2125 ) );
				Add( new GenericBuyInfo( typeof( Artifact_KamiNarisIndestructableDoubleAxe ), 0, 1, 3915, 1161 ) );
				Add( new GenericBuyInfo( typeof( Artifact_KodiakBearMask ), 0, 1, 5445, 1899 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PowerSurge ), 0, 1, 2584, 1158 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LegacyOfTheDreadLord ), 0, 1, 3917, 1654 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LegsOfFortune ), 0, 1, 5082, 1281 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LegsOfInsight ), 0, 1, 5137, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LeggingsOfAegis ), 0, 1, 5137, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LeggingsOfBane ), 0, 1, 5054, 1269 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LeggingsOfDeceit ), 0, 1, 5054, 38 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LeggingsOfEnlightenment ), 0, 1, 5067, 1159 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LeggingsOfFire ), 0, 1, 5054, 1359 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LegsOfTheFallenKing ), 0, 1, 5067, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LegsOfTheHarrower ), 0, 1, 5202, 1270 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LegsOfNobility ), 0, 1, 5104, 1278 ) );
				Add( new GenericBuyInfo( typeof( Artifact_HydrosLexicon ), 0, 1, 0x6420, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ConansLoinCloth ), 0, 1, 11112, 2424 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LongShot ), 0, 1, 9922, 1195 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LuckyEarrings ), 0, 1, 19707, 0xAFF ) );
				Add( new GenericBuyInfo( typeof( Artifact_LuckyNecklace ), 0, 1, 19711, 0xAFF ) );
				Add( new GenericBuyInfo( typeof( Artifact_LuminousRuneBlade ), 0, 1, 11570, 1278 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MadmansHatchet ), 0, 1, 3907, 1157 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MagesBand ), 0, 1, 19705, 1170 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MagiciansIllusion ), 0, 1, 9919, 1072 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MagiciansMempo ), 0, 1, 10105, 1151 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MantleofPyros ), 0, 1, 0x5C14, 0x981 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MantleofHydros ), 0, 1, 0x5C14, 0x97F ) );
				Add( new GenericBuyInfo( typeof( Artifact_MantleofLithos ), 0, 1, 0x5C14, 0x85D ) );
				Add( new GenericBuyInfo( typeof( Artifact_MantleofStratos ), 0, 1, 0x5C14, 0xAFE ) );
				Add( new GenericBuyInfo( typeof( Artifact_StratosManual ), 0, 1, 0x6421, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_DeathsMask ), 0, 1, 5201, 2518 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MauloftheBeast ), 0, 1, 5179, 1779 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MaulOfTheTitans ), 0, 1, 5179, 2953 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MelisandesCorrodedHatchet ), 0, 1, 3907, 1172 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GandalfsHat ), 0, 1, 5912, 2953 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GandalfsRobe ), 0, 1, 9902, 2953 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GandalfsStaff ), 0, 1, 3721, 2949 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MidnightBracers ), 0, 1, 5198, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MidnightGloves ), 0, 1, 5200, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MidnightHelm ), 0, 1, 5201, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MidnightLegs ), 0, 1, 5202, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MidnightTunic ), 0, 1, 5199, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_MinersPickaxe ), 0, 1, 3718, 974 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ANecromancerShroud ), 0, 1, 7939, 12218 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TheNightReaper ), 0, 1, 9933, 1052 ) );
				Add( new GenericBuyInfo( typeof( Artifact_NightsKiss ), 0, 1, 3921, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_NordicVikingSword ), 0, 1, 0x568F, 741 ) );
				Add( new GenericBuyInfo( typeof( Artifact_VampiresRobe ), 0, 1, 8221, 1175 ) );
				Add( new GenericBuyInfo( typeof( Artifact_NoxBow ), 0, 1, 5117, 267 ) );
				Add( new GenericBuyInfo( typeof( Artifact_NoxNightlight ), 0, 1, 2584, 1269 ) );
				Add( new GenericBuyInfo( typeof( Artifact_NoxRangersHeavyCrossbow ), 0, 1, 5117, 1420 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OblivionsNeedle ), 0, 1, 3922, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OrcChieftainHelm ), 0, 1, 7947, 675 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OrcishVisage ), 0, 1, 7947, 1426 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OrnamentOfTheMagician ), 0, 1, 19696, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OrnateCrownOfTheHarrower ), 0, 1, 5201, 1270 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OssianGrimoire ), 0, 1, 8787, 2713 ) );
				Add( new GenericBuyInfo( typeof( Artifact_OverseerSunderedBlade ), 0, 1, 11559, 1260 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Pacify ), 0, 1, 9918, 2101 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PadsOfTheCuSidhe ), 0, 1, 8967, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PendantOfTheMagi ), 0, 1, 19711, 1165 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Pestilence ), 0, 1, 0x2B02, 1151 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PhantomStaff ), 0, 1, 11557, 1 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PixieSwatter ), 0, 1, 9916, 138 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PolarBearBoots ), 0, 1, 8967, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PolarBearCape ), 0, 1, 8970, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Quell ), 0, 1, 3917, 549 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfBlight ), 0, 1, 11010, 2937 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfFire ), 0, 1, 11010, 2839 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfIce ), 0, 1, 11010, 2456 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfInfinity ), 0, 1, 11010, 2458 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfLightning ), 0, 1, 11010, 2265 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfRage ), 0, 1, 11010, 2817 ) );
				Add( new GenericBuyInfo( typeof( QuiverOfElements ), 0, 1, 11010, 2814 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RaedsGlory ), 0, 1, 11555, 486 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RamusNecromanticScalpel ), 0, 1, 3922, 1372 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ResilientBracer ), 0, 1, 19697, 1160 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Retort ), 0, 1, 5125, 910 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RighteousAnger ), 0, 1, 11573, 644 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RingOfHealth ), 0, 1, 19704, 33 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RingOfProtection ), 0, 1, 19706, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RingOfTheElements ), 0, 1, 19702, 1257 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RingOfTheMagician ), 0, 1, 19704, 1364 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RingOfTheVile ), 0, 1, 19699, 1271 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TheRobeOfBritanniaAri ), 0, 1, 7939, 1163 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeOfTeleportation ), 0, 1, 7939, 2124 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeofPyros ), 0, 1, 0x2B69, 0x981 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeOfTheEclipse ), 0, 1, 7940, 1158 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeOfTheEquinox ), 0, 1, 7940, 214 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeofHydros ), 0, 1, 0x0289, 0x97F ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeofLithos ), 0, 1, 0x0287, 0x85D ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeofStratos ), 0, 1, 0x2B6A, 0xAFE ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobeOfTreason ), 0, 1, 7939, 1107 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobinHoodsBow ), 0, 1, 9922, 1155 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RobinHoodsFeatheredHat ), 0, 1, 5914, 276 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RodOfResurrection ), 0, 1, 9916, 1196 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RoyalArchersBow ), 0, 1, 5042, 2101 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LieutenantOfTheBritannianRoyalGuard ), 0, 1, 5441, 232 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RoyalGuardSurvivalKnife ), 0, 1, 3922, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RoyalGuardsGorget ), 0, 1, 5139, 2956 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RoyalGuardsChestplate ), 0, 1, 5141, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LeggingsOfEmbers ), 0, 1, 5137, 44 ) );
				Add( new GenericBuyInfo( typeof( Artifact_RuneCarvingKnife ), 0, 1, 11553, 1165 ) );
				Add( new GenericBuyInfo( typeof( Artifact_FalseGodsScepter ), 0, 1, 9916, 1107 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SerpentsFang ), 0, 1, 5120, 1160 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowDancerArms ), 0, 1, 5069, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowDancerCap ), 0, 1, 7609, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowDancerGloves ), 0, 1, 5062, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowDancerGorget ), 0, 1, 5063, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowDancerLeggings ), 0, 1, 5074, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShadowDancerTunic ), 0, 1, 5068, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShaMontorrossbow ), 0, 1, 9923, 1284 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShardThrasher ), 0, 1, 11556, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShieldOfInvulnerability ), 0, 1, 7108, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShimmeringTalisman ), 0, 1, 11391, 1266 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ShroudOfDeciet ), 0, 1, 5199, 911 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SilvanisFeywoodBow ), 0, 1, 11550, 26 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TheDragonSlayer ), 0, 1, 9920, 1328 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SongWovenMantle ), 0, 1, 5069, 1171 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SoulSeeker ), 0, 1, 11571, 908 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SpellWovenBritches ), 0, 1, 5067, 1159 ) );
				Add( new GenericBuyInfo( typeof( Artifact_PolarBearMask ), 0, 1, 5445, 1153 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SpiritOfTheTotem ), 0, 1, 5445, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SprintersSandals ), 0, 1, 5901, 1372 ) );
				Add( new GenericBuyInfo( typeof( Artifact_StaffOfPower ), 0, 1, 3568, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_StaffOfTheMagi ), 0, 1, 3568, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_StaffofSnakes ), 0, 1, 3721, 772 ) );
				Add( new GenericBuyInfo( typeof( Artifact_StitchersMittens ), 0, 1, 5062, 1153 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Stormbringer ), 0, 1, 5049, 1899 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Subdue ), 0, 1, 9914, 715 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SwiftStrike ), 0, 1, 10148, 2111 ) );
				Add( new GenericBuyInfo( typeof( Artifact_GlassSword ), 0, 1, 9934, 91 ) );
				Add( new GenericBuyInfo( typeof( Artifact_SinbadsSword ), 0, 1, 5185, 1169 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TalonBite ), 0, 1, 11572, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TheTaskmaster ), 0, 1, 5125, 1272 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TitansHammer ), 0, 1, 5177, 1154 ) );
				Add( new GenericBuyInfo( typeof( Artifact_LithosTome ), 0, 1, 0x641F, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TorchOfTrapFinding ), 0, 1, 3947, 0 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TotemArms ), 0, 1, 5069, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TotemGloves ), 0, 1, 5062, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TotemGorget ), 0, 1, 5063, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TotemLeggings ), 0, 1, 5067, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TotemOfVoid ), 0, 1, 12123, 720 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TotemTunic ), 0, 1, 5068, 1109 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TunicOfAegis ), 0, 1, 5141, 1150 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TunicOfBane ), 0, 1, 5055, 1269 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TunicOfFire ), 0, 1, 5055, 1359 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TunicOfTheFallenKing ), 0, 1, 5068, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_TunicOfTheHarrower ), 0, 1, 5199, 1270 ) );
				Add( new GenericBuyInfo( typeof( Artifact_BelmontWhip ), 0, 1, 0x6453, 0x986 ) );
				Add( new GenericBuyInfo( typeof( Artifact_VampiricDaisho ), 0, 1, 10153, 1153 ) );
				Add( new GenericBuyInfo( typeof( Artifact_VioletCourage ), 0, 1, 7172, 1158 ) );
				Add( new GenericBuyInfo( typeof( Artifact_VoiceOfTheFallenKing ), 0, 1, 5063, 1901 ) );
				Add( new GenericBuyInfo( typeof( Artifact_WarriorsClasp ), 0, 1, 19697, 2117 ) );
				Add( new GenericBuyInfo( typeof( Artifact_WildfireBow ), 0, 1, 11550, 1161 ) );
				Add( new GenericBuyInfo( typeof( Artifact_Windsong ), 0, 1, 11563, 172 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ArcticBeacon ), 0, 1, 2584, 1151 ) );
				Add( new GenericBuyInfo( typeof( Artifact_WizardsPants ), 0, 1, 5067, 1265 ) );
				Add( new GenericBuyInfo( typeof( Artifact_WrathOfTheDryad ), 0, 1, 5112, 668 ) );
				Add( new GenericBuyInfo( typeof( Artifact_YashimotosHatsuburi ), 0, 1, 10100, 1157 ) );
				Add( new GenericBuyInfo( typeof( Artifact_ZyronicClaw ), 0, 1, 3909, 1157 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBuyArtifacts: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBuyArtifacts()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AbysmalGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AchillesShield ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AchillesSpear ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AcidProofRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Aegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AegisOfGrace ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AilricsLongbow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AlchemistsBauble ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ANecromancerShroud ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AngelicEmbrace ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AngeroftheGods ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Annihilation ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneCap ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneShield ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcaneTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcanicRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcticBeacon ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArcticDeathDealer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmorOfFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmorOfInsight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmorOfNobility ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfAegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfInsight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfNobility ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfTheFallenKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfTheHarrower ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ArmsOfToxicity ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AuraOfShadows ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AxeOfTheHeavens ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_AxeoftheMinotaur ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BeggarsRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BelmontWhip ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BeltofHercules ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BladeDance ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BladeOfInsanity ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BladeOfTheRighteous ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BlazeOfDeath ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BlightGrippedLongbow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BloodwoodSpirit ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BoneCrusher ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Bonesmasher ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Boomstick ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BootsofHermes ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BowOfTheJukaKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BowofthePhoenix ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BraceletOfHealth ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BraceletOfTheElements ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BraceletOfTheVile ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BrambleCoat ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BraveKnightOfTheBritannia ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BreathOfTheDead ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BurglarsBandana ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Calm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CandleCold ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CandleEnergy ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CandleFire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CandleNecromancer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CandlePoison ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CandleWizard ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CapOfFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CapOfTheFallenKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CaptainJohnsHat ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CaptainQuacklebushsCutlass ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CavortingClub ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CircletOfTheSorceress ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CoifOfBane ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CoifOfFire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ColdBlood ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ColdForgedBlade ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ConansHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ConansLoinCloth ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ConansSword ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CrimsonCincture ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_CrownOfTalKeesh ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DaggerOfVenom ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DarkGuardiansChest ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DarkLordsPitchfork ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DarkNeck ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DeathsMask ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DetectiveBoots ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DivineArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DivineCountenance ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DivineGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DivineGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DivineLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DivineTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DjinnisRing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DreadPirateHat ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DupresCollar ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_DupresShield ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EarringsOfHealth ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RingOfProtection ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EarringsOfTheElements ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EarringsOfTheMagician ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EarringsOfTheVile ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EmbroideredOakLeafCloak ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EnchantedTitanLegBone ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EssenceOfBattle ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EternalFlame ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_EvilMageGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Excalibur ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FalseGodsScepter ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FangOfRactus ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FesteringWound ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FeyLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FleshRipper ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Fortifiedarms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FortunateBlades ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Frostbringer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_FurCapeOfTheSorceress ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Fury ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GandalfsHat ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GandalfsRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GandalfsStaff ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GauntletsOfNobility ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GeishasObi ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GiantBlackjack ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GladiatorsCollar ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlassSword ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfAegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfCorruption ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfDexterity ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfInsight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfRegeneration ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfTheFallenKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfTheHarrower ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GlovesOfThePugilist ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GorgetOfAegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GorgetOfFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GorgetOfInsight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GrayMouserCloak ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GrimReapersLantern ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GrimReapersMask ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GrimReapersRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GrimReapersScythe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_GuantletsOfAnger ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HammerofThor ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HatOfTheMagi ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HeartOfTheLion ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HellForgedArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HelmOfAegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HelmOfBrilliance ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HelmOfInsight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HelmOfSwiftness ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolyKnightsArmPlates ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolyKnightsBreastplate ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolyKnightsGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolyKnightsGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolyKnightsLegging ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolyKnightsPlateHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HolySword ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HoodedShroudOfShadows ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HuntersArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HuntersGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HuntersGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HuntersHeaddress ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HuntersLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HuntersTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Indecency ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_InquisitorsArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_InquisitorsGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_InquisitorsHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_InquisitorsLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_InquisitorsResolution ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_InquisitorsTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_IronwoodCrown ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JackalsArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JackalsCollar ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JackalsGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JackalsHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JackalsLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JackalsTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JadeScimitar ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JesterHatofChuckles ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_JinBaoriOfGoodFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_KamiNarisIndestructableDoubleAxe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_KodiakBearMask ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LegacyOfTheDreadLord ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LeggingsOfAegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LeggingsOfBane ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LeggingsOfDeceit ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LeggingsOfEmbers ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LeggingsOfEnlightenment ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LeggingsOfFire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LegsOfFortune ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LegsOfInsight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LegsOfNobility ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LegsOfTheFallenKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LegsOfTheHarrower ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LieutenantOfTheBritannianRoyalGuard ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LongShot ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LuckyEarrings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LuckyNecklace ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LuminousRuneBlade ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LunaLance ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MadmansHatchet ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MagesBand ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MagiciansIllusion ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MagiciansMempo ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MarbleShield ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MauloftheBeast ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MaulOfTheTitans ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MelisandesCorrodedHatchet ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MidnightBracers ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MidnightGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MidnightHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MidnightLegs ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MidnightTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MinersPickaxe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_NightsKiss ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_NordicVikingSword ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_NoxBow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_NoxNightlight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_NoxRangersHeavyCrossbow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_OblivionsNeedle ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_OrcChieftainHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_OrcishVisage ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_OrnamentOfTheMagician ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_OrnateCrownOfTheHarrower ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_OverseerSunderedBlade ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Pacify ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PadsOfTheCuSidhe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PendantOfTheMagi ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Pestilence ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PhantomStaff ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PixieSwatter ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PolarBearBoots ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PolarBearCape ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PolarBearMask ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PowerSurge ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Quell ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RaedsGlory ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RamusNecromanticScalpel ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ResilientBracer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Retort ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RighteousAnger ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RingOfHealth ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RingOfTheElements ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RingOfTheMagician ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RingOfTheVile ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeOfTeleportation ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeOfTheEclipse ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeOfTheEquinox ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeOfTreason ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobinHoodsBow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobinHoodsFeatheredHat ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RodOfResurrection ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RoyalArchersBow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RoyalGuardsChestplate ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RoyalGuardsGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RoyalGuardSurvivalKnife ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RuneCarvingKnife ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SamaritanRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SamuraiHelm ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SerpentsFang ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowBlade ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowDancerArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowDancerCap ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowDancerGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowDancerGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowDancerLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShadowDancerTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShaMontorrossbow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShardThrasher ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShieldOfInvulnerability ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShimmeringTalisman ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ShroudOfDeciet ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SilvanisFeywoodBow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SinbadsSword ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SongWovenMantle ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SoulSeeker ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SpellWovenBritches ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SpiritOfTheTotem ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SprintersSandals ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_StaffOfPower ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_StaffofSnakes ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_StaffOfTheMagi ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_StitchersMittens ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Stormbringer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Subdue ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_SwiftStrike ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TalonBite ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TheBeserkersMaul ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TheDragonSlayer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TheDryadBow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TheNightReaper ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TheRobeOfBritanniaAri ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TheTaskmaster ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TitansHammer ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TorchOfTrapFinding ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TotemArms ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TotemGloves ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TotemGorget ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TotemLeggings ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TotemOfVoid ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TotemTunic ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TownGuardsHalberd ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TunicOfAegis ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TunicOfBane ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TunicOfFire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TunicOfTheFallenKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_TunicOfTheHarrower ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_VampiresRobe ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_VampiricDaisho ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_VioletCourage ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_VoiceOfTheFallenKing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_WarriorsClasp ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_WildfireBow ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_Windsong ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_WizardsPants ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_WrathOfTheDryad ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_YashimotosHatsuburi ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_ZyronicClaw ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( BookOfKnowledge ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( ColoringBook ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( EverlastingBottle ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( EverlastingLoaf ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( GemOfSeeing ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( GwennosHarp ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( HornOfKingTriton ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( IolosLute ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( OssianGrimoire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( PandorasBox ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfBlight ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfElements ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfFire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfIce ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfInfinity ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfLightning ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( QuiverOfRage ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( PhillipsWoodenSteed ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeofStratos ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BootsofHydros ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BootsofLithos ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BootsofPyros ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_BootsofStratos ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MantleofHydros ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MantleofLithos ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MantleofPyros ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_MantleofStratos ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeofHydros ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeofLithos ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_RobeofPyros ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_PyrosGrimoire ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_StratosManual ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_HydrosLexicon ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){Add( typeof( Artifact_LithosTome ), Utility.Random( 250,2500 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBGemArmor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGemArmor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AmethystShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "amethyst", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EmeraldShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "emerald", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GarnetShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "garnet", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IceFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IcePlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IcePlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IcePlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IcePlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IcePlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IcePlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IceShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "ice", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadeFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadePlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadePlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadePlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadePlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadePlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadePlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JadeShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "jade", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarbleFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarblePlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarblePlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarblePlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarblePlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarblePlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarblePlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarbleShields ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "marble", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( OnyxShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "onyx", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( QuartzShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "quartz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RubyShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphireFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphirePlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphirePlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphirePlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphirePlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphirePlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphirePlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SapphireShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "sapphire", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SilverShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "silver", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SpinelShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "spinel", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StarRubyShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "star ruby", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazFemalePlateChest ), 5513, 1, 0x1C04, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazPlateArms ), 5494, 1, 0x1410, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazPlateChest ), 5521, 1, 0x1415, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazPlateGloves ), 5372, 1, 0x1414, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazPlateGorget ), 5352, 1, 0x1413, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazPlateHelm ), 5320, 1, 0x1419, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazPlateLegs ), 5509, 1, 0x46AA, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TopazShield ), 5415, 1, 0x1B76, MaterialInfo.GetMaterialColor( "topaz", "", 0 ) ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( AmethystShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( EmeraldShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( GarnetShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IceFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IcePlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IcePlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IcePlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IcePlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IcePlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IcePlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( IceShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadeFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadePlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadePlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadePlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadePlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadePlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadePlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( JadeShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarbleFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarblePlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarblePlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarblePlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarblePlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarblePlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarblePlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( MarbleShields ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( OnyxShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzPlateGloves  ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( QuartzShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RubyShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphirePlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphirePlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphirePlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphirePlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphirePlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphireFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphirePlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SapphireShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SilverShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( SpinelShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( StarRubyShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazPlateArms ), 470 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazPlateGloves ), 360 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazPlateGorget ), 260 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazPlateLegs ), 545 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazPlateChest ), 605 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazFemalePlateChest ), 565 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazPlateHelm ), 330 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( TopazShield ), 575 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyChance() ){Add( typeof( RareAnvil ), Utility.Random( 200,1000 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBRoscoe: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRoscoe()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( 1 > 0 ){Add( new GenericBuyInfo( typeof( LesserManaPotion ), 20, Utility.Random( 1,15 ), 0x23BD, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( ManaPotion ), 40, Utility.Random( 1,15 ), 0x180F, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( GreaterManaPotion ), 80, Utility.Random( 1,15 ), 0x2406, 0x48D ) ); }

				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( ClumsyMagicStaff ), 500, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( CreateFoodMagicStaff ), 500, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( FeebleMagicStaff ), 500, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( HealMagicStaff ), 500, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( MagicArrowMagicStaff ), 500, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( NightSightMagicStaff ), 500, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( ReactiveArmorMagicStaff ), 500, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( WeaknessMagicStaff ), 500, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( AgilityMagicStaff ), 1000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( CunningMagicStaff ), 1000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( CureMagicStaff ), 1000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( HarmMagicStaff ), 1000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( MagicTrapMagicStaff ), 1000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( MagicUntrapMagicStaff ), 1000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( ProtectionMagicStaff ), 1000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( StrengthMagicStaff ), 1000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( BlessMagicStaff ), 2000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( FireballMagicStaff ), 2000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( MagicLockMagicStaff ), 2000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( MagicUnlockMagicStaff ), 2000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( PoisonMagicStaff ), 2000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( TelekinesisMagicStaff ), 2000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( TeleportMagicStaff ), 2000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellRareChance() ){Add( new GenericBuyInfo( typeof( WallofStoneMagicStaff ), 2000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArchCureMagicStaff ), 4000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArchProtectionMagicStaff ), 4000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CurseMagicStaff ), 4000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FireFieldMagicStaff ), 4000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GreaterHealMagicStaff ), 4000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LightningMagicStaff ), 4000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ManaDrainMagicStaff ), 4000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RecallMagicStaff ), 4000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BladeSpiritsMagicStaff ), 8000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DispelFieldMagicStaff ), 8000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( IncognitoMagicStaff ), 8000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MagicReflectionMagicStaff ), 8000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MindBlastMagicStaff ), 8000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ParalyzeMagicStaff ), 8000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( PoisonFieldMagicStaff ), 8000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SummonCreatureMagicStaff ), 8000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( DispelMagicStaff ), 16000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EnergyBoltMagicStaff ), 16000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ExplosionMagicStaff ), 16000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( InvisibilityMagicStaff ), 16000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MarkMagicStaff ), 16000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MassCurseMagicStaff ), 16000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ParalyzeFieldMagicStaff ), 16000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( RevealMagicStaff ), 16000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ChainLightningMagicStaff ), 24000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EnergyFieldMagicStaff ), 24000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FlameStrikeMagicStaff ), 24000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( GateTravelMagicStaff ), 24000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ManaVampireMagicStaff ), 24000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MassDispelMagicStaff ), 24000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MeteorSwarmMagicStaff ), 24000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( PolymorphMagicStaff ), 24000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AirElementalMagicStaff ), 32000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EarthElementalMagicStaff ), 32000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EarthquakeMagicStaff ), 32000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( EnergyVortexMagicStaff ), 32000, 1, 0xDF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FireElementalMagicStaff ), 32000, 1, 0xDF2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ResurrectionMagicStaff ), 32000, 1, 0xDF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SummonDaemonMagicStaff ), 32000, 1, 0xDF4, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WaterElementalMagicStaff ), 32000, 1, 0xDF5, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( LesserManaPotion ), 10 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaPotion ), 20 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GreaterManaPotion ), 40 ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ClumsyMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CreateFoodMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FeebleMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HealMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicArrowMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( NightSightMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ReactiveArmorMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WeaknessMagicStaff ), Utility.Random( 10,20 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AgilityMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CunningMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CureMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( HarmMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicTrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUntrapMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ProtectionMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( StrengthMagicStaff ), Utility.Random( 20,40 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BlessMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireballMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicLockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicUnlockMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TelekinesisMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( TeleportMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WallofStoneMagicStaff ), Utility.Random( 30,60 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchCureMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ArchProtectionMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( CurseMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireFieldMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GreaterHealMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( LightningMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaDrainMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RecallMagicStaff ), Utility.Random( 40,80 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( BladeSpiritsMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( IncognitoMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MagicReflectionMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MindBlastMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PoisonFieldMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonCreatureMagicStaff ), Utility.Random( 50,100 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( DispelMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyBoltMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ExplosionMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( InvisibilityMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MarkMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassCurseMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ParalyzeFieldMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( RevealMagicStaff ), Utility.Random( 60,120 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ChainLightningMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyFieldMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FlameStrikeMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( GateTravelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ManaVampireMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MassDispelMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( MeteorSwarmMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( PolymorphMagicStaff ), Utility.Random( 70,140 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( AirElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EarthquakeMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( EnergyVortexMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( FireElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( ResurrectionMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( SummonDaemonMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
				if ( MyServerSettings.BuyRareChance() ){ Add( typeof( WaterElementalMagicStaff ), Utility.Random( 80,160 ) ); } // DO NOT WANT?
			}
		}
	}

/////----------------------------------------------------------------------------------------------------------------------------------------------------/////

	public class SBTinkerGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTinkerGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GuildTinkering ), 500, Utility.Random( 1,5 ), 0x1EBB, 0x430 ) );
				Add( new GenericBuyInfo( typeof( Clock ), 22, Utility.Random( 3,31 ), 0x104B, 0 ) );
				Add( new GenericBuyInfo( typeof( Nails ), 3, Utility.Random( 3,31 ), 0x102E, 0 ) );
				Add( new GenericBuyInfo( typeof( ClockParts ), 3, Utility.Random( 3,31 ), 0x104F, 0 ) );
				Add( new GenericBuyInfo( typeof( AxleGears ), 3, Utility.Random( 3,31 ), 0x1051, 0 ) );
				Add( new GenericBuyInfo( typeof( Gears ), 2, Utility.Random( 3,31 ), 0x1053, 0 ) );
				Add( new GenericBuyInfo( typeof( Hinge ), 2, Utility.Random( 3,31 ), 0x1055, 0 ) );
				Add( new GenericBuyInfo( typeof( Sextant ), 13, Utility.Random( 3,31 ), 0x1057, 0 ) );
				Add( new GenericBuyInfo( typeof( SextantParts ), 5, Utility.Random( 3,31 ), 0x1059, 0 ) );
				Add( new GenericBuyInfo( typeof( Axle ), 2, Utility.Random( 3,31 ), 0x105B, 0 ) );
				Add( new GenericBuyInfo( typeof( Springs ), 3, Utility.Random( 3,31 ), 0x105D, 0 ) );
				Add( new GenericBuyInfo( "1024111", typeof( Key ), 8, Utility.Random( 3,31 ), 0x100F, 0 ) );
				Add( new GenericBuyInfo( "1024112", typeof( Key ), 8, Utility.Random( 3,31 ), 0x1010, 0 ) );
				Add( new GenericBuyInfo( "1024115", typeof( Key ), 8, Utility.Random( 3,31 ), 0x1013, 0 ) );
				Add( new GenericBuyInfo( typeof( KeyRing ), 8, Utility.Random( 3,31 ), 0x1010, 0 ) );
				Add( new GenericBuyInfo( typeof( Lockpick ), 12, Utility.Random( 3,31 ), 0x14FC, 0 ) );
				Add( new GenericBuyInfo( typeof( SkeletonsKey ), Utility.Random( 3,31 ), 1, 0x410A, 0 ) );
				Add( new GenericBuyInfo( typeof( TinkersTools ), 7, Utility.Random( 3,31 ), 0x1EBC, 0 ) );
				Add( new GenericBuyInfo( typeof( SewingKit ), 3, Utility.Random( 3,31 ), 0x4C81, 0 ) );
				Add( new GenericBuyInfo( typeof( DrawKnife ), 10, Utility.Random( 3,31 ), 0x10E4, 0 ) );
				Add( new GenericBuyInfo( typeof( Froe ), 10, Utility.Random( 3,31 ), 0x10E5, 0 ) );
				Add( new GenericBuyInfo( typeof( Scorp ), 10, Utility.Random( 3,31 ), 0x10E7, 0 ) );
				Add( new GenericBuyInfo( typeof( Inshave ), 10, Utility.Random( 3,31 ), 0x10E6, 0 ) );
				Add( new GenericBuyInfo( typeof( ButcherKnife ), 13, Utility.Random( 3,31 ), 0x13F6, 0 ) );
				Add( new GenericBuyInfo( typeof( Scissors ), 11, Utility.Random( 3,31 ), 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( Tongs ), 13, Utility.Random( 3,31 ), 0xFBB, 0 ) );
				Add( new GenericBuyInfo( typeof( DovetailSaw ), 12, Utility.Random( 3,31 ), 0x1028, 0 ) );
				Add( new GenericBuyInfo( typeof( Saw ), 15, Utility.Random( 3,31 ), 0x1034, 0 ) );
				Add( new GenericBuyInfo( typeof( Hammer ), 17, Utility.Random( 3,31 ), 0x102A, 0 ) );
				Add( new GenericBuyInfo( typeof( SmithHammer ), 23, Utility.Random( 3,31 ), 0x0FB4, 0 ) );
				Add( new GenericBuyInfo( typeof( Shovel ), 12, Utility.Random( 3,31 ), 0xF39, 0 ) );
				Add( new GenericBuyInfo( typeof( OreShovel ), 10, Utility.Random( 3,31 ), 0xF39, 0x96D ) );
				Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, Utility.Random( 3,31 ), 0x102C, 0 ) );
				Add( new GenericBuyInfo( typeof( JointingPlane ), 10, Utility.Random( 3,31 ), 0x1030, 0 ) );
				Add( new GenericBuyInfo( typeof( SmoothingPlane ), 11, Utility.Random( 3,31 ), 0x1032, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodworkingTools ), 10, Utility.Random( 10,50 ), 0x4F52, 0 ) );
				Add( new GenericBuyInfo( typeof( Pickaxe ), 25, Utility.Random( 3,31 ), 0xE86, 0 ) );
				Add( new GenericBuyInfo( typeof( ThrowingWeapon ), 2, Utility.Random( 20, 120 ), 0x52B2, 0 ) );
				Add( new GenericBuyInfo( typeof( light_wall_torch ), 50, Utility.Random( 3,31 ), 0xA07, 0 ) );
				Add( new GenericBuyInfo( typeof( light_dragon_brazier ), 750, Utility.Random( 3,31 ), 0x194E, 0 ) );
				Add( new GenericBuyInfo( typeof( TrapKit ), 420, Utility.Random( 1,3 ), 0x1EBB, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( LootChest ), 600 );
				Add( typeof( Shovel ), 6 );
				Add( typeof( OreShovel ), 5 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Scissors ), 6 );
				Add( typeof( Tongs ), 7 );
				Add( typeof( Key ), 1 );
				Add( typeof( DovetailSaw ), 6 );
				Add( typeof( MouldingPlane ), 6 );
				Add( typeof( Nails ), 1 );
				Add( typeof( JointingPlane ), 6 );
				Add( typeof( SmoothingPlane ), 6 );
				Add( typeof( Saw ), 7 );
				Add( typeof( Clock ), 11 );
				Add( typeof( ClockParts ), 1 );
				Add( typeof( AxleGears ), 1 );
				Add( typeof( Gears ), 1 );
				Add( typeof( Hinge ), 1 );
				Add( typeof( Sextant ), 6 );
				Add( typeof( SextantParts ), 2 );
				Add( typeof( Axle ), 1 );
				Add( typeof( Springs ), 1 );
				Add( typeof( DrawKnife ), 5 );
				Add( typeof( Froe ), 5 );
				Add( typeof( Inshave ), 5 );
				Add( typeof( WoodworkingTools ), 5 );
				Add( typeof( Scorp ), 5 );
				Add( typeof( Lockpick ), 6 );
				Add( typeof( SkeletonsKey ), 10 );
				Add( typeof( TinkerTools ), 3 );
				Add( typeof( Log ), 1 );
				Add( typeof( Pickaxe ), 16 );
				Add( typeof( Hammer ), 3 );
				Add( typeof( SmithHammer ), 11 );
				Add( typeof( ButcherKnife ), 6 );
				Add( typeof( CrystalScales ), Utility.Random( 300,600 ) );
				Add( typeof( GolemManual ), Utility.Random( 500,750 ) );
				Add( typeof( PowerCrystal ), 15 );
				Add( typeof( ArcaneGem ), 10 );
				Add( typeof( ClockworkAssembly ), 15 );
				Add( typeof( BottleOil ), 5 );
				Add( typeof( ThrowingWeapon ), 1 );
				Add( typeof( TrapKit ), 210 );
				Add( typeof( SpaceJunkA ), Utility.Random( 5, 10 ) );
				Add( typeof( SpaceJunkB ), Utility.Random( 10, 20 ) );
				Add( typeof( SpaceJunkC ), Utility.Random( 15, 30 ) );
				Add( typeof( SpaceJunkD ), Utility.Random( 20, 40 ) );
				Add( typeof( SpaceJunkE ), Utility.Random( 25, 50 ) );
				Add( typeof( SpaceJunkF ), Utility.Random( 30, 60 ) );
				Add( typeof( SpaceJunkG ), Utility.Random( 35, 70 ) );
				Add( typeof( SpaceJunkH ), Utility.Random( 40, 80 ) );
				Add( typeof( SpaceJunkI ), Utility.Random( 45, 90 ) );
				Add( typeof( SpaceJunkJ ), Utility.Random( 50, 100 ) );
				Add( typeof( SpaceJunkK ), Utility.Random( 55, 110 ) );
				Add( typeof( SpaceJunkL ), Utility.Random( 60, 120 ) );
				Add( typeof( SpaceJunkM ), Utility.Random( 65, 130 ) );
				Add( typeof( SpaceJunkN ), Utility.Random( 70, 140 ) );
				Add( typeof( SpaceJunkO ), Utility.Random( 75, 150 ) );
				Add( typeof( SpaceJunkP ), Utility.Random( 80, 160 ) );
				Add( typeof( SpaceJunkQ ), Utility.Random( 85, 170 ) );
				Add( typeof( SpaceJunkR ), Utility.Random( 90, 180 ) );
				Add( typeof( SpaceJunkS ), Utility.Random( 95, 190 ) );
				Add( typeof( SpaceJunkT ), Utility.Random( 100, 200 ) );
				Add( typeof( SpaceJunkU ), Utility.Random( 105, 210 ) );
				Add( typeof( SpaceJunkV ), Utility.Random( 110, 220 ) );
				Add( typeof( SpaceJunkW ), Utility.Random( 115, 230 ) );
				Add( typeof( SpaceJunkX ), Utility.Random( 120, 240 ) );
				Add( typeof( SpaceJunkY ), Utility.Random( 125, 250 ) );
				Add( typeof( SpaceJunkZ ), Utility.Random( 130, 260 ) );
				Add( typeof( LandmineSetup ), Utility.Random( 100, 300 ) );
				Add( typeof( PlasmaGrenade ), Utility.Random( 28, 38 ) );
				Add( typeof( ThermalDetonator ), Utility.Random( 28, 38 ) );
				Add( typeof( PuzzleCube ), Utility.Random( 45, 90 ) );
				Add( typeof( PlasmaTorch ), Utility.Random( 45, 90 ) );
				Add( typeof( DuctTape ), Utility.Random( 45, 90 ) );
				Add( typeof( RobotBatteries ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotSheetMetal ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotOil ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotGears ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotEngineParts ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotCircuitBoard ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotBolt ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotTransistor ), Utility.Random( 5, 100 ) );
				Add( typeof( RobotSchematics ), Utility.Random( 500,750 ) );
				Add( typeof( DataPad ), Utility.Random( 5, 150 ) );
				Add( typeof( MaterialLiquifier ), Utility.Random( 100, 300 ) );
				Add( typeof( Chainsaw ), Utility.Random( 130, 260 ) );
				Add( typeof( PortableSmelter ), Utility.Random( 130, 260 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBThiefGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBThiefGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Backpack ), 15, Utility.Random( 3,31 ), 0x53D5, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 6, Utility.Random( 3,31 ), 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 8, Utility.Random( 3,31 ), 0xF6B, 0 ) );
				Add( new GenericBuyInfo( typeof( Lantern ), 2, Utility.Random( 3,31 ), 0xA25, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnStealingBook ), 5, Utility.Random( 3,31 ), 0x4C5C, 0 ) );
				Add( new GenericBuyInfo( typeof( Lockpick ), 12, Utility.Random( 25,100 ), 0x14FC, 0 ) );
				Add( new GenericBuyInfo( typeof( SkeletonsKey ), Utility.Random( 3,31 ), 1, 0x410A, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBox ), 14, Utility.Random( 3,31 ), 0x9AA, 0 ) );
				Add( new GenericBuyInfo( typeof( Key ), 2, Utility.Random( 3,31 ), 0x100E, 0 ) );
				Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 100, Utility.Random( 1,15 ), 0xEFF, 0 ) );
				Add( new GenericBuyInfo( "hair dye bottle", typeof( HairDyeBottle ), 1000, Utility.Random( 1,15 ), 0xE0F, 0 ) );
				Add( new GenericBuyInfo( typeof( DisguiseKit ), 700, Utility.Random( 1,5 ), 0xE05, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Backpack ), 7 );
				Add( typeof( Pouch ), 3 );
				Add( typeof( Torch ), 3 );
				Add( typeof( Lantern ), 1 );
				Add( typeof( Lockpick ), 6 );
				Add( typeof( WoodenBox ), 7 );
				Add( typeof( HairDye ), 50 );
				Add( typeof( HairDyeBottle ), 300 );
				Add( typeof( SkeletonsKey ), 10 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBTailorGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTailorGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GuildSewing ), 500, Utility.Random( 1,5 ), 0x4C81, 0x430 ) );
				Add( new GenericBuyInfo( typeof( SewingKit ), 3, Utility.Random( 3,31 ), 0x4C81, 0xB61 ) );
				Add( new GenericBuyInfo( typeof( Scissors ), 11, Utility.Random( 3,31 ), 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( DyeTub ), 8, Utility.Random( 3,31 ), 0xFAB, 0 ) );
				Add( new GenericBuyInfo( typeof( Dyes ), 8, Utility.Random( 3,31 ), 0xFA9, 0 ) );
				Add( new GenericBuyInfo( typeof( Shirt ), 12, Utility.Random( 3,31 ), 0x1517, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ShortPants ), 7, Utility.Random( 3,31 ), 0x152E, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyShirt ), 21, Utility.Random( 3,31 ), 0x1EFD, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( LongPants ), 10, Utility.Random( 3,31 ), 0x1539, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyDress ), 26, Utility.Random( 3,31 ), 0x1EFF, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( PlainDress ), 13, Utility.Random( 3,31 ), 0x1F01, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Kilt ), 11, Utility.Random( 3,31 ), 0x1537, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( HalfApron ), 10, Utility.Random( 3,31 ), 0x153b, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( LoinCloth ), 10, Utility.Random( 3,31 ), 0x2B68, 637 ) );
				Add( new GenericBuyInfo( typeof( RoyalLoinCloth ), 10, Utility.Random( 3,31 ), 0x55DB, 637 ) );
				Add( new GenericBuyInfo( typeof( Robe ), 18, Utility.Random( 3,31 ), 0x1F03, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( JokerRobe ), 40, Utility.Random( 1,5 ), 0x2B6B, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( AssassinRobe ), 40, Utility.Random( 1,5 ), 0x2B69, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyRobe ), 40, Utility.Random( 1,5 ), 0x2B6A, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( GildedRobe ), 40, Utility.Random( 1,5 ), 0x2B6C, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( OrnateRobe ), 40, Utility.Random( 1,5 ), 0x2B6E, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( MagistrateRobe ), 40, Utility.Random( 1,5 ), 0x2B70, 0 ) );
				Add( new GenericBuyInfo( typeof( RoyalRobe ), 40, Utility.Random( 1,5 ), 0x2B73, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SorcererRobe ), 40, Utility.Random( 1,5 ), 0x3175, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ScholarRobe ), 40, Utility.Random( 1,5 ), 0x2652, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( NecromancerRobe ), 40, Utility.Random( 1,5 ), 0x2FBA, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SpiderRobe ), 40, Utility.Random( 1,5 ), 0x2FC6, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( VagabondRobe ), 40, Utility.Random( 1,5 ), 0x567D, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( PirateCoat ), 40, Utility.Random( 1,5 ), 0x567E, 0 ) );
				Add( new GenericBuyInfo( typeof( ExquisiteRobe ), 40, Utility.Random( 1,5 ), 0x283, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ProphetRobe ), 40, Utility.Random( 1,5 ), 0x284, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ElegantRobe ), 40, Utility.Random( 1,5 ), 0x285, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( FormalRobe ), 40, Utility.Random( 1,5 ), 0x286, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ArchmageRobe ), 40, Utility.Random( 1,5 ), 0x287, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( PriestRobe ), 40, Utility.Random( 1,5 ), 0x288, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( CultistRobe ), 40, Utility.Random( 1,5 ), 0x289, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( GildedDarkRobe ), 40, Utility.Random( 1,5 ), 0x28A, 0 ) );
				Add( new GenericBuyInfo( typeof( GildedLightRobe ), 40, Utility.Random( 1,5 ), 0x301, 0 ) );
				Add( new GenericBuyInfo( typeof( SageRobe ), 40, Utility.Random( 1,5 ), 0x302, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cloak ), 8, Utility.Random( 3,31 ), 0x1515, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Doublet ), 13, Utility.Random( 3,31 ), 0x1F7B, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Tunic ), 18, Utility.Random( 3,31 ), 0x1FA1, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( JesterSuit ), 26, Utility.Random( 3,31 ), 0x1F9F, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( JesterHat ), 12, Utility.Random( 3,31 ), 0x171C, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( FloppyHat ), 7, Utility.Random( 3,31 ), 0x1713, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WideBrimHat ), 8, Utility.Random( 3,31 ), 0x1714, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cap ), 10, Utility.Random( 3,31 ), 0x1715, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TallStrawHat ), 8, Utility.Random( 3,31 ), 0x1716, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( StrawHat ), 7, Utility.Random( 3,31 ), 0x1717, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WizardsHat ), 11, Utility.Random( 3,31 ), 0x1718, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WitchHat ), 11, Utility.Random( 1,15 ), 0x2FC3, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( LeatherCap ), 10, Utility.Random( 3,31 ), 0x1DB9, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( FeatheredHat ), 10, Utility.Random( 3,31 ), 0x171A, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TricorneHat ), 8, Utility.Random( 3,31 ), 0x171B, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( PirateHat ), 8, Utility.Random( 3,31 ), 0x2FBC, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Bandana ), 6, Utility.Random( 3,31 ), 0x1540, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SkullCap ), 7, Utility.Random( 3,31 ), 0x1544, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ClothHood ), 12, Utility.Random( 1,15 ), 0x2B71, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ClothCowl ), 12, Utility.Random( 1,15 ), 0x3176, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( HoodedMantle ), 12, Utility.Random( 1,15 ), 0x5C14, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WizardHood ), 12, Utility.Random( 1,15 ), 0x310, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( FancyHood ), 12, Utility.Random( 1,15 ), 0x4D09, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cloth ), 2, Utility.Random( 3,31 ), 0x1766, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( UncutCloth ), 2, Utility.Random( 3,31 ), 0x1767, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cotton ), 102, Utility.Random( 3,31 ), 0xDF9, 0 ) );
				Add( new GenericBuyInfo( typeof( Wool ), 62, Utility.Random( 3,31 ), 0xDF8, 0 ) );
				Add( new GenericBuyInfo( typeof( Flax ), 102, Utility.Random( 3,31 ), 0x1A9C, 0 ) );
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 18, Utility.Random( 3,31 ), 0x543A, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Scissors ), 6 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Dyes ), 4 );
				Add( typeof( DyeTub ), 4 );
				Add( typeof( FancyShirt ), 10 );
				Add( typeof( Shirt ), 6 );
				Add( typeof( ShortPants ), 3 );
				Add( typeof( LongPants ), 5 );
				Add( typeof( Cloak ), 4 );
				Add( typeof( FancyDress ), 12 );
				Add( typeof( Robe ), 9 );
				Add( typeof( PlainDress ), 7 );
				Add( typeof( Skirt ), 5 );
				Add( typeof( Kilt ), 5 );
				Add( typeof( Doublet ), 7 );
				Add( typeof( Tunic ), 9 );
				Add( typeof( JesterSuit ), 13 );
				Add( typeof( FullApron ), 5 );
				Add( typeof( HalfApron ), 5 );
				Add( typeof( LoinCloth ), 5 );
				Add( typeof( JesterHat ), 6 );
				Add( typeof( FloppyHat ), 3 );
				Add( typeof( WideBrimHat ), 4 );
				Add( typeof( Cap ), 5 );
				Add( typeof( SkullCap ), 3 );
				Add( typeof( ClothCowl ), 6 );
				Add( typeof( ClothHood ), 6 );
				Add( typeof( HoodedMantle ), 6 );
				Add( typeof( WizardHood ), 6 );
				Add( typeof( FancyHood ), 6 );
				Add( typeof( Bandana ), 3 );
				Add( typeof( TallStrawHat ), 4 );
				Add( typeof( StrawHat ), 4 );
				Add( typeof( WizardsHat ), 5 );
				Add( typeof( WitchHat ), 5 );
				Add( typeof( Bonnet ), 4 );
				Add( typeof( FeatheredHat ), 5 );
				Add( typeof( TricorneHat ), 4 );
				Add( typeof( PirateHat ), 4 );
				Add( typeof( SpoolOfThread ), 9 );
				Add( typeof( Flax ), 51 );
				Add( typeof( Cotton ), 51 );
				Add( typeof( Wool ), 31 );
				Add( typeof( MagicRobe ), 30 );
				Add( typeof( MagicHat ), 20 );
				Add( typeof( MagicCloak ), 30 );
				Add( typeof( MagicBelt ), 20 );
				Add( typeof( MagicSash ), 20 );
				Add( typeof( JokerRobe ), 19 );
				Add( typeof( AssassinRobe ), 19 );
				Add( typeof( FancyRobe ), 19 );
				Add( typeof( GildedRobe ), 19 );
				Add( typeof( OrnateRobe ), 19 );
				Add( typeof( MagistrateRobe ), 19 );
				Add( typeof( VagabondRobe ), 19 );
				Add( typeof( PirateCoat ), 19 );
				Add( typeof( RoyalRobe ), 19 );
				Add( typeof( SorcererRobe ), 19 );
				Add( typeof( ScholarRobe ), 29 );
				Add( typeof( NecromancerRobe ), 19 );
				Add( typeof( SpiderRobe ), 19 );
				Add( typeof( ExquisiteRobe ), 19 );
				Add( typeof( ProphetRobe ), 19 );
				Add( typeof( ElegantRobe ), 19 );
				Add( typeof( FormalRobe ), 19 );
				Add( typeof( ArchmageRobe ), 19 );
				Add( typeof( PriestRobe ), 19 );
				Add( typeof( CultistRobe ), 19 );
				Add( typeof( GildedDarkRobe ), 19 );
				Add( typeof( GildedLightRobe ), 19 );
				Add( typeof( SageRobe ), 19 );
				Add( typeof( MagicScissors ), Utility.Random( 300,400 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMinerGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMinerGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Bag ), 6, Utility.Random( 3,31 ), 0xE76, 0xABE ) );
				Add( new GenericBuyInfo( typeof( Candle ), 6, Utility.Random( 3,31 ), 0xA28, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 8, Utility.Random( 3,31 ), 0xF6B, 0 ) );
				Add( new GenericBuyInfo( typeof( Lantern ), 2, Utility.Random( 3,31 ), 0xA25, 0 ) );
				Add( new GenericBuyInfo( typeof( Pickaxe ), 25, Utility.Random( 3,31 ), 0xE86, 0 ) );
				Add( new GenericBuyInfo( typeof( Shovel ), 12, Utility.Random( 3,31 ), 0xF39, 0 ) );
				Add( new GenericBuyInfo( typeof( OreShovel ), 10, Utility.Random( 3,31 ), 0xF39, 0x96D ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Pickaxe ), 12 );
				Add( typeof( Shovel ), 6 );
				Add( typeof( OreShovel ), 5 );
				Add( typeof( Lantern ), 1 );
				Add( typeof( Torch ), 3 );
				Add( typeof( Bag ), 3 );
				Add( typeof( Candle ), 3 );
				Add( typeof( Amber ), 25 );
				Add( typeof( Amethyst ), 50 );
				Add( typeof( Citrine ), 25 );
				Add( typeof( Diamond ), 100 );
				Add( typeof( Emerald ), 50 );
				Add( typeof( Ruby ), 37 );
				Add( typeof( Sapphire ), 50 );
				Add( typeof( StarSapphire ), 62 );
				Add( typeof( Tourmaline ), 47 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( RareAnvil ), Utility.Random( 200,1000 ) ); } // DO NOT WANT?
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBMageGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMageGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Spellbook ), 18, Utility.Random( 3,31 ), 0xEFA, 0 ) );
				Add( new GenericBuyInfo( typeof( ScribesPen ), 8, Utility.Random( 3,31 ), 0x2051, 0 ) );
				Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, Utility.Random( 3,31 ), 0x1718, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WitchHat ), 11, Utility.Random( 1,15 ), 0x2FC3, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( RecallRune ), 15, Utility.Random( 3,31 ), 0x1F14, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 30,310 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 30,310 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 30,310 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 30,310 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 30,310 ), 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 30,310 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 30,310 ), 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 30,310 ), 0xF8C, 0 ) );
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( reagents_magic_jar1 ), 2000, Utility.Random( 3,31 ), 0x1007, 0 ) ); }
				Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) );
				Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) );
				Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) );
				Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) );

				Type[] types = Loot.RegularScrollTypes;

				int circles = 4;

				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), Utility.Random( 1,15 ), itemID, 0 ) );
				}
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				Add( typeof( MagicTalisman ), Utility.Random( 50,100 ) );
				Add( typeof( WizardsHat ), 15 );
				Add( typeof( WitchHat ), 5 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ),4 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 1 );
				Add( typeof( RecallRune ), 13 );
				Add( typeof( Spellbook ), 25 );
				Add( typeof( MysticalPearl ), 250 );

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add( types[i], ((i / 8) + 1) * 4 );

				Add( typeof( ClumsyMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( CreateFoodMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( FeebleMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( HealMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( MagicArrowMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( NightSightMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( ReactiveArmorMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( WeaknessMagicStaff ), Utility.Random( 10,20 ) );
				Add( typeof( AgilityMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( CunningMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( CureMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( HarmMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( MagicTrapMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( MagicUntrapMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( ProtectionMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( StrengthMagicStaff ), Utility.Random( 20,40 ) );
				Add( typeof( BlessMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( FireballMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( MagicLockMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( MagicUnlockMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( PoisonMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( TelekinesisMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( TeleportMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( WallofStoneMagicStaff ), Utility.Random( 30,60 ) );
				Add( typeof( ArchCureMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( ArchProtectionMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( CurseMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( FireFieldMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( GreaterHealMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( LightningMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( ManaDrainMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( RecallMagicStaff ), Utility.Random( 40,80 ) );
				Add( typeof( BladeSpiritsMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( DispelFieldMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( IncognitoMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( MagicReflectionMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( MindBlastMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( ParalyzeMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( PoisonFieldMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( SummonCreatureMagicStaff ), Utility.Random( 50,100 ) );
				Add( typeof( DispelMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( EnergyBoltMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( ExplosionMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( InvisibilityMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( MarkMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( MassCurseMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( ParalyzeFieldMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( RevealMagicStaff ), Utility.Random( 60,120 ) );
				Add( typeof( ChainLightningMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( EnergyFieldMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( FlameStrikeMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( GateTravelMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( ManaVampireMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( MassDispelMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( MeteorSwarmMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( PolymorphMagicStaff ), Utility.Random( 70,140 ) );
				Add( typeof( AirElementalMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( EarthElementalMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( EarthquakeMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( EnergyVortexMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( FireElementalMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( ResurrectionMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( SummonDaemonMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( WaterElementalMagicStaff ), Utility.Random( 80,160 ) );
				Add( typeof( MySpellbook ), 500 );
				Add( typeof( TomeOfWands ), Utility.Random( 100,400 ) );
				Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) );
				Add( typeof( WizardStaff ), 20 );
				Add( typeof( WizardStick ), 19 );
				Add( typeof( MageEye ), 1 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHealerGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHealerGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 30,310 ), 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 3,31 ), 0x25FD, 0 ) );
				Add( new GenericBuyInfo( typeof( HealPotion ), 30, Utility.Random( 3,31 ), 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 60, Utility.Random( 3,31 ), 0x25FE, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 3,31 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 3,31 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 3,31 ), 0xF0B, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( HealPotion ), 14 );
				Add( typeof( GreaterHealPotion ), 28 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( FirstAidKit ), Utility.Random( 100,250 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBSailorGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSailorGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "1041205", typeof( SmallBoatDeed ), 9500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) );
				Add( new GenericBuyInfo( "1041206", typeof( SmallDragonBoatDeed ), 10500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) );
				Add( new GenericBuyInfo( "1041207", typeof( MediumBoatDeed ), 11500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) );
				Add( new GenericBuyInfo( "1041208", typeof( MediumDragonBoatDeed ), 12500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) );
				Add( new GenericBuyInfo( "1041209", typeof( LargeBoatDeed ), 13500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) );
				Add( new GenericBuyInfo( "1041210", typeof( LargeDragonBoatDeed ), 14500, Utility.Random( 1,15 ), 0x14F3, 0x5BE ) );
				Add( new GenericBuyInfo( typeof( DockingLantern ), 58, Utility.Random( 3,31 ), 0x40FF, 0 ) );
				Add( new GenericBuyInfo( typeof( RawFishSteak ), 3, Utility.Random( 3,31 ), 0x97A, 0 ) );
				Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 3,31 ), 0x9CC, 0 ) );
				Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 3,31 ), 0x9CD, 0 ) );
				Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 3,31 ), 0x9CE, 0 ) );
				Add( new GenericBuyInfo( typeof( Fish ), 6, Utility.Random( 3,31 ), 0x9CF, 0 ) );
				Add( new GenericBuyInfo( typeof( FishingPole ), 15, Utility.Random( 3,31 ), 0xDC0, 0 ) );
				Add( new GenericBuyInfo( typeof( BoatStain ), 26, Utility.Random( 1,15 ), 0x14E0, 0 ) );
				Add( new GenericBuyInfo( typeof( Sextant ), 13, Utility.Random( 1,15 ), 0x1057, 0 ) );
				Add( new GenericBuyInfo( typeof( GrapplingHook ), 58, Utility.Random( 1,15 ), 0x4F40, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( SeaShell ), 58 );
				Add( typeof( DockingLantern ), 29 );
				Add( typeof( RawFishSteak ), 1 );
				Add( typeof( Fish ), 1 );
				Add( typeof( FishingPole ), 7 );
				Add( typeof( Sextant ), 6 );
				Add( typeof( GrapplingHook ), 29 );
				Add( typeof( PirateChest ), Utility.RandomMinMax( 200, 800 ) );
				Add( typeof( SunkenChest ), Utility.RandomMinMax( 200, 800 ) );
				Add( typeof( FishingNet ), Utility.RandomMinMax( 20, 40 ) );
				Add( typeof( SpecialFishingNet ), Utility.RandomMinMax( 60, 80 ) );
				Add( typeof( FabledFishingNet ), Utility.RandomMinMax( 100, 120 ) );
				Add( typeof( NeptunesFishingNet ), Utility.RandomMinMax( 140, 160 ) );
				Add( typeof( PrizedFish ), Utility.RandomMinMax( 60, 120 ) );
				Add( typeof( WondrousFish ), Utility.RandomMinMax( 60, 120 ) );
				Add( typeof( TrulyRareFish ), Utility.RandomMinMax( 60, 120 ) );
				Add( typeof( PeculiarFish ), Utility.RandomMinMax( 60, 120 ) );
				Add( typeof( SpecialSeaweed ), Utility.RandomMinMax( 40, 160 ) );
				Add( typeof( SunkenBag ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( ShipwreckedItem ), Utility.RandomMinMax( 20, 60 ) );
				Add( typeof( HighSeasRelic ), Utility.RandomMinMax( 20, 60 ) );
				Add( typeof( BoatStain ), 13 );
				Add( typeof( MegalodonTooth ), Utility.RandomMinMax( 1000, 2000 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBlacksmithGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBlacksmithGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GuildHammer ), 500, Utility.Random( 1,5 ), 0xFB5, 0x430 ) );
				Add( new GenericBuyInfo( typeof( Tongs ), 13, Utility.Random( 3,31 ), 0xFBB, 0 ) );
				Add( new GenericBuyInfo( typeof( BronzeShield ), 66, Utility.Random( 3,31 ), 0x1B72, Server.Misc.MaterialInfo.PlainIronColor(0x1B72) ) );
				Add( new GenericBuyInfo( typeof( Buckler ), 50, Utility.Random( 3,31 ), 0x1B73, 0 ) );
				Add( new GenericBuyInfo( typeof( MetalKiteShield ), 123, Utility.Random( 3,31 ), 0x1B74, 0 ) );
				Add( new GenericBuyInfo( typeof( HeaterShield ), 231, Utility.Random( 3,31 ), 0x1B76, 0 ) );
				Add( new GenericBuyInfo( typeof( MetalShield ), 121, Utility.Random( 3,31 ), 0x1B7B, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateGorget ), 104, Utility.Random( 3,31 ), 0x1413, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateChest ), 243, Utility.Random( 3,31 ), 0x1415, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateLegs ), 218, Utility.Random( 3,31 ), 0x46AA, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateSkirt ), 218, Utility.Random( 1,15 ), 0x1C08, MaterialInfo.PlainIronColor(0x1C08) ) );
				Add( new GenericBuyInfo( typeof( PlateArms ), 188, Utility.Random( 3,31 ), 0x1410, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateGloves ), 155, Utility.Random( 3,31 ), 0x1414, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateHelm ), 21, Utility.Random( 3,31 ), 0x1412, 0 ) );
				Add( new GenericBuyInfo( typeof( CloseHelm ), 18, Utility.Random( 3,31 ), 0x1408, 0 ) );
				Add( new GenericBuyInfo( typeof( CloseHelm ), 18, Utility.Random( 3,31 ), 0x1409, 0 ) );
				Add( new GenericBuyInfo( typeof( Helmet ), 31, Utility.Random( 3,31 ), 0x140A, 0 ) );
				Add( new GenericBuyInfo( typeof( Helmet ), 18, Utility.Random( 3,31 ), 0x140B, 0 ) );
				Add( new GenericBuyInfo( typeof( NorseHelm ), 18, Utility.Random( 3,31 ), 0x140E, 0 ) );
				Add( new GenericBuyInfo( typeof( NorseHelm ), 18, Utility.Random( 3,31 ), 0x140F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bascinet ), 18, Utility.Random( 3,31 ), 0x140C, 0 ) );
				Add( new GenericBuyInfo( typeof( PlateHelm ), 21, Utility.Random( 3,31 ), 0x1419, 0 ) );
				Add( new GenericBuyInfo( typeof( DreadHelm ), 21, Utility.Random( 3,31 ), 0x2FBB, 0 ) );
				Add( new GenericBuyInfo( typeof( ChainCoif ), 17, Utility.Random( 3,31 ), 0x13BB, 0 ) );
				Add( new GenericBuyInfo( typeof( ChainChest ), 143, Utility.Random( 3,31 ), 0x13BF, 0 ) );
				Add( new GenericBuyInfo( typeof( ChainLegs ), 149, Utility.Random( 3,31 ), 0x13BE, 0 ) );
				Add( new GenericBuyInfo( typeof( ChainSkirt ), 149, Utility.Random( 1,15 ), 0x63B4, MaterialInfo.PlainIronColor(0x63B4) ) );
				Add( new GenericBuyInfo( typeof( RingmailChest ), 121, Utility.Random( 3,31 ), 0x13ec, 0 ) );
				Add( new GenericBuyInfo( typeof( RingmailLegs ), 90, Utility.Random( 3,31 ), 0x13F0, 0 ) );
				Add( new GenericBuyInfo( typeof( RingmailSkirt ), 90, Utility.Random( 1,15 ), 0x63B4, 0xABF ) );
				Add( new GenericBuyInfo( typeof( RingmailArms ), 85, Utility.Random( 3,31 ), 0x13EE, 0 ) );
				Add( new GenericBuyInfo( typeof( RingmailGloves ), 93, Utility.Random( 3,31 ), 0x13eb, 0 ) );
				Add( new GenericBuyInfo( typeof( ExecutionersAxe ), 30, Utility.Random( 3,31 ), 0xF45, 0 ) );
				Add( new GenericBuyInfo( typeof( Bardiche ), 60, Utility.Random( 3,31 ), 0xF4D, 0 ) );
				Add( new GenericBuyInfo( typeof( BattleAxe ), 26, Utility.Random( 3,31 ), 0xF47, 0 ) );
				Add( new GenericBuyInfo( typeof( TwoHandedAxe ), 32, Utility.Random( 3,31 ), 0x1443, 0 ) );
				Add( new GenericBuyInfo( typeof( ButcherKnife ), 14, Utility.Random( 3,31 ), 0x13F6, 0 ) );
				Add( new GenericBuyInfo( typeof( Cutlass ), 24, Utility.Random( 3,31 ), 0x1441, 0 ) );
				Add( new GenericBuyInfo( typeof( Dagger ), 21, Utility.Random( 3,31 ), 0xF52, 0 ) );
				Add( new GenericBuyInfo( typeof( Halberd ), 42, Utility.Random( 3,31 ), 0x143E, 0 ) );
				Add( new GenericBuyInfo( typeof( HammerPick ), 26, Utility.Random( 3,31 ), 0x143D, 0 ) );
				Add( new GenericBuyInfo( typeof( Katana ), 33, Utility.Random( 3,31 ), 0x13FF, 0 ) );
				Add( new GenericBuyInfo( typeof( Kryss ), 32, Utility.Random( 3,31 ), 0x1401, 0 ) );
				Add( new GenericBuyInfo( typeof( LargeKnife ), 21, Utility.Random( 3,31 ), 0x2674, 0 ) );
				Add( new GenericBuyInfo( typeof( Broadsword ), 35, Utility.Random( 3,31 ), 0xF5E, 0 ) );
				Add( new GenericBuyInfo( typeof( Longsword ), 55, Utility.Random( 3,31 ), 0xF61, 0 ) );
				Add( new GenericBuyInfo( typeof( ShortSword ), 35, Utility.Random( 1,15 ), 0x2672, 0 ) );
				Add( new GenericBuyInfo( typeof( ThinLongsword ), 27, Utility.Random( 3,31 ), 0x13B8, 0 ) );
				Add( new GenericBuyInfo( typeof( VikingSword ), 55, Utility.Random( 3,31 ), 0x13B9, 0 ) );
				Add( new GenericBuyInfo( typeof( Claymore ), 60, Utility.Random( 3,31 ), 0x568F, 0 ) );
				Add( new GenericBuyInfo( typeof( Cleaver ), 15, Utility.Random( 3,31 ), 0xEC3, 0 ) );
				Add( new GenericBuyInfo( typeof( Axe ), 40, Utility.Random( 3,31 ), 0xF49, 0 ) );
				Add( new GenericBuyInfo( typeof( DoubleAxe ), 52, Utility.Random( 3,31 ), 0xF4B, 0 ) );
				Add( new GenericBuyInfo( typeof( Pickaxe ), 22, Utility.Random( 3,31 ), 0xE86, 0 ) );
				Add( new GenericBuyInfo( typeof( Pitchforks ), 19, Utility.Random( 3,31 ), 0xE88, 0 ) );
				Add( new GenericBuyInfo( typeof( Scimitar ), 36, Utility.Random( 3,31 ), 0x13B6, 0 ) );
				Add( new GenericBuyInfo( typeof( SkinningKnife ), 14, Utility.Random( 3,31 ), 0xEC4, 0 ) );
				Add( new GenericBuyInfo( typeof( LargeBattleAxe ), 33, Utility.Random( 3,31 ), 0x13FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WarAxe ), 29, Utility.Random( 3,31 ), 0x13B0, 0 ) );
				Add( new GenericBuyInfo( typeof( BoneHarvester ), 35, Utility.Random( 3,31 ), 0x26BB, 0 ) );
				Add( new GenericBuyInfo( typeof( CrescentBlade ), 37, Utility.Random( 3,31 ), 0x26C1, 0 ) );
				Add( new GenericBuyInfo( typeof( DoubleBladedStaff ), 35, Utility.Random( 3,31 ), 0x26BF, 0 ) );
				Add( new GenericBuyInfo( typeof( Lance ), 34, Utility.Random( 3,31 ), 0x26C0, 0 ) );
				Add( new GenericBuyInfo( typeof( Pike ), 39, Utility.Random( 3,31 ), 0x26BE, 0 ) );
				Add( new GenericBuyInfo( typeof( Scythe ), 39, Utility.Random( 3,31 ), 0x26BA, 0 ) );
				Add( new GenericBuyInfo( typeof( Pitchfork ), 19, Utility.Random( 3,31 ), 0xE87, MaterialInfo.PlainIronColor(0xE87) ) );
				Add( new GenericBuyInfo( typeof( Mace ), 28, Utility.Random( 3,31 ), 0xF5C, 0 ) );
				Add( new GenericBuyInfo( typeof( Maul ), 21, Utility.Random( 3,31 ), 0x143B, 0 ) );
				Add( new GenericBuyInfo( typeof( SmithHammer ), 21, Utility.Random( 3,31 ), 0x0FB4, 0 ) );
				Add( new GenericBuyInfo( typeof( Hammers ), 28, Utility.Random( 3,31 ), 0x267E, 0 ) );
				Add( new GenericBuyInfo( typeof( ShortSpear ), 23, Utility.Random( 3,31 ), 0x1403, 0 ) );
				Add( new GenericBuyInfo( typeof( Spear ), 31, Utility.Random( 3,31 ), 0xF62, 0 ) );
				Add( new GenericBuyInfo( typeof( SpikedClub ), 28, Utility.Random( 3,31 ), 0x2AB5, 0 ) );
				Add( new GenericBuyInfo( typeof( WarHammer ), 25, Utility.Random( 3,31 ), 0x1439, 0 ) );
				Add( new GenericBuyInfo( typeof( WarMace ), 31, Utility.Random( 3,31 ), 0x1407, 0 ) );
				Add( new GenericBuyInfo( typeof( Scepter ), 39, Utility.Random( 3,31 ), 0x26BC, 0 ) );
				Add( new GenericBuyInfo( typeof( BladedStaff ), 40, Utility.Random( 3,31 ), 0x26BD, 0 ) );
				Add( new GenericBuyInfo( typeof( GuardsmanShield ), 231, Utility.Random( 1,15 ), 0x2FCB, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenShield ), 231, Utility.Random( 1,15 ), 0x2FCA, 0 ) );
				Add( new GenericBuyInfo( typeof( DarkShield ), 231, Utility.Random( 1,15 ), 0x2FC8, 0 ) );
				Add( new GenericBuyInfo( typeof( CrestedShield ), 231, Utility.Random( 1,15 ), 0x2FC9, 0 ) );
				Add( new GenericBuyInfo( typeof( ChampionShield ), 231, Utility.Random( 1,15 ), 0x2B74, 0 ) );
				Add( new GenericBuyInfo( typeof( JeweledShield ), 231, Utility.Random( 1,15 ), 0x2B75, 0 ) );
				Add( new GenericBuyInfo( typeof( AssassinSpike ), 21, Utility.Random( 1,15 ), 0x2D21, 0 ) );
				Add( new GenericBuyInfo( typeof( Leafblade ), 21, Utility.Random( 1,15 ), 0x2D22, 0 ) );
				Add( new GenericBuyInfo( typeof( WarCleaver ), 25, Utility.Random( 1,15 ), 0x2D2F, 0 ) );
				Add( new GenericBuyInfo( typeof( DiamondMace ), 31, Utility.Random( 1,15 ), 0x2D24, 0 ) );
				Add( new GenericBuyInfo( typeof( OrnateAxe ), 55, Utility.Random( 1,15 ), 0x2D28, 0 ) );
				Add( new GenericBuyInfo( typeof( RuneBlade ), 55, Utility.Random( 1,15 ), 0x2D32, 0 ) );
				Add( new GenericBuyInfo( typeof( RadiantScimitar ), 35, Utility.Random( 1,15 ), 0x2D33, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenSpellblade ), 33, Utility.Random( 1,15 ), 0x2D20, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenMachete ), 35, Utility.Random( 1,15 ), 0x2D35, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( GuardsmanShield ), 115 );
				Add( typeof( ElvenShield ), 115 );
				Add( typeof( DarkShield ), 115 );
				Add( typeof( CrestedShield ), 115 );
				Add( typeof( ChampionShield ), 115 );
				Add( typeof( JeweledShield ), 115 );
				Add( typeof( Tongs ), 7 );
				Add( typeof( Buckler ), 25 );
				Add( typeof( BronzeShield ), 33 );
				Add( typeof( MetalShield ), 60 );
				Add( typeof( MetalKiteShield ), 62 );
				Add( typeof( HeaterShield ), 115 );
				Add( typeof( PlateArms ), 94 );
				Add( typeof( PlateChest ), 121 );
				Add( typeof( PlateGloves ), 72 );
				Add( typeof( PlateGorget ), 52 );
				Add( typeof( PlateLegs ), 109 );
				Add( typeof( PlateSkirt ), 109 );
				Add( typeof( FemalePlateChest ), 113 );
				Add( typeof( Bascinet ), 9 );
				Add( typeof( CloseHelm ), 9 );
				Add( typeof( Helmet ), 9 );
				Add( typeof( NorseHelm ), 9 );
				Add( typeof( PlateHelm ), 10 );
				Add( typeof( DreadHelm ), 10 );
				Add( typeof( ChainCoif ), 6 );
				Add( typeof( ChainChest ), 71 );
				Add( typeof( ChainLegs ), 74 );
				Add( typeof( ChainSkirt ), 74 );
				Add( typeof( RingmailArms ), 42 );
				Add( typeof( RingmailChest ), 60 );
				Add( typeof( RingmailGloves ), 26 );
				Add( typeof( RingmailLegs ), 45 );
				Add( typeof( RingmailSkirt ), 45 );
				Add( typeof( BattleAxe ), 13 );
				Add( typeof( DoubleAxe ), 26 );
				Add( typeof( ExecutionersAxe ), 15 );
				Add( typeof( LargeBattleAxe ),16 );
				Add( typeof( Pickaxe ), 11 );
				Add( typeof( TwoHandedAxe ), 16 );
				Add( typeof( WarAxe ), 14 );
				Add( typeof( Axe ), 20 );
				Add( typeof( Bardiche ), 30 );
				Add( typeof( Halberd ), 21 );
				Add( typeof( ButcherKnife ), 7 );
				Add( typeof( Cleaver ), 7 );
				Add( typeof( Dagger ), 10 );
				Add( typeof( LargeKnife ), 10 );
				Add( typeof( SkinningKnife ), 7 );
				Add( typeof( HammerPick ), 13 );
				Add( typeof( Mace ), 14 );
				Add( typeof( Maul ), 10 );
				Add( typeof( WarHammer ), 12 );
				Add( typeof( WarMace ), 15 );
				Add( typeof( Scepter ), 20 );
				Add( typeof( BladedStaff ), 20 );
				Add( typeof( Scythe ), 19 );
				Add( typeof( BoneHarvester ), 17 );
				Add( typeof( Scepter ), 18 );
				Add( typeof( SpikedClub ), 14 );
				Add( typeof( Hammers ), 14 );
				Add( typeof( BladedStaff ), 16 );
				Add( typeof( Pike ), 19 );
				Add( typeof( DoubleBladedStaff ), 17 );
				Add( typeof( Lance ), 17 );
				Add( typeof( CrescentBlade ), 18 );
				Add( typeof( Spear ), 15 );
				Add( typeof( Pitchfork ), 9 );
				Add( typeof( Pitchforks ), 9 );
				Add( typeof( ShortSpear ), 11 );
				Add( typeof( SmithHammer ), 10 );
				Add( typeof( Broadsword ), 17 );
				Add( typeof( Cutlass ), 12 );
				Add( typeof( Katana ), 16 );
				Add( typeof( Kryss ), 16 );
				Add( typeof( Longsword ), 27 );
				Add( typeof( Scimitar ), 18 );
				Add( typeof( ShortSword ), 17 );
				Add( typeof( ThinLongsword ), 13 );
				Add( typeof( VikingSword ), 27 );
				Add( typeof( Claymore ), 29 );
				Add( typeof( AssassinSpike ), 10 );
				Add( typeof( Leafblade ), 10 );
				Add( typeof( WarCleaver ), 12 );
				Add( typeof( DiamondMace ), 15 );
				Add( typeof( OrnateAxe ),27 );
				Add( typeof( RuneBlade ), 27 );
				Add( typeof( RadiantScimitar ), 17 );
				Add( typeof( ElvenSpellblade ), 16 );
				Add( typeof( ElvenMachete ), 17 );
				Add( typeof( RareAnvil ), Utility.Random( 400,1500 ) );
				Add( typeof( MagicHammer ), Utility.Random( 300,400 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBBardGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBardGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Drums ), 21, Utility.Random( 3,31 ), 0x0E9C, 0 ) );
				Add( new GenericBuyInfo( typeof( Tambourine ), 21, Utility.Random( 3,31 ), 0x0E9E, 0 ) );
				Add( new GenericBuyInfo( typeof( LapHarp ), 21, Utility.Random( 3,31 ), 0x0EB2, 0 ) );
				Add( new GenericBuyInfo( typeof( Lute ), 21, Utility.Random( 3,31 ), 0x0EB3, 0 ) );
				Add( new GenericBuyInfo( typeof( BambooFlute ), 21, Utility.Random( 1,15 ), 0x2805, 0 ) );
				Add( new GenericBuyInfo( typeof( Trumpet ), 21, Utility.Random( 3,31 ), 0x6458, 0 ) );
				Add( new GenericBuyInfo( typeof( SongBook ), 24, Utility.Random( 1,5 ), 0x225A, 0 ) );
				Add( new GenericBuyInfo( typeof( EnergyCarolScroll ), 32, Utility.Random( 1,5 ), 0x1F48, 0x96 ) );
				Add( new GenericBuyInfo( typeof( FireCarolScroll ), 32, Utility.Random( 1,5 ), 0x1F49, 0x96 ) );
				Add( new GenericBuyInfo( typeof( IceCarolScroll ), 32, Utility.Random( 1,5 ), 0x1F34, 0x96 ) );
				Add( new GenericBuyInfo( typeof( KnightsMinneScroll ), 32, Utility.Random( 1,5 ), 0x1F31, 0x96 ) );
				Add( new GenericBuyInfo( typeof( PoisonCarolScroll ), 32, Utility.Random( 1,5 ), 0x1F33, 0x96 ) );
				Add( new GenericBuyInfo( typeof( JarsOfWaxInstrument ), 160, Utility.Random( 1,5 ), 0x1005, 0x845 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( JarsOfWaxInstrument ), 80 );
				Add( typeof( BambooFlute ), 10 );
				Add( typeof( LapHarp ), 10 );
				Add( typeof( Lute ), 10 );
				Add( typeof( Trumpet ), 10 );
				Add( typeof( Drums ), 10 );
				Add( typeof( Harp ), 10 );
				Add( typeof( Tambourine ), 10 );
				Add( typeof( MySongbook ), 200 );
				Add( typeof( SongBook ), 12 );
				Add( typeof( EnergyCarolScroll ), 5 );
				Add( typeof( FireCarolScroll ), 5 );
				Add( typeof( IceCarolScroll ), 5 );
				Add( typeof( KnightsMinneScroll ), 5 );
				Add( typeof( PoisonCarolScroll ), 5 );
				Add( typeof( ArmysPaeonScroll ), 6 );
				Add( typeof( MagesBalladScroll ), 6 );
				Add( typeof( EnchantingEtudeScroll ), 7 );
				Add( typeof( SheepfoeMamboScroll ), 7 );
				Add( typeof( SinewyEtudeScroll ), 7 );
				Add( typeof( EnergyThrenodyScroll ), 8 );
				Add( typeof( FireThrenodyScroll ), 8 );
				Add( typeof( IceThrenodyScroll ), 8 );
				Add( typeof( PoisonThrenodyScroll ), 8 );
				Add( typeof( FoeRequiemScroll ), 9 );
				Add( typeof( MagicFinaleScroll ), 10 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHolidayXmas : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHolidayXmas()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( WreathDeed ), 300, Utility.Random( 1,3 ), 0x14EF, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GreenStocking ), 110, Utility.Random( 1,3 ), 0x2bd9, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( RedStocking ), 110, Utility.Random( 1,3 ), 0x2bdb, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( SnowPileDeco ), 80, Utility.Random( 1,3 ), 0x8E2, 0x481 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( Snowman ), 230, Utility.Random( 1,3 ), 0x2328, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( BlueSnowflake ), 100, Utility.Random( 1,3 ), 0x232E, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( WhiteSnowflake ), 100, Utility.Random( 1,3 ), 0x232F, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( RedPoinsettia ), 120, Utility.Random( 1,3 ), 0x2330, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( WhitePoinsettia ), 120, Utility.Random( 1,3 ), 0x2331, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcyPatch ), 60, Utility.Random( 1,3 ), 0x122F, 0x481 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcicleLargeSouth ), 80, Utility.Random( 1,3 ), 0x4572, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcicleMedSouth ), 70, Utility.Random( 1,3 ), 0x4573, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcicleSmallSouth ), 60, Utility.Random( 1,3 ), 0x4574, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcicleLargeEast ), 80, Utility.Random( 1,3 ), 0x4575, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcicleMedEast ), 70, Utility.Random( 1,3 ), 0x4576, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( IcicleSmallEast ), 60, Utility.Random( 1,3 ), 0x4577, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GingerBreadHouseDeed ), 450, Utility.Random( 1,3 ), 0x14EF, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CandyCane ), 20, Utility.Random( 1,3 ), 0x2bdd, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GingerBreadCookie ), 20, Utility.Random( 1,3 ), 0x2be1, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HolidayBell ), 280, Utility.Random( 1,3 ), 0x1C12, 0xA ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HolidayBells ), 560, Utility.Random( 1,3 ), 0x5474, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxRectangle ), 140, Utility.Random( 1,3 ), 0x46A6, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxCube ), 140, Utility.Random( 1,3 ), 0x46A2, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxCylinder ), 140, Utility.Random( 1,3 ), 0x46A3, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxOctogon ), 140, Utility.Random( 1,3 ), 0x46A4, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxAngel ), 140, Utility.Random( 1,3 ), 0x46A7, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxNeon ), 140, Utility.Random( 1,3 ), 0x232A, Utility.RandomList( 0x438, 0x424, 0x433, 0x445, 0x42b, 0x448 ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GiftBox ), 140, Utility.Random( 1,3 ), 0x232A, Utility.RandomDyedHue() ) ); }
				Add( new GenericBuyInfo( typeof( HolidayTreeDeed ), 860, Utility.Random( 1,3 ), 0x0CC8, 0 ) );
				Add( new GenericBuyInfo( typeof( HolidayTreeFlatDeed ), 860, Utility.Random( 1,3 ), 0x0CC8, 0 ) );
				Add( new GenericBuyInfo( typeof( NewHolidayTree ), 980, Utility.Random( 1,3 ), 0x4C7D, 0 ) );
				Add( new GenericBuyInfo( typeof( RibbonTreeSmall ), 700, Utility.Random( 1,3 ), 0x5462, 0 ) );
				Add( new GenericBuyInfo( typeof( RibbonTree ), 800, Utility.Random( 1,3 ), 0x5461, 0 ) );
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( ChristmasRobe ), 50, Utility.Random( 1,3 ), 0x2684, 1153 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHolidayDeco : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHolidayDeco()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( WreathDeed ), 300, Utility.Random( 1,3 ), 0x14EF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GreenStocking ), 110, Utility.Random( 1,3 ), 0x2bd9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( RedStocking ), 110, Utility.Random( 1,3 ), 0x2bdb, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( SnowPileDeco ), 80, Utility.Random( 1,3 ), 0x8E2, 0x481 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( Snowman ), 230, Utility.Random( 1,3 ), 0x2328, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( BlueSnowflake ), 100, Utility.Random( 1,3 ), 0x232E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( WhiteSnowflake ), 100, Utility.Random( 1,3 ), 0x232F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( RedPoinsettia ), 120, Utility.Random( 1,3 ), 0x2330, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( WhitePoinsettia ), 120, Utility.Random( 1,3 ), 0x2331, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcyPatch ), 60, Utility.Random( 1,3 ), 0x122F, 0x481 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcicleLargeSouth ), 80, Utility.Random( 1,3 ), 0x4572, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcicleMedSouth ), 70, Utility.Random( 1,3 ), 0x4573, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcicleSmallSouth ), 60, Utility.Random( 1,3 ), 0x4574, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcicleLargeEast ), 80, Utility.Random( 1,3 ), 0x4575, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcicleMedEast ), 70, Utility.Random( 1,3 ), 0x4576, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( IcicleSmallEast ), 60, Utility.Random( 1,3 ), 0x4577, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GingerBreadHouseDeed ), 450, Utility.Random( 1,3 ), 0x14EF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CandyCane ), 20, Utility.Random( 1,3 ), 0x2bdd, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GingerBreadCookie ), 20, Utility.Random( 1,3 ), 0x2be1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HolidayBell ), 280, Utility.Random( 1,3 ), 0x1C12, 0xA ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HolidayBells ), 560, Utility.Random( 1,3 ), 0x5474, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxRectangle ), 140, Utility.Random( 1,3 ), 0x46A6, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxCube ), 140, Utility.Random( 1,3 ), 0x46A2, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxCylinder ), 140, Utility.Random( 1,3 ), 0x46A3, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxOctogon ), 140, Utility.Random( 1,3 ), 0x46A4, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxAngel ), 140, Utility.Random( 1,3 ), 0x46A7, Utility.RandomList( 0x672, 0x454, 0x507, 0x4ac, 0x504, 0x84b, 0x495, 0x97c, 0x493, 0x4a8, 0x494, 0x4aa, 0xb8b, 0x84f, 0x491, 0x851, 0x503, 0xb8c, 0x4ab, 0x84B ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBoxNeon ), 140, Utility.Random( 1,3 ), 0x232A, Utility.RandomList( 0x438, 0x424, 0x433, 0x445, 0x42b, 0x448 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GiftBox ), 140, Utility.Random( 1,3 ), 0x232A, Utility.RandomDyedHue() ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HolidayTreeDeed ), 860, Utility.Random( 1,3 ), 0x0CC8, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HolidayTreeFlatDeed ), 860, Utility.Random( 1,3 ), 0x0CC8, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( NewHolidayTree ), 980, Utility.Random( 1,3 ), 0x4C7D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( RibbonTreeSmall ), 700, Utility.Random( 1,3 ), 0x5462, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( RibbonTree ), 800, Utility.Random( 1,3 ), 0x5461, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( ChristmasRobe ), 50, Utility.Random( 1,3 ), 0x2684, 1153 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBHolidayHalloween : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHolidayHalloween()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( BloodyTableAddonDeed ), 1500, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( BloodPentagramDeed ), 3800, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( MongbatDartBoardEastDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( MongbatDartBoardSouthDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( DaemonDartBoardEastDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0xB01 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( DaemonDartBoardSouthDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0xB01 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( EerieGhost ), 1500, Utility.Random( 1,3 ), 0x5754, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree6 ), 800, Utility.Random( 1,3 ), 0xCCD, 0x2C1 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree5 ), 800, Utility.Random( 1,3 ), 0x224D, 0x2C1 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree4 ), 800, Utility.Random( 1,3 ), 0xCD3, 0x2C1 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree3 ), 800, Utility.Random( 1,3 ), 0x224A, 0x2C5 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree2 ), 800, Utility.Random( 1,3 ), 0xD94, 0x2C5 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree1 ), 800, Utility.Random( 1,3 ), 0xCE3, 0x2C5 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTortSkel ), 450, Utility.Random( 1,3 ), 0x1A03, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenStoneSpike2 ), 600, Utility.Random( 1,3 ), 0x2202, 0x322 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenStoneSpike ), 600, Utility.Random( 1,3 ), 0x2201, 0x322 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenStoneColumn ), 500, Utility.Random( 1,3 ), 0x77, 0x322 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenSkullPole ), 540, Utility.Random( 1,3 ), 0x2204, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenShrineChaosDeed ), 1380, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenPylonFire ), 2100, Utility.Random( 1,3 ), 0x19AF, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenPylon ), 1800, Utility.Random( 1,3 ), 0x1ECB, 0x322 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenMaiden ), 2780, Utility.Random( 1,3 ), 0x124B, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenGrave3 ), 350, Utility.Random( 1,3 ), 0xEDE, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenGrave2 ), 350, Utility.Random( 1,3 ), 0x116E, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenGrave1 ), 350, Utility.Random( 1,3 ), 0x1168, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenColumn ), 1100, Utility.Random( 1,3 ), 0x196, 0x322 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenChopper ), 1760, Utility.Random( 1,3 ), 0x1245, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenBonePileDeed ), 680, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenBlood ), 90, Utility.Random( 1,3 ), 0x122A, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( AppleBobbingBarrel ), 170, Utility.Random( 1,3 ), 0x0F33, 0 ) ); }
				Add( new GenericBuyInfo( typeof( CarvedPumpkin ), Utility.Random( 80,200 ), Utility.Random( 1,3 ), 0x4694, 0 ) );
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin2 ), Utility.Random( 80,200 ), Utility.Random( 1,3 ), 0x4698, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin3 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x5499, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin4 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x549D, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin5 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54A1, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin6 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54A5, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin7 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54A9, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin8 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54AD, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin9 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54B1, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin10 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54B5, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin11 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54B9, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin12 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54BD, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin13 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54C1, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin14 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54C9, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin15 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54CC, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin16 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54CE, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin17 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54D2, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin18 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54D6, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin19 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54DA, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin20 ), Utility.Random( 1500,5000 ), Utility.Random( 1,3 ), 0x5481, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( DeadBodyEWDeed ), 345, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( DeadBodyNSDeed ), 345, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( EvilFireplaceSouthFaceAddonDeed ), 6800, Utility.Random( 1,3 ), 0x14EF, 1175 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( EvilFireplaceEastFaceAddonDeed ), 6800, Utility.Random( 1,3 ), 0x14EF, 1175 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_coffin_eastAddonDeed ), 470, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_coffin_southAddonDeed ), 470, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_block_southAddonDeed ), 430, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_block_eastAddonDeed ), 430, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( LargeDyingPlant ), 225, Utility.Random( 1,3 ), 0x42B9, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( DyingPlant ), 175, Utility.Random( 1,3 ), 0x42BA, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( PumpkinScarecrow ), 240, Utility.Random( 1,3 ), 0x469B, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GrimWarning ), 120, Utility.Random( 1,3 ), 0x42BD, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( SkullsOnPike ), 120, Utility.Random( 1,3 ), 0x42B5, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( BlackCatStatue ), 100, Utility.Random( 1,3 ), 0x4688, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( RuinedTapestry ), 135, Utility.Random( 1,3 ), 0x4699, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( HalloweenWeb ), 185, Utility.Random( 1,3 ), 0xEE3, Utility.RandomList( 43, 1175, 1151 ) ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_shackles ), 125, Utility.Random( 1,3 ), 5696, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_ruined_bookcase ), 340, Utility.Random( 1,3 ), 0x0C14, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_covered_chair ), 220, Utility.Random( 1,3 ), 3095, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_HauntedMirror1 ), 270, Utility.Random( 1,3 ), 10875, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_HauntedMirror2 ), 270, Utility.Random( 1,3 ), 10876, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( halloween_devil_face ), 150, Utility.Random( 1,3 ), 4348, 0 ) ); }
				if ( SetStock.SellCommonChance() ){ Add( new GenericBuyInfo( typeof( PackedCostume ), 230, Utility.Random( 1,3 ), 0x46A3, 0x5E0 ) ); }
				if ( SetStock.SellCommonChance() ){ Add( new GenericBuyInfo( typeof( WrappedCandy ), 20, Utility.Random( 1,3 ), 0x469E, 0 ) ); }
				if ( SetStock.SellCommonChance() ){ Add( new GenericBuyInfo( typeof( HalloweenPack ), 130, Utility.Random( 1,3 ), 0x46A3, 0x5E0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( NecromancerTable ), 520, Utility.Random( 1,3 ), 0x149D, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( NecromancerBanner ), 350, Utility.Random( 1,3 ), 0x149B, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( BurningScarecrowA ), 290, Utility.Random( 1,3 ), 0x23A9, 0 ) ); }
				if ( SetStock.SellChance() ){ Add( new GenericBuyInfo( typeof( GothicCandelabraA ), 280, Utility.Random( 1,3 ), 0x052D, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBScaryDeco : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBScaryDeco()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( BloodyTableAddonDeed ), 1500, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( BloodPentagramDeed ), 3800, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( MongbatDartBoardEastDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( MongbatDartBoardSouthDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( DaemonDartBoardEastDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0xB01 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( DaemonDartBoardSouthDeed ), 1200, Utility.Random( 1,3 ), 0x14EF, 0xB01 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EerieGhost ), 1500, Utility.Random( 1,3 ), 0x5754, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree6 ), 800, Utility.Random( 1,3 ), 0xCCD, 0x2C1 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree5 ), 800, Utility.Random( 1,3 ), 0x224D, 0x2C1 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree4 ), 800, Utility.Random( 1,3 ), 0xCD3, 0x2C1 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree3 ), 800, Utility.Random( 1,3 ), 0x224A, 0x2C5 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree2 ), 800, Utility.Random( 1,3 ), 0xD94, 0x2C5 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTree1 ), 800, Utility.Random( 1,3 ), 0xCE3, 0x2C5 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenTortSkel ), 450, Utility.Random( 1,3 ), 0x1A03, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenStoneSpike2 ), 600, Utility.Random( 1,3 ), 0x2202, 0x322 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenStoneSpike ), 600, Utility.Random( 1,3 ), 0x2201, 0x322 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenStoneColumn ), 500, Utility.Random( 1,3 ), 0x77, 0x322 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenSkullPole ), 540, Utility.Random( 1,3 ), 0x2204, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenShrineChaosDeed ), 1380, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenPylonFire ), 2100, Utility.Random( 1,3 ), 0x19AF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenPylon ), 1800, Utility.Random( 1,3 ), 0x1ECB, 0x322 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenMaiden ), 2780, Utility.Random( 1,3 ), 0x124B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenGrave3 ), 350, Utility.Random( 1,3 ), 0xEDE, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenGrave2 ), 350, Utility.Random( 1,3 ), 0x116E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenGrave1 ), 350, Utility.Random( 1,3 ), 0x1168, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenColumn ), 1100, Utility.Random( 1,3 ), 0x196, 0x322 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenChopper ), 1760, Utility.Random( 1,3 ), 0x1245, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenBonePileDeed ), 680, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenBlood ), 90, Utility.Random( 1,3 ), 0x122A, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( AppleBobbingBarrel ), 170, Utility.Random( 1,3 ), 0x0F33, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin ), Utility.Random( 80,200 ), Utility.Random( 1,3 ), 0x4694, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin2 ), Utility.Random( 80,200 ), Utility.Random( 1,3 ), 0x4698, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin3 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x5499, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin4 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x549D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin5 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54A1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin6 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54A5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin7 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54A9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin8 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54AD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin9 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54B1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin10 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54B5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin11 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54B9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin12 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54BD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin13 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54C1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin14 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54C9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin15 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54CC, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin16 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54CE, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin17 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54D2, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin18 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54D6, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin19 ), Utility.Random( 150,500 ), Utility.Random( 1,3 ), 0x54DA, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( CarvedPumpkin20 ), Utility.Random( 1500,5000 ), Utility.Random( 1,3 ), 0x5481, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( DeadBodyEWDeed ), 345, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( DeadBodyNSDeed ), 345, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EvilFireplaceSouthFaceAddonDeed ), 6800, Utility.Random( 1,3 ), 0x14EF, 1175 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( EvilFireplaceEastFaceAddonDeed ), 6800, Utility.Random( 1,3 ), 0x14EF, 1175 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_coffin_eastAddonDeed ), 470, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_coffin_southAddonDeed ), 470, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_block_southAddonDeed ), 430, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_block_eastAddonDeed ), 430, Utility.Random( 1,3 ), 0x14EF, 0x96C ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( LargeDyingPlant ), 225, Utility.Random( 1,3 ), 0x42B9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( DyingPlant ), 175, Utility.Random( 1,3 ), 0x42BA, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( PumpkinScarecrow ), 240, Utility.Random( 1,3 ), 0x469B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GrimWarning ), 120, Utility.Random( 1,3 ), 0x42BD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( SkullsOnPike ), 120, Utility.Random( 1,3 ), 0x42B5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( BlackCatStatue ), 100, Utility.Random( 1,3 ), 0x4688, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( RuinedTapestry ), 135, Utility.Random( 1,3 ), 0x4699, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenWeb ), 185, Utility.Random( 1,3 ), 0xEE3, Utility.RandomList( 43, 1175, 1151 ) ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_shackles ), 125, Utility.Random( 1,3 ), 5696, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_ruined_bookcase ), 340, Utility.Random( 1,3 ), 0x0C14, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_covered_chair ), 220, Utility.Random( 1,3 ), 3095, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_HauntedMirror1 ), 270, Utility.Random( 1,3 ), 10875, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_HauntedMirror2 ), 270, Utility.Random( 1,3 ), 10876, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( halloween_devil_face ), 150, Utility.Random( 1,3 ), 4348, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( PackedCostume ), 230, Utility.Random( 1,3 ), 0x46A3, 0x5E0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( WrappedCandy ), 20, Utility.Random( 1,3 ), 0x469E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( HalloweenPack ), 130, Utility.Random( 1,3 ), 0x46A3, 0x5E0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( NecromancerTable ), 520, Utility.Random( 1,3 ), 0x149D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( NecromancerBanner ), 350, Utility.Random( 1,3 ), 0x149B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( BurningScarecrowA ), 290, Utility.Random( 1,3 ), 0x23A9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){ Add( new GenericBuyInfo( typeof( GothicCandelabraA ), 280, Utility.Random( 1,3 ), 0x052D, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBNecroGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBNecroGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BatWing ), 3, Utility.Random( 30,310 ), 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, Utility.Random( 30,310 ), 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 5, Utility.Random( 30,310 ), 0xF8A, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, Utility.Random( 30,310 ), 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 3, Utility.Random( 30,310 ), 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 30,310 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 30,310 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 30,310 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( GargoyleEar ), 6, Utility.Random( 30,310 ), 0x2FD9, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 30,310 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 30,310 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( PixieSkull ), 6, Utility.Random( 30,310 ), 0x2FE1, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 30,310 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 30,310 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 30,310 ), 0x2FE0, 0 ) );
				Add( new GenericBuyInfo( typeof( BitterRoot ), 5, Utility.Random( 30,310 ), 0x640C, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackSand ), 7, Utility.Random( 30,310 ), 0x640D, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodRose ), 5, Utility.Random( 30,310 ), 0x640E, 0 ) );
				Add( new GenericBuyInfo( typeof( DriedToad ), 7, Utility.Random( 30,310 ), 0x640F, 0 ) );
				Add( new GenericBuyInfo( typeof( Maggot ), 5, Utility.Random( 30,310 ), 0x6410, 0 ) );
				Add( new GenericBuyInfo( typeof( MummyWrap ), 7, Utility.Random( 30,310 ), 0x6411, 0 ) );
				Add( new GenericBuyInfo( typeof( VioletFungus ), 5, Utility.Random( 30,310 ), 0x6412, 0 ) );
				Add( new GenericBuyInfo( typeof( WerewolfClaw ), 7, Utility.Random( 30,310 ), 0x6413, 0 ) );
				Add( new GenericBuyInfo( typeof( Wolfsbane ), 5, Utility.Random( 30,310 ), 0x6414, 0 ) );
				Add( new GenericBuyInfo( typeof( BloodOathScroll ), 25, Utility.Random( 3,31 ), 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( CorpseSkinScroll ), 28, Utility.Random( 3,31 ), 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( CurseWeaponScroll ), 12, Utility.Random( 3,31 ), 0x2263, 0 ) );
				Add( new GenericBuyInfo( typeof( PolishBoneBrush ), 12, 10, 0x1371, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveShovel ), 12, Utility.Random( 3,31 ), 0xF39, 0x966 ) );
				Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 3,31 ), 0x640B, 0 ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 3,31 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) );
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, Utility.Random( 3,31 ), 0x2253, 0 ) );
				Add( new GenericBuyInfo( typeof( TarotDeck ), 5, Utility.Random( 3,31 ), 0x12AB, 0 ) );
				Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) );
				Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) );
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( BlackDyeTub ), 5000, Utility.Random( 1,1 ), 0xFAB, 0x1 ) ); }
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) ); }
				Add( new GenericBuyInfo( typeof( reagents_magic_jar2 ), 1500, Utility.Random( 30,310 ), 0x1007, 0xB97 ) );
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( HellsGateScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x54F ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ManaLeechScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0xB87 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( NecroCurePoisonScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x8A2 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( NecroPoisonScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x4F8 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( NecroUnlockScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x493 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( PhantasmScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x6DE ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( RetchedAirScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0xA97 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( SpectreShadowScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x17E ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( UndeadEyesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x491 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( VampireGiftScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0xB85 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( WallOfSpikesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0xB8F ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( BloodPactScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x5B5 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GhostlyImagesScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0xBF ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GhostPhaseScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x47E ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GraveyardGatewayScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x2EA ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( HellsBrandScroll ), Utility.Random( 10,100 ), Utility.Random( 1,3 ), 0x1007, 0x54C ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ReaperHood ), 28, Utility.Random( 1,10 ), 0x4CDB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ReaperCowl ), 28, Utility.Random( 1,10 ), 0x4CDD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( DeadMask ), 28, Utility.Random( 1,10 ), 0x405, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( NecromancerRobe ), 50, Utility.Random( 1,10 ), 0x2FBA, 0 ) ); }
				Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) );
				Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) );
				Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				if ( MyServerSettings.BuyChance() ){Add( typeof( BlackStaff ), 11 ); } // DO NOT WANT?
				Add( typeof( BatWing ), 1 );
				Add( typeof( DaemonBlood ), 3 );
				Add( typeof( PigIron ), 2 );
				Add( typeof( NoxCrystal ), 3 );
				Add( typeof( GraveDust ), 1 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( GargoyleEar ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( PixieSkull ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				Add( typeof( BitterRoot ), 2 );
				Add( typeof( BlackSand ), 3 );
				Add( typeof( BloodRose ), 2 );
				Add( typeof( DriedToad ), 3 );
				Add( typeof( Maggot ), 2 );
				Add( typeof( MummyWrap ), 3 );
				Add( typeof( VioletFungus ), 2 );
				Add( typeof( WerewolfClaw ), 3 );
				Add( typeof( Wolfsbane ), 2 );
				Add( typeof( NecromancerSpellbook ), 55 );
				Add( typeof( DeathKnightSpellbook ), Utility.Random( 100,300 ) );
				Add( typeof( ExorcismScroll ), 72 );
				Add( typeof( AnimateDeadScroll ), 26 );
				Add( typeof( BloodOathScroll ), 26 );
				Add( typeof( CorpseSkinScroll ), 26 );
				Add( typeof( CurseWeaponScroll ), 26 );
				Add( typeof( EvilOmenScroll ), 26 );
				Add( typeof( PainSpikeScroll ), 26 );
				Add( typeof( SummonFamiliarScroll ), 26 );
				Add( typeof( HorrificBeastScroll ), 27 );
				Add( typeof( MindRotScroll ), 39 );
				Add( typeof( PoisonStrikeScroll ), 39 );
				Add( typeof( WraithFormScroll ), 51 );
				Add( typeof( LichFormScroll ), 64 );
				Add( typeof( StrangleScroll ), 64 );
				Add( typeof( WitherScroll ), 64 );
				Add( typeof( VampiricEmbraceScroll ), 101 );
				Add( typeof( VengefulSpiritScroll ), 114 );
				Add( typeof( WitchCauldron ), 8 );
				Add( typeof( MyNecromancerSpellbook ), 500 );
				Add( typeof( BlackDyeTub ), 2500 );
				Add( typeof( PolishBoneBrush ), 6 );
				Add( typeof( PolishedSkull ), 3 );
				Add( typeof( PolishedBone ), 3 );
				Add( typeof( BoneContainer ), Utility.RandomMinMax( 100, 400 ) );
				Add( typeof( CorpseSailor ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BodyPart ), Utility.RandomMinMax( 30, 90 ) );
				Add( typeof( CorpseChest ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( BuriedBody ), Utility.RandomMinMax( 50, 300 ) );
				Add( typeof( LeftLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightLeg ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( TastyHeart ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( Head ), Utility.RandomMinMax( 10, 20 ) );
				Add( typeof( LeftArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RightArm ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Torso ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bone ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( RibCage ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( BonePile ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( Bones ), Utility.RandomMinMax( 5, 10 ) );
				Add( typeof( GraveChest ), Utility.RandomMinMax( 100, 500 ) );
				Add( typeof( SkullMinotaur ), Utility.Random( 50,150 ) );
				Add( typeof( SkullWyrm ), Utility.Random( 200,400 ) );
				Add( typeof( SkullGreatDragon ), Utility.Random( 300,600 ) );
				Add( typeof( SkullDragon ), Utility.Random( 100,300 ) );
				Add( typeof( SkullDemon ), Utility.Random( 100,300 ) );
				Add( typeof( SkullGiant ), Utility.Random( 100,300 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
				Add( typeof( WoodenCoffin ), 25 );
				Add( typeof( WoodenCasket ), 25 );
				Add( typeof( StoneCoffin ), 45 );
				Add( typeof( StoneCasket ), 45 );
				Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) );
				Add( typeof( ReaperHood ), 11 );
				Add( typeof( ReaperCowl ), 11 );
				Add( typeof( DeadMask ), 11 );
				Add( typeof( NecromancerRobe ), 19 );
				if ( MyServerSettings.BuyChance() ){Add( typeof( DracolichSkull ), Utility.Random( 500,1000 ) ); } // DO NOT WANT?
				Add( typeof( WizardStaff ), 20 );
				Add( typeof( WizardStick ), 19 );
				Add( typeof( MageEye ), 1 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBElementalGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElementalGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( ElementalSpellbook ), 80, Utility.Random( 1,5 ), Utility.RandomList( 0x641F, 0x6420, 0x6421, 0x6422 ), 0 ) );
				Add( new GenericBuyInfo( typeof( WizardStaff ), 40, Utility.Random( 1,5 ), 0x0908, MaterialInfo.PlainIronColor(0) ) );
				Add( new GenericBuyInfo( typeof( WizardStick ), 38, Utility.Random( 1,5 ), 0xDF2, MaterialInfo.PlainIronColor(0) ) );
				Add( new GenericBuyInfo( typeof( MageEye ), 2, Utility.Random( 10,150 ), 0xF19, 0xB78 ) );
				Add( new GenericBuyInfo( typeof( BlackStaff ), 22, Utility.Random( 1,15 ), 0xDF1, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 1,30 ), 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( TotalRefreshPotion ), 30, Utility.Random( 1,30 ), 0x25FF, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserManaPotion ), 860, Utility.Random( 1,25 ), 0x23BD, 0x48D ) );
				Add( new GenericBuyInfo( typeof( ManaPotion ), 890, Utility.Random( 1,15 ), 0x180F, 0x48D ) );
				Add( new GenericBuyInfo( typeof( GreaterManaPotion ), 8120, Utility.Random( 1,5 ), 0x2406, 0x48D ) );

				int id=299;
				id++; Add( new GenericBuyInfo( typeof( Elemental_Armor_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Bolt_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Mend_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Sanctuary_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Pain_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Protection_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Purge_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Steed_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Call_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Force_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Wall_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Warp_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Field_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Restoration_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Strike_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Void_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				/*
				id++; Add( new GenericBuyInfo( typeof( Elemental_Blast_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Echo_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Fiend_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Hold_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Barrage_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Rune_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Storm_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Summon_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Devastation_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Fall_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Gate_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Havoc_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Apocalypse_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Lord_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Soul_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				id++; Add( new GenericBuyInfo( typeof( Elemental_Spirit_Scroll ), ElementalSpell.ScrollPrice( id, false ), Utility.Random( 1,5 ), ElementalSpell.ScrollLook( id, 1 ), ElementalSpell.ScrollLook( id, 2 ) ) );
				*/
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BlackStaff ), 11 );
				Add( typeof( MagicTalisman ), Utility.Random( 50,100 ) );
				Add( typeof( WizardsHat ), 5 );
				Add( typeof( WitchHat ), 5 );
				Add( typeof( ElementalSpellbook ), 35 );
				Add( typeof( MyElementalSpellbook ), 500 );
				Add( typeof( DemonPrison ), Utility.Random( 500,1000 ) );
				Add( typeof( WizardStaff ), 20 );
				Add( typeof( WizardStick ), 19 );
				Add( typeof( MageEye ), 1 );
				int id=299;
				id++; Add( typeof( Elemental_Armor_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Bolt_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Mend_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Sanctuary_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Pain_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Protection_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Purge_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Steed_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Call_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Force_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Wall_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Warp_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Field_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Restoration_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Strike_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Void_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Blast_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Echo_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Fiend_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Hold_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Barrage_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Rune_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Storm_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Summon_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Devastation_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Fall_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Gate_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Havoc_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Apocalypse_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Lord_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Soul_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
				id++; Add( typeof( Elemental_Spirit_Scroll ), ElementalSpell.ScrollPrice( id, true ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBArcherGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBArcherGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( GuildFletching ), 500, Utility.Random( 1,5 ), 0x1EB8, 0x430 ) );
				Add( new GenericBuyInfo( typeof( ArcherQuiver ), 32, Utility.Random( 1,5 ), Utility.RandomList( 0x2B02, 0x2B03, 0x5770, 0x5770 ), 0 ) );
				Add( new GenericBuyInfo( typeof( ManyArrows100 ), 200, Utility.Random( 1,10 ), 0xF41, 0 ) );
				Add( new GenericBuyInfo( typeof( ManyBolts100 ), 200, Utility.Random( 1,10 ), 0x1BFD, 0 ) );
				Add( new GenericBuyInfo( typeof( ManyArrows1000 ), 2000, Utility.Random( 1,10 ), 0xF41, 0 ) );
				Add( new GenericBuyInfo( typeof( ManyBolts1000 ), 2000, Utility.Random( 1,10 ), 0x1BFD, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ArcherQuiver ), 16 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBAlchemistGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemistGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( MortarPestle ), 8, Utility.Random( 3,31 ), 0x4CE9, 0 ) );
				Add( new GenericBuyInfo( typeof( WitchCauldron ), 16, Utility.Random( 3,31 ), 0x640B, 0 ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 3,31 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( AlchemicalElixirs ), 50, Utility.Random( 1,15 ), 0x2219, 0 ) );
				Add( new GenericBuyInfo( typeof( AlchemicalMixtures ), 50, Utility.Random( 1,15 ), 0x2223, 0 ) );
				Add( new GenericBuyInfo( typeof( BookOfPoisons ), 50, Utility.Random( 1,15 ), 0x2253, 0xB51 ) );
				Add( new GenericBuyInfo( typeof( HeatingStand ), 2, Utility.Random( 1,15 ), 0x1849, 0 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 30,310 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 30,310 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 30,310 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 30,310 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 30,310 ), 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 30,310 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 30,310 ), 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 30,310 ), 0xF8C, 0 ) );

				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 30,310 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( ButterflyWings ), 6, Utility.Random( 30,310 ), 0x3002, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 30,310 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( FairyEgg ), 6, Utility.Random( 30,310 ), 0x2FDB, 0 ) );
				Add( new GenericBuyInfo( typeof( GargoyleEar ), 6, Utility.Random( 30,310 ), 0x2FD9, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 30,310 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 30,310 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( PixieSkull ), 6, Utility.Random( 30,310 ), 0x2FE1, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 30,310 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SeaSalt ), 6, Utility.Random( 30,310 ), 0x2FE9, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 30,310 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 30,310 ), 0x2FE0, 0 ) );

				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( reagents_magic_jar1 ), 2000, Utility.Random( 3,31 ), 0x1007, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){ Add( new GenericBuyInfo( typeof( reagents_magic_jar2 ), 1500, Utility.Random( 3,31 ), 0x1007, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( reagents_magic_jar3 ), 5000, Utility.Random( 30,310 ), 0x1007, 0x488 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( BottleOfAcid ), 600, Utility.Random( 3,21 ), 0x180F, 1167 ) ); }

				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 10,25 ), 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, Utility.Random( 10,25 ), 0xF08, 0 ) );
				Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, Utility.Random( 10,25 ), 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 10,25 ), 0x25FD, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, Utility.Random( 10,25 ), 0xF09, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, Utility.Random( 10,25 ), 0x2600, 0 ) );
 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 15, Utility.Random( 10,25 ), 0x233B, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 21, Utility.Random( 10,25 ), 0x2407, 0 ) );

				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( HealPotion ), 30, Utility.Random( 1,15 ), 0xF0C, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( PoisonPotion ), 30, Utility.Random( 1,15 ), 0xF0A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( CurePotion ), 30, Utility.Random( 1,15 ), 0xF07, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ExplosionPotion ), 42, Utility.Random( 1,15 ), 0xF0D, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ConflagrationPotion ), 30, Utility.Random( 1,15 ), 0x180F, 0xAD8 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ConfusionBlastPotion ), 30, Utility.Random( 1,15 ), 0x180F, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( FrostbitePotion ), 30, Utility.Random( 1,15 ), 0x180F, 0xAF3 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( TotalRefreshPotion ), 30, Utility.Random( 1,15 ), 0x25FF, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterAgilityPotion ), 60, Utility.Random( 1,15 ), 0x256A, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterConflagrationPotion ), 60, Utility.Random( 1,15 ), 0x2406, 0xAD8 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterConfusionBlastPotion ), 60, Utility.Random( 1,15 ), 0x2406, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 60, Utility.Random( 1,15 ), 0x24EA, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterExplosionPotion ), 60, Utility.Random( 1,15 ), 0x2408, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterFrostbitePotion ), 60, Utility.Random( 1,15 ), 0x2406, 0xAF3 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 60, Utility.Random( 1,15 ), 0x25FE, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterPoisonPotion ), 60, Utility.Random( 1,15 ), 0x2601, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterStrengthPotion ), 60, Utility.Random( 1,15 ), 0x25F7, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( DeadlyPoisonPotion ), 60, Utility.Random( 1,15 ), 0x2669, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( LesserInvisibilityPotion ), 860, Utility.Random( 1,3 ), 0x23BD, 0x490 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( LesserManaPotion ), 860, Utility.Random( 1,3 ), 0x23BD, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( LesserRejuvenatePotion ), 860, Utility.Random( 1,3 ), 0x23BD, 0x48E ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( InvisibilityPotion ), 890, Utility.Random( 1,3 ), 0x180F, 0x490 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ManaPotion ), 890, Utility.Random( 1,3 ), 0x180F, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( RejuvenatePotion ), 890, Utility.Random( 1,3 ), 0x180F, 0x48E ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterInvisibilityPotion ), 8120, 1, 0x2406, 0x490 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterManaPotion ), 8120, 1, 0x2406, 0x48D ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreaterRejuvenatePotion ), 8120, 1, 0x2406, 0x48E ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( InvulnerabilityPotion ), 8300, 1, 0x180F, 0x48F ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( AutoResPotion ), 8600, 1, 0x0E0F, 0x494 ) ); }
				Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) );
				Add( new GenericBuyInfo( typeof( AlchemistPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0xAFE ) );
				Add( new GenericBuyInfo( typeof( DruidPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x8A1 ) );
				Add( new GenericBuyInfo( typeof( WitchPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x845 ) );
				Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( SkullMinotaur ), Utility.Random( 50,150 ) );
				Add( typeof( SkullWyrm ), Utility.Random( 200,400 ) );
				Add( typeof( SkullGreatDragon ), Utility.Random( 300,600 ) );
				Add( typeof( SkullDragon ), Utility.Random( 100,300 ) );
				Add( typeof( SkullDemon ), Utility.Random( 100,300 ) );
				Add( typeof( SkullGiant ), Utility.Random( 100,300 ) );
				Add( typeof( CanopicJar ), Utility.Random( 50,300 ) );
				Add( typeof( WitchCauldron ), 8 );
				Add( typeof( DragonTooth ), 120 );
				Add( typeof( EnchantedSeaweed ), 120 );
				Add( typeof( GhostlyDust ), 120 );
				Add( typeof( GoldenSerpentVenom ), 120 );
				Add( typeof( LichDust ), 120 );
				Add( typeof( SilverSerpentVenom ), 120 );
				Add( typeof( UnicornHorn ), 120 );
				Add( typeof( DemigodBlood ), 120 );
				Add( typeof( DemonClaw ), 120 );
				Add( typeof( DragonBlood ), 120 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 1 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( ButterflyWings ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( FairyEgg ), 3 );
				Add( typeof( GargoyleEar ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( PixieSkull ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SeaSalt ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				Add( typeof( MortarPestle ), 4 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( AutoResPotion ), 94 );
				Add( typeof( BottleOfAcid ), 32 );
				Add( typeof( ConflagrationPotion ), 7 );
				Add( typeof( FrostbitePotion ), 7 );
				Add( typeof( ConfusionBlastPotion ), 7 );
				Add( typeof( CurePotion ), 14 );
				Add( typeof( DeadlyPoisonPotion ), 28 );
				Add( typeof( ExplosionPotion ), 14 );
				Add( typeof( GreaterAgilityPotion ), 28 );
				Add( typeof( GreaterConflagrationPotion ), 28 );
				Add( typeof( GreaterFrostbitePotion ), 28 );
				Add( typeof( GreaterConfusionBlastPotion ), 28 );
				Add( typeof( GreaterCurePotion ), 28 );
				Add( typeof( GreaterExplosionPotion ), 28 );
				Add( typeof( GreaterHealPotion ), 28 );
				Add( typeof( GreaterInvisibilityPotion ), 28 );
				Add( typeof( GreaterManaPotion ), 28 );
				Add( typeof( GreaterPoisonPotion ), 28 );
				Add( typeof( GreaterRejuvenatePotion ), 28 );
				Add( typeof( GreaterStrengthPotion ), 28 );
				Add( typeof( HealPotion ), 14 );
				Add( typeof( InvisibilityPotion ), 14 );
				Add( typeof( InvulnerabilityPotion ), 53 );
				Add( typeof( PotionOfWisdom ), Utility.Random( 250,500 ) );
				Add( typeof( PotionOfDexterity ), Utility.Random( 250,500 ) );
				Add( typeof( PotionOfMight ), Utility.Random( 250,500 ) );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserInvisibilityPotion ), 7 );
				Add( typeof( LesserManaPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserRejuvenatePotion ), 7 );
				Add( typeof( ManaPotion ), 14 );
				Add( typeof( NightSightPotion ), 14 );
				Add( typeof( PoisonPotion ), 14 );
				Add( typeof( RefreshPotion ), 14 );
				Add( typeof( RejuvenatePotion ), 28 );
				Add( typeof( StrengthPotion ), 14 );
				Add( typeof( TotalRefreshPotion ), 28 );
				Add( typeof( SpecialSeaweed ), Utility.Random( 20, 40 ) );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBLibraryGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBLibraryGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( LoreGuidetoAdventure ), 5, Utility.Random( 5,15 ), 0x4FDF, Utility.RandomColor(0) ) );
				Add( new GenericBuyInfo( typeof( WeaponAbilityBook ), 5, Utility.Random( 1,15 ), 0x2254, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnLeatherBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnMiscBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnMetalBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnWoodBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnReagentsBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnTailorBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnGraniteBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( LearnScalesBook ), 5, Utility.Random( 1,15 ), 0x02DD, 0 ) );
				Add( new GenericBuyInfo( typeof( BookDruidBrewing ), 50, Utility.Random( 1,15 ), 0x5688, 0x85D ) );
				Add( new GenericBuyInfo( typeof( BookWitchBrewing ), 50, Utility.Random( 1,15 ), 0x5689, 0x9A2 ) );
				Add( new GenericBuyInfo( typeof( AlchemicalElixirs ), 50, Utility.Random( 1,15 ), 0x2219, 0 ) );
				Add( new GenericBuyInfo( typeof( AlchemicalMixtures ), 50, Utility.Random( 1,15 ), 0x2223, 0 ) );
				Add( new GenericBuyInfo( typeof( BookOfPoisons ), 50, Utility.Random( 1,15 ), 0x2253, 0xB51 ) );
				Add( new GenericBuyInfo( typeof( WorkShoppes ), 50, Utility.Random( 1,15 ), 0x2259, 0xB50 ) );
				Add( new GenericBuyInfo( typeof( LearnTitles ), 5, Utility.Random( 1,15 ), 0xFF2, 0 ) );
				Add( new GenericBuyInfo( typeof( ScribesPen ), 8, Utility.Random( 3,31 ), 0x2051, 0 ) );
				Add( new GenericBuyInfo( typeof( Monocle ), 24, Utility.Random( 3,30 ), 0x543B, 0 ) );
				if ( MyServerSettings.SellVeryRareChance() ){ Add( new GenericBuyInfo( "1041267", typeof( Runebook ), 3500, Utility.Random( 1,3 ), 0x0F3D, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScribesPen ), 4 );
				Add( typeof( Monocle ), 12 );
				Add( typeof( DynamicBook ), Utility.Random( 10,150 ) );
				Add( typeof( TomeOfWands ), Utility.Random( 100,400 ) );
				Add( typeof( JokeBook ), Utility.Random( 750,1500 ) );
				Add( typeof( DataPad ), Utility.Random( 5, 150 ) );
				Add( typeof( NecromancerSpellbook ), 55 );
				Add( typeof( BookOfBushido ), 70 );
				Add( typeof( BookOfNinjitsu ), 70 );
				Add( typeof( MysticSpellbook ), 70 );
				Add( typeof( DeathKnightSpellbook ), Utility.Random( 100,300 ) );
				Add( typeof( Runebook ), Utility.Random( 100,350 ) );
				Add( typeof( BookOfChivalry ), 70 );
				Add( typeof( BookOfChivalry ), 70 );
				Add( typeof( HolyManSpellbook ), Utility.Random( 50,200 ) );
				Add( typeof( SmallHollowBook ), Utility.Random( 25,250 ) );
				Add( typeof( LargeHollowBook ), Utility.Random( 35,300 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBDruidGuild : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDruidGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Bandage ), 2, Utility.Random( 30,310 ), 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, Utility.Random( 3,31 ), 0x25FD, 0 ) );
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, Utility.Random( 30,310 ), 0x266F, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, Utility.Random( 30,310 ), 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, Utility.Random( 30,310 ), 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, Utility.Random( 30,310 ), 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, Utility.Random( 30,310 ), 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, Utility.Random( 30,310 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, Utility.Random( 30,310 ), 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, Utility.Random( 30,310 ), 0xF8C, 0 ) );
				Add( new GenericBuyInfo( typeof( Brimstone ), 6, Utility.Random( 30,310 ), 0x2FD3, 0 ) );
				Add( new GenericBuyInfo( typeof( ButterflyWings ), 6, Utility.Random( 30,310 ), 0x3002, 0 ) );
				Add( new GenericBuyInfo( typeof( EyeOfToad ), 6, Utility.Random( 30,310 ), 0x2FDA, 0 ) );
				Add( new GenericBuyInfo( typeof( FairyEgg ), 6, Utility.Random( 30,310 ), 0x2FDB, 0 ) );
				Add( new GenericBuyInfo( typeof( BeetleShell ), 6, Utility.Random( 30,310 ), 0x2FF8, 0 ) );
				Add( new GenericBuyInfo( typeof( MoonCrystal ), 6, Utility.Random( 30,310 ), 0x3003, 0 ) );
				Add( new GenericBuyInfo( typeof( RedLotus ), 6, Utility.Random( 30,310 ), 0x2FE8, 0 ) );
				Add( new GenericBuyInfo( typeof( SeaSalt ), 6, Utility.Random( 30,310 ), 0x2FE9, 0 ) );
				Add( new GenericBuyInfo( typeof( SilverWidow ), 6, Utility.Random( 30,310 ), 0x2FF7, 0 ) );
				Add( new GenericBuyInfo( typeof( SwampBerries ), 6, Utility.Random( 30,310 ), 0x2FE0, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, Utility.Random( 3,31 ), 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( DruidCauldron ), 16, Utility.Random( 3,31 ), 0x640A, 0 ) );
				Add( new GenericBuyInfo( typeof( BookDruidBrewing ), 50, Utility.Random( 1,15 ), 0x5688, 0x85D ) );
				Add( new GenericBuyInfo( typeof( AlchemyTub ), 2400, Utility.Random( 1,5 ), 0x126A, 0 ) );
				Add( new GenericBuyInfo( typeof( DruidPouch ), Utility.Random( 800,1200 ), Utility.Random( 1,2 ), 0x5776, 0x8A1 ) );
				Add( new GenericBuyInfo( typeof( AlchemyPouch ), Utility.Random( 2900,3500 ), Utility.Random( 1,2 ), 0x1C10, 0x89F ) );
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( AppleTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( CherryBlossomTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( DarkBrownTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( GreyTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( LightBrownTreeDeed ), 540, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( PeachTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( PearTreeDeed ), 640, Utility.Random( 1,2 ), 0x14F0, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 1 );
				Add( typeof( Brimstone ), 3 );
				Add( typeof( ButterflyWings ), 3 );
				Add( typeof( EyeOfToad ), 3 );
				Add( typeof( FairyEgg ), 3 );
				Add( typeof( BeetleShell ), 3 );
				Add( typeof( MoonCrystal ), 3 );
				Add( typeof( RedLotus ), 3 );
				Add( typeof( SeaSalt ), 3 );
				Add( typeof( SilverWidow ), 3 );
				Add( typeof( SwampBerries ), 3 );
				Add( typeof( DruidCauldron ), 8 );
				Add( typeof( AlchemyTub ), Utility.Random( 200, 500 ) );
				Add( typeof( FirstAidKit ), Utility.Random( 100,250 ) );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBCarpenterGuild: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCarpenterGuild()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Hatchet ), 20, Utility.Random( 1,15 ), 0xF44, 0 ) );
				Add( new GenericBuyInfo( typeof( LumberAxe ), 22, Utility.Random( 1,15 ), 0xF43, 0x96D ) );
				Add( new GenericBuyInfo( typeof( GuildCarpentry ), 500, Utility.Random( 1,5 ), 0x1EBA, 0x430 ) );
				Add( new GenericBuyInfo( typeof( Nails ), 3, Utility.Random( 3,31 ), 0x102E, 0 ) );
				Add( new GenericBuyInfo( typeof( Axle ), 2, Utility.Random( 3,31 ), 0x105B, 0 ) );
				Add( new GenericBuyInfo( typeof( DrawKnife ), 10, Utility.Random( 3,31 ), 0x10E4, 0 ) );
				Add( new GenericBuyInfo( typeof( Froe ), 10, Utility.Random( 3,31 ), 0x10E5, 0 ) );
				Add( new GenericBuyInfo( typeof( Scorp ), 10, Utility.Random( 3,31 ), 0x10E7, 0 ) );
				Add( new GenericBuyInfo( typeof( Inshave ), 10, Utility.Random( 3,31 ), 0x10E6, 0 ) );
				Add( new GenericBuyInfo( typeof( DovetailSaw ), 12, Utility.Random( 3,31 ), 0x1028, 0 ) );
				Add( new GenericBuyInfo( typeof( Saw ), 15, Utility.Random( 3,31 ), 0x1034, 0 ) );
				Add( new GenericBuyInfo( typeof( Hammer ), 17, Utility.Random( 3,31 ), 0x102A, 0 ) );
				Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, Utility.Random( 3,31 ), 0x102C, 0 ) );
				Add( new GenericBuyInfo( typeof( SmoothingPlane ), 10, Utility.Random( 3,31 ), 0x1032, 0 ) );
				Add( new GenericBuyInfo( typeof( JointingPlane ), 11, Utility.Random( 3,31 ), 0x1030, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodworkingTools ), 10, Utility.Random( 10,50 ), 0x4F52, 0 ) );
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AdventurerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( AlchemyCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F91, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ArmsCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BakerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F92, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BeekeeperCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F95, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BlacksmithCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( BowyerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F97, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ButcherCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F89, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CarpenterCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8A, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( FletcherCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F88, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HealerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F98, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( HugeCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F86, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( JewelerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( LibrarianCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F96, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( MusicianCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F94, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NecromancerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9A, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( ProvisionerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8E, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SailorCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9C, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( StableCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F87, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( SupplyCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F9D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TailorCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TavernCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F99, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TinkerCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F90, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( TreasureCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F93, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( WizardryCrate ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x4F8C, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C43, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C45, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C47, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C89, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x38B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x38D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CCB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireI ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CCD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmoireJ ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D26, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BF1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C31, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C63, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CAD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewArmorShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CEF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C3B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C65, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C67, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CBF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBakerShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C41, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C4B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C6B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBlacksmithShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C15, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C2B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C2D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C33, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C5F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C61, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C79, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfI ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfJ ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CAF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfK ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CEB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfL ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CED, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBookShelfM ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D05, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C29, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C5D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewBowyerShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewCarpenterShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C6F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewCarpenterShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CD7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewCarpenterShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CFB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C51, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C53, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C75, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C77, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CDD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CDF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CFF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewClothShelfH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D01, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDarkBookShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BF9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDarkBookShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BFB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDarkShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BFD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C7F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C81, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C83, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C85, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C87, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersI ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CBB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersJ ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CBD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersK ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D0B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersL ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D20, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersM ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D22, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrawersN ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D24, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C27, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C5B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CA1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewDrinkShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C1B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewHelmShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BFF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewHunterShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C4D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewKitchenShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C19, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewKitchenShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C39, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewOldBookShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x19FF, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewPotionShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3BF3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewRuinedBookShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0xC14, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C35, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C3D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C69, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C7B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfG ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShelfH ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D07, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C37, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C7D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CB3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewShoeShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D09, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C4F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C73, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CDB, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSorcererShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CFD, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSupplyShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C57, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSupplyShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C9D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewSupplyShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE3, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C3F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C6D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CC7, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTailorShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CF9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTannerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C23, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTannerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C49, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C25, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C59, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C9F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTavernShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE5, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTinkerShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C71, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTinkerShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CD9, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTinkerShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3D03, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewTortureShelf ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C2F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfA ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C17, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfB ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C1D, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfC ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C21, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfD ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C55, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfE ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3C9B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( NewWizardShelfF ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x3CE1, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterFancy ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x544F, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterWood ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5451, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterWooden ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5453, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterStained ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5455, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterPolished ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5457, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterRustic ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x5459, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterDark ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x545B, 0 ) ); }
				if ( SetStock.SellVeryRareChance() ){Add( new GenericBuyInfo( typeof( CounterLight ), Utility.Random( 200,400 ), Utility.Random( 1,5 ), 0x545D, 0 ) ); }
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Hatchet ), 15 );
				Add( typeof( LumberAxe ), 16 );
				Add( typeof( WoodenBox ), 7 );
				Add( typeof( SmallCrate ), 5 );
				Add( typeof( MediumCrate ), 6 );
				Add( typeof( LargeCrate ), 7 );
				Add( typeof( WoodenChest ), 15 );
				Add( typeof( LargeTable ), 10 );
				Add( typeof( Nightstand ), 7 );
				Add( typeof( YewWoodTable ), 10 );
				Add( typeof( Throne ), 24 );
				Add( typeof( WoodenThrone ), 6 );
				Add( typeof( Stool ), 6 );
				Add( typeof( FootStool ), 6 );
				Add( typeof( FancyWoodenChairCushion ), 12 );
				Add( typeof( WoodenChairCushion ), 10 );
				Add( typeof( WoodenChair ), 8 );
				Add( typeof( BambooChair ), 6 );
				Add( typeof( WoodenBench ), 6 );
				Add( typeof( Saw ), 9 );
				Add( typeof( Scorp ), 6 );
				Add( typeof( SmoothingPlane ), 6 );
				Add( typeof( DrawKnife ), 6 );
				Add( typeof( Froe ), 6 );
				Add( typeof( Hammer ), 14 );
				Add( typeof( Inshave ), 6 );
				Add( typeof( WoodworkingTools ), 6 );
				Add( typeof( JointingPlane ), 6 );
				Add( typeof( MouldingPlane ), 6 );
				Add( typeof( DovetailSaw ), 7 );
				Add( typeof( Axle ), 1 );
				Add( typeof( Club ), 13 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBAssassin : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAssassin()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, Utility.Random( 10,50 ), 0x2600, 0 ) );
				Add( new GenericBuyInfo( typeof( PoisonPotion ), 30, Utility.Random( 10,50 ), 0xF0A, 0 ) );
				Add( new GenericBuyInfo( typeof( GreaterPoisonPotion ), 60, Utility.Random( 10,50 ), 0x2601, 0 ) );
				if ( MyServerSettings.SellChance() ){Add( new GenericBuyInfo( typeof( DeadlyPoisonPotion ), 120, Utility.Random( 1,15 ), 0x2669, 0 ) ); }
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( LethalPoisonPotion ), 320, Utility.Random( 1,15 ), 0x266A, 0 ) ); }
				Add( new GenericBuyInfo( typeof( Nightshade ), 4, Utility.Random( 30,310 ), 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( Dagger ), 21, Utility.Random( 10,50 ), 0xF52, 0 ) );
				Add( new GenericBuyInfo( typeof( LargeKnife ), 21, Utility.Random( 10,50 ), 0x2674, 0 ) );
				Add( new GenericBuyInfo( typeof( AssassinSpike ), 21, Utility.Random( 1,15 ), 0x2D21, 0 ) );
				Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 100, Utility.Random( 1,15 ), 0xEFF, 0 ) );
				Add( new GenericBuyInfo( "hair dye bottle", typeof( HairDyeBottle ), 1000, Utility.Random( 1,15 ), 0xE0F, 0 ) );
				if ( MyServerSettings.SellRareChance() ){Add( new GenericBuyInfo( typeof( DisguiseKit ), 700, Utility.Random( 1,5 ), 0xE05, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( AssassinRobe ), 38, Utility.Random( 1,10 ), 0x2B69, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ScholarRobe ), 50, Utility.Random( 1,10 ), 0x2652, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ReaperHood ), 28, Utility.Random( 1,10 ), 0x4CDB, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( ReaperCowl ), 28, Utility.Random( 1,10 ), 0x4CDD, 0 ) ); }
				if ( MyServerSettings.SellChance() ){ Add( new GenericBuyInfo( typeof( DeadMask ), 28, Utility.Random( 1,10 ), 0x405, 0 ) ); }
				Add( new GenericBuyInfo( typeof( BookOfPoisons ), 50, Utility.Random( 1,15 ), 0x2253, 0xB51 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( PoisonPotion ), 14 );
				Add( typeof( GreaterPoisonPotion ), 28 );
				Add( typeof( DeadlyPoisonPotion ), 56 );
				Add( typeof( LethalPoisonPotion ), 128 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( Dagger ), 10 );
				Add( typeof( LargeKnife ), 10 );
				Add( typeof( HairDye ), 50 );
				Add( typeof( HairDyeBottle ), 300 );
				Add( typeof( SilverSerpentVenom ), 140 );
				Add( typeof( GoldenSerpentVenom ), 210 );
				Add( typeof( AssassinSpike ), 10 );
				Add( typeof( AssassinRobe ), 19 );
				Add( typeof( ScholarRobe ), 29 );
				Add( typeof( ReaperHood ), 11 );
				Add( typeof( ReaperCowl ), 11 );
				Add( typeof( DeadMask ), 11 );
			}
		}
	}
	///////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SBCartographer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBCartographer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( BlankMap ), 5, Utility.Random( 3,31 ), 0x14EC, 0 ) );
				Add( new GenericBuyInfo( typeof( MapmakersPen ), 8, Utility.Random( 3,31 ), 0x2052, 0 ) );
				Add( new GenericBuyInfo( typeof( MasterSkeletonsKey ), Utility.Random( 100,500 ), Utility.Random( 3,5 ), 0x410B, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( MapmakersPen ), 4 );
				Add( typeof( BlankMap ), 2 );
				Add( typeof( CityMap ), 3 );
				Add( typeof( LocalMap ), 3 );
				Add( typeof( WorldMap ), 3 );
				Add( typeof( PresetMapEntry ), 3 );
				Add( typeof( WorldMapLodor ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapSosaria ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapBottle ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapSerpent ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapUmber ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapAmbrosia ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapIslesOfDread ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapSavage ), Utility.Random( 10,150 ) );
				Add( typeof( WorldMapUnderworld ), Utility.Random( 20,300 ) );
				Add( typeof( AlternateRealityMap ), Utility.Random( 500,1000 ) );
			}
		}
	}
}

namespace Server.Misc
{
    class SetStock
    {
		private static int S_SellChance = 50;
		private static int S_SellCommonChance = 80;
		private static int S_SellRareChance = 25;
		private static int S_SellVeryRareChance = 5;
		private static int S_BuyChance = 50;
		private static int S_BuyCommonChance = 80;
		private static int S_BuyRareChance = 70;

		public static bool SellChance() // CHANCE A VENDOR SELLS A REGULAR ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_SellChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}

		public static bool SellCommonChance() // CHANCE A VENDOR SELLS A REALLY COMMON ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_SellCommonChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}

		public static bool SellRareChance() // CHANCE A VENDOR SELLS A RARE ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_SellRareChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}

		public static bool SellVeryRareChance() // CHANCE A VENDOR SELLS A VERY RARE ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_SellVeryRareChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}

		public static bool BuyChance() // CHANCE A VENDOR BUYS A REGULAR ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_BuyChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}

		public static bool BuyCommonChance() // CHANCE A VENDOR BUYS A COMMON ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_BuyCommonChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}

		public static bool BuyRareChance() // CHANCE A VENDOR BUYS A RARE ITEM. SET "chance" HIGHER FOR MORE OFTEN
		{
			int chance = S_BuyRareChance;	if ( chance >= Utility.RandomMinMax( 1, 100 ) ){ return true; }
			return false;
		}
	}
}
