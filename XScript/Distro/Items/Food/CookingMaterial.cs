using ScriptSDK;
using ScriptSDK.Data;

namespace XScript.Items
{
    [QuerySearch(0x103d)]
    public class Dough : CookingMaterial
    {
        public Dough(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x103d, 150, 1041340)]
    public class SweetDough : CookingMaterial
    {
        public SweetDough(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9ec)]
    public class JarHoney : CookingMaterial
    {
        public JarHoney(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xa1e)]
    public class BowlFlour : CookingMaterial
    {
        public BowlFlour(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x15f8)]
    public class WoodenBowl : CookingMaterial
    {
        public WoodenBowl(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x1f9d, 0x1f9e, 0x1f9f})]
    public class PitcherWater : CookingMaterial
    {
        public PitcherWater(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1039)]
    public class SackFlour : CookingMaterial
    {
        public SackFlour(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9b4)]
    public class Eggshells : CookingMaterial
    {
        public Eggshells(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(7869)]
    public class WheatSheaf : CookingMaterial
    {
        public WheatSheaf(Serial serial)
            : base(serial)
        {
        }
    }
}