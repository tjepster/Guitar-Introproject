using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioSource song;
    public GameObject pauseMenu;
    public void Pause()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            StopGame();
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        song.UnPause();
        GameIsPaused = false;
    }
    void StopGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        song.Pause();
        GameIsPaused = true;
    }
    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        song.Stop();
        SceneManager.LoadScene("Menu");
    }


}
