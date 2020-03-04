using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Boomerang), typeof (Cyclone), typeof (SoulGlaive))]
    public class BaseThrowing : BaseMeleeWeapon
    {
        public BaseThrowing(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Throwing; }
        }
    }

    [QuerySearch(new ushort[] {0x4067})]
    public class Boomerang : BaseThrowing
    {
        public Boomerang(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.MysticArc; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.ConcussionBlow; }
        }
    }

    [QuerySearch(new ushort[] {0x406C})]
    public class Cyclone : BaseThrowing
    {
        public Cyclone(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.MovingShot; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.InfusedThrow; }
        }
    }

    [QuerySearch(new ushort[] {0x406B})]
    public class SoulGlaive : BaseThrowing
    {
        public SoulGlaive(Serial serial)
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
}