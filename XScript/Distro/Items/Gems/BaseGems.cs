using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;
using XScript.Interfaces;

namespace XScript.Items
{
    [QueryType(typeof (BaseJewelGems))]
    public class BaseGems : Item, ICommodity
    {
        public BaseGems(Serial serial)
            : base(serial)
        {
        }
    }

    [QueryType(typeof (Tourmaline), typeof (StarSapphire), typeof (Sapphire), typeof (Ruby), typeof (Emerald),
        typeof (Diamond), typeof (Citrine), typeof (Amethyst), typeof (Amber))]
    public class BaseJewelGems : Item, ICommodity
    {
        public BaseJewelGems(Serial serial)
            : base(serial)
        {
        }
    }
}