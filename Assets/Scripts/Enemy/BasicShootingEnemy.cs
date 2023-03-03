using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShootingEnemy : MoveAroundEnemy
{
   
    public GameObject bulletPrefab; // Bullet 프리팹
    public float chasingSpeed;


    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
        timer += Time.deltaTime;
        if(!Idle)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction*chasingSpeed*Time.deltaTime);

            if (timer>cooltime)
            {
                timer =0;
                ShootBullet(direction);
            }
        }
    }

    void ShootBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        MonsterBullet bulletComponent = bullet.GetComponent<MonsterBullet>();

        if (bulletComponent != null)
        {
            bulletComponent.SetDirection(direction);
        }
    }
}
