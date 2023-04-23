using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    internal interface IGameController
    {
        public void PlantTree(int plot, int treeType);

        public bool PlantTree(string itemName);

        public Tree GetTree(int plot);

        public PlantingPlot GetPlot(int plot);
        public List<PlantingPlot> GetPlots();

        public bool BuyPlot();

        public int CheckProductOnTree(int plot);

        public ItemSlot Harvert(int plot);

        public void UpgradeEquipment();

        public int GetItemNumber(string itemName);

        public int GetPlayerCoin();

        public void Sell(string itemName);

        public void Buy(string itemName);

        public ItemShop GetItemShop(string itemName);

        public void WokerWork();
        public void HireWorker();

        public void OnLoad();

        public bool IsEndGame();
    }
}
