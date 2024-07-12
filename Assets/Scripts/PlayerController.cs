using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed = 30f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    private Rigidbody playerRb;
    [SerializeField] TextMeshProUGUI speedometer;

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
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        //rotate the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        speed = playerRb.velocity.magnitude * 3.6f;
        speedometer.SetText("Speed : " + speed + " km/h");

        //ADD FORCE 
        // ROUND KM/H
    }
}
