using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSFX : MonoBehaviour
{
    AudioSource sfx;

    void Start()
    {
        sfx = gameObject.GetComponent<AudioSource>();
    }

    public void Click()
    {
        sfx.Play();
        Debug.Log("SHIT");
    }
}
