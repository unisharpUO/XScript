using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x41BF})]
    public class RareSerpentEgg : Item
    {
        public RareSerpentEgg(Serial serial)
            : base(serial)
        {
        }
    }
}