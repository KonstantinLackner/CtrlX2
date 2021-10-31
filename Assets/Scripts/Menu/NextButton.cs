using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextButton : MonoBehaviour
{
    private SpriteRenderer info;
    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;
    public Sprite spr4;
    public Sprite spr5;
    public Sprite spr6;
    public Sprite spr7;
    private Sprite[] sprites;
    private int count;
    private Sprite currentSprite;
    private SpriteRenderer buttonSprite;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new[] {spr1, spr2, spr3, spr4, spr5, spr6, spr7};
        info = GameObject.Find("Info").GetComponent<SpriteRenderer>();
        buttonSprite = gameObject.GetComponent<SpriteRenderer>();
        count = 0;
        currentSprite = sprites[count];
    }

    public void OnMouseDown()
    {
        buttonSprite.color = Color.gray;
        gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        count++;
        if (count > sprites.Length - 1)
        {
            count = 0;
        }

        currentSprite = sprites[count];
        info.sprite = currentSprite;
    }

    public void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1);
        buttonSprite.color = Color.white;
    }
}