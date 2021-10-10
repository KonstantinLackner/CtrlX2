using System;
using System.Collections.Generic;
using UnityEngine;

public class GameBools : MonoBehaviour
{
    public static GameBools instance;
    public bool Level1Fire { get; set; } = false;
    public bool Level1BridgeBurn { get; set; } = false;

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
    public void AssignBoolsLevel1(LinkedList<bool> boolList)
    {
        for (int i = 0; i <= boolList.Count; i++)
        {
            switch (i)
            {
                case 0:
                    Level1Fire = boolList.First.Value;
                    boolList.RemoveFirst();
                    break;
                case 1:
                    Level1BridgeBurn = boolList.First.Value;
                    boolList.RemoveFirst();
                    break;
            }
        }
    }
}
