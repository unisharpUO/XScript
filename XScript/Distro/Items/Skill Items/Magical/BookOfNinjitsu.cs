using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x23A0)]
	public class BookOfNinjitsu : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Ninja; } }

        public BookOfNinjitsu(uint objectID) : base(objectID)
        {
        }

        public BookOfNinjitsu(Serial serial) : base(serial)
        {
        }
	}
}
