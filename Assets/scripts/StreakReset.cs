using UnityEngine;

public class StreakReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Beat")
        {
            FindObjectOfType<Streak>().streak = 0;
        }
    }
}
