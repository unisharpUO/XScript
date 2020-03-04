using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QueryType(typeof (BaseBow), typeof (BaseThrowing))]
    public class BaseRangedWeapon : BaseWeapon
    {
        public BaseRangedWeapon(Serial serial)
            : base(serial)
        {
        }
    }
}