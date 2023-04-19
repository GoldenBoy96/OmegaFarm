using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using static UnityEditor.Progress;

namespace Assets.Scripts.Game
{
    internal class Inventory
    {
        public class Slot
        {
            public Item Item { get; set; }
            public int Amount;

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

        public void Put(Item item, int amount)
        {
            bool itemExisted = false;
            for(int i = 0; i < slots.Count; i++)
            {
                if (item.Name.Equals(slots[i].Item.Name))
                {
                    slots[i].Amount += amount;
                    itemExisted = true;
                    break;
                }
            }
            if (!itemExisted)
            {
                slots.Add(new Slot(item, amount));
            }
        }
        //public void Put(Item item, int number, int slot)
        //{

        //}

        public Slot Get(int number, int slot) 
        {
            Slot result;
            if (slots[slot].Amount > number)
            {
                result = new(slots[slot].Item, number);
                slots[slot].Amount -= number;
            } 
            else
            {
                result = new(slots[slot].Item, number);
                slots.Remove(slots[slot]);
            }
            
            return result;
        }

        public Slot Get(int slot)
        {
            Slot result = new(slots[slot].Item, slots[slot].Amount);
            slots.Remove(slots[slot]);
            return result;
        }
        
    }
}
