using System;
using Server;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class OilCloth : Item, IScissorable, IDyable
	{
		public override int LabelNumber{ get{ return 1041498; } } // oil cloth

		public override double DefaultWeight
		{
			get { return 1.0; }
		}

		[Constructable]
		public OilCloth() : this( 1 )
		{
		}

		[Constructable]
		public OilCloth( int amount ) : base( 0x175D )
		{
			Stackable = true;
			Amount = amount;
			Hue = 2001;
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) )
				return false;

			base.ScissorHelper( from, new Bandage(), Amount );

			return true;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( OnTarget ) );
				from.SendLocalizedMessage( 1005424 ); // Select the weapon or armor you wish to use the cloth on.
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public void OnTarget( Mobile from, object obj )
		{
			// TODO: Need details on how oil cloths should get consumed here

			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else if ( obj is BaseWeapon )
			{
				BaseWeapon weapon = (BaseWeapon)obj;

				if ( weapon.RootParent != from )
				{
					from.SendLocalizedMessage( 1005425 ); // You may only wipe down items you are holding or carrying.
				}
				else if ( weapon.Poison == null || weapon.PoisonCharges <= 0 )
				{
					from.LocalOverheadMessage( Network.MessageType.Regular, 0x3B2, 1005422 ); // Hmmmm... this does not need to be cleaned.
				}
				else
				{
					if ( weapon.PoisonCharges < 2 )
						weapon.PoisonCharges = 0;
					else
						weapon.PoisonCharges -= 2;

					if ( weapon.PoisonCharges > 0 )
						from.SendLocalizedMessage( 1005423 ); // You have removed some of the caustic substance, but not all.
					else
						from.SendLocalizedMessage( 1010497 ); // You have cleaned the item.
				}
			}
			else if ( obj is BaseBeverage )
			{
				BaseBeverage beverage = (BaseBeverage) obj;

				if ( beverage.Content == BeverageType.Liquor )
				{
					Firebomb bomb = new Firebomb( beverage.ItemID );
					bomb.Name = beverage.Name;
					Point3D loc = beverage.Location;
					beverage.Delete();

					from.AddToBackpack( bomb );
					bomb.Location = loc;
					from.SendLocalizedMessage( 1060580 ); // You prepare a firebomb.
					Consume();
				}
			}
			else if ( obj is Firebomb )
			{
				from.SendLocalizedMessage( 1060579 ); // That is already a firebomb!
			}
			else
			{
				from.SendLocalizedMessage( 1005426 ); // The cloth will not work on that.
			}
		}

		public OilCloth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}