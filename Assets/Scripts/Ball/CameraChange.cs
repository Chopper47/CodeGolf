using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeCamRotation : MonoBehaviour
{
    enum direction
    {
        right,
        front,
        back,
        left
    }

    direction dir;
    GameObject cinemachine;

    public bool invertVerticalAxis;
    public bool invertHorizontalAxis;
    // Start is called before the first frame update
    void Start()
    {
        float y = transform.eulerAngles.y / 90f;
        switch(y)
        {
            case 0f:
                if(invertVerticalAxis)
                {
                    dir = direction.back;
                }
                else
                {
                    dir = direction.front;
                }
                break;
            case 1f:
                if(invertHorizontalAxis)
                { 
                    dir = direction.left;
                }
                else
                {
                    dir = direction.right;
                }
                break;
            case 2f:
                if (invertVerticalAxis)
                {
                    dir = direction.front;
                }
                else
                {
                    dir = direction.back;
                }
                break;
            case 3f:
                if (invertHorizontalAxis)
                {
                    dir = direction.right;
                }
                else
                {
                    dir = direction.left;
                }
                break;
            case 4f:
                if (invertVerticalAxis)
                {
                    dir = direction.back;
                }
                else
                {
                    dir = direction.front;
                }
                break;
            case -1f:
                if (invertHorizontalAxis)
                {
                    dir = direction.right;
                }
                else
                {
                    dir = direction.left;
                }
                break;
            case -2f:
                if (invertVerticalAxis)
                {
                    dir = direction.front;
                }
                else
                {
                    dir = direction.back;
                }
                break;
            case -3f:
                if (invertHorizontalAxis)
                {
                    dir = direction.left;
                }
                else
                {
                    dir = direction.right;
                }
                break;
        }

        cinemachine = FindAnyObjectByType<CinemachineVirtualCamera>().gameObject;
    }

    public void ChangeCameraRotation(int currentDir)
    {
        Debug.Log("Rotate");
        switch (dir)
        {
            case direction.right:StartCoroutine(LerpRotationHorizontal(1f));
                break;
            case direction.front:StartCoroutine(LerpRotationVertical(1f));
                break;
            case direction.back:StartCoroutine(LerpRotationVerticalInverse(1f));
                break;
            case direction.left:StartCoroutine(LerpRotationHorizontalInverse(1f));
                break;
        }
    }

    public int VerticalCamera()
    {
        switch(dir)
        {
            case direction.right:
                return 1;
            case direction.front:
                return 0;
            case direction.back:
                return 2;
            case direction.left:
                return 3;
            default: return 0;
        }
    }

    IEnumerator LerpRotationHorizontal(float rotationTime)
    {
        float timer = 0f;
        float yStarter = cinemachine.transform.rotation.eulerAngles.y;
        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(yStarter, 90f, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
    }

    IEnumerator LerpRotationVerticalInverse(float rotationTime)
    {
        float timer = 0f;

        float yStarter = cinemachine.transform.rotation.eulerAngles.y;

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(yStarter, 180f, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
    }

    IEnumerator LerpRotationHorizontalInverse(float rotationTime)
    {
        float timer = 0f;
        float yStarter = cinemachine.transform.rotation.eulerAngles.y;

        float left;
        if(yStarter < 90)
        {
            left = -90f;
        }
        else
        {
            left = 270f;
        }

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(yStarter, left, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 270f, 0f);
    }

    IEnumerator LerpRotationVertical(float rotationTime)
    {
        float timer = 0f;
        float yStarter = cinemachine.transform.rotation.eulerAngles.y;
        Debug.Log(yStarter);
        float front;
        if(yStarter <= 180)
        {
            front = 0f;
        }
        else
        {
            front = 360f;
        }

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(yStarter, front, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}

