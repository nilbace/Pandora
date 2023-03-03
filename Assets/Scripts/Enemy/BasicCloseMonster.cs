using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCloseMonster : MoveAroundEnemy
{
    public float chasingSpeed;

    protected override void Update() {
        base.Update();
        if(!Idle)
        {
            if(playerisleft)
            {
                spriteRenderer.flipX = true==isFliped;
                rigidbody2D.velocity = new Vector2(-chasingSpeed,rigidbody2D.velocity.y);
            }
            else
            {
                spriteRenderer.flipX = false==isFliped;
                rigidbody2D.velocity = new Vector2(chasingSpeed, rigidbody2D.velocity.y);
            }
        }
    }
}
