using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class ScoreSetGet : MonoBehaviour
{
    public GameObject Highscoretext;
    public GameObject Highscorescore;
    public GameObject Parent;
    private string secretKey = "b393AqP2jNAaJdojkKLs2Jd24i4oJ5Z3k";
    public string addScoreURL = "https://www.cdprojektblue.com/scores/addscores.php";
    public string highscoreURL = "https://www.cdprojektblue.com/scores/getscores.php";

    void Start()
    {
        StartCoroutine(GetScores(""));
    }

    IEnumerator PostScores(string name, int score, string level)
    {
        //This connects to a server side php script that will add the name, score and level to a MySQL DB.
        // Supply it with a string representing the players name, players score and level.
        string hash = Md5Sum(name + score + level + secretKey);

        string post_url = addScoreURL + "?name=" + UnityWebRequest.EscapeURL(name) + "&score=" + score + "&level=" + level + "&hash=" + hash;

        // Post the URL to the site and create a download object to get the result.
        UnityWebRequest hs_post = UnityWebRequest.Get(post_url);
        yield return hs_post.SendWebRequest(); // Wait until the download is done

        if (hs_post.isNetworkError || hs_post.isHttpError)
        {
            Debug.Log(hs_post.error);
        }
    }
    bool executed = false;
    // Get the scores from the MySQL DB to display in a GUIText.
    public IEnumerator GetScores(string level)
    {
        if (executed == true)
        {
            DestroyHighscore();
        }
        else {
            executed = true;
        }
        level = level.Replace(' ', '_');
        string highscoreURL2 = highscoreURL + "?level=" + level;
        UnityWebRequest hs_get = UnityWebRequest.Get(highscoreURL2);
        yield return hs_get.SendWebRequest();
        if (hs_get.isNetworkError || hs_get.isHttpError)
        {
            Debug.Log(hs_get.error);
        }
        else
        {
            // Show results as text
            string result = hs_get.downloadHandler.text;
            string[] results = result.Split(new Char[] { '\n' , '\t'});
            int count = 0;
            int posy = -110;
            GameObject hi_text;
            foreach (string s in results)
            {
                if (count < 14)
                {
                    if (count % 2 == 0 && count != 0)
                    { posy -= 50; }
                    if (count % 2 == 0)
                    {
                        hi_text = Instantiate(Highscoretext, new Vector3(Parent.transform.position.x, Parent.transform.position.y, Parent.transform.position.z), Quaternion.identity, Parent.transform);
                    }
                    else
                    {
                        hi_text = Instantiate(Highscorescore, new Vector3(Parent.transform.position.x, Parent.transform.position.y, Parent.transform.position.z), Quaternion.identity, Parent.transform);
                    }
                    RectTransform hi_text_rect = hi_text.GetComponent<RectTransform>();
                    hi_text_rect.offsetMax = new Vector2(hi_text_rect.offsetMax.x, posy);
                    hi_text.GetComponent<TextMeshProUGUI>().SetText(s);
                    hi_text.tag = "Highscore";
                    count++;

                }
            }


        }
    }

    //Delete the highscores if they need to be replaced
    void DestroyHighscore() {
        GameObject[] hi_destroy;

        hi_destroy = GameObject.FindGameObjectsWithTag("Highscore");

        foreach (GameObject hi in hi_destroy)
        {
            Destroy(hi);
        }
    }


    public string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }
}
