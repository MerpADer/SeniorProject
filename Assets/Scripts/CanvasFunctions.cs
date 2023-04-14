using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFunctions : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;

    private SceneEditor sceneEditor;

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    public void LoadScene(int scene)
    {
        sceneEditor = FindObjectOfType<SceneEditor>();

        sceneEditor.NextScene(scene);
    }

}
