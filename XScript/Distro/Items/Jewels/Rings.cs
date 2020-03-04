using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (HumanRing), typeof (GargishRing))]
    public class BaseRing : BaseJewel
    {
        public BaseRing(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Ring; }
        }
    }

    [QuerySearch(new ushort[] {0x108A, 0x1F09})]
    public class HumanRing : BaseRing
    {
        public HumanRing(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x4212)]
    public class GargishRing : BaseRing
    {
        public GargishRing(Serial serial)
            : base(serial)
        {
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }
}