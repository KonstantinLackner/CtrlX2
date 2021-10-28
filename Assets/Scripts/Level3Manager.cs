using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private SceneLoader sceneLoader;

    void Start()
    {
        player = GameObject.Find("Player");
        princess = GameObject.Find("Princess");
        dragon = GameObject.Find("Dragon");

        princessScript = princess.GetComponent<PatrolingAndAttacking>();
        dragonScript = dragon.GetComponent<PatrolingAndAttacking>();
        attackScriptPlayer = player.GetComponent<AttackScript>();

        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        
        GameBools gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();

        // princess aggressive, princess target, dragon aggressive, dragon target, you target
        initLevel(gameBools.Level3PrincessAggressive, gameBools.Level3PrincessTarget, gameBools.Level3DragonAggressive,
            gameBools.Level3DragonTarget, gameBools.Level3YouTarget, gameBools.Level3YouSafe, gameBools.kill, gameBools.safe);
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
                StartCoroutine(winLevel());
            } else if (princess == null)
            {
                StartCoroutine(loseLeve());
            }
        }
        else if (kill.Equals("princess") && safe.Equals("dragon"))
        {
            if (princess == null && dragon != null)
            {
                // Won
                StartCoroutine(winLevel());
            } else if (dragon == null)
            {
                StartCoroutine(loseLeve());
            }
        }
        else if (kill.Equals("you") && safe.Equals("princess"))
        {
            if (player == null && princess != null)
            {
                // Won
                StartCoroutine(winLevel());
            } else if (princess == null)
            {
                StartCoroutine(loseLeve());
            }
        }
        else if (kill.Equals("princess") && safe.Equals("you"))
        {
            if (princess == null && player != null)
            {
                // Won
                StartCoroutine(winLevel());
            } else if (player == null)
            {
                StartCoroutine(loseLeve());
            }
        }
        else if (kill.Equals("you") && safe.Equals("dragon"))
        {
            if (player == null && dragon != null)
            {
                // Won
                StartCoroutine(winLevel());
            } else if (dragon == null)
            {
                StartCoroutine(loseLeve());
            }
        }
        else if (kill.Equals("dragon") && safe.Equals("you"))
        {
            if (dragon == null && player != null)
            {
                // Won
                StartCoroutine(winLevel());
            } else if (player == null)
            {
                StartCoroutine(loseLeve());
            }
        }
    }

    public void initLevel(bool princessAggressive, bool princessTarget, bool dragonAggressive, bool dragonTarget,
        bool youTarget, bool youSafe, String kill, String safe)
    {
        // princess aggressive, princess target, dragon aggressive, dragon target, you target
        
        this.kill = kill;
        this.safe = safe;

        if (princessAggressive)
        {
            princessScript.aggressive = true;
            if (dragonTarget && !youSafe)
            {
                // a princess rescues you from a dragon
                princessScript.aggressionAgainst = dragon;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Dragon");
                dragonScript.aggressionAgainst = player;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Player");
                attackScriptPlayer.canAttack = false;
            } else if (dragonTarget && youSafe)
            {
                // you rescue a dragon from a princess
                princessScript.aggressionAgainst = dragon;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Dragon");
                attackScriptPlayer.canAttack = true;
                attackScriptPlayer.hurtableLayerMask = LayerMask.GetMask("Princess");
            }
            else if (youTarget)
            {
                // a princess rescues a dragon from you
                princessScript.aggressionAgainst = player;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Player");
                attackScriptPlayer.canAttack = true;
                attackScriptPlayer.hurtableLayerMask = LayerMask.GetMask("Dragon");
            }
        }
        else if (dragonAggressive)
        {
            dragonScript.aggressive = true;
            if (princessTarget && !youSafe)
            {
                // a dragon rescues you from a princess
                dragonScript.aggressionAgainst = princess;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Princess");
                princessScript.aggressionAgainst = player;
                princessScript.hurtableLayerMask = LayerMask.GetMask("Player");

            } else if(princessTarget && youSafe)
            {
                // you rescue a princess from a dragon
                dragonScript.aggressionAgainst = princess;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Princess");
                attackScriptPlayer.canAttack = true;
                attackScriptPlayer.hurtableLayerMask = LayerMask.GetMask("Dragon");
            }
            else if (youTarget)
            {
                // a dragon rescues a princess from you
                dragonScript.aggressionAgainst = player;
                dragonScript.hurtableLayerMask = LayerMask.GetMask("Player");
                attackScriptPlayer.canAttack = true;
                attackScriptPlayer.hurtableLayerMask = LayerMask.GetMask("Princess");
            }
        }
        else
        {
            GameObject.Find("hint").GetComponent<Text>().text = "press e to attack";
        }
    }

    IEnumerator winLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/WinScreen");
    }
    
    IEnumerator loseLeve()
    {
        yield return new WaitForSeconds(2);
        sceneLoader.LoadInputLevel();
    }
}