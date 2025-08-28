using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsOnClaimReward : MonoBehaviour
{
    public TextMeshProUGUI stats1, stats1Value, stats2, stats2Value;
    public Slider slider1, slider2;

    public static StatsOnClaimReward instance;
    private void Awake()
    {
        if (instance != null)
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

    public void StatsDisplay(bool isCar, bool turret, string _obtained)
    {
        if (isCar)
        {
            stats1.text = "Vitesse:";
            stats1Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider1.value = PlayerPrefs.GetInt(_obtained + "Level", 1);

            stats2.text = "Drift:";
            stats2Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider2.value = PlayerPrefs.GetInt(_obtained + "Level", 1);
        }

        if (turret)
        {
            stats1.text = "Cibles:";
            stats1Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider1.value = PlayerPrefs.GetInt(_obtained + "Level", 1);

            stats2.text = "Precision:";
            stats2Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider2.value = PlayerPrefs.GetInt(_obtained + "Level", 1);
        }

        if (_obtained == "Cercle de feu")
        {
            stats1.text = "Duree:";
            stats1Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider1.value = PlayerPrefs.GetInt(_obtained + "Level", 1);

            stats2.text = "Rayon:";
            stats2Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider2.value = PlayerPrefs.GetInt(_obtained + "Level", 1);
        }

        if (_obtained == "Scies")
        {
            stats1.text = "Scies:";
            stats1Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider1.value = PlayerPrefs.GetInt(_obtained + "Level", 1);

            stats2.text = "Rayon:";
            stats2Value.text = PlayerPrefs.GetInt(_obtained + "Level", 1).ToString();
            slider2.value = PlayerPrefs.GetInt(_obtained + "Level", 1);
        }
    }
}
