using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion   

    public GameObject player;

    Animator animator;

    void Start()
    {
        animator = player.GetComponentInChildren<Animator>();
    }

    public void KillPlayer()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        animator.SetBool("isDead", true);
        player.GetComponent<PlayerController>().SetDead();

        StartCoroutine(PlayerDeath());
    }

    IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(5f);
        // Change Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
