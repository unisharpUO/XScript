using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(0xE2A, 0x1C1)]
    public class Vanilla : Spices
    {
        public Vanilla(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1039, 0x83F)]
    public class SackOfSugar : Spices
    {
        public SackOfSugar(Serial serial)
            : base(serial)
        {
        }
    }
}