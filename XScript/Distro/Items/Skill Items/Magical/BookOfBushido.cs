using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x238C)]
    public class BookOfBushido : Spellbook
    {
        public override SpellbookType SpellbookType { get { return SpellbookType.Samurai; } }

        public BookOfBushido(uint objectID)
            : base(objectID)
        {
        }

        public BookOfBushido(Serial serial)
            : base(serial)
        {
        }
    }
}
