using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Platform> platformList = new List<Platform>();

    //public Platform[] WinFlag;

    int objectiveDone;

    // Start is called before the first frame update
    void Start()
    {
        

        var platformArray = FindObjectsOfType<Platform>();
        for (int i = 0; i < platformArray.Length; i++)
        {
            if (platformArray[i].isFlag)
                platformList.Add(platformArray[i]);

        }
    }



    // Update is called once per frame
    void Update()
    {
        foreach(var flags in platformList)
        {
            if(flags.GetComponent<Platform>().flagConneted == true)
            {
                WinGame();
            }
        }

        if(Timer.Instance.remainTime == 0)
        {
            LoseGame();
        }

    }
    
    private void WinGame()
    {
        Debug.Log("Win");
    }
    
    private void LoseGame()
    {
        Debug.Log("Lose");
    }
}
