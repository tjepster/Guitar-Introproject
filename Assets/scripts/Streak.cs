using UnityEngine;
using UnityEngine.UI;

public class Streak : MonoBehaviour
{
    public int streak;
    public Text StreakText;
    void Update()
    {
        string sttext = "Streak " + streak.ToString();
        StreakText.text = sttext;
    }
}
