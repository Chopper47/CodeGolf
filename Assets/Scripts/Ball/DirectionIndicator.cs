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
    float height;
    float diff;

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
        height = -arrow.offsetMax.y;
        diff = Mathf.Abs(height+height);
        DissapearArrow();
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.AimState())
        {
            Vector3 dir = movement.GetDirectionValue();

            if(dir.x < 0)
            {
                canvas.transform.rotation = Quaternion.Euler(90f, 0f, Vector3.Angle(movement.GetDirectionValue(), Vector3.forward)); 
            }
            else
            {
                canvas.transform.rotation = Quaternion.Euler(90f, 0f, -Vector3.Angle(movement.GetDirectionValue(), Vector3.forward));
            }

        }
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
