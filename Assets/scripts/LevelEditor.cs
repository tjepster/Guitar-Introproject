using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelEditor : MonoBehaviour
{
    public GameObject YellowPrefab;
    public GameObject RedPrefab;
    public GameObject BluePrefab;
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
            }
        }
        audiosource.Play();
    }

    public void OnEditorClick() {

    }
    
}
