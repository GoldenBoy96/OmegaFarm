using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal interface IGameController
    {
        public void PlantTree(int plot, int treeType);

        public Tree GetTree(int plot);

        public PlantingPlot GetPlot(int plot);
        public List<PlantingPlot> GetPlots();

        public void BuyPlot();

        public int CheckProductOnTree(int plot);

        public ItemSlot Harvert(int plot);
    }
}
