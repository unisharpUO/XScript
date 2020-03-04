using ScriptSDK;
using XScript.Interfaces;

namespace XScript.Items
{
    internal class BaseClothing : BaseArmor, IClothing
    {
        public BaseClothing(Serial serial) : base(serial)
        {
        }
    }
}