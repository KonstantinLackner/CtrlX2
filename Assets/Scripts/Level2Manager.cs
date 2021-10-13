using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{

    private PlayerMovement playerScript;
    
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        
        GameBools gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();
        
        initLevel(gameBools.Level2Hero, gameBools.Level2Void);
    }

    public void initLevel(bool hero, bool voidJoke)
    {
        if (voidJoke)
        {
            playerScript.killPlayer();
        }
    }
}
