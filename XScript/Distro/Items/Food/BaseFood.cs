using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;
using XScript.Extensions;
using XScript.Interfaces;

namespace XScript.Items
{
    [QueryType(typeof (EnhancedFruits), typeof (Fruit), typeof (Vegetables), typeof (Spices), typeof (CookableFood),
        typeof (ConsumeableFood), typeof (SpecialFood))]
    public class Food : Item, ICraftable, IDecorateable
    {
        public Food(Serial serial)
            : base(serial)
        {
        }

        private bool _exceptional { get; set; }
        private string _craftername { get; set; }
        private string _decorationmessage { get; set; }

        public bool Exceptional
        {
            get { return this.ReadIsExceptionalState(Properties); }
        }

        public string Crafter
        {
            get { return this.ReadCrafterName(Properties); }
        }

        public string DecorationMessage
        {
            get { return this.ReadDecorationMessage(Properties); }
        }
    }

    [QueryType(typeof (FruitBasket), typeof (FruitBowl), typeof (Banana), typeof (Bananas), typeof (SplitCoconut),
        typeof (Lemon), typeof (Lemons), typeof (Lime),
        typeof (Limes), typeof (Coconut), typeof (OpenCoconut), typeof (Dates), typeof (Grapes), typeof (Peach),
        typeof (Pear), typeof (Apple), typeof (Watermelon),
        typeof (Cantaloupe), typeof (Squash), typeof (Pear))]
    public class Fruit : Food
    {
        public Fruit(Serial serial)
            : base(serial)
        {
        }
    }

    [QueryType(typeof (EnchantedApple), typeof (GrapesOfWrath))]
    public class EnhancedFruits : Food
    {
        public EnhancedFruits(Serial serial)
            : base(serial)
        {
            // TODO :
            /*  Enhanced Fruits have a timer for reeating. Would be nice if we could capture it and check on Handle ;)*/
        }
    }

    [QueryType(typeof (Carrot), typeof (Cabbage), typeof (Onion), typeof (Lettuce), typeof (QueryGraphic),
        typeof (SmallPumpkin))]
    public class Vegetables : Food
    {
        public Vegetables(Serial serial)
            : base(serial)
        {
        }
    }

    [QueryType(typeof (Vanilla), typeof (SackOfSugar))]
    public class Spices : Food
    {
        public Spices(Serial serial)
            : base(serial)
        {
        }
    }

    [QueryType(typeof (BowlOfCarrots), typeof (BowlOfCorn), typeof (BowlOfLettuce), typeof (BowlOfPeas),
        typeof (BowlOfPotatoes), typeof (BowlOfRotwormStew),
        typeof (BowlOfStew), typeof (TomatoSoup), typeof (PewterBowl), typeof (BentoBox), typeof (WasabiClumps),
        typeof (Wasabi), typeof (GreenTeaBasket),
        typeof (GreenTea), typeof (SushiPlatter), typeof (SushiRolls), typeof (AwaseMisoSoup), typeof (RedMisoSoup),
        typeof (WhiteMisoSoup), typeof (MisoSoup),
        typeof (BreadLoaf), typeof (Bacon), typeof (SlabOfBacon), typeof (FishSteak), typeof (CheeseWheel),
        typeof (CheeseWedge), typeof (CheeseSlice),
        typeof (FrenchBread), typeof (FriedEggs), typeof (CookedBird), typeof (RoastPig), typeof (Sausage), typeof (Ham),
        typeof (Cake), typeof (Ribs), typeof (Cookies),
        typeof (Muffins), typeof (CheesePizza), typeof (SausagePizza), typeof (FruitPie), typeof (MeatPie),
        typeof (PumpkinPie), typeof (ApplePie), typeof (PeachCobbler),
        typeof (Quiche), typeof (LambLeg), typeof (ChickenLeg), typeof (HoneydewMelon), typeof (YellowGourd),
        typeof (GreenGourd), typeof (EarOfCorn), typeof (Turnip),
        typeof (SheafOfHay), typeof (DarkChocolate), typeof (MilkChocolate), typeof (WhiteChocolate))]
    public class ConsumeableFood : Food
    {
        public ConsumeableFood(Serial serial)
            : base(serial)
        {
            // TODO
            /* Cookable food has the Ability to be cooked, would be nice if there would be a handler for it:) */
        }

        public virtual Food Cook()
        {
            return null;
        }
    }

    [QueryType(typeof (EasterEggs), typeof (RawRibs), typeof (RawLambLeg), typeof (RawChickenLeg), typeof (RawBird),
        typeof (UnbakedPeachCobbler), typeof (UnbakedFruitPie),
        typeof (UnbakedMeatPie), typeof (UnbakedPumpkinPie), typeof (UnbakedApplePie), typeof (UncookedCheesePizza),
        typeof (UncookedSausagePizza), typeof (UnbakedQuiche),
        typeof (Eggs), typeof (CookieMix), typeof (CakeMix), typeof (RawFishSteak), typeof (RawRotwormMeat))]
    public class CookableFood : Food
    {
        public CookableFood(Serial serial)
            : base(serial)
        {
            // TODO
            /* Cookable food has the Ability to be cooked, would be nice if there would be a handler for it:) */
        }

        public virtual Food Cook()
        {
            return null;
        }
    }

    [QueryType(typeof (CocoaLiquor), typeof (CocoaButter))]
    public class SpecialFood : Food
    {
        public SpecialFood(Serial serial) : base(serial)
        {
        }
    }


    [QueryType(typeof (Dough), typeof (SweetDough), typeof (JarHoney), typeof (BowlFlour), typeof (WoodenBowl),
        typeof (PitcherWater), typeof (SackFlour), typeof (Eggshells), typeof (WheatSheaf))]
    public class CookingMaterial : Food
    {
        public CookingMaterial(Serial serial)
            : base(serial)
        {
        }
    }
}