using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeNet : MonoBehaviour
{
    public float limit = -1f;
    BallMovement ball;
    GameObject ballGo;


    public void Awake()
    {
        ball = FindAnyObjectByType<BallMovement>();
        ballGo = ball.gameObject;
    }

    public void Update()
    {
        if(ballGo.transform.position.y <= limit)
        {
            ball.SendToLastPosition();
        }
    }
}
