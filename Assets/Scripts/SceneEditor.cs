using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{
    public Animator anim;

    // private SceneEnder sceneEnder;
    //private int SceneEnderNum;

    private bool firstLoad;

    public List<RoomData> Rooms;

    private void Start()
    {
        firstLoad = true;
        DontDestroyOnLoad(gameObject);
        // sceneEnder = FindSceneEnder();
        // SceneEnderNum = sceneEnder.SceneNum;
    }

    private void Update()
    {
        //if (sceneEnder == null && firstLoad)
        //{
        //    firstLoad = false;
        //    fadeOut();
        //}
    }

    //public void fadeOut()
    //{
    //    anim.SetBool("IsFadedOut", true);
    //    Invoke(nameof(fadeIn), 2f);
    //}

    //public void fadeIn()
    //{
    //    anim.SetBool("IsFadedOut", false);
    //    NextScene(SceneEnderNum);
    //}

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

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        firstLoad = true;
        // sceneEnder = FindSceneEnder();
        // SceneEnderNum = sceneEnder.SceneNum;
    }

    // finds the text object that once deleted, will end the scene and transport to another scene
    private SceneEnder FindSceneEnder()
    {
        return GameObject.FindObjectOfType<SceneEnder>();
    }

    //Scene Manipulation
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NextScene(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }

    public void NextScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public RoomData RandomRoom()
    {
        return Rooms[Random.Range(0, Rooms.Count)];
    }

}
