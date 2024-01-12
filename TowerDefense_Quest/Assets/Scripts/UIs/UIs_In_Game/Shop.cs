using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint upgradedStandardTurret;
    public TurretBlueprint laserTurret;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.buildManagerInstance;
    }
    public void SelectStandardTurret()
    {
        buildManager.NextTurretToBuild(standardTurret);
    }
    public void SelectLaserTurret()
    {
        buildManager.NextTurretToBuild(laserTurret);
    }
    public void SelectUpgradedStandardTurret()
    {
        buildManager.NextTurretToBuild(upgradedStandardTurret);
    }
}
