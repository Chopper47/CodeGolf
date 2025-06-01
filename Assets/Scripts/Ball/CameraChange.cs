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
        horizontal,
        vertical
    }

    direction dir;
    float lastDir = 0f;
    GameObject cinemachine;
    // Start is called before the first frame update
    void Start()
    {
        float y = transform.rotation.y / 90f;

        if (Mathf.Approximately(y % 2, 0))
        {
            dir = direction.vertical;
        }
        else
        {
            dir = direction.horizontal;
        }

        cinemachine = FindAnyObjectByType<CinemachineVirtualCamera>().gameObject;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(LerpRotationVertical(1f));
        }
        
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(LerpRotationVerticalInverse(1f));
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(LerpRotationHorizontalInverse(1f));
        }
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(LerpRotationHorizontal(1f));
        }
    }

    public void ChangeCameraRotation(bool vertical)
    {
        Debug.Log("Rotate");
        switch (dir)
        {
            case direction.horizontal:
                if(vertical)
                {
                    StartCoroutine(LerpRotationHorizontal(1f));
                }
                break;
            case direction.vertical:
                if(!vertical)
                {
                    StartCoroutine(LerpRotationVertical(1f));
                }
                break;
        }
    }

    public bool VerticalCamera()
    {
        return dir == direction.vertical;
    }

    IEnumerator LerpRotationHorizontal(float rotationTime)
    {
        float timer = 0f;
        float yStarter = lastDir;

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(yStarter, 90f, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        lastDir = 90f;
        yield return null;
    }

    IEnumerator LerpRotationVerticalInverse(float rotationTime)
    {
        float timer = 0f;

        float yStarter = lastDir;

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(yStarter, 180f, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
        lastDir = 180f;
        yield return null;
    }

    IEnumerator LerpRotationHorizontalInverse(float rotationTime)
    {
        float timer = 0f;
        float yStarter = lastDir;

        float left;
        if(lastDir < 90)
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
        lastDir = 270f;
        yield return null;
    }

    IEnumerator LerpRotationVertical(float rotationTime)
    {
        float timer = 0f;
        float yStarter = lastDir;

        float front;
        if(lastDir <= 180)
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
        lastDir = 0f;
        yield return null;
    }
}

