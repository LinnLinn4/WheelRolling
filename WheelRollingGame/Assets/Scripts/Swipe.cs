using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public SwipeControl swipeControls;
    public Transform Player;
    private Vector3 desiredPosition;
    private Vector3 swipeLeft;
    private Vector3 swipeRight;
    
    // Update is called once per frame
    void Update()
    {
        swipeLeft[0] = -3;
        swipeRight[0] = 3;
        if (swipeControls.SwipeLeft)
            desiredPosition += swipeLeft;
        if (swipeControls.SwipeRight)
            desiredPosition += swipeRight;
        
        Player.transform.position = Vector3.MoveTowards(Player.transform.position, desiredPosition, 3f * Time.deltaTime);

        if(swipeControls.Tap)
        {
            Debug.Log("Tap!");
            Debug.Log(transform.position);
        }
    }
}
