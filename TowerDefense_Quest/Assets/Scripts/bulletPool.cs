using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPool : MonoBehaviour
{
    public static bulletPool bulletPoolInstance;

    public GameObject bulletPrefab;
    public int poolSize = 10;
    public bool willGrow;

    private List<Bullet> pooledBullets;

    private void Awake()
    {
        bulletPoolInstance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        pooledBullets = new List<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledBullets.Add(obj.GetComponent<Bullet>());
        }
    }

    public Bullet GetBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].gameObject.activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            Bullet newBullet = obj.GetComponent<Bullet>();
            pooledBullets.Add(newBullet);
            return newBullet;
        }

        return null;
    }

    public void ReturnToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}