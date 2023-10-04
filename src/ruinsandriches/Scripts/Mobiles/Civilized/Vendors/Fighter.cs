using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	public class Fighter : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.WarriorsGuild; } }

		[Constructable]
		public Fighter() : base( "the fighter" )
		{
			SetSkill( SkillName.Fencing, 45.0, 68.0 );
			SetSkill( SkillName.Bludgeoning, 45.0, 68.0 );
			SetSkill( SkillName.Swords, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 36.0, 68.0 );
			SetSkill( SkillName.Parry, 45.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			switch ( Utility.Random( 8 ) )
			{
				case 0:
				{
					m_SBInfos.Add( new SBLeatherArmor() );
					m_SBInfos.Add( new SBStuddedArmor() );
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBPlateArmor() );
					m_SBInfos.Add( new SBHelmetArmor() );
					m_SBInfos.Add( new SBChainmailArmor() );
					m_SBInfos.Add( new SBRingmailArmor() );
					break;
				}
				case 1:
				{
					m_SBInfos.Add( new SBStuddedArmor() );
					m_SBInfos.Add( new SBLeatherArmor() );
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBHelmetArmor() );
					break;
				}
				case 2:
				{
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBPlateArmor() );
					m_SBInfos.Add( new SBHelmetArmor() );
					m_SBInfos.Add( new SBChainmailArmor() );
					m_SBInfos.Add( new SBRingmailArmor() );
					break;
				}
				case 3:
				{
					m_SBInfos.Add( new SBMetalShields() );
					m_SBInfos.Add( new SBHelmetArmor() );
					break;
				}
				case 4:
				case 5:
				case 6:
				case 7:
				{
					m_SBInfos.Add( new SBWeaponSmith() );
					break;
				}
			}
		}

		public override void InitOutfit()
		{
			Mobile m = this;
			int weapon = Utility.RandomMinMax( 4, 32 );
			bool shield = true;

			if ( Utility.RandomMinMax(1,20) == 1 )
			{
				if ( Utility.RandomBool() ){ m.AddItem( new BoneArms() ); } else { m.AddItem( new OrcHelm() ); }
				m.AddItem( new BoneChest() );
				m.AddItem( new BoneGloves() );
				m.AddItem( new BoneHelm() );
				m.AddItem( new BoneLegs() );
			}
			else
			{
				switch ( Utility.Random( 10 ) )
				{
					case 0: m.AddItem( new PlateHelm() ); break;
					case 1: m.AddItem( new ChainCoif() ); break;
					case 2: m.AddItem( new Bascinet() ); break;
					case 3: m.AddItem( new CloseHelm() ); break;
					case 4: m.AddItem( new Helmet() ); break;
					case 5: m.AddItem( new NorseHelm() ); break;
				}
				switch ( Utility.Random( 3 ) )
				{
					case 0: m.AddItem( new PlateArms() ); break;
					case 1: m.AddItem( new RingmailArms() ); break;
				}
				switch ( Utility.Random( 2 ) )
				{
					case 0: m.AddItem( new PlateGorget() ); break;
				}
				switch ( Utility.Random( 3 ) )
				{
					case 0: m.AddItem( new PlateLegs() ); break;
					case 1: m.AddItem( new RingmailLegs() ); break;
					case 2: m.AddItem( new ChainLegs() ); break;
				}
				switch ( Utility.Random( 3 ) )
				{
					case 0: m.AddItem( new PlateGloves() ); break;
					case 1: m.AddItem( new RingmailGloves() ); break;
				}
				switch ( Utility.Random( 3 ) )
				{
					case 0: if ( m.Female && Utility.RandomBool() ){ m.AddItem( new FemalePlateChest() ); } else { m.AddItem( new PlateChest() ); } break;
					case 1: m.AddItem( new RingmailChest() ); break;
					case 2: m.AddItem( new ChainChest() ); break;
				}
			}

			switch ( Utility.Random( 2 ) )
			{
				case 0: m.AddItem( new Boots() ); break;
				case 1: m.AddItem( new ThighBoots() ); break;
			}

			switch ( Utility.Random( 2 ) )
			{
				case 0: m.AddItem( new Cloak( Utility.RandomColor(0) ) ); break;
			}

			switch ( weapon )
			{
				case 0: m.AddItem( new ButcherKnife() ); break;
				case 1: m.AddItem( new Cleaver() ); break;
				case 2: m.AddItem( new Dagger() ); break;
				case 3: m.AddItem( new SkinningKnife() ); break;

				case 4: m.AddItem( new Broadsword() ); break;
				case 5: m.AddItem( new Cutlass() ); break;
				case 6: m.AddItem( new Katana() ); break;
				case 7: m.AddItem( new Kryss() ); break;
				case 8: m.AddItem( new Longsword() ); break;
				case 9: m.AddItem( new Scimitar() ); break;
				case 10: m.AddItem( new ThinLongsword() ); break;
				case 11: m.AddItem( new VikingSword() ); break;
				case 12: m.AddItem( new Scythe() ); shield = false; break;
				case 13: m.AddItem( new ShortSpear() ); break;

				case 14: m.AddItem( new BattleAxe() ); shield = false; break;
				case 15: m.AddItem( new DoubleAxe() ); shield = false; break;
				case 16: m.AddItem( new ExecutionersAxe() ); shield = false; break;
				case 17: m.AddItem( new LargeBattleAxe() ); shield = false; break;
				case 18: m.AddItem( new Pickaxe() ); shield = false; break;
				case 19: m.AddItem( new TwoHandedAxe() ); shield = false; break;
				case 20: m.AddItem( new WarAxe() ); shield = false; break;
				case 21: m.AddItem( new Axe() ); shield = false; break;

				case 22: m.AddItem( new Spear() ); shield = false; break;
				case 23: m.AddItem( new Pitchfork() ); shield = false; break;
				case 24: m.AddItem( new Pike() ); shield = false; break;

				case 25: m.AddItem( new Bardiche() ); shield = false; break;
				case 26: m.AddItem( new Halberd() ); shield = false; break;

				case 27: m.AddItem( new Club() ); break;
				case 28: m.AddItem( new HammerPick() ); break;
				case 29: m.AddItem( new Mace() ); break;
				case 30: m.AddItem( new Maul() ); break;
				case 31: m.AddItem( new WarHammer() ); break;
				case 32: m.AddItem( new WarMace() ); break;

				case 33: m.AddItem( new BlackStaff() ); shield = false; break;
				case 34: m.AddItem( new GnarledStaff() ); shield = false; break;
				case 35: m.AddItem( new QuarterStaff() ); shield = false; break;
				case 36: m.AddItem( new ShepherdsCrook() ); shield = false; break;

				case 37: m.AddItem( new HeavyCrossbow() ); shield = false; break;
				case 38: m.AddItem( new Bow() ); shield = false; break;
				case 39: m.AddItem( new Crossbow() ); shield = false; break;
			}

			if ( shield && Utility.RandomBool() )
			{
				switch ( Utility.Random( 8 ) )
				{
					case 0: m.AddItem( new BronzeShield() ); break;
					case 1: m.AddItem( new ChaosShield() ); break;
					case 2: m.AddItem( new HeaterShield() ); break;
					case 3: m.AddItem( new MetalKiteShield() ); break;
					case 4: m.AddItem( new MetalShield() ); break;
					case 5: m.AddItem( new OrderShield() ); break;
					case 6: m.AddItem( new WoodenKiteShield() ); break;
					case 7: m.AddItem( new WoodenShield() ); break;
				}
			}
		}

		public Fighter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}