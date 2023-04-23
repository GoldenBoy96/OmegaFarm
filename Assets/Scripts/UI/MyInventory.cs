using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyInventory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ToggleInventory();
    }


    public void ToggleInventory()
    {
        GameObject inventory = transform.Find("Inventory").gameObject;
        if (inventory.active)
        {
            inventory.SetActive(false);
            transform.Find("ToggleInventory").GetComponentInChildren<TextMeshProUGUI>().SetText("Open");
        }
        else
        {
            inventory.SetActive(true);
            transform.Find("ToggleInventory").GetComponentInChildren<TextMeshProUGUI>().SetText("Close");
        }
    }
}
