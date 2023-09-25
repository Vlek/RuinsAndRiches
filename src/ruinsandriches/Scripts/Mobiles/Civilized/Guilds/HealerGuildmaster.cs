using System;
using System.Collections;
using Server;

namespace Server.Mobiles
{
	public class HealerGuildmaster : BaseGuildmaster
	{
		public override NpcGuild NpcGuild{ get{ return NpcGuild.HealersGuild; } }

		[Constructable]
		public HealerGuildmaster() : base( "healer" )
		{
			SetSkill( SkillName.Anatomy, 85.0, 100.0 );
			SetSkill( SkillName.Healing, 90.0, 100.0 );
			SetSkill( SkillName.Forensics, 75.0, 98.0 );
			SetSkill( SkillName.MagicResist, 75.0, 98.0 );
			SetSkill( SkillName.Spiritualism, 65.0, 88.0 );
		}

		public override void InitSBInfo()
		{
			SBInfos.Add( new SBHealerGuild() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			switch ( Utility.RandomMinMax( 0, 4 ) )
			{
				case 1: AddItem( new Server.Items.GnarledStaff() ); break;
				case 2: AddItem( new Server.Items.BlackStaff() ); break;
				case 3: AddItem( new Server.Items.WildStaff() ); break;
				case 4: AddItem( new Server.Items.QuarterStaff() ); break;
			}
		}

		public HealerGuildmaster( Serial serial ) : base( serial )
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
