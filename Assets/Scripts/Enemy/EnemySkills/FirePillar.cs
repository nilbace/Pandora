using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    [SerializeField] float timer;
    SpriteRenderer spriteRenderer;
    Color newColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        newColor = new Color();
        newColor.a = 1;
        Destroy(gameObject,1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer < 1f)
        {
            newColor.r = Mathf.Lerp(startColor.r, endColor.r, timer);
            newColor.g = Mathf.Lerp(startColor.g, endColor.g, timer);
            newColor.b = Mathf.Lerp(startColor.b, endColor.b, timer);
            spriteRenderer.color = newColor;
        }

    }
}
