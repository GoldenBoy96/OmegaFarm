using System;
using System.Collections.Generic;
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
    }
}
