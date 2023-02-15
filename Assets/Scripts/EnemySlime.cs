using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : EnemyBaseClass
{

    [Header("Slime vars")]
    [SerializeField] float timeToJump;
    private float timer;

    void Start()
    {
        timer = timeToJump;
    }


    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = timeToJump;
            StartCoroutine(nameof(JumpSeq));
        }
        
    }

    IEnumerator JumpSeq()
    {
        anim.SetTrigger("Jump");

        yield return new WaitForSeconds(0.2f);

        rb.velocity += new Vector2(1, 2);
    }

}
