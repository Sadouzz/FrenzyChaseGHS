using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CarSpawnOnGame : MonoBehaviour
{
    public GameObject carRapide, tata, taxi, diagaNdiaye, dakarDemDikk;
    //public GameObject sedan, hatro, taxi, terza, macT, tRash, van, fireT, hatch, flato, sPera, ghost;
    string chosenCar;
    public bool isPoidsLourd, isDrift;

    public static CarSpawnOnGame instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        chosenCar = PlayerPrefs.GetString("ChosenCar", "carRapide");
        SpawnCar();
    }

    void SpawnCar()
    {
        switch (chosenCar)
        {
            case "carRapide":
                isPoidsLourd = true;
                Instantiate(carRapide, new Vector3(0, 0, -10.5f), carRapide.transform.rotation);
                break;
            case "tata":
                isPoidsLourd = true;
                Instantiate(tata, new Vector3(0, 0, -10.5f), tata.transform.rotation);
                break;
            case "taxi":
                Instantiate(taxi, new Vector3(0, 0, -10.5f), taxi.transform.rotation);
                break;
            case "diagaNdiaye":
                isPoidsLourd = true;
                Instantiate(diagaNdiaye, new Vector3(0, 0, -10.5f), diagaNdiaye.transform.rotation);
                break;
            case "dakarDemDikk":
                isPoidsLourd = true;
                Instantiate(dakarDemDikk, new Vector3(0, 0, -10.5f), dakarDemDikk.transform.rotation);
                break;
            default:
                break;
        }
        /*if(chosenCar == "sedan")
        {
            Instantiate(sedan, new Vector3(0, 0, -6.75f), sedan.transform.rotation);
        }
        if(chosenCar == "hatro")
        {
            Instantiate(hatro, new Vector3(0, 0, -6.75f), hatro.transform.rotation);
        }
        if (chosenCar == "taxi")
        {
            Instantiate(taxi, new Vector3(0, 0, -6.75f), taxi.transform.rotation);
        }
        if (chosenCar == "terza")
        {
            Instantiate(terza, new Vector3(0, 0, -6.75f), terza.transform.rotation);
        }
        if (chosenCar == "mac-T")
        {
            Instantiate(macT, new Vector3(0, 0, -6.75f), macT.transform.rotation);
            isPoidsLourd = true;
        }
        if (chosenCar == "t-Rash")
        {
            Instantiate(tRash, new Vector3(0, 0, -6.75f), tRash.transform.rotation);
            isPoidsLourd = true;
        }
        if (chosenCar == "van")
        {
            Instantiate(van, new Vector3(0, 0, -6.75f), tRash.transform.rotation);
            isPoidsLourd = true;
        }
        if (chosenCar == "fire-T")
        {
            Instantiate(fireT, new Vector3(0, 0, -6.75f), tRash.transform.rotation);
            isPoidsLourd = true;
        }
        if (chosenCar == "hatch")
        {
            Instantiate(hatch, new Vector3(0, 0, -6.75f), tRash.transform.rotation);
        }
        if (chosenCar == "tlato")
        {
            Instantiate(flato, new Vector3(0, 0, -6.75f), flato.transform.rotation);
        }
        if (chosenCar == "s-Pera")
        {
            Instantiate(sPera, new Vector3(0, 0, -6.75f), sPera.transform.rotation);
        }
        if (chosenCar == "ghost")
        {
            Instantiate(ghost, new Vector3(0, 0, -6.75f), ghost.transform.rotation);
        }*/
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
