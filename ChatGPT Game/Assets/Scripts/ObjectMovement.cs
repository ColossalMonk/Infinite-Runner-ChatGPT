using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 1f; // the speed at which the object will move
    public Vector3 direction = Vector3.forward; // the direction in which the object will move

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
