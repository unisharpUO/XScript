using System;
using ScriptSDK;
using ScriptSDK.Data;
using XScript.Interfaces;

namespace XScript.Items
{
    [QuerySearch(0x2FD7, 0x482)]
    public class GrapesOfWrath : EnhancedFruits, ICommodity
    {
        public static readonly TimeSpan Cooldown = TimeSpan.FromMinutes(2.0);

        public GrapesOfWrath(Serial serial) : base(serial)
        {
        }
    }

    [QuerySearch(0x9D0, 1160, 1032248)]
    public class EnchantedApple : EnhancedFruits, ICommodity
    {
        public static readonly TimeSpan Cooldown = TimeSpan.FromSeconds(30.0);

        public EnchantedApple(Serial serial)
            : base(serial)
        {
        }
    }
}