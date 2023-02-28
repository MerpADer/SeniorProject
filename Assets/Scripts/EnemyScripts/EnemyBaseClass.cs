using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    [HideInInspector] public GameObject Player;
    [HideInInspector] public GameObject dmgBox;

    [HideInInspector] public SpriteRenderer spr;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Material defaultMat;
    [HideInInspector] public Animator anim;

    [Header("Material stuff")]
    public Material FlashWhite;

    [Header("Basic variables")]
    public int hp;
    public float speed;

    [Header("Money")]
    [SerializeField] List<GameObject> dropList;

    private void Awake()
    {
        // set all base variables
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        defaultMat = spr.material;
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<Movement>().gameObject;
        dmgBox = GetComponentInChildren<AttackStats>().gameObject;

        GetComponentInChildren<HealthBar>().SetMaxHealth(hp);
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

    // returns true if player is within distance of enemy
    public bool playerIsDetected(float distance)
    {
        if (Mathf.Abs(Player.transform.position.x - transform.position.x) < distance)
        {
            return true;
        }
        return false;
    }

    // changes direction enemy is facing when not facing player
    public int ChangeDir()
    {
        if (isFacingObject(gameObject, Player))
        {
            spr.flipX = !spr.flipX;
            return -1;
        }
        return 1;
    }

    // these two methods do the enemy taking damage
    void ThisFlashWhite(GameObject obj)
    {
        hp -= obj.GetComponent<AttackStats>().AttackDmg;

        // enemy flashes white to signify damage being dealt
        spr.material = FlashWhite;

        Invoke(nameof(ResetMat), 0.1f);
    }

    void ResetMat()
    {
        spr.material = defaultMat;
    }

    public void DeathConditions()
    {
        // play death anim
        if (hp <= 0)
        {
            anim.SetBool("Die", true);

            // hide damage collider
            Destroy(dmgBox);
        }

    }

    public void DestroySelf()
    {
        DropMoney(5);
        Destroy(gameObject);
    }

    void DropMoney(int amt)
    {
        for (int i = 0; i < amt; i++)
        {
            Instantiate(dropList[Random.Range(0, dropList.Count)], transform.position, Quaternion.identity);
        }
    }

}
