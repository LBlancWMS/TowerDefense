using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private UI_InGame_Manager UI_inGame;
    [SerializeField] private int timer = 120;
    [SerializeField] private Defeat_Menu defeat_menu;
    private ennemiesSpawner spawner;
    [SerializeField] private Victory_Menu victory_Menu;
    private int golds = 0;

    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("ennemiesSpawner").GetComponent<ennemiesSpawner>();
        UI_inGame.SetHPText(health);
        UI_inGame.SetTimerText(timer);
        Invoke("OverrideStart", 1f);
    }

    public void EarnGold(int amount)
    {
        golds += amount;
        UI_inGame.SetGoldsValue(golds);
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
            UI_inGame.SetTimerText(timer);
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
            victory_Menu.gameObject.SetActive(true);
            Debug.Log("victoire");
            Time.timeScale = 0;
            Destroy(this);
    }
    public void takeDMG(int damages)
    {
        health -= damages;
        UI_inGame.SetHPText(health);
        if(health <= 0)
        {
            Instantiate(defeat_menu);
            defeat_menu.gameObject.SetActive(true);
            Debug.Log("partie perdue");
            Time.timeScale = 0;
            Destroy(this);
        }
    }

    public void payGolds(int goldToPay)
    {
        golds -= goldToPay;
        UI_inGame.SetGoldsValue(golds);
    }

    public int getHealth()
    {
        return health;
    }
}
