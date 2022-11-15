using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer spr;

    [SerializeField] int speed;

    [SerializeField] KeyCode leftKey;
    [SerializeField] KeyCode rightKey;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spr = gameObject.GetComponent<SpriteRenderer>();
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
        }
        if (Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spr.flipX = false;
        }

        if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
