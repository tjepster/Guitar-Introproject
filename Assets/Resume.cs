using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public void ResumeGame()
    {
        FindObjectOfType<GameManager>().Resume();
    }
}
