using UnityEngine;

public class StreakReset : MonoBehaviour
{
    public Streak streak;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Beat")
        {
            streak.streak = 0;
        }
    }
}
