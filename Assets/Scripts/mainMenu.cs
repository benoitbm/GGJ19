using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class mainMenu : MonoBehaviour
{
    [SerializeField] GameObject titleMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject disclaimer;
    [SerializeField] Image backgroundFade;
    [SerializeField] GameObject siroccoLoading;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disclaimerDisplay());
    }

    public void Play()
    {
        StartCoroutine(fadeImage(false, 2f));
        //Commentary start
        siroccoLoading.SetActive(true);
        StartCoroutine(loadLevel(5.0f));
    }

    public void Credits()
    {
        credits.SetActive(true);
        titleMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        credits.SetActive(false);
        titleMenu.SetActive(true);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    IEnumerator disclaimerDisplay()
    {
        titleMenu.SetActive(false);
        credits.SetActive(false);
        disclaimer.SetActive(true);
        siroccoLoading.SetActive(false);
        backgroundFade.gameObject.SetActive(false);
        yield return new WaitForSeconds(5.0f);
        disclaimer.SetActive(false);
        titleMenu.SetActive(true);
    }

    IEnumerator fadeImage(bool fade, float time)
    {
        backgroundFade.gameObject.SetActive(true);
        if (fade)
        {
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                Color col = backgroundFade.color;
                col.a = i;
                backgroundFade.color = col;
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= time; i += Time.deltaTime)
            {
                Color col = backgroundFade.color;
                col.a = i;
                backgroundFade.color = col;
                yield return null;
            }
        }
    }

    IEnumerator loadLevel(float time)
    {
        yield return new WaitForSeconds(time); //Temp value, will be changed after audio ends
        float initTime = time;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1); // 1 is main level

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone || initTime > 0)
        {
            initTime -= Time.fixedUnscaledDeltaTime;
            yield return null;
        }

        SceneManager.LoadScene(1); //1 is main level
    }
}
