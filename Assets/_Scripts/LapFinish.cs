using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LapFinish : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;

    public GameObject MilliDisplay;

    public GameObject LapTimeBox;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LapTimeManage.SecondCounter <= 9)
            {
                SecondDisplay.GetComponent<TextMeshProUGUI>().text = "0" + LapTimeManage.SecondCounter + ".";
            }
            else
            {
                SecondDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManage.SecondCounter + ".";
            }

            if (LapTimeManage.MinuteCounter <= 9)
            {
                MinuteDisplay.GetComponent<TextMeshProUGUI>().text = "0" + LapTimeManage.MinuteCounter + ".";
            }
            else
            {
                MinuteDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManage.MinuteCounter + ".";
            }

            MilliDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManage.MilliCounter;

            LapTimeManage.MinuteCounter = 0;
            LapTimeManage.SecondCounter = 0;
            LapTimeManage.MilliCounter = 0;

            HalfLapTrig.SetActive(true);
            LapCompleteTrig.SetActive(false);
        }
    }
}

