using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DirectionIndicator : MonoBehaviour
{
    BallMovement movement;

    public GameObject directionArrow;
    public GameObject canvas;

    Quaternion canvasInitialState;
    RectTransform arrow;
    UnityEngine.UI.Image arrowImage;

    [Header(" --- Rotation --- ")]
    public float time = 5f;
    public float dispersion = 40f;
    public float desviationScaling = 5f;
    Vector3 originalDir;

    Coroutine coroutine;
    float dispersionProportion = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        movement = GetComponent<BallMovement>();

        if(movement == null )
        {
            Debug.LogError("Movement not found, maybe not implemented on GameObject");
        }

        if(directionArrow == null )
        {
            Debug.LogError("Arrow gameObject not assigned");
        }
        
        if(canvas == null )
        {
            Debug.LogError("Canvas not assigned");
        }
    }

    private void Start()
    {
        canvasInitialState = canvas.transform.rotation;
        arrow = directionArrow.GetComponent<RectTransform>();
        arrowImage = directionArrow.GetComponent<UnityEngine.UI.Image>();
        DissapearArrow();
        PlayerInfo info = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<PlayerInfo>();

        if (info != null)
        {
            dispersion = dispersion - desviationScaling * info.accuracyLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.AimState())
        {
            canvas.transform.SetParent(null);
            canvas.transform.position = transform.position;

            Vector3 dir = movement.GetDirectionValue();

            if (coroutine == null)
            { 
                dispersionProportion = 0f;
                transform.rotation = Quaternion.Euler(0f,0f,0f);
            }

            if (dir.x < 0)
            {
                originalDir = new Vector3(90f, 0f, Vector3.Angle(movement.GetDirectionValue(), Vector3.forward)); 
            }
            else
            {
                originalDir = new Vector3(90f, 0f, -Vector3.Angle(movement.GetDirectionValue(), Vector3.forward));
            }

            if(coroutine == null)
            {
                if(Random.Range(0,2) == 1)
                {
                    coroutine = StartCoroutine(Up());
                }
                else
                {
                    coroutine = StartCoroutine(Down());
                }
            }
        }
    }

    public void StopCoroutineDispersion()
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = null;
    }

    IEnumerator Down()            //sumar
    {
        float timer = 0f;
        Quaternion start = canvas.transform.localRotation;

        float starterDispersion = dispersionProportion;

        while (timer < time)
        {
            canvas.transform.localRotation = Quaternion.Lerp(start, Quaternion.Euler(90f, 0f, originalDir.z + dispersion), timer / time);

            if (starterDispersion == 0f)
            {
                dispersionProportion = Mathf.Lerp(0f, 1f, timer / time);
            }
            else
            {
                dispersionProportion = Mathf.Lerp(-1f, 1f, timer / time);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        dispersionProportion = 1f;

        coroutine = StartCoroutine(Up());
    }

    IEnumerator Up()            //restar
    {
        float timer = 0f;
        Quaternion start = canvas.transform.localRotation;

        float starterDispersion = dispersionProportion;

        while (timer < time)
        {
            canvas.transform.localRotation = Quaternion.Lerp(start, Quaternion.Euler(90f, 0f,originalDir.z - dispersion), timer / time);

            if (starterDispersion == 0f)
            {
                dispersionProportion = Mathf.Lerp(0f,-1f, timer/time);
            }
            else
            {
                dispersionProportion = Mathf.Lerp(1f, -1f, timer / time); 
            }

            timer += Time.deltaTime;
            yield return null;
        }

        dispersionProportion = -1f;

        coroutine = StartCoroutine(Down());
    }

    public void RecallCanvas()
    {
        canvas.transform.SetParent(this.transform);
    }

    public float GetDispersion()
    {
        return dispersionProportion;
    }

    public float DispersionAmount()
    {
        return dispersion;
    }

    public void AppearArrow()
    {
        Vector3 dir = movement.GetDirectionValue();

        if (dir.x < 0)
        {
            canvas.transform.rotation = Quaternion.Euler(90f, 0f, Vector3.Angle(movement.GetDirectionValue(), Vector3.forward));
        }
        else
        {
            canvas.transform.rotation = Quaternion.Euler(90f, 0f, -Vector3.Angle(movement.GetDirectionValue(), Vector3.forward));
        }
        canvas.SetActive(true);
    }

    public void DissapearArrow()
    {
        canvas.SetActive(false);
    }

    public void ResetRotation()
    {
        canvas.transform.rotation = canvasInitialState;
    }

    public void SetFill(float fill)
    {
        arrowImage.fillAmount = fill;
    }
}
