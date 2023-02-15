using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : EnemyBaseClass
{

    private float timer = 0;

    private bool isLockedOn = false;

    private double AttackTimer = 0f;

    private int TurnTime;

    void Awake()
    {
        Player = FindObjectOfType<Movement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        defaultMat = spr.material;
        GetComponentInChildren<HealthBar>().SetMaxHealth(hp, armor);
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
                GetComponentInChildren<AttackStats>().gameObject.transform.localScale *= new Vector2(-1, 1);
            }
        }
        else
        {
            timer = 0;
            // enemy movement towards player
            if (playerIsDetected(0.45f))
            {
                anim.SetBool("isRunning", false);

                AttackTimer += Time.deltaTime;

                if(AttackTimer >= 0.5f)
                    AttackPlayer();

            }
            else if (spr.flipX == false && !anim.GetCurrentAnimatorStateInfo(0).IsName("AttackLizard"))
            {
                anim.SetBool("isRunning", true);
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else if (spr.flipX == true && !anim.GetCurrentAnimatorStateInfo(0).IsName("AttackLizard"))
            {
                anim.SetBool("isRunning", true);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
    }
    private void AttackPlayer()
    {
        anim.SetTrigger("isAttacking");
        AttackTimer = 0;
    }
}
