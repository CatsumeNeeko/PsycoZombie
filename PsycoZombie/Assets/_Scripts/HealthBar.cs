using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
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
        currentHealth = healthManager.currentHealth;

        target = currentHealth / maxHealth;

        healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, ReducedSpeed * Time.deltaTime);
    }
}
