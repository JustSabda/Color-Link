using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Wilberforce;

public class SceneLoad : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject selectLevelPanel;
    public GameObject creditPanel;
    public GameObject settingsPanel;

    bool settings = false;

    public static SceneLoad Instance { get; private set; }

    private int currentSceneIndex;
    private int sceneToContinue;



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

    private void Start()
    {
        Time.timeScale = 1f;

        if (AudioManager.Instance.x == true)
        {
            if (SceneManager.GetActiveScene().name == ("MainMenu"))
            {
                AudioManager.Instance.PlayMusic("MainMenu");
            }
            else if (SceneManager.GetActiveScene().name == ("Cutscene") ||
                SceneManager.GetActiveScene().name == ("BlindColor Cutscene"))
            {
                AudioManager.Instance.PlayMusic("Cutscene");
            }
            else
            {
                AudioManager.Instance.PlayMusic("Level");
            }


            AudioManager.Instance.x = false;
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
    public void NewGame()
    {
        
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        
        AudioManager.Instance.x = true;

    }

    public void SelectLevelPanel()
    {
        if (menuPanel == null || selectLevelPanel == null || creditPanel == null || settingsPanel == null)
        {
            return;
        }
        else
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            creditPanel.SetActive(false);
            selectLevelPanel.SetActive(true);
        }
    }

    public void SettingPanel()
    {
        settings = !settings;

        if (settings == true)
            settingsPanel.SetActive(true);
        else
            settingsPanel.SetActive(false);
    }


    public void CreditPanel()
    {
        if (menuPanel == null || selectLevelPanel == null || creditPanel == null || settingsPanel == null)
        {
            return;
        }
        else
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            creditPanel.SetActive(true);
            selectLevelPanel.SetActive(false);
        }
    }

    public void Back()
    {
        if (menuPanel == null || selectLevelPanel == null || creditPanel == null || settingsPanel == null)
        {
            return;
        }
        else
        {
            menuPanel.SetActive(true);
            settingsPanel.SetActive(false);
            creditPanel.SetActive(false);
            selectLevelPanel.SetActive(false);
        }
    }

    public void BackMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        
        SceneManager.LoadScene(0);
        AudioManager.Instance.x = true;

    }

    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;
        Time.timeScale = 1f;

        AudioManager.Instance.x = true;
    }

    public void openLevelNormal(int level)
    {
        
        if (level != 1)
            SceneManager.LoadScene(level);
        else
            NextLevel();
        AudioManager.Instance.x = true;
    }

    public void openLevelBlindMode(int level)
    {
        
        if (level != 1)
            SceneManager.LoadScene(level + 5);
        else
            SceneManager.LoadScene(5);
        AudioManager.Instance.x = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Instance.x = true;
    }


    public void HideImage(GameObject child)
    {
        child.SetActive(false);
    }

    public void RevealImage(GameObject child)
    {
        child.SetActive(true);
    }

}
