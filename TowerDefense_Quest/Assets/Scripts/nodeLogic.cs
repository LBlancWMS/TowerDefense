using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color colorOnSlot;

    public Vector3 offset;
    public GameObject turret;
    private Color startColor;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.buildManagerInstance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if (turret != null)
        {
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        rend.material.color = colorOnSlot;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
