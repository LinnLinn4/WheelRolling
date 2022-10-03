using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int desirdLane = 1;
    public float LaneDistance = 2.5f;

    void Update()
    {
        // camera.transform.position = transform.position + offset;
        //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }

    void FixedUpdate()
    {
        // rb.AddForce(0, 0, ForwardForce * Time.deltaTime);
        // if(Input.GetKey("d"))
        // {
        //     rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }
        // if(Input.GetKey("a"))
        // {
        //     rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }
    }
}
