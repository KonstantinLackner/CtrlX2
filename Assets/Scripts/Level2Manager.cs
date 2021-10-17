using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{

    private GameObject player;
    private PlayerMovement playerScript;
    private static readonly int IsHero = Animator.StringToHash("IsHero");

    void Start()
    {
        player = GameObject.Find("Player");
        
        playerScript = player.GetComponent<PlayerMovement>();
        
        GameBools gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();
        
        initLevel(gameBools.Level2Hero, gameBools.Level2Void);
    }

    public void initLevel(bool hero, bool voidJoke)
    {
        if (voidJoke)
        {
            playerScript.killPlayer();
        } else if (hero)
        {
            player.GetComponent<Animator>().SetBool(IsHero, true);
        }
    }
}
