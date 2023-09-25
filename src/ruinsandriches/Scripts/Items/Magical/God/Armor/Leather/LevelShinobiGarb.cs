using System;
using Server.Items;

namespace Server.Items
{
	public class LevelShinobiRobe : LevelLeatherRobe
	{
		[Constructable]
		public LevelShinobiRobe() : base( 0x5C10 )
		{
			Name = "leather shinobi robe";
			Weight = 6.0;
			Layer = Layer.OuterTorso;
			Hue = Server.Misc.MaterialInfo.PlainLeatherColor();
		}

		public LevelShinobiRobe( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class LevelShinobiHood : LevelLeatherCap
	{
		[Constructable]
		public LevelShinobiHood() : base( 0x5C11 )
		{
			Weight = 2.0;
			Name = "leather shinobi hood";
			Layer = Layer.Helm;
			Hue = Server.Misc.MaterialInfo.PlainLeatherColor();
		}

		public LevelShinobiHood( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class LevelShinobiMask : LevelLeatherCap
	{
		[Constructable]
		public LevelShinobiMask() : base( 0x5C12 )
		{
			Weight = 2.0;
			Name = "leather shinobi mask";
			Layer = Layer.Helm;
			Hue = Server.Misc.MaterialInfo.PlainLeatherColor();
		}

		public LevelShinobiMask( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class LevelShinobiCowl : LevelLeatherCap
	{
		[Constructable]
		public LevelShinobiCowl() : base( 0x5C13 )
		{
			Weight = 2.0;
			Name = "leather shinobi cowl";
			Layer = Layer.Helm;
			Hue = Server.Misc.MaterialInfo.PlainLeatherColor();
		}

		public LevelShinobiCowl( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
