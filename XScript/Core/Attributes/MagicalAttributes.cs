using System;
using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;

namespace XScript.Attributes
{
    public enum MagicalAttribute
    {
        RegenHits = 0x00000001,
        RegenStam = 0x00000002,
        RegenMana = 0x00000004,
        DefendChance = 0x00000008,
        AttackChance = 0x00000010,
        BonusStr = 0x00000020,
        BonusDex = 0x00000040,
        BonusInt = 0x00000080,
        BonusHits = 0x00000100,
        BonusStam = 0x00000200,
        BonusMana = 0x00000400,
        WeaponDamage = 0x00000800,
        WeaponSpeed = 0x00001000,
        SpellDamage = 0x00002000,
        CastRecovery = 0x00004000,
        CastSpeed = 0x00008000,
        LowerManaCost = 0x00010000,
        LowerRegCost = 0x00020000,
        ReflectPhysical = 0x00040000,
        EnhancePotions = 0x00080000,
        Luck = 0x00100000,
        SpellChanneling = 0x00200000,
        NightSight = 0x00400000,
        LowerAmmoCost = 0x00800000,
        IncreasedKarmaLoss = 0x01000000,
        CastingFocus = 0x02000000
    }

    public sealed class MagicalAttributes : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            var x = Enum.GetValues(typeof (MagicalAttribute));
            foreach (var e in x)
            {
                _data.Add((MagicalAttribute) e, 0);
            }

            this[MagicalAttribute.RegenHits] = (ClilocHelper.Contains(_lastmetatable, 1060444))
                ? ClilocHelper.GetParams(_lastmetatable, 1060444)[0]
                : 0;
            this[MagicalAttribute.RegenStam] = (ClilocHelper.Contains(_lastmetatable, 1060443))
                ? ClilocHelper.GetParams(_lastmetatable, 1060443)[0]
                : 0;
            this[MagicalAttribute.RegenMana] = (ClilocHelper.Contains(_lastmetatable, 1060440))
                ? ClilocHelper.GetParams(_lastmetatable, 1060440)[0]
                : 0;
            this[MagicalAttribute.DefendChance] = (ClilocHelper.Contains(_lastmetatable, 1060408))
                ? ClilocHelper.GetParams(_lastmetatable, 1060408)[0]
                : 0;
            this[MagicalAttribute.AttackChance] = (ClilocHelper.Contains(_lastmetatable, 1060415))
                ? ClilocHelper.GetParams(_lastmetatable, 1060415)[0]
                : 0;
            this[MagicalAttribute.BonusStr] = (ClilocHelper.Contains(_lastmetatable, 1060485))
                ? ClilocHelper.GetParams(_lastmetatable, 1060485)[0]
                : 0;
            this[MagicalAttribute.BonusDex] = (ClilocHelper.Contains(_lastmetatable, 1060409))
                ? ClilocHelper.GetParams(_lastmetatable, 1060409)[0]
                : 0;
            this[MagicalAttribute.BonusInt] = (ClilocHelper.Contains(_lastmetatable, 1060432))
                ? ClilocHelper.GetParams(_lastmetatable, 1060432)[0]
                : 0;
            this[MagicalAttribute.BonusHits] = (ClilocHelper.Contains(_lastmetatable, 1060431))
                ? ClilocHelper.GetParams(_lastmetatable, 1060431)[0]
                : 0;
            this[MagicalAttribute.BonusStam] = (ClilocHelper.Contains(_lastmetatable, 1060484))
                ? ClilocHelper.GetParams(_lastmetatable, 1060484)[0]
                : 0;
            this[MagicalAttribute.BonusMana] = (ClilocHelper.Contains(_lastmetatable, 1060439))
                ? ClilocHelper.GetParams(_lastmetatable, 1060439)[0]
                : 0;

            uint ClilocID = 0;

            switch (XConfig.Engine)
            {
                case ShardEngine.Broadsword:
                    ClilocID = 1060402;
                    break;
                case ShardEngine.RebirthUO:
                    ClilocID = 1060401;
                    break;
            }
            this[MagicalAttribute.WeaponDamage] = (ClilocHelper.Contains(_lastmetatable, ClilocID)) ? ClilocHelper.GetParams(_lastmetatable, ClilocID)[0] : 0;

            this[MagicalAttribute.WeaponSpeed] = (ClilocHelper.Contains(_lastmetatable, 1060486))
                ? ClilocHelper.GetParams(_lastmetatable, 1060486)[0]
                : 0;
            this[MagicalAttribute.SpellDamage] = (ClilocHelper.Contains(_lastmetatable, 1060483))
                ? ClilocHelper.GetParams(_lastmetatable, 1060483)[0]
                : 0;
            this[MagicalAttribute.CastRecovery] = (ClilocHelper.Contains(_lastmetatable, 1060412))
                ? ClilocHelper.GetParams(_lastmetatable, 1060412)[0]
                : 0;
            this[MagicalAttribute.CastSpeed] = (ClilocHelper.Contains(_lastmetatable, 1060413))
                ? ClilocHelper.GetParams(_lastmetatable, 1060413)[0]
                : 0;
            this[MagicalAttribute.LowerManaCost] = (ClilocHelper.Contains(_lastmetatable, 1060433))
                ? ClilocHelper.GetParams(_lastmetatable, 1060433)[0]
                : 0;
            this[MagicalAttribute.LowerRegCost] = (ClilocHelper.Contains(_lastmetatable, 1060434))
                ? ClilocHelper.GetParams(_lastmetatable, 1060434)[0]
                : 0;
            this[MagicalAttribute.ReflectPhysical] = (ClilocHelper.Contains(_lastmetatable, 1060442))
                ? ClilocHelper.GetParams(_lastmetatable, 1060442)[0]
                : 0;
            this[MagicalAttribute.EnhancePotions] = (ClilocHelper.Contains(_lastmetatable, 1060411))
                ? ClilocHelper.GetParams(_lastmetatable, 1060411)[0]
                : 0;
            this[MagicalAttribute.Luck] = (ClilocHelper.Contains(_lastmetatable, 1060436))
                ? ClilocHelper.GetParams(_lastmetatable, 1060436)[0]
                : 0;
            this[MagicalAttribute.SpellChanneling] = (ClilocHelper.Contains(_lastmetatable, 1060482));
            this[MagicalAttribute.NightSight] = (ClilocHelper.Contains(_lastmetatable, 1060441));
            this[MagicalAttribute.IncreasedKarmaLoss] = (ClilocHelper.Contains(_lastmetatable, 1075210))
                ? ClilocHelper.GetParams(_lastmetatable, 1075210)[0]
                : 0;
            this[MagicalAttribute.CastingFocus] = (ClilocHelper.Contains(_lastmetatable, 1113696))
                ? ClilocHelper.GetParams(_lastmetatable, 1113696)[0]
                : 0;
            this[MagicalAttribute.LowerAmmoCost] = (ClilocHelper.Contains(_lastmetatable, 1075208))
                ? ClilocHelper.GetParams(_lastmetatable, 1075208)[0]
                : 0;

            base.Parse();
        }

        #endregion

        #region Constructors

        public MagicalAttributes(UOEntity owner, List<ClilocItemRec> reader)
            : base(owner, reader)
        {
        }

        public MagicalAttributes(UOEntity owner)
            : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public int RegenHits
        {
            get { return this[MagicalAttribute.RegenHits]; }
        }

        public int RegenStam
        {
            get { return this[MagicalAttribute.RegenStam]; }
        }

        public int RegenMana
        {
            get { return this[MagicalAttribute.RegenMana]; }
        }

        public int DefendChance
        {
            get { return this[MagicalAttribute.DefendChance]; }
        }

        public int AttackChance
        {
            get { return this[MagicalAttribute.AttackChance]; }
        }

        public int BonusStr
        {
            get { return this[MagicalAttribute.BonusStr]; }
        }

        public int BonusDex
        {
            get { return this[MagicalAttribute.BonusDex]; }
        }

        public int BonusInt
        {
            get { return this[MagicalAttribute.BonusInt]; }
        }

        public int BonusHits
        {
            get { return this[MagicalAttribute.BonusHits]; }
        }

        public int BonusStam
        {
            get { return this[MagicalAttribute.BonusStam]; }
        }

        public int BonusMana
        {
            get { return this[MagicalAttribute.BonusMana]; }
        }

        public int WeaponDamage
        {
            get { return this[MagicalAttribute.WeaponDamage]; }
        }

        public int WeaponSpeed
        {
            get { return this[MagicalAttribute.WeaponSpeed]; }
        }

        public int SpellDamage
        {
            get { return this[MagicalAttribute.SpellDamage]; }
        }

        public int CastRecovery
        {
            get { return this[MagicalAttribute.CastRecovery]; }
        }

        public int CastSpeed
        {
            get { return this[MagicalAttribute.CastSpeed]; }
        }

        public int LowerManaCost
        {
            get { return this[MagicalAttribute.LowerManaCost]; }
        }

        public int LowerRegCost
        {
            get { return this[MagicalAttribute.LowerRegCost]; }
        }

        public int ReflectPhysical
        {
            get { return this[MagicalAttribute.ReflectPhysical]; }
        }

        public int EnhancePotions
        {
            get { return this[MagicalAttribute.EnhancePotions]; }
        }

        public int Luck
        {
            get { return this[MagicalAttribute.Luck]; }
        }

        public bool SpellChanneling
        {
            get { return this[MagicalAttribute.SpellChanneling]; }
        }

        public bool NightSight
        {
            get { return this[MagicalAttribute.NightSight]; }
        }

        public int LowerAmmoCost
        {
            get { return this[MagicalAttribute.LowerAmmoCost]; }
        }

        public int IncreasedKarmaLoss
        {
            get { return this[MagicalAttribute.IncreasedKarmaLoss]; }
        }

        public int CastingFocus
        {
            get { return this[MagicalAttribute.CastingFocus]; }
        }

        #endregion
    }
}