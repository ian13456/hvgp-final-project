using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EssentialsManager : MonoBehaviour
{
    #region Singleton
    public static EssentialsManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public int essentialsRequirement = 1;
    public Transform forceField;
    public Transform rex;

    int essentialsCount = 0;

    public void Apply(Essential newItem)
    {
        essentialsCount++;

        if (essentialsCount == essentialsRequirement)
        {
            Destroy(forceField.gameObject);
            rex.GetComponent<NavMeshAgent>().enabled = true;
            rex.GetComponent<WanderController>().enabled = true;
        }
    }
}
