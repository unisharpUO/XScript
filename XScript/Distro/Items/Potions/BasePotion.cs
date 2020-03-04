using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QueryType(typeof (BaseCurePotion))]
    public class BasePotion : Item
    {
        public BasePotion(Serial serial)
            : base(serial)
        {
        }
    }
}