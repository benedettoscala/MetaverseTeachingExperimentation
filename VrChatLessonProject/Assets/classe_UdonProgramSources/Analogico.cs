
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

using System.Collections;
using System.Collections.Generic;


public class Analogico : UdonSharpBehaviour
{
    public Material targetMaterial;
    public Color[] colors;
    private int colorIndex = 0;
    private float lastColorChangeTime;

    private void Start()
    {
        targetMaterial = GetComponent<Renderer>().material;
        if (targetMaterial == null || colors.Length == 0)
        {
            Debug.LogError("Please assign a material and at least one color in the inspector.");
            enabled = false;
            return;
        }

        targetMaterial.color = colors[colorIndex];
        lastColorChangeTime = Time.time;
    }

    private void Update()
    {
        // Check if a second has passed since the last color change
        if (Time.time - lastColorChangeTime >= 1f)
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            targetMaterial.color = colors[colorIndex];
            lastColorChangeTime = Time.time;
        }
    }
}
