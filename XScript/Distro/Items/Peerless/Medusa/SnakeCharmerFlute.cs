using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;

namespace XScript.Items
{
    [QueryType(typeof (BambooFlute))]
    public class SnakeCharmerFlute : Item
    {
        public SnakeCharmerFlute(Serial serial)
            : base(serial)
        {
        }
    }
}