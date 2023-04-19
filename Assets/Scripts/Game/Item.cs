using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class Item 
    {
        private string name;
        private int sellPrice;
        private bool isPlantable;
        private int treeType;

        public int SellPrice { get => sellPrice; set => sellPrice = value; }
        public bool IsPlantable { get => isPlantable; set => isPlantable = value; }
        public int TreeType { get => treeType; set => treeType = value; }
        public string Name { get => name; set => name = value; }

        public Item(string name)
        {
            this.name = name;
            List<Item> itemDataSheet = ReadCSVConfigFile();
            foreach(Item item in itemDataSheet)
            {
                if (name.Equals(item.Name))
                {
                    sellPrice = item.SellPrice;
                    isPlantable = item.IsPlantable;
                    treeType = item.treeType;
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

        public static void WriteCSVConfigFile()
        {
            List<Item> defaultItem = new List<Item>();
            CSV.WriteFile("Config/Item.csv", defaultItem);
        }

        public static List<Item> ReadCSVConfigFile()
        {
            return CSV.ReadFile<Item>("Config/Item.csv");
        }
    }
}
