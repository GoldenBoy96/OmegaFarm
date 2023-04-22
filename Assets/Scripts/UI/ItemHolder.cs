using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowItemNumber();
    }

    void ShowItemNumber()
    {
        //Debug.Log(transform.Find("Amount"));
        transform.Find("Amount").GetComponent<TextMeshProUGUI>().SetText(GetItemNumber().ToString());


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
