using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class StartScreen : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject canvas;
    public float fadeDuration = 0.5f;

    public GameObject naturalElements;
    public GameObject techElements;

    private void Start()
    {
        canvas.gameObject.SetActive(false);
        techElements.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("ball"))
        ChangeElements();
    }

    public void ChangeElements()
    {  
        naturalElements.SetActive(false);
        techElements.SetActive(true);
        StartCoroutine(FadeOutAndLoad());
    }

    private IEnumerator FadeOutAndLoad()
    {
        yield return new WaitForSeconds(fadeDuration);

        canvas.SetActive(true);
        canvasGroup.alpha = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }

}
