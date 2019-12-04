using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Is called when the quit button is pushed in the main menu scene and leaves the apllication
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
