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
            MangoClient client = new MangoClient("9D19955EE09BF0B5F0681F566ED78CE2");
            var heroes = Stash.Heroes;
            var items = Stash.Items;
            items[101].GetImage().Save("test.png");
        }
    }
}
