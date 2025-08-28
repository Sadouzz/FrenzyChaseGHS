using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using Newtonsoft.Json.Linq;


public class UIScript : MonoBehaviour
{
    bool secondPack;
    public AudioSource openPackAudio;
    public Image articleImageSprite;
    public Sprite[] articleSprites;

    public string[] _coinsPossibleOnPack, powerUps, carsPossibleOnPack, rewardPossible;
    public bool play;
    public Button buyButton;
    public GameObject secondPanelReward, carsUnlocking, gainedGameObjectOnPack, statsBoardOnClaimReward, starsOnClaimReward, achievementsPanel, inventoryPanel, playPanel, rewardPanel, loadingScreen, shopPanel, settingsPanel, profilePanel, pseudoPanel, navBar, buyPanel;
    public TextMeshProUGUI starsOnClaim, levelText, pseudoText, pseudoText1, starsText, textCoinsToAdd, objectGetOnPack, recapPack, totalCars, totalMaps, highScoreText, highPoliceDestroyedText, highTotalSecondsOutputText, totalScoreText, totalPoliceDestroyedText, totalSecondsPlayed, priceTextBuyingPanel, levelOnUpgradeRewardCarText;
    public Transform car;
    public TMP_InputField pseudoInputField;

    public GameObject mapSelection, noMoneyPanel;

    public GameObject rewardPanelImage;

    public Image showedPack;

    public Sprite bluePack, purplePack, starsSprite, carRapide, tata, taxi, diagaNdiaye, dakarDemDikk, turrel, fireCircle, destabilizator, saw, mines, greenBackOnReward, blueBackOnReward, purpleBackOnReward;

    //public Sprite bluePack, purplePack, starsSprite, sedan, hatro, taxi, terza, macT, tRash, van, fireT, hatch, flato, sPera, ghost, turrel, fireCircle, destabilizator, saw, mines, greenBackOnReward, blueBackOnReward, purpleBackOnReward;

    public int stars;

    public Animator pack;

    public GameObject sedanCarReward, carRapideCarReward, tataCarReward, taxiCarReward, diagaNdiayeCarReward, dakarDemDikkCarReward;
    //public GameObject sedanCarReward, hatroCarReward, taxiCarReward, terzaCarReward, macTCarReward, tRashCarReward, vanCarReward, fireTCarReward, hatchCarReward, flatoCarReward, sPeraCarReward, ghostCarReward;

    int rOnPack;
    string obtainedRewardOnPack;

    public Sprite[] itemSprites;
    public string[] itemStrings;

    public static UIScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'un inventaire");
            return;
        }
        instance = this;
        itemSprites = new Sprite[] { carRapide, tata, taxi, diagaNdiaye, dakarDemDikk, turrel, fireCircle, destabilizator, saw, mines };
        itemStrings = new string[] { "carRapide", "tata", "taxi", "diagaNdiaye", "dakarDemDikk", "Tourelle", "Cercle de feu", "D�stabilisateur", "Scies", "Mines" };
    }
    void Start()
    {
        Time.timeScale = 1;
        int _index = PlayerPrefs.GetInt("map", 0);
        SettingsToggle(_index);

        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        //highPoliceDestroyedText.text = PlayerPrefs.GetInt("highDestroyedCars", 0).ToString();
        //highTotalSecondsOutputText.text = PlayerPrefs.GetString("highTotalSecondsOutput", "00:00:00");

        //totalScoreText.text = PlayerPrefs.GetInt("totalScore", 0).ToString(); 
        totalPoliceDestroyedText.text = PlayerPrefs.GetInt("totalDestroyedCars", 0).ToString();
        totalSecondsPlayed.text = PlayerPrefs.GetString("totalSecondsPlayedOutput", "00:00:00");
    }

    void Update()
    {
        totalCars.text = PlayerPrefs.GetInt("carsOwned", 1) + "/5";
        int mapsCount = 1;
        if (PlayerPrefs.GetString("lagosPaid", "no") == "yes")
        {
            if (PlayerPrefs.GetString("cityPaid", "no") == "yes")
            {
                mapsCount = 3;
            }
            else
            {
                mapsCount = 2;
            }
        }
        else
        {
            if (PlayerPrefs.GetString("cityPaid", "no") == "yes")
            {
                mapsCount = 2;
            }
        }
        totalMaps.text = mapsCount.ToString() + "/2";
        stars = PlayerPrefs.GetInt("stars", 0);
        starsOnClaim.text = PlayerPrefs.GetInt("stars", 0).ToString();
        starsText.text = stars.ToString();
        pseudoText.text = PlayerPrefs.GetString("pseudo", "player");
        pseudoText1.text = PlayerPrefs.GetString("pseudo", "player");

        if (PlayerPrefs.GetString("lagosPaid", "no") == "yes")
        {
            mapSelection.transform.GetChild(1).GetChild(1).transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetString("cityPaid", "no") == "yes")
        {
            mapSelection.transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetString("beachPaid", "no") == "yes" && PlayerPrefs.GetString("cityPaid", "no") == "yes")
        {
            PlayerPrefs.SetString("allMapsUnlocked", "yes");
        }

        if (PlayerPrefs.GetString("allCarsUnlocked", "no") == "yes" && PlayerPrefs.GetString("allMapsUnlocked", "no") == "yes")
        {
            PlayerPrefs.SetString("allCarsMapsUnlocked", "yes");
        }
    }

    public void UpdatePseudo()
    {
        pseudoInputField.text = PlayerPrefs.GetString("pseudo", "player");
    }
    public void Play()
    {
        //TimeManagerFreePack.instance.SavingTime();
        //TimeManagerFreePackWithAd.instance.SavingTime();
        StartCoroutine(LoadingPlay());
    }

    public IEnumerator LoadingPlay()
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        //AdMob.instance.DestroyAd();
        SceneManager.LoadScene(1);
    }

    public void OnClickAchievements()
    {
        achievementsPanel.SetActive(true);
    }

    public void OnCloseAchievements()
    {
        achievementsPanel.SetActive(false);
    }

    public void OnclickSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnCloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OnChangePseudo()
    {
        pseudoPanel.SetActive(true);
    }

    public void OnClosePseudo()
    {
        pseudoPanel.SetActive(false);
        PlayerPrefs.SetString("pseudo", pseudoInputField.text);
    }

    public void OnClickProfile()
    {
        profilePanel.SetActive(true);
    }

    public void OnCloseProfile()
    {
        profilePanel.SetActive(false);
    }

    public void OnClickShop()
    {
        PlayPanelOpening(false);
        InventoryOpening(false);
        ShopOpening(true);
    }

    public void OnClickInventory()
    {
        ShopOpening(false);
        PlayPanelOpening(false);
        InventoryOpening(true);
        UpdateCarOrPower.instance.updatePanel.SetActive(false);
    }

    public void OnClickPlay()
    {
        ShopOpening(false);
        InventoryOpening(false);
        PlayPanelOpening(true);
    }

    public void ShopOpening(bool _bool)
    {
        if (_bool)
        {
            shopPanel.GetComponent<CanvasGroup>().alpha = 1;
            shopPanel.GetComponent<CanvasGroup>().interactable = true;
            shopPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            shopPanel.GetComponent<CanvasGroup>().alpha = 0;
            shopPanel.GetComponent<CanvasGroup>().interactable = false;
            shopPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        if (_bool)
        {
            //EventSystem.current.currentSelectedGameObject.transform.GetChild(3).gameObject.SetActive(_bool);
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color32(33, 65, 142, 255);
        }
        else
        {
            navBar.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
            //EventSystem.current.currentSelectedGameObject.;
        }
    }

    public void PlayPanelOpening(bool _bool)
    {
        if (_bool)
        {
            playPanel.GetComponent<CanvasGroup>().alpha = 1;
            playPanel.GetComponent<CanvasGroup>().interactable = true;
            playPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            playPanel.GetComponent<CanvasGroup>().alpha = 0;
            playPanel.GetComponent<CanvasGroup>().interactable = false;
            playPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        if (_bool)
        {
            //EventSystem.current.currentSelectedGameObject.transform.GetChild(3).gameObject.SetActive(_bool);
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color32(33, 65, 142, 255);
        }
        else
        {
            navBar.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
            //EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
        }
    }

    public void InventoryOpening(bool _bool)
    {
        if (_bool)
        {
            inventoryPanel.GetComponent<CanvasGroup>().alpha = 1;
            inventoryPanel.GetComponent<CanvasGroup>().interactable = true;
            inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
            inventoryPanel.GetComponent<CanvasGroup>().interactable = false;
            inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        if (_bool)
        {
            //EventSystem.current.currentSelectedGameObject.transform.GetChild(3).gameObject.SetActive(_bool);
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color32(33, 65, 142, 255);
        }
        else
        {
            navBar.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
            //EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
        }
    }

    public void OpenShopDirectly()
    {
        navBar.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color32(33, 65, 142, 255);
        playPanel.GetComponent<CanvasGroup>().alpha = 0;
        playPanel.GetComponent<CanvasGroup>().interactable = false;
        playPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        navBar.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
        inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
        inventoryPanel.GetComponent<CanvasGroup>().interactable = false;
        inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        navBar.transform.GetChild(2).gameObject.GetComponent<Image>().color = new Color32(54, 217, 255, 255);
        shopPanel.GetComponent<CanvasGroup>().alpha = 1;
        shopPanel.GetComponent<CanvasGroup>().interactable = true;
        shopPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void ClaimRewardOnPack(string packColor)
    {
        PackOpening.instance.Opening();
        rewardPanel.SetActive(true);
        if (packColor == "blue")
        {
            showedPack.sprite = bluePack;
        }
        if (packColor == "purple")
        {
            showedPack.sprite = purplePack;
        }
        if (packColor == "bluePurple")
        {
            secondPack = true;
            showedPack.sprite = bluePack;
        }
        /*
        int r = Random.Range(0, _coinsPossibleOnPack.Length);
        int _coinsToAdd = _coinsPossibleOnPack[r]; 
        textCoinsToAdd.text = _coinsToAdd.ToString() + " etoiles";
        rewardPanel.SetActive(true);
        PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) + _coinsToAdd);
        */
        carsPossibleOnPack = UpgradableCars.instance.carsList;
        //rewardPossible = _coinsPossibleOnPack;
        for (int i = 0; i < _coinsPossibleOnPack.Length; i++)
        {
            rewardPossible[i] = _coinsPossibleOnPack[i];
        }
        for (int i = 5; i < powerUps.Length + 5; i++)
        {
            rewardPossible[i] = powerUps[i - 5];
        }
        for (int i = 10; i < carsPossibleOnPack.Length + 10; i++)
        {
            rewardPossible[i] = carsPossibleOnPack[i - 10];
        }
        int a = CountFilled(rewardPossible);
        int r = Random.Range(0, a);
        string obtainedReward = rewardPossible[r];
        textCoinsToAdd.text = obtainedReward;
        obtainedRewardOnPack = obtainedReward;
        rOnPack = r;
        //ImageOnClaimPanel(obtainedReward, r);

        Debug.Log("OnClaim");
        rewardPanelImage.transform.parent.gameObject.SetActive(false);

        levelText.gameObject.SetActive(false);
        objectGetOnPack.gameObject.SetActive(false);
        recapPack.gameObject.SetActive(false);
        textCoinsToAdd.gameObject.SetActive(false);
        statsBoardOnClaimReward.SetActive(false);
        starsOnClaimReward.SetActive(false);
    }

    int CountFilled(string[] array)
    {
        int count = 0;
        foreach (string element in array)
        {
            if (!string.IsNullOrEmpty(element))
            {
                count++;
            }
        }
        return count;
    }

    public void ImageOnClaimPanel(string _obtained, int r)
    {
        textCoinsToAdd.gameObject.SetActive(true);
        //recapPack.gameObject.SetActive(false);
        //openPackAudio.Play();
        //Debug.Log("Hriifjekn");
        rewardPanelImage.transform.parent.gameObject.SetActive(true);
        gainedGameObjectOnPack.SetActive(true);
        int randomCardsToAdd = 0;

        if (r < 5)
        {
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = starsSprite;

            textCoinsToAdd.text = "x" + _obtained;
            objectGetOnPack.text = "ETOILES";
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) + int.Parse(_obtained));
            levelText.gameObject.SetActive(false);
            statsBoardOnClaimReward.SetActive(false);
            starsOnClaimReward.SetActive(true);
            recapPack.text = "DEVISE ACTUELLE : ETOILES";
            gainedGameObjectOnPack.SetActive(true);
        }
        else
        {
            starsOnClaimReward.SetActive(false);
            recapPack.text = "STATISTIQUES : " + _obtained;
            //gainedGameObjectOnPack.SetActive(false);
        }


        if (_obtained == "carRapide")
        {
            objectGetOnPack.text = "Car Rapide";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = carRapide;

            starsOnClaimReward.SetActive(false);
            //levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
            //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
            //levelText.gameObject.SetActive(true);
            //levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
            //statsBoardOnClaimReward.SetActive(true);

            //StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);

        }
        if (_obtained == "tata")
        {
            objectGetOnPack.text = "Tata";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = tata;

            starsOnClaimReward.SetActive(false);
        }

        if (_obtained == "taxi")
        {
            objectGetOnPack.text = "Taxi";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = taxi;

            starsOnClaimReward.SetActive(false);
        }

        if (_obtained == "diagaNdiaye")
        {
            objectGetOnPack.text = "DiagaNdiaye";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = blueBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = diagaNdiaye;

            starsOnClaimReward.SetActive(false);
        }

        if (_obtained == "dakarDemDikk")
        {
            objectGetOnPack.text = "DakarDemDikk";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = blueBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = dakarDemDikk;

            starsOnClaimReward.SetActive(false);
        }



        if (_obtained == "Tourelle")
        {
            objectGetOnPack.text = "Tourelle";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = turrel;

            starsOnClaimReward.SetActive(false);
        }
        if (_obtained == "Cercle de feu")
        {
            objectGetOnPack.text = "Cercle de feu";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = fireCircle;

            starsOnClaimReward.SetActive(false);
        }
        if (_obtained == "D�stabilisateur")
        {
            objectGetOnPack.text = "Destabilisateur";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = destabilizator;

            starsOnClaimReward.SetActive(false);
        }
        if (_obtained == "Scies")
        {
            objectGetOnPack.text = "Scies";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = saw;

            starsOnClaimReward.SetActive(false);
        }
        if (_obtained == "Mines")
        {
            objectGetOnPack.text = "Mines";
            //sedanCarReward.SetActive(true);
            randomCardsToAdd = Random.Range(1, 10);
            rewardPanelImage.transform.parent.gameObject.GetComponent<Image>().sprite = greenBackOnReward;
            rewardPanelImage.GetComponent<Image>().sprite = mines;

            starsOnClaimReward.SetActive(false);
        }
        if (r >= 5)
        {
            randomCardsToAdd = randomCardsToAdd * PlayerPrefs.GetInt(_obtained + "Level", 1);
            textCoinsToAdd.text = "x" + randomCardsToAdd;
        }


        if (r >= 5)
        {
            if (randomCardsToAdd <= 0)
            {
                randomCardsToAdd = Random.Range(1, 10);
                Debug.LogWarning("randomCardsToAdd était à 0, valeur par défaut appliquée pour : " + _obtained);
            }

            randomCardsToAdd *= Mathf.Max(1, PlayerPrefs.GetInt(_obtained + "Level", 1));
            textCoinsToAdd.text = "x" + randomCardsToAdd;

            //CardsManager.instance.AddCards(randomCardsToAdd, _obtained);
            CardsManager.instance.AddCards(randomCardsToAdd, _obtained);
        }

        /*if (_obtained == "hatro")
        {
            objectGetOnPack.text = "Hatro";
            hatroCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = hatro;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = hatro;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "taxi")
        {
            objectGetOnPack.text = "Taxi";
            taxiCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = taxi;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                //StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = taxi;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "terza")
        {
            objectGetOnPack.text = "Terza";
            terzaCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = terza;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = terza;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "mac-T")
        {
            objectGetOnPack.text = "Mac-T";
            macTCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = macT;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = macT;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "t-Rash")
        {
            objectGetOnPack.text = "T-Rash";
            tRashCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = tRash;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = tRash;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "van")
        {
            objectGetOnPack.text = "Van";
            vanCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = van;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = van;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "fire-T")
        {
            objectGetOnPack.text = "Fire-T";
            fireTCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = fireT;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = fireT;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "hatch")
        {
            objectGetOnPack.text = "Hatch";
            hatchCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = hatch;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = hatch;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "flato")
        {
            objectGetOnPack.text = "Flato";
            flatoCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = flato;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = flato;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "s-Pera")
        {
            objectGetOnPack.text = "S-Pera";
            sPeraCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = sPera;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = sPera;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //8PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "ghost")
        {
            objectGetOnPack.text = "Ghost";
            ghostCarReward.SetActive(true);
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = ghost;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = ghost;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(true, false, _obtained);
            }
        }
        if (_obtained == "Tourelle")
        {
            objectGetOnPack.text = "Tourelle";
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = turrel;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, true, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = turrel;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, true, _obtained);
            }
        }
        if (_obtained == "Cercle de feu")
        {
            objectGetOnPack.text = "Cercle de feu";
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = fireCircle;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = fireCircle;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, false, _obtained);
            }
        }
        if (_obtained == "Destabilisateur")
        {
            objectGetOnPack.text = "Destabilisateur";
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = destabilizator;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, true, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = destabilizator;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, true, _obtained);
            }
        }
        if (_obtained == "Scies")
        {
            objectGetOnPack.text = "Scies";
            if (PlayerPrefs.GetInt(_obtained + "Level", 1) < 5)
            {
                rewardPanelImage.GetComponent<Image>().sprite = saw;
                
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 1) + 1).ToString();
                PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau " + PlayerPrefs.GetInt(_obtained + "Level", 1);
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, false, _obtained);
            }
            else
            {
                rewardPanelImage.GetComponent<Image>().sprite = saw;
                levelOnUpgradeRewardCarText.text = (PlayerPrefs.GetInt(_obtained + "Level", 5)).ToString();
                //PlayerPrefs.SetInt(_obtained + "Level", PlayerPrefs.GetInt(_obtained + "Level", 1) + 1);
                levelText.gameObject.SetActive(true);
                levelText.text = "Niveau MAX";
                statsBoardOnClaimReward.SetActive(true);
                starsOnClaimReward.SetActive(false);
                StatsOnClaimReward.instance.StatsDisplay(false, false, _obtained);
            }
        }*/

    }

    public void OpenRewardOnPack()
    {
        Debug.Log("defefefe");
        pack.SetBool("openAndPlayAnims", true);
        openPackAudio.Play();
        //packOpeningButton.onClick.AddListener(delegate { EndRewardOnPack(); });
        secondPanelReward.SetActive(true);
        //carsUnlocking.SetActive(true );
        //carsUnlocking.GetComponent<CarOnClaimPack>().Drift();
        ImageOnClaimPanel(obtainedRewardOnPack, rOnPack);
        //levelOnUpgradeRewardCarImage.gameObject.SetActive(true);
        //levelText.gameObject.SetActive(true);
        objectGetOnPack.gameObject.SetActive(true);
        //recapPack.gameObject.SetActive(true);

    }
    public void EndRewardOnPack()
    {
        rewardPanel.SetActive(false);
        if (secondPack)
        {
            ClaimRewardOnPack("purple");
            secondPack = false;
        }
        else
        {
            PackOpening.instance.Closing();
        }
        carsUnlocking.SetActive(false);
        foreach (Transform child in carsUnlocking.transform)
        {
            // D�sactive le GameObject de l'enfant
            child.gameObject.SetActive(false);
        }
        secondPanelReward.SetActive(false);
    }

    public void SetMapParking()
    {
        PlayerPrefs.SetInt("map", 0);
        SettingsToggle(PlayerPrefs.GetInt("map", 0));
    }
    public void SetMapLagos()
    {
        if (PlayerPrefs.GetString("lagosPaid", "no") == "yes")
        {
            PlayerPrefs.SetInt("map", 1);
            SettingsToggle(PlayerPrefs.GetInt("map", 0));
        }
        else
        {
            BuyingPanel(1500);
            Indexer(0);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(1500, "lagos"); });
            SettingsToggle(PlayerPrefs.GetInt("map", 0));
        }
    }
    public void SetMapBeach()
    {
        if (PlayerPrefs.GetString("beachPaid", "no") == "yes")
        {
            PlayerPrefs.SetInt("map", 1);
            SettingsToggle(PlayerPrefs.GetInt("map", 0));
        }
        else
        {
            BuyingPanel(1500);
            Indexer(0);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(1500, "beach"); });
            SettingsToggle(PlayerPrefs.GetInt("map", 0));
        }
    }
    public void SetMapCity()
    {
        if (PlayerPrefs.GetString("cityPaid", "no") == "yes")
        {
            PlayerPrefs.SetInt("map", 2);
            SettingsToggle(PlayerPrefs.GetInt("map", 0));
        }
        else
        {
            BuyingPanel(2500);
            Indexer(1);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(2500, "city"); });
            SettingsToggle(PlayerPrefs.GetInt("map", 0));
        }

    }

    public void SettingsToggle(int value)
    {
        if (value == 0)
        {
            mapSelection.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().color = new Color32(53, 66, 99, 255);
            mapSelection.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);

            mapSelection.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            mapSelection.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(53, 66, 99, 255);

            mapSelection.transform.GetChild(1).GetChild(2).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            mapSelection.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(53, 66, 99, 255);
        }

        if (value == 1)
        {
            mapSelection.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            mapSelection.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(53, 66, 99, 255);

            mapSelection.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Image>().color = new Color32(53, 66, 99, 255);
            mapSelection.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);

            mapSelection.transform.GetChild(1).GetChild(2).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            mapSelection.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(53, 66, 99, 255);
        }

        if (value == 2)
        {
            mapSelection.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            mapSelection.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(53, 66, 99, 255);

            mapSelection.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            mapSelection.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(53, 66, 99, 255);

            mapSelection.transform.GetChild(1).GetChild(2).gameObject.GetComponent<Image>().color = new Color32(53, 66, 99, 255);
            mapSelection.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void CloseBuyPanel()
    {
        buyPanel.SetActive(false);
        buyButton.onClick.RemoveAllListeners();
    }

    public void CloseNoMoneyPanel()
    {
        noMoneyPanel.SetActive(false);
    }

    public void BuyingPanel(int money)
    {
        buyPanel.SetActive(true);
        priceTextBuyingPanel.text = money.ToString();
    }

    public void BuyingOnClick(int _price, string _map)
    {
        if (PlayerPrefs.GetInt("stars", 0) >= _price)
        {
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) - _price);
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
            if (_map == "lagos")
            {
                UnlockMap("lagos");
            }

            if (_map == "beach")
            {
                UnlockMap("beach");
            }

            if (_map == "city")
            {
                UnlockMap("city");
            }
        }
        else
        {
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
            noMoneyPanel.SetActive(true);
        }
    }

    public void UnlockMap(string _map)
    {
        PlayerPrefs.SetString(_map + "Paid", "yes");
    }

    public void Indexer(int _index)
    {
        articleImageSprite.sprite = articleSprites[_index];
    }
}