using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (ButcherKnife), typeof (Cleaver), typeof (Dagger), typeof (GargishDagger), typeof (SkinningKnife),
        typeof (Leafblade), typeof (GargishButcherKnife), typeof (GargishCleaver), typeof (GargishTekagi), typeof (Kama),
        typeof (Tekagi), typeof (Sai), typeof (Lajatang))]
    public class BaseKnife : BaseMeleeWeapon
    {
        public BaseKnife(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Fencing; }
        }
    }

    [QuerySearch(new ushort[] {0x27AD, 0x27F8})]
    public class Kama : BaseKnife
    {
        public Kama(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.DefenseMastery; }
        }
    }

    [QuerySearch(new ushort[] {0x27A7, 0x27F2})]
    public class Lajatang : BaseKnife
    {
        public Lajatang(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DefenseMastery; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.FrenziedWhirlwind; }
        }
    }

    [QuerySearch(new ushort[] {0x27Ab, 0x27F6})]
    public class Tekagi : BaseKnife
    {
        public Tekagi(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DualWield; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.TalonStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x27AF, 0x27FA})]
    public class Sai : BaseKnife
    {
        public Sai(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Block; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ArmorPierce; }
        }
    }

    [QuerySearch(new ushort[] {0x48CF, 0x48CE})]
    public class GargishTekagi : BaseKnife
    {
        public GargishTekagi(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DualWield; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.TalonStrike; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x2D22, 0x2D2E})]
    public class Leafblade : BaseKnife
    {
        public Leafblade(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Feint; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }
    }

    public class LeafbladeOfEase : Leafblade
    {
        public LeafbladeOfEase(Serial serial)
            : base(serial)
        {
        }
    }

    public class MagekillerLeafblade : Leafblade
    {
        public MagekillerLeafblade(Serial serial)
            : base(serial)
        {
        }
    }

    public class TrueLeafblade : Leafblade
    {
        public TrueLeafblade(Serial serial)
            : base(serial)
        {
        }
    }

    public class Luckblade : Leafblade
    {
        public Luckblade(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x13F6, 0x13F7})]
    public class ButcherKnife : BaseKnife
    {
        public ButcherKnife(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }
    }

    [QuerySearch(new ushort[] {0x48B7, 0x48B6})]
    public class GargishButcherKnife : BaseKnife
    {
        public GargishButcherKnife(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0xEC3, 0xEC2})]
    public class Cleaver : BaseKnife
    {
        public Cleaver(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }
    }

    [QuerySearch(new ushort[] {0x48AF, 0x48AE})]
    public class GargishCleaver : BaseKnife
    {
        public GargishCleaver(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0xF52, 0xF51})]
    public class Dagger : BaseKnife
    {
        public Dagger(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x902, 0x406A})]
    public class GargishDagger : BaseKnife
    {
        public GargishDagger(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }
    }

    [QuerySearch(new ushort[] {0xEC4, 0xEC5})]
    public class SkinningKnife : BaseKnife
    {
        public SkinningKnife(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }
    }
}