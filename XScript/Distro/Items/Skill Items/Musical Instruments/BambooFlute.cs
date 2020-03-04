using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x2805, 0x504, 0x503})]
    public class BambooFlute : Item
    {
        public BambooFlute(Serial serial)
            : base(serial)
        {
        }
    }
}