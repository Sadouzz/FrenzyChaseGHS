using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoScript : MonoBehaviour
{
    public GameObject first, second, playButtonSecond, pointerPlayButtonSecond, third, starsThird, pointerThird, fourth, pointerFourth1, pointerFourth2, instructionsPanel;
    public TextMeshProUGUI stars;
    public TMP_InputField pseudoInputField;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("tutorial", "no") == "nextThird")
        {
            SetThird();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("tutorial", "no") == "no")
        {
            SetTutorial();
        }

        if (PlayerPrefs.GetString("tutorial", "no") == "fourth")
        {
            NextThird();
        }

        if (PlayerPrefs.GetString("tutorial", "no") == "done")
        {
            instructionsPanel.SetActive(false);
        }
        stars.text = PlayerPrefs.GetInt("stars", 0).ToString();
    }
    
    public void SetTutorial()
    {
        first.SetActive(true);
    }

    public void NextFirst()
    {
        first.SetActive(false);
        second.SetActive(true);
        playButtonSecond.SetActive(true);
        pointerPlayButtonSecond.SetActive(true);
        PlayerPrefs.SetString("pseudo", pseudoInputField.text);
        PlayerPrefs.SetString("tutorial", "first");
    }

    public void Play()
    {
        PlayerPrefs.SetString("tutorial", "third");
    }

    public void SetThird()
    {
        third.SetActive(true);
        starsThird.SetActive(true);
        pointerThird.SetActive(true);
    }

    public void NextThird()
    {
        PlayerPrefs.SetString("tutorial", "fourth");
        third.SetActive(false);
        starsThird.SetActive(false);
        pointerThird.SetActive(false);
        fourth.SetActive(true);
        pointerFourth1.SetActive(true);
        pointerFourth2.SetActive(true);
    }

    public void NextFourth()
    {
        PlayerPrefs.SetString("tutorial", "done");
        fourth.SetActive(false );
        pointerFourth1.SetActive(false);
        pointerFourth2.SetActive(false);
        instructionsPanel.SetActive(false);
    }
}
