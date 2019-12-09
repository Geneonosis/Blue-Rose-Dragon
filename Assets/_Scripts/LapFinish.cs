using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LapFinish : MonoBehaviour
{
    public int lapCount = 1;

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;

    public GameObject MilliDisplay;

    public GameObject LapTimeBox;

    public TextMeshProUGUI LapNumberDisplay = null;
    public GameObject finishInformation;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lapCount++;
            LapNumberDisplay.text = "" + lapCount;
            if(lapCount > 3)
            {
                //TODO: pause the game and show finish information
                finishInformation.SetActive(true);
                Time.timeScale = 0;
            }
            
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

