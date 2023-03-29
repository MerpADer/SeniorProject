using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamFindPlayer : MonoBehaviour
{

    private CinemachineVirtualCamera cam;
    private Movement player;

    void Awake()
    {
        player = FindObjectOfType<Movement>();
        cam = GetComponent<CinemachineVirtualCamera>();

        cam.Follow = player.gameObject.transform;
    }

    
}
