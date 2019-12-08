using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceCalculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerPosition;
    [SerializeField] List<Vector3> checkpoints = null;
    [SerializeField] GameObject[] racers;
    GameObject minDistanceRacer = null;

    //todo find a way to make this an array?
    [SerializeField] float distance1 = 9999999;
    [SerializeField] float distance2 = 9999999;
    [SerializeField] float distance3 = 9999999;
    [SerializeField] float distance4 = 9999999;

    float minDistance = 9999999;

    Vector3 [] checkpointsArray = null;

    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("PlayerPosition").GetComponent<TextMeshProUGUI>(); //probably unnecessary but meh
        foreach(Transform checkpoint in transform)
        {
            checkpoints.Add(checkpoint.position);
        }
        checkpointsArray = checkpoints.ToArray();
    }

    private void FixedUpdate()
    {

        //this for loop controls what node each racer is headed twoard
        foreach(GameObject racer in racers)
        {
            PlacePosition pp = racer.GetComponent<PlacePosition>();
            pp._destinationLocation = checkpointsArray[pp.indexOfPositionHeadedToward];

            if(pp.GetDistance() < 10 && pp.updatedOnce == false)
            {
                pp.updatedOnce = true;
                Debug.Log("updating index...");
                pp.indexOfPositionHeadedToward++;
                if(pp.indexOfPositionHeadedToward > checkpointsArray.Length-1)
                {
                    pp.indexOfPositionHeadedToward = 0;
                }
                StartCoroutine(pp.updateController());
            }


            //need some sort of min / max distant checker that will compare across each racer


            if (minDistance > pp.GetDistance())
            {
                minDistance = pp.GetDistance();
                GameObject minDistanceRacer = pp.gameObject;
            }


        }


    }

    public void UpdatePlayerPosition(int position)
    {
        string str = "";
        str += position;
        PlayerPosition.SetText(str);
    }
}
