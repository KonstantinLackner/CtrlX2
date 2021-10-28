using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    private GameObject player;
    private GameObject princess;
    private GameObject dragon;
    private PatrolingAndAttacking princessScript;
    private PatrolingAndAttacking dragonScript;
    private AttackScript attackScriptPlayer;

    private String kill;
    private String safe;

    void Start()
    {
        player = GameObject.Find("Player");
        princess = GameObject.Find("Princess");
        dragon = GameObject.Find("Dragon");
        
        princessScript = princess.GetComponent<PatrolingAndAttacking>();
        dragonScript = dragon.GetComponent<PatrolingAndAttacking>();
        attackScriptPlayer = player.GetComponent<AttackScript>();
        

        GameBools gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();

        // princess aggressive, princess target, dragon aggressive, dragon target, you target
        initLevel(gameBools.Level3PrincessAggressive, gameBools.Level3PrincessTarget, gameBools.Level3DragonAggressive, gameBools.Level3DragonTarget, gameBools.Level3YouTarget, gameBools.kill, gameBools.safe);
    }

    private void Update()
    {
        player = GameObject.Find("Player");
        princess = GameObject.Find("Princess");
        dragon = GameObject.Find("Dragon");
        
        if (kill.Equals("dragon") && safe.Equals("princess"))
        {
            if (dragon == null && princess != null)
            {
                // Won
            }
        } else if (kill.Equals("princess") && safe.Equals("dragon"))
        {
            if (princess == null && dragon != null)
            {
                // Won
            }
        } else if (kill.Equals("you") && safe.Equals("princess"))
        {
            if (player == null && princess != null)
            {
                // Won
            }
        } else if (kill.Equals("princess") && safe.Equals("you"))
        {
            if (princess == null && player != null)
            {
                // Won
            }
        } else if (kill.Equals("you") && safe.Equals("dragon"))
        {
            if (player == null && dragon != null)
            {
                // Won
            }
        } else if (kill.Equals("dragon") && safe.Equals("you"))
        {
            if (dragon == null && player != null)
            {
                // Won
            }
        }
    }

    public void initLevel(bool princessAggressive, bool princessTarget, bool dragonAggressive, bool dragonTarget, bool youTarget, String kill, String safe)
    {
        this.kill = kill;
        this.safe = safe;
        
        if (princessAggressive)
        {
            princessScript.aggressive = true;
            if (dragonTarget)
            {
                // Set dragon as target for princess
                princessScript.aggressionAgainst = dragon;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Dragon");
                attackScriptPlayer.canAttack = true;
                attackScriptPlayer.hurtableLayerMask = LayerMask.GetMask("Dragon");
            } else if (youTarget)
            {
                // Set you as target for princess and princess as target for dragon
                princessScript.aggressionAgainst = player;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Player");
                dragonScript.aggressive = true;
                dragonScript.aggressionAgainst = princess;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Princess");
                attackScriptPlayer.canAttack = false;
            }
        } else if (dragonAggressive)
        {
            dragonScript.aggressive = true;
            if (princessTarget)
            {
                // Set princess as target for dragon
                dragonScript.aggressionAgainst = princess;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Princess");
                attackScriptPlayer.canAttack = true;
                attackScriptPlayer.hurtableLayerMask = LayerMask.GetMask("Dragon");
            } else if (youTarget)
            {
                // Set you as target for dragon and dragon as target for princess
                dragonScript.aggressionAgainst = player;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Player");
                princessScript.aggressive = true;
                princessScript.aggressionAgainst = dragon;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Dragon");
                attackScriptPlayer.canAttack = false;
            }
        }
    }
}
