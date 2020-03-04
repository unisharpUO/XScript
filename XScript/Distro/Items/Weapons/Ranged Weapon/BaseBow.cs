using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Bow), typeof (CompositeBow), typeof (Crossbow), typeof (HeavyCrossbow),
        typeof (RepeatingCrossbow), typeof (Yumi),
        typeof (ElvenCompositeLongBow), typeof (MagicalShortbow))]
    public class BaseBow : BaseMeleeWeapon
    {
        public BaseBow(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Archery; }
        }
    }

    [QuerySearch(new ushort[] {0x13B2, 0x13B1})]
    public class Bow : BaseBow
    {
        public Bow(Serial serial)
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

    [QuerySearch(new ushort[] {0x2D1F, 0x2D2B})]
    public class MagicalShortbow : BaseBow
    {
        public MagicalShortbow(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.LightningArrow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.PsychicAttack; }
        }
    }

    [QuerySearch(new ushort[] {0x26C2, 0x26CC})]
    public class CompositeBow : BaseBow
    {
        public CompositeBow(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorIgnore; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MovingShot; }
        }
    }

    [QuerySearch(new ushort[] {0xF50, 0xF4F})]
    public class Crossbow : BaseBow
    {
        public Crossbow(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x13FD, 0x13FC})]
    public class HeavyCrossbow : BaseBow
    {
        public HeavyCrossbow(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.MovingShot; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }
    }

    public class JukaBow : Bow
    {
        public JukaBow(Serial serial)
            : base(serial)
        {
        }
    }

    public class OrcishBow : Bow
    {
        public OrcishBow(Serial serial)
            : base(serial)
        {
        }
    }

    public class AssassinsShortbow : MagicalShortbow
    {
        public AssassinsShortbow(Serial serial)
            : base(serial)
        {
        }
    }

    public class RangersShortbow : MagicalShortbow
    {
        public RangersShortbow(Serial serial)
            : base(serial)
        {
        }
    }

    public class MysticalShortbow : MagicalShortbow
    {
        public MysticalShortbow(Serial serial)
            : base(serial)
        {
        }
    }

    public class LightweightShortbow : MagicalShortbow
    {
        public LightweightShortbow(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x26C3, 0x26CD})]
    public class RepeatingCrossbow : BaseBow
    {
        public RepeatingCrossbow(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.DoubleStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MovingShot; }
        }
    }

    [QuerySearch(new ushort[] {0x27A5, 0x27F0})]
    public class Yumi : BaseBow
    {
        public Yumi(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ArmorPierce; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.DoubleShot; }
        }
    }

    [QuerySearch(new ushort[] {0x2D1E, 0x2D2A})]
    public class ElvenCompositeLongBow : BaseBow
    {
        public ElvenCompositeLongBow(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ForceArrow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.SerpentArrow; }
        }
    }

    public class BarbedLongbow : ElvenCompositeLongBow
    {
        public BarbedLongbow(Serial serial)
            : base(serial)
        {
        }
    }

    public class FrozenLongbow : ElvenCompositeLongBow
    {
        public FrozenLongbow(Serial serial)
            : base(serial)
        {
        }
    }

    public class LongbowOfMight : ElvenCompositeLongBow
    {
        public LongbowOfMight(Serial serial)
            : base(serial)
        {
        }
    }

    public class SlayerLongbow : ElvenCompositeLongBow
    {
        public SlayerLongbow(Serial serial)
            : base(serial)
        {
        }
    }
}