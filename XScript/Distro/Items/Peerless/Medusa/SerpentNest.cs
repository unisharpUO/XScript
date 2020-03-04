using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x2233})]
    public class SerpentNest : Item
    {
        public SerpentNest(Serial serial)
            : base(serial)
        {
        }
    }
}