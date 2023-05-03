using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public CanvasGroup blackScreen;
    public int nextSceneIndex;
    public bool starting, ending, done;
    public bool loadOut;

    void Start()
    {
        starting = true;
        ending = false;
        done = false;
    }

    void Update()
    {
        if (starting)
        {
            StartCoroutine(fadeIn());
        }

        if (!loadOut) { }
        else if (ending)
        {
            StartCoroutine(fadeOut());
        }
        else
        {
            StartCoroutine(delay());
        }

        if (done)
        {
            SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        }

    }

    IEnumerator fadeOut()
    {
        print("fading");

        float curOpacity = blackScreen.alpha;
        float endOpacity = 1f;

        float totalTime = 1f; //the amount of time you want the movement to take
        float currentTime = 0f;//The amount of time that has passed

        while (curOpacity != endOpacity && currentTime < totalTime)
        {
            currentTime += Time.deltaTime;
            blackScreen.alpha = Mathf.Lerp(curOpacity, endOpacity, currentTime / totalTime);

            yield return null;
        }
        blackScreen.alpha = endOpacity;
        ending = false;
        done = true;
        print("finished");

        yield return null;
    }

    IEnumerator delay()
    {
        float totalTime = 2f;
        float currentTime = 0f;
        while (currentTime < totalTime)
        {
            currentTime += Time.deltaTime;

            yield return null;
        }
        ending = true;
        yield return null;
    }

    IEnumerator fadeIn()
    {
        float curOpacity = blackScreen.alpha;
        float endOpacity = 0f;

        float totalTime = 1f; //the amount of time you want the movement to take
        float currentTime = 0f;//The amount of time that has passed

        while (curOpacity != endOpacity && currentTime < totalTime)
        {
            currentTime += Time.deltaTime;
            blackScreen.alpha = Mathf.Lerp(curOpacity, endOpacity, currentTime / totalTime);

            yield return null;
        }
        blackScreen.alpha = endOpacity;
        print("finished");
        starting = false;

        yield return null;
    }
}
