using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]

public class GlowingObject : MonoBehaviour
{

    private Light2D light2D;

    // moves us along the x of the sin function
    private float timer;

    [SerializeField] float howLong;

    [SerializeField] float intensityChange;

    // how much the intensity will be moved by in the end
    private float sinVariable;

    // initial intensity
    private float startIntensity;

    void Awake()
    {
        light2D = GetComponent<Light2D>();
        startIntensity = light2D.intensity;
    }

    void Update()
    {
        timer += Time.deltaTime;
        // each variable affects the transformations of the sin function
        sinVariable = intensityChange * Mathf.Sin(timer * (2 * Mathf.PI / howLong)) + intensityChange;
        light2D.intensity = sinVariable + startIntensity;
    }
}
