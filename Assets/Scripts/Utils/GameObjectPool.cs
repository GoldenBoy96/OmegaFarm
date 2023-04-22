using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    private Stack<GameObject> _pool = new Stack<GameObject>();

    public void CreatePool(GameObject prefab, int number) 
    {
        if(number >= 0)
        {
            _pool = new Stack<GameObject>();
            for (int i = 0; i < number; i++)
            {
                GameObject gameObject = Instantiate(prefab);                
                Push(gameObject);
            }
        } 
        else
        {
            Debug.Log("Out of range!");
        }
    }

    public void CreatePool(GameObject prefab, int number, Transform parent)
    {
        if (number >= 0)
        {
            _pool = new Stack<GameObject>();
            for (int i = 0; i < number; i++)
            {
                GameObject gameObject = Instantiate(prefab);
                gameObject.transform.parent = parent;
                Push(gameObject);
            }
        }
        else
        {
            Debug.Log("Out of range!");
        }
    }

    public void Push(GameObject gameObject)
    {
        gameObject.SetActive(false);
        _pool.Push(gameObject);
    }

    public GameObject Pop()
    {
        if (_pool.Count > 0)
        {
            _pool.Peek().SetActive(true);
            return _pool.Pop();
        }
        else
        {
            Debug.Log("Pool empty!");
            return null;
        }
    }
}
