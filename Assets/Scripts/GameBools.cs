using System;
using UnityEngine;

public class GameBools : MonoBehaviour
{
    public static GameBools instance;
    public bool Level1Fire { get; set; } = false;
    public bool Level1BridgeBurn { get; set; } = false;
    public bool Level2Hero { get; set; } = false;
    public bool Level2Void { get; set; } = false;
    public bool Level3PrincessAggressive { get; set; } = false;
    public bool Level3PrincessTarget { get; set; } = false;
    public bool Level3DragonAggressive { get; set; } = false;
    public bool Level3DragonTarget { get; set; } = false;
    public bool Level3YouTarget { get; set; } = false;
    
    public String kill { get; set; }
    
    public String safe { get; set; }

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
    
    public void AssignBoolsLevel2(bool[] boolList)
    {
        for (int i = 0; i <= boolList.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Level2Hero = boolList[0];
                    break;
                case 1:
                    Level2Void = boolList[1];
                    break;
            }
        }
    }
    
    public void AssignBoolsLevel3(bool[] boolList, String kill, String safe)
    {
        for (int i = 0; i <= boolList.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Level3PrincessAggressive = boolList[0];
                    break;
                case 1:
                    Level3PrincessTarget = boolList[1];
                    break;
                case 2:
                    Level3DragonAggressive = boolList[2];
                    break;
                case 3:
                    Level3DragonTarget = boolList[3];
                    break;
                case 4:
                    Level3YouTarget = boolList[4];
                    break;
            }
        }
        this.kill = kill;
        
        this.safe = safe;
    }
}
