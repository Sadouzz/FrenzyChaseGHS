using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedCarScript : MonoBehaviour
{
    //public GameObject hatroPanel, taxiPanel, terzaPanel, macTPanel, tRashPanel, vanPanel, fireTPanel, hatchPanel, flatoPanel, sPeraPanel, ghostPanel;
    // Start is called before the first frame update
    public GameObject tataPanel, taxiPanel, diagaNdiayePanel, dakarDemDikkPanel;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("tataPaid", "no") == "yes")
        {
            tataPanel.SetActive(false);
            tataPanel.transform.parent.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            tataPanel.transform.parent.GetChild(6).gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetString("taxiPaid", "no") == "yes")
        {
            taxiPanel.SetActive(false);
            taxiPanel.transform.parent.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            taxiPanel.transform.parent.GetChild(6).gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetString("diagaNdiayePaid", "no") == "yes")
        {
            diagaNdiayePanel.SetActive(false);
            diagaNdiayePanel.transform.parent.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            diagaNdiayePanel.transform.parent.GetChild(6).gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetString("dakarDemDikkPaid", "no") == "yes")
        {
            dakarDemDikkPanel.SetActive(false);
            dakarDemDikkPanel.transform.parent.GetChild(6).gameObject.SetActive(true);
        }
        else
        {
            dakarDemDikkPanel.transform.parent.GetChild(6).gameObject.SetActive(false);
        }
    }
}
