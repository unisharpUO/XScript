using ScriptSDK;
using ScriptSDK.Data;
using ScriptSDK.Items;
using XScript.Extensions;
using XScript.Interfaces;

namespace XScript.Items
{
    [QueryType(typeof (BeverageBottle), typeof (Jug), typeof (CeramicMug), typeof (PewterMug), typeof (Goblet),
        typeof (GlassMug), typeof (Pitcher), typeof (Glass), typeof (GlassBottle))]
    public class BaseBeverage : Item, IHasQuantity
    {
        public BaseBeverage(Serial serial)
            : base(serial)
        {
        }

        private double _fillstate { get; set; }

        public double FillState
        {
            get { return this.GetFillState(Properties); }
        }
    }
}