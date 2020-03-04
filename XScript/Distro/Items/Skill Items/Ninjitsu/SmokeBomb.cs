using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x2808})]
    public class SmokeBomb : BaseSmokeBomb
    {
        public SmokeBomb(Serial serial)
            : base(serial)
        {
        }
    }
}