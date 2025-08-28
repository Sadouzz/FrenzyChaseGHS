using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayPanel : MonoBehaviour, IPointerClickHandler
{
    int elapsedTime;
    float lastClick = 0f;
    float interval = 0.25f;
    public GameObject instructions, third, fourth, panelThird;

    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("tutorial", "no") == "third")
        {
            SetThird();
            Time.timeScale = 0;
        }
        else
        {
            panelThird.SetActive(false);
        }
        StartCoroutine(HideInstructions());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            instructions.SetActive(false);
        }
    }

    public void SetThird()
    {
        third.SetActive(true);
    }

    public void FirstOK()
    {
        third.SetActive(false);
        fourth.SetActive(true);
    }

    public void SecondOK()
    {
        fourth.SetActive(false);
        panelThird.SetActive(false);
        PlayerPrefs.SetString("tutorial", "nextThird");
        Time.timeScale = 1;
    }

    IEnumerator HideInstructions()
    {
        yield return new WaitForSeconds(2);
        instructions.SetActive(false);
    }

    

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        
        if ((lastClick + interval) > Time.time)
        {
            //InventoryScript.instance.Saw();
            //InventoryScript.instance.Fire();
            //InventoryScript.instance.Turret();
            //InventoryScript.instance.UsePower();
            //InventoryScript.instance.Mines();
            //InventoryScript.instance.Destabilizer();
        }
        lastClick = Time.time;
    }
}
