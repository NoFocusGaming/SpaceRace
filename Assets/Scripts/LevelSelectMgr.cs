using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMgr : MonoBehaviour
{
    public void BackButton() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
