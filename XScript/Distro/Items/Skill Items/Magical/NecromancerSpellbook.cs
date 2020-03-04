using ScriptSDK;
using ScriptSDK.Data;

namespace Server.Items
{
    [QuerySearch(0x2253)]
	public class NecromancerSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Necromancer; } }

        public NecromancerSpellbook(uint objectID) : base(objectID)
        {
        }

        public NecromancerSpellbook(Serial serial) : base(serial)
        {
        }
	}
}
