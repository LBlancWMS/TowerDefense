using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiesSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int poolSize = 10;
    public float spawnRate = 1.0f;

    private List<GameObject> objectPool;
    private float nextSpawnTime;

    void Start()
    {
        InitializeObjectPool();
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnFromPool();
            nextSpawnTime = Time.time + 1.0f / spawnRate;
        }
    }

    void InitializeObjectPool()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefabToSpawn);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    void SpawnFromPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                objectPool[i].transform.position = transform.position;
                objectPool[i].transform.rotation = transform.rotation;
                objectPool[i].SetActive(true);
                return;
            }
        }

        GameObject newObj = Instantiate(prefabToSpawn);
        newObj.SetActive(false);
        objectPool.Add(newObj);
    }
}
