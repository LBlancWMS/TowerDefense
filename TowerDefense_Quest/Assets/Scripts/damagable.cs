using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ResetHealth();
        GameObject baseObject = GameObject.FindGameObjectWithTag("Base");
        baseObject.GetComponent<Base>().EarnGold(1);
        ReturnToPool();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    private void ReturnToPool()
    {
        GameObject.FindGameObjectWithTag("ennemiesSpawner").GetComponent<ennemiesSpawner>().returnToPool(gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(2);
            other.GetComponentInParent<Bullet>().HitTarget();
        }
    }
}
