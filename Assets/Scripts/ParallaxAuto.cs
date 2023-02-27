using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxAuto : MonoBehaviour
{
    private float length;
    private float startpos;
    private float timeElapsed;

    [SerializeField] GameObject cam;
    [SerializeField] float parallexEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        transform.position = new Vector2(startpos + timeElapsed * parallexEffect, transform.position.y);

        if (Mathf.Abs(transform.position.x) > length)
        {
            timeElapsed = 0;
            transform.position = new Vector2(startpos, transform.position.y);
        }

    }

}
