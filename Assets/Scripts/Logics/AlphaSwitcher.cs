using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaSwitcher : MonoBehaviour
{
    public float fadeSpeed = 0.4f;
    public float maxAlpha = 0.6f;

    private float spawnTime;
    private bool reversed = false;
    private Material myMaterial;

    // Use this for initialization
    void Start()
    {
        // Because `Material` is a class,
        // The following line does not create a copy of the material
        // But creates a reference (points to) the material of the renderer
        myMaterial = GetComponent<MeshRenderer>().material;
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the alpha according to the current time and the time the object has spawned
        SetAlpha((Time.time - spawnTime) * fadeSpeed);

        if (myMaterial.color.a == maxAlpha)
        {
            reversed = true;
            spawnTime = Time.time;
        }
        else if (myMaterial.color.a == 0f)
        {
            reversed = false;
            spawnTime = Time.time;
        }
    }

    void SetAlpha(float alpha)
    {
        // Here you assign a color to the referenced material,
        // changing the color of your renderer
        Color color = myMaterial.color;
        if (reversed)
            color.a = maxAlpha - Mathf.Clamp(alpha, 0, maxAlpha);
        else
            color.a = Mathf.Clamp(alpha, 0, maxAlpha);
        myMaterial.color = color;
    }
}
