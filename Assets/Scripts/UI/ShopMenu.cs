using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
