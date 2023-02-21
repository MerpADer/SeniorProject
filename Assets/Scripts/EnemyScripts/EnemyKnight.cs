using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : EnemyBaseClass
{

    private int dir;

    void Start()
    {
        dir = -1;
    }

    void Update()
    {
        if (!playerIsDetected(.25f))
        {
            anim.SetBool("isAttacking", false);
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                dir *= ChangeDir();
                Move();
            }
        }
        else
        {
            anim.SetBool("isAttacking", true);
        }

    }

    void Move()
    {
        rb.velocity = new Vector2(speed * dir, 0);
    }

    private void AttackPlayer()
    {
        anim.SetTrigger("isAttacking");
    }
}
