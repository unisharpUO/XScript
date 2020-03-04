using System;
using System.Linq;
using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Engines;
using ScriptSDK.Items;
using XScript.Attributes;
using XScript.Enumerations;
using XScript.Extensions;
using XScript.Interfaces;

namespace XScript.Items
{
    [QueryType(typeof (BaseLegs), typeof (BaseNeck), typeof (BaseArms), typeof (BaseGloves), typeof (BaseChest),
        typeof (BaseHead))]
    public class BaseArmor : Item, IArmor
    {
        #region Constructors

        public BaseArmor(Serial serial)
            : base(serial)
        {
        }

        #endregion

        #region Properties

        public CraftResource CraftResource
        {
            get
            {
                var props = Properties;
                if (ClilocHelper.Contains(props, 1053099))
                {
                    var Value = ClilocHelper.GetParams(props, 1053099)[0];
                    return
                        (from object e in Enum.GetValues(typeof (CraftResource)) where Value.Equals(e) select e)
                            .Cast<CraftResource>().FirstOrDefault();
                }
                return CraftResource.Default;
            }
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

        public int GorgonCharges
        {
            get { return this.ReadGorgonCharges(Properties); }
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