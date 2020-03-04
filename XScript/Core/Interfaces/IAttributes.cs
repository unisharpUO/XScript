using XScript.Attributes;
using XScript.Enumerations;

namespace XScript.Interfaces
{
    public interface IResistances
    {
        ElementAttributes Resistances { get; }
    }

    public interface IMagicalItem
    {
        MagicalAttributes Attributes { get; }
    }

    public interface ISkillBonuses
    {
        SkillBonuses SkillBonuses { get; }
    }

    public interface IAbsorption
    {
        AbsorptionAttributes AbsorptionAttributes { get; }
    }

    public interface IFactionItem
    {
        bool IsFactionItem { get; }
    }

    public interface IEngraveable
    {
        string EngravedText { get; }
    }

    public interface ICraftable
    {
        bool Exceptional { get; }
        string Crafter { get; }
    }

    public interface ISetItem
    {
    }

    public interface IDyeable
    {
    }

    public interface IScissorable
    {
    }

    public interface ICommodity
    {
    }

    public interface IDurability
    {
        bool CanLoseDurability { get; }
        int HitPoints { get; }
        int MaxHitPoints { get; }
        bool Brittle { get; }
        bool Antique { get; }
        bool Cursed { get; }
        bool CannotBeRepaired { get; }
    }

    public interface IDecorateable
    {
        string DecorationMessage { get; }
    }

    public interface IImbueable
    {
        bool Imbued { get; }
    }

    public interface IHasQuantity
    {
        double FillState { get; }
    }

    public interface IWaterSource : IHasQuantity
    {
    }

    public interface IArcaneEquip
    {
        bool IsArcane { get; }
        int CurArcaneCharges { get; }
        int MaxArcaneCharges { get; }
    }

    public interface ISlayer
    {
        SlayerName Slayer { get; }
        SlayerName Slayer2 { get; }
    }

    public interface IGorgonCharges
    {
        int GorgonCharges { get; }
    }

    public interface IAlterable
    {
        bool IsAltered { get; }
    }

    public interface ICookable
    {
    }

    public interface IPoisonable
    {
        PoisonLevel Poison { get; }
    }

    public interface IUsesRemaining
    {
        int Uses { get; }
    }

    public interface ICraftResource
    {
        CraftResource CraftResource { get; }
    }

    public interface ILootValue
    {
        LootValue LootValue { get; }
    }
}