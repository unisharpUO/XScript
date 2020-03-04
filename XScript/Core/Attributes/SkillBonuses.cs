using System.Collections.Generic;
using ScriptSDK;
using StealthAPI;
using ScriptSDK.Attributes;
using ScriptSDK.Data;
using XScript.Extensions;

namespace XScript.Attributes
{
    public sealed class SkillBonuses : BaseAttributes
    {
        #region Parser

        protected override void Parse()
        {
            for (var i = 0; i < 5; i++)
            {
                var res = this.ReadSkillBonus(((uint) (1060451 + i)), _lastmetatable);

                switch (i)
                {
                    case 0:
                    {
                        Skill_1_Name = res[0];
                        Skill_1_Value = res[1];
                        break;
                    }
                    case 1:
                    {
                        Skill_2_Value = res[1];
                        Skill_2_Name = res[0];
                        break;
                    }
                    case 2:
                    {
                        Skill_3_Value = res[1];
                        Skill_3_Name = res[0];
                        break;
                    }
                    case 3:
                    {
                        Skill_4_Value = res[1];
                        Skill_4_Name = res[0];
                        break;
                    }
                    case 4:
                    {
                        Skill_5_Value = res[1];
                        Skill_5_Name = res[0];
                        break;
                    }
                }
            }
            base.Parse();
        }

        #endregion

        #region Constructors

        public SkillBonuses(UOEntity owner, List<ClilocItemRec> reader)
            : base(owner, reader)
        {
        }

        public SkillBonuses(UOEntity owner)
            : base(owner, owner.Properties)
        {
        }

        #endregion

        #region Properties

        public double Skill_1_Value { get; private set; }
        public SkillName Skill_1_Name { get; private set; }
        public double Skill_2_Value { get; private set; }
        public SkillName Skill_2_Name { get; private set; }
        public double Skill_3_Value { get; private set; }
        public SkillName Skill_3_Name { get; private set; }
        public double Skill_4_Value { get; private set; }
        public SkillName Skill_4_Name { get; private set; }
        public double Skill_5_Value { get; private set; }
        public SkillName Skill_5_Name { get; private set; }

        #endregion
    }
}