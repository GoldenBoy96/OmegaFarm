using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class Player : IUpdateStatus
    {
        private string name;
        private List<PlantingPlot> plots;
        private List<Item> items;
        private int workers;
        private int coins;
        private List<DateTime> equipmentsUpgrades;
        private List<Tree> deadTrees;

        public string Name { get => name; set => name = value; }
        public int Workers { get => workers; set => workers = value; }
        public int Coins { get => coins; set => coins = value; }
        public List<DateTime> EquipmentsUpgrades { get => equipmentsUpgrades; set => equipmentsUpgrades = value; }
        internal List<PlantingPlot> Plots { get => plots; set => plots = value; }
        internal List<Item> Items { get => items; set => items = value; }
        internal List<Tree> DeadTrees { get => deadTrees; set => deadTrees = value; }

        public Player(string name)
        {
            this.name = name;
            this.workers = 1;
            this.coins = 0;
            //default item
            this.EquipmentsUpgrades = new List<DateTime>();
            this.EquipmentsUpgrades.Add(DateTime.Now);
        }

        public void UpgradeEquipment()
        {
            EquipmentsUpgrades.Add(DateTime.Now);
        }

        public void UpdateStatus()
        {
            throw new NotImplementedException();
        }
    }
}
