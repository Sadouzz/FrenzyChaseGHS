using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophiesManager : MonoBehaviour
{
	public GameObject checkCollectChallenge1, checkCollectChallenge2, checkCollectChallenge3, checkCollectChallenge4, checkCollectChallenge5, checkCollectChallenge6, checkCollectChallenge7, checkCollectChallenge8, checkCollectChallenge9, checkCollectChallenge10, button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, notCollected, infernoObtained;
	public Button collect1, collect2, collect3, collect4, collect5, collect6, collect7, collect8, collect9, collect10;

	public string lang,challenge1, challenge2, challenge3, challenge4, challenge5, challenge6, challenge7, challenge8, challenge9, challenge10;

	int coinsTaker;
	public Text pièceReceiveText;
	public AudioSource coinSound;
    // Start is called before the first frame update
    public static TrophiesManager instance;

    private void Awake()
    {
    	if(instance != null)
    	{
    		Debug.LogWarning("Il y a plus d'un inventaire");
    		return;
    	}
    	instance = this;
    }
    void Start()
    {
        infernoObtained.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    	lang = PlayerPrefs.GetString ("_language", "fr");
    	
    	challenge1 = PlayerPrefs.GetString("Challenge1", "no");
    	challenge2 = PlayerPrefs.GetString("Challenge2", "no");
    	challenge3 = PlayerPrefs.GetString("Challenge3", "no");
    	challenge4 = PlayerPrefs.GetString("Challenge4", "no");
    	challenge5 = PlayerPrefs.GetString("Challenge5", "no");
    	challenge6 = PlayerPrefs.GetString("Challenge6", "no");
    	challenge7 = PlayerPrefs.GetString("Challenge7", "no");
    	challenge8 = PlayerPrefs.GetString("Challenge8", "no");
    	challenge9 = PlayerPrefs.GetString("Challenge9", "no");
    	challenge10 = PlayerPrefs.GetString("Challenge10", "no");
    	coinsTaker = PlayerPrefs.GetInt("Coins", 0);

    	if(challenge1 == "done")
    	{
    		collect1.interactable = true;
    	}
    	if(challenge2 == "done")
    	{
    		collect2.interactable = true;
    	}
    	if(challenge3 == "done")
    	{
    		collect3.interactable = true;
    	}
    	if(challenge4 == "done")
    	{
    		collect4.interactable = true;
    	}
    	if(challenge5 == "done")
    	{
    		collect5.interactable = true;
    	}
    	if(challenge6 == "done")
    	{
    		collect6.interactable = true;
    	}
    	if(challenge7 == "done")
    	{
    		collect7.interactable = true;
    	}
    	if(challenge8 == "done")
    	{
    		collect8.interactable = true;
    	}
    	if(challenge9 == "done")
    	{
    		collect9.interactable = true;
    	}
    	if(challenge10 == "done")
    	{
    		collect10.interactable = true;
    	}
    	if(challenge1 == "collected")
    	{
    		checkCollectChallenge1.SetActive(true);
    		button1.SetActive(false);    	}
    	if(challenge2 == "collected")
    	{
    		checkCollectChallenge2.SetActive(true);
    		button2.SetActive(false);
    	}
    	if(challenge3 == "collected")
    	{
    		checkCollectChallenge3.SetActive(true);
    		button3.SetActive(false);
    	}
    	if(challenge4 == "collected")
    	{
    		checkCollectChallenge4.SetActive(true);
    		button4.SetActive(false);
    	}
    	if(challenge5 == "collected")
    	{
    		checkCollectChallenge5.SetActive(true);
    		button5.SetActive(false);
    	}
    	if(challenge6 == "collected")
    	{
    		checkCollectChallenge6.SetActive(true);
    		button6.SetActive(false);
    	}
    	if(challenge7 == "collected")
    	{
    		checkCollectChallenge7.SetActive(true);
    		button7.SetActive(false);
    	}
    	if(challenge8 == "collected")
    	{
    		checkCollectChallenge8.SetActive(true);
    		button8.SetActive(false);
    	}
    	if(challenge9 == "collected")
    	{
    		checkCollectChallenge9.SetActive(true);
    		button9.SetActive(false);
    	}
    	if(challenge10 == "collected")
    	{
    		checkCollectChallenge10.SetActive(true);
    		button10.SetActive(false);
    	}
    	if(challenge1 == "done" || challenge2 == "done" || challenge3 == "done" || challenge4 == "done" || challenge5 == "done" || challenge6 == "done" || challenge7 == "done" || challenge8 == "done" || challenge9 == "done" || challenge10 == "done")
    	{
    		notCollected.SetActive(true);
    	}
    	else
    	{
    		notCollected.SetActive(false);
    	}
    }
    public void Collect1()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 500);
    	PlayerPrefs.SetString("Challenge1", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 500 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 500 coins";
    	}
    	StartCoroutine(DisText());
    }
    public void Collect2()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 750);
    	PlayerPrefs.SetString("Challenge2", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 750 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 750 coins";
    	}
    	StartCoroutine(DisText());
    }

    public void Collect3()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 700);
    	PlayerPrefs.SetString("Challenge3", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 700 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 700 coins";
    	}
    	StartCoroutine(DisText());
    }

    public void Collect4()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 800);
    	PlayerPrefs.SetString("Challenge4", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 800 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 800 coins";
    	}
    	StartCoroutine(DisText());
    }
    public void Collect5()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 900);
    	PlayerPrefs.SetString("Challenge5", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 900 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 900 coins";
    	}
    	StartCoroutine(DisText());
    }
    public void Collect6()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 1000);
    	PlayerPrefs.SetString("Challenge6", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 1000 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 1000 coins";
    	}
    	StartCoroutine(DisText());
    }
    public void Collect7()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 1100);
    	PlayerPrefs.SetString("Challenge7", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 1100 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 1100 coins";
    	}
    	StartCoroutine(DisText());
    }
    public void Collect8()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 1150);
    	PlayerPrefs.SetString("Challenge8", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 1150 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 1150 coins";
    	}
    	StartCoroutine(DisText());
    }
    public void Collect9()
    {
    	PlayerPrefs.SetInt("Coins", coinsTaker + 1250);
    	PlayerPrefs.SetString("Challenge9", "collected");
    	pièceReceiveText.enabled = true;
    	if(lang == "fr")
    	{
    		pièceReceiveText.text = "Vous venez de recevoir 1250 pièces";
    	}
    	else{
    		pièceReceiveText.text = "You just received 1250 coins";
    	}
    	
    	StartCoroutine(DisText());
    }
    public void Collect10()
    {
    	PlayerPrefs.SetString("Challenge10", "collected");
    	pièceReceiveText.enabled = true;
    	PlayerPrefs.SetString("Inferno", "yes");
    	infernoObtained.SetActive(true);
    	StartCoroutine(DisText());
    }

    public void CloseInfernoPanel()
    {
    	infernoObtained.SetActive(false);
    }

    public IEnumerator DisText()
    {
    	coinSound.Play(0);
    	yield return new WaitForSeconds(1);
    	pièceReceiveText.enabled = false;
    	coinSound.Stop();
    }

}
