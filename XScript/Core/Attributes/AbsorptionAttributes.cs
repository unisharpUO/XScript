using System;
using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;

namespace XScript.Attributes
{
    public enum AbsorptionAttribute
    {
        KineticEater = 0x00000001,
        FireEater = 0x00000002,
        ColdEater = 0x00000004,
        PoisonEater = 0x00000008,
        EnergyEater = 0x00000010,
        DamageEater = 0x00000020,
        KineticResonance = 0x00000040,
        FireResonance = 0x00000080,
        ColdResonance = 0x00000100,
        PoisonResonance = 0x00000200,
        EnergyResonance = 0x00000400
    }

    public sealed class AbsorptionAttributes : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            var x = Enum.GetValues(typeof (AbsorptionAttribute));
            foreach (var e in x)
            {
                _data.Add((AbsorptionAttribute) e, 0);
            }

            this[AbsorptionAttribute.KineticEater] = (ClilocHelper.GetIndex(_lastmetatable, 1113597) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113597)[0]
                : 0;
            this[AbsorptionAttribute.FireEater] = (ClilocHelper.GetIndex(_lastmetatable, 1113593) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113593)[0]
                : 0;
            this[AbsorptionAttribute.ColdEater] = (ClilocHelper.GetIndex(_lastmetatable, 1113594) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113594)[0]
                : 0;
            this[AbsorptionAttribute.PoisonEater] = (ClilocHelper.GetIndex(_lastmetatable, 1113595) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113595)[0]
                : 0;
            this[AbsorptionAttribute.EnergyEater] = (ClilocHelper.GetIndex(_lastmetatable, 1113596) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113596)[0]
                : 0;
            this[AbsorptionAttribute.DamageEater] = (ClilocHelper.GetIndex(_lastmetatable, 1113598) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113598)[0]
                : 0;
            this[AbsorptionAttribute.KineticResonance] = (ClilocHelper.GetIndex(_lastmetatable, 1113695) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113695)[0]
                : 0;
            this[AbsorptionAttribute.FireResonance] = (ClilocHelper.GetIndex(_lastmetatable, 1113691) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113691)[0]
                : 0;
            this[AbsorptionAttribute.ColdResonance] = (ClilocHelper.GetIndex(_lastmetatable, 1113692) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113692)[0]
                : 0;
            this[AbsorptionAttribute.PoisonResonance] = (ClilocHelper.GetIndex(_lastmetatable, 1113693) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113693)[0]
                : 0;
            this[AbsorptionAttribute.EnergyResonance] = (ClilocHelper.GetIndex(_lastmetatable, 1113694) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113694)[0]
                : 0;
            base.Parse();
        }

        #endregion

        #region Constructors

        public AbsorptionAttributes(UOEntity owner, List<ClilocItemRec> reader) : base(owner, reader)
        {
        }

        public AbsorptionAttributes(UOEntity owner) : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public int KineticEater
        {
            get { return this[AbsorptionAttribute.KineticEater]; }
        }

        public int FireEater
        {
            get { return this[AbsorptionAttribute.FireEater]; }
        }

        public int ColdEater
        {
            get { return this[AbsorptionAttribute.ColdEater]; }
        }

        public int PoisonEater
        {
            get { return this[AbsorptionAttribute.PoisonEater]; }
        }

        public int EnergyEater
        {
            get { return this[AbsorptionAttribute.EnergyEater]; }
        }

        public int DamageEater
        {
            get { return this[AbsorptionAttribute.DamageEater]; }
        }

        public int KineticResonance
        {
            get { return this[AbsorptionAttribute.KineticResonance]; }
        }

        public int FireResonance
        {
            get { return this[AbsorptionAttribute.FireResonance]; }
        }

        public int ColdResonance
        {
            get { return this[AbsorptionAttribute.ColdResonance]; }
        }

        public int PoisonResonance
        {
            get { return this[AbsorptionAttribute.PoisonResonance]; }
        }

        public int EnergyResonance
        {
            get { return this[AbsorptionAttribute.EnergyResonance]; }
        }

        #endregion
    }
}