using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class ItemShop : ItemSlot
    {
        private ItemSlot shopItems;
        private int price;

        public ItemSlot ShopItems { get => shopItems; set => shopItems = value; }
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
