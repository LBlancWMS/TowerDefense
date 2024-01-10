
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    public float range = 10f;

    public string enemyTag = "Enemy";
    public Transform turretPartRotation;

    public float turnSpeed = 7f;

    public float fireRate = 1f;
    private float fireCooldown = 0f;

    public GameObject projectile;
    public Transform firePoint;


    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    
    private void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion look = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turretPartRotation.rotation, look, Time.deltaTime * turnSpeed).eulerAngles;
        turretPartRotation.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCooldown <= 0)
        {
            Shoot();
            fireCooldown = 1 / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        bulletPool bulletPoolInstance = bulletPool.bulletPoolInstance;
        Bullet projectileShot = bulletPoolInstance.GetBullet();

        if (projectileShot != null)
        {
            projectileShot.transform.position = firePoint.position;
            projectileShot.gameObject.SetActive(true);
            projectileShot.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
