using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0xc77, 0xc78})]
    public class Carrot : Vegetables
    {
        public Carrot(Serial serial) : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xc7b, 0xc7c})]
    public class Cabbage : Vegetables
    {
        public Cabbage(Serial serial) : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xc6d, 0xc6e})]
    public class Onion : Vegetables
    {
        public Onion(Serial serial) : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xc70, 0xc71})]
    public class Lettuce : Vegetables
    {
        public Lettuce(Serial serial) : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xC6A, 0xC6B})]
    public class QueryGraphic : Vegetables
    {
        public QueryGraphic(Serial serial) : base(serial)
        {
        }
    }

    [QuerySearch(0xC6C)]
    public class SmallPumpkin : Vegetables
    {
        public SmallPumpkin(Serial serial) : base(serial)
        {
        }
    }
}