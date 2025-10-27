using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.ConstrainedExecution;


public class StoreIAPManager : MonoBehaviour
{
    public Button button4, button5, button6, button7;

    void Awake()
    {
        SetupBuilder();
    }

    void SetupBuilder()
    {

        if (PlayerPrefs.GetString("allCarsUnlocked", "no") == "no")
        {
        }
        else
        {
            button4.interactable = false;
            PlayerPrefs.SetInt("carsOwned", 5);
        }

        if (PlayerPrefs.GetString("allMapsUnlocked", "no") == "no")
        {
        }
        else
        {
            button5.interactable = false;
        }

        if (PlayerPrefs.GetString("allCarsMapsUnlocked", "no") == "no")
        {
        }
        else
        {
            button6.interactable = false;
            PlayerPrefs.SetInt("carsOwned", 5);
        }

    }

    public void Update()
    {
        if (PlayerPrefs.GetInt("allCarsUnlockedInt", 0) == 1)
        {
            button4.interactable = false;
            PlayerPrefs.SetString("allCarsUnlocked", "yes");
            PlayerPrefs.SetInt("carsOwned", 5);
            string[] cars = new string[] { "carRapide", "tata", "taxi", "diagaNdiaye", "dakarDemDikk" };
            foreach (string carItem in cars)
            {
                PlayerPrefs.SetString(carItem + "Paid", "yes");
                PlayerPrefs.SetString("ownedCars", PlayerPrefs.GetString("ownedCars", "carRapide") + " " + carItem);
            }
        }
        else
        {
            
        }

        if (PlayerPrefs.GetInt("allMapsUnlockedInt", 0) == 1)
        {
            button5.interactable = false;

            PlayerPrefs.SetString("allMapsUnlocked", "yes");
            UIScript.instance.UnlockMap("lagos");
        }
        else
        {
            
        }

        if (PlayerPrefs.GetInt("allCarsMapsUnlockedInt", 0) == 1)
        {
            button6.interactable = false;

            PlayerPrefs.SetString("allMapsUnlockedInt", "yes");
            PlayerPrefs.SetString("allCarsUnlockedInt", "yes");
            PlayerPrefs.SetInt("carsOwned", 5);
            string[] cars = new string[] { "carRapide", "tata", "taxi", "diagaNdiaye", "dakarDemDikk"};
            foreach (string carItem in cars)
            {
                PlayerPrefs.SetString(carItem + "Paid", "yes");
                PlayerPrefs.SetString("ownedCars", PlayerPrefs.GetString("ownedCars", "carRapide") + " " + carItem);
            }
            UIScript.instance.UnlockMap("lagos");
        }
        
    }

}
