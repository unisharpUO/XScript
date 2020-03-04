using ScriptSDK;
using StealthAPI;
using ScriptSDK.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XScript.Scripts.unisharpUO
{
    public class TargetExtensions
    {
        public static Item RequestTarget(uint TimeoutMS = 0)
        {
            Stealth.Client.ClientRequestObjectTarget();
            Stopwatch timer = new Stopwatch();


            timer.Start();
            while (Stealth.Client.ClientTargetResponsePresent() == false)
            {
                if (TimeoutMS != 0 && timer.ElapsedMilliseconds >= TimeoutMS)
                    return default(Item);
            }

            return new Item(new Serial(Stealth.Client.ClientTargetResponse().ID));
        }
    }
}
