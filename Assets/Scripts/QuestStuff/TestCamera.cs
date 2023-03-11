using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{

    private Camera cam;
    public LayerMask layerMask;

    void Awake()
    {
        cam = GetComponent<Camera>();
        
    }

    void Update()
    {
        cam.cullingMask = layerMask;
    }
}
