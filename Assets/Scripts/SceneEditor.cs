using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{
    public Animator anim;

    private SceneEnder sceneEnder;
    private int SceneEnderNum;

    private float timer = 0f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        sceneEnder = FindSceneEnder();
        SceneEnderNum = sceneEnder.SceneNum;
    }

    private void Update()
    {
        if (sceneEnder == null)
        {
            anim.SetBool("IsFadedOut", true);
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                anim.SetBool("IsFadedOut", false);
                timer = 0;
                NextScene();
            }
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

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        sceneEnder = FindSceneEnder();
        SceneEnderNum = sceneEnder.SceneNum;
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
