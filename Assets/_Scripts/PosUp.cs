using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosUp : MonoBehaviour
{
    public TextMeshProUGUI positionText;
    public GameObject myCar;

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CarPos")
        {
            positionText.SetText("1st");
        }
    }
}
