using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    [SerializeField] List<AudioClip> sceneIndexMusic;

    private AudioClip currentTrack;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        currentTrack = sceneIndexMusic[SceneManager.GetActiveScene().buildIndex];
        audioSource.clip = currentTrack;
        audioSource.Play();
    }

    //// these 3 methods do stuff when we load a new scene
    //void OnEnable()
    //{
    //    //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
    //    SceneManager.sceneLoaded += OnLevelFinishedLoading;
    //}

    //void OnDisable()
    //{
    //    //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
    //    SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    //}

    //// if I have to do something at the very start a new scene, do it here
    //void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    //{
    //    if (sceneIndexMusic[SceneManager.GetActiveScene().buildIndex] != currentTrack)
    //    {
    //        currentTrack = sceneIndexMusic[SceneManager.GetActiveScene().buildIndex];
    //        audioSource.clip = currentTrack;
    //    }
    //}

}
