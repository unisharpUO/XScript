using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (HumanNecklace))]
    public class BaseNecklace : BaseJewel
    {
        public BaseNecklace(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Neck; }
        }
    }

    [QuerySearch(new ushort[] {0x1085, 0x1088, 0x1089, 0x1F08, 0x1F05})]
    public class HumanNecklace : BaseNecklace
    {
        public HumanNecklace(Serial serial)
            : base(serial)
        {
        }
    }
}