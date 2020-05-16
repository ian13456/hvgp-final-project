using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthStatsChanger : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    CharacterStats characterStats;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        characterStats.OnHealthChanged += OnHealthChange;
        healthText.text = characterStats.maxHealth.ToString();
    }

    void OnHealthChange(int maxHealth, int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}
