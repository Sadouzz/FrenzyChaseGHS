using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockCarAnimation : MonoBehaviour
{
    public TextMeshProUGUI carText, carLevelText;
    public GameObject unlockCarPanel;
    public static UnlockCarAnimation instance;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Anim(string car)
    {
        unlockCarPanel.SetActive(true);
        PackOpening.instance.mainCamera.SetActive(false);
        PackOpening.instance.virtualCam.SetActive(true);
        PackOpening.instance.virtualCameraBrain.SetActive(true);
        PackOpening.instance.canvas.SetActive(false);
        PackOpening.instance.canvasWorld.SetActive(false);
        PackOpening.instance.decor.SetActive(false);
        PackOpening.instance.carsOnMenu.SetActive(false);
        carLevelText.gameObject.SetActive(false);
        carText.gameObject.SetActive(true);
        carText.text = car + " DEBLOQUE !";
        UIScript.instance.carsUnlocking.SetActive(true );
        UIScript.instance.carsUnlocking.GetComponent<CarOnClaimPack>().Drift();
        UIScript.instance.carsUnlocking.transform.Find(car).gameObject.SetActive(true);
        PackOpening.instance.canvasPack.SetActive(true);
    }

    public void AnimUpdate(string car)
    {
        unlockCarPanel.SetActive(true);
        PackOpening.instance.mainCamera.SetActive(false);
        PackOpening.instance.virtualCam.SetActive(true);
        PackOpening.instance.virtualCameraBrain.SetActive(true);
        PackOpening.instance.canvas.SetActive(false);
        PackOpening.instance.canvasWorld.SetActive(false);
        PackOpening.instance.decor.SetActive(false);
        PackOpening.instance.carsOnMenu.SetActive(false);
        carText.gameObject.SetActive(true);
        carLevelText.gameObject.SetActive(true);
        carLevelText.text = "Niveau " + PlayerPrefs.GetInt(car + "Level", 2).ToString();
        carText.text = car + " AMELIORE !";
        UIScript.instance.carsUnlocking.SetActive(true);
        UIScript.instance.carsUnlocking.GetComponent<CarOnClaimPack>().Drift();
        UIScript.instance.carsUnlocking.transform.Find(car).gameObject.SetActive(true);
        PackOpening.instance.canvasPack.SetActive(true);
    }

    public void CloseAnim()
    {
        unlockCarPanel.SetActive(false);
        PackOpening.instance.mainCamera.SetActive(true);
        PackOpening .instance.virtualCam.SetActive(false);
        PackOpening.instance.virtualCameraBrain.SetActive(false);
        PackOpening.instance.canvas.SetActive(true);
        PackOpening.instance.canvasWorld.SetActive(true);
        PackOpening.instance.decor.SetActive(true);
        PackOpening.instance.carsOnMenu.SetActive(true);
        UIScript.instance.carsUnlocking.SetActive(false);
        foreach (Transform child in UIScript.instance.carsUnlocking.transform)
        {
            // Désactive le GameObject de l'enfant
            child.gameObject.SetActive(false);
        }
        carText.gameObject.SetActive(false);
        UpdateCarOrPower.instance.updatePanel.SetActive(false);
    }
}
