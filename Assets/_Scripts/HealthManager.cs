using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HealthManager : NetworkBehaviour
{
    [Header("Dependancies")]
    public PlayerStats stats;
    [Header("HealthStats")]
    public NetworkVariable<float> currentHealth = new NetworkVariable<float>(default,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);

    void Start()
    {
        currentHealth.Value = stats.maxHealth;
    }
    [ClientRpc]
    public void TakeDamageClientRpc(float damage)
    {
        if(!IsOwner) return;    
        currentHealth.Value -= damage;
        if (currentHealth.Value <= 0f)
        {
            Die();
        }
    }
    [ClientRpc]
    public void HealDamageClientRpc(float damage)
    {
        currentHealth.Value += damage;
        if (currentHealth.Value > stats.maxHealth)
        {
            currentHealth.Value = stats.maxHealth;
            SyncHealthClientRpc(currentHealth.Value);
        }
    }
    [ClientRpc]
    private void SyncHealthClientRpc(float newHealthValue)
    {
        // Modify the health variable on all clients
        currentHealth.Value = newHealthValue;
    }
    private void Die()
    {
        Destroy(gameObject);
    }


    
    public void Update()
    {
        if (!IsOwner) return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamageClientRpc(10f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            HealDamageClientRpc(10f);
        }
    }
}
