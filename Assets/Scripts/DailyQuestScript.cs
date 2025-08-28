using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuestScript : MonoBehaviour
{
    public TextMeshProUGUI remainingTime;
    public TextMeshProUGUI missionText;
    public Button claimButton;
    public string[] missions;

    public DateTime tmr8AM;
    // Start is called before the first frame update
    void Start()
    {
        DateTime time;
        time = DateTime.Parse(PlayerPrefs.GetString("tmr8AM", DateTime.Now.ToString()));
        Debug.Log(time.ToString());
        Debug.Log(time.Subtract(DateTime.Now));
        if (time.Subtract(DateTime.Now) < TimeSpan.Zero)
        {
            SetNewTime();
            Debug.Log("New");
        }
        else
        {
            tmr8AM = DateTime.Parse(PlayerPrefs.GetString("tmr8AM", "08:00:00"));
            missionText.text = missions[PlayerPrefs.GetInt("randomDailyMissionPicker", 0)];
            Debug.Log("Previous");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = tmr8AM.Subtract(DateTime.Now);
        if (ts.Hours < 10)
        {
            if(ts.Minutes < 10)
            {
                if (ts.Seconds < 10)
                {
                    remainingTime.text = "0" + ts.Hours + ":0" + ts.Minutes + ":0" + ts.Seconds;
                }
                else
                {
                    remainingTime.text = "0" + ts.Hours + ":0" + ts.Minutes + ":" + ts.Seconds;
                }
            }
            else
            {
                if (ts.Seconds < 10)
                {
                    remainingTime.text = "0" + ts.Hours + ":" + ts.Minutes + ":0" + ts.Seconds;
                }
                else
                {
                    remainingTime.text = "0" + ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
                }
            }
        }
        else
        {
            if (ts.Minutes < 10)
            {
                if (ts.Seconds < 10)
                {
                    remainingTime.text = ts.Hours + ":0" + ts.Minutes + ":0" + ts.Seconds;
                }
                else
                {
                    remainingTime.text = ts.Hours + ":0" + ts.Minutes + ":" + ts.Seconds;
                }
            }
            else
            {
                if (ts.Seconds < 10)
                {
                    remainingTime.text = ts.Hours + ":" + ts.Minutes + ":0" + ts.Seconds;
                }
                else
                {
                    remainingTime.text = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
                }
            }
        }
        
        if(PlayerPrefs.GetString("dailyMission", "no") == "yes")
        {
            claimButton.interactable = true;
        }
        else
        {
            claimButton.interactable = false;
            if(PlayerPrefs.GetString("dailyMission", "no") == "collected")
            {
                claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "deja recupere";
            }
        }
    }

    void SetNewTime()
    {
        DateTime tmr;
        tmr = DateTime.Now.AddDays(1);
        tmr8AM = new DateTime(tmr.Year, tmr.Month, tmr.Day, 8, 0, 0);
        PlayerPrefs.SetString("tmr8AM", tmr8AM.ToString());

        SetNewMission();
    }

    void SetNewMission()
    {
        int r = UnityEngine.Random.Range(0, 2);
        PlayerPrefs.SetInt("randomDailyMissionPicker", r);
        missionText.text = missions[r];
        //PlayerPrefs.SetString("dailyMissionText", missions[r]);
        PlayerPrefs.SetString("dailyMission", "no");
        claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "recuperer";
    }

    public void ClaimReward()
    {
        PlayerPrefs.SetString("dailyMission", "collected");
        claimButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "deja recupere";
        UIScript.instance.ClaimRewardOnPack("blue");
    }
}
