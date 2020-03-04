using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (BaseAxe), typeof (BaseMace), typeof (BaseKnife), typeof (BasePoleArm), typeof (BaseStaff),
        typeof (BaseSpear),
        typeof (BaseFork), typeof (BaseSword))]
    public class BaseMeleeWeapon : BaseWeapon
    {
        public BaseMeleeWeapon(Serial serial)
            : base(serial)
        {
        }
    }
}