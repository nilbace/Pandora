using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    bool moveleft = false;
    float timer;
    public Vector2 moveSpeed;
    public float moveDuration;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>moveDuration)
        {
            timer = 0;
            moveleft = !moveleft;
        }

        int temp = moveleft ? 1 : -1;
        transform.Translate(moveSpeed*Time.deltaTime * temp);
    }


    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            int temp = moveleft ? 1 : -1;
            other.gameObject.transform.Translate(moveSpeed*Time.deltaTime * temp);
        }
    }
}
