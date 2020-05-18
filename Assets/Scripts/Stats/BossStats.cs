using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStats : EnemyStats
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
        SceneManager.LoadScene(5);

        // Transition to TO BE CONTINUED
    }
}
