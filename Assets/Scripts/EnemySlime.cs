using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBaseClass
{

    [Header("Slime vars")]
    [SerializeField] float timeToJump;

    private float timer;
    private int dir;

    void Start()
    {
        timer = timeToJump;
        dir = -1;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timeToJump;
            StartCoroutine(nameof(JumpSeq));
        }

        changeDir();

    }

    IEnumerator JumpSeq()
    {
        anim.SetTrigger("Jump");

        yield return new WaitForSeconds(0.2f);

        rb.velocity += new Vector2(1 * dir, 2);
    }

    void changeDir() 
    {
        if (isFacingObject(gameObject, Player))
        {
            spr.flipX = !spr.flipX;
            dir *= -1;
        }
    }

}
