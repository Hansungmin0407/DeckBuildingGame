using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmenu : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;

    public float fadeDuration = 1.5f;
    public bool inGame = false;
    public float waitTime = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadInGameScene()
    {
        Debug.Log("Game Start");
        StartCoroutine(FadeOut(false));
    }

    public void GameQuit()
    {
        Debug.Log("Game Quit");
        StartCoroutine(FadeOut(true));
    }

    public void StageClear()
    {
        Debug.Log("Game Clear");
        StartCoroutine(FadeOut(false));
    }

    private IEnumerator FadeIn()
    {
        float fadeInTimer = 0f;
        Color color = fadeImage.color;

        color.a = 1f;
        fadeImage.color = color;

        if (inGame)
        {
            yield return new WaitForSeconds(waitTime);
        }

        while (fadeInTimer < fadeDuration)
        {
            fadeInTimer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, fadeInTimer / fadeDuration);
            fadeImage.color = color;

            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
        fadeImage.gameObject.SetActive(false);
    }

    private IEnumerator FadeOut(bool quit)
    {
        fadeImage.gameObject.SetActive(true);
        float fadeInTimer = 0f;
        Color color = fadeImage.color;

        color.a = 0f;
        fadeImage.color = color;

        while (fadeInTimer < fadeDuration)
        {
            fadeInTimer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, fadeInTimer / fadeDuration);
            fadeImage.color = color;

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        if (quit)
        {
            Application.Quit();
        }
        else if (inGame)
        {
            SceneManager.LoadScene("StartMenu");
        }
        else
        {
            SceneManager.LoadScene("Background");
        }
    }
}
