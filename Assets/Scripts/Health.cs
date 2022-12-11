using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int hp;
    [SerializeField] int armor;

    [SerializeField] HealthBar healthBar;

    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth(hp, armor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamage"))
        {
            hp -= collision.GetComponent<AttackStats>().AttackDmg;
            healthBar.SetHealth(hp, armor);
        }
    }

}
