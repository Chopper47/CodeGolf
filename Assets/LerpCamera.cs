using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LerpCamera : MonoBehaviour
{
    public Transform ball;
    public float timeToLerp = 0.5f;

    bool lerp = false;
    bool activeLerp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(lerp)
        {
            if (!activeLerp)
            {
                StartCoroutine(Lerp());
            }
        }
    }

    IEnumerator Lerp()
    {
        activeLerp = true;
        float timer = 0f;

        while (timer < timeToLerp)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(ball.position.x, transform.position.y, ball.position.z), timer/timeToLerp);
            timer += Time.deltaTime;
        }
        activeLerp = false;
        yield return null;
    }

    public void ActivateLerp()
    {
        lerp = true;
        //StartCoroutine(DelayLerp());
    }

    IEnumerator DelayLerp()
    {
        yield return new WaitForSeconds(0.2f);
        lerp = true;
    }
}
