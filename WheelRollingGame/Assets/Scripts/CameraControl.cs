using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float SkyboxSpeed;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * SkyboxSpeed);
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
        transform.LookAt(target);
    }
}
