using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (LesserCurePotion), typeof (CurePotion), typeof (GreaterCurePotion))]
    public class BaseCurePotion : BasePotion
    {
        public BaseCurePotion(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x0F07})]
    public class LesserCurePotion : BaseCurePotion
    {
        public LesserCurePotion(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x0F07})]
    public class CurePotion : BaseCurePotion
    {
        public CurePotion(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x0F07})]
    public class GreaterCurePotion : BaseCurePotion
    {
        public GreaterCurePotion(Serial serial)
            : base(serial)
        {
        }
    }
}