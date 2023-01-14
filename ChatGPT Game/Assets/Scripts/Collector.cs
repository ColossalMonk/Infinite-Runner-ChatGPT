using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public string tagToCheck = "Untagged"; // The tag to check for collision or trigger

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagToCheck))
        {
            Destroy(collision.gameObject);
        }

        Destroy(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
        {
            Destroy(other.gameObject);
        }

        Destroy(other.gameObject);
    }
}
