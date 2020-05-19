using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : EnemyStats
{
    public TransitionController transitionController;
    public float delay = 3f;

    public override void Die()
    {
        if (drop.Length != 0)
            if (Random.Range(0.0f, 1.0f) < dropRate)
                Instantiate(base.RandomDrop(), transform.position, Quaternion.identity);

        // DO THE TRANSITIONS HERE;
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        damage.RemoveModifier(-100);
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        yield return new WaitForSeconds(delay);

        // Transition to TO BE CONTINUED
        transitionController.FadeToLevel(5);

        Destroy(gameObject);
    }
}
