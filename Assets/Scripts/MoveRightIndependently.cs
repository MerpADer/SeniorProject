using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightIndependently : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 startPos;

    [SerializeField] float speed;
    [SerializeField] float speedVariance;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = gameObject.transform.position;
        newStartPos();
    }

    void Update()
    {
        rb.velocity = new Vector3(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shredder"))
        {
            newStartPos();
            gameObject.transform.position = startPos;
        }
    }

    private void newStartPos()
    {
        speed += Random.Range(-speedVariance, speedVariance);
        if (speed < 0)
            speed = speedVariance;
        startPos = new Vector3(startPos.x, Random.Range(-5, 5));
    }

}
