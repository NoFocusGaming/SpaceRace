using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMgr : MonoBehaviour
{
    public CanvasGroup blackScreen; //fade object
    bool starting, ending; //bools to control coroutines
    bool levels, options, stop; //bools to control scene to load
    public int nextSceneIndex;

    void Awake()
    {
        starting = true;
        ending = false;
        levels = false;
        options = false;
        stop = false;
    }

    void Update()
    {
        if (starting)
        {
            StartCoroutine(fadeIn());
        }
        else if (ending)
        {
            StartCoroutine(fadeOut());
        }
        else if (levels)
        {
            SceneManager.LoadScene("Moon", LoadSceneMode.Single);
        }
        else if (options)
        {
            SceneManager.LoadScene("OptionsMenu", LoadSceneMode.Single);
        }
        else if (stop)
        {
            Application.Quit();
        }
    }

    public void LevelSelect() {
        ending = true;
        levels = true;
    }

    public void Options()
    {
        ending = true;
        options = true;
    }

    public void Exit()
    {
        ending = true;
        stop = true;
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
        print("finished");

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
