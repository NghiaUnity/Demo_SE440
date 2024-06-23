using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : NetworkBehaviour
{
    public enum WheelType
    {
        //phia truoc
        Front,
        //phia sau
        Rear
    }
    //cho phep thay doi
    [System.Serializable]
    //nhu class 
    public struct Wheel
    {
        public WheelType type;
        public WheelCollider collider;
        public Transform transform;
    }
    //giam sat 4 banh xe 
    [SerializeField]
    private List<Wheel> wheels =new List<Wheel>();

    [SerializeField] private float speed = 50f;
    [SerializeField] private float steerSpeed = 30f;
    [SerializeField] private float maxSteerAngle = 30f;
    //- de phan biet
    private float _moveInput;
    private float _steerInput;
   
 
    //tao gia tri ban dau
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        if (!isLocalPlayer) return;

        _moveInput = Input.GetAxis("Vertical");
        _steerInput = Input.GetAxis("Horizontal");
        WheelAnimation();
        BrakeControl();
    }
    private void BrakeControl()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 1000;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.collider.brakeTorque = 0;
            }
        }
    }
    private void WheelAnimation()
    {
        foreach (Wheel wheel in wheels)
        {
            Vector3 pos;
            Quaternion rot;
            wheel.collider.GetWorldPose(out pos, out rot);
            wheel.transform.position = pos;
            wheel.transform.rotation = rot;
        }
    }
    private void LateUpdate()
    {
        if (!isLocalPlayer) return;
        Move();
        Steer();
    }
    private void Move()
    {
        foreach ( var wheel in wheels )
        {
            wheel.collider.motorTorque = _moveInput * speed;
        }
    }
    private void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.type == WheelType.Front) // Chỉ rẽ bánh xe phía trước
            {

                wheel.collider.steerAngle = _steerInput * steerSpeed;// Điều chỉnh góc rẽ sau 0.5 thi goc moi se tinh lai
            }
        }
    }
}