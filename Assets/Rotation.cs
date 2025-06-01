using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float time = 5f;
    public float disppersion = 40f;
    Vector3 og = Vector3.forward;

    public void Start()
    {
        StartCoroutine(Down());
    }
    IEnumerator Down()            //sumar
    {
        float timer = 0f;
        Quaternion start = transform.rotation;
        while (timer < time)
        {
            transform.rotation = Quaternion.Lerp(start ,Quaternion.Euler(start.x, og.y + disppersion, start.z), timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(Up());
    }

    IEnumerator Up()            //restar
    {
        float timer = 0f;
        Quaternion start = transform.rotation;
        while (timer < time)
        {
            transform.rotation = Quaternion.Lerp(start, Quaternion.Euler(start.x, og.y - disppersion, start.z), timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(Down());
    }
}
