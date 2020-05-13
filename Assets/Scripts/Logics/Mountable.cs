using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(WanderController))]
public class Mountable : Interactable
{
    public PlayerController playerController;
    public WanderController wanderController;
    public NavMeshAgent navMeshAgent;

    void Start()
    {
        playerController = PlayerManager.instance.player.GetComponent<PlayerController>();
    }

    public override void Interact()
    {
        base.Interact();

        if (playerController.isMounted)
            UnmountPlayer();
        else
            MountPlayer();
    }

    void MountPlayer()
    {
        playerController.Mount(this);
        navMeshAgent.updateRotation = true;
        wanderController.Disable();
    }

    void UnmountPlayer()
    {
        playerController.Unmount();
        navMeshAgent.updateRotation = false;
        wanderController.Enable();
    }

    public void MoveToPoint(Vector3 point)
    {
        navMeshAgent.SetDestination(point);
        wanderController.SetTarget(point);
    }
}
