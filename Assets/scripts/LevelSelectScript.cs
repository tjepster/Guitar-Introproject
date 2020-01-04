using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public void PlayLevel1()
    {
        PlayerPrefs.SetString("currentLevel", "level1");
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
