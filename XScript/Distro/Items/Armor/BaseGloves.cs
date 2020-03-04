using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (PlateGloves), typeof (RangerGloves), typeof (RingmailGloves), typeof (StuddedGloves),
        typeof (WoodlandGauntlets),
        typeof (BoneGloves), typeof (DaemonBoneGloves), typeof (DragonGloves), typeof (HideGloves), typeof (LeafGloves),
        typeof (LeatherNinjaMitts),
        typeof (LeatherGloves), typeof (FemaleGargishClothKilt), typeof (GargishClothKilt),
        typeof (FemaleGargishLeatherKilt), typeof (GargishLeatherKilt),
        typeof (FemaleGargishPlatemailKilt), typeof (GargishPlatemailKilt), typeof (FemaleGargishStoneKilt),
        typeof (GargishStoneKilt),
        typeof(TurtleBracers))]
    public class BaseGloves : BaseArmor
    {
        public BaseGloves(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Gloves; }
        }
    }

    [QuerySearch(new ushort[] {0x1414, 0x1418})]
    public class PlateGloves : BaseGloves
    {
        public PlateGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x13d5, 0x13dd})]
    public class RangerGloves : BaseGloves
    {
        public RangerGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x13eb, 0x13f2})]
    public class RingmailGloves : BaseGloves
    {
        public RingmailGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Ringmail; }
        }
    }

    [QuerySearch(new ushort[] {0x13d5, 0x13dd})]
    public class StuddedGloves : BaseGloves
    {
        public StuddedGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x3161, 0x2B6A})]
    public class WoodlandGauntlets : BaseGloves
    {
        public WoodlandGauntlets(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Wood; }
        }
    }

    [QuerySearch(new ushort[] {0x1450, 0x1455})]
    public class BoneGloves : BaseGloves
    {
        public BoneGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x1450, 0x1455})]
    public class DaemonBoneGloves : BaseGloves
    {
        public DaemonBoneGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x2643, 0x2644})]
    public class DragonGloves : BaseGloves
    {
        public DragonGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Scale; }
        }
    }

    [QuerySearch(new ushort[] {0x2B75, 0x316C})]
    public class HideGloves : BaseGloves
    {
        public HideGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x317C, 0x2fc6})]
    public class LeafGloves : BaseGloves
    {
        public LeafGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x2792, 0x27DD})]
    public class LeatherNinjaMitts : BaseGloves
    {
        public LeatherNinjaMitts(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x13C6, 0x13CE })]
    public class LeatherGloves : BaseGloves
    {
        public LeatherGloves(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x782E })]
    public class TurtleBracers : BaseGloves
    {
        public TurtleBracers(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x4063})]
    public class FemaleGargishClothKilt : BaseGloves
    {
        public FemaleGargishClothKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x4064})]
    public class GargishClothKilt : BaseGloves
    {
        public GargishClothKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x404B})]
    public class FemaleGargishLeatherKilt : BaseGloves
    {
        public FemaleGargishLeatherKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x404C})]
    public class GargishLeatherKilt : BaseGloves
    {
        public GargishLeatherKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x4053, 0x030B})]
    public class FemaleGargishPlatemailKilt : BaseGloves
    {
        public FemaleGargishPlatemailKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x4054, 0x030C})]
    public class GargishPlatemailKilt : BaseGloves
    {
        public GargishPlatemailKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x405B, 0x0287})]
    public class FemaleGargishStoneKilt : BaseGloves
    {
        public FemaleGargishStoneKilt(Serial serial)
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

    [QuerySearch(new ushort[] {0x405C, 0x0288})]
    public class GargishStoneKilt : BaseGloves
    {
        public GargishStoneKilt(Serial serial)
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
}