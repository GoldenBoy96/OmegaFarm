using Assets.Scripts.Game;
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
        InvokeRepeating("UpdateStatus", 0, 0.1f);
    }

    public void UpdateStatus()
    {
        try
        {
            Debug.Log(gameController.Player.Plots[3].Tree.IsDead());
        }
        catch
        {

        }

        gameController.Player.UpdateStatus();
        gameController.SaveData();
    }

    void Update()
    {
        
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
        Debug.Log(gameController.GetPlots().Count);
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
        Debug.Log(itemName);
        Debug.Log(new Item(itemName).TreeType);
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
}
