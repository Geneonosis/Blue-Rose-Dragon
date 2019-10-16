using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 45;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    //public maxMotorTorque = 

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
        //relVector = relVector / relVector.magnitude;
        float nSteer = (relVector.x / relVector.magnitude)*maxSteerAngle;
        wheelFL.steerAngle = nSteer;
        wheelFR.steerAngle = nSteer;
    }

    private void Drive()
    {
        wheelFL.motorTorque = 100f;
        wheelFR.motorTorque = 100f;
    }

    private void CheckWPDistance()
    {
        if(Vector3.Distance(transform.position, nodes[curNode].position) < 0.5f)
        {
            if(curNode == nodes.Count - 1)
            {
                curNode = 0;
            }
            else
            {
                curNode++;
            }
        }
    }
}
