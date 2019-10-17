using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapTimeManage : MonoBehaviour
{
    public static int MinuteCounter;
    public static int SecondCounter;
    public static float MilliCounter;
    public static string MilliDisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;



    // Update is called once per frame
    void Update()
    {
        MilliCounter += (Time.deltaTime * 10);
        MilliDisplay = MilliCounter.ToString("F0");
        MilliBox.GetComponent<TextMeshProUGUI>().text = "" + MilliDisplay;

        if (MilliCounter >= 10)
        {
            MilliCounter = 0;
            SecondCounter += 1;
        }

        if (SecondCounter <= 9)
        {
            SecondBox.GetComponent<TextMeshProUGUI>().text = "0" + SecondCounter + ".";
        }
        else
        {
            SecondBox.GetComponent<TextMeshProUGUI>().text = "" + SecondCounter + ".";
        }

        if (SecondCounter >= 60)
        {
            SecondCounter = 0;
            MinuteCounter += 1;
        }

        if (MinuteCounter <= 9)
        {
            MinuteBox.GetComponent<TextMeshProUGUI>().text = "0" + MinuteCounter + ":";
        }
        else
        {
            MinuteBox.GetComponent<TextMeshProUGUI>().text = "" + MinuteCounter + ":";
        }

    }
}
