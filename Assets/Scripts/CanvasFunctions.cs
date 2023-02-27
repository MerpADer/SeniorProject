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

    public void ZTest(RectTransform rectTransform, int x, int y)
    {
        rectTransform.position = new Vector2(rectTransform.position.x + x, rectTransform.position.y + y);
    }

}
