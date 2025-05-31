using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    public List<GameObject> triggers;

    public float alternateTime = 2f;
    public float startWait = 0f;
    bool active = false;

    private void Start()
    {
        InvokeRepeating("Alternate", startWait, alternateTime);
    }

    public void Alternate()
    {
        if(active) 
        { 
            foreach(GameObject trigger in triggers) 
            { 
                trigger.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject trigger in triggers)
            {
                trigger.SetActive(true);
            }
        }

        active = !active;
    }
}
