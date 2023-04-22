using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class PlantingPlot : IUpdateStatus
    {
        private Tree tree;

        public static float price = 500;

        public Tree Tree { get => tree; set => tree = value; }

        public PlantingPlot()
        {
            this.tree = null;
        }

        public PlantingPlot(Tree tree)
        {
            this.tree = tree;
        }

        public void Plant(Tree tree)
        {
            if (tree != null)
            {
                Tree = tree;
            }
        }

        public void RemoveTree()
        {
            Tree = null;
        }

        public override string ToString()
        {
            return $"{{{nameof(Tree)}={Tree}}}";
        }

        public void UpdateStatus()
        {

            if(tree.IsDead())
            {
                RemoveTree();
            }
        }
    }
}
