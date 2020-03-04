using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;
using XScript.Interfaces;

namespace XScript.Items
{
    [QuerySearch(new ushort[] {0x15F9, 0x15FE})]
    public class BowlOfCarrots : ConsumeableFood
    {
        public BowlOfCarrots(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x15FA, 0x15FF})]
    public class BowlOfCorn : ConsumeableFood
    {
        public BowlOfCorn(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x15FB, 0x1600})]
    public class BowlOfLettuce : ConsumeableFood
    {
        public BowlOfLettuce(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x15FC, 0x1601})]
    public class BowlOfPeas : ConsumeableFood
    {
        public BowlOfPeas(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1602, 0xFFFF, 1025634)]
    public class BowlOfPotatoes : ConsumeableFood
    {
        public BowlOfPotatoes(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x2DBA, 0xFFFF, 1031706)]
    public class BowlOfRotwormStew : ConsumeableFood
    {
        public BowlOfRotwormStew(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1604, 0xFFFF, 1025636)]
    public class BowlOfStew : ConsumeableFood
    {
        public BowlOfStew(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1606, 0xFFFF, 1025638)]
    public class TomatoSoup : ConsumeableFood
    {
        public TomatoSoup(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x15FD, 0xFFFF, 1025629)]
    public class PewterBowl : ConsumeableFood
    {
        public PewterBowl(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2836, 0x2837}, 0xFFFF, 1030292)]
    public class BentoBox : ConsumeableFood
    {
        public BentoBox(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x24EB, 0xFFFF, 1029451)]
    public class WasabiClumps : ConsumeableFood
    {
        public WasabiClumps(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x24E8, 0x24E9}, 0xFFFF, 1029449)]
    public class Wasabi : ConsumeableFood
    {
        public Wasabi(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x284B)]
    public class GreenTeaBasket : Item
    {
        public GreenTeaBasket(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x284C, 0xFFFF, 1030316)]
    public class GreenTea : ConsumeableFood
    {
        public GreenTea(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x2840, 0x2841}, 0xFFFF, 1030305)]
    public class SushiPlatter : ConsumeableFood
    {
        public SushiPlatter(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0x283E, 0x283F}, 0xFFFF, 1030303)]
    public class SushiRolls : ConsumeableFood
    {
        public SushiRolls(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x2850, 0xFFFF, 1030320)]
    public class AwaseMisoSoup : ConsumeableFood
    {
        public AwaseMisoSoup(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x284F, 0xFFFF, 1030318)]
    public class RedMisoSoup : ConsumeableFood
    {
        public RedMisoSoup(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x284E, 0xFFFF, 1025634)]
    public class WhiteMisoSoup : ConsumeableFood
    {
        public WhiteMisoSoup(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x284D, 0xFFFF, 1030317)]
    public class MisoSoup : ConsumeableFood
    {
        public MisoSoup(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x103B)]
    public class BreadLoaf : ConsumeableFood, ICommodity
    {
        public BreadLoaf(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x979)]
    public class Bacon : ConsumeableFood, ICommodity
    {
        public Bacon(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x976)]
    public class SlabOfBacon : ConsumeableFood, ICommodity
    {
        public SlabOfBacon(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x97B)]
    public class FishSteak : ConsumeableFood, ICommodity
    {
        public FishSteak(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x97E)]
    public class CheeseWheel : ConsumeableFood, ICommodity
    {
        public CheeseWheel(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x97D)]
    public class CheeseWedge : ConsumeableFood, ICommodity
    {
        public CheeseWedge(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x97C)]
    public class CheeseSlice : ConsumeableFood, ICommodity
    {
        public CheeseSlice(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x98C)]
    public class FrenchBread : ConsumeableFood, ICommodity
    {
        public FrenchBread(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9B6)]
    public class FriedEggs : ConsumeableFood, ICommodity
    {
        public FriedEggs(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9B7)]
    public class CookedBird : ConsumeableFood, ICommodity
    {
        public CookedBird(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9BB)]
    public class RoastPig : ConsumeableFood, ICommodity
    {
        public RoastPig(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9C0)]
    public class Sausage : ConsumeableFood, ICommodity
    {
        public Sausage(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9C9)]
    public class Ham : ConsumeableFood, ICommodity
    {
        public Ham(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9E9)]
    public class Cake : ConsumeableFood
    {
        public Cake(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9F2)]
    public class Ribs : ConsumeableFood, ICommodity
    {
        public Ribs(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x160b)]
    public class Cookies : ConsumeableFood, ICommodity
    {
        public Cookies(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x9eb)]
    public class Muffins : ConsumeableFood
    {
        public Muffins(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1040, 0xFFFF, 1044516)]
    public class CheesePizza : ConsumeableFood
    {
        public CheesePizza(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1040, 0xFFFF, 1044517)]
    public class SausagePizza : ConsumeableFood
    {
        public SausagePizza(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1041, 0xFFFF, 1041346)]
    public class FruitPie : ConsumeableFood
    {
        public FruitPie(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1041, 0xFFFF, 1041347)]
    public class MeatPie : ConsumeableFood
    {
        public MeatPie(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1041, 0xFFFF, 1041348)]
    public class PumpkinPie : ConsumeableFood
    {
        public PumpkinPie(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1041, 0xFFFF, 1041343)]
    public class ApplePie : ConsumeableFood
    {
        public ApplePie(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1041, 0xFFFF, 1041344)]
    public class PeachCobbler : ConsumeableFood
    {
        public PeachCobbler(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1041, 0xFFFF, 1041345)]
    public class Quiche : ConsumeableFood, ICommodity
    {
        public Quiche(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x160a)]
    public class LambLeg : ConsumeableFood, ICommodity
    {
        public LambLeg(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x1608)]
    public class ChickenLeg : ConsumeableFood, ICommodity
    {
        public ChickenLeg(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xC74, 0xC75})]
    public class HoneydewMelon : ConsumeableFood, ICommodity
    {
        public HoneydewMelon(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xC64, 0xC65})]
    public class YellowGourd : ConsumeableFood, ICommodity
    {
        public YellowGourd(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xC66, 0xC67})]
    public class GreenGourd : ConsumeableFood, ICommodity
    {
        public GreenGourd(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(new ushort[] {0xC7F, 0xC81})]
    public class EarOfCorn : ConsumeableFood, ICommodity
    {
        public EarOfCorn(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xD3A)]
    public class Turnip : ConsumeableFood, ICommodity
    {
        public Turnip(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xF36)]
    public class SheafOfHay : Item, ICommodity
    {
        public SheafOfHay(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x15FD, 0xFFFF, 2051)]
    public class DarkChocolate : ConsumeableFood, ICommodity
    {
        public DarkChocolate(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0x15FD, 0xFFFF, 1121)]
    public class MilkChocolate : ConsumeableFood, ICommodity
    {
        public MilkChocolate(Serial serial)
            : base(serial)
        {
        }
    }

    [QuerySearch(0xF13, 0xFFFF, 2037)]
    public class WhiteChocolate : ConsumeableFood, ICommodity
    {
        public WhiteChocolate(Serial serial)
            : base(serial)
        {
        }
    }
}