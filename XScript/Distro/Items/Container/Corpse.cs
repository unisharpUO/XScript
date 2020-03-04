using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x2006})]
    public class Corpse : BaseContainer
    {
        public Corpse(Serial serial)
            : base(serial)
        {
        }
    }
}