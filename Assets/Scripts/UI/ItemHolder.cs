using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    int itemHolderType; //1) Inventory    2) Shop
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name.Equals("Inventory"))
        {
            itemHolderType = 1;
        }
        else if (transform.parent.name.Equals("Shop"))
        {
            itemHolderType = 2;
        }

        if (itemHolderType == 2)
        {
            ShowPrice();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (itemHolderType == 1)
        {
            ShowItemNumber();
        }
    }

    void ShowItemNumber()
    {
        //Debug.Log(transform.Find("Amount"));
        transform.Find("Amount").GetComponent<TextMeshProUGUI>().SetText(GetItemNumber().ToString());
    }

    void ShowPrice()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Item"))
            {
                transform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(
                            UIController.Instance.GetItemShop(child.name).Price.ToString() + "c/"
                            + UIController.Instance.GetItemShop(child.name).Amount.ToString()
                            );
            }
        }
        
    }

    public void Plant()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Item"))
            {
                UIController.Instance.PlantTree(child.name);
            }
        }

    }

    public void Sell()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Item"))
            {
                UIController.Instance.Sell(child.name);
            }
        }

    }

    public void Buy()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Item"))
            {
                UIController.Instance.Buy(child.name);
            }
        }
    }

    int GetItemNumber()
    {
        try
        {
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Item"))
                {
                    return UIController.Instance.GetItemNumber(child.name);
                }
            }
        }
        catch
        {

        }

        return 0;
    }
}
