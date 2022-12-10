using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseClass : MonoBehaviour
{

    [HideInInspector] public GameObject Player;

    //material stuff
    [HideInInspector] public SpriteRenderer spr;
    [HideInInspector] public Material defaultMat;
    public Material FlashWhite;

    // basic variables
    public int hp;
    public float speed;
    public float TurnTime;

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
        hp -= obj.GetComponent<AttackStats>().AttackDmg;
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
