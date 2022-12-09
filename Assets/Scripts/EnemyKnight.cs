using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : EnemyBaseClass
{

    private float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (playerIsDetected(3) && !isFacingEnemy())
        {
            timer += Time.deltaTime;
            if (timer >= TurnTime)
            {
                // ATP the player is always detected
                spr.flipX = !spr.flipX;
            }
        }
    }

    

}
