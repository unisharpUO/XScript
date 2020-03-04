using System;
using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;

namespace XScript.Attributes
{
    public enum WeaponAttribute
    {
        LowerStatReq = 0x00000001,
        SelfRepair = 0x00000002,
        HitLeechHits = 0x00000004,
        HitLeechStam = 0x00000008,
        HitLeechMana = 0x00000010,
        HitLowerAttack = 0x00000020,
        HitLowerDefend = 0x00000040,
        HitMagicArrow = 0x00000080,
        HitHarm = 0x00000100,
        HitFireball = 0x00000200,
        HitLightning = 0x00000400,
        HitDispel = 0x00000800,
        HitColdArea = 0x00001000,
        HitFireArea = 0x00002000,
        HitPoisonArea = 0x00004000,
        HitEnergyArea = 0x00008000,
        HitPhysicalArea = 0x00010000,
        HitCurse = 0x00020000,
        HitFatigue = 0x00040000,
        HitManaDrain = 0x00080000,
        SplinteringWeapon = 0x00100000,
        BattleLust = 0x00200000,
        UseBestSkill = 0x00400000,
        MageWeapon = 0x00800000,
        DurabilityBonus = 0x01000000,
        FireDamagePercent = 0x02000000,
        ColdDamagePercent = 0x04000000,
        PoisonDamagePercent = 0x08000000,
        EnergyDamagePercent = 0x10000000,
        Velocity = 0x20000000,
        Balanced = 0x40000000,
        BloodDrinker = unchecked((int) 0x80000000)
    }

    public sealed class WeaponAttributes : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            var x = Enum.GetValues(typeof (WeaponAttribute));
            foreach (var e in x)
            {
                _data.Add((WeaponAttribute) e, 0);
            }

            this[WeaponAttribute.BloodDrinker] = (ClilocHelper.Contains(_lastmetatable, 1113591));
            this[WeaponAttribute.BattleLust] = (ClilocHelper.Contains(_lastmetatable, 1113710));
            this[WeaponAttribute.Balanced] = (ClilocHelper.Contains(_lastmetatable, 1072792));
            this[WeaponAttribute.Velocity] = (ClilocHelper.Contains(_lastmetatable, 1072793))
                ? ClilocHelper.GetParams(_lastmetatable, 1072793)[0]
                : 0;
            this[WeaponAttribute.UseBestSkill] = (ClilocHelper.Contains(_lastmetatable, 1060400));
            this[WeaponAttribute.HitColdArea] = (ClilocHelper.Contains(_lastmetatable, 1060416))
                ? ClilocHelper.GetParams(_lastmetatable, 1060416)[0]
                : 0;
            this[WeaponAttribute.HitDispel] = (ClilocHelper.Contains(_lastmetatable, 1060417))
                ? ClilocHelper.GetParams(_lastmetatable, 1060417)[0]
                : 0;
            this[WeaponAttribute.HitEnergyArea] = (ClilocHelper.Contains(_lastmetatable, 1060418))
                ? ClilocHelper.GetParams(_lastmetatable, 1060418)[0]
                : 0;
            this[WeaponAttribute.HitFireArea] = (ClilocHelper.Contains(_lastmetatable, 1060419))
                ? ClilocHelper.GetParams(_lastmetatable, 1060419)[0]
                : 0;
            this[WeaponAttribute.HitFireball] = (ClilocHelper.Contains(_lastmetatable, 1060420))
                ? ClilocHelper.GetParams(_lastmetatable, 1060420)[0]
                : 0;
            this[WeaponAttribute.HitHarm] = (ClilocHelper.Contains(_lastmetatable, 1060421))
                ? ClilocHelper.GetParams(_lastmetatable, 1060421)[0]
                : 0;
            this[WeaponAttribute.HitCurse] = (ClilocHelper.Contains(_lastmetatable, 1113712))
                ? ClilocHelper.GetParams(_lastmetatable, 1113712)[0]
                : 0;
            this[WeaponAttribute.HitFatigue] = (ClilocHelper.Contains(_lastmetatable, 1113700))
                ? ClilocHelper.GetParams(_lastmetatable, 1113700)[0]
                : 0;
            this[WeaponAttribute.HitManaDrain] = (ClilocHelper.Contains(_lastmetatable, 1113699))
                ? ClilocHelper.GetParams(_lastmetatable, 1113699)[0]
                : 0;
            this[WeaponAttribute.SplinteringWeapon] = (ClilocHelper.Contains(_lastmetatable, 1112857))
                ? ClilocHelper.GetParams(_lastmetatable, 1112857)[0]
                : 0;
            this[WeaponAttribute.HitLeechHits] = (ClilocHelper.Contains(_lastmetatable, 1060422))
                ? ClilocHelper.GetParams(_lastmetatable, 1060422)[0]
                : 0;
            this[WeaponAttribute.HitLightning] = (ClilocHelper.Contains(_lastmetatable, 1060423))
                ? ClilocHelper.GetParams(_lastmetatable, 1060423)[0]
                : 0;
            this[WeaponAttribute.HitLowerAttack] = (ClilocHelper.Contains(_lastmetatable, 1060424))
                ? ClilocHelper.GetParams(_lastmetatable, 1060424)[0]
                : 0;
            this[WeaponAttribute.HitLowerDefend] = (ClilocHelper.Contains(_lastmetatable, 1060425))
                ? ClilocHelper.GetParams(_lastmetatable, 1060425)[0]
                : 0;
            this[WeaponAttribute.HitMagicArrow] = (ClilocHelper.Contains(_lastmetatable, 1060426))
                ? ClilocHelper.GetParams(_lastmetatable, 1060426)[0]
                : 0;
            this[WeaponAttribute.HitLeechMana] = (ClilocHelper.Contains(_lastmetatable, 1060427))
                ? ClilocHelper.GetParams(_lastmetatable, 1060427)[0]
                : 0;
            this[WeaponAttribute.HitPhysicalArea] = (ClilocHelper.Contains(_lastmetatable, 1060428))
                ? ClilocHelper.GetParams(_lastmetatable, 1060428)[0]
                : 0;
            this[WeaponAttribute.HitPoisonArea] = (ClilocHelper.Contains(_lastmetatable, 1060429))
                ? ClilocHelper.GetParams(_lastmetatable, 1060429)[0]
                : 0;
            this[WeaponAttribute.HitLeechStam] = (ClilocHelper.Contains(_lastmetatable, 1060430))
                ? ClilocHelper.GetParams(_lastmetatable, 1060430)[0]
                : 0;
            this[WeaponAttribute.MageWeapon] = (ClilocHelper.Contains(_lastmetatable, 1060438))
                ? ClilocHelper.GetParams(_lastmetatable, 1060438)[0]
                : 0;
            this[WeaponAttribute.SelfRepair] = (ClilocHelper.Contains(_lastmetatable, 1060450))
                ? ClilocHelper.GetParams(_lastmetatable, 1060450)[0]
                : 0;


            //this[ArmorAttribute.SelfRepair] = (ClilocHelper.GetIndex(_lastmetatable, 1060450) > -1)? ClilocHelper.GetParams(_lastmetatable, 1060450)[0]: 0;

            base.Parse();
        }

        #endregion

        #region Constructors

        public WeaponAttributes(UOEntity owner, List<ClilocItemRec> reader)
            : base(owner, reader)
        {
        }

        public WeaponAttributes(UOEntity owner)
            : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public int LowerStatReq
        {
            get { return this[WeaponAttribute.LowerStatReq]; }
        }

        public int SelfRepair
        {
            get { return this[WeaponAttribute.SelfRepair]; }
        }

        public int HitLeechHits
        {
            get { return this[WeaponAttribute.HitLeechHits]; }
        }

        public int HitLeechStam
        {
            get { return this[WeaponAttribute.HitLeechStam]; }
        }

        public int HitLeechMana
        {
            get { return this[WeaponAttribute.HitLeechMana]; }
        }

        public int HitLowerAttack
        {
            get { return this[WeaponAttribute.HitLowerAttack]; }
        }

        public int HitLowerDefend
        {
            get { return this[WeaponAttribute.HitLowerDefend]; }
        }

        public int HitMagicArrow
        {
            get { return this[WeaponAttribute.HitMagicArrow]; }
        }

        public int HitHarm
        {
            get { return this[WeaponAttribute.HitHarm]; }
        }

        public int HitFireball
        {
            get { return this[WeaponAttribute.HitFireball]; }
        }

        public int HitLightning
        {
            get { return this[WeaponAttribute.HitLightning]; }
        }

        public int HitDispel
        {
            get { return this[WeaponAttribute.HitDispel]; }
        }

        public int HitColdArea
        {
            get { return this[WeaponAttribute.HitColdArea]; }
        }

        public int HitFireArea
        {
            get { return this[WeaponAttribute.HitFireArea]; }
        }

        public int HitPoisonArea
        {
            get { return this[WeaponAttribute.HitPoisonArea]; }
        }

        public int HitEnergyArea
        {
            get { return this[WeaponAttribute.HitEnergyArea]; }
        }

        public int HitPhysicalArea
        {
            get { return this[WeaponAttribute.HitPhysicalArea]; }
        }

        public int HitCurse
        {
            get { return this[WeaponAttribute.HitCurse]; }
        }

        public int HitFatigue
        {
            get { return this[WeaponAttribute.HitFatigue]; }
        }

        public int HitManaDrain
        {
            get { return this[WeaponAttribute.HitManaDrain]; }
        }

        public int SplinteringWeapon
        {
            get { return this[WeaponAttribute.SplinteringWeapon]; }
        }

        public bool BattleLust
        {
            get { return this[WeaponAttribute.BattleLust]; }
        }

        public bool UseBestSkill
        {
            get { return this[WeaponAttribute.UseBestSkill]; }
        }

        public int MageWeapon
        {
            get { return this[WeaponAttribute.MageWeapon]; }
        }

        public int DurabilityBonus
        {
            get { return this[WeaponAttribute.DurabilityBonus]; }
        }

        public int DamageFirePercent
        {
            get { return this[WeaponAttribute.FireDamagePercent]; }
        }

        public int DamageColdPercent
        {
            get { return this[WeaponAttribute.ColdDamagePercent]; }
        }

        public int DamagePoisonPercent
        {
            get { return this[WeaponAttribute.PoisonDamagePercent]; }
        }

        public int DamageEnergyPercent
        {
            get { return this[WeaponAttribute.EnergyDamagePercent]; }
        }

        public int Velocity
        {
            get { return this[WeaponAttribute.Velocity]; }
        }

        public bool Balanced
        {
            get { return this[WeaponAttribute.Balanced]; }
        }

        public bool BloodDrinker
        {
            get { return this[WeaponAttribute.BloodDrinker]; }
        }

        #endregion
    }
}