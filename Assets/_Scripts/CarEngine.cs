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

        Drive();
        ApplySteer();
        CheckWPDistance();
    }

    private void ApplySteer()
    {
        Vector3 relVector = transform.InverseTransformPoint(nodes[curNode].position);
        relVector = relVector / relVector.magnitude;
        float nSteer = (relVector.x / relVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = nSteer;
        wheelFR.steerAngle = nSteer;
        if (Vector3.Distance(nodes[curNode + 1].position, nodes[curNode].position) < 10f)
        {
            print("Current node = " + curNode + " is near to another node");
        }
        else
        {
            print("Current node = " + curNode + " is FARRRRRRR from another node");
        }
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

            curSpeed -= 10;
        }
        //if (Vector3.Distance(transform.position, nodes[curNode].position) < 1.5f)
        // {
        //     curSpeed -= 10;
    }
}



/* SLOW DOWN
 * 1. keep track of distance between nodes
 * 2. keep track of distance between car and next node
 * 3. normalize distance between nodes
 * 4. calculate 1-(3/4 * normalized distance)
 * 5. check car dostance to sec is <= item #4
 * 6. if #5 true then slow down but dont go to 0 speed
 * 7. if hit new point then recalculate
 */