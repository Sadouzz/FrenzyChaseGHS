using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ChoosingCarScript : MonoBehaviour
{
    public int carsOwned;
    bool carRapide, tata, taxi, diagaNdiaye, dakarDemDikk;
    //bool sedan, hatro, taxi, terza, macT, tRash, van, fireT, hatch, flato, sPera, ghost;
    public Image panelCarSpriteImage;
    public Sprite tataSprite, taxiSprite, diagaNdiayeSprite, dakarDemDikkSprite;
    //public Sprite hatroSprite, taxiSprite, terzaSprite, macTSprite, tRashSprite, vanSprite, fireTSprite, hatchSprite, flatoSprite, sPeraSprite, ghostSprite;
    public TextMeshProUGUI priceTextBuyingPanel, carsOwnedText, chosenCarText;
    public Button buyButton;
    public GameObject noMoneyPanel, buyPanel, carRapideNamePanel, tataNamePanel, taxiNamePanel, diagaNdiayeNamePanel, dakarDemDikkNamePanel;
    public GameObject carRapideCar, tataCar, taxiCar, diagaNdiayeCar, dakarDemDikkCar;
    //public GameObject sedanNamePanel, hatroNamePanel, taxiNamePanel, terzaNamePanel, macTNamePanel, tRashNamePanel, vanNamePanel, fireTNamePanel, hatchNamePanel, flatoNamePanel, sPeraNamePanel, ghostNamePanel, sedanCar, hatroCar, taxiCar, terzaCar, macTCar, tRashCar, vanCar, fireTCar, hatchCar, flatoCar, sPeraCar, ghostCar;
    public string chosenCar;

    public static ChoosingCarScript instance;

    private void Awake()
    {
        carsOwned = PlayerPrefs.GetInt("carsOwned", 1);
        RefreshCarsOwnedNumber();

        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void RefreshCarsOwnedNumber()
    {
        carsOwnedText.text = carsOwned.ToString() + "/5";
        PlayerPrefs.SetInt("carsOwned", carsOwned);
        if(PlayerPrefs.GetInt("carsOwned", carsOwned) == 5)
        {
            PlayerPrefs.SetString("allCarsUnlocked", "yes");
        }
    }

    public void CarRapideCall()
    {
        CarRapide();
    }

    public void TataCall()
    {
        Tata(500);
        Debug.Log("1");
    }

    public void TaxiCall()
    {
        Taxi(750);
    }

    public void DiagaNdiayeCall()
    {
        DiagaNdiaye(1000);
    }

    public void DakarDemDikkCall()
    {
        DakarDemDikk(1500);
    }

    public int CarRapide()
    {
        if (carRapide)
        {
            UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.carRapideSlider, PlayerPrefs.GetInt("carRapideLevel", 1) * 75, 0);
        }
        carRapide = true;
        tata = false;
        taxi = false;
        diagaNdiaye = false;
        dakarDemDikk = false;
        return 0;
    }

    public int Tata(int _price, bool fromChoosingArrows = false)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("tataPaid", "no");
        Debug.Log("2");
        if (isPaid == "yes" && fromChoosingArrows)
        {
            if (tata)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.tataSlider, PlayerPrefs.GetInt("tataLevel", 1) * 75, 1);
            }
            carRapide = false;
            tata = true;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = false;
            return 0;
        }
        else if(isPaid == "no" && fromChoosingArrows) 
        {
            carRapide = false;
            tata = true;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = false;
            /*BuyingPanel(_price, tataSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "tata"); });*/
            return 1;
        }
        else if(isPaid == "no" && !fromChoosingArrows)
        {
            BuyingPanel(_price, tataSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "tata"); });
            return 2;
        }
        else
        {
            if (tata)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.tataSlider, PlayerPrefs.GetInt("tataLevel", 1) * 75, 1);
            }
            carRapide = false;
            tata = true;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = false;
            return 0;
        }
        /*if (isPaid == "yes")
        {
            if (tata)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.tataSlider, PlayerPrefs.GetInt("tataLevel", 1) * 75, 1);
            }
            carRapide = false;
            tata = true;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = false;
        }
        else
        {
            BuyingPanel(_price, tataSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "tata"); });
        }*/
    }

    public int Taxi(int _price, bool fromChoosingArrows=false)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("taxiPaid", "no");
        if (isPaid == "yes" && fromChoosingArrows)
        {
            if (taxi)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.taxiSlider, PlayerPrefs.GetInt("taxiLevel", 1) * 75, 2);
            }
            carRapide = false;
            tata = false;
            taxi = true;
            diagaNdiaye = false;
            dakarDemDikk = false;
            return 0;
        }
        else if (isPaid == "no" && fromChoosingArrows)
        {
            carRapide = false;
            tata = false;
            taxi = true;
            diagaNdiaye = false;
            dakarDemDikk = false;
            /*BuyingPanel(_price, tataSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "tata"); });*/
            return 1;
        }
        else if (isPaid == "no" && !fromChoosingArrows)
        {
            BuyingPanel(_price, taxiSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "taxi"); });
            return 2;
        }
        else
        {
            if (taxi)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.taxiSlider, PlayerPrefs.GetInt("taxiLevel", 1) * 75, 2);
            }
            carRapide = false;
            tata = false;
            taxi = true;
            diagaNdiaye = false;
            dakarDemDikk = false;
            return 0;
        }
        /*if (isPaid == "yes")
        {
            if (taxi)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.taxiSlider, PlayerPrefs.GetInt("taxiLevel", 1) * 75, 2);
            }
            carRapide = false;
            tata = false;
            taxi = true;
            diagaNdiaye = false;
            dakarDemDikk = false;
        }
        else
        {
            BuyingPanel(_price, taxiSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "taxi"); });
        }*/
    }
    
    public int DiagaNdiaye(int _price, bool fromChoosingArrows=false)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("diagaNdiayePaid", "no");
        if (isPaid == "yes" && fromChoosingArrows)
        {
            if (diagaNdiaye)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.diagaNdiayeSlider, PlayerPrefs.GetInt("diagaNdiayeLevel", 1) * 75, 3);
            }
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = true;
            dakarDemDikk = false;
            return 0;
        }
        else if (isPaid == "no" && fromChoosingArrows)
        {
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = true;
            dakarDemDikk = false;
            /*BuyingPanel(_price, tataSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "tata"); });*/
            return 1;
        }
        else if (isPaid == "no" && !fromChoosingArrows)
        {
            BuyingPanel(_price, diagaNdiayeSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "diagaNdiaye"); });
            return 2;
        }
        else
        {
            if (diagaNdiaye)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.diagaNdiayeSlider, PlayerPrefs.GetInt("diagaNdiayeLevel", 1) * 75, 3);
            }
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = true;
            dakarDemDikk = false;
            return 0;
        }
        /*if (isPaid == "yes")
        {
            if (diagaNdiaye)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.diagaNdiayeSlider, PlayerPrefs.GetInt("diagaNdiayeLevel", 1) * 75, 3);
            }
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = true;
            dakarDemDikk = false;
        }
        else
        {
            BuyingPanel(_price, diagaNdiayeSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "diagaNdiaye"); });
        }*/
    }
    
    public int DakarDemDikk(int _price, bool fromChoosingArrows = false)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("dakarDemDikkPaid", "no");
        if (isPaid == "yes" && fromChoosingArrows)
        {
            if (dakarDemDikk)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.dakarDemDikkSlider, PlayerPrefs.GetInt("dakarDemDikkLevel", 1) * 75, 4);
            }
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = true;
            return 0;
        }
        else if (isPaid == "no" && fromChoosingArrows)
        {
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = true;
            /*BuyingPanel(_price, tataSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "tata"); });*/
            return 1;
        }
        else if (isPaid == "no" && !fromChoosingArrows)
        {
            BuyingPanel(_price, dakarDemDikkSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "dakarDemDikk"); });
            return 2;
        }
        else
        {
            if (dakarDemDikk)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.dakarDemDikkSlider, PlayerPrefs.GetInt("dakarDemDikkLevel", 1) * 75, 4);
            }
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = true;
            return 0;
        }
        /*if (isPaid == "yes")
        {
            if (dakarDemDikk)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.dakarDemDikkSlider, PlayerPrefs.GetInt("dakarDemDikkLevel", 1) * 75, 4);
            }
            carRapide = false;
            tata = false;
            taxi = false;
            diagaNdiaye = false;
            dakarDemDikk = true;
        }
        else
        {
            BuyingPanel(_price, dakarDemDikkSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "dakarDemDikk"); });
        }*/
    }

    /*public void Sedan()
    {
        if(sedan)
        {
            UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.sedanSlider, PlayerPrefs.GetInt("sedanLevel", 1) * 75, 0);
        }
        sedan = true;
        hatro = false;
        taxi = false;
        terza = false;
        macT = false;
        tRash = false;
        van = false;
        fireT = false;
        hatch = false;
        flato = false;
        sPera = false;
        ghost = false;
    }

    public void Hatro(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("hatroPaid", "no");
        if (isPaid == "yes")
        {
            if (hatro)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.hatroSlider, PlayerPrefs.GetInt("hatroLevel", 1) * 75, 0);
            }
            sedan = false;
            hatro = true;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, hatroSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "hatro"); });
        }
    }

    public void Taxi(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("taxiPaid", "no");
        if (isPaid == "yes")
        {
            if (taxi)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.taxiSlider, PlayerPrefs.GetInt("taxiLevel", 1) * 75, 2);
            }
            sedan = false;
            hatro = false;
            taxi = true;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, taxiSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "taxi"); });
        }
    }

    public void Terza(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("terzaPaid", "no");
        if (isPaid == "yes")
        {
            if (terza)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.terzaSlider, PlayerPrefs.GetInt("terzaLevel", 1) * 75, 3);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = true;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, terzaSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "terza"); });
        }
    }

    public void MacT(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("mac-TPaid", "no");
        if (isPaid == "yes")
        {
            if (macT)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.macTSlider, PlayerPrefs.GetInt("mac-TLevel", 1) * 75, 4);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = true;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, macTSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "mac-T"); });
        }
    }

    public void TRash(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("t-RashPaid", "no");
        if (isPaid == "yes")
        {
            if (tRash)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.tRashSlider, PlayerPrefs.GetInt("t-RashLevel", 1) * 75, 5);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = true;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, tRashSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "t-Rash"); });
        }
    }

    public void Van(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("vanPaid", "no");
        if (isPaid == "yes")
        {
            if (van)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.vanSlider, PlayerPrefs.GetInt("vanLevel", 1) * 75, 6);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = true;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, vanSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "van"); });
        }
    }

    public void FireT(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("fire-TPaid", "no");
        if (isPaid == "yes")
        {
            if (fireT)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.fireTSlider, PlayerPrefs.GetInt("fire-TLevel", 1) * 75, 7);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = true;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, fireTSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "fire-T"); });
        }
    }

    public void Hatch(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("hatchPaid", "no");
        if (isPaid == "yes")
        {
            if (hatch)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.hatchSlider, PlayerPrefs.GetInt("hatchLevel", 1) * 75, 8);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = true;
            flato = false;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, hatchSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "hatch"); });
        }
    }

    public void Flato(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("flatoPaid", "no");
        if (isPaid == "yes")
        {
            if (flato)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.flatoSlider, PlayerPrefs.GetInt("flatoLevel", 1) * 75, 9);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = true;
            sPera = false;
            ghost = false;
        }
        else
        {
            BuyingPanel(_price, flatoSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "flato"); });
        }
    }

    public void SPera(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("s-PeraPaid", "no");
        if (isPaid == "yes")
        {
            if (sPera)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.sPeraSlider, PlayerPrefs.GetInt("s-PeraLevel", 1) * 75, 10);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = true;
            ghost = false;
        }
        else
        {
            NotificationScript.instance.CallNotif("TERMINEZ LA MISSION 7", UIScript.instance.sPera);
            NotificationScript.instance.ChangeTitle("VEHICULE VEROUILLE");
            //BuyingPanel(_price, sPeraSprite);
            //buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "s-Pera"); });
        }
    }

    public void Ghost(int _price)
    {
        string isPaid;
        isPaid = PlayerPrefs.GetString("ghostPaid", "no");
        if (isPaid == "yes")
        {
            if (ghost)
            {
                UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.ghostSlider, PlayerPrefs.GetInt("ghostLevel", 1) * 75, 11);
            }
            sedan = false;
            hatro = false;
            taxi = false;
            terza = false;
            macT = false;
            tRash = false;
            van = false;
            fireT = false;
            hatch = false;
            flato = false;
            sPera = false;
            ghost = true;
        }
        else
        {
            NotificationScript.instance.CallNotif("TERMINEZ LA MISSION 8", UIScript.instance.ghost);
            NotificationScript.instance.ChangeTitle("VEHICULE VEROUILLE");
            //BuyingPanel(_price, ghostSprite);
            //buyButton.onClick.AddListener(delegate { BuyingOnClick(_price, "ghost"); });
        }
    }*/

    public void Turret()
    {
        UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.turrelSlider, PlayerPrefs.GetInt("TourelleLevel", 1) * 75, 12);
    }

    public void FireCircle()
    {
        UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.fireCircleSlider, PlayerPrefs.GetInt("Cercle de feuLevel", 1) * 75, 13);
    }

    public void Destabilizer()
    {
        UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.destabilizatorSlider, PlayerPrefs.GetInt("D�stabilisateurLevel", 1) * 75, 14);
    }

    public void Saw()
    {
        UpdateCarOrPower.instance.OpeningUpdatePanel(CardsDisplayer.instance.sawSlider, PlayerPrefs.GetInt("SciesLevel", 1) * 75, 15);
    }

    void Start()
    {
        chosenCar = PlayerPrefs.GetString("ChosenCar", "carRapide");
        switch (chosenCar)
        {
            case "carRapide":
                CarRapide();
                break;

            case "tata":
                Tata(0);
                break;
            case "taxi":
                Taxi(0);
                break;
            case "diagaNdiaye":
                DiagaNdiaye(0);
                break;
            case "dakarDemDikk":
                DakarDemDikk(0);
                break;

            // Tu peux ajouter d'autres cas ici
            default:
                Debug.Log("Véhicule inconnu : " + chosenCar);
                break;
        }

        /*if(chosenCar == "sedan")
        {
            Sedan();
        }
        if(chosenCar == "hatro")
        {
            Hatro(0);
        }
        if(chosenCar == "taxi")
        {
            Taxi(0);
        }
        if (chosenCar == "terza")
        {
            Terza(0);
        }
        if (chosenCar == "mac-T")
        {
            MacT(0);
        }
        if (chosenCar == "t-Rash")
        {
            TRash(0);
        }
        if (chosenCar == "van")
        {
            Van(0);
        }
        if (chosenCar == "fire-T")
        {
            FireT(0);
        }
        if (chosenCar == "hatch")
        {
            Hatch(0);
        }
        if (chosenCar == "flato")
        {
            Flato(0);
        }
        if (chosenCar == "s-Pera")
        {
            SPera(0);
        }
        if (chosenCar == "ghost")
        {
            Ghost(0);
        }*/
    }

    void Update()
    {
        if (carRapide)
        {
            SelectCar("carRapide");
            SetActualCarInt(1);
            SetChosenCarText("Car Rapide");
        }
        else if (tata)
        {
            SelectCar("tata");
            SetActualCarInt(2);
            SetChosenCarText("Tata");
        }
        else if (taxi)
        {
            SelectCar("taxi");
            SetActualCarInt(3);
            SetChosenCarText("Taxi");
        }
        else if (diagaNdiaye)
        {
            SelectCar("diagaNdiaye");
            SetActualCarInt(4);
            SetChosenCarText("Diaga Ndiaye");
        }
        else if (dakarDemDikk)
        {
            SelectCar("dakarDemDikk");
            SetActualCarInt(5);
            SetChosenCarText("Dakar Dem Dikk");
        }


        /*if(sedan)
        {
            PlayerPrefs.SetString("ChosenCar", "sedan");
            sedanCar.SetActive(true);
            sedanNamePanel.SetActive(true);
        }
        else{
            sedanCar.SetActive(false);
            sedanNamePanel.SetActive(false);
        }

        if (hatro)
        {
            PlayerPrefs.SetString("ChosenCar", "hatro");
            hatroCar.SetActive(true);
            hatroNamePanel.SetActive(true);
        }
        else{
            hatroCar.SetActive(false);
            hatroNamePanel.SetActive(false);
        }

        if (taxi)
        {
            PlayerPrefs.SetString("ChosenCar", "taxi");
            taxiCar.SetActive(true);
            taxiNamePanel.SetActive(true);
        }
        else{
            taxiCar.SetActive(false);
            taxiNamePanel.SetActive(false);
        }

        if (terza)
        {
            PlayerPrefs.SetString("ChosenCar", "terza");
            terzaCar.SetActive(true);
            terzaNamePanel.SetActive(true);
        }
        else
        {
            terzaCar.SetActive(false);
            terzaNamePanel.SetActive(false);
        }

        if (macT)
        {
            PlayerPrefs.SetString("ChosenCar", "mac-T");
            macTCar.SetActive(true);
            macTNamePanel.SetActive(true);
        }
        else
        {
            macTCar.SetActive(false);
            macTNamePanel.SetActive(false);
        }

        if (tRash)
        {
            PlayerPrefs.SetString("ChosenCar", "t-Rash");
            tRashCar.SetActive(true);
            tRashNamePanel.SetActive(true);
        }
        else
        {
            tRashCar.SetActive(false);
            tRashNamePanel.SetActive(false);
        }

        if (van)
        {
            PlayerPrefs.SetString("ChosenCar", "van");
            vanCar.SetActive(true);
            vanNamePanel.SetActive(true);
        }
        else
        {
            vanCar.SetActive(false);
            vanNamePanel.SetActive(false);
        }

        if (fireT)
        {
            PlayerPrefs.SetString("ChosenCar", "fire-T");
            fireTCar.SetActive(true);
            fireTNamePanel.SetActive(true);
        }
        else
        {
            fireTCar.SetActive(false);
            fireTNamePanel.SetActive(false);
        }

        if (hatch)
        {
            PlayerPrefs.SetString("ChosenCar", "hatch");
            hatchCar.SetActive(true);
            hatchNamePanel.SetActive(true);
        }
        else
        {
            hatchCar.SetActive(false);
            hatchNamePanel.SetActive(false);
        }

        if (flato)
        {
            PlayerPrefs.SetString("ChosenCar", "flato");
            flatoCar.SetActive(true);
            flatoNamePanel.SetActive(true);
        }
        else
        {
            flatoCar.SetActive(false);
            flatoNamePanel.SetActive(false);
        }

        if (sPera)
        {
            PlayerPrefs.SetString("ChosenCar", "s-Pera");
            sPeraCar.SetActive(true);
            sPeraNamePanel.SetActive(true);
        }
        else
        {
            sPeraCar.SetActive(false);
            sPeraNamePanel.SetActive(false);
        }

        if (ghost)
        {
            PlayerPrefs.SetString("ChosenCar", "ghost");
            ghostCar.SetActive(true);
            ghostNamePanel.SetActive(true);
        }
        else
        {
            ghostCar.SetActive(false);
            ghostNamePanel.SetActive(false);
        }*/

        /*if (PlayerPrefs.GetString("allCarsUnlocked", "no") == "yes")
        {
            PlayerPrefs.SetInt("carsOwned", 12);
        }*/
    }

    void SetActualCarInt(int carInt)
    {
        PlayerPrefs.SetInt("ActualCarInt", carInt);
    }

    void SetChosenCarText(string text)
    {
        chosenCarText.text = text;
    }

    void SelectCar(string chosenCar)
    {
        PlayerPrefs.SetString("ChosenCar", chosenCar);

        carRapideCar.SetActive(chosenCar == "carRapide");
        carRapideNamePanel.SetActive(chosenCar == "carRapide");

        tataCar.SetActive(chosenCar == "tata");
        tataNamePanel.SetActive(chosenCar == "tata");
        
        taxiCar.SetActive(chosenCar == "taxi");
        taxiNamePanel.SetActive(chosenCar == "taxi");
        
        diagaNdiayeCar.SetActive(chosenCar == "diagaNdiaye");
        diagaNdiayeNamePanel.SetActive(chosenCar == "diagaNdiaye");
        
        dakarDemDikkCar.SetActive(chosenCar == "dakarDemDikk");
        dakarDemDikkNamePanel.SetActive(chosenCar == "dakarDemDikk");
    }


    public void CloseBuyPanel()
    {
        buyPanel.SetActive(false);
        buyButton.onClick.RemoveAllListeners();
    }

    public void CloseNoMoneyPanel()
    {
        noMoneyPanel.SetActive(false);
    }

    public void BuyingPanel(int money, Sprite carSprite)
    {
        buyPanel.SetActive(true);
        priceTextBuyingPanel.text = money.ToString();
        panelCarSpriteImage.sprite = carSprite;
    }

    public void BuyingOnClick(int _price, string car)
    {
        if(PlayerPrefs.GetInt("stars", 0) >= _price)
        {
            carsOwned += 1;
            PlayerPrefs.SetString(car + "Paid", "yes");
            PlayerPrefs.SetString("ownedCars", PlayerPrefs.GetString("ownedCars", "sedan") + " " + car);
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) - _price);
            UnlockCarAnimation.instance.Anim(car);
            CloseBuyPanel();
            RefreshCarsOwnedNumber();
            ChoosingCarWithArrows.instance.RefreshCar();
            buyButton.onClick.RemoveAllListeners();
        }
        else
        {
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
            noMoneyPanel.SetActive(true);
        }
    }
}
