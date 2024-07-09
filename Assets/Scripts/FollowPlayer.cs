using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3 (0, 5, -8);


    // Update is called once per frame
    void LateUpdate()
    {
        //Set the main camera behind the car and follow it
        transform.position = player.transform.position + offset;
    }
}
