using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x2252)]
	public class BookOfChivalry : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Paladin; } }

        public BookOfChivalry(uint objectID) : base(objectID)
        {
        }

        public BookOfChivalry(Serial serial) : base(serial)
        {
        }
	}
}
