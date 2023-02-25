using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax02 : MonoBehaviour
{

    public Vector2 speed;

    Vector2 offset;

    private Material mat;

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = speed * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }

}
