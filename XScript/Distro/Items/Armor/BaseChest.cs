using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (PlateChest), typeof (PlateDo), typeof (RangerChest), typeof (RingmailChest),
        typeof (FemaleStuddedChest),
        typeof (StuddedBustier), typeof (StuddedChest), typeof (StuddedDo), typeof (WoodlandChest), typeof (LeatherDo),
        typeof (LeatherNinjaJacket),
        typeof (FemalePlateChest), typeof (BoneChest), typeof (ChainChest), typeof (FemaleGargishClothChest),
        typeof (GargishClothChest),
        typeof (DaemonChest), typeof (DragonChest), typeof (FemaleGargishLeatherChest), typeof (GargishLeatherChest),
        typeof (FemaleGargishPlatemailChest),
        typeof (GargishPlatemailChest), typeof (FemaleGargishStoneChest), typeof (GargishStoneChest),
        typeof (HideFemaleChest),
        typeof (HideTunic), typeof (FemaleLeafTunic), typeof (LeafTunic), typeof (FemaleLeatherChest),
        typeof (LeatherBustier), typeof (LeatherChest),
        typeof(TigerChest), typeof(TigerFemaleChest), typeof(TurtleChest), typeof(TurtleFemaleChest))]
    public class BaseChest : BaseArmor
    {
        public BaseChest(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.MiddleTorso; }
        }
    }

    [QuerySearch(new ushort[] {0x1415, 0x1416})]
    public class PlateChest : BaseChest
    {
        public PlateChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x27C8, 0x277D})]
    public class PlateDo : BaseChest
    {
        public PlateDo(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x13db, 0x13e2})]
    public class RangerChest : BaseChest
    {
        public RangerChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x13ec, 0x13ed})]
    public class RingmailChest : BaseChest
    {
        public RingmailChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Ringmail; }
        }
    }

    [QuerySearch(new ushort[] {0x1c02, 0x1c03})]
    public class FemaleStuddedChest : BaseChest
    {
        public FemaleStuddedChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x1c0c, 0x1c0d})]
    public class StuddedBustier : BaseChest
    {
        public StuddedBustier(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x13db, 0x13e2})]
    public class StuddedChest : BaseChest
    {
        public StuddedChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x27C7, 0x277C})]
    public class StuddedDo : BaseChest
    {
        public StuddedDo(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x315E, 0x2B67})]
    public class WoodlandChest : BaseChest
    {
        public WoodlandChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Wood; }
        }
    }

    [QuerySearch(new ushort[] {0x27C6, 0x277B})]
    public class LeatherDo : BaseChest
    {
        public LeatherDo(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x2793, 0x27DE})]
    public class LeatherNinjaJacket : BaseChest
    {
        public LeatherNinjaJacket(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1c04, 0x1c05})]
    public class FemalePlateChest : BaseChest
    {
        public FemalePlateChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x144f, 0x1454})]
    public class BoneChest : BaseChest
    {
        public BoneChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x13bf, 0x13c4})]
    public class ChainChest : BaseChest
    {
        public ChainChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Chainmail; }
        }
    }

    [QuerySearch(new ushort[] {0x4061})]
    public class FemaleGargishClothChest : BaseChest
    {
        public FemaleGargishClothChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x4062})]
    public class GargishClothChest : BaseChest
    {
        public GargishClothChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x144f, 0x1454})]
    public class DaemonChest : BaseChest
    {
        public DaemonChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x2641, 0x2642})]
    public class DragonChest : BaseChest
    {
        public DragonChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Scale; }
        }
    }

    [QuerySearch(new ushort[] {0x4049, 0x0303})]
    public class FemaleGargishLeatherChest : BaseChest
    {
        public FemaleGargishLeatherChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x404A, 0x0304})]
    public class GargishLeatherChest : BaseChest
    {
        public GargishLeatherChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x4051, 0x0309})]
    public class FemaleGargishPlatemailChest : BaseChest
    {
        public FemaleGargishPlatemailChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x4052, 0x030A})]
    public class GargishPlatemailChest : BaseChest
    {
        public GargishPlatemailChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x4059, 0x0285})]
    public class FemaleGargishStoneChest : BaseChest
    {
        public FemaleGargishStoneChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x405A, 0x0286})]
    public class GargishStoneChest : BaseChest
    {
        public GargishStoneChest(Serial serial)
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

    [QuerySearch(new ushort[] {0x2B79, 0x3170})]
    public class HideFemaleChest : BaseChest
    {
        public HideFemaleChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x316B, 0x2B74})]
    public class HideTunic : BaseChest
    {
        public HideTunic(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] {0x2FCB, 0x3181})]
    public class FemaleLeafTunic : BaseChest
    {
        public FemaleLeafTunic(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x317B})]
    public class LeafTunic : BaseChest
    {
        public LeafTunic(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1c06, 0x1c07})]
    public class FemaleLeatherChest : BaseChest
    {
        public FemaleLeatherChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1c0a, 0x1c0b})]
    public class LeatherBustier : BaseChest
    {
        public LeatherBustier(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x13cc, 0x13d3 })]
    public class LeatherChest : BaseChest
    {
        public LeatherChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x7822 })]
    public class TigerChest : BaseChest
    {
        public TigerChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x7823 })]
    public class TigerFemaleChest : BaseChest
    {
        public TigerFemaleChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x782A })]
    public class TurtleChest : BaseChest
    {
        public TurtleChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }

    [QuerySearch(new ushort[] { 0x782B })]
    public class TurtleFemaleChest : BaseChest
    {
        public TurtleFemaleChest(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }
}




