using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float hp;
    [SerializeField] bool isEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDamage" && isEnemy)
        {

        }
        else if (collision.gameObject.tag == "EnemyDamage" && !isEnemy)
        {

        }
    }

}
