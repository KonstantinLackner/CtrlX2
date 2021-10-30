using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    
    private SpriteRenderer buttonSprite;
    // Start is called before the first frame update
    void Start()
    {
        buttonSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    
    public void OnMouseDown()
    {
        buttonSprite.color = Color.gray;
        gameObject.transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    public void OnMouseUp()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1);
        buttonSprite.color = Color.white;
        SceneManager.LoadScene("Scenes/Input");
    }
}
