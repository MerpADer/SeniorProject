using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealObj : MonoBehaviour
{

    public SpriteRenderer revealedObj;
    [SerializeField] float dist;

    private GameObject Player;

    [HideInInspector] public bool isRevealed;

    void Awake()
    {
        isRevealed = false;
        Player = FindObjectOfType<Movement>().gameObject;
    }

    void Update()
    {
        if (revealedObj == null)
        {
            Destroy(this);
        }
        else
        {
            if (Mathf.Abs(Player.transform.position.x - transform.position.x) < dist)
            {
                isRevealed = true;
                revealedObj.enabled = true;
            }
            else
            {
                isRevealed = false;
                revealedObj.enabled = false;
            }
        }
    }

}
