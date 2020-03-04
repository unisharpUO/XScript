using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (BoneArms), typeof (FemaleGargishClothArms), typeof (GargishClothArms), typeof (DaemonArms),
        typeof (DragonArms),
        typeof (FemaleGargishLeatherArms), typeof (GargishLeatherArms), typeof (FemaleGargishPlatemailArms),
        typeof (GargishPlatemailArms),
        typeof (FemaleGargishStoneArms), typeof (GargishStoneArms), typeof (LeatherHiroSode), typeof (PlateArms),
        typeof (PlateHiroSode),
        typeof (RangerArms), typeof (RingmailArms), typeof (StuddedArms), typeof (StuddedHiroSode),
        typeof (WoodlandArms), typeof (HidePauldrons),
        typeof (LeafArms), typeof (LeatherArms))]
    public class BaseArms : BaseArmor
    {
        public BaseArms(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Arms; }
        }
    }

    [QuerySearch(new ushort[] {0x144e, 0x1453})]
    public class BoneArms : BaseArms
    {
        public BoneArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x405F})]
    public class FemaleGargishClothArms : BaseArms
    {
        public FemaleGargishClothArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4060})]
    public class GargishClothArms : BaseArms
    {
        public GargishClothArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x144e, 0x1453})]
    public class DaemonArms : BaseArms
    {
        public DaemonArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x2657, 0x2658})]
    public class DragonArms : BaseArms
    {
        public DragonArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Scale; }
        }
    }

    [QuerySearch(new ushort[] {0x4047, 0x0301})]
    public class FemaleGargishLeatherArms : BaseArms
    {
        public FemaleGargishLeatherArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4048, 0x0302})]
    public class GargishLeatherArms : BaseArms
    {
        public GargishLeatherArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x404F, 0x0307})]
    public class FemaleGargishPlatemailArms : BaseArms
    {
        public FemaleGargishPlatemailArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4050, 0x0308})]
    public class GargishPlatemailArms : BaseArms
    {
        public GargishPlatemailArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4057, 0x0283})]
    public class FemaleGargishStoneArms : BaseArms
    {
        public FemaleGargishStoneArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Stone; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4058, 0x0284})]
    public class GargishStoneArms : BaseArms
    {
        public GargishStoneArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Stone; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x277E})]
    public class LeatherHiroSode : BaseArms
    {
        public LeatherHiroSode(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1410, 0x1417})]
    public class PlateArms : BaseArms
    {
        public PlateArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x2780})]
    public class PlateHiroSode : BaseArms
    {
        public PlateHiroSode(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x13dc, 0x13d4})]
    public class RangerArms : BaseArms
    {
        public RangerArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x13ee, 0x13ef})]
    public class RingmailArms : BaseArms
    {
        public RingmailArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Ringmail; }
        }
    }

    [QuerySearch(new ushort[] {0x13dc, 0x13d4})]
    public class StuddedArms : BaseArms
    {
        public StuddedArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x277F})]
    public class StuddedHiroSode : BaseArms
    {
        public StuddedHiroSode(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x3163, 0x2B6C})]
    public class WoodlandArms : BaseArms
    {
        public WoodlandArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Wood; }
        }
    }

    [QuerySearch(new ushort[] {0x316E})]
    public class HidePauldrons : BaseArms
    {
        public HidePauldrons(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x317E, 0x2fc8})]
    public class LeafArms : BaseArms
    {
        public LeafArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x13cd, 0x13c5})]
    public class LeatherArms : BaseArms
    {
        public LeatherArms(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }
}