using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;
using XScript.Attributes;
using XScript.Enumerations;
using XScript.Extensions;
using XScript.Interfaces;

namespace XScript.Items
{
    [QueryType(typeof (BaseNecklace), typeof (BaseRing), typeof (BaseEarring), typeof (BaseBracelet))]
    public class BaseJewel : Item, IJewel
    {
        public BaseJewel(uint ObjectID) : base(ObjectID)
        {
        }

        public BaseJewel(Serial serial) : base(serial)
        {
        }

        #region Properties

        public CraftResource CraftResource
        {
            get { return this.ReadCraftResource(Properties); }
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

        public AbsorptionAttributes AbsorptionAttributes
        {
            get { return new AbsorptionAttributes(this, Properties); }
        }

        public ArmorAttributes ArmorAttributes
        {
            get { return new ArmorAttributes(this, Properties); }
        }

        public LootValue LootValue
        {
            get { return this.ReadLootValue(Properties); }
        }

        public int ArtifactRarity
        {
            get { return this.ReadArtifactRarity(Properties); }
        }

        public bool Exceptional
        {
            get { return this.ReadIsExceptionalState(Properties); }
        }

        public string Crafter
        {
            get { return this.ReadCrafterName(Properties); }
        }

        public int HitPoints
        {
            get { return this.ReadDurability(Properties)[0]; }
        }

        public int MaxHitPoints
        {
            get { return this.ReadDurability(Properties)[1]; }
        }

        public bool Brittle
        {
            get { return this.ReadBrittleState(Properties); }
        }
        
        public bool Antique
        {
            get { return this.ReadAntiqueState(Properties); }
        }

        public bool Cursed
        {
            get { return this.ReadCursedState(Properties); }
        }

        public bool CannotBeRepaired
        {
            get { return this.ReadCannotRepairedState(Properties); }
        }

        public string EngravedText
        {
            get { return this.ReadEngraveable(Properties); }
        }

        public bool IsFactionItem
        {
            get { return this.ReadFactionItemState(Properties); }
        }

        public bool Imbued
        {
            get { return this.ReadImbueState(Properties); }
        }

        public bool IsAltered
        {
            get { return this.ReadAlteringState(Properties); }
        }

        #endregion

        #region Virtual Properties

        public virtual bool CanFortify
        {
            get { return !Imbued; }
        }

        public virtual bool AllowMaleWearer
        {
            get { return true; }
        }

        public virtual bool AllowFemaleWearer
        {
            get { return true; }
        }

        public virtual bool CanLoseDurability
        {
            get { return HitPoints >= 0 && MaxHitPoints > 0; }
        }

        public virtual Layer BodyPosition
        {
            get { return Layer.Invalid; }
        }

        public ItemValue ItemValue { get { return this.GetItemValue(); } }

        public virtual bool Meditable
        {
            get { return (MaterialType.ReadMediableState(Properties) || ArmorAttributes.MageArmor); }
        }

        public virtual ArmorMaterialType MaterialType
        {
            get { return ArmorMaterialType.Cloth; }
        }

        #endregion
    }
}