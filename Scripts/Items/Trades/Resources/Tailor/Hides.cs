using System;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseHides : Item, ICommodity
	{
		private CraftResource m_Resource;

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource Resource
		{
			get{ return m_Resource; }
			set{ m_Resource = value; InvalidateProperties(); }
		}
		
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
			writer.Write( (int) m_Resource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			m_Resource = (CraftResource)reader.ReadInt();
			Name = Server.Misc.MaterialInfo.GetResourceName( m_Resource ) + "hide";
		}

		public BaseHides( CraftResource resource ) : this( resource, 1 )
		{
		}

		public BaseHides( CraftResource resource, int amount ) : base( 0x1079 )
		{
			Stackable = true;
			Weight = 5.0;
			Amount = amount;
			Hue = CraftResources.GetHue( resource );

			m_Resource = resource;
			Name = Server.Misc.MaterialInfo.GetResourceName( resource ) + "hide";
		}

		public BaseHides( Serial serial ) : base( serial )
		{
		}

		public override int LabelNumber
		{
			get
			{
				if ( m_Resource >= CraftResource.SpinedLeather && m_Resource <= CraftResource.BarbedLeather )
					return 1049687 + (int)(m_Resource - CraftResource.SpinedLeather);

				if ( m_Resource == CraftResource.DinosaurLeather )
					return 1036112;

				return 1047023;
			}
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class Hides : BaseHides, IScissorable
	{
		[Constructable]
		public Hides() : this( 1 )
		{
		}

		[Constructable]
		public Hides( int amount ) : base( CraftResource.RegularLeather, amount )
		{
		}

		public Hides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}
			base.ScissorHelper( from, new Leather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class SpinedHides : BaseHides, IScissorable
	{
		[Constructable]
		public SpinedHides() : this( 1 )
		{
		}

		[Constructable]
		public SpinedHides( int amount ) : base( CraftResource.SpinedLeather, amount )
		{
		}

		public SpinedHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new SpinedLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class HornedHides : BaseHides, IScissorable
	{
		[Constructable]
		public HornedHides() : this( 1 )
		{
		}

		[Constructable]
		public HornedHides( int amount ) : base( CraftResource.HornedLeather, amount )
		{
		}

		public HornedHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}
			
			base.ScissorHelper( from, new HornedLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class BarbedHides : BaseHides, IScissorable
	{
		[Constructable]
		public BarbedHides() : this( 1 )
		{
		}

		[Constructable]
		public BarbedHides( int amount ) : base( CraftResource.BarbedLeather, amount )
		{
		}

		public BarbedHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new BarbedLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class NecroticHides : BaseHides, IScissorable
	{
		[Constructable]
		public NecroticHides() : this( 1 )
		{
		}

		[Constructable]
		public NecroticHides( int amount ) : base( CraftResource.NecroticLeather, amount )
		{
		}

		public NecroticHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new NecroticLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class VolcanicHides : BaseHides, IScissorable
	{
		[Constructable]
		public VolcanicHides() : this( 1 )
		{
		}

		[Constructable]
		public VolcanicHides( int amount ) : base( CraftResource.VolcanicLeather, amount )
		{
		}

		public VolcanicHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new VolcanicLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class FrozenHides : BaseHides, IScissorable
	{
		[Constructable]
		public FrozenHides() : this( 1 )
		{
		}

		[Constructable]
		public FrozenHides( int amount ) : base( CraftResource.FrozenLeather, amount )
		{
		}

		public FrozenHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new FrozenLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class GoliathHides : BaseHides, IScissorable
	{
		[Constructable]
		public GoliathHides() : this( 1 )
		{
		}

		[Constructable]
		public GoliathHides( int amount ) : base( CraftResource.GoliathLeather, amount )
		{
		}

		public GoliathHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new GoliathLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class DraconicHides : BaseHides, IScissorable
	{
		[Constructable]
		public DraconicHides() : this( 1 )
		{
		}

		[Constructable]
		public DraconicHides( int amount ) : base( CraftResource.DraconicLeather, amount )
		{
		}

		public DraconicHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new DraconicLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class HellishHides : BaseHides, IScissorable
	{
		[Constructable]
		public HellishHides() : this( 1 )
		{
		}

		[Constructable]
		public HellishHides( int amount ) : base( CraftResource.HellishLeather, amount )
		{
		}

		public HellishHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new HellishLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class DinosaurHides : BaseHides, IScissorable
	{
		[Constructable]
		public DinosaurHides() : this( 1 )
		{
		}

		[Constructable]
		public DinosaurHides( int amount ) : base( CraftResource.DinosaurLeather, amount )
		{
		}

		public DinosaurHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new DinosaurLeather(), 1 );

			return true;
		}
	}

	[FlipableAttribute( 0x1079, 0x1078 )]
	public class AlienHides : BaseHides, IScissorable
	{
		[Constructable]
		public AlienHides() : this( 1 )
		{
		}

		[Constructable]
		public AlienHides( int amount ) : base( CraftResource.AlienLeather, amount )
		{
		}

		public AlienHides( Serial serial ) : base( serial )
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

		public bool Scissor( Mobile from, Scissors scissors )
		{
			if ( Deleted || !from.CanSee( this ) ) return false;

			if ( !IsChildOf ( from.Backpack ) )
			{
				from.SendLocalizedMessage ( 502437 ); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper( from, new AlienLeather(), 1 );

			return true;
		}
	}
}