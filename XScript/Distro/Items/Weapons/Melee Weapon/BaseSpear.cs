using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Pike), typeof (ShortSpear), typeof (Spear), typeof (TribalSpear), typeof (AssassinSpike), typeof(GargishPike),
        typeof(DualPointedSpear))]
    public class BaseSpear : BaseMeleeWeapon
    {
        public BaseSpear(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Fencing; }
        }
    }

    [QuerySearch(new ushort[] {0x2D21, 0x2D2D})]
    public class AssassinSpike : BaseSpear
    {
        public AssassinSpike(Serial serial)
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

    [QuerySearch(new ushort[] {0x406D})]
    public class DualPointedSpear : BaseSpear
    {
        public DualPointedSpear(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x48C9, 0x48C8})]
    public class GargishPike : BaseSpear
    {
        public GargishPike(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    public class ChargedAssassinSpike : AssassinSpike
    {
        public ChargedAssassinSpike(Serial serial)
            : base(serial)
        {
        }
    }

    public class MagekillerAssassinSpike : AssassinSpike
    {
        public MagekillerAssassinSpike(Serial serial)
            : base(serial)
        {
        }
    }

    public class TrueAssassinSpike : AssassinSpike
    {
        public TrueAssassinSpike(Serial serial)
            : base(serial)
        {
        }
    }

    public class WoundingAssassinSpike : AssassinSpike
    {
        public WoundingAssassinSpike(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x26BE, 0x26C8})]
    public class Pike : BaseSpear
    {
        public Pike(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfectiousStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x1403, 0x1402})]
    public class ShortSpear : BaseSpear
    {
        public ShortSpear(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }
    }

    [QuerySearch(new ushort[] {0xF62, 0xF63})]
    public class Spear : BaseSpear
    {
        public Spear(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0xF62, 0xF63})]
    public class TribalSpear : BaseSpear
    {
        public TribalSpear(Serial serial)
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
    }
}