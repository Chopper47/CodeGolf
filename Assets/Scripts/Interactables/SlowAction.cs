using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if(ball)
        {
            ball.GetComponent<Rigidbody>().velocity /= 2;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if(ball)
        {
            ball.Slow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if (ball)
        {
            ball.Slow();
        }
    }
}
