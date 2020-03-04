using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QuerySearch(0x1B73)]
    public class Buckler : BaseShield
    {
        public Buckler(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x1B72)]
    public class BronzeShield : BaseShield
    {
        public BronzeShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x1BC3)]
    public class ChaosShield : BaseShield
    {
        public ChaosShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1BC4, 0x1BC5})]
    public class OrderShield : BaseShield
    {
        public OrderShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x1B7B)]
    public class MetalShield : BaseShield
    {
        public MetalShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1B74, 0x1B75})]
    public class MetalKiteShield : BaseShield
    {
        public MetalKiteShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1B79, 0x1B78})]
    public class WoodenKiteShield : BaseShield
    {
        public WoodenKiteShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(new ushort[] {0x1B76, 0x1B77})]
    public class HeaterShield : BaseShield
    {
        public HeaterShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }

    [QuerySearch(0x1B7A)]
    public class WoodenShield : BaseShield
    {
        public WoodenShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }
    }
}