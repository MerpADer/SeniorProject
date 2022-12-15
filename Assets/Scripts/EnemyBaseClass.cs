using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    [HideInInspector] public GameObject Player;

    [Header("material stuff")]
    [HideInInspector] public SpriteRenderer spr;
    [HideInInspector] public Material defaultMat;
    public Material FlashWhite;

    [Header("basic variables")]
    public int hp;
    public int armor;
    public float speed;
    public float TurnTime;

    [Header("how much enemy bounces off")]
    [SerializeField] Vector2 BounceDist;
    [HideInInspector] public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerParry")) // && isFacingObject(collision.gameObject, gameObject)
        {
            BounceOff();
        }
        if (collision.CompareTag("PlayerDamage"))
        {
            ThisFlashWhite(collision.gameObject);
            GetComponentInChildren<HealthBar>().SetHealth(hp, armor);
        }
    }

    public bool isFacingObject(GameObject obj1, GameObject obj2)
    {
        // if obj1 is to the left of the obj2 and the sprite is not flipped, it is facing the obj2
        if (obj1.transform.position.x < obj2.transform.position.x && obj1.GetComponent<SpriteRenderer>().flipX == false)
        {
            return true;
        }
        // reciprocal
        else if (obj1.transform.position.x > obj2.transform.position.x && obj1.GetComponent<SpriteRenderer>().flipX == true)
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

    private void BounceOff()
    {
        rb.velocity += BounceDist;
    }

}
