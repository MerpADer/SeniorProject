using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    private GameObject Player;

    //material stuff
    [HideInInspector] public SpriteRenderer spr;
    private Material defaultMat;
    public Material FlashWhite;

    // basic variables
    [SerializeField] float hp;
    public float speed;
    public float TurnTime;

    void Awake()
    {
        Player = FindObjectOfType<Movement>().gameObject;
        spr = GetComponent<SpriteRenderer>();
        defaultMat = spr.material;
    }

    void Update()
    {
        print(playerIsDetected(3));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDamage"))
        {
            ThisFlashWhite(collision.gameObject);
        }
    }

    public bool isFacingEnemy()
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

    public bool playerIsDetected(int distance)
    {
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < distance)
        {
            return true;
        }
        return false;
    }

    void ThisFlashWhite(GameObject obj)
    {
        hp -= obj.GetComponent<AttackStats>().AttackDmg;
        spr.material = FlashWhite;
        if (hp <= 0)
            Destroy(gameObject);
        else
            Invoke("ResetMat", 0.1f);
    }

    void ResetMat()
    {
        spr.material = defaultMat;
    }

}
