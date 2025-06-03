using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    bool touched = false;
    public void OnTriggerEnter(Collider other)
    {
        if (!touched)
        {
            BallMovement ball = other.GetComponent<BallMovement>();

            if (ball)
            {
                ball.ShieldGain(gameObject);
                transform.parent = ball.transform;
                transform.localPosition = Vector3.zero;
                touched = true;
                gameObject.SetActive(false);
            }
        }
    }
}
