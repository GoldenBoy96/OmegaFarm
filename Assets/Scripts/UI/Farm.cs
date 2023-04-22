using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Farm : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private GameObject plotPrefab;

    [SerializeField] private Transform cam;

    private Dictionary<Vector2, GameObject> plots;

    public GameObjectPool plotPool;

    public List<GameObject> plotsList = new();

    void Start()
    {
        plotPool = transform.AddComponent<GameObjectPool>();
        GenerateGrid();
    }

    private void Update()
    {
        
    }

    public void ExpandFarm()
    {
        if(UIController.Instance.BuyPlot())
        {
            plotPool.Pop();
        }
    }

    

    void GenerateGrid()
    {
        plots = new Dictionary<Vector2, GameObject>();
        for (int y = width; y > 0; y--)
        {
            for (int x = 0; x < height; x++)
            {
                GameObject spawnedPlot = Instantiate(plotPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedPlot.name = $"Plot {x} {y}";
                spawnedPlot.transform.parent = transform;
                plotsList.Add(spawnedPlot);                

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedPlot.GetComponent<Plot>().Init(isOffset);


                plots[new Vector2(x, y)] = spawnedPlot;
            }
        }

        for (int i = plotsList.Count - 1; i >= 0; i--)
        {
            plotPool.Push(plotsList[i]);
        }

        for (int i = 0; i < UIController.Instance.GetPlots().Count; i++)
        {
            plotPool.Pop();
        }

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        cam.transform.position += new Vector3(0, 7, 0);
        
    }

    public GameObject GetPlotAtPosition(Vector2 pos)
    {
        if (plots.TryGetValue(pos, out var plot)) return plot;
        return null;
    }
}