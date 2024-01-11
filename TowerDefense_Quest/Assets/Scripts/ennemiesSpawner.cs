using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiesSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform[] waypoints;
    private int poolSize = 500;
    public float spawnRate = 0.2f;

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
                objectPool[i].transform.position = waypoints[0].position;
                objectPool[i].transform.position = new Vector3(objectPool[i].transform.position.x, 3f, objectPool[i].transform.position.z);
                objectPool[i].transform.rotation = transform.rotation;
                objectPool[i].SetActive(true);
                return;
            }
        }
    }

    public void IncreaseWaves()
    {
            spawnRate *= 1.2f;
    }

    public void returnToPool(GameObject ennemi)
    {
        ennemi.transform.position = waypoints[0].position;
        ennemi.transform.rotation = transform.rotation;
        ennemi.GetComponent<ennemiesMovement>().ResetWaypoints();
        ennemi.SetActive(false);
    }
}
