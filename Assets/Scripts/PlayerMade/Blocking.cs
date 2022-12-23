using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{

    [HideInInspector] public bool isBlocked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamage"))
        {
            isBlocked = true;
            Invoke(nameof(ResetBlock), 0.5f);
        }
    }

    private void ResetBlock()
    {
        isBlocked = false;
    }

}
