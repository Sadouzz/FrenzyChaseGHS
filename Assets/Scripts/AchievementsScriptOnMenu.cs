using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsScriptOnMenu : MonoBehaviour
{
    public Button[] buttons;
    public TextMeshProUGUI textMission2, textMission4, textMission7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (AdMob.instance.watchedCount >= 10 && PlayerPrefs.GetString("mission7", "no") == "no")
        {
            PlayerPrefs.SetString("mission7", "yes");
        }
        textMission2.text = PlayerPrefs.GetInt("totalDestroyedCars", 0).ToString();
        textMission4.text = PlayerPrefs.GetInt("totalDestroyedCars", 0).ToString();
        textMission7.text = PlayerPrefs.GetInt("watchedAdsCount", 0).ToString();*/

        //FirstMission Play20SecondsOnOneParty
        if (PlayerPrefs.GetString("mission1", "no") == "yes" && PlayerPrefs.GetString("mission1Collected", "no") == "no")
        {
            buttons[0].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission1Collected", "no") == "yes")
            {
                buttons[0].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[0].interactable = false;
        }

        //SecondMission Destroy150CarsOverall
        if (PlayerPrefs.GetString("mission2", "no") == "yes" && PlayerPrefs.GetString("mission2Collected", "no") == "no")
        {
            buttons[1].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission2Collected", "no") == "yes")
            {
                buttons[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[1].interactable = false;
        }

        //ThirdMission 10PowerUpsOnOneParty
        if (PlayerPrefs.GetString("mission3", "no") == "yes" && PlayerPrefs.GetString("mission3Collected", "no") == "no")
        {
            buttons[2].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission3Collected", "no") == "yes")
            {
                buttons[2].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[2].interactable = false;
        }

        //FourthMission Destroy500CarsOverall
        if (PlayerPrefs.GetString("mission4", "no") == "yes" && PlayerPrefs.GetString("mission4Collected", "no") == "no")
        {
            buttons[3].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission4Collected", "no") == "yes")
            {
                buttons[3].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[3].interactable = false;
        }

        //FifthMission Play120SecondsOnOneParty
        if (PlayerPrefs.GetString("mission5", "no") == "yes" && PlayerPrefs.GetString("mission5Collected", "no") == "no")
        {
            buttons[4].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission5Collected", "no") == "yes")
            {
                buttons[4].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[4].interactable = false;
        }

        //SixthMission Destroy100CarsOnOneParty
        if (PlayerPrefs.GetString("mission6", "no") == "yes" && PlayerPrefs.GetString("mission6Collected", "no") == "no")
        {
            buttons[5].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission6Collected", "no") == "yes")
            {
                buttons[5].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[5].interactable = false;
        }

        //SeventhMission Watch10Ads
        if ((PlayerPrefs.GetString("mission7", "no") == "yes" || PlayerPrefs.GetInt("watchedAds", 0) >= 10) && PlayerPrefs.GetString("mission7Collected", "no") == "no")
        {
            buttons[6].interactable = true;
        }
        else
        {
            if (PlayerPrefs.GetString("mission7Collected", "no") == "yes")
            {
                PlayerPrefs.SetString("mission7", "yes");
                buttons[6].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[6].interactable = false;
        }

        //EighthMission Play240SecondsOnOneParty
        if (PlayerPrefs.GetString("mission8", "no") == "yes" && PlayerPrefs.GetString("mission8Collected", "no") == "no")
        {
            buttons[7].interactable = true;
        }
        else
        {
            if(PlayerPrefs.GetString("mission8Collected", "no") == "yes")
            {
                buttons[7].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DEJA COLLECTE";
            }
            buttons[7].interactable = false;
        }
    }

    public void CollectRewardFromMission(int _index)
    {
        buttons[_index - 1].interactable = false;
        PlayerPrefs.SetString("mission" + _index + "Collected", "yes");
        if(_index == 1)
        {
            NotificationScript.instance.CallNotif("VOUS RECEVEZ 100 ETOILES", UIScript.instance.starsSprite);
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) + 200);
        }
        if (_index == 2)
        {
            NotificationScript.instance.CallNotif("VOUS RECEVEZ 200 ETOILES", UIScript.instance.starsSprite);
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) + 200);
        }
        if (_index == 3)
        {
            UIScript.instance.ClaimRewardOnPack("blue");
        }
        if (_index == 4 || _index == 5 || _index == 6)
        {
            UIScript.instance.ClaimRewardOnPack("bluePurple");
        }

        /*if (_index == 7)
        {
            //ChoosingCarScript.instance.SPera(0);
            ChoosingCarScript.instance.carsOwned += 1;
            PlayerPrefs.SetString("s-PeraPaid", "yes");
            PlayerPrefs.SetString("ownedCars", PlayerPrefs.GetString("ownedCars", "sedan") + " " + "s-Pera");
            ChoosingCarScript.instance.RefreshCarsOwnedNumber();
            NotificationScript.instance.CallNotif("VOUS RECEVEZ S-PERA", UIScript.instance.sPera);
        }
        if (_index == 8)
        {
            //ChoosingCarScript.instance.Ghost(0);
            ChoosingCarScript.instance.carsOwned += 1;
            PlayerPrefs.SetString("ghostPaid", "yes");
            PlayerPrefs.SetString("ownedCars", PlayerPrefs.GetString("ownedCars", "sedan") + " " + "ghost");
            ChoosingCarScript.instance.RefreshCarsOwnedNumber();
            NotificationScript.instance.CallNotif("VOUS RECEVEZ GHOST", UIScript.instance.ghost);
        }*/
    }
}
