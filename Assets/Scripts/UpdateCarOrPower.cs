using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCarOrPower : MonoBehaviour
{
    public GameObject updatePanel, noCardsPanel, noMoneyPanel;
    public Slider updateSlider;
    public Image updateImage;
    Sprite updateSprite;
    public TextMeshProUGUI updatePrice, cardsText, levelText;
    public Button updateButton;

    public static UpdateCarOrPower instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }
    public void OpeningUpdatePanel(Slider _slider, int _price, int _index)
    {
        updatePanel.SetActive(true);
        updateSlider.maxValue = _slider.maxValue;
        updateSlider.value = _slider.value;
        updateSprite = UIScript.instance.itemSprites[_index];
        updateImage.sprite = updateSprite;
        cardsText.text = PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Cards", 0).ToString() + "/" + (PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Level", 1) * 10).ToString();
        levelText.text = "Niveau " + PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Level", 1).ToString();
        updatePrice.text = _price.ToString();
        updateButton.onClick.RemoveAllListeners();
        updateButton.onClick.AddListener(
            delegate 
            {
                OnClickUpdate(_index, _price); 
            }
        );
    }

    public void OnClickUpdate(int _index, int _price)
    {
        if (PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Cards", 0) >= PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Level", 1) * 10)
        {
            if(UIScript.instance.stars >= _price)
            {
                PlayerPrefs.SetInt(UIScript.instance.itemStrings[_index] + "Cards", PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Cards", 0) - (PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Level", 1) * 10));

                PlayerPrefs.SetInt(UIScript.instance.itemStrings[_index] + "Level", PlayerPrefs.GetInt(UIScript.instance.itemStrings[_index] + "Level", 1) + 1);

                UnlockCarAnimation.instance.AnimUpdate(UIScript.instance.itemStrings[_index]);
            }
            else
            {
                noMoneyPanel.SetActive(true);
            }
        }
        else
        {
            noCardsPanel.SetActive(true);
        }

        CloseUpdatePanel();
    }

    public void CloseUpdatePanel()
    {
        updatePanel.SetActive(false);
    }

    public void CloseNoCardsPanel()
    {
        noCardsPanel.SetActive(false);
    }
}
