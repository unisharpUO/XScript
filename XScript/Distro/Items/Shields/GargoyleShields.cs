using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QuerySearch(0x4229)]
    public class GargishChaosShield : BaseShield
    {
        public GargishChaosShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x4201)]
    public class GargishKiteShield : BaseShield
    {
        public GargishKiteShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x422C)]
    public class GargishOrderShield : BaseShield
    {
        public GargishOrderShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x4200, 0x4207})]
    public class GargishWoodenShield : BaseShield
    {
        public GargishWoodenShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x4204)]
    public class LargePlateShield : BaseShield
    {
        public LargePlateShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x420B, 0x4205})]
    public class LargeStoneShield : BaseShield
    {
        public LargeStoneShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x4203)]
    public class MediumPlateShield : BaseShield
    {
        public MediumPlateShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x4202)]
    public class SmallPlateShield : BaseShield
    {
        public SmallPlateShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }
}