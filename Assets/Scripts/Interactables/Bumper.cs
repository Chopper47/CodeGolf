using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force;
    public void OnCollisionEnter(Collision collision)
    {
        BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

        if(ball)
        {
            if(!ball.GetShieldActive())
            {
                Vector3 forceApply = ball.transform.position - collision.contacts[0].point;
                ball.ApplyForce(forceApply.normalized, force);
            }
            else
            {
                ball.Stopped();
            }
        }
    }
}
