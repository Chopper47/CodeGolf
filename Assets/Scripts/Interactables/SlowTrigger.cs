using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if(ball)
        {
            ball.Slow();
        }
    }
}
