using MangoSharp.Enumerations;
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
    public class Hero
    {
        public int ID { get; set; }
        public string DisplayName { get; set; }
        public string InternalName { get; set; }

        internal Hero(int id, string internalName, string displayName)
        {
            ID = id;
            DisplayName = displayName;
            InternalName = internalName;
        }

        public Image GetPortrait(PortraitFormat format)
        {
            string portraitName = InternalName.Replace("npc_dota_hero_", String.Empty);
            switch (format)
            {
                case PortraitFormat.SmallHorizontal:
                    portraitName += "_sb";
                    break;
                case PortraitFormat.LargeHorizontal:
                    portraitName += "_lg";
                    break;
                case PortraitFormat.FullHorizontal:
                    portraitName += "_full";
                    break;
                case PortraitFormat.FullVertical:
                    portraitName += "_vert";
                    break;
            }
            portraitName += ".png";

            byte[] imageData = Repository.GetHeroImageData(portraitName);
            return Image.FromStream(new MemoryStream(imageData));
        }
    }
}
