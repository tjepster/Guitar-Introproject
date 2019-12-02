using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text Scoretext;
    public Streak streak;
    int OldScore = 0;
    
    void Update()
    {
        if (OldScore != score)
        {
            score *= streak.times;
            OldScore = score;
        }
        
        string sctext = "Score " + score.ToString();


        Scoretext.text = sctext;
    }
}
