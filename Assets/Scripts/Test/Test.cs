using Assets.Scripts.Game;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = Assets.Scripts.Game.Tree;
using Newtonsoft.Json;

public class Test : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        //player = new Player("Meow");
        //player.Inventory.Put(new Item("BlueBerry"), 100);

        //PlantingPlot plantingPlot = new();
        //plantingPlot.Plant(new Tree(1, new Item("BlueBerry"), 0.1f, 40));
        //player.Plots.Add(plantingPlot);
        //Debug.Log(player.Inventory.Get(0).Item.SellPrice);

        Item.WriteConfigFile();
        Tree.WriteConfigFile();
        Player.WriteConfigFile();
        Shop.WriteConfigFile();
        Worker.WriteConfigFile();

        //Debug.Log(new Item("BlueBerry").ToString());
        //Debug.Log(new Tree(1).ToString());
        Debug.Log(Player.ReadConfigFile()[0]);
    }

    // Update is called once per frame
    void Update()
    {
        //player.Plots[0].Tree.CreateProduct(player.EquipmentsUpgrades);
        //Debug.Log(player.Plots[0].Tree);
    }

    public void Havert()
    {
        int havert = player.Plots[0].Tree.Havert().Amount;
        Debug.Log("Havert:" + havert);
        player.Coins += havert;
        Debug.Log("Product:" + player.Coins);
    }

    public void OnTreeNumber()
    {
        Debug.Log("Tree:" + player.Plots[0].Tree.OnTreeNumber);
        //Debug.Log(player);
        //string json = JsonConvert.SerializeObject(player);
        //Debug.Log(json);
        JSON.SaveData(player, "Data/Player.txt");
    }

    public void Upgrade()
    {
        player.UpgradeEquipment();
        Debug.Log(player.EquipmentsUpgrades.Count);
    }
}
