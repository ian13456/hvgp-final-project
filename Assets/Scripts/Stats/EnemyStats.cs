using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // public Equipment drop;
    // public GameObject dropsParent;

    public override void Die()
    {
        base.Die();

        // if (drop != null)
        //     Instantiate(drop.lootPrefab, transform.position, Quaternion.identity);

        // Add ragdoll effect / death animation

        Destroy(gameObject);

        // Add loot
    }
}
