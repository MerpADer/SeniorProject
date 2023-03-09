using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    [SerializeField] List<MusicItem> sceneIndexMusic;

    private AudioClip currentTrack;
    private AudioSource audioSource;
    private int sceneIndex;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();

        currentTrack = sceneIndexMusic[sceneIndex].mainTrack;
        audioSource.clip = currentTrack;
        audioSource.Play();

        CheckData();
    }

    void SetNewTrack()
    {
        audioSource.clip = sceneIndexMusic[sceneIndex].secondaryTrack;
        audioSource.Play();
        audioSource.loop = true;
    }

    void CheckData()
    {
        if (sceneIndexMusic[SceneManager.GetActiveScene().buildIndex].isLooping)
        {
            audioSource.loop = true;
        }
        else
        {
            Invoke(nameof(SetNewTrack), sceneIndexMusic[sceneIndex].mainTrack.length);
        }
    }

    // these 3 methods do stuff when we load a new scene
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    // if I have to do something at the very start a new scene, do it here
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (sceneIndexMusic[SceneManager.GetActiveScene().buildIndex].mainTrack != currentTrack)
        {
            currentTrack = sceneIndexMusic[SceneManager.GetActiveScene().buildIndex].mainTrack;
            audioSource.clip = currentTrack;
            audioSource.Play();
            CancelInvoke();
            CheckData();
        }
    }

}
