using System;
using Server;

namespace Server.Items
{
    public class AngeroftheGods : Broadsword, IIslesDreadDyable
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

        [Constructable]
        public AngeroftheGods()
        {
            Name = "Anger of the Gods";
            Attributes.WeaponDamage = 35;
            Attributes.AttackChance = 10;
            Attributes.DefendChance = 15;
            WeaponAttributes.HitHarm = 50;
            WeaponAttributes.HitLeechMana = 15;
            WeaponAttributes.HitLowerAttack = 25;
            Attributes.CastSpeed = 1;
            Attributes.WeaponSpeed = 20;
            Hue = 1265;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

        public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
        {
            phys = 25;
            cold = 25;
            fire = 0;
            nrgy = 50;
            pois = 0;
            chaos = 0;
            direct = 0;
        }

        public AngeroftheGods( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int)0 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
