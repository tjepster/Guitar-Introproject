using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    // Is used to manage the game
    // variables are to see if the game is paused or not
    // references to the audioplayer and pausemenu UI
    public static bool GameIsPaused = false;
    public AudioSource song;
    public GameObject pauseMenu;

    public GameObject redBeat;
    public GameObject blueBeat;
    public GameObject yellowBeat;

    public List<string> levelStringList = new List<string>();

    private void Start()
    {
        string levelname = "";
        if (PlayerPrefs.HasKey("currentLevel"))
        {
            levelname = PlayerPrefs.GetString("currentLevel");
        }
        else
        {
            // error
        }
        string filename = Application.dataPath + "/levels/" + levelname + "/level.txt";
        Readfile(filename);
        MakeLevel();
        song.Play();
    }


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

    private void Readfile(string filename)
    {
        StreamReader reader = new StreamReader(filename);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            levelStringList.Add(line);
        }
        reader.Close();
    }
    void MakeLevel()
    {
        float pos = 0;
        string Beat = "start";
        bool Ispos;
        for (int i = 0; i < levelStringList.Count; i++)
        {
            string line = levelStringList[i];
            try
            {
                pos = float.Parse(line);
                Ispos = true;
            }
            catch (FormatException)
            {
                Beat = line;
                Ispos = false;
            }
            if (Beat != "r" && Beat != "y" && Beat != "b")
            {

            }
            else if (Beat == "r" && Ispos)
            {
                Instantiate(redBeat, new Vector3(0, 0.25f, pos), Quaternion.identity);
            }
            else if (Beat == "y" && Ispos)
            {
                Instantiate(yellowBeat, new Vector3(-2, 0.25f, pos), Quaternion.identity);
            }
            else if (Beat == "b" && Ispos)
            {
                Instantiate(blueBeat, new Vector3(2, 0.25f, pos), Quaternion.identity);
            }
        }
    }
}
