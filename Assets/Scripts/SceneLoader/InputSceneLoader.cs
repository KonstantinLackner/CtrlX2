using DefaultNamespace;
using UnityEngine;

public class InputSceneLoader : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private SceneLoader sceneLoader;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.Play();
        gameStateManager = GameObject.Find("Game State Manager").GetComponent<GameStateManager>();
        sceneLoader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
        gameStateManager.InitLevel(sceneLoader.nextSentence);
    }
}
