using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScript : MonoBehaviour
{
    public GameObject notifPanel;
    public TextMeshProUGUI text, title;
    public Image reward;

    public static NotificationScript instance;
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

    public void CallNotif(string _text, Sprite _image)
    {
        text.text = _text;
        reward.sprite = _image;
        StartCoroutine(DisableObject());
    }

    public void ChangeTitle(string _text)
    {
        title.text = _text;
    }

    IEnumerator DisableObject()
    {
        notifPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(2);
        title.text = "RECOMPENSE RECUPEREE";
        notifPanel.SetActive(false);
    }
}
