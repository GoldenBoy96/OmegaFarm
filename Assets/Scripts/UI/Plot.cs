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
    [SerializeField] private SpriteRenderer renderer;
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
            treeType = PlayerController.Instance.GetTree(plotId).TreeType;

        }
        catch (Exception e)
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
                    if (child.tag.Equals("Tree"))
                    {
                        hasTree = true;
                    }
                }
                if (!hasTree) {
                    //Debug.Log(Resources.Load("Prefabs/TomatoTree"));
                    Instantiate(Resources.Load("Prefabs/TomatoTree"), this.transform);
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
            PlayerController.Instance.PlantTree(plotId, 1);
        }
    }

    void CheckProduct()
    {
        try
        {
            Debug.Log(plotId + " | " + PlayerController.Instance.CheckProductOnTree(plotId));
            int productOnTree = PlayerController.Instance.CheckProductOnTree(plotId);
            if (productOnTree > 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.CompareTag("Tree"))
                    {
                        foreach(Transform childChild in child)
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

    private void Havert()
    {
        PlayerController.Instance.Harvert(plotId);
    }

    private void OnMouseDown()
    {
        PlantTree();
        Havert();
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
        
    }

    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}