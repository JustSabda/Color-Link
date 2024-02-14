using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI timerWinText;
    [SerializeField] private Image timerImg;
    
    [SerializeField] public float remainTime;
    float startTimer;


    float gameTime;


    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    void Start()
    {
        startTimer = remainTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isWin == false && GameManager.Instance.isLose == false)
        {
            if (remainTime > 0)
            {
                remainTime -= Time.deltaTime;
            }
            else if (remainTime < 0)
            {
                remainTime = 0;
                //GameOver

            }
        }
        if(GameManager.Instance.isWin == false && GameManager.Instance.isLose == false)
        {
            gameTime += Time.deltaTime;
        }


        timerText.text = remainTime.ToString("0");
        //remainTime += Time.deltaTime;
        //int minute = Mathf.FloorToInt(gameTime / 60);
        //int seconds = Mathf.FloorToInt(gameTime % 60);
        //timerWinText.text = string.Format("{minute}:{seconds}", minute, seconds);

        int seconds = Mathf.FloorToInt(gameTime);

        timerWinText.text = seconds + " second";

        //if (minute == 0)
        //    timerWinText.text = seconds + " second";
        //else if (seconds == 0)
        //    timerWinText.text = minute + " minute";
        //else if (seconds != 0 && minute != 0)
        //    timerWinText.text = minute + " minute " + seconds + " second";
       
        if(timerImg != null)
        timerImg.fillAmount = GameManager.Instance.GetPercent(remainTime, startTimer);

    }


}
