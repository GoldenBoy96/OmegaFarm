using Assets.Scripts.Utils;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class Shop
    {
        
        private List<ItemShop> shopItems;

        [Index(0)]
        public List<ItemShop> ShopItems { get => shopItems; set => shopItems = value; }

        public Shop()
        {
            ShopItems = ReadConfigFile() ;
        }

        public static void WriteConfigFile()
        {
            List<ItemShop> defaultItemShop = new();
            defaultItemShop.Add(new ItemShop("TomatoSeed", 1, 30));
            defaultItemShop.Add(new ItemShop("BlueBerrySeed", 1, 50));
            defaultItemShop.Add(new ItemShop("DairyCowSeed", 1, 100));
            defaultItemShop.Add(new ItemShop("StrawBerrySeed", 10, 400));

            JSON.SaveData(defaultItemShop, "Config/Shop.json");
        }

        public static List<ItemShop> ReadConfigFile()
        {
            return JSON.ReadData<List<ItemShop>>("Config/Shop.json");
        }

        public override string ToString()
        {
            return $"{{{nameof(ShopItems)}={ShopItems}}}";
        }

        public ItemSlot Buy(Item item, Player player)
        {
            foreach(ItemShop x in ShopItems)
            {
                if (item.Name.Equals(x.ShopItems.Name))
                {

                    break;
                }
            }
            return null;
        }
    }
}
