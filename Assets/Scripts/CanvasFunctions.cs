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

    public void LoadScene(string str)
    {
        sceneEditor = FindObjectOfType<SceneEditor>();

        sceneEditor.WrapperNextScene(str);
    }

}
