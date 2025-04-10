using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoboticArm : MonoBehaviour
{
    public Transform grabPoint;

    public GameObject ballFollow;

    Animator animator;

    bool canGrab = true;
    BallMovement ball;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canGrab)
        {
            ball = other.GetComponent<BallMovement>();

            if (ball)
            {
                animator.SetBool("grabbed", true);
                ball.transform.position = grabPoint.position;
                ball.transform.parent = ballFollow.transform;
                canGrab = false;
                ball.Grabbed();
            }
        }
    }

    public void StopGrabbed()
    {
        animator.SetBool("grabbed", false);
    }

    public void CanGrab()
    {
        canGrab = true;
    }

    public void Throw()
    {
        ball.ApplyForce(new Vector3(1,0,0), 5f);
        ball.transform.parent = null;
    }
}
