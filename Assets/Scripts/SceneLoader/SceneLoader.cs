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
         * Sentence 1
         * -------------------------------------------
         */
        Sentence sentence1 = new Sentence("you cross the burning bridge", 2, 1);
        
        nextSentence = sentence1;
        
        bool[] boolListVariationS1V1 = {false, true};
        Variation testVariationS1V1 = new Variation("you burn the bridge", 1, boolListVariationS1V1);
        
        bool[] boolListVariationS1V2 = {false, false};
        Variation testVariationS1V2 = new Variation("you cross the bridge", 1, boolListVariationS1V2);
        
        bool[] boolListVariationS1V3 = {true, false};
        Variation testVariationS1V3 = new Variation("you cross the burning bridge", 1, boolListVariationS1V3);
            
        LinkedList<Variation> variationsSentence1 = new LinkedList<Variation>();
        variationsSentence1.AddLast(testVariationS1V1);
        variationsSentence1.AddLast(testVariationS1V2);
        variationsSentence1.AddLast(testVariationS1V3);

        sentence1.variations = variationsSentence1;
        // ------------------------------------------
        
        /*
        * Sentence 2
        * -------------------------------------------
        */
        Sentence sentence2 = new Sentence("you are not a hero", 2, 0);
        
        bool[] boolListVariationS2V1 = {true, false};
        Variation testVariationS2V1 = new Variation("you are a hero", 2, boolListVariationS2V1);
        
        bool[] boolListVariationS2V2 = {false, true};
        Variation testVariationS2V2 = new Variation("you are not", 2, boolListVariationS2V2);
        
        bool[] boolListVariationS2V3 = {false, false};
        Variation testVariationS2V3 = new Variation("you are not a hero", 2, boolListVariationS2V3);
            
        LinkedList<Variation> variationsSentence2 = new LinkedList<Variation>();
        variationsSentence2.AddLast(testVariationS2V1);
        variationsSentence2.AddLast(testVariationS2V2);
        variationsSentence2.AddLast(testVariationS2V3);

        sentence2.variations = variationsSentence2;
        // ------------------------------------------
        
        /*
        * Sentence 3
        * -------------------------------------------
        */
        Sentence sentence3 = new Sentence("you are not a hero", 2, 0);
        
        bool[] boolListVariationS3V1 = {true, false};
        Variation testVariationS3V1 = new Variation("you are a hero", 2, boolListVariationS3V1);
        
        bool[] boolListVariationS3V2 = {false, true};
        Variation testVariationS3V2 = new Variation("you are not", 2, boolListVariationS3V2);
        
        bool[] boolListVariationS3V3 = {false, false};
        Variation testVariationS3V3 = new Variation("you are not a hero", 2, boolListVariationS3V3);
            
        LinkedList<Variation> variationsSentence3 = new LinkedList<Variation>();
        variationsSentence3.AddLast(testVariationS3V1);
        variationsSentence3.AddLast(testVariationS3V2);
        variationsSentence3.AddLast(testVariationS3V3);

        sentence2.variations = variationsSentence2;
        // ------------------------------------------
        
        levelSentences = new[] {sentence1, sentence2, sentence3};
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
            LoadLevel2(boolList);
        } else if (levelToLoad == 3)
        {
            // LoadLevel3(boolList);
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
    
    public void LoadLevel2(bool[] boolList)
    {
        gameBools.AssignBoolsLevel2(boolList);
        // nextSentence = levelSentences[1];
        StartCoroutine(LoadLevel2Coroutine());
    }

    IEnumerator LoadLevel2Coroutine()
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("Scenes/Level2");
    }
}
