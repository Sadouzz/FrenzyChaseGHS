using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailyQuestScriptOnGame : MonoBehaviour
{
    public int r;
    // Start is called before the first frame update
    void Start()
    {
        r = PlayerPrefs.GetInt("randomDailyMissionPicker", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(r == 0)
        {
            if (InventoryScript.instance.totalSeconds >= 60 && PlayerPrefs.GetString("dailyMission", "no") == "no")
            {
                PlayerPrefs.SetString("dailyMission", "yes");
            }
        }
        if(r == 1)
        {
            if (PoliceSpawner.instance.destroyedCars >= 50 && PlayerPrefs.GetString("dailyMission", "no") == "no")
            {
                PlayerPrefs.SetString("dailyMission", "yes");
            }
        }
        if (r == 2)
        {
            if (InventoryScript.instance.totalSeconds >= 50 && PlayerPrefs.GetString("dailyMission", "no") == "no")
            {
                PlayerPrefs.SetString("dailyMission", "yes");
            }
        }
    }
}
