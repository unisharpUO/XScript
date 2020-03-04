using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (HumanShield), typeof (GargoyleShield))]
    public class BaseShield : BaseArmor
    {
        public BaseShield(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }

        public override Layer BodyPosition
        {
            get { return Layer.TwoHanded; }
        }
    }

    [QueryType(typeof (Buckler), typeof (BronzeShield), typeof (ChaosShield), typeof (OrderShield), typeof (MetalShield),
        typeof (MetalKiteShield), typeof (WoodenKiteShield), typeof (HeaterShield), typeof (WoodenShield))]
    public class HumanShield : BaseShield
    {
        public HumanShield(Serial serial) : base(serial)
        {
        }
    }

    [QueryType(typeof (GargishChaosShield), typeof (GargishKiteShield), typeof (GargishOrderShield),
        typeof (GargishWoodenShield), typeof (LargePlateShield), typeof (LargeStoneShield), typeof (MediumPlateShield),
        typeof (SmallPlateShield))]
    public class GargoyleShield : BaseShield
    {
        public GargoyleShield(Serial serial) : base(serial)
        {
        }
    }
}