using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManagerInstance;

    public GameObject standardTurretPrefab;
    private GameObject turretToBuild;

    private void Awake()
    {
        if (buildManagerInstance != null)
        {
            return;
        }

        buildManagerInstance = this;
    }

    public void NextTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
    public GameObject GetTurretToBuild() { return turretToBuild; }
}
