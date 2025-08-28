using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackOpening : MonoBehaviour
{
    public Button packOpeningButton;
    public GameObject canvas, canvasWorld, canvasPack, decor, carsOnMenu , carsRewardPack, mainCamera, virtualCam, virtualCameraBrain;

    public static PackOpening instance;
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

    public void Opening()
    {
        mainCamera.SetActive(false);
        virtualCam.SetActive(true);
        virtualCameraBrain.SetActive(true);
        canvas.SetActive(false);
        canvasWorld.SetActive(false);
        decor.SetActive(false);
        carsOnMenu.SetActive(false);
        canvasPack.SetActive(true);
    }
    public void Closing()
    {
        Debug.Log("Play");
        UIScript.instance.pack.SetBool("openAndPlayAnims", false);
        mainCamera.SetActive(true);
        virtualCam.SetActive(false);
        virtualCameraBrain.SetActive(false);
        canvas.SetActive(true);
        canvasWorld.SetActive(true);
        decor.SetActive(true);
        carsOnMenu.SetActive(true);
        foreach (Transform child in carsRewardPack.transform)
        {
            // Désactive le GameObject de l'enfant
            child.gameObject.SetActive(false);
        }
        canvasPack.SetActive(false);
        //packOpeningButton.onClick.AddListener(delegate { UIScript.instance.OpenRewardOnPack(); });
    }
}
