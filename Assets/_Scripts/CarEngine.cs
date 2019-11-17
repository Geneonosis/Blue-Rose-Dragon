﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 30;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public float maxMotorTorque = 80f;
    public float curSpeed;
    public float maxSpeed = 100f;
    private float distanceN_N;
    private float distanceC_N;
    private float slowDownSpot;

    private List<Transform> nodes;
    private int curNode = 0;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTranforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();//cant repeat this step

        for (int i = 0; i < pathTranforms.Length; i++)
        {
            if (pathTranforms[i] != path.transform)
            {
                nodes.Add(pathTranforms[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        Drive();
        ApplySteer();
        CheckWPDistance();
        SlowDown();
    }

    private void ApplySteer()
    {
        Vector3 relVector = transform.InverseTransformPoint(nodes[curNode].position);
        relVector = relVector / relVector.magnitude;
        float nSteer = (relVector.x / relVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = nSteer;
        wheelFR.steerAngle = nSteer;
    }

    private void Drive()
    {
        curSpeed = 2 * wheelFL.radius * wheelFL.rpm * Mathf.PI * 60 / 1000;
        if (curSpeed < maxSpeed)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
            wheelRL.motorTorque = 50f;
            wheelRR.motorTorque = 50f;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
            wheelRL.motorTorque = -10f;
            wheelRR.motorTorque = -10f;
        }
    }

    private void CheckWPDistance()
    {
        //print(Vector3.Distance(transform.position, nodes[curNode].position) < 0.05f);
        if (Vector3.Distance(transform.position, nodes[curNode].position) < 0.9f)
        {
            print("Current node = " + curNode);
            if (curNode == nodes.Count - 1)
            {
                curNode = 0;
            }
            else
            {
                curNode++;
            }

            //curSpeed -= 10;
        }
        //if (Vector3.Distance(transform.position, nodes[curNode].position) < 1.5f)
        // {
        //     curSpeed -= 10;
    }

    private void SlowDown()
    {
        if (curNode == 49)
        {
            distanceN_N = Vector3.Distance(nodes[curNode].position, nodes[0].position);
            distanceC_N = Vector3.Distance(transform.position, nodes[curNode].position);
            slowDownSpot = 1 - ((distanceN_N * .6f) / distanceN_N);
            if (distanceC_N <= slowDownSpot)
                curSpeed /= 2;
        }
        else
        {
            distanceN_N = Vector3.Distance(nodes[curNode].position, nodes[curNode + 1].position);
            distanceC_N = Vector3.Distance(transform.position, nodes[curNode].position);
            slowDownSpot = 1 - ((distanceN_N * .6f) / distanceN_N);
            if (distanceC_N <= slowDownSpot)
                curSpeed /= 2;
        }
    }


}



/* SLOW DOWN
 * 1. keep track of distance between nodes
 * 2. keep track of distance between car and next node
 * 3. normalize distance between nodes
 * 4. calculate 1-(3/4 * distance)
 * 5. check car dostance to sec is <= item #4
 * 6. if #5 true then slow down but dont go to 0 speed
 * 7. if hit new point then recalculate
 */