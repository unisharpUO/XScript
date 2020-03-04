using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x2D50)]
	public class SpellweavingSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Arcanist; } }

        public SpellweavingSpellbook(uint objectID) : base(objectID)
        {
        }

        public SpellweavingSpellbook(Serial serial) : base(serial)
        {
        }
	}
}
