using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_InGame_Manager : MonoBehaviour
{
    [SerializeField] private GameObject pause_Menu;
    public void SetPause()
    {
        GameObject menu = Instantiate(pause_Menu);
        menu.SetActive(true);
    }
}
