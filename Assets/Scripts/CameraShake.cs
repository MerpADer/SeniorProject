using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }

    private CinemachineVirtualCamera cineCamera;
    private CinemachineBasicMultiChannelPerlin perlin;
    private float timer;

    private void Awake()
    {
        Instance = this;
        cineCamera = GetComponent<CinemachineVirtualCamera>();
        perlin = cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                perlin.m_AmplitudeGain = 0;
            }
        }
    }

    public void Shake(float frequency, float intensity, float timer)
    {
        perlin.m_AmplitudeGain = intensity;
        perlin.m_FrequencyGain = frequency;
        this.timer = timer;
    }

}
