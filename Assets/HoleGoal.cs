using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BallMovement ball = other.GetComponent<BallMovement>();
        if (ball)
        {
            Debug.Log("ganaste");
        }
    }
}
