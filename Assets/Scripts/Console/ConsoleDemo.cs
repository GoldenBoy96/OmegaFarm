using Assets.Scripts.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tree = Assets.Scripts.Game.Tree;

public class ConsoleDemo : MonoBehaviour
{
    Tree tree;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player("Meow");
        tree = new Tree(1, new Item(), 0.1f, 40);
    }

    // Update is called once per frame
    void Update()
    {
        tree.CreateProduct(player.EquipmentsUpgrades);
        //Debug.Log(tree.OnTreeNumber);
    }

    public void Havert()
    {
        int havert = tree.Havert();
        Debug.Log("Havert:" + havert);
        player.Coins += havert;
        Debug.Log("Product:" + player.Coins);
    }

    public void OnTreeNumber()
    {
        Debug.Log("Tree:" + tree.OnTreeNumber);
    }

    public void Upgrade()
    {
        player.UpgradeEquipment();
        Debug.Log(player.EquipmentsUpgrades.Count);
    }
}
