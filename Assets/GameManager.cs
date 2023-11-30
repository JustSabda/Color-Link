using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<Platform> platformList = new List<Platform>();

    //public Platform[] WinFlag;

    int objectiveDone;

    [HideInInspector] public bool isWin = false;
    [HideInInspector] public bool isLose = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

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
        if(platformList.All(go => go.GetComponent<Platform>().flagConneted == true))
        {
            isWin = true;
        }

        //foreach(var flags in platformList)
        //{
        //    if(flags.GetComponent<Platform>().flagConneted == false)
        //    {
        //        isWin = true;
        //    }
        //}

        if (Timer.Instance.remainTime == 0)
        {
            isLose = true;
        }

        if (isWin)
        {
            WinGame();
        }

        if (isLose)
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
