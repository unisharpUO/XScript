using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Engines;
using ScriptSDK.Items;
using XScript.Attributes;
using XScript.Enumerations;
using XScript.Extensions;
using XScript.Interfaces;

namespace Server.Items
{
    public enum SpellbookType
    {
        Invalid = -1,
        Regular,
        Necromancer,
        Paladin,
        Ninja,
        Samurai,
        Arcanist,
        Mystic,
        Bard
    }

    public interface ISpellbook
    {
        int Spells { get; }
    }

    [QuerySearch(0xEFA)]
    public class Spellbook : Item, ICraftable, ISlayer, IMagicalItem, ISkillBonuses, IEngraveable
    {
        public virtual SpellbookType SpellbookType { get { return SpellbookType.Regular; } }

        public override bool WearableByGargoyles { get { return true; } }

        public virtual Layer BodyPosition
        {
            get { return Layer.OneHanded; }
        }

        public Spellbook(uint objectID) : base(objectID)
        {
            //Layer = Layer.OneHanded;
            //LootType = LootType.Blessed;
        }

        public Spellbook(Serial serial)
            : base(serial)
        {
        }


        public bool Exceptional
        {
            get { return this.ReadIsExceptionalState(Properties); }
        }

        public string Crafter
        {
            get { return this.ReadCrafterName(Properties); }
        }

        public string EngravedText
        {
            get { return this.ReadEngraveable(Properties); }
        }

        public virtual SlayerName Slayer
        {
            get { return this.GetSlayer(Properties); }
        }

        public virtual SlayerName Slayer2
        {
            get { return this.GetSlayer(Properties, 2); }
        }

        public virtual int Spells
        {
            get { return this.GetSpellCount(); }
        }

        public MagicalAttributes Attributes
        {
            get { return new MagicalAttributes(this, Properties); }
        }

        public ElementAttributes Resistances
        {
            get { return new ElementAttributes(this, Properties); }
        }

        public SkillBonuses SkillBonuses
        {
            get { return new SkillBonuses(this, Properties); }
        }
    }

    public static class SpellbookExtensions
    {
        public static int GetSpellCount(this Spellbook sb)
        {
            return ClilocHelper.Contains(sb.Properties, 1042886) ? ClilocHelper.GetParams(sb.Properties, 1042886)[0] : 0;
        }
    }
}