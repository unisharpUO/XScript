using System;
using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Engines;

namespace XScript.Attributes
{
    public enum ElementAttribute
    {
        Physical = 0x00000001,
        Fire = 0x00000002,
        Cold = 0x00000004,
        Poison = 0x00000008,
        Energy = 0x00000010
    }


    public sealed class ElementAttributes : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            var x = Enum.GetValues(typeof (ElementAttribute));
            foreach (var e in x)
            {
                _data.Add((ElementAttribute) e, 0);
            }


            this[ElementAttribute.Physical] = (ClilocHelper.GetIndex(_lastmetatable, 1060448) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1060448)[0]
                : 0;
            this[ElementAttribute.Fire] = (ClilocHelper.GetIndex(_lastmetatable, 1060447) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1060447)[0]
                : 0;
            this[ElementAttribute.Cold] = (ClilocHelper.GetIndex(_lastmetatable, 1060445) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1060445)[0]
                : 0;
            this[ElementAttribute.Poison] = (ClilocHelper.GetIndex(_lastmetatable, 1060449) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1060449)[0]
                : 0;
            this[ElementAttribute.Energy] = (ClilocHelper.GetIndex(_lastmetatable, 1060446) > -1)
                ? ClilocHelper.GetParams(_lastmetatable, 1060446)[0]
                : 0;
            base.Parse();
        }

        #endregion

        #region Constructors

        public ElementAttributes(UOEntity owner, List<ClilocItemRec> reader) : base(owner, reader)
        {
        }

        public ElementAttributes(UOEntity owner)
            : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public int Physical
        {
            get { return this[ElementAttribute.Physical]; }
        }

        public int Fire
        {
            get { return this[ElementAttribute.Fire]; }
        }

        public int Cold
        {
            get { return this[ElementAttribute.Cold]; }
        }

        public int Poison
        {
            get { return this[ElementAttribute.Poison]; }
        }

        public int Energy
        {
            get { return this[ElementAttribute.Energy]; }
        }

        #endregion
    }
}