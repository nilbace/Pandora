using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundEnemy : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도
    public float detectionRange = 5f; //플레이어 감지 범위
    protected bool Idle = true;
    protected bool movingLeft;
    protected GameObject player; // 플레이어 오브젝트
    protected bool playerisleft;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigidbody2D;
    public bool isFliped;
    protected float timer;
    public float cooltime;
    Coroutine changedir;

    protected virtual void Start()
    {
        changedir = StartCoroutine(changeDir());
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        if(player.transform.position.x < transform.position.x)
        {
            playerisleft = true;
        }
        else
        {
            playerisleft = false;
        }
        if(Idle)
        {
            //평소엔 좌우로 이동
            if (movingLeft)
            {
                rigidbody2D.velocity = new Vector2(-moveSpeed,0);
                spriteRenderer.flipX = true==isFliped;
            }
            else
            {
                rigidbody2D.velocity = new Vector2(moveSpeed,0);
                spriteRenderer.flipX = false==isFliped;
            }

            //평소엔 계속 플레이어 탐색
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if(distance<=detectionRange)
            {
                Idle = false;
                StopCoroutine(changedir);
            }
        }
    }

    IEnumerator changeDir()
    {
        while(true)
        {
            movingLeft = !movingLeft;
            yield return new WaitForSeconds(3f);
        }
    }
}
