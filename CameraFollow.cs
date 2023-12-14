using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10f);
    private float smoothTime = 0.25f;
    private Vector3 cameraVelocity= Vector3.zero;

    [SerializeField] private Transform player;
    
    void Update()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position=Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity,smoothTime);
        
    }
}
