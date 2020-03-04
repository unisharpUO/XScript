using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Axe), typeof (BattleAxe), typeof (DoubleAxe), typeof (Hatchet), typeof (LargeBattleAxe),
        typeof (Pickaxe), typeof (TwoHandedAxe), typeof (WarAxe),
        typeof (OrnateAxe), typeof (DualShortAxes), typeof (GargishAxe), typeof (GargishBattleAxe),
        typeof (ExecutionersAxe))]
    public class BaseAxe : BaseMeleeWeapon
    {
        public BaseAxe(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Swords; }
        }
    }

    [QuerySearch(new ushort[] {0x2D28, 0x2D34})]
    public class OrnateAxe : BaseAxe
    {
        public OrnateAxe(Serial serial)
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

    [QuerySearch(new ushort[] {0x4068})]
    public class DualShortAxes : BaseAxe
    {
        public DualShortAxes(Serial serial)
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

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x48B3})]
    public class GargishAxe : BaseAxe
    {
        public GargishAxe(Serial serial)
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

    [QuerySearch(new ushort[] {0x48B1, 0x48B0})]
    public class GargishBattleAxe : BaseAxe
    {
        public GargishBattleAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
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

    public class GuardianAxe : OrnateAxe
    {
        public GuardianAxe(Serial serial)
            : base(serial)
        {
        }
    }

    public class HeavyOrnateAxe : OrnateAxe
    {
        public HeavyOrnateAxe(Serial serial)
            : base(serial)
        {
        }
    }

    public class SingingAxe : OrnateAxe
    {
        public SingingAxe(Serial serial)
            : base(serial)
        {
        }
    }

    public class ThunderingAxe : OrnateAxe
    {
        public ThunderingAxe(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xF49, 0xF4A})]
    public class Axe : BaseAxe
    {
        public Axe(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0xF47, 0xF48})]
    public class BattleAxe : BaseAxe
    {
        public BattleAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }
    }

    [QuerySearch(new ushort[] {0xf4b, 0xf4c})]
    public class DoubleAxe : BaseAxe
    {
        public DoubleAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }
    }

    [QuerySearch(new ushort[] {0xf45, 0xf46})]
    public class ExecutionersAxe : BaseAxe
    {
        public ExecutionersAxe(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0xF43, 0xF44})]
    public class Hatchet : BaseAxe
    {
        public Hatchet(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }
    }

    [QuerySearch(new ushort[] {0x13FB, 0x13FA})]
    public class LargeBattleAxe : BaseAxe
    {
        public LargeBattleAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }
    }

    [QuerySearch(new ushort[] {0xE86, 0xE85})]
    public class Pickaxe : BaseAxe
    {
        public Pickaxe(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0x1443, 0x1442})]
    public class TwoHandedAxe : BaseAxe
    {
        public TwoHandedAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x13B0, 0x13AF})]
    public class WarAxe : BaseAxe
    {
        public WarAxe(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }
    }
}