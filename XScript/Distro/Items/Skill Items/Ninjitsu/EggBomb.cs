using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x2808})]
    public class EggBomb : BaseSmokeBomb
    {
        public EggBomb(Serial serial)
            : base(serial)
        {
        }
    }
}