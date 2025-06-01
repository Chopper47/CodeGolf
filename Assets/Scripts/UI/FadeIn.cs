using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject canvasObject;
    public float fadeDuration = 0.5f;

    private void Awake()
    {

        canvasObject.SetActive(true);
        canvasGroup.alpha = 1f;  
        
    }

    private void Start()
    {
        FadeOutAndDeactivate();
    }

    public void FadeOutAndDeactivate()
    {

        StartCoroutine(FadeOut());
        
    }

    private System.Collections.IEnumerator FadeOut()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
        canvasObject.SetActive(false); 
    }
}
