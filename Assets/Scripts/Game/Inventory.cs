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
        

        private List<ItemSlot> slots;
        private int numberOfSlot;

        public List<ItemSlot> Slots { get => slots; set => slots = value; }
        public int NumberOfSlot { get => numberOfSlot; set => numberOfSlot = value; }

        public Inventory()
        {
            this.slots = new List<ItemSlot>();
        }

        public Inventory (List<ItemSlot> slots)
        {
            this.Slots = slots;
        }
        public Inventory(int numberOfSlot)
        {
            Slots = new(numberOfSlot);
            this.NumberOfSlot = numberOfSlot;
        }

        public void Put(string item, int amount)
        {
            bool itemExisted = false;
            for(int i = 0; i < Slots.Count; i++)
            {
                if (item.Equals(Slots[i].Name))
                {
                    Slots[i].Amount += amount;
                    itemExisted = true;
                    break;
                }
            }
            if (!itemExisted)
            {
                Slots.Add(new ItemSlot(item, amount));
            }
        }
        //public void Put(Item item, int number, int slot)
        //{

        //}

        public ItemSlot Get(int number, int slot) 
        {
            ItemSlot result;
            if (Slots[slot].Amount > number)
            {
                result = new(Slots[slot].Name, number);
                Slots[slot].Amount -= number;
            } 
            else
            {
                result = new(Slots[slot].Name, number);
                Slots.Remove(Slots[slot]);
            }
            
            return result;
        }

        public ItemSlot Get(int slot)
        {
            ItemSlot result = new(Slots[slot].Name, Slots[slot].Amount);
            Slots.Remove(Slots[slot]);
            return result;
        }

        public override string ToString()
        {
            return $"{{{nameof(Slots)}={Slots}, {nameof(NumberOfSlot)}={NumberOfSlot.ToString()}}}";
        }
    }
}
