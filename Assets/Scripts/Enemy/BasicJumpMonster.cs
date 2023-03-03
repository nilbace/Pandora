using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicJumpMonster : MoveAroundEnemy
{
    public float jumpForce; // 점프력
    public float jumpX;
    protected override void Start() {
        base.Start();
        timer = 2000;
    }

    protected override void Update() {
        base.Update();
        if(!Idle)
        {
            if(playerisleft)
            {
                transform.Translate(-moveSpeed*Time.deltaTime, 0,0);
                spriteRenderer.flipX = true==isFliped;
            }
            else
            {
                transform.Translate(moveSpeed*Time.deltaTime, 0,0);
                spriteRenderer.flipX = false==isFliped;
            }
            if(timer>cooltime)
            {
                timer = 0;
                if(playerisleft)
                {
                    rigidbody2D.AddForce(new Vector2(-jumpX, jumpForce), ForceMode2D.Impulse);
                    print("left");
                }
                else
                {
                    rigidbody2D.AddForce(new Vector2(jumpX, jumpForce), ForceMode2D.Impulse);
                    print("right");
                }
            }
        }
    }
}
