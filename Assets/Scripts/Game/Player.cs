using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    internal class Player : IUpdateStatus, IPredictEvent 
    {
        private string name;
        private int defaultId;
        private List<PlantingPlot> plots;
        private Inventory inventory;
        private List<Worker> workers;
        private int coins;
        private List<DateTime> equipmentsUpgrades;
        private List<Tree> deadTrees;

        public string Name { get => name; set => name = value; }
        public int DefaultId { get => defaultId; set => defaultId = value; }
        public List<PlantingPlot> Plots { get => plots; set => plots = value; }
        public Inventory Inventory { get => inventory; set => inventory = value; }
        public List<Worker> Workers { get => workers; set => workers = value; }
        public int Coins { get => coins; set => coins = value; }
        public List<DateTime> EquipmentsUpgrades { get => equipmentsUpgrades; set => equipmentsUpgrades = value; }
        public List<Tree> DeadTrees { get => deadTrees; set => deadTrees = value; }

        public Player()
        {
        }

        private Player(string name)
        {
            this.Name = name;
            this.DefaultId = 0;
            this.Workers = new();
            this.Coins = 0;
            this.EquipmentsUpgrades = new();
            this.Plots = new();
            this.DeadTrees = new();
            this.Inventory = new(100);
        }

        public Player(string name, int defaultId)
        {
            this.Name = name;
            List<Player> playerDataSheet = Player.ReadConfigFile();
            foreach (Player player in playerDataSheet)
            {
                if (defaultId == player.DefaultId)
                {
                    this.DefaultId = defaultId;
                    this.Workers = player.Workers;
                    for (int i = 0; i < Workers.Count; i++)
                    {
                        Workers[i] = new Worker(Workers[i].Type);
                    }
                    this.Coins = player.Coins;
                    this.EquipmentsUpgrades = player.EquipmentsUpgrades;
                    this.Plots = player.Plots;
                    this.DeadTrees = new();
                    this.Inventory = player.Inventory;
                    for (int i = 0; i < Inventory.Slots.Count; i++)
                    {
                        Inventory.Slots[i] = new ItemSlot(Inventory.Slots[i].Name, Inventory.Slots[i].Amount);
                    }
                }
            }
        }

        public Player(string name, List<Worker> workers, int coins, List<DateTime> equipmentsUpgrades, List<PlantingPlot> plots, List<Tree> deadTrees, Inventory inventory) : this(name)
        {
            Workers = workers;
            Coins = coins;
            EquipmentsUpgrades = equipmentsUpgrades;
            Plots = plots;
            DeadTrees = deadTrees;
            Inventory = inventory;
        }

        public void UpgradeEquipment()
        {
            EquipmentsUpgrades.Add(DateTime.Now);
        }

        public void UpdateStatus()
        {
            foreach (PlantingPlot plot in Plots)
            {
                try
                {
                    plot.Tree.CreateProduct(EquipmentsUpgrades);
                    plot.UpdateStatus();
                }
                catch
                {

                }
            }
            
        }

        public void UpdateStatus(DateTime time)
        {
            foreach (PlantingPlot plot in Plots)
            {
                try
                {
                    plot.Tree.CreateProduct(EquipmentsUpgrades, time);
                    plot.UpdateStatus(time);
                }
                catch
                {

                }
            }
        }

        public List<DateTime> GetPredictEvent(DateTime time)
        {
            List<DateTime> result = new List<DateTime>();
            foreach(PlantingPlot plot in Plots)
            {
                if (plot.Tree != null)
                {
                    result.AddRange(plot.Tree.GetPredictEvent(time));
                }
            }
            foreach(Worker worker in Workers)
            {
                result.AddRange(worker.GetPredictEvent(time));
            }
            result.Sort();
            return result;
        }
        public static void WriteConfigFile()
        {
            List<Player> defaultPlayer = new();
            Player player = new("Hi");
            player.Coins = 100;

            player.Workers = new(100);
            player.Workers.Add(new Worker(1));

            player.Plots = new(100);
            player.Plots.Add(new PlantingPlot());
            player.Plots.Add(new PlantingPlot());
            player.Plots.Add(new PlantingPlot());

            player.Inventory = new(100);

            player.Inventory.Put("TomatoSeed", 10);
            player.Inventory.Put("BlueBerrySeed", 10);
            player.Inventory.Put("DairyCowSeed", 2);

            player.EquipmentsUpgrades = new();
            player.EquipmentsUpgrades.Add(DateTime.Now);

            player.DeadTrees = new();

            defaultPlayer.Add(player);

            JSON.SaveData(defaultPlayer, "Config/Player.json");
        }

        public static List<Player> ReadConfigFile()
        {
            return JSON.ReadData<List<Player>>("Config/Player.json");
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(DefaultId)}={DefaultId.ToString()}, {nameof(Plots)}={Plots}, {nameof(Inventory)}={Inventory}, {nameof(Workers)}={Workers}, {nameof(Coins)}={Coins.ToString()}, {nameof(EquipmentsUpgrades)}={EquipmentsUpgrades}, {nameof(DeadTrees)}={DeadTrees}}}";
        }

        
    }
}
