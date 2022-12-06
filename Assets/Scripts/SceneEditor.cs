using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEditor : MonoBehaviour
{
    public Animator anim;

    private GameObject sceneEnder;

    private float timer = 0f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        sceneEnder = FindSceneEnder();
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
                sceneEnder = FindSceneEnder();
                print(sceneEnder);
            }
        }
    }

    private GameObject FindSceneEnder()
    {
        return GameObject.FindWithTag("SceneEnder");
    }

    //Scene Manipulation
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print(SceneManager.GetActiveScene().buildIndex + 1);
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
