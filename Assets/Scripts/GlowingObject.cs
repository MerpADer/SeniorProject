using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]

public class GlowingObject : MonoBehaviour
{

    private Light2D light2D;

    private float timer;

    [SerializeField] float howLong;

    [SerializeField] float intensityChange;

    private float sinVariable;

    private float startIntensity;

    void Awake()
    {
        light2D = GetComponent<Light2D>();
        startIntensity = light2D.intensity;
    }

    void Update()
    {
        timer += Time.deltaTime;
        sinVariable = intensityChange * Mathf.Sin(timer * (2 * Mathf.PI / howLong)) + intensityChange;
        light2D.intensity = sinVariable + startIntensity;
    }
}
