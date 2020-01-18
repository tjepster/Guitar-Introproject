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
    public GameObject Viewport;
    public GameObject Canvas;
    public GameObject AudioBar;
    public GameObject AudioLine;
    public GameObject InputField;
    public GameObject scrollbar;
    public GameObject YellowButton;
    public GameObject RedButton;
    public GameObject BlueButton;

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

    private void SetWidth(float songlength) {
        RectTransform rt = ContentView.GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(songlength * 120 - 648, rt.offsetMax.y);
    }

    public void OnYellowClick() 
    {
        OnContentClick(1);

    }

    public void OnRedClick()
    {
        OnContentClick(2);

    }

    public void OnBlueClick()
    {
        OnContentClick(3);
    }

    private void OnContentClick(int colour)
    {
        float mousepos = (ContentView.GetComponent<RectTransform>().rect.size.x - Viewport.GetComponent<RectTransform>().rect.size.x) * scrollbar.GetComponent<Scrollbar>().value + 1.15f * (Input.mousePosition.x - Viewport.transform.position.x);
        int left = (int)mousepos / 120;
        left *= 120;
        if (colour == 1)
        {
            GameObject Circle = Instantiate(YellowPrefab, new Vector3(0, 0, YellowButton.transform.position.z), Quaternion.identity, YellowButton.transform);
            Circle.GetComponent<RectTransform>().offsetMax = new Vector2((-(ContentView.GetComponent<RectTransform>().rect.size.x - left - 60)), 0);
            Circle.GetComponent<RectTransform>().offsetMin = new Vector2(left - 60, 0);
        }
        else if (colour == 2)
        {
            GameObject Circle = Instantiate(RedPrefab, new Vector3(0, 0, RedButton.transform.position.z), Quaternion.identity, RedButton.transform);
            Circle.GetComponent<RectTransform>().offsetMax = new Vector2((-(ContentView.GetComponent<RectTransform>().rect.size.x - left - 60)), 0);
            Circle.GetComponent<RectTransform>().offsetMin = new Vector2(left - 60, 0);
        }
        else if (colour == 3)
        {
            GameObject Circle = Instantiate(BluePrefab, new Vector3(0, 0, BlueButton.transform.position.z), Quaternion.identity, BlueButton.transform);
            Circle.GetComponent<RectTransform>().offsetMax = new Vector2((-(ContentView.GetComponent<RectTransform>().rect.size.x - left - 60)), 0);
            Circle.GetComponent<RectTransform>().offsetMin = new Vector2(left - 60, 0);
        }
       
    }
    public void AddAudio() {
        string songlocation = InputField.GetComponent<TMP_InputField>().text;
        StartCoroutine(ImportAudio(songlocation,song));

    }

    public void PlayAudio()
    { song.Play(); }

    public void PauseAudio()
    { song.Pause(); }

    private void Update()
    {
        if (song.isPlaying)
        {
            AudioLine.GetComponent<RectTransform>().localPosition = new Vector2(song.time * 120, AudioLine.GetComponent<RectTransform>().localPosition.y) ;
        }
    }
}
