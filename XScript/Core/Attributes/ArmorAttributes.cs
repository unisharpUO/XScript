using System;
using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;

namespace XScript.Attributes
{
    public enum ArmorAttribute
    {
        LowerStatReq = 0x00000001,
        SelfRepair = 0x00000002,
        MageArmor = 0x00000004,
        DurabilityBonus = 0x00000008,
        SoulCharge = 0x00000010,
        ReactiveParalyze = 0x00000020
    }

    public sealed class ArmorAttributes : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            var x = Enum.GetValues(typeof (ArmorAttribute));
            foreach (var e in x)
            {
                _data.Add((ArmorAttribute) e, 0);
            }

            this[ArmorAttribute.MageArmor] = (ClilocHelper.Contains(_lastmetatable, 1060437));
            this[ArmorAttribute.SelfRepair] = (ClilocHelper.GetIndex(_lastmetatable, 1060450) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1060450)[0]
                : 0;
            this[ArmorAttribute.SoulCharge] = (ClilocHelper.GetIndex(_lastmetatable, 1113630) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1113630)[0]
                : 0;
            this[ArmorAttribute.ReactiveParalyze] = (ClilocHelper.Contains(_lastmetatable, 1112364));
            this[ArmorAttribute.LowerStatReq] = (ClilocHelper.GetIndex(_lastmetatable, 1061170) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1061170)[0]
                : 0;

            base.Parse();
        }

        #endregion

        #region Constructors

        public ArmorAttributes(UOEntity owner, List<ClilocItemRec> reader) : base(owner, reader)
        {
        }

        public ArmorAttributes(UOEntity owner)
            : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public int LowerStatReq
        {
            get { return this[ArmorAttribute.LowerStatReq]; }
        }

        public int SelfRepair
        {
            get { return this[ArmorAttribute.SelfRepair]; }
        }

        public bool MageArmor
        {
            get { return this[ArmorAttribute.MageArmor]; }
        }

        public int DurabilityBonus
        {
            get { return this[ArmorAttribute.DurabilityBonus]; }
        }

        public int SoulCharge
        {
            get { return this[ArmorAttribute.SoulCharge]; }
        }

        public bool ReactiveParalyze
        {
            get { return this[ArmorAttribute.ReactiveParalyze]; }
        }

        #endregion
    }
}