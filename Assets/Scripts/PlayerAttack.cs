using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("isAttacking");
            rb.velocity = new Vector2(0, 0);
        }
    }
}
