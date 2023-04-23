using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ToggleShop();
    }

    // Update is called once per frame
    void Update()
    {
        ShowPlayerCoin();
    }

    public void ShowPlayerCoin()
    {
        transform.Find("Coin").Find("Text").GetComponent<TextMeshProUGUI>().SetText(UIController.Instance.GetPlayerCoin().ToString());
    }

    public void ToggleShop()
    {
        GameObject shop = transform.Find("Shop").gameObject;
        if (shop.active)
        {
            shop.SetActive(false);
        }
        else
        {
            shop.SetActive(true);
        }
    }
}
