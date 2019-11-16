using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LapFinish : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;

    public GameObject MilliDisplay;

    public GameObject LapTimeBox;

    void OnTriggerEnter()
    {
        if (LapTimeManage.SecondCounter <= 9)
        {
            SecondDisplay.GetComponent<Text>().text = "0" +LapTimeManage.SecondCounter + ".";
        }
        else
        {
            SecondDisplay.GetComponent<Text>().text = "" + LapTimeManage.SecondCounter + ".";
        }

        if (LapTimeManage.MinuteCounter <= 9)
        {
            MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManage.MinuteCounter + ".";
        }
        else
        {
            MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManage.MinuteCounter + ".";
        }

        MilliDisplay.GetComponent<Text>().text = "" + LapTimeManage.MilliCounter;

        LapTimeManage.MinuteCounter = 0;
        LapTimeManage.SecondCounter = 0;
        LapTimeManage.MilliCounter = 0;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

