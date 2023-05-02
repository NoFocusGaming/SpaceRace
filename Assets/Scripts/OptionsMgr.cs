using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMgr : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
