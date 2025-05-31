using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public GameObject directionPoint;
    public float speed;


    public float amplifier = 1f;

    public float cooldown = 3f;
    Vector3 dirVector;

    bool canBoost = true;
    // Start is called before the first frame update
    void Start()
    {
        dirVector = directionPoint.transform.position - transform.position;

        dirVector.Normalize();
        dirVector *= speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();

        if (ball != null && canBoost) 
        { 
            ball.GetComponent<Rigidbody>().velocity += dirVector*amplifier;
            canBoost = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canBoost = true;
    }

}
