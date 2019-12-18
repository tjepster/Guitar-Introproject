using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Is called when the play button is pressed in the menu scene and starts the level scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Level Select");
    }
}
