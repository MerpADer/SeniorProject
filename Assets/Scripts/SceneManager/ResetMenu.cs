using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMenu : MonoBehaviour
{

    private Movement player;
    private GameObject[] sceneManagers;

    void Start()
    {
        Time.timeScale = 1;

        player = FindObjectOfType<Movement>();

        if (player != null)
        {
            Destroy(player.gameObject);
        }

        sceneManagers = GameObject.FindGameObjectsWithTag("SceneEditor");

        if (sceneManagers.Length > 1)
        {
            int temp = 0;

            for (int i = 0; i < sceneManagers.Length; i++)
            {
                if (sceneManagers[i].GetComponent<SceneEditor>().Rooms.Count < sceneManagers[temp].GetComponent<SceneEditor>().Rooms.Count)
                {
                    temp = i;
                }
            }

            Destroy(sceneManagers[temp].gameObject);
        }

    }

}
