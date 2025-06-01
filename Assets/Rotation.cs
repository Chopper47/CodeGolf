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
        Debug.Log("down");
        float timer = 0f;
        Quaternion start = transform.rotation;
        while (timer < time)
        {
            transform.rotation = Quaternion.Lerp(start ,Quaternion.Euler(0f, Vector3.Angle(Quaternion.AngleAxis(disppersion,Vector3.up)*og, og), 0f), timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(Up());
    }

    IEnumerator Up()            //restar
    {
        Debug.Log("up");
        float timer = 0f;
        Quaternion start = transform.rotation;
        while (timer < time)
        {
            transform.rotation = Quaternion.Lerp(start, Quaternion.Euler(0f, Vector3.Angle(Quaternion.AngleAxis(360-disppersion, Vector3.up) * og, og), 0f), timer / time);
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("up ended");
    }
}
