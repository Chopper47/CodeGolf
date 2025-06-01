using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float inputForce;

    public float strengthScaling = 2.5f;

    public float slowProportion = 2f;

    float distanceProportion;

    public LayerMask mask;

    float strengthAdded;

    Rigidbody rb;

    Touch[] touches;
    Vector3 startingPos;
    Vector3 dir;
    Vector3 forceToApply;

    bool slowed;

    bool grabbed = false;
    bool stoppedMoving = true;
    bool checkSpeed = false;

    bool verticalInput = true;

    bool aiming = false;

    public TMPro.TMP_InputField tmp;

    HitCounter hitCounter;

    DirectionIndicator directionIndicator;

    [Header(" --- Joystick Variables --- ")]
    public GameObject joystickParent;

    public GameObject joystickBackground;

    public GameObject joystick;

    public float maxJoystickDistance;

    ChangeCamRotation change;

    Vector3 lastHitPosition;

    Transform lastChangeTransform;

    public void Awake()
    {
        checkSpeed = false;
        directionIndicator = GetComponent<DirectionIndicator>();
        hitCounter = GetComponent<HitCounter>();
    }

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

        strengthAdded = strengthScaling * PlayerPrefs.GetFloat("strengthLevel"); //*level
    }

    private void Update()
    {
        tmp.text = rb.velocity.magnitude.ToString();

        
        if(!stoppedMoving && checkSpeed)
        {
            Debug.Log("Checking speed");
            if (rb.velocity.magnitude <= 0.25f)
            {
                Debug.Log("Aproxed 0");
                stoppedMoving = true;
            }
        }

        if(stoppedMoving && checkSpeed)
        {
            Debug.Log("stopped");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            checkSpeed = false;
        }

        if (stoppedMoving && !grabbed)
        {
            touches = Input.touches;

            foreach (var t in touches)
            {
                if (t.fingerId == 0)
                {
                    //Se crea un unico joystick y se añade la fuerza una vez sueltas
                    switch (t.phase)
                    {
                        case TouchPhase.Began:
                            directionIndicator.ResetRotation();
                            aiming = true;
                            joystickParent.SetActive(true);
                            startingPos = new Vector3(t.position.x, t.position.y, 0f);
                            joystickParent.transform.localPosition = new Vector3(t.position.x, t.position.y, 0f);
                            dir = (new Vector3(t.position.x, t.position.y, 0f) - startingPos);
                            distanceProportion = 0f;
                            directionIndicator.AppearArrow();
                            directionIndicator.SetFill(distanceProportion);
                            break;
                        case TouchPhase.Moved:
                            if(!grabbed)
                            {
                                dir = (new Vector3(t.position.x, t.position.y, 0f) - startingPos);

                                if (dir.magnitude > maxJoystickDistance)
                                {
                                    joystick.transform.localPosition = dir.normalized * maxJoystickDistance;
                                    distanceProportion = 1f;
                                }
                                else
                                {
                                    joystick.transform.localPosition = dir;
                                    distanceProportion = dir.magnitude/maxJoystickDistance;
                                }

                                directionIndicator.SetFill(distanceProportion);
                            }
                            else
                            {
                                joystickParent.SetActive(false);
                                joystick.transform.localPosition = Vector3.zero;
                            }
                            break;
                        case TouchPhase.Stationary:
                            if(grabbed)
                            {
                                joystickParent.SetActive(false);
                                joystick.transform.localPosition = Vector3.zero;
                            }
                            break;
                        case TouchPhase.Ended:
                            aiming = false;
                            directionIndicator.StopCoroutineDispersion();
                            directionIndicator.DissapearArrow();

                            if(verticalInput)
                            {
                                forceToApply = -new Vector3(dir.x, 0f, dir.y);
                            }
                            else
                            {
                                forceToApply = new Vector3(-dir.y, 0f, dir.x);
                            }

                            float magnitudeToApply = (inputForce + strengthAdded) * distanceProportion;

                            if(directionIndicator.GetDispersion() < 0)
                            {
                                Vector3.RotateTowards(forceToApply, new Vector3(-forceToApply.x, 0f, forceToApply.z), directionIndicator.DispersionAmount()* Math.Abs(directionIndicator.GetDispersion()),0f);
                            }

                            if(slowed)
                            {
                                magnitudeToApply /= slowProportion;
                                slowed = false;
                            }

                            lastHitPosition = transform.position;
                            rb.AddForce(forceToApply.normalized * magnitudeToApply, ForceMode.Force);
                            stoppedMoving = false;
                            StartCoroutine(TimerForStopCheck());
                            joystickParent.SetActive(false);
                            joystick.transform.localPosition = Vector3.zero;
                            hitCounter.Hit();
                            break;
                    }
                }
            }
        }

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f, mask))
        {
            if (lastChangeTransform != hit.transform)
            {
                lastChangeTransform = hit.transform;

                change = lastChangeTransform.GetComponent<ChangeCamRotation>();

                if (change)
                {
                    change.ChangeCameraRotation(verticalInput);
                    verticalInput = change.VerticalCamera();
                }
            }
        }
    }

    public void Slow()
    {
        slowed = true;
    }

    public void NotSlow()
    {
        slowed = false;
    }

    public Vector3 GetDirectionValue()
    {
        if (verticalInput)
        {
            return -new Vector3(dir.x, 0f, dir.y);
        }
        else
        {
            return new Vector3(-dir.y, 0f, dir.x);
        }
    }

    public bool IsCameraVertical()
    {
        return verticalInput;
    }

    public bool AimState()
    {
        return aiming;
    }
    
    public float DistanceProportion()
    {
        return distanceProportion;
    }

    IEnumerator TimerForStopCheck()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Check set true");
        checkSpeed = true;
    }

    public void Grabbed()
    {
        grabbed = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void ApplyForce(Vector3 dir, float force)
    {
        rb.AddForce(dir * force, ForceMode.Force);
    }

    public void NotGrabbed()
    {
        grabbed = false;
    }

    public bool IsGrabbed()
    {
        return grabbed;
    }

    public void SendToLastPosition()
    {
        transform.position = lastHitPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
