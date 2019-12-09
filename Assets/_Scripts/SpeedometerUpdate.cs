using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedometerUpdate : MonoBehaviour
{
    public GameObject vehicle;
    public DriveScript driveScript;
    public TextMeshProUGUI text;




    // Start is called before the first frame update
    void Start()
    {
        driveScript = vehicle.GetComponent<DriveScript>();

    }

    // Update is called once per frame
    void Update()
    {

        text.SetText(driveScript.currentSpeed.ToString() + " MPH");
    }
}
