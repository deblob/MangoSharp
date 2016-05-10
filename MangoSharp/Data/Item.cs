using MangoSharp.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoSharp.Data
{
    public class Item
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public string InternalName { get; set; }
        public int GoldCost { get; set; }
        public bool SideShop { get; set; }
        public bool SecretShop { get; set; }
        public bool IsRecipe { get; set; }

        public Image GetImage()
        {
            string itemName = InternalName.Replace("item_", String.Empty);
            itemName += "_lg.png";
            byte[] imageData = Repository.GetItemImageData(itemName);
            return Image.FromStream(new MemoryStream(imageData));
        }
    }
}
