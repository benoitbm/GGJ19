using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endUI : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] Text txt_Time, txt_Alert, txt_reached, txt_safely;

    // Start is called before the first frame update
    void Start()
    {
        Color noAlpha = new Color(1, 1, 1, 0);
        txt_Time.color = txt_Alert.color = txt_reached.color = txt_safely.color = noAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerEndGame(GameObject player)
    {
        //Comment end dialog here

        int minutes = Mathf.FloorToInt(Time.timeSinceLevelLoad/60);
        int seconds = Mathf.CeilToInt(Time.timeSinceLevelLoad % 60);
        txt_Time.text = "You've reached your home in " + minutes + "'" + seconds + "\".";
        txt_Alert.text = "You met " + 10 + " persons on your journey.";

        StartCoroutine(done());
    }

    IEnumerator done()
    {
        const float timePerText = 2f;
        for (float i = 0; i <= timePerText; i += Time.deltaTime)
        {
            Color col = fadeImage.color;
            col.a = (i / timePerText);
            fadeImage.color = col;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        for (float i = 0; i <= timePerText; i += Time.deltaTime)
        {
            Color col = txt_Time.color;
            col.a = (i / timePerText);
            txt_Time.color = col;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        for (float i = 0; i <= timePerText; i += Time.deltaTime)
        {
            Color col = txt_Alert.color;
            col.a = (i / timePerText);
            txt_Alert.color = col;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        for (float i = 0; i <= timePerText; i += Time.deltaTime)
        {
            Color col = txt_reached.color;
            col.a = (i / timePerText);
            txt_reached.color = col;
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        for (float i = 0; i <= timePerText; i += Time.deltaTime)
        {
            Color col = txt_safely.color;
            col.a = (i / timePerText);
            txt_safely.color = col;
            yield return null;
        }

        yield return new WaitForSeconds(5.0f);
        for (float i = 1; i > 0; i -= Time.deltaTime)
        {
            Color col = txt_safely.color;
            col.a = i;
            txt_reached.color = col;
            txt_safely.color = col;
            txt_Alert.color = col;
            txt_Time.color = col;
            yield return null;
        }

        SceneManager.LoadScene(0); //And go back to main menu finally
    }
}
