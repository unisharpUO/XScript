using System.ComponentModel;

namespace XScript.Enumerations
{
    public enum BeverageType
    {
        Ale,
        Cider,
        Liquor,
        Milk,
        Wine,
        Water,
        Champagne,
        Gluhwein,
        Eggnog,
        Unknown
    }

    public enum CraftResource
    {
        Default = 0,
        DullCopper = 1053108,
        ShadowIron = 1053107,
        Copper = 1053106,
        Bronze = 1053105,
        Gold = 1053104,
        Agapite = 1053103,
        Verite = 1053102,
        Valorite = 1053101,
        SpinedLeather = 1061118,
        HornedLeather = 1061117,
        BarbedLeather = 1061116,
        RedScales = 1060814,
        YellowScales = 1060818,
        BlackScales = 1060820,
        GreenScales = 1060819,
        WhiteScales = 1060821,
        BlueScales = 1060815,
        Oak = 1072533,
        Ash = 1072534,
        Yew = 1072535,
        Heartwood = 1072536,
        Bloodwood = 1072538,
        Frostwood = 1072539
    }

    public enum ArmorMaterialType
    {
        Cloth,
        Leather,
        Studded,
        Bone,
        Ringmail,
        Chainmail,
        Plate,
        Scale,
        Wood,
        Stone
    }

    public enum SlayerName
    {
        None = 0,
        Undead = 1060479,
        Orc = 1060470,
        Troll = 1060480,
        Ogre = 1060468,
        Repond = 1060472,
        Dragon = 1060462,
        Terathan = 1060478,
        Snake = 1060475,
        Lizardman = 1060467,
        Reptile = 1060473,
        Gargoyle = 1060466,
        Demon = 1060461,
        Ophidian = 1060469,
        Spider = 1060477,
        Scorpion = 1060474,
        Arachnid = 1060458,
        FireElemental = 1060465,
        WaterElemental = 1060481,
        AirElemental = 1060457,
        PoisonElemental = 1060471,
        EarthElemental = 1060463,
        BloodElemental = 1060459,
        SnowElemental = 1060476,
        Elemental = 1060464,
        Fey = 1070855
    }

    public enum PoisonLevel
    {
        None = 0,
        Lesser = 1062412,
        Standard = 1062413,
        Greater = 1062414,
        Deadly = 1062415,
        Lethal = 1062416,
        Parasitic = 1072853,
        Darkglow = 1072853
    }

    public enum LootValue
    {
        None,
        MinorMagic = 1151488,
        LesserMagic = 1151489,
        GreaterMagic = 1151490,
        MajorMagic = 1151491,
        LesserArtifact = 1151492,
        GreaterArtifact = 1151493,
        MajorArtifact = 1151494,
        LegendaryArtifact = 1151495
    }

    [DefaultValue(None)]
    public enum ItemValue
    {
        None,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Event,
        OOAK,
        Artifact,
        Donation,
        ITSArtifact,
        Newbie,
        SetItem
    }
}