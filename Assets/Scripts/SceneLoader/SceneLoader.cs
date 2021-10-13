using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    // public Animator transitionAnimator;
    public String answer { get; set; }
    public Sentence nextSentence { get; set; }

    private GameBools gameBools;
    public Sentence[] levelSentences { get; set; }

    public int currentLevelCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        /*
         * Bullshit test init
         */
        Sentence testSentence1 = new Sentence("you cross the burning bridge", 2, 1);
        Sentence testSentence2 = new Sentence("you are not a hero",3, 0);
        Sentence testSentence3 = new Sentence("you rescue a princess from a dragon", 0, 1);
        
        nextSentence = testSentence1;

        levelSentences = new[] {testSentence1, testSentence2, testSentence3};

        bool[] boolListVariationS1V1 = {false, true};
        Variation testVariationS1V1 = new Variation("you burn the bridge", 1, boolListVariationS1V1);
        
        bool[] boolListVariationS1V2 = {false, false};
        Variation testVariationS1V2 = new Variation("you cross the bridge", 1, boolListVariationS1V2);
        
        bool[] boolListVariationS1V3 = {true, false};
        Variation testVariationS1V3 = new Variation("you cross the burning bridge", 1, boolListVariationS1V3);
            
        LinkedList<Variation> variations = new LinkedList<Variation>();
        variations.AddLast(testVariationS1V1);
        variations.AddLast(testVariationS1V2);
        variations.AddLast(testVariationS1V3);

        testSentence1.variations = variations;
    }

    private void Start()
    {
        gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();
    }

    public void LoadLevel(int levelToLoad, bool[] boolList)
    {
        if (levelToLoad == 1)
        {
            LoadLevel1(boolList);
        } else if (levelToLoad == 2)
        {
            
        } else if (levelToLoad == 3)
        {
            
        }
    }
    
    public void LoadInputLevel()
    {
        StartCoroutine(LoadInputLevelCoroutine());
    }
    
    IEnumerator LoadInputLevelCoroutine()
    {

        // transitionAnimator.SetTrigger("StartFade");

        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("Scenes/Input");
    }

    public void LoadLevel1(bool[] boolList)
    {
        gameBools.AssignBoolsLevel1(boolList);
        // nextSentence = levelSentences[1];
        StartCoroutine(LoadLevel1Coroutine());
    }

    IEnumerator LoadLevel1Coroutine()
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("Scenes/Level1");
    }
}
