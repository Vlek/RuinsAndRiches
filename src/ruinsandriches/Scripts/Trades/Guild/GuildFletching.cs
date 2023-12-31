using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using System.Collections.Generic;
using Server.Misc;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;

namespace Server.Items
{
    public class GuildFletching : Item
    {
        [Constructable]
        public GuildFletching() : base(0x1EB8)
        {
            Name = "Extraordinary Bowcrafting Tools";
			Weight = 5.0;
			Hue = 0x430;
        }

        public GuildFletching(Serial serial) : base(serial)
		{
		}

        public override void OnDoubleClick( Mobile from )
        {
			if ( from is PlayerMobile )
			{
				int canDo = 0;

				foreach ( Mobile m in this.GetMobilesInRange( 20 ) )
				{
					if ( m is ArcherGuildmaster )
						++canDo;
				}
				foreach ( Item i in this.GetItemsInRange( 20 ) )
				{
					if ( i is BowyerShoppe && !i.Movable )
					{
						BowyerShoppe b = (BowyerShoppe)i;

						if ( b.ShoppeOwner == from )
							++canDo;
					}
				}
				if ( from.Map == Map.SavagedEmpire && from.X > 1054 && from.X < 1126 && from.Y > 1907 && from.Y < 1983 ){ ++canDo; }

				PlayerMobile pc = (PlayerMobile)from;
				if ( pc.NpcGuild != NpcGuild.ArchersGuild )
				{
					from.SendMessage( "Only those of the Archers Guild may use this!" );
				}
				else if ( from.Skills[SkillName.Bowcraft].Value < 90 )
				{
					from.SendMessage( "Only a master fletcher can use this!" );
				}
				else if ( canDo == 0 )
				{
					from.SendMessage( "You need to be near a bowyer guildmaster, or a bowyer shoppe you own, to use this!" );
				}
				else
				{
					from.SendMessage("Select the bow or crossbow you would like to enhance...");
					from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(OnTarget));
				}
			}
        }

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{ 
			base.GetContextMenuEntries( from, list ); 
			list.Add( new SpeechGumpEntry( from ) );
		} 

		public class SpeechGumpEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			
			public SpeechGumpEntry( Mobile from ) : base( 6121, 3 )
			{
				m_Mobile = from;
			}

			public override void OnClick()
			{
			    if( !( m_Mobile is PlayerMobile ) )
				return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( ! mobile.HasGump( typeof( SpeechGump ) ) )
					{
						mobile.SendGump(new SpeechGump( mobile, "Enhancing Items", SpeechFunctions.SpeechText( m_Mobile, m_Mobile, "Enhance" ) ));
					}
				}
            }
        }

        public void OnTarget(Mobile from, object obj)
        {
            if ( obj is Item )
            {
				Item item = (Item)obj;

                if (((Item)obj).RootParent != from)
                {
                    from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                }
				else if ( item is ILevelable )
				{
					from.SendMessage( "You cannot enhance legendary artefacts!" );
				}
				else if ( item is BaseRanged )
				{
					BaseWeapon weapon = (BaseWeapon)item;

					if ( Server.Misc.MaterialInfo.IsAnyKindOfWoodItem( item ) )
                    {
						GuildCraftingProcess process = new GuildCraftingProcess(from, (Item)obj);
						process.BeginProcess();
					}
					else
					{
						from.SendMessage( "You cannot enhance this item!" );
					}
				}
                else
                {
					from.SendMessage( "You cannot enhance this item!" );
                }
            }
        }
        
        public override void Serialize(GenericWriter writer)
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