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

    public void ChangeCameraRotation()
    {
        Debug.Log("Rotate");
        switch (dir)
        {
            case direction.horizontal:
                cinemachine.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
                break;
            case direction.vertical:
                cinemachine.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                break;
        }
    }

    IEnumerator LerpRotation()
    {
        float timer = 0f;

        while (timer < 0.5f)
        {
            cinemachine.transform.rotation = Quaternion.Euler(90f, Mathf.Lerp(0f, 90f, timer / 0.5f), 0f);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }
}

