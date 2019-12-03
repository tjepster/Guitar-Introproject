using UnityEngine;
using UnityEngine.UI;

public class Streak : MonoBehaviour
{
    public int streak;
    public Text StreakText;
    public int times = 1;
    void Update()
    {
        if (streak < 10)
        {
            times = 1;
            //FindObjectOfType<FireActive>().StopTheFire();
        }
        else if (streak >= 10 && streak < 20)
        {
            times = 2;
        }
        else if (streak >= 20 && streak < 30)
        {
            times = 3;
        }
        else if (streak >= 30)
        {
            times = 4;
            //FindObjectOfType<FireActive>().StartTheFire();
        }
        string sttext = "Streak " + streak.ToString();
        StreakText.text = sttext + System.Environment.NewLine + times.ToString() + "x";
    }
}
