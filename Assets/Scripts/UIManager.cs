using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [HideInInspector]
    public bool isPaused;

    [SerializeField]
    private GameObject panelWin;

    public GameObject panelLose;

    public GameObject pausePanel;


    // Start is called before the first frame update
    [Header("MusicBtn")]
    public GameObject musicBtnOn;
    public GameObject musicBtnOff;

    [Header("SFXBtn")]
    public GameObject SFXBtnOn;
    public GameObject SFXBtnOff;

    bool soundPlayWin = true;
    bool soundPlayLose = true;

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
    private void Start()
    {
        if(panelWin != null)
        {
            panelWin.SetActive(false);
        }
        if (panelLose != null)
        {
            panelLose.SetActive(false);
        }
        
    }



    // Update is called once per frame
    private void Update()
    {



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        //if (!AudioManager.Instance.musicSource.mute)
        //{
        //    musicBtnOn.SetActive(true);
        //    musicBtnOff.SetActive(false);
        //}
        //else
        //{
        //    musicBtnOn.SetActive(false);
        //    musicBtnOff.SetActive(true);
        //}

        //if (!AudioManager.Instance.sfxSource.mute)
        //{
        //    SFXBtnOn.SetActive(true);
        //    SFXBtnOff.SetActive(false);
        //}
        //else
        //{
        //    SFXBtnOn.SetActive(false);
        //    SFXBtnOff.SetActive(true);
        //}


        //if (GameManager.Instance.isWin == true && panelWin != null && soundPlayWin == true)
        //{
        //    panelWin.SetActive(true);
        //    AudioManager.Instance.PlaySFX("SFX_Win");
        //    soundPlayWin = false;
        //}

        //if (GameManager.Instance.isLose == true && panelLose != null && soundPlayLose == true)
        //{
        //    panelLose.SetActive(true);
        //    AudioManager.Instance.PlaySFX("SFX_Lose");
        //    soundPlayLose = false;
        //}

    }


    public void musicBtn()
    {
       
        AudioManager.Instance.ToogleMusic();

    }

    public void SFXBtn()
    {
       
        AudioManager.Instance.ToogleSFX();

    }


    public void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

    }


}
