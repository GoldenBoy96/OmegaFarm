using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class ItemSlot : Item
    {
        private int amount;
        public int Amount { get => amount; set => amount = value; }

        public ItemSlot()
        {
        }

        public ItemSlot(string name, int amount) : base(name)
        {
            Amount = amount;
        }


        public override string ToString() => $"({base.ToString()}, {Amount})";
    }
}
