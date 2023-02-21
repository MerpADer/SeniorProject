using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBaseClass
{

    [Header("Slime vars")]
    [SerializeField] float timeToJump;

    // timer counts down from timeToJump
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

        if (timer <= 0 && !anim.GetBool("Die"))
        {
            timer = timeToJump;
            StartCoroutine(nameof(JumpSeq));
        }

        // doesn't change direction right before jump
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("SlimeJump"))
        {
            dir *= ChangeDir();
        }

        DeathConditions();

        // sets velocity variable for when slime is flying up or down for animation
        if (rb.velocity.y > 0)
        {
            anim.SetInteger("VelocityY", 1);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetInteger("VelocityY", -1);
        }
        else
        {
            anim.SetInteger("VelocityY", 0);
        }

    }

    // Makes the slime do the jump animation and then sends it up
    IEnumerator JumpSeq()
    {
        anim.SetTrigger("Jump");
        yield return new WaitForSeconds(0.4f);

        rb.velocity += new Vector2(1.5f * dir, 3);
    }

    void DeathConditions()
    {
        // play death anim
        if (hp <= 0)
        {
            anim.SetBool("Die", true);

            // hide damage collider
            Destroy(dmgBox);
        }

    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
