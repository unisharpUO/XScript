using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (BoneLegs), typeof (LeatherLegs), typeof (StuddedLegs), typeof (ChainmailLegs),
        typeof (DragonLegs),
        typeof (RingmailLegs), typeof (WoodlandLegs), typeof (DaemonBoneLegs), typeof (HideLegs), typeof (PlateSuneate),
        typeof (LeafLegs), typeof (PlateLegs), typeof (PlateHaidate), typeof (RangerLegs),
        typeof (FemaleGargishClothLegs),
        typeof (GargishClothLegs), typeof (FemaleGargishLeatherLegs), typeof (GargishLeatherLegs),
        typeof (FemaleGargishPlateLegs),
        typeof (GargishPlateLegs), typeof (FemaleGargishStoneLegs), typeof (GargishStoneLegs), typeof (LeatherShorts),
        typeof (LeatherSkirt), typeof(TurtlePants),
        typeof(TigerLongSkirt), typeof(TigerShortSkirt), typeof(TigerLongPants), typeof(TigerShortPants),
        typeof(LeatherNinjaPants))]
    public class BaseLegs : BaseArmor
    {
        public BaseLegs(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.OuterLegs; }
        }
    }
    
    [QuerySearch(new ushort[] { 0x1452, 0x1457 })]
    public class BoneLegs : BaseLegs
    {
        public BoneLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] { 0x2787 })]
    public class StuddedSuneate : BaseLegs
    {
        public StuddedSuneate(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] { 0x7824 })]
    public class TigerLongPants : BaseLegs
    {
        public TigerLongPants(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x7825 })]
    public class TigerShortPants : BaseLegs
    {
        public TigerShortPants(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x7826 })]
    public class TigerLongSkirt : BaseLegs
    {
        public TigerLongSkirt(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x7827 })]
    public class TigerShortSkirt : BaseLegs
    {
        public TigerShortSkirt(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x13cb, 0x13d2})]
    public class LeatherLegs : BaseLegs
    {
        public LeatherLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }


    [QuerySearch(new ushort[] {0x13da, 0x13e1})]
    public class StuddedLegs : BaseLegs
    {
        public StuddedLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x13be, 0x13c3})]
    public class ChainmailLegs : BaseLegs
    {
        public ChainmailLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Chainmail; }
        }
    }

    [QuerySearch(new ushort[] {0x2647, 0x2648})]
    public class DragonLegs : BaseLegs
    {
        public DragonLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Scale; }
        }
    }

    [QuerySearch(new ushort[] {0x13f0, 0x13f1})]
    public class RingmailLegs : BaseLegs
    {
        public RingmailLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Ringmail; }
        }
    }

    [QuerySearch(new ushort[] {0x3162, 0x2B6B})]
    public class WoodlandLegs : BaseLegs
    {
        public WoodlandLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Wood; }
        }
    }

    [QuerySearch(new ushort[] {0x1452, 0x1457})]
    public class DaemonBoneLegs : BaseLegs
    {
        public DaemonBoneLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x2B78, 0x316F})]
    public class HideLegs : BaseLegs
    {
        public HideLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x27D3, 0x2788})]
    public class PlateSuneate : BaseLegs
    {
        public PlateSuneate(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x2FC9, 0x317F})]
    public class LeafLegs : BaseLegs
    {
        public LeafLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1C00, 0x1C01})]
    public class LeatherShorts : BaseLegs
    {
        public LeatherShorts(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1C08, 0x1C09})]
    public class LeatherSkirt : BaseLegs
    {
        public LeatherSkirt(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1411, 0x141a})]
    public class PlateLegs : BaseLegs
    {
        public PlateLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x27D8, 0x278D})]
    public class PlateHaidate : BaseLegs
    {
        public PlateHaidate(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] { 0x13da, 0x13e1 })]
    public class RangerLegs : BaseLegs
    {
        public RangerLegs(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] { 0x782C })]
    public class TurtlePants : BaseLegs
    {
        public TurtlePants(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x4065})]
    public class FemaleGargishClothLegs : BaseLegs
    {
        public FemaleGargishClothLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x4066})]
    public class GargishClothLegs : BaseLegs
    {
        public GargishClothLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x404D, 0x0305})]
    public class FemaleGargishLeatherLegs : BaseLegs
    {
        public FemaleGargishLeatherLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x404E, 0x0306})]
    public class GargishLeatherLegs : BaseLegs
    {
        public GargishLeatherLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x4055, 0x030D})]
    public class FemaleGargishPlateLegs : BaseLegs
    {
        public FemaleGargishPlateLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x4056, 0x030E})]
    public class GargishPlateLegs : BaseLegs
    {
        public GargishPlateLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x405D, 0x0289})]
    public class FemaleGargishStoneLegs : BaseLegs
    {
        public FemaleGargishStoneLegs(Serial serial)
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

    [QuerySearch(new ushort[] {0x405E, 0x028A})]
    public class GargishStoneLegs : BaseLegs
    {
        public GargishStoneLegs(Serial serial)
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

    [QuerySearch(new ushort[] { 0x2791 })]
    public class LeatherNinjaPants : BaseLegs
    {
        public LeatherNinjaPants(Serial serial)
            : base(serial)
        { }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }
}