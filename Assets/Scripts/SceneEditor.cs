using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{
    public Animator anim;

    public List<RoomData> Rooms;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void fadeOut()
    {
        anim.SetBool("IsFadedOut", true);
        Invoke(nameof(fadeIn), 2f);
    }

    public void fadeIn()
    {
        anim.SetBool("IsFadedOut", false);
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

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        
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

    public IEnumerator NextScene(string SceneName)
    {
        fadeOut();

        yield return new WaitForSeconds(2f);

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
