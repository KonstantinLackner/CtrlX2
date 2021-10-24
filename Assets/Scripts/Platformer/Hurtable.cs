using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtable : MonoBehaviour
{
    [SerializeField] private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceHealth()
    {
        Debug.Log(this.name + ": I have been hit!");
        health -= 1;
        StartCoroutine(hurtOrDie());
    }

    private IEnumerator hurtOrDie()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = Color.white;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
