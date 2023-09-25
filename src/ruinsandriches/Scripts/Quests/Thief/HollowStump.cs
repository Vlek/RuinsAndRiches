using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using System.Collections.Generic;
using System.Collections;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
	[Flipable( 0x19FD, 0x19FE )]
	public class HollowStump : Item
	{
		public string StumpTown;
		[CommandProperty(AccessLevel.Owner)]
		public string Stump_Town { get { return StumpTown; } set { StumpTown = value; InvalidateProperties(); } }

		[Constructable]
		public HollowStump() : base( 0x19FD )
		{
			Name = "hollow stump";
			Movable = false;
		}

		public static void GetNearbyTown( HollowStump stump )
		{
			if ( stump.Map == Map.SerpentIsland )
			{
				stump.StumpTown = "the City of Furnace";
			}
			else
			{
				foreach ( Mobile citizen in stump.GetMobilesInRange( 200 ) )
				{
					if ( citizen is BaseVendor || citizen is TownGuards || ( citizen is Citizens && !(citizen is HouseVisitor) ) )
					{
						if ( citizen.Region.Name != null ){ stump.StumpTown = Server.Misc.Worlds.GetRegionName( citizen.Map, citizen.Location ); }
					}
				}
			}

			if ( stump.StumpTown == null || stump.StumpTown == "" ){ stump.StumpTown = "the City of Britain"; }
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 2 ) )
			{
				bool LookInside = true;

				if ( from.Backpack.FindItemByType( typeof ( ThiefNote ) ) != null )
				{
					Item mail = from.Backpack.FindItemByType( typeof ( ThiefNote ) );
					ThiefNote envelope = (ThiefNote)mail;

					if ( envelope.NoteOwner == from && envelope.NoteItemGot > 0 && StumpTown == envelope.NoteDeliverTo && envelope.NoteDeliverType == 1 )
					{
						LoggingFunctions.LogStandard( from, "has stolen " + envelope.NoteItem + "." );
						from.AddToBackpack ( new Gold( envelope.NoteReward ) );
						Titles.AwardFame( from, ((int)(envelope.NoteReward/100)), true );
						Titles.AwardKarma( from, -((int)(envelope.NoteReward/100)), true );
						Server.Items.ThiefNote.SetupNote( envelope, from );
						from.LocalOverheadMessage(MessageType.Emote, 1150, true, "You collected your reward.");
						from.SendMessage( "You found another secret note for you." );
						from.SendSound( 0x3D );
						from.CloseGump( typeof( Server.Items.ThiefNote.NoteGump ) );
						Server.Items.ThiefNote.ThiefTimeAllowed( from );
						LookInside = false;
					}
				}

				if ( LookInside )
				{
					string message = "There is nothing of interest in here.";

					if ( Utility.RandomMinMax( 1, 20 ) == 1 && Stackable == false )
					{
						Server.Misc.ContainerFunctions.GiveRandomItem( from );
						message = "You pull something out of the stump and it falls by your feet.";
					}
					Stackable = true;

					from.SendSound( 0x057 );
					from.SendMessage( message );
				}
			}
			else
			{
				from.SendLocalizedMessage( 502138 ); // That is too far away for you to use
			}
		}

		public HollowStump( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
            writer.Write( StumpTown );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			StumpTown = reader.ReadString();
		}
	}
}
