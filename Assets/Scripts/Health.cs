using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float hp;
    [SerializeField] bool isEnemy;

    private Material defaultMat;
    public Material FlashWhite;
    private SpriteRenderer spr;

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        defaultMat = spr.material;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDamage") && isEnemy)
        {
            hp -= collision.GetComponent<AttackStats>().AttackDmg;
            spr.material = FlashWhite;
            if (hp <= 0)
                Destroy(gameObject);
            else
                Invoke("ResetMat", 0.1f);
        }
        else if (collision.CompareTag("EnemyDamage") && !isEnemy)
        {

        }
    }

    void ResetMat()
    {
        spr.material = defaultMat;
    }

}
