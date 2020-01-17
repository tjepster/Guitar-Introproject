using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScore : MonoBehaviour
{

    // THis method is used in the endscreen to show the end score
    public Score score;
    public TextMeshProUGUI _score;
    void Start()
    {
        _score.text = score.score.ToString();
    }
}
