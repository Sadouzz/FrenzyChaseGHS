using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public int _value;
    public GameObject toggleGroupQuality;

    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private void Awake()
    {
        _value = PlayerPrefs.GetInt("GraphicsIndex", 2);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0);
        //audioMixer.SetFloat("Volume", volumeSlider.value);
        SetVolume(volumeSlider.value);
        SettingsToggle(_value);
        Refresh();
    }

    public void Refresh()
    {
        _value = PlayerPrefs.GetInt("GraphicsIndex", 2);
        QualitySettings.SetQualityLevel(_value);
    }

    public void LowQuality()
    {
        QualitySettings.SetQualityLevel(0);
        PlayerPrefs.SetInt("GraphicsIndex", 0);
        Refresh();
    }

    public void MediumQuality()
    {
        QualitySettings.SetQualityLevel(1);
        PlayerPrefs.SetInt("GraphicsIndex", 1);
        Refresh();
    }

    public void HighQuality()
    {
        QualitySettings.SetQualityLevel(2);
        PlayerPrefs.SetInt("GraphicsIndex", 2);
        Refresh();
    }

    public void UltraQuality()
    {
        QualitySettings.SetQualityLevel(3);
        PlayerPrefs.SetInt("GraphicsIndex", 3);
        Refresh();
    }

    public void SettingsToggle(int value)
    {
        if(value == 0)
        {
            toggleGroupQuality.transform.GetChild(0).gameObject.GetComponent<Toggle>().isOn = true;
        }

        if (value == 1)
        {
            toggleGroupQuality.transform.GetChild(1).gameObject.GetComponent<Toggle>().isOn = true;
        }

        if (value == 2)
        {
            toggleGroupQuality.transform.GetChild(2).gameObject.GetComponent<Toggle>().isOn = true;
        }

        if (value == 3)
        {
            toggleGroupQuality.transform.GetChild(3).gameObject.GetComponent<Toggle>().isOn = true;
        }
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("carsOwned", 1);
        ChoosingCarScript.instance.CarRapide();
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
