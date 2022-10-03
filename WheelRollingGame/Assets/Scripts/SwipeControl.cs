using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private static bool tap, swipeLeft, swipeRight, isDraging;
    private Vector2 startTouch, swipeDelta;

    private void Update() 
    {
        tap = swipeLeft = swipeRight = false;

        //Standalone Input
        if(Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        
        //Mobile Input
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }

        //calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        } 

        if (swipeDelta.magnitude > 125)
        {
            float x = swipeDelta.x;
            if (x < 0)
                swipeLeft = true;
            else
                swipeRight = true;
            Reset();
        }

    }

    private void Reset(){
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public bool Tap {get {return tap;}}
    public Vector2 SwipeDelta {get {return swipeDelta;}}
    public bool SwipeLeft {get {return swipeLeft;}}
    public bool SwipeRight {get {return swipeRight;}}
}
