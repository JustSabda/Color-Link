using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public GameObject tutorialPanel;

    public GameObject inGamePanel;


    // Start is called before the first frame update
    [Header("MusicBtn")]
    public GameObject musicBtnOn;

    [Header("SFXBtn")]
    public GameObject SFXBtnOn;

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
        if (SceneManager.GetActiveScene().name != ("MainMenu"))
        {
            if (panelWin != null)
            {
                panelWin.SetActive(false);
            }
            if (panelLose != null)
            {
                panelLose.SetActive(false);
            }

            isPaused = true;
            Time.timeScale = 0f;

            UnhideCursor();
        }

        
    }



    // Update is called once per frame
    private void Update()
    {

        if (SceneManager.GetActiveScene().name != ("MainMenu"))
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

            if (GameManager.Instance.isWin == true && panelWin != null && soundPlayWin == true )
            {
                panelWin.SetActive(true);
                AudioManager.Instance.PlaySFX("WinSFX");
                soundPlayWin = false;
            }

            if (GameManager.Instance.isLose == true && panelLose != null && soundPlayLose == true)
            {
                panelLose.SetActive(true);
                AudioManager.Instance.PlaySFX("LoseSFX");
                soundPlayLose = false;
            }
        }

        if (!AudioManager.Instance.musicSource.mute)
        {
            musicBtnOn.SetActive(true);
        }
        else
        {
            musicBtnOn.SetActive(false);
        }

        if (!AudioManager.Instance.sfxSource.mute)
        {
            SFXBtnOn.SetActive(true);
        }
        else
        {
            SFXBtnOn.SetActive(false);
        }

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
        UnhideCursor();
    }
    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);

        Time.timeScale = 1f;
        HideCursor();

        if (tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(false);
            inGamePanel.SetActive(true);
        }
  
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void UnhideCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }



}
