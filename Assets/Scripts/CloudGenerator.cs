using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{

    [SerializeField] GameObject cloud;
    [SerializeField] int amtOnScreen;


    void Start()
    {
        for (int i = 0; i < amtOnScreen; i++)
        {
            Instantiate(cloud, new Vector3(gameObject.transform.position.x, Random.Range(-5, 5)), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
