using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer spr;
    private Animator anim;

    [SerializeField] float speed;

    public KeyCode leftKey;
    public KeyCode rightKey;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        if (Input.GetKey(leftKey))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spr.flipX = true;
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spr.flipX = false;
            anim.SetBool("isWalking", true);
        }

        if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("isWalking", false);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey) && collision.gameObject.tag == "Slope")
        {
            rb.velocity = new Vector2(0, 0);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slope")
        {
            rb.velocity = new Vector2(0, 0);
        }
        rb.gravityScale = 1;
    }
}
