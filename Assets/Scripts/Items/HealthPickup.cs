using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    public int minHealthModifier;
    public int maxHealthModifier;

    int healthModifier;
    PlayerManager playerManager;

    void Start()
    {
        healthModifier = Random.Range(minHealthModifier, maxHealthModifier);
        playerManager = PlayerManager.instance;
    }

    public override void Interact()
    {
        base.Interact();

        Apply();
    }

    void Apply()
    {
        playerManager.player.GetComponent<CharacterStats>().AddHealth(healthModifier);
        Destroy(gameObject);
    }
}
