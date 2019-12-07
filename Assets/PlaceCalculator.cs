using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceCalculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerPosition;

    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("PlayerPosition").GetComponent<TextMeshProUGUI>(); //probably unnecessary but meh
    }

    
}
