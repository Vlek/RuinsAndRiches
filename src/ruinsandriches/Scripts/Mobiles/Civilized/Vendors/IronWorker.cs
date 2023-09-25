using System;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	public class IronWorker : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.BlacksmithsGuild; } }

		[Constructable]
		public IronWorker() : base( "the iron worker" )
		{
			SetSkill( SkillName.ArmsLore, 36.0, 68.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Fencing, 60.0, 83.0 );
			SetSkill( SkillName.Bludgeoning, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBAxeWeapon() );
			m_SBInfos.Add( new SBKnifeWeapon() );
			m_SBInfos.Add( new SBMaceWeapon() );
			m_SBInfos.Add( new SBSmithTools() );
			m_SBInfos.Add( new SBPoleArmWeapon() );
			m_SBInfos.Add( new SBSpearForkWeapon() );
			m_SBInfos.Add( new SBSwordWeapon() );
			m_SBInfos.Add( new SBMetalShields() );
			m_SBInfos.Add( new SBHelmetArmor() );
			m_SBInfos.Add( new SBPlateArmor() );
			m_SBInfos.Add( new SBChainmailArmor() );
			m_SBInfos.Add( new SBRingmailArmor() );

			m_SBInfos.Add( new RSIngotsMain() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Serpent Island" )
				m_SBInfos.Add( new RSIngotsSerpentIsland() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Savaged Empire" )
				m_SBInfos.Add( new RSIngotsSavagedEmpire() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Island of Umber Veil" )
				m_SBInfos.Add( new RSIngotsUmberVeil() );
			if ( Worlds.GetMyWorld( this.Map, this.Location, this.X, this.Y ) == "the Underworld" )
				m_SBInfos.Add( new RSIngotsUnderworld() );
			if ( Server.Misc.Worlds.IsSeaTown( this.Location, this.Map ) )
				m_SBInfos.Add( new RSIngotsSea() );

			m_SBInfos.Add( new SBBuyArtifacts() );
			m_SBInfos.Add( new SBGemArmor() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			if ( Utility.RandomBool() ){ AddItem( new Server.Items.Bandana( Utility.RandomNeutralHue() ) ); }
			if ( Utility.RandomBool() ){ AddItem( new Server.Items.SmithHammer() ); }
		}

		public IronWorker( Serial serial ) : base( serial )
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
