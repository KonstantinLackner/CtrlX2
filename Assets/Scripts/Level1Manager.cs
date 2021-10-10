using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameBools gameBools = GameObject.Find("GameBools").GetComponent<GameBools>();
        
        initLevel(gameBools.Level1Fire, gameBools.Level1BridgeBurn);
    }

    public void initLevel(bool fire, bool bridgeBurn)
    {
        if (fire)
        {
            GameObject.Find("bridge").SetActive(true);
            GameObject.Find("BridgeFire").SetActive(true);
            GameObject.Find("burnedBridge").SetActive(false);
            GameObject.Find("BridgeFireLeft").SetActive(false);
            GameObject.Find("BridgeFireRight").SetActive(false);
        } else if (bridgeBurn)
        {
            GameObject.Find("BridgeFireLeft").SetActive(true);
            GameObject.Find("BridgeFireRight").SetActive(true);
            GameObject.Find("burnedBridge").SetActive(true);
            GameObject.Find("BridgeFire").SetActive(false);
            GameObject.Find("bridge").SetActive(false);
        }
        else
        {
            GameObject.Find("bridge").SetActive(true);
            GameObject.Find("burnedBridge").SetActive(false);
            GameObject.Find("BridgeFireLeft").SetActive(false);
            GameObject.Find("BridgeFireRight").SetActive(false);
            GameObject.Find("BridgeFire").SetActive(false);
        }
    }
}
