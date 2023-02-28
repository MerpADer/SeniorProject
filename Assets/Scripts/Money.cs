using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    
    [SerializeField] List<Sprite> images;
    public int value;

    private SpriteRenderer spr;
    private Rigidbody2D rb;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        spr.sprite = images[Random.Range(0, images.Count)];

        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

    }

}
