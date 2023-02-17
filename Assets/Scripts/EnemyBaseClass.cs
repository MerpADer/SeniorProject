using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    [HideInInspector] public GameObject Player;

    [Header("Material stuff")]
    [HideInInspector] public SpriteRenderer spr;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Material defaultMat;
    [HideInInspector] public Animator anim;
    public Material FlashWhite;

    [Header("Basic variables")]
    public int hp;
    int armor = 0;
    public float speed;

    private void Awake()
    {
        // set all base variables
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        defaultMat = spr.material;
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<Movement>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDamage"))
        {
            ThisFlashWhite(collision.gameObject);
            GetComponentInChildren<HealthBar>().SetHealth(hp);
        }
    }

    public bool isFacingObject(GameObject obj1, GameObject obj2)
    {
        // if obj1 is to the left of the obj2 and the sprite is not flipped, it is facing the obj2
        if (obj1.transform.position.x < obj2.transform.position.x && obj1.GetComponentInChildren<SpriteRenderer>().flipX == false)
        {
            return true;
        }
        // reciprocal
        else if (obj1.transform.position.x > obj2.transform.position.x && obj1.GetComponentInChildren<SpriteRenderer>().flipX == true)
        {
            return true;
        }
        return false;
    }

    public bool playerIsDetected(float distance)
    {
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < distance)
        {
            return true;
        }
        return false;
    }

    void ThisFlashWhite(GameObject obj)
    {
        // chooses which health value to hit when player deals damage
        if (armor <= 0 || !isFacingObject(gameObject, Player))
            hp -= obj.GetComponent<AttackStats>().AttackDmg;
        else
            armor -= obj.GetComponent<AttackStats>().AttackDmg;

        // enemy flashes white to signify damage being dealt
        spr.material = FlashWhite;

        if (hp <= 0)
            Destroy(gameObject);
        else
            Invoke(nameof(ResetMat), 0.1f);
    }

    void ResetMat()
    {
        spr.material = defaultMat;
    }

}
