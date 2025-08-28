using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsScriptOnGame : MonoBehaviour
{
    //public GameObject notifManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FirstMission Play20SecondsOnOneParty
        if(InventoryScript.instance.totalSeconds >= 20 && PlayerPrefs.GetString("mission1", "no") == "no")
        {
            PlayerPrefs.SetString("mission1", "yes");
            //GooglePlaySuccess.instance.UnlockSuccess("CgkI4Irdz7UaEAIQBg");
            //GooglePlaySuccess.instance.IncrementSucces("CgkI4Irdz7UaEAIQBg");
            NotificationScript.instance.CallNotif("MISSION 1 TERMINEE", InventoryScript.instance.missionsSprite);
        }

        //SecondMission Destroy150CarsOverall
        if(PlayerPrefs.GetInt("totalDestroyedCars", 0) >= 150 && PlayerPrefs.GetString("mission2", "no") == "no")
        {
            PlayerPrefs.SetString("mission2", "yes");
            NotificationScript.instance.CallNotif("MISSION 2 TERMINEE", InventoryScript.instance.missionsSprite);
        }

        //ThirdMission 10PowerUpsOnOneParty
        if(InventoryScript.instance.usedPower >= 10 && PlayerPrefs.GetString("mission3", "no") == "no")
        {
            //GooglePlaySuccess.instance.UnlockSuccess("CgkI4Irdz7UaEAIQBQ");
            //GooglePlaySuccess.instance.IncrementSucces("CgkI4Irdz7UaEAIQBQ");
            PlayerPrefs.SetString("mission3", "yes");
            NotificationScript.instance.CallNotif("MISSION 3 TERMINEE", InventoryScript.instance.missionsSprite);
        }

        //FourthMission Destroy500CarsOverall
        if(PlayerPrefs.GetInt("totalDestroyedCars", 0) >= 500 && PlayerPrefs.GetString("mission4", "no") == "no")
        {
            //GooglePlaySuccess.instance.UnlockSuccess("CgkI4Irdz7UaEAIQBA");
            //GooglePlaySuccess.instance.IncrementSucces("CgkI4Irdz7UaEAIQBA");
            PlayerPrefs.SetString("mission4", "yes");
            NotificationScript.instance.CallNotif("MISSION 4 TERMINEE", InventoryScript.instance.missionsSprite);
        }

        //FifthMission Play120SecondsOnOneParty
        if(InventoryScript.instance.totalSeconds >= 120 && PlayerPrefs.GetString("mission5", "no") == "no")
        {
            PlayerPrefs.SetString("mission5", "yes");
            NotificationScript.instance.CallNotif("MISSION 5 TERMINEE", InventoryScript.instance.missionsSprite);
        }

        //SixthMission Destroy100CarsOnOneParty
        if (PoliceSpawner.instance.destroyedCars >= 100 && PlayerPrefs.GetString("mission6", "no") == "no")
        {
            //GooglePlaySuccess.instance.UnlockSuccess("CgkI4Irdz7UaEAIQAw");
            //GooglePlaySuccess.instance.IncrementSucces("CgkI4Irdz7UaEAIQAw");
            PlayerPrefs.SetString("mission6", "yes");
            NotificationScript.instance.CallNotif("MISSION 6 TERMINEE", InventoryScript.instance.missionsSprite);
        }

        //SeventhMission Watch10Ads
        /*if(AdMob.instance.watchedCount >= 10 && PlayerPrefs.GetString("mission7", "no") == "no")
        {
            PlayerPrefs.SetString("mission7", "yes");
            NotificationScript.instance.CallNotif("MISSION 7 TERMINEE", InventoryScript.instance.missionsSprite);
        }*/

        //EighthMission Play240SecondsOnOneParty
        if(InventoryScript.instance.totalSeconds >= 240 && PlayerPrefs.GetString("mission8", "no") == "no")
        {
            //GooglePlaySuccess.instance.UnlockSuccess("CgkI4Irdz7UaEAIQAg");
            //GooglePlaySuccess.instance.IncrementSucces("CgkI4Irdz7UaEAIQAg");
            PlayerPrefs.SetString("mission8", "yes");
            NotificationScript.instance.CallNotif("MISSION 8 TERMINEE", InventoryScript.instance.missionsSprite);
        }
    }
}
