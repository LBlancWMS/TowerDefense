using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(int damage)
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
            TakeDamage(100);
            other.GetComponentInParent<Bullet>().HitTarget();
        }
    }
}
