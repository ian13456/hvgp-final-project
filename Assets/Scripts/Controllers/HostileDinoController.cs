using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileDinoController : EnemyController
{
    WanderController wander;

    new void Start()
    {
        base.Start();
        wander = GetComponent<WanderController>();
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            wander.Disable();
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }

            }
            wander.FaceTarget(target.position);
        }
        else
        {
            wander.Enable();
        }
    }
}
