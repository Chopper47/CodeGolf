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
    }

    private void OnTriggerEnter(Collider other)
    {
        RampForceProyection ball = other.GetComponent<RampForceProyection>();

        if (ball != null && canBoost) 
        {
            MonoBehaviour ballScript = ball.GetComponent<BallMovement>();
            StartCoroutine(DisableMovementScript(ballScript));

            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody>().AddForce(dirVector*amplifier*speed, ForceMode.Impulse);
            ball.StartCheck();

            canBoost = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canBoost = true;
    }

    IEnumerator DisableMovementScript(MonoBehaviour script)
    {
        script.enabled = false;
        yield return new WaitForSeconds(0.5f);
        script.enabled = true;
    }
}
