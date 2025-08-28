using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class PlayScript : MonoBehaviour
{
    public bool play;
    public PlayerMovement playerMovement;
    public GameObject carParts, playPanel, pausePanel, diePanel, loadingScreen;
    public Transform car;

    public static PlayScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        //Time.timeScale = 0.5f;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        carParts = GameObject.FindGameObjectWithTag("Car");
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    /*void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // L'application est mise en veille
            Pause();
        }
        else
        {
            // L'application reprend
            Debug.Log("Application reprise");
        }
    }*/

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            // L'application est mise en veille
            Pause();
        }
        else
        {
            // L'application reprend
            Debug.Log("Application reprise");
        }
    }


    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Home()
    {
        //AdMob.instance.DestroyAd();
        SceneManager.LoadScene(0);
        InventoryScript.instance.SaveData();
        Time.timeScale = 1;
    }

    public void Retry()
    {
        //AdMob.instance.DestroyAd();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
