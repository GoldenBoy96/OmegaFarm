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

        public int GetPrice(string itemName)
        {
            try
            {

                return Slots[GetItemIndex(itemName)].SellPrice;
            }
            catch
            {
                return 0;
            }
        }

        public ItemSlot Get(int number, string itemName)
        {
            ItemSlot result;
            int itemIndex = GetItemIndex(itemName);
            if (itemIndex >= 0)
            {
                if (Slots[itemIndex].Amount > number)
                {
                    result = new(Slots[itemIndex].Name, number);
                    Slots[itemIndex].Amount -= number;
                }
                else
                {
                    result = new(Slots[itemIndex].Name, number);
                    Slots.Remove(Slots[itemIndex]);
                }
                return result;
            }           

            return null;
        }

        public ItemSlot Get(int slot)
        {
            ItemSlot result = new(Slots[slot].Name, Slots[slot].Amount);
            Slots.Remove(Slots[slot]);
            return result;
        }

        public ItemSlot Get(string itemName)
        {
            int itemIndex = GetItemIndex(itemName);
            if (itemIndex >= 0)
            {
                ItemSlot result = new(Slots[itemIndex].Name, Slots[itemIndex].Amount);
                Slots.Remove(Slots[itemIndex]);
                return result;
            }
            return null;
        }

        public int GetItemNumber(string itemName)
        {
            foreach(ItemSlot slot in Slots)
            {
                if (slot.Name.Equals(itemName)) {
                    return slot.Amount;
                }
            }
            return 0;
        }

        private int GetItemIndex(string itemName)
        {
            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i].Name.Equals(itemName))
                {
                    return i;
                }
            }
            return -1;
        }
        public override string ToString()
        {
            return $"{{{nameof(Slots)}={Slots}, {nameof(NumberOfSlot)}={NumberOfSlot.ToString()}}}";
        }
    }
}
