using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;
using XScript.Attributes;
using XScript.Enumerations;
using XScript.Extensions;
using XScript.Interfaces;

namespace XScript.Items
{
    public enum WeaponAbility
    {
        ArmorIgnore,
        BleedAttack,
        ConcussionBlow,
        CrushingBlow,
        Disarm,
        Dismount,
        DoubleStrike,
        InfectiousStrike,
        MortalStrike,
        MovingShot,
        ParalyzingBlow,
        ShadowStrike,
        WhirlwindAttack,
        RidingSwipe,
        FrenziedWhirlwind,
        Block,
        DefenseMastery,
        NerveStrike,
        TalonStrike,
        Feint,
        DualWield,
        DoubleShot,
        ArmorPierce,
        Bladeweave,
        ForceArrow,
        LightningArrow,
        PsychicAttack,
        SerpentArrow,
        ForceOfNature,
        InfusedThrow,
        MysticArc,
        None
    }

    [QueryType(typeof (BaseMeleeWeapon), typeof (BaseRangedWeapon))]
    public class BaseWeapon : Item, IWeapon
    {
        public BaseWeapon(uint ObjectID) : base(ObjectID)
        {
        }

        public BaseWeapon(Serial serial) : base(serial)
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

        public WeaponAttributes WeaponAttributes
        {
            get { return new WeaponAttributes(this, Properties); }
        }

        public WeaponDamageAttributes WeaponDamageElements
        {
            get { return new WeaponDamageAttributes(this, Properties); }
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

        public SlayerName Slayer
        {
            get { return this.GetSlayer(Properties); }
        }

        public SlayerName Slayer2
        {
            get { return this.GetSlayer(Properties); }
        }


        public bool Immolated
        {
            get { return this.ReadImmolation(Properties); }
        }

        public bool Enchanted
        {
            get { return this.ReadEnchantment(Properties); }
        }

        public int LowerStrRequirement
        {
            get { return this.ReadLowerStrRequirement(Properties); }
        }

        public int DamageMin
        {
            get { return this.ReadWeaponDamage(Properties)[0]; }
        }

        public int DamageMax
        {
            get { return this.ReadWeaponDamage(Properties)[1]; }
        }

        public double WeaponSpeed
        {
            get { return this.ReadWeaponSpeed(Properties); }
        }

        public int LowerStatRequirement
        {
            get { return this.ReadLowerStatRequirement(Properties); }
        }

        #endregion

        #region Virtual Properties
        
        public virtual SkillName RequiredSkill
        {
            get { return this.ReadSkillRequirements(Properties); }
        }

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
            get { return this.ReadHandingType(Properties); }
        }

        public ItemValue ItemValue { get { return this.GetItemValue(); } }

        public virtual WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.None; }
        }

        public virtual WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.None; }
        }

        #endregion
    }
}