using MangoSharp.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoSharp.Test
{
    static class Program
    {
        public static void Main(string[] args)
        {
            MangoClient client = new MangoClient("YOUR API KEY GOES HERE");
            var heroes = Stash.Heroes;
            var items = Stash.Items;
            items[101].GetImage().Save("test.png");
        }
    }
}
