using System.Collections;
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

    private List<Transform> nodes;
    private int curNode = 0;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTranforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

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
        ApplySteer();
        Drive();
        CheckWPDistance();
    }

    private void ApplySteer()
    {
        Vector3 relVector = transform.InverseTransformPoint(nodes[curNode].position);
        relVector = relVector / relVector.magnitude;
        float nSteer = (relVector.x / relVector.magnitude)*maxSteerAngle;
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
            wheelRL.motorTorque = 100f;
            wheelRR.motorTorque = 100f;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
    }

    private void CheckWPDistance()
    {
        //print(Vector3.Distance(transform.position, nodes[curNode].position) < 0.05f);
        if(Vector3.Distance(transform.position, nodes[curNode].position) < 0.9f)
        {
            //print("Current node = " + curNode);
            if(curNode == nodes.Count - 1)
            { 
                curNode = 0;
            }
            else
            { 
                curNode++;
            }

            curSpeed -= 10;
        }
        //if (Vector3.Distance(transform.position, nodes[curNode].position) < 1.5f)
       // {
       //     curSpeed -= 10;
       }
}
