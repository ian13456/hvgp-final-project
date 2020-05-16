using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoseStats : EnemyStats
{
    public GameObject villain;

    public override void Die()
    {
        base.Die();

        villain.SetActive(true);

        // DO THE TRANSITIONS HERE;
    }
}
