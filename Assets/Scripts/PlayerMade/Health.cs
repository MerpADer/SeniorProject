using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int hp;

    [SerializeField] HealthBar healthBar;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(hp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamage") && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRoll"))
        {
            hp -= collision.GetComponent<AttackStats>().AttackDmg;
            healthBar.SetHealth(hp);
        }
    }

}
