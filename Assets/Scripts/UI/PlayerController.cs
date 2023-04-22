using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = Assets.Scripts.Game.Tree;

public class PlayerController : MonoBehaviour, IGameController, IUpdateStatus
{
    public static PlayerController Instance { get; private set; }

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
        return gameController.GetPlots();
    }

    public void BuyPlot()
    {
        gameController.BuyPlot();
    }

    public int CheckProductOnTree(int plot)
    {
        return gameController.CheckProductOnTree(plot);
    }

    public ItemSlot Harvert(int plot)
    {
        return gameController.Harvert(plot);
    }

    
}
