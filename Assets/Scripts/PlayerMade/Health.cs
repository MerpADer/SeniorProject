using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int hp;
    [HideInInspector] public int maxHealth;

    public HealthBar healthBar;

    private Animator anim;

    [SerializeField] GameObject deathMenu;

    private void Awake()
    {
        maxHealth = hp;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(hp);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamage") && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerRoll"))
        {
            hp -= collision.GetComponent<AttackStats>().AttackDmg;
            healthBar.SetHealth(hp);
            if (hp <= 0)
            {
                deathMenu.SetActive(true);
            }
        }
    }

}
