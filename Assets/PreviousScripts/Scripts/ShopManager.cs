using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
	public int money;
	public Text moneyText, infoText;
	public GameObject buyText, upFlatPriceText, botferPriceText, hatchPriceText, sedanMaxPriceText, ghostPriceText, infernoPriceText, infoPanel, infoSure;
	public string chooseUpFlat, chooseBotfer, chooseHatch, chooseSedanMax, chooseGhost, chooseInferno, carChoosed, chal9, chal10;
	public GameObject checkMarkUpFlat, checkMarkSedan, checkMarkBotfer, checkMarkHatch, checkMarkSedanMax, checkMarkGhost, checkMarkInferno;
	public Animator sedanAnim, upflatAnim, botferAnim, hatchAnim, sedanMaxAnim, ghostAnim, infernoAnim;
	public GameObject upFlatImage, botferImage, hatchImage, sedanMaxImage, ghostImage;
	public static ShopManager instance;
    public Button yesButton;
    public AudioSource coinSound;
    public string lang;
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
		checkMarkHatch.SetActive(false);
		checkMarkBotfer.SetActive(false);
		checkMarkSedan.SetActive(false);
		checkMarkUpFlat.SetActive(false);
        checkMarkGhost.SetActive(false);
        checkMarkSedanMax.SetActive(false);
        checkMarkInferno.SetActive(false);
		upFlatImage.SetActive(false);
    	botferImage.SetActive(false);
    	hatchImage.SetActive(false);
        sedanMaxImage.SetActive(false);
        ghostImage.SetActive(false);
    	infoPanel.SetActive(false);
        infoSure.SetActive(false);
	}
	void Update()
	{
        lang = PlayerPrefs.GetString ("_language", "fr");
        chal9 = PlayerPrefs.GetString("Challenge9", "no");
        chal10 = PlayerPrefs.GetString("Challenge10", "no");
		chooseUpFlat = PlayerPrefs.GetString("UpFlat");
		chooseBotfer = PlayerPrefs.GetString("Botfer");
		chooseHatch = PlayerPrefs.GetString("Hatch");
        chooseSedanMax = PlayerPrefs.GetString("SedanMax");
        chooseGhost = PlayerPrefs.GetString("Ghost");
        chooseInferno = PlayerPrefs.GetString("Inferno");
        carChoosed = PlayerPrefs.GetString("CarChoosed", "Sedan");
		money = PlayerPrefs.GetInt("Coins", 0);
		moneyText.text = money.ToString();
		if(carChoosed == null)
		{
            carChoosed = "Sedan";
		}
		if(chooseUpFlat == "yes")
		{
			upFlatPriceText.SetActive(false);
		}
		if(chooseBotfer == "yes")
		{
			botferPriceText.SetActive(false);
		}
		if(chooseHatch == "yes")
		{
			hatchPriceText.SetActive(false);
		}
        if(chooseSedanMax == "yes")
        {
            sedanMaxPriceText.SetActive(false);
        }
        if(chooseGhost == "yes")
        {
            ghostPriceText.SetActive(false);
        }
        if(chooseInferno == "yes")
        {
            infernoPriceText.SetActive(false);
        }
        if(chooseUpFlat == "yes" && chooseBotfer == "yes" && chooseHatch == "yes" && chooseSedanMax == "yes" && chooseGhost == "yes" && chal9 == "no")
        {
            PlayerPrefs.SetString("Challenge9", "done");
        }
		if(carChoosed == "Sedan")
		{
			checkMarkHatch.SetActive(false);
    		hatchAnim.enabled= false;
    		sedanAnim.enabled = true;
    		upflatAnim.enabled = false;
    		botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
    		checkMarkSedan.SetActive(true);
    		checkMarkUpFlat.SetActive(false);
    		checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
		}
		else if(carChoosed == "UpFlat")
		{
			checkMarkHatch.SetActive(false);
    		hatchAnim.enabled= false;
    		sedanAnim.enabled = false;
    		upflatAnim.enabled = true;
    		botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
    		checkMarkSedan.SetActive(false);
    		checkMarkUpFlat.SetActive(true);
    		checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
		}
		else if(carChoosed == "Botfer")
		{
			checkMarkHatch.SetActive(false);
    		hatchAnim.enabled= false;
    		sedanAnim.enabled = false;
    		upflatAnim.enabled = false;
    		botferAnim.enabled = true;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
    		checkMarkSedan.SetActive(false);
    		checkMarkUpFlat.SetActive(false);
    		checkMarkBotfer.SetActive(true);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
		}
		else if(carChoosed == "Hatch")
		{
			checkMarkHatch.SetActive(true);
    		hatchAnim.enabled= true;
    		sedanAnim.enabled = false;
    		upflatAnim.enabled = false;
    		botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
    		checkMarkSedan.SetActive(false);
    		checkMarkUpFlat.SetActive(false);
    		checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
		}
        else if(carChoosed == "SedanMax")
        {
            checkMarkHatch.SetActive(false);
            hatchAnim.enabled= false;
            sedanAnim.enabled = false;
            upflatAnim.enabled = false;
            botferAnim.enabled = false;
            sedanMaxAnim.enabled = true;
            ghostAnim.enabled = false;
            checkMarkSedan.SetActive(false);
            checkMarkUpFlat.SetActive(false);
            checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(true);
            checkMarkGhost.SetActive(false);
        }
        else if(carChoosed == "Ghost")
        {
            checkMarkHatch.SetActive(false);
            hatchAnim.enabled= false;
            sedanAnim.enabled = false;
            upflatAnim.enabled = false;
            botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = true;
            checkMarkSedan.SetActive(false);
            checkMarkUpFlat.SetActive(false);
            checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(true);
        }
        else if(carChoosed == "Inferno")
        {
            checkMarkHatch.SetActive(false);
            hatchAnim.enabled= false;
            sedanAnim.enabled = false;
            upflatAnim.enabled = false;
            botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
            infernoAnim.enabled = true;
            checkMarkInferno.SetActive(true);
            checkMarkSedan.SetActive(false);
            checkMarkUpFlat.SetActive(false);
            checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
        }
	}
    public void BuyUpFlat()
    {
    	if(money >= 1000 && chooseUpFlat != "yes")
    	{
            infoSure.SetActive(true);
            yesButton.onClick.RemoveListener(SureToBuyUpFlat);
    		yesButton.onClick.AddListener(SureToBuyUpFlat);
            yesButton.onClick.RemoveListener(SureToBuyBotfer);
            yesButton.onClick.RemoveListener(SureToBuyHatch);
            yesButton.onClick.RemoveListener(SureToBuySedanMax);
            yesButton.onClick.RemoveListener(SureToBuyGhost);
    	}
    	if(money < 1000 && chooseUpFlat != "yes")
    	{
    		if(lang == "fr")
            {
                infoText.text = "Pas assez de pièces";
            }
            else if(lang == "en")
            {
                infoText.text = "Not enough coins";
            }

    		infoPanel.SetActive(true);
    	}
    	if(chooseUpFlat == "yes")
    	{
    		ChooseUpFlat();
    	}
    }
    public void SureToBuyUpFlat()
    {
        coinSound.Play(0);
        infoSure.SetActive(false);
        money = money - 1000;
        PlayerPrefs.SetInt("Coins",money);
        upFlatPriceText.SetActive(false);
        PlayerPrefs.SetString("UpFlat", "yes");
        infoPanel.SetActive(true);
        infoText.text = "UpFlat";
        upFlatImage.SetActive(true);
        StartCoroutine(DisSound());
    }
    public void BuyBotfer()
    {
    	if(money >= 5000 && chooseBotfer != "yes")
    	{
    		infoSure.SetActive(true);
            yesButton.onClick.RemoveListener(SureToBuyBotfer);
            yesButton.onClick.AddListener(SureToBuyBotfer);
            yesButton.onClick.RemoveListener(SureToBuyUpFlat);
            yesButton.onClick.RemoveListener(SureToBuyHatch);
            yesButton.onClick.RemoveListener(SureToBuySedanMax);
            yesButton.onClick.RemoveListener(SureToBuyGhost);
    	}
    	if(money < 5000 && chooseBotfer != "yes")
    	{
    		if(lang == "fr")
            {
                infoText.text = "Pas assez de pièces";
            }
            else if(lang == "en")
            {
                infoText.text = "Not enough coins";
            }
    		infoPanel.SetActive(true);
    	}
    	if(chooseBotfer == "yes")
    	{
    		ChooseBotfer();
    	}
    }
    public void SureToBuyBotfer()
    {
        coinSound.Play(0);
        infoSure.SetActive(false);
        money = money - 5000;
        PlayerPrefs.SetInt("Coins",money);
        botferPriceText.SetActive(false);
        PlayerPrefs.SetString("Botfer", "yes");
        infoPanel.SetActive(true);
        infoText.text = "Botfer";
        botferImage.SetActive(true);
        StartCoroutine(DisSound());
    }
    public void BuyHatch()
    {
    	if(money >= 7500 && chooseHatch != "yes")
    	{
            infoSure.SetActive(true);
            yesButton.onClick.RemoveListener(SureToBuyHatch);
    		yesButton.onClick.AddListener(SureToBuyHatch);
            yesButton.onClick.RemoveListener(SureToBuyBotfer);
            yesButton.onClick.RemoveListener(SureToBuyUpFlat);
            yesButton.onClick.RemoveListener(SureToBuySedanMax);
            yesButton.onClick.RemoveListener(SureToBuyGhost);
    	}
    	if(money < 7500 && chooseHatch != "yes")
    	{
    		if(lang == "fr")
            {
                infoText.text = "Pas assez de pièces";
            }
            else if(lang == "en")
            {
                infoText.text = "Not enough coins";
            }
    		infoPanel.SetActive(true);
    	}
    	if(chooseHatch == "yes")
    	{
    		ChooseHatch();
    	}
    }
    public void SureToBuyHatch()
    {
        coinSound.Play(0);
        infoSure.SetActive(false);
        money = money - 7500;
        PlayerPrefs.SetInt("Coins",money);
        hatchPriceText.SetActive(false);
        PlayerPrefs.SetString("Hatch", "yes");
        infoPanel.SetActive(true);
        infoText.text = "Hatch";
        hatchImage.SetActive(true);
        StartCoroutine(DisSound());
    }
    public void BuySedanMax()
    {
        if(money >= 15000 && chooseSedanMax != "yes")
        {
            infoSure.SetActive(true);
            yesButton.onClick.RemoveListener(SureToBuySedanMax);
            yesButton.onClick.AddListener(SureToBuySedanMax);
            yesButton.onClick.RemoveListener(SureToBuyBotfer);
            yesButton.onClick.RemoveListener(SureToBuyHatch);
            yesButton.onClick.RemoveListener(SureToBuyUpFlat);
            yesButton.onClick.RemoveListener(SureToBuyGhost);
        }
        if(money < 15000 && chooseSedanMax != "yes")
        {
            if(lang == "fr")
            {
                infoText.text = "Pas assez de pièces";
            }
            else if(lang == "en")
            {
                infoText.text = "Not enough coins";
            }
            infoPanel.SetActive(true);
        }
        if(chooseSedanMax == "yes")
        {
            ChooseSedanMax();
        }
    }
    public void SureToBuySedanMax()
    {
        coinSound.Play(0);
        infoSure.SetActive(false);
        money = money - 15000;
        PlayerPrefs.SetInt("Coins",money);
        sedanMaxPriceText.SetActive(false);
        PlayerPrefs.SetString("SedanMax", "yes");
        infoPanel.SetActive(true);
        infoText.text = "SedanMax";
        sedanMaxImage.SetActive(true);
        StartCoroutine(DisSound());
    }
    public void BuyGhost()
    {
        if(money >= 20000 && chooseGhost != "yes")
        {
            infoSure.SetActive(true);
            yesButton.onClick.RemoveListener(SureToBuyGhost);
            yesButton.onClick.AddListener(SureToBuyGhost);
            yesButton.onClick.RemoveListener(SureToBuyBotfer);
            yesButton.onClick.RemoveListener(SureToBuyHatch);
            yesButton.onClick.RemoveListener(SureToBuySedanMax);
            yesButton.onClick.RemoveListener(SureToBuyUpFlat);
        }
        if(money < 20000 && chooseGhost != "yes")
        {
            if(lang == "fr")
            {
                infoText.text = "Pas assez de pièces";
            }
            else if(lang == "en")
            {
                infoText.text = "Not enough coins";
            }
            infoPanel.SetActive(true);
        }
        if(chooseGhost == "yes")
        {
            ChooseGhost();
        }
    }
    public void SureToBuyGhost()
    {
        coinSound.Play(0);
        infoSure.SetActive(false);
        money = money - 20000;
        PlayerPrefs.SetInt("Coins",money);
        ghostPriceText.SetActive(false);
        PlayerPrefs.SetString("Ghost", "yes");
        infoPanel.SetActive(true);
        infoText.text = "Ghost";
        ghostImage.SetActive(true);   
        StartCoroutine(DisSound());
    }
    public void ChooseSedan()
    {
    	checkMarkSedan.SetActive(true);
    	sedanAnim.enabled= true;
    	upflatAnim.enabled = false;
    	botferAnim.enabled = false;
    	hatchAnim.enabled = false;
        sedanMaxAnim.enabled = false;
        ghostAnim.enabled = false;
        infernoAnim.enabled = false;
        checkMarkInferno.SetActive(false);
    	checkMarkUpFlat.SetActive(false);
    	checkMarkBotfer.SetActive(false);
    	checkMarkHatch.SetActive(false);
        checkMarkSedanMax.SetActive(false);
        checkMarkGhost.SetActive(false);
    	PlayerPrefs.SetString("CarChoosed", "Sedan");
    }
    public void ChooseUpFlat()
    {
    	if(chooseUpFlat == "yes")
    	{
    		checkMarkUpFlat.SetActive(true);
    		upflatAnim.enabled= true;
    		sedanAnim.enabled = false;
    		botferAnim.enabled = false;
    		hatchAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
            infernoAnim.enabled = false;
            checkMarkInferno.SetActive(false);
    		checkMarkSedan.SetActive(false);
    		checkMarkBotfer.SetActive(false);
    		checkMarkHatch.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
    		PlayerPrefs.SetString("CarChoosed", "UpFlat");
    	}
    }
    public void ChooseBotfer()
    {
    	if(chooseBotfer == "yes")
    	{
    		checkMarkBotfer.SetActive(true);
    		botferAnim.enabled= true;
    		sedanAnim.enabled = false;
    		upflatAnim.enabled = false;
    		hatchAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
            infernoAnim.enabled = false;
            checkMarkInferno.SetActive(false);
    		checkMarkSedan.SetActive(false);
    		checkMarkUpFlat.SetActive(false);
    		checkMarkHatch.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
    		PlayerPrefs.SetString("CarChoosed", "Botfer");
    	}	
    }
    public void ChooseHatch()
    {
    	if(chooseHatch == "yes")
    	{
    		checkMarkHatch.SetActive(true);
    		hatchAnim.enabled= true;
    		sedanAnim.enabled = false;
    		upflatAnim.enabled = false;
    		botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
            infernoAnim.enabled = false;
            checkMarkInferno.SetActive(false);
    		checkMarkSedan.SetActive(false);
    		checkMarkUpFlat.SetActive(false);
    		checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
    		PlayerPrefs.SetString("CarChoosed", "Hatch");
    	}	
    }
    public void ChooseSedanMax()
    {
        if(chooseSedanMax == "yes")
        {
            checkMarkHatch.SetActive(false);
            hatchAnim.enabled= false;
            sedanAnim.enabled = false;
            upflatAnim.enabled = false;
            botferAnim.enabled = false;
            sedanMaxAnim.enabled = true;
            ghostAnim.enabled = false;
            infernoAnim.enabled = false;
            checkMarkInferno.SetActive(false);
            checkMarkSedan.SetActive(false);
            checkMarkUpFlat.SetActive(false);
            checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(true);
            checkMarkGhost.SetActive(false);
            PlayerPrefs.SetString("CarChoosed", "SedanMax");
        }   
    }
    public void ChooseGhost()
    {
        if(chooseGhost == "yes")
        {
            checkMarkHatch.SetActive(false);
            hatchAnim.enabled = false;
            sedanAnim.enabled = false;
            upflatAnim.enabled = false;
            botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = true;
            checkMarkSedan.SetActive(false);
            checkMarkUpFlat.SetActive(false);
            checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(true);
            infernoAnim.enabled = false;
            checkMarkInferno.SetActive(false);
            PlayerPrefs.SetString("CarChoosed", "Ghost");
        }   
    }
    public void ChooseInerno()
    {
        if(chooseInferno == "yes")
        {
            checkMarkHatch.SetActive(false);
            hatchAnim.enabled = false;
            sedanAnim.enabled = false;
            upflatAnim.enabled = false;
            botferAnim.enabled = false;
            sedanMaxAnim.enabled = false;
            ghostAnim.enabled = false;
            infernoAnim.enabled = true;
            checkMarkSedan.SetActive(false);
            checkMarkUpFlat.SetActive(false);
            checkMarkBotfer.SetActive(false);
            checkMarkSedanMax.SetActive(false);
            checkMarkGhost.SetActive(false);
            checkMarkInferno.SetActive(true);
            PlayerPrefs.SetString("CarChoosed", "Inferno");
        }
        else{
            buyText.SetActive(false);
            if(lang == "fr")
            {
                infoText.text = "Terminer tous les défis du jeu pour accéder à cette voiture";
            }
            else if(lang == "en")
            {
                infoText.text = "Complete all the challenges of the game to access this car";
            }
            infoPanel.SetActive(true);
        }
    }
    public void CloseInfoPanel()
    {
    	upFlatImage.SetActive(false);
    	botferImage.SetActive(false);
    	hatchImage.SetActive(false);
        sedanMaxImage.SetActive(false);
        ghostImage.SetActive(false);
    	infoPanel.SetActive(false);
        infoSure.SetActive(false);
        buyText.SetActive(true);
    }
    public IEnumerator DisSound()
    {
        yield return new WaitForSeconds(1);
        coinSound.Stop();
    }
}