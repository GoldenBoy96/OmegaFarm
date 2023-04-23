using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowWorkerNumber();
        ShowUpgradeLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWorkerNumber()
    {
        transform.Find("WorkerNumber").GetComponent<TextMeshProUGUI>().SetText("Worker: " + UIController.Instance.GetWorkerNumber());
    }

    public void ShowUpgradeLevel()
    {
        transform.Find("UpgradeLevel").GetComponent<TextMeshProUGUI>().SetText("Upgrade Level: " + UIController.Instance.GetUpgradeLevel());
    }
}
