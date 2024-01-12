using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.buildManagerInstance;
    }
    public void SelectTurret()
    {
        buildManager.NextTurretToBuild(standardTurret);
    }
}
