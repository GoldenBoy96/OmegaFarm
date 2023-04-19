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
        private Inventory inventory;
        private int workers;
        private int coins;
        private List<DateTime> equipmentsUpgrades;
        private List<Tree> deadTrees;

        public string Name { get => name; set => name = value; }
        public int Workers { get => workers; set => workers = value; }
        public int Coins { get => coins; set => coins = value; }
        public List<DateTime> EquipmentsUpgrades { get => equipmentsUpgrades; set => equipmentsUpgrades = value; }
        public List<PlantingPlot> Plots { get => plots; set => plots = value; }
        public List<Tree> DeadTrees { get => deadTrees; set => deadTrees = value; }
        internal Inventory Inventory { get => inventory; set => inventory = value; }

        public Player(string name)
        {
            this.name = name;
            this.workers = 1;
            this.coins = 0;
            this.plots = new();
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
