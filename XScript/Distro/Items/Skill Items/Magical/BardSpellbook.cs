using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x225A)]
	public class BardSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Bard; } }

        public BardSpellbook(uint objectID) : base(objectID)
        {
        }

        public BardSpellbook(Serial serial) : base(serial)
        {
        }
	}
}
