using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : EnemyBaseClass
{

    private int dir;

    private float timer;

    [SerializeField] float attackRadius;

    void Start()
    {
        dir = -1;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // attacking the player
        if (!playerIsDetected(attackRadius))
        {

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && dmgBox != null)
            {
                int dirMult = ChangeDir();

                dir *= dirMult;
                dmgBox.transform.localScale = new Vector2(dmgBox.transform.localScale.x * dirMult, 1);
                Move();
            }
        }
        else if (timer <= 0)
        {
            timer = 10;
            int temp = Random.Range(1, 4);
            if (temp == 1)
            {
                Attack1();
            }
            else if (temp == 2)
            {
                Attack2();
            }
            else
            {
                Attack3();
            }
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        DeathConditions();
    }

    void Move()
    {
        anim.SetBool("Walking", true);
        rb.velocity = new Vector2(speed * dir, rb.velocity.y);
    }

    void Attack1()
    {
        anim.SetTrigger("Attack1");
    }

    void Attack2()
    {
        anim.SetTrigger("Attack2");
    }

    void Attack3()
    {
        anim.SetTrigger("Attack3");
    }

}
