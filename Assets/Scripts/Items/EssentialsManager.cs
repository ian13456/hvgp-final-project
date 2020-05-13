using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

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
    public TextMeshProUGUI countText;
    public TextMeshProUGUI releaseText;
    public AudioClip bossLevel;
    public AudioSource bgm;
    public InventoryUI inventory;
    public Vector3 offset;

    PlayerManager playerManager;
    CameraController cameraController;

    int essentialsCount = 0;
    string baseCountText = "Field Disruptors Needed: ";
    string releaseMessage = "T-REX BOSS RELEASED!";

    void Start()
    {
        playerManager = PlayerManager.instance;
        cameraController = Camera.main.gameObject.GetComponent<CameraController>();

        UpdateCounts();
    }

    public void Apply(Essential newItem)
    {
        essentialsCount++;
        UpdateCounts();

        if (essentialsCount == essentialsRequirement)
        {
            // Camera Transition
            Destroy(countText);
            StartCoroutine(ReleaseRex());
            StartCoroutine(ReleaseAlert());
        }
    }

    IEnumerator ReleaseRex()
    {
        cameraController.isTransitioning = true;
        cameraController.transform.position = rex.transform.position + offset;
        cameraController.transform.LookAt(rex.position);
        bgm.clip = bossLevel;
        bgm.Play();
        inventory.Toggle();

        yield return new WaitForSeconds(2f);

        Destroy(forceField.gameObject);
        rex.GetComponent<NavMeshAgent>().enabled = true;
        rex.GetComponent<WanderController>().enabled = true;

        yield return new WaitForSeconds(3f);

        cameraController.isTransitioning = false;
    }

    IEnumerator ReleaseAlert()
    {
        foreach (char c in releaseMessage)
        {
            releaseText.text += c;
            yield return new WaitForSeconds(0.125f);
        }

        yield return new WaitForSeconds(2f);

        Destroy(releaseText);
    }

    void UpdateCounts()
    {
        countText.text = baseCountText + (essentialsRequirement - essentialsCount);
    }
}
