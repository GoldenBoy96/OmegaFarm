using Assets.Scripts.Utils;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    class GameController :  IGameController
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
            else
            {
                for (int i = 0; i < player.Workers.Count; i++)
                {
                    player.Workers[i] = new Worker(player.Workers[i].Type);
                }
                for (int i = 0; i < player.Inventory.Slots.Count; i++)
                {
                    player.Inventory.Slots[i] = new ItemSlot(player.Inventory.Slots[i].Name, player.Inventory.Slots[i].Amount);
                }
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
            if (player.Coins >= 500)
            {
                player.Coins -= 500;
                player.UpgradeEquipment();
            }
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

        public void Buy(string itemName)
        {
            if (player.Coins >= shop.GetPrice(itemName))
            {
                ItemShop itemBuy = shop.Buy(itemName);
                player.Coins -= itemBuy.Price;
                player.Inventory.Put(itemBuy.Name, itemBuy.Amount);
            }
        }

        public ItemShop GetItemShop(string itemName)
        {
            return shop.GetItemShop(itemName);
        }

        public void WokerWork()
        {
            foreach (Worker worker in player.Workers)
            {
                try
                {
                    string work = worker.Work();

                    if (work != null)
                    {
                        
                        int count = 0;
                        bool isWorked = false;
                        while (!isWorked)
                        {
                            count++;
                            if (count >= 10)
                            {
                                isWorked = true;
                            }

                            switch (work)
                            {
                                case "Havert":
                                    for (int i = 0; i < player.Plots.Count; i++)
                                    {
                                        if (player.Plots[i].Tree != null)
                                        {
                                            if (player.Plots[i].Tree.OnTreeNumber > 0 || player.Plots[i].Tree.HavertedNumber >= player.Plots[i].Tree.MaxProduct)
                                            {
                                                if (player.Plots[i].Tree.HavertedNumber >= player.Plots[i].Tree.MaxProduct)
                                                {
                                                    player.Plots[i].RemoveTree();
                                                }
                                                else
                                                {
                                                    Harvert(i);
                                                }
                                                isWorked = true;
                                                break;
                                            }
                                        }

                                    }
                                    if (!isWorked)
                                    {
                                        work = "Plant";
                                    }
                                    break;
                                case "Plant":
                                    for (int i = 0; i < player.Plots.Count; i++)
                                    {
                                        if (player.Plots[i].Tree == null)
                                        {
                                            foreach (ItemSlot slot in player.Inventory.Slots)
                                            {
                                                if (slot.IsPlantable)
                                                {
                                                    PlantTree(i, player.Inventory.Get(1, slot.Name).TreeType);
                                                    isWorked = true;
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }



                }
                catch
                {

                }
            }
        }
    }
}
