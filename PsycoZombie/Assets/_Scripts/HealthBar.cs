using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthBar : NetworkBehaviour
{
    [Header("Dependancies")]
    public HealthManager healthManager;
    public PlayerStats playerStats;

    public TMP_Text HealthTxt;
    public string HealthStr;

    [SerializeField] private Image healthbarSprite;
    [SerializeField] private float ReducedSpeed = 2f;
    private float target = 1f;
    public float maxHealth;
    public float currentHealth;


    // Update is called once per frame
    void Update()
    {
        HealthStr = currentHealth.ToString();
        HealthTxt.text = HealthStr;



        maxHealth = playerStats.maxHealth;
        currentHealth = healthManager.currentHealth.Value;

        target = currentHealth / maxHealth;

        healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, ReducedSpeed * Time.deltaTime);
    }
}
