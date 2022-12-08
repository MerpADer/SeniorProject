using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    private GameObject Player;
    SpriteRenderer spr;

    void Awake()
    {
        Player = FindObjectOfType<Movement>().gameObject;
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    bool isFacingEnemy()
    {
        // if the player is to the left of the enemy and the sprite is not flipped, it is facing the enemy
        if (Player.transform.position.x < transform.position.x && Player.GetComponent<SpriteRenderer>().flipX == false && spr.flipX == true)
        {
            return true;
        }
        // reciprocal
        else if (Player.transform.position.x > transform.position.x && Player.GetComponent<SpriteRenderer>().flipX == true && spr.flipX == false)
        {
            return true;
        }
        return false;
    }

}
