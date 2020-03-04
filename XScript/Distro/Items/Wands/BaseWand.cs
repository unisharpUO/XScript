using System;
using ScriptSDK;
using ScriptSDK.Data;
using XScript.Extensions;

namespace XScript.Items
{
    public enum WandEffect
    {
        None = 0,
        Clumsiness = 1017326,
        Identification = 1017350,
        Healing = 1017329,
        Feeblemindedness = 1017327,
        Weakness = 1017328,
        MagicArrow = 1060492,
        Harming = 1017334,
        Fireball = 1060487,
        GreaterHealing = 1017330,
        Lightning = 1060491,
        ManaDraining = 1017339
    }

    [QuerySearch(new ushort[] {0xDF2, 0xDF3, 0xDF4, 0xDF5})]
    public class BaseWand : BaseWeapon /*BaseBashing*/
    {
        public BaseWand(Serial serial)
            : base(serial)
        {
        }

        public virtual TimeSpan GetUseDelay
        {
            get { return TimeSpan.FromSeconds(4.0); }
        }

        public override bool WearableByGargoyles
        {
            get { return true; }
        }

        public WandEffect Effect
        {
            get { return this.ReadWandType(Properties); }
        }

        public int Charges
        {
            get { return this.ReadWandCharges(Properties); }
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
}