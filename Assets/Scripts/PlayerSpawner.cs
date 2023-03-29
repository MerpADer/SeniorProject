using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    private Movement player;

    void Awake()
    {
        player = FindObjectOfType<Movement>();

        player.enabled = true;
        player.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

}
