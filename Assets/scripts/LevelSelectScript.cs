using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelectScript : MonoBehaviour
{
    public GameObject myPrefab;
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
                if(File.Exists(dir + "/level.txt"))
                {
                    string dir2 = dir.Replace(Application.dataPath + "/levels\\", "");
                    GameObject button = Instantiate(myPrefab, new Vector3(transform.position.x, transform.position.y + posy, transform.position.z), Quaternion.identity, transform);
                    button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(dir2);
                    button.GetComponent<Button>().onClick.AddListener(() => PlayLevel(dir2));
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
