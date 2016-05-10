using MangoSharp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MangoSharp.Internal
{
    internal static class Repository
    {
        private static string REQ_GET_HEROES
        {
            get
            {
                return $"https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v0001/?format=XML&key={Key}&language=en_us";
            }
        }

        private static string REQ_GET_PORTRAIT
        {
            get
            {
                return "http://cdn.dota2.com/apps/dota2/images/heroes/";
            }
        }

        private static string REQ_GET_ITEMS
        {
            get
            {
                return $"https://api.steampowered.com/IEconDOTA2_570/GetGameItems/V001/?format=XML&key={Key}&language=en_us";
            }
        }

        private static string REQ_GET_ITEM_IMAGE
        {
            get
            {
                return "http://cdn.dota2.com/apps/dota2/images/items/";
            }
        }

        public static string Key { private get; set; }

        internal static void LoadHeroes()
        {
            string heroData = new StreamReader(
                HttpWebRequest.Create(REQ_GET_HEROES)
                .GetResponse()
                .GetResponseStream())
                .ReadToEnd();

            XElement heroesXml = XElement.Parse(heroData);

            heroesXml
                .Element("heroes")
                .Elements("hero")
                .ToList()
                .ForEach(heroNode =>
                {
                    string internalName = heroNode.Element("name").Value;
                    string displayName = heroNode.Element("localized_name").Value;
                    string id = heroNode.Element("id").Value;

                    Stash.Heroes.Add(new Hero(Int32.Parse(id), internalName, displayName));
                });
        }

        internal static byte[] GetHeroImageData(string name)
        {
            WebResponse response = HttpWebRequest.Create(REQ_GET_PORTRAIT + name).GetResponse();
            byte[] result = new byte[response.ContentLength];
            using (Stream responseStream = response.GetResponseStream())
            {
                int i = 0;
                while(true)
                {
                    int data = responseStream.ReadByte();
                    if (data == -1)
                        break;
                    result[i] = (byte)data;

                    i++;
                }
            }

            return result;
        }

        internal static void LoadItems()
        {
            string itemData = new StreamReader(
                HttpWebRequest.Create(REQ_GET_ITEMS)
                .GetResponse()
                .GetResponseStream())
                .ReadToEnd();

            XElement itemsXml = XElement.Parse(itemData);

            itemsXml
                .Element("items")
                .Elements("item")
                .ToList()
                .ForEach(itemNode =>
                {
                    string id = itemNode.Element("id").Value;
                    string internalName = itemNode.Element("name").Value;
                    string displayName = itemNode.Element("localized_name").Value;
                    string cost = itemNode.Element("cost").Value;
                    string secretShop = itemNode.Element("secret_shop").Value;
                    string sideShop = itemNode.Element("side_shop").Value;
                    string recipe = itemNode.Element("recipe").Value;

                    Item item = new Item();
                    item.ID = Int32.Parse(id);
                    item.InternalName = internalName;
                    item.DisplayName = displayName;
                    item.GoldCost = Int32.Parse(cost);
                    item.SecretShop = secretShop.Equals("1");
                    item.SideShop = sideShop.Equals("1");
                    item.IsRecipe = recipe.Equals("1");

                    Stash.Items.Add(item);
                });
        }

        internal static byte[] GetItemImageData(string name)
        {
            WebResponse response = HttpWebRequest.Create(REQ_GET_ITEM_IMAGE + name).GetResponse();
            byte[] result = new byte[response.ContentLength];
            using (Stream responseStream = response.GetResponseStream())
            {
                int i = 0;
                while (true)
                {
                    int data = responseStream.ReadByte();
                    if (data == -1)
                        break;
                    result[i] = (byte)data;

                    i++;
                }
            }

            return result;
        }
    }
}
