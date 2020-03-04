using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x99F, 0x99B, 0x9C7}, 0xFFFF, 1042959)]
    public class BeverageBottle : BaseBeverage
    {
        public BeverageBottle(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9C8, 0xFFFF, 1042965)]
    public class Jug : BaseBeverage
    {
        public Jug(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x995, 0x996, 0x997, 0x998, 0x999, 0x9CA}, 0xFFFF, 1042982)]
    public class CeramicMug : BaseBeverage
    {
        public CeramicMug(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xFFF, 0x1000, 0x1001, 0x1002}, 0xFFFF, 1042994)]
    public class PewterMug : BaseBeverage
    {
        public PewterMug(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x99A, 0x9B3, 0x9BF, 0x9CB}, 0xFFFF, 1043000)]
    public class Goblet : BaseBeverage
    {
        public Goblet(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(
        new ushort[]
        {
            0x1F81, 0x1F82, 0x1F83, 0x1F84, 0x9EF, 0x9EE, 0x1F7D, 0x1F7F, 0x1F80, 0x1F85, 0x1F86, 0x1F87, 0x1F88, 0x1F89,
            0x1F8A, 0x1F8B, 0x1F8D, 0x1F8F, 0x1F91, 0x1F92, 0x1F93, 0x1F94
        }, 0xFFFF, 1043000)]
    public class GlassMug : BaseBeverage
    {
        public GlassMug(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(
        new ushort[]
        {
            0x9A7, 0xFF7, 0xFF6, 0x1F96, 0x1F95, 0x1F98, 0x1F97, 0x1F9A, 0x1F99, 0x9AD, 0x9F0, 0x1F9C, 0x1F9B, 0xFF8,
            0xFF9,
            0x1F9E, 0x1F9D
        }, 0xFFFF, 1048128)]
    public class Pitcher : BaseBeverage
    {
        public Pitcher(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x1f81, 0x1f82, 0x1f83, 0x1f84})]
    public class Glass : BaseBeverage
    {
        public Glass(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xe2b)]
    public class GlassBottle : BaseBeverage
    {
        public GlassBottle(Serial serial)
            : base(serial)
        {
        }
    }
}