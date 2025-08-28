using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AllTimerScript : MonoBehaviour
{
    private bool inProgress;
    private DateTime TimerStart;
    private DateTime TimerEnd;

    public TextMeshProUGUI timeLeftText;
    public Button skipButton;
    public Button startButton;

    public GameObject timeLeftObj;
    public Slider timeLeftSlider;

    public int Days, Hours, Minutes, Seconds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartTimer()
    {
        TimerStart = DateTime.Now;
        TimeSpan time = new TimeSpan(Days, Hours, Minutes, Seconds);
        TimerEnd = TimerStart.Add(time);
        inProgress = true;

        StartCoroutine(Timer());
        StartCoroutine(DisplayTime());
    }

    private IEnumerator DisplayTime()
    {
        DateTime start = DateTime.Now;
        TimeSpan timeLeft = TimerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (TimerEnd - TimerStart).TotalSeconds;
        string text;

        while(startButton.gameObject.activeSelf && timeLeftObj.activeSelf)
        {
            text = "";
            timeLeftSlider.value = 1 - Convert.ToSingle((TimerEnd - DateTime.Now).TotalSeconds / totalSeconds);
            if(totalSecondsLeft > 1)
            {
                if (timeLeft.Days != 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Days + "j ";
                    text += ts.Hours + "h ";
                }
                else if (timeLeft.Hours != 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Hours + "h ";
                    text += ts.Minutes + "m ";
                }
                else if (timeLeft.Minutes != 0)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Minutes + "m ";
                    text += ts.Seconds + "s ";
                }
                else
                {
                    text += Mathf.FloorToInt((float)totalSecondsLeft) + "s";
                }
                
                timeLeftText.text = text;

                totalSecondsLeft -= Time.deltaTime;
                yield return null;
            }
            else
            {
                timeLeftText.text = "Finished";
                skipButton.gameObject.SetActive(false);
                inProgress = false;
                break;
            }
        }

        yield return null;
    }

    private IEnumerator Timer()
    {
        DateTime start = DateTime.Now;
        double secondsToFinished = (TimerEnd - start).TotalSeconds;
        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));
        Debug.Log("fine");
    }

    public void Skip()
    {
        StopCoroutine(DisplayTime());
        StopCoroutine(Timer());
        TimerEnd = DateTime.Now;
        inProgress = false;
        
        timeLeftText.text = "Finished";
        timeLeftSlider.value = 1;

    }
}
