using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class Inventory
    {
        public struct Slot
        {
            public Item Item { get; set; }
            public int Amount { get; set; }

            public Slot(Item item, int amount)
            {
                Item = item;
                Amount = amount;
            }

            public override string ToString() => $"({Item}, {Amount})";
        }

        private List<Slot> slots;
        private int numberOfSlot;

        public Inventory (List<Slot> slots)
        {
            this.slots = slots;
        }
        public Inventory(int numberOfSlot)
        {
            slots = new();
            this.numberOfSlot = numberOfSlot;
        }

        public void Put(Item item, int number)
        {

        }
        public void Put(Item item, int number, int slot)
        {

        }

        
    }
}
