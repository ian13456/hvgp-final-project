using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public float dropRate = 0.5f;
    public GameObject[] drop;

    public override void Die()
    {
        base.Die();

        if (drop.Length != 0)
            if (Random.Range(0.0f, 1.0f) < dropRate)
                Instantiate(RandomDrop(), transform.position, Quaternion.identity);

        // Add ragdoll effect / death animation

        Destroy(gameObject);

        // Add loot
    }

    GameObject RandomDrop()
    {
        return drop[Random.Range(0, drop.Length - 1)];
    }
}
