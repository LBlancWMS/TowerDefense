using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color colorOnSlot;

    public Vector3 offset;
    private GameObject turret;
    private Color startColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("a");
            return;
        }

        GameObject turretToBuild = BuildManager.buildManagerInstance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = colorOnSlot;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
