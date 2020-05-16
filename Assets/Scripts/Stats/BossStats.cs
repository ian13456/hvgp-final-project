using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoseStats : EnemyStats
{
    public GameObject villain;
    public float delay = 5f;

    public override void Die()
    {
        base.Die();

        // DO THE TRANSITIONS HERE;
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        villain.SetActive(true);
        yield return new WaitForSeconds(delay);

        // Transition to TO BE CONTINUED
    }
}
