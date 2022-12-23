using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int hp;
    [SerializeField] int armor;

    [SerializeField] HealthBar healthBar;

    private SpriteRenderer spr;
    private Blocking parry;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        healthBar.SetMaxHealth(hp, armor);
        parry = GetComponentInChildren<Blocking>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamage") && !parry.isBlocked)
        {
            hp -= collision.GetComponent<AttackStats>().AttackDmg;
            healthBar.SetHealth(hp, armor);
        }
    }

}
