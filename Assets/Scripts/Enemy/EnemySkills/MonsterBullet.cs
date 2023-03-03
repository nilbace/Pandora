using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float speed; // 총알 이동 속도

    private Vector2 direction; // 총알 이동 방향

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
      this.direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            print("Player hit");
            Destroy(gameObject);
        }
    }
}
