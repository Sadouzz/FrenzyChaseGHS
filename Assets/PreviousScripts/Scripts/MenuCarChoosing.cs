using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCarChoosing : MonoBehaviour
{
	public GameObject sedan, upflat, botfer, hatch, sedanMax, ghost, inferno;
	public string car;

    // Update is called once per frame
    void Update()
    {
    	car = PlayerPrefs.GetString("CarChoosed", "Sedan");
        if(car == "Sedan")
		{
			sedan.SetActive(true);
			upflat.SetActive(false);
			botfer.SetActive(false);
			hatch.SetActive(false);
			sedanMax.SetActive(false);
			ghost.SetActive(false);
			inferno.SetActive(false);
		}
		else if(car == "UpFlat")
		{
			sedan.SetActive(false);
			upflat.SetActive(true);
			botfer.SetActive(false);
			hatch.SetActive(false);
			sedanMax.SetActive(false);
			ghost.SetActive(false);
			inferno.SetActive(false);
		}
		else if(car == "Botfer")
		{
			sedan.SetActive(false);
			upflat.SetActive(false);
			botfer.SetActive(true);
			hatch.SetActive(false);
			sedanMax.SetActive(false);
			ghost.SetActive(false);
			inferno.SetActive(false);
		}
		else if(car == "Hatch")
		{
			sedan.SetActive(false);
			upflat.SetActive(false);
			botfer.SetActive(false);
			hatch.SetActive(true);
			sedanMax.SetActive(false);
			ghost.SetActive(false);
			inferno.SetActive(false);
		}
		else if(car == "SedanMax")
		{
			sedan.SetActive(false);
			upflat.SetActive(false);
			botfer.SetActive(false);
			hatch.SetActive(false);
			sedanMax.SetActive(true);
			ghost.SetActive(false);
			inferno.SetActive(false);
		}
		else if(car == "Ghost")
		{
			sedan.SetActive(false);
			upflat.SetActive(false);
			botfer.SetActive(false);
			hatch.SetActive(false);
			sedanMax.SetActive(false);
			ghost.SetActive(true);
			inferno.SetActive(false);
		}
		else if(car == "Inferno")
		{
			sedan.SetActive(false);
			upflat.SetActive(false);
			botfer.SetActive(false);
			hatch.SetActive(false);
			sedanMax.SetActive(false);
			ghost.SetActive(false);
			inferno.SetActive(true);
		}
    }
}
