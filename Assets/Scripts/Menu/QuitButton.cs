using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private SpriteRenderer buttonSprite;

    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
        buttonSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void OnMouseDown()
    {
        buttonSprite.color = Color.gray;
        gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    public void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1);
        buttonSprite.color = Color.white;
        Application.Quit();
    }
}
