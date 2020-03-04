using ScriptSDK.Data;
using XScript.Attributes;
using XScript.Enumerations;
using XScript.Items;

namespace XScript.Interfaces
{
    public interface IEquipment : IArtifactRarity, IMagicalItem, IResistances, ISkillBonuses, IFactionItem, IEngraveable,
        ICraftable
    {
        Layer BodyPosition { get; }
        ItemValue ItemValue { get; }
    }

    public interface IArmor : IEquipment, IGorgonCharges, IImbueable, IAbsorption, IDurability, IAlterable,
        ICraftResource, ILootValue
    {
        ArmorAttributes ArmorAttributes { get; }
        ArmorMaterialType MaterialType { get; }
    }

    public interface ISpellBook : IEquipment
    {
    }

    public interface IWeapon : IEquipment, IGorgonCharges, IImbueable, IAbsorption, IDurability, IAlterable, ISlayer,
        ICraftResource, ILootValue
    {
        WeaponAttributes WeaponAttributes { get; }
        WeaponDamageAttributes WeaponDamageElements { get; }
        SkillName RequiredSkill { get; }
        bool Immolated { get; }
        bool Enchanted { get; }
        int LowerStrRequirement { get; }
        int LowerStatRequirement { get; }
        int DamageMin { get; }
        int DamageMax { get; }
        double WeaponSpeed { get; }
        WeaponAbility PrimaryAbility { get; }
        WeaponAbility SecondaryAbility { get; }
    }

    public interface IMeleeWeapon : IWeapon, IPoisonable
    {
    }

    public interface IRangeWeapon : IWeapon
    {
    }

    public interface IJewel : IEquipment, IImbueable, IAbsorption, IDurability, IAlterable, ICraftResource, ILootValue
    {
    }

    public interface IClothing : IArmor, IDyeable, IScissorable
    {
    }

    public interface ITalisman
    {
    }
}