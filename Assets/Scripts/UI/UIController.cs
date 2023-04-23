using Assets.Scripts.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = Assets.Scripts.Game.Tree;

public class UIController : MonoBehaviour, IGameController, IUpdateStatus
{
    public static UIController Instance { get; private set; }

    GameController gameController = new GameController();

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        //Player.WriteConfigFile();

        //Debug.Log(Tree.ReadConfigFile());

        //GameController.GenerateDefaultConfigFile();



        gameController = new GameController();
        OnLoad();

        InvokeRepeating("UpdateStatus", 0, 0.1f);
    }

    public void UpdateStatus()
    {       
        
        gameController.Player.UpdateStatus();
        WokerWork();
        if (IsEndGame())
        {
            Debug.Log("You Win!");
        }
        gameController.SaveData();
    }


    public Tree GetTree(int plot)
    {
        return gameController.GetTree(plot);
    }

    public void PlantTree(int plot, int treeType)
    {
        gameController.PlantTree(plot, treeType);
    }

    public PlantingPlot GetPlot(int plot)
    {
        return gameController.GetPlot(plot);
    }

    public List<PlantingPlot> GetPlots()
    {
        //Debug.Log(gameController.GetPlots().Count);
        return gameController.GetPlots();
    }

    public bool BuyPlot()
    {
        return gameController.BuyPlot();
    }

    public int CheckProductOnTree(int plot)
    {
        return gameController.CheckProductOnTree(plot);
    }

    public ItemSlot Harvert(int plot)
    {
        return gameController.Harvert(plot);
    }

    public void UpgradeEquipment()
    {
        gameController.UpgradeEquipment();
    }

    public int GetItemNumber(string itemName)
    {
        return gameController.GetItemNumber(itemName);
    }

    public bool PlantTree(string itemName)
    {
        //Debug.Log(itemName);
        //Debug.Log(new Item(itemName).TreeType);
        return gameController.PlantTree(itemName);
    }

    public int GetPlayerCoin()
    {
        return gameController.GetPlayerCoin();
    }

    public void Sell(string itemName)
    {
        gameController.Sell(itemName);
    }

    public void Buy(string itemName)
    {
        gameController.Buy(itemName);
    }

    public ItemShop GetItemShop(string itemName)
    {
        return gameController.GetItemShop(itemName);
    }

    public void WokerWork()
    {
        Debug.Log(gameController.Player.Workers[0].PreviousWorkTime);
        Debug.Log((DateTime.Now - gameController.Player.Workers[0].PreviousWorkTime));
        //Debug.Log(gameController.Player.Workers[0].Work());


        gameController.WokerWork();
        //Debug.Log(DateTime.Now.Subtract( gameController.Player.Workers[0].PreviousWorkTime).Minutes);
    }

    public int GetWorkerNumber()
    {
        return gameController.Player.Workers.Count;
    }

    public int GetUpgradeLevel()
    {
        return gameController.Player.EquipmentsUpgrades.Count;
    }
    public void HireWorker()
    {
        gameController.HireWorker();
    }

    public bool IsEndGame()
    {
        return gameController.IsEndGame();
    }

        public void OnLoad()
    {
        gameController.OnLoad();
    }
}
