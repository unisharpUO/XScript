using ScriptSDK.Data;
using XScript.Items;

namespace XScript.Interfaces
{
    [QueryType(typeof (BoneLegs), typeof (BoneGloves), typeof (BoneChest), typeof (BoneArms), typeof (BoneHelm))]
    public interface IBoneArmor
    {
    }

    [QueryType(typeof (LeatherLegs), typeof (FemaleGargishLeatherLegs), typeof (GargishLeatherLegs),
        typeof (LeatherGloves), typeof (LeatherDo),
        typeof (LeatherNinjaJacket), typeof (FemaleGargishLeatherChest), typeof (GargishLeatherChest),
        typeof (FemaleLeatherChest),
        typeof (LeatherBustier), typeof (LeatherChest), typeof (FemaleGargishLeatherArms), typeof (GargishLeatherArms),
        typeof (LeatherHiroSode),
        typeof (LeafArms), typeof (LeatherArms), typeof (LeafGorget), typeof (LeatherGorget),
        typeof (FemaleGargishLeatherKilt), typeof (GargishLeatherKilt),
        typeof (LeatherNinjaHood), typeof (LeatherJingasa), typeof (LeatherCap), typeof (OrcHelm), typeof (DeerMask),
        typeof (BearMask),
        typeof (TribalMask), typeof (TribalFaceMask), typeof (OrcMask), typeof (OrcHelm), typeof (LeatherShorts),
        typeof (LeatherSkirt))]
    public interface ILeatherArmor
    {
    }

    [QueryType(typeof (StuddedLegs), typeof (StuddedGloves), typeof (FemaleStuddedChest), typeof (StuddedBustier),
        typeof (StuddedChest),
        typeof (StuddedDo), typeof (StuddedArms), typeof (StuddedHiroSode), typeof (HidePauldrons),
        typeof (StuddedGorget))]
    public interface IStuddedArmor
    {
    }

    [QueryType(typeof (ChainmailLegs), typeof (ChainChest), typeof (ChainCoif))]
    public interface IChainmailArmor
    {
    }

    [QueryType(typeof (DragonLegs), typeof (DragonGloves), typeof (DragonChest), typeof (DragonArms),
        typeof (DragonHelm))]
    public interface IDragonArmor
    {
    }

    [QueryType(typeof (RingmailLegs), typeof (RingmailGloves), typeof (RingmailChest), typeof (RingmailArms))]
    public interface IRingmailArmor
    {
    }

    [QueryType(typeof (WoodlandLegs), typeof (WoodlandGauntlets), typeof (WoodlandChest), typeof (WoodlandArms),
        typeof (WoodlandGorget),
        typeof (RavenHelm))]
    public interface IWoodlandArmor
    {
    }

    [QueryType(typeof (HideLegs), typeof (WoodlandGauntlets), typeof (HideFemaleChest), typeof (HideTunic),
        typeof (HideGorget))]
    public interface IHideArmor
    {
    }

    [QueryType(typeof (DaemonBoneLegs), typeof (DaemonBoneGloves), typeof (DaemonChest), typeof (DaemonArms),
        typeof (DaemonHelm))]
    public interface IDaemonBoneArmor
    {
    }

    [QueryType(typeof (PlateSuneate), typeof (PlateLegs), typeof (PlateHaidate), typeof (FemaleGargishPlateLegs),
        typeof (GargishPlateLegs), typeof (PlateGloves), typeof (PlateChest), typeof (PlateDo),
        typeof (FemalePlateChest),
        typeof (FemaleGargishPlatemailChest), typeof (GargishPlatemailChest), typeof (FemaleGargishPlatemailArms),
        typeof (GargishPlatemailArms), typeof (PlateArms), typeof (PlateHiroSode), typeof (PlateGorget),
        typeof (FemaleGargishPlatemailKilt),
        typeof (GargishPlatemailKilt), typeof (VultureHelm), typeof (PlateHelm), typeof (WingedHelm),
        typeof (SmallPlateJingasa),
        typeof (LightPlateJingasa), typeof (HeavyPlateJingasa), typeof (Bascinet), typeof (CloseHelm), typeof (Helmet),
        typeof (NorseHelm), typeof (PlateHelm))]
    public interface IPlateArmor
    {
    }

    [QueryType(typeof (LeafLegs), typeof (LeafGloves), typeof (FemaleLeafTunic), typeof (LeafTunic))]
    public interface ILeafArmor
    {
    }

    [QueryType(typeof (RangerLegs), typeof (RangerGloves), typeof (RangerChest), typeof (RangerArms),
        typeof (RangerGorget))]
    public interface IRangerArmor
    {
    }

    [QueryType(typeof (FemaleGargishStoneLegs), typeof (GargishStoneLegs), typeof (FemaleGargishStoneChest),
        typeof (GargishStoneChest),
        typeof (FemaleGargishStoneArms), typeof (GargishStoneArms), typeof (FemaleGargishStoneKilt),
        typeof (GargishStoneKilt))]
    public interface IStoneArmor
    {
    }

    [QueryType(typeof (FemaleGargishClothLegs), typeof (GargishClothLegs), typeof (FemaleGargishClothChest),
        typeof (GargishClothChest),
        typeof (FemaleGargishClothArms), typeof (GargishClothArms), typeof (FemaleGargishClothKilt),
        typeof (GargishClothKilt),
        typeof (Skullcap), typeof (Bandana), typeof (FloppyHat), typeof (WideBrimHat), typeof (Cap),
        typeof (TallStrawHat), typeof (StrawHat),
        typeof (WizardsHat), typeof (Bonnet), typeof (FeatheredHat), typeof (TricorneHat), typeof (JesterHat))]
    public interface IClothArmor
    {
    }
}