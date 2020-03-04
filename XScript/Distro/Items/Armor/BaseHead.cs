using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (DragonHelm), typeof (Circlet), typeof (ElvenGlasses), typeof (GemmedCirclet), typeof (RavenHelm),
        typeof (VultureHelm), typeof (WingedHelm), typeof (GargishGlasses), typeof (SmallPlateJingasa),
        typeof (LightPlateJingasa),
        typeof (HeavyPlateJingasa), typeof (LeatherNinjaHood), typeof (LeatherJingasa), typeof (Bascinet),
        typeof (BoneHelm),
        typeof (ChainCoif), typeof (CloseHelm), typeof (DaemonHelm), typeof (Helmet), typeof (LeatherCap),
        typeof (NorseHelm),
        typeof (OrcHelm), typeof (PlateHelm), typeof (DeerMask), typeof (BearMask), typeof (TribalMask),
        typeof (TribalFaceMask),
        typeof (Skullcap), typeof (Bandana), typeof (FloppyHat), typeof (WideBrimHat), typeof (Cap),
        typeof (TallStrawHat),
        typeof (StrawHat), typeof (WizardsHat), typeof (Bonnet), typeof (FeatheredHat), typeof (TricorneHat),
        typeof (JesterHat),
        typeof (OrcMask), typeof (GargishEarrings),
        typeof(TigerHelm), typeof(TurtleHelm))]
    public class BaseHead : BaseArmor
    {
        public BaseHead(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.OuterLegs; }
        }
    }

    [QuerySearch(new ushort[] {0x2645, 0x2646})]
    public class DragonHelm : BaseHead
    {
        public DragonHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Scale; }
        }
    }

    [QuerySearch(new ushort[] {0x2B6E})]
    public class Circlet : BaseHead
    {
        public Circlet(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2FB8})]
    public class ElvenGlasses : BaseHead
    {
        public ElvenGlasses(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2B70})]
    public class GemmedCirclet : BaseHead
    {
        public GemmedCirclet(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2B71, 0X3168})]
    public class RavenHelm : BaseHead
    {
        public RavenHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Wood; }
        }
    }

    [QuerySearch(new ushort[] {0x2B72, 0X3169})]
    public class VultureHelm : BaseHead
    {
        public VultureHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x2B73, 0X316A})]
    public class WingedHelm : BaseHead
    {
        public WingedHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x4644})]
    public class GargishGlasses : BaseHead
    {
        public GargishGlasses(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2784})]
    public class SmallPlateJingasa : BaseHead
    {
        public SmallPlateJingasa(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x2781})]
    public class LightPlateJingasa : BaseHead
    {
        public LightPlateJingasa(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x2777})]
    public class HeavyPlateJingasa : BaseHead
    {
        public HeavyPlateJingasa(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x278E})]
    public class LeatherNinjaHood : BaseHead
    {
        public LeatherNinjaHood(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x2776})]
    public class LeatherJingasa : BaseHead
    {
        public LeatherJingasa(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x140C, 0x140D})]
    public class Bascinet : BaseHead
    {
        public Bascinet(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1451, 0x1456})]
    public class BoneHelm : BaseHead
    {
        public BoneHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x13BB, 0x13C0})]
    public class ChainCoif : BaseHead
    {
        public ChainCoif(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Chainmail; }
        }
    }

    [QuerySearch(new ushort[] {0x1408, 0x1409})]
    public class CloseHelm : BaseHead
    {
        public CloseHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1451, 0x1456})]
    public class DaemonHelm : BaseHead
    {
        public DaemonHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Bone; }
        }
    }

    [QuerySearch(new ushort[] {0x140A, 0x140B})]
    public class Helmet : BaseHead
    {
        public Helmet(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1db9, 0x1dba})]
    public class LeatherCap : BaseHead
    {
        public LeatherCap(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x140E, 0x140F})]
    public class NorseHelm : BaseHead
    {
        public NorseHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1F0B, 0x1F0C})]
    public class OrcHelm : BaseHead
    {
        public OrcHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1412, 0x1419})]
    public class PlateHelm : BaseHead
    {
        public PlateHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1547, 0x1548})]
    public class DeerMask : BaseHead
    {
        public DeerMask(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1545, 0x1546})]
    public class BearMask : BaseHead
    {
        public BearMask(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1549, 0x154A})]
    public class TribalMask : BaseHead
    {
        public TribalMask(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x154B, 0x154C})]
    public class TribalFaceMask : BaseHead
    {
        public TribalFaceMask(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] {0x1543, 0x1544})]
    public class Skullcap : BaseHead
    {
        public Skullcap(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x153F, 0x1540})]
    public class Bandana : BaseHead
    {
        public Bandana(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1713})]
    public class FloppyHat : BaseHead
    {
        public FloppyHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1714})]
    public class WideBrimHat : BaseHead
    {
        public WideBrimHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1715})]
    public class Cap : BaseHead
    {
        public Cap(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1716})]
    public class TallStrawHat : BaseHead
    {
        public TallStrawHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1717})]
    public class StrawHat : BaseHead
    {
        public StrawHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1718})]
    public class WizardsHat : BaseHead
    {
        public WizardsHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x1719})]
    public class Bonnet : BaseHead
    {
        public Bonnet(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x171A})]
    public class FeatheredHat : BaseHead
    {
        public FeatheredHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x171B})]
    public class TricorneHat : BaseHead
    {
        public TricorneHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] {0x171C})]
    public class JesterHat : BaseHead
    {
        public JesterHat(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }
    }

    [QuerySearch(new ushort[] { 0x141B, 0x141C })]
    public class OrcMask : BaseHead
    {
        public OrcMask(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x7828 })]
    public class TigerHelm : BaseHead
    {
        public TigerHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Leather; }
        }
    }

    [QuerySearch(new ushort[] { 0x782D })]
    public class TurtleHelm : BaseHead
    {
        public TurtleHelm(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Studded; }
        }
    }
}