using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
public class WorldManager : MonoBehaviour
{
    bool isCity = false;                     //시작은 City이다. Start문에서 Change로 시작해야하니 false로 설정한다. 
    public static WorldManager instance;    //싱글턴용
    SpriteRenderer BackGround;
    public List<Sprite> Imgs;   
    public GameObject countdownBlock;
    public GameObject City;
    public GameObject Dream;
    public Tilemap[] CityTiles;
    public Tilemap[] DreamTiles;
    public float transparentValue = 0.1f;      //투명값
    float opaqueValue = 1f;             //불투명값

    private void Start() {
        instance = this;                                 //싱글턴
        BackGround = GetComponent<SpriteRenderer>();     //배경이미지
        CityTiles = City.GetComponentsInChildren<Tilemap>();
        DreamTiles = Dream.GetComponentsInChildren<Tilemap>();

        Change();                                        //City 시작
    }
    public void Change()
    {
        isCity = !isCity;

        BackGround.sprite = isCity ? Imgs[0] : Imgs[1];

        foreach(Tilemap Citytile in CityTiles)
        {
            Citytile.GetComponent<TilemapCollider2D>().enabled = isCity;
            Color temp = Citytile.color;
            temp.a = isCity ? opaqueValue : transparentValue;
            Citytile.color = temp;
        }
        foreach(Tilemap dreamtile in DreamTiles)
        {
            dreamtile.GetComponent<TilemapCollider2D>().enabled = !isCity;
            Color temp = dreamtile.color;
            temp.a = isCity ? transparentValue : opaqueValue;
            dreamtile.color = temp;
        }
    }

    public void DestroyCountdownBlock()
    {
        StartCoroutine(breakthisObject());
    }

    IEnumerator breakthisObject()
    {
        countdownBlock.SetActive(false);
        yield return new WaitForSeconds(5);
        countdownBlock.SetActive(true);
    }
    
}
