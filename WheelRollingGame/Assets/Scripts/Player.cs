using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desirdLane = 1;
    public float LaneDistance;
    public SwipeControl swipeControl;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        if(swipeControl.SwipeRight) //Input.GetKeyDown(KeyCode.RightArrow)
        {
            desirdLane++;
            if (desirdLane == 3)
                desirdLane = 2;
        }
        if(swipeControl.SwipeLeft)//Input.GetKeyDown(KeyCode.LeftArrow)
        {
            desirdLane--;
            if (desirdLane == -1)
                desirdLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desirdLane == 0)
        {
            targetPosition += Vector3.left * LaneDistance;
        }
        else if(desirdLane == 2)
        {
            targetPosition += Vector3.right * LaneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
