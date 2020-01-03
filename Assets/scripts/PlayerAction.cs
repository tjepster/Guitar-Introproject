using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerAction : MonoBehaviour
{
    // conections to the transform and Beatcollision components of the playerbutton
    public Transform scale;
    public BeatCollision bc;
    // easy to change variables for colour of player and key to press
    public string Colour;
    public string Key;
    // start of the voice recognision sofware
    private KeywordRecognizer keywordRecognizer;
    readonly private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public GameObject Fire;
    void Start()
    {
        actions.Add(Colour, Rainbow);

        // Voice recognision start
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    // Is called when a word is recognized
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // checks if the button press is at the right time to give points or if not to end the streak
    private void Rainbow()
    {
        Pressed();
        if (bc.Presswindow == true)
        {
            GameObject.Destroy(bc.CurrentBeat);
            FindObjectOfType<Score>().score += 200;
            FindObjectOfType<Streak>().streak += 1;
            FirePress();
            bc.Presswindow = false;
        }
        else
        {
            FindObjectOfType<Streak>().streak = 0;
        }
    }

    // checks if the button press is at the right time to give points or if not to end the streak
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            Pressed();
            if (bc.Presswindow == true)
            {
                GameObject.Destroy(bc.CurrentBeat);
                FindObjectOfType<Score>().score += 200;
                FindObjectOfType<Streak>().streak += 1;
                FirePress();
                bc.Presswindow = false;
            }
            else
            {
                FindObjectOfType<Streak>().streak = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<GameManager>().Pause();
        }
    }

    // pushes the button down on press
    void Pressed()
    {
        scale.localScale = new Vector3(1, 0.2f, 1);
        scale.localPosition -= new Vector3(0, 0.05f, 0);
        Invoke("ButtonUp", 0.1f);
    }

    // brings the button back to normal
    void ButtonUp()
    {
        scale.localScale = new Vector3(1, 0.25f, 1);
        scale.localPosition += new Vector3(0, 0.05f, 0);
    }

    void FirePress()
    {
        if (Colour == "red")
        {
            Instantiate(Fire, new Vector3(0, 0.4f, 7.5f), Quaternion.Euler(90, 0, 0));
        }
        else if (Colour == "yellow")
        {
            Instantiate(Fire, new Vector3(-2, 0.4f, 7.5f), Quaternion.Euler(90, 0, 0));
        }
        else if (Colour == "blue")
        {
            Instantiate(Fire, new Vector3(2, 0.4f, 7.5f), Quaternion.Euler(90, 0, 0));
        }
    }
}