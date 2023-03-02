using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    private GameObject player;
    private RevealObj revealedObj;

    public GameObject shopMenu;

    void Awake()
    {
        player = FindObjectOfType<Movement>().gameObject;
        revealedObj = GetComponent<RevealObj>();
    }

    void Update()
    {
        if (revealedObj.isRevealed && Input.GetKeyDown(KeyCode.E))
        {
            openShop();
        }
    }

    public void openShop()
    {
        player.GetComponent<Movement>().enabled = false;
        shopMenu.SetActive(true);
    }

}
