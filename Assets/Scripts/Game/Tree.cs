﻿using Assets.Scripts.Utils;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Game
{
    public class Tree 
    {
        private int treeType;
        private Item product;
        private float cooldownTime; //minutes
        private int maxProduct;
        private int onTreeNumber;
        private int havertedNumber;
        private DateTime plantedTime;
        private DateTime previousProductTime;

        [Index(0)]
        public int TreeType { get => treeType; set => treeType = value; }
        [Index(1)]
        public Item Product { get => product; set => product = value; }
        [Index(2)]
        public float CooldownTime { get => cooldownTime; set => cooldownTime = value; }
        [Index(3)]
        public int MaxProduct { get => maxProduct; set => maxProduct = value; }
        [Index(4)]
        public int OnTreeNumber { get => onTreeNumber; set => onTreeNumber = value; }
        [Index(5)]
        public int HavertedNumber { get => havertedNumber; set => havertedNumber = value; }
        [Index(6)]
        public DateTime PlantedTime { get => plantedTime; set => plantedTime = value; }
        [Index(7)]
        public DateTime PreviousProductTime { get => previousProductTime; set => previousProductTime = value; }

        public Tree()
        {
        }

        public Tree (int treeType)
        {
            this.TreeType = treeType;
            List<Tree> treeDataSheet = ReadConfigFile();
            if (treeDataSheet == null)
            {
                WriteConfigFile();
                ReadConfigFile();
            }
            foreach(Tree tree in treeDataSheet)
            {
                if (this.TreeType == tree.TreeType)
                {
                    this.Product = tree.Product;
                    this.CooldownTime = tree.CooldownTime;
                    this.MaxProduct = tree.MaxProduct;
                    this.OnTreeNumber = 0;
                    this.HavertedNumber = 0;
                    this.PlantedTime = DateTime.Now;
                    this.PreviousProductTime = PlantedTime;
                    break;
                }
            }
        }

        public Tree(int treeType, Item product, float cooldownTime, int maxProduct)
        {
            this.TreeType = treeType;
            this.Product = product;
            this.CooldownTime = cooldownTime;
            this.MaxProduct = maxProduct;
            this.OnTreeNumber = 0;
            this.HavertedNumber = 0;
            this.PlantedTime = DateTime.Now;
            this.PreviousProductTime = DateTime.Now;
        }

        

        public ItemSlot Havert()
        {
            int havertNumber = OnTreeNumber;
            HavertedNumber += OnTreeNumber;
            OnTreeNumber = 0;
            return new ItemSlot(this.product.Name, havertNumber);
        }

        public void CreateProduct(List<DateTime> equipmentsUpgrades)
        {
            TimeSpan deltaTime = new TimeSpan();
            if (OnTreeNumber + HavertedNumber < MaxProduct)
            {
                int currentUpgradeEquipment = 0;
                if (DateTime.Compare(PreviousProductTime, DateTime.Now) < 0)
                {
                    if (equipmentsUpgrades.Count == 1)
                    {
                        deltaTime = TimeSpan.FromMinutes(CooldownTime);
                    }
                    else
                    {
                        for (int i = equipmentsUpgrades.Count - 1; i >= currentUpgradeEquipment; i--)
                        {
                            if (DateTime.Compare(equipmentsUpgrades[i], PreviousProductTime) <= 0)
                            {
                                currentUpgradeEquipment = i;
                            }
                        }
                        if (currentUpgradeEquipment == equipmentsUpgrades.Count - 1)
                        {
                            deltaTime = TimeSpan.FromMinutes(CooldownTime / Math.Pow(1.1f, currentUpgradeEquipment));
                        }
                        else
                        {
                            deltaTime = TimeSpan.FromMinutes(CooldownTime / Math.Pow(1.1f, currentUpgradeEquipment));
                            for (int i = currentUpgradeEquipment + 1; i < equipmentsUpgrades.Count; i++)
                            {
                                if (PreviousProductTime + deltaTime > equipmentsUpgrades[i])
                                {
                                    deltaTime = equipmentsUpgrades[i].Subtract(PreviousProductTime)
                                        + equipmentsUpgrades[i].Subtract(PreviousProductTime) / Math.Pow(1.1f, i);
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                    if (PreviousProductTime + deltaTime > DateTime.Now)
                    {
                        
                    }
                    else
                    {
                        OnTreeNumber++;
                        PreviousProductTime += deltaTime;
                    }



                }
            }
            
        }

        
        public bool IsDead()
        {
            if (HavertedNumber + OnTreeNumber == MaxProduct)
            {
                if (DateTime.Now.Subtract(previousProductTime).Minutes >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        public static void WriteConfigFile()
        {
            List<Tree> defaultTree = new();
            defaultTree.Add(new(1, new("Tomato"), 10, 40));
            defaultTree.Add(new(2, new("BlueBerry"), 15, 40));
            defaultTree.Add(new(3, new("Milk"), 30, 100));
            defaultTree.Add(new(3, new("StrawBerry"), 5, 20));

            JSON.SaveData(defaultTree,"Config/Tree.json");
        }

        public static List<Tree> ReadConfigFile()
        {
            return JSON.ReadData<List<Tree>>("Config/Tree.json");
        }

        public override string ToString()
        {
            return $"{{{nameof(TreeType)}={TreeType.ToString()}, {nameof(CooldownTime)}={CooldownTime.ToString()}, {nameof(MaxProduct)}={MaxProduct.ToString()}, {nameof(OnTreeNumber)}={OnTreeNumber.ToString()}, {nameof(HavertedNumber)}={HavertedNumber.ToString()}, {nameof(PlantedTime)}={PlantedTime.ToString()}, {nameof(Product)}={Product}, {nameof(PreviousProductTime)}={PreviousProductTime.ToString()}}}";
        }

      
    }
}
