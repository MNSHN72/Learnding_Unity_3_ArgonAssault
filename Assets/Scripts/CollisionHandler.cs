using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"collided with {collision.collider.gameObject.name}");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"triggered by {other.gameObject.name}");
    }
}
