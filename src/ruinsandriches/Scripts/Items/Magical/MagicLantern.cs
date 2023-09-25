using System;
using Server;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class MagicLantern : GoldRing
	{
		[Constructable]
		public MagicLantern()
		{
			Resource = CraftResource.None;
			Name = "lantern";

			//Name = LootPackEntry.MagicItemAdj( "start", false, false, ItemID ) + " " + Name;

			Hue = Utility.RandomColor(0);
			Light = LightType.Circle300;
			Weight = 2.0;
			ItemID = 0xA18;
			GraphicID = 0xA18;
			Layer = Layer.TwoHanded;
            Attributes.NightSight = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			if ( this.ItemID == 0xA15 || this.ItemID == 0x6478 ){ list.Add( 1049644, "Double-Click to Unequip"); }
			else { list.Add( 1049644, "Double-Click to Equip"); }
        }

		public override bool AllowEquipedCast( Mobile from )
		{
			return true;
		}

		public override bool OnEquip( Mobile from )
		{
			from.PlaySound( 0x47 );
			this.ItemID = 0xA15;
			this.GraphicID = 0xA15;
			return base.OnEquip( from );
		}

		public override void OnRemoved( object parent )
		{
			if ( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.PlaySound( 0x4BB );
			}
			this.ItemID = 0xA18;
			this.GraphicID = 0xA18;
			base.OnRemoved( parent );
		}

		public override void OnDoubleClick( Mobile from )
		{
			Item torch = from.FindItemOnLayer( Layer.TwoHanded );
			if ( torch != null && torch == this && ( torch.ItemID == 0xA18 || torch.ItemID == 0x647B) )
			{
				OnEquip( from );
			}
			else if ( torch != null && torch == this && ( torch.ItemID == 0xA15 || torch.ItemID == 0x6478) )
			{
				from.AddToBackpack(this);
				OnRemoved( from );
			}
			else if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else
			{
				if ( from.FindItemOnLayer( Layer.TwoHanded ) != null )
				{
					from.AddToBackpack( from.FindItemOnLayer( Layer.TwoHanded ) );
				}
				from.SendMessage( "You put the lantern in your left hand." );
				from.AddItem(this);
				OnEquip( from );
			}
			from.ProcessClothing();
		}

		public MagicLantern( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
