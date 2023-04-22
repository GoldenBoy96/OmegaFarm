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

        public bool PlantTree(string itemName)
        {
            for (int i = 0; i < player.Plots.Count; i++)
            {
                if (player.Plots[i].Tree == null)
                {
                    if (player.Inventory.GetItemNumber(itemName) > 0)
                    {
                        Item item = new Item(itemName);
                        PlantTree(i, item.TreeType);
                        player.Inventory.Get(1, itemName);
                        return true;
                    }
                }
            }
            return false;
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

        public bool BuyPlot()
        {
            if (player.Coins >= 500)
            {
                player.Coins -= 500;
                player.Plots.Add(new PlantingPlot());
                return true;
            }
            return false;
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
            if (player.Plots[plot].Tree.HavertedNumber >= player.Plots[plot].Tree.MaxProduct)
            {
                player.Plots[plot].RemoveTree();
                
            }
            ItemSlot harvert = player.Plots[plot].Tree.Havert();
            player.Inventory.Put(harvert.Name, harvert.Amount);
            return harvert;
        }

        public void UpgradeEquipment()
        {
            player.UpgradeEquipment();
        }

        public int GetItemNumber(string itemName)
        {
            return player.Inventory.GetItemNumber(itemName);
        }

        public int GetPlayerCoin()
        {
            return player.Coins;
        }

        public void Sell(string itemName)
        {
            try
            {
                player.Coins += player.Inventory.GetPrice(itemName) * player.Inventory.Get(itemName).Amount;

            }
            catch
            {

            }
        }
    }
}
