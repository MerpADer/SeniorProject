using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : EnemyBaseClass
{

    private float timer = 0;

    private bool isLockedOn = false;

    private Rigidbody2D rb;

    private Animator anim;

    void Awake()
    {
        Player = FindObjectOfType<Movement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        defaultMat = spr.material;
    }

    void Update()
    {
        if (playerIsDetected(3))
            isLockedOn = true;

        if (isLockedOn)
            LockOn();

    }

    void LockOn()
    {
        if (!isFacingObject(gameObject, Player))
        {
            timer += Time.deltaTime;
            if (timer >= TurnTime)
            {
                spr.flipX = !spr.flipX;
            }
        }
        else
        {
            timer = 0;
            // enemy movement towards player
            if (playerIsDetected(0.5f))
            {
                rb.velocity = new Vector2(0, 0);
                Invoke(nameof(AttackPlayer), 1f);
            }
            else if (spr.flipX == false)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else if (spr.flipX == true)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
        }
    }
    private void AttackPlayer()
    {
        anim.SetTrigger("isAttacking");
        CancelInvoke(nameof(AttackPlayer));
    }
}
