using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x2D9D)]
	public class MysticismSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Mystic; } }

        public MysticismSpellbook(uint objectID) : base(objectID)
        {
        }

        public MysticismSpellbook(Serial serial) : base(serial)
        {
        }
	}
}
