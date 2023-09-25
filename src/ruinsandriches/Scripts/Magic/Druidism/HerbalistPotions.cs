using System;
using Server;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;

namespace Server.Items
{
	public class ShieldOfEarthPotion : SpellScroll
	{
		[Constructable]
		public ShieldOfEarthPotion() : this( 1 )
		{
		}

		[Constructable]
		public ShieldOfEarthPotion( int amount ) : base( 147, 0x282F, amount )
		{
			Name = "shield of earth liquid";
			Hue = 0x300;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public ShieldOfEarthPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class WoodlandProtectionPotion : SpellScroll
	{
		[Constructable]
		public WoodlandProtectionPotion() : this( 1 )
		{
		}

		[Constructable]
		public WoodlandProtectionPotion( int amount ) : base( 148, 0x282F, amount )
		{
			Name = "woodland protection oil";
			Hue = 0x7E2;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public WoodlandProtectionPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class ProtectiveFairyPotion : SpellScroll
	{
		[Constructable]
		public ProtectiveFairyPotion() : this( 1 )
		{
		}

		[Constructable]
		public ProtectiveFairyPotion( int amount ) : base( 149, 0x282F, amount )
		{
			Name = "fairy in a jar";
			Hue = 0x9FF;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public ProtectiveFairyPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
			Name = "fairy in a jar";
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class HerbalHealingPotion : SpellScroll
	{
		[Constructable]
		public HerbalHealingPotion() : this( 1 )
		{
		}

		[Constructable]
		public HerbalHealingPotion( int amount ) : base( 150, 0x282F, amount )
		{
			Name = "herbal healing elixir";
			Hue = 0x279;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public HerbalHealingPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class GraspingRootsPotion : SpellScroll
	{
		[Constructable]
		public GraspingRootsPotion() : this( 1 )
		{
		}

		[Constructable]
		public GraspingRootsPotion( int amount ) : base( 151, 0x282F, amount )
		{
			Name = "grasping roots mixture";
			Hue = 0x83F;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public GraspingRootsPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class BlendWithForestPotion : SpellScroll
	{
		[Constructable]
		public BlendWithForestPotion() : this( 1 )
		{
		}

		[Constructable]
		public BlendWithForestPotion( int amount ) : base( 152, 0x282F, amount )
		{
			Name = "forest blending oil";
			Hue = 0x59C;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public BlendWithForestPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class SwarmOfInsectsPotion : SpellScroll
	{
		[Constructable]
		public SwarmOfInsectsPotion() : this( 1 )
		{
		}

		[Constructable]
		public SwarmOfInsectsPotion( int amount ) : base( 153, 0x282F, amount )
		{
			Name = "jar of insects";
			Hue = 0xA70;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public SwarmOfInsectsPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
			Name = "jar of insects";
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class VolcanicEruptionPotion : SpellScroll
	{
		[Constructable]
		public VolcanicEruptionPotion() : this( 1 )
		{
		}

		[Constructable]
		public VolcanicEruptionPotion( int amount ) : base( 154, 0x282F, amount )
		{
			Name = "volcanic fluid";
			Hue = 0x54E;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public VolcanicEruptionPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class TreefellowPotion : SpellScroll
	{
		[Constructable]
		public TreefellowPotion() : this( 1 )
		{
		}

		[Constructable]
		public TreefellowPotion( int amount ) : base( 155, 0x282F, amount )
		{
			Name = "treant fertilizer";
			Hue = 0x223;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public TreefellowPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class StoneCirclePotion : SpellScroll
	{
		[Constructable]
		public StoneCirclePotion() : this( 1 )
		{
		}

		[Constructable]
		public StoneCirclePotion( int amount ) : base( 156, 0x282F, amount )
		{
			Name = "stone rising concoction";
			Hue = 0x396;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public StoneCirclePotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class DruidicRunePotion : SpellScroll
	{
		[Constructable]
		public DruidicRunePotion() : this( 1 )
		{
		}

		[Constructable]
		public DruidicRunePotion( int amount ) : base( 157, 0x282F, amount )
		{
			Name = "druidic marking oil";
			Hue = 0x487;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public DruidicRunePotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class LureStonePotion : SpellScroll
	{
		[Constructable]
		public LureStonePotion() : this( 1 )
		{
		}

		[Constructable]
		public LureStonePotion( int amount ) : base( 158, 0x282F, amount )
		{
			Name = "stone in a jar";
			Hue = 0x967;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public LureStonePotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
			Name = "stone in a jar";
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class NaturesPassagePotion : SpellScroll
	{
		[Constructable]
		public NaturesPassagePotion() : this( 1 )
		{
		}

		[Constructable]
		public NaturesPassagePotion( int amount ) : base( 159, 0x282F, amount )
		{
			Name = "nature passage mixture";
			Hue = 0x48B;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public NaturesPassagePotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class MushroomGatewayPotion : SpellScroll
	{
		[Constructable]
		public MushroomGatewayPotion() : this( 1 )
		{
		}

		[Constructable]
		public MushroomGatewayPotion( int amount ) : base( 160, 0x282F, amount )
		{
			Name = "mushroom gateway growth";
			Hue = 0x3B7;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public MushroomGatewayPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class RestorativeSoilPotion : SpellScroll
	{
		[Constructable]
		public RestorativeSoilPotion() : this( 1 )
		{
		}

		[Constructable]
		public RestorativeSoilPotion( int amount ) : base( 161, 0x282F, amount )
		{
			Name = "jar of magical mud";
			Hue = 0x479;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public RestorativeSoilPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
			Name = "jar of magical mud";
		}
	}
	//////////////////////////////////////////////////////////////////////////////////////////////////////////
	public class FireflyPotion : SpellScroll
	{
		[Constructable]
		public FireflyPotion() : this( 1 )
		{
		}

		[Constructable]
		public FireflyPotion( int amount ) : base( 162, 0x282F, amount )
		{
			Name = "jar of fireflies";
			Hue = 0x491;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
		}

		public FireflyPotion( Serial serial ) : base( serial )
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
			ItemID = 0x282F;
			Name = "jar of fireflies";
		}
	}
}
