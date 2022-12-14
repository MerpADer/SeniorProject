using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{

    [SerializeField] float max;
    [SerializeField] float min;

    [SerializeField] Sprite newSpr;
    private Sprite oldSpr;
    private SpriteRenderer spr;

    private float timerLength;
    private float timer;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        oldSpr = spr.sprite;
        SetTimer();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerLength)
        {
            if (spr.sprite == oldSpr)
            {
                spr.sprite = newSpr;
            }
            else
            {
                spr.sprite = oldSpr;
            }
            SetTimer();
        }
    }

    private void SetTimer()
    {
        timer = 0;
        timerLength = Random.Range(min, max);
    }

}
