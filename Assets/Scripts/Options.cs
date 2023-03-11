using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    private static int amtOfMenus;

    private Movement player;

    private void Awake()
    {
        player = FindObjectOfType<Movement>();
    }

    private void OnEnable()
    {
        amtOfMenus++;
        Time.timeScale = 0;
        if (player != null)
        {
            player.enabled = false;
        }
    }

    private void OnDisable()
    {
        amtOfMenus--;
        if (amtOfMenus == 0)
        {
            Time.timeScale = 1;
            if (player != null)
            {
                player.enabled = true;
            }
        }
    }

}
