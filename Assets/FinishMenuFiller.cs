using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FinishMenuFiller : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI placeIndicator;
    [SerializeField] public TextMeshProUGUI firstLapTime;
    [SerializeField] public TextMeshProUGUI secondLapTime;
    [SerializeField] public TextMeshProUGUI thirdLapTime;
    [SerializeField] public TextMeshProUGUI bestLapTime;

    [SerializeField] public TextMeshProUGUI Rank;

    public void SetPlaceIndicator()
    {
        placeIndicator.SetText(Rank.text);
    }

    public void SetFirstLapTime(float time)
    {
        int mins = (int)(time / 60);
        int secs = (int)(time % 60);
        int mili = (int)((int)time % time);
        string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, mili);
        firstLapTime.SetText(formattedTime);
    }

    public void SetSecondLapTime(float time)
    {
        int mins = (int)(time / 60);
        int secs = (int)(time % 60);
        int mili = (int)((int)time % time);
        string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, mili);
        secondLapTime.SetText(formattedTime);
    }

    public void SetThirdLapTime(float time)
    {
        int mins = (int)(time / 60);
        int secs = (int)(time % 60);
        int mili = (int)((int)time % time);
        string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, mili);
        thirdLapTime.SetText(formattedTime);
    }

    public void SetBestTime(float time1, float time2, float time3)
    {
        if(time1 < time2 && time1 < time3)
        {
            int mins = (int)(time1 / 60);
            int secs = (int)(time1 % 60);
            int mili = (int)((int)time1 % time1);
            string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, mili);
            bestLapTime.text = "" + formattedTime;
        }
        else if(time2 < time1 && time2 < time3)
        {
            int mins = (int)(time2 / 60);
            int secs = (int)(time2 % 60);
            int mili = (int)((int)time2 % time2);
            string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, mili);
            bestLapTime.text = "" + formattedTime;
        }
        else
        {
            int mins = (int)(time3 / 60);
            int secs = (int)(time3 % 60);
            int mili = (int)((int)time3 % time3);
            string formattedTime = string.Format("{0:00}:{1:00}.{2:00}", mins, secs, mili);
            bestLapTime.text = "" + formattedTime;
        }
    }
}
