using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QuerySearch(new ushort[]
    {
        0x09AB, 0x0E40, 0x0E41, 0x0E42, 0x0E43, 0x0E7C,
        0x2DE9, 0x2DEA, 0x2DF3, 0x2DF4, 0x3098, 0x3099, 0x309A, 0x309B, 0xE75, 0xE79, 0x9AA
    })]
    [QueryType(typeof (Corpse))]
    public class BaseContainer : Container
    {
        public BaseContainer(Serial serial) : base(serial)
        {
        }
    }
}