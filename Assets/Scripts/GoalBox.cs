using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBox : MonoBehaviour
{

    [SerializeField] private int leadsToLevel;

    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            sceneLoader.currentLevelCount++;
            if (sceneLoader.currentLevelCount <= 2)
            {
                sceneLoader.nextSentence = sceneLoader.levelSentences[sceneLoader.currentLevelCount];
            }
            sceneLoader.LoadInputLevel();
        }
    }
}
