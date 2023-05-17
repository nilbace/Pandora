using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;
    Vector3 _destPoz;
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    public enum PlayerState{
        Die,
        Moving,
        Idle,
    }
    PlayerState _state = PlayerState.Idle;
    void UpdateDie()
    {

    }

    void UpdateMoving()
    {
        Vector3 dir = _destPoz - transform.position;
            if(dir.magnitude < 0.01f)
            {
                _state = PlayerState.Idle;
            }
            else
            {
                float _moveDist = Mathf.Clamp(_speed * Time.deltaTime,0,dir.magnitude);
                transform.position = transform.position + dir.normalized*_speed*Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10*Time.deltaTime);
            }

       _anim.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {
        _anim.SetFloat("speed", 0f);
    }

    private void Update() {
        
        switch(_state)
        {
            case PlayerState.Die:
                UpdateDie();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;

            case PlayerState.Idle:
                UpdateIdle();
                break;
            
        }
    }


    void OnMouseClicked(Define.MouseEvent evt)
    {
        if(_state == PlayerState.Die)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction*100f, Color.red, 1.0f);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Wall")))
        {
            _destPoz = hit.point;
            _state = PlayerState.Moving;
        }
    }
}
