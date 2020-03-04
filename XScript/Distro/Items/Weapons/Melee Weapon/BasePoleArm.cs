using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Bardiche), typeof (Halberd), typeof (Scythe), typeof (BladedStaff), typeof (DoubleBladedStaff),
        typeof (GargishBardiche),
        typeof (GargishScythe))]
    public class BasePoleArm : BaseMeleeWeapon
    {
        public BasePoleArm(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }
    }

    [QuerySearch(new ushort[] {0xF4D, 0xF4E})]
    public class Bardiche : BasePoleArm
    {
        public Bardiche(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }
    }

    [QuerySearch(new ushort[] {0x48B5, 0x48B4})]
    public class GargishBardiche : BasePoleArm
    {
        public GargishBardiche(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
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

    [QuerySearch(new ushort[] {0x48C5, 0x48C4})]
    public class GargishScythe : BasePoleArm
    {
        public GargishScythe(Serial serial)
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

    [QuerySearch(new ushort[] {0x143E, 0x143F})]
    public class Halberd : BasePoleArm
    {
        public Halberd(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x26BA, 0x26C4})]
    public class Scythe : BasePoleArm
    {
        public Scythe(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0x26BD, 0x26C7})]
    public class BladedStaff : BasePoleArm
    {
        public BladedStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }
    }

    [QuerySearch(new ushort[] {0x26BF, 0x26C9})]
    public class DoubleBladedStaff : BasePoleArm
    {
        public DoubleBladedStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }
    }
}