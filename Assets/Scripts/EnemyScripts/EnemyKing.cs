using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : EnemyBaseClass
{

    private int dir;

    private float timer;

    [Header("Attack Variables")]
    [SerializeField] List<float> attackRadius;

    [SerializeField] float timerLen;

    [SerializeField] Vector2 offset;
    [SerializeField] GameObject spawnfxPrefab;
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] GameObject atkPrefab;

    private int temp;

    void Start()
    {
        dir = -1;
        temp = 2;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        // attacking the player
        if (isFacingObject(gameObject, Player) || !playerIsDetected(0.5f))
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3") && dmgBox != null)
            {
                int dirMult = ChangeDir();

                dir *= dirMult;
                dmgBox.transform.localScale = new Vector2(dmgBox.transform.localScale.x * dirMult, 1);
                Move();
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (timer <= 0 && playerIsDetected(attackRadius[temp - 1]))
        {
            timer = timerLen;
            if (temp == 1)
            {
                Attack1();
            }
            else if (temp == 2)
            {
                StartCoroutine(nameof(Attack2));
            }
            else
            {
                StartCoroutine(nameof(Attack3));
            }
            anim.SetBool("Walking", false);
            temp = Random.Range(1, 4);
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

    IEnumerator Attack2()
    {
        anim.SetTrigger("Attack2");

        Instantiate(spawnfxPrefab, new Vector2(transform.position.x + offset.x * dir, transform.position.y + offset.y), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(spawnPrefab, new Vector2(transform.position.x + offset.x * dir, transform.position.y + offset.y), Quaternion.identity);
    }

    IEnumerator Attack3()
    {
        anim.SetTrigger("Attack3");

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.4f);
            Instantiate(atkPrefab, new Vector2(transform.position.x + (offset.x + i * 0.7f) * dir, transform.position.y + offset.y), Quaternion.identity);
        }

    }

}
