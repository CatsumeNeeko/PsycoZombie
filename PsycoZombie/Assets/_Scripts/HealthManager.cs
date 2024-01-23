using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Dependancies")]
    public PlayerStats stats;
    [Header("HealthStats")]
    public float currentHealth;

    void Start()
    {
        currentHealth = stats.maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    public void HealDamage(float damage)
    {
        currentHealth += damage;
        if (currentHealth > stats.maxHealth)
        {
            currentHealth = stats.maxHealth;
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HealDamage(10f);
        }
    }
}
