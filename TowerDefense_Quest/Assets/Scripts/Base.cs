using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int health = 10;
    private int timer = 60;
    [SerializeField] private Defeat_Menu defeat_menu;
    private ennemiesSpawner spawner;
    [SerializeField] private Victory_Menu victory_Menu;
    private int golds = 0;

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("ennemiesSpawner").GetComponent<ennemiesSpawner>();
        Invoke("OverrideStart", 3f);
    }

    public void EarnGold(int amount)
    {
        golds++;
    }

    public int GetCurrentGold()
    {
        return golds;
    }

    void OverrideStart()
    {
        StartCoroutine(IncreaseWaves());
        StartCoroutine(TimeCounter());
    }

    private IEnumerator IncreaseWaves()
    {
        while (true)
        {
            spawner.IncreaseWaves();
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator TimeCounter()
    {
        while (true)
        {
            timer --;
            if (timer <= 0f)
            {
                TimerExpired();
            }
            yield return new WaitForSeconds(1f);
        }
    }


    void TimerExpired()
    {
            Instantiate(victory_Menu);
            Debug.Log("victoire");
            Destroy(this);
    }
    public void takeDMG(int damages)
    {
        health -= damages;

        if(health <= 0)
        {
            Instantiate(defeat_menu, new Vector3(0,0,0), Quaternion.identity);
            Debug.Log("partie perdue");
            Destroy(this);
        }
    }

    public int getHealth()
    {
        return health;
    }
}
