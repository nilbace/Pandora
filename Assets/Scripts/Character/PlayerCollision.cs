using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Vector2 _hitPoz;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _hitPoz = collision.contacts[0].point;
        print("사망 검사 시작");
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.contacts[0].point.y < _hitPoz.y)
        {
            print("사망");
        }
    }
}
