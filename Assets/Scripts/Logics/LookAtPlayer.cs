using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
    }

    void FacePlayer()
    {
        Vector3 direction = (playerManager.player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
        Vector3 rot = lookRotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y - 180f, rot.z);
        lookRotation = Quaternion.Euler(rot);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
