using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmenu : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;
    public AudioSource clickSound;
    public GameRuleMaster gameRuleMaster;

    public float fadeDuration = 1.5f;
    public bool inGame = false;
    public float waitTime = 0.5f;
    private bool _isAudioPlayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadInGameScene()
    {
        Debug.Log("Game Start");
        if (!_isAudioPlayed)
        {
            clickSound.Play();
            _isAudioPlayed = true;
        }
        StartCoroutine(FadeOut(false));
    }

    public void GameQuit()
    {
        Debug.Log("Game Quit");
        if (!_isAudioPlayed)
        {
            clickSound.Play();
            _isAudioPlayed = true;
        }
        StartCoroutine(FadeOut(true));
    }

    public void Defeat()
    {
        Debug.Log("Defeated");
        StartCoroutine(gameRuleMaster.TurnOffBGM());
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
        Debug.Log("quit: " + quit);
        Debug.Log("inGame: " + inGame);
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

        if (inGame && quit)
        {
            SceneManager.LoadScene("StartMenu");
            //SceneManager.LoadScene("DefeatScene");
        }
        else if (inGame)
        {
            SceneManager.LoadScene("StartMenu");
        }
        else if (quit)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("Background");
        }
    }
}
