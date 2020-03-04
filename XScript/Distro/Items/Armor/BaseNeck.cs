using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (HideGorget), typeof (LeafGorget), typeof (LeatherGorget), typeof (PlateGorget),
        typeof (RangerGorget),
        typeof (StuddedGorget), typeof (WoodlandGorget), typeof (GargishNecklace), typeof (GargishAmulet),
        typeof (GargishStoneAmulet), typeof(TigerCollar))]
    public class BaseNeck : BaseArmor
    {
        public BaseNeck(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Neck; }
        }
    }

    [QuerySearch(new ushort[] {0x316D})]
    public class HideGorget : BaseNeck
    {
        public HideGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x317D, 0x2fc7})]
    public class LeafGorget : BaseNeck
    {
        public LeafGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x13C7})]
    public class LeatherGorget : BaseNeck
    {
        public LeatherGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1413})]
    public class PlateGorget : BaseNeck
    {
        public PlateGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x13D6})]
    public class RangerGorget : BaseNeck
    {
        public RangerGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] { 0x316D })]
    public class StuddedGorget : BaseNeck
    {
        public StuddedGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] { 0x7829 })]
    public class TigerCollar : BaseNeck
    {
        public TigerCollar(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x3160, 0x2B69})]
    public class WoodlandGorget : BaseNeck
    {
        public WoodlandGorget(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Wood; }
        }
    }


    [QuerySearch(0x4210)]
    public class GargishNecklace : BaseArmor
    {
        public GargishNecklace(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }

        public override Layer BodyPosition
        {
            get { return Layer.Neck; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(0x4D0A)]
    public class GargishStoneAmulet : BaseArmor
    {
        public GargishStoneAmulet(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Stone; }
        }

        public override Layer BodyPosition
        {
            get { return Layer.Neck; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(0x4D0B)]
    public class GargishAmulet : BaseArmor
    {
        public GargishAmulet(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }

        public override Layer BodyPosition
        {
            get { return Layer.Neck; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }
}