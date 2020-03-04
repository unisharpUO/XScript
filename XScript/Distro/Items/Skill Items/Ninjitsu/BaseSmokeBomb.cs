using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QueryType(typeof (EggBomb), typeof (SmokeBomb))]
    public class BaseSmokeBomb : Item
    {
        public BaseSmokeBomb(Serial serial)
            : base(serial)
        {
        }
    }
}