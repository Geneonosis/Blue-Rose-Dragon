using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        MilliCounter += Time.deltaTime * 10;
        MilliDisplay = MilliCounter.ToString("F0");
        MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

        if (MilliCounter >= 10)
        {
            MilliCounter = 0;
            SecondCounter += 1;
        }

        if (SecondCounter <= 9)
        {
            SecondBox.GetComponent<Text>().text = "0" + SecondCounter + ".";
        }
        else
        {
            SecondBox.GetComponent<Text>().text = "" + SecondCounter + ".";
        }

        if (SecondCounter >= 60)
        {
            SecondCounter = 0;
            MinuteCounter += 1;
        }

        if (MinuteCounter <= 9)
        {
            MinuteBox.GetComponent<Text>().text = "0" + MinuteCounter + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text>().text = "" + MinuteCounter + ":";
        }

    }
}
