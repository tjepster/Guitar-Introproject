using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerAction : MonoBehaviour
{
    public BeatCollision bc;
    public string Colour;
    public string Key;
    public int LocalScore = 0;

    private KeywordRecognizer keywordRecognizer;
    readonly private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    void Start()
    {
        actions.Add(Colour, Rainbow);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        //keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Rainbow()
    {
        if (bc.Presswindow == true)
        {
            GameObject.Find(bc.CurrentBeat).SetActive(false);
            FindObjectOfType<Score>().score += 200;
            FindObjectOfType<Streak>().streak += 1;
            bc.Presswindow = false;

        }
        else
        {
            FindObjectOfType<Streak>().streak = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            if (bc.Presswindow == true)
            {
                GameObject.Find(bc.CurrentBeat).SetActive(false);
                FindObjectOfType<Score>().score += 200;
                FindObjectOfType<Streak>().streak += 1;
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
}
