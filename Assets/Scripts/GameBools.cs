using UnityEngine;

public class GameBools : MonoBehaviour
{
    public static GameBools instance;
    public bool Level1Fire { get; set; } = false;
    public bool Level1BridgeBurn { get; set; } = false;
    public bool Level2Hero { get; set; } = false;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void AssignBoolsLevel1(bool[] boolList)
    {
        for (int i = 0; i <= boolList.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Level1Fire = boolList[0];
                    break;
                case 1:
                    Level1BridgeBurn = boolList[1];
                    break;
            }
        }
    }
}
