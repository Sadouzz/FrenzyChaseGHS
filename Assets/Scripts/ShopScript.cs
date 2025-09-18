using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopScript : MonoBehaviour
{
    public Image articleImageSprite;
    public Sprite[] articleSprites;
    public GameObject buyPanel, noMoneyPanel;
    public Button buyButton;
    public TextMeshProUGUI priceTextBuyingPanel;
    bool buy;
    string recupString;
    int cardsToAdd;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void PurchaseWithCoins(int _price)
    {
        BuyingPanel(_price);
        buyButton.onClick.AddListener(delegate { BuyingOnClick(_price); });
        if (PlayerPrefs.GetInt("stars", 0) >= _price)
        {
            buyButton.onClick.AddListener(delegate { UIScript.instance.ClaimRewardOnPack(recupString); });
        }
    }

    public void PurchasePowerUp(int _price)
    {
        BuyingPanel(_price);
        buyButton.onClick.AddListener(delegate { BuyingOnClick(_price); });
        if (PlayerPrefs.GetInt("stars", 0) >= _price)
        {
            buyButton.onClick.AddListener(delegate { 
                CardsManager.instance.AddCards(cardsToAdd, recupString); 
                NotificationScript.instance.CallNotif("VOUS RECEVEZ x" + cardsToAdd.ToString(), articleImageSprite.sprite);
                NotificationScript.instance.ChangeTitle("Achat reussi");
            });
            
        }
    }

    public void Indexer(int _index)
    {
        articleImageSprite.sprite = articleSprites[_index];
    }

    public void Texter(string text)
    {
        recupString = text;
    }

    public void Inter(int intt)
    {
        cardsToAdd = intt;
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

    public void BuyingOnClick(int _price)
    {
        if (PlayerPrefs.GetInt("stars", 0) >= _price)
        {
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars", 0) - _price);
            //buyButton.onClick.AddListener(delegate { UIScript.instance.ClaimRewardOnPack(text); });
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
        }
        else
        {
            CloseBuyPanel();
            buyButton.onClick.RemoveAllListeners();
            noMoneyPanel.SetActive(true);
        }
    }
}
