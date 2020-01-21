using System.Collections;
using System.Collections.Generic;
using System.IO; // streamwriter 
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Is used to manage the game
    // variables are to see if the game is paused or not
    // references to the audioplayer and pausemenu UI
    public static bool GameIsPaused = false;
    public AudioSource song;
    public GameObject pauseMenu;

    // This method is called when the esc button is pressed it can either start or stop a pause screen
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

    // If the game is paused but we want to start playing again we deactivate the pause UI start the time and unpause the game
    // The bool is also changed to indacate we are not paused anymore
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        song.UnPause();
        GameIsPaused = false;
    }

    // If we are playing but want to pause we activate the pause menu UI, set the game time still and pause the song
    // The bool is also set to indacate the game is paused
    void StopGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        song.Pause();
        GameIsPaused = true;
    }

    // When we go to the main menu from the pause scene we first need to reset the gametime, indacate the game is not paused and stop the song.
    public void MainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        song.Stop();
        SceneManager.LoadScene("Menu");
    }

    public void Start()
    {
        string path = Application.dataPath + "/level.txt";
        StreamReader readLevel = new StreamReader(path);

    }
}
