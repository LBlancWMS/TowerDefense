using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame_Manager : MonoBehaviour
{
    [SerializeField] private GameObject pause_Menu;
    [SerializeField] private Text hp_Text;
    [SerializeField] private Text timer_Text;
    [SerializeField] private Text golds_Text;

    public void SetPause()
    {
        GameObject menu = Instantiate(pause_Menu);
        menu.SetActive(true);
    }

    public void SetHPText(int currentHP)
    {
        hp_Text.GetComponent<Text>().text = currentHP.ToString() + " Points de vie";
    }

    public void SetGoldsValue(int goldValues)
    {
        golds_Text.GetComponent<Text>().text = golds_Text.ToString() + " Golds";
    }

    public void SetTimerText(int timeRemaining)
    {
        if (timeRemaining >= 0)
        {
            int minutes = timeRemaining / 60;
            int seconds = timeRemaining % 60;

            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
            timer_Text.text = timerString + " restant";
        }
    }
}
