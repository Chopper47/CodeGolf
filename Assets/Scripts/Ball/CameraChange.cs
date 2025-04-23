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

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(0f, 90f, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        yield return null;
    }

    IEnumerator LerpRotationVertical(float rotationTime)
    {
        float timer = 0f;

        while (timer < rotationTime)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(90f, 0f, timer / rotationTime), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        cinemachine.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        yield return null;
    }
}

