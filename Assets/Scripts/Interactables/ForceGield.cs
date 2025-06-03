using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGield : MonoBehaviour
{
    public float interval = 0.8f;
    public float waitStart = 0f;

    public GameObject forceField;

    public void Start()
    {
        InvokeRepeating("Alternate", waitStart, interval);
    }

    void Alternate()
    {
        forceField.gameObject.SetActive(!forceField.activeSelf);
    }
}
