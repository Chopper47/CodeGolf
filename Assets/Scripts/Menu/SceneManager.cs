using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject canvasObject;
    public float fadeDuration = 2f;

    private void Awake()
    {
        canvasObject.SetActive(false);
    }

    public void GoToMainMenu()
    {
        StartCoroutine(FadeOutAndLoad("MainMenu"));
    }

    public void GoToLevel(string level)
    {
        StartCoroutine(FadeOutAndLoad(level));
    }

    private IEnumerator FadeOutAndLoad(string scene)
    {
        canvasObject.SetActive(true);
        canvasGroup.alpha = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
