using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingCarWithArrows : MonoBehaviour
{
    public int actualCar;
    public Button playButton, buyButton, nextButton, previousButton;

    public static ChoosingCarWithArrows instance;

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
        actualCar = PlayerPrefs.GetInt("ActualCarInt", 1);
        RefreshCar();
    }

    public void NextCar()
    {
        if (actualCar < 5)
            actualCar++;
        PlayerPrefs.SetInt("ActualCarInt", actualCar);
        RefreshCar();
    }

    public void PreviousCar()
    {
        if (actualCar > 1)
            actualCar--;
        PlayerPrefs.SetInt("ActualCarInt", actualCar);
        RefreshCar();
    }

    public void RefreshCar()
    {
        int car;
        string carName;
        if (actualCar == 5)
            nextButton.interactable = false;
        else
            nextButton.interactable = true;


        if (actualCar == 1)
            previousButton.interactable = false;
        else
            previousButton.interactable = true;

        switch (actualCar)
        {
            case 1:
                car = ChoosingCarScript.instance.CarRapide();
                ProceedChoosing(car, "carRapide", 0);
                break;
            case 2:
                car = ChoosingCarScript.instance.Tata(500, true);
                carName = "tata";
                ProceedChoosing(car, carName, 500);
                Debug.Log("CAR"+car);
                break;
            case 3:
                car = ChoosingCarScript.instance.Taxi(750, true);
                carName = "taxi";
                ProceedChoosing(car, carName, 750);
                Debug.Log("CAR" + car);
                break;
            case 4:
                car =ChoosingCarScript.instance.DiagaNdiaye(1000, true);
                carName = "diagaNdiaye";
                ProceedChoosing(car, carName, 1000);
                break;
            case 5:
                car = ChoosingCarScript.instance.DakarDemDikk(1500, true);
                carName = "dakarDemDikk";
                ProceedChoosing(car, carName, 1500);
                break;
        }
    }

    void ProceedChoosing(int _car, string _carName, int _price)
    {
        ChoosingCarScript.instance.buyButton.onClick.RemoveAllListeners();
        Sprite actualSprite = null;
        switch(_carName)
        {
            case "tata":
                actualSprite = ChoosingCarScript.instance.tataSprite;
                break;
            case "taxi":
                actualSprite = ChoosingCarScript.instance.taxiSprite;
                break;
            case "diagaNdiaye":
                actualSprite = ChoosingCarScript.instance.diagaNdiayeSprite;
                break;
            case "dakarDemDikk":
                actualSprite = ChoosingCarScript.instance.dakarDemDikkSprite;
                break;
        }
        if (_car == 0)
        {
            buyButton.gameObject.SetActive(false);
            playButton.interactable = true;
        }
        else if (_car == 1)
        {
            buyButton.gameObject.SetActive(true);
            playButton.interactable = false;
            ChoosingCarScript.instance.BuyingPanel(_price, actualSprite);
            ChoosingCarScript.instance.buyPanel.SetActive(false);
            ChoosingCarScript.instance.buyButton.onClick.AddListener(delegate { UIScript.instance.OnClickInventory(); ChoosingCarScript.instance.BuyingOnClick(_price, _carName); });
        }
        else
        {
            return;
        }
    }

    public void ActivateBuyPanel()
    {
        ChoosingCarScript.instance.buyPanel.SetActive(true);
    }
}
