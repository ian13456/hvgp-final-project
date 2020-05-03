using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioClip[] audioSources;

    public float minSoundDelay = 1f;
    public float maxSoundDelay = 10f;

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        float delay = Random.Range(minSoundDelay, maxSoundDelay);
        yield return new WaitForSeconds(delay);
        RandomSoundness();
    }

    void RandomSoundness()
    {
        AudioClip clip = audioSources[Random.Range(0, audioSources.Length)];
        AudioSource.PlayClipAtPoint(clip, transform.position, 10f);
    }
}
