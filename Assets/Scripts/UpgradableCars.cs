using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class UpgradableCars : MonoBehaviour
{
    public string ownedCars;
    public string[] carsList;

    public TextMeshProUGUI carRapideLevel, tataLevel, taxiLevel, diagaNdiayeLevel, dakarDemDikkLevel;

    //public TextMeshProUGUI sedanLevel, hatroLevel, taxiLevel, terzaLevel, macTLevel, tRashLevel, vanLevel, fireTLevel, hatchLevel, flatoLevel, sPeraLevel, ghostLevel;
    public TextMeshProUGUI turrelLevel, fireCircleLevel, destabilizatorLevel, sawLevel;

    public static UpgradableCars instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(PlayerPrefs.GetInt("carsOwned", 1) == 5)
        {
            string carsList_ =  "carRapide tata taxi diagaNdiaye dakarDemDikk";
            char[] delimiters = new char[] { ' ', ',', '.', ';', ':', '!', '?', '\n', '\r', '\t' };
            carsList = carsList_.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
        }
        else
        {
            ownedCars = PlayerPrefs.GetString("ownedCars", "carRapide");
            char[] delimiters = new char[] { ' ', ',', '.', ';', ':', '!', '?', '\n', '\r', '\t' };
            carsList = ownedCars.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
        }

        carRapideLevel.text = "Niveau " + PlayerPrefs.GetInt("carRapideLevel", 1).ToString();
        tataLevel.text = "Niveau " + PlayerPrefs.GetInt("tataLevel", 1).ToString();
        taxiLevel.text = "Niveau " + PlayerPrefs.GetInt("taxiLevel", 1).ToString();
        diagaNdiayeLevel.text = "Niveau " + PlayerPrefs.GetInt("diagaNdiayeLevel", 1).ToString();
        dakarDemDikkLevel.text = "Niveau " + PlayerPrefs.GetInt("dakarDemDikkLevel", 1).ToString();

        turrelLevel.text = "Niveau " + PlayerPrefs.GetInt("TourelleLevel", 1).ToString();
        fireCircleLevel.text = "Niveau " + PlayerPrefs.GetInt("Cercle de feuLevel", 1).ToString();
        destabilizatorLevel.text = "Niveau " + PlayerPrefs.GetInt("D�stabilisateurLevel", 1).ToString();
        sawLevel.text = "Niveau " + PlayerPrefs.GetInt("SciesLevel", 1).ToString();
    }


}
