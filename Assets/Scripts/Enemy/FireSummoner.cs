using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSummoner : MoveAroundEnemy
{
    public GameObject FirePillar;
    protected override void Start()
    {
        base.Start();
        timer = 2000;
    }

    protected override void Update()
    {
        base.Update();
        if(!Idle)
        {
           if(playerisleft)
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = true==isFliped;
            }
            else
            {
                rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = false==isFliped;
            }   
            if(timer > cooltime)
            {
                timer=0;
                Instantiate(FirePillar, player.transform.position, Quaternion.identity);
            }
        }
    }
}
