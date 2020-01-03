
using UnityEngine;

public class BeatCollision : MonoBehaviour
{
    // variables to indacate the current beat and if it is at the right position to be pressed
    public bool Presswindow;
    public GameObject CurrentBeat;

    // When a beat enters the trigger (Player + colour) it becomes pressable
    private void OnTriggerEnter(Collider colliderinfo)
    {
        CurrentBeat = colliderinfo.gameObject;
        if (colliderinfo.gameObject.tag == "BeatY" || colliderinfo.gameObject.tag == "BeatR" || colliderinfo.gameObject.tag == "BeatB")
        {
            Presswindow = true;
        }
    }

    // When a beat exits the trigger (Player + colour) it becomes impressable
    // It also resets the streak since a beat is missed
    private void OnTriggerExit(Collider colliderinfo)
    {
        if (colliderinfo.gameObject.tag == "BeatY" || colliderinfo.gameObject.tag == "BeatR" || colliderinfo.gameObject.tag == "BeatB")
        {
            Presswindow = false;
            FindObjectOfType<Streak>().streak = 0;
        }
    }
}
