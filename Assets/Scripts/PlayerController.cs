using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    [SerializeField] float rpm;
    [SerializeField] float turnSpeed = 30f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] float horsePower;
    [SerializeField] TextMeshProUGUI speedometer;
    [SerializeField] TextMeshProUGUI rpmMeter;
    [SerializeField] List<WheelCollider> wheels;
    private int wheelsOnRoad;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //get Input for movements
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //we'll move the vehicle forward
        //transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        if (IsOnRoad())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //rotate the vehicle
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
        speedometer.SetText("Speed : " + speed + " km/h");

        rpm = (speed % 60) * 100;
        rpmMeter.SetText("Rpm : " + rpm);
        }

        Debug.Log("wheelsOnRaod : " + wheelsOnRoad);
    }

    bool IsOnRoad()
    {
        wheelsOnRoad = 0;
        foreach (WheelCollider wheel in wheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnRoad++;
            }
        }

        if (wheelsOnRoad > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
