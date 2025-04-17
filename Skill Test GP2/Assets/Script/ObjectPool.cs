using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> pooledObject=new List<GameObject>();

    [SerializeField] int amount;
    [SerializeField] GameObject pooledObjects;
    [SerializeField] double maxDistance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(pooledObjects);
            obj.SetActive(false);
            pooledObject.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0;i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
            else if (pooledObject[i].transform.position.x>maxDistance|| pooledObject[i].transform.position.z > maxDistance)
            {
                pooledObject[i].SetActive(false);
            }
        }
        return null;
    }

}

