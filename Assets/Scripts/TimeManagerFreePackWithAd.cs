using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManagerFreePackWithAd : MonoBehaviour
{
    public Button freepackButton;
    //public float totalSecondsRemaining;
    public bool finished;

    public TextMeshProUGUI timerText;

    public static TimeManagerFreePackWithAd instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.sceneUnloaded += OnSceneUnloaded;

        DateTime dateNow = DateTime.Now;
        //DateTime dateQuit = DateTime.Parse(PlayerPrefs.GetString("dateQuit", ""));
        DateTime dateFinish = DateTime.Parse(PlayerPrefs.GetString("dateFinishWithAd", DateTime.Now.ToString()));
        //TimeSpan interval = dateNow - dateQuit;
        //totalSecondsRemaining = PlayerPrefs.GetFloat("totalSecondsRemainingForAd", 300);
        //TimeSpan remainingTime = TimeSpan.FromSeconds(totalSecondsRemaining);

        TimeSpan difference = dateFinish.Subtract(dateNow);

        //TimeSpan ts = remainingTime - difference;
        /*if (totalSecondsRemaining == 0)
        {
            remainingTime = TimeSpan.Zero;
            ts = remainingTime;
        }*/

        


        if(difference <= TimeSpan.Zero)
        {
            //Finished
            finished = true;
            timerText.text = "Regarder";
            //freepackButton.interactable = true;
        }
        else
        {
            //Not finished
            finished = false;
            //totalSecondsRemaining = Convert.ToSingle(ts.TotalSeconds);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = DateTime.Parse(PlayerPrefs.GetString("dateFinishWithAd", DateTime.Now.ToString())).Subtract(DateTime.Now);
        if (!finished)
        {
            freepackButton.interactable = false;
            //totalSecondsRemaining -= Time.deltaTime;
            //TimeSpan ts = TimeSpan.FromSeconds(totalSecondsRemaining);
            timerText.text = ts.Minutes + "min" + ts.Seconds + "s";
        }
        else
        {
            timerText.text = "Regarder";
        }

        if (ts <= TimeSpan.Zero)
        {
            finished = true;
            if(this.GetComponent<RewardedAdsButton>().canClick)
            {
                freepackButton.interactable = true;
            }
            //freepackButton.interactable = true;
        }
        
    }

    public void OnResetTimer()
    {
        //totalSecondsRemaining = 300;
        finished = false;
        PlayerPrefs.SetString("dateFinishWithAd", DateTime.Now.AddSeconds(300).ToString());
    }

    /*private void OnApplicationQuit()
    {
        SavingTime();
    }*/

    /*void OnSceneUnloaded(Scene scene)
    {
        SavingTime();
        Debug.Log("Change Scene");
    }*/

    public void SavingTime()
    {
        //DateTime dateQuit = DateTime.Now;
        /*if (totalSecondsRemaining <= 0)
        {
            PlayerPrefs.SetFloat("totalSecondsRemainingForAd", 0);
        }
        else
        {
            PlayerPrefs.SetFloat("totalSecondsRemainingForAd", totalSecondsRemaining);
        }*/
        
        //PlayerPrefs.SetString("dateQuit", DateTime.Now.ToString());
    }
}
