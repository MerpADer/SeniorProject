using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFunctions : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

}
