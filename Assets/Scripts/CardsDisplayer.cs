using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardsDisplayer : MonoBehaviour
{
    public TextMeshProUGUI carRapideCardsText, tataCardsText, taxiCardsText, diagaNdiayeCardsText, dakarDemDikkCardsText;
    public Slider carRapideSlider, tataSlider, taxiSlider, diagaNdiayeSlider, dakarDemDikkSlider;
    
    //public TextMeshProUGUI sedanCardsText, hatroCardsText, taxiCardsText, terzaCardsText, macTCardsText, tRashCardsText, vanCardsText, fireTCardsText, hatchCardsText, flatoCardsText, sPeraCardsText, ghostCardsText;
    public TextMeshProUGUI turrelCardsText, fireCircleCardsText, destabilizatorCardsText, sawCardsText, minesCardsText;
    //public Slider sedanSlider, hatroSlider, taxiSlider, terzaSlider, macTSlider, tRashSlider, vanSlider, fireTSlider, hatchSlider, flatoSlider, sPeraSlider, ghostSlider;
    public Slider turrelSlider, fireCircleSlider, destabilizatorSlider, sawSlider, minesSlider;
    public static CardsDisplayer instance;

    Slider[] sliders;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        RefreshCardsOnDisplay();
        sliders = new Slider[] { carRapideSlider, tataSlider, taxiSlider, diagaNdiayeSlider, dakarDemDikkSlider, turrelSlider, fireCircleSlider, destabilizatorSlider, sawSlider, minesSlider};
    }
    private void Update()
    {
        UpdateArrow();
        RefreshCardsOnDisplay();
    }

    public void UpdateArrow()
    {
        foreach (var slider in sliders)
        {
            if(slider.value >= slider.maxValue)
            {
                slider.transform.parent.GetChild(1).GetComponent<Animator>().enabled = true;
            }
            else
            {
                slider.transform.parent.GetChild(1).GetComponent<Animator>().enabled = false;
            }
        }
    }
    public void RefreshCardsOnDisplay()
    {
        carRapideCardsText.text = PlayerPrefs.GetInt("carRapideCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("carRapideLevel", 1) * 10).ToString();
        carRapideSlider.maxValue = (PlayerPrefs.GetInt("carRapideLevel", 1) * 10);
        carRapideSlider.value = (PlayerPrefs.GetInt("carRapideCards", 0));

        tataCardsText.text = PlayerPrefs.GetInt("tataCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("tataLevel", 1) * 10).ToString();
        tataSlider.maxValue = (PlayerPrefs.GetInt("tataLevel", 1) * 10);
        tataSlider.value = PlayerPrefs.GetInt("tataCards", 0);

        taxiCardsText.text = PlayerPrefs.GetInt("taxiCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("taxiLevel", 1) * 10).ToString();
        taxiSlider.maxValue = (PlayerPrefs.GetInt("taxiLevel", 1) * 10);
        taxiSlider.value = PlayerPrefs.GetInt("taxiCards", 0);

        diagaNdiayeCardsText.text = PlayerPrefs.GetInt("diagaNdiayeCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("diagaNdiayeLevel", 1) * 10).ToString();
        diagaNdiayeSlider.maxValue = (PlayerPrefs.GetInt("diagaNdiayeLevel", 1) * 10);
        diagaNdiayeSlider.value = PlayerPrefs.GetInt("diagaNdiayeCards", 0);

        dakarDemDikkCardsText.text = PlayerPrefs.GetInt("dakarDemDikkCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("dakarDemDikkLevel", 1) * 10).ToString();
        dakarDemDikkSlider.maxValue = (PlayerPrefs.GetInt("dakarDemDikkLevel", 1) * 10);
        dakarDemDikkSlider.value = PlayerPrefs.GetInt("dakarDemDikkCards", 0);

        //turrelCardsText.text = PlayerPrefs.GetInt("TourelleCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("TourelleLevel", 1) * 10).ToString();
        turrelCardsText.text = PlayerPrefs.GetInt("TourelleCards", 0).ToString();
        turrelSlider.maxValue = (PlayerPrefs.GetInt("TourelleLevel", 1) * 10);
        turrelSlider.value = (PlayerPrefs.GetInt("TourelleCards", 0));

        //fireCircleCardsText.text = PlayerPrefs.GetInt("Cercle de feuCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("Cercle de feuLevel", 1) * 10).ToString();
        fireCircleCardsText.text = PlayerPrefs.GetInt("Cercle de feuCards", 0).ToString();
        fireCircleSlider.maxValue = (PlayerPrefs.GetInt("Cercle de feuLevel", 1) * 10);
        fireCircleSlider.value = (PlayerPrefs.GetInt("Cercle de feuCards", 0));

        //destabilizatorCardsText.text = PlayerPrefs.GetInt("DéstabilisateurCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("D�stabilisateurLevel", 1) * 10).ToString();
        destabilizatorCardsText.text = PlayerPrefs.GetInt("DéstabilisateurCards", 0).ToString();
        destabilizatorSlider.maxValue = (PlayerPrefs.GetInt("DéstabilisateurLevel", 1) * 10);
        destabilizatorSlider.value = (PlayerPrefs.GetInt("DéstabilisateurCards", 0));

        //sawCardsText.text = PlayerPrefs.GetInt("SciesCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("SciesLevel", 1) * 10).ToString();
        sawCardsText.text = PlayerPrefs.GetInt("SciesCards", 0).ToString();
        sawSlider.maxValue = (PlayerPrefs.GetInt("SciesLevel", 1) * 10);
        sawSlider.value = (PlayerPrefs.GetInt("SciesCards", 0));

        //minesCardsText.text = PlayerPrefs.GetInt("MinesCards", 0).ToString() + "/" + (PlayerPrefs.GetInt("MinesLevel", 1) * 10).ToString();
        minesCardsText.text = PlayerPrefs.GetInt("MinesCards", 0).ToString();
        minesSlider.maxValue = (PlayerPrefs.GetInt("MinesLevel", 1) * 10);
        minesSlider.value = (PlayerPrefs.GetInt("MinesCards", 0));
    }
}
