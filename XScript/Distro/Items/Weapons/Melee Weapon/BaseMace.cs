using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Club), typeof (HammerPick), typeof (Mace), typeof (MagicWand), typeof (Maul), typeof (Scepter),
        typeof (WarHammer),
        typeof (WarMace), typeof (DiamondMace), typeof (DiscMace), typeof (GargishMaul), typeof (GargishTessen),
        typeof (GargishWarHammer),
        typeof (Nunchaku), typeof (Tessen), typeof (Tetsubo), typeof (SledgeHammer), typeof(SmithsHammer))]
    public class BaseMace : BaseMeleeWeapon
    {
        public BaseMace(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Macing; }
        }
    }

    [QuerySearch(new ushort[] {0x48CC, 0x48CD})]
    public class GargishTessen : BaseMace
    {
        public GargishTessen(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Feint; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Block; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0xFB4, 0xFB5})]
    public class SledgeHammer : BaseMace
    {
        public SledgeHammer(Serial serial)
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

    [QuerySearch(new ushort[] {0x48C1, 0x48C0})]
    public class GargishWarHammer : BaseMace
    {
        public GargishWarHammer(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x2D24, 0x2D30})]
    public class DiamondMace : BaseMace
    {
        public DiamondMace(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x27AE, 0x27F9})]
    public class Nunchaku : BaseMace
    {
        public Nunchaku(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Block; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Feint; }
        }
    }

    [QuerySearch(new ushort[] {0x27A3, 0x27EE})]
    public class Tessen : BaseMace
    {
        public Tessen(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Feint; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Block; }
        }
    }

    [QuerySearch(new ushort[] {0x27A6, 0x27F1})]
    public class Tetsubo : BaseMace
    {
        public Tetsubo(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.FrenziedWhirlwind; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x406E})]
    public class DiscMace : BaseMace
    {
        public DiscMace(Serial serial)
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

        public override Race RequiredRace
        {
            get { return Race.Gargoyle; }
        }
    }

    [QuerySearch(new ushort[] {0x48C3, 0x48C2})]
    public class GargishMaul : BaseMace
    {
        public GargishMaul(Serial serial)
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

    [QuerySearch(new ushort[] {0x13b4, 0x13b3})]
    public class Club : BaseMace
    {
        public Club(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ShadowStrike; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }
    }

    [QuerySearch(new ushort[] {0x143D, 0x143C})]
    public class HammerPick : BaseMace
    {
        public HammerPick(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0xF5C, 0xF5D})]
    public class Mace : BaseMace
    {
        public Mace(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }
    }

    public class EmeraldMace : Mace
    {
        public EmeraldMace(Serial serial)
            : base(serial)
        {
        }
    }

    public class RubyMace : Mace
    {
        public RubyMace(Serial serial)
            : base(serial)
        {
        }
    }

    public class SapphireMace : Mace
    {
        public SapphireMace(Serial serial)
            : base(serial)
        {
        }
    }

    public class SilverEtchedMace : Mace
    {
        public SilverEtchedMace(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xDF2})]
    public class MagicWand : BaseMace
    {
        public MagicWand(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }
    }

    [QuerySearch(new ushort[] {0x143B, 0x143A})]
    public class Maul : BaseMace
    {
        public Maul(Serial serial)
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
    }

    [QuerySearch(new ushort[] {0x26BC, 0x26C6})]
    public class Scepter : BaseMace
    {
        public Scepter(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.MortalStrike; }
        }
    }

    [QuerySearch(new ushort[] {0x1439, 0x1438})]
    public class WarHammer : BaseMace
    {
        public WarHammer(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.WhirlwindAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }
    }

    [QuerySearch(new ushort[] { 0x1407, 0x1406 })]
    public class WarMace : BaseMace
    {
        public WarMace(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }
    }

    [QuerySearch(new ushort[] { 0x13E3, 0x13E4 })]
    public class SmithsHammer : BaseMace
    {
        public SmithsHammer(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.CrushingBlow; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }
    }
}