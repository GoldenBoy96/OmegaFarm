using Assets.Scripts.Utils;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    public class Item 
    {
        private string name;
        private int sellPrice;
        private bool isPlantable;
        private int treeType;

        [Index(0)]
        public string Name { get => name; set => name = value; }
        [Index(1)]
        public int SellPrice { get => sellPrice; set => sellPrice = value; }
        [Index(2)]
        public bool IsPlantable { get => isPlantable; set => isPlantable = value; }
        [Index(3)]
        public int TreeType { get => treeType; set => treeType = value; }

        public Item()
        {
        }

        public Item(string name)
        {
            this.name = name;
            List<Item> itemDataSheet = ReadConfigFile();
            if (itemDataSheet == null)
            {
                WriteConfigFile();
                ReadConfigFile();
            }
            foreach(Item item in itemDataSheet)
            {
                if (name.Equals(item.Name))
                {
                    sellPrice = item.SellPrice;
                    isPlantable = item.IsPlantable;
                    treeType = item.treeType;
                    break;
                }
            }
        }

        public Item(string name, int sellPrice)
        {
            this.name = name;
            this.sellPrice = sellPrice;
            this.isPlantable = false;
            this.treeType = 0;
        }

        public Item(string name, int sellPrice, int treeType) : this(name, sellPrice)
        {
            this.treeType = treeType;
            this.isPlantable = true;
        }

        public static void WriteConfigFile()
        {
            List<Item> defaultItem = new List<Item>();
            defaultItem.Add(new("TomatoSeed", 1, 1));
            defaultItem.Add(new("Tomato", 5));
            defaultItem.Add(new("BlueBerrySeed", 1, 2));
            defaultItem.Add(new("BlueBerry", 8));
            defaultItem.Add(new("DairyCowSeed", 50, 3));
            defaultItem.Add(new("Milk", 15));
            defaultItem.Add(new("StrawBerrySeed", 10, 4));
            defaultItem.Add(new("StrawBerry", 5));

            CSV.WriteFile("Config/Item.csv", defaultItem);
        }

        public static List<Item> ReadConfigFile()
        {
            return CSV.ReadFile<Item>("Config/Item.csv");
        }

        

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(SellPrice)}={SellPrice.ToString()}, {nameof(IsPlantable)}={IsPlantable.ToString()}, {nameof(TreeType)}={TreeType.ToString()}}}";
        }
    }
}
