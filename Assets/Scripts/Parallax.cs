using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] Transform followObj;
    [SerializeField] Vector2 offset;

    private Vector2 firstPos;

    void Start()
    {
        firstPos = new Vector2(followObj.position.x, followObj.position.y);
    }

    void Update()
    {
        offset.x = (firstPos.x - followObj.position.x) / 3;

        transform.position = new Vector3(followObj.position.x + offset.x, offset.y);
    }
}
