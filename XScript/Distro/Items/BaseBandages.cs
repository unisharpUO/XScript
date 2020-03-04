using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x0EE9, 0x0E21})]
    public class Bandage : Item
    {
        public Bandage(Serial serial)
            : base(serial)
        {
        }
    }
}