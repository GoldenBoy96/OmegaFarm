using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    internal class Tree : IUpdateStatus
    {
        private int treeType;
        private Item product;
        private float cooldownTime; //minutes
        private int maxProduct;
        private int onTreeNumber;
        private int havertedNumber;
        private DateTime plantedTime;
        private DateTime previousProductTime;

        public int TreeType { get => treeType; set => treeType = value; }
        public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }
        public int MaxProduct { get => maxProduct; set => maxProduct = value; }
        public int OnTreeNumber { get => onTreeNumber; set => onTreeNumber = value; }
        public int HavertedNumber { get => havertedNumber; set => havertedNumber = value; }
        public DateTime PlantedTime { get => plantedTime; set => plantedTime = value; }
        public Item Product { get => product; set => product = value; }
        public DateTime PreviousProductTime { get => previousProductTime; set => previousProductTime = value; }

        public Tree(int treeType, Item product, float cooldownTime, int maxProduct)
        {
            this.treeType = treeType;
            this.product = product;
            this.cooldownTime = cooldownTime;
            this.maxProduct = maxProduct;
            this.onTreeNumber = 0;
            this.havertedNumber = 0;
            this.plantedTime = DateTime.Now;
            this.previousProductTime = DateTime.Now;
        }

        public void UpdateStatus()
        {
            KillTree();
        }

        public int Havert()
        {
            int havert = OnTreeNumber;
            HavertedNumber += OnTreeNumber;
            OnTreeNumber = 0;
            return havert;
        }

        public void CreateProduct(List<DateTime> equipmentsUpgrades)
        {
            TimeSpan deltaTime = new TimeSpan();
            if (onTreeNumber + HavertedNumber < MaxProduct)
            {
                int currentUpgradeEquipment = 0;
                while (DateTime.Compare(previousProductTime, DateTime.Now) < 0)
                {
                    if (equipmentsUpgrades.Count == 1)
                    {
                        deltaTime = TimeSpan.FromMinutes(cooldownTime);
                    }
                    else
                    {
                        for (int i = equipmentsUpgrades.Count - 1; i >= currentUpgradeEquipment; i--)
                        {
                            if (DateTime.Compare(equipmentsUpgrades[i], previousProductTime) <= 0)
                            {
                                currentUpgradeEquipment = i;
                            }
                        }
                        if (currentUpgradeEquipment == equipmentsUpgrades.Count - 1)
                        {
                            deltaTime = TimeSpan.FromMinutes(cooldownTime / Math.Pow(1.1f, currentUpgradeEquipment));
                        }
                        else
                        {
                            deltaTime = TimeSpan.FromMinutes(cooldownTime / Math.Pow(1.1f, currentUpgradeEquipment));
                            for (int i = currentUpgradeEquipment + 1; i < equipmentsUpgrades.Count; i++)
                            {
                                if (previousProductTime + deltaTime > equipmentsUpgrades[i])
                                {
                                    deltaTime = equipmentsUpgrades[i].Subtract(previousProductTime)
                                        + equipmentsUpgrades[i].Subtract(previousProductTime) / Math.Pow(1.1f, i);
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                    if (previousProductTime + deltaTime > DateTime.Now)
                    {
                        break;
                    }
                    else
                    {
                        onTreeNumber++;
                        previousProductTime += deltaTime;
                    }



                }
            }
            
        }

        public void KillTree()
        {
            if (DateTime.Now.Subtract(PlantedTime).Minutes >= MaxProduct * CooldownTime + 60)
            {
                Console.WriteLine("Tree dead!");
            }
        }


    }
}
