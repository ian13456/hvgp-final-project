using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WanderController : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Vector3 latestPos;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private bool isDisabled = false;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;

        agent.updateRotation = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isDisabled)
        {

            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
                SetTarget(newPos);
            }
        }
        FaceTarget(latestPos);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    void FaceTarget(Vector3 position)
    {
        Vector3 direction = (position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        Vector3 rot = lookRotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y - 90, rot.z);
        lookRotation = Quaternion.Euler(rot);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void Disable()
    {
        isDisabled = true;
    }

    public void Enable()
    {
        isDisabled = false;
    }

    public void SetTarget(Vector3 targetPos)
    {
        latestPos = targetPos;
    }
}
