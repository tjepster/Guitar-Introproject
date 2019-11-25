using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerAction playerRed, playerBlue, playerYellow;
    public Text Scoretext;
    public Streak streak;
    int LocalStreak;
    
    void Update()
    {
        if (streak.streak == 0)
        {
            LocalStreak = 1;
        }
        else
        {
            LocalStreak = streak.streak;
        }
        int localScore = (playerBlue.LocalScore + playerRed.LocalScore + playerYellow.LocalScore) * LocalStreak;
        string sctext = "Score " + localScore.ToString();


        Scoretext.text = sctext;
    }
}
