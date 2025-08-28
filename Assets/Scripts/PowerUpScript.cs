using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{
    public GameObject buyPanel;
    public Button buyButton;
    public Image panelCarSpriteImage;
    public Sprite turrelSprite, fireSprite, destaSprite, sawSprite, mineSprite;
    public TextMeshProUGUI starsOwnedText, priceTextBuyingPanel, turrelCardsText, fireCircleCardsText, destabilisatorCardsText, sawCardsText, minesCardsText;

    public void TurrelClick()
    {
        if(PlayerPrefs.GetInt("TourelleCards", 0) > 1)
        {
            InventoryScript.instance.Turret();
            PlayerPrefs.SetInt("TourelleCards", PlayerPrefs.GetInt("TourelleCards", 0) - 1);
        }
        else
        {
            BuyingPanel(150, turrelSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(150, "Tourelle"); });
        }
    }

    public void FireCircleClick()
    {
        if (PlayerPrefs.GetInt("Cercle de feuCards", 0) > 1)
        {
            InventoryScript.instance.Fire();
            PlayerPrefs.SetInt("Cercle de feuCards", PlayerPrefs.GetInt("Cercle de feuCards", 0) - 1);
        }
        else
        {
            BuyingPanel(175, fireSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(175, "Cercle de feu"); });
        }
    }

    public void DestabilisateurClick()
    {
        if (PlayerPrefs.GetInt("DéstabilisateurCards", 0) > 1)
        {
            InventoryScript.instance.Destabilizer();
            PlayerPrefs.SetInt("DéstabilisateurCards", PlayerPrefs.GetInt("DéstabilisateurCards", 0) - 1);
        }
        else
        {
            BuyingPanel(200, destaSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(200, "Déstabilisateur"); });
        }
    }

    public void SawClick()
    {
        if (PlayerPrefs.GetInt("SciesCards", 0) > 1)
        {
            InventoryScript.instance.Saw();
            PlayerPrefs.SetInt("SciesCards", PlayerPrefs.GetInt("SciesCards", 0) - 1);
        }
        else
        {
            BuyingPanel(200, sawSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(200, "Scies"); });
        }
    }

    public void MinesClick()
    {
        if (PlayerPrefs.GetInt("MinesCards", 0) > 1)
        {
            InventoryScript.instance.Mines();
            PlayerPrefs.SetInt("MinesCards", PlayerPrefs.GetInt("MinesCards", 0) - 1);
        }
        else
        {
            BuyingPanel(225, mineSprite);
            buyButton.onClick.AddListener(delegate { BuyingOnClick(225, "Mines"); });
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        RefreshText();
    }

    public void RefreshText()
    {
        turrelCardsText.text = PlayerPrefs.GetInt("TourelleCards", 0) > 1 ? PlayerPrefs.GetInt("TourelleCards", 0).ToString() : "+";
        fireCircleCardsText.text = PlayerPrefs.GetInt("Cercle de feuCards", 0) > 1 ? PlayerPrefs.GetInt("Cercle de feuCards", 0).ToString() : "+";
        destabilisatorCardsText.text = PlayerPrefs.GetInt("DéstabilisateurCards", 0) > 1 ? PlayerPrefs.GetInt("DéstabilisateurCards", 0).ToString() : "+";
        sawCardsText.text = PlayerPrefs.GetInt("SciesCards", 0) > 1 ? PlayerPrefs.GetInt("SciesCards", 0).ToString() : "+";
        minesCardsText.text = PlayerPrefs.GetInt("MinesCards", 0) > 1 ? PlayerPrefs.GetInt("MinesCards", 0).ToString() : "+";
    }

    public void BuyingPanel(int money, Sprite carSprite)
    {
        Time.timeScale = 0;
        buyPanel.SetActive(true);
        starsOwnedText.text = PlayerPrefs.GetInt("stars", 0).ToString();
        priceTextBuyingPanel.text = money.ToString();
        panelCarSpriteImage.sprite = carSprite;
    }

    public void BuyingOnClick(int _price, string car)
    {
        if (PlayerPrefs.GetInt("stars", 0) >= _price)
        {
            CardsManager.instance.AddCards(1, car);
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) - _price);
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
        }
        else
        {
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
        }
    }

    public void CloseBuyPanel()
    {
        buyPanel.SetActive(false);
        buyButton.onClick.RemoveAllListeners();
        Time.timeScale = 1;
        RefreshText();
    }

}
