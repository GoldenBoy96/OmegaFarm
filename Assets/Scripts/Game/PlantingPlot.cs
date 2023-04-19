﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class PlantingPlot 
    {
        private Tree tree;

        public Tree Tree { get => tree; set => tree = value; }

        public PlantingPlot()
        {
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

        public void Remote()
        {
            Tree = null;
        }
    }
}
