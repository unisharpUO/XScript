using ScriptSDK;
using ScriptSDK.Data;
using XScript.Enumerations;

namespace XScript.Items
{
    [QueryType(typeof (HumanEarring), typeof (GargishEarrings))]
    public class BaseEarring : BaseJewel
    {
        public BaseEarring(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Earrings; }
        }
    }

    [QuerySearch(new ushort[] {0x1087, 0x1F07})]
    public class HumanEarring : BaseEarring
    {
        public HumanEarring(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x4213)]
    public class GargishEarrings : BaseArmor
    {
        public GargishEarrings(Serial serial)
            : base(serial)
        {
        }

        public override ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Plate; }
        }

        public override Layer BodyPosition
        {
            get { return Layer.Earrings; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }
}