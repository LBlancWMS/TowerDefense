using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.buildManagerInstance;
    }
    public void PurchaseTurret()
    {
        buildManager.NextTurretToBuild(buildManager.standardTurretPrefab);
    }
}
