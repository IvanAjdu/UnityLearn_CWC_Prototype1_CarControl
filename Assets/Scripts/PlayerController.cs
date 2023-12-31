using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 15.0f;
    [SerializeField] float turnSpeed = 30f;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get Input for movements
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //we'll move the vehicle forward
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        //rotate the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
