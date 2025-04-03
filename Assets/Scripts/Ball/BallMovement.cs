using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float inputForce;

    Rigidbody rb;

    Touch[] touches;
    Vector3 startingPos;
    Vector3 dir;
    Vector3 forceToApply;

    bool moved;

    public TMPro.TMP_InputField tmp;

    [Header(" --- Joystick Variables --- ")]
    public GameObject joystickParent;

    public GameObject joystickBackground;

    public GameObject joystick;

    public float maxJoystickDistance;

    private void Start()
    {
        if (joystickParent == null)
        {
            Debug.LogError("Not assigned joystick parent");
        }
        else
        {
            joystickParent.SetActive(false);
        }
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        tmp.text = rb.velocity.magnitude.ToString();
        touches = Input.touches;

        foreach (var t in touches)
        {
            if (t.fingerId == 0)
            {
                //Se crea un unico joystick y se añade la fuerza una vez sueltas
                switch (t.phase)
                {
                    case TouchPhase.Began:
                        //Debug.Log(t.position);
                        joystickParent.SetActive(true);
                        startingPos = new Vector3(t.position.x,t.position.y, 0f);
                        joystickParent.transform.localPosition = new Vector3(t.position.x, t.position.y, 0f);
                        break;
                    case TouchPhase.Moved:
                        dir = (new Vector3(t.position.x, t.position.y, 0f) - startingPos);

                        if(dir.magnitude > maxJoystickDistance)
                        {
                            joystick.transform.localPosition = dir.normalized * maxJoystickDistance;
                        }
                        else
                        {
                            joystick.transform.localPosition = dir;
                        }

                        break;
                    case TouchPhase.Ended:
                        forceToApply = -(new Vector3(dir.x, 0f, dir.y));
                        rb.AddForce(forceToApply.normalized * inputForce, ForceMode.Force);
                        joystickParent.SetActive(false);
                        joystick.transform.localPosition = Vector3.zero;
                        break;
                }
            }
        }
    }

}
