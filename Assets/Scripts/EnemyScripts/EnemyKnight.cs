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
        DeathConditions();
    }

    void Move()
    {
        rb.velocity = new Vector2(speed * dir, 0);
    }

}
