
using UnityEngine;

public class BeatCollision : MonoBehaviour
{
    public bool Presswindow;
    public string CurrentBeat;
    private void OnTriggerEnter(Collider colliderinfo)
    {
        CurrentBeat = colliderinfo.gameObject.name;
        if (colliderinfo.gameObject.tag == "Beat")
        {
            Presswindow = true;
        }
    }
    private void OnTriggerExit(Collider colliderinfo)
    {
        if (colliderinfo.gameObject.tag == "Beat")
        {
            Presswindow = false;
        }
    }
}
