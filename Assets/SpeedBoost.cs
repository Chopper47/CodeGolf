using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public GameObject directionPoint;
    public float speed;

    Vector3 dirVector;
    // Start is called before the first frame update
    void Start()
    {
        dirVector = directionPoint.transform.position - transform.position;

        dirVector.Normalize();
        dirVector *= speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if (ball != null) 
        { 
            ball.GetComponent<Rigidbody>().velocity = dirVector;
        }
    }
}
