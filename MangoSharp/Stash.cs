using MangoSharp.Data;
using MangoSharp.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoSharp
{
    /// <summary>
    /// Class containing all heroes and items
    /// </summary>
    /// <remarks>
    /// Initialize a MangoClient before accessing this class
    /// </remarks>
    public static class Stash
    {
        static Stash()
        {
            Heroes = new List<Hero>();
            Items = new List<Item>();
        }

        public static List<Hero> Heroes { get; internal set; }
        public static List<Item> Items { get; internal set; }
    }
}
