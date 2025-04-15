using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoboticArm : MonoBehaviour
{
    public Transform grabPoint;

    public GameObject ballFollow;

    public float throwForce = 5f;

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
                ball.GetComponent<Collider>().isTrigger = true;
                ball.GetComponent<Rigidbody>().useGravity = false;
                ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

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
        ball.transform.parent = null;
        ball.ApplyForce(-transform.right, throwForce);
        ball.NotGrabbed();
        StartCoroutine(SolidBall());

    }

    IEnumerator SolidBall()
    {
        yield return new WaitForSeconds(0.8f);

        ball.GetComponent<Collider>().isTrigger = false;
        ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        ball.GetComponent<Rigidbody>().useGravity = true;
    }
}
