﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveScript : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private float _steerAngle;
    private bool _enabler;

    public WheelCollider FL_Wheel, FR_Wheel;
    public WheelCollider RL_Wheel, RR_Wheel;
    //public Transform FL_WheelT, FR_WheelT;
    //public Transform RL_WheelT, RR_WheelT;
    public float maxSteerAngle = 30;
    public float motorForce = 100;
    public float currentSpeed;

    public void Start()
    {
        _enabler = false;
        StartCoroutine(Enabler());
    }

    IEnumerator Enabler()
    {
        yield return new WaitForSeconds(3f);
        _enabler = true;
    }

    public void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

    }

    public void Steer()
    {
        _steerAngle = maxSteerAngle * _horizontalInput;
        FL_Wheel.steerAngle = _steerAngle;
        FR_Wheel.steerAngle = _steerAngle;
    }

    public void Accelerate()
    {
        if(Input.GetKey("down")){
            motorForce = motorForce * 5;
        }
        FL_Wheel.motorTorque = _verticalInput * motorForce;
        FR_Wheel.motorTorque = _verticalInput * motorForce;
        RR_Wheel.motorTorque = _verticalInput * motorForce;
        RL_Wheel.motorTorque = _verticalInput * motorForce;
        currentSpeed = FL_Wheel.rpm * FL_Wheel.radius * Mathf.PI * 60 / 1000;
    }
    /*
    public void UpdateWheelPoses()
    {
        UpdateWheelPose(FR_Wheel, FR_WheelT);
        UpdateWheelPose(FL_Wheel, FL_WheelT);
        UpdateWheelPose(RR_Wheel, RR_WheelT);
        UpdateWheelPose(RL_Wheel, RL_WheelT);
    }

    private void UpdateWheelPose(WheelCollider _Collider, Transform  _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _Collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;

    }
   */ 
    private void Update()
    {
        if (_enabler == true)
        {
            GetInput();
            Steer();
            Accelerate();
        }
        //UpdateWheelPoses();
    }
}


