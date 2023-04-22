using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    class GameController : IGameController
    {
        private Player player;
        private Shop shop;

        internal Player Player { get => player; set => player = value; }
        internal Shop Shop { get => shop; set => shop = value; }

        public GameController()
        {
            player = LoadData();
            if (player == null)
            {
                player = new Player("Meow", 0);
                SaveData();
            }
            shop = new Shop();
        }
        public GameController(Player player, Shop shop)
        {
            this.player = player;
            this.shop = shop;
        }

        public void PlantTree(int plot, int treeType)
        {
            player.Plots[plot].Plant(new Tree(treeType));
        }

        public Tree GetTree(int plot)
        {
            return player.Plots[plot].Tree;
        }

        public PlantingPlot GetPlot(int plot)
        {
            return player.Plots[plot];
        }
        public List<PlantingPlot> GetPlots()
        {
            return player.Plots;
        }

        public void BuyPlot()
        {
            player.Plots.Add(new PlantingPlot());
        }

        public void SaveData()
        {
            JSON.SaveData(player, "Data/Player.json");
        }

        public Player LoadData()
        {
            return JSON.ReadData<Player>("Data/Player.json");
        }

        public static void GenerateDefaultConfigFile()
        {
            Item.WriteConfigFile();
            Tree.WriteConfigFile();
            Player.WriteConfigFile();
            Shop.WriteConfigFile();
            Worker.WriteConfigFile();
        }

        public override string ToString()
        {
            return $"{{}}";
        }

        public int CheckProductOnTree(int plot)
        {
            return player.Plots[plot].Tree.OnTreeNumber;
        }

        public ItemSlot Harvert(int plot)
        {
           return player.Plots[plot].Tree.Havert();
        }
    }
}
