using UnityEngine;

public class Health : MonoBehaviour, IHitable
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount, DamageEffectType effectType)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //TODO EFECTS
        Destroy(gameObject);
    }
}