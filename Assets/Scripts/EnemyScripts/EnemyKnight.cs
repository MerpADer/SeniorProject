using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : EnemyBaseClass
{

    private int dir;

    private bool flagDeath = false;

    [SerializeField] float attackRadius;

    void Start()
    {
        dir = -1;
    }

    void Update()
    {
        // attacking the player
        if (!playerIsDetected(attackRadius))
        {
            anim.SetBool("isAttacking", false);
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && dmgBox != null)
            {
                int dirMult = ChangeDir();

                dir *= dirMult;
                dmgBox.transform.localScale = new Vector2(dmgBox.transform.localScale.x * dirMult, 1);
                Move();
            }
        }
        else
        {
            anim.SetBool("isAttacking", true);
        }

        // shoot skeleton back
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && !flagDeath)
        {
            flagDeath = true;

            if (gameObject.transform.position.x > Player.transform.position.x)
            {
                rb.velocity += new Vector2(2, 1.5f);
            }
            else
            {
                rb.velocity += new Vector2(-2, 1.5f);
            }

        }

        DeathConditions();
    }

    void Move()
    {
        rb.velocity = new Vector2(speed * dir, rb.velocity.y);
    }

}
