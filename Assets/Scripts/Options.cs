using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    private static int amtOfMenus;

    private void OnEnable()
    {
        amtOfMenus++;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        amtOfMenus--;
        if (amtOfMenus == 0)
        {
            Time.timeScale = 1;
        }
    }

}
