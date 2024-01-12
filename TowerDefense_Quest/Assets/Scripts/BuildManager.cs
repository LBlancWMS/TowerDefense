using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManagerInstance;

    public GameObject standardTurretPrefab;
    private TurretBlueprint turretToBuild;
    public Base baseScript;

    public bool canBuild { get { return turretToBuild != null; } }

    #region
    private void Awake()
    {
        if (buildManagerInstance != null)
        {
            return;
        }

        buildManagerInstance = this;
    }
#endregion

    public void BuildTurretOn(Node node)
    {
        if (baseScript.GetCurrentGold() < turretToBuild.cost)
        {
            return;
        }

        GameObject turret = Instantiate(turretToBuild.prefab, node.transform.position + node.offset, Quaternion.identity);
        node.turret = turret;

        baseScript.payGolds(turretToBuild.cost);
    }
    public void NextTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    
}
