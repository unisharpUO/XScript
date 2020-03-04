using ScriptSDK;
using ScriptSDK.Data;
using XScript.Interfaces;

namespace XScript.Items
{
    [QuerySearch(0x993)]
    public class FruitBasket : Fruit
    {
        public FruitBasket(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x2D4F, 0xFFFF, 1072950)]
    public class FruitBowl : Fruit
    {
        public FruitBowl(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x171f, 0x1720})]
    public class Banana : Fruit, ICommodity
    {
        public Banana(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x1721, 0x1722})]
    public class Bananas : Fruit, ICommodity
    {
        public Bananas(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1725)]
    public class SplitCoconut : Fruit, ICommodity
    {
        public SplitCoconut(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1728)]
    public class Lemon : Fruit, ICommodity
    {
        public Lemon(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1729)]
    public class Lemons : Fruit, ICommodity
    {
        public Lemons(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x172a)]
    public class Lime : Food, ICommodity
    {
        public Lime(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x172B)]
    public class Limes : Food, ICommodity
    {
        public Limes(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1726)]
    public class Coconut : Food, ICommodity
    {
        public Coconut(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1723)]
    public class OpenCoconut : Food, ICommodity
    {
        public OpenCoconut(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1727)]
    public class Dates : Food, ICommodity
    {
        public Dates(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9D1)]
    public class Grapes : Food, ICommodity
    {
        public Grapes(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9D2)]
    public class Peach : Food, ICommodity
    {
        public Peach(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x994)]
    public class Pear : Food, ICommodity
    {
        public Pear(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9D0)]
    public class Apple : Food, ICommodity
    {
        public Apple(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xC5C)]
    public class Watermelon : Food, ICommodity
    {
        public Watermelon(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xC5D)]
    public class SmallWatermelon : Food, ICommodity
    {
        public SmallWatermelon(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xc72, 0xc73})]
    public class Squash : Food, ICommodity
    {
        public Squash(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xc79, 0xc7a})]
    public class Cantaloupe : Food, ICommodity
    {
        public Cantaloupe(Serial serial)
            : base(serial)
        {
        }
    }
}