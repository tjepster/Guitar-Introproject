using UnityEngine;

public class GuitarEnd : MonoBehaviour
{
    // This method erases beats that were missed
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Beat") 
        {
            collision.gameObject.SetActive(false);
        }
    }
}
