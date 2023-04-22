using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private int plotId;
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public void Init(bool isOffset)
    {
        renderer.color = isOffset ? offsetColor : baseColor;
    }

    public void Start()
    {
        plotId = this.transform.parent.GetComponent<Farm>().plotsList.FindIndex(x => x == gameObject);
    }

    private void Update()
    {

        if (CheckTree() != 0)
        {
            CheckProduct();
        }

    }
    int CheckTree()
    {
        int treeType;
        try
        {
            treeType = UIController.Instance.GetTree(plotId).TreeType;

        }
        catch
        {
            treeType = 0;
        }

        switch (treeType)
        {
            case 0:
                if (transform.childCount > 0)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.tag.Equals("Tree"))
                        {
                            Destroy(child.gameObject);
                        }
                    }
                }
                break;
            case 1:
                bool hasTree = false;
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        hasTree = true;
                    }
                }
                if (!hasTree)
                {
                    Instantiate(Resources.Load("Prefabs/TomatoTree"), this.transform);
                }
                break;
            case 2:
                hasTree = false;
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        hasTree = true;
                    }
                }
                if (!hasTree)
                {
                    Instantiate(Resources.Load("Prefabs/BlueBerryTree"), this.transform);
                }
                break;
            case 3:
                hasTree = false;
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        hasTree = true;
                    }
                }
                if (!hasTree)
                {
                    Instantiate(Resources.Load("Prefabs/DairyCowTree"), this.transform);
                }
                break;
            case 4:
                hasTree = false;
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        hasTree = true;
                    }
                }
                if (!hasTree)
                {
                    Instantiate(Resources.Load("Prefabs/StrawBerryTree"), this.transform);
                }
                break;
        }

        return treeType;
    }

    void PlantTree()
    {
        if (CheckTree() == 0)
        {
            Debug.Log("Plot: " + plotId);
            UIController.Instance.PlantTree(plotId, 1);
        }
    }

    void CheckProduct()
    {
        try
        {
            Debug.Log(plotId + " | " + UIController.Instance.CheckProductOnTree(plotId));
            int productOnTree = UIController.Instance.CheckProductOnTree(plotId);
            if (productOnTree > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        foreach (Transform childChild in child)
                        {
                            if (childChild.CompareTag("Product"))
                            {
                                childChild.gameObject.SetActive(true);
                            }
                        }
                        //Debug.Log(child.Find("Amount").GetComponentInChildren<TextMeshProUGUI>());
                        child.Find("Amount").GetComponentInChildren<TextMeshProUGUI>().SetText(productOnTree.ToString());
                    }
                }

                //transform.Find("Amount").GetComponentInChildren<TextMeshPro>().SetText("1");

            }
            else
            {
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        foreach (Transform childChild in child)
                        {
                            if (childChild.CompareTag("Product"))
                            {
                                childChild.gameObject.SetActive(false);
                            }
                        }
                        child.Find("Amount").GetComponentInChildren<TextMeshProUGUI>().SetText(productOnTree.ToString());
                    }
                }
            }


        }
        catch
        {

        }
    }

    public void Havert()
    {
        try
        {
            UIController.Instance.Harvert(plotId);
        }
        catch
        {
        }
    }

    //private void OnMouseDown()
    //{
    //    PlantTree();
    //    Havert();
    //}

    void OnMouseEnter()
    {
        highlight.SetActive(true);

    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}