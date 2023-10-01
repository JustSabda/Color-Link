using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainTime;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(remainTime > 0)
        {
            remainTime -= Time.deltaTime;
        }
        else if (remainTime < 0)
        {
            remainTime = 0;
            //GameOver

        }

        //remainTime += Time.deltaTime;
        int minute = Mathf.FloorToInt(remainTime / 60);
        int seconds = Mathf.FloorToInt(remainTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minute, seconds);
    }
}
