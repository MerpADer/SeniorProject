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

            // move player back
            if (collision.transform.position.x > gameObject.transform.position.x)
            {
                StartCoroutine(Hurt(-1));
            }
            else
            {
                StartCoroutine(Hurt(1));
            }

            // death condition
            if (hp <= 0)
            {
                deathMenu.SetActive(true);
            }
        }
    }

    IEnumerator Hurt(int dir)
    {
        for (int i = 0; i < 25; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Translate(new Vector2(0.03f * dir, 0));
        }
    }

}
