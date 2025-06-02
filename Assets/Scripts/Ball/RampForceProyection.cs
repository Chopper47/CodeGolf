using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampForceProyection : MonoBehaviour
{
    bool checkForRamp = false;

    bool foundRamp = false;

    bool rampTouched = false;

    Rigidbody rb;

    public LayerMask ramp;

    Vector3 touchPoint;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(checkForRamp && rampTouched) 
        {
            Debug.DrawRay(transform.position, (touchPoint - transform.position).normalized, Color.magenta);
            if(Physics.Raycast(transform.position,(touchPoint - transform.position).normalized,out RaycastHit hit,0.5f,ramp))
            { 
                foundRamp = true;
                Debug.Log("Fixing ");
                rb.velocity = Vector3.ProjectOnPlane(rb.velocity, hit.normal);
            }
            else
            {
                if(foundRamp) 
                {
                    Debug.Log("left");
                    StopCheck();
                }
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (checkForRamp)
        { 
            if(collision.gameObject.layer == 8)
            {
                rampTouched = true;
                touchPoint = collision.contacts[0].point;
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (checkForRamp)
        {
            if (collision.gameObject.layer == 8)
            {
                rampTouched = true;
                touchPoint = collision.contacts[0].point;
            }
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if(checkForRamp)
        {
            if(collision.gameObject.layer == 8)
            {
                touchPoint = transform.position;
            }
        }
    }

    public void StartCheck()
    {
        checkForRamp = true;
    }

    void StopCheck()
    {
        checkForRamp = false;
        rampTouched  = false;
    }
}
