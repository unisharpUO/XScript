using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(0x103F, 0x73E, 1079999)]
    public class CocoaLiquor : SpecialFood
    {
        public CocoaLiquor(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x2FD6, 0x73E, 1079998)]
    public class CocoaButter : SpecialFood
    {
        public CocoaButter(Serial serial)
            : base(serial)
        {
        }
    }
}