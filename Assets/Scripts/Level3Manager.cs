using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        GameBools gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();
        
        // princess aggressive, princess target, dragon aggressive, dragon target, you target
        initLevel(gameBools.Level3PrincessAggressive, gameBools.Level3PrincessTarget, gameBools.Level3DragonAggressive, gameBools.Level3DragonTarget, gameBools.Level3YouTarget);
    }

    public void initLevel(bool princessAggressive, bool princessTarget, bool dragonAggressive, bool dragonTarget, bool youTarget)
    {
        if (princessAggressive)
        {
            // set princess aggressive
            if (dragonTarget)
            {
                // Set dragon as target for princess
            } else if (youTarget)
            {
                // Set you as target for princess
            }
        } else if (dragonAggressive)
        {
            if (princessTarget)
            {
                
            } else if (youTarget)
            {
                
            }
        }
    }
}
