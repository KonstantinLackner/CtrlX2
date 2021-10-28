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
        Variation testVariationS1V1 = new Variation("you burn the bridge", 1, boolListVariationS1V1, null);
        
        bool[] boolListVariationS1V2 = {false, false};
        Variation testVariationS1V2 = new Variation("you cross the bridge", 1, boolListVariationS1V2, null);
        
        bool[] boolListVariationS1V3 = {true, false};
        Variation testVariationS1V3 = new Variation("you cross the burning bridge", 1, boolListVariationS1V3, null);
            
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
        Variation testVariationS2V1 = new Variation("you are a hero", 2, boolListVariationS2V1, null);
        
        bool[] boolListVariationS2V2 = {false, true};
        Variation testVariationS2V2 = new Variation("you are not", 2, boolListVariationS2V2, null);
        
        bool[] boolListVariationS2V3 = {false, false};
        Variation testVariationS2V3 = new Variation("you are not a hero", 2, boolListVariationS2V3, null);
            
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
        Sentence sentence3 = new Sentence("a princess rescues a dragon from you", 0, 2);
        
        // princess aggressive, princess target, dragon aggressive, dragon target, you target, playerSafes
        bool[] boolListVariationS3V1 = {true, false, false, false, true, false};
        String[] killSafe1 = {"you", "dragon"};
        Variation testVariationS3V1 = new Variation("a princess rescues a dragon from you", 3, boolListVariationS3V1, killSafe1);
        
        bool[] boolListVariationS3V2 = {true, false, false, true, false, false};
        String[] killSafe2 = {"dragon", "you"};
        Variation testVariationS3V2 = new Variation("a princess rescues you from a dragon", 3, boolListVariationS3V2, killSafe2);
        
        bool[] boolListVariationS3V3 = {false, true, true, false, false, false};
        String[] killSafe3 = {"princess", "you"};
        Variation testVariationS3V3 = new Variation("a dragon rescues you from a princess", 3, boolListVariationS3V3, killSafe3);
        
        bool[] boolListVariationS3V4 = {false, false, true, false, true, false};
        String[] killSafe4 = {"you", "princess"};
        Variation testVariationS3V4 = new Variation("a dragon rescues a princess from you", 3, boolListVariationS3V4, killSafe4);
        
        bool[] boolListVariationS3V5 = {false, true, true, false, false, true};
        String[] killSafe5 = {"dragon", "princess"};
        Variation testVariationS3V5 = new Variation("you rescue a princess from a dragon", 3, boolListVariationS3V5, killSafe5);
        
        bool[] boolListVariationS3V6 = {true, false, false, true, false, true};
        String[] killSafe6 = {"princess", "dragon"};
        Variation testVariationS3V6 = new Variation("you rescue a dragon from a princess", 3, boolListVariationS3V6, killSafe6);
        
        LinkedList<Variation> variationsSentence3 = new LinkedList<Variation>();
        variationsSentence3.AddLast(testVariationS3V1);
        variationsSentence3.AddLast(testVariationS3V2);
        variationsSentence3.AddLast(testVariationS3V3);
        variationsSentence3.AddLast(testVariationS3V4);
        variationsSentence3.AddLast(testVariationS3V5);
        variationsSentence3.AddLast(testVariationS3V6);

        sentence3.variations = variationsSentence3;
        // ------------------------------------------
        
        levelSentences = new[] {sentence1, sentence2, sentence3};
    }

    private void Start()
    {
        gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();
    }

    public void LoadLevel(int levelToLoad, bool[] boolList, String[] killSafe)
    {
        if (levelToLoad == 1)
        {
            LoadLevel1(boolList);
        } else if (levelToLoad == 2)
        {
            LoadLevel2(boolList);
        } else if (levelToLoad == 3)
        {
            LoadLevel3(boolList, killSafe);
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
        StartCoroutine(LoadLevel2Coroutine());
    }

    IEnumerator LoadLevel2Coroutine()
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("Scenes/Level2");
    }
    
    public void LoadLevel3(bool[] boolList, String[] killSafe)
    {
        gameBools.AssignBoolsLevel3(boolList, killSafe[0], killSafe[1]);
        StartCoroutine(LoadLevel3Coroutine());
    }

    IEnumerator LoadLevel3Coroutine()
    {
        yield return new WaitForSeconds(0.1f);

        SceneManager.LoadScene("Scenes/Level3");
    }
}
