using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1;
    public float LaneDistance;
    int scoreAmount = 0;
    public TMP_Text scoreText;
    public GameObject PausePanel;

    private void Start() {
        instance = this;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        scoreText.SetText("Score: " + scoreAmount.ToString());

        direction.z = forwardSpeed;

        if(SwipeControl.swipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if(SwipeControl.swipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
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
    public void AddScore(int score)
    {
        scoreAmount = score + scoreAmount;
        Debug.Log(scoreAmount);
    }

    public void PauseButton()
    {
        PausePanel.SetActive(true);
    }
}
