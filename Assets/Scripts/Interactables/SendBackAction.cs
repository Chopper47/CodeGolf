using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBackAction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if(ball)
        {
            ball.SendToLastPosition();
        }
    }
}
