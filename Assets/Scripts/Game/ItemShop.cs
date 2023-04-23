using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class ItemShop : ItemSlot
    {
        private ItemSlot shopItems;
        private int price;

        [Index(0)]
        public ItemSlot ShopItems { get => shopItems; set => shopItems = value; }
        [Index(1)]
        public int Price { get => price; set => price = value; }

        public ItemShop(string name, int amount, int price) : base(name, amount)
        {
            ShopItems = new ItemSlot(name, amount);
            Price = price;
        }


        public override string ToString()
        {
            return $"{{{nameof(ShopItems)}={ShopItems}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
