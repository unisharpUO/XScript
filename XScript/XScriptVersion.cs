using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XScript
{
    public enum ShardEngine
    {
        Unknown,
        Broadsword,
        RebirthUO
    }

    public static class XConfig
    {
        public static ShardEngine Engine { get; set; }

        public static void Initialize()
        {
            Engine = ShardEngine.Unknown;
        }
    }
}
