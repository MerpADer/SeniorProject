using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnAnimEnd : MonoBehaviour
{

    [SerializeField] AnimationClip anim;

    private double timer;

    void Start()
    {
        timer = anim.length;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
