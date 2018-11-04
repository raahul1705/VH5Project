using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePool : MonoBehaviour {
    public static NotePool instance;
    public GameObject objectToPool;
    public List<GameObject> pooledObjects;
    public int amountToPool;
    public bool shouldExpand = true;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
	}
	
	public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }

        else
        {
            return null;
        }
    }
}
