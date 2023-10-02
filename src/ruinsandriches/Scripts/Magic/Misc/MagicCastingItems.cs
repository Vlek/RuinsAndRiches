using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Mobiles;

namespace Server.Misc
{
class MagicCastingItem
{
    public static bool CastNoSkill(Item item)
    {
        if (item is BaseMagicStaff)
        {
            return true;
        }

        if (item is RobeOfTeleportation || item is Artifact_RobeOfTeleportation)
        {
            return true;
        }

        if (item is BaseMagicObject)
        {
            return true;
        }

        return false;
    }
}
}
