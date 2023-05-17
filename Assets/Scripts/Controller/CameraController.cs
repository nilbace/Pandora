using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    Vector3 _playerPoz;
    [SerializeField] Vector2 offset;
    [SerializeField] float CamSpeed;
    [SerializeField] Ease TestEase;
    static float timer;
   

    public static void SetTimerZero()
    {
        timer = 0;
    }
    

    private void LateUpdate() {
        timer += Time.deltaTime;
        _playerPoz = PlayerMove.instance.gameObject.transform.position;
        
        Vector3 destPoz = _playerPoz + (PlayerMove.instance.isLookingleft ? new Vector3(-offset.x, offset.y,-10) : new Vector3(offset.x, offset.y,-10));


        transform.position = new Vector3( Mathf.Lerp(transform.position.x , destPoz.x, timer * CamSpeed), _playerPoz.y, -10);
    }

    
}
