using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (WildStaff), typeof (BlackStaff), typeof (GnarledStaff), typeof (QuarterStaff), typeof (Crook),
        typeof (GargishGnarledStaff),
        typeof (GlassStaff), typeof (SerpentstoneStaff))]
    public class BaseStaff : BaseMeleeWeapon
    {
        public BaseStaff(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Macing; }
        }
    }

    [QuerySearch(new ushort[] {0x2D25, 0x2D31})]
    public class WildStaff : BaseStaff
    {
        public WildStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Block; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ForceOfNature; }
        }
    }

    [QuerySearch(new ushort[] {0x48B9, 0x48B8})]
    public class GargishGnarledStaff : BaseStaff
    {
        public GargishGnarledStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
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

    [QuerySearch(new ushort[] {0x406F})]
    public class SerpentstoneStaff : BaseStaff
    {
        public SerpentstoneStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
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

    [QuerySearch(new ushort[] {0x0905})]
    public class GlassStaff : BaseStaff
    {
        public GlassStaff(Serial serial)
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

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    public class AncientWildStaff : WildStaff
    {
        public AncientWildStaff(Serial serial)
            : base(serial)
        {
        }
    }

    public class ArcanistsWildStaff : WildStaff
    {
        public ArcanistsWildStaff(Serial serial)
            : base(serial)
        {
        }
    }

    public class HardenedWildStaff : WildStaff
    {
        public HardenedWildStaff(Serial serial)
            : base(serial)
        {
        }
    }

    public class ThornedWildStaff : WildStaff
    {
        public ThornedWildStaff(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xDF1, 0xDF0})]
    public class BlackStaff : BaseStaff
    {
        public BlackStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x13F8, 0x13F9})]
    public class GnarledStaff : BaseStaff
    {
        public GnarledStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ParalyzingBlow; }
        }
    }

    [QuerySearch(new ushort[] {0xE89, 0xE8a})]
    public class QuarterStaff : BaseStaff
    {
        public QuarterStaff(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }
    }

    [QuerySearch(new ushort[] {0xE81, 0xE82, 0x13F4, 0x13F5})]
    public class Crook : BaseStaff
    {
        public Crook(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }
    }
}