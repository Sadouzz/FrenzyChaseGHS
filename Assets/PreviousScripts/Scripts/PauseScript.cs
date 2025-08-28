using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;
    public GameObject shopPanel, homePanel, settingsPanel, trophiesPanel;
    public Text coins;
    public int coinsNumber;

    public static PauseScript instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
            return;
        }
        instance = this; 
    } 

    // Update is called once per frame
   void Start()
    {
    	pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        homePanel.SetActive(true);
        shopPanel.SetActive(false);
        settingsPanel.SetActive(false);
        trophiesPanel.SetActive(false);
    }
    
    void Update()
    {
        coinsNumber = PlayerPrefs.GetInt("Coins", 0);
    	coins.text = coinsNumber.ToString();
    }

    public void Shop()
    {
        shopPanel.SetActive(true);
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        trophiesPanel.SetActive(false);
    }

    public void Home()
    {
        shopPanel.SetActive(false);
        homePanel.SetActive(true);
        settingsPanel.SetActive(false);
        trophiesPanel.SetActive(false);
    }

    public void Settings()
    {
        shopPanel.SetActive(false);
        homePanel.SetActive(false);
        settingsPanel.SetActive(true);
        trophiesPanel.SetActive(false);
    }

    public void Trophies()
    {
        shopPanel.SetActive(false);
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        trophiesPanel.SetActive(true);
    }

    public void Resume()
    {
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
        pauseButton.SetActive(true);
    }

    public void Pause()
    {
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
        pauseButton.SetActive(false);
    }
}
