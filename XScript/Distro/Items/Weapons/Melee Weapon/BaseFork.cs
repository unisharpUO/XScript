using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (Pitchfork), typeof (WarFork), typeof (GargishWarFork))]
    public class BaseFork : BaseMeleeWeapon
    {
        public BaseFork(Serial serial)
            : base(serial)
        {
        }

        public override SkillName RequiredSkill
        {
            get { return SkillName.Fencing; }
        }
    }

    [QuerySearch(new ushort[] {0xE87, 0xE88})]
    public class Pitchfork : BaseFork
    {
        public Pitchfork(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Dismount; }
        }
    }

    [QuerySearch(new ushort[] {0x1405, 0x1404})]
    public class WarFork : BaseFork
    {
        public WarFork(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
        }

        public override WeaponAbility SecondaryAbility
        {
            get { return WeaponAbility.Disarm; }
        }
    }

    [QuerySearch(new ushort[] {0x48BF, 0x48BE})]
    public class GargishWarFork : BaseFork
    {
        public GargishWarFork(Serial serial)
            : base(serial)
        {
        }

        public override WeaponAbility PrimaryAbility
        {
            get { return WeaponAbility.BleedAttack; }
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
}