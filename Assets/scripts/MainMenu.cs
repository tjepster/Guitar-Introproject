using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Is used when the main menu button is pressed in the pause screen
    public void Menu()
    {
        FindObjectOfType<GameManager>().MainMenu();
    }
}
