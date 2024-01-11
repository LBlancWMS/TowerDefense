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

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    public GameObject GetTurretToBuild() { return turretToBuild; }
}
