using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	public GameObject crashPanel;

	public string car;

	public GameObject Sedan, Upflat, Botfer, Hatch, SedanMax, Ghost, Inferno;

	public static Manager instance;

    private void Awake()
    {
    	if(instance != null)
    	{
    		Debug.LogWarning("Il y a plus d'un inventaire");
    		return;
    	}
    	instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        car = PlayerPrefs.GetString("CarChoosed", "Sedan");

        if(car == "Sedan")
        {
        	Instantiate(Sedan, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if(car == "UpFlat")
        {
        	Instantiate(Upflat, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if(car == "Botfer")
        {
        	Instantiate(Botfer, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if(car == "Hatch")
        {
        	Instantiate(Hatch, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if(car == "SedanMax")
        {
            Instantiate(SedanMax, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if(car == "Ghost")
        {
            Instantiate(Ghost, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if(car == "Inferno")
        {
            Instantiate(Inferno, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void Scene(int scene)
    {
    	SceneManager.LoadScene(scene);
    }
}
