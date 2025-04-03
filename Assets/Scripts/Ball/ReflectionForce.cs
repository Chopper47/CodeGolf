using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReflectionForce : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject wall = collision.gameObject;
        
        if(wall.layer == 6)
        {
            BounceOffWall(collision.contacts[0].point);
        }
    }

    public void BounceOffWall(Vector3 collisionPoint)
    {
        //Collision is the contact point

        float speed = rb.velocity.magnitude;

        Vector3 dir = collisionPoint - transform.position;

        RaycastHit hit;
        
        Vector3 bounceVector;

        if (Physics.Raycast(transform.position, dir, out hit, 1f, 6))
        {
            bounceVector = Vector3.Reflect(dir, hit.normal);
        }
        else
        {
            bounceVector = -dir;
        }

        rb.velocity = bounceVector.normalized * speed;
    }
}
