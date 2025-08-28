using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public static CardsManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }
    public void AddCards(int _numb, string _item)
    {
        PlayerPrefs.SetInt(_item + "Cards", PlayerPrefs.GetInt(_item + "Cards", 0) + _numb);
    }
}
