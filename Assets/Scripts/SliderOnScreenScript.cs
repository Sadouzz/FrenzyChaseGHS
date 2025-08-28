using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class SliderOnScreenScript : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI scoreMultiplierText, scoreMultiplierTextToGet;
    public static SliderOnScreenScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreMultiplierTextToGet.text = "x2";
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value >= slider.maxValue)
        {
            ResetSlider();
        }
    }

    public void AddValue()
    {
        slider.value += .7f;
    }

    public void ResetSlider()
    {
        slider.value = 0;
        slider.maxValue += 20;
        InventoryScript.instance.scoreMultiplier += 1;
        scoreMultiplierText.text = "x" + InventoryScript.instance.scoreMultiplier.ToString();
        scoreMultiplierTextToGet.text = "x" + (InventoryScript.instance.scoreMultiplier + 1).ToString();
        Debug.Log("Multiplier++");
    }
}
