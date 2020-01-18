using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject LevelLoader;
    bool Executed = false;
    // This script will instantiate the Prefab when the game starts and add text and an onclick event
    public void AddText()
    {
        if (Executed == false)
        {
            int posy = 80;
            string[] directories = Directory.GetDirectories(Application.dataPath + "/levels");
            foreach (string dir in directories)
            {
                if(File.Exists(dir + "/level.txt") && File.Exists(dir + "/song.wav"))
                {
                    //get name of level
                    string dir2 = dir.Replace(Application.dataPath + "/levels\\", "");

                    //create button
                    GameObject button = Instantiate(myPrefab, new Vector3(transform.position.x, transform.position.y + posy, transform.position.z), Quaternion.identity, transform);

                    //create levelloader
                    Instantiate(LevelLoader, new Vector3(0, 0, 0), Quaternion.identity);

                    //set the text of the button to the name of the level
                    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(dir2);

                    //add an onclick event to the button to play the level when the button is clicked
                    button.GetComponent<Button>().onClick.AddListener(() => PlayLevel(dir2));

                    //create eventtriggers for pointerenter and pointerexit for the button to display the highscores for the level when hovering over the button, 
                    //and displaying the main highscores when not hovering over the button anymore
                    EventTrigger.Entry eventtype = new EventTrigger.Entry();
                    eventtype.eventID = EventTriggerType.PointerEnter;
                    eventtype.callback.AddListener((eventData) => {StartCoroutine(gameObject.GetComponent<ScoreSetGet>().GetScores(dir2));});
                    EventTrigger.Entry eventtype2 = new EventTrigger.Entry();
                    eventtype2.eventID = EventTriggerType.PointerExit;
                    eventtype2.callback.AddListener((eventData) => { StartCoroutine(gameObject.GetComponent<ScoreSetGet>().GetScores("")); });

                    //add the eventtriggers to the button
                    button.AddComponent<EventTrigger>();
                    button.GetComponent<EventTrigger>().triggers.Add(eventtype);
                    button.GetComponent<EventTrigger>().triggers.Add(eventtype2);

                    posy -= 50;
                }
            }
            Executed = true;
        }
    }
    public void PlayLevel(string level)
    {
        PlayerPrefs.SetString("currentLevel", level);
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
