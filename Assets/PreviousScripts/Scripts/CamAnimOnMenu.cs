using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimOnMenu : MonoBehaviour
{
	public GameObject playButton;
	public GameObject shopButton;
	public GameObject settingsButton;
	public GameObject trophiesButton;
	public AudioSource spawnButtonAudio;


	public static CamAnimOnMenu instance;

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

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator DisableCamAnim()
    {
    	StartCoroutine(Trophies());
    	yield return new WaitForSeconds(.5f);
    	StartCoroutine(Garage());
    	yield return new WaitForSeconds(.5f);
    	StartCoroutine(Play());
    	yield return new WaitForSeconds(.5f);
    	StartCoroutine(Settings());  
    }

    IEnumerator Trophies()
    {
    	trophiesButton.SetActive(true);
    	spawnButtonAudio.Play(0);
    	trophiesButton.transform.localScale= new Vector3(1.3f,1.3f,1.3f);
    	yield return new WaitForSeconds(.1f);
    	trophiesButton.transform.localScale= new Vector3(1.2f,1.2f,1.2f);
    	yield return new WaitForSeconds(.1f);
    	trophiesButton.transform.localScale= new Vector3(1.1f,1.1f,1.1f);
    	yield return new WaitForSeconds(.1f);
    	trophiesButton.transform.localScale = new Vector3(1,1,1);
    }

    IEnumerator Play()
    {
    	playButton.SetActive(true);
    	spawnButtonAudio.Play(0);
    	playButton.transform.localScale= new Vector3(1.3f,1.3f,1.3f);
    	yield return new WaitForSeconds(.1f);
    	playButton.transform.localScale= new Vector3(1.2f,1.2f,1.2f);
    	yield return new WaitForSeconds(.1f);
    	playButton.transform.localScale= new Vector3(1.1f,1.1f,1.1f);
    	yield return new WaitForSeconds(.1f);
    	playButton.transform.localScale = new Vector3(1,1,1);
    }

    IEnumerator Garage()
    {
    	shopButton.SetActive(true);
    	spawnButtonAudio.Play(0);
    	shopButton.transform.localScale= new Vector3(1.3f,1.3f,1.3f);
    	yield return new WaitForSeconds(.1f);
    	shopButton.transform.localScale= new Vector3(1.2f,1.2f,1.2f);
    	yield return new WaitForSeconds(.1f);
    	shopButton.transform.localScale= new Vector3(1.1f,1.1f,1.1f);
    	yield return new WaitForSeconds(.1f);
    	shopButton.transform.localScale = new Vector3(1,1,1);
    }

    IEnumerator Settings()
    {
    	settingsButton.SetActive(true);
    	spawnButtonAudio.Play(0);
    	settingsButton.transform.localScale= new Vector3(1.3f,1.3f,1.3f);
    	yield return new WaitForSeconds(.1f);
    	settingsButton.transform.localScale= new Vector3(1.2f,1.2f,1.2f);
    	yield return new WaitForSeconds(.1f);
    	settingsButton.transform.localScale= new Vector3(1.1f,1.1f,1.1f);
    	yield return new WaitForSeconds(.1f);
    	settingsButton.transform.localScale = new Vector3(1,1,1);
    }
}
