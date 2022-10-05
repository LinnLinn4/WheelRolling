using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1;
    public float LaneDistance;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        if(SwipeControl.swipeRight) //Input.GetKeyDown(KeyCode.RightArrow)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if(SwipeControl.swipeLeft)//Input.GetKeyDown(KeyCode.LeftArrow)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * LaneDistance;
        }
        else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * LaneDistance;
        }

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }
    }
    
    private void FixedUpdate() {
        controller.Move(direction * Time.deltaTime);
    }
}
