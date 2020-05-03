using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    EnemyStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<EnemyStats>();
    }

    public override void Interact()
    {
        base.Interact();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        Debug.Log("damn");

        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
        // Attack the enemy
    }
}
