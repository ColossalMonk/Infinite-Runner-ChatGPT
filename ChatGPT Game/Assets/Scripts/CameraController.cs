using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // the player object that the camera should follow
    public Vector3 offset; // the offset that the camera should maintain from the player

    void LateUpdate()
    {
        // calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;
        // make the camera look at the player
        transform.LookAt(target);
        transform.position = targetPosition;
    }
}
