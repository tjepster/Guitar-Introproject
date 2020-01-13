using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LevelEditor : MonoBehaviour
{
    public GameObject YellowPrefab;
    public GameObject RedPrefab;
    public GameObject BluePrefab;
    public GameObject ContentView;
    public GameObject AudioBar;
    public GameObject InputField;
    public AudioSource song;

    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator ImportAudio(string songlocation, AudioSource audiosource) {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(songlocation, AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audiosource.clip = DownloadHandlerAudioClip.GetContent(www);
                float songlength = audiosource.clip.length;
                SetWidth(songlength);
            }
        }
       }

    void SetWidth(float songlength) {
        RectTransform rt = ContentView.GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(songlength * 120 - 648, rt.offsetMax.y);
    }

    public void OnEditorClick() {
        Vector3 vector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -1);
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(vector3);
        if (mouseposition.x < 0.95 && mouseposition.x > -0.63)
        {
            if (mouseposition.y > 0.45 && mouseposition.y < 0.79)
            {
                Debug.Log(1);
            }
            else if (mouseposition.y > 0.81 && mouseposition.y < 1.14)
            {
                Debug.Log(2);
            }
            else if (mouseposition.y > 1.165 && mouseposition.y < 1.52)
            {
                Debug.Log(3);
            }
        }
    }

    public void AddAudio() {
        string songlocation = InputField.GetComponent<TMP_InputField>().text;
        StartCoroutine(ImportAudio(songlocation,song));

    }
}
