using System;
using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;

namespace XScript.Attributes
{
    public enum WeaponDamageAttribute
    {
        PhysicalDamage = 0x00000001,
        FireDamage = 0x00000002,
        ColdDamage = 0x00000004,
        PoisonDamage = 0x00000008,
        EnergyDamage = 0x00000010,
        ChaosDamage = 0x00000020
    }

    public sealed class WeaponDamageAttributes : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            var x = Enum.GetValues(typeof (WeaponDamageAttribute));
            foreach (var e in x)
            {
                _data.Add((WeaponDamageAttribute) e, 0);
            }

            this[WeaponDamageAttribute.PhysicalDamage] = (ClilocHelper.Contains(_lastmetatable, 1060403))
                ? ClilocHelper.GetParams(_lastmetatable, 1060403)[0]
                : 0;
            this[WeaponDamageAttribute.FireDamage] = (ClilocHelper.Contains(_lastmetatable, 1060405))
                ? ClilocHelper.GetParams(_lastmetatable, 1060405)[0]
                : 0;
            this[WeaponDamageAttribute.ColdDamage] = (ClilocHelper.Contains(_lastmetatable, 1060404))
                ? ClilocHelper.GetParams(_lastmetatable, 1060404)[0]
                : 0;
            this[WeaponDamageAttribute.PoisonDamage] = (ClilocHelper.Contains(_lastmetatable, 1060406))
                ? ClilocHelper.GetParams(_lastmetatable, 1060406)[0]
                : 0;
            this[WeaponDamageAttribute.EnergyDamage] = (ClilocHelper.Contains(_lastmetatable, 1060407))
                ? ClilocHelper.GetParams(_lastmetatable, 1060407)[0]
                : 0;
            this[WeaponDamageAttribute.ChaosDamage] = (ClilocHelper.Contains(_lastmetatable, 1072846))
                ? ClilocHelper.GetParams(_lastmetatable, 1072846)[0]
                : 0;

            base.Parse();
        }

        #endregion

        #region Constructors

        public WeaponDamageAttributes(UOEntity owner, List<ClilocItemRec> reader)
            : base(owner, reader)
        {
        }

        public WeaponDamageAttributes(UOEntity owner)
            : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public int PhysicalDamage
        {
            get { return this[WeaponDamageAttribute.PhysicalDamage]; }
        }

        public int FireDamage
        {
            get { return this[WeaponDamageAttribute.FireDamage]; }
        }

        public int ColdDamage
        {
            get { return this[WeaponDamageAttribute.ColdDamage]; }
        }

        public int PoisonDamage
        {
            get { return this[WeaponDamageAttribute.PoisonDamage]; }
        }

        public int EnergyDamage
        {
            get { return this[WeaponDamageAttribute.EnergyDamage]; }
        }

        public int ChaosDamage
        {
            get { return this[WeaponDamageAttribute.ChaosDamage]; }
        }

        #endregion
    }
}