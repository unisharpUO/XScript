using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (HumanBracelet), typeof (GargishBrace))]
    public class BaseBracelet : BaseJewel
    {
        public BaseBracelet(Serial serial)
            : base(serial)
        {
        }

        public override Layer BodyPosition
        {
            get { return Layer.Bracelet; }
        }
    }

    [QuerySearch(new ushort[] {0x1086, 0x1F06})]
    public class HumanBracelet : BaseBracelet
    {
        public HumanBracelet(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x4211)]
    public class GargishBrace : BaseBracelet
    {
        public GargishBrace(Serial serial)
            : base(serial)
        {
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }
}