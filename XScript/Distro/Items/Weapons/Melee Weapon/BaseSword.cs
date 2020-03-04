using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (BoneHarvester), typeof (Broadsword), typeof (CrescentBlade), typeof (Cutlass), typeof (Katana),
        typeof (Kryss),
        typeof (Lance), typeof (Longsword), typeof (Scimitar), typeof (VikingSword), typeof (ElvenMachete),
        typeof (ElvenSpellBlade),
        typeof (RadiantScimitar), typeof (RuneBlade), typeof (WarCleaver), typeof (Bloodblade), typeof (DreadSword),
        typeof (GargishBoneHarvester),
        typeof (GargishDaisho), typeof (GargishKatana), typeof (GargishKryss), typeof (GargishLance),
        typeof (GargishTalwar), typeof (GlassSword),
        typeof (Shortblade), typeof (StoneWarSword), typeof (Bokuto), typeof (Wakizashi), typeof (Daisho),
        typeof (NoDachi))]
    public class BaseSword : BaseMeleeWeapon
    {
        public BaseSword(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }
    }

    [QuerySearch(new ushort[] {0x4072})]
    public class Bloodblade : BaseSword
    {
        public Bloodblade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x27A8, 0x27F3})]
    public class Bokuto : BaseSword
    {
        public Bokuto(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Feint; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.NerveStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x27A4, 0x27EF})]
    public class Wakizashi : BaseSword
    {
        public Wakizashi(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.FrenziedWhirlwind; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x27A9, 0x27F4})]
    public class Daisho : BaseSword
    {
        public Daisho(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Feint; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x27A2, 0x27ED})]
    public class NoDachi : BaseSword
    {
        public NoDachi(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.RidingSwipe; }
        }
    }

    [QuerySearch(new ushort[] {0x4076})]
    public class Shortblade : BaseSword
    {
        public Shortblade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4071})]
    public class StoneWarSword : BaseSword
    {
        public StoneWarSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x090C, 0x4073})]
    public class GlassSword : BaseSword
    {
        public GlassSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x4075})]
    public class GargishTalwar : BaseSword
    {
        public GargishTalwar(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x48BB, 0x48BA})]
    public class GargishKatana : BaseSword
    {
        public GargishKatana(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x48BD, 0x48BC})]
    public class GargishKryss : BaseSword
    {
        public GargishKryss(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Fencing; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x48D1, 0x48D0})]
    public class GargishDaisho : BaseSword
    {
        public GargishDaisho(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Feint; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x090B})]
    public class DreadSword : BaseSword
    {
        public DreadSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x2D23, 0x2D2F})]
    public class WarCleaver : BaseSword
    {
        public WarCleaver(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Bladeweave; }
        }
    }

    [QuerySearch(new ushort[] {0x48C7, 0x48C6})]
    public class GargishBoneHarvester : BaseSword
    {
        public GargishBoneHarvester(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    public class ButchersWarCleaver : WarCleaver
    {
        public ButchersWarCleaver(Serial serial)
            : base(serial)
        {
        }
    }

    public class KnightsWarCleaver : WarCleaver
    {
        public KnightsWarCleaver(Serial serial)
            : base(serial)
        {
        }
    }

    public class SerratedWarCleaver : WarCleaver
    {
        public SerratedWarCleaver(Serial serial)
            : base(serial)
        {
        }
    }

    public class TrueWarCleaver : WarCleaver
    {
        public TrueWarCleaver(Serial serial)
            : base(serial)
        {
        }
    }

    public class AdventurersMachete : ElvenMachete
    {
        public AdventurersMachete(Serial serial)
            : base(serial)
        {
        }
    }

    public class BoneMachete : ElvenMachete
    {
        public BoneMachete(Serial serial)
            : base(serial)
        {
        }
    }

    public class DiseasedMachete : ElvenMachete
    {
        public DiseasedMachete(Serial serial)
            : base(serial)
        {
        }
    }

    public class MacheteOfDefense : ElvenMachete
    {
        public MacheteOfDefense(Serial serial)
            : base(serial)
        {
        }
    }

    public class OrcishMachete : ElvenMachete
    {
        public OrcishMachete(Serial serial)
            : base(serial)
        {
        }
    }

    public class CorruptedRuneBlade : RuneBlade
    {
        public CorruptedRuneBlade(Serial serial)
            : base(serial)
        {
        }
    }

    public class MagesRuneBlade : RuneBlade
    {
        public MagesRuneBlade(Serial serial)
            : base(serial)
        {
        }
    }

    public class RuneBladeOfKnowledge : RuneBlade
    {
        public RuneBladeOfKnowledge(Serial serial)
            : base(serial)
        {
        }
    }

    public class Runesabre : RuneBlade
    {
        public Runesabre(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2D26, 0x2D32})]
    public class RuneBlade : BaseSword
    {
        public RuneBlade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Bladeweave; }
        }
    }

    [QuerySearch(new ushort[] {0x2D27, 0x2D33})]
    public class RadiantScimitar : BaseSword
    {
        public RadiantScimitar(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Bladeweave; }
        }
    }

    public class DarkglowScimitar : RadiantScimitar
    {
        public DarkglowScimitar(Serial serial)
            : base(serial)
        {
        }
    }

    public class IcyScimitar : RadiantScimitar
    {
        public IcyScimitar(Serial serial)
            : base(serial)
        {
        }
    }

    public class TrueRadiantScimitar : RadiantScimitar
    {
        public TrueRadiantScimitar(Serial serial)
            : base(serial)
        {
        }
    }

    public class TwinklingScimitar : RadiantScimitar
    {
        public TwinklingScimitar(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2D20, 0x2D2C})]
    public class ElvenSpellBlade : BaseSword
    {
        public ElvenSpellBlade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.PsychicAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }
    }

    public class FierySpellblade : ElvenSpellBlade
    {
        public FierySpellblade(Serial serial)
            : base(serial)
        {
        }
    }

    public class IcySpellblade : ElvenSpellBlade
    {
        public IcySpellblade(Serial serial)
            : base(serial)
        {
        }
    }

    public class SpellbladeOfDefense : ElvenSpellBlade
    {
        public SpellbladeOfDefense(Serial serial)
            : base(serial)
        {
        }
    }

    public class TrueSpellblade : ElvenSpellBlade
    {
        public TrueSpellblade(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2D29, 0x2D35})]
    public class ElvenMachete : BaseSword
    {
        public ElvenMachete(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Bladeweave; }
        }
    }

    [QuerySearch(new ushort[] {0x26BB, 0x26C5})]
    public class BoneHarvester : BaseSword
    {
        public BoneHarvester(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }
    }

    [QuerySearch(new ushort[] {0xF5E, 0xF5F})]
    public class Broadsword : BaseSword
    {
        public Broadsword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }
    }

    [QuerySearch(new ushort[] {0x26C1, 0x26CB})]
    public class CrescentBlade : BaseSword
    {
        public CrescentBlade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x1441, 0x1440})]
    public class Cutlass : BaseSword
    {
        public Cutlass(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x13FF, 0x13FE})]
    public class Katana : BaseSword
    {
        public Katana(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }
    }

    [QuerySearch(new ushort[] {0x1401, 0x1400})]
    public class Kryss : BaseSword
    {
        public Kryss(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Fencing; }
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x26C0, 0x26CA})]
    public class Lance : BaseSword
    {
        public Lance(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x48CB, 0x48CA})]
    public class GargishLance : BaseSword
    {
        public GargishLance(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0xF61, 0xF60})]
    public class Longsword : BaseSword
    {
        public Longsword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x13B6, 0x13B5})]
    public class Scimitar : BaseSword
    {
        public Scimitar(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x13B9, 0x13BA})]
    public class VikingSword : BaseSword
    {
        public VikingSword(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }
    }
}